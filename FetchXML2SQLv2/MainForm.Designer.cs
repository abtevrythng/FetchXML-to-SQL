/*
 * Created by SharpDevelop.
 * User: g.nelson
 * Date: 19/09/2016
 * Time: 4:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FetchXML2SQLv2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.RichTextBox sqlBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button convert2SQL;
		private System.Windows.Forms.RichTextBox fetchXMLBox;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.sqlBox = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.convert2SQL = new System.Windows.Forms.Button();
			this.fetchXMLBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// sqlBox
			// 
			this.sqlBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sqlBox.Location = new System.Drawing.Point(453, 33);
			this.sqlBox.Name = "sqlBox";
			this.sqlBox.Size = new System.Drawing.Size(445, 554);
			this.sqlBox.TabIndex = 1;
			this.sqlBox.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "FetchXML";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(451, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "SQL";
			// 
			// convert2SQL
			// 
			this.convert2SQL.Location = new System.Drawing.Point(350, 4);
			this.convert2SQL.Name = "convert2SQL";
			this.convert2SQL.Size = new System.Drawing.Size(95, 23);
			this.convert2SQL.TabIndex = 4;
			this.convert2SQL.Text = "Process";
			this.convert2SQL.UseVisualStyleBackColor = true;
			this.convert2SQL.Click += new System.EventHandler(this.Button1Click);
			// 
			// fetchXMLBox
			// 
			this.fetchXMLBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fetchXMLBox.Location = new System.Drawing.Point(13, 33);
			this.fetchXMLBox.Name = "fetchXMLBox";
			this.fetchXMLBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.fetchXMLBox.Size = new System.Drawing.Size(432, 553);
			this.fetchXMLBox.TabIndex = 5;
			this.fetchXMLBox.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(910, 599);
			this.Controls.Add(this.fetchXMLBox);
			this.Controls.Add(this.convert2SQL);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sqlBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FetchXML2SQLv2";
			this.ResumeLayout(false);

		}

		}
	}
