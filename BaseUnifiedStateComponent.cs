using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003225 RID: 12837
[NullableContext(2)]
[Nullable(0)]
public class BaseUnifiedStateComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x0601AB40 RID: 109376 RVA: 0x007F31FD File Offset: 0x007F13FD
	static BaseUnifiedStateComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseUnifiedStateComponent.CreateStaticDefaultValue), new Action(BaseUnifiedStateComponent.ResetStaticDefaultValue));
	}

	// Token: 0x17002433 RID: 9267
	// (get) Token: 0x0601AB41 RID: 109377 RVA: 0x007F321C File Offset: 0x007F141C
	// (set) Token: 0x0601AB42 RID: 109378 RVA: 0x007F3224 File Offset: 0x007F1424
	protected virtual ECharPositionState CachedPositionState { get; set; }

	// Token: 0x17002434 RID: 9268
	// (get) Token: 0x0601AB43 RID: 109379 RVA: 0x007F322D File Offset: 0x007F142D
	// (set) Token: 0x0601AB44 RID: 109380 RVA: 0x007F3235 File Offset: 0x007F1435
	protected virtual ECharMoveState CachedMoveState { get; set; } = ECharMoveState.Stand;

	// Token: 0x17002435 RID: 9269
	// (get) Token: 0x0601AB45 RID: 109381 RVA: 0x007F323E File Offset: 0x007F143E
	// (set) Token: 0x0601AB46 RID: 109382 RVA: 0x007F3246 File Offset: 0x007F1446
	protected virtual ECharDirectionState CachedDirectionState { get; set; } = ECharDirectionState.FaceDirection;

	// Token: 0x0601AB47 RID: 109383 RVA: 0x007F3250 File Offset: 0x007F1450
	protected override bool OnStart()
	{
		this.ActorComponent = base.Entity.GetComponent<BaseActorComponent>();
		this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
		this.IsInGameInternal = new bool?(false);
		this.InitCharState();
		Singleton<EventSystem>.Instance.AddWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnMovementModeChanged));
		return true;
	}

	// Token: 0x0601AB48 RID: 109384 RVA: 0x007F32B4 File Offset: 0x007F14B4
	private void OnMovementModeChanged(int charId, EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
		switch (newMovementMode)
		{
		case EMovementMode.MOVE_None:
			this.SetPositionState(ECharPositionState.Ground);
			this.SetMoveState(ECharMoveState.Other);
			return;
		case EMovementMode.MOVE_Walking:
		case EMovementMode.MOVE_NavWalking:
			this.SetPositionState(ECharPositionState.Ground);
			return;
		case EMovementMode.MOVE_Falling:
			this.SetPositionState(ECharPositionState.Air);
			if (this.MoveState != ECharMoveState.KnockUp && this.MoveState != ECharMoveState.Captured)
			{
				this.SetMoveState(ECharMoveState.Other);
				return;
			}
			break;
		case EMovementMode.MOVE_Swimming:
			break;
		case EMovementMode.MOVE_Flying:
			this.SetPositionState(ECharPositionState.Air);
			if (this.MoveState != ECharMoveState.Captured)
			{
				this.SetMoveState(ECharMoveState.Flying);
				return;
			}
			break;
		case EMovementMode.MOVE_Custom:
			switch (newCustomMode)
			{
			case 0:
			case 13:
				this.SetPositionState(ECharPositionState.Climb);
				return;
			case 1:
				this.SetPositionState(ECharPositionState.Water);
				return;
			case 2:
				this.SetPositionState(ECharPositionState.Air);
				this.SetMoveState(ECharMoveState.Glide);
				return;
			case 5:
				this.SetPositionState(ECharPositionState.Ground);
				return;
			case 8:
				this.SetPositionState(ECharPositionState.Ski);
				return;
			case 11:
				this.SetPositionState(ECharPositionState.Ride);
				return;
			case 12:
				this.SetPositionState(ECharPositionState.RailSlide);
				return;
			}
			this.SetPositionState(ECharPositionState.Air);
			break;
		default:
			return;
		}
	}

	// Token: 0x0601AB49 RID: 109385 RVA: 0x007F33C9 File Offset: 0x007F15C9
	protected override void OnActivate()
	{
		this.SetIsInGame(base.Entity.Active);
	}

	// Token: 0x0601AB4A RID: 109386 RVA: 0x007F33DC File Offset: 0x007F15DC
	protected override bool OnInit()
	{
		BaseUnifiedStateComponent.Load();
		return true;
	}

	// Token: 0x0601AB4B RID: 109387 RVA: 0x007F33E4 File Offset: 0x007F15E4
	protected override void OnEnable()
	{
		this.SetIsInGame(true);
	}

	// Token: 0x0601AB4C RID: 109388 RVA: 0x007F33ED File Offset: 0x007F15ED
	[NullableContext(1)]
	protected override void OnDisable(string reason)
	{
		this.SetIsInGame(false);
	}

	// Token: 0x0601AB4D RID: 109389 RVA: 0x007F33F6 File Offset: 0x007F15F6
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnMovementModeChanged));
		return true;
	}

	// Token: 0x17002436 RID: 9270
	// (get) Token: 0x0601AB4E RID: 109390 RVA: 0x007F341B File Offset: 0x007F161B
	public bool? IsInGame
	{
		get
		{
			return this.IsInGameInternal;
		}
	}

	// Token: 0x0601AB4F RID: 109391 RVA: 0x007F3423 File Offset: 0x007F1623
	public void SetIsInGame(bool isInGame)
	{
		this.IsInGameInternal = new bool?(isInGame);
	}

	// Token: 0x0601AB50 RID: 109392 RVA: 0x007F3434 File Offset: 0x007F1634
	public unsafe static void Load()
	{
		if (BaseUnifiedStateComponent.BaseNeedLoad)
		{
			BaseUnifiedStateComponent.PositionTagIdList = new int[]
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
			BaseUnifiedStateComponent.MoveTagIdList = new int[]
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
			BaseUnifiedStateComponent.DirectionTagIdList = new int[]
			{
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.注视方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.瞄准方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.面朝方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.看向方向"],
				GameplayTagDefine.EGameplayTagId["行为状态.方向状态.相机方向"]
			};
			BaseUnifiedStateComponent.PositionEnumToTagId = new Dictionary<ECharPositionState, int>();
			BaseUnifiedStateComponent.PositionEnumToTagIdInverse = new Dictionary<int, ECharPositionState>();
			Array enumValuesAsUnderlyingType = typeof(ECharPositionState).GetEnumValuesAsUnderlyingType();
			foreach (ECharPositionState echarPositionState in *Unsafe.As<Array, ECharPositionState[]>(ref enumValuesAsUnderlyingType))
			{
				if (echarPositionState >= ECharPositionState.Ground && echarPositionState < (ECharPositionState)BaseUnifiedStateComponent.PositionTagIdList.Length)
				{
					BaseUnifiedStateComponent.PositionEnumToTagId[echarPositionState] = BaseUnifiedStateComponent.PositionTagIdList[(int)echarPositionState];
					BaseUnifiedStateComponent.PositionEnumToTagIdInverse[BaseUnifiedStateComponent.PositionTagIdList[(int)echarPositionState]] = echarPositionState;
				}
			}
			BaseUnifiedStateComponent.MoveEnumToTagId = new Dictionary<ECharMoveState, int>();
			BaseUnifiedStateComponent.MoveEnumToTagIdInverse = new Dictionary<int, ECharMoveState>();
			Array enumValuesAsUnderlyingType2 = typeof(ECharMoveState).GetEnumValuesAsUnderlyingType();
			foreach (ECharMoveState echarMoveState in *Unsafe.As<Array, ECharMoveState[]>(ref enumValuesAsUnderlyingType2))
			{
				if (echarMoveState >= ECharMoveState.Other && echarMoveState < (ECharMoveState)BaseUnifiedStateComponent.MoveTagIdList.Length)
				{
					BaseUnifiedStateComponent.MoveEnumToTagId[echarMoveState] = BaseUnifiedStateComponent.MoveTagIdList[(int)echarMoveState];
					BaseUnifiedStateComponent.MoveEnumToTagIdInverse[BaseUnifiedStateComponent.MoveTagIdList[(int)echarMoveState]] = echarMoveState;
				}
			}
			BaseUnifiedStateComponent.DirectionEnumToTagId = new Dictionary<ECharDirectionState, int>();
			BaseUnifiedStateComponent.DirectionEnumToTagIdInverse = new Dictionary<int, ECharDirectionState>();
			Array enumValuesAsUnderlyingType3 = typeof(ECharDirectionState).GetEnumValuesAsUnderlyingType();
			foreach (ECharDirectionState echarDirectionState in *Unsafe.As<Array, ECharDirectionState[]>(ref enumValuesAsUnderlyingType3))
			{
				BaseUnifiedStateComponent.DirectionEnumToTagId[echarDirectionState] = BaseUnifiedStateComponent.DirectionTagIdList[(int)echarDirectionState];
				BaseUnifiedStateComponent.DirectionEnumToTagIdInverse[BaseUnifiedStateComponent.DirectionTagIdList[(int)echarDirectionState]] = echarDirectionState;
			}
			BaseUnifiedStateComponent.BaseNeedLoad = false;
		}
	}

	// Token: 0x0601AB51 RID: 109393 RVA: 0x007F39A8 File Offset: 0x007F1BA8
	public virtual void InitCharState()
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.AddTag(new int?(BaseUnifiedStateComponent.PositionEnumToTagId[ECharPositionState.Ground]));
		}
		BaseTagComponent tagComponent2 = this.TagComponent;
		if (tagComponent2 != null)
		{
			tagComponent2.AddTag(new int?(BaseUnifiedStateComponent.MoveEnumToTagId[ECharMoveState.Stand]));
		}
		BaseTagComponent tagComponent3 = this.TagComponent;
		if (tagComponent3 == null)
		{
			return;
		}
		tagComponent3.AddTag(new int?(BaseUnifiedStateComponent.DirectionEnumToTagId[ECharDirectionState.FaceDirection]));
	}

	// Token: 0x0601AB52 RID: 109394 RVA: 0x007F3A17 File Offset: 0x007F1C17
	public virtual void ResetCharState()
	{
		this.SetMoveState(ECharMoveState.Stand);
		this.SetDirectionState(ECharDirectionState.FaceDirection);
	}

	// Token: 0x0601AB53 RID: 109395 RVA: 0x007F3A28 File Offset: 0x007F1C28
	public virtual void SetPositionState(ECharPositionState newPositionState)
	{
		ECharPositionState echarPositionState = this.PositionState;
		if (!this.ActorComponent.IsAutonomousProxy)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态"]));
			}
			int value;
			if (BaseUnifiedStateComponent.PositionEnumToTagId.TryGetValue(newPositionState, out value))
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 != null)
				{
					tagComponent2.AddTag(new int?(value));
				}
			}
			echarPositionState = this.CachedPositionState;
			this.CachedPositionState = newPositionState;
			this.OnPositionStateChange(echarPositionState, newPositionState);
			return;
		}
		if (echarPositionState == newPositionState)
		{
			return;
		}
		BaseTagComponent tagComponent3 = this.TagComponent;
		if (tagComponent3 != null)
		{
			tagComponent3.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态"]));
		}
		int value2;
		if (BaseUnifiedStateComponent.PositionEnumToTagId.TryGetValue(newPositionState, out value2))
		{
			BaseTagComponent tagComponent4 = this.TagComponent;
			if (tagComponent4 != null)
			{
				tagComponent4.AddTag(new int?(value2));
			}
		}
		this.CachedPositionState = newPositionState;
		this.OnPositionStateChange(echarPositionState, newPositionState);
	}

	// Token: 0x17002437 RID: 9271
	// (get) Token: 0x0601AB54 RID: 109396 RVA: 0x007F3B0C File Offset: 0x007F1D0C
	public virtual ECharPositionState PositionState
	{
		get
		{
			if (!this.ActorComponent.IsAutonomousProxy)
			{
				foreach (int num in BaseUnifiedStateComponent.PositionTagIdList)
				{
					BaseTagComponent tagComponent = this.TagComponent;
					if (tagComponent != null && tagComponent.HasTag(num))
					{
						return BaseUnifiedStateComponent.PositionEnumToTagIdInverse[num];
					}
				}
			}
			return this.CachedPositionState;
		}
	}

	// Token: 0x0601AB55 RID: 109397 RVA: 0x007F3B65 File Offset: 0x007F1D65
	protected virtual void OnPositionStateChange(ECharPositionState oldState, ECharPositionState newState)
	{
		if (newState == ECharPositionState.Ground)
		{
			this.OnLand();
		}
		else if (this.DirectionState == ECharDirectionState.AimDirection)
		{
			this.SetDirectionState(ECharDirectionState.FaceDirection);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, oldState, newState);
	}

	// Token: 0x0601AB56 RID: 109398 RVA: 0x007F3B9A File Offset: 0x007F1D9A
	protected virtual void OnLand()
	{
		this.SetMoveState(ECharMoveState.Other);
	}

	// Token: 0x0601AB57 RID: 109399 RVA: 0x007F3BA4 File Offset: 0x007F1DA4
	public virtual void SetMoveState(ECharMoveState newMoveState)
	{
		if (!this.ActorComponent.IsAutonomousProxy)
		{
			return;
		}
		ECharMoveState moveState = this.MoveState;
		if (moveState == newMoveState)
		{
			return;
		}
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态"]));
		}
		int value;
		if (BaseUnifiedStateComponent.MoveEnumToTagId.TryGetValue(newMoveState, out value))
		{
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null)
			{
				tagComponent2.AddTag(new int?(value));
			}
		}
		this.CachedMoveState = newMoveState;
		Singleton<EventSystem>.Instance.EmitWithTarget<ECharMoveState, ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, moveState, newMoveState);
	}

	// Token: 0x17002438 RID: 9272
	// (get) Token: 0x0601AB58 RID: 109400 RVA: 0x007F3C38 File Offset: 0x007F1E38
	public virtual ECharMoveState MoveState
	{
		get
		{
			if (!this.ActorComponent.IsAutonomousProxy)
			{
				foreach (int num in BaseUnifiedStateComponent.MoveTagIdList)
				{
					BaseTagComponent tagComponent = this.TagComponent;
					if (tagComponent != null && tagComponent.HasTag(num))
					{
						return BaseUnifiedStateComponent.MoveEnumToTagIdInverse[num];
					}
				}
			}
			return this.CachedMoveState;
		}
	}

	// Token: 0x0601AB59 RID: 109401 RVA: 0x007F3C94 File Offset: 0x007F1E94
	public virtual void SetDirectionState(ECharDirectionState newDirectionState)
	{
		if (!this.ActorComponent.IsAutonomousProxy)
		{
			return;
		}
		ECharDirectionState directionState = this.DirectionState;
		if (!this.SetDirectionStateInternal(newDirectionState))
		{
			return;
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<ECharDirectionState, ECharDirectionState>(base.Entity, EEventName.CharOnDirectionStateChanged, directionState, newDirectionState);
	}

	// Token: 0x0601AB5A RID: 109402 RVA: 0x007F3CD8 File Offset: 0x007F1ED8
	protected bool SetDirectionStateInternal(ECharDirectionState newDirectionState)
	{
		ECharDirectionState directionState = this.DirectionState;
		if (directionState == newDirectionState)
		{
			return false;
		}
		this.UpdateDirectionTag(directionState, newDirectionState);
		return true;
	}

	// Token: 0x17002439 RID: 9273
	// (get) Token: 0x0601AB5B RID: 109403 RVA: 0x007F3CFC File Offset: 0x007F1EFC
	public virtual ECharDirectionState DirectionState
	{
		get
		{
			if (!this.ActorComponent.IsAutonomousProxy)
			{
				foreach (int num in BaseUnifiedStateComponent.DirectionTagIdList)
				{
					BaseTagComponent tagComponent = this.TagComponent;
					if (tagComponent != null && tagComponent.HasTag(num))
					{
						return BaseUnifiedStateComponent.DirectionEnumToTagIdInverse[num];
					}
				}
			}
			return this.CachedDirectionState;
		}
	}

	// Token: 0x0601AB5C RID: 109404 RVA: 0x007F3D55 File Offset: 0x007F1F55
	protected virtual void UpdateDirectionTag(ECharDirectionState oldDirectionState, ECharDirectionState newDirectionState)
	{
		this.CachedDirectionState = newDirectionState;
		this.ClearDirectionTag(oldDirectionState);
		this.AddDirectionTag(newDirectionState);
	}

	// Token: 0x0601AB5D RID: 109405 RVA: 0x007F3D6C File Offset: 0x007F1F6C
	protected virtual void ClearDirectionTag(ECharDirectionState oldDirectionState)
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.方向状态"]));
	}

	// Token: 0x0601AB5E RID: 109406 RVA: 0x007F3D93 File Offset: 0x007F1F93
	protected virtual void AddDirectionTag(ECharDirectionState charDirectionState)
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		tagComponent.AddTag(new int?(BaseUnifiedStateComponent.DirectionEnumToTagId[charDirectionState]));
	}

	// Token: 0x0601AB5F RID: 109407 RVA: 0x007F3DB5 File Offset: 0x007F1FB5
	public static void CreateStaticDefaultValue()
	{
		BaseUnifiedStateComponent.BaseNeedLoad = true;
	}

	// Token: 0x0601AB60 RID: 109408 RVA: 0x007F3DC0 File Offset: 0x007F1FC0
	public static void ResetStaticDefaultValue()
	{
		BaseUnifiedStateComponent.BaseNeedLoad = false;
		BaseUnifiedStateComponent.PositionTagIdList = null;
		BaseUnifiedStateComponent.MoveTagIdList = null;
		BaseUnifiedStateComponent.SubStateTagIdList = null;
		BaseUnifiedStateComponent.DirectionTagIdList = null;
		BaseUnifiedStateComponent.MoveEnumToTagId = null;
		BaseUnifiedStateComponent.MoveEnumToTagIdInverse = null;
		BaseUnifiedStateComponent.PositionEnumToTagId = null;
		BaseUnifiedStateComponent.PositionEnumToTagIdInverse = null;
		BaseUnifiedStateComponent.DirectionEnumToTagId = null;
		BaseUnifiedStateComponent.DirectionEnumToTagIdInverse = null;
	}

	// Token: 0x0601AB61 RID: 109409 RVA: 0x007F3E10 File Offset: 0x007F2010
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseUnifiedStateComponent baseUnifiedStateComponent = (BaseUnifiedStateComponent)componentTemplate;
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (baseUnifiedStateComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (baseUnifiedStateComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("<CachedPositionState>k__BackingField"))
		{
			this.CachedPositionState = baseUnifiedStateComponent.CachedPositionState;
		}
		if (base.CanResetComponentProperty("<CachedMoveState>k__BackingField"))
		{
			this.CachedMoveState = baseUnifiedStateComponent.CachedMoveState;
		}
		if (base.CanResetComponentProperty("<CachedDirectionState>k__BackingField"))
		{
			this.CachedDirectionState = baseUnifiedStateComponent.CachedDirectionState;
		}
		if (base.CanResetComponentProperty("IsInFighting"))
		{
			this.IsInFighting = baseUnifiedStateComponent.IsInFighting;
		}
		if (base.CanResetComponentProperty("IsInGameInternal"))
		{
			this.IsInGameInternal = baseUnifiedStateComponent.IsInGameInternal;
		}
		return true;
	}

	// Token: 0x0400D873 RID: 55411
	protected static int[] PositionTagIdList;

	// Token: 0x0400D874 RID: 55412
	protected static int[] MoveTagIdList;

	// Token: 0x0400D875 RID: 55413
	protected static int[] SubStateTagIdList;

	// Token: 0x0400D876 RID: 55414
	protected static int[] DirectionTagIdList;

	// Token: 0x0400D877 RID: 55415
	protected static Dictionary<ECharMoveState, int> MoveEnumToTagId;

	// Token: 0x0400D878 RID: 55416
	protected static Dictionary<int, ECharMoveState> MoveEnumToTagIdInverse;

	// Token: 0x0400D879 RID: 55417
	protected static Dictionary<ECharPositionState, int> PositionEnumToTagId;

	// Token: 0x0400D87A RID: 55418
	protected static Dictionary<int, ECharPositionState> PositionEnumToTagIdInverse;

	// Token: 0x0400D87B RID: 55419
	protected static Dictionary<ECharDirectionState, int> DirectionEnumToTagId;

	// Token: 0x0400D87C RID: 55420
	protected static Dictionary<int, ECharDirectionState> DirectionEnumToTagIdInverse;

	// Token: 0x0400D87D RID: 55421
	protected BaseTagComponent TagComponent;

	// Token: 0x0400D87E RID: 55422
	protected BaseActorComponent ActorComponent;

	// Token: 0x0400D882 RID: 55426
	public bool IsInFighting;

	// Token: 0x0400D883 RID: 55427
	protected bool? IsInGameInternal;

	// Token: 0x0400D884 RID: 55428
	protected static bool BaseNeedLoad;
}
