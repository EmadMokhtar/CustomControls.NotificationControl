# Description #
**NotificationControl** is ASP.NET WebForms server control wrapper for jQuery Notification plug-in called [jNotify](http://www.givainc.com/labs/jnotify_jquery_plugin.cfm "jnotify").

# Features #
**It has 3 types of notifications:** 

1. Info (Green). 
2. Warning (Yellow).
3. Error (Red).

**It has 2 types of display:**

1. Auto hide after certain time.
2. Sticky and can be hide by clicking on "x" button at the upper right corner.

**It works with UpdatePanel (Partial Postbacks).**

**It works without UpdatePanel (Full Postbacks).**

**All resources injected to ASP.NET WebForm using WebResources.**

**It can use its embded jQuery or project's jQuery.**

# How to Install #

1. Download the repository.
2. Run Visual Studio, and open project.
3. Build the project.
4. Go to bin/Release folder and locate the *CustomControls.NotificationControl.dll* file.
5. In your ASP.NET WebForms project open any .ASPX file then open the toolbox.
6. Right click on any tab you need to add the control to it.
7. Select *Choose Items...* then browse to the *CustomControls.NotificationControl.dll* file.

# How to Use #

1. Drag and drop the control from Toolbox to ASPX page.
2. Give it an ID.
3. From code-behind just call one of its methods, here is description for each method:

	- Show info notification with message and default delay
    ```C#	    
    Notificaiton.ShowInfo("Hello it's info");
    ```
	- Show info notification with message and 5000 milliseconds delay
	```C#
	Notificaiton.ShowInfo("Hello it's info", 5000);
    ```
	- Show warning notification with message and default delay
	```C#
	Notificaiton.ShowWraning("Hello it's warning");
    ```
	- Show warning notification with message and 5000 milliseconds delay
	```C#
	Notificaiton.ShowWraning("Hello it's warning", 5000);
    ```
	- Show error notification with message and default delay
	```C#
	 Notificaiton.ShowError("Hello it's error");
    ```
	- Show error notification with message and 5000 milliseconds delay
	```C#
	Notificaiton.ShowError("Hello it's error", 5000);
    ```
	- Show info notification with message and it'll be sticky (user must close it to hide):
	```C#
	Notificaiton.ShowStickyInfo("Hello it's sticky info");
    ```
	- Show warning notification with message and it'll be sticky (user must close it to hide):
	```C#
    Notificaiton.ShowStickyWarning("Hello it's sticky warning");
    ```
	- Show error notification with message and it'll be sticky (user must close it to hide):
	```C#
	Notificaiton.ShowStickyError("Hello it's sticky error");
    ```
	- Show info notification with setup:
    ```C#
    Notificaiton.Delay = 5000;
    Notificaiton.Type = NotificationType.Info;
    Notificaiton.Message = "Hello it's info notification with configuration and Show() only";
    Notificaiton.Show();
    ```