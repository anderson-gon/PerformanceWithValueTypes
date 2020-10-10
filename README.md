This poc demonstrate the performance and free allocation memory benchmark against reference types and value types.
For the simulation this example loads 100.000.000 objects that represents rectangles.

## Implementations

### `Implementation 1`
This example shows a reference type implementation with a Equals method.

### `Implementation 2`
This example shows a value type implementation with struct. Note that on the comparation reflections will be used causing memory allocations and GC invocations.

### `Implementation 3`
This example shows a value type implementation with struct and an Equals method. Note that Equals has a parameter of type object. In this method the struct will do a boxing to object causing memory allocations and GC invocations.

### `Implementation 4`
This example shows a value type implementation with struct that implements IEquatable<Rectangle> and an Equals method. Note that Equals has a parameter of type Rectangle. In this method the struct will do not a boxing to object and will not use reflections causing free memory allocations and no GC invocations.

## How to run
Each implementation is comment. Uncomment the implementation that you want to see the elapsed time and GC invocations and run with dotnet run - c Release