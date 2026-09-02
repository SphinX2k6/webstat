using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EFF RID: 12031
[RequiredMember]
public class RequirementCritical : IRequirement
{
	// Token: 0x17002174 RID: 8564
	// (get) Token: 0x06018AF1 RID: 101105 RVA: 0x006F83C2 File Offset: 0x006F65C2
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.ShouldCritical;
		}
	}

	// Token: 0x06018AF2 RID: 101106 RVA: 0x006F83C5 File Offset: 0x006F65C5
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementCritical()
	{
	}

	// Token: 0x0400BFED RID: 49133
	[RequiredMember]
	public bool IsCritical;
}
