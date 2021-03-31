using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace GameJam
{
    class MousePointer : CollidableObject
    {
        private string resourcePath;
        private Texture2D leftClick;
        private Texture2D nomalState;
        private bool doHaveMino;
        private Mino Mino;
        //x
        private Vector2F prePosition;
        private int count;
        public MousePointer(Vector2F position ,string resourcePath)
            :base(position)
        {
            nomalState = Texture2D.LoadStrict(resourcePath + "mouse.png");
            Texture = nomalState;
            leftClick = Texture2D.LoadStrict(resourcePath + "left-click-mouse.png");
            this.resourcePath = resourcePath;
            collider.Size = Texture.Size;
            doSurvey = true;
            doHaveMino = false;
            count = 0;
        }

        //マウスの動き全般を管理
        public void MoveMouse()
        {
            prePosition = Position;
            Position = Engine.Mouse.Position - new Vector2F(Texture.Size.X / 2, Texture.Size.Y / 2);
            Vector2F moveVector = (Position - prePosition);
            Console.WriteLine(moveVector);
            if (Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Hold)
            {
                Texture = leftClick;
            } else
            {
                Texture = nomalState;
            }
        }
        public void MoveMino()
        {
            if(doHaveMino)
            { 
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            MoveMouse();
            count++;
        }

        protected override void OnCollide(CollidableObject obj)
        {
            base.OnCollide(obj);
            if(obj is Mino)
            {
                var mino = (Mino)obj;
                if(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Push)
                {
                }
                if(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Hold)
                {
                    //参照するMinoを登録する
                    Mino = mino;
                    Vector2F moveVector = (Position - prePosition);
                    Console.WriteLine(moveVector);
                    if (moveVector != new Vector2F(0, 0))
                    {
                        prePosition = Position;
                    }
                    //Console.WriteLine(moveVector);
                    foreach (var m in Mino.mino)
                    {
                        m.Position += moveVector;
                    }
                    mino.Position += moveVector;
                    var mainBlock = mino.mino[Mino.mainBlock];
                    Position = mainBlock.Position + new Vector2F(mainBlock.Texture.Size.X / 2, mainBlock.Texture.Size.Y / 2);
                    prePosition = Position;
                    doHaveMino = true;
                }
                if(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Release)
                {
                    doHaveMino = false;
                }
            }
/*            if(obj is Block)
            {
                if(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Hold)
                {
                    Console.WriteLine("a");
                    obj.Position = Engine.Mouse.Position - obj.Texture.Size / 2;
                    doHaveMino = true;
                    Block = (Block)obj;
                }else
                {
                    doHaveMino = false;
                }
            }*/
            if(obj is Cell)
            {
/*                if(doHaveMino)
                {
                    if(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Release)
                    {
                        Cell cell = (Cell)obj;
                        Block.Scale = new Vector2F(2, 2);
                        Block.collider.Size = Block.Texture.Size * 2;
                        Block.Position = obj.Position;
                        Block = null;
                        doHaveMino = false;
                        cell.isEmpty = false;
                    }
                }*/
/*                if(doHaveMino)
                {
                    if(Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft) == ButtonState.Release)
                    {
                        //objをCellであることを明記する
                        Cell cell = (Cell)obj;
                        Mino.Scale = new Vector2F(2, 2);
                        Mino.collider.Size *= new Vector2F(2, 2);
                        Mino.Position = cell.Position;
                        Mino = null;
                        doHaveMino = false;
                    }
                    else
                    {
                    }
                }*/
            }
        }
    }
}
