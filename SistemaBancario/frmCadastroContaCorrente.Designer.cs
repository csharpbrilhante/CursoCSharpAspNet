namespace SistemaBancario
{
    partial class frmCadastroContaCorrente
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.cbxCorrentistas = new System.Windows.Forms.ComboBox();
            this.txtNumConta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agencia";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(16, 34);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(111, 20);
            this.txtAgencia.TabIndex = 1;
            this.txtAgencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgencia_KeyPress);
            this.txtAgencia.Leave += new System.EventHandler(this.txtAgencia_Leave);
            // 
            // cbxCorrentistas
            // 
            this.cbxCorrentistas.FormattingEnabled = true;
            this.cbxCorrentistas.Location = new System.Drawing.Point(16, 92);
            this.cbxCorrentistas.Name = "cbxCorrentistas";
            this.cbxCorrentistas.Size = new System.Drawing.Size(423, 21);
            this.cbxCorrentistas.TabIndex = 2;
            // 
            // txtNumConta
            // 
            this.txtNumConta.Location = new System.Drawing.Point(133, 34);
            this.txtNumConta.Name = "txtNumConta";
            this.txtNumConta.ReadOnly = true;
            this.txtNumConta.Size = new System.Drawing.Size(198, 20);
            this.txtNumConta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número Conta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Correntista";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(229, 154);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(102, 35);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmCadastroContaCorrente
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 219);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumConta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCorrentistas);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.label1);
            this.Name = "frmCadastroContaCorrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Contas Correntes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.ComboBox cbxCorrentistas;
        private System.Windows.Forms.TextBox txtNumConta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button button2;
    }
}