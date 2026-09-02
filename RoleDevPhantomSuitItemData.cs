using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200280D RID: 10253
[NullableContext(1)]
[Nullable(0)]
public class RoleDevPhantomSuitItemData
{
	// Token: 0x060143B6 RID: 82870 RVA: 0x005A2456 File Offset: 0x005A0656
	[NullableContext(2)]
	public void Init(int fetterGroupId, int roleId, VisionFetterRecommendInfo visionFetterRecommendInfo)
	{
		this.SuitIdInternal = fetterGroupId;
		this.RoleIdInternal = roleId;
		this.VisionFetterRecommendInfoInternal = visionFetterRecommendInfo;
	}

	// Token: 0x17001A07 RID: 6663
	// (get) Token: 0x060143B7 RID: 82871 RVA: 0x005A246D File Offset: 0x005A066D
	public int SuitId
	{
		get
		{
			return this.SuitIdInternal;
		}
	}

	// Token: 0x17001A08 RID: 6664
	// (get) Token: 0x060143B8 RID: 82872 RVA: 0x005A2475 File Offset: 0x005A0675
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A09 RID: 6665
	// (get) Token: 0x060143B9 RID: 82873 RVA: 0x005A247D File Offset: 0x005A067D
	public List<int> RecommendGroupIds
	{
		get
		{
			VisionFetterRecommendInfo visionFetterRecommendInfoInternal = this.VisionFetterRecommendInfoInternal;
			return ((visionFetterRecommendInfoInternal != null) ? visionFetterRecommendInfoInternal.BuildFetterList() : null) ?? new List<int>();
		}
	}

	// Token: 0x17001A0A RID: 6666
	// (get) Token: 0x060143BA RID: 82874 RVA: 0x005A249A File Offset: 0x005A069A
	public int UseRate
	{
		get
		{
			VisionFetterRecommendInfo visionFetterRecommendInfoInternal = this.VisionFetterRecommendInfoInternal;
			if (visionFetterRecommendInfoInternal == null)
			{
				return 0;
			}
			return visionFetterRecommendInfoInternal.GetUsage();
		}
	}

	// Token: 0x17001A0B RID: 6667
	// (get) Token: 0x060143BB RID: 82875 RVA: 0x005A24AD File Offset: 0x005A06AD
	public string UseRateText
	{
		get
		{
			VisionFetterRecommendInfo visionFetterRecommendInfoInternal = this.VisionFetterRecommendInfoInternal;
			return ((visionFetterRecommendInfoInternal != null) ? visionFetterRecommendInfoInternal.GetUsageText() : null) ?? "";
		}
	}

	// Token: 0x17001A0C RID: 6668
	// (get) Token: 0x060143BC RID: 82876 RVA: 0x005A24CC File Offset: 0x005A06CC
	public PhantomFetterGroup? FetterGroupConfig
	{
		get
		{
			PhantomBattleConfig instance = ConfigBase<PhantomBattleConfig>.Instance;
			if (instance == null)
			{
				return null;
			}
			return new PhantomFetterGroup?(instance.GetFetterGroupById(this.SuitIdInternal));
		}
	}

	// Token: 0x17001A0D RID: 6669
	// (get) Token: 0x060143BD RID: 82877 RVA: 0x005A24FC File Offset: 0x005A06FC
	public string SuitName
	{
		get
		{
			PhantomFetterGroup? phantomFetterGroup;
			return ((this.FetterGroupConfig != null) ? phantomFetterGroup.GetValueOrDefault().FetterGroupName : null) ?? "";
		}
	}

	// Token: 0x17001A0E RID: 6670
	// (get) Token: 0x060143BE RID: 82878 RVA: 0x005A2534 File Offset: 0x005A0734
	public bool HasElementIcon
	{
		get
		{
			PhantomFetterGroup? phantomFetterGroup;
			return !string.IsNullOrEmpty((this.FetterGroupConfig != null) ? phantomFetterGroup.GetValueOrDefault().FetterElementPath : null);
		}
	}

	// Token: 0x17001A0F RID: 6671
	// (get) Token: 0x060143BF RID: 82879 RVA: 0x005A256C File Offset: 0x005A076C
	[Nullable(2)]
	public string ElementColor
	{
		[NullableContext(2)]
		get
		{
			if (this.FetterGroupConfig == null)
			{
				return null;
			}
			PhantomFetterGroup? phantomFetterGroup;
			return phantomFetterGroup.GetValueOrDefault().FetterElementColor;
		}
	}

	// Token: 0x17001A10 RID: 6672
	// (get) Token: 0x060143C0 RID: 82880 RVA: 0x005A259C File Offset: 0x005A079C
	[Nullable(2)]
	public string ElementIconPath
	{
		[NullableContext(2)]
		get
		{
			if (this.FetterGroupConfig == null)
			{
				return null;
			}
			PhantomFetterGroup? phantomFetterGroup;
			return phantomFetterGroup.GetValueOrDefault().FetterElementPath;
		}
	}

	// Token: 0x17001A11 RID: 6673
	// (get) Token: 0x060143C1 RID: 82881 RVA: 0x005A25CC File Offset: 0x005A07CC
	public List<int> DungeonIdList
	{
		get
		{
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup = (instance != null) ? instance.GetPhantomJumpGroupConfig(this.SuitIdInternal) : null;
			if (roleDevPhantomJumpGroup == null)
			{
				return new List<int>();
			}
			int[] array = roleDevPhantomJumpGroup.Value.PhantomJumpId();
			if (array == null)
			{
				return new List<int>();
			}
			return new List<int>(array);
		}
	}

	// Token: 0x04009D6E RID: 40302
	private int SuitIdInternal;

	// Token: 0x04009D6F RID: 40303
	private int RoleIdInternal;

	// Token: 0x04009D70 RID: 40304
	[Nullable(2)]
	private VisionFetterRecommendInfo VisionFetterRecommendInfoInternal;
}
