using System;

namespace Library;
public static class Search {
    public static int Binary(IComparable[] array, IComparable target) {
        // A relevant situation that could result in
        // an out-of-bounce would be if the input is Null. 
        // This would cast a null ref. exception. 
        // instead we construct a guardrail:
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        var low = 0;
        var high = array.Length - 1;

        if (array.Length == 0)
            return -1;

        // 2.7 Optimization. Before starting the search of a sorted array we can check 
        // if the target is with the upper/lower bound by comparing it to the first,
        // and the last element of the array.
        if (target.CompareTo(array[low]) < 0|| target.CompareTo(array[high]) > 0)
            return -1;


        while (low <= high) {
            //var mid = (high + low) / 2;
            // high + low results in integers that could exceed the 32bit limit.
            // This can be solved by calculating the difference (high-low)
            // and adding to low. This increases the limit. 
            var mid = low + (high - low) / 2;

            // Another cause for out-of-bounce errors could be
            // Lines like this: var midVal = array[mid];
            // If mid ends up being negative, or larger than or equal to array.Length
            // then we will get an Out-of-Bounds error. 
            // (dificult to test, and would never happen this case...)
            // The gaurd rails makes sure that this is not the case
            // or throws an exception
            if (mid < 0 || mid >= array.Length){
                throw new IndexOutOfRangeException(mid.ToString()); 
            } 

            var midVal = array[mid];
            var relation = midVal.CompareTo(target);
        
            if (relation < 0) {
                low = mid + 1;
            } else if (relation > 0) {
                high = mid - 1;
            } else {
                if (mid == 0 || array[mid - 1].CompareTo(target) < 0){
                    return mid;
                }
                high = mid - 1;
            }
        }

        return -1;
    }

    public static int Jump(IComparable[] array, IComparable target) {

        // Some inital checks taken from Binary
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        var low = 0;
        var high = array.Length - 1;

        if (array.Length == 0)
            return -1;

        if (target.CompareTo(array[low]) < 0 || target.CompareTo(array[high]) > 0)
            return -1;


        int jump = (int)Math.Floor(Math.Sqrt(array.Length));
        int prev = 0;
        int current = jump;
        
        // Jump forward, until a block could contain the target
        while(array[Math.Min(current, array.Length)-1].CompareTo(target) < 0) {
            prev = current;
            current += jump;

            if (prev >= array.Length)
                return -1;
        }

        // Once inside a block that could contain the target, performce linear search.

        for (int i = prev; i < Math.Min(current, array.Length); i++) {
            int foundTarget = array[i].CompareTo(target);
            // if we found the target return the index
            if (foundTarget == 0)
                return i;
            // if the element is larger than the target, then it is out of bounce
            // and it should return -1 (acts as a stop since this condition is already accounted for)
            if (foundTarget > 0)
                return -1;
        }
        return -1;
    }

    
}