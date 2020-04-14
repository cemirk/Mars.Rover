using System;
using Mars.Rover.Interfaces;

namespace Mars.Rover.Models
{
    public class Rover : IRover
    {
        public string Name { get; set; }
        public State State { get; set; }

        public Rover()
        {
            //initial state
            State = new State {Direction = Direction.N, Status = Status.Idle};
        }

        public CommandResult ApplyCommands(string commands)
        {
            var commandsArray = commands.Split(' ');
            if (commandsArray.Length < 6)
                return new CommandResult {ErrorMessage = "Invalid Command"};
            Move(commandsArray);
            State.Status = Status.Idle;
            return new CommandResult {Rover = this, IsSuccess = true};
        }

        private void Move(string[] commands)
        {
            int.TryParse(commands[0], out var maxX);
            int.TryParse(commands[1], out var maxY);
            int.TryParse(commands[2], out var initialX);
            int.TryParse(commands[3], out var initialY);
            Enum.TryParse<Direction>(commands[4].ToUpper(), out var initialDirection);
            var moves = commands[5].ToUpper();
            var maxCoords = new[] {maxX, maxY};
            State = new State {Direction = initialDirection, Status = Status.Moving, X = initialX, Y = initialY};
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveForward(maxCoords);

                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                }

                if (State.Status == Status.Died)
                {
                    break;
                }
            }
        }

        private void TurnRight()
        {
            if (State.Direction == Direction.W)
                State.Direction = Direction.N;
            else
                State.Direction++;
        }

        private void TurnLeft()
        {
            if (State.Direction == Direction.N)
                State.Direction = Direction.W;
            else
                State.Direction--;
        }

        private void MoveForward(int[] maxCoords)
        {
            var maxX = maxCoords[0];
            var maxY = maxCoords[1];
            switch (State.Direction)
            {
                case Direction.N:
                    if (State.Y + 1 >= maxY)
                    {
                        State.Status = Status.Died;
                    }

                    if (!CheckIfIDie(State.X, State.Y + 1))
                        State.Y += 1;
                    break;
                case Direction.S:
                    if (State.Y - 1 >= 0)
                    {
                        State.Status = Status.Died;
                    }

                    if (!CheckIfIDie(State.X, State.Y + 1))
                        State.Y -= 1;
                    break;
                case Direction.E:
                    if (State.X + 1 >= maxX)
                    {
                        State.Status = Status.Died;
                    }

                    if (!CheckIfIDie(State.X, State.Y + 1))
                        State.X += 1;
                    break;
                case Direction.W:
                    if (State.X - 1 >= 0)
                    {
                        State.Status = Status.Died;
                    }

                    if (!CheckIfIDie(State.X, State.Y + 1))
                        State.X -= 1;
                    break;
            }
        }

        private bool CheckIfIDie(int stateX, int stateY)
        {
            return DangerZoneDbRepo.Instance.Value.IsRestricted(stateX, stateY);
        }
    }
}