using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D28 RID: 3368
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAudioEvent.TsAnimNotifyStateAudioEvent_C")]
public class TsAnimNotifyStateAudioEvent : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06004528 RID: 17704 RVA: 0x000890AC File Offset: 0x000872AC
	// (set) Token: 0x06004529 RID: 17705 RVA: 0x000890E5 File Offset: 0x000872E5
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAkAudioEvent> AudioEvent
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAkAudioEvent> result;
			if ((result = this._AudioEvent) == null)
			{
				result = (this._AudioEvent = new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_AudioEvent, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_AudioEvent, 1);
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x0600452A RID: 17706 RVA: 0x0008910A File Offset: 0x0008730A
	// (set) Token: 0x0600452B RID: 17707 RVA: 0x0008911E File Offset: 0x0008731E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_SocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_SocketName) = value;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x0600452C RID: 17708 RVA: 0x00089133 File Offset: 0x00087333
	// (set) Token: 0x0600452D RID: 17709 RVA: 0x00089143 File Offset: 0x00087343
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Follow
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_Follow) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_Follow) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x0600452E RID: 17710 RVA: 0x00089154 File Offset: 0x00087354
	// (set) Token: 0x0600452F RID: 17711 RVA: 0x00089164 File Offset: 0x00087364
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool KeepAlive
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_KeepAlive) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_KeepAlive) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06004530 RID: 17712 RVA: 0x00089175 File Offset: 0x00087375
	// (set) Token: 0x06004531 RID: 17713 RVA: 0x00089185 File Offset: 0x00087385
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FadeDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_FadeDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_FadeDuration) = value;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06004532 RID: 17714 RVA: 0x00089196 File Offset: 0x00087396
	// (set) Token: 0x06004533 RID: 17715 RVA: 0x000891A6 File Offset: 0x000873A6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAudioFadeCurve FadeCurve
	{
		get
		{
			return (EAudioFadeCurve)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_FadeCurve));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_FadeCurve) = (byte)value;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06004534 RID: 17716 RVA: 0x000891B8 File Offset: 0x000873B8
	// (set) Token: 0x06004535 RID: 17717 RVA: 0x000891F1 File Offset: 0x000873F1
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAkAudioEvent> TrailingAudioEvent
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAkAudioEvent> result;
			if ((result = this._TrailingAudioEvent) == null)
			{
				result = (this._TrailingAudioEvent = new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_TrailingAudioEvent, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_TrailingAudioEvent, 1);
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x06004536 RID: 17718 RVA: 0x00089218 File Offset: 0x00087418
	// (set) Token: 0x06004537 RID: 17719 RVA: 0x00089251 File Offset: 0x00087451
	[UProperty(EPropertyFlags.CPF_None)]
	public SAudioEventProbabilityCooldownInfo TagProbabilityInfo
	{
		get
		{
			base.FastCheckIsValid();
			SAudioEventProbabilityCooldownInfo result;
			if ((result = this._TagProbabilityInfo) == null)
			{
				result = (this._TagProbabilityInfo = new SAudioEventProbabilityCooldownInfo(base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_TagProbabilityInfo, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SAudioEventProbabilityCooldownInfo.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateAudioEvent.__PropertyOffset_TagProbabilityInfo, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06004538 RID: 17720 RVA: 0x0008927C File Offset: 0x0008747C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004539 RID: 17721 RVA: 0x000892F7 File Offset: 0x000874F7
	protected override string GetNotifyName_Implementation()
	{
		if (!(this.AudioEvent != null))
		{
			return "AudioEvent";
		}
		return "AudioEvent: " + Singleton<AudioSystem>.Instance.parseAudioEventPath(this.AudioEvent);
	}

	// Token: 0x0600453A RID: 17722 RVA: 0x00089328 File Offset: 0x00087528
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animSequence != null) ? animSequence.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600453B RID: 17723 RVA: 0x000893D0 File Offset: 0x000875D0
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence, float totalDuration)
	{
		this.NotifyDuration = totalDuration;
		if (this.AudioEvent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.MSY;
			string message = "[Game.AnimNotifyState] 无效的 AudioEvent";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AnimNotify", this);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AnimSequence", UKismetSystemLibrary.GetPathName(animSequence));
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		string text = this.AudioEvent.ToAssetPathName();
		UObject outer = meshComponent.GetOuter();
		if (Singleton<Info>.Instance.IsGameRunning())
		{
			if (outer is TsBaseCharacter)
			{
				Entity entityNoBlueprint = (outer as TsBaseCharacter).GetEntityNoBlueprint();
				BaseTagComponent baseTagComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseTagComponent>() : null;
				if (baseTagComponent != null && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["系统.活动.声骸对战.bvb镜头"]))
				{
					return false;
				}
				CharacterActorComponent characterActorComponent = (outer as TsBaseCharacter).CharacterActorComponent;
				text = (((characterActorComponent != null) ? characterActorComponent.GetReplaceEffect(text) : null) ?? text);
			}
		}
		else
		{
			text = EffectUtil.GetPreviewReplaceEffectPath(text);
		}
		string text2 = (this.AudioEvent != null) ? Singleton<AudioSystem>.Instance.parseAudioEventPath(text) : null;
		if (text2 != null)
		{
			bool flag = true;
			TsBaseCharacter tsBaseCharacter = meshComponent.GetOwner() as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
				Entity entity = (characterActorComponent2 != null) ? characterActorComponent2.Entity : null;
				if (entity != null)
				{
					flag = ModelBase<GameAudioModel>.Instance.CheckAudioProbabilityInfo(entity.Id, text2, new AudioCoolDownWithTagInfo
					{
						DefaultProbability = (double)this.TagProbabilityInfo.DefaultProbability,
						DefaultCooldownTime = this.TagProbabilityInfo.DefaultCooldownTime,
						TagProbability = this.TagProbabilityInfo.TagProbability
					}, true, true, true);
				}
			}
			if (!flag)
			{
				return true;
			}
			this.PostAudioEvent(text2, meshComponent, animSequence);
		}
		return true;
	}

	// Token: 0x0600453C RID: 17724 RVA: 0x00089588 File Offset: 0x00087788
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animSequence != null) ? animSequence.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600453D RID: 17725 RVA: 0x00089628 File Offset: 0x00087828
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		if (this.KeepAlive && base.CurrentTimeLength > this.NotifyDuration)
		{
			return false;
		}
		if (meshComponent == null)
		{
			return false;
		}
		AActor owner = meshComponent.GetOwner();
		if (owner == null || !owner.IsValid())
		{
			return false;
		}
		if (GlobalData.GameInstance == null)
		{
			int num;
			if (this.HandleMap.TryGetValue(owner, out num) && num != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(num, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(this.FadeDuration),
					TransitionFadeCurve = new EAudioFadeCurve?(this.FadeCurve)
				}));
				this.HandleMap.Remove(owner);
			}
			return true;
		}
		int num2;
		if (!this.HandleMap.TryGetValue(owner, out num2) || num2 == 0)
		{
			return true;
		}
		Singleton<AudioSystem>.Instance.ExecuteAction(num2, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
		{
			TransitionDuration = new int?(this.FadeDuration),
			TransitionFadeCurve = new EAudioFadeCurve?(this.FadeCurve)
		}));
		this.HandleMap.Remove(owner);
		ControllerBase<GameAudioController>.Instance.RemoveEvent(owner, num2);
		string text = (this.TrailingAudioEvent != null) ? Singleton<AudioSystem>.Instance.parseAudioEventPath(this.TrailingAudioEvent) : null;
		if (text != null)
		{
			this.PostAudioEvent(text, meshComponent, animSequence);
		}
		return true;
	}

	// Token: 0x0600453E RID: 17726 RVA: 0x00089770 File Offset: 0x00087970
	private void PostAudioEvent(string eventName, USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		AActor owner = meshComponent.GetOwner();
		if (owner == null || !owner.IsValid())
		{
			return;
		}
		if (GlobalData.GameInstance == null)
		{
			UAkComponent akComponent = Singleton<AudioSystem>.Instance.GetAkComponent(owner, new FName?(this.SocketName), null);
			if (akComponent == null || !akComponent.IsValid())
			{
				return;
			}
			int num = Singleton<AudioSystem>.Instance.PostEvent(eventName, akComponent, null);
			if (num != 0)
			{
				this.StopExistingHandle(owner);
				this.HandleMap[owner] = num;
			}
			return;
		}
		else if (this.Follow)
		{
			int num2 = ControllerBase<GameAudioController>.Instance.PostEvent(owner, eventName, new FName?(this.SocketName));
			if (num2 == 0)
			{
				return;
			}
			this.StopExistingHandle(owner);
			this.HandleMap[owner] = num2;
			return;
		}
		else
		{
			FTransformDouble value = meshComponent.D_GetSocketTransform(this.SocketName, ERelativeTransformSpace.RTS_World);
			int num3 = Singleton<AudioSystem>.Instance.PostEvent(eventName, new FTransformDouble?(value), null);
			if (num3 == 0)
			{
				return;
			}
			this.StopExistingHandle(owner);
			this.HandleMap[owner] = num3;
			return;
		}
	}

	// Token: 0x0600453F RID: 17727 RVA: 0x0008987C File Offset: 0x00087A7C
	private void StopExistingHandle(AActor owner)
	{
		int num;
		if (this.HandleMap.TryGetValue(owner, out num) && num != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(num, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(this.FadeDuration),
				TransitionFadeCurve = new EAudioFadeCurve?(this.FadeCurve)
			}));
		}
	}

	// Token: 0x06004540 RID: 17728 RVA: 0x000898DA File Offset: 0x00087ADA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAudioEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAudioEvent.TsAnimNotifyStateAudioEvent_C");
		}
		return TsAnimNotifyStateAudioEvent._ClassPtr;
	}

	// Token: 0x06004541 RID: 17729 RVA: 0x00089900 File Offset: 0x00087B00
	public TsAnimNotifyStateAudioEvent() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAudioEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004542 RID: 17730 RVA: 0x00089928 File Offset: 0x00087B28
	public TsAnimNotifyStateAudioEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAudioEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004543 RID: 17731 RVA: 0x0008995B File Offset: 0x00087B5B
	protected TsAnimNotifyStateAudioEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004544 RID: 17732 RVA: 0x0008996F File Offset: 0x00087B6F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x06004545 RID: 17733 RVA: 0x00089984 File Offset: 0x00087B84
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004546 RID: 17734 RVA: 0x000899C0 File Offset: 0x00087BC0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400127B RID: 4731
	private const int DEFAULT_FADE_DURATION = 500;

	// Token: 0x0400127C RID: 4732
	private float NotifyDuration;

	// Token: 0x0400127D RID: 4733
	private readonly Dictionary<AActor, int> HandleMap = new Dictionary<AActor, int>();

	// Token: 0x0400127E RID: 4734
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAudioEvent.TsAnimNotifyStateAudioEvent_C";

	// Token: 0x0400127F RID: 4735
	private static IntPtr _ClassPtr;

	// Token: 0x04001280 RID: 4736
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001281 RID: 4737
	private static int __PropertyOffset_AudioEvent;

	// Token: 0x04001282 RID: 4738
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAkAudioEvent> _AudioEvent;

	// Token: 0x04001283 RID: 4739
	private static int __PropertyOffset_SocketName;

	// Token: 0x04001284 RID: 4740
	private static int __PropertyOffset_Follow;

	// Token: 0x04001285 RID: 4741
	private static int __PropertyOffset_KeepAlive;

	// Token: 0x04001286 RID: 4742
	private static int __PropertyOffset_FadeDuration;

	// Token: 0x04001287 RID: 4743
	private static int __PropertyOffset_FadeCurve;

	// Token: 0x04001288 RID: 4744
	private static int __PropertyOffset_TrailingAudioEvent;

	// Token: 0x04001289 RID: 4745
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAkAudioEvent> _TrailingAudioEvent;

	// Token: 0x0400128A RID: 4746
	private static int __PropertyOffset_TagProbabilityInfo;

	// Token: 0x0400128B RID: 4747
	[Nullable(2)]
	private SAudioEventProbabilityCooldownInfo _TagProbabilityInfo;
}
