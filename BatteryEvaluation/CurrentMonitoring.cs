using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryEvaluation
{
    public class CurrentMonitoring
    {
        public bool ValidateReadingList(List<int> readingList)
        {
            if ((readingList != null) && (readingList.Count != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<RangeWiseReadings> FindRangeWiseReadingsFromCurrentList(List<int> readingsList)
        {
            List<RangeWiseReadings> rangeWiseReadingsFromList = new List<RangeWiseReadings>();
            if (ValidateReadingList(readingsList))
            {
                rangeWiseReadingsFromList = EvaluateCurrentRangesForRangeWiseReadings(readingsList);
            }   
            else
            {
                rangeWiseReadingsFromList = null;
            }
            return rangeWiseReadingsFromList;
        }

        private List<RangeWiseReadings> EvaluateCurrentRangesForRangeWiseReadings(List<int> readingList)
        {            
            List<RangeWiseReadings> rangeWiseReadingsFromList = new List<RangeWiseReadings>();
            RangeWiseReadings newRangeWiseReading = new RangeWiseReadings();
            int i=0,startRange = 0, endRange = 0, currentReading = 0, counter = 0;
            readingList.Sort();
            for (i = 0; i < readingList.Count(); i++)
            {
                if (counter == 0)
                {
                    startRange = readingList[i];
                    endRange = readingList[i];
                    currentReading = readingList[i];
                    counter = 1;
                    continue;
                }
                else if (readingList[i] == currentReading + 1)
                {
                    endRange = readingList[i];
                    currentReading = readingList[i];
                    counter++;
                }
                else
                {
                    newRangeWiseReading = new RangeWiseReadings();
                    newRangeWiseReading.rangeName = startRange + "-" + endRange;
                    newRangeWiseReading.totalReadings = counter;
                    rangeWiseReadingsFromList.Add(newRangeWiseReading);
                    startRange = readingList[i];
                    endRange = readingList[i];
                    currentReading = readingList[i];
                    counter = 1;
                }

            }
            newRangeWiseReading = new RangeWiseReadings();
            newRangeWiseReading.rangeName = startRange + "-" + endRange;
            newRangeWiseReading.totalReadings = counter;
            rangeWiseReadingsFromList.Add(newRangeWiseReading);
            return rangeWiseReadingsFromList;
        }
    }
}
