using System;
using System.Runtime.CompilerServices;

// Token: 0x02002763 RID: 10083
[NullableContext(1)]
[Nullable(0)]
public class ReportPersonInfo
{
	// Token: 0x06013E59 RID: 81497 RVA: 0x0058B59F File Offset: 0x0058979F
	public ReportPersonInfo(int playerId, string name, string signature, EReportSourceType sourceType)
	{
		this.PlayerId = playerId;
		this.Name = name;
		this.Signature = signature;
		this.SourceType = sourceType;
	}

	// Token: 0x06013E5A RID: 81498 RVA: 0x0058B5C4 File Offset: 0x005897C4
	public int GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x06013E5B RID: 81499 RVA: 0x0058B5CC File Offset: 0x005897CC
	public string GetName()
	{
		return this.Name;
	}

	// Token: 0x06013E5C RID: 81500 RVA: 0x0058B5D4 File Offset: 0x005897D4
	public string GetSignature()
	{
		return this.Signature;
	}

	// Token: 0x06013E5D RID: 81501 RVA: 0x0058B5DC File Offset: 0x005897DC
	public EReportSourceType GetSourceType()
	{
		return this.SourceType;
	}

	// Token: 0x04009AD9 RID: 39641
	private readonly int PlayerId;

	// Token: 0x04009ADA RID: 39642
	private readonly string Name;

	// Token: 0x04009ADB RID: 39643
	private readonly string Signature;

	// Token: 0x04009ADC RID: 39644
	private readonly EReportSourceType SourceType;
}
