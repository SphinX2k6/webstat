using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C31 RID: 11313
[NullableContext(1)]
[Nullable(0)]
public class UiCameraAnimationHandle
{
	// Token: 0x06016A67 RID: 92775 RVA: 0x00649D70 File Offset: 0x00647F70
	public void Initialize()
	{
		this.UiCameraLoadingAnimation = new UiCameraLoadingAnimation();
		this.UiCameraLoadingAnimation.Initialize();
		this.IsActivate = false;
	}

	// Token: 0x06016A68 RID: 92776 RVA: 0x00649D8F File Offset: 0x00647F8F
	public void Reset()
	{
		this.Deactivate();
		this.HandleData = null;
		this.UiCameraAnimationConfig = null;
		this.UiCameraLoadingAnimation = null;
		this.IsViewInLoading = false;
		this.IsPendingRevert = false;
		this.OnRevertFinished = null;
	}

	// Token: 0x06016A69 RID: 92777 RVA: 0x00649DC1 File Offset: 0x00647FC1
	public void Tick(float delta)
	{
		UiCameraLoadingAnimation uiCameraLoadingAnimation = this.UiCameraLoadingAnimation;
		if (uiCameraLoadingAnimation == null)
		{
			return;
		}
		uiCameraLoadingAnimation.Tick(delta);
	}

	// Token: 0x06016A6A RID: 92778 RVA: 0x00649DD4 File Offset: 0x00647FD4
	public void SetHandleData(UiCameraHandleData handleData)
	{
		this.HandleData = handleData;
	}

	// Token: 0x06016A6B RID: 92779 RVA: 0x00649DE0 File Offset: 0x00647FE0
	public unsafe void Activate(UiCameraHandleData handleData, bool bBlend = true, bool bPlayBlendInSequence = true)
	{
		this.HandleData = handleData;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "激活界面镜头状态";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		SUiCameraAnimationSettings uiCameraAnimationConfig = this.HandleData.GetUiCameraAnimationConfig();
		if (uiCameraAnimationConfig == null)
		{
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandleFail, this.HandleData);
			return;
		}
		if (handleData.IsEmptyState)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CameraAnimation;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "激活界面镜头状态时，激活了一个空状态";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, handleData);
			return;
		}
		this.UiCameraAnimationConfig = uiCameraAnimationConfig;
		this.IsPlayingBlendInSequence = false;
		UiCameraAnimationDefine.EPlayBlendCameraSequenceResult eplayBlendCameraSequenceResult = this.TryPlayBlendCameraSequence(uiCameraAnimationConfig.BlendInCameraSequence, uiCameraAnimationConfig.BlendInCameraSequencePlayRate, uiCameraAnimationConfig.bRevertBlendInCameraSequence, delegate
		{
			this.IsPlayingBlendInSequence = false;
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnUiBlendInCameraSequenceFinished, handleData);
		});
		if (eplayBlendCameraSequenceResult == UiCameraAnimationDefine.EPlayBlendCameraSequenceResult.TargetActorNotFound)
		{
			this.IsPlayingBlendInSequence = false;
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.CameraAnimation;
			ELogAuthor author3 = ELogAuthor.BB;
			string message3 = "激活界面镜头状态时，填了BlendInCameraSequence，但是目标Actor无法找到，直接休眠UI相机状态";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandleFail, this.HandleData);
			this.Deactivate();
			return;
		}
		if (eplayBlendCameraSequenceResult == UiCameraAnimationDefine.EPlayBlendCameraSequenceResult.Success)
		{
			this.IsPlayingBlendInSequence = true;
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.CameraAnimation;
			ELogAuthor author4 = ELogAuthor.BB;
			string message4 = "激活界面镜头状态时，填了BlendInCameraSequence，会直接播放Sequence而不会进行其他线性变化计算";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, handleData);
			return;
		}
		if (Singleton<UiCameraAnimationManager>.Instance.UiCamera == null)
		{
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandleFail, this.HandleData);
			this.Deactivate();
			return;
		}
		this.IsPendingRevert = false;
		FVectorDouble? targetLocation = this.HandleData.GetTargetLocation();
		FRotator? targetRotation = this.HandleData.GetTargetRotation();
		if (targetLocation == null || targetRotation == null)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.CameraAnimation;
			ELogAuthor author5 = ELogAuthor.BB;
			string message5 = "激活界面镜头状态时，找不到对应位置或旋转，可能是对应目标无法找到";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ReplaceCameraTag", this.HandleData.ReplaceCameraTag);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "ReplaceCameraIsValid";
			ACineCameraActor replaceCameraActor = this.HandleData.GetReplaceCameraActor();
			ptr = new ValueTuple<string, object>(item, (replaceCameraActor != null) ? new bool?(replaceCameraActor.IsValid()) : null);
			instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandleFail, this.HandleData);
			this.Deactivate();
			return;
		}
		this.StopSequence();
		this.SetUiCameraAnimationRotation(targetRotation.Value);
		this.SetUiCameraAnimationLocation(targetLocation.Value);
		this.SetSpringArmLength(this.HandleData.GetTargetArmLength());
		this.SetSpringArmRelativeLocation(this.HandleData.GetTargetArmOffsetLocation());
		this.SetSprintArmRelativeRotation(this.HandleData.GetTargetArmOffsetRotation());
		this.SetCollisionTest(this.HandleData.GetTargetArmCollisionTest());
		this.SetCameraFieldOfView(this.HandleData.GetTargetFieldOfView());
		this.SetCameraFocalRegion(this.HandleData.GetTargetFocalRegion());
		this.SetCameraPostProcessBlendWeight(this.HandleData.GetTargetPostProcessBlendWeight());
		this.SetWidgetCameraAttachToAnimationActor();
		Singleton<UiCameraAnimationManager>.Instance.UiCamera.Enter(bBlend ? uiCameraAnimationConfig.BlendInTime : 0f, uiCameraAnimationConfig.BlendInFunction, uiCameraAnimationConfig.BlendInExp, delegate
		{
			Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnUiBlendInTimeCameraFinished, handleData);
		});
		if (this.UiCameraAnimationConfig.bResetCameraTransform)
		{
			Singleton<UiCameraAnimationManager>.Instance.ResetFightCameraRotation();
		}
		string viewName = this.HandleData.ViewName;
		UiCameraAnimationDefine.IUiCameraMapping uiCameraMappingConfig = this.HandleData.UiCameraMappingConfig;
		if (!string.IsNullOrEmpty(viewName) && Singleton<UiManager>.Instance.IsViewCreating((EUiViewName)viewName) && uiCameraMappingConfig != null && uiCameraMappingConfig.PlayLoadingCameraAnimation)
		{
			Log instance6 = Singleton<Log>.Instance;
			ELogModule module6 = ELogModule.CameraAnimation;
			ELogAuthor author6 = ELogAuthor.BB;
			string message6 = "激活界面镜头状态时，当前界面在加载中，过渡到模糊镜头效果";
			ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			instance6.Info(module6, author6, message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
			this.UiCameraLoadingAnimation.Play(Singleton<UiCameraAnimationManager>.Instance.LoadingViewCameraAnimationLength.Value, Singleton<UiCameraAnimationManager>.Instance.LoadingViewManualFocusDistance.Value, Singleton<UiCameraAnimationManager>.Instance.LoadingViewAperture.Value);
			this.IsViewInLoading = true;
		}
		else
		{
			Log instance7 = Singleton<Log>.Instance;
			ELogModule module7 = ELogModule.CameraAnimation;
			ELogAuthor author7 = ELogAuthor.BB;
			string message7 = "激活界面镜头状态时，当前界面不在加载中，所以停止模糊效果";
			ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			instance7.Info(module7, author7, message7, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
			this.IsViewInLoading = false;
			this.UiCameraLoadingAnimation.Stop();
			if (ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings() == null)
			{
				this.SetCameraFocalDistance(this.HandleData.GetTargetFocalDistance());
			}
			this.SetCameraAperture(this.HandleData.GetTargetAperture());
			if (bPlayBlendInSequence)
			{
				this.PlayUiCameraSequence(uiCameraAnimationConfig.BlendInSequence, uiCameraAnimationConfig.BlendInPlayRate, uiCameraAnimationConfig.bBlendInSequenceReverse, null);
			}
		}
		this.IsActivate = true;
		CameraModel instance8 = ModelBase<CameraModel>.Instance;
		if (instance8.MainModel.GetSavedSeqCameraThings() != null)
		{
			instance8.MainModel.ResetSavedSeqCameraThings();
		}
		Singleton<EventSystem>.Instance.Emit<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, handleData);
	}

	// Token: 0x06016A6C RID: 92780 RVA: 0x0064A33F File Offset: 0x0064853F
	public void Deactivate()
	{
		if (!this.IsActivate)
		{
			return;
		}
		UiCameraLoadingAnimation uiCameraLoadingAnimation = this.UiCameraLoadingAnimation;
		if (uiCameraLoadingAnimation != null && uiCameraLoadingAnimation.IsPlaying)
		{
			this.UiCameraLoadingAnimation.Stop();
		}
		this.IsActivate = false;
	}

	// Token: 0x06016A6D RID: 92781 RVA: 0x0064A370 File Offset: 0x00648570
	public UiCameraHandleData GetHandleData()
	{
		return this.HandleData;
	}

	// Token: 0x06016A6E RID: 92782 RVA: 0x0064A378 File Offset: 0x00648578
	public bool GetIsActivate()
	{
		return this.IsActivate;
	}

	// Token: 0x06016A6F RID: 92783 RVA: 0x0064A380 File Offset: 0x00648580
	[NullableContext(2)]
	public void Revert(bool bPlayBlendOutSequence = true, Action onRevertFinished = null)
	{
		SUiCameraAnimationSettings uiCameraAnimationConfig = this.HandleData.GetUiCameraAnimationConfig();
		if (uiCameraAnimationConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CameraAnimation;
			ELogAuthor author = ELogAuthor.BB;
			string message = "找不到镜头配置，强制还原镜头至战斗镜头";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (onRevertFinished != null)
			{
				onRevertFinished();
			}
			this.Reset();
			return;
		}
		this.UiCameraAnimationConfig = uiCameraAnimationConfig;
		TSoftObjectPtr<ULevelSequence> blendOutCameraSequence = uiCameraAnimationConfig.BlendOutCameraSequence;
		float blendOutCameraSequencePlayRate = uiCameraAnimationConfig.BlendOutCameraSequencePlayRate;
		bool bRevertBlendOutCameraSequence = uiCameraAnimationConfig.bRevertBlendOutCameraSequence;
		this.OnRevertFinished = onRevertFinished;
		if (this.TryPlayBlendCameraSequence(blendOutCameraSequence, blendOutCameraSequencePlayRate, bRevertBlendOutCameraSequence, new Action(this.FinishRevert)) == UiCameraAnimationDefine.EPlayBlendCameraSequenceResult.Success)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CameraAnimation;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "还原界面镜头状态时，填了BlendOutCameraSequence，会直接播放Sequence而不会进行其他线性变化计算";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		float blendOutTime = this.UiCameraAnimationConfig.BlendOutTime;
		TEnumAsByte<EViewTargetBlendFunction> blendOutFunction = this.UiCameraAnimationConfig.BlendOutFunction;
		float blendOutExp = this.UiCameraAnimationConfig.BlendOutExp;
		bool bResetCameraTransform = this.UiCameraAnimationConfig.bResetCameraTransform;
		TSoftObjectPtr<ULevelSequence> blendOutSequence = this.UiCameraAnimationConfig.BlendOutSequence;
		bool bBlendOutSequenceReverse = this.UiCameraAnimationConfig.bBlendOutSequenceReverse;
		float blendOutPlayRate = this.UiCameraAnimationConfig.BlendOutPlayRate;
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.CameraAnimation;
		ELogAuthor author3 = ELogAuthor.BB;
		string message3 = "还原镜头至战斗镜头";
		ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
		instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		if (bResetCameraTransform)
		{
			Singleton<UiCameraAnimationManager>.Instance.ResetFightCameraRotation();
		}
		Singleton<UiCameraAnimationManager>.Instance.UiCamera.Exit(blendOutTime, blendOutFunction, blendOutExp);
		if (bResetCameraTransform)
		{
			FightCamera fightCamera = ModelBase<CameraModel>.Instance.MainModel.FightCamera;
			if (fightCamera != null)
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				if (logicComponent != null)
				{
					logicComponent.ForceTickOutSide();
				}
			}
		}
		this.IsPendingRevert = true;
		TSoftObjectPtr<UObject> tsoftObjectPtr = new TSoftObjectPtr<UObject>(blendOutSequence);
		if (bPlayBlendOutSequence && UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
		{
			this.PlayUiCameraSequence(blendOutSequence, blendOutPlayRate, bBlendOutSequenceReverse, null).ContinueWith(delegate()
			{
				Singleton<UiCameraAnimationManager>.Instance.UiCameraSequenceComponent.AddUiCameraSequenceFinishedCallback(new Action(this.OnBlendOutSequenceFinished));
			});
			return;
		}
		this.FinishRevert();
	}

	// Token: 0x06016A70 RID: 92784 RVA: 0x0064A569 File Offset: 0x00648769
	private void OnBlendOutSequenceFinished()
	{
		this.FinishRevert();
	}

	// Token: 0x06016A71 RID: 92785 RVA: 0x0064A574 File Offset: 0x00648774
	private void FinishRevert()
	{
		if (this.HandleData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "界面镜头状态 Revert(BlendOut) 完成时已被重置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "界面镜头状态 Revert(BlendOut) 完成";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("HandleData", this.HandleData.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Action onRevertFinished = this.OnRevertFinished;
		if (onRevertFinished != null)
		{
			onRevertFinished();
		}
		this.Reset();
	}

	// Token: 0x06016A72 RID: 92786 RVA: 0x0064A5EE File Offset: 0x006487EE
	public bool GetIsPendingRevert()
	{
		return this.IsPendingRevert;
	}

	// Token: 0x06016A73 RID: 92787 RVA: 0x0064A5F6 File Offset: 0x006487F6
	public void StopSequence()
	{
		if (Singleton<UiCameraAnimationManager>.Instance.UiCameraSequenceComponent == null)
		{
			return;
		}
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSequenceComponent.DestroyUiCameraSequence(true, ERestoreStateType.NotRestore);
	}

	// Token: 0x06016A74 RID: 92788 RVA: 0x0064A616 File Offset: 0x00648816
	public string GetViewName()
	{
		return this.HandleData.ViewName;
	}

	// Token: 0x06016A75 RID: 92789 RVA: 0x0064A623 File Offset: 0x00648823
	public bool GetIsPlayingBlendInSequence()
	{
		return this.IsPlayingBlendInSequence;
	}

	// Token: 0x17001DCE RID: 7630
	// (get) Token: 0x06016A76 RID: 92790 RVA: 0x0064A62B File Offset: 0x0064882B
	public AActor GetUiCameraAnimationActor
	{
		get
		{
			return Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.GetOwnActor();
		}
	}

	// Token: 0x06016A77 RID: 92791 RVA: 0x0064A63C File Offset: 0x0064883C
	private UiCameraAnimationDefine.EPlayBlendCameraSequenceResult TryPlayBlendCameraSequence(TSoftObjectPtr<ULevelSequence> blendInCameraSequence, float playRate, bool bReverse, Action onFinished = null)
	{
		TSoftObjectPtr<UObject> tsoftObjectPtr = new TSoftObjectPtr<UObject>(blendInCameraSequence);
		if (!UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
		{
			return UiCameraAnimationDefine.EPlayBlendCameraSequenceResult.PathIsEmpty;
		}
		AActor targetActor = this.HandleData.GetTargetActor();
		if (targetActor == null || !targetActor.IsValid())
		{
			return UiCameraAnimationDefine.EPlayBlendCameraSequenceResult.TargetActorNotFound;
		}
		this.SetWidgetCameraDetachFromAnimationActor();
		this.PlayUiCameraSequence(blendInCameraSequence, playRate, bReverse, targetActor).ContinueWith(delegate()
		{
			SUiCameraAnimationSettings uiCameraAnimationConfig = this.HandleData.GetUiCameraAnimationConfig();
			Singleton<UiCameraAnimationManager>.Instance.UiCamera.Enter(uiCameraAnimationConfig.BlendInTime, uiCameraAnimationConfig.BlendInFunction, uiCameraAnimationConfig.BlendInExp, null);
		});
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSequenceComponent.AddUiCameraSequenceFinishedCallback(onFinished);
		return UiCameraAnimationDefine.EPlayBlendCameraSequenceResult.Success;
	}

	// Token: 0x06016A78 RID: 92792 RVA: 0x0064A6A8 File Offset: 0x006488A8
	public void SetUiCameraAnimationLocation(FVectorDouble location)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetActorLocation(location);
	}

	// Token: 0x06016A79 RID: 92793 RVA: 0x0064A6BA File Offset: 0x006488BA
	public void SetUiCameraAnimationRelativeLocation(FVectorDouble location)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetActorRelativeLocation(location);
	}

	// Token: 0x06016A7A RID: 92794 RVA: 0x0064A6CC File Offset: 0x006488CC
	public void SetUiCameraAnimationRotation(FRotator rotation)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetActorRotation(rotation);
	}

	// Token: 0x06016A7B RID: 92795 RVA: 0x0064A6DE File Offset: 0x006488DE
	public void SetSpringArmLength(float length)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetSpringArmLength(length);
	}

	// Token: 0x06016A7C RID: 92796 RVA: 0x0064A6F0 File Offset: 0x006488F0
	public void SetSprintArmRelativeRotation(FRotator rotation)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetSprintArmRelativeRotation(rotation);
	}

	// Token: 0x06016A7D RID: 92797 RVA: 0x0064A702 File Offset: 0x00648902
	public void SetSpringArmRelativeLocation(FVectorDouble location)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetSpringArmRelativeLocation(location);
	}

	// Token: 0x06016A7E RID: 92798 RVA: 0x0064A714 File Offset: 0x00648914
	private void SetCollisionTest(bool bCollisionTest)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetCollisionTest(bCollisionTest);
	}

	// Token: 0x06016A7F RID: 92799 RVA: 0x0064A726 File Offset: 0x00648926
	public void SetCameraFieldOfView(float fieldOfView)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraPostEffectComponent.SetCameraFieldOfView(fieldOfView);
	}

	// Token: 0x06016A80 RID: 92800 RVA: 0x0064A738 File Offset: 0x00648938
	public void SetCameraFocalDistance(float focalDistance)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraPostEffectComponent.SetCameraFocalDistance(focalDistance);
	}

	// Token: 0x06016A81 RID: 92801 RVA: 0x0064A74A File Offset: 0x0064894A
	public void SetCameraCurrentFocalLength(float currentFocalLength)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraPostEffectComponent.SetCameraCurrentFocalLength(currentFocalLength);
	}

	// Token: 0x06016A82 RID: 92802 RVA: 0x0064A75C File Offset: 0x0064895C
	public void SetCameraAperture(float aperture)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraPostEffectComponent.SetCameraAperture(aperture);
	}

	// Token: 0x06016A83 RID: 92803 RVA: 0x0064A76E File Offset: 0x0064896E
	public void SetCameraFocalRegion(float focalRegion)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraPostEffectComponent.SetCameraFocalRegion(focalRegion);
	}

	// Token: 0x06016A84 RID: 92804 RVA: 0x0064A780 File Offset: 0x00648980
	public void SetCameraPostProcessBlendWeight(float postProcessBlendWeight)
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraPostEffectComponent.SetCameraPostProcessBlendWeight(postProcessBlendWeight);
	}

	// Token: 0x06016A85 RID: 92805 RVA: 0x0064A792 File Offset: 0x00648992
	public void SetWidgetCameraAttachToAnimationActor()
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.CameraActorAttachToSpringActor();
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.SetCameraActorRelativeLocation(FVectorDouble.ZeroVector);
	}

	// Token: 0x06016A86 RID: 92806 RVA: 0x0064A7B7 File Offset: 0x006489B7
	public void SetWidgetCameraDetachFromAnimationActor()
	{
		Singleton<UiCameraAnimationManager>.Instance.UiCameraSpringStructure.CameraActorDetachFromSpringActor();
	}

	// Token: 0x06016A87 RID: 92807 RVA: 0x0064A7C8 File Offset: 0x006489C8
	private UniTask PlayUiCameraSequence(TSoftObjectPtr<ULevelSequence> sequenceSoftObjectPtr, float playRate, bool bReverse, AActor originActor = null)
	{
		UiCameraAnimationHandle.<PlayUiCameraSequence>d__41 <PlayUiCameraSequence>d__;
		<PlayUiCameraSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayUiCameraSequence>d__.<>4__this = this;
		<PlayUiCameraSequence>d__.sequenceSoftObjectPtr = sequenceSoftObjectPtr;
		<PlayUiCameraSequence>d__.playRate = playRate;
		<PlayUiCameraSequence>d__.bReverse = bReverse;
		<PlayUiCameraSequence>d__.originActor = originActor;
		<PlayUiCameraSequence>d__.<>1__state = -1;
		<PlayUiCameraSequence>d__.<>t__builder.Start<UiCameraAnimationHandle.<PlayUiCameraSequence>d__41>(ref <PlayUiCameraSequence>d__);
		return <PlayUiCameraSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06016A88 RID: 92808 RVA: 0x0064A82C File Offset: 0x00648A2C
	public void DeepCopyCameraInfo(ACameraActor cameraActor)
	{
		this.SetUiCameraAnimationRotation(cameraActor.K2_GetActorRotation());
		this.SetUiCameraAnimationLocation(cameraActor.D_K2_GetActorLocation());
		this.SetCameraFieldOfView(cameraActor.CameraComponent.FieldOfView);
	}

	// Token: 0x0400AEC8 RID: 44744
	private SUiCameraAnimationSettings UiCameraAnimationConfig;

	// Token: 0x0400AEC9 RID: 44745
	private UiCameraHandleData HandleData;

	// Token: 0x0400AECA RID: 44746
	private bool IsActivate;

	// Token: 0x0400AECB RID: 44747
	[Nullable(2)]
	private Action OnRevertFinished;

	// Token: 0x0400AECC RID: 44748
	private UiCameraLoadingAnimation UiCameraLoadingAnimation;

	// Token: 0x0400AECD RID: 44749
	public bool IsViewInLoading;

	// Token: 0x0400AECE RID: 44750
	private bool IsPendingRevert;

	// Token: 0x0400AECF RID: 44751
	private bool IsPlayingBlendInSequence;
}
