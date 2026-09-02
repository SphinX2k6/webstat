using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Enum;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Module.UiCameraAnimation;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C2E RID: 11310
[NullableContext(2)]
[Nullable(0)]
public class UiCameraAnimation
{
	// Token: 0x06016A2D RID: 92717 RVA: 0x006486EC File Offset: 0x006468EC
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<UiCameraAnimationDefine.IFinishData> AsyncPlayUiCameraAnimation(UiCameraHandleData fromHandleData, UiCameraHandleData toHandleData, string blendDataName)
	{
		UiCameraAnimation.<AsyncPlayUiCameraAnimation>d__19 <AsyncPlayUiCameraAnimation>d__;
		<AsyncPlayUiCameraAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiCameraAnimationDefine.IFinishData>.Create();
		<AsyncPlayUiCameraAnimation>d__.<>4__this = this;
		<AsyncPlayUiCameraAnimation>d__.fromHandleData = fromHandleData;
		<AsyncPlayUiCameraAnimation>d__.toHandleData = toHandleData;
		<AsyncPlayUiCameraAnimation>d__.blendDataName = blendDataName;
		<AsyncPlayUiCameraAnimation>d__.<>1__state = -1;
		<AsyncPlayUiCameraAnimation>d__.<>t__builder.Start<UiCameraAnimation.<AsyncPlayUiCameraAnimation>d__19>(ref <AsyncPlayUiCameraAnimation>d__);
		return <AsyncPlayUiCameraAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x06016A2E RID: 92718 RVA: 0x00648747 File Offset: 0x00646947
	private void NewWaitPromise()
	{
		if (this.WaitPromise == null)
		{
			this.WaitPromise = new CustomPromise<UiCameraAnimationDefine.IFinishData>();
		}
	}

	// Token: 0x06016A2F RID: 92719 RVA: 0x0064875C File Offset: 0x0064695C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private CustomPromise<UiCameraAnimationDefine.IFinishData> GetWaitPromise()
	{
		return this.WaitPromise;
	}

	// Token: 0x06016A30 RID: 92720 RVA: 0x00648764 File Offset: 0x00646964
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<UiCameraAnimationDefine.IFinishData> WaitCameraAnimationFinished()
	{
		UiCameraAnimation.<WaitCameraAnimationFinished>d__22 <WaitCameraAnimationFinished>d__;
		<WaitCameraAnimationFinished>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiCameraAnimationDefine.IFinishData>.Create();
		<WaitCameraAnimationFinished>d__.<>4__this = this;
		<WaitCameraAnimationFinished>d__.<>1__state = -1;
		<WaitCameraAnimationFinished>d__.<>t__builder.Start<UiCameraAnimation.<WaitCameraAnimationFinished>d__22>(ref <WaitCameraAnimationFinished>d__);
		return <WaitCameraAnimationFinished>d__.<>t__builder.Task;
	}

	// Token: 0x06016A31 RID: 92721 RVA: 0x006487A8 File Offset: 0x006469A8
	[NullableContext(1)]
	public unsafe void PlayUiCameraAnimation(UiCameraHandleData fromHandleData, UiCameraHandleData toHandleData, string blendDataName)
	{
		this.ResetUiCameraBlendAnimation();
		if (!toHandleData.CanApplyAnimationHandle())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CameraAnimation;
			ELogAuthor author = ELogAuthor.BB;
			string message = "无法播放镜头动画：原因是找不到对应插槽或骨骼模型为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("toHandleData", toHandleData.ToString());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (!this.RefreshAnimationSourceData(fromHandleData, blendDataName, toHandleData))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CameraAnimation;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "刷新动画数据失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("fromHandleData", fromHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("toHandleData", toHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("blendDataName", blendDataName);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.CameraAnimation;
		ELogAuthor author3 = ELogAuthor.BB;
		string message3 = "播放界面摄像机动画------开始";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("fromHandleName", fromHandleData.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("toHandleName", toHandleData.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("blendDataName", blendDataName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("timeLength", this.TimeLength);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		this.CurrentCameraHandle.Deactivate();
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetCameraActorRelativeLocation(Vector.ZeroVectorDouble);
		this.CurrentCameraHandle.SetWidgetCameraAttachToAnimationActor();
		if (this.TimeLength <= 0f)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.CameraAnimation;
			ELogAuthor author4 = ELogAuthor.BB;
			string message4 = "播放界面摄像机动画时间<=0，会立马结束动画";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("timeLength", this.TimeLength);
			instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.FinishUiCameraAnimation();
			return;
		}
		this.LoadCurveFloat();
		this.PlayUiCameraAnimationSequence(this.CurrentAnimationBlendData.LevelSequence, this.CurrentAnimationBlendData.PlayRate, this.CurrentAnimationBlendData.bReverse);
	}

	// Token: 0x06016A32 RID: 92722 RVA: 0x006489A4 File Offset: 0x00646BA4
	[NullableContext(1)]
	private bool RefreshAnimationSourceData(UiCameraHandleData fromHandleData, string blendDataName, UiCameraHandleData toHandleData)
	{
		this.FromHandleData = fromHandleData;
		this.ToHandleData = toHandleData;
		this.CurrentCameraHandle = Singleton<UiCameraAnimationManager>.Instance.GetCurrentCameraHandle();
		this.CurrentAnimationBlendData = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraAnimationBlendData(blendDataName);
		if (this.CurrentCameraHandle == null || this.CurrentAnimationBlendData == null)
		{
			return false;
		}
		UiCameraSpringStructure uiCameraSpringStructure = Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure;
		UiCameraPostEffectComponent uiCameraPostEffectComponent = Singleton<UiCameraAnimationManager>.Instance.UiCameraPostEffectComponent;
		this.SetAnimationSourceData(uiCameraSpringStructure.GetActorLocation(), uiCameraSpringStructure.GetActorRotation(), uiCameraSpringStructure.GetSpringArmLength(), uiCameraSpringStructure.GetSpringRelativeLocation(), uiCameraSpringStructure.GetSpringRelativeRotation(), uiCameraPostEffectComponent.GetFieldOfView(), uiCameraPostEffectComponent.GetManualFocusDistance(), uiCameraPostEffectComponent.GetCurrentAperture(), uiCameraPostEffectComponent.GetPostProcessBlendWeight(), this.CurrentAnimationBlendData.Time);
		return true;
	}

	// Token: 0x06016A33 RID: 92723 RVA: 0x00648A58 File Offset: 0x00646C58
	public void StopUiCameraAnimation()
	{
		if (this.ToHandleData == null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "播放界面摄像机动画------停止";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
		string item = "fromHandleName";
		UiCameraHandleData fromHandleData = this.FromHandleData;
		ptr = new ValueTuple<string, object>(item, (fromHandleData != null) ? fromHandleData.ToString() : null);
		ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item2 = "toHandleName";
		UiCameraHandleData toHandleData = this.ToHandleData;
		ptr2 = new ValueTuple<string, object>(item2, (toHandleData != null) ? toHandleData.ToString() : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.WaitPromise != null)
		{
			UiCameraAnimationDefine.FinishData result = new UiCameraAnimationDefine.FinishData
			{
				FinishType = UiCameraAnimationDefine.ECameraAnimationFinishType.Stop,
				FromHandleData = this.FromHandleData,
				ToHandleData = this.ToHandleData
			};
			this.WaitPromise.SetResult(result);
			this.WaitPromise = null;
		}
		this.DestroyUiCameraSequence(true, ERestoreStateType.NotRestore);
		this.ResetUiCameraBlendAnimation();
	}

	// Token: 0x06016A34 RID: 92724 RVA: 0x00648B34 File Offset: 0x00646D34
	private unsafe void FinishUiCameraAnimation()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "播放界面摄像机动画------完成";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("fromHandleName", this.FromHandleData.ToString());
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "toHandleName";
		UiCameraHandleData toHandleData = this.ToHandleData;
		ptr = new ValueTuple<string, object>(item, (toHandleData != null) ? toHandleData.ToString() : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.WaitPromise != null)
		{
			UiCameraAnimationDefine.FinishData result = new UiCameraAnimationDefine.FinishData
			{
				FinishType = UiCameraAnimationDefine.ECameraAnimationFinishType.Finished,
				FromHandleData = this.FromHandleData,
				ToHandleData = this.ToHandleData
			};
			this.WaitPromise.SetResult(result);
			this.WaitPromise = null;
		}
		this.DestroyUiCameraSequence(true, ERestoreStateType.NotSet);
		this.ResetUiCameraBlendAnimation();
	}

	// Token: 0x06016A35 RID: 92725 RVA: 0x00648C00 File Offset: 0x00646E00
	private void SetAnimationSourceData(FVectorDouble location, FRotator rotation, float armLength, FVectorDouble armRelativeLocation, FRotator armRelativeRotation, float fieldOfView, float focalDistance, float aperture, float processBlendWeight, float timeLength)
	{
		this.CurrentLocation = new FVectorDouble?(location);
		this.CurrentRotation = new FRotator?(rotation);
		this.CurrentArmLength = new float?(armLength);
		this.CurrentArmRelativeLocation = new FVectorDouble?(armRelativeLocation);
		this.CurrentArmRelativeRotation = new FRotator?(armRelativeRotation);
		this.CurrentFieldOfView = new float?(fieldOfView);
		this.CurrentFocalDistance = new float?(focalDistance);
		this.CurrentAperture = aperture;
		this.CurrentPostProcessBlendWeight = new float?(processBlendWeight);
		this.TimeLength = timeLength;
	}

	// Token: 0x06016A36 RID: 92726 RVA: 0x00648C84 File Offset: 0x00646E84
	public void Tick(float delta)
	{
		if (this.CurrentAnimationBlendData == null || this.CurrentCameraHandle == null)
		{
			return;
		}
		this.CurrentTimeLength += delta / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		if (this.CurrentTimeLength >= this.TimeLength)
		{
			this.FinishUiCameraAnimation();
			return;
		}
		if (this.ToHandleData == null)
		{
			return;
		}
		SUiCameraAnimationSettings uiCameraAnimationConfig = this.ToHandleData.GetUiCameraAnimationConfig();
		this.BlendLocationByAnimationSettings(uiCameraAnimationConfig.LocationType);
		this.BlendRotationByAnimationSettings();
		this.LerpArmLength(new float?(this.ToHandleData.GetTargetArmLength()));
		this.LerpArmOffsetLocation(new FVectorDouble?(this.ToHandleData.GetTargetArmOffsetLocation()));
		this.LerpArmOffsetRotation(new FRotator?(this.ToHandleData.GetTargetArmOffsetRotation()));
		this.LerpCameraFieldOfView(new float?(this.ToHandleData.GetTargetFieldOfView()));
		this.LerpFocalDistance(new float?(this.ToHandleData.GetTargetFocalDistance()));
		this.LerpAperture(new float?(this.ToHandleData.GetTargetAperture()));
		this.LerpFocalRegion(new float?(this.ToHandleData.GetTargetFocalRegion()));
		this.LerpPostProcessBlendWeight(new float?(this.ToHandleData.GetTargetPostProcessBlendWeight()));
	}

	// Token: 0x06016A37 RID: 92727 RVA: 0x00648DB3 File Offset: 0x00646FB3
	public bool IsPlaying()
	{
		return this.CurrentTimeLength < this.TimeLength;
	}

	// Token: 0x06016A38 RID: 92728 RVA: 0x00648DC4 File Offset: 0x00646FC4
	private void BlendLocationByAnimationSettings(EUiCameraAnimationLocationType targetLocationType)
	{
		FVectorDouble? targetLocation = this.ToHandleData.GetTargetLocation();
		if (targetLocation == null)
		{
			return;
		}
		this.LerpLocation(targetLocation, targetLocationType > EUiCameraAnimationLocationType.WorldLocation);
	}

	// Token: 0x06016A39 RID: 92729 RVA: 0x00648DF4 File Offset: 0x00646FF4
	private void BlendRotationByAnimationSettings()
	{
		FRotator? targetRotation = this.ToHandleData.GetTargetRotation();
		if (targetRotation == null)
		{
			return;
		}
		this.LerpRotation(targetRotation);
	}

	// Token: 0x06016A3A RID: 92730 RVA: 0x00648E20 File Offset: 0x00647020
	private void LerpLocation(FVectorDouble? targetLocation, bool isRelativeLocation)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.Location);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		FVectorDouble fvectorDouble = UKismetMathLibrary.D_VLerp(this.CurrentLocation.Value, targetLocation.Value, (double)currentCurveFloatValue.Value);
		if (isRelativeLocation)
		{
			this.CurrentCameraHandle.SetUiCameraAnimationRelativeLocation(fvectorDouble);
			return;
		}
		this.CurrentCameraHandle.SetUiCameraAnimationLocation(fvectorDouble);
	}

	// Token: 0x06016A3B RID: 92731 RVA: 0x00648E7C File Offset: 0x0064707C
	private void LerpRotation(FRotator? targetRotation)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.Rotation);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		FRotator uiCameraAnimationRotation = UKismetMathLibrary.RLerp(this.CurrentRotation.Value, targetRotation.Value, currentCurveFloatValue.Value, true);
		this.CurrentCameraHandle.SetUiCameraAnimationRotation(uiCameraAnimationRotation);
	}

	// Token: 0x06016A3C RID: 92732 RVA: 0x00648EC8 File Offset: 0x006470C8
	private void LerpArmLength(float? targetArmLength)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.ArmLength);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		float springArmLength = Singleton<MathUtils>.Instance.Lerp(this.CurrentArmLength.Value, targetArmLength.Value, currentCurveFloatValue.Value);
		this.CurrentCameraHandle.SetSpringArmLength(springArmLength);
	}

	// Token: 0x06016A3D RID: 92733 RVA: 0x00648F18 File Offset: 0x00647118
	private void LerpArmOffsetLocation(FVectorDouble? targetArmOffsetLocation)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.ArmOffsetLocation);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		FVectorDouble springArmRelativeLocation = UKismetMathLibrary.D_VLerp(this.CurrentArmRelativeLocation.Value, targetArmOffsetLocation.Value, (double)currentCurveFloatValue.Value);
		this.CurrentCameraHandle.SetSpringArmRelativeLocation(springArmRelativeLocation);
	}

	// Token: 0x06016A3E RID: 92734 RVA: 0x00648F64 File Offset: 0x00647164
	private void LerpArmOffsetRotation(FRotator? targetRotation)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.ArmOffsetRotation);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		FRotator sprintArmRelativeRotation = UKismetMathLibrary.RLerp(this.CurrentArmRelativeRotation.Value, targetRotation.Value, currentCurveFloatValue.Value, true);
		this.CurrentCameraHandle.SetSprintArmRelativeRotation(sprintArmRelativeRotation);
	}

	// Token: 0x06016A3F RID: 92735 RVA: 0x00648FB0 File Offset: 0x006471B0
	private void LerpCameraFieldOfView(float? targetFieldOfView)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.CameraFieldOfView);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		float cameraFieldOfView = Singleton<MathUtils>.Instance.Lerp(this.CurrentFieldOfView.Value, targetFieldOfView.Value, currentCurveFloatValue.Value);
		this.CurrentCameraHandle.SetCameraFieldOfView(cameraFieldOfView);
	}

	// Token: 0x06016A40 RID: 92736 RVA: 0x00649000 File Offset: 0x00647200
	private void LerpFocalDistance(float? targetFocalDistance)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.FocalDistance);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		float cameraFocalDistance = Singleton<MathUtils>.Instance.Lerp(this.CurrentFocalDistance.Value, targetFocalDistance.Value, currentCurveFloatValue.Value);
		this.CurrentCameraHandle.SetCameraFocalDistance(cameraFocalDistance);
	}

	// Token: 0x06016A41 RID: 92737 RVA: 0x00649050 File Offset: 0x00647250
	private void LerpAperture(float? targetAperture)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.Aperture);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		float cameraAperture = Singleton<MathUtils>.Instance.Lerp(this.CurrentAperture, targetAperture.Value, currentCurveFloatValue.Value);
		this.CurrentCameraHandle.SetCameraAperture(cameraAperture);
	}

	// Token: 0x06016A42 RID: 92738 RVA: 0x0064909C File Offset: 0x0064729C
	private void LerpFocalRegion(float? targetFocalRegion)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.FocalRegion);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		float cameraFocalRegion = Singleton<MathUtils>.Instance.Lerp(this.CurrentFocalRegion, targetFocalRegion.Value, currentCurveFloatValue.Value);
		this.CurrentCameraHandle.SetCameraFocalRegion(cameraFocalRegion);
	}

	// Token: 0x06016A43 RID: 92739 RVA: 0x006490E8 File Offset: 0x006472E8
	private void LerpPostProcessBlendWeight(float? targetPostProcessBlendWeight)
	{
		float? currentCurveFloatValue = this.GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType.PostProcessBlendWeight);
		if (currentCurveFloatValue == null)
		{
			return;
		}
		float cameraPostProcessBlendWeight = Singleton<MathUtils>.Instance.Lerp(this.CurrentPostProcessBlendWeight.Value, targetPostProcessBlendWeight.Value, currentCurveFloatValue.Value);
		this.CurrentCameraHandle.SetCameraPostProcessBlendWeight(cameraPostProcessBlendWeight);
	}

	// Token: 0x06016A44 RID: 92740 RVA: 0x00649137 File Offset: 0x00647337
	private float? GetCurrentCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType type)
	{
		return this.GetCurveFloatValue(type, this.CurrentTimeLength);
	}

	// Token: 0x06016A45 RID: 92741 RVA: 0x00649148 File Offset: 0x00647348
	public float? GetCurveFloatValue(UiCameraAnimationDefine.ECameraAnimationAttributeType type, float time)
	{
		if (time > this.TimeLength)
		{
			return new float?(1f);
		}
		UCurveFloat curveFloat = this.GetCurveFloat(type);
		if (curveFloat == null)
		{
			return null;
		}
		return new float?(Math.Min(curveFloat.GetFloatValue(time), 1f));
	}

	// Token: 0x06016A46 RID: 92742 RVA: 0x00649194 File Offset: 0x00647394
	public UCurveFloat GetCurveFloat(UiCameraAnimationDefine.ECameraAnimationAttributeType attributeType)
	{
		UCurveFloat result;
		if (!this.CurveFloatMap.TryGetValue(attributeType, out result))
		{
			return this.CommonCurveFloat;
		}
		return result;
	}

	// Token: 0x06016A47 RID: 92743 RVA: 0x006491BC File Offset: 0x006473BC
	private void LoadCurveFloat()
	{
		if (this.CommonCurveFloat == null || !this.CommonCurveFloat.IsValid())
		{
			TSoftObjectPtr<UCurveFloat> commonCurve = this.CurrentAnimationBlendData.CommonCurve;
			TSoftObjectPtr<UObject> tsoftObjectPtr = new TSoftObjectPtr<UObject>(commonCurve);
			if (UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
			{
				string text = commonCurve.ToAssetPathName();
				if (!StringUtils.IsEmpty(text))
				{
					Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(text, delegate([Nullable(2)] UCurveFloat curveFloat, string _)
					{
						this.CommonCurveFloat = curveFloat;
					}, 100, "Ui.UiCamera");
				}
			}
		}
		if (this.CurveFloatMap.Count <= 0)
		{
			foreach (KeyValuePair<TEnumAsByte<EUiCameraAnimationAttributeType>, TSoftObjectPtr<UCurveFloat>> keyValuePair in this.CurrentAnimationBlendData.CurveMap)
			{
				TEnumAsByte<EUiCameraAnimationAttributeType> key2;
				TSoftObjectPtr<UCurveFloat> tsoftObjectPtr2;
				keyValuePair.Deconstruct(out key2, out tsoftObjectPtr2);
				TEnumAsByte<EUiCameraAnimationAttributeType> key = key2;
				TSoftObjectPtr<UCurveFloat> tsoftObjectPtr3 = tsoftObjectPtr2;
				TSoftObjectPtr<UObject> tsoftObjectPtr4 = new TSoftObjectPtr<UObject>(tsoftObjectPtr3);
				if (UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr4))
				{
					string text2 = tsoftObjectPtr3.ToAssetPathName();
					if (!StringUtils.IsEmpty(text2))
					{
						Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(text2, delegate([Nullable(2)] UCurveFloat curveFloat, string _)
						{
							this.CurveFloatMap[(UiCameraAnimationDefine.ECameraAnimationAttributeType)key] = curveFloat;
						}, 100, "Ui.UiCamera");
					}
				}
			}
		}
	}

	// Token: 0x17001DCD RID: 7629
	// (get) Token: 0x06016A48 RID: 92744 RVA: 0x006492E4 File Offset: 0x006474E4
	public float GetTimeLength
	{
		get
		{
			return this.TimeLength;
		}
	}

	// Token: 0x06016A49 RID: 92745 RVA: 0x006492EC File Offset: 0x006474EC
	private void ResetUiCameraBlendAnimation()
	{
		this.CurrentAnimationBlendData = null;
		this.CurrentCameraHandle = null;
		this.FromHandleData = null;
		this.ToHandleData = null;
		this.CurrentLocation = null;
		this.CurrentRotation = null;
		this.CurrentArmLength = null;
		this.CurrentArmRelativeLocation = null;
		this.CurrentArmRelativeRotation = null;
		this.CurrentFieldOfView = null;
		this.CurrentFocalDistance = null;
		this.CurrentPostProcessBlendWeight = null;
		this.CurrentTimeLength = 0f;
		this.TimeLength = 0f;
		this.CommonCurveFloat = null;
		this.CurveFloatMap.Clear();
	}

	// Token: 0x06016A4A RID: 92746 RVA: 0x006493A0 File Offset: 0x006475A0
	[NullableContext(1)]
	private void PlayUiCameraAnimationSequence(TSoftObjectPtr<ULevelSequence> sequence, float playRate, bool reverse)
	{
		TSoftObjectPtr<UObject> tsoftObjectPtr = new TSoftObjectPtr<UObject>(sequence);
		if (!UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
		{
			return;
		}
		this.DestroyUiCameraSequence(true, ERestoreStateType.NotRestore);
		UiCameraSequenceComponent uiCameraSequenceComponent = Singleton<UiCameraAnimationManager>.Instance.UiCameraSequenceComponent;
		uiCameraSequenceComponent.AddUiCameraSequenceFinishedCallback(new Action(this.OnUiCameraAnimationSequenceFinished));
		uiCameraSequenceComponent.LoadAndPlayUiCameraSequence(sequence, playRate, reverse, null);
	}

	// Token: 0x06016A4B RID: 92747 RVA: 0x006493EC File Offset: 0x006475EC
	private void OnUiCameraAnimationSequenceFinished()
	{
		this.DestroyUiCameraSequence(true, ERestoreStateType.NotSet);
	}

	// Token: 0x06016A4C RID: 92748 RVA: 0x006493F6 File Offset: 0x006475F6
	private void DestroyUiCameraSequence(bool destroyBlackScreen = true, ERestoreStateType restoreStateType = ERestoreStateType.NotSet)
	{
		UiCameraSequenceComponent uiCameraSequenceComponent = Singleton<UiCameraAnimationManager>.Instance.UiCameraSequenceComponent;
		if (uiCameraSequenceComponent == null)
		{
			return;
		}
		uiCameraSequenceComponent.DestroyUiCameraSequence(destroyBlackScreen, restoreStateType);
	}

	// Token: 0x0400AEB0 RID: 44720
	private UiCameraAnimationHandle CurrentCameraHandle;

	// Token: 0x0400AEB1 RID: 44721
	private SUiCameraAnimationBlendSettings CurrentAnimationBlendData;

	// Token: 0x0400AEB2 RID: 44722
	private float CurrentTimeLength;

	// Token: 0x0400AEB3 RID: 44723
	private FVectorDouble? CurrentLocation;

	// Token: 0x0400AEB4 RID: 44724
	private FRotator? CurrentRotation;

	// Token: 0x0400AEB5 RID: 44725
	private float? CurrentArmLength;

	// Token: 0x0400AEB6 RID: 44726
	private FVectorDouble? CurrentArmRelativeLocation;

	// Token: 0x0400AEB7 RID: 44727
	private FRotator? CurrentArmRelativeRotation;

	// Token: 0x0400AEB8 RID: 44728
	private float? CurrentFieldOfView;

	// Token: 0x0400AEB9 RID: 44729
	private float? CurrentFocalDistance;

	// Token: 0x0400AEBA RID: 44730
	private float CurrentAperture;

	// Token: 0x0400AEBB RID: 44731
	private readonly float CurrentFocalRegion;

	// Token: 0x0400AEBC RID: 44732
	private float? CurrentPostProcessBlendWeight;

	// Token: 0x0400AEBD RID: 44733
	[Nullable(1)]
	private readonly Dictionary<UiCameraAnimationDefine.ECameraAnimationAttributeType, UCurveFloat> CurveFloatMap = new Dictionary<UiCameraAnimationDefine.ECameraAnimationAttributeType, UCurveFloat>();

	// Token: 0x0400AEBE RID: 44734
	private float TimeLength;

	// Token: 0x0400AEBF RID: 44735
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CustomPromise<UiCameraAnimationDefine.IFinishData> WaitPromise;

	// Token: 0x0400AEC0 RID: 44736
	private UiCameraHandleData FromHandleData;

	// Token: 0x0400AEC1 RID: 44737
	private UiCameraHandleData ToHandleData;

	// Token: 0x0400AEC2 RID: 44738
	private UCurveFloat CommonCurveFloat;
}
