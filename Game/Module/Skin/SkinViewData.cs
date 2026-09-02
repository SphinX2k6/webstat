using System;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Skin
{
	// Token: 0x02004F5E RID: 20318
	public class SkinViewData : ISkinViewData
	{
		// Token: 0x17008A2C RID: 35372
		// (get) Token: 0x06034654 RID: 214612 RVA: 0x00D1C5F1 File Offset: 0x00D1A7F1
		// (set) Token: 0x06034655 RID: 214613 RVA: 0x00D1C5F9 File Offset: 0x00D1A7F9
		public int RoleId { get; set; }

		// Token: 0x17008A2D RID: 35373
		// (get) Token: 0x06034656 RID: 214614 RVA: 0x00D1C602 File Offset: 0x00D1A802
		// (set) Token: 0x06034657 RID: 214615 RVA: 0x00D1C60A File Offset: 0x00D1A80A
		public int WeaponId { get; set; }

		// Token: 0x17008A2E RID: 35374
		// (get) Token: 0x06034658 RID: 214616 RVA: 0x00D1C613 File Offset: 0x00D1A813
		// (set) Token: 0x06034659 RID: 214617 RVA: 0x00D1C61B File Offset: 0x00D1A81B
		public EUiTabViewName TabViewName { get; set; }

		// Token: 0x17008A2F RID: 35375
		// (get) Token: 0x0603465A RID: 214618 RVA: 0x00D1C624 File Offset: 0x00D1A824
		// (set) Token: 0x0603465B RID: 214619 RVA: 0x00D1C62C File Offset: 0x00D1A82C
		public bool NeedLoadRole { get; set; }

		// Token: 0x17008A30 RID: 35376
		// (get) Token: 0x0603465C RID: 214620 RVA: 0x00D1C635 File Offset: 0x00D1A835
		// (set) Token: 0x0603465D RID: 214621 RVA: 0x00D1C63D File Offset: 0x00D1A83D
		public int? FlySkinId { get; set; }

		// Token: 0x17008A31 RID: 35377
		// (get) Token: 0x0603465E RID: 214622 RVA: 0x00D1C646 File Offset: 0x00D1A846
		// (set) Token: 0x0603465F RID: 214623 RVA: 0x00D1C64E File Offset: 0x00D1A84E
		public EFlySkinTab? FlySkinTab { get; set; }

		// Token: 0x17008A32 RID: 35378
		// (get) Token: 0x06034660 RID: 214624 RVA: 0x00D1C657 File Offset: 0x00D1A857
		// (set) Token: 0x06034661 RID: 214625 RVA: 0x00D1C65F File Offset: 0x00D1A85F
		public int? CalabashSkinId { get; set; }

		// Token: 0x17008A33 RID: 35379
		// (get) Token: 0x06034662 RID: 214626 RVA: 0x00D1C668 File Offset: 0x00D1A868
		// (set) Token: 0x06034663 RID: 214627 RVA: 0x00D1C670 File Offset: 0x00D1A870
		public int? SelectRoleSkinId { get; set; }

		// Token: 0x17008A34 RID: 35380
		// (get) Token: 0x06034664 RID: 214628 RVA: 0x00D1C679 File Offset: 0x00D1A879
		// (set) Token: 0x06034665 RID: 214629 RVA: 0x00D1C681 File Offset: 0x00D1A881
		public int? OrnamentSkinId { get; set; }

		// Token: 0x17008A35 RID: 35381
		// (get) Token: 0x06034666 RID: 214630 RVA: 0x00D1C68A File Offset: 0x00D1A88A
		// (set) Token: 0x06034667 RID: 214631 RVA: 0x00D1C692 File Offset: 0x00D1A892
		public int? OrnamentId { get; set; }

		// Token: 0x17008A36 RID: 35382
		// (get) Token: 0x06034668 RID: 214632 RVA: 0x00D1C69B File Offset: 0x00D1A89B
		// (set) Token: 0x06034669 RID: 214633 RVA: 0x00D1C6A3 File Offset: 0x00D1A8A3
		public bool? SkipOrnamentCameraBlend { get; set; }
	}
}
