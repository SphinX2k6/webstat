using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;

// Token: 0x02002F09 RID: 12041
[RequiredMember]
public class RequirementFollowTagExistence : IRequirement
{
	// Token: 0x1700217E RID: 8574
	// (get) Token: 0x06018B05 RID: 101125 RVA: 0x006F8437 File Offset: 0x006F6637
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedFollowTagExistence;
		}
	}

	// Token: 0x06018B06 RID: 101126 RVA: 0x006F843B File Offset: 0x006F663B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementFollowTagExistence()
	{
	}

	// Token: 0x0400BFFE RID: 49150
	[RequiredMember]
	public ESummonType SummonType;

	// Token: 0x0400BFFF RID: 49151
	[RequiredMember]
	public int SummonIndex;

	// Token: 0x0400C000 RID: 49152
	[RequiredMember]
	public bool IsExist;

	// Token: 0x0400C001 RID: 49153
	[RequiredMember]
	public ERequirementTargetType RequireTargetType;

	// Token: 0x0400C002 RID: 49154
	[Nullable(1)]
	[RequiredMember]
	public int[] RequireTagContainer;
}
