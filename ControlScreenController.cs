using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A8D RID: 6797
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ControlScreenController : UiControllerBase<ControlScreenController>
{
	// Token: 0x0600C29E RID: 49822 RVA: 0x00334BDC File Offset: 0x00332DDC
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600C29F RID: 49823 RVA: 0x00334BE0 File Offset: 0x00332DE0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoadCompleted));
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleGoDown, new Action<int>(this.OnRoleGoDown));
		ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9
		}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
	}

	// Token: 0x0600C2A0 RID: 49824 RVA: 0x00334C6C File Offset: 0x00332E6C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoadCompleted));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleGoDown, new Action<int>(this.OnRoleGoDown));
		Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
		ControllerBase<InputDistributeController>.Instance.UnBindTouches(new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9
		}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
	}

	// Token: 0x0600C2A1 RID: 49825 RVA: 0x00334D04 File Offset: 0x00332F04
	private void TouchTrigger(bool bTouchPress, int touchId)
	{
		TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData((EFingerIndex)touchId);
		if (touchFingerData == null)
		{
			return;
		}
		ControlScreenModel instance = ModelBase<ControlScreenModel>.Instance;
		if (bTouchPress)
		{
			ULGUIPointerEventData pointerEventData = touchFingerData.GetPointerEventData();
			USceneComponent usceneComponent = (pointerEventData != null) ? pointerEventData.enterComponent : null;
			USceneComponent usceneComponent2 = (pointerEventData != null) ? pointerEventData.pressComponent : null;
			if (!touchFingerData.IsTouchEmpty() && !touchFingerData.IsTouchComponentContainTag(ControlScreenDefine.ignoreTag))
			{
				touchFingerData.GetFingerIndex();
				if (pointerEventData != null)
				{
					bool isOpenJoystickLog = ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog;
					return;
				}
				bool isOpenJoystickLog2 = ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog;
				return;
			}
			else
			{
				instance.AddTouchEmptyFingerData(touchFingerData);
				if (instance.IsDoubleTouch(touchId) && instance.IsDoubleTouchResetCameraComponent(touchFingerData, ControlScreenDefine.resetCameraTag))
				{
					ControllerBase<BattleUiControl>.Instance.ResetFocus();
				}
				instance.SetCurrentTouchTimeStamp(Singleton<TimeUtil>.Instance.GetServerTimeStamp());
				instance.SetCurrentTouchId(touchId);
				if (usceneComponent != null)
				{
					instance.SetCurrentEnterComponent(usceneComponent);
				}
				if (usceneComponent2 != null)
				{
					instance.SetCurrentPressComponent(usceneComponent2);
					return;
				}
			}
		}
		else
		{
			instance.RemoveTouchEmptyFingerData(touchFingerData);
		}
	}

	// Token: 0x0600C2A2 RID: 49826 RVA: 0x00334DE8 File Offset: 0x00332FE8
	private void TouchMoved(int touchId)
	{
		ControlScreenModel instance = ModelBase<ControlScreenModel>.Instance;
		int touchEmptyFingerDataCount = instance.GetTouchEmptyFingerDataCount();
		if (touchEmptyFingerDataCount == 1)
		{
			this.RefreshCameraRotation((EFingerIndex)touchId);
			return;
		}
		if (touchEmptyFingerDataCount != 2)
		{
			return;
		}
		TouchFingerData[] touchEmptyFingerDataByCount = instance.GetTouchEmptyFingerDataByCount(2);
		TouchFingerData touchFingerData = touchEmptyFingerDataByCount[0];
		TouchFingerData touchFingerData2 = touchEmptyFingerDataByCount[1];
		EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
		EFingerIndex fingerIndex2 = touchFingerData2.GetFingerIndex();
		this.RefreshCameraSpringLength(fingerIndex, fingerIndex2);
	}

	// Token: 0x0600C2A3 RID: 49827 RVA: 0x00334E3C File Offset: 0x0033303C
	private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		InputDistributeDefine.ETouchType touchType = touchData.TouchType;
		int touchId = int.Parse(touchIdName);
		switch (touchType)
		{
		case InputDistributeDefine.ETouchType.TouchBegin:
			this.TouchTrigger(true, touchId);
			return;
		case InputDistributeDefine.ETouchType.TouchEnd:
			this.TouchTrigger(false, touchId);
			return;
		case InputDistributeDefine.ETouchType.TouchMove:
			this.TouchMoved(touchId);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600C2A4 RID: 49828 RVA: 0x00334E84 File Offset: 0x00333084
	public bool RefreshCameraRotation(EFingerIndex fingerIndex)
	{
		if (!this.CanCameraRotationInput())
		{
			bool isOpenJoystickLog = ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog;
			return false;
		}
		TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData(fingerIndex);
		if (touchFingerData == null)
		{
			return false;
		}
		if (!touchFingerData.IsInTouch())
		{
			return false;
		}
		if (!ModelBase<ControlScreenModel>.Instance.IsTouchEmpty(fingerIndex))
		{
			return false;
		}
		this.ExecuteCameraRotation(fingerIndex);
		return true;
	}

	// Token: 0x0600C2A5 RID: 49829 RVA: 0x00334ED8 File Offset: 0x003330D8
	public bool RefreshCameraSpringLength(EFingerIndex aFingerIndex, EFingerIndex bFingerIndex)
	{
		if (!this.CanCameraZoomInput())
		{
			return false;
		}
		this.ExecuteCameraZoom(aFingerIndex, bFingerIndex);
		return true;
	}

	// Token: 0x0600C2A6 RID: 49830 RVA: 0x00334EF0 File Offset: 0x003330F0
	public void ExecuteCameraRotation(EFingerIndex fingerIndex)
	{
		ValueTuple<float, float>? fingerDirection = Singleton<TouchFingerManager>.Instance.GetFingerDirection(fingerIndex);
		if (fingerDirection == null)
		{
			return;
		}
		float rotationScreenRate = ModelBase<ControlScreenModel>.Instance.GetRotationScreenRate();
		float value = fingerDirection.Value.Item1 * rotationScreenRate;
		float value2 = fingerDirection.Value.Item2 * rotationScreenRate;
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Turn, value, true);
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.LookUp, value2, true);
	}

	// Token: 0x0600C2A7 RID: 49831 RVA: 0x00334F60 File Offset: 0x00333160
	public void ExecuteCameraZoom(EFingerIndex aFingerIndex, EFingerIndex bFingerIndex)
	{
		ControlScreenModel instance = ModelBase<ControlScreenModel>.Instance;
		float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(aFingerIndex, bFingerIndex);
		float value = Singleton<MathUtils>.Instance.RangeClamp(fingerExpandCloseValue, instance.MinTouchMoveDifference, instance.MaxTouchMoveDifference, instance.MinTouchMoveValue, instance.MaxTouchMoveValue);
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Zoom, value, true);
	}

	// Token: 0x0600C2A8 RID: 49832 RVA: 0x00334FB8 File Offset: 0x003331B8
	public void OnFormationLoadCompleted()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return;
		}
		ModelBase<ControlScreenModel>.Instance.RefreshRotationScreenRate();
		this.AddRoleEvents(getCurrentEntity.Entity);
	}

	// Token: 0x0600C2A9 RID: 49833 RVA: 0x00334FEC File Offset: 0x003331EC
	public void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return;
		}
		ModelBase<ControlScreenModel>.Instance.RefreshRotationScreenRate();
		this.AddRoleEvents(getCurrentEntity.Entity);
	}

	// Token: 0x0600C2AA RID: 49834 RVA: 0x00335020 File Offset: 0x00333220
	public void OnRoleGoDown(int creatureDataId)
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity((long)creatureDataId);
		if (entity == null)
		{
			return;
		}
		this.RemoveRoleEvents(entity);
	}

	// Token: 0x0600C2AB RID: 49835 RVA: 0x00335048 File Offset: 0x00333248
	public void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		if (component.GetEntityType() != EEntityType.Player)
		{
			return;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int playerId = component.GetPlayerId();
		if (!(id.GetValueOrDefault() == playerId & id != null))
		{
			return;
		}
		this.RemoveRoleEvents(handle);
	}

	// Token: 0x0600C2AC RID: 49836 RVA: 0x003350A4 File Offset: 0x003332A4
	private void AddRoleEvents(Entity entity)
	{
		int id = entity.Id;
		if (this.CurrentAddEventEntityId == id)
		{
			return;
		}
		this.CurrentAddEventEntityId = id;
		if (entity == null)
		{
			return;
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.OnCharCameraStateChanged)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.OnCharCameraStateChanged));
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(id);
		if (entityById != null && !Singleton<EventSystem>.Instance.HasWithTarget(entityById, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
		{
			Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, entityById, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
	}

	// Token: 0x0600C2AD RID: 49837 RVA: 0x00335154 File Offset: 0x00333354
	private void RemoveRoleEvents(EntityHandle handle)
	{
		if (Singleton<EventSystem>.Instance.HasWithTarget(handle.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.OnCharCameraStateChanged)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(handle.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.OnCharCameraStateChanged));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTargetUseKey(this, handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
	}

	// Token: 0x0600C2AE RID: 49838 RVA: 0x003351E2 File Offset: 0x003333E2
	public void OnCharCameraStateChanged(ECharDirectionState oldMoveState, ECharDirectionState newMoveState)
	{
		if (newMoveState == oldMoveState)
		{
			return;
		}
		ModelBase<ControlScreenModel>.Instance.RefreshRotationScreenRate();
	}

	// Token: 0x0600C2AF RID: 49839 RVA: 0x003351F3 File Offset: 0x003333F3
	private bool CanCameraRotationInput()
	{
		return ControllerBase<InputDistributeController>.Instance.IsAllowFightCameraRotationInput();
	}

	// Token: 0x0600C2B0 RID: 49840 RVA: 0x003351FF File Offset: 0x003333FF
	private bool CanCameraZoomInput()
	{
		return ControllerBase<InputDistributeController>.Instance.IsAllowFightCameraZoomInput();
	}

	// Token: 0x04005D46 RID: 23878
	private int CurrentAddEventEntityId;
}
