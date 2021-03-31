using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace GameJam
{
    class Frame
    {
        private int row;
        //列
        private int column;

        private Vector2F initPosition;
        public Frame(Vector2F initPopsition, string resourcePath)
        {
            row = 5;
            column = 8;
            this.initPosition = initPopsition;
            var x = initPopsition.X;
            var y = initPopsition.Y;
            var cellTexture = Texture2D.LoadStrict(resourcePath + "frame.png");
            for(int row = 0; row < this.row; row++)
            {
                for(int column = 0; column < this.column; column++)
                {
                    var pos = new Vector2F(x + (column * cellTexture.Size.X), y + (row * cellTexture.Size.Y));
                    var cell = new Cell(pos, resourcePath, row, column);
                    Engine.AddNode(cell);
                }
            }
        }
    }
}
