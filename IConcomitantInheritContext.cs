using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x0200303B RID: 12347
[NullableContext(2)]
[Nullable(0)]
public class IConcomitantInheritContext
{
	// Token: 0x0400C6D0 RID: 50896
	public bool SkillInterrupt;

	// Token: 0x0400C6D1 RID: 50897
	public bool HitInterrupt;

	// Token: 0x0400C6D2 RID: 50898
	public bool OtherInterrupt;

	// Token: 0x0400C6D3 RID: 50899
	[Nullable(1)]
	public List<long> NewSkillIds = new List<long>();

	// Token: 0x0400C6D4 RID: 50900
	public EConcomitantDurationType ConcomitantDurationType;

	// Token: 0x0400C6D5 RID: 50901
	public float Duration;

	// Token: 0x0400C6D6 RID: 50902
	public long StartCue;

	// Token: 0x0400C6D7 RID: 50903
	public long EndCue;

	// Token: 0x0400C6D8 RID: 50904
	public int SummonIndex;

	// Token: 0x0400C6D9 RID: 50905
	public long BuffId;

	// Token: 0x0400C6DA RID: 50906
	public long? PreMessage;

	// Token: 0x0400C6DB RID: 50907
	public int? SkillId;

	// Token: 0x0400C6DC RID: 50908
	public TimerHandle TimerHandle;

	// Token: 0x0400C6DD RID: 50909
	public UAnimMontage CurrentMontage;

	// Token: 0x0400C6DE RID: 50910
	public Action<UAnimMontage, bool> OnMontageEnded;

	// Token: 0x0400C6DF RID: 50911
	public CharacterAnimationComponent SummonAnimComp;
}
