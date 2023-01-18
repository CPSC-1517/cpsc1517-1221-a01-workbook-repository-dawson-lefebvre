using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHLSystemClassLibrary;

namespace NHLSystemTestProject
{
    [TestClass]
    public class PlayerTest
    {

        //VALID DATA TEST
        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, 46, 38, 46)]
        [DataRow(29, "Leon Draisaitl", Position.C, 44, 26, 44)]
        [DataRow(91, "Evander Kane", Position.LW, 15, 5, 8)]
        public void Name_ValidName_NameSet(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            //Arange

            Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
            //Act
            //Assert
            Assert.AreEqual(testPlayer.Name, name);
            Assert.AreEqual(testPlayer.PlayerNo, playerNo);
            Assert.AreEqual(testPlayer.GamesPlayed, gamesPlayed);
            Assert.AreEqual(testPlayer.Goals, goals);
            Assert.AreEqual(testPlayer.Assists, assists);
            Assert.AreEqual(testPlayer.Points, goals + assists);
        }

        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, 46, 38, 46)]
        [DataRow(29, "Leon Draisaitl", Position.C, 44, 26, 44)]
        [DataRow(91, "Evander Kane", Position.LW, 15, 5, 8)]
        public void Number_ValidNumber_NumberSet(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            //Arange

            Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
            //Act
            //Assert
            Assert.AreEqual(testPlayer.PlayerNo, playerNo);
        }

        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, 46, 38, 46)]
        [DataRow(29, "Leon Draisaitl", Position.C, 44, 26, 44)]
        [DataRow(91, "Evander Kane", Position.LW, 15, 5, 8)]
        public void GamesPlayed_ValidGamesPlayed_GamesPlayedSet(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            //Arange

            Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
            //Act
            //Assert
            
            Assert.AreEqual(testPlayer.GamesPlayed, gamesPlayed);
            
        }

        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, 46, 38, 46)]
        [DataRow(29, "Leon Draisaitl", Position.C, 44, 26, 44)]
        [DataRow(91, "Evander Kane", Position.LW, 15, 5, 8)]
        public void Goals_ValidGoals_GoalsSet(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            //Arange

            Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
            //Act
            //Assert
            
            Assert.AreEqual(testPlayer.Goals, goals);
            
        }

        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, 46, 38, 46)]
        [DataRow(29, "Leon Draisaitl", Position.C, 44, 26, 44)]
        [DataRow(91, "Evander Kane", Position.LW, 15, 5, 8)]
        public void Assists_ValidAssists_AssistsSet(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            //Arange

            Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
            //Act
            //Assert

            Assert.AreEqual(testPlayer.Assists, assists);

        }

        //INVALID DATA TEST
        [TestMethod]
        [DataRow(97, null, Position.C, 46, 38, 46, "Value cannot be null.")]
        [DataRow(29, "", Position.C, 44, 26, 44, "Name cannot be blank")]
        [DataRow(91, " ", Position.LW, 15, 5, 8, "Name cannot be blank")]

        public void Name_InvalidName_ThrowsArgumentNulLException(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists, string expectedResult)
        {
            try
            {
                Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
                Assert.Fail("Should have thrown ArgumentNullExeption");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult);
            }
        }

        [TestMethod]
        [DataRow(99, "Connor McDavid", Position.C, 46, 38, 46, "Player number must be 1-98")]
        [DataRow(0, "Leon Draisaitl", Position.C, 44, 26, 44, "Player number must be 1-98")]

        public void Number_InvalidNumber_ThrowsArgumentOutOfRangeException(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists, string expectedResult)
        {
            try
            {
                Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
                Assert.Fail("Should have thrown ArgumentOutOfRangeExeption");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult);
            }
        }

        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, -1, 38, 46, "Games played cannot be less than 0")]

        public void GamesPlayed_InvalidGamesPlayed_ThrowsArgumentOutOfRangeException(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists, string expectedResult)
        {
            try
            {
                Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
                Assert.Fail("Should have thrown ArgumentOutOfRangeExeption");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult);
            }
        }

        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, 46, -1, 46, "Goals cannot be less than 0")]

        public void Goals_InvalidGoals_ThrowsArgumentOutOfRangeException(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists, string expectedResult)
        {
            try
            {
                Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
                Assert.Fail("Should have thrown ArgumentOutOfRangeExeption");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult);
            }
        }

        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C, 46, 38, -1, "Assists cannot be less than 0")]

        public void Assists_InvalidAssists_ThrowsArgumentOutOfRangeException(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists, string expectedResult)
        {
            try
            {
                Player testPlayer = new Player(playerNo, name, position, gamesPlayed, goals, assists);
                Assert.Fail("Should have thrown ArgumentOutOfRangeExeption");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult);
            }
        }
    }
}
