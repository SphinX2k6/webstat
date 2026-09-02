using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;

// Token: 0x02002EDB RID: 11995
[NullableContext(1)]
[Nullable(0)]
public class CharacterUnifiedStateComponent : BaseUnifiedStateComponent, IComponentDependency
{
	// Token: 0x06018A2B RID: 100907 RVA: 0x006F1B14 File Offset: 0x006EFD14
	static CharacterUnifiedStateComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterUnifiedStateComponent.CreateStaticDefaultValue), new Action(CharacterUnifiedStateComponent.ResetStaticDefaultValue));
	}

	// Token: 0x17002155 RID: 8533
	// (get) Token: 0x06018A2C RID: 100908 RVA: 0x006F1BD3 File Offset: 0x006EFDD3
	[Nullable(2)]
	protected new CharacterActorComponent ActorComponent
	{
		[NullableContext(2)]
		get
		{
			return this.ActorComponent as CharacterActorComponent;
		}
	}

	// Token: 0x17002156 RID: 8534
	// (get) Token: 0x06018A2D RID: 100909 RVA: 0x006F1BE0 File Offset: 0x006EFDE0
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterAbilityComponent)
			};
		}
	}

	// Token: 0x06018A2E RID: 100910 RVA: 0x006F1C02 File Offset: 0x006EFE02
	protected override bool OnInit()
	{
		CharacterUnifiedStateComponent.Load();
		return true;
	}

	// Token: 0x06018A2F RID: 100911 RVA: 0x006F1C0C File Offset: 0x006EFE0C
	protected override bool OnStart()
	{
		this.ActorComponent = base.Entity.GetComponent<CharacterActorComponent>();
		this.CueComponent = base.Entity.GetComponent<CharacterGameplayCueComponent>();
		this.AbilityComponent = base.Entity.CheckGetComponent<CharacterAbilityComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.MoveComponent = base.Entity.CheckGetComponent<CharacterMoveComponent>();
		this.RoleGaitComponent = base.Entity.GetComponent<RoleGaitComponent>();
		this.FloatingComponent = base.Entity.GetComponent<CharacterFloatingComponent>();
		this.IsInGameInternal = new bool?(false);
		this.InitCharState();
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.StateInheritHandle));
		Singleton<EventSystem>.Instance.AddWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<ECharDirectionState, ECharDirectionState>(base.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.OnDirectionStateChange));
		Singleton<EventSystem>.Instance.AddWithTarget<bool, AiController>(base.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAggroChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<bool>(base.Entity, EEventName.AiInFight, new Action<bool>(this.OnInFight));
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		return true;
	}

	// Token: 0x06018A30 RID: 100912 RVA: 0x006F1D6C File Offset: 0x006EFF6C
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.StateInheritHandle));
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharDirectionState, ECharDirectionState>(base.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.OnDirectionStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget<bool, AiController>(base.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAggroChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(base.Entity, EEventName.AiInFight, new Action<bool>(this.OnInFight));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component != null && component.GetEntityType() == EEntityType.Player)
		{
			ControllerBase<FormationDataController>.Instance.MarkAggroDirty();
		}
		return true;
	}

	// Token: 0x06018A31 RID: 100913 RVA: 0x006F1E66 File Offset: 0x006F0066
	protected override void OnEnable()
	{
		base.OnEnable();
		this.PreprocessChangeRole(true);
	}

	// Token: 0x06018A32 RID: 100914 RVA: 0x006F1E75 File Offset: 0x006F0075
	protected override void OnDisable(string reason)
	{
		base.OnDisable(reason);
		this.PreprocessChangeRole(false);
	}

	// Token: 0x06018A33 RID: 100915 RVA: 0x006F1E88 File Offset: 0x006F0088
	private void StateInheritHandle(Entity oldEntity, bool notInheritMoveAndAnim)
	{
		ControllerBase<FormationDataController>.Instance.MarkAggroDirty();
		CharacterUnifiedStateComponent characterUnifiedStateComponent = oldEntity.CheckGetComponent<CharacterUnifiedStateComponent>();
		this.IsWalkModeInternal = characterUnifiedStateComponent.IsWalkModeInternal;
		if (notInheritMoveAndAnim)
		{
			if (!CharacterUnifiedStateComponent.notInheritMoveStateSet.Contains(characterUnifiedStateComponent.MoveState) && CharacterUnifiedStateTypes.LegalMoveStates[this.PositionState].Contains(characterUnifiedStateComponent.MoveState))
			{
				this.SetMoveState(characterUnifiedStateComponent.MoveState);
			}
		}
		else if (this.RoleGaitComponent != null)
		{
			global::ECharMoveState moveState = characterUnifiedStateComponent.MoveState;
			if (moveState <= global::ECharMoveState.Captured)
			{
				switch (moveState)
				{
				case global::ECharMoveState.Walk:
				{
					this.SetPositionState(characterUnifiedStateComponent.PositionState);
					if (this.RoleGaitComponent.EnableRoleGaitState(ERoleGaitEnableType.Walk))
					{
						this.SetMoveState(characterUnifiedStateComponent.MoveState);
						goto IL_1DA;
					}
					global::ECharMoveState? echarMoveState = this.RoleGaitComponent.FindEnableCharMoveState();
					if (echarMoveState != null)
					{
						this.SetMoveState(echarMoveState.Value);
						goto IL_1DA;
					}
					goto IL_1DA;
				}
				case global::ECharMoveState.WalkStop:
				case global::ECharMoveState.RunStop:
					break;
				case global::ECharMoveState.Run:
				{
					this.SetPositionState(characterUnifiedStateComponent.PositionState);
					if (this.RoleGaitComponent.EnableRoleGaitState(ERoleGaitEnableType.Run))
					{
						this.SetMoveState(characterUnifiedStateComponent.MoveState);
						goto IL_1DA;
					}
					global::ECharMoveState? echarMoveState2 = this.RoleGaitComponent.FindEnableCharMoveState();
					if (echarMoveState2 != null)
					{
						this.SetMoveState(echarMoveState2.Value);
						goto IL_1DA;
					}
					goto IL_1DA;
				}
				case global::ECharMoveState.Sprint:
				{
					this.SetPositionState(characterUnifiedStateComponent.PositionState);
					if (this.RoleGaitComponent.EnableRoleGaitState(ERoleGaitEnableType.Sprint))
					{
						this.SetMoveState(characterUnifiedStateComponent.MoveState);
						goto IL_1DA;
					}
					global::ECharMoveState? echarMoveState3 = this.RoleGaitComponent.FindEnableCharMoveState();
					if (echarMoveState3 != null)
					{
						this.SetMoveState(echarMoveState3.Value);
						goto IL_1DA;
					}
					goto IL_1DA;
				}
				default:
					if (moveState == global::ECharMoveState.Captured)
					{
						goto IL_1DA;
					}
					break;
				}
			}
			else if (moveState == global::ECharMoveState.Flying || moveState == global::ECharMoveState.Roll)
			{
				goto IL_1DA;
			}
			if (characterUnifiedStateComponent.PositionState != global::ECharPositionState.Ride && characterUnifiedStateComponent.PositionState != global::ECharPositionState.Floating)
			{
				this.SetPositionState(characterUnifiedStateComponent.PositionState);
				this.SetMoveState(characterUnifiedStateComponent.MoveState);
			}
		}
		IL_1DA:
		ECharDirectionState directionState = characterUnifiedStateComponent.DirectionState;
		if (directionState != ECharDirectionState.AimDirection)
		{
			this.SetDirectionState(directionState);
		}
		else
		{
			this.SetDirectionState(ECharDirectionState.FaceDirection);
		}
		if (characterUnifiedStateComponent.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]))
		{
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持.长按"]));
		}
	}

	// Token: 0x06018A34 RID: 100916 RVA: 0x006F20C8 File Offset: 0x006F02C8
	private void OnCharacterMovementModeChanged(int charId, EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
		switch (newMovementMode)
		{
		case EMovementMode.MOVE_None:
			this.SetPositionState(global::ECharPositionState.Ground);
			this.SetMoveState(global::ECharMoveState.Other);
			return;
		case EMovementMode.MOVE_Walking:
		case EMovementMode.MOVE_NavWalking:
			this.SetPositionState(global::ECharPositionState.Ground);
			return;
		case EMovementMode.MOVE_Falling:
			this.SetPositionState(global::ECharPositionState.Air);
			if (this.MoveState != global::ECharMoveState.KnockUp && this.MoveState != global::ECharMoveState.Captured)
			{
				this.SetMoveState(global::ECharMoveState.Other);
				return;
			}
			break;
		case EMovementMode.MOVE_Swimming:
			break;
		case EMovementMode.MOVE_Flying:
			this.SetPositionState(global::ECharPositionState.Air);
			if (this.MoveState != global::ECharMoveState.Captured)
			{
				this.SetMoveState(global::ECharMoveState.Flying);
				return;
			}
			break;
		case EMovementMode.MOVE_Custom:
			switch (newCustomMode)
			{
			case 0:
				this.SetPositionState(global::ECharPositionState.Climb);
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]))
				{
					this.SwitchFastClimb(true, false);
					return;
				}
				return;
			case 1:
				this.SetPositionState(global::ECharPositionState.Water);
				return;
			case 2:
				this.SetPositionState(global::ECharPositionState.Air);
				this.SetMoveState(global::ECharMoveState.Glide);
				return;
			case 4:
				this.SetPositionState(global::ECharPositionState.Air);
				return;
			case 5:
				this.SetPositionState(global::ECharPositionState.Ground);
				return;
			case 6:
				this.SetPositionState(global::ECharPositionState.Air);
				return;
			case 7:
				this.SetPositionState(global::ECharPositionState.Air);
				this.SetMoveState(global::ECharMoveState.Soar);
				return;
			case 8:
				this.SetPositionState(global::ECharPositionState.Ski);
				return;
			case 9:
				this.SetPositionState(global::ECharPositionState.Air);
				this.SetMoveState(global::ECharMoveState.Roll);
				return;
			case 10:
				this.SetPositionState(global::ECharPositionState.Air);
				this.SetMoveState(global::ECharMoveState.Kite);
				return;
			case 11:
				this.SetPositionState(global::ECharPositionState.Ride);
				return;
			case 12:
				this.SetPositionState(global::ECharPositionState.RailSlide);
				return;
			case 13:
				this.SetPositionState(global::ECharPositionState.Climb);
				return;
			case 15:
				this.SetPositionState(global::ECharPositionState.Floating);
				this.SetMoveState(global::ECharMoveState.Floating);
				return;
			}
			this.SetPositionState(global::ECharPositionState.Air);
			break;
		case EMovementMode.MOVE_WalkingOnAir:
			this.SetPositionState(global::ECharPositionState.Air);
			this.SetMoveState(global::ECharMoveState.WalkOnAir);
			return;
		default:
			return;
		}
	}

	// Token: 0x17002157 RID: 8535
	// (get) Token: 0x06018A35 RID: 100917 RVA: 0x006F227B File Offset: 0x006F047B
	// (set) Token: 0x06018A36 RID: 100918 RVA: 0x006F2283 File Offset: 0x006F0483
	protected override global::ECharPositionState CachedPositionState { get; set; }

	// Token: 0x06018A37 RID: 100919 RVA: 0x006F228C File Offset: 0x006F048C
	public unsafe override void SetPositionState(global::ECharPositionState newPositionState)
	{
		global::ECharPositionState positionState = this.PositionState;
		if (!this.ActorComponent.IsMoveAutonomousProxy)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.UnifiedState;
			Entity entity = base.Entity;
			string message = "非主控端尝试修改位置状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("old", positionState.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("new", newPositionState.ToString());
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (!this.SetPositionStateInternal(newPositionState))
		{
			return;
		}
		this.OnPositionStateChange(positionState, newPositionState);
	}

	// Token: 0x06018A38 RID: 100920 RVA: 0x006F232F File Offset: 0x006F052F
	public void SetPositionStateHandle(global::ECharPositionState newPositionState)
	{
		if (this.ActorComponent.IsMoveAutonomousProxy)
		{
			return;
		}
		this.SetPositionStateInternal(newPositionState);
	}

	// Token: 0x06018A39 RID: 100921 RVA: 0x006F2348 File Offset: 0x006F0548
	private unsafe bool SetPositionStateInternal(global::ECharPositionState newPositionState)
	{
		global::ECharPositionState positionState = this.PositionState;
		if (positionState == newPositionState)
		{
			return false;
		}
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态"]));
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.PositionEnumToTag[newPositionState]));
		this.SetPositionSubState(global::ECharPositionSubState.None, true);
		this.CachedPositionState = newPositionState;
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.UnifiedState;
		Entity entity = base.Entity;
		string message = "设置位置状态";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("old", positionState.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("new", newPositionState.ToString());
		instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (base.Entity != null)
		{
			UKuroJsModelFunctionLibrary.SetCharacterUnifiedStateComponentPositionState(base.Entity.Id, (byte)newPositionState);
		}
		return true;
	}

	// Token: 0x17002158 RID: 8536
	// (get) Token: 0x06018A3A RID: 100922 RVA: 0x006F2436 File Offset: 0x006F0636
	public override global::ECharPositionState PositionState
	{
		get
		{
			return this.CachedPositionState;
		}
	}

	// Token: 0x06018A3B RID: 100923 RVA: 0x006F2440 File Offset: 0x006F0640
	protected override void OnLand()
	{
		FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.落地"]);
		this.AbilityComponent.SendGameplayEventToActor(gameplayTagById.Value, null);
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharOnLand);
		if (this.MoveState == global::ECharMoveState.KnockUp)
		{
			this.SetMoveState(global::ECharMoveState.StandUp);
			return;
		}
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击"]))
		{
			return;
		}
		this.SetMoveState(global::ECharMoveState.Other);
	}

	// Token: 0x06018A3C RID: 100924 RVA: 0x006F24C2 File Offset: 0x006F06C2
	protected override void OnPositionStateChange(global::ECharPositionState oldState, global::ECharPositionState newState)
	{
		if (newState == global::ECharPositionState.Ground)
		{
			this.OnLand();
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<global::ECharPositionState, global::ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, oldState, newState);
	}

	// Token: 0x17002159 RID: 8537
	// (get) Token: 0x06018A3D RID: 100925 RVA: 0x006F24E5 File Offset: 0x006F06E5
	// (set) Token: 0x06018A3E RID: 100926 RVA: 0x006F24ED File Offset: 0x006F06ED
	protected override global::ECharMoveState CachedMoveState { get; set; } = global::ECharMoveState.Stand;

	// Token: 0x06018A3F RID: 100927 RVA: 0x006F24F8 File Offset: 0x006F06F8
	public unsafe override void SetMoveState(global::ECharMoveState newMoveState)
	{
		ControllerBase<RoleAudioController>.Instance.OnMoveStateChange(newMoveState, base.Entity);
		if (!this.ActorComponent.IsMoveAutonomousProxy)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.UnifiedState;
			Entity entity = base.Entity;
			string message = "非主控端尝试修改移动状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("old", this.MoveState.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("new", newMoveState.ToString());
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.SetMoveStateInternal(newMoveState);
	}

	// Token: 0x06018A40 RID: 100928 RVA: 0x006F25A2 File Offset: 0x006F07A2
	public void SetMoveStateHandle(global::ECharMoveState newMoveState)
	{
		if (this.ActorComponent.IsMoveAutonomousProxy)
		{
			return;
		}
		this.SetMoveStateInternal(newMoveState);
	}

	// Token: 0x06018A41 RID: 100929 RVA: 0x006F25BC File Offset: 0x006F07BC
	private unsafe bool SetMoveStateInternal(global::ECharMoveState newMoveState)
	{
		global::ECharMoveState moveState = this.MoveState;
		if (moveState == newMoveState)
		{
			return false;
		}
		if (this.ActorComponent.IsRoleAndCtrlByMe && !CharacterUnifiedStateTypes.LegalMoveStates[this.PositionState].Contains(newMoveState))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Error Move State";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Actor";
			CharacterActorComponent actorComponent = this.ActorComponent;
			object item2;
			if (actorComponent == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = actorComponent.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ptr = new ValueTuple<string, object>(item, item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PositionState", this.PositionState);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MoveState", newMoveState);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		CombatLog instance2 = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.UnifiedState;
		Entity entity = base.Entity;
		string message2 = "修改移动状态";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("position", this.PositionState.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("state", newMoveState.ToString());
		instance2.Info(flag, entity, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态"]));
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.MoveEnumToTag[newMoveState]));
		this.CachedMoveState = newMoveState;
		if (base.Entity != null)
		{
			UKuroJsModelFunctionLibrary.SetCharacterUnifiedStateComponentMoveState(base.Entity.Id, (byte)newMoveState);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<global::ECharMoveState, global::ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, moveState, newMoveState);
		return true;
	}

	// Token: 0x1700215A RID: 8538
	// (get) Token: 0x06018A42 RID: 100930 RVA: 0x006F2784 File Offset: 0x006F0984
	public override global::ECharMoveState MoveState
	{
		get
		{
			return this.CachedMoveState;
		}
	}

	// Token: 0x1700215B RID: 8539
	// (get) Token: 0x06018A43 RID: 100931 RVA: 0x006F278C File Offset: 0x006F098C
	// (set) Token: 0x06018A44 RID: 100932 RVA: 0x006F2794 File Offset: 0x006F0994
	protected override ECharDirectionState CachedDirectionState { get; set; } = ECharDirectionState.FaceDirection;

	// Token: 0x06018A45 RID: 100933 RVA: 0x006F27A0 File Offset: 0x006F09A0
	private void OnDirectionStateChange(ECharDirectionState oldDirectionState, ECharDirectionState newDirectionState)
	{
		if (oldDirectionState == ECharDirectionState.AimDirection)
		{
			this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.瞄准模式.瞄准键进入"]));
			this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.瞄准模式.长按攻击进入"]));
		}
	}

	// Token: 0x06018A46 RID: 100934 RVA: 0x006F27F1 File Offset: 0x006F09F1
	public void EnterAimStatus(EAimViewState aimViewState)
	{
		this.CurrentAimType = aimViewState;
		this.ActorComponent.UseControllerRotation = true;
		this.SetDirectionState(ECharDirectionState.AimDirection);
		CharacterLevelShootComponent component = base.Entity.GetComponent<CharacterLevelShootComponent>();
		if (component == null)
		{
			return;
		}
		component.OnEnterAimShoot();
	}

	// Token: 0x06018A47 RID: 100935 RVA: 0x006F2824 File Offset: 0x006F0A24
	public void ExitAimStatus()
	{
		this.ActorComponent.UseControllerRotation = false;
		if (this.DirectionState == ECharDirectionState.AimDirection)
		{
			CharacterLockOnComponent component = base.Entity.GetComponent<CharacterLockOnComponent>();
			if (component == null || !component.TryRestoreLookAt())
			{
				this.SetDirectionState(ECharDirectionState.FaceDirection);
			}
		}
		CharacterLevelShootComponent component2 = base.Entity.GetComponent<CharacterLevelShootComponent>();
		if (component2 == null)
		{
			return;
		}
		component2.OnExitAimShoot();
	}

	// Token: 0x06018A48 RID: 100936 RVA: 0x006F287E File Offset: 0x006F0A7E
	public void SetDirectionStateHandle(ECharDirectionState newDirectionState)
	{
		base.SetDirectionStateInternal(newDirectionState);
	}

	// Token: 0x1700215C RID: 8540
	// (get) Token: 0x06018A49 RID: 100937 RVA: 0x006F2888 File Offset: 0x006F0A88
	public override ECharDirectionState DirectionState
	{
		get
		{
			return this.CachedDirectionState;
		}
	}

	// Token: 0x06018A4A RID: 100938 RVA: 0x006F2890 File Offset: 0x006F0A90
	protected override void ClearDirectionTag(ECharDirectionState oldDirectionState)
	{
		if (oldDirectionState == ECharDirectionState.AimDirection)
		{
			this.ExitAimState();
		}
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.方向状态"]));
	}

	// Token: 0x06018A4B RID: 100939 RVA: 0x006F28BC File Offset: 0x006F0ABC
	protected override void AddDirectionTag(ECharDirectionState charDirectionState)
	{
		if (charDirectionState == ECharDirectionState.AimDirection)
		{
			this.EnterAimState();
		}
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.DirectionEnumToTag[charDirectionState]));
	}

	// Token: 0x06018A4C RID: 100940 RVA: 0x006F28E4 File Offset: 0x006F0AE4
	protected void EnterAimState()
	{
		this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走.瞄准"]));
		switch (this.CurrentAimType)
		{
		case EAimViewState.瞄准154身高:
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.154身高"]));
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.融合.下半身右转融合"]));
			return;
		case EAimViewState.瞄准180身高:
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.180身高"]));
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.融合.下半身右转融合"]));
			return;
		case EAimViewState.寂寞小姐身高:
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.寂寞小姐瞄准镜头"]));
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.融合.下半身右转融合"]));
			return;
		case EAimViewState.露帕瞄准:
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.露帕瞄准"]));
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.融合.下半身右转融合"]));
			return;
		case EAimViewState.Rebecca瞄准:
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.Rebecca瞄准"]));
			return;
		default:
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.融合.下半身通用融合"]));
			return;
		}
	}

	// Token: 0x06018A4D RID: 100941 RVA: 0x006F2A74 File Offset: 0x006F0C74
	protected void ExitAimState()
	{
		this.CurrentAimType = EAimViewState.EAimViewState_MAX;
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走.瞄准"]));
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.融合.下半身通用融合"]));
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.融合.下半身右转融合"]));
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头"]));
	}

	// Token: 0x06018A4E RID: 100942 RVA: 0x006F2B08 File Offset: 0x006F0D08
	public override void InitCharState()
	{
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.PositionEnumToTag[global::ECharPositionState.Ground]));
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.MoveEnumToTag[global::ECharMoveState.Stand]));
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.DirectionEnumToTag[ECharDirectionState.FaceDirection]));
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.PositionSubStateEnumToTag[global::ECharPositionSubState.None]));
	}

	// Token: 0x06018A4F RID: 100943 RVA: 0x006F2B81 File Offset: 0x006F0D81
	public override void ResetCharState()
	{
		this.SetPositionSubState(global::ECharPositionSubState.None, false);
	}

	// Token: 0x06018A50 RID: 100944 RVA: 0x006F2B8B File Offset: 0x006F0D8B
	private void OnCharPositionSubStateChanged(global::ECharPositionSubState oldSubState, global::ECharPositionSubState newSubState)
	{
		Singleton<EventSystem>.Instance.EmitWithTarget<global::ECharPositionSubState, global::ECharPositionSubState>(base.Entity, EEventName.CharOnPositionSubStateChanged, oldSubState, newSubState);
	}

	// Token: 0x06018A51 RID: 100945 RVA: 0x006F2BA5 File Offset: 0x006F0DA5
	private void UpdatePositionSubTag(global::ECharPositionSubState oldSubState, global::ECharPositionSubState newSubState)
	{
		this.ClearPositionSubTag(oldSubState);
		this.AddPositionSubTag(newSubState);
	}

	// Token: 0x06018A52 RID: 100946 RVA: 0x006F2BB5 File Offset: 0x006F0DB5
	private void ClearPositionSubTag(global::ECharPositionSubState oldSubState)
	{
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态"]));
	}

	// Token: 0x06018A53 RID: 100947 RVA: 0x006F2BD7 File Offset: 0x006F0DD7
	private void AddPositionSubTag(global::ECharPositionSubState charSubState)
	{
		this.TagComponent.AddTag(new int?(CharacterUnifiedStateComponent.PositionSubStateEnumToTag[charSubState]));
	}

	// Token: 0x06018A54 RID: 100948 RVA: 0x006F2BF4 File Offset: 0x006F0DF4
	public void SetPositionSubStateHandle(global::ECharPositionSubState newCharPositionSubState)
	{
		this.SetPositionSubStateInternal(newCharPositionSubState, true);
	}

	// Token: 0x06018A55 RID: 100949 RVA: 0x006F2C00 File Offset: 0x006F0E00
	public bool SetPositionSubStateInternal(global::ECharPositionSubState newCharPositionSubState, bool forceAddTag = false)
	{
		global::ECharPositionSubState positionSubState = this.PositionSubState;
		if (positionSubState == newCharPositionSubState)
		{
			if (forceAddTag)
			{
				this.UpdatePositionSubTag(positionSubState, newCharPositionSubState);
			}
			return false;
		}
		this.PositionSubStateInternal = newCharPositionSubState;
		this.UpdatePositionSubTag(positionSubState, newCharPositionSubState);
		return true;
	}

	// Token: 0x06018A56 RID: 100950 RVA: 0x006F2C38 File Offset: 0x006F0E38
	public void SetPositionSubState(global::ECharPositionSubState newCharPositionSubState, bool forceAddTag = false)
	{
		if (!this.ActorComponent.IsAutonomousProxy)
		{
			return;
		}
		global::ECharPositionSubState positionSubState = this.PositionSubState;
		if (!this.SetPositionSubStateInternal(newCharPositionSubState, forceAddTag))
		{
			return;
		}
		this.OnCharPositionSubStateChanged(positionSubState, newCharPositionSubState);
	}

	// Token: 0x1700215D RID: 8541
	// (get) Token: 0x06018A57 RID: 100951 RVA: 0x006F2C6D File Offset: 0x006F0E6D
	public global::ECharPositionSubState PositionSubState
	{
		get
		{
			return this.PositionSubStateInternal;
		}
	}

	// Token: 0x06018A58 RID: 100952 RVA: 0x006F2C75 File Offset: 0x006F0E75
	private void EnterSprintRetain()
	{
		if (!this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持.长按"]))
		{
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持.长按"]));
		}
	}

	// Token: 0x06018A59 RID: 100953 RVA: 0x006F2CB2 File Offset: 0x006F0EB2
	private void ExitSprintRetain()
	{
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持.长按"]));
	}

	// Token: 0x06018A5A RID: 100954 RVA: 0x006F2CD4 File Offset: 0x006F0ED4
	public void SprintPress()
	{
		if (this.RoleGaitComponent == null || !this.RoleGaitComponent.EnableRoleGaitState(ERoleGaitEnableType.Sprint))
		{
			return;
		}
		this.EnterSprintRetain();
		RoleAudioController instance = ControllerBase<RoleAudioController>.Instance;
		Entity entity = base.Entity;
		global::ECharMoveState moveState = this.MoveState;
		global::ECharPositionState positionState = this.PositionState;
		CharacterMoveComponent moveComponent = this.MoveComponent;
		TEnumAsByte<EMovementMode>? tenumAsByte;
		if (moveComponent == null)
		{
			tenumAsByte = null;
		}
		else
		{
			UCharacterMovementComponent characterMovement = moveComponent.CharacterMovement;
			tenumAsByte = ((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null);
		}
		TEnumAsByte<EMovementMode>? tenumAsByte2 = tenumAsByte;
		int? movementMode = (tenumAsByte2 != null) ? new int?((int)tenumAsByte2.GetValueOrDefault()) : null;
		CharacterMoveComponent moveComponent2 = this.MoveComponent;
		byte? b;
		if (moveComponent2 == null)
		{
			b = null;
		}
		else
		{
			UCharacterMovementComponent characterMovement2 = moveComponent2.CharacterMovement;
			b = ((characterMovement2 != null) ? new byte?(characterMovement2.CustomMovementMode) : null);
		}
		byte? b2 = b;
		instance.OnPlayAccelerateAudio(entity, moveState, positionState, movementMode, (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null);
	}

	// Token: 0x06018A5B RID: 100955 RVA: 0x006F2DC9 File Offset: 0x006F0FC9
	public void SprintRelease()
	{
		this.ExitSprintRetain();
	}

	// Token: 0x06018A5C RID: 100956 RVA: 0x006F2DD1 File Offset: 0x006F0FD1
	public void WalkPress()
	{
		this.WalkPressInternal();
	}

	// Token: 0x06018A5D RID: 100957 RVA: 0x006F2DD9 File Offset: 0x006F0FD9
	public void SwingPress()
	{
		this.SetMoveState(global::ECharMoveState.Swing);
	}

	// Token: 0x06018A5E RID: 100958 RVA: 0x006F2DE3 File Offset: 0x006F0FE3
	public void SwingRelease()
	{
		this.SetMoveState(global::ECharMoveState.Other);
	}

	// Token: 0x06018A5F RID: 100959 RVA: 0x006F2DEC File Offset: 0x006F0FEC
	public void SwitchFastSwim(bool fastSwim)
	{
		this.SetMoveState(fastSwim ? global::ECharMoveState.FastSwim : global::ECharMoveState.NormalSwim);
		if (fastSwim)
		{
			this.EnterSprintRetain();
		}
	}

	// Token: 0x06018A60 RID: 100960 RVA: 0x006F2E08 File Offset: 0x006F1008
	public void SwitchFastClimb(bool fastClimb, bool noMatterEnterExit = false)
	{
		bool flag = (fastClimb && !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.快速攀爬禁止"])) || this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制快速攀爬"]);
		if (noMatterEnterExit || (this.MoveState != global::ECharMoveState.EnterClimb && this.MoveState != global::ECharMoveState.ExitClimb))
		{
			this.SetMoveState(flag ? global::ECharMoveState.FastClimb : global::ECharMoveState.NormalClimb);
		}
		if (flag)
		{
			this.EnterSprintRetain();
			RoleAudioController instance = ControllerBase<RoleAudioController>.Instance;
			Entity entity = base.Entity;
			global::ECharMoveState moveState = this.MoveState;
			global::ECharPositionState positionState = this.PositionState;
			CharacterMoveComponent moveComponent = this.MoveComponent;
			TEnumAsByte<EMovementMode>? tenumAsByte;
			if (moveComponent == null)
			{
				tenumAsByte = null;
			}
			else
			{
				UCharacterMovementComponent characterMovement = moveComponent.CharacterMovement;
				tenumAsByte = ((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null);
			}
			TEnumAsByte<EMovementMode>? tenumAsByte2 = tenumAsByte;
			int? movementMode = (tenumAsByte2 != null) ? new int?((int)tenumAsByte2.GetValueOrDefault()) : null;
			CharacterMoveComponent moveComponent2 = this.MoveComponent;
			byte? b;
			if (moveComponent2 == null)
			{
				b = null;
			}
			else
			{
				UCharacterMovementComponent characterMovement2 = moveComponent2.CharacterMovement;
				b = ((characterMovement2 != null) ? new byte?(characterMovement2.CustomMovementMode) : null);
			}
			byte? b2 = b;
			instance.OnPlayAccelerateAudio(entity, moveState, positionState, movementMode, (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null);
		}
	}

	// Token: 0x06018A61 RID: 100961 RVA: 0x006F2F50 File Offset: 0x006F1150
	public void ExitHitState(string reason = "")
	{
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击"]) && !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"]))
		{
			if (this.FloatingComponent != null && this.FloatingComponent.IsFloating)
			{
				this.FloatingComponent.ExitHitState();
			}
			else
			{
				this.SetMoveState(global::ECharMoveState.Other);
			}
		}
		base.Entity.GetComponent<CharacterHitComponent>().DeActiveStiff(reason);
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			base.Entity.GetComponent<CharacterMovementSyncComponent>().CollectSampleAndSend(false);
		}
		if (this.ActorComponent.IsMoveAutonomousProxy)
		{
			BaseHitComponent.HitEndRequest(base.Entity);
		}
		CharacterFightStateComponent component = base.Entity.GetComponent<CharacterFightStateComponent>();
		if (component != null && (component.CurrentState == ECharacterFightState.BeHit || component.CurrentState == ECharacterFightState.CounterattackBeHit || component.CurrentState == ECharacterFightState.BeBrokeWeakness))
		{
			base.Entity.GetComponent<CharacterFightStateComponent>().ResetState();
			this.ActorComponent.ResetMoveControlled("退出受击");
		}
	}

	// Token: 0x06018A62 RID: 100962 RVA: 0x006F3050 File Offset: 0x006F1250
	private void WalkPressInternal()
	{
		if (this.MoveComponent != null && this.MoveComponent.CanWalkPress() && this.MarkWalkOrRun(!this.IsWalkModeInternal, true, null))
		{
			this.SetWalkOrRunInternal(this.IsWalkMode);
		}
	}

	// Token: 0x06018A63 RID: 100963 RVA: 0x006F309C File Offset: 0x006F129C
	public bool CustomSetWalkOrRun(bool isWalk)
	{
		bool flag;
		if (isWalk)
		{
			flag = (this.MoveState != global::ECharMoveState.Walk);
		}
		else
		{
			flag = (this.MoveState != global::ECharMoveState.Run);
		}
		if (!flag)
		{
			return true;
		}
		if (this.MoveComponent != null && this.MoveComponent.CanWalkPress())
		{
			if (this.MarkWalkOrRun(isWalk, true, null))
			{
				this.SetWalkOrRunInternal(isWalk);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06018A64 RID: 100964 RVA: 0x006F3104 File Offset: 0x006F1304
	public bool MarkWalkOrRun(bool isWalk, bool showUi = true, bool? lockValue = null)
	{
		bool? flag = lockValue;
		bool flag2 = false;
		if (flag.GetValueOrDefault() == flag2 & flag != null)
		{
			this.LockWalkRunState = false;
		}
		if (isWalk == this.IsWalkModeInternal || this.LockWalkRunState || (this.TagComponent != null && this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.屏蔽切换走跑功能"])))
		{
			return false;
		}
		this.LockWalkRunState = (lockValue ?? this.LockWalkRunState);
		bool isWalkModeInternal = this.IsWalkModeInternal;
		this.IsWalkModeInternal = isWalk;
		if (!showUi || (this.TagComponent != null && this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.屏蔽切换行走提示"])))
		{
			Singleton<EventSystem>.Instance.Emit<bool, bool, bool>(EEventName.OnChangeWalkOrRun, isWalkModeInternal, isWalk, false);
		}
		else
		{
			Singleton<EventSystem>.Instance.Emit<bool, bool, bool>(EEventName.OnChangeWalkOrRun, isWalkModeInternal, isWalk, true);
		}
		return false;
	}

	// Token: 0x06018A65 RID: 100965 RVA: 0x006F31E5 File Offset: 0x006F13E5
	private void SetWalkOrRunInternal(bool isWalk)
	{
		if (this.PositionState != global::ECharPositionState.Ground)
		{
			return;
		}
		if (isWalk)
		{
			this.SetMoveState(global::ECharMoveState.Walk);
			return;
		}
		this.SetMoveState(global::ECharMoveState.Run);
	}

	// Token: 0x06018A66 RID: 100966 RVA: 0x006F3202 File Offset: 0x006F1402
	public bool IsInFightState()
	{
		return this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
	}

	// Token: 0x06018A67 RID: 100967 RVA: 0x006F3220 File Offset: 0x006F1420
	public void RefreshFightState(bool? inFight = null)
	{
		PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
		int valueOrDefault = ((instance != null) ? instance.GetId() : null).GetValueOrDefault();
		if (!ModelBase<SceneTeamModel>.Instance.GetAllGroupEntities(valueOrDefault).Exists((EntityHandle role) => role.Id == base.Entity.Id))
		{
			return;
		}
		if (inFight ?? (this.AggroSet.Count > 0))
		{
			this.TryAddInFightTags();
			return;
		}
		this.TryClearInFightTags();
	}

	// Token: 0x06018A68 RID: 100968 RVA: 0x006F32A4 File Offset: 0x006F14A4
	private bool TryAddInFightTags()
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]));
		}
		if (this.InFightCueHandle == 0)
		{
			this.InFightCueHandle = this.CueComponent.AddCue(1101005001L, null);
		}
		return true;
	}

	// Token: 0x06018A69 RID: 100969 RVA: 0x006F3300 File Offset: 0x006F1500
	public bool TryClearInFightTags()
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]));
		}
		if (this.InFightCueHandle != 0)
		{
			CharacterGameplayCueComponent cueComponent = this.CueComponent;
			if (cueComponent != null)
			{
				cueComponent.RemoveCueByHandle((long)this.InFightCueHandle);
			}
		}
		this.InFightCueHandle = 0;
		return true;
	}

	// Token: 0x06018A6A RID: 100970 RVA: 0x006F335C File Offset: 0x006F155C
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.PlayerBattleStateChangeNotify, false, false)]
	public static void OnPlayerBattleStateChangeNotify(Entity entity, [Nullable(1)] PlayerBattleStateChangeNotify data, CombatCommon combatCommon = null)
	{
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetAllGroupEntities(data.PlayerId))
		{
			WorldEntity entity2 = entityHandle.Entity;
			CharacterUnifiedStateComponent characterUnifiedStateComponent = (entity2 != null) ? entity2.GetComponent<CharacterUnifiedStateComponent>() : null;
			if (characterUnifiedStateComponent != null)
			{
				characterUnifiedStateComponent.RefreshFightState(new bool?(data.InBattle));
			}
			if (characterUnifiedStateComponent != null)
			{
				characterUnifiedStateComponent.OnInFight(data.InBattle);
			}
		}
		if (data.PlayerId == ModelBase<CreatureModel>.Instance.GetPlayerId())
		{
			ControllerBase<FormationDataController>.Instance.NotifyInFight(data.InBattle);
		}
	}

	// Token: 0x06018A6B RID: 100971 RVA: 0x006F340C File Offset: 0x006F160C
	public void OnAggroChanged(bool addOrRemove, AiController from)
	{
		int id = from.CharActorComp.Entity.Id;
		CharacterActorComponent actorComponent = this.ActorComponent;
		bool flag = actorComponent != null && actorComponent.CreatureData.GetEntityType() == EEntityType.Player;
		if (addOrRemove)
		{
			this.AggroSet.Add(id);
		}
		else
		{
			this.AggroSet.Remove(id);
		}
		int id2 = base.Entity.Id;
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		int? num = (getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null;
		if (id2 == num.GetValueOrDefault() & num != null)
		{
			ControllerBase<FormationDataController>.Instance.MarkAggroDirty();
		}
		if (flag)
		{
			ControllerBase<FormationDataController>.Instance.RefreshFightState();
		}
		if (!this.IsInFighting && !ControllerBase<FormationDataController>.Instance.GlobalIsInFight && addOrRemove && flag)
		{
			float num2 = (float)global::Vector.Dist(this.ActorComponent.ActorLocationProxy, from.CharActorComp.ActorLocationProxy);
			ControllerBase<RoleAudioController>.Instance.OnPlayerEnterFight(base.Entity, (double)num2);
		}
	}

	// Token: 0x06018A6C RID: 100972 RVA: 0x006F350C File Offset: 0x006F170C
	private void MarkActorInFighting(bool isInFighting)
	{
		this.IsInFighting = isInFighting;
		if (base.Entity != null && base.Entity.GameBudgetManagedToken != 0U)
		{
			UKuroGameBudgetAllocatorCSharpInterface.MarkActorInFighting(base.Entity.GameBudgetConfig.GroupName, base.Entity.GameBudgetManagedToken, isInFighting);
			CharacterActorComponent actorComponent = this.ActorComponent;
			TsBaseCharacter tsBaseCharacter = (actorComponent != null) ? actorComponent.Actor : null;
			if (tsBaseCharacter != null)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<bool>(tsBaseCharacter, EEventName.OnMarkActorInFighting, isInFighting);
			}
		}
	}

	// Token: 0x06018A6D RID: 100973 RVA: 0x006F357E File Offset: 0x006F177E
	public void OnInFight(bool inFight)
	{
		this.MarkActorInFighting(inFight);
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		if (component != null)
		{
			component.SetAnimParamsInFight(inFight);
		}
		ModelBase<CombatMessageModel>.Instance.AnyHateChange = true;
	}

	// Token: 0x06018A6E RID: 100974 RVA: 0x006F35AC File Offset: 0x006F17AC
	public void OnUpdateSceneTeam()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component != null && component.IsRole())
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int playerId = component.GetPlayerId();
			if ((id.GetValueOrDefault() == playerId & id != null) && ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
			{
				this.RefreshFightState(new bool?(true));
				this.OnInFight(true);
			}
		}
	}

	// Token: 0x1700215E RID: 8542
	// (get) Token: 0x06018A6F RID: 100975 RVA: 0x006F3615 File Offset: 0x006F1815
	public bool WalkModeLocked
	{
		get
		{
			return !this.RoleGaitComponent.EnableRoleGaitState(ERoleGaitEnableType.Run);
		}
	}

	// Token: 0x1700215F RID: 8543
	// (get) Token: 0x06018A70 RID: 100976 RVA: 0x006F3626 File Offset: 0x006F1826
	public bool IsWalkBaseMode
	{
		get
		{
			return this.IsWalkModeInternal;
		}
	}

	// Token: 0x17002160 RID: 8544
	// (get) Token: 0x06018A71 RID: 100977 RVA: 0x006F362E File Offset: 0x006F182E
	public bool IsWalkMode
	{
		get
		{
			return this.WalkModeLocked || this.IsWalkModeInternal;
		}
	}

	// Token: 0x06018A72 RID: 100978 RVA: 0x006F3640 File Offset: 0x006F1840
	public new unsafe static void Load()
	{
		if (CharacterUnifiedStateComponent.NeedLoad)
		{
			CharacterUnifiedStateComponent.PositionTagList = new int[]
			{
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.滑雪"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.载具"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.滑轨"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.悬浮"]
			};
			CharacterUnifiedStateComponent.MoveTagList = new int[]
			{
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.其他"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.站立"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.行走"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.行走停止"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.跑步"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.跑步停止"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.冲刺"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.冲刺停止"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.闪避"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.落地翻滚"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.击倒"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被弹反"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.轻击"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.重击"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.正常攀爬"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.快速攀爬"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.滑翔"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.击飞"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.加速游泳"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.正常游泳"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.摇荡"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.滑坡.普通滑坡"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.特殊飞行"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.攀爬.进入攀爬"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.攀爬.退出攀爬"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.滑雪.正常滑雪"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.倒地起身"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.特殊滚动"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.风筝"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.贡多拉"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.NPC载具"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.空中步行"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被破弱"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.上升"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.下降"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.常规移动"]
			};
			CharacterUnifiedStateComponent.DirectionTagList = new int[]
			{
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.注视方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.瞄准方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.面朝方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.看向方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.相机方向"]
			};
			CharacterUnifiedStateComponent.PositionSubStateTagList = new int[]
			{
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态.无次状态"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态.水面"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态.空中行走"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态.空中悬浮"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态.地面悬浮"]
			};
			CharacterUnifiedStateComponent.PositionEnumToTag = new Dictionary<global::ECharPositionState, int>();
			CharacterUnifiedStateComponent.PositionEnumToTagInverse = new Dictionary<int, global::ECharPositionState>();
			Array enumValuesAsUnderlyingType = typeof(global::ECharPositionState).GetEnumValuesAsUnderlyingType();
			foreach (global::ECharPositionState echarPositionState in *Unsafe.As<Array, global::ECharPositionState[]>(ref enumValuesAsUnderlyingType))
			{
				CharacterUnifiedStateComponent.PositionEnumToTag[echarPositionState] = CharacterUnifiedStateComponent.PositionTagList[(int)echarPositionState];
				CharacterUnifiedStateComponent.PositionEnumToTagInverse[CharacterUnifiedStateComponent.PositionTagList[(int)echarPositionState]] = echarPositionState;
			}
			CharacterUnifiedStateComponent.MoveEnumToTag = new Dictionary<global::ECharMoveState, int>();
			CharacterUnifiedStateComponent.MoveEnumToTagInverse = new Dictionary<int, global::ECharMoveState>();
			Array enumValuesAsUnderlyingType2 = typeof(global::ECharMoveState).GetEnumValuesAsUnderlyingType();
			foreach (global::ECharMoveState echarMoveState in *Unsafe.As<Array, global::ECharMoveState[]>(ref enumValuesAsUnderlyingType2))
			{
				CharacterUnifiedStateComponent.MoveEnumToTag[echarMoveState] = CharacterUnifiedStateComponent.MoveTagList[(int)echarMoveState];
				CharacterUnifiedStateComponent.MoveEnumToTagInverse[CharacterUnifiedStateComponent.MoveTagList[(int)echarMoveState]] = echarMoveState;
			}
			CharacterUnifiedStateComponent.DirectionEnumToTag = new Dictionary<ECharDirectionState, int>();
			CharacterUnifiedStateComponent.DirectionEnumToTagInverse = new Dictionary<int, ECharDirectionState>();
			Array enumValuesAsUnderlyingType3 = typeof(ECharDirectionState).GetEnumValuesAsUnderlyingType();
			foreach (ECharDirectionState echarDirectionState in *Unsafe.As<Array, ECharDirectionState[]>(ref enumValuesAsUnderlyingType3))
			{
				CharacterUnifiedStateComponent.DirectionEnumToTag[echarDirectionState] = CharacterUnifiedStateComponent.DirectionTagList[(int)echarDirectionState];
				CharacterUnifiedStateComponent.DirectionEnumToTagInverse[CharacterUnifiedStateComponent.DirectionTagList[(int)echarDirectionState]] = echarDirectionState;
			}
			CharacterUnifiedStateComponent.PositionSubStateEnumToTag = new Dictionary<global::ECharPositionSubState, int>();
			Array enumValuesAsUnderlyingType4 = typeof(global::ECharPositionSubState).GetEnumValuesAsUnderlyingType();
			foreach (global::ECharPositionSubState echarPositionSubState in *Unsafe.As<Array, global::ECharPositionSubState[]>(ref enumValuesAsUnderlyingType4))
			{
				CharacterUnifiedStateComponent.PositionSubStateEnumToTag[echarPositionSubState] = CharacterUnifiedStateComponent.PositionSubStateTagList[(int)echarPositionSubState];
			}
			CharacterUnifiedStateComponent.NeedLoad = false;
		}
	}

	// Token: 0x06018A73 RID: 100979 RVA: 0x006F3C4C File Offset: 0x006F1E4C
	public void PreprocessChangeRole(bool inGame)
	{
		foreach (int num in CharacterUnifiedStateComponent.outGameRoleTags)
		{
			if (inGame)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null)
				{
					tagComponent.RemoveTag(new int?(num));
				}
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null || !tagComponent2.HasTag(num))
				{
					BaseTagComponent tagComponent3 = this.TagComponent;
					if (tagComponent3 != null)
					{
						tagComponent3.AddTag(new int?(num));
					}
				}
			}
		}
	}

	// Token: 0x06018A74 RID: 100980 RVA: 0x006F3CBD File Offset: 0x006F1EBD
	public HashSet<int> GetAggroSet()
	{
		return this.AggroSet;
	}

	// Token: 0x06018A75 RID: 100981 RVA: 0x006F3CC5 File Offset: 0x006F1EC5
	public new static void CreateStaticDefaultValue()
	{
		CharacterUnifiedStateComponent.NeedLoad = true;
	}

	// Token: 0x06018A76 RID: 100982 RVA: 0x006F3CD0 File Offset: 0x006F1ED0
	public new static void ResetStaticDefaultValue()
	{
		CharacterUnifiedStateComponent.NeedLoad = false;
		CharacterUnifiedStateComponent.PositionTagList = null;
		CharacterUnifiedStateComponent.MoveTagList = null;
		CharacterUnifiedStateComponent.SubStateTagList = null;
		CharacterUnifiedStateComponent.DirectionTagList = null;
		CharacterUnifiedStateComponent.PositionSubStateTagList = null;
		CharacterUnifiedStateComponent.MoveEnumToTag = null;
		CharacterUnifiedStateComponent.MoveEnumToTagInverse = null;
		CharacterUnifiedStateComponent.PositionEnumToTag = null;
		CharacterUnifiedStateComponent.PositionEnumToTagInverse = null;
		CharacterUnifiedStateComponent.DirectionEnumToTag = null;
		CharacterUnifiedStateComponent.DirectionEnumToTagInverse = null;
		CharacterUnifiedStateComponent.PositionSubStateEnumToTag = null;
	}

	// Token: 0x06018A77 RID: 100983 RVA: 0x006F3D2C File Offset: 0x006F1F2C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterUnifiedStateComponent characterUnifiedStateComponent = (CharacterUnifiedStateComponent)componentTemplate;
		if (base.CanResetComponentProperty("AbilityComponent"))
		{
			if (characterUnifiedStateComponent.AbilityComponent == null)
			{
				this.AbilityComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAbilityComponent>(this.AbilityComponent), "AbilityComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CueComponent"))
		{
			if (characterUnifiedStateComponent.CueComponent == null)
			{
				this.CueComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterGameplayCueComponent>(this.CueComponent), "CueComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RoleGaitComponent"))
		{
			if (characterUnifiedStateComponent.RoleGaitComponent == null)
			{
				this.RoleGaitComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleGaitComponent>(this.RoleGaitComponent), "RoleGaitComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FloatingComponent"))
		{
			if (characterUnifiedStateComponent.FloatingComponent == null)
			{
				this.FloatingComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterFloatingComponent>(this.FloatingComponent), "FloatingComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComponent"))
		{
			if (characterUnifiedStateComponent.MoveComponent == null)
			{
				this.MoveComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComponent), "MoveComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LockWalkRunState"))
		{
			this.LockWalkRunState = characterUnifiedStateComponent.LockWalkRunState;
		}
		if (base.CanResetComponentProperty("<CachedPositionState>k__BackingField"))
		{
			this.CachedPositionState = characterUnifiedStateComponent.CachedPositionState;
		}
		if (base.CanResetComponentProperty("<CachedMoveState>k__BackingField"))
		{
			this.CachedMoveState = characterUnifiedStateComponent.CachedMoveState;
		}
		if (base.CanResetComponentProperty("<CachedDirectionState>k__BackingField"))
		{
			this.CachedDirectionState = characterUnifiedStateComponent.CachedDirectionState;
		}
		if (base.CanResetComponentProperty("CurrentAimType"))
		{
			this.CurrentAimType = characterUnifiedStateComponent.CurrentAimType;
		}
		if (base.CanResetComponentProperty("PositionSubStateInternal"))
		{
			this.PositionSubStateInternal = characterUnifiedStateComponent.PositionSubStateInternal;
		}
		if (base.CanResetComponentProperty("InFightCueHandle"))
		{
			this.InFightCueHandle = characterUnifiedStateComponent.InFightCueHandle;
		}
		if (base.CanResetComponentProperty("AggroSet") && characterUnifiedStateComponent.AggroSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.AggroSet), "AggroSet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsWalkModeInternal"))
		{
			this.IsWalkModeInternal = characterUnifiedStateComponent.IsWalkModeInternal;
		}
		return true;
	}

	// Token: 0x0400BEBA RID: 48826
	[StaticVariableRuleIgnore]
	public static readonly int[] outGameRoleTags = new int[]
	{
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不被取对象"],
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不被子弹命中"]
	};

	// Token: 0x0400BEBB RID: 48827
	[StaticVariableRuleIgnore]
	private static HashSet<global::ECharMoveState> notInheritMoveStateSet = new HashSet<global::ECharMoveState>
	{
		global::ECharMoveState.Flying,
		global::ECharMoveState.Roll,
		global::ECharMoveState.WalkOnAir,
		global::ECharMoveState.Glide
	};

	// Token: 0x0400BEBC RID: 48828
	[Nullable(2)]
	private CharacterAbilityComponent AbilityComponent;

	// Token: 0x0400BEBD RID: 48829
	[Nullable(2)]
	private CharacterGameplayCueComponent CueComponent;

	// Token: 0x0400BEBE RID: 48830
	[Nullable(2)]
	private RoleGaitComponent RoleGaitComponent;

	// Token: 0x0400BEBF RID: 48831
	[Nullable(2)]
	private CharacterFloatingComponent FloatingComponent;

	// Token: 0x0400BEC0 RID: 48832
	[Nullable(2)]
	private CharacterMoveComponent MoveComponent;

	// Token: 0x0400BEC1 RID: 48833
	private bool LockWalkRunState;

	// Token: 0x0400BEC5 RID: 48837
	protected EAimViewState CurrentAimType = EAimViewState.EAimViewState_MAX;

	// Token: 0x0400BEC6 RID: 48838
	protected global::ECharPositionSubState PositionSubStateInternal;

	// Token: 0x0400BEC7 RID: 48839
	protected int InFightCueHandle;

	// Token: 0x0400BEC8 RID: 48840
	private readonly HashSet<int> AggroSet = new HashSet<int>();

	// Token: 0x0400BEC9 RID: 48841
	[StaticVariableRuleIgnore]
	private static readonly Stat RefreshFightStateStat = Stat.Create("OnAggroChanged.RefreshFightState", "", "");

	// Token: 0x0400BECA RID: 48842
	[StaticVariableRuleIgnore]
	private static readonly Stat FightBuffStat = Stat.Create("OnAggroChanged.FightBuff", "", "");

	// Token: 0x0400BECB RID: 48843
	protected static int[] PositionTagList;

	// Token: 0x0400BECC RID: 48844
	protected static int[] MoveTagList;

	// Token: 0x0400BECD RID: 48845
	protected static int[] SubStateTagList;

	// Token: 0x0400BECE RID: 48846
	protected static int[] DirectionTagList;

	// Token: 0x0400BECF RID: 48847
	protected static int[] PositionSubStateTagList;

	// Token: 0x0400BED0 RID: 48848
	protected static Dictionary<global::ECharMoveState, int> MoveEnumToTag;

	// Token: 0x0400BED1 RID: 48849
	protected static Dictionary<int, global::ECharMoveState> MoveEnumToTagInverse;

	// Token: 0x0400BED2 RID: 48850
	protected static Dictionary<global::ECharPositionState, int> PositionEnumToTag;

	// Token: 0x0400BED3 RID: 48851
	protected static Dictionary<int, global::ECharPositionState> PositionEnumToTagInverse;

	// Token: 0x0400BED4 RID: 48852
	protected static Dictionary<ECharDirectionState, int> DirectionEnumToTag;

	// Token: 0x0400BED5 RID: 48853
	protected static Dictionary<int, ECharDirectionState> DirectionEnumToTagInverse;

	// Token: 0x0400BED6 RID: 48854
	protected static Dictionary<global::ECharPositionSubState, int> PositionSubStateEnumToTag;

	// Token: 0x0400BED7 RID: 48855
	private bool IsWalkModeInternal;

	// Token: 0x0400BED8 RID: 48856
	private static bool NeedLoad = false;
}
