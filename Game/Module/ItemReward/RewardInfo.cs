using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B09 RID: 23305
	[NullableContext(2)]
	[Nullable(0)]
	public class RewardInfo : IRewardInfo
	{
		// Token: 0x17009650 RID: 38480
		// (get) Token: 0x0603AF59 RID: 241497 RVA: 0x00EF227F File Offset: 0x00EF047F
		// (set) Token: 0x0603AF5A RID: 241498 RVA: 0x00EF2287 File Offset: 0x00EF0487
		public ERewardInfoType Type { get; set; }

		// Token: 0x17009651 RID: 38481
		// (get) Token: 0x0603AF5B RID: 241499 RVA: 0x00EF2290 File Offset: 0x00EF0490
		// (set) Token: 0x0603AF5C RID: 241500 RVA: 0x00EF2298 File Offset: 0x00EF0498
		public EUiViewName ViewName { get; set; }

		// Token: 0x17009652 RID: 38482
		// (get) Token: 0x0603AF5D RID: 241501 RVA: 0x00EF22A1 File Offset: 0x00EF04A1
		// (set) Token: 0x0603AF5E RID: 241502 RVA: 0x00EF22A9 File Offset: 0x00EF04A9
		public string AudioId { get; set; }
	}
}
