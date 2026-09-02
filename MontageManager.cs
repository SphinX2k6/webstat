using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002FF9 RID: 12281
[NullableContext(2)]
[Nullable(0)]
public class MontageManager : IClear
{
	// Token: 0x170021B4 RID: 8628
	// (get) Token: 0x06019064 RID: 102500 RVA: 0x0071988A File Offset: 0x00717A8A
	[Nullable(1)]
	private UAnimInstance AnimInst
	{
		[NullableContext(1)]
		get
		{
			return this.AnimComp.MainAnimInstance;
		}
	}

	// Token: 0x06019065 RID: 102501 RVA: 0x00719897 File Offset: 0x00717A97
	public UAnimMontage GetPlayingMontage()
	{
		return this.CurrentMontage;
	}

	// Token: 0x06019066 RID: 102502 RVA: 0x0071989F File Offset: 0x00717A9F
	[NullableContext(1)]
	public void Init(BaseAnimationComponent animComp, EPerformGroup group = EPerformGroup.DefaultGroup)
	{
		this.AnimComp = animComp;
		this.Group = group;
		this.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(animComp.Entity.Id);
	}

	// Token: 0x06019067 RID: 102503 RVA: 0x007198CA File Offset: 0x00717ACA
	public bool ClearObject()
	{
		this.Clear();
		return true;
	}

	// Token: 0x06019068 RID: 102504 RVA: 0x007198D4 File Offset: 0x00717AD4
	public void Clear()
	{
		if (this.NeedQueue)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BasePerform;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[Montage] NeedQueue true when clear";
			string item = "pbDataId";
			EntityHandle entityHandle = this.EntityHandle;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (entityHandle != null) ? new int?(entityHandle.PbDataId) : null);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.NeedQueue = false;
		}
		this.UnsubscribeMontageEvents();
		if (this.AnimComp != null)
		{
			this.AnimComp.IgnoreMontageBlinkCurve = false;
		}
		this.AnimComp = null;
		this.EntityHandle = null;
		if (this.LoadHandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandleId);
		}
		this.LoadHandleId = -1;
		this.Duration = 0f;
		this.CurrentMontage = null;
		this.CurrentMontagePath = null;
		this.OnPlay = null;
		this.OnEnd = null;
		this.OnBlendOut = null;
		this.BlinkCurveOwnerHandleId = null;
		this.CallbackQueue.Clear();
	}

	// Token: 0x06019069 RID: 102505 RVA: 0x007199CC File Offset: 0x00717BCC
	public bool IsMontagePlaying(int? handleId = null)
	{
		if (handleId != null)
		{
			int handleId2 = this.HandleId;
			int? num = handleId;
			return handleId2 == num.GetValueOrDefault() & num != null;
		}
		return this.LoadHandleId != -1 || ObjectUtils.IsValid(this.CurrentMontage);
	}

	// Token: 0x0601906A RID: 102506 RVA: 0x00719A14 File Offset: 0x00717C14
	[NullableContext(1)]
	public unsafe int PlayMontage(IPlayMontageParam param)
	{
		if (this.NeedQueue)
		{
			Action<UAnimMontage, bool> onEndCallback = param.OnEndCallback;
			if (onEndCallback != null)
			{
				onEndCallback(null, true);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BasePerform;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[Montage] 播放蒙太奇嵌套";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", this.EntityHandle.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", this.EntityHandle.Entity.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return -1;
		}
		this.NeedQueue = true;
		float? currentTime = null;
		UAnimMontage inheritedMontage = null;
		if (this.CurrentMontage != null)
		{
			if (param.MontagePath == this.CurrentMontagePath || param.MontageAsset == this.CurrentMontage)
			{
				FName fname = this.AnimInst.Montage_GetCurrentSection(this.CurrentMontage);
				inheritedMontage = this.CurrentMontage;
				if (param.InSectionToStartMontageAt == null || param.InSectionToStartMontageAt.Value.IsNone())
				{
					if (!fname.Equals(Singleton<CharacterNameDefines>.Instance.END_SECTION))
					{
						currentTime = new float?(this.AnimInst.Montage_GetPosition(this.CurrentMontage));
					}
				}
				else if (fname.Equals(param.InSectionToStartMontageAt))
				{
					currentTime = new float?(this.AnimInst.Montage_GetPosition(this.CurrentMontage));
				}
			}
			this.LastMontage = this.CurrentMontage;
		}
		this.ClearAndDoCallback(true);
		int handleId = this.HandleId;
		Action<int, EPerformGroup> onStartCallback = param.OnStartCallback;
		if (onStartCallback != null)
		{
			onStartCallback(handleId, this.Group);
		}
		this.OnEnd = param.OnEndCallback;
		this.OnPlay = param.OnPlayCallback;
		this.OnBlendOut = param.OnBlendOutCallback;
		if (StringUtils.IsEmpty(param.MontagePath) && !ObjectUtils.IsValid(param.MontageAsset))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BasePerform;
			ELogAuthor author2 = ELogAuthor.FZX;
			string message2 = "[Montage] 实体播放蒙太奇路径和资产都为空";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ELogModule", ELogModule.BasePerform);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ELogAuthor", ELogAuthor.FZX);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("pbDataId", this.EntityHandle.PbDataId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			this.ClearAndDoCallback(true);
			this.NeedQueue = false;
			while (!this.CallbackQueue.Empty)
			{
				Action action = this.CallbackQueue.Pop();
				if (action != null)
				{
					action();
				}
			}
			return -1;
		}
		this.CurrentMontagePath = (param.MontagePath ?? UKismetSystemLibrary.GetPathName(param.MontageAsset));
		Action<UAnimMontage, string> action2 = delegate([Nullable(2)] UAnimMontage montage, string path)
		{
			this.LoadHandleId = -1;
			if (this.LastMontage != null)
			{
				this.AnimInst.Montage_Stop(0.5f, this.LastMontage);
			}
			if (montage == null || !ObjectUtils.IsValid(montage) || !this.CheckMontage(montage))
			{
				this.ClearAndDoCallback(true);
				return;
			}
			this.CurrentMontage = montage;
			float? currentTime = currentTime;
			if (currentTime == null && param.InSectionToStartMontageAt != null && !param.InSectionToStartMontageAt.Value.IsNone())
			{
				TArray<FCompositeSection> compositeSections = montage.CompositeSections;
				int num = compositeSections.Num();
				for (int i = 0; i < num; i++)
				{
					FCompositeSection fcompositeSection = compositeSections.Get(i);
					if (fcompositeSection.SectionName.Equals(param.InSectionToStartMontageAt))
					{
						currentTime = new float?(fcompositeSection.SegmentBeginTime);
						break;
					}
				}
				bool flag = currentTime != null;
			}
			if (this.AnimInst.Montage_Play(this.CurrentMontage, 1f, EMontagePlayReturnType.MontageLength, currentTime.GetValueOrDefault(), !param.KeepOtherMontage.GetValueOrDefault()) <= 0f)
			{
				Action<UAnimMontage> onPlay = this.OnPlay;
				if (onPlay != null)
				{
					onPlay(this.CurrentMontage);
				}
				this.OnMontageStop(this.CurrentMontage, true);
				return;
			}
			this.UpdateDelayEndTimer(param.Duration, new EStopMethod?(EStopMethod.WaitNextEndSection), null);
			this.UpdateLoopState(param.IsLoop);
			if (inheritedMontage == null)
			{
				this.SubscribeMontageEvents();
			}
			this.SetBlinkCurveState(handleId, param.DisableBlinkCurve.GetValueOrDefault());
			Action<UAnimMontage> onPlay2 = this.OnPlay;
			if (onPlay2 == null)
			{
				return;
			}
			onPlay2(this.CurrentMontage);
		};
		if (param.MontageAsset != null || inheritedMontage != null)
		{
			action2(param.MontageAsset ?? inheritedMontage, string.Empty);
		}
		else
		{
			this.LoadHandleId = -2;
			int loadHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(param.MontagePath, action2, 100, "js_undefined");
			if (this.LoadHandleId == -2)
			{
				this.LoadHandleId = loadHandleId;
			}
		}
		this.NeedQueue = false;
		while (!this.CallbackQueue.Empty)
		{
			Action action3 = this.CallbackQueue.Pop();
			if (action3 != null)
			{
				action3();
			}
		}
		if (handleId != this.HandleId)
		{
			return -1;
		}
		return handleId;
	}

	// Token: 0x0601906B RID: 102507 RVA: 0x00719E2C File Offset: 0x0071802C
	[NullableContext(1)]
	public void StopMontage(IStopMontageParam param)
	{
		if (param.HandleId != null)
		{
			int handleId = this.HandleId;
			int? handleId2 = param.HandleId;
			if (!(handleId == handleId2.GetValueOrDefault() & handleId2 != null))
			{
				return;
			}
		}
		if (string.IsNullOrEmpty(this.CurrentMontagePath))
		{
			return;
		}
		if (param.Montage != null)
		{
			if (this.CurrentMontage != param.Montage)
			{
				return;
			}
			if (UKismetSystemLibrary.GetPathName(param.Montage) != this.CurrentMontagePath)
			{
				return;
			}
		}
		float valueOrDefault = param.Delay.GetValueOrDefault();
		if (valueOrDefault > 0f)
		{
			this.UpdateDelayEndTimer(new float?(valueOrDefault), param.Method, new float?(valueOrDefault));
			return;
		}
		if (this.LoadHandleId != -1)
		{
			this.ClearAndDoCallback(true);
			return;
		}
		TArray<FCompositeSection> compositeSections = this.CurrentMontage.CompositeSections;
		int num = compositeSections.Num();
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < num; i++)
		{
			FCompositeSection fcompositeSection = compositeSections.Get(i);
			if (!flag2 && fcompositeSection.SectionName.Equals(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME))
			{
				flag2 = true;
			}
			if (!flag && fcompositeSection.SectionName.Equals(Singleton<CharacterNameDefines>.Instance.END_SECTION))
			{
				flag = true;
			}
		}
		float valueOrDefault2 = param.BlendOutTime.GetValueOrDefault(0.5f);
		switch (param.Method.GetValueOrDefault())
		{
		case EStopMethod.BlendOut:
			this.AnimInst.Montage_Stop(valueOrDefault2, this.CurrentMontage);
			break;
		case EStopMethod.WaitNextEndSection:
			if (!flag)
			{
				if (!flag2)
				{
					this.AnimInst.Montage_Stop(valueOrDefault2, this.CurrentMontage);
				}
				else
				{
					this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, Singleton<CharacterNameDefines>.Instance.NULL_SECTION, this.CurrentMontage);
				}
			}
			else
			{
				this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.START_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, this.CurrentMontage);
				this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, this.CurrentMontage);
			}
			break;
		case EStopMethod.JumpToEndSection:
			if (!flag)
			{
				this.AnimInst.Montage_Stop(valueOrDefault2, this.CurrentMontage);
			}
			else
			{
				this.AnimInst.Montage_JumpToSection(Singleton<CharacterNameDefines>.Instance.END_SECTION, this.CurrentMontage);
			}
			break;
		case EStopMethod.FastOut:
			if (!flag)
			{
				this.AnimInst.Montage_Stop(valueOrDefault2, this.CurrentMontage);
			}
			else
			{
				float num2 = this.AnimInst.Montage_GetPosition(this.CurrentMontage);
				float num3 = this.CurrentMontage.SequenceLength - num2;
				float num4 = valueOrDefault2;
				if (num3 > num4)
				{
					float newPlayRate = num3 / num4;
					this.AnimInst.Montage_SetPlayRate(this.CurrentMontage, newPlayRate);
				}
				this.AnimComp.MainAnimInstance.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, this.CurrentMontage);
			}
			break;
		case EStopMethod.WaitLoopToEnd:
			if (!flag)
			{
				this.AnimInst.Montage_Stop(valueOrDefault2, this.CurrentMontage);
			}
			else
			{
				this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, this.CurrentMontage);
			}
			break;
		case EStopMethod.BlendToEndSection:
			if (!flag)
			{
				this.AnimInst.Montage_Stop(valueOrDefault2, this.CurrentMontage);
			}
			else if (!this.AnimInst.Montage_GetCurrentSection(this.CurrentMontage).Equals(Singleton<CharacterNameDefines>.Instance.END_SECTION))
			{
				this.AnimInst.Montage_Stop(valueOrDefault2, this.CurrentMontage);
				float? num5 = null;
				for (int j = 0; j < num; j++)
				{
					FCompositeSection fcompositeSection2 = compositeSections.Get(j);
					if (fcompositeSection2.SectionName.Equals(Singleton<CharacterNameDefines>.Instance.END_SECTION))
					{
						num5 = new float?(fcompositeSection2.SegmentBeginTime);
						break;
					}
				}
				if (num5 != null)
				{
					this.AnimInst.Montage_Play(this.CurrentMontage, 1f, EMontagePlayReturnType.MontageLength, num5.Value, false);
					this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, this.CurrentMontage);
				}
			}
			break;
		}
		if (param.ImmediatelyCallback.GetValueOrDefault())
		{
			this.ClearAndDoCallback(true);
		}
	}

	// Token: 0x0601906C RID: 102508 RVA: 0x0071A27C File Offset: 0x0071847C
	public void ClearCallback(int? handleId = null)
	{
		if (handleId != null)
		{
			int handleId2 = this.HandleId;
			int? num = handleId;
			if (!(handleId2 == num.GetValueOrDefault() & num != null))
			{
				return;
			}
		}
		this.OnPlay = null;
		this.OnEnd = null;
		this.OnBlendOut = null;
	}

	// Token: 0x0601906D RID: 102509 RVA: 0x0071A2C3 File Offset: 0x007184C3
	public void DetachWithoutStop(bool bInterrupted = false)
	{
		if (this.CurrentMontage == null && string.IsNullOrEmpty(this.CurrentMontagePath))
		{
			return;
		}
		this.UnsubscribeMontageEvents();
		this.ClearAndDoCallback(bInterrupted);
	}

	// Token: 0x0601906E RID: 102510 RVA: 0x0071A2E8 File Offset: 0x007184E8
	private void UpdateDelayEndTimer(float? duration = 0f, EStopMethod? method = 1, float? blendOutTime = null)
	{
		this.DelayStopParam = new IStopMontageParam
		{
			Method = method,
			BlendOutTime = blendOutTime
		};
		this.Duration = duration.GetValueOrDefault();
	}

	// Token: 0x0601906F RID: 102511 RVA: 0x0071A310 File Offset: 0x00718510
	private unsafe void UpdateLoopState(bool? isLoop = null)
	{
		if (isLoop == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < this.CurrentMontage.CompositeSections.Num(); i++)
		{
			FCompositeSection fcompositeSection = this.CurrentMontage.CompositeSections.Get(i);
			if (fcompositeSection.SectionName.Equals(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION))
			{
				flag = true;
				break;
			}
			if (fcompositeSection.SectionName.Equals(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME))
			{
				flag2 = true;
				break;
			}
		}
		if (!flag && !flag2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BasePerform;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[Montage] 蒙太奇片段不合法";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ELogModule", ELogModule.BasePerform);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ELogAuthor", ELogAuthor.FZX);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("montage", this.CurrentMontage);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("pbDataId", this.EntityHandle.PbDataId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		if (isLoop.GetValueOrDefault())
		{
			if (flag)
			{
				this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, this.CurrentMontage);
				return;
			}
			if (flag2)
			{
				this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, this.CurrentMontage);
				return;
			}
		}
		else
		{
			if (flag)
			{
				this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, this.CurrentMontage);
				return;
			}
			if (flag2)
			{
				this.AnimInst.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, Singleton<CharacterNameDefines>.Instance.NULL_SECTION, this.CurrentMontage);
			}
		}
	}

	// Token: 0x06019070 RID: 102512 RVA: 0x0071A4FC File Offset: 0x007186FC
	private void SubscribeMontageEvents()
	{
		if (this.bSubscribed)
		{
			return;
		}
		this.AnimInst.OnMontageEnded.Add(new Action<UAnimMontage, bool>(this.OnMontageStop));
		this.AnimInst.OnMontageBlendingOut.Add(new Action<UAnimMontage, bool>(this.OnMontageBlendingOut));
		this.bSubscribed = true;
	}

	// Token: 0x06019071 RID: 102513 RVA: 0x0071A554 File Offset: 0x00718754
	private void UnsubscribeMontageEvents()
	{
		if (!this.bSubscribed)
		{
			return;
		}
		if (this.AnimComp != null && this.AnimComp.MainAnimInstance != null)
		{
			this.AnimInst.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.OnMontageStop));
			this.AnimInst.OnMontageBlendingOut.Remove(new Action<UAnimMontage, bool>(this.OnMontageBlendingOut));
		}
		this.bSubscribed = false;
	}

	// Token: 0x06019072 RID: 102514 RVA: 0x0071A5BE File Offset: 0x007187BE
	private void OnMontageStop(UAnimMontage montage, bool bInterrupted)
	{
		if (this.AnimInst.Montage_IsActive(montage))
		{
			return;
		}
		if (montage != this.CurrentMontage)
		{
			return;
		}
		this.UnsubscribeMontageEvents();
		this.ClearAndDoCallback(bInterrupted);
	}

	// Token: 0x06019073 RID: 102515 RVA: 0x0071A5E8 File Offset: 0x007187E8
	private void OnMontageBlendingOut(UAnimMontage montage, bool bInterrupted)
	{
		if (montage != this.CurrentMontage)
		{
			return;
		}
		Action<UAnimMontage, bool> onBlendOutCallback = this.OnBlendOut;
		if (this.NeedQueue)
		{
			this.CallbackQueue.Push(delegate
			{
				Action<UAnimMontage, bool> onBlendOutCallback2 = onBlendOutCallback;
				if (onBlendOutCallback2 == null)
				{
					return;
				}
				onBlendOutCallback2(montage, bInterrupted);
			});
			return;
		}
		Action<UAnimMontage, bool> onBlendOutCallback3 = onBlendOutCallback;
		if (onBlendOutCallback3 == null)
		{
			return;
		}
		onBlendOutCallback3(montage, bInterrupted);
	}

	// Token: 0x06019074 RID: 102516 RVA: 0x0071A660 File Offset: 0x00718860
	private void ClearAndDoCallback(bool bInterrupted = true)
	{
		int handleId = this.HandleId;
		this.HandleId++;
		if (this.LoadHandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandleId);
		}
		UAnimMontage montage = this.CurrentMontage;
		bool flag = this.CurrentMontage == null && string.IsNullOrEmpty(this.CurrentMontagePath);
		this.LoadHandleId = -1;
		this.Duration = 0f;
		this.CurrentMontage = null;
		this.CurrentMontagePath = null;
		Action<UAnimMontage> onPlayCallback = this.OnPlay;
		Action<UAnimMontage, bool> onEndCallback = this.OnEnd;
		this.OnPlay = null;
		this.OnEnd = null;
		this.OnBlendOut = null;
		if (flag)
		{
			return;
		}
		if (montage == null)
		{
			if (this.NeedQueue)
			{
				this.CallbackQueue.Push(delegate
				{
					Action<UAnimMontage> onPlayCallback2 = onPlayCallback;
					if (onPlayCallback2 == null)
					{
						return;
					}
					onPlayCallback2(null);
				});
			}
			else
			{
				Action<UAnimMontage> onPlayCallback3 = onPlayCallback;
				if (onPlayCallback3 != null)
				{
					onPlayCallback3(null);
				}
			}
		}
		if (this.NeedQueue)
		{
			this.CallbackQueue.Push(delegate
			{
				this.TryResetBlinkCurveState(handleId);
				Action<UAnimMontage, bool> onEndCallback2 = onEndCallback;
				if (onEndCallback2 != null)
				{
					onEndCallback2(montage, bInterrupted);
				}
				Singleton<EventSystem>.Instance.EmitWithTarget<int>(this.EntityHandle, EEventName.PerformMontageStop, handleId);
			});
			return;
		}
		this.TryResetBlinkCurveState(handleId);
		Action<UAnimMontage, bool> onEndCallback3 = onEndCallback;
		if (onEndCallback3 != null)
		{
			onEndCallback3(montage, bInterrupted);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<int>(this.EntityHandle, EEventName.PerformMontageStop, handleId);
	}

	// Token: 0x06019075 RID: 102517 RVA: 0x0071A7C6 File Offset: 0x007189C6
	private void SetBlinkCurveState(int handleId, bool disable)
	{
		if (disable)
		{
			this.BlinkCurveOwnerHandleId = new int?(handleId);
			this.AnimComp.IgnoreMontageBlinkCurve = true;
			return;
		}
		this.BlinkCurveOwnerHandleId = null;
		this.AnimComp.IgnoreMontageBlinkCurve = false;
	}

	// Token: 0x06019076 RID: 102518 RVA: 0x0071A7FC File Offset: 0x007189FC
	private void TryResetBlinkCurveState(int handleId)
	{
		int? blinkCurveOwnerHandleId = this.BlinkCurveOwnerHandleId;
		if (!(blinkCurveOwnerHandleId.GetValueOrDefault() == handleId & blinkCurveOwnerHandleId != null))
		{
			return;
		}
		this.BlinkCurveOwnerHandleId = null;
		this.AnimComp.IgnoreMontageBlinkCurve = false;
	}

	// Token: 0x06019077 RID: 102519 RVA: 0x0071A840 File Offset: 0x00718A40
	[NullableContext(1)]
	private unsafe bool CheckMontage(UAnimMontage montage)
	{
		string slotGroupName = PerformGroupHelper.GetSlotGroupName(this.Group);
		if (slotGroupName == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BasePerform;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[Montage] 未知的PerformGroup";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("group", this.Group);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("pbDataId", this.EntityHandle.PbDataId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		BaseAnimationComponent animComp = this.AnimComp;
		USkeleton uskeleton = (animComp != null) ? animComp.GetSkeleton() : null;
		if (uskeleton == null)
		{
			return true;
		}
		HashSet<string> hashSet = new HashSet<string>();
		TArray<FAnimSlotGroup> slotGroups = uskeleton.SlotGroups;
		for (int i = 0; i < slotGroups.Num(); i++)
		{
			FAnimSlotGroup fanimSlotGroup = slotGroups.Get(i);
			if (fanimSlotGroup.GroupName.ToString() == slotGroupName)
			{
				TArray<FName> slotNames = fanimSlotGroup.SlotNames;
				for (int j = 0; j < slotNames.Num(); j++)
				{
					hashSet.Add(slotNames.Get(j).ToString());
				}
				break;
			}
		}
		if (hashSet.Count == 0)
		{
			return true;
		}
		TArray<FSlotAnimationTrack> slotAnimTracks = montage.SlotAnimTracks;
		int num = slotAnimTracks.Num();
		for (int k = 0; k < num; k++)
		{
			FSlotAnimationTrack fslotAnimationTrack = slotAnimTracks.Get(k);
			if (!hashSet.Contains(fslotAnimationTrack.SlotName.ToString()))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.BasePerform;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "[Montage] 蒙太奇Slot不属于目标SlotGroup";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("montage", montage);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("slot", fslotAnimationTrack.SlotName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("group", this.Group);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("slotGroup", slotGroupName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("pbDataId", this.EntityHandle.PbDataId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
				return false;
			}
		}
		return true;
	}

	// Token: 0x06019078 RID: 102520 RVA: 0x0071AA94 File Offset: 0x00718C94
	public void OnTick(float delta)
	{
		if (this.Duration <= 0f)
		{
			return;
		}
		this.Duration -= delta;
		if (this.Duration <= 0f)
		{
			this.StopMontage(this.DelayStopParam);
			this.DelayStopParam = null;
			this.Duration = 0f;
		}
	}

	// Token: 0x06019079 RID: 102521 RVA: 0x0071AAE8 File Offset: 0x00718CE8
	public float GetRemainDuration(int id)
	{
		if (this.HandleId != id)
		{
			return 0f;
		}
		return this.Duration;
	}

	// Token: 0x0601907A RID: 102522 RVA: 0x0071AAFF File Offset: 0x00718CFF
	public UAnimMontage GetCurrentMontage()
	{
		if (!ObjectUtils.IsValid(this.CurrentMontage))
		{
			return null;
		}
		return this.CurrentMontage;
	}

	// Token: 0x0601907B RID: 102523 RVA: 0x0071AB16 File Offset: 0x00718D16
	public string GetCurrentMontagePath()
	{
		if (!string.IsNullOrEmpty(this.CurrentMontagePath))
		{
			return this.CurrentMontagePath;
		}
		if (this.CurrentMontage != null)
		{
			return UKismetSystemLibrary.GetPathName(this.CurrentMontage);
		}
		return null;
	}

	// Token: 0x0400C3D5 RID: 50133
	private const float MONTAGE_BLEND_TIME = 0.5f;

	// Token: 0x0400C3D6 RID: 50134
	private const int LOADING_ID = -2;

	// Token: 0x0400C3D7 RID: 50135
	private int HandleId = 1;

	// Token: 0x0400C3D8 RID: 50136
	private bool bSubscribed;

	// Token: 0x0400C3D9 RID: 50137
	private BaseAnimationComponent AnimComp;

	// Token: 0x0400C3DA RID: 50138
	private EntityHandle EntityHandle;

	// Token: 0x0400C3DB RID: 50139
	private EPerformGroup Group;

	// Token: 0x0400C3DC RID: 50140
	private int LoadHandleId = -1;

	// Token: 0x0400C3DD RID: 50141
	private float Duration;

	// Token: 0x0400C3DE RID: 50142
	private IStopMontageParam DelayStopParam;

	// Token: 0x0400C3DF RID: 50143
	private Action<UAnimMontage> OnPlay;

	// Token: 0x0400C3E0 RID: 50144
	private Action<UAnimMontage, bool> OnEnd;

	// Token: 0x0400C3E1 RID: 50145
	private Action<UAnimMontage, bool> OnBlendOut;

	// Token: 0x0400C3E2 RID: 50146
	private UAnimMontage CurrentMontage;

	// Token: 0x0400C3E3 RID: 50147
	private string CurrentMontagePath;

	// Token: 0x0400C3E4 RID: 50148
	private bool NeedQueue;

	// Token: 0x0400C3E5 RID: 50149
	private UAnimMontage LastMontage;

	// Token: 0x0400C3E6 RID: 50150
	private int? BlinkCurveOwnerHandleId;

	// Token: 0x0400C3E7 RID: 50151
	[Nullable(1)]
	private readonly Queue<Action> CallbackQueue = new Queue<Action>(4);
}
