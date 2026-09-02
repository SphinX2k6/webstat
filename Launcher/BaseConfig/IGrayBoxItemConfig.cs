using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004684 RID: 18052
	[NullableContext(1)]
	[Nullable(0)]
	public class IGrayBoxItemConfig
	{
		// Token: 0x0401ACB0 RID: 109744
		public string Name;

		// Token: 0x0401ACB1 RID: 109745
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public int? Divisor;

		// Token: 0x0401ACB2 RID: 109746
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public int? Left;

		// Token: 0x0401ACB3 RID: 109747
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public int? Right;

		// Token: 0x0401ACB4 RID: 109748
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public List<int> Ids;
	}
}
