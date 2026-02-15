namespace Demos;

/*
class EmailService
{
   public void Send() { }
}

class Notification
{
   private EmailService _email = new EmailService();

   public void Notify()
   {
       _email.Send();
   }
}
*/

interface ISender
{
	void Send();
}

class SmsSender : ISender
{
	public void Send()
	{
		Console.WriteLine("Sending SMS...");
	}
}

class EmailSender : ISender
{
	public void Send()
	{
		Console.WriteLine("Sending Email...");
	}
}

class Notification
{
	private readonly ISender _sender;

	public Notification(ISender sender)
	{
		_sender = sender;
	}

	public void Notify()
	{
		_sender.Send();
	}
}

static class DIP
{
	public static void Demo()
 	{
	    ISender sender = new EmailSender();
	    Notification notification = new(sender);
	    notification.Notify();
	}
}
