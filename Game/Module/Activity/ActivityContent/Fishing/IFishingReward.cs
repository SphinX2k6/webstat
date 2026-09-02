using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067FF RID: 26623
	public interface IFishingReward
	{
		// Token: 0x1700A14D RID: 41293
		// (get) Token: 0x060425E4 RID: 271844
		// (set) Token: 0x060425E5 RID: 271845
		int Id { get; set; }

		// Token: 0x1700A14E RID: 41294
		// (get) Token: 0x060425E6 RID: 271846
		// (set) Token: 0x060425E7 RID: 271847
		int Current { get; set; }

		// Token: 0x1700A14F RID: 41295
		// (get) Token: 0x060425E8 RID: 271848
		// (set) Token: 0x060425E9 RID: 271849
		int Target { get; set; }

		// Token: 0x1700A150 RID: 41296
		// (get) Token: 0x060425EA RID: 271850
		// (set) Token: 0x060425EB RID: 271851
		bool IsFinished { get; set; }

		// Token: 0x1700A151 RID: 41297
		// (get) Token: 0x060425EC RID: 271852
		// (set) Token: 0x060425ED RID: 271853
		bool IsTaken { get; set; }
	}
}
