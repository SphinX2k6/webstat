using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EFC RID: 12028
[RequiredMember]
public class RequirementSmashType : IRequirement
{
	// Token: 0x17002171 RID: 8561
	// (get) Token: 0x06018AEB RID: 101099 RVA: 0x006F83A0 File Offset: 0x006F65A0
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedSmashType;
		}
	}

	// Token: 0x06018AEC RID: 101100 RVA: 0x006F83A3 File Offset: 0x006F65A3
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementSmashType()
	{
	}

	// Token: 0x0400BFEA RID: 49130
	[Nullable(1)]
	[RequiredMember]
	public int[] SmashTypes;
}
