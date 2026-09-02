using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005584 RID: 21892
	[NullableContext(1)]
	public interface ICardDetailPassiveSkillData
	{
		// Token: 0x17008FA3 RID: 36771
		// (get) Token: 0x06037C4B RID: 228427
		// (set) Token: 0x06037C4C RID: 228428
		string Desc { get; set; }

		// Token: 0x17008FA4 RID: 36772
		// (get) Token: 0x06037C4D RID: 228429
		// (set) Token: 0x06037C4E RID: 228430
		List<string> Params { get; set; }

		// Token: 0x17008FA5 RID: 36773
		// (get) Token: 0x06037C4F RID: 228431
		// (set) Token: 0x06037C50 RID: 228432
		ICardDetailEffectCountData EffectCountData { get; set; }

		// Token: 0x17008FA6 RID: 36774
		// (get) Token: 0x06037C51 RID: 228433
		// (set) Token: 0x06037C52 RID: 228434
		ICardDetailPassiveSkillFieldData FieldData { get; set; }
	}
}
