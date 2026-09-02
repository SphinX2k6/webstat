using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002F00 RID: 12032
[RequiredMember]
public class RequirementElementType : IRequirement
{
	// Token: 0x17002175 RID: 8565
	// (get) Token: 0x06018AF3 RID: 101107 RVA: 0x006F83CD File Offset: 0x006F65CD
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedElementType;
		}
	}

	// Token: 0x06018AF4 RID: 101108 RVA: 0x006F83D0 File Offset: 0x006F65D0
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementElementType()
	{
	}

	// Token: 0x0400BFEE RID: 49134
	[Nullable(1)]
	[RequiredMember]
	public EElementType[] ElementTypes;
}
