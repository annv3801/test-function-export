﻿using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using TestFunctionExport.Database;

public class Functions
{
    private ApplicationDbContext _context;

    public Functions(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> ExportExcel()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Bangkok"); // +07:00
        try
        {
            const int batchSize = 10000;
            var offset = 0;
            var stt = 1;
            var keyName = "";
            var tempFilePath = Path.Combine("D:/", "tempExcelFile1.xlsx");
            using (var spreadsheet = SpreadsheetDocument.Create(tempFilePath, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = spreadsheet.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                var sheets = spreadsheet.WorkbookPart?.Workbook.AppendChild(new Sheets());
                sheets.AppendChild(new Sheet()
                {
                    Id = spreadsheet.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"
                });
                var stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                var stylesheet = new Stylesheet();

// Create a Fonts object
                Fonts fonts = new Fonts();
                Font font = new Font(); // Default font
                fonts.Append(font);
                Font whiteFont = new Font(); // White font
                whiteFont.Append(new Color() { Rgb = new HexBinaryValue() { Value = "FFFFFF" } });
                whiteFont.Append(new FontSize() { Val = 18 }); // Set font size to 24
                fonts.Append(whiteFont);

                Fills fills = new Fills();
                Fill fill = new Fill(); // Default fill
                fills.Append(fill);
                Fill systemFill = new Fill(); // System fill
                fills.Append(systemFill);
                Fill redFill = new Fill(new PatternFill(new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FF0000" } }) { PatternType = PatternValues.Solid }); // Orange fill
                fills.Append(redFill);
                Fill orangeFill = new Fill(new PatternFill(new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFA500" } }) { PatternType = PatternValues.Solid }); // Orange fill
                fills.Append(orangeFill);
                Fill greenFill = new Fill(new PatternFill(new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "008000" } }) { PatternType = PatternValues.Solid }); // Green fill
                fills.Append(greenFill);

                Borders borders = new Borders();
                Border border = new Border(); // Default border
                borders.Append(border);

                CellFormats cellFormats = new CellFormats();
                CellFormat defaultFormat = new CellFormat(); // Default cell format
                cellFormats.Append(defaultFormat);
                CellFormat redFormat1 = new CellFormat() { FillId = 2, BorderId = 0, ApplyFill = true }; // Red cell format
                cellFormats.Append(redFormat1);
                CellFormat greenFormat1 = new CellFormat() { FillId = 4, BorderId = 0, ApplyFill = true }; // Green cell format
                cellFormats.Append(greenFormat1);
                CellFormat orangeFormat = new CellFormat() { FontId = 1, FillId = 3, BorderId = 0, ApplyFill = true, Alignment = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center } }; // Orange cell format
                cellFormats.Append(orangeFormat);
                CellFormat greenFormat = new CellFormat() { FontId = 1, FillId = 4, BorderId = 0, ApplyFill = true, Alignment = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center } }; // Green cell format
                cellFormats.Append(greenFormat);

                stylesheet.Append(fonts);
                stylesheet.Append(fills);
                stylesheet.Append(borders);
                stylesheet.Append(cellFormats);

                uint redFormatIndex = (uint)cellFormats.ChildElements.Count - 2;
                uint greenFormatIndex = (uint)cellFormats.ChildElements.Count - 1;


                stylesPart.Stylesheet = stylesheet;
                stylesPart.Stylesheet.Save();
                using (var writer = OpenXmlWriter.Create(worksheetPart))
                {
                    writer.WriteStartElement(new Worksheet());
                    writer.WriteStartElement(new SheetData());

                    // Write the cell with the value "Trouble Code Old" at A1 and "Trouble Code New" at J1
                    writer.WriteStartElement(new Row());
                    var cellOld = new Cell { DataType = CellValues.String, CellValue = new CellValue("Trouble Code Old"), StyleIndex = redFormatIndex };
                    writer.WriteElement(cellOld);
                    for (int i = 1; i <= 8; i++) // Skip cells until J
                    {
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(string.Empty) });
                    }
                    var cellNew = new Cell { DataType = CellValues.String, CellValue = new CellValue("Trouble Code New"), StyleIndex = greenFormatIndex };
                    writer.WriteElement(cellNew);
                    writer.WriteEndElement(); // End of Row

                    writer.WriteStartElement(new Row { RowIndex = 3 });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("Combined Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("Vrt Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("VRT Name") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("VFG Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("VFG Name") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("CTC Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("CTC Name") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("Note") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("Combined Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("Vrt Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("VRT Name") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("VFG Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("VFG Name") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("CTC Code") });
                    writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("CTC Name") });
                    writer.WriteEndElement();
                    var code = await _context.CccCodeComparisons.ToListAsync();
                    UInt32Value? row = 3;
                    foreach (var item in code)
                    {
                        row++;
                        writer.WriteStartElement(new Row { RowIndex = row });
                        var oldStyleVrtCodeIndex = item.VrtCodeValueOld == item.VrtCodeValueNew ? (uint?)null : 1U;
                        var newStyleVrtCodeIndex = item.VrtCodeValueOld == item.VrtCodeValueNew ? (uint?)null : 2U;
                        var oldStyleVrtCodeDescriptionIndex = item.VrtCodeDescriptionOld == item.VrtCodeDescriptionNew ? (uint?)null : 1U;
                        var newStyleVrtCodeDescriptionIndex = item.VrtCodeDescriptionOld == item.VrtCodeDescriptionNew ? (uint?)null : 2U;
                        var oldStyleVfgCodeIndex = item.VfgCodeValueOld == item.VfgCodeValueNew ? (uint?)null : 1U;
                        var newStyleVfgCodeIndex = item.VrtCodeValueOld == item.VfgCodeValueNew ? (uint?)null : 2U;
                        var oldStyleVfgCodeDescriptionIndex = item.VfgCodeDescriptionOld == item.VfgCodeDescriptionNew ? (uint?)null : 1U;
                        var newStyleVfgCodeDescriptionIndex = item.VfgCodeDescriptionOld == item.VfgCodeDescriptionNew ? (uint?)null : 2U;
                        var oldStyleCtcCodeIndex = item.CtcCodeValueOld == item.CtcCodeValueNew ? (uint?)null : 1U;
                        var newStyleCtcCodeIndex = item.CtcCodeValueOld == item.CtcCodeValueNew ? (uint?)null : 2U;
                        var oldStyleCtcCodeDescriptionIndex = item.CtcCodeDescriptionOld == item.CtcCodeDescriptionNew ? (uint?)null : 1U;
                        var newStyleCtcCodeDescriptionIndex = item.CtcCodeDescriptionOld == item.CtcCodeDescriptionNew ? (uint?)null : 2U;
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VrtCodeValueOld + (item.VfgCodeValueOld != null ? "_" + item.VfgCodeValueOld : string.Empty) + (item.CtcCodeValueOld != null ? "_" + item.CtcCodeValueOld : string.Empty)) });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VrtCodeValueOld ?? string.Empty), StyleIndex = oldStyleVrtCodeIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VrtCodeDescriptionOld ?? string.Empty), StyleIndex = oldStyleVrtCodeDescriptionIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VfgCodeValueOld ?? string.Empty), StyleIndex = oldStyleVfgCodeIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VfgCodeDescriptionOld ?? string.Empty), StyleIndex = oldStyleVfgCodeDescriptionIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.CtcCodeValueOld ?? string.Empty), StyleIndex = oldStyleCtcCodeIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.CtcCodeDescriptionOld ?? string.Empty), StyleIndex = oldStyleCtcCodeDescriptionIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("Note") });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue("") });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VrtCodeValueNew + (item.VfgCodeValueNew != null ? "_" + item.VfgCodeValueNew : string.Empty) + (item.CtcCodeValueNew != null ? "_" + item.CtcCodeValueNew : string.Empty)) });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VrtCodeValueNew ?? string.Empty), StyleIndex = newStyleVrtCodeIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VrtCodeDescriptionNew ?? string.Empty), StyleIndex = newStyleVrtCodeDescriptionIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VfgCodeValueNew ?? string.Empty), StyleIndex = newStyleVfgCodeIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.VfgCodeDescriptionNew ?? string.Empty), StyleIndex = newStyleVfgCodeDescriptionIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.CtcCodeValueNew ?? string.Empty), StyleIndex = newStyleCtcCodeIndex });
                        writer.WriteElement(new Cell { DataType = CellValues.String, CellValue = new CellValue(item.CtcCodeDescriptionNew ?? string.Empty), StyleIndex = newStyleCtcCodeDescriptionIndex });
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement(); // End of SheetData

                    // Merge cells from A1 to H2 and from J1 to P2
                    writer.WriteStartElement(new MergeCells());
                    writer.WriteElement(new MergeCell { Reference = new StringValue("A1:H2") });
                    writer.WriteElement(new MergeCell { Reference = new StringValue("J1:P2") });
                    writer.WriteEndElement(); // End of MergeCells

                    writer.WriteEndElement(); // End of Worksheet
                }

                workbookPart.Workbook.Save();
            }

            stopWatch.Stop();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

        return "ok";
    }
}