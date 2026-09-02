using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005582 RID: 21890
	[NullableContext(1)]
	public interface ICardDetailPassiveSkillFieldData
	{
		// Token: 0x17008F9F RID: 36767
		// (get) Token: 0x06037C42 RID: 228418
		// (set) Token: 0x06037C43 RID: 228419
		ICardDetailConditionOutData OutData { get; set; }

		// Token: 0x17008FA0 RID: 36768
		// (get) Token: 0x06037C44 RID: 228420
		// (set) Token: 0x06037C45 RID: 228421
		ICardDetailConditionInData InData { get; set; }
	}
}
