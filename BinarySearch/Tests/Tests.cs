using System;
//using System.Runtime.CompilerServices;
using Library;
using NUnit.Framework;
using PersonNS;


namespace Tests;
    [TestFixture]
    public class Test {
        [SetUp]
        public void Init() {
            gen = new Generator();
        }

        private Generator gen;

        [Test]
        public void TestTooLow(){
            IComparable[] array = {1, 2, 3, 4, 5};
            var index = Search.Binary(array, 0);
            Assert.AreEqual(-1, index);
        }
        [Test]
        public void TestTooHigh(){
            IComparable[] array = {1, 2, 3, 4, 5};
            var index = Search.Binary(array, 10);
            Assert.AreEqual(-1, index);
            
        }
        [Test]
        public void TestElement(){
            IComparable[] array = {1, 2, 3, 4, 5};
            var index = Search.Binary(array, 5);
            Assert.AreNotEqual(-1, index);
            Assert.AreEqual(4, index);
            
        }
        [Test]
        public void TestEmptyArray(){
            IComparable[] array = {};
            var index = Search.Binary(array, 0);
            Assert.AreEqual(-1, index);
            
        }
        // Additional test 1
        // Binary search expects a sorted array. The constructed array 
        // should make the algorithm return a false index.
        // Switching 4 and 3 makes the algorithm think that 3 is not in the array. 
        // since it thinks that 3 should be right before 4. 
        [Test]
        public void TestUnsortedArray(){
            IComparable[] array = {1, 2, 4, 3, 5};
            var index = Search.Binary(array, 3);
            Assert.AreNotEqual(3, index);
        }
        //additional test 2
        //checks that Binary search returns a least one true index 
        // of the searched number if there exists multiples
        [Test]
        public void TestDoublicatesArray(){
            IComparable[] array = {1, 2, 2, 2, 5};
            var index = Search.Binary(array, 2);
            bool istrue = index == 1; 
            Assert.IsTrue(istrue);
        }
        //additional test 3
        // Test if binary search is able to find negative values
        [Test]
        public void TestNegativeArray(){
            IComparable[] array = {-1, 2, 2, 2, 5};
            var index = Search.Binary(array, -1);
            Assert.AreEqual(0, index);
        }

        /*
        Persons Tests:
        */
        

        // Enitial test to check that binary works with the person class. 
        // Note that the list must i reverse order (largest age first)
        [Test]
        public void TestPersonElement(){
            Person per1 = new Person("Andreas", 25); 
            Person per2 = new Person("Jens", 24);
            Person per3 = new Person("Dennis", 23);
            Person per4 = new Person("Tine", 22);
            Person per5 = new Person("Finn", 21);
            Person[] perGroup = {per1, per2, per3, per4, per5};
            var index = Search.Binary(perGroup, per3);
            Assert.AreEqual(2,index);
        }

        // Test shows that a reversed order does not work 
        // and returns -1 when searching for an element that is present.
        // note that the order does not matter i the target is in the middle element
        // This is because the binary search algorithm starts at the middle element.
        [Test]
        public void TestPerson(){
            Person per1 = new Person("Andreas", 25); 
            Person per2 = new Person("Jens", 24);
            Person per3 = new Person("Dennis", 23);
            Person per4 = new Person("Tine", 22);
            Person per5 = new Person("Finn", 21);
            Person[] perGroup = {per5, per4, per3, per2, per1};
            var index = Search.Binary(perGroup, per2);
            Assert.AreEqual(-1,index);
        }


        // Test looks for a person with an age to low, but correct name
        [Test]
        public void TestPersonToLow(){
            Person per1 = new Person("Andreas", 25); 
            Person per2 = new Person("Jens", 24);
            Person per3 = new Person("Dennis", 23);
            Person per4 = new Person("Tine", 22);
            Person per5 = new Person("Finn", 21);
            Person perTest = new Person("Finn", 20);
            Person[] perGroup = {per1, per2, per3, per4, per5};
            var index = Search.Binary(perGroup, perTest);
            Assert.AreEqual(-1,index);
        }
        [Test]
        public void TestPersonToHigh(){
            Person per1 = new Person("Andreas", 25); 
            Person per2 = new Person("Jens", 24);
            Person per3 = new Person("Dennis", 23);
            Person per4 = new Person("Tine", 22);
            Person per5 = new Person("Finn", 21);
            Person perTest = new Person("Andreas", 26);
            Person[] perGroup = {per1, per2, per3, per4, per5};
            var index = Search.Binary(perGroup, perTest);
            Assert.AreEqual(-1,index);
            
        }


        [Test]
        public void TestPersonEmptyArray(){
            Person[] perGroup = {};
            Person perTest = new Person("Andreas", 26);
            var index = Search.Binary(perGroup, perTest);
            Assert.AreEqual(-1,index);
            
        }
        [Test]
        public void TestPersonUnsortedArray(){
            Person per1 = new Person("Andreas", 25); 
            Person per2 = new Person("Jens", 24);
            Person per3 = new Person("Dennis", 23);
            Person per4 = new Person("Tine", 22);
            Person per5 = new Person("Finn", 21);
            Person[] perGroup = {per1, per3, per2, per4, per5};
            var index = Search.Binary(perGroup, per3);
            Assert.AreEqual(-1,index);
            
        }
        [Test]
        public void TestPersonDoublicatesArray(){
            Person per1 = new Person("Andreas", 25); 
            Person per2 = new Person("Jens", 24);
            Person per3 = new Person("Dennis", 23);
            Person[] perGroup = {per1, per2, per2, per2, per3};
            var index = Search.Binary(perGroup, per2);
            bool istrue = index == 1; // || index == 2 || index == 3;
            Assert.IsTrue(istrue);
            
        }

        // Even though negative age does not make sence.
        // still finnds the element succesfully.
        [Test]
        public void TestPersonNegativeArray(){
            Person per1 = new Person("Andreas", 25); 
            Person per2 = new Person("Jens", 24);
            Person per3 = new Person("Dennis", 23);
            Person per4 = new Person("Tine", 22);
            Person per5 = new Person("Finn", -21);
            Person[] perGroup = {per1, per3, per2, per4, per5};
            var index = Search.Binary(perGroup, per5);
            Assert.AreEqual(4,index);
            
        }
        // Test of the new functionality to find "mid"
        // Uses largest possible int32 values. Which would 
        // cause Arithmetic Overflow with the old implementation
        // becuase of (high + low). 
        [Test]
        public void TestArithmeticOverflow(){
            int largeInt1 = Int32.MaxValue;
            int largeInt2 = Int32.MaxValue-1;
            int largeInt3 = Int32.MaxValue-2;
            int largeInt4 = Int32.MaxValue-3;
            int largeInt5 = Int32.MaxValue-4;
            IComparable[] array = {largeInt5, largeInt4, largeInt3, largeInt2, largeInt1};
            var index = Search.Binary(array, largeInt4);
            Assert.AreEqual(1, index);
        }

        // Tests that the guardrail works when given a null as the array
        [Test]
        public void TestNullArrayGuardrail() {
            Assert.Throws<ArgumentNullException>(() => Search.Binary(null, 0)); 
            // help for syntax, chatGPT
        }

        // Tests that the guardrail works when given a null as the target
        [Test]
        public void TestNullTargetGuardrail(){
            IComparable[] array = {1, 2, 4, 3, 5};
            Assert.Throws<ArgumentNullException>(() => Search.Binary(array, null));
        }



        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        public void TestRunningTime(int arraySize){
            ComparisonCountedInt[] countArray = new ComparisonCountedInt[arraySize];
            for (int i = 0; i < arraySize; i++) {
                countArray[i] = new ComparisonCountedInt(i);
            }
            IComparable[] array = countArray; 
            var target = countArray[arraySize / 2];

            int index = Search.Binary(array,target);
            int comparisons = ComparisonCountedInt.CountComparisons(countArray);
            // +4 to account for extra comparisons   
            int theoreticalMax = (int)Math.Ceiling(Math.Log(arraySize, 2.0))+4; 
            // make sure that the cases still finds the index
            Assert.AreNotEqual(-1,index);
            // and assert that the run time was less than the theoretical max
            Assert.LessOrEqual(comparisons, theoreticalMax);
        }

        //The test works by constructing a large ComparisonCountedInt array, 
        //The target is then set to something that is not in the array. 
        [Test]
        public void TestOptimization(){
            int arraySize = 1000;
            ComparisonCountedInt[] countArray = new ComparisonCountedInt[arraySize];
            for (int i = 0; i < arraySize; i++) {
                countArray[i] = new ComparisonCountedInt(i);
            }
            IComparable[] array = countArray; 
            //targets that are not present
            int[] targets = {-1, 10000};
            foreach (int t in targets) {
                var target = new ComparisonCountedInt(t);

                int index = Search.Binary(array,target);
                int comparisons = ComparisonCountedInt.CountComparisons(countArray);

                // The algorithm should make less than 2 comparisons
                int theoreticalMax = 2;

                // make sure that algorithm still does not find the index (it is not present)
                Assert.AreEqual(-1,index);

                // and assert that the run time was less than the theoretical max
                Assert.LessOrEqual(comparisons, theoreticalMax);
            }
        }

        [Test]
        public void TestJump(){
            int arraySize = 1024;
            ComparisonCountedInt[] countArray = new ComparisonCountedInt[arraySize];
            for (int i = 0; i < arraySize; i++) {
                countArray[i] = new ComparisonCountedInt(i);
            }
            IComparable[] array = countArray; 
            int[] targets = {-1, 10000};
            foreach (int t in targets) {
                var target = new ComparisonCountedInt(t);

                int index = Search.Jump(array,target);
                int comparisons = ComparisonCountedInt.CountComparisons(countArray);

                // make sure that algorithm does not find the index (it is not present)
                Assert.AreEqual(-1,index);
            }

            // Make sure that the algorithm finds an index (if it is present)
            // checks all 1024 elements. 
            for (int i = 0; i < array.Length; i++){
                var target2 = new ComparisonCountedInt(i);
                int index2 = Search.Jump(array,target2);
                Assert.AreNotEqual(-1,index2);
            }


        }


        [Test]    
        public void TestComparison(){
            int arraySize = 1024;
            int binaryTotalComparisons = 0;
            int jumpTotalComparisons = 0;

            for (int i = 0; i < arraySize; i++){
                var target = new ComparisonCountedInt(i);

                //binary setup
                ComparisonCountedInt[] binaryCountArray = new ComparisonCountedInt[arraySize];
                for (int j = 0; j < arraySize; j++) {
                    binaryCountArray[j] = new ComparisonCountedInt(j);
                }
                IComparable[] binaryArray = binaryCountArray; 
                

                //Jump setup
                ComparisonCountedInt[] jumpCountArray = new ComparisonCountedInt[arraySize];
                for (int j = 0; j < arraySize; j++) {
                    jumpCountArray[j] = new ComparisonCountedInt(j);
                }

                IComparable[] jumpArray = jumpCountArray; 
            
                // checks that Jump and Binary both return the same index each itteration
                Assert.AreEqual(Search.Jump(jumpArray, target), Search.Binary(binaryArray, target));

                binaryTotalComparisons += ComparisonCountedInt.CountComparisons(binaryCountArray);
                jumpTotalComparisons += ComparisonCountedInt.CountComparisons(jumpCountArray);
            

            }
            // check that Binary uses less or equal comparisons, compared to Jump in total
            Assert.LessOrEqual(binaryTotalComparisons, jumpTotalComparisons);
        }


    }