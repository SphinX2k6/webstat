using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200299C RID: 10652
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerRecordShareData
{
	// Token: 0x0601530E RID: 86798 RVA: 0x005DDC83 File Offset: 0x005DBE83
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerRecordShareData()
	{
	}

	// Token: 0x0400A359 RID: 41817
	[RequiredMember]
	public string AreaTitle;

	// Token: 0x0400A35A RID: 41818
	[RequiredMember]
	public int TotalScore;

	// Token: 0x0400A35B RID: 41819
	[RequiredMember]
	public int TotalWave;

	// Token: 0x0400A35C RID: 41820
	[Nullable(2)]
	public string GradeResId;

	// Token: 0x0400A35D RID: 41821
	[RequiredMember]
	public List<ShipTowerRecordItemData> RecordList;

	// Token: 0x0400A35E RID: 41822
	[RequiredMember]
	public string DateText;
}
