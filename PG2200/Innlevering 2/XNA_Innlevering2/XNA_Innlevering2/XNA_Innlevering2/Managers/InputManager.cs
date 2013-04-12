using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XNA_Innlevering2.GameComponents
{
    public class InputManager : GameComponent
    {
        // create a list of actions
        private List<Action> actions;

        public InputManager(Game game) : base(game)
        {
            //instantiate the list of actions
            actions = new List<Action>();
        }

        //public field
        public Action this[String actionName]
        {
            // finds a given action by matching the name supplied with the name in the action lists
            get
            {
                //returns if name equals supplied name
                return actions.Find(a => a.Name == actionName);
            }
        }

        public void AddAction(String ActionName)
        {
            //adding an action with the manager, calls the add method for the new action instantiated
            actions.Add(new Action(ActionName));
        }

        public void Update()
        {
            //gets the current keyboard state every update
            KeyboardState kbState = Keyboard.GetState();

            //update every action in the action list every update
            foreach (Action a in actions)
            {
                a.Update(kbState);
            }
        }
    }

    public class Action
    {
        //the name for the key
        public String Name;

        // a list of keys for a given function
        private List<Keys> _keyList = new List<Keys>();

        //record status of current and previous states of the key
        private bool currentStatus;
        private bool previousStatus;

        public Action(String name)
        {
            Name = name;
        }

        //two states: tapped or held down
        public bool IsDown
        {
            get { return currentStatus; }
        }

        public bool IsTapped
        {
            get { return (currentStatus) && (!previousStatus); }
        }

        //when new action is created, associate it with a name

        //add new key method
        public void Add(Keys key)
        {
            //make sure the key doesn't exist already, before adding to list
            if (!_keyList.Contains(key))
                _keyList.Add(key);
        }

        internal void Update(KeyboardState kbState)
        {
            //check button press when updated...
            previousStatus = currentStatus;
            currentStatus = false;

            //... for every key in the list
            foreach (Keys k in _keyList)
                if (kbState.IsKeyDown(k))
                    currentStatus = true;
        }
    }
}