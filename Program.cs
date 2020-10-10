using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ClassVsStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen0Snapshot = GC.CollectionCount(0);
	        const int listSize = 100_000_000;
	        IEnumerable<Rectangle> rectangles =  Enumerable
                                            .Range(1, listSize)
									        .Select(value => new Rectangle { Length = value, Width = value * 2 });
            
            var rectangleToFind = new Rectangle { Length = -1, Width = -1 };

            var sw = Stopwatch.StartNew();

            var found = rectangles.Contains(rectangleToFind);
	
	        sw.Stop();
            
	        Console.WriteLine($"Elappesed time: {sw.ElapsedMilliseconds} ms");
	        Console.WriteLine($"GC calls on Generation 0 : {GC.CollectionCount(0) - gen0Snapshot}");
        }
    }

    // Implementation 1: Using reference type and implementing a Equals
    /*class Rectangle 
    {
	    public int Length { get; set; }
	    public int Width { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle other)) {
                return false;
            }

            return Length == other.Length && Width == other.Width;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    */
    
    

    //Implementation 2: Using value type and comparing the values by reflection
    //this operation causes memory allocation
    /*struct Rectangle 
    {
	    public int Length { get; set; }
	    public int Width { get; set; }
        
    }
    */
    

    //Implementation 3: Using value type and implementing Equals
    /*struct Rectangle 
    {
	    public int Length { get; set; }
	    public int Width { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle other)) {
                return false;
            }

            return Length == other.Length && Width == other.Width;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    */
    

    //Implementation 4: 
    //This example is free memomy allocation not performing a boxing to object on Equals
    struct Rectangle : IEquatable<Rectangle>
    {
	    public int Length { get; set; }
	    public int Width { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle other)) {
                return false;
            }

            return Length == other.Length && Width == other.Width;
        }

        public bool Equals([AllowNull] Rectangle other)
        {
            return Length == other.Length && Width == other.Width;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        
    }
    
    
    
    
    

  

}
