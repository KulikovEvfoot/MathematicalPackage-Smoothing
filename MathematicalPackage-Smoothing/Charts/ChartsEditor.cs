using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System.Collections.Generic;

namespace MathematicalPackage_Smoothing.Charts
{
    public class ChartsEditor
    {
        public void InputChart(float[] spline, float step)
        {
            ChartValues<ObservablePoint> charts = new ChartValues<ObservablePoint>();
            float x = 0;
            for (int i = 0; i < spline.Length; i++)
            {
                charts.Add(new ObservablePoint(x, spline[i]));
                x += step;
            }

            m_Line.Add(new LineSeries()
            {
                Values = charts,
                Fill = System.Windows.Media.Brushes.Transparent
            });
        }

        public void ShowSpline(LiveCharts.WinForms.CartesianChart cartesianChart)
        {
            cartesianChart.Series = new SeriesCollection();
            cartesianChart.Series.AddRange(m_Line);
        }

        private List<LineSeries> m_Line = new List<LineSeries>();
    }
}
