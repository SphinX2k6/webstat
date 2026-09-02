using System;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B18 RID: 23320
	public interface IRewardProgress
	{
		// Token: 0x170096BD RID: 38589
		// (get) Token: 0x0603B03B RID: 241723
		// (set) Token: 0x0603B03C RID: 241724
		int FromProgress { get; set; }

		// Token: 0x170096BE RID: 38590
		// (get) Token: 0x0603B03D RID: 241725
		// (set) Token: 0x0603B03E RID: 241726
		int ToProgress { get; set; }

		// Token: 0x170096BF RID: 38591
		// (get) Token: 0x0603B03F RID: 241727
		// (set) Token: 0x0603B040 RID: 241728
		int MaxProgress { get; set; }
	}
}
