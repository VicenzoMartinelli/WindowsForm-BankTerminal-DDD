namespace Agencia.UI
{
  partial class frmLogin
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
      this.label1 = new System.Windows.Forms.Label();
      this.btnConta = new System.Windows.Forms.Button();
      this.btnAdm = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(197)))), ((int)(((byte)(204)))));
      this.label1.Name = "label1";
      // 
      // btnConta
      // 
      this.btnConta.Cursor = System.Windows.Forms.Cursors.Hand;
      resources.ApplyResources(this.btnConta, "btnConta");
      this.btnConta.Name = "btnConta";
      this.btnConta.UseVisualStyleBackColor = false;
      // 
      // btnAdm
      // 
      this.btnAdm.Cursor = System.Windows.Forms.Cursors.Hand;
      resources.ApplyResources(this.btnAdm, "btnAdm");
      this.btnAdm.Name = "btnAdm";
      this.btnAdm.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
      this.label2.ForeColor = System.Drawing.Color.Black;
      this.label2.Name = "label2";
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
      this.label3.ForeColor = System.Drawing.Color.Black;
      this.label3.Name = "label3";
      // 
      // frmLogin
      // 
      resources.ApplyResources(this, "$this");
      this.BackgroundImage = global::Terminal.Ui.Properties.Resources.bank;
      this.ControlBox = false;
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnAdm);
      this.Controls.Add(this.btnConta);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(197)))), ((int)(((byte)(204)))));
      this.Name = "frmLogin";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label txtCpf;
    private System.Windows.Forms.Label txtConta;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnConta;
    private System.Windows.Forms.Button btnAdm;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
  }
}

