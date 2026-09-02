using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02002F0E RID: 12046
[RequiredMember]
public class RequirementRelationship : IRequirement
{
	// Token: 0x17002183 RID: 8579
	// (get) Token: 0x06018B0F RID: 101135 RVA: 0x006F8473 File Offset: 0x006F6673
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.Relationship;
		}
	}

	// Token: 0x06018B10 RID: 101136 RVA: 0x006F8477 File Offset: 0x006F6677
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementRelationship()
	{
	}

	// Token: 0x0400C008 RID: 49160
	[RequiredMember]
	public ERequirementTargetType RequireTargetType1;

	// Token: 0x0400C009 RID: 49161
	[RequiredMember]
	public ERequirementTargetType RequireTargetType2;

	// Token: 0x0400C00A RID: 49162
	[RequiredMember]
	public ERelation Relationship;
}
