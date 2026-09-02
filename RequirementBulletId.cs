using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EFD RID: 12029
[RequiredMember]
public class RequirementBulletId : IRequirement
{
	// Token: 0x17002172 RID: 8562
	// (get) Token: 0x06018AED RID: 101101 RVA: 0x006F83AB File Offset: 0x006F65AB
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedBulletId;
		}
	}

	// Token: 0x06018AEE RID: 101102 RVA: 0x006F83AE File Offset: 0x006F65AE
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementBulletId()
	{
	}

	// Token: 0x0400BFEB RID: 49131
	[Nullable(1)]
	[RequiredMember]
	public long[] BulletIds;
}
