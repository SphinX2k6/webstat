using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002EDF RID: 11999
public static class CharacterUnifiedStateTypes
{
	// Token: 0x06018A7A RID: 100986 RVA: 0x006F3F98 File Offset: 0x006F2198
	// Note: this type is marked as 'beforefieldinit'.
	static CharacterUnifiedStateTypes()
	{
		Dictionary<ECharPositionState, HashSet<ECharMoveState>> dictionary = new Dictionary<ECharPositionState, HashSet<ECharMoveState>>();
		dictionary[ECharPositionState.Ground] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.Stand,
			ECharMoveState.Walk,
			ECharMoveState.WalkStop,
			ECharMoveState.Run,
			ECharMoveState.RunStop,
			ECharMoveState.Sprint,
			ECharMoveState.SprintStop,
			ECharMoveState.Dodge,
			ECharMoveState.LandRoll,
			ECharMoveState.KnockDown,
			ECharMoveState.Parry,
			ECharMoveState.SoftKnock,
			ECharMoveState.HeavyKnock,
			ECharMoveState.NormalClimb,
			ECharMoveState.FastClimb,
			ECharMoveState.Glide,
			ECharMoveState.KnockUp,
			ECharMoveState.Captured,
			ECharMoveState.Flying,
			ECharMoveState.StandUp,
			ECharMoveState.BreakWeakness
		};
		dictionary[ECharPositionState.Climb] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.NormalClimb,
			ECharMoveState.FastClimb,
			ECharMoveState.ExitClimb,
			ECharMoveState.EnterClimb
		};
		dictionary[ECharPositionState.Air] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.Dodge,
			ECharMoveState.KnockDown,
			ECharMoveState.Parry,
			ECharMoveState.SoftKnock,
			ECharMoveState.HeavyKnock,
			ECharMoveState.Glide,
			ECharMoveState.KnockUp,
			ECharMoveState.Swing,
			ECharMoveState.Captured,
			ECharMoveState.Slide,
			ECharMoveState.Flying,
			ECharMoveState.Soar,
			ECharMoveState.Roll,
			ECharMoveState.Kite,
			ECharMoveState.WalkOnAir,
			ECharMoveState.BreakWeakness
		};
		dictionary[ECharPositionState.Water] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.FastSwim,
			ECharMoveState.NormalSwim
		};
		dictionary[ECharPositionState.Ski] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.NormalSki
		};
		dictionary[ECharPositionState.Ride] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.Gongduola,
			ECharMoveState.NpcVehicle
		};
		dictionary[ECharPositionState.RailSlide] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.Stand,
			ECharMoveState.Walk,
			ECharMoveState.Run
		};
		dictionary[ECharPositionState.Floating] = new HashSet<ECharMoveState>
		{
			ECharMoveState.Other,
			ECharMoveState.KnockDown,
			ECharMoveState.Parry,
			ECharMoveState.SoftKnock,
			ECharMoveState.HeavyKnock,
			ECharMoveState.KnockUp,
			ECharMoveState.Captured,
			ECharMoveState.Floating,
			ECharMoveState.Rise,
			ECharMoveState.Drop,
			ECharMoveState.FloatingGround
		};
		CharacterUnifiedStateTypes.LegalMoveStates = dictionary;
	}

	// Token: 0x0400BF0F RID: 48911
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<ECharPositionState, HashSet<ECharMoveState>> LegalMoveStates;
}
