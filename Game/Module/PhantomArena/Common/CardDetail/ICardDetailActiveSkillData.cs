using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005566 RID: 21862
	[NullableContext(1)]
	public interface ICardDetailActiveSkillData
	{
		// Token: 0x17008F77 RID: 36727
		// (get) Token: 0x06037BB1 RID: 228273
		// (set) Token: 0x06037BB2 RID: 228274
		string Desc { get; set; }

		// Token: 0x17008F78 RID: 36728
		// (get) Token: 0x06037BB3 RID: 228275
		// (set) Token: 0x06037BB4 RID: 228276
		List<string> Params { get; set; }
	}
}
