# PowerApps Dev Bootcamp 2022
Sample repo for PowerApps Dev Bootcamp 2022

Slides can be found in the slides/ folder at the root.

This is the supporting code for a very simple scenario :

## Scenario : Azure function + Dataverse + Plugin

- 1) We receive some contactdata into an Azure Function
- 2) The Azure function creates a Contact using DataverseClient nuget package in .net core (which is about to reach official production status 1.0.0 in June 2022!)
- 3) A plugin that fires on create of that contact record and creates a follow up Task.

In the demo we approached unit testing such scenario as follows:

- 1) A unit test to validate that the contact data is sent to Dataverse correcly (the contact is created)
- 2) A unit test to verify the plugin creates a follow up task given a Create message with an OutputParameter (the resulting from the Create operation) was received
- 3) A pipeline simulation scenario that wires everything together In-Memory, to check that both the contact and the task are created (this is experimental stuff, because really, the target versions of the client (.net core 3.1) and the server (net462) are different in production, but eventually....)

## Building and testing

Use **functions branch** to find out a sample unit test of an Azure Function against Dataverse that will create a contact in .net core and using the Dataverse Service Client NuGet package. Use this branch so you can build the project in a Linux distro / Mac

    tests/MyAzureFunctionTests/CreateContactTests.cs

Please Use **pipeline branch** to find a sample of the plugin unit test here:

    tests/PowerAppsBootCamp.Plugins.Tests/PowerAppsBootCamp.Plugins.Tests/FollowUpPluginTests.cs


Please also use **pipeline branch** to check a sample that will trigger a FollowUp plugin on Create of a contact from the same Azure function, and that you can step through it in the debugger (experimental)

    tests/MyAzureFunctionTests/CreateContactTestsWithSimulation.cs

