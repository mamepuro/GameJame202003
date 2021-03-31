using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace GameJam
{
    class Block : CollidableObject
    {
        public int row;
        public int column;
        public bool isSet; 
        public Block(Vector2F position, string resourcePath, int row, int column)
            :base(position)
        {
            Texture = Texture2D.LoadStrict(resourcePath + "MousePointer.png");
            isSet = false;
            this.row = row;
            this.column = column;
        }
    }
}
