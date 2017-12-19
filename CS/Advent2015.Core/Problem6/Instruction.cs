using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem6
{
    public class Instruction
    {
        public static Instruction Create(string instruction)
        {
            if (instruction.StartsWith("turn off"))
            {
                return Create(instruction.Substring(9, instruction.Length - 9), InstructionAction.TurnOff);
            }
            else if (instruction.StartsWith("toggle"))
            {
                return Create(instruction.Substring(7, instruction.Length - 7), InstructionAction.Toggle);
            }
            else if (instruction.StartsWith("turn on"))
            {
                return Create(instruction.Substring(8, instruction.Length - 8), InstructionAction.TurnOn);
            }

            throw new ArgumentException("Unrecognized instruction: could not determine action");
        }

        private static Instruction Create(string instructions, InstructionAction action)
        {
            var coordinates = instructions.Split(new string[] { "through" }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(ar => Coordinate.Create(ar));

            return new Instruction(action,
                                   new CoordinateRectangle(coordinates.ElementAt(0), coordinates.ElementAt(1)));
        }

        public Instruction(InstructionAction action, CoordinateRectangle rectangle)
        {
            this.Action = action;
            this.Rectangle = rectangle;
        }

        public InstructionAction Action { get; private set; }

        public CoordinateRectangle Rectangle { get; private set; }
    }

    public enum InstructionAction
    {
        Toggle,
        TurnOn,
        TurnOff
    };
}
