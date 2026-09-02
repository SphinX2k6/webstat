using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EFE RID: 12030
[RequiredMember]
public class RequirementDamageId : IRequirement
{
	// Token: 0x17002173 RID: 8563
	// (get) Token: 0x06018AEF RID: 101103 RVA: 0x006F83B6 File Offset: 0x006F65B6
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedDamageId;
		}
	}

	// Token: 0x06018AF0 RID: 101104 RVA: 0x006F83BA File Offset: 0x006F65BA
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementDamageId()
	{
	}

	// Token: 0x0400BFEC RID: 49132
	[Nullable(1)]
	[RequiredMember]
	public long[] DamageIds;
}
