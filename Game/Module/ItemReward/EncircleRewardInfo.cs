using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B11 RID: 23313
	public class EncircleRewardInfo : RewardInfo, IEncircleRewardInfo, IRewardInfo
	{
		// Token: 0x170096A3 RID: 38563
		// (get) Token: 0x0603B003 RID: 241667 RVA: 0x00EF256D File Offset: 0x00EF076D
		// (set) Token: 0x0603B004 RID: 241668 RVA: 0x00EF2575 File Offset: 0x00EF0775
		public bool IsSuccess { get; set; }

		// Token: 0x170096A4 RID: 38564
		// (get) Token: 0x0603B005 RID: 241669 RVA: 0x00EF257E File Offset: 0x00EF077E
		// (set) Token: 0x0603B006 RID: 241670 RVA: 0x00EF2586 File Offset: 0x00EF0786
		public int? Score { get; set; }

		// Token: 0x170096A5 RID: 38565
		// (get) Token: 0x0603B007 RID: 241671 RVA: 0x00EF258F File Offset: 0x00EF078F
		// (set) Token: 0x0603B008 RID: 241672 RVA: 0x00EF2597 File Offset: 0x00EF0797
		public int? RecordScore { get; set; }

		// Token: 0x170096A6 RID: 38566
		// (get) Token: 0x0603B009 RID: 241673 RVA: 0x00EF25A0 File Offset: 0x00EF07A0
		// (set) Token: 0x0603B00A RID: 241674 RVA: 0x00EF25A8 File Offset: 0x00EF07A8
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RewardItemData> CommonItems { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
