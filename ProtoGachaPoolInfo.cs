using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001D0E RID: 7438
[NullableContext(1)]
[Nullable(0)]
public class ProtoGachaPoolInfo
{
	// Token: 0x0600DA77 RID: 55927 RVA: 0x003AB2E0 File Offset: 0x003A94E0
	public ProtoGachaPoolInfo(GachaPoolInfo poolInfo)
	{
		this.Id = poolInfo.Id;
		this.BeginTime = (double)Singleton<MathUtils>.Instance.LongToNumber(poolInfo.BeginTime);
		this.EndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(poolInfo.EndTime);
		this.Title = poolInfo.Title;
		this.Description = poolInfo.SummaryDescribe;
		this.UiType = poolInfo.UIType;
		this.ThemeColor = poolInfo.ThemeColor;
		this.ShowIdList = poolInfo.ShowIdList.ToArray<int>();
		this.UpList = poolInfo.UpList.ToArray<int>();
		this.PreviewIdList = poolInfo.PreviewIdList.ToArray<int>();
		this.ComplianceDetail = poolInfo.ComplianceDetail;
		GachaPool? gachaPoolConfig = ConfigBase<GachaConfig>.Instance.GetGachaPoolConfig(this.Id);
		if (gachaPoolConfig != null)
		{
			this.Sort = gachaPoolConfig.Value.Sort;
		}
	}

	// Token: 0x04006849 RID: 26697
	public int Id;

	// Token: 0x0400684A RID: 26698
	public double BeginTime;

	// Token: 0x0400684B RID: 26699
	public double EndTime;

	// Token: 0x0400684C RID: 26700
	public int Sort;

	// Token: 0x0400684D RID: 26701
	public string Title = "";

	// Token: 0x0400684E RID: 26702
	public string Description = "";

	// Token: 0x0400684F RID: 26703
	public int UiType;

	// Token: 0x04006850 RID: 26704
	public string ThemeColor = "";

	// Token: 0x04006851 RID: 26705
	public int[] ShowIdList = Array.Empty<int>();

	// Token: 0x04006852 RID: 26706
	public int[] UpList = Array.Empty<int>();

	// Token: 0x04006853 RID: 26707
	public int[] PreviewIdList = Array.Empty<int>();

	// Token: 0x04006854 RID: 26708
	public string ComplianceDetail = "";
}
