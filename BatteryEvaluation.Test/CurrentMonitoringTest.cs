using CurrentRangesTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace BatteryEvaluation.Test
{
    public class CurrentMonitoringTest
    {
        CurrentMonitoring currentMonitoring = new CurrentMonitoring();
        private List<RangeWiseReadings> ExpectedResultList()
        {
            List<RangeWiseReadings> expectedRangeWiseReadings = new List<RangeWiseReadings>();
            RangeWiseReadings readingInformation = new RangeWiseReadings();
            readingInformation.rangeName = "3-5";
            readingInformation.totalReadings = 4;
            expectedRangeWiseReadings.Add(readingInformation);
            readingInformation = new RangeWiseReadings();
            readingInformation.rangeName = "10-12";
            readingInformation.totalReadings = 3;
            expectedRangeWiseReadings.Add(readingInformation);
            return expectedRangeWiseReadings;
        }

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
            List<RangeWiseReadings> rangeWiseReadingsList = ExpectedResultList();
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
        public void FindRangeWiseReadingsFromCurrentList_ReadingListIsGiven_FalseExpectedCheck()
        {
            List<RangeWiseReadings> falseExpectedReadings = ExpectedResultList();
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 7, 8, 10, 11, 12 };
            List<RangeWiseReadings> actualRangeReadingList = currentMonitoring.FindRangeWiseReadingsFromCurrentList(currentReadingsList);
            Assert.False(AssertObjectsHelper.ExpectedAndActualObjectsAreEqual(falseExpectedReadings, actualRangeReadingList));
        }
    }
}
