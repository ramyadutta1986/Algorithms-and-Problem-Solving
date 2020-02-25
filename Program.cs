using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic var = 100;
            //Console.WriteLine($"Dynamic variable value {var},Type is{var.GetType().ToString()}");
            //Anonymous Types
            var anonymousvar = new
            {
                name = "lasya",
                Id = 101,
                address = "Redmond"

            };
            //Console.WriteLine($"size of new array is {ReomveElement(3)}");
            //int[] nums = { 1, 2, 3, 4, 4,5,5 };
            //Console.WriteLine($"length of new array is {RemoveDuplicatesfromSortedArray(nums)}");

            Console.WriteLine($"Index of 1st occurence is {StrStr("asasad","sad")}");

           // Console.WriteLine($"Name is {anonymousvar.name},Id is {anonymousvar.Id},Address is {anonymousvar.address}");

            
            //long num = Lcm(20);
            //Console.WriteLine(num);
            
            //int matrixSize = 5;
            var matrix = new int[3, 4]
            {
                { 1, 2, 3, 4 },
                { 6, 7, 8, 9 },
                { 11,12,13,14 },
     
                
            };

           //PrintMatrix(matrix);
           //Console.WriteLine($" {FindElementinSortedMatrix(matrix,13)}");

            //RotateMatrixInPlaceclockwise(matrixSize, matrix);

            //PrintMatrix(matrix);

            //RotateMatrixAntiClockwise(matrixSize, matrix);

            //PrintMatrix(matrix);

            //int[] a = { 1, 2,2,3,3,4};
            //int i=1,og=a[0];
      

            // 7, 6, 4, 3 => HashSet lookup is O(1)

           

     }
        //return the indexes when the sum of 2 elements is 8.
        private static void FindIndexesinArray(int [] a)
        {
            bool found = false;
            Dictionary<int, int> compliments = new Dictionary<int, int>();
            var expectedSum = 8;
            for (int i = 0; i < a.Length; i++) {
                var currentComplement = expectedSum - a[i];
                if (compliments.ContainsKey(a[i]))
                {
                    found = true;
                    Console.WriteLine($"found {i}, {compliments[a[i]]} => {a[i]},{a[compliments[a[i]]]}!");
                    break;
                }
                else
                {
                    compliments.Add(currentComplement, i);
                }
                // if (found) break; }

            }

            if (!found)
                Console.WriteLine("not found");
            
            //if (a[i] + a[j] == 8)
            //{
            //    found = true;
            //    Console.WriteLine($"found {i}, {j} => {a[i]}, {a[j]}");
            //    break;
            //}
        }

        private static long Lcm(long n) {

            long ans = 1;
            for (int i = 1; i <= n; i++) {
                ans = (ans * i) / Gcd(ans, i);
            }
            return ans;
        }
        private static long Gcd(long a, long b) {
            if (a % b != 0) { return Gcd(b,a % b); }
            else
            return b;
        }

        

        private static int RemoveDuplicatesfromSortedArray(int [] nums)
        {
            int count;
            if (nums.Length == 0)
            {
                return count = 0;
            }
            int i=1,og=nums[0];
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != og)
                {
                    og = nums[j];
                    nums[i] = nums[j];
                    i++;
                }
            }
            return count=i;
        }
        private static int ReomveElement(int val) {
            int len = 0,i=0,j=0;
            
            int[] nums = {5, 3, 4, 2,6 };
            while (i < nums.Length)
            {
                if (nums[i] != val)
                {
                    nums[j] = nums[i];
                    j++;
                }
                i++;
            }
            return len =j;
        }

        private static int StrStr(string haystack, string needle)
        {
            int len = haystack.Length,n=-1;
                if (needle == "") { return  0; }
           n= haystack.IndexOf(needle);
            if (n != -1) { return n; }
            else { return -1; }
          
        }

        private static void RotateMatrixInPlaceclockwise(int matrixSize, int[,] matrix)
        {
            for (int level = 0; level < matrixSize / 2; level++)
            {
                  
                int last = matrixSize - level - 1;

                for (int offset = level; offset < last; offset++)
                {
                    int temp = matrix[level, level + offset];

                    matrix[level, level + offset] = matrix[last - offset, level];

                    matrix[last - offset, level] = matrix[last, last - offset];


                    matrix[last, last - offset] = matrix[level + offset, last];

                    matrix[level + offset, last] = temp;
                }
            }
        }


        private static void RotateMatrixAntiClockwise(int matrixsize, int[,] matrix)
        {
            for (int layer = 0; layer < matrixsize / 2; layer++)
            {
                int last = matrixsize -layer- 1;

                for (int offset = layer; offset < last; offset++)
                {
                    int temp = matrix[layer,layer+offset];
                    matrix[layer, layer + offset] = matrix[layer+offset,last];
                    matrix[layer + offset, last] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[last-offset,layer];
                    matrix[last - offset, layer] = temp;
                }

            }
        }

        private static bool FindElementinSortedMatrix(int[,] matrix, int val)
        {
            int rowsize = matrix.GetLength(0), columnsize = matrix.GetLength(1);
            if (val < matrix[0, 0] || val > matrix[rowsize - 1, columnsize - 1])
            {
                return false;
            }

            int r = 0, c = columnsize - 1;
            while (r <= columnsize - 1 && c > 0)
            {
                if (val == matrix[r, c])
                {
                    return true;
                    Console.WriteLine($"The element found at [{r},{c}]");
                }
                else if (val < matrix[r, c])
                {
                    c--;
                }
                else
                {
                    r++;
                }

            }


            return false;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            
            //int midElementrowIndex = (rowsize - 1) / 2;
            //int midElementColindex = (columnsize - 1) / 2;
           
            //Console.WriteLine($"{matrix[midElementrowIndex,midElementColindex]}");
           
            //for (int i = 0; i < rowsize ; i++)
            //{
            //    for (int j = 0; j < columnsize; j++)
            //    {
            //        Console.Write($"{matrix[i, j],2} ");
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
