using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002EFB RID: 12027
[RequiredMember]
public class RequirementAttributeInterval : IRequirement
{
	// Token: 0x17002170 RID: 8560
	// (get) Token: 0x06018AE9 RID: 101097 RVA: 0x006F8395 File Offset: 0x006F6595
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedLifeInterval;
		}
	}

	// Token: 0x06018AEA RID: 101098 RVA: 0x006F8398 File Offset: 0x006F6598
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementAttributeInterval()
	{
	}

	// Token: 0x0400BFE8 RID: 49128
	[RequiredMember]
	public ERequirementTargetType RequireTargetType;

	// Token: 0x0400BFE9 RID: 49129
	[Nullable(1)]
	[RequiredMember]
	public AttributeIntervalCheck RequireInterval;
}
