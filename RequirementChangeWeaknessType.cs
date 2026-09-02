using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F0D RID: 12045
[RequiredMember]
public class RequirementChangeWeaknessType : IRequirement
{
	// Token: 0x17002182 RID: 8578
	// (get) Token: 0x06018B0D RID: 101133 RVA: 0x006F8467 File Offset: 0x006F6667
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.ChangeWeaknessType;
		}
	}

	// Token: 0x06018B0E RID: 101134 RVA: 0x006F846B File Offset: 0x006F666B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementChangeWeaknessType()
	{
	}

	// Token: 0x0400C007 RID: 49159
	[RequiredMember]
	public EChangeWeaknessType ChangeWeaknessType;
}
