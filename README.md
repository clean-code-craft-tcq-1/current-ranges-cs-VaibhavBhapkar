# Test Driven Ranges

This exercise extends the [Battery Monitoring] use-case.

The charging current varies during the process of charging.
We need to capture the range of current measurements -
what range of currents are most often encountered while charging.

> **DO NOT** jump into implementation! Read the example and the starting task below.

## Example

### Input

Consider a set of periodic current samples from a charging session to be:
`3, 3, 5, 4, 10, 11, 12`

### Functionality

The continuous ranges in there are: `3,4,5` and `10,11,12`.

The task is to detect the ranges and
output the number of readings in each range.

In this example,

- the `3-5` range has `4` readings
- the `10-12` range has `3` readings.

### Output

The expected output would be:

```
Range, Readings
3-5, 4
10-12, 3
```

## Tasks

Start test-driven development:

1. Establish quality parameters for your project: What is the maximum complexity you would allow? How much duplication would you consider unacceptable? What is the coverage you'll aim for?
Adapt/adopt/extend the `yml` files from one of your workflow folders.

1. Write the smallest possible failing test.

1. Write the minimum amount of code that'll make it pass.

1. Write the next failing test.

Implement one failing test and at least one passing test:

- ValidateReadingList_ValidCurrentReadingsList_True | FindRangeWiseReadingsFromCurrentList_ReadingListIsProvided_RangeWiseReadingsResult 
- ValidateReadingList_EmptyCurrentReadingsList_False | FindRangeWiseReadingsFromCurrentList_EmptyReadingListIsProvided_NullRangeWiseReadingsResult | FindRangeWiseReadingsFromCurrentList_ReadingListIsGiven_FalseExpectedCheck




## MY ASSIGNMENT DETAILS

1. Firstly written a test to check current mesaurment list(empty & valid) accordinglt feature is added in devlopemnt
2. Second for finding the range wise reading test case is defined then written a function which will perform operation on list and return reading according to ranges
3. In test case while comparing the object its not allowing so written assertion helper which will help in comparing result object
4. Finally Added all the workflows complexity,duplication & build with test coverage.
