namespace SistemaBancario
{
    partial class frmListaContaCorrente
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
            this.btnNovo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gridContasCorrentes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrentistaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrentistaCpfCnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnAlterar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnLançamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExtrato = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridContasCorrentes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(15, 12);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(79, 30);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Alterar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(177, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "Excluir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gridContasCorrentes
            // 
            this.gridContasCorrentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridContasCorrentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContasCorrentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.CorrentistaNome,
            this.CorrentistaCpfCnpj});
            this.gridContasCorrentes.ContextMenuStrip = this.contextMenuStrip1;
            this.gridContasCorrentes.Location = new System.Drawing.Point(14, 59);
            this.gridContasCorrentes.Name = "gridContasCorrentes";
            this.gridContasCorrentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridContasCorrentes.Size = new System.Drawing.Size(558, 325);
            this.gridContasCorrentes.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Agencia";
            this.Column1.HeaderText = "Agência";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NumConta";
            this.Column2.HeaderText = "Número Conta";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // CorrentistaNome
            // 
            this.CorrentistaNome.HeaderText = "Nome do Correntista";
            this.CorrentistaNome.Name = "CorrentistaNome";
            this.CorrentistaNome.ReadOnly = true;
            // 
            // CorrentistaCpfCnpj
            // 
            this.CorrentistaCpfCnpj.HeaderText = "CPF ou CNPJ";
            this.CorrentistaCpfCnpj.Name = "CorrentistaCpfCnpj";
            this.CorrentistaCpfCnpj.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAlterar,
            this.mnExcluir,
            this.toolStripSeparator1,
            this.mnLançamento,
            this.mnExtrato});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 98);
            // 
            // mnAlterar
            // 
            this.mnAlterar.Name = "mnAlterar";
            this.mnAlterar.Size = new System.Drawing.Size(180, 22);
            this.mnAlterar.Text = "Alterar";
            this.mnAlterar.Click += new System.EventHandler(this.button2_Click);
            // 
            // mnExcluir
            // 
            this.mnExcluir.Name = "mnExcluir";
            this.mnExcluir.Size = new System.Drawing.Size(172, 22);
            this.mnExcluir.Text = "Excluir";
            this.mnExcluir.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnLançamento
            // 
            this.mnLançamento.Name = "mnLançamento";
            this.mnLançamento.Size = new System.Drawing.Size(180, 22);
            this.mnLançamento.Text = "&Novo Lançamento";
            // 
            // mnExtrato
            // 
            this.mnExtrato.Name = "mnExtrato";
            this.mnExtrato.Size = new System.Drawing.Size(180, 22);
            this.mnExtrato.Text = "&Consulta Extrato";
            // 
            // frmListaContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 396);
            this.Controls.Add(this.gridContasCorrentes);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnNovo);
            this.Name = "frmListaContaCorrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de contas correntes cadastradas";
            this.Load += new System.EventHandler(this.frmListaContaCorrente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridContasCorrentes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView gridContasCorrentes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnAlterar;
        private System.Windows.Forms.ToolStripMenuItem mnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnLançamento;
        private System.Windows.Forms.ToolStripMenuItem mnExtrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrentistaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrentistaCpfCnpj;
    }
}