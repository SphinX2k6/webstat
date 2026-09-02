using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005553 RID: 21843
	public interface ICardSkillComponentData
	{
		// Token: 0x17008F4C RID: 36684
		// (get) Token: 0x06037AA8 RID: 228008
		// (set) Token: 0x06037AA9 RID: 228009
		int SkillCd { get; set; }

		// Token: 0x17008F4D RID: 36685
		// (get) Token: 0x06037AAA RID: 228010
		// (set) Token: 0x06037AAB RID: 228011
		bool InSelect { get; set; }

		// Token: 0x17008F4E RID: 36686
		// (get) Token: 0x06037AAC RID: 228012
		// (set) Token: 0x06037AAD RID: 228013
		bool InFight { get; set; }
	}
}
