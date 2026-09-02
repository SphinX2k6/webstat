using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x02003133 RID: 12595
[RequiredMember]
public class EndSkillBehaviorParam
{
	// Token: 0x0601A15A RID: 106842 RVA: 0x007A6C2E File Offset: 0x007A4E2E
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public EndSkillBehaviorParam()
	{
	}

	// Token: 0x0400D142 RID: 53570
	[Nullable(1)]
	[RequiredMember]
	public Entity Entity;

	// Token: 0x0400D143 RID: 53571
	public ESkillBehaviorActionType ActionType;

	// Token: 0x0400D144 RID: 53572
	public EMovementMode? MovementMode;

	// Token: 0x0400D145 RID: 53573
	public ECollisionChannel? CollisionChannel;

	// Token: 0x0400D146 RID: 53574
	public ECollisionResponse? CollisionResponse;

	// Token: 0x0400D147 RID: 53575
	[Nullable(2)]
	public BaseSkillComponent SummonSkillComponent;

	// Token: 0x0400D148 RID: 53576
	public int? SummonSkillId;

	// Token: 0x0400D149 RID: 53577
	public long? GameplayCue;
}
