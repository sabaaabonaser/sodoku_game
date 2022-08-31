using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sudoku.Ariel.CSharp.DP.Components;

namespace Sudoku.Ariel.CSharp.DP.Buttons
{
    public class CheckCButtonLogic
    {
        private readonly Block[,] r_Blocks;
        private readonly Button r_Button;

        internal CheckCButtonLogic(Button i_Button, Block[,] i_Blocks)
        {
            this.r_Blocks = i_Blocks;
            this.r_Button = i_Button;
            
            this.r_Button.Location = new System.Drawing.Point(480, 12);
            this.r_Button.Name = "CheckButton";
            this.r_Button.Size = new System.Drawing.Size(119, 48);
            this.r_Button.TabIndex = 1;
            this.r_Button.Text = @"Check Input Button";
            this.r_Button.UseVisualStyleBackColor = true;
            this.r_Button.Click += new System.EventHandler(CheckButton_Click);
        }
        
        public void CheckButton_Click(object sender, EventArgs e)
        {
            List<Block> wrongCells = new List<Block>();

            // Find all the wrong inputs
            foreach (Block block in r_Blocks)
            {
                if (!string.Equals(block.Value.ToString(), block.Text))
                {
                    wrongCells.Add(block);
                }
            }

            // Check if the inputs are wrong or the player wins 
            if (wrongCells.Count > 0)
            {
                // Highlight the wrong inputs 
                wrongCells.ForEach(x => x.ForeColor = Color.Red);
                MessageBox.Show(@"Wrong inputs");
            }
            else
            {
                MessageBox.Show(@"You Wins");
            }
        }
    }
}
