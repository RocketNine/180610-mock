using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class SpaceportDepartureBoardTest
    {
        [Test]
        public void SpaceportDepartureBoard_LaunchInfoSortedByDestination()
        {
            // Arrange
            var mock = new MockProvider();
            var launch1 = new LaunchInfo();
            launch1.Destination = "Jupiter";
            var launch2 = new LaunchInfo();
            launch2.Destination = "Oort Cloud";
            var launch3 = new LaunchInfo();
            launch3.Destination = "Hoth";

            var myList = new List<LaunchInfo>();
            myList.Add(launch1);
            myList.Add(launch2);
            myList.Add(launch3);
            mock.listOfLaunches = myList;

            // Act
            var board = new SpaceportDepartureBoard(mock);

            // Assert
            var expected = new List<LaunchInfo>();
            expected.Add(launch3);
            expected.Add(launch1);
            expected.Add(launch2);
            Assert.AreEqual(expected, board.LaunchList);
            Assert.AreEqual("Hoth", board.LaunchList[0].Destination, "Hoth is first alphabetically");
            Assert.AreEqual("Jupiter", board.LaunchList[1].Destination, "Jupiter is second alphabetically");
            Assert.AreEqual("Oort Cloud", board.LaunchList[2].Destination, "Oort Cloud is third alphabetically");
        }
    }
    
    public class MockProvider : ISpacelineLaunchInfoProvider
    {
        public IDisposable Subscribe(IObserver<LaunchInfo> observer)
        {
            return null;
        }

        public List<LaunchInfo> GetCurrentLaunches()
        {
            return listOfLaunches;
        }

        public List<LaunchInfo> listOfLaunches { get; set; }
    }
}