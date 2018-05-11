# Examples

I often find myself coding up small examples of
approaches or technology for illustrative purposes.

Rather than redo them on an ad-hoc basis, I'm going 
to start keeping them here.

## Selenium Page Objects

This is a very simple demonstration of the [Selenium
Page Object pattern](https://martinfowler.com/bliki/PageObject.html), 
using Google search as the example system under test.
The tests are built with [Xunit](https://github.com/xunit/xunit) and [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
which are nice tools, but not the point of the example.

## Using Selenium with Specflow

A simple example of how to combine [Selenium](https://github.com/SeleniumHQ/selenium) and
[Specflow](https://github.com/techtalk/SpecFlow) together to create automated acceptance tests.

It is built on top of the Page Object example using
[Xunit](https://github.com/xunit/xunit) and [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
but those are tool choices and not the point of the example.

Note that it is not neccessarily an example of how to write
Specflow features and scenarios (see comments in the code for 
more details) and the example is too small to demonstrate
any particular method of organising test automation code.