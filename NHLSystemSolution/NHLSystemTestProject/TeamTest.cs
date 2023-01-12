using NHLSystemClassLibrary;
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
        [DataRow(null, "Name cannot be blank")]
        [DataRow("", "Name cannot be blank")]
        [DataRow(" ", "Name cannot be blank")]

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
    }
}