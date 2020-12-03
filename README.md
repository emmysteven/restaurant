# Restaurant

![.NET Core](https://github.com/iammukeshm/CleanArchitecture.WebApi/workflows/.NET%20Core/badge.svg?branch=master)
![GitHub stars](https://img.shields.io/github/stars/emmysteven/restaurant)
[![Twitter Follow](https://img.shields.io/twitter/follow/emmysteven_?style=social&label=follow)](https://twitter.com/emmysteven_)

<br/>

An Implementation of Clean Architecture with .NET 5
With this Open-Source Codebase, you will get access to the world of Loosely-Coupled and Inverted-Dependency Architecture in .NET 5

## Upcoming Release 

### v1.1-release 

Read the [Changelog file](https://github.com/emmysteven/restaurant/blob/master/CHANGELOG.md) to see the new changes.

Clone this repository to get the latest unreleased version.


## Releases

v1.0-preview - [Download the first Preview here](https://github.com/emmysteven/restaurant/releases/tag/v1.0-preview) 

### v1 Preview.
Follow these steps to get started with this Boiler Plate Template.
1. Clone this Repository and Extract it to a Folder.
3. Change the Connection Strings for the Application and Identity in the WebUI/appsettings.json - (WebUI Project)
2. Run the following commands on Terminal in the WebUI Project's directory.
- dotnet restore
- dotnet ef database update -Context ApplicationDbContext
- dotnet ef database update -Context IdentityContext
- dotnet run (OR) Run the Solution using Visual Studio 2019

Check out my [blog](https://www.mycodegist.com) or say [Hi on Twitter!](https://twitter.com/emmysteven_)

## Purpose of this Project

Does it really make sense to an restaurant and you told that they are fully booked? Aren't we wasting quite a lot of time in doing this over and over again?

This is the exact Problem that I intend to solve with this Full-Fledged .NET 5, that also follows various principles of Clean Architecture.

The primary goal is to create a solve restaurant booking problem, that is well documented along with the steps taken to build this Solution from Scratch. This Solution Template will also be available within Visual Studio 2019 (by installing the required Nuget Package / Extension).
- Demonstrate Clean Monolith Architecture in .NET 5 
- This is not a Proof of Concept
- Implementation that is ready for Production
- Integrate the most essential libraries and packages

## Give a Star ⭐️
If you found this Project helpful, do give it a star. Thanks! <br/>
If you are feeling really generous, send me ETH: <code>0x9F4942911f2406E5897669Db99184d47B3078E99</code>

## Technologies
- .NET 5
- REST Standards
- .NET 5 Libraries

## Features
- [x] Clean Architecture
- [x] CQRS with MediatR Library
- [x] Entity Framework Core - Code First
- [x] Repository Pattern - Generic
- [x] MediatR Pipeline Logging & Validation
- [x] Serilog
- [ ] Swagger UI
- [x] Response Wrappers
- [x] Healthchecks
- [x] Pagination
- [ ] In-Memory Caching
- [x] Redis Caching
- [x] RDBMS
- [x] JWT Authentication
- [x] Role based Authorization
- [x] Custom Exception Handler
- [x] Fluent Validation
- [x] Automapper
- [x] SMTP / Mailkit / Sendgrid Email Service
- [x] Complete User Management Module (Register / Generate Token / Forgot Password / Confirmation Mail)
- [x] User Auditing

## Brief Overview
![alt text](https://pbs.twimg.com/media/EnmjcrjW4AEvm-e?format=jpg&name=900x900)

## Prerequisites
- JetBrains Rider 2020.1.4 & above | Visual Studio 2019 Community and above
- .NET Core 3.1 SDK and above
- Basic Understanding of Clean Architecture
- I Recommend that you read [Onion Architecture In ASP.NET Core With CQRS – Detailed](https://www.codewithmukesh.com/blog/onion-architecture-in-aspnet-core/) article to understand this project much better. This project is just an Advanced Version of the mentioned article.

## Getting Started

## Changelog
Every changes / additions / deletions will be recorded in the [Changelog file](https://github.com/emmysteven/Restaurant/blob/main/CHANGELOG.md).

## Questions? Bugs? Suggestions for Improvement?
Having any issues or troubles getting started? [Get in touch with me](https://www.mycodegist.com/contact) or [Raise a Bug or Feature Request](https://github.com/emmysteven/restaurant/issues/new/choose). Always happy to help.

## Support
Has this Project helped you learn something New? or Helped you at work? Do Consider Supporting. <br/>
ETH: <code>0x9F4942911f2406E5897669Db99184d47B3078E99</code>


## Share it!
I have personally not come across a clean implementation on a WebAPI, which is the reason that I started building this up. There are quite a lot of improvements and fixes along the way from the day I started out. Thanks to the community for the support and suggestions.
Please share this Repository within your developer community, if you think that this would a difference! Thanks.

## About the Author
### Emmy Steven
- Blogs at [mycodegist.com](https://www.mycodegist.com)
- Twitter - [Emmy Steven](https://www.twitter.com/emmysteven_)
- Linkedin - [Emmy Steven](https://www.linkedin.com/in/emmysteven/)

## Licensing
emmysteven/restaurant Project is licensed with the [MIT License](https://github.com/emmysteven/restaurant/blob/main/LICENSE).
