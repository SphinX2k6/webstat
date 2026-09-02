using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F08 RID: 12040
[RequiredMember]
public class RequirementBuffStackCount : IRequirement
{
	// Token: 0x1700217D RID: 8573
	// (get) Token: 0x06018B03 RID: 101123 RVA: 0x006F842B File Offset: 0x006F662B
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.BuffStackCount;
		}
	}

	// Token: 0x06018B04 RID: 101124 RVA: 0x006F842F File Offset: 0x006F662F
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementBuffStackCount()
	{
	}

	// Token: 0x0400BFFA RID: 49146
	[RequiredMember]
	public long BuffId;

	// Token: 0x0400BFFB RID: 49147
	[RequiredMember]
	public ERequirementTargetType RequireTargetType;

	// Token: 0x0400BFFC RID: 49148
	[RequiredMember]
	public int MinStack;

	// Token: 0x0400BFFD RID: 49149
	[RequiredMember]
	public int MaxStack;
}
