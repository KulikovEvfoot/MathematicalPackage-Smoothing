
namespace MathematicalPackage_Smoothing
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.FormMatrixButton = new MaterialSkin.Controls.MaterialButton();
            this.ChooseMatrixButton = new MaterialSkin.Controls.MaterialButton();
            this.MenuMaterialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MainCartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Doc = new MaterialSkin.Controls.MaterialButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.MenuMaterialTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuImageList
            // 
            this.MenuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MenuImageList.ImageStream")));
            this.MenuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MenuImageList.Images.SetKeyName(0, "icons8-spline-chart-64.png");
            this.MenuImageList.Images.SetKeyName(1, "icons8-matrix-desktop-50.png");
            this.MenuImageList.Images.SetKeyName(2, "icons8-microsoft-excel-50.png");
            this.MenuImageList.Images.SetKeyName(3, "icons8-info-50.png");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.ImageKey = "icons8-matrix-desktop-50.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1584, 762);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Matrix";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1584, 762);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("a_FuturaOrtoLt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(195)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("a_FuturaOrtoLt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(195)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 5);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1259, 752);
            this.dataGridView1.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.FormMatrixButton, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1271, 5);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(309, 752);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // FormMatrixButton
            // 
            this.FormMatrixButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormMatrixButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.FormMatrixButton.Depth = 0;
            this.FormMatrixButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormMatrixButton.HighEmphasis = true;
            this.FormMatrixButton.Icon = null;
            this.FormMatrixButton.Location = new System.Drawing.Point(6, 9);
            this.FormMatrixButton.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.FormMatrixButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.FormMatrixButton.Name = "FormMatrixButton";
            this.FormMatrixButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.FormMatrixButton.Size = new System.Drawing.Size(297, 57);
            this.FormMatrixButton.TabIndex = 2;
            this.FormMatrixButton.Text = "Form a matrix";
            this.FormMatrixButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.FormMatrixButton.UseAccentColor = false;
            this.FormMatrixButton.UseVisualStyleBackColor = true;
            this.FormMatrixButton.Click += new System.EventHandler(this.FormMatrixButton_Click);
            // 
            // ChooseMatrixButton
            // 
            this.ChooseMatrixButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChooseMatrixButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ChooseMatrixButton.Depth = 0;
            this.ChooseMatrixButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseMatrixButton.HighEmphasis = true;
            this.ChooseMatrixButton.Icon = null;
            this.ChooseMatrixButton.Location = new System.Drawing.Point(6, 9);
            this.ChooseMatrixButton.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.ChooseMatrixButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChooseMatrixButton.Name = "ChooseMatrixButton";
            this.ChooseMatrixButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ChooseMatrixButton.Size = new System.Drawing.Size(297, 57);
            this.ChooseMatrixButton.TabIndex = 1;
            this.ChooseMatrixButton.Text = "Choose Matrix";
            this.ChooseMatrixButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ChooseMatrixButton.UseAccentColor = false;
            this.ChooseMatrixButton.UseVisualStyleBackColor = true;
            // 
            // MenuMaterialTabControl
            // 
            this.MenuMaterialTabControl.Controls.Add(this.tabPage1);
            this.MenuMaterialTabControl.Controls.Add(this.tabPage2);
            this.MenuMaterialTabControl.Controls.Add(this.tabPage5);
            this.MenuMaterialTabControl.Controls.Add(this.tabPage3);
            this.MenuMaterialTabControl.Depth = 0;
            this.MenuMaterialTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuMaterialTabControl.ImageList = this.MenuImageList;
            this.MenuMaterialTabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MenuMaterialTabControl.Location = new System.Drawing.Point(4, 98);
            this.MenuMaterialTabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MenuMaterialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.MenuMaterialTabControl.Multiline = true;
            this.MenuMaterialTabControl.Name = "MenuMaterialTabControl";
            this.MenuMaterialTabControl.SelectedIndex = 0;
            this.MenuMaterialTabControl.Size = new System.Drawing.Size(1592, 797);
            this.MenuMaterialTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.ImageKey = "icons8-spline-chart-64.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1584, 762);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "Smoothing";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.MainCartesianChart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1584, 762);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // MainCartesianChart
            // 
            this.MainCartesianChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainCartesianChart.Location = new System.Drawing.Point(4, 5);
            this.MainCartesianChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainCartesianChart.Name = "MainCartesianChart";
            this.MainCartesianChart.Size = new System.Drawing.Size(1259, 752);
            this.MainCartesianChart.TabIndex = 0;
            this.MainCartesianChart.Text = "cartesianChart1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ChooseMatrixButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.materialButton1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1271, 5);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(309, 752);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage5.Controls.Add(this.tableLayoutPanel1);
            this.tabPage5.ImageKey = "icons8-microsoft-excel-50.png";
            this.tabPage5.Location = new System.Drawing.Point(4, 31);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1334, 785);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Spline";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1334, 785);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(4, 5);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1059, 775);
            this.dataGridView2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.Doc, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1071, 5);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(259, 775);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // Doc
            // 
            this.Doc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Doc.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Doc.Depth = 0;
            this.Doc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Doc.HighEmphasis = true;
            this.Doc.Icon = null;
            this.Doc.Location = new System.Drawing.Point(6, 9);
            this.Doc.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.Doc.MouseState = MaterialSkin.MouseState.HOVER;
            this.Doc.Name = "Doc";
            this.Doc.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Doc.Size = new System.Drawing.Size(247, 59);
            this.Doc.TabIndex = 3;
            this.Doc.Text = "doc";
            this.Doc.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Doc.UseAccentColor = false;
            this.Doc.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage3.ImageKey = "icons8-info-50.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1334, 785);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Informaion";
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(6, 84);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(297, 57);
            this.materialButton1.TabIndex = 3;
            this.materialButton1.Text = "Form a matrix";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.MenuMaterialTabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.MenuMaterialTabControl;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4, 98, 4, 5);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.MenuMaterialTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList MenuImageList;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private MaterialSkin.Controls.MaterialButton FormMatrixButton;
        private MaterialSkin.Controls.MaterialButton ChooseMatrixButton;
        private MaterialSkin.Controls.MaterialTabControl MenuMaterialTabControl;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private LiveCharts.WinForms.CartesianChart MainCartesianChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialButton Doc;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}

