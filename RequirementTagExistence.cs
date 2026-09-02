using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F02 RID: 12034
[RequiredMember]
public class RequirementTagExistence : IRequirement
{
	// Token: 0x17002177 RID: 8567
	// (get) Token: 0x06018AF7 RID: 101111 RVA: 0x006F83E3 File Offset: 0x006F65E3
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedTagExistence;
		}
	}

	// Token: 0x06018AF8 RID: 101112 RVA: 0x006F83E7 File Offset: 0x006F65E7
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementTagExistence()
	{
	}

	// Token: 0x0400BFF0 RID: 49136
	[RequiredMember]
	public bool IsExist;

	// Token: 0x0400BFF1 RID: 49137
	[RequiredMember]
	public ERequirementTargetType RequireTargetType;

	// Token: 0x0400BFF2 RID: 49138
	[Nullable(1)]
	[RequiredMember]
	public int[] RequireTagContainer;
}
