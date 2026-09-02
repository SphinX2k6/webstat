using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B27 RID: 23335
	[NullableContext(2)]
	[Nullable(0)]
	public class RewardExploreConfirmButtonData : IRewardExploreConfirmButton
	{
		// Token: 0x170096EC RID: 38636
		// (get) Token: 0x0603B0A0 RID: 241824 RVA: 0x00EF2807 File Offset: 0x00EF0A07
		// (set) Token: 0x0603B0A1 RID: 241825 RVA: 0x00EF280F File Offset: 0x00EF0A0F
		[Nullable(1)]
		public string ButtonTextId { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170096ED RID: 38637
		// (get) Token: 0x0603B0A2 RID: 241826 RVA: 0x00EF2818 File Offset: 0x00EF0A18
		// (set) Token: 0x0603B0A3 RID: 241827 RVA: 0x00EF2820 File Offset: 0x00EF0A20
		public string DescriptionTextId { get; set; }

		// Token: 0x170096EE RID: 38638
		// (get) Token: 0x0603B0A4 RID: 241828 RVA: 0x00EF2829 File Offset: 0x00EF0A29
		// (set) Token: 0x0603B0A5 RID: 241829 RVA: 0x00EF2831 File Offset: 0x00EF0A31
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<object> DescriptionArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170096EF RID: 38639
		// (get) Token: 0x0603B0A6 RID: 241830 RVA: 0x00EF283A File Offset: 0x00EF0A3A
		// (set) Token: 0x0603B0A7 RID: 241831 RVA: 0x00EF2842 File Offset: 0x00EF0A42
		public int? TimeDown { get; set; }

		// Token: 0x170096F0 RID: 38640
		// (get) Token: 0x0603B0A8 RID: 241832 RVA: 0x00EF284B File Offset: 0x00EF0A4B
		// (set) Token: 0x0603B0A9 RID: 241833 RVA: 0x00EF2853 File Offset: 0x00EF0A53
		public bool IsTimeDownCloseView { get; set; }

		// Token: 0x170096F1 RID: 38641
		// (get) Token: 0x0603B0AA RID: 241834 RVA: 0x00EF285C File Offset: 0x00EF0A5C
		// (set) Token: 0x0603B0AB RID: 241835 RVA: 0x00EF2864 File Offset: 0x00EF0A64
		public Action OnTimeDownOnCallback { get; set; }

		// Token: 0x170096F2 RID: 38642
		// (get) Token: 0x0603B0AC RID: 241836 RVA: 0x00EF286D File Offset: 0x00EF0A6D
		// (set) Token: 0x0603B0AD RID: 241837 RVA: 0x00EF2875 File Offset: 0x00EF0A75
		public bool IsClickedCloseView { get; set; }

		// Token: 0x170096F3 RID: 38643
		// (get) Token: 0x0603B0AE RID: 241838 RVA: 0x00EF287E File Offset: 0x00EF0A7E
		// (set) Token: 0x0603B0AF RID: 241839 RVA: 0x00EF2886 File Offset: 0x00EF0A86
		public Action<int> OnClickedCallback { get; set; }

		// Token: 0x170096F4 RID: 38644
		// (get) Token: 0x0603B0B0 RID: 241840 RVA: 0x00EF288F File Offset: 0x00EF0A8F
		// (set) Token: 0x0603B0B1 RID: 241841 RVA: 0x00EF2897 File Offset: 0x00EF0A97
		public int? ClickCd { get; set; }
	}
}
