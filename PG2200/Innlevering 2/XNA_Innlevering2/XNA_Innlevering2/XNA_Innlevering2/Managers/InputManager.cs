using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XNA_Innlevering2.GameObjects;


namespace XNA_Innlevering2.GameComponents
{
    public class InputManager : GameComponent
    {
        private List<Action> actions;

        public InputManager(Game game) : base(game)
        {
            actions = new List<Action>();
        }

        public void AddAction(String ActionName)
        {
            actions.Add(new Action(this, ActionName));
        }

        public Action this[String actionName]
        {
            get
            {
                return actions.Find(a => a.name == actionName);
            }
        }

        public void Update()
        {
            KeyboardState kbState = Keyboard.GetState();

            foreach (Action a in actions)
            {
                a.Update(kbState);
            }

        }
    }

    public class Action
    {
        public String name;
        List<Keys> keyList = new List<Keys>();
        
        private InputManager parent = null;
        private bool currentStatus = false;
        private bool previousStatus = false;

        public bool IsDown { get { return currentStatus; } }
        public bool IsTapped { get { return (currentStatus) && (!previousStatus); } }

        public Action(InputManager inputManager, String n)
        {
            parent = inputManager;
            name = n;
        }

        public void Add(Keys key)
        {
            if (!keyList.Contains(key))
                keyList.Add(key);
        }

        internal void Update(KeyboardState kbState)
        {
            previousStatus = currentStatus;
            currentStatus = false;

            foreach (Keys k in keyList)
                if (kbState.IsKeyDown(k))
                    currentStatus = true;
        }

    }
}
