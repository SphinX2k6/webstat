using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024A6 RID: 9382
[NullableContext(1)]
[Nullable(0)]
public class VisionAttrRecommendInfo
{
	// Token: 0x06012341 RID: 74561 RVA: 0x00501D58 File Offset: 0x004FFF58
	public VisionAttrRecommendInfo()
	{
		this.MainAttrRecommendInfo = new List<AttrRecommendInfo>();
		this.SubAttrRecommendInfo = new List<AttrRecommendInfo>();
		this.OfficialMainAttrRecommendInfo = new List<AttrRecommendInfo>();
		this.OfficialSubAttrRecommendInfo = new List<AttrRecommendInfo>();
		this.UsageMainAttrRecommendInfo = new List<AttrRecommendInfo>();
		this.UsageSubAttrRecommendInfo = new List<AttrRecommendInfo>();
	}

	// Token: 0x06012342 RID: 74562 RVA: 0x00501DAD File Offset: 0x004FFFAD
	public List<AttrRecommendInfo> GetMainAttrRecommendInfo()
	{
		return this.MainAttrRecommendInfo;
	}

	// Token: 0x06012343 RID: 74563 RVA: 0x00501DB5 File Offset: 0x004FFFB5
	public List<AttrRecommendInfo> GetSubAttrRecommendInfo()
	{
		return this.SubAttrRecommendInfo;
	}

	// Token: 0x06012344 RID: 74564 RVA: 0x00501DBD File Offset: 0x004FFFBD
	public List<AttrRecommendInfo> GetOfficialMainAttrRecommendInfo()
	{
		return this.OfficialMainAttrRecommendInfo;
	}

	// Token: 0x06012345 RID: 74565 RVA: 0x00501DC5 File Offset: 0x004FFFC5
	public List<AttrRecommendInfo> GetOfficialSubAttrRecommendInfo()
	{
		return this.OfficialSubAttrRecommendInfo;
	}

	// Token: 0x06012346 RID: 74566 RVA: 0x00501DCD File Offset: 0x004FFFCD
	public List<AttrRecommendInfo> GetUsageMainAttrRecommendInfo()
	{
		return this.UsageMainAttrRecommendInfo;
	}

	// Token: 0x06012347 RID: 74567 RVA: 0x00501DD5 File Offset: 0x004FFFD5
	public List<AttrRecommendInfo> GetUsageSubAttrRecommendInfo()
	{
		return this.UsageSubAttrRecommendInfo;
	}

	// Token: 0x06012348 RID: 74568 RVA: 0x00501DE0 File Offset: 0x004FFFE0
	public void BuildPlanLists()
	{
		this.OfficialMainAttrRecommendInfo.Clear();
		this.OfficialSubAttrRecommendInfo.Clear();
		this.UsageMainAttrRecommendInfo.Clear();
		this.UsageSubAttrRecommendInfo.Clear();
		foreach (AttrRecommendInfo attrRecommendInfo in this.MainAttrRecommendInfo)
		{
			if (attrRecommendInfo.GetUsage() == 0)
			{
				this.OfficialMainAttrRecommendInfo.Add(attrRecommendInfo);
			}
			else
			{
				this.UsageMainAttrRecommendInfo.Add(attrRecommendInfo);
			}
		}
		foreach (AttrRecommendInfo attrRecommendInfo2 in this.SubAttrRecommendInfo)
		{
			if (attrRecommendInfo2.GetUsage() == 0)
			{
				this.OfficialSubAttrRecommendInfo.Add(attrRecommendInfo2);
			}
			else
			{
				this.UsageSubAttrRecommendInfo.Add(attrRecommendInfo2);
			}
		}
	}

	// Token: 0x04008E09 RID: 36361
	private readonly List<AttrRecommendInfo> MainAttrRecommendInfo;

	// Token: 0x04008E0A RID: 36362
	private readonly List<AttrRecommendInfo> SubAttrRecommendInfo;

	// Token: 0x04008E0B RID: 36363
	private readonly List<AttrRecommendInfo> OfficialMainAttrRecommendInfo;

	// Token: 0x04008E0C RID: 36364
	private readonly List<AttrRecommendInfo> OfficialSubAttrRecommendInfo;

	// Token: 0x04008E0D RID: 36365
	private readonly List<AttrRecommendInfo> UsageMainAttrRecommendInfo;

	// Token: 0x04008E0E RID: 36366
	private readonly List<AttrRecommendInfo> UsageSubAttrRecommendInfo;
}
