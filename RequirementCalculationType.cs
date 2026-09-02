using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F0A RID: 12042
[RequiredMember]
public class RequirementCalculationType : IRequirement
{
	// Token: 0x1700217F RID: 8575
	// (get) Token: 0x06018B07 RID: 101127 RVA: 0x006F8443 File Offset: 0x006F6643
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.CalculateType;
		}
	}

	// Token: 0x06018B08 RID: 101128 RVA: 0x006F8447 File Offset: 0x006F6647
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementCalculationType()
	{
	}

	// Token: 0x0400C003 RID: 49155
	[Nullable(1)]
	[RequiredMember]
	public ECalculationType[] CalculationTypes;
}
