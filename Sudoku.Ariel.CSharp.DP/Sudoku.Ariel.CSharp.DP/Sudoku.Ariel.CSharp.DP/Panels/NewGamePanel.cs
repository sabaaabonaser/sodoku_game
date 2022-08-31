using System;
using System.Windows.Forms;
using Sudoku.Ariel.CSharp.DP.Components;
using Sudoku.Ariel.CSharp.DP.GameLogic;

namespace Sudoku.Ariel.CSharp.DP.Panels
{
    public class NewGamePanel
    {
        private readonly Block[,] r_Blocks;
        private readonly Button r_NewGameStartButton;
        private readonly Label r_Difficulty;

        public RadioButton EasyButton { get; }
        public RadioButton MediumButton { get; }
        public RadioButton HardButton { get; }

        public Panel ThisPanel { get; }

        public NewGamePanel(Block[,] i_Blocks, Panel i_NewGamePanel, Button i_NewGameStartButton, Label i_Difficulty, RadioButton i_EasyButton, RadioButton i_MediumButton, RadioButton i_HardButton)
        {
            this.ThisPanel = i_NewGamePanel;

            this.r_Blocks = i_Blocks;
            this.r_NewGameStartButton = i_NewGameStartButton;

            this.r_Difficulty = i_Difficulty;
            this.EasyButton = i_EasyButton; 
            this.MediumButton = i_MediumButton;
            this.HardButton = i_HardButton;
            // 
            // New Game Button
            // 
            this.r_NewGameStartButton.Location = new System.Drawing.Point(0, 150);
            this.r_NewGameStartButton.Name = "NewGame";
            this.r_NewGameStartButton.Size = new System.Drawing.Size(119, 48);
            this.r_NewGameStartButton.TabIndex = 1;
            this.r_NewGameStartButton.Text = @"New Game";
            this.r_NewGameStartButton.UseVisualStyleBackColor = true;
            this.r_NewGameStartButton.Click += new System.EventHandler(newGameButton_Click);

            // 
            // Difficulty
            // 
            this.r_Difficulty.AutoSize = true;
            this.r_Difficulty.Location = new System.Drawing.Point(0, 0);
            this.r_Difficulty.Name = "Difficulty";
            this.r_Difficulty.Size = new System.Drawing.Size(61, 17);
            this.r_Difficulty.TabIndex = 3;
            this.r_Difficulty.Text = @"Difficulty";
            // 
            // Easy
            // 
            this.EasyButton.AutoSize = true;
            this.EasyButton.Location = new System.Drawing.Point(0, 25);
            this.EasyButton.Name = "EasyButton";
            this.EasyButton.Size = new System.Drawing.Size(110, 21);
            this.EasyButton.TabIndex = 4;
            this.EasyButton.TabStop = true;
            this.EasyButton.Text = @"EasyButton";
            this.EasyButton.UseVisualStyleBackColor = true;
            // 
            // Medium
            // 
            this.MediumButton.AutoSize = true;
            this.MediumButton.Location = new System.Drawing.Point(0, 50);
            this.MediumButton.Name = "MediumButton";
            this.MediumButton.Size = new System.Drawing.Size(110, 21);
            this.MediumButton.TabIndex = 5;
            this.MediumButton.TabStop = true;
            this.MediumButton.Text = @"MediumButton";
            this.MediumButton.UseVisualStyleBackColor = true;
            // 
            // HardButton
            // 
            this.HardButton.AutoSize = true;
            this.HardButton.Location = new System.Drawing.Point(0, 75);
            this.HardButton.Name = "HardButton";
            this.HardButton.Size = new System.Drawing.Size(110, 21);
            this.HardButton.TabIndex = 6;
            this.HardButton.TabStop = true;
            this.HardButton.Text = @"HardButton";
            this.HardButton.UseVisualStyleBackColor = true;


            this.ThisPanel.Controls.Add(r_Difficulty);
            this.ThisPanel.Controls.Add(EasyButton);
            this.ThisPanel.Controls.Add(MediumButton);
            this.ThisPanel.Controls.Add(HardButton);
            this.ThisPanel.Controls.Add(r_NewGameStartButton);


        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            new NewGameStart(r_Blocks,this);
        }
    }
}
