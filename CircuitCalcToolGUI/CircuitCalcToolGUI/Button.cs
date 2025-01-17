﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitCalcToolGUI
{
    class Button
    {
        public Button(Position pos, int width, string title = "")
        {
            this.pos = pos;
            this.width = width;
            this.title = title;

            Border border = StringBuilder.GetPreset(new Position(width, 3), 0);
            text = StringBuilder.Border(border);

            Initialize();

        }
        public Button(Position pos, int width, int preset, string title = "")
        {
            this.pos = pos;
            this.width = width;
            this.title = title;

            Border border = StringBuilder.GetPreset(new Position(width, 3), preset);
            text = StringBuilder.Border(border);

            Initialize();

        }
        public Button(Position pos, int width, string cornTop, string cornBot, string borderVert, string borderHori, string title = "")
        {
            this.pos = pos;
            this.width = width;
            this.title = title;

            text = StringBuilder.Border(new Border(new Position(width, 3), cornTop, cornBot, borderVert, borderHori));

            Initialize();
        }

        private void Initialize()
        {
            UpdateArr();
        }

        public readonly Position pos;
        public readonly int width;
        public string[] text = new string[3];
        public string title;

        public event EventHandler Clicked;
        protected virtual void OnClicked(EventArgs e)
        {
            EventHandler handler = Clicked;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        public void Press()
        {
            OnClicked(EventArgs.Empty);
        }


        public bool ChangeValue(string toChange)
        {
            title = toChange;
            UpdateArr();
            return true;
        }
        private void UpdateArr()
        {
            for (int c = 1; c < width - 1; c++)
            {
                if (c < title.Length + 1)
                    text[1] = ChangeChar(text[1], c, title[c - 1].ToString());
                else
                    text[1] = ChangeChar(text[1], c, " ");
            }
        }

        private string ChangeChar(string s, int index, string newChar)
        {
            return s.Remove(index, 1).Insert(index, newChar);
        }
    }
}
