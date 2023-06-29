# Detailed description of exercise 1 - Crawler 
The task is to prepare a simple "crawler" that will crawl a selected Web page and find email addresses located there.

### How does it work?
- The program receives a single argument, which is the URL of the page that will be the target of the scan of the "crawler"
- Using the HttpClient class, it executes an HTTP GET request and retrieves the source code of the web page
- Searches the content of the page and prints out on the console all the email addresses that were found on the page

### Requirements 
- If an argument has not been passed, an `ArgumentNullException` error should be returned
- If an argument is not a valid URL, an `ArgumentException` error should be returned
- In a situation where an error occurs while downloading the page (that is, a request status that is not between 200-299), an Exception error should be returned with the message `Error while loading website.`
- When no email addresses have been found, an Exception error should be returned with the message `No email addresses found.`
- When email addresses have been found, they should be displayed on the console. The application should return only unique email addresses