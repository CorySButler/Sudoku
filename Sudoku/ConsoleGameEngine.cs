using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Sudoku
{
    public class Key
    {
        public bool IsHeld;
        public bool IsPressed;
        public bool IsReleased;
    }

    public class ConsoleGameEngine
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        private bool _atomActive = false;
        private int _screenWidth;
        private int _screenHeight;
        private int[] _keyOldState = new int[256];
        private int[] _keyNewState = new int[256];
        private Key[] _keys = new Key[256];

        public void ConstructConsole(int screenWidth, int screenHeight, int fontWidth = 12, int fontHeight = 12)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            Console.SetWindowSize(_screenWidth, _screenHeight);
            Console.SetBufferSize(_screenHeight, _screenHeight);

            // TODO: Change font size
        }

        public void Start()
        {
            _atomActive = true;

            Thread thread = new Thread(GameThread);
            thread.Start();
            thread.Join();
        }

        private void GameThread()
        {
            if (!OnUserCreate()) return;

            DateTime tp1 = DateTime.Now;
            DateTime tp2 = DateTime.Now;

            while (_atomActive)
            {
                tp2 = DateTime.Now;
                TimeSpan elapsedTime = tp2 - tp1;
                tp1 = tp2;

                for (int i = 0; i < 256; i++)
                {
                    _keyNewState[i] = GetAsyncKeyState(i);

                    _keys[i].IsPressed = false;
                    _keys[i].IsReleased = false;

                    if (_keyNewState[i] != _keyOldState[i])
                    {
                        if (_keyNewState[i] == 0x8000)
                        {
                            _keys[i].IsPressed = !_keys[i].IsHeld;
                            _keys[i].IsHeld = true;
                        }
                        else
                        {
                            _keys[i].IsReleased = true;
                            _keys[i].IsHeld = false;
                        }
                    }

                        _keyOldState[i] = _keyNewState[i];
                }

                if (!OnUserUpdate(elapsedTime)) _atomActive = false;
                
            }
        }

        public virtual bool OnUserCreate() => false;
        public virtual bool OnUserUpdate(TimeSpan elapsedTime) => false;
        public virtual bool OnUserDestroy() => true;
    }
}
