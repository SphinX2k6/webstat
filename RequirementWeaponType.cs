using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F01 RID: 12033
[RequiredMember]
public class RequirementWeaponType : IRequirement
{
	// Token: 0x17002176 RID: 8566
	// (get) Token: 0x06018AF5 RID: 101109 RVA: 0x006F83D8 File Offset: 0x006F65D8
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedWeaponType;
		}
	}

	// Token: 0x06018AF6 RID: 101110 RVA: 0x006F83DB File Offset: 0x006F65DB
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementWeaponType()
	{
	}

	// Token: 0x0400BFEF RID: 49135
	[Nullable(1)]
	[RequiredMember]
	public int[] WeaponTypes;
}
