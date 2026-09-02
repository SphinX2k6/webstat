using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F04 RID: 12036
[RequiredMember]
public class RequirementBulletTag : IRequirement
{
	// Token: 0x17002179 RID: 8569
	// (get) Token: 0x06018AFB RID: 101115 RVA: 0x006F83FB File Offset: 0x006F65FB
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedBulletTag;
		}
	}

	// Token: 0x06018AFC RID: 101116 RVA: 0x006F83FF File Offset: 0x006F65FF
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementBulletTag()
	{
	}

	// Token: 0x0400BFF4 RID: 49140
	[Nullable(1)]
	[RequiredMember]
	public int[] RequireBulletTags;
}
