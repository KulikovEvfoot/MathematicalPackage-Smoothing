using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System.Collections.Generic;
using System.Windows.Media;

namespace MathematicalPackage_Smoothing.Charts
{
    public class ChartsEditor
    {
        public void InputChart(float[] spline, float[] steps, string legend)
        {
            ChartValues<ObservablePoint> charts = new ChartValues<ObservablePoint>();
            for (int i = 0; i < spline.Length; i++)
            {
                charts.Add(new ObservablePoint(steps[i], spline[i]));
            }

            m_Line.Add(new LineSeries()
            {
                Title = legend,
                Values = charts,
                Fill = Brushes.Transparent
            });
        }

        public void ShowSpline(LiveCharts.WinForms.CartesianChart cartesianChart)
        {
            cartesianChart.Series = new SeriesCollection();
            cartesianChart.LegendLocation = LegendLocation.Top;
            cartesianChart.DefaultLegend.FontSize = 18;
            cartesianChart.DefaultLegend.Visibility = System.Windows.Visibility.Visible;
            cartesianChart.Series.AddRange(m_Line);
        }

        private List<LineSeries> m_Line = new List<LineSeries>();
    }
}
