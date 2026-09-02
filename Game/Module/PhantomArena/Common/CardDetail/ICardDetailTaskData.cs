using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200558A RID: 21898
	[NullableContext(1)]
	public interface ICardDetailTaskData
	{
		// Token: 0x17008FAD RID: 36781
		// (get) Token: 0x06037C6C RID: 228460
		// (set) Token: 0x06037C6D RID: 228461
		string Desc { get; set; }

		// Token: 0x17008FAE RID: 36782
		// (get) Token: 0x06037C6E RID: 228462
		// (set) Token: 0x06037C6F RID: 228463
		int CurrentProgress { get; set; }
	}
}
