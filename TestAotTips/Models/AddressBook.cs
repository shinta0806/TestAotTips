namespace TestAotTips.Models;

internal class AddressBook
{
	public String BookName
	{
		get;
		set;
	} = String.Empty;

	public List<Person> People
	{
		get;
		set;
	} = new();
}
