using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot.Sequence;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA2 RID: 3490
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsSeqAnimNotifyStateAudioEvent.TsSeqAnimNotifyStateAudioEvent_C")]
public class TsSeqAnimNotifyStateAudioEvent : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004D3 RID: 1235
	// (get) Token: 0x06004E35 RID: 20021 RVA: 0x000B1D08 File Offset: 0x000AFF08
	// (set) Token: 0x06004E36 RID: 20022 RVA: 0x000B1D41 File Offset: 0x000AFF41
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAkAudioEvent> AudioEvent
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAkAudioEvent> result;
			if ((result = this._AudioEvent) == null)
			{
				result = (this._AudioEvent = new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_AudioEvent, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_AudioEvent, 1);
		}
	}

	// Token: 0x170004D4 RID: 1236
	// (get) Token: 0x06004E37 RID: 20023 RVA: 0x000B1D66 File Offset: 0x000AFF66
	// (set) Token: 0x06004E38 RID: 20024 RVA: 0x000B1D7A File Offset: 0x000AFF7A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_SocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_SocketName) = value;
		}
	}

	// Token: 0x170004D5 RID: 1237
	// (get) Token: 0x06004E39 RID: 20025 RVA: 0x000B1D8F File Offset: 0x000AFF8F
	// (set) Token: 0x06004E3A RID: 20026 RVA: 0x000B1D9F File Offset: 0x000AFF9F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Follow
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_Follow) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_Follow) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004D6 RID: 1238
	// (get) Token: 0x06004E3B RID: 20027 RVA: 0x000B1DB0 File Offset: 0x000AFFB0
	// (set) Token: 0x06004E3C RID: 20028 RVA: 0x000B1DC0 File Offset: 0x000AFFC0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool KeepAlive
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_KeepAlive) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_KeepAlive) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004D7 RID: 1239
	// (get) Token: 0x06004E3D RID: 20029 RVA: 0x000B1DD1 File Offset: 0x000AFFD1
	// (set) Token: 0x06004E3E RID: 20030 RVA: 0x000B1DE1 File Offset: 0x000AFFE1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FadeDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_FadeDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_FadeDuration) = value;
		}
	}

	// Token: 0x170004D8 RID: 1240
	// (get) Token: 0x06004E3F RID: 20031 RVA: 0x000B1DF2 File Offset: 0x000AFFF2
	// (set) Token: 0x06004E40 RID: 20032 RVA: 0x000B1E02 File Offset: 0x000B0002
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAudioFadeCurve FadeCurve
	{
		get
		{
			return (EAudioFadeCurve)(*(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_FadeCurve));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_FadeCurve) = (byte)value;
		}
	}

	// Token: 0x170004D9 RID: 1241
	// (get) Token: 0x06004E41 RID: 20033 RVA: 0x000B1E14 File Offset: 0x000B0014
	// (set) Token: 0x06004E42 RID: 20034 RVA: 0x000B1E4D File Offset: 0x000B004D
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAkAudioEvent> TrailingAudioEvent
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAkAudioEvent> result;
			if ((result = this._TrailingAudioEvent) == null)
			{
				result = (this._TrailingAudioEvent = new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_TrailingAudioEvent, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsSeqAnimNotifyStateAudioEvent.__PropertyOffset_TrailingAudioEvent, 1);
		}
	}

	// Token: 0x06004E43 RID: 20035 RVA: 0x000B1E74 File Offset: 0x000B0074
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

	// Token: 0x06004E44 RID: 20036 RVA: 0x000B1EEF File Offset: 0x000B00EF
	protected override string GetNotifyName_Implementation()
	{
		if (!(this.AudioEvent != null))
		{
			return "AudioEvent";
		}
		return "AudioEvent: " + Singleton<AudioSystem>.Instance.parseAudioEventPath(this.AudioEvent);
	}

	// Token: 0x06004E45 RID: 20037 RVA: 0x000B1F20 File Offset: 0x000B0120
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

	// Token: 0x06004E46 RID: 20038 RVA: 0x000B1FC8 File Offset: 0x000B01C8
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence, float totalDuration)
	{
		if (meshComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "不存在的MeshComp";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AnimNotify", this);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (meshComponent.bHiddenInGame)
		{
			return false;
		}
		bool flag = false;
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(meshComponent.GetOwner());
		if (worldType != BP_EWorldType.Game && worldType != BP_EWorldType.PIE)
		{
			ULevelSequence selectedSequenceInEditor = SequenceUtils.GetSelectedSequenceInEditor();
			if (selectedSequenceInEditor != null)
			{
				flag = selectedSequenceInEditor.GetAnimAudio();
			}
		}
		else
		{
			ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
			bool? flag2;
			if (curLevelSeqActor == null)
			{
				flag2 = null;
			}
			else
			{
				ULevelSequence sequence = curLevelSeqActor.GetSequence();
				flag2 = ((sequence != null) ? new bool?(sequence.GetAnimAudio()) : null);
			}
			bool? flag3 = flag2;
			flag = flag3.GetValueOrDefault();
		}
		if (!flag)
		{
			return false;
		}
		this.NotifyDuration = totalDuration;
		if (this.AudioEvent == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Audio;
			ELogAuthor author2 = ELogAuthor.JYS;
			string message2 = "[Game.AnimNotifyState] 无效的 AudioEvent";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AnimNotify", this);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AnimSequence", UKismetSystemLibrary.GetPathName(animSequence));
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		string text = (this.AudioEvent != null) ? Singleton<AudioSystem>.Instance.parseAudioEventPath(this.AudioEvent) : null;
		if (text != null)
		{
			this.PostAudioEvent(text, meshComponent, animSequence);
		}
		return true;
	}

	// Token: 0x06004E47 RID: 20039 RVA: 0x000B211C File Offset: 0x000B031C
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

	// Token: 0x06004E48 RID: 20040 RVA: 0x000B21BC File Offset: 0x000B03BC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		if (meshComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "[Game.AnimNotify] 不存在的MeshComp";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AnimNotify", this);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (meshComponent.bHiddenInGame)
		{
			return false;
		}
		bool flag = false;
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(meshComponent.GetOwner());
		if (worldType != BP_EWorldType.Game && worldType != BP_EWorldType.PIE)
		{
			ULevelSequence selectedSequenceInEditor = SequenceUtils.GetSelectedSequenceInEditor();
			if (selectedSequenceInEditor != null)
			{
				flag = selectedSequenceInEditor.GetAnimAudio();
			}
		}
		else
		{
			ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
			bool? flag2;
			if (curLevelSeqActor == null)
			{
				flag2 = null;
			}
			else
			{
				ULevelSequence sequence = curLevelSeqActor.GetSequence();
				flag2 = ((sequence != null) ? new bool?(sequence.GetAnimAudio()) : null);
			}
			bool? flag3 = flag2;
			flag = flag3.GetValueOrDefault();
		}
		if (!flag)
		{
			return false;
		}
		if (this.KeepAlive && base.GetCurrentTriggerOffsetInThisNotifyTick() > this.NotifyDuration)
		{
			return false;
		}
		AActor owner = meshComponent.GetOwner();
		if (owner == null)
		{
			return false;
		}
		if (owner.bHidden)
		{
			return false;
		}
		int handle = 0;
		if (owner != null && this.HandleMap.TryGetValue(owner, out handle))
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(this.FadeDuration),
				TransitionFadeCurve = new EAudioFadeCurve?(this.FadeCurve)
			}));
			this.HandleMap.Remove(owner);
			string text = (this.TrailingAudioEvent != null) ? Singleton<AudioSystem>.Instance.parseAudioEventPath(this.TrailingAudioEvent) : null;
			if (text != null)
			{
				this.PostAudioEvent(text, meshComponent, animSequence);
			}
			return true;
		}
		return true;
	}

	// Token: 0x06004E49 RID: 20041 RVA: 0x000B2338 File Offset: 0x000B0538
	private unsafe void PostAudioEvent(string eventName, USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		AActor owner = meshComponent.GetOwner();
		if (owner == null || !owner.IsValid())
		{
			return;
		}
		if (owner.bHidden)
		{
			return;
		}
		if (!SequenceUtils.CheckIfUseAudioSeq(owner))
		{
			return;
		}
		if (!this.Follow)
		{
			FTransformDouble value = meshComponent.D_GetSocketTransform(this.SocketName, ERelativeTransformSpace.RTS_World);
			int value2 = Singleton<AudioSystem>.Instance.PostEvent(eventName, new FTransformDouble?(value), null);
			this.HandleMap.Add(owner, value2);
			return;
		}
		UAkComponent akComponent = Singleton<AudioSystem>.Instance.GetAkComponent(meshComponent, new FName?(this.SocketName), null);
		if (akComponent == null || !akComponent.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "[Game.AnimNotify] 无效的 akComponent";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EventName", eventName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AnimNotify", this);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("AnimSequence", UKismetSystemLibrary.GetPathName(animSequence));
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		int value3 = Singleton<AudioSystem>.Instance.PostEvent(eventName, meshComponent.GetOwner(), null);
		this.HandleMap.Add(owner, value3);
	}

	// Token: 0x06004E4A RID: 20042 RVA: 0x000B247C File Offset: 0x000B067C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSeqAnimNotifyStateAudioEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsSeqAnimNotifyStateAudioEvent.TsSeqAnimNotifyStateAudioEvent_C");
		}
		return TsSeqAnimNotifyStateAudioEvent._ClassPtr;
	}

	// Token: 0x06004E4B RID: 20043 RVA: 0x000B24A0 File Offset: 0x000B06A0
	public TsSeqAnimNotifyStateAudioEvent() : this(BuiltinUtils.AllocNativeUObject(TsSeqAnimNotifyStateAudioEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E4C RID: 20044 RVA: 0x000B24C8 File Offset: 0x000B06C8
	public TsSeqAnimNotifyStateAudioEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSeqAnimNotifyStateAudioEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E4D RID: 20045 RVA: 0x000B24FB File Offset: 0x000B06FB
	protected TsSeqAnimNotifyStateAudioEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E4E RID: 20046 RVA: 0x000B250F File Offset: 0x000B070F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x06004E4F RID: 20047 RVA: 0x000B2524 File Offset: 0x000B0724
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004E50 RID: 20048 RVA: 0x000B2560 File Offset: 0x000B0760
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040016A1 RID: 5793
	private const int DEFAULT_FADE_DURATION = 500;

	// Token: 0x040016A2 RID: 5794
	private float NotifyDuration;

	// Token: 0x040016A3 RID: 5795
	private readonly Dictionary<AActor, int> HandleMap = new Dictionary<AActor, int>();

	// Token: 0x040016A4 RID: 5796
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsSeqAnimNotifyStateAudioEvent.TsSeqAnimNotifyStateAudioEvent_C";

	// Token: 0x040016A5 RID: 5797
	private static IntPtr _ClassPtr;

	// Token: 0x040016A6 RID: 5798
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016A7 RID: 5799
	private static int __PropertyOffset_AudioEvent;

	// Token: 0x040016A8 RID: 5800
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAkAudioEvent> _AudioEvent;

	// Token: 0x040016A9 RID: 5801
	private static int __PropertyOffset_SocketName;

	// Token: 0x040016AA RID: 5802
	private static int __PropertyOffset_Follow;

	// Token: 0x040016AB RID: 5803
	private static int __PropertyOffset_KeepAlive;

	// Token: 0x040016AC RID: 5804
	private static int __PropertyOffset_FadeDuration;

	// Token: 0x040016AD RID: 5805
	private static int __PropertyOffset_FadeCurve;

	// Token: 0x040016AE RID: 5806
	private static int __PropertyOffset_TrailingAudioEvent;

	// Token: 0x040016AF RID: 5807
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAkAudioEvent> _TrailingAudioEvent;
}
