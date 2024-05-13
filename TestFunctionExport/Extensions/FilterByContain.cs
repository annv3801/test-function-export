using System.Linq.Expressions;
using ExportExcel.Models;

namespace ExportExcel.Extensions;

public static class FilterByContain
{
    public static IQueryable<T> Filter<T>(this IQueryable<T> source, IEnumerable<FilterModel> filterModels)
    {
        var groupedFilters = filterModels
            .GroupBy(f => f.FilterFieldName)
            .Where(g => g.All(item => item.FilterValue != null));

        var parameter = Expression.Parameter(typeof(T), "item");
        List<Expression> groupExpressions = new List<Expression>();

        foreach (var group in groupedFilters)
        {
            var orExpressions = new List<Expression>();

            foreach (var filterModel in group)
            {
                var memberSelector = filterModel.FilterFieldName.Split('.').Aggregate((Expression)parameter, Expression.PropertyOrField);
                var memberType = memberSelector.Type;
                var value = filterModel.FilterValue;

                // Cast value to type of Member
                if (value != null && value.GetType() != memberType)
                    value = (string)Convert.ChangeType(value, memberType);

                // Get the method Contains of string type
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                if (containsMethod == null)
                    return source;

                // Convert value into expression contains
                var constantExpressionValue = Expression.Constant(value, typeof(string));

                // To lower case both sides
                var toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
                if (toLowerMethod == null)
                    return source;

                var toLowerLeftSideExp = Expression.Call(memberSelector, toLowerMethod);
                var toLowerRightSideExp = Expression.Call(constantExpressionValue, toLowerMethod);

                // Add left side and right side --> item.Name.ToLower().Contains("Delete".ToLower())
                var expression = Expression.Call(toLowerLeftSideExp, containsMethod, toLowerRightSideExp);
                orExpressions.Add(expression);
            }

            if (orExpressions.Any())
            {
                var orCombinedExpression = orExpressions.Aggregate(Expression.OrElse);
                groupExpressions.Add(orCombinedExpression);
            }
        }

        if (groupExpressions.Any())
        {
            // Combine all group expressions with AND
            var andCombinedExpression = groupExpressions.Aggregate(Expression.AndAlso);

            // Build the predicate --> item => ((item.Name.ToLower().Contains("Delete".ToLower()) OR item.Category.ToLower().Contains("Delete".ToLower())) AND ...)
            var predicate = Expression.Lambda<Func<T, bool>>(andCombinedExpression, parameter);

            // Add to the where method
            return source.Where(predicate);
        }

        return source;
    }

}