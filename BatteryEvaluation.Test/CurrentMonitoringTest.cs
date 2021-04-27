using CurrentRangesTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace BatteryEvaluation.Test
{
    public class CurrentMonitoringTest
    {
        CurrentMonitoring currentMonitoring = new CurrentMonitoring();
       
        [Fact]
        public void ValidateReadingList_EmptyCurrentReadingsList_False()
        {
            List<int> emptyReadingList = new List<int>();
            bool actualResult = currentMonitoring.ValidateReadingList(emptyReadingList);
            Assert.False(actualResult);
        }

        [Fact]
        public void ValidateReadingList_ValidCurrentReadingsList_True()
        {
            List<int> validReadingList = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            bool actualResult = currentMonitoring.ValidateReadingList(validReadingList);
            Assert.True(actualResult);
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_ReadingListIsProvided_RangeWiseReadingsResult()
        {
            List<RangeWiseReadings> rangeWiseReadingsList = new List<RangeWiseReadings>();
            RangeWiseReadings newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "3-5";
            newReadingDetails.totalReadings = 4;
            rangeWiseReadingsList.Add(newReadingDetails);
            newReadingDetails = new RangeWiseReadings();
            newReadingDetails.rangeName = "10-12";
            newReadingDetails.totalReadings = 3;
            rangeWiseReadingsList.Add(newReadingDetails);
            CurrentMonitoring currentMonitoring = new CurrentMonitoring();
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            List<RangeWiseReadings> actualReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.True(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(rangeWiseReadingsList, actualReadingList));
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_EmptyReadingListIsProvided_NullRangeWiseReadingsResult()
        {            
            List<int> emptyReadingList = new List<int>();
            List<RangeWiseReadings> actualReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(emptyReadingList);
            Assert.Null(actualReadingList);
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_ReadingListIsGiven_ExpectingRangeWiseReadings()
        {
            List<RangeWiseReadings> expectedRangeWiseReadings = new List<RangeWiseReadings>();
            RangeWiseReadings readingInformation = new RangeWiseReadings();
            readingInformation.rangeName = "3-5";
            readingInformation.totalReadings = 4;
            expectedRangeWiseReadings.Add(readingInformation);
            readingInformation = new RangeWiseReadings();
            readingInformation.rangeName = "7-8";
            readingInformation.totalReadings = 2;
            expectedRangeWiseReadings.Add(readingInformation);
            readingInformation = new RangeWiseReadings();
            readingInformation.rangeName = "10-12";
            readingInformation.totalReadings = 3;
            expectedRangeWiseReadings.Add(readingInformation);
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 7, 8, 10, 11, 12 };
            List<RangeWiseReadings> actualRangeWiseReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.True(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(expectedRangeWiseReadings, actualRangeWiseReadingList));
        }

        [Fact]
        public void FindRangeWiseReadingsFromCurrentList_ReadingListIsGiven_FalseExpectedCheck()
        {
            List<RangeWiseReadings> falseExpectedReadings = new List<RangeWiseReadings>();
            RangeWiseReadings readingDetails = new RangeWiseReadings();
            readingDetails.rangeName = "3-5";
            readingDetails.totalReadings = 4;
            falseExpectedReadings.Add(readingDetails);
            readingDetails = new RangeWiseReadings();
            readingDetails.rangeName = "10-12";
            readingDetails.totalReadings = 3;
            falseExpectedReadings.Add(readingDetails);
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 7, 8, 10, 11, 12 };
            List<RangeWiseReadings> actualRangeReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.False(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(falseExpectedReadings, actualRangeReadingList));
        }
    }
}
