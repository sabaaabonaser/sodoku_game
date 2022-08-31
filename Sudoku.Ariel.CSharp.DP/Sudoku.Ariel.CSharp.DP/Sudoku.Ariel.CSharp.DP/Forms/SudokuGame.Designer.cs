using System.Windows.Forms;
using Sudoku.Ariel.CSharp.DP.Buttons;
using Sudoku.Ariel.CSharp.DP.Components;
using Sudoku.Ariel.CSharp.DP.GameLogic;
using Sudoku.Ariel.CSharp.DP.Panels;

namespace Sudoku.Ariel.CSharp.DP.Forms
{
    partial class SudokuGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private SudokuBlocks sudokuBlocks;
        private CheckCButtonLogic m_CheckButton;
        private ClearButton m_ClearButton;
        private NewGamePanel m_NewGamePanel;

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
            this.boardPanel = new System.Windows.Forms.Panel();
            this.CheckButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.NewGameStartButton = new System.Windows.Forms.Button();
            this.Difficulty = new System.Windows.Forms.Label();
            this.EasyButton = new System.Windows.Forms.RadioButton();
            this.MediumButton = new System.Windows.Forms.RadioButton();
            this.HardButton = new System.Windows.Forms.RadioButton();
            this.newGamePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(12, 0);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(625, 530);
            this.boardPanel.TabIndex = 0;
            // 
            // newGamePanel
            // 
            this.newGamePanel.Location = new System.Drawing.Point(643, 211);
            this.newGamePanel.Name = "newGamePanel";
            this.newGamePanel.Size = new System.Drawing.Size(176, 319);
            this.newGamePanel.TabIndex = 7;
            // 
            // SudokuGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 564);
            this.Controls.Add(this.newGamePanel);
            this.Controls.Add(this.HardButton);
            this.Controls.Add(this.MediumButton);
            this.Controls.Add(this.EasyButton);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.NewGameStartButton);
            this.Controls.Add(this.boardPanel);
            this.Name = "SudokuGame";
            this.Text = "SudokuGame.cs";
            this.ResumeLayout(false);

        }

        private void startGame()
        {
            this.sudokuBlocks = new SudokuBlocks(this.boardPanel);
            this.sudokuBlocks.CreateBlocks();

            this.m_CheckButton = new CheckCButtonLogic(this.CheckButton, this.sudokuBlocks.Blocks);
            this.m_ClearButton = new ClearButton(this.sudokuBlocks.Blocks, this.ClearButton);
            this.m_NewGamePanel = new NewGamePanel(this.sudokuBlocks.Blocks, this.newGamePanel, this.NewGameStartButton, this.Difficulty,this.EasyButton,this.MediumButton,this.HardButton);
            new NewGameStart(sudokuBlocks.Blocks, this.m_NewGamePanel);
        }

        private Panel boardPanel;
        private Button CheckButton;
        private Button ClearButton;
        private Button NewGameStartButton;
        private Label Difficulty;
        private RadioButton EasyButton;
        private RadioButton MediumButton;
        private RadioButton HardButton;

        #endregion

        private Panel newGamePanel;
    }
}

