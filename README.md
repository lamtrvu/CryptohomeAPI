Crypto Home API
===============

An API for Cryptohome, a Cloud-Based Home Automation system using standard web technologies and the SAAS model.

It is developed using C# and .NET 8 runtime, documentation can be found [here](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview).


Features
========

1. Create device and Retrieve device details.
2. Create action to Turn on and Turn off device, or Undo previous action of a device.
3. Retrieve details of created action. Generate a bunch of random actions for testing purpose.
4. User registration, login and authentication using user name and password.

How to use
==========

The API service will generate swagger to describe all API information. [example]({URL}/swagger/index.html)

Description | API command 
------------|------------
Create an action | POST / Actions
Get all actions | GET / Actions
Get a specific action details | GET / Actions/{id}
Get a specific device details | GET / Devices/{id}
Create a device | POST / Devices
Register a user | POST / Users/Register
User login | POST / Users/Login

Any further details for calling the API, please check [swagger]({URL}/swagger/index.html)