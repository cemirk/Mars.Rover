using Mars.Rover.Models;
using NUnit.Framework;

namespace Mars.Rover.UnitTest
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Call_ApplyCommand_With_Invalid_Input_Should_Receive_Invalid_Command_Message()
        {
            //Arrange
            var rover = new Models.Rover
            {
                Name = "Curiosity"
            };
            var commands = "LMLMLMLMM";
            var expectedResult = new CommandResult
            {
                IsSuccess = false,
                ErrorMessage = "Invalid Command",
                Rover = new Models.Rover
                {
                Name = "Curiosity",
                State = new State
                {
                    Direction = Direction.N, X = 0, Y = 0
                }
            }
            };
        }

        [Test]
        public void Call_ApplyCommand_With_1_2_N_LMLMLMLMM_Input_Should_Get_Expected_Result()
        {
            //Arrange
            var rover = new Models.Rover
            {
                Name = "Curiosity"
            };
            var commands = "5 5 1 2 N LMLMLMLMM";
            var expectedResult = new CommandResult
            {
                IsSuccess = true,
                Rover = new Models.Rover
                {
                    Name = "Curiosity",
                    State = new State
                    {
                        Direction = Direction.N, X = 1, Y = 3
                    }
                }
            };
            //Assert
            var result = rover.ApplyCommands(commands);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Call_ApplyCommand_With_3_3_E_MMRMMRMRRM_Input_Should_Get_Expected_Result()
        {
            //Arrange
            var rover = new Models.Rover
            {
                Name = "Perseverance"
            };
            var commands = "5 5 3 3 E MMRMMRMRRM";
            var expectedResult = new CommandResult
            {
                IsSuccess = true,
                Rover = new Models.Rover
                {
                    Name = "Perseverance",
                    State = new State
                    {
                        Direction = Direction.E, X = 5, Y = 1
                    }
                }
            };
            //Assert
            var result = rover.ApplyCommands(commands);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}