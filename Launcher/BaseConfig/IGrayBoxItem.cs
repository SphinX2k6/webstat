using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004685 RID: 18053
	public class IGrayBoxItem
	{
		// Token: 0x0401ACB5 RID: 109749
		public int Divisor;

		// Token: 0x0401ACB6 RID: 109750
		public int Left;

		// Token: 0x0401ACB7 RID: 109751
		public int Right;

		// Token: 0x0401ACB8 RID: 109752
		[Nullable(2)]
		public HashSet<int> PlayerIds;
	}
}
