namespace Launcher
{
	partial class MainForm
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.txtserver = new System.Windows.Forms.TextBox();
			this.lblserver = new System.Windows.Forms.Label();
			this.lblport = new System.Windows.Forms.Label();
			this.txtport = new System.Windows.Forms.TextBox();
			this.btnjouer = new System.Windows.Forms.Button();
			this.btnquitter = new System.Windows.Forms.Button();
			this.lblpseudo = new System.Windows.Forms.Label();
			this.txtpseudo = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtserver
			// 
			this.txtserver.Location = new System.Drawing.Point(516, 136);
			this.txtserver.Name = "txtserver";
			this.txtserver.Size = new System.Drawing.Size(100, 20);
			this.txtserver.TabIndex = 0;
			this.txtserver.Text = "127.0.0.1";
			// 
			// lblserver
			// 
			this.lblserver.AutoSize = true;
			this.lblserver.Location = new System.Drawing.Point(513, 120);
			this.lblserver.Name = "lblserver";
			this.lblserver.Size = new System.Drawing.Size(44, 13);
			this.lblserver.TabIndex = 1;
			this.lblserver.Text = "Serveur";
			// 
			// lblport
			// 
			this.lblport.AutoSize = true;
			this.lblport.Location = new System.Drawing.Point(513, 159);
			this.lblport.Name = "lblport";
			this.lblport.Size = new System.Drawing.Size(26, 13);
			this.lblport.TabIndex = 3;
			this.lblport.Text = "Port";
			// 
			// txtport
			// 
			this.txtport.Location = new System.Drawing.Point(516, 175);
			this.txtport.Name = "txtport";
			this.txtport.Size = new System.Drawing.Size(100, 20);
			this.txtport.TabIndex = 2;
			this.txtport.Text = "970";
			// 
			// btnjouer
			// 
			this.btnjouer.Location = new System.Drawing.Point(526, 210);
			this.btnjouer.Name = "btnjouer";
			this.btnjouer.Size = new System.Drawing.Size(75, 23);
			this.btnjouer.TabIndex = 4;
			this.btnjouer.Text = "Jouer";
			this.btnjouer.UseVisualStyleBackColor = true;
			this.btnjouer.Click += new System.EventHandler(this.btnjouer_Click);
			// 
			// btnquitter
			// 
			this.btnquitter.Location = new System.Drawing.Point(526, 240);
			this.btnquitter.Name = "btnquitter";
			this.btnquitter.Size = new System.Drawing.Size(75, 23);
			this.btnquitter.TabIndex = 5;
			this.btnquitter.Text = "Quitter";
			this.btnquitter.UseVisualStyleBackColor = true;
			this.btnquitter.Click += new System.EventHandler(this.btnquitter_Click);
			// 
			// lblpseudo
			// 
			this.lblpseudo.AutoSize = true;
			this.lblpseudo.Location = new System.Drawing.Point(513, 81);
			this.lblpseudo.Name = "lblpseudo";
			this.lblpseudo.Size = new System.Drawing.Size(43, 13);
			this.lblpseudo.TabIndex = 7;
			this.lblpseudo.Text = "Pseudo";
			// 
			// txtpseudo
			// 
			this.txtpseudo.Location = new System.Drawing.Point(516, 97);
			this.txtpseudo.Name = "txtpseudo";
			this.txtpseudo.Size = new System.Drawing.Size(100, 20);
			this.txtpseudo.TabIndex = 6;
			this.txtpseudo.Text = "Pseudo";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(501, 573);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("OCR A Extended", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Sienna;
			this.label1.Location = new System.Drawing.Point(235, 542);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(381, 29);
			this.label1.TabIndex = 9;
			this.label1.Text = "La fabrique des étoiles";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(628, 599);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblpseudo);
			this.Controls.Add(this.txtpseudo);
			this.Controls.Add(this.btnquitter);
			this.Controls.Add(this.btnjouer);
			this.Controls.Add(this.lblport);
			this.Controls.Add(this.txtport);
			this.Controls.Add(this.lblserver);
			this.Controls.Add(this.txtserver);
			this.Name = "MainForm";
			this.Text = "La fabrique des étoiles";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtserver;
		private System.Windows.Forms.Label lblserver;
		private System.Windows.Forms.Label lblport;
		private System.Windows.Forms.TextBox txtport;
		private System.Windows.Forms.Button btnjouer;
		private System.Windows.Forms.Button btnquitter;
		private System.Windows.Forms.Label lblpseudo;
		private System.Windows.Forms.TextBox txtpseudo;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
	}
}

