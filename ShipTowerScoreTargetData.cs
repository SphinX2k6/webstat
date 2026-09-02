using System;
using System.Runtime.CompilerServices;

// Token: 0x02002986 RID: 10630
[RequiredMember]
public class ShipTowerScoreTargetData
{
	// Token: 0x060152FB RID: 86779 RVA: 0x005DDBEB File Offset: 0x005DBDEB
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerScoreTargetData()
	{
	}

	// Token: 0x0400A2FB RID: 41723
	[Nullable(1)]
	[RequiredMember]
	public string Title;

	// Token: 0x0400A2FC RID: 41724
	[RequiredMember]
	public int ScoreTarget;

	// Token: 0x0400A2FD RID: 41725
	[Nullable(2)]
	public string ScoreGradeRes;

	// Token: 0x0400A2FE RID: 41726
	[RequiredMember]
	public bool IsFinish;
}
