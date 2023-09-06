# APBD

## Short description of the exercises

### Exercise 1 - Crawler
The task is to prepare a simple "crawler" that will crawl a selected web page and find email addresses located there.

#### Application operation in a nutshell
- The program receives a single argument, which is the URL of the page that will be the target of the "crawler" scan.
- Using the HttpClient class, it executes an HTTP GET request and retrieves the source code of the web page.
- Searches the content of the page and prints out on the console all the email addresses that were found on the page.
