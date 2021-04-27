using CurrentRangesTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace BatteryEvaluation.Test
{
    public class CurrentMonitoringTest
    {

        [Fact]
        public void ValidateReadingList_EmptyCurrentReadingsList_False()
        {
            CurrentMonitoring currentMonitoring = new CurrentMonitoring();
            List<int> currentReadingsList = new List<int>();
            bool actualResult = currentMonitoring.ValidateReadingList(currentReadingsList);
            Assert.False(actualResult);
        }

        [Fact]
        public void ValidateReadingList_ValidCurrentReadingsList_True()
        {
            CurrentMonitoring currentMonitoring = new CurrentMonitoring();
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            bool actualResult = currentMonitoring.ValidateReadingList(currentReadingsList);
            Assert.True(actualResult);
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_ReadingListIsProvided_RangeWiseReadingsResult()
        {
            List<RangeWiseReadings> rangeWiseReadings = new List<RangeWiseReadings>();
            RangeWiseReadings newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "3-5";
            newReadingDetails.totalReadings = 4;
            rangeWiseReadings.Add(newReadingDetails);
            newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "10-12";
            newReadingDetails.totalReadings = 3;
            rangeWiseReadings.Add(newReadingDetails);
            CurrentMonitoring currentMonitoring = new CurrentMonitoring();
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            List<RangeWiseReadings> actualReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.True(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(rangeWiseReadings, actualReadingList));
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_EmptyReadingListIsProvided_RangeWiseReadingsResult()
        {
            CurrentMonitoring currentMonitoring = new CurrentMonitoring();
            List<int> currentReadingsList = new List<int>();
            List<RangeWiseReadings> actualReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.Null(actualReadingList);
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_ReadingListIsGiven_ExpectingRangeWiseReadings()
        {
            List<RangeWiseReadings> rangeWiseReadings = new List<RangeWiseReadings>();
            RangeWiseReadings newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "3-5";
            newReadingDetails.totalReadings = 4;
            rangeWiseReadings.Add(newReadingDetails);
            newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "7-8";
            newReadingDetails.totalReadings = 2;
            rangeWiseReadings.Add(newReadingDetails);
            newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "10-12";
            newReadingDetails.totalReadings = 3;
            rangeWiseReadings.Add(newReadingDetails);
            CurrentMonitoring currentMonitoring = new CurrentMonitoring();
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 7, 8, 10, 11, 12 };
            List<RangeWiseReadings> actualReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.True(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(rangeWiseReadings, actualReadingList));
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_ReadingListIsGiven_FalseExpectedCheck()
        {
            List<RangeWiseReadings> rangeWiseReadings = new List<RangeWiseReadings>();
            RangeWiseReadings newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "3-5";
            newReadingDetails.totalReadings = 4;
            rangeWiseReadings.Add(newReadingDetails);            
            newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "10-12";
            newReadingDetails.totalReadings = 3;
            rangeWiseReadings.Add(newReadingDetails);
            CurrentMonitoring currentMonitoring = new CurrentMonitoring();
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 7, 8, 10, 11, 12 };
            List<RangeWiseReadings> actualReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.False(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(rangeWiseReadings, actualReadingList));
        }
    }
}
