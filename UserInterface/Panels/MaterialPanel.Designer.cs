﻿namespace Render3D.UserInterface.Panels
{
    partial class MaterialPanel
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
            this.btnCreateFigure = new System.Windows.Forms.Button();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nrRedColor = new System.Windows.Forms.NumericUpDown();
            this.nrGreenColor = new System.Windows.Forms.NumericUpDown();
            this.nrBlueColor = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExceptionError = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nrRedColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrGreenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrBlueColor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateFigure
            // 
            this.btnCreateFigure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreateFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateFigure.Location = new System.Drawing.Point(0, 582);
            this.btnCreateFigure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateFigure.Name = "btnCreateFigure";
            this.btnCreateFigure.Size = new System.Drawing.Size(505, 96);
            this.btnCreateFigure.TabIndex = 13;
            this.btnCreateFigure.Text = "Create!!!";
            this.btnCreateFigure.UseVisualStyleBackColor = true;
            this.btnCreateFigure.Click += new System.EventHandler(this.BtnCreateFigure_Click);
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialName.Location = new System.Drawing.Point(167, 195);
            this.txtMaterialName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(265, 34);
            this.txtMaterialName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 267);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Red:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Create a new material!!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Green:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 385);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Blue:";
            // 
            // nrRedColor
            // 
            this.nrRedColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nrRedColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrRedColor.Location = new System.Drawing.Point(167, 261);
            this.nrRedColor.Margin = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.nrRedColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nrRedColor.Name = "nrRedColor";
            this.nrRedColor.Size = new System.Drawing.Size(265, 34);
            this.nrRedColor.TabIndex = 10;
            // 
            // nrGreenColor
            // 
            this.nrGreenColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nrGreenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrGreenColor.Location = new System.Drawing.Point(167, 321);
            this.nrGreenColor.Margin = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.nrGreenColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nrGreenColor.Name = "nrGreenColor";
            this.nrGreenColor.Size = new System.Drawing.Size(265, 34);
            this.nrGreenColor.TabIndex = 11;
            // 
            // nrBlueColor
            // 
            this.nrBlueColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nrBlueColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrBlueColor.Location = new System.Drawing.Point(167, 385);
            this.nrBlueColor.Margin = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.nrBlueColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nrBlueColor.Name = "nrBlueColor";
            this.nrBlueColor.Size = new System.Drawing.Size(265, 34);
            this.nrBlueColor.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaterial);
            this.panel1.Controls.Add(this.lblExceptionError);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nrBlueColor);
            this.panel1.Controls.Add(this.btnCreateFigure);
            this.panel1.Controls.Add(this.nrGreenColor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nrRedColor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtMaterialName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 678);
            this.panel1.TabIndex = 17;
            // 
            // lblExceptionError
            // 
            this.lblExceptionError.AutoSize = true;
            this.lblExceptionError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionError.ForeColor = System.Drawing.Color.Red;
            this.lblExceptionError.Location = new System.Drawing.Point(56, 528);
            this.lblExceptionError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExceptionError.Name = "lblExceptionError";
            this.lblExceptionError.Size = new System.Drawing.Size(45, 20);
            this.lblExceptionError.TabIndex = 18;
            this.lblExceptionError.Text = "error";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Items.AddRange(new object[] {
            "Lambertiano",
            "Metalico"});
            this.cmbMaterial.Location = new System.Drawing.Point(167, 128);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(265, 24);
            this.cmbMaterial.TabIndex = 19;
            this.cmbMaterial.Text = "Lambertiano";
            // 
            // lblMaterial
            // 
            this.lblMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(55, 123);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(105, 29);
            this.lblMaterial.TabIndex = 20;
            this.lblMaterial.Text = "Material:";
            // 
            // MaterialPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 714);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MaterialPanel";
            this.Text = "Material";
            this.Shown += new System.EventHandler(this.VariablesInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.nrRedColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrGreenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrBlueColor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateFigure;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nrRedColor;
        private System.Windows.Forms.NumericUpDown nrGreenColor;
        private System.Windows.Forms.NumericUpDown nrBlueColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblExceptionError;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
    }
}