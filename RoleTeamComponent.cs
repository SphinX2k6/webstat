using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Role.Common;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.NewWorld.Character.Role.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02003204 RID: 12804
[NullableContext(2)]
[Nullable(0)]
public class RoleTeamComponent : EntityComponent
{
	// Token: 0x0601A8F3 RID: 108787 RVA: 0x007DDF08 File Offset: 0x007DC108
	protected override bool OnInit()
	{
		this.BuffComponent = base.Entity.GetComponent<CharacterBuffComponent>();
		this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.FloatingComp = base.Entity.GetComponent<CharacterFloatingComponent>();
		this.InheritComp = base.Entity.GetComponent<RoleInheritComponent>();
		this.SkillComp = base.Entity.GetComponent<CharacterSkillComponent>();
		this.QteComp = base.Entity.GetComponent<RoleQteComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.InputComp = base.Entity.GetComponent<CharacterInputComponent>();
		this.LockOnComp = base.Entity.GetComponent<CharacterLockOnComponent>();
		this.ManipulateComp = base.Entity.GetComponent<CharacterManipulateComponent>();
		this.ManipulateInteractComp = base.Entity.GetComponent<CharacterManipulateInteractComponent>();
		this.CharacterExploreComp = base.Entity.GetComponent<CharacterExploreComponent>();
		this.RoleSceneInteractComp = base.Entity.GetComponent<RoleSceneInteractComponent>();
		this.DriveVehicleComp = base.Entity.GetComponent<CharacterDriveVehicleComponent>();
		this.MovementSyncComp = base.Entity.GetComponent<CharacterMovementSyncComponent>();
		return true;
	}

	// Token: 0x0601A8F4 RID: 108788 RVA: 0x007DE038 File Offset: 0x007DC238
	protected override bool OnStart()
	{
		string effectPath = EffectUtil.GetEffectPath("GoBattleMaterial");
		Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerDataGroup_C>(effectPath, delegate([Nullable(2)] PD_CharacterControllerDataGroup_C effect, string _)
		{
			if (effect == null)
			{
				return;
			}
			this.GoBattleMaterial = effect;
		}, 100, "js_undefined");
		string effectPath2 = EffectUtil.GetEffectPath("GoDownMaterial");
		Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(effectPath2, delegate([Nullable(2)] PD_CharacterControllerData_C effect, string _)
		{
			if (effect == null)
			{
				return;
			}
			this.GoDownMaterial = effect;
		}, 100, "js_undefined");
		return true;
	}

	// Token: 0x0601A8F5 RID: 108789 RVA: 0x007DE09A File Offset: 0x007DC29A
	protected override void OnPostActivate()
	{
		this.RefreshTeamTag();
		if (this.DelayOutOfControl)
		{
			this.DelayOutOfControl = false;
			this.ExecuteOutOfControl();
		}
	}

	// Token: 0x0601A8F6 RID: 108790 RVA: 0x007DE0B7 File Offset: 0x007DC2B7
	protected override bool OnEnd()
	{
		this.ClearWaiters();
		return true;
	}

	// Token: 0x0601A8F7 RID: 108791 RVA: 0x007DE0C0 File Offset: 0x007DC2C0
	private void ClearWaiters()
	{
		ITagTask notHideTagTask = this.NotHideTagTask;
		if (notHideTagTask != null)
		{
			notHideTagTask.EndTask();
		}
		this.NotHideTagTask = null;
		ITagTask isStiffTagTask = this.IsStiffTagTask;
		if (isStiffTagTask != null)
		{
			isStiffTagTask.EndTask();
		}
		this.IsStiffTagTask = null;
		if (this.WaitQuitEffectTimer != null)
		{
			TimerSystem.Instance.Remove(this.WaitQuitEffectTimer);
			this.WaitQuitEffectTimer = null;
		}
	}

	// Token: 0x0601A8F8 RID: 108792 RVA: 0x007DE11D File Offset: 0x007DC31D
	public bool NeedSyncTransform()
	{
		return !this.InheritedTransform;
	}

	// Token: 0x0601A8F9 RID: 108793 RVA: 0x007DE128 File Offset: 0x007DC328
	[NullableContext(1)]
	public unsafe static void OnChangeRole([Nullable(2)] EntityHandle lastRole, EntityHandle newRole, bool useGoBattleSkill, double coolDownTime, bool goDownWaitSkillEnd, bool allowRefreshTransform, bool forceInheritTransform)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneTeam;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "执行战斗换人";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Last", (lastRole != null) ? new int?(lastRole.Id) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("New", newRole.Id);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		RoleTeamComponent roleTeamComponent;
		if (lastRole == null)
		{
			roleTeamComponent = null;
		}
		else
		{
			WorldEntity entity = lastRole.Entity;
			roleTeamComponent = ((entity != null) ? entity.GetComponent<RoleTeamComponent>() : null);
		}
		RoleTeamComponent roleTeamComponent2 = roleTeamComponent;
		RoleTeamComponent component = newRole.Entity.GetComponent<RoleTeamComponent>();
		WorldEntity entity2 = newRole.Entity;
		CreatureDataComponent creatureDataComponent = (entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null;
		WorldEntity entity3 = newRole.Entity;
		CreatureDataComponent creatureDataComponent2 = (entity3 != null) ? entity3.GetComponent<CreatureDataComponent>() : null;
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.SceneTeam;
		ELogAuthor author2 = ELogAuthor.HYJ;
		string message2 = "Bug 追踪 RoleTeamComponent OnChangeRole";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Last is valid", lastRole != null && lastRole.Valid);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Last is removing", creatureDataComponent == null || creatureDataComponent.GetRemoveState());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("new is valid", newRole != null && newRole.Valid);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("new is removing", creatureDataComponent2 == null || creatureDataComponent2.GetRemoveState());
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		ETeamGroupType valueOrDefault = ModelBase<SceneTeamModel>.Instance.CurrentGroupType.GetValueOrDefault();
		bool flag = SceneTeamDefine.needInheritTypeSet.Contains(valueOrDefault);
		CharacterSkillComponent characterSkillComponent = (roleTeamComponent2 != null) ? roleTeamComponent2.SkillComp : null;
		if (goDownWaitSkillEnd && characterSkillComponent != null && characterSkillComponent.CurrentSkill != null && !characterSkillComponent.IsMainSkillReadyEnd)
		{
			EntityHandle entityHandle = characterSkillComponent.SkillTarget;
			if (entityHandle == null && ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
			{
				CharacterLockOnComponent lockOnComp = roleTeamComponent2.LockOnComp;
				if (lockOnComp != null)
				{
					lockOnComp.DetectSoftLockTarget(new SkillTargetImpl(), true);
				}
				entityHandle = ((lockOnComp != null) ? lockOnComp.GetCurrentTarget() : null);
			}
			CharacterBuffComponent buffComponent = roleTeamComponent2.BuffComponent;
			if (entityHandle != null && buffComponent != null && buffComponent.HasBuffAuthority())
			{
				buffComponent.AddBuff(1101006002L, new AddBuffParam
				{
					InstigatorId = buffComponent.CreatureDataId,
					Reason = "战斗换人"
				});
			}
		}
		bool specialRollInAir = false;
		bool flag2 = false;
		BaseTagComponent baseTagComponent = (roleTeamComponent2 != null) ? roleTeamComponent2.TagComponent : null;
		if (baseTagComponent != null)
		{
			flag2 = (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]) || baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]));
			specialRollInAir = baseTagComponent.HasAllTag(new int[]
			{
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"],
				GameplayTagDefine.EGameplayTagId["行为状态.动作状态.特殊滚动"]
			});
		}
		component.PerformPossess();
		if (roleTeamComponent2 != null && roleTeamComponent2 != component)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.SceneTeam;
			ELogAuthor author3 = ELogAuthor.LYY;
			string message3 = "角色下场";
			string item = "Entity";
			Entity entity4 = roleTeamComponent2.Entity;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (entity4 != null) ? new int?(entity4.Id) : null);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (GlobalData.GameInstance != null)
			{
				GlobalData.BpEventManager.当换人完成时.Broadcast();
			}
			CharacterManipulateComponent manipulateComp = component.ManipulateComp;
			if (manipulateComp != null)
			{
				manipulateComp.SetDataFromOldRole(lastRole);
			}
			CharacterManipulateInteractComponent manipulateInteractComp = component.ManipulateInteractComp;
			if (manipulateInteractComp != null)
			{
				manipulateInteractComp.SetDataFromOldRole(lastRole);
			}
			CharacterExploreComponent characterExploreComp = component.CharacterExploreComp;
			if (characterExploreComp != null)
			{
				characterExploreComp.SetDataFromOldRole(lastRole);
			}
			RoleSceneInteractComponent roleSceneInteractComp = component.RoleSceneInteractComp;
			if (roleSceneInteractComp != null)
			{
				roleSceneInteractComp.SetDataFromOldRole(lastRole);
			}
			CharacterManipulateInteractComponent manipulateInteractComp2 = roleTeamComponent2.ManipulateInteractComp;
			if (manipulateInteractComp2 != null)
			{
				manipulateInteractComp2.ClearTarget();
			}
			roleTeamComponent2.ClearMovePlatformAttach();
			if (flag || !roleTeamComponent2.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.切人不隐藏"]))
			{
				roleTeamComponent2.SkillComp.StopGroup1Skill("RoleTeamComponent.OnChangeRole");
			}
			bool skill = roleTeamComponent2.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) && !roleTeamComponent2.SkillComp.IsMainSkillReadyEnd;
			RoleInheritComponent.StateInherit(roleTeamComponent2.InheritComp, component.InheritComp, (!component.QteComp.IsInQte) ? ERoleInheritType.NORMAL : ERoleInheritType.QTE, skill);
			roleTeamComponent2.GoDown(flag);
			roleTeamComponent2.CommitChangeRoleCoolDown(coolDownTime);
		}
		bool forceInherit = flag2 || forceInheritTransform || flag;
		component.RefreshPosition(lastRole, specialRollInAir, allowRefreshTransform, forceInherit);
		component.GoBattle(!flag2 && useGoBattleSkill);
	}

	// Token: 0x0601A8FA RID: 108794 RVA: 0x007DE59C File Offset: 0x007DC79C
	private unsafe void PerformPossess()
	{
		AController characterController = Global.CharacterController;
		TsBaseCharacter actor = this.ActorComp.Actor;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.HYJ;
		string message = "RoleTeam PerformPossess";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleActor", actor);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("valid:", actor.IsValid());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (characterController.Pawn != actor)
		{
			actor.Mesh.AddTickPrerequisiteActor(characterController);
			characterController.Possess(actor);
			this.MoveComp.StopMove(false, "RoleTeamComponent.PerformPossess");
			CharacterInputComponent inputComp = this.InputComp;
			if (inputComp == null || !inputComp.Active)
			{
				CharacterInputComponent inputComp2 = this.InputComp;
				if (inputComp2 == null)
				{
					return;
				}
				inputComp2.SetActive(true);
			}
		}
	}

	// Token: 0x0601A8FB RID: 108795 RVA: 0x007DE670 File Offset: 0x007DC870
	private void RefreshPosition(EntityHandle lastRole, bool specialRollInAir, bool allowRefresh, bool forceInherit)
	{
		this.InheritedTransform = false;
		bool clearInputFacing = lastRole == null;
		if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "人物上场，GM推进中，继承位置", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InheritTransform(clearInputFacing, lastRole);
			return;
		}
		if (!allowRefresh)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "人物上场，不允许改变位置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (forceInherit)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "人物上场，强制继承位置", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InheritTransform(clearInputFacing, lastRole);
			return;
		}
		if (this.QteComp.IsInQte)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "人物上场，角色QTE中，不更新位置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		BaseTagComponent baseTagComponent;
		if (lastRole == null)
		{
			baseTagComponent = null;
		}
		else
		{
			WorldEntity entity = lastRole.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null || !baseTagComponent2.HasAnyTag(new int[]
		{
			GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"],
			GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"],
			GameplayTagDefine.EGameplayTagId["角色.Common.切人不隐藏"],
			GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"]
		}))
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "人物上场，上个角色不在场，继承位置", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InheritTransform(clearInputFacing, lastRole);
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "人物上场，上个角色还在场，进行寻点", default(ReadOnlySpan<ValueTuple<string, object>>));
		bool flag = specialRollInAir || (!baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.切人强制地面寻点"]) && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]));
		base.Entity.GetComponent<RoleQteComponent>().SetQtePosition(new IOffsetParam
		{
			Rotate = (flag ? 35f : 80f),
			Length = (flag ? 150f : 200f),
			Height = (flag ? -100f : 0f),
			ReferenceTarget = false,
			QteType = (flag ? EQteType.InAir : EQteType.OnLand)
		});
		EMovementMode mode = flag ? EMovementMode.MOVE_Falling : EMovementMode.MOVE_Walking;
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		CharacterActorComponent actorComp = moveComp.ActorComp;
		if (actorComp == null)
		{
			return;
		}
		actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = mode,
			Context = "[RoleTeamComponent.RefreshPosition]"
		});
	}

	// Token: 0x0601A8FC RID: 108796 RVA: 0x007DE8D4 File Offset: 0x007DCAD4
	public bool InheritTransform(bool clearInputFacing = false, EntityHandle lastRole = null)
	{
		this.InheritedTransform = true;
		FTransformDouble? spawnTransform = ModelBase<SceneTeamModel>.Instance.GetSpawnTransform();
		if (spawnTransform == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneTeam, ELogAuthor.LYY, "继承位置失败，获取角色Transform为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		FTransformDouble value = spawnTransform.Value;
		CharacterDriveVehicleComponent component = base.Entity.GetComponent<CharacterDriveVehicleComponent>();
		if (component == null || !component.IsOnVehicle)
		{
			if (this.MoveComp.IsStandardGravity)
			{
				FQuat fquat = new FRotator(0f, value.Rotator().Yaw, 0f).Quaternion();
				value.SetRotation(fquat);
			}
			else
			{
				this.TempQuat.FromUeQuat(value.GetRotation());
				this.TempQuat.RotateVector(Vector.ForwardVectorProxy, this.TempVector);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TempVector, this.MoveComp.GravityUp, this.TempRotator);
				this.TempRotator.Quaternion(this.TempQuat);
				FQuat fquat = this.TempQuat.ToUeQuat();
				value.SetRotation(fquat);
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneTeam;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "继承位置";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Location", value.GetLocation());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ActorComp.SetActorTransform(value, "换人.上场", false, null);
		if (clearInputFacing)
		{
			this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, false);
		}
		ModelBase<SceneTeamModel>.Instance.SetLastTransform(null);
		CharacterUnifiedStateComponent stateComp = this.StateComp;
		CharacterFloatingComponent characterFloatingComponent = (lastRole != null && lastRole.Valid) ? lastRole.Entity.GetComponent<CharacterFloatingComponent>() : null;
		bool flag = characterFloatingComponent != null && characterFloatingComponent.Valid && characterFloatingComponent.WasNearGround;
		if (stateComp.PositionState == ECharPositionState.Ground && ModelBase<SceneTeamModel>.Instance.LastEntityIsOnGround)
		{
			this.FixSwitchLocation("换人.地面修正", lastRole);
		}
		else if (stateComp.MoveState == ECharMoveState.Slide || stateComp.MoveState == ECharMoveState.NormalSki)
		{
			this.FixSwitchLocation("换人.滑行修正", lastRole);
		}
		else
		{
			if (!flag)
			{
				CharacterFloatingComponent floatingComp = this.FloatingComp;
				if (floatingComp == null || !floatingComp.InFloatingState)
				{
					return true;
				}
			}
			this.FixSwitchLocation("换人.悬浮修正", lastRole);
		}
		return true;
	}

	// Token: 0x0601A8FD RID: 108797 RVA: 0x007DEB14 File Offset: 0x007DCD14
	[NullableContext(1)]
	private void FixSwitchLocation(string context, [Nullable(2)] EntityHandle lastRole = null)
	{
		float num = 0f;
		CharacterFloatingComponent characterFloatingComponent = (lastRole != null && lastRole.Valid) ? lastRole.Entity.GetComponent<CharacterFloatingComponent>() : null;
		if (characterFloatingComponent != null && characterFloatingComponent.Valid && characterFloatingComponent.WasNearGround)
		{
			CharacterActorComponent component = lastRole.Entity.GetComponent<CharacterActorComponent>();
			if (component != null && component.Valid)
			{
				num = this.ActorComp.HalfHeight - component.HalfHeight;
			}
			num -= characterFloatingComponent.WasNearGroundDist;
		}
		this.ActorComp.FixSwitchLocation(context, true, true, num);
	}

	// Token: 0x0601A8FE RID: 108798 RVA: 0x007DEB98 File Offset: 0x007DCD98
	private void GoBattle(bool useGoBattleSkill)
	{
		if (this.QteComp.IsInQte)
		{
			this.GoBattleSkill = false;
		}
		else
		{
			bool flag = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.无QTE则强制出场技"]);
			this.LockOnComp.DetectSoftLockTarget(new SkillTargetImpl(), true);
			EntityHandle currentTarget = this.LockOnComp.GetCurrentTarget();
			bool flag2 = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.后台"]);
			this.GoBattleSkill = (flag || (useGoBattleSkill && flag2 && currentTarget != null));
		}
		this.ClearWaiters();
		foreach (int value in CharacterUnifiedStateComponent.outGameRoleTags)
		{
			this.TagComponent.RemoveTag(new int?(value));
		}
		this.SetTeamTag(ETeamState.OnStage);
		if (!ModelBase<PlotModel>.Instance.InSeamlessFormation)
		{
			base.Entity.EnableByKey(EEntityDisableKey.GoDown, true);
		}
		else
		{
			base.Entity.DisableByKey(EEntityDisableKey.GoDown, true);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.OnRoleGoUpEnable);
		Singleton<TickProcessSystem>.Instance.RegisterOnceTickProcess(ETickingGroup.TG_PostUpdateWork, true, new Action<float>(this.NextSpawnGoBattleMaterial));
		this.ActorComp.KuroMoveAlongFloor(Vector.ZeroVector, 0f, "GoBattle");
		if (!Singleton<UiCameraAnimationManager>.Instance.IsActivate())
		{
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
		}
		if (this.GoBattleSkill)
		{
			bool flag3 = this.StateComp.PositionState == ECharPositionState.Air;
			bool flag4;
			if (this.StateComp.PositionState == ECharPositionState.Floating)
			{
				CharacterFloatingComponent floatingComp = this.FloatingComp;
				flag4 = (floatingComp != null && !floatingComp.IsOnGround);
			}
			else
			{
				flag4 = false;
			}
			bool flag5 = flag4;
			this.ActorComp.Actor.FightCommand(flag3 || flag5);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.OnRoleGoUp);
	}

	// Token: 0x0601A8FF RID: 108799 RVA: 0x007DED6D File Offset: 0x007DCF6D
	private void NextSpawnGoBattleMaterial(float delta)
	{
		TimerSystem.Instance.Next(delegate(float _)
		{
			this.SpawnGoBattleMaterial();
		}, null, null);
	}

	// Token: 0x0601A900 RID: 108800 RVA: 0x007DED88 File Offset: 0x007DCF88
	private void SpawnGoBattleMaterial()
	{
		if (!base.Entity.Active)
		{
			return;
		}
		if (ModelBase<SceneTeamModel>.Instance.CurrentGroupType.GetValueOrDefault() == ETeamGroupType.Plot)
		{
			int roleId = base.Entity.GetComponent<CreatureDataComponent>().GetRoleId();
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(roleId);
			UObject goBattleMaterial = ModelBase<PlotModel>.Instance.GoBattleMaterial;
			if (goBattleMaterial != null && ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId))
			{
				this.ActorComp.Actor.CharRenderingComponent.AddMaterialControllerData(goBattleMaterial);
			}
			return;
		}
		if (this.GoBattleMaterial != null)
		{
			this.ActorComp.Actor.CharRenderingComponent.AddMaterialControllerDataGroup(this.GoBattleMaterial);
		}
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(this.ActorComp.ActorTransform);
		int id = instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRole_Play.DA_Fx_Group_ChangeRole_Play", "[RoleTeamComponent.SpawnGoBattleMaterial]", new EffectContext(new int?(base.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
		Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, id, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		if (Singleton<EffectSystem>.Instance.IsValid(id))
		{
			Singleton<EffectSystem>.Instance.GetEffectActor(id).K2_AttachToComponent(this.ActorComp.SkeletalMesh, new FName?(FNameUtil.NONE), EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, true);
		}
	}

	// Token: 0x0601A901 RID: 108801 RVA: 0x007DEEC4 File Offset: 0x007DD0C4
	private void GoDown(bool forceGoDown)
	{
		BaseTagComponent tagComponent = this.TagComponent;
		bool flag = tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.切人不隐藏"]);
		BaseTagComponent tagComponent2 = this.TagComponent;
		bool flag2 = tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"]);
		if (forceGoDown || (!flag && !flag2))
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "角色下场，立即隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SetTeamTag(ETeamState.UnderStage);
			base.Entity.DisableByKey(EEntityDisableKey.GoDown, true);
			this.ActorComp.RestoreDefaultController();
			CharacterMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.StopAllAddMove();
			}
			Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.OnRoleGoDownFinish);
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "角色下场，等待切人不隐藏Tag、硬直时间Tag移除再隐藏角色", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (flag && this.NotHideTagTask == null)
		{
			this.NotHideTagTask = this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.切人不隐藏"]), delegate(int tagId, bool tagExist)
			{
				if (!tagExist)
				{
					ITagTask notHideTagTask = this.NotHideTagTask;
					if (notHideTagTask != null)
					{
						notHideTagTask.EndTask();
					}
					this.NotHideTagTask = null;
					this.TryGoDown();
				}
			}, null);
		}
		if (flag2 && this.IsStiffTagTask == null)
		{
			this.IsStiffTagTask = this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"]), delegate(int tagId, bool tagExist)
			{
				if (!tagExist)
				{
					ITagTask isStiffTagTask = this.IsStiffTagTask;
					if (isStiffTagTask != null)
					{
						isStiffTagTask.EndTask();
					}
					this.IsStiffTagTask = null;
					this.TryGoDown();
				}
			}, null);
		}
		this.SetTeamTag(ETeamState.OnStageWithoutControl);
		this.ActorComp.RestoreDefaultController();
		CharacterMoveComponent moveComp2 = this.MoveComp;
		if (moveComp2 == null)
		{
			return;
		}
		moveComp2.StopAllAddMove();
	}

	// Token: 0x0601A902 RID: 108802 RVA: 0x007DF044 File Offset: 0x007DD244
	private void TryGoDown()
	{
		bool flag = this.NotHideTagTask == null && this.IsStiffTagTask == null;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneTeam;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "角色下场，尝试隐藏角色";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CanGoDown", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!flag)
		{
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		int? num = (getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null;
		int id = base.Entity.Id;
		if (!(num.GetValueOrDefault() == id & num != null))
		{
			this.DisableRoleWithEffect();
		}
	}

	// Token: 0x0601A903 RID: 108803 RVA: 0x007DF0E4 File Offset: 0x007DD2E4
	public void InterruptDisableWithEffect()
	{
		if (this.WaitQuitEffectTimer != null)
		{
			TimerSystem.Instance.Remove(this.WaitQuitEffectTimer);
			this.WaitQuitEffectTimer = null;
		}
		int quitEffectHandle = this.QuitEffectHandle;
		if (quitEffectHandle != 0)
		{
			this.ActorComp.Actor.CharRenderingComponent.RemoveMaterialControllerData(quitEffectHandle);
			this.QuitEffectHandle = 0;
		}
	}

	// Token: 0x0601A904 RID: 108804 RVA: 0x007DF138 File Offset: 0x007DD338
	public void DisableRoleWithEffect()
	{
		if (this.WaitQuitEffectTimer != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "角色下场，正在播放特效等待隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "角色下场，播放特效后再隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.GoDownMaterial != null)
		{
			this.QuitEffectHandle = this.ActorComp.Actor.CharRenderingComponent.AddMaterialControllerData(this.GoDownMaterial);
		}
		this.WaitQuitEffectTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.WaitQuitEffectTimer = null;
			this.DisableRole();
		}, 300f, null, null, true, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<SceneTeamController>.Instance.RoleGoDownPush(base.Entity);
		}
	}

	// Token: 0x0601A905 RID: 108805 RVA: 0x007DF1FC File Offset: 0x007DD3FC
	public void DisableRoleWithoutEffect()
	{
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "角色下场，立刻隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.WaitQuitEffectTimer != null)
		{
			TimerSystem.Instance.Remove(this.WaitQuitEffectTimer);
			this.WaitQuitEffectTimer = null;
		}
		this.DisableRole();
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<SceneTeamController>.Instance.RoleGoDownPush(base.Entity);
		}
	}

	// Token: 0x0601A906 RID: 108806 RVA: 0x007DF268 File Offset: 0x007DD468
	private void DisableRole()
	{
		int quitEffectHandle = this.QuitEffectHandle;
		if (quitEffectHandle != 0)
		{
			this.ActorComp.Actor.CharRenderingComponent.RemoveMaterialControllerData(quitEffectHandle);
			this.QuitEffectHandle = 0;
		}
		this.SkillComp.StopAllSkills("RoleTeamComponent.DisableRole");
		this.UpdateStealthTag(false);
		this.SetTeamTag(ETeamState.UnderStage);
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp != null)
		{
			UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
			if (characterMovement != null)
			{
				characterMovement.SetDefaultMovementMode();
			}
		}
		base.Entity.DisableByKey(EEntityDisableKey.GoDown, true);
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.OnRoleGoDownFinish);
	}

	// Token: 0x0601A907 RID: 108807 RVA: 0x007DF2FC File Offset: 0x007DD4FC
	private void CommitChangeRoleCoolDown(double coolDown)
	{
		double num = coolDown * 1000.0;
		this.ChangeRoleCdEndTime = num + Singleton<Time>.Instance.PlayerWorldTime;
		Singleton<EventSystem>.Instance.EmitWithTarget<double>(base.Entity, EEventName.OnChangeRoleCoolDownChanged, coolDown);
	}

	// Token: 0x0601A908 RID: 108808 RVA: 0x007DF33E File Offset: 0x007DD53E
	public bool IsChangeRoleCoolDown()
	{
		if (this.GetChangeRoleCoolDown() > 0.0)
		{
			return true;
		}
		this.ChangeRoleCdEndTime = -1.0;
		return false;
	}

	// Token: 0x0601A909 RID: 108809 RVA: 0x007DF363 File Offset: 0x007DD563
	public double GetChangeRoleCoolDown()
	{
		if (this.ChangeRoleCdEndTime <= 0.0)
		{
			return -1.0;
		}
		return this.ChangeRoleCdEndTime - Singleton<Time>.Instance.PlayerWorldTime;
	}

	// Token: 0x0601A90A RID: 108810 RVA: 0x007DF391 File Offset: 0x007DD591
	public void SetTeamTag(ETeamState state)
	{
		this.TeamState = new ETeamState?(state);
		if (base.Entity.IsInit)
		{
			this.RefreshTeamTag();
		}
	}

	// Token: 0x0601A90B RID: 108811 RVA: 0x007DF3B4 File Offset: 0x007DD5B4
	private void RefreshTeamTag()
	{
		if (this.TeamState == null)
		{
			return;
		}
		ETeamState? teamState = this.TeamState;
		if (teamState != null)
		{
			switch (teamState.GetValueOrDefault())
			{
			case ETeamState.OnStage:
				this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]));
				this.UpdateStealthTag(false);
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.后台"]))
				{
					this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.后台"]));
				}
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"]))
				{
					this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"]));
					return;
				}
				break;
			case ETeamState.OnStageWithoutControl:
				this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"]));
				this.UpdateStealthTag(true);
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.后台"]))
				{
					this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.后台"]));
				}
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]))
				{
					this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]));
					return;
				}
				break;
			case ETeamState.UnderStage:
				if (this.ActorComp.IsAutonomousProxy)
				{
					this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.后台"]));
				}
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]))
				{
					this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]));
				}
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"]))
				{
					this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"]));
				}
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x0601A90C RID: 108812 RVA: 0x007DF5E5 File Offset: 0x007DD7E5
	public ETeamState? GetTeamState()
	{
		return this.TeamState;
	}

	// Token: 0x0601A90D RID: 108813 RVA: 0x007DF5F0 File Offset: 0x007DD7F0
	private void UpdateStealthTag(bool onStageWithoutControl)
	{
		if (onStageWithoutControl)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null)
			{
				return;
			}
			tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不被敌方子弹命中.前台不受控制"]));
			return;
		}
		else
		{
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 == null)
			{
				return;
			}
			tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不被敌方子弹命中.前台不受控制"]));
			return;
		}
	}

	// Token: 0x0601A90E RID: 108814 RVA: 0x007DF64A File Offset: 0x007DD84A
	public void OutOfControl()
	{
		this.SetTeamTag(ETeamState.OnStageWithoutControl);
		if (!base.Entity.IsInit)
		{
			this.DelayOutOfControl = true;
			return;
		}
		this.ExecuteOutOfControl();
	}

	// Token: 0x0601A90F RID: 108815 RVA: 0x007DF670 File Offset: 0x007DD870
	private void ExecuteOutOfControl()
	{
		this.SkillComp.StopAllSkills("RoleTeamComponent.OutOfControl");
		CharacterInputComponent inputComp = this.InputComp;
		if (inputComp != null)
		{
			inputComp.ClearMoveVectorCache();
		}
		CharacterInputComponent inputComp2 = this.InputComp;
		if (inputComp2 != null)
		{
			inputComp2.SetActive(false);
		}
		this.ActorComp.ClearInput(false, true);
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp != null)
		{
			moveComp.StopMove(true, "RoleTeamComponent.ExecuteOutOfControl");
		}
		this.ActorComp.RestoreDefaultController();
		CharacterMoveComponent moveComp2 = this.MoveComp;
		if (moveComp2 == null)
		{
			return;
		}
		moveComp2.StopAllAddMove();
	}

	// Token: 0x0601A910 RID: 108816 RVA: 0x007DF6F0 File Offset: 0x007DD8F0
	[NullableContext(1)]
	public static void OnSimulateChangeRole(EntityHandle lastEntityHandle, EntityHandle newEntityHandle, bool onStageWithoutControl, [Nullable(2)] Vector location = null, [Nullable(2)] Rotator rotation = null)
	{
		Entity entity = lastEntityHandle.Entity;
		Entity entity2 = newEntityHandle.Entity;
		if (entity2 == null || entity == null)
		{
			return;
		}
		entity2.GetComponent<RoleTeamComponent>().SimulateGoBattle();
		bool flag = location != null && rotation != null;
		if (entity2.IsInit)
		{
			CharacterActorComponent component = entity2.GetComponent<CharacterActorComponent>();
			if (flag)
			{
				component.SetActorLocationAndRotation(location.ToUeVector(false), rotation.ToUeRotator(), "SwitchRoleNotify", false, null);
			}
			else
			{
				component.SetActorTransform(entity.GetComponent<CharacterActorComponent>().ActorTransform, "SwitchRoleNotify", false, null);
				if (entity.GetComponent<BaseTagComponent>().HasAnyTag(SceneTeamDefine.needFixLocationTagList))
				{
					component.FixSwitchLocation("模拟端换人地面修正", true, true, 0f);
				}
			}
			component.SetInputFacing(component.ActorForwardProxy, false);
		}
		UObject mainAnimInstance = entity2.GetComponent<CharacterAnimationComponent>().MainAnimInstance;
		UObject mainAnimInstance2 = entity.GetComponent<CharacterAnimationComponent>().MainAnimInstance;
		if (UKuroStaticLibrary.IsObjectClassByName(mainAnimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE) && UKuroStaticLibrary.IsObjectClassByName(mainAnimInstance2, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE))
		{
			((ABP_BaseRole_C)mainAnimInstance).替换角色时同步动作数据((ABP_BaseRole_C)mainAnimInstance2);
		}
		if (!flag)
		{
			BaseMovementSyncComponent component2 = entity2.GetComponent<CharacterMovementSyncComponent>();
			CharacterMovementSyncComponent component3 = entity.GetComponent<CharacterMovementSyncComponent>();
			component2.CloneMoveSampleInfos(component3);
		}
		if (!onStageWithoutControl)
		{
			entity.GetComponent<RoleTeamComponent>().SimulateGoDown(false);
		}
	}

	// Token: 0x0601A911 RID: 108817 RVA: 0x007DF83B File Offset: 0x007DDA3B
	public void SimulateGoBattle()
	{
		this.InterruptDisableWithEffect();
		base.Entity.GetComponent<CreatureDataComponent>().SetVisible(true);
		base.Entity.EnableByKey(EEntityDisableKey.GoDown, true);
	}

	// Token: 0x0601A912 RID: 108818 RVA: 0x007DF864 File Offset: 0x007DDA64
	public void SimulateGoDown(bool onStageWithoutControl)
	{
		if (!onStageWithoutControl)
		{
			this.SimulateDisableRole();
			return;
		}
		if (this.WaitQuitEffectTimer != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "模拟端角色下场，正在播放特效等待隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "模拟端角色下场，播放特效后再隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.GoDownMaterial != null)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			int? num;
			if (actorComp == null)
			{
				num = null;
			}
			else
			{
				TsBaseCharacter actor = actorComp.Actor;
				if (actor == null)
				{
					num = null;
				}
				else
				{
					CharRenderingComponent charRenderingComponent = actor.CharRenderingComponent;
					num = ((charRenderingComponent != null) ? new int?(charRenderingComponent.AddMaterialControllerData(this.GoDownMaterial)) : null);
				}
			}
			int? num2 = num;
			this.QuitEffectHandle = num2.GetValueOrDefault();
		}
		this.WaitQuitEffectTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.WaitQuitEffectTimer = null;
			this.SimulateDisableRole();
		}, 300f, null, null, true, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
	}

	// Token: 0x0601A913 RID: 108819 RVA: 0x007DF950 File Offset: 0x007DDB50
	private void SimulateDisableRole()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component != null)
		{
			component.SetVisible(false);
		}
		base.Entity.DisableByKey(EEntityDisableKey.GoDown, true);
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.OnOtherRoleGoDownFinish);
	}

	// Token: 0x0601A914 RID: 108820 RVA: 0x007DF98C File Offset: 0x007DDB8C
	public void ClearMovePlatformAttach()
	{
		this.DriveVehicleComp.IsAttachToMoveSceneItem = false;
		this.MoveComp.NeedRootMotionWhenAttached = false;
		this.MoveComp.CharacterMovement.bKuroStopUpdateBasedMovement = false;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			AActor owner = actorComp.Owner;
			if (owner != null)
			{
				owner.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
			}
		}
		CharacterMovementSyncComponent movementSyncComp = this.MovementSyncComp;
		if (movementSyncComp == null)
		{
			return;
		}
		movementSyncComp.ClearBasePlatform();
	}

	// Token: 0x0601A915 RID: 108821 RVA: 0x007DF9F4 File Offset: 0x007DDBF4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleTeamComponent roleTeamComponent = (RoleTeamComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (roleTeamComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (roleTeamComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (roleTeamComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (roleTeamComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FloatingComp"))
		{
			if (roleTeamComponent.FloatingComp == null)
			{
				this.FloatingComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterFloatingComponent>(this.FloatingComp), "FloatingComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InheritComp"))
		{
			if (roleTeamComponent.InheritComp == null)
			{
				this.InheritComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleInheritComponent>(this.InheritComp), "InheritComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (roleTeamComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("QteComp"))
		{
			if (roleTeamComponent.QteComp == null)
			{
				this.QteComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleQteComponent>(this.QteComp), "QteComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (roleTeamComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputComp"))
		{
			if (roleTeamComponent.InputComp == null)
			{
				this.InputComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComp), "InputComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LockOnComp"))
		{
			if (roleTeamComponent.LockOnComp == null)
			{
				this.LockOnComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterLockOnComponent>(this.LockOnComp), "LockOnComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ManipulateComp"))
		{
			if (roleTeamComponent.ManipulateComp == null)
			{
				this.ManipulateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterManipulateComponent>(this.ManipulateComp), "ManipulateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ManipulateInteractComp"))
		{
			if (roleTeamComponent.ManipulateInteractComp == null)
			{
				this.ManipulateInteractComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterManipulateInteractComponent>(this.ManipulateInteractComp), "ManipulateInteractComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterExploreComp"))
		{
			if (roleTeamComponent.CharacterExploreComp == null)
			{
				this.CharacterExploreComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterExploreComponent>(this.CharacterExploreComp), "CharacterExploreComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RoleSceneInteractComp"))
		{
			if (roleTeamComponent.RoleSceneInteractComp == null)
			{
				this.RoleSceneInteractComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleSceneInteractComponent>(this.RoleSceneInteractComp), "RoleSceneInteractComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MovementSyncComp"))
		{
			if (roleTeamComponent.MovementSyncComp == null)
			{
				this.MovementSyncComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMovementSyncComponent>(this.MovementSyncComp), "MovementSyncComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DriveVehicleComp"))
		{
			if (roleTeamComponent.DriveVehicleComp == null)
			{
				this.DriveVehicleComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterDriveVehicleComponent>(this.DriveVehicleComp), "DriveVehicleComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GoBattleMaterial"))
		{
			if (roleTeamComponent.GoBattleMaterial == null)
			{
				this.GoBattleMaterial = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PD_CharacterControllerDataGroup_C>(this.GoBattleMaterial), "GoBattleMaterial"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GoDownMaterial"))
		{
			if (roleTeamComponent.GoDownMaterial == null)
			{
				this.GoDownMaterial = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PD_CharacterControllerData_C>(this.GoDownMaterial), "GoDownMaterial"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ChangeRoleCdEndTime"))
		{
			this.ChangeRoleCdEndTime = roleTeamComponent.ChangeRoleCdEndTime;
		}
		if (base.CanResetComponentProperty("TeamState"))
		{
			this.TeamState = roleTeamComponent.TeamState;
		}
		if (base.CanResetComponentProperty("GoBattleSkill"))
		{
			this.GoBattleSkill = roleTeamComponent.GoBattleSkill;
		}
		if (base.CanResetComponentProperty("NotHideTagTask"))
		{
			if (roleTeamComponent.NotHideTagTask == null)
			{
				this.NotHideTagTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.NotHideTagTask), "NotHideTagTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsStiffTagTask"))
		{
			if (roleTeamComponent.IsStiffTagTask == null)
			{
				this.IsStiffTagTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.IsStiffTagTask), "IsStiffTagTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("QuitEffectHandle"))
		{
			this.QuitEffectHandle = roleTeamComponent.QuitEffectHandle;
		}
		if (base.CanResetComponentProperty("WaitQuitEffectTimer"))
		{
			if (roleTeamComponent.WaitQuitEffectTimer == null)
			{
				this.WaitQuitEffectTimer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.WaitQuitEffectTimer), "WaitQuitEffectTimer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InheritedTransform"))
		{
			this.InheritedTransform = roleTeamComponent.InheritedTransform;
		}
		if (base.CanResetComponentProperty("DelayOutOfControl"))
		{
			this.DelayOutOfControl = roleTeamComponent.DelayOutOfControl;
		}
		return (!base.CanResetComponentProperty("TempVector") || roleTeamComponent.TempVector == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector")) && (!base.CanResetComponentProperty("TempRotator") || roleTeamComponent.TempRotator == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TempRotator), "TempRotator")) && (!base.CanResetComponentProperty("TempQuat") || roleTeamComponent.TempQuat == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TempQuat), "TempQuat"));
	}

	// Token: 0x0400D6E0 RID: 55008
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D6E1 RID: 55009
	private CharacterBuffComponent BuffComponent;

	// Token: 0x0400D6E2 RID: 55010
	private BaseTagComponent TagComponent;

	// Token: 0x0400D6E3 RID: 55011
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400D6E4 RID: 55012
	private CharacterFloatingComponent FloatingComp;

	// Token: 0x0400D6E5 RID: 55013
	private RoleInheritComponent InheritComp;

	// Token: 0x0400D6E6 RID: 55014
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400D6E7 RID: 55015
	private RoleQteComponent QteComp;

	// Token: 0x0400D6E8 RID: 55016
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400D6E9 RID: 55017
	private CharacterInputComponent InputComp;

	// Token: 0x0400D6EA RID: 55018
	private CharacterLockOnComponent LockOnComp;

	// Token: 0x0400D6EB RID: 55019
	private CharacterManipulateComponent ManipulateComp;

	// Token: 0x0400D6EC RID: 55020
	private CharacterManipulateInteractComponent ManipulateInteractComp;

	// Token: 0x0400D6ED RID: 55021
	private CharacterExploreComponent CharacterExploreComp;

	// Token: 0x0400D6EE RID: 55022
	private RoleSceneInteractComponent RoleSceneInteractComp;

	// Token: 0x0400D6EF RID: 55023
	private CharacterMovementSyncComponent MovementSyncComp;

	// Token: 0x0400D6F0 RID: 55024
	private CharacterDriveVehicleComponent DriveVehicleComp;

	// Token: 0x0400D6F1 RID: 55025
	private PD_CharacterControllerDataGroup_C GoBattleMaterial;

	// Token: 0x0400D6F2 RID: 55026
	private PD_CharacterControllerData_C GoDownMaterial;

	// Token: 0x0400D6F3 RID: 55027
	private double ChangeRoleCdEndTime = -1.0;

	// Token: 0x0400D6F4 RID: 55028
	private ETeamState? TeamState;

	// Token: 0x0400D6F5 RID: 55029
	public bool GoBattleSkill;

	// Token: 0x0400D6F6 RID: 55030
	private ITagTask NotHideTagTask;

	// Token: 0x0400D6F7 RID: 55031
	private ITagTask IsStiffTagTask;

	// Token: 0x0400D6F8 RID: 55032
	private int QuitEffectHandle;

	// Token: 0x0400D6F9 RID: 55033
	private TimerHandle WaitQuitEffectTimer;

	// Token: 0x0400D6FA RID: 55034
	private bool InheritedTransform;

	// Token: 0x0400D6FB RID: 55035
	private bool DelayOutOfControl;

	// Token: 0x0400D6FC RID: 55036
	[Nullable(1)]
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400D6FD RID: 55037
	[Nullable(1)]
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x0400D6FE RID: 55038
	[Nullable(1)]
	private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);
}
