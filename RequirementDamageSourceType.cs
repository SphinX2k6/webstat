using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F0C RID: 12044
[RequiredMember]
public class RequirementDamageSourceType : IRequirement
{
	// Token: 0x17002181 RID: 8577
	// (get) Token: 0x06018B0B RID: 101131 RVA: 0x006F845B File Offset: 0x006F665B
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.DamageSourceType;
		}
	}

	// Token: 0x06018B0C RID: 101132 RVA: 0x006F845F File Offset: 0x006F665F
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementDamageSourceType()
	{
	}

	// Token: 0x0400C005 RID: 49157
	[RequiredMember]
	public bool CheckInclude;

	// Token: 0x0400C006 RID: 49158
	[Nullable(1)]
	[RequiredMember]
	public DamageSourceType[] DamageSourceTypes;
}
