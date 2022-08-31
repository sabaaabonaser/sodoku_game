using System;
using System.Collections.Generic;
using System.Drawing;
using Sudoku.Ariel.CSharp.DP.Buttons;
using Sudoku.Ariel.CSharp.DP.Components;
using Sudoku.Ariel.CSharp.DP.Panels;

namespace Sudoku.Ariel.CSharp.DP.GameLogic
{
    public class NewGameStart
    {
        private readonly Block[,] r_Blocks;
        private readonly NewGamePanel r_NewGamePanel;
        readonly Random r_Random = new Random();

        public NewGameStart(Block[,] i_Blocks, NewGamePanel i_NewGamePanel)
        {
            this.r_Blocks = i_Blocks;
            this.r_NewGamePanel = i_NewGamePanel;
            loadValues();

            //Show values of 45 cells as hint
            showRandomValuesHints(checkDifficulty());
        }

        private int checkDifficulty()
        {
            int hintsCount = 0;
            
            // Assign the hints count based on the 
            // level player chosen
            if (r_NewGamePanel.EasyButton.Checked)
                hintsCount = 80;
            else if (r_NewGamePanel.MediumButton.Checked)
                hintsCount = 60;
            else if (r_NewGamePanel.HardButton.Checked)
                hintsCount = 40;
            return hintsCount;
        }
            private void loadValues()
            {
                // Clear the values in each cells
                foreach(Block blocks in r_Blocks)
                {
                    blocks.Value = 0;
                    blocks.Clear();
                }

                // This method will be called recursively 
                // until it finds suitable values for each cells
                findValueForNextCell(0, -1);
            }

            private bool findValueForNextCell(int i, int j)
            {
                // Increment the i and j values to move to the next cell
                // and if the columsn ends move to the next row
                if(++j > 8)
                {
                    j = 0;

                    // Exit if the line ends
                    if(++i > 8)
                        return true;
                }

                int value = 0;
                List<int> numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                
                // Find a random and valid number for the cell and go to the next cell 
                // and check if it can be allocated with another random and valid number
                do
                {
                    // If there is not numbers left in the list to try next, 
                    // return to the previous cell and allocate it with a different number
                    if(numsLeft.Count < 1)
                    {
                        r_Blocks[i, j].Value = 0;
                        return false;
                    }

                    // Take a random number from the numbers left in the list
                    value = numsLeft[r_Random.Next(0, numsLeft.Count)];
                    r_Blocks[i, j].Value = value;

                    // Remove the allocated value from the list
                    numsLeft.Remove(value);
                }
                while(!isValidNumber(value, i, j) || !findValueForNextCell(i, j));

                // TDO: Remove this line after testing
                // r_Blocks[i, j].Text = value.ToString();

                return true;
            }

        private bool isValidNumber(int value, int x, int y)
        {
            for(int i = 0; i < 9; i++)
            {
                // Check all the cells in vertical direction
                if(i != y && r_Blocks[x, i].Value == value)
                    return false;

                // Check all the cells in horizontal direction
                if(i != x && r_Blocks[i, y].Value == value)
                    return false;
            }

            // Check all the cells in the specific block
            for(int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for(int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if(i != x && j != y && r_Blocks[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private void showRandomValuesHints(int hintsCount)
        {
            // Show value in random cells
            // The hints count is based on the level player choose
            for (int i = 0; i < hintsCount; i++)
            {
                int rX = r_Random.Next(9);
                int rY = r_Random.Next(9);

                // Style the hint cells differently and
                // lock the cell so that player can't edit the value
                r_Blocks[rX, rY].Text = r_Blocks[rX, rY].Value.ToString();
                r_Blocks[rX, rY].ForeColor = Color.Black;
                r_Blocks[rX, rY].IsLocked = true;
            }
        }
    }
}
