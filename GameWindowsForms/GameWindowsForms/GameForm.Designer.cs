namespace GameWindowsForms
{
    partial class GameForm
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
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.EnemyFireLoop = new System.Windows.Forms.Timer(this.components);
            this.healthLabel = new System.Windows.Forms.Label();
            this.HeroCount = new System.Windows.Forms.Label();
            this.EnemyCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Interval = 10;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // EnemyFireLoop
            // 
            this.EnemyFireLoop.Enabled = true;
            this.EnemyFireLoop.Interval = 900;
            this.EnemyFireLoop.Tick += new System.EventHandler(this.EnemyFireLoop_Tick);
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.BackColor = System.Drawing.Color.Transparent;
            this.healthLabel.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.healthLabel.Location = new System.Drawing.Point(1085, 31);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(93, 29);
            this.healthLabel.TabIndex = 5;
            this.healthLabel.Text = "Health: ";
            this.healthLabel.Click += new System.EventHandler(this.healthLabel_Click);
            // 
            // HeroCount
            // 
            this.HeroCount.AutoSize = true;
            this.HeroCount.BackColor = System.Drawing.Color.Transparent;
            this.HeroCount.Font = new System.Drawing.Font("Palatino Linotype", 13F);
            this.HeroCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HeroCount.Location = new System.Drawing.Point(12, 31);
            this.HeroCount.Name = "HeroCount";
            this.HeroCount.Size = new System.Drawing.Size(144, 29);
            this.HeroCount.TabIndex = 6;
            this.HeroCount.Text = "Hero Count :";
            // 
            // EnemyCount
            // 
            this.EnemyCount.AutoSize = true;
            this.EnemyCount.BackColor = System.Drawing.Color.Transparent;
            this.EnemyCount.Font = new System.Drawing.Font("Palatino Linotype", 13F);
            this.EnemyCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EnemyCount.Location = new System.Drawing.Point(12, 64);
            this.EnemyCount.Name = "EnemyCount";
            this.EnemyCount.Size = new System.Drawing.Size(162, 29);
            this.EnemyCount.TabIndex = 7;
            this.EnemyCount.Text = "Enemy Count :";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameWindowsForms.Properties.Resources.working;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1263, 744);
            this.Controls.Add(this.EnemyCount);
            this.Controls.Add(this.HeroCount);
            this.Controls.Add(this.healthLabel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.Timer EnemyFireLoop;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label HeroCount;
        private System.Windows.Forms.Label EnemyCount;
    }
}

