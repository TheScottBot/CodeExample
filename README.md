# CodeExample
An example of a small app which the coding standards progressively get better - please not this is by no means the best code, and the lack of automated tests makes it not great either
First off the NotSoGreatWay folder.

Look at program.cs - try to understand what its doing.... its difficult isn't it. 

In short the app scans my temp folder for python scripts and then executes one that parses XML

The lack of meaningful variable names makes it really tricky to understand whats going on here.

############################################################################################################

So move on to the FirstPass folder, look inside BetterWay - program.cs 

The variables are named in a meaningful way, so the code starts to describe itself more. 
But we still have issues that this main method is "doing more than one thing" 

############################################################################################################

SecondPass - AnotherBetterWay - Program.cs

If you look at the Main method now you'll see, by implementing methods to do tasks its more readable - for example FindStringInFiles 
is more descriptive that the previous one where it had a foreach loop. There are still redundant variables and a lot of stuff is still
hard coded

############################################################################################################

ThirdPass - FineTuning - program.cs 

First think you'll notice is there are different projects in here. This is to further isolate responsibility and therefore increase 
reuse of each function. The idea is things should be broken down in such a way that tests can be assigned to each.

This is following on the DRY (Don't Repeat Yourself) principle and SOLID's S principle (Single responsibility)

Here the app is taking information out of the app.config. Allowing it to be more dynamic **There is no error handling on this, this is bad** 
We should probably think about moving this config parsing out to another class to again ensure we are ensuring the Main method only has
a single responsibility

############################################################################################################ 

I hope this helps.



