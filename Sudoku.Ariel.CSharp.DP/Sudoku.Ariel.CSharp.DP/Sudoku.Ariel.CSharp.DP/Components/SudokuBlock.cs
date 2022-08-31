using System.Drawing;
using System.Windows.Forms;

namespace Sudoku.Ariel.CSharp.DP.Components
{
    public class SudokuBlocks
    {
        public Block[,] Blocks { get; set; }
        private Panel Panel { get;}

        public SudokuBlocks(Panel i_Panel)
        {
            Blocks = new Block[9, 9];
            this.Panel = i_Panel;
        }
            
        public void CreateBlocks()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Create 81 cells for with styles and locations based on the index
                    Blocks[i, j] = new Block();
                    Blocks[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    Blocks[i, j].Size = new Size(45, 45);
                    Blocks[i, j].ForeColor = SystemColors.ControlDarkDark;
                    Blocks[i, j].Location = new Point(i * 45, j * 45);
                    Blocks[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    Blocks[i, j].FlatStyle = FlatStyle.Flat;
                    Blocks[i, j].FlatAppearance.BorderColor = Color.Black;
                    Blocks[i, j].X = i;
                    Blocks[i, j].Y = j;

                    // Assign key press event for each cells
                    Blocks[i, j].KeyPress += Block_keyPressed;
                    // Blocks[i, j].MouseHover += (i_Sender, i_Args) =>
                    //     {
                    //         Button nButton = i_Sender as Button;
                    //         nButton.BackColor = Color.Aqua;
                    //     };

                    this.Panel.Controls.Add(Blocks[i, j]);
                }
            }
        }

        private void Block_keyPressed(object sender, KeyPressEventArgs e)
        {
            Block block = sender as Block;

            // Do nothing if the cell is locked
            if (block.IsLocked)
                return;

            int value;

            // Add the pressed key value in the cell only if it is a number
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                // Clear the cell value if pressed key is zero
                if (value == 0)
                    block.Clear();
                else
                    block.Text = value.ToString();

                block.ForeColor = SystemColors.ControlDarkDark;
            }
        }

    }
}
