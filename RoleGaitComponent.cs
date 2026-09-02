using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;

// Token: 0x020031F2 RID: 12786
[NullableContext(2)]
[Nullable(0)]
public class RoleGaitComponent : EntityComponent, IComponentDependency
{
	// Token: 0x170023EE RID: 9198
	// (get) Token: 0x0601A86C RID: 108652 RVA: 0x007D84DA File Offset: 0x007D66DA
	[Nullable(1)]
	public static Type[] Dependencies
	{
		[NullableContext(1)]
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterMoveComponent)
			};
		}
	}

	// Token: 0x0601A86D RID: 108653 RVA: 0x007D84FC File Offset: 0x007D66FC
	private void OnForceWalkTagChanged(bool tagExist)
	{
		if (tagExist)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]));
			}
			CharacterBuffComponent buffComp = this.BuffComp;
			if (buffComp != null)
			{
				buffComp.RemoveBuffByTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]), null, null);
			}
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Run].Add(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"]);
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Sprint].Add(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"]);
		}
		else
		{
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Run].Remove(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"]);
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Sprint].Remove(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"]);
		}
		this.RefreshMoveState();
	}

	// Token: 0x0601A86E RID: 108654 RVA: 0x007D85F0 File Offset: 0x007D67F0
	private void OnForceRunTagChanged(bool tagExist)
	{
		if (tagExist)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]));
			}
			CharacterBuffComponent buffComp = this.BuffComp;
			if (buffComp != null)
			{
				buffComp.RemoveBuffByTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]), null, null);
			}
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Walk].Add(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"]);
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Sprint].Add(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"]);
		}
		else
		{
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Walk].Remove(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"]);
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Sprint].Remove(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"]);
		}
		this.RefreshMoveState();
	}

	// Token: 0x0601A86F RID: 108655 RVA: 0x007D86E4 File Offset: 0x007D68E4
	private void OnForceNotWalkTagChanged(bool tagExist)
	{
		if (tagExist)
		{
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Walk].Add(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止行走"]);
		}
		else
		{
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Walk].Remove(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止行走"]);
		}
		this.RefreshMoveState();
	}

	// Token: 0x0601A870 RID: 108656 RVA: 0x007D8740 File Offset: 0x007D6940
	private void OnForbidSprintTagTagChanged(bool tagExist)
	{
		if (tagExist)
		{
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Sprint].Add(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"]);
		}
		else
		{
			this.RoleGaitUnEnableState[ERoleGaitEnableType.Sprint].Remove(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"]);
		}
		this.RefreshMoveState();
	}

	// Token: 0x0601A871 RID: 108657 RVA: 0x007D879A File Offset: 0x007D699A
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.RoleForbidMovementHelper = new RoleForbidMovementHelper();
		return true;
	}

	// Token: 0x0601A872 RID: 108658 RVA: 0x007D87A8 File Offset: 0x007D69A8
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.MoveComp = base.Entity.CheckGetComponent<CharacterMoveComponent>();
		this.UnifiedStateComponent = base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.InputComp = base.Entity.CheckGetComponent<CharacterInputComponent>();
		this.BuffComp = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		RoleGaitStatic.Init();
		this.InitRoleForbidMovementHelper();
		return true;
	}

	// Token: 0x0601A873 RID: 108659 RVA: 0x007D8828 File Offset: 0x007D6A28
	public unsafe void InitRoleForbidMovementHelper()
	{
		this.RoleGaitUnEnableState[ERoleGaitEnableType.Run] = new HashSet<int>();
		this.RoleGaitUnEnableState[ERoleGaitEnableType.Walk] = new HashSet<int>();
		this.RoleGaitUnEnableState[ERoleGaitEnableType.Sprint] = new HashSet<int>();
		this.RoleForbidMovementHelper.TagComp = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.RoleForbidMovementHelper.CreateTagHandler(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"], 1, new Action<bool>(this.OnForceWalkTagChanged));
		this.RoleForbidMovementHelper.CreateTagHandler(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"], 1, new Action<bool>(this.OnForceRunTagChanged));
		this.RoleForbidMovementHelper.CreateTagHandler(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止行走"], 0, new Action<bool>(this.OnForceNotWalkTagChanged));
		RoleForbidMovementHelper roleForbidMovementHelper = this.RoleForbidMovementHelper;
		int num = 2;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num2 = 0;
		*span[num2] = GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"];
		num2++;
		*span[num2] = GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止行走"];
		roleForbidMovementHelper.RegisterMutuallyTags(list);
		this.RoleForbidMovementHelper.CreateTagHandler(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"], 0, new Action<bool>(this.OnForbidSprintTagTagChanged));
		this.RoleForbidMovementHelper.Awake();
	}

	// Token: 0x0601A874 RID: 108660 RVA: 0x007D897C File Offset: 0x007D6B7C
	protected override bool OnClear()
	{
		RoleForbidMovementHelper roleForbidMovementHelper = this.RoleForbidMovementHelper;
		if (roleForbidMovementHelper != null)
		{
			roleForbidMovementHelper.Clear();
		}
		return true;
	}

	// Token: 0x0601A875 RID: 108661 RVA: 0x007D8990 File Offset: 0x007D6B90
	protected override void OnTick(float delta)
	{
		this.RefreshMoveState();
	}

	// Token: 0x0601A876 RID: 108662 RVA: 0x007D8998 File Offset: 0x007D6B98
	private void RefreshMoveState()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsAutonomousProxy)
		{
			return;
		}
		this.UpdateMoveStateByControllerType();
		ECharMoveState moveState = this.UnifiedStateComponent.MoveState;
		ECharPositionState positionState = this.UnifiedStateComponent.PositionState;
		BaseTagComponent tagComponent = this.TagComponent;
		bool hasSprintRetain = tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]);
		ECharDirectionState directionState = this.UnifiedStateComponent.DirectionState;
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp != null && moveComp.HasMoveInput)
		{
			this.UpdateMovePressing(hasSprintRetain, positionState, moveState, directionState);
			return;
		}
		this.UpdateMoveReleasing(hasSprintRetain, positionState, moveState, directionState);
	}

	// Token: 0x0601A877 RID: 108663 RVA: 0x007D8A32 File Offset: 0x007D6C32
	public bool EnableRoleGaitState(ERoleGaitEnableType type)
	{
		HashSet<int> valueOrDefault = this.RoleGaitUnEnableState.GetValueOrDefault(type);
		return valueOrDefault != null && valueOrDefault.Count == 0;
	}

	// Token: 0x0601A878 RID: 108664 RVA: 0x007D8A50 File Offset: 0x007D6C50
	public ERoleGaitEnableType? FindEnableGaitState()
	{
		foreach (KeyValuePair<ERoleGaitEnableType, HashSet<int>> keyValuePair in this.RoleGaitUnEnableState)
		{
			if (keyValuePair.Value.Count == 0)
			{
				return new ERoleGaitEnableType?(keyValuePair.Key);
			}
		}
		return null;
	}

	// Token: 0x0601A879 RID: 108665 RVA: 0x007D8AC4 File Offset: 0x007D6CC4
	public ECharMoveState? FindEnableCharMoveState()
	{
		ERoleGaitEnableType? eroleGaitEnableType = this.FindEnableGaitState();
		if (eroleGaitEnableType != null && eroleGaitEnableType != null)
		{
			switch (eroleGaitEnableType.GetValueOrDefault())
			{
			case ERoleGaitEnableType.Walk:
				return new ECharMoveState?(ECharMoveState.Walk);
			case ERoleGaitEnableType.Run:
				return new ECharMoveState?(ECharMoveState.Run);
			case ERoleGaitEnableType.Sprint:
				return new ECharMoveState?(ECharMoveState.Run);
			}
		}
		return null;
	}

	// Token: 0x0601A87A RID: 108666 RVA: 0x007D8B28 File Offset: 0x007D6D28
	protected void UpdateMovePressing(bool hasSprintRetain, ECharPositionState positionState, ECharMoveState moveState, ECharDirectionState cameraState)
	{
		switch (positionState)
		{
		case ECharPositionState.Ground:
		{
			if (hasSprintRetain && this.EnableRoleGaitState(ERoleGaitEnableType.Sprint))
			{
				float value = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength);
				if (moveState != ECharMoveState.Sprint)
				{
					if (value >= 0.01f)
					{
						CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
						if (unifiedStateComponent == null)
						{
							return;
						}
						unifiedStateComponent.SetMoveState(ECharMoveState.Sprint);
						return;
					}
				}
				else if (value > 0f)
				{
					break;
				}
			}
			CharacterUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
			if (unifiedStateComponent2 != null && unifiedStateComponent2.IsWalkBaseMode)
			{
				if (this.EnableRoleGaitState(ERoleGaitEnableType.Walk))
				{
					CharacterUnifiedStateComponent unifiedStateComponent3 = this.UnifiedStateComponent;
					if (unifiedStateComponent3 == null)
					{
						return;
					}
					unifiedStateComponent3.SetMoveState(ECharMoveState.Walk);
					return;
				}
				else if (this.EnableRoleGaitState(ERoleGaitEnableType.Run))
				{
					CharacterUnifiedStateComponent unifiedStateComponent4 = this.UnifiedStateComponent;
					if (unifiedStateComponent4 == null)
					{
						return;
					}
					unifiedStateComponent4.SetMoveState(ECharMoveState.Run);
					return;
				}
				else
				{
					CharacterUnifiedStateComponent unifiedStateComponent5 = this.UnifiedStateComponent;
					if (unifiedStateComponent5 == null)
					{
						return;
					}
					unifiedStateComponent5.SetMoveState(ECharMoveState.Walk);
					return;
				}
			}
			else if (this.EnableRoleGaitState(ERoleGaitEnableType.Run))
			{
				CharacterUnifiedStateComponent unifiedStateComponent6 = this.UnifiedStateComponent;
				if (unifiedStateComponent6 == null)
				{
					return;
				}
				unifiedStateComponent6.SetMoveState(ECharMoveState.Run);
				return;
			}
			else if (this.EnableRoleGaitState(ERoleGaitEnableType.Walk))
			{
				CharacterUnifiedStateComponent unifiedStateComponent7 = this.UnifiedStateComponent;
				if (unifiedStateComponent7 == null)
				{
					return;
				}
				unifiedStateComponent7.SetMoveState(ECharMoveState.Walk);
				return;
			}
			else
			{
				CharacterUnifiedStateComponent unifiedStateComponent8 = this.UnifiedStateComponent;
				if (unifiedStateComponent8 == null)
				{
					return;
				}
				unifiedStateComponent8.SetMoveState(ECharMoveState.Run);
				return;
			}
			break;
		}
		case ECharPositionState.Climb:
			if (moveState != ECharMoveState.EnterClimb && moveState != ECharMoveState.ExitClimb && moveState != ECharMoveState.FastClimb && moveState != ECharMoveState.NormalClimb)
			{
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制快速攀爬"]))
				{
					this.UnifiedStateComponent.SetMoveState(ECharMoveState.FastClimb);
					return;
				}
				this.UnifiedStateComponent.SetMoveState(ECharMoveState.NormalClimb);
			}
			break;
		case ECharPositionState.Air:
			break;
		case ECharPositionState.Water:
			if (moveState != ECharMoveState.FastSwim && moveState != ECharMoveState.NormalSwim)
			{
				CharacterUnifiedStateComponent unifiedStateComponent9 = this.UnifiedStateComponent;
				if (unifiedStateComponent9 == null)
				{
					return;
				}
				unifiedStateComponent9.SetMoveState(ECharMoveState.NormalSwim);
				return;
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x0601A87B RID: 108667 RVA: 0x007D8C9C File Offset: 0x007D6E9C
	protected void UpdateMoveReleasing(bool hasSprintRetain, ECharPositionState positionState, ECharMoveState moveState, ECharDirectionState cameraState)
	{
		if (hasSprintRetain)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]));
			}
			CharacterBuffComponent buffComp = this.BuffComp;
			if (buffComp != null)
			{
				buffComp.RemoveBuffByTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]), null, null);
			}
		}
		switch (positionState)
		{
		case ECharPositionState.Ground:
			if (cameraState != ECharDirectionState.AimDirection)
			{
				if (moveState <= ECharMoveState.KnockUp)
				{
					switch (moveState)
					{
					case ECharMoveState.Walk:
					case ECharMoveState.Run:
					case ECharMoveState.Sprint:
					{
						if (!this.DisableStopAnim)
						{
							this.SetRunStop();
							return;
						}
						CharacterMoveComponent moveComp = this.MoveComp;
						if (moveComp == null || moveComp.Speed >= 5f)
						{
							return;
						}
						CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
						if (unifiedStateComponent == null)
						{
							return;
						}
						unifiedStateComponent.SetMoveState(ECharMoveState.Stand);
						return;
					}
					case ECharMoveState.WalkStop:
					case ECharMoveState.RunStop:
					case ECharMoveState.SprintStop:
					case ECharMoveState.Dodge:
					case ECharMoveState.LandRoll:
						break;
					case ECharMoveState.KnockDown:
					case ECharMoveState.Parry:
					case ECharMoveState.SoftKnock:
					case ECharMoveState.HeavyKnock:
						return;
					default:
						if (moveState == ECharMoveState.KnockUp)
						{
							return;
						}
						break;
					}
				}
				else if (moveState == ECharMoveState.Captured || moveState == ECharMoveState.BreakWeakness)
				{
					break;
				}
				CharacterMoveComponent moveComp2 = this.MoveComp;
				if (moveComp2 != null && moveComp2.Speed < 5f)
				{
					CharacterUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
					if (unifiedStateComponent2 == null)
					{
						return;
					}
					unifiedStateComponent2.SetMoveState(ECharMoveState.Stand);
					return;
				}
			}
			break;
		case ECharPositionState.Climb:
		{
			CharacterUnifiedStateComponent unifiedStateComponent3 = this.UnifiedStateComponent;
			if (unifiedStateComponent3 == null || unifiedStateComponent3.MoveState != ECharMoveState.EnterClimb)
			{
				CharacterUnifiedStateComponent unifiedStateComponent4 = this.UnifiedStateComponent;
				if (unifiedStateComponent4 == null || unifiedStateComponent4.MoveState != ECharMoveState.ExitClimb)
				{
					CharacterUnifiedStateComponent unifiedStateComponent5 = this.UnifiedStateComponent;
					if (unifiedStateComponent5 == null)
					{
						return;
					}
					unifiedStateComponent5.SetMoveState(ECharMoveState.Other);
				}
			}
			break;
		}
		case ECharPositionState.Air:
			break;
		case ECharPositionState.Water:
		{
			CharacterUnifiedStateComponent unifiedStateComponent6 = this.UnifiedStateComponent;
			if (unifiedStateComponent6 == null)
			{
				return;
			}
			unifiedStateComponent6.SetMoveState(ECharMoveState.Other);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0601A87C RID: 108668 RVA: 0x007D8E40 File Offset: 0x007D7040
	protected void SetRunStop()
	{
		CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		ECharMoveState? echarMoveState = (unifiedStateComponent != null) ? new ECharMoveState?(unifiedStateComponent.MoveState) : null;
		if (echarMoveState != null)
		{
			switch (echarMoveState.GetValueOrDefault())
			{
			case ECharMoveState.Walk:
			{
				CharacterUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
				if (unifiedStateComponent2 == null)
				{
					return;
				}
				unifiedStateComponent2.SetMoveState(ECharMoveState.WalkStop);
				return;
			}
			case ECharMoveState.WalkStop:
			case ECharMoveState.RunStop:
			case ECharMoveState.SprintStop:
				break;
			case ECharMoveState.Run:
			case ECharMoveState.Sprint:
			case ECharMoveState.Dodge:
			case ECharMoveState.LandRoll:
				if (!this.CanSprintStop())
				{
					CharacterUnifiedStateComponent unifiedStateComponent3 = this.UnifiedStateComponent;
					if (unifiedStateComponent3 == null)
					{
						return;
					}
					unifiedStateComponent3.SetMoveState(ECharMoveState.RunStop);
					return;
				}
				else
				{
					CharacterUnifiedStateComponent unifiedStateComponent4 = this.UnifiedStateComponent;
					if (unifiedStateComponent4 == null)
					{
						return;
					}
					unifiedStateComponent4.SetMoveState(ECharMoveState.SprintStop);
				}
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x0601A87D RID: 108669 RVA: 0x007D8EE4 File Offset: 0x007D70E4
	private void UpdateMoveStateByControllerType()
	{
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp != null && moveComp.IsMovingToLocation())
		{
			return;
		}
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			if (!this.LastInKeyBoard && this.UnifiedStateComponent.MarkWalkOrRun(false, false, null))
			{
				this.UnifiedStateComponent.WalkPress();
			}
			this.LastInKeyBoard = true;
			return;
		}
		this.LastInKeyBoard = false;
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.UpdateMoveStateByGamepad();
			return;
		}
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.UpdateMoveStateByTouch();
		}
	}

	// Token: 0x0601A87E RID: 108670 RVA: 0x007D8F74 File Offset: 0x007D7174
	private void UpdateMoveStateByGamepad()
	{
		CharacterInputComponent inputComp = this.InputComp;
		Vector vector = (inputComp != null) ? inputComp.GetMoveVectorCache() : null;
		double num = (vector != null) ? vector.SizeSquared() : 0.0;
		if (Singleton<MathUtils>.Instance.IsNearlyZero(num, null) || num > Singleton<MathUtils>.Instance.Square((double)RoleGaitStatic.GetWalkOrRunRate()))
		{
			if (this.UnifiedStateComponent.MarkWalkOrRun(false, false, null))
			{
				this.UnifiedStateComponent.WalkPress();
				return;
			}
		}
		else if (this.UnifiedStateComponent.MarkWalkOrRun(true, false, null))
		{
			this.UnifiedStateComponent.WalkPress();
		}
	}

	// Token: 0x0601A87F RID: 108671 RVA: 0x007D9018 File Offset: 0x007D7218
	private void UpdateMoveStateByTouch()
	{
		CharacterInputComponent inputComp = this.InputComp;
		Vector vector = (inputComp != null) ? inputComp.GetMoveVectorCache() : null;
		if (((vector != null) ? vector.SizeSquared() : 0.0) > Singleton<MathUtils>.Instance.Square((double)RoleGaitStatic.GetWalkOrRunRate()))
		{
			CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null && unifiedStateComponent.MoveState == ECharMoveState.Walk)
			{
				CharacterUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
				if (unifiedStateComponent2 == null)
				{
					return;
				}
				unifiedStateComponent2.WalkPress();
				return;
			}
		}
		else
		{
			CharacterUnifiedStateComponent unifiedStateComponent3 = this.UnifiedStateComponent;
			if (unifiedStateComponent3 != null && unifiedStateComponent3.MoveState == ECharMoveState.Run)
			{
				CharacterUnifiedStateComponent unifiedStateComponent4 = this.UnifiedStateComponent;
				if (unifiedStateComponent4 == null)
				{
					return;
				}
				unifiedStateComponent4.WalkPress();
			}
		}
	}

	// Token: 0x0601A880 RID: 108672 RVA: 0x007D90AC File Offset: 0x007D72AC
	public void EnableSprintStop(bool enable)
	{
		if (this.IsDisableSprintStop != enable)
		{
			return;
		}
		this.IsDisableSprintStop = !enable;
	}

	// Token: 0x0601A881 RID: 108673 RVA: 0x007D90C4 File Offset: 0x007D72C4
	private bool CanSprintStop()
	{
		if (this.IsDisableSprintStop)
		{
			return false;
		}
		float sprintSpeed = this.MoveComp.MovementData.FaceDirection.Standing.SprintSpeed;
		float num = 150f;
		return this.MoveComp.Speed + num >= sprintSpeed;
	}

	// Token: 0x0601A882 RID: 108674 RVA: 0x007D910F File Offset: 0x007D730F
	public void SetDisableStopAnim(bool enable)
	{
		this.DisableStopAnim = enable;
	}

	// Token: 0x0601A883 RID: 108675 RVA: 0x007D9118 File Offset: 0x007D7318
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleGaitComponent roleGaitComponent = (RoleGaitComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (roleGaitComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputComp"))
		{
			if (roleGaitComponent.InputComp == null)
			{
				this.InputComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComp), "InputComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (roleGaitComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComp"))
		{
			if (roleGaitComponent.BuffComp == null)
			{
				this.BuffComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComp), "BuffComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComponent"))
		{
			if (roleGaitComponent.UnifiedStateComponent == null)
			{
				this.UnifiedStateComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (roleGaitComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RoleForbidMovementHelper"))
		{
			if (roleGaitComponent.RoleForbidMovementHelper == null)
			{
				this.RoleForbidMovementHelper = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleForbidMovementHelper>(this.RoleForbidMovementHelper), "RoleForbidMovementHelper"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RoleGaitUnEnableState"))
		{
			if (roleGaitComponent.RoleGaitUnEnableState == null)
			{
				this.RoleGaitUnEnableState = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<ERoleGaitEnableType, HashSet<int>>>(this.RoleGaitUnEnableState), "RoleGaitUnEnableState"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DisableStopAnim"))
		{
			this.DisableStopAnim = roleGaitComponent.DisableStopAnim;
		}
		if (base.CanResetComponentProperty("LastInKeyBoard"))
		{
			this.LastInKeyBoard = roleGaitComponent.LastInKeyBoard;
		}
		if (base.CanResetComponentProperty("IsDisableSprintStop"))
		{
			this.IsDisableSprintStop = roleGaitComponent.IsDisableSprintStop;
		}
		return true;
	}

	// Token: 0x0400D66D RID: 54893
	private const float STOP_SPEED = 5f;

	// Token: 0x0400D66E RID: 54894
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D66F RID: 54895
	private CharacterInputComponent InputComp;

	// Token: 0x0400D670 RID: 54896
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400D671 RID: 54897
	private CharacterBuffComponent BuffComp;

	// Token: 0x0400D672 RID: 54898
	private CharacterUnifiedStateComponent UnifiedStateComponent;

	// Token: 0x0400D673 RID: 54899
	private BaseTagComponent TagComponent;

	// Token: 0x0400D674 RID: 54900
	public RoleForbidMovementHelper RoleForbidMovementHelper;

	// Token: 0x0400D675 RID: 54901
	[Nullable(1)]
	public Dictionary<ERoleGaitEnableType, HashSet<int>> RoleGaitUnEnableState = new Dictionary<ERoleGaitEnableType, HashSet<int>>();

	// Token: 0x0400D676 RID: 54902
	private bool DisableStopAnim;

	// Token: 0x0400D677 RID: 54903
	private bool LastInKeyBoard = true;

	// Token: 0x0400D678 RID: 54904
	private bool IsDisableSprintStop;
}
