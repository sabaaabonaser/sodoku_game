using System;
using System.Windows.Forms;
using Sudoku.Ariel.CSharp.DP.Components;

namespace Sudoku.Ariel.CSharp.DP.Buttons
{
    public class ClearButton
    {
        private readonly Block[,] r_Blocks;
        private readonly Button r_Button;

        public ClearButton(Block[,] i_Blocks, Button i_Button)
        {
            this.r_Blocks = i_Blocks;
            this.r_Button = i_Button;

            this.r_Button.Location = new System.Drawing.Point(480, 60);
            this.r_Button.Name = "ClearButton";
            this.r_Button.Size = new System.Drawing.Size(119, 48);
            this.r_Button.TabIndex = 1;
            this.r_Button.Text = "ClearButton";
            this.r_Button.UseVisualStyleBackColor = true;
            this.r_Button.Click += new System.EventHandler(clearButton_Click);
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var block in r_Blocks)
            {
                // Clear the cell only if it is not locked
                if (block.IsLocked == false)
                    block.Clear();
            }
        }
    }
}
