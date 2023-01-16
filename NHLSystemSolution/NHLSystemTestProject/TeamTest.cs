using NHLSystemClassLibrary;
using System.Runtime.CompilerServices;

namespace NHLSystemTestProject
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        [DataRow("Oilers")]
        [DataRow("Flames")]
        [DataRow("Canucks")]
        [DataRow("Maple Leafs")]
        [DataRow("Senators")]
        [DataRow("Canadiens")]
        public void Name_ValidName_NameSet(string teamName)
        {
            //Arange
            //Act
            Team currentTeam = new Team(teamName);
            //Assert
            Assert.AreEqual(teamName, currentTeam.Name);
        }

        [TestMethod]
        [DataRow(null, "Value cannot be null.")]
        [DataRow("", "Value cannot be null.")]
        [DataRow(" ", "Value cannot be null.")]
        [DataRow("Oilers1", "Name must contain only letters and spaces")]

        public void Name_InvalidName_ThrowsArgumentNulLException(string teamName, string expectedResult)
        {
            try
            {
                Team testTeam = new Team(teamName);
                Assert.Fail("Should have thrown ArgumentNullExeption");
            }
            catch(Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult); 
            }
        }

        [TestMethod]
        [DataRow ("Edmonton")]
        [DataRow("Calgary")]
        [DataRow("Vancouver")]
        [DataRow("Toronto")]
        [DataRow("Ottowa")]
        [DataRow("Montreal")]
        public void City_ValidCity_SetCity(string city)
        {
            Team testTeam = new Team(Conference.Eastern, Division.Atlantic, "Test Name", city, "Test Arena");
            Assert.AreEqual(testTeam.City, city);
        }

        [TestMethod]
        [DataRow(null, "Value cannot be null.")]
        [DataRow("", "Value cannot be null.")]
        [DataRow(" ", "Value cannot be null.")]
        [DataRow("LA", "City must be longer than 2 characters")]
        public void City_InvalidCity_ThrowsExeption(string city, string expectedResult)
        {
            try
            {
                Team testTeam = new Team(Conference.Eastern, Division.Atlantic, "Test Name", city, "Test Arena");
                Assert.Fail("Does not throw exception");
            }
            catch(Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult);
            }
            
        }

        [TestMethod]
        [DataRow("Rogers Place")]
        [DataRow("Saddle Dome")]
        [DataRow("Rogers Arena")]
        [DataRow("Scotiabank Arena")]
        [DataRow("Canadian Tire Centre")]
        [DataRow("Centre Bell")]
        public void Arena_ValidArena_SetArena(string arena)
        {
            Team testTeam = new Team(Conference.Eastern, Division.Atlantic, "Test Name", "Test City", arena);
            Assert.AreEqual(testTeam.Arena, arena);
        }

        [TestMethod]
        [DataRow(null, "Value cannot be null.")]
        [DataRow("", "Value cannot be null.")]
        [DataRow(" ", "Value cannot be null.")]

        public void Arena_InvalidArena_ThrowsException(string arena, string expectedResult)
        {
            try
            {
                Team testTeam = new Team(Conference.Eastern, Division.Atlantic, "Test Name", "Test City", arena);
                Assert.Fail("Does not throw Exeption");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, expectedResult);
            }
        }
    }
}