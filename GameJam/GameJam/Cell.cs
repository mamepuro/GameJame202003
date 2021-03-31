using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace GameJam
{
    class Cell : CollidableObject
    {
        public bool isEmpty;

        /// <summary>
        /// 何行目かを保存する
        /// </summary>
        int row;

        /// <summary>
        /// 何列目のセルかを保存する
        /// </summary>
        int column;

        public Cell(Vector2F position, string resourcePath, int row, int column)
            :base(position)
        {
            Texture = Texture2D.LoadStrict(resourcePath + "frame.png");
            collider.Size = Texture.Size;
            isEmpty = false;
            this.row = row;
            this.column = column;
        }
    }
}
