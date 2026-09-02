using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007029 RID: 28713
	[NullableContext(1)]
	public interface ITalkOption
	{
		// Token: 0x1700A4F9 RID: 42233
		// (get) Token: 0x06045870 RID: 284784
		// (set) Token: 0x06045871 RID: 284785
		int TextId { get; set; }

		// Token: 0x1700A4FA RID: 42234
		// (get) Token: 0x06045872 RID: 284786
		// (set) Token: 0x06045873 RID: 284787
		IActionInfo[] Actions { get; set; }
	}
}
