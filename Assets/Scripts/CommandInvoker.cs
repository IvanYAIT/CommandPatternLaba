using UnityEngine;

namespace Command
{
    class CommandInvoker
    {
        public static void Invoke(ICommand command, Vector2 mousePosition) =>
            command.Invoke(mousePosition);
    }
}