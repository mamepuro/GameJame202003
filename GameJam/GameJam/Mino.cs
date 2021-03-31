using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace GameJam
{
    class Mino:CollidableObject
    {
        private const int ROW = 2;
        private const int COLUMN = 3;
        //注目するブロック番号
        public const int mainBlock = 3;
        public List<Block> mino = new List<Block>();
        //2*3の長方形を準備
        private int[,] initMinoPattern = new int[ROW, COLUMN]
        {{ 1, 0, 1},
         { 1, 1, 1}
        };
        public Mino(Vector2F position, string resourcePath)
            :base(position)
        {
            Texture = Texture2D.LoadStrict(resourcePath + "MousePointer.png");
            collider.Size = new Vector2F(Texture.Size.X * COLUMN, Texture.Size.Y * ROW);
            Console.WriteLine("{0}, {1}", collider.Size.X, collider.Size.Y);
            Console.WriteLine("{0}, {1}", collider.Position.X, collider.Position.Y);
            doSurvey = false;
            for(int row = 0; row < ROW; row++)
            {
                for(int column = 0; column < COLUMN; column++)
                {
                    if(initMinoPattern[row,column] == 1)
                    {
                        var block = new Block(new Vector2F(Position.X + (column * Texture.Size.X), Position.Y + (row * Texture.Size.Y)), resourcePath, row, column);
                        mino.Add(block);
                        Engine.AddNode(block);
                    }
                    Console.WriteLine(mino.Count);
                }
            }
        }
        public void Rotate()
        {

        }
        protected override void OnCollide(CollidableObject obj)
        {
            //Console.WriteLine(this.collider.Position);
        }
    }
}
