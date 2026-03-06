using System;

namespace PersonNS;
internal class Program {
    private static void Main(string[] args) {
        // Showing that the iComparable interface works
        // persons can be initiated, and set into person arrays. 
        // and are reperesented correctly with name and age. 
        Person per1 = new Person("Andreas", 25); 
        Person per2 = new Person("Jens", 25);
        Person[] perGroup = {per1, per2};
        foreach (Person p in perGroup){
            Console.WriteLine(p);
        }
    }
}
