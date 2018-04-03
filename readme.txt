Tasks 40:
1.	Add implicit waiter for WebDriver.
	file: ImplicitWeDriverWaiterTest.cs

2.	Add Thread.sleep for login test, which was created on previous training. What type of waiter is it (add your answer as comment near sleep)?
	file: LoginTest.cs	

3.	Add explicit waiter for login test, which will wait until Sign out link appears (after login).
	file: LoginTest.cs

4.	Add explicit waiter for following test case:
a)	Go to RMSys login page, RMSys login page should appear.
b)	Enter correct username and password, both inputs should be filled in.
c)	Click Submit button, RMSys home page should appear.
d)	Go to office tab, wait for "Search by office" input to appear (wait 15 seconds, polling frequence - 2,7 seconds).
	file: ExplicitWebDriverWaiter.cs

5.	Create DDT test, which will cover login functionality (only happy path with > 3 datasets).

6.	Create test with frames (URL - https://the-internet.herokuapp.com/iframe). Write the following text – Hello world!  and check it. Do not use menu File -> New Document.
	file: IFrameTest

7.	Create 3 tests for alerts (URL - https://the-internet.herokuapp.com/javascript_alerts).
	files: JSAlertTest.cs, JSConfirmTest.cs, JSPrompt.cs
