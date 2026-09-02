using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x0200701F RID: 28703
	[NullableContext(1)]
	public interface IActionInfo
	{
		// Token: 0x1700A4E1 RID: 42209
		// (get) Token: 0x0604583E RID: 284734
		// (set) Token: 0x0604583F RID: 284735
		string Name { get; set; }

		// Token: 0x1700A4E2 RID: 42210
		// (get) Token: 0x06045840 RID: 284736
		// (set) Token: 0x06045841 RID: 284737
		bool? Async { get; set; }

		// Token: 0x1700A4E3 RID: 42211
		// (get) Token: 0x06045842 RID: 284738
		// (set) Token: 0x06045843 RID: 284739
		[Nullable(2)]
		object Params { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
