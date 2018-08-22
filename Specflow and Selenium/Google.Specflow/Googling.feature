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

# While they demo the technology adequately, these are not examples of
# great scenarios. The language isn't greate, and there is no way to control
# the state of the system under test. Under normal circumstances not being 
# able to put the system into a known state (using Given steps) would make the 
# tests too fragile to be useful. In fact I would expect these test to fail 
# from most locations, as I imagine Google will try to be helpful by 
# returning results relavant to the users location.
#
# I'm able to get away with it because:
#   a) It's fine for it to work in just the UK for my illustrative purposes.
#   b) It's a fairly safe assumption that Microsoft will ensure that they are
#      always the top search result for "Microsoft"
#   c) It's unlikely that Microsoft are going to stop using the microsoft.com 
#      domain any time soon. 