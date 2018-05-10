Feature: Googling
In order learn about things I am interested in
As the average Joe
I want to find potentially interesting websites with Google

Scenario: Googling Microsoft
Given a user is on the Google UK homepage
When the user googles "Microsoft"
Then the top google result is "https://www.microsoft.com/en-gb"