using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F0B RID: 12043
[RequiredMember]
public class RequirementBattleFlags : IRequirement
{
	// Token: 0x17002180 RID: 8576
	// (get) Token: 0x06018B09 RID: 101129 RVA: 0x006F844F File Offset: 0x006F664F
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.BattleFlags;
		}
	}

	// Token: 0x06018B0A RID: 101130 RVA: 0x006F8453 File Offset: 0x006F6653
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementBattleFlags()
	{
	}

	// Token: 0x0400C004 RID: 49156
	[Nullable(1)]
	[RequiredMember]
	public string[] BattleFlags;
}
