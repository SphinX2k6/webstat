using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F03 RID: 12035
[RequiredMember]
public class RequirementPartTag : IRequirement
{
	// Token: 0x17002178 RID: 8568
	// (get) Token: 0x06018AF9 RID: 101113 RVA: 0x006F83EF File Offset: 0x006F65EF
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedPartTag;
		}
	}

	// Token: 0x06018AFA RID: 101114 RVA: 0x006F83F3 File Offset: 0x006F65F3
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementPartTag()
	{
	}

	// Token: 0x0400BFF3 RID: 49139
	[Nullable(1)]
	[RequiredMember]
	public int[] RequirePartTags;
}
