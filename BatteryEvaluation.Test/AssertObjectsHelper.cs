using BatteryEvaluation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CurrentRangesTest
{
    public static class AssertObjectsHelper
    {
        public static bool ExpectedAndActualObjectsAreEqual(List<RangeWiseReadings> expectedList, List<RangeWiseReadings> actualList)
        {
            bool result=false;
            if (expectedList.Count == actualList.Count)
            {
                for (int i = 0; i < expectedList.Count(); i++)
                {
                    var expectedValue = expectedList[i];
                    var actualValue = actualList[i];
                    result=AssertPropertiesOfObjectAreEquals((RangeWiseReadings)actualValue, (RangeWiseReadings)expectedValue);
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        private static bool AssertPropertiesOfObjectAreEquals(RangeWiseReadings actualObject, RangeWiseReadings expectedObject)
        {
            bool result = false;
            PropertyInfo[] properties = expectedObject.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expectedObject, null);
                object actualValue = property.GetValue(actualObject, null);
                if (!Equals(expectedValue, actualValue))
                {
                    result = false;
                    break;
                }
            }
            result = true;
            return result;

        }

    }
}
