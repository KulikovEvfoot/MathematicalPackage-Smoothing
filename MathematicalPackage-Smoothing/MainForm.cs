using System;
using MaterialSkin.Controls;
using MathematicalPackage_Smoothing.Design;
using MathematicalPackage_Smoothing.FileHelper;
using MathematicalPackage_Smoothing.Charts;
using MathematicalPackage_Smoothing.Caclulations.SplineCoefficients;
using MathematicalPackage_Smoothing.Caclulations;
using MathematicalPackage_Smoothing.Caclulations.SmoothingParameter;
using System.Drawing;
using System.Drawing.Imaging;

namespace MathematicalPackage_Smoothing
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var formDesigner = new FormDesigner();
            DisableAllPanels();
            InitComboboxes();
        }

        private void DisableAllPanels()
        {
            BoundaryConditionsPanel.Enabled = false;
            SmoothingParameterPanel.Enabled = false;
            SubstitutionAPanel.Enabled = false;
            CalculateAPanel.Enabled = false;
            DsPanel.Enabled = false;
            CalculateSplinePanel.Enabled = false;
            SaveSplinePanel.Enabled = false;
            ChartsPanel.Enabled = false;
            ShowChartsPanel.Enabled = false;
            SaveChartPanel.Enabled = false;
            ClearFields();
        }

        private void EnableIfFileSelected()
        {
            BoundaryConditionsPanel.Enabled = true;
            SmoothingParameterPanel.Enabled = true;
            CalculateSplinePanel.Enabled = true;
            DsPanel.Enabled = true;
        }

        private void EnableCharts()
        {
            ChartsPanel.Enabled = true;
            ShowChartsPanel.Enabled = true;
        }

        private void InitComboboxes()
        {
            string[] output = new string[3] { m_Type_1, m_Type_2 , m_Type_2_0 };
            LeftComboBox.Items.AddRange(output);
            RightComboBox.Items.AddRange(output);
        }

        private bool VerificationSpecifiedData()
        {
            string errors = "";
            if (LeftComboBox.Text.Trim() == "")
            {
                errors += "The 'left' edge condition is not filled in! \n";
            }
            if (RightComboBox.Text.Trim() == "")
            {
                errors += "The 'right' edge condition is not filled in! \n";
            }
            if (!SubstitutionRadioButton.Checked && !CalculateRadioButton.Checked)
            {
                errors += "The 'smoothing parameter' is not specified! \n";
            }
            if (SubstitutionRadioButton.Checked)
            {
                if (SubstitutionATextBox.Text.Trim() == "")
                {
                    errors += "Field 'substitution' must be filled in! \n";
                }
                if (!float.TryParse(SubstitutionATextBox.Text.Trim(), out float result))
                {
                    errors += "The 'substitution' field is filled in incorrectly! \n";
                }
            }
            if (CalculateRadioButton.Checked)
            {
                if (MinATextBox.Text.Trim() == "")
                {
                    errors += "Field 'min' must be filled in! \n";
                }
                else if (!float.TryParse(MinATextBox.Text, out float result))
                {
                    errors += "The 'min' field is filled in incorrectly! \n";
                }
                if (MaxATextBox.Text.Trim() == "")
                {
                    errors += "Field 'max' must be filled in! \n";
                }
                else if (!float.TryParse(MaxATextBox.Text, out float result))
                {
                    errors += "The 'max' field is filled in incorrectly! \n";
                }
            }
            if (LeftComboBox.Text.Trim() == m_Type_1)
            {
                if (Ds1TextBox.Text.Trim() == "")
                {
                    errors += "Field 'first derivative' must be filled in! \n";
                }
                else if (!float.TryParse(Ds1TextBox.Text, out float result))
                {
                    errors += "The 'first derivative' field is filled in incorrectly! \n";
                }
            }
            if (RightComboBox.Text.Trim() == m_Type_1)
            {
                if (Ds2TextBox.Text.Trim() == "")
                {
                    errors += "Field 'last derivative' must be filled in! \n";
                }
                else if (!float.TryParse(Ds2TextBox.Text, out float result))
                {
                    errors += "The 'last derivative' field is filled in incorrectly! \n";
                }
            }

            if (errors == "")
            {
                return true;
            }
            else
            {
                MaterialMessageBox.Show(errors);
                return false;
            }
            
        }

        private BoundaryConditions CheckTypeOfConditions(string text)
        {
            if (text == m_Type_1)
            {
                return BoundaryConditions.Type_1;
            }
            else if (text == m_Type_2)
            {
                return BoundaryConditions.Type_2;
            }
            else
            {
                return BoundaryConditions.Type_2_0;
            }
        }

        private bool FillSplineParameters()
        {
            if (InputDataGridView.Rows.Count == 0)
            {
                return false;
            }

            m_N = InputDataGridView.Rows.Count;
            m_X = new float[m_N];
            m_P = new float[m_N];
            m_F = new float[m_N];
            try
            {
                for (int i = 0; i < m_N; i++)
                {
                    m_X[i] += Convert.ToSingle(InputDataGridView.Rows[i].Cells[1].Value);
                    m_P[i] += Convert.ToSingle(InputDataGridView.Rows[i].Cells[2].Value);
                    m_F[i] += Convert.ToSingle(InputDataGridView.Rows[i].Cells[3].Value);
                }
                return true;
            }
            catch (Exception)
            {
                MaterialMessageBox.Show("The data in the original document is incorrect");
                return false;
            }
        }

        private float InitDs1()
        {
            if (LeftComboBox.Text.Trim() == m_Type_1)
            {
                return Convert.ToSingle(Ds1TextBox.Text);
            }
            else return 0;        
        }

        private float InitDs2()
        {
            if (RightComboBox.Text.Trim() == m_Type_1)
            {
                return Convert.ToSingle(Ds2TextBox.Text);
            }
            else return 0;
        }

        private float InitMinA()
        {
            if (CalculateRadioButton.Checked)
            {
                return Convert.ToSingle(MinATextBox.Text);
            }
            else return 0;
        }

        private float InitMaxA()
        {
            if (CalculateRadioButton.Checked)
            {
                return Convert.ToSingle(MaxATextBox.Text);
            }
            else return 0;
        }

        private float InitA()
        {
            float a;
            if (SubstitutionRadioButton.Checked)
            {
                a = Convert.ToSingle(SubstitutionATextBox.Text);
            }
            else
            {
                CalculateA calculateA = new CalculateA(m_N, m_X);
                a = calculateA.InitALCurve(
                    m_N,
                    m_X,
                    m_P,
                    m_F,
                    m_MinA,
                    m_MaxA,
                    m_Ds1,
                    m_Ds2,
                    m_LeftType,
                    m_RightType);
            }

            return a;
        }

        private void ShowSmoothSpline()
        {
            ProcessedDataGridView.Columns.Clear();
            ProcessedDataGridView.Columns.Add("X", "X");
            ProcessedDataGridView.Columns.Add("F", "F");
            ProcessedDataGridView.Columns.Add("Fn", "Fn");
            for (int i = 0; i < m_X.Length; i++)
            {
                ProcessedDataGridView.Rows.Add(m_X[i]);
                ProcessedDataGridView.Rows[i].Cells[1].Value = m_F[i];
                ProcessedDataGridView.Rows[i].Cells[2].Value = m_Spline[i];
            }

            if (CalculateRadioButton.Checked)
            {
                FoundValueTextBox.Text = m_A.ToString();
            }
        }

        private bool CalculatingSpline()
        {
            m_LeftType = CheckTypeOfConditions(LeftComboBox.Text);
            m_RightType = CheckTypeOfConditions(RightComboBox.Text);

            m_Ds1 = InitDs1();
            m_Ds2 = InitDs2();

            m_MinA = InitMinA();
            m_MaxA = InitMaxA();

            try
            {
                m_A = InitA();

                CalculateSpline calculateSpline = new CalculateSpline(m_N, m_X);
                m_Spline = calculateSpline.InitSplineX(
                    m_N,
                    m_X,
                    m_P,
                    m_F,
                    m_A,
                    m_Ds1,
                    m_Ds2,
                    m_LeftType,
                    m_RightType);

                m_D1Spline = calculateSpline.InitD1SplineX(
                    m_N,
                    m_X,
                    m_P,
                    m_F,
                    m_A,
                    m_Ds1,
                    m_Ds2,
                    m_LeftType,
                    m_RightType);

                EnableCharts();
                return true;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Error in calculations");
                return false;
            }
        }

        private void UploadDataButton_Click(object sender, EventArgs e)
        {
            WindowOpener openFile = new WindowOpener();
            string filePath = openFile.OpenFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                using (CsvConnector csvOpen = new CsvConnector())
                {
                    InputDataGridView = csvOpen.PullData(filePath, InputDataGridView);
                }

                ProcessedDataGridView.Columns.Clear();
                if (FillSplineParameters())
                {
                    EnableIfFileSelected();
                }
                else
                {
                    InputDataGridView.Columns.Clear();
                    DisableAllPanels();
                }
            }
        }

        private void SubstitutionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SubstitutionAPanel.Enabled = true;
            CalculateAPanel.Enabled = false;
            MinATextBox.Text = "";
            MaxATextBox.Text = "";
        }

        private void CalculateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SubstitutionAPanel.Enabled = false;
            CalculateAPanel.Enabled = true;
            SubstitutionATextBox.Text = "";
        }

        private void CalculateSplineButton_Click(object sender, EventArgs e)
        {
            if (VerificationSpecifiedData())
            {
                if (CalculatingSpline())
                {
                    ShowSmoothSpline();
                    SaveSplinePanel.Enabled = true;
                }
            }
        }

        private void SaveSplineButton_Click(object sender, EventArgs e)
        {
            WindowOpener saveFile = new WindowOpener();
            string filePath = saveFile.SaveFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                using (CsvConnector csvOpen = new CsvConnector())
                {
                    csvOpen.SaveCsvFile(filePath, ProcessedDataGridView, m_X, m_F, m_Spline);
                }
            }
        }

        private void ShowChartsButton_Click(object sender, EventArgs e)
        {
            ChartsEditor chartsEditor = new ChartsEditor();

            if (OriginalCheckbox.Checked)
            {
                chartsEditor.InputChart(m_F, m_X, "Original", System.Windows.Media.Brushes.Blue);
            }
            if (SmoothedCheckbox.Checked)
            {
                chartsEditor.InputChart(m_Spline, m_X, "Smoothing", System.Windows.Media.Brushes.Red);
            }
            if (DerivativeCheckbox.Checked)
            {
                chartsEditor.InputChart(m_D1Spline, m_X, "Derivative", System.Windows.Media.Brushes.Orange);
            }

            chartsEditor.ShowSpline(MainCartesianChart);

            SaveChartPanel.Enabled = true;
        }

        private void SaveChartButton_Click(object sender, EventArgs e)
        {
            WindowOpener saveFile = new WindowOpener();
            string filePath = saveFile.SavePngFile();
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            Bitmap bmp = new Bitmap(MainCartesianChart.Width, MainCartesianChart.Height);
            MainCartesianChart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(filePath, ImageFormat.Png);
        }


        private void ClearFields()
        {
            SubstitutionATextBox.Clear();
            MinATextBox.Clear();
            MaxATextBox.Clear();
            Ds1TextBox.Clear();
            Ds2TextBox.Clear();
            FoundValueTextBox.Clear();
            SubstitutionRadioButton.Checked = false;
            CalculateRadioButton.Checked = false;
            OriginalCheckbox.Checked = false;
            SmoothedCheckbox.Checked = false;
            DerivativeCheckbox.Checked = false;
            MainCartesianChart.Series.Clear();
        }

        private int m_N;
        private float[] m_X;
        private float[] m_P;
        private float[] m_F;

        private float m_MinA;
        private float m_MaxA;

        private float m_Ds1;
        private float m_Ds2;

        private BoundaryConditions m_LeftType;
        private BoundaryConditions m_RightType;

        private float m_A;

        private float[] m_Spline;
        private float[] m_D1Spline;

        private string m_Type_1 = "Type 1";
        private string m_Type_2 = "Type 2";
        private string m_Type_2_0 = "Type 2.0";

        private void MainForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
        }
    }
}
