using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using Google.Protobuf;

// Token: 0x020030B4 RID: 12468
[NullableContext(1)]
[Nullable(0)]
public class CharacterLockOnComponent : BaseLockOnComponent, IComponentDependency
{
	// Token: 0x1700229E RID: 8862
	// (get) Token: 0x06019B1F RID: 105247 RVA: 0x00779588 File Offset: 0x00777788
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Type[] Dependencies
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return new Type[]
			{
				typeof(CharacterUnifiedStateComponent)
			};
		}
	}

	// Token: 0x06019B20 RID: 105248 RVA: 0x0077959D File Offset: 0x0077779D
	protected override void OnTargetDeadOrRemoved()
	{
		if (this.IsLookAt)
		{
			this.ForceLookAt(null, false);
			return;
		}
		if (base.IsHardLock)
		{
			this.DetectHardLockTargets(true);
			return;
		}
		base.SetCurrentInfo(null);
		this.SetShowTarget(null, "", false);
	}

	// Token: 0x06019B21 RID: 105249 RVA: 0x007795D8 File Offset: 0x007777D8
	private void OnStateInherit(Entity lastEntity, bool _)
	{
		CharacterLockOnComponent component = lastEntity.GetComponent<CharacterLockOnComponent>();
		this.IsLookAt = component.IsLookAt;
		this.IgnoreInfos = new List<LockOnInfo>(component.IgnoreInfos);
		base.SetCurrentInfo(component.GetCurrentInfo);
		this.RestoreIgnoreTarget = component.RestoreIgnoreTarget;
		this.SetShowTarget(component.ShowTarget, component.ShowTargetSocket, false);
	}

	// Token: 0x06019B22 RID: 105250 RVA: 0x00779638 File Offset: 0x00777838
	protected override bool OnStart()
	{
		base.OnStart();
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.CreatureComp = base.Entity.GetComponent<CreatureDataComponent>();
		RoleInfo? roleConfig = this.CreatureComp.GetRoleConfig();
		int softLockConfigId = (roleConfig != null) ? roleConfig.GetValueOrDefault().LockOnDefaultId : 0;
		roleConfig = this.CreatureComp.GetRoleConfig();
		base.SetLockOnConfig(softLockConfigId, (roleConfig != null) ? roleConfig.GetValueOrDefault().LockOnLookOnId : 0);
		this.UnifiedStateComponent = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.InputComponent = base.Entity.GetComponent<CharacterInputComponent>();
		this.BuffComponent = base.Entity.GetComponent<CharacterBuffComponent>();
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		this.TagListeners.Add(this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不可锁定.强锁定.结束恢复"]), new BaseTagComponent.TTagSwitchedCallback(this.OnRestoreTargetTagAddOrRemove), null));
		this.TagListeners.Add(this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.特殊锁定.切换强锁配置.远距离强锁"]), new BaseTagComponent.TTagSwitchedCallback(this.OnForceLockTagAddOrRemove), null));
		return true;
	}

	// Token: 0x06019B23 RID: 105251 RVA: 0x007797A4 File Offset: 0x007779A4
	protected override bool OnEnd()
	{
		base.OnEnd();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		foreach (ITagTask tagTask in this.TagListeners)
		{
			tagTask.EndTask();
		}
		this.TagListeners.Clear();
		if (this.ForceLockEntityAddDispose != null)
		{
			this.ForceLockEntityAddDispose();
			this.ForceLockEntityAddDispose = null;
		}
		return true;
	}

	// Token: 0x06019B24 RID: 105252 RVA: 0x00779860 File Offset: 0x00777A60
	protected override void OnDisable(string reason)
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.拥有锁定目标"]));
	}

	// Token: 0x06019B25 RID: 105253 RVA: 0x00779887 File Offset: 0x00777A87
	protected override void OnTick(float delta)
	{
		this.TickMoveDir();
		this.TickCurrentInfo();
		base.Check(delta);
		base.UpdateTargetsIsLock(delta);
		this.SendRequestMessageIfHardLockStateChanged();
		this.RefreshHardLockDebug();
		base.OnTick(delta);
	}

	// Token: 0x06019B26 RID: 105254 RVA: 0x007798B8 File Offset: 0x00777AB8
	private void RefreshHardLockDebug()
	{
		if (!LockOnDebug.IsShowDebugLine || !base.IsHardLock)
		{
			return;
		}
		LockOnInfo getCurrentInfo = base.GetCurrentInfo;
		bool flag;
		if (getCurrentInfo == null)
		{
			flag = true;
		}
		else
		{
			EntityHandle entityHandle = getCurrentInfo.EntityHandle;
			flag = !((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault();
		}
		if (flag)
		{
			LockOnDebug.Clear();
			return;
		}
		global::Vector vector = global::Vector.Create();
		global::Vector vector2 = global::Vector.Create();
		base.GetSkillBoneLocation(getCurrentInfo.EntityHandle, getCurrentInfo.SocketName, this.TmpVector1);
		this.TmpVector1.Subtraction(base.ActorLocationProxy, this.TmpVector2);
		float distance = (float)this.TmpVector2.Size();
		float angle = 0f;
		if (!this.TmpVector2.IsNearlyZero(1E-08))
		{
			ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Quaternion(null).RotateVector(global::Vector.ForwardVectorProxy, vector);
			angle = (float)(Math.Acos(Math.Clamp(vector.CosineAngle2D(this.TmpVector2, 9.999999747378752E-05), -1.0, 1.0)) * 57.295780181884766);
			this.TmpVector2.Normalize(1E-08);
			vector2.DeepCopy(this.TmpVector2);
		}
		LockOnDebug.Clear();
		LockOnDebug.Push(getCurrentInfo);
		LockOnDebug.SetDebugString(getCurrentInfo, angle, distance, this.InputDirect, vector2);
		LockOnDebug.SetDebugArrow(getCurrentInfo, EColorType.Black);
	}

	// Token: 0x06019B27 RID: 105255 RVA: 0x00779A20 File Offset: 0x00777C20
	[NullableContext(2)]
	protected override void SetAndShowTarget(LockOnInfo bestInfo, bool showTarget)
	{
		base.SetCurrentInfo(bestInfo);
		if (bestInfo != null)
		{
			EntityHandle entityHandle = bestInfo.EntityHandle;
			if (((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault())
			{
				LockOnDebug.SetDebugArrow(bestInfo, EColorType.Green);
			}
		}
		if (showTarget)
		{
			this.SetShowTargetBySkill(base.GetCurrentTarget(), base.GetCurrentTargetSocketName());
		}
	}

	// Token: 0x06019B28 RID: 105256 RVA: 0x00779A80 File Offset: 0x00777C80
	public override bool SetShowTarget([Nullable(2)] EntityHandle target, string socketName = "", bool isHardLock = false)
	{
		CharacterActorComponent characterActorComponent;
		if (target == null)
		{
			characterActorComponent = null;
		}
		else
		{
			WorldEntity entity = target.Entity;
			characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		string text = socketName;
		if (target != null && target.Valid)
		{
			bool? flag;
			if (characterActorComponent2 == null)
			{
				flag = null;
			}
			else
			{
				CameraLockOnConfig cameraLockOnConfig = characterActorComponent2.CameraLockOnConfig;
				flag = ((cameraLockOnConfig != null) ? new bool?(cameraLockOnConfig.IsEnabled) : null);
			}
			bool? flag2 = flag;
			if (flag2.GetValueOrDefault() && !this.IsLookAt)
			{
				text = characterActorComponent2.CameraLockOnConfig.CameraLockOnBoneName;
			}
			if (!base.HasShowTarget)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null)
				{
					tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.拥有锁定目标"]));
				}
			}
			ControllerBase<SceneTeamController>.Instance.EmitEvent<int, string, bool>(base.Entity, EEventName.CharSetShowTarget, target.Id, text, isHardLock);
		}
		else if (base.HasShowTarget)
		{
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null)
			{
				tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.拥有锁定目标"]));
			}
			SceneTeamController instance = ControllerBase<SceneTeamController>.Instance;
			Entity entity2 = base.Entity;
			EEventName name = EEventName.CharEndShowTarget;
			EntityHandle showTarget = base.ShowTarget;
			instance.EmitEvent<int, string, bool>(entity2, name, (showTarget != null) ? showTarget.Id : -1, base.ShowTargetSocket, base.IsHardLock);
		}
		this.ShowTargetSetTime = Singleton<Time>.Instance.WorldTime;
		if (base.ShowTarget == target && base.ShowTargetSocket == text)
		{
			return true;
		}
		if (target == null)
		{
			this.ShowTargetInternal = null;
			this.ShowTargetSocketInternal = "";
			GlobalData.BpEventManager.小队技能目标改变时.Broadcast(null);
			return false;
		}
		this.ShowTargetInternal = target;
		this.ShowTargetSocketInternal = text;
		if (characterActorComponent2 != null)
		{
			GlobalData.BpEventManager.小队技能目标改变时.Broadcast(characterActorComponent2.Actor);
		}
		return true;
	}

	// Token: 0x06019B29 RID: 105257 RVA: 0x00779C24 File Offset: 0x00777E24
	private bool SetShowTargetBySkill([Nullable(2)] EntityHandle target, string socketName = "")
	{
		if (base.IsHardLock)
		{
			return false;
		}
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.新版控物"]))
		{
			return false;
		}
		if (target == null || !target.Valid || !target.Entity.Active)
		{
			return this.SetShowTarget(null, "", false);
		}
		CharacterActorComponent component = target.Entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			return this.SetShowTarget(target, socketName, false);
		}
		if (string.IsNullOrEmpty(socketName))
		{
			return component.LockOnParts.Count <= 0 && this.SetShowTarget(target, socketName, false);
		}
		LockOnPart valueOrDefault = component.LockOnParts.GetValueOrDefault(socketName);
		return valueOrDefault != null && valueOrDefault.SoftLockValid && this.SetShowTarget(target, socketName, false);
	}

	// Token: 0x06019B2A RID: 105258 RVA: 0x00779CE5 File Offset: 0x00777EE5
	protected override void ClearLockOnTarget()
	{
		base.ClearLockOnTarget();
		this.ExitLockDirection();
		this.ForceLookAt(null, false);
	}

	// Token: 0x06019B2B RID: 105259 RVA: 0x00779CFC File Offset: 0x00777EFC
	[NullableContext(2)]
	public void ForceLookAt(LockOnInfo target, bool enable)
	{
		if (enable)
		{
			LockOnInfo target2 = target;
			if (!LockOnUtils.IsValidLockOnTarget((target2 != null) ? target2.EntityHandle : null, null, null, false))
			{
				Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.LockOn, base.Entity, "无效的看向目标！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.IsLookAt)
			{
				LockOnInfo target3 = target;
				if (target3 == null || !target3.Different(base.GetCurrentInfo))
				{
					Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.LockOn, base.Entity, "重复进入看向状态！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
			}
			if (this.IgnoreInfos.Exists((LockOnInfo element) => !element.Different(target)))
			{
				Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.LockOn, base.Entity, "忽略锁定期间不能进入看向状态！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
		}
		bool isLookAt = this.IsLookAt;
		if (enable)
		{
			this.IsLookAt = true;
			if (base.IsHardLock)
			{
				LockOnInfo target4 = target;
				if (target4 == null || !target4.Different(base.GetCurrentInfo))
				{
					return;
				}
			}
			else
			{
				if (this.UnifiedStateComponent.DirectionState == ECharDirectionState.AimDirection)
				{
					base.SetCurrentInfo(target);
					return;
				}
				this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.LookAtDirection);
			}
			base.SetCurrentInfo(target);
			LockOnInfo target5 = target;
			EntityHandle target6 = (target5 != null) ? target5.EntityHandle : null;
			LockOnInfo target7 = target;
			this.SetShowTarget(target6, (target7 != null) ? target7.SocketName : null, false);
		}
		else if (this.IsLookAt)
		{
			LockOnInfo target8 = target;
			if (target8 == null || !target8.Different(base.GetCurrentInfo))
			{
				this.IsLookAt = false;
				if (!base.IsHardLock && this.UnifiedStateComponent.DirectionState == ECharDirectionState.LookAtDirection)
				{
					this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.FaceDirection);
				}
			}
		}
		bool isLookAt2 = this.IsLookAt;
	}

	// Token: 0x06019B2C RID: 105260 RVA: 0x00779ECC File Offset: 0x007780CC
	public bool TryRestoreLookAt()
	{
		if (!this.IsLookAt || base.IsHardLock)
		{
			return false;
		}
		LockOnInfo getCurrentInfo = base.GetCurrentInfo;
		if (!LockOnUtils.IsValidLockOnTarget((getCurrentInfo != null) ? getCurrentInfo.EntityHandle : null, null, null, false))
		{
			this.IsLookAt = false;
			return false;
		}
		this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.LookAtDirection);
		this.SetShowTarget((getCurrentInfo != null) ? getCurrentInfo.EntityHandle : null, (getCurrentInfo != null) ? getCurrentInfo.SocketName : null, false);
		return true;
	}

	// Token: 0x06019B2D RID: 105261 RVA: 0x00779F40 File Offset: 0x00778140
	public void ForceIgnore(LockOnInfo target, bool enable)
	{
		if (enable)
		{
			if (this.IgnoreInfos.Exists((LockOnInfo ignoreInfo) => !ignoreInfo.Different(target)))
			{
				Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.LockOn, base.Entity, "重复进入忽略锁定状态！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.IsLookAt)
			{
				LockOnInfo getCurrentInfo = base.GetCurrentInfo;
				if (getCurrentInfo != null && !getCurrentInfo.Different(target))
				{
					Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.LockOn, base.Entity, "看向状态期间不能忽略锁定！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
			}
		}
		if (enable)
		{
			this.IgnoreInfos.Add(target);
			if (base.GetCurrentInfo == null || target.Different(base.GetCurrentInfo))
			{
				return;
			}
			if (base.IsHardLock)
			{
				this.RestoreIgnoreTarget = base.GetCurrentInfo;
			}
			base.SetCurrentInfo(null);
			this.SetShowTarget(null, "", false);
			if (this.UnifiedStateComponent.DirectionState != ECharDirectionState.AimDirection)
			{
				this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.FaceDirection);
				return;
			}
		}
		else
		{
			if (this.IgnoreInfos.Exists((LockOnInfo ignoreInfo) => !ignoreInfo.Different(target)))
			{
				this.IgnoreInfos = this.IgnoreInfos.FindAll((LockOnInfo ignoreInfo) => ignoreInfo.Different(target));
			}
			if (this.RestoreIgnoreTarget != null && !this.RestoreIgnoreTarget.Different(target))
			{
				if (!base.IsHardLock && LockOnUtils.IsValidLockOnTarget(target.EntityHandle, null, null, false) && this.UnifiedStateComponent.DirectionState != ECharDirectionState.AimDirection)
				{
					base.SetCurrentInfo(this.RestoreIgnoreTarget);
					this.SetShowTarget(this.RestoreIgnoreTarget.EntityHandle, this.RestoreIgnoreTarget.SocketName, false);
					base.SVarHardLockedQueue.Push(this.RestoreIgnoreTarget);
					this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.LockDirection);
				}
				this.RestoreIgnoreTarget = null;
			}
		}
	}

	// Token: 0x06019B2E RID: 105262 RVA: 0x0077A124 File Offset: 0x00778324
	private void TickCurrentInfo()
	{
		if (this.IsLookAt)
		{
			return;
		}
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.新版控物"]))
		{
			this.ClearLockOnTarget();
			return;
		}
		LockOnInfo getCurrentInfo = base.GetCurrentInfo;
		bool flag;
		if (getCurrentInfo == null)
		{
			flag = false;
		}
		else
		{
			EntityHandle entityHandle = getCurrentInfo.EntityHandle;
			flag = ((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault();
		}
		if (flag && this.HardLockConfig != null)
		{
			Aki.Config.LockOnConfig value = this.HardLockConfig.Value;
			if (base.IsHardLock)
			{
				global::Vector tmpVector = this.TmpVector1;
				base.GetSkillBoneLocation(base.GetCurrentInfo.EntityHandle, base.GetCurrentInfo.SocketName, tmpVector);
				if (base.IsEntityContainsDisableHardLockTag(base.GetCurrentInfo.EntityHandle) || base.CannotBeDetected(value, base.GetCurrentInfo.EntityHandle, tmpVector))
				{
					this.ExitLockDirection();
					return;
				}
			}
			else if (base.IsEntityContainsDisableSoftLockTag(base.GetCurrentInfo.EntityHandle) || base.CannotBeDetected(value, base.GetCurrentInfo.EntityHandle, base.GetCurrentInfo.EntityHandle.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy))
			{
				base.SetCurrentInfo(null);
				this.SetShowTarget(null, "", false);
			}
		}
	}

	// Token: 0x06019B2F RID: 105263 RVA: 0x0077A264 File Offset: 0x00778464
	private void TickMoveDir()
	{
		if (this.InputComponent == null)
		{
			return;
		}
		global::Vector moveDirectionCache = this.InputComponent.GetMoveDirectionCache();
		if (this.InputComponent.GetCameraInput().Item1 != 0f || !this.MoveDirCache.Equals(moveDirectionCache, 1E-08))
		{
			this.MoveDirCache.Set(moveDirectionCache.X, moveDirectionCache.Y, 0.0);
			this.InputDirect.DeepCopy(this.ActorComp.InputDirectProxy);
			if (!this.MoveDirCache.IsNearlyZero(1E-08))
			{
				this.HasChangeInput = true;
			}
		}
		if (this.SpeedUpCleanTarget())
		{
			this.HasChangeInput = true;
		}
	}

	// Token: 0x06019B30 RID: 105264 RVA: 0x0077A318 File Offset: 0x00778518
	public void EnterLockDirection()
	{
		if (!this.IsLookAt)
		{
			if (base.IsHardLock)
			{
				return;
			}
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.方向状态.瞄准方向"]))
			{
				return;
			}
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.新版控物"]))
			{
				return;
			}
			if (ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.IsDisableResetFocus != 0f)
			{
				return;
			}
			if (this.IsForceLock)
			{
				LockOnInfo getCurrentInfo = base.GetCurrentInfo;
				bool flag;
				if (getCurrentInfo == null)
				{
					flag = false;
				}
				else
				{
					EntityHandle entityHandle = getCurrentInfo.EntityHandle;
					flag = ((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault();
				}
				if (flag && this.UnifiedStateComponent.DirectionState == ECharDirectionState.LockDirection)
				{
					return;
				}
			}
			this.DetectHardLockTargets(true);
			if (base.GetCurrentInfo == null)
			{
				base.ResetFocus();
				return;
			}
			this.CheckCount = 0;
		}
		base.SVarHardLockedQueue.Push(base.GetCurrentInfo);
		this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.LockDirection);
	}

	// Token: 0x06019B31 RID: 105265 RVA: 0x0077A41C File Offset: 0x0077861C
	public void ExitLockDirection()
	{
		if (base.IsHardLock)
		{
			if (this.IsForceLock)
			{
				return;
			}
			if (this.IsLookAt)
			{
				this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.LookAtDirection);
				return;
			}
			this.SetShowTarget(null, "", false);
			base.SVarHardLockedQueue.Clear();
			this.UnifiedStateComponent.SetDirectionState(ECharDirectionState.FaceDirection);
		}
	}

	// Token: 0x06019B32 RID: 105266 RVA: 0x0077A474 File Offset: 0x00778674
	private void OnBattleStateChanged(bool isInFight)
	{
		bool flag = this.IsCompensateLockDirection();
		if (!isInFight)
		{
			this.CompensateLockDirection();
			return;
		}
		if (flag)
		{
			this.ExitLockDirection();
			this.QuitCompensateLockDirection();
			this.EnterLockDirection();
		}
	}

	// Token: 0x06019B33 RID: 105267 RVA: 0x0077A4A8 File Offset: 0x007786A8
	private void CompensateLockDirection()
	{
		if (!base.IsHardLock)
		{
			return;
		}
		CharacterBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent == null)
		{
			return;
		}
		long buffId = 1001006001L;
		AddBuffParam addBuffParam = new AddBuffParam();
		CharacterBuffComponent buffComponent2 = this.BuffComponent;
		addBuffParam.InstigatorId = ((buffComponent2 != null) ? buffComponent2.CreatureDataId : 0L);
		addBuffParam.Reason = "角色强锁补偿buff";
		buffComponent.AddBuff(buffId, addBuffParam);
	}

	// Token: 0x06019B34 RID: 105268 RVA: 0x0077A500 File Offset: 0x00778700
	private bool QuitCompensateLockDirection()
	{
		if (this.IsCompensateLockDirection() && this.BuffComponent != null)
		{
			this.BuffComponent.RemoveBuff(1001006001L, -1, "角色强锁补偿buff", null, null, null);
			return true;
		}
		return false;
	}

	// Token: 0x06019B35 RID: 105269 RVA: 0x0077A552 File Offset: 0x00778752
	public bool IsCompensateLockDirection()
	{
		return this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["被动.功能.多波次锁定补偿"]);
	}

	// Token: 0x06019B36 RID: 105270 RVA: 0x0077A570 File Offset: 0x00778770
	private void DetectHardLockTargets(bool clearCache)
	{
		if (this.HardLockConfig == null)
		{
			return;
		}
		if (clearCache)
		{
			base.SVarHardLockedQueue.Clear();
		}
		Aki.Config.LockOnConfig value = this.HardLockConfig.Value;
		List<LockOnInfo> list = base.DetectAlternativeTargets(value, true);
		while (list.Count > 0)
		{
			bool flag = true;
			for (int i = 0; i < list.Count; i++)
			{
				if (!base.SVarHardLockedQueue.Has(list[i]))
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			base.SVarHardLockedQueue.Pop();
		}
		LockOnInfo lockOnInfo = base.FindTheBest(base.GetVipList(list, true), ESkillTargetPriority.镜头方向优先, true, value.ToleranceAngle, 0.0);
		base.SetCurrentInfo(lockOnInfo);
		if (lockOnInfo == null)
		{
			this.SetShowTarget(null, "", false);
			this.ExitLockDirection();
			return;
		}
		base.SVarHardLockedQueue.Push(lockOnInfo);
		this.SetShowTarget(lockOnInfo.EntityHandle, lockOnInfo.SocketName, true);
		this.TimeElapsedSinceLastLock = 0f;
		if (lockOnInfo != null)
		{
			EntityHandle entityHandle = lockOnInfo.EntityHandle;
			if (((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault())
			{
				LockOnDebug.SetDebugArrow(lockOnInfo, EColorType.Black);
			}
		}
	}

	// Token: 0x06019B37 RID: 105271 RVA: 0x0077A698 File Offset: 0x00778898
	protected override int GetSelfCamp()
	{
		return (int)this.ActorComp.Actor.Camp;
	}

	// Token: 0x06019B38 RID: 105272 RVA: 0x0077A6AC File Offset: 0x007788AC
	private void OnRestoreTargetTagAddOrRemove(int tagId, bool tagExist)
	{
		if (tagExist)
		{
			if (base.IsHardLock)
			{
				this.OldInfoAtRemoveDisableHardLockTag = base.GetCurrentInfo;
			}
			return;
		}
		LockOnInfo oldInfoAtRemoveDisableHardLockTag = this.OldInfoAtRemoveDisableHardLockTag;
		WorldEntity worldEntity;
		if (oldInfoAtRemoveDisableHardLockTag == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle entityHandle = oldInfoAtRemoveDisableHardLockTag.EntityHandle;
			worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (this.OldInfoAtRemoveDisableHardLockTag == null || (worldEntity2 == null || !worldEntity2.Valid))
		{
			return;
		}
		CharacterActorComponent component = worldEntity2.GetComponent<CharacterActorComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		FightCamera fightCamera = ModelBase<CameraModel>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.CheckPositionInScreen(component.ActorLocationProxy, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMinX, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMaxX, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMinY, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMaxY))
		{
			return;
		}
		if (!base.IsHardLock)
		{
			this.EnterLockDirection();
		}
		else
		{
			base.SetCurrentInfo(this.OldInfoAtRemoveDisableHardLockTag);
			this.SetShowTarget(base.GetCurrentInfo.EntityHandle, base.GetCurrentInfo.SocketName, false);
			base.SVarHardLockedQueue.Push(base.GetCurrentInfo);
		}
		this.OldInfoAtRemoveDisableHardLockTag = null;
	}

	// Token: 0x06019B39 RID: 105273 RVA: 0x0077A7D8 File Offset: 0x007789D8
	private void OnForceLockTagAddOrRemove(int tagId, bool tagExist)
	{
		RoleInfo? roleConfig;
		if (!tagExist)
		{
			roleConfig = this.CreatureComp.GetRoleConfig();
			int softLockConfigId = (roleConfig != null) ? roleConfig.GetValueOrDefault().LockOnDefaultId : 0;
			roleConfig = this.CreatureComp.GetRoleConfig();
			base.SetLockOnConfig(softLockConfigId, (roleConfig != null) ? roleConfig.GetValueOrDefault().LockOnLookOnId : 0);
			this.IsForceLock = false;
			if (this.ForceLockEntityAddDispose != null)
			{
				this.ForceLockEntityAddDispose();
				this.ForceLockEntityAddDispose = null;
			}
			this.ExitLockDirection();
			return;
		}
		if (this.ForceLockId == 0)
		{
			this.ForceLockId = ConfigCommonParamById.GetIntConfig("SwitchLockOnWithTag").GetValueOrDefault();
		}
		roleConfig = this.CreatureComp.GetRoleConfig();
		base.SetLockOnConfig((roleConfig != null) ? roleConfig.GetValueOrDefault().LockOnDefaultId : 0, this.ForceLockId);
		this.EnterLockDirection();
		this.IsForceLock = true;
		LockOnInfo getCurrentInfo = base.GetCurrentInfo;
		bool flag;
		if (getCurrentInfo == null)
		{
			flag = false;
		}
		else
		{
			EntityHandle entityHandle = getCurrentInfo.EntityHandle;
			bool? flag2 = (entityHandle != null) ? new bool?(entityHandle.Valid) : null;
			bool flag3 = false;
			flag = (flag2.GetValueOrDefault() == flag3 & flag2 != null);
		}
		if (flag && this.ForceLockEntityAddDispose == null)
		{
			this.ForceLockEntityAddDispose = EntityAddListener.ListenMonsterAddOnce(delegate(EntityHandle handle)
			{
				this.ForceLockEntityAddDispose = null;
				this.EnterLockDirection();
			}, base.Entity.Id);
		}
	}

	// Token: 0x06019B3A RID: 105274 RVA: 0x0077A934 File Offset: 0x00778B34
	private void SendRequestMessageIfHardLockStateChanged()
	{
		bool isHardLock = base.IsHardLock;
		if (this.IsHardLockInternal != isHardLock)
		{
			CombatNet instance = Singleton<CombatNet>.Instance;
			EPushMessageId id = isHardLock ? EPushMessageId.EnterViewDirectionPush : EPushMessageId.ExitViewDirectionPush;
			Entity entity = base.Entity;
			IMessage message2;
			if (!isHardLock)
			{
				IMessage message = ExitViewDirectionPush.Create();
				message2 = message;
			}
			else
			{
				IMessage message = EnterViewDirectionPush.Create();
				message2 = message;
			}
			instance.Send(id, entity, message2, null, null, null);
			this.IsHardLockInternal = isHardLock;
		}
	}

	// Token: 0x06019B3B RID: 105275 RVA: 0x0077A9A8 File Offset: 0x00778BA8
	public void RefreshCurrentLockState([Nullable(2)] EntityHandle target, string refreshSocket = "")
	{
		LockOnInfo getCurrentInfo = base.GetCurrentInfo;
		if (((getCurrentInfo != null) ? getCurrentInfo.EntityHandle : null) != target)
		{
			return;
		}
		CharacterActorComponent characterActorComponent;
		if (target == null)
		{
			characterActorComponent = null;
		}
		else
		{
			WorldEntity entity = target.Entity;
			characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		if (characterActorComponent2 == null)
		{
			return;
		}
		LockOnInfo getCurrentInfo2 = base.GetCurrentInfo;
		string text = (getCurrentInfo2 != null) ? getCurrentInfo2.SocketName : null;
		if (!string.IsNullOrEmpty(text) && text == refreshSocket && characterActorComponent2.LockOnParts.ContainsKey(text))
		{
			LockOnPart lockOnPart = characterActorComponent2.LockOnParts[text];
			if (!lockOnPart.HardLockValid)
			{
				this.ExitLockDirection();
			}
			if (!lockOnPart.SoftLockValid)
			{
				this.SetShowTarget(null, "", false);
			}
		}
	}

	// Token: 0x06019B3C RID: 105276 RVA: 0x0077AA4C File Offset: 0x00778C4C
	public bool SpeedUpCleanTarget()
	{
		CharacterMoveComponent component = base.Entity.GetComponent<CharacterMoveComponent>();
		return component != null && component.Valid && component.Speed > 70f && !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]);
	}

	// Token: 0x06019B3D RID: 105277 RVA: 0x0077AA9C File Offset: 0x00778C9C
	public void ResetTarget()
	{
		if (this.IsLookAt || !base.IsHardLock)
		{
			return;
		}
		this.DetectHardLockTargets(false);
	}

	// Token: 0x06019B3E RID: 105278 RVA: 0x0077AAB8 File Offset: 0x00778CB8
	public bool ChangeShowTarget(Vector2D inputDirect, float angleCoefficient, float distCoefficient)
	{
		if (this.IsLookAt || !base.IsHardLock || this.HardLockConfig == null || base.GetCurrentInfo == null)
		{
			return false;
		}
		List<LockOnInfo> list = base.DetectAlternativeTargets(this.HardLockConfig.Value, true);
		global::Vector actorLocationProxy = base.ActorLocationProxy;
		base.GetSkillBoneLocation(base.GetCurrentInfo.EntityHandle, base.GetCurrentInfo.SocketName, this.TmpVector1);
		this.TmpVector2.DeepCopy(actorLocationProxy);
		this.TmpVector2.Z = this.TmpVector1.Z;
		this.TmpVector1.SubtractionEqual(actorLocationProxy);
		Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector1, global::Vector.UpVectorProxy, this.InverseQuat);
		this.InverseQuat.Inverse(this.InverseQuat);
		double num = inputDirect.SizeSquared();
		LockOnInfo lockOnInfo = null;
		double num2 = 1E+50;
		for (int i = 0; i < list.Count; i++)
		{
			LockOnInfo lockOnInfo2 = list[i];
			if (LockOnUtils.IsValidLockOnTarget(lockOnInfo2.EntityHandle, null, null, false) && !lockOnInfo2.Equal(base.GetCurrentInfo))
			{
				base.GetSkillBoneLocation(lockOnInfo2.EntityHandle, lockOnInfo2.SocketName, this.TmpVector1);
				this.TmpVector1.SubtractionEqual(this.TmpVector2);
				this.InverseQuat.RotateVector(this.TmpVector1, this.TmpVector1);
				if (Math.Abs(this.TmpVector1.X) >= 1E-08 || Math.Abs(this.TmpVector1.Y) >= 1E-08)
				{
					double num3 = Math.Atan2(this.TmpVector1.Y, this.TmpVector1.X) * 57.295780181884766;
					double num4 = Math.Asin(this.TmpVector1.Z / this.TmpVector1.Size()) * 57.295780181884766;
					double num5 = Math.Sqrt(num3 * num3 + num4 * num4);
					this.TmpVector2D.X = num3;
					this.TmpVector2D.Y = num4;
					double num6 = this.TmpVector2D.DotProduct(inputDirect);
					if (num6 >= 0.0)
					{
						double num7 = Math.Acos(num6 / Math.Sqrt(this.TmpVector2D.SizeSquared() * num)) * 57.295780181884766;
						double num8 = (double)angleCoefficient * num7 / 180.0 + (double)distCoefficient * num5;
						if (num8 < num2)
						{
							num2 = num8;
							lockOnInfo = lockOnInfo2;
						}
					}
				}
			}
		}
		if (lockOnInfo != null)
		{
			base.SetCurrentInfo(lockOnInfo);
			this.SetShowTarget(lockOnInfo.EntityHandle, lockOnInfo.SocketName, true);
			LockOnDebug.SetDebugArrow(lockOnInfo, EColorType.Black);
			return true;
		}
		return false;
	}

	// Token: 0x06019B3F RID: 105279 RVA: 0x0077AD66 File Offset: 0x00778F66
	[NullableContext(2)]
	public LockOnInfo GetPredictedLockOnTarget()
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.预测锁定"]))
		{
			return this.PredictedInfo;
		}
		return null;
	}

	// Token: 0x06019B40 RID: 105280 RVA: 0x0077AD93 File Offset: 0x00778F93
	[NullableContext(2)]
	public void SetPredictedLockOnTarget(LockOnInfo predictedInfo)
	{
		this.PredictedInfo = predictedInfo;
	}

	// Token: 0x06019B41 RID: 105281 RVA: 0x0077AD9C File Offset: 0x00778F9C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterLockOnComponent characterLockOnComponent = (CharacterLockOnComponent)componentTemplate;
		if (base.CanResetComponentProperty("StatTickMoveDir") && characterLockOnComponent.StatTickMoveDir != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatTickMoveDir), "StatTickMoveDir"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("StatTickCurrentInfo") && characterLockOnComponent.StatTickCurrentInfo != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatTickCurrentInfo), "StatTickCurrentInfo"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("StatCheck") && characterLockOnComponent.StatCheck != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatCheck), "StatCheck"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterLockOnComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComponent"))
		{
			if (characterLockOnComponent.UnifiedStateComponent == null)
			{
				this.UnifiedStateComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputComponent"))
		{
			if (characterLockOnComponent.InputComponent == null)
			{
				this.InputComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComponent), "InputComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (characterLockOnComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagListeners") && characterLockOnComponent.TagListeners != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.TagListeners), "TagListeners"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("MoveDirCache") && characterLockOnComponent.MoveDirCache != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.MoveDirCache), "MoveDirCache"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsForceLock"))
		{
			this.IsForceLock = characterLockOnComponent.IsForceLock;
		}
		if (base.CanResetComponentProperty("ForceLockId"))
		{
			this.ForceLockId = characterLockOnComponent.ForceLockId;
		}
		if (base.CanResetComponentProperty("ForceLockEntityAddDispose"))
		{
			if (characterLockOnComponent.ForceLockEntityAddDispose == null)
			{
				this.ForceLockEntityAddDispose = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TCbDispose>(this.ForceLockEntityAddDispose), "ForceLockEntityAddDispose"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsHardLockInternal"))
		{
			this.IsHardLockInternal = characterLockOnComponent.IsHardLockInternal;
		}
		if (base.CanResetComponentProperty("PredictedInfo"))
		{
			if (characterLockOnComponent.PredictedInfo == null)
			{
				this.PredictedInfo = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LockOnInfo>(this.PredictedInfo), "PredictedInfo"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400CCB0 RID: 52400
	private const string LOCK_DIR_COMPENSATE_REASON = "角色强锁补偿buff";

	// Token: 0x0400CCB1 RID: 52401
	private readonly Stat StatTickMoveDir = Stat.Create("CharacterLockOnComponent.StatTickMoveDir", "", "");

	// Token: 0x0400CCB2 RID: 52402
	private readonly Stat StatTickCurrentInfo = Stat.Create("CharacterLockOnComponent.StatTickCurrentInfo", "", "");

	// Token: 0x0400CCB3 RID: 52403
	private readonly Stat StatCheck = Stat.Create("CharacterLockOnComponent.StatCheck", "", "");

	// Token: 0x0400CCB4 RID: 52404
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CCB5 RID: 52405
	[Nullable(2)]
	private CharacterUnifiedStateComponent UnifiedStateComponent;

	// Token: 0x0400CCB6 RID: 52406
	[Nullable(2)]
	private CharacterInputComponent InputComponent;

	// Token: 0x0400CCB7 RID: 52407
	[Nullable(2)]
	private CharacterBuffComponent BuffComponent;

	// Token: 0x0400CCB8 RID: 52408
	private readonly List<ITagTask> TagListeners = new List<ITagTask>();

	// Token: 0x0400CCB9 RID: 52409
	private readonly global::Vector MoveDirCache = global::Vector.Create();

	// Token: 0x0400CCBA RID: 52410
	private bool IsForceLock;

	// Token: 0x0400CCBB RID: 52411
	private int ForceLockId;

	// Token: 0x0400CCBC RID: 52412
	[Nullable(2)]
	private TCbDispose ForceLockEntityAddDispose;

	// Token: 0x0400CCBD RID: 52413
	private bool IsHardLockInternal;

	// Token: 0x0400CCBE RID: 52414
	[Nullable(2)]
	private LockOnInfo PredictedInfo;
}
