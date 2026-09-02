using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B26 RID: 23334
	[NullableContext(2)]
	public interface IRewardExploreConfirmButton
	{
		// Token: 0x170096E3 RID: 38627
		// (get) Token: 0x0603B08E RID: 241806
		// (set) Token: 0x0603B08F RID: 241807
		[Nullable(1)]
		string ButtonTextId { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170096E4 RID: 38628
		// (get) Token: 0x0603B090 RID: 241808
		// (set) Token: 0x0603B091 RID: 241809
		string DescriptionTextId { get; set; }

		// Token: 0x170096E5 RID: 38629
		// (get) Token: 0x0603B092 RID: 241810
		// (set) Token: 0x0603B093 RID: 241811
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<object> DescriptionArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170096E6 RID: 38630
		// (get) Token: 0x0603B094 RID: 241812
		// (set) Token: 0x0603B095 RID: 241813
		int? TimeDown { get; set; }

		// Token: 0x170096E7 RID: 38631
		// (get) Token: 0x0603B096 RID: 241814
		// (set) Token: 0x0603B097 RID: 241815
		bool IsTimeDownCloseView { get; set; }

		// Token: 0x170096E8 RID: 38632
		// (get) Token: 0x0603B098 RID: 241816
		// (set) Token: 0x0603B099 RID: 241817
		Action OnTimeDownOnCallback { get; set; }

		// Token: 0x170096E9 RID: 38633
		// (get) Token: 0x0603B09A RID: 241818
		// (set) Token: 0x0603B09B RID: 241819
		bool IsClickedCloseView { get; set; }

		// Token: 0x170096EA RID: 38634
		// (get) Token: 0x0603B09C RID: 241820
		// (set) Token: 0x0603B09D RID: 241821
		Action<int> OnClickedCallback { get; set; }

		// Token: 0x170096EB RID: 38635
		// (get) Token: 0x0603B09E RID: 241822
		// (set) Token: 0x0603B09F RID: 241823
		int? ClickCd { get; set; }
	}
}
