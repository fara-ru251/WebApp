# WebApp
Project created on the basis of [Clean Architecture by Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture).
Web app has three APIs (endpoints).
1. /api/topten/ is realized in [SimpleWebCrawler app](https://github.com/fara-ru251/SimpleWebCrawler/tree/master) using Hashtable (CuncurrentDictionary<,>).
As the key I used "string" key, as value integer incremental value
3. /api/search?text=asd is realized via Hashtable (Dictionary<,>)
