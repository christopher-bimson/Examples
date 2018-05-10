Feature: Googling
In order learn about things I am interested in
As the average Joe
I want to find potentially interesting websites with Google

Scenario: Googling Microsoft
Given a user is on the Google UK homepage
When the user googles "Microsoft"
Then the top google result is "https://www.microsoft.com/en-gb"

Scenario: Googling Service Fabric on Microsoft.com
Given a user is on the Google UK homepage
When the user googles the site "microsoft.com" for "service fabric"
Then all google results are from "microsoft.com"