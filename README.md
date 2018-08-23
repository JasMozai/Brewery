# Brewery

A TransportRefrigerationSensors solution to show Baz the current temperature of each container and notifies him when the temperatures are oot of the correct range.

## Getting Started

Download->unzip->open in Visual Studio->run the file.

## Highlights

Flexibility of the solution:
- Apply the solution on multiple trucks.
- Each truck can have multiple containers.
- Each container can have multiple contents, not only for beer, you can load soft drink if you want (Just inherit the RefrigerationContent class).
- Mock temperature by generating random number.
- The Time interval of checking sensor can be set individually by user for each Truck.

## Assumptions

- The random generated temperature is between 0 to 30 °C.
- The initial load in Main.

## Improvement

There are some work could have been done in better way:
- More unit tests.
- Handle of exception cases.
- Layering the application.
- Apply Observer design pattern.


