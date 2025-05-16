using WinRT;

namespace TestAotTips.Models.Json;

[GeneratedBindableCustomProperty([nameof(Name)], [typeof(String)])]
internal partial record Person(String Name, Int32 Age);
