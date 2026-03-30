namespace CálculoFinancierodePréstamos.MenúPrincipal
{
    partial class FormSolicitudPréstamos
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
            this.Btn_VolverMenúPrincipal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_VolverMenúPrincipal
            // 
            this.Btn_VolverMenúPrincipal.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_VolverMenúPrincipal.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_VolverMenúPrincipal.ForeColor = System.Drawing.Color.White;
            this.Btn_VolverMenúPrincipal.Location = new System.Drawing.Point(12, 404);
            this.Btn_VolverMenúPrincipal.Name = "Btn_VolverMenúPrincipal";
            this.Btn_VolverMenúPrincipal.Size = new System.Drawing.Size(252, 32);
            this.Btn_VolverMenúPrincipal.TabIndex = 0;
            this.Btn_VolverMenúPrincipal.Text = "Volver al Menú Principal ↺";
            this.Btn_VolverMenúPrincipal.UseVisualStyleBackColor = false;
            this.Btn_VolverMenúPrincipal.Click += new System.EventHandler(this.Btn_VolverMenúPrincipal_Click);
            // 
            // FormSolicitudPréstamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_VolverMenúPrincipal);
            this.Name = "FormSolicitudPréstamos";
            this.Text = "FormSolicitudPréstamos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_VolverMenúPrincipal;
    }
}