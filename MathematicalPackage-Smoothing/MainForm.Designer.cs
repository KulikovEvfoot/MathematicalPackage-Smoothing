
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
            this.MenuMaterialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ChooseExcelButton = new MaterialSkin.Controls.MaterialButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DocumentsDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.OpenExcelButton = new MaterialSkin.Controls.MaterialButton();
            this.DocunetPanel = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.MenuMaterialTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsDataGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMaterialTabControl
            // 
            this.MenuMaterialTabControl.Controls.Add(this.tabPage1);
            this.MenuMaterialTabControl.Controls.Add(this.tabPage2);
            this.MenuMaterialTabControl.Controls.Add(this.tabPage3);
            this.MenuMaterialTabControl.Depth = 0;
            this.MenuMaterialTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuMaterialTabControl.ImageList = this.MenuImageList;
            this.MenuMaterialTabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MenuMaterialTabControl.Location = new System.Drawing.Point(3, 64);
            this.MenuMaterialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.MenuMaterialTabControl.Multiline = true;
            this.MenuMaterialTabControl.Name = "MenuMaterialTabControl";
            this.MenuMaterialTabControl.SelectedIndex = 0;
            this.MenuMaterialTabControl.Size = new System.Drawing.Size(894, 533);
            this.MenuMaterialTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.ImageKey = "icons8-calculator-50.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(886, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Smoothing";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.cartesianChart1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(880, 492);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(3, 3);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(698, 486);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.ChooseExcelButton, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(707, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(170, 486);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // ChooseExcelButton
            // 
            this.ChooseExcelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChooseExcelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ChooseExcelButton.Depth = 0;
            this.ChooseExcelButton.HighEmphasis = true;
            this.ChooseExcelButton.Icon = null;
            this.ChooseExcelButton.Location = new System.Drawing.Point(4, 6);
            this.ChooseExcelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ChooseExcelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChooseExcelButton.Name = "ChooseExcelButton";
            this.ChooseExcelButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ChooseExcelButton.Size = new System.Drawing.Size(162, 36);
            this.ChooseExcelButton.TabIndex = 1;
            this.ChooseExcelButton.Text = "Choose Excel Document";
            this.ChooseExcelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ChooseExcelButton.UseAccentColor = false;
            this.ChooseExcelButton.UseVisualStyleBackColor = true;
            this.ChooseExcelButton.Click += new System.EventHandler(this.ChooseExcelButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.ImageKey = "icons8-microsoft-excel-50.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(886, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Documents";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.DocumentsDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(880, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DocumentsDataGridView
            // 
            this.DocumentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DocumentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.DocumentsDataGridView.Name = "DocumentsDataGridView";
            this.DocumentsDataGridView.Size = new System.Drawing.Size(698, 486);
            this.DocumentsDataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.OpenExcelButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DocunetPanel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(707, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(170, 486);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // OpenExcelButton
            // 
            this.OpenExcelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenExcelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.OpenExcelButton.Depth = 0;
            this.OpenExcelButton.HighEmphasis = true;
            this.OpenExcelButton.Icon = null;
            this.OpenExcelButton.Location = new System.Drawing.Point(4, 6);
            this.OpenExcelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OpenExcelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.OpenExcelButton.Name = "OpenExcelButton";
            this.OpenExcelButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.OpenExcelButton.Size = new System.Drawing.Size(162, 36);
            this.OpenExcelButton.TabIndex = 0;
            this.OpenExcelButton.Text = "Open Excel Document";
            this.OpenExcelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.OpenExcelButton.UseAccentColor = false;
            this.OpenExcelButton.UseVisualStyleBackColor = true;
            // 
            // DocunetPanel
            // 
            this.DocunetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocunetPanel.Location = new System.Drawing.Point(3, 51);
            this.DocunetPanel.Name = "DocunetPanel";
            this.DocunetPanel.Size = new System.Drawing.Size(164, 432);
            this.DocunetPanel.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage3.ImageKey = "icons8-info-50.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(886, 498);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Information";
            // 
            // MenuImageList
            // 
            this.MenuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MenuImageList.ImageStream")));
            this.MenuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MenuImageList.Images.SetKeyName(0, "icons8-calculator-50.png");
            this.MenuImageList.Images.SetKeyName(1, "icons8-microsoft-excel-50.png");
            this.MenuImageList.Images.SetKeyName(2, "icons8-info-50.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.MenuMaterialTabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.MenuMaterialTabControl;
            this.Name = "MainForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuMaterialTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsDataGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MenuMaterialTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList MenuImageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DocumentsDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton OpenExcelButton;
        private System.Windows.Forms.Panel DocunetPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialButton ChooseExcelButton;
    }
}

