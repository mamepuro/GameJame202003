using System;
using System.Collections.Generic;
using Altseed2;

namespace GameJam
{
    class Program
    {
        public static readonly string resourcePath = "Resources/Textures/";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var cnf = new Configuration();
            //設定ファイルでtrueとかをfalseをいじれると良い？
            cnf.IsFullscreen = false;
            Engine.Initialize("test", 1280, 720, cnf);
            var m = new MousePointer(new Vector2F(300, 300), resourcePath);
//            var b = new Block(new Vector2F(300, 300), resourcePath, 0 , 0);
            var f = new Frame(new Vector2F(200, 200), resourcePath);
            var mino = new Mino(new Vector2F(500, 500), resourcePath);
            Engine.AddNode(mino);
            Engine.AddNode(m);
 //           Engine.AddNode(b);
            while (Engine.DoEvents())
            {
                Engine.Update();
                if (Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push)
                {
                    break;
                }
            }
            Engine.Terminate();
        }
    }
}
