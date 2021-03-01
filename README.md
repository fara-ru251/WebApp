# WebApp
Project created on the basis of [Clean Architecture by Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture).
Web app has three APIs (endpoints). 
Used libraries: AutoMapper, SwaggerUI, [MediatR](https://github.com/jbogard/MediatR)
1. /api/topten/ is realized in [SimpleWebCrawler app](https://github.com/fara-ru251/SimpleWebCrawler/tree/master) using Hashtable (CuncurrentDictionary<,>).
As the key I used "string" type, as value "integer" incremental value
3. /api/search?text=asd is realized via Hashtable (Dictionary<,>).
Here I've used CQRS pattern, which has two sides: queries, commands. Mediator pattern is a behavioural pattern, that aims to produce loosely coupled objects by moving this dependencies into the one mediator object. This object navigates objects to each other, giving to us flexibility, we only depend on Mediator object now.
