using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005051 RID: 20561
	[NullableContext(1)]
	public interface IDisplayableItem
	{
		// Token: 0x17008B4F RID: 35663
		// (get) Token: 0x06034EF0 RID: 216816
		// (set) Token: 0x06034EF1 RID: 216817
		string DisplayName { get; set; }

		// Token: 0x17008B50 RID: 35664
		// (get) Token: 0x06034EF2 RID: 216818
		// (set) Token: 0x06034EF3 RID: 216819
		string DisplayIcon { get; set; }

		// Token: 0x17008B51 RID: 35665
		// (get) Token: 0x06034EF4 RID: 216820
		// (set) Token: 0x06034EF5 RID: 216821
		int? DisplayCount { get; set; }

		// Token: 0x17008B52 RID: 35666
		// (get) Token: 0x06034EF6 RID: 216822
		// (set) Token: 0x06034EF7 RID: 216823
		bool IsUnlocked { get; set; }

		// Token: 0x17008B53 RID: 35667
		// (get) Token: 0x06034EF8 RID: 216824
		// (set) Token: 0x06034EF9 RID: 216825
		bool IsEquipped { get; set; }

		// Token: 0x17008B54 RID: 35668
		// (get) Token: 0x06034EFA RID: 216826
		// (set) Token: 0x06034EFB RID: 216827
		int? QualityLevel { get; set; }

		// Token: 0x17008B55 RID: 35669
		// (get) Token: 0x06034EFC RID: 216828
		// (set) Token: 0x06034EFD RID: 216829
		bool? IsFinished { get; set; }

		// Token: 0x17008B56 RID: 35670
		// (get) Token: 0x06034EFE RID: 216830
		// (set) Token: 0x06034EFF RID: 216831
		EClickActionType ClickAction { get; set; }

		// Token: 0x17008B57 RID: 35671
		// (get) Token: 0x06034F00 RID: 216832
		// (set) Token: 0x06034F01 RID: 216833
		int? ClickParam { get; set; }
	}
}
