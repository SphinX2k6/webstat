using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DC4 RID: 19908
	[NullableContext(1)]
	public interface ITrapDefenseTab<[Nullable(2)] T>
	{
		// Token: 0x17008832 RID: 34866
		// (get) Token: 0x060338C1 RID: 211137
		// (set) Token: 0x060338C2 RID: 211138
		T TabType { get; set; }

		// Token: 0x17008833 RID: 34867
		// (get) Token: 0x060338C3 RID: 211139
		// (set) Token: 0x060338C4 RID: 211140
		string TabNameKey { get; set; }
	}
}
