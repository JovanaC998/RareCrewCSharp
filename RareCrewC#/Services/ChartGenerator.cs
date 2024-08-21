using OxyPlot;
using OxyPlot.Series;
using OxyPlot.SkiaSharp;
using RareCrewC_.Models;
using System.Collections.Generic;
using System.IO;

namespace RareCrewC_.Services
{
    public class ChartGenerator
    {
        public void GeneratePieChart(string filePath, IEnumerable<GroupedEmployeeData> data)
        {
            var model = new PlotModel
            {
                Title = "Total time in month",
                TitleFontSize = 18,
                IsLegendVisible = true,
                TitleFont = "Arial Bold",
            };

            var pieSeries = new PieSeries
            {
                StrokeThickness = 0,
                Diameter = 0.9,
                AngleSpan = 360,
                StartAngle = 0,
                InsideLabelFormat = "{1}",
                AreInsideLabelsAngled = false,
                LegendFormat = "{0}",
            };

            foreach (var item in data)
            {
                pieSeries.Slices.Add(new PieSlice(item.EmployeeName, item.Percentage));
            }

            model.Series.Add(pieSeries);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var pngExporter = new PngExporter { Width = 800, Height = 500 };
                pngExporter.Export(model, stream);
            }
        }
    }
}