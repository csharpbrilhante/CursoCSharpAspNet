namespace SistemaBancario.CaixaEletronico.Controls
{
    partial class ucSessao
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNomeCorrentista = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblConta = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAgencia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNomeCorrentista
            // 
            this.lblNomeCorrentista.AutoSize = true;
            this.lblNomeCorrentista.ForeColor = System.Drawing.Color.White;
            this.lblNomeCorrentista.Location = new System.Drawing.Point(108, 62);
            this.lblNomeCorrentista.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeCorrentista.Name = "lblNomeCorrentista";
            this.lblNomeCorrentista.Size = new System.Drawing.Size(45, 16);
            this.lblNomeCorrentista.TabIndex = 17;
            this.lblNomeCorrentista.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Correntista:";
            // 
            // lblConta
            // 
            this.lblConta.AutoSize = true;
            this.lblConta.ForeColor = System.Drawing.Color.White;
            this.lblConta.Location = new System.Drawing.Point(108, 38);
            this.lblConta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConta.Name = "lblConta";
            this.lblConta.Size = new System.Drawing.Size(50, 16);
            this.lblConta.TabIndex = 15;
            this.lblConta.Text = "000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(44, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Conta:";
            // 
            // lblAgencia
            // 
            this.lblAgencia.AutoSize = true;
            this.lblAgencia.ForeColor = System.Drawing.Color.White;
            this.lblAgencia.Location = new System.Drawing.Point(108, 12);
            this.lblAgencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgencia.Name = "lblAgencia";
            this.lblAgencia.Size = new System.Drawing.Size(36, 16);
            this.lblAgencia.TabIndex = 13;
            this.lblAgencia.Text = "0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Agência:";
            // 
            // ucSessao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.Controls.Add(this.lblNomeCorrentista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblConta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAgencia);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucSessao";
            this.Size = new System.Drawing.Size(551, 95);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblNomeCorrentista;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblConta;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblAgencia;
        public System.Windows.Forms.Label label2;
    }
}
