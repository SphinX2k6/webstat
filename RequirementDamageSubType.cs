using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F06 RID: 12038
[RequiredMember]
public class RequirementDamageSubType : IRequirement
{
	// Token: 0x1700217B RID: 8571
	// (get) Token: 0x06018AFF RID: 101119 RVA: 0x006F8413 File Offset: 0x006F6613
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.DamageSubType;
		}
	}

	// Token: 0x06018B00 RID: 101120 RVA: 0x006F8417 File Offset: 0x006F6617
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementDamageSubType()
	{
	}

	// Token: 0x0400BFF6 RID: 49142
	[RequiredMember]
	public ERequirementsIncludeType IncludeType;

	// Token: 0x0400BFF7 RID: 49143
	[Nullable(1)]
	[RequiredMember]
	public int[] DamageSubTypes;
}
