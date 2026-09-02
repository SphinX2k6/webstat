using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F05 RID: 12037
[RequiredMember]
public class RequirementDamageGenre : IRequirement
{
	// Token: 0x1700217A RID: 8570
	// (get) Token: 0x06018AFD RID: 101117 RVA: 0x006F8407 File Offset: 0x006F6607
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedDamageGenre;
		}
	}

	// Token: 0x06018AFE RID: 101118 RVA: 0x006F840B File Offset: 0x006F660B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementDamageGenre()
	{
	}

	// Token: 0x0400BFF5 RID: 49141
	[Nullable(1)]
	[RequiredMember]
	public int[] DamageTypes;
}
