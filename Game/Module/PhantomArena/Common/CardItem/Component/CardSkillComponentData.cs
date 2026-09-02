using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005554 RID: 21844
	public class CardSkillComponentData : ICardSkillComponentData
	{
		// Token: 0x17008F4F RID: 36687
		// (get) Token: 0x06037AAE RID: 228014 RVA: 0x00E1E8DA File Offset: 0x00E1CADA
		// (set) Token: 0x06037AAF RID: 228015 RVA: 0x00E1E8E2 File Offset: 0x00E1CAE2
		public int SkillCd { get; set; }

		// Token: 0x17008F50 RID: 36688
		// (get) Token: 0x06037AB0 RID: 228016 RVA: 0x00E1E8EB File Offset: 0x00E1CAEB
		// (set) Token: 0x06037AB1 RID: 228017 RVA: 0x00E1E8F3 File Offset: 0x00E1CAF3
		public bool InSelect { get; set; }

		// Token: 0x17008F51 RID: 36689
		// (get) Token: 0x06037AB2 RID: 228018 RVA: 0x00E1E8FC File Offset: 0x00E1CAFC
		// (set) Token: 0x06037AB3 RID: 228019 RVA: 0x00E1E904 File Offset: 0x00E1CB04
		public bool InFight { get; set; }
	}
}
