namespace ADO
{
    partial class Form1
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPais = new System.Windows.Forms.DataGridView();
            this.gridFilhos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridPais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilhos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPais
            // 
            this.gridPais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPais.Location = new System.Drawing.Point(12, 12);
            this.gridPais.Name = "gridPais";
            this.gridPais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPais.Size = new System.Drawing.Size(590, 198);
            this.gridPais.TabIndex = 0;
            // 
            // gridFilhos
            // 
            this.gridFilhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFilhos.Location = new System.Drawing.Point(12, 216);
            this.gridFilhos.Name = "gridFilhos";
            this.gridFilhos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFilhos.Size = new System.Drawing.Size(590, 132);
            this.gridFilhos.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 359);
            this.Controls.Add(this.gridFilhos);
            this.Controls.Add(this.gridPais);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilhos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPais;
        private System.Windows.Forms.DataGridView gridFilhos;
    }
}

