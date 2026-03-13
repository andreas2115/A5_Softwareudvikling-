using System;
//using System.Runtime.CompilerServices;
//using Library;
namespace Library;
//namespace CountedInt;

public class ComparisonCountedInt : IComparable {

    private int integer;
    private int count;

    public ComparisonCountedInt(int integer) {
        this.integer = integer;
        this.count = 0;
    }

    // makes a get for count.
    // a read only called ComparisonCount
    public int ComparisonCount{
        get { return count; }
    }

    // A method from IComparable, that is adjusted to increase count 
    // as well as compare this with other. 
    public int CompareTo(object obj) {
        count ++;
        // type-cast syntax help chatGPT, obj gets typecasted into a ComparisonCountedInt. 
        if (obj == null) return 1;
        if (obj is not ComparisonCountedInt other) {
        throw new ArgumentException("Object is not a ComparisonCountedInt");
        }
        //ComparisonCountedInt other = (ComparisonCountedInt)obj; 
        return integer.CompareTo(other.integer);
    }


    public static int CountComparisons(ComparisonCountedInt[] array){
        int sum = 0; 
        for (int i = 0; i < array.Length; i++)
            sum += array[i].ComparisonCount;
        
        return sum;
    }

}