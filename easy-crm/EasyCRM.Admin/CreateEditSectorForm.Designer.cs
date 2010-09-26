namespace EasyCRM.Admin
{
    partial class CreateEditSectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEditSectorForm));
            this.sectorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.otherErrorLabel = new System.Windows.Forms.Label();
            this.sectorErrorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sectorTextBox = new System.Windows.Forms.TextBox();
            this.sectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.createEditButton = new System.Windows.Forms.Button();
            this.validationMessageLabel = new System.Windows.Forms.Label();
            this.sectorTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sectorTableLayoutPanel
            // 
            this.sectorTableLayoutPanel.AutoSize = true;
            this.sectorTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sectorTableLayoutPanel.ColumnCount = 3;
            this.sectorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.sectorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.sectorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.sectorTableLayoutPanel.Controls.Add(this.otherErrorLabel, 0, 1);
            this.sectorTableLayoutPanel.Controls.Add(this.sectorErrorLabel, 2, 2);
            this.sectorTableLayoutPanel.Controls.Add(this.label1, 0, 2);
            this.sectorTableLayoutPanel.Controls.Add(this.cancelButton, 1, 3);
            this.sectorTableLayoutPanel.Controls.Add(this.sectorTextBox, 1, 2);
            this.sectorTableLayoutPanel.Controls.Add(this.createEditButton, 0, 3);
            this.sectorTableLayoutPanel.Controls.Add(this.validationMessageLabel, 0, 0);
            this.sectorTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.sectorTableLayoutPanel.Name = "sectorTableLayoutPanel";
            this.sectorTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.sectorTableLayoutPanel.RowCount = 4;
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sectorTableLayoutPanel.Size = new System.Drawing.Size(319, 121);
            this.sectorTableLayoutPanel.TabIndex = 1;
            // 
            // otherErrorLabel
            // 
            this.otherErrorLabel.AutoEllipsis = true;
            this.otherErrorLabel.AutoSize = true;
            this.sectorTableLayoutPanel.SetColumnSpan(this.otherErrorLabel, 3);
            this.otherErrorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.otherErrorLabel.Location = new System.Drawing.Point(8, 21);
            this.otherErrorLabel.Name = "otherErrorLabel";
            this.otherErrorLabel.Size = new System.Drawing.Size(303, 13);
            this.otherErrorLabel.TabIndex = 22;
            this.otherErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sectorErrorLabel
            // 
            this.sectorErrorLabel.AutoEllipsis = true;
            this.sectorErrorLabel.AutoSize = true;
            this.sectorErrorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.sectorErrorLabel.Location = new System.Drawing.Point(274, 34);
            this.sectorErrorLabel.Name = "sectorErrorLabel";
            this.sectorErrorLabel.Size = new System.Drawing.Size(37, 26);
            this.sectorErrorLabel.TabIndex = 2;
            this.sectorErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sector";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(89, 63);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 36);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // sectorTextBox
            // 
            this.sectorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sectorBindingSource, "Sector", true));
            this.sectorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorTextBox.Location = new System.Drawing.Point(89, 37);
            this.sectorTextBox.Name = "sectorTextBox";
            this.sectorTextBox.Size = new System.Drawing.Size(179, 20);
            this.sectorTextBox.TabIndex = 1;
            // 
            // sectorBindingSource
            // 
            this.sectorBindingSource.DataSource = typeof(EasyCRM.Model.Domains.IndustrialSector);
            // 
            // createEditButton
            // 
            this.createEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createEditButton.Location = new System.Drawing.Point(8, 63);
            this.createEditButton.Name = "createEditButton";
            this.createEditButton.Size = new System.Drawing.Size(75, 36);
            this.createEditButton.TabIndex = 14;
            this.createEditButton.Text = "Create";
            this.createEditButton.UseVisualStyleBackColor = true;
            this.createEditButton.Click += new System.EventHandler(this.createEditButton_Click);
            // 
            // validationMessageLabel
            // 
            this.validationMessageLabel.AutoEllipsis = true;
            this.validationMessageLabel.AutoSize = true;
            this.sectorTableLayoutPanel.SetColumnSpan(this.validationMessageLabel, 3);
            this.validationMessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.validationMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validationMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.validationMessageLabel.Location = new System.Drawing.Point(8, 5);
            this.validationMessageLabel.Name = "validationMessageLabel";
            this.validationMessageLabel.Size = new System.Drawing.Size(303, 16);
            this.validationMessageLabel.TabIndex = 16;
            this.validationMessageLabel.Text = "Please correct the errors and try again.";
            this.validationMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.validationMessageLabel.Visible = false;
            // 
            // CreateEditSectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(319, 121);
            this.Controls.Add(this.sectorTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateEditSectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create a new Sector";
            this.sectorTableLayoutPanel.ResumeLayout(false);
            this.sectorTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel sectorTableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox sectorTextBox;
        private System.Windows.Forms.Button createEditButton;
        private System.Windows.Forms.Label validationMessageLabel;
        private System.Windows.Forms.Label sectorErrorLabel;
        private System.Windows.Forms.Label otherErrorLabel;
        private System.Windows.Forms.BindingSource sectorBindingSource;

    }
}