# PowerApps Dev Bootcamp 2022
Sample repo for PowerApps Dev Bootcamp 2022

Slides can be found in the slides/ folder at the root.


- Use functions branch to find out a sample unit test of an Azure Function against Dataverse that will create a contact in .net core and using the Dataverse Service Client NuGet package (which is about to reach official production status 1.0.0 in June 2022)

   tests/MyAzureFunctionTests/CreateContactTests.cs

- Use pipeline branch to find a sample that will trigger a FollowUp plugin on Create of a contact from the same Azure function, and that you can step through it in the debugger (experimental)

    tests/MyAzureFunctionTests/CreateContactTestsWithSimulation.cs

