using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F91 RID: 8081
[NullableContext(2)]
[Nullable(0)]
public class LockCursorHandle : HudUnitHandleBase
{
	// Token: 0x0600F25F RID: 62047 RVA: 0x00423B80 File Offset: 0x00421D80
	protected override void OnAddEvents()
	{
		ControllerBase<InputDistributeController>.Instance.BindAction("锁定目标", new TInputHandle<InputDistributeDefine.EActionType>(this.OnLockInput));
		Singleton<EventSystem>.Instance.Add<bool, EBehaviorType>(EEventName.OnPressOrReleaseBehaviorButton, new Action<bool, EBehaviorType>(this.OnPressOrReleaseBehaviorButton));
		Singleton<EventSystem>.Instance.Add<bool, int>(EEventName.BreakWeaknessPanelLogicVisibleChange, new Action<bool, int>(this.OnBreakWeaknessPanelLogicVisibleChange));
	}

	// Token: 0x0600F260 RID: 62048 RVA: 0x00423BE0 File Offset: 0x00421DE0
	protected override void OnRemoveEvents()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAction("锁定目标", new TInputHandle<InputDistributeDefine.EActionType>(this.OnLockInput));
		Singleton<EventSystem>.Instance.Remove<bool, EBehaviorType>(EEventName.OnPressOrReleaseBehaviorButton, new Action<bool, EBehaviorType>(this.OnPressOrReleaseBehaviorButton));
		Singleton<EventSystem>.Instance.Remove<bool, int>(EEventName.BreakWeaknessPanelLogicVisibleChange, new Action<bool, int>(this.OnBreakWeaknessPanelLogicVisibleChange));
	}

	// Token: 0x0600F261 RID: 62049 RVA: 0x00423C40 File Offset: 0x00421E40
	[NullableContext(1)]
	private void OnLockInput(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				this.HasLockCursorUnitBeforeGamepadLock = (this.LockCursorUnit != null);
			}
			else
			{
				this.ReleaseGamepadLock = true;
			}
		}
		if (this.LockCursorUnit == null)
		{
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		object obj;
		if (getCurrentEntity == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			obj = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null && obj2.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止锁定目标"]))
		{
			return;
		}
		if (actionType == InputDistributeDefine.EActionType.Press)
		{
			this.ActivateUnlockTimeDown();
			return;
		}
		this.DeactivateUnlockTimeDown();
	}

	// Token: 0x0600F262 RID: 62050 RVA: 0x00423CCD File Offset: 0x00421ECD
	private void OnPressOrReleaseBehaviorButton(bool bPress, EBehaviorType behaviorType)
	{
		if (behaviorType != EBehaviorType.LockTarget)
		{
			return;
		}
		if (bPress)
		{
			this.ActivateUnlockTimeDown();
			return;
		}
		this.DeactivateUnlockTimeDown();
	}

	// Token: 0x0600F263 RID: 62051 RVA: 0x00423CE5 File Offset: 0x00421EE5
	private void OnBreakWeaknessPanelLogicVisibleChange(bool logicVisible, int monsterEntityId)
	{
		if (logicVisible)
		{
			this.LockExecutionEntityId = monsterEntityId;
			return;
		}
		this.LockExecutionEntityId = 0;
	}

	// Token: 0x0600F264 RID: 62052 RVA: 0x00423CF9 File Offset: 0x00421EF9
	protected override void OnDestroyed()
	{
		this.ClearTargetInfo();
		this.LockCursorUnit = null;
	}

	// Token: 0x0600F265 RID: 62053 RVA: 0x00423D08 File Offset: 0x00421F08
	private void ActivateUnlockTimeDown()
	{
		LockCursorUnit lockCursorUnit = this.LockCursorUnit;
		if (lockCursorUnit == null || !lockCursorUnit.IsForceLockState())
		{
			return;
		}
		float time = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<CharacterInputComponent>().GetBpInputComp().UnlockLongPressTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.LockCursorUnit.ActivateUnlockTimeDown(time);
	}

	// Token: 0x0600F266 RID: 62054 RVA: 0x00423D64 File Offset: 0x00421F64
	private void DeactivateUnlockTimeDown()
	{
		LockCursorUnit lockCursorUnit = this.LockCursorUnit;
		if (lockCursorUnit == null)
		{
			return;
		}
		lockCursorUnit.DeactivateUnlockTimeDown();
	}

	// Token: 0x0600F267 RID: 62055 RVA: 0x00423D78 File Offset: 0x00421F78
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (this.IsLoading)
		{
			return;
		}
		this.RefreshTargetInfo();
		if (this.ReleaseGamepadLock)
		{
			this.ReleaseGamepadLock = false;
			if (!this.HasLockCursorUnitBeforeGamepadLock && this.TmpTargetEntity == null && !this.IsAim())
			{
				ControllerBase<BattleUiControl>.Instance.ResetFocus();
			}
		}
		if (this.TmpTargetEntity == null || this.TmpTargetEntity.Id == this.LockExecutionEntityId)
		{
			this.Deactivate();
			return;
		}
		FVectorDouble? worldLocation = this.GetWorldLocation(this.TmpTargetEntity, this.TmpTargetSocketName);
		if (worldLocation == null)
		{
			this.Deactivate();
			return;
		}
		if (!HudUnitUtils.PositionUtil.ProjectWorldToScreen(worldLocation.Value, this.ScreenPos))
		{
			this.Deactivate();
			return;
		}
		this.Activate();
		if (this.LockCursorUnit != null)
		{
			this.LockCursorUnit.Refresh(this.TmpTargetEntity, this.TmpSelfEntity, this.TmpIsPlayerLock);
			this.LockCursorUnit.GetRootItem().SetAnchorOffset(this.ScreenPos.ToUeVector2D(false));
		}
		this.ClearTargetInfo();
	}

	// Token: 0x0600F268 RID: 62056 RVA: 0x00423E80 File Offset: 0x00422080
	private bool IsAim()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			return false;
		}
		CharacterUnifiedStateComponent component = getCurrentEntity.Entity.GetComponent<CharacterUnifiedStateComponent>();
		return ((component != null) ? new ECharDirectionState?(component.DirectionState) : null).GetValueOrDefault() == ECharDirectionState.AimDirection;
	}

	// Token: 0x0600F269 RID: 62057 RVA: 0x00423EDA File Offset: 0x004220DA
	public void Activate()
	{
		if (this.LockCursorUnit != null)
		{
			this.LockCursorUnit.Activate();
			return;
		}
		if (this.IsLoading)
		{
			return;
		}
		this.IsLoading = true;
		this.LoadLockCursorUnit().Forget();
	}

	// Token: 0x0600F26A RID: 62058 RVA: 0x00423F0C File Offset: 0x0042210C
	private UniTask LoadLockCursorUnit()
	{
		LockCursorHandle.<LoadLockCursorUnit>d__22 <LoadLockCursorUnit>d__;
		<LoadLockCursorUnit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadLockCursorUnit>d__.<>4__this = this;
		<LoadLockCursorUnit>d__.<>1__state = -1;
		<LoadLockCursorUnit>d__.<>t__builder.Start<LockCursorHandle.<LoadLockCursorUnit>d__22>(ref <LoadLockCursorUnit>d__);
		return <LoadLockCursorUnit>d__.<>t__builder.Task;
	}

	// Token: 0x0600F26B RID: 62059 RVA: 0x00423F4F File Offset: 0x0042214F
	public void Deactivate()
	{
		this.ClearTargetInfo();
		if (this.LockCursorUnit == null)
		{
			return;
		}
		this.LockCursorUnit.Deactivate();
	}

	// Token: 0x0600F26C RID: 62060 RVA: 0x00423F6C File Offset: 0x0042216C
	private void RefreshTargetInfo()
	{
		this.ClearTargetInfo();
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			return;
		}
		ShowTargetInfo targetInfo = getCurrentEntity.Entity.CheckGetComponent<CharacterLockOnComponent>().GetTargetInfo();
		EntityHandle showTarget = targetInfo.ShowTarget;
		if (showTarget != null && showTarget.Valid)
		{
			this.TmpTargetEntity = targetInfo.ShowTarget;
			this.TmpTargetSocketName = targetInfo.SocketName;
			this.TmpSelfEntity = getCurrentEntity;
			this.TmpIsPlayerLock = true;
			return;
		}
		RoleDriveVehicleComponent component = getCurrentEntity.Entity.GetComponent<RoleDriveVehicleComponent>();
		BaseLockOnComponent baseLockOnComponent;
		if (component == null)
		{
			baseLockOnComponent = null;
		}
		else
		{
			Entity vehicleEntity = component.VehicleEntity;
			baseLockOnComponent = ((vehicleEntity != null) ? vehicleEntity.GetComponent<BaseLockOnComponent>() : null);
		}
		BaseLockOnComponent baseLockOnComponent2 = baseLockOnComponent;
		if (baseLockOnComponent2 != null)
		{
			ShowTargetInfo targetInfo2 = baseLockOnComponent2.GetTargetInfo();
			EntityHandle showTarget2 = targetInfo2.ShowTarget;
			if (showTarget2 != null && showTarget2.Valid)
			{
				this.TmpTargetEntity = targetInfo2.ShowTarget;
				this.TmpTargetSocketName = targetInfo2.SocketName;
				return;
			}
		}
		BaseTagComponent component2 = getCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component2 != null && component2.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"]))
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(getCurrentEntity.Entity, ESummonType.ConcomitantVision, 1);
			if (summonedEntity != null && summonedEntity.Valid)
			{
				CharacterLockOnComponent characterLockOnComponent = summonedEntity.Entity.CheckGetComponent<CharacterLockOnComponent>();
				if (characterLockOnComponent != null)
				{
					ShowTargetInfo targetInfo3 = characterLockOnComponent.GetTargetInfo();
					EntityHandle showTarget3 = targetInfo3.ShowTarget;
					if (showTarget3 != null && showTarget3.Valid)
					{
						this.TmpTargetEntity = targetInfo3.ShowTarget;
						this.TmpTargetSocketName = targetInfo3.SocketName;
						this.TmpSelfEntity = summonedEntity;
					}
				}
			}
		}
	}

	// Token: 0x0600F26D RID: 62061 RVA: 0x004240D9 File Offset: 0x004222D9
	private void ClearTargetInfo()
	{
		this.TmpTargetEntity = null;
		this.TmpTargetSocketName = null;
		this.TmpSelfEntity = null;
		this.TmpIsPlayerLock = false;
	}

	// Token: 0x0600F26E RID: 62062 RVA: 0x004240F8 File Offset: 0x004222F8
	private FVectorDouble? GetWorldLocation(EntityHandle targetEntity, string targetSocketName)
	{
		if (targetEntity == null || !targetEntity.Valid)
		{
			return null;
		}
		TsBaseCharacter tsBaseCharacter = targetEntity.Entity.GetComponent<BaseActorComponent>().Owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return null;
		}
		USkeletalMeshComponent mesh = tsBaseCharacter.Mesh;
		FName inSocketName = LockCursorHandle.HIT_CASE_SOCKET;
		if (!string.IsNullOrEmpty(targetSocketName))
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName(targetSocketName);
			if (dynamicFName != null)
			{
				FName value = dynamicFName.Value;
				if (mesh.DoesSocketExist(value))
				{
					inSocketName = value;
				}
			}
		}
		else if (!mesh.DoesSocketExist(inSocketName))
		{
			inSocketName = LockCursorHandle.HIT_CASE_SOCKET;
		}
		return new FVectorDouble?(mesh.D_GetSocketLocation(inSocketName));
	}

	// Token: 0x04007465 RID: 29797
	private static readonly FName HIT_CASE_SOCKET = new FName("HitCase");

	// Token: 0x04007466 RID: 29798
	[Nullable(1)]
	private readonly Vector2D ScreenPos = new Vector2D();

	// Token: 0x04007467 RID: 29799
	private LockCursorUnit LockCursorUnit;

	// Token: 0x04007468 RID: 29800
	private bool IsLoading;

	// Token: 0x04007469 RID: 29801
	private bool ReleaseGamepadLock;

	// Token: 0x0400746A RID: 29802
	private bool HasLockCursorUnitBeforeGamepadLock;

	// Token: 0x0400746B RID: 29803
	private int LockExecutionEntityId;

	// Token: 0x0400746C RID: 29804
	private EntityHandle TmpTargetEntity;

	// Token: 0x0400746D RID: 29805
	private string TmpTargetSocketName;

	// Token: 0x0400746E RID: 29806
	private EntityHandle TmpSelfEntity;

	// Token: 0x0400746F RID: 29807
	private bool TmpIsPlayerLock;
}
