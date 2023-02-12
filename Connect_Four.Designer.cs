namespace Connect_Four
{
    partial class Connect_Four
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
            this.lblLastTurn = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNumPlayers = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLastTurn
            // 
            this.lblLastTurn.AutoSize = true;
            this.lblLastTurn.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastTurn.Location = new System.Drawing.Point(21, 397);
            this.lblLastTurn.Name = "lblLastTurn";
            this.lblLastTurn.Size = new System.Drawing.Size(113, 26);
            this.lblLastTurn.TabIndex = 0;
            this.lblLastTurn.Text = "Last Move: ";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(452, 348);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 43);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblNumPlayers
            // 
            this.lblNumPlayers.AutoSize = true;
            this.lblNumPlayers.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPlayers.Location = new System.Drawing.Point(447, 51);
            this.lblNumPlayers.Name = "lblNumPlayers";
            this.lblNumPlayers.Size = new System.Drawing.Size(66, 26);
            this.lblNumPlayers.TabIndex = 2;
            this.lblNumPlayers.Text = "Player";
            this.lblNumPlayers.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(452, 283);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 43);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Connect_Four
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblNumPlayers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblLastTurn);
            this.Name = "Connect_Four";
            this.Text = "Connect Four";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Connect_Four_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Connect_Four_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastTurn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblNumPlayers;
        private System.Windows.Forms.Button btnReset;
    }
}

