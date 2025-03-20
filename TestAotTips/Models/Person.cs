using WinRT;

namespace TestAotTips.Models;

[GeneratedBindableCustomProperty([nameof(Name)], [typeof(String)])]
internal partial record Person(String Name, Int32 Age);
