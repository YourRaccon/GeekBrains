namespace DZ7
{
    partial class Form1
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
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblComandCounter = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lblGoal = new System.Windows.Forms.Label();
            this.lblGolal = new System.Windows.Forms.Label();
            this.lblGoalNumber = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(212, 10);
            this.btnCommand1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(109, 50);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Location = new System.Drawing.Point(212, 63);
            this.btnCommand2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(109, 50);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(212, 116);
            this.btnReset.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(109, 50);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.Location = new System.Drawing.Point(32, 49);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(30, 31);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Команд отдано:";
            // 
            // lblComandCounter
            // 
            this.lblComandCounter.AutoSize = true;
            this.lblComandCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblComandCounter.Location = new System.Drawing.Point(181, 277);
            this.lblComandCounter.Name = "lblComandCounter";
            this.lblComandCounter.Size = new System.Drawing.Size(24, 25);
            this.lblComandCounter.TabIndex = 5;
            this.lblComandCounter.Text = "0";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(212, 169);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(109, 50);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "Играть";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGoal.Location = new System.Drawing.Point(12, 252);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(65, 25);
            this.lblGoal.TabIndex = 7;
            this.lblGoal.Text = "Цель:";
            this.lblGoal.Visible = false;
            // 
            // lblGolal
            // 
            this.lblGolal.AutoSize = true;
            this.lblGolal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGolal.Location = new System.Drawing.Point(83, 252);
            this.lblGolal.Name = "lblGolal";
            this.lblGolal.Size = new System.Drawing.Size(0, 25);
            this.lblGolal.TabIndex = 8;
            this.lblGolal.Visible = false;
            // 
            // lblGoalNumber
            // 
            this.lblGoalNumber.AutoSize = true;
            this.lblGoalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGoalNumber.Location = new System.Drawing.Point(83, 252);
            this.lblGoalNumber.Name = "lblGoalNumber";
            this.lblGoalNumber.Size = new System.Drawing.Size(24, 25);
            this.lblGoalNumber.TabIndex = 9;
            this.lblGoalNumber.Text = "0";
            this.lblGoalNumber.Visible = false;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Enabled = false;
            this.btnGoBack.Location = new System.Drawing.Point(212, 222);
            this.btnGoBack.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(109, 50);
            this.btnGoBack.TabIndex = 10;
            this.btnGoBack.Text = "Назад";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lblGoalNumber);
            this.Controls.Add(this.lblGolal);
            this.Controls.Add(this.lblGoal);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lblComandCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Удвоитель";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblComandCounter;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.Label lblGolal;
        private System.Windows.Forms.Label lblGoalNumber;
        private System.Windows.Forms.Button btnGoBack;
    }
}

