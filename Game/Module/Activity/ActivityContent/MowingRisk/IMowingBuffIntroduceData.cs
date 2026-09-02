using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200667C RID: 26236
	[NullableContext(1)]
	public interface IMowingBuffIntroduceData
	{
		// Token: 0x17009FB9 RID: 40889
		// (get) Token: 0x06041881 RID: 268417
		// (set) Token: 0x06041882 RID: 268418
		string BackgroundPath { get; set; }

		// Token: 0x17009FBA RID: 40890
		// (get) Token: 0x06041883 RID: 268419
		// (set) Token: 0x06041884 RID: 268420
		string LevelTextId { get; set; }

		// Token: 0x17009FBB RID: 40891
		// (get) Token: 0x06041885 RID: 268421
		// (set) Token: 0x06041886 RID: 268422
		string[] LevelTextArgs { get; set; }

		// Token: 0x17009FBC RID: 40892
		// (get) Token: 0x06041887 RID: 268423
		// (set) Token: 0x06041888 RID: 268424
		string NameTextId { get; set; }

		// Token: 0x17009FBD RID: 40893
		// (get) Token: 0x06041889 RID: 268425
		// (set) Token: 0x0604188A RID: 268426
		string TipsTextId { get; set; }

		// Token: 0x17009FBE RID: 40894
		// (get) Token: 0x0604188B RID: 268427
		// (set) Token: 0x0604188C RID: 268428
		string[] TipsArgs { get; set; }

		// Token: 0x17009FBF RID: 40895
		// (get) Token: 0x0604188D RID: 268429
		// (set) Token: 0x0604188E RID: 268430
		string IconPath { get; set; }

		// Token: 0x17009FC0 RID: 40896
		// (get) Token: 0x0604188F RID: 268431
		// (set) Token: 0x06041890 RID: 268432
		string HexColor { get; set; }

		// Token: 0x17009FC1 RID: 40897
		// (get) Token: 0x06041891 RID: 268433
		// (set) Token: 0x06041892 RID: 268434
		bool IsUnlock { get; set; }
	}
}
