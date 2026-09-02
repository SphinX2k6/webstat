using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EF8 RID: 12024
[RequiredMember]
public class RequirementSkillId : IRequirement
{
	// Token: 0x1700216D RID: 8557
	// (get) Token: 0x06018AE4 RID: 101092 RVA: 0x006F837F File Offset: 0x006F657F
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedSkillId;
		}
	}

	// Token: 0x06018AE5 RID: 101093 RVA: 0x006F8382 File Offset: 0x006F6582
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementSkillId()
	{
	}

	// Token: 0x0400BFE6 RID: 49126
	[Nullable(1)]
	[RequiredMember]
	public long[] SkillIds;
}
