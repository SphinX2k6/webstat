using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x0200554B RID: 21835
	public interface ICardEffectCountComponentData
	{
		// Token: 0x17008F44 RID: 36676
		// (get) Token: 0x06037A7D RID: 227965
		// (set) Token: 0x06037A7E RID: 227966
		int EffectCount { get; set; }

		// Token: 0x17008F45 RID: 36677
		// (get) Token: 0x06037A7F RID: 227967
		// (set) Token: 0x06037A80 RID: 227968
		int EffectCountMax { get; set; }

		// Token: 0x17008F46 RID: 36678
		// (get) Token: 0x06037A81 RID: 227969
		// (set) Token: 0x06037A82 RID: 227970
		bool InFight { get; set; }
	}
}
