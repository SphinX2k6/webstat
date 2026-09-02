using System;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Skin
{
	// Token: 0x02004F5D RID: 20317
	public interface ISkinViewData
	{
		// Token: 0x17008A21 RID: 35361
		// (get) Token: 0x0603463E RID: 214590
		// (set) Token: 0x0603463F RID: 214591
		int RoleId { get; set; }

		// Token: 0x17008A22 RID: 35362
		// (get) Token: 0x06034640 RID: 214592
		// (set) Token: 0x06034641 RID: 214593
		int WeaponId { get; set; }

		// Token: 0x17008A23 RID: 35363
		// (get) Token: 0x06034642 RID: 214594
		// (set) Token: 0x06034643 RID: 214595
		EUiTabViewName TabViewName { get; set; }

		// Token: 0x17008A24 RID: 35364
		// (get) Token: 0x06034644 RID: 214596
		// (set) Token: 0x06034645 RID: 214597
		bool NeedLoadRole { get; set; }

		// Token: 0x17008A25 RID: 35365
		// (get) Token: 0x06034646 RID: 214598
		// (set) Token: 0x06034647 RID: 214599
		int? FlySkinId { get; set; }

		// Token: 0x17008A26 RID: 35366
		// (get) Token: 0x06034648 RID: 214600
		// (set) Token: 0x06034649 RID: 214601
		EFlySkinTab? FlySkinTab { get; set; }

		// Token: 0x17008A27 RID: 35367
		// (get) Token: 0x0603464A RID: 214602
		// (set) Token: 0x0603464B RID: 214603
		int? CalabashSkinId { get; set; }

		// Token: 0x17008A28 RID: 35368
		// (get) Token: 0x0603464C RID: 214604
		// (set) Token: 0x0603464D RID: 214605
		int? SelectRoleSkinId { get; set; }

		// Token: 0x17008A29 RID: 35369
		// (get) Token: 0x0603464E RID: 214606
		// (set) Token: 0x0603464F RID: 214607
		int? OrnamentSkinId { get; set; }

		// Token: 0x17008A2A RID: 35370
		// (get) Token: 0x06034650 RID: 214608
		// (set) Token: 0x06034651 RID: 214609
		int? OrnamentId { get; set; }

		// Token: 0x17008A2B RID: 35371
		// (get) Token: 0x06034652 RID: 214610
		// (set) Token: 0x06034653 RID: 214611
		bool? SkipOrnamentCameraBlend { get; set; }
	}
}
