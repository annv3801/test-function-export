using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestFunctionExport.Database;

namespace TestFunctionExport
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=2223;Database=vf_binning_phase_2_backup;Username=postgres;Password=VOIsJ14I563t3dSZqs7c"));
            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            Functions functions = new Functions(dbContext);
            await functions.ExportExcel();
        }
    }

}
