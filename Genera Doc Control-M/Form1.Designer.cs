namespace Genera_Doc_Control_M
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGeneraDoc = new Button();
            txtPlantilla = new TextBox();
            lblPlantilla = new Label();
            lblBD = new Label();
            txtBD = new TextBox();
            SuspendLayout();
            // 
            // btnGeneraDoc
            // 
            btnGeneraDoc.Location = new Point(233, 182);
            btnGeneraDoc.Name = "btnGeneraDoc";
            btnGeneraDoc.Size = new Size(325, 34);
            btnGeneraDoc.TabIndex = 0;
            btnGeneraDoc.Text = "Genera Documentación Control-M";
            btnGeneraDoc.UseVisualStyleBackColor = true;
            btnGeneraDoc.Click += btnGeneraDoc_Click;
            // 
            // txtPlantilla
            // 
            txtPlantilla.Location = new Point(151, 28);
            txtPlantilla.Name = "txtPlantilla";
            txtPlantilla.Size = new Size(637, 31);
            txtPlantilla.TabIndex = 1;
            // 
            // lblPlantilla
            // 
            lblPlantilla.AutoSize = true;
            lblPlantilla.Location = new Point(62, 28);
            lblPlantilla.Name = "lblPlantilla";
            lblPlantilla.Size = new Size(76, 25);
            lblPlantilla.TabIndex = 3;
            lblPlantilla.Text = "Plantilla:";
            // 
            // lblBD
            // 
            lblBD.AutoSize = true;
            lblBD.Location = new Point(9, 74);
            lblBD.Name = "lblBD";
            lblBD.Size = new Size(129, 25);
            lblBD.TabIndex = 4;
            lblBD.Text = "Base de Datos:";
            // 
            // txtBD
            // 
            txtBD.Location = new Point(151, 71);
            txtBD.Name = "txtBD";
            txtBD.Size = new Size(637, 31);
            txtBD.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBD);
            Controls.Add(lblPlantilla);
            Controls.Add(txtBD);
            Controls.Add(txtPlantilla);
            Controls.Add(btnGeneraDoc);
            Name = "Form1";
            Text = "Genera Doc. Control-M";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGeneraDoc;
        private TextBox txtPlantilla;
        private Label lblPlantilla;
        private Label lblBD;
        private TextBox txtBD;
    }
}