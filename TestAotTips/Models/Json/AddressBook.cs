namespace TestAotTips.Models.Json;

internal class AddressBook
{
	public string BookName
	{
		get;
		set;
	} = string.Empty;

	public List<Person> People
	{
		get;
		set;
	} = [];
}
