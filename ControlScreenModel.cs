using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A8F RID: 6799
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ControlScreenModel : ModelBase<ControlScreenModel>
{
	// Token: 0x0600C2B4 RID: 49844 RVA: 0x0033523C File Offset: 0x0033343C
	protected override bool OnInit()
	{
		this.MinTouchMoveDifference = (float)ConfigCommonParamById.GetIntConfig("MinTouchMoveDifference").Value;
		this.MaxTouchMoveDifference = (float)ConfigCommonParamById.GetIntConfig("MaxTouchMoveDifference").Value;
		this.MaxTouchMoveValue = ConfigCommonParamById.GetFloatConfig("MaxTouchMoveValue").Value;
		this.MinTouchMoveValue = ConfigCommonParamById.GetFloatConfig("MinTouchMoveValue").Value;
		this.CommonRotationScreenRateInternal = ConfigCommonParamById.GetFloatConfig("CommonRotationRate").Value;
		this.ArmRotationScreenRateInternal = ConfigCommonParamById.GetFloatConfig("ArmRotationRate").Value;
		this.DoubleTouchTime = ConfigCommonParamById.GetIntConfig("DoubleTouchTime").Value;
		return true;
	}

	// Token: 0x0600C2B5 RID: 49845 RVA: 0x003352F9 File Offset: 0x003334F9
	public void SetCurrentTouchTimeStamp(Number timeStamp)
	{
		this.CurrentTouchTimeStamp = timeStamp;
	}

	// Token: 0x0600C2B6 RID: 49846 RVA: 0x00335302 File Offset: 0x00333502
	public void SetCurrentTouchId(int touchId)
	{
		this.CurrentTouchId = touchId;
	}

	// Token: 0x0600C2B7 RID: 49847 RVA: 0x0033530B File Offset: 0x0033350B
	public void SetCurrentEnterComponent(USceneComponent enterComponent)
	{
		this.CurrentEnterComponent = enterComponent;
	}

	// Token: 0x0600C2B8 RID: 49848 RVA: 0x00335314 File Offset: 0x00333514
	public void SetCurrentPressComponent(USceneComponent pressComponent)
	{
		this.CurrentPressComponent = pressComponent;
	}

	// Token: 0x0600C2B9 RID: 49849 RVA: 0x0033531D File Offset: 0x0033351D
	public bool IsDoubleTouch(int touchId)
	{
		return this.GetTouchEmptyFingerDataCount() == 1 && touchId == this.CurrentTouchId && Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.CurrentTouchTimeStamp <= this.DoubleTouchTime;
	}

	// Token: 0x0600C2BA RID: 49850 RVA: 0x0033535C File Offset: 0x0033355C
	public bool IsDoubleTouchResetCameraComponent(TouchFingerData touchFingerData, FName componentTag)
	{
		return this.CurrentEnterComponent != null && this.CurrentEnterComponent.IsValid() && this.CurrentPressComponent != null && this.CurrentPressComponent.IsValid() && (this.CurrentEnterComponent.ComponentHasTag(componentTag) || this.CurrentPressComponent.ComponentHasTag(componentTag)) && touchFingerData.IsTouchComponentContainTag(componentTag);
	}

	// Token: 0x0600C2BB RID: 49851 RVA: 0x003353BC File Offset: 0x003335BC
	public void AddTouchEmptyFingerData(TouchFingerData touchFingerData)
	{
		EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
		this.TouchEmptyFingerDataMap[fingerIndex] = touchFingerData;
	}

	// Token: 0x0600C2BC RID: 49852 RVA: 0x003353E0 File Offset: 0x003335E0
	public void RemoveTouchEmptyFingerData(TouchFingerData touchFingerData)
	{
		EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
		this.TouchEmptyFingerDataMap.Remove(fingerIndex);
	}

	// Token: 0x0600C2BD RID: 49853 RVA: 0x00335401 File Offset: 0x00333601
	public int GetTouchEmptyFingerDataCount()
	{
		return this.TouchEmptyFingerDataMap.Count;
	}

	// Token: 0x17000FED RID: 4077
	// (get) Token: 0x0600C2BE RID: 49854 RVA: 0x0033540E File Offset: 0x0033360E
	public bool IsTouching
	{
		get
		{
			return this.TouchEmptyFingerDataMap.Count > 0;
		}
	}

	// Token: 0x0600C2BF RID: 49855 RVA: 0x0033541E File Offset: 0x0033361E
	public bool IsTouchEmpty(EFingerIndex fingerIndex)
	{
		return this.TouchEmptyFingerDataMap.ContainsKey(fingerIndex);
	}

	// Token: 0x0600C2C0 RID: 49856 RVA: 0x0033542C File Offset: 0x0033362C
	public TouchFingerData[] GetTouchEmptyFingerDataByCount(int count)
	{
		List<TouchFingerData> list = new List<TouchFingerData>();
		foreach (TouchFingerData item in this.TouchEmptyFingerDataMap.Values)
		{
			if (list.Count >= count)
			{
				break;
			}
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600C2C1 RID: 49857 RVA: 0x0033549C File Offset: 0x0033369C
	public void SetCommonRotationScreenRate(float rate)
	{
		this.CommonRotationScreenRateInternal = rate;
	}

	// Token: 0x0600C2C2 RID: 49858 RVA: 0x003354A5 File Offset: 0x003336A5
	public void SetArmRotationScreenRate(float rate)
	{
		this.ArmRotationScreenRateInternal = rate;
	}

	// Token: 0x0600C2C3 RID: 49859 RVA: 0x003354B0 File Offset: 0x003336B0
	public void RefreshRotationScreenRate()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			this.RotationScreenRateInternal = this.CommonRotationScreenRateInternal;
			return;
		}
		CharacterUnifiedStateComponent component = getCurrentEntity.Entity.GetComponent<CharacterUnifiedStateComponent>();
		if (component == null)
		{
			this.RotationScreenRateInternal = this.CommonRotationScreenRateInternal;
			return;
		}
		if (component.DirectionState == ECharDirectionState.AimDirection)
		{
			this.RotationScreenRateInternal = this.ArmRotationScreenRateInternal;
			return;
		}
		this.RotationScreenRateInternal = this.CommonRotationScreenRateInternal;
	}

	// Token: 0x0600C2C4 RID: 49860 RVA: 0x00335516 File Offset: 0x00333716
	public float GetRotationScreenRate()
	{
		return this.RotationScreenRateInternal;
	}

	// Token: 0x04005D4B RID: 23883
	private float CommonRotationScreenRateInternal = 0.3f;

	// Token: 0x04005D4C RID: 23884
	private float ArmRotationScreenRateInternal = 0.3f;

	// Token: 0x04005D4D RID: 23885
	private float RotationScreenRateInternal = 0.3f;

	// Token: 0x04005D4E RID: 23886
	public float MinTouchMoveDifference;

	// Token: 0x04005D4F RID: 23887
	public float MaxTouchMoveDifference;

	// Token: 0x04005D50 RID: 23888
	public float MaxTouchMoveValue;

	// Token: 0x04005D51 RID: 23889
	public float MinTouchMoveValue;

	// Token: 0x04005D52 RID: 23890
	private Number CurrentTouchTimeStamp = 0;

	// Token: 0x04005D53 RID: 23891
	private int CurrentTouchId;

	// Token: 0x04005D54 RID: 23892
	private Number DoubleTouchTime = 0;

	// Token: 0x04005D55 RID: 23893
	private readonly Dictionary<EFingerIndex, TouchFingerData> TouchEmptyFingerDataMap = new Dictionary<EFingerIndex, TouchFingerData>();

	// Token: 0x04005D56 RID: 23894
	[Nullable(2)]
	private USceneComponent CurrentEnterComponent;

	// Token: 0x04005D57 RID: 23895
	[Nullable(2)]
	private USceneComponent CurrentPressComponent;
}
