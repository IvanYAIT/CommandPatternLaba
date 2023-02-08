using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class CommandInvoker
    {
        private List<ICommand> _queueOfCompletedCommands;
        private List<SpawnPrefabCommand> _queueOfIncompletedCommands;
        private int _queueLenght;

        public CommandInvoker(int queueLenght)
        {
            _queueOfCompletedCommands = new List<ICommand>(queueLenght);
            _queueLenght = queueLenght;
        }

        public void AddCommandToQueue(SpawnPrefabCommand command) =>
            _queueOfIncompletedCommands.Add(command);

        public void InvokeAllIncompletedCommands()
        {
            foreach (SpawnPrefabCommand command in _queueOfIncompletedCommands)
            {
                command.Invoke();
            }
        }

        public void Invoke(ICommand command, Vector2 mousePosition)
        {
            if (_queueOfCompletedCommands.Count == _queueLenght)
                _queueOfCompletedCommands.RemoveAt(_queueOfCompletedCommands.Count-1);

            _queueOfCompletedCommands.Add(command);
            command.Invoke(mousePosition);
        }

        public void Undo()
        {
            if(_queueOfCompletedCommands.Count > 0)
            {
                ICommand command = _queueOfCompletedCommands[_queueOfCompletedCommands.Count - 1];
                _queueOfCompletedCommands.RemoveAt(_queueOfCompletedCommands.Count - 1);
                command.Undo();
            }
        }
    }
}