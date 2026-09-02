using System;
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

// Token: 0x02000DA7 RID: 3495
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAudioEvent.TsAnimNotifyAudioEvent_C")]
public class TsAnimNotifyAudioEvent : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004E3 RID: 1251
	// (get) Token: 0x06004E8D RID: 20109 RVA: 0x000B35C0 File Offset: 0x000B17C0
	// (set) Token: 0x06004E8E RID: 20110 RVA: 0x000B35F9 File Offset: 0x000B17F9
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAkAudioEvent> AudioEvent
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAkAudioEvent> result;
			if ((result = this._AudioEvent) == null)
			{
				result = (this._AudioEvent = new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_AudioEvent, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_AudioEvent, 1);
		}
	}

	// Token: 0x170004E4 RID: 1252
	// (get) Token: 0x06004E8F RID: 20111 RVA: 0x000B361E File Offset: 0x000B181E
	// (set) Token: 0x06004E90 RID: 20112 RVA: 0x000B3632 File Offset: 0x000B1832
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_SocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_SocketName) = value;
		}
	}

	// Token: 0x170004E5 RID: 1253
	// (get) Token: 0x06004E91 RID: 20113 RVA: 0x000B3647 File Offset: 0x000B1847
	// (set) Token: 0x06004E92 RID: 20114 RVA: 0x000B3657 File Offset: 0x000B1857
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Follow
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_Follow) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_Follow) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004E6 RID: 1254
	// (get) Token: 0x06004E93 RID: 20115 RVA: 0x000B3668 File Offset: 0x000B1868
	// (set) Token: 0x06004E94 RID: 20116 RVA: 0x000B36A1 File Offset: 0x000B18A1
	[UProperty(EPropertyFlags.CPF_None)]
	public SAudioEventProbabilityCooldownInfo TagProbabilityInfo
	{
		get
		{
			base.FastCheckIsValid();
			SAudioEventProbabilityCooldownInfo result;
			if ((result = this._TagProbabilityInfo) == null)
			{
				result = (this._TagProbabilityInfo = new SAudioEventProbabilityCooldownInfo(base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_TagProbabilityInfo, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SAudioEventProbabilityCooldownInfo.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyAudioEvent.__PropertyOffset_TagProbabilityInfo, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06004E95 RID: 20117 RVA: 0x000B36CC File Offset: 0x000B18CC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004E96 RID: 20118 RVA: 0x000B3747 File Offset: 0x000B1947
	protected override string GetNotifyName_Implementation()
	{
		if (!(this.AudioEvent != null))
		{
			return "AudioEvent";
		}
		return "AudioEvent: " + Singleton<AudioSystem>.Instance.parseAudioEventPath(this.AudioEvent);
	}

	// Token: 0x06004E97 RID: 20119 RVA: 0x000B3778 File Offset: 0x000B1978
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x06004E98 RID: 20120 RVA: 0x000B3818 File Offset: 0x000B1A18
	[NullableContext(2)]
	protected unsafe virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		if (this.AudioEvent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.MSY;
			string message = "[Game.AnimNotify] 无效的 AudioEvent";
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
			TsBaseCharacter tsBaseCharacter = outer as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				text = (((characterActorComponent != null) ? characterActorComponent.GetReplaceEffect(text) : null) ?? text);
			}
		}
		else
		{
			text = EffectUtil.GetPreviewReplaceEffectPath(text);
		}
		string text2 = Singleton<AudioSystem>.Instance.parseAudioEventPath(text);
		if (text2 != null)
		{
			bool flag = true;
			TsBaseCharacter tsBaseCharacter2 = meshComponent.GetOwner() as TsBaseCharacter;
			if (tsBaseCharacter2 != null)
			{
				CharacterActorComponent characterActorComponent2 = tsBaseCharacter2.CharacterActorComponent;
				Entity entity = (characterActorComponent2 != null) ? characterActorComponent2.Entity : null;
				if (entity != null)
				{
					AudioCoolDownWithTagInfo param = new AudioCoolDownWithTagInfo
					{
						DefaultCooldownTime = this.TagProbabilityInfo.DefaultCooldownTime,
						DefaultProbability = (double)this.TagProbabilityInfo.DefaultProbability,
						TagProbability = this.TagProbabilityInfo.TagProbability
					};
					flag = ModelBase<GameAudioModel>.Instance.CheckAudioProbabilityInfo(entity.Id, text2, param, true, true, true);
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

	// Token: 0x06004E99 RID: 20121 RVA: 0x000B3984 File Offset: 0x000B1B84
	private void PostAudioEvent(string eventName, USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		AActor owner = meshComponent.GetOwner();
		if (owner == null || !owner.IsValid())
		{
			return;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
			BaseTagComponent baseTagComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["系统.活动.声骸对战.bvb镜头"]))
			{
				return;
			}
		}
		if (GlobalData.GameInstance == null)
		{
			UAkComponent akComponent = Singleton<AudioSystem>.Instance.GetAkComponent(owner, new FName?(this.SocketName), null);
			if (akComponent == null || !akComponent.IsValid())
			{
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent(eventName, akComponent, null);
			return;
		}
		else
		{
			if (!this.Follow)
			{
				FTransformDouble value = meshComponent.D_GetSocketTransform(this.SocketName, ERelativeTransformSpace.RTS_World);
				Singleton<AudioSystem>.Instance.PostEvent(eventName, new FTransformDouble?(value), null);
				return;
			}
			UAkComponent akComponent2 = ControllerBase<GameAudioController>.Instance.GetAkComponent(owner, new FName?(this.SocketName));
			if (akComponent2 == null || !akComponent2.IsValid())
			{
				return;
			}
			ControllerBase<GameAudioController>.Instance.PostEvent(owner, eventName, new FName?(this.SocketName));
			return;
		}
	}

	// Token: 0x06004E9A RID: 20122 RVA: 0x000B3AA5 File Offset: 0x000B1CA5
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyAudioEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAudioEvent.TsAnimNotifyAudioEvent_C");
		}
		return TsAnimNotifyAudioEvent._ClassPtr;
	}

	// Token: 0x06004E9B RID: 20123 RVA: 0x000B3ACC File Offset: 0x000B1CCC
	public TsAnimNotifyAudioEvent() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAudioEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E9C RID: 20124 RVA: 0x000B3AF4 File Offset: 0x000B1CF4
	public TsAnimNotifyAudioEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAudioEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E9D RID: 20125 RVA: 0x000B3B27 File Offset: 0x000B1D27
	protected TsAnimNotifyAudioEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E9E RID: 20126 RVA: 0x000B3B30 File Offset: 0x000B1D30
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x06004E9F RID: 20127 RVA: 0x000B3B44 File Offset: 0x000B1D44
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040016C8 RID: 5832
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAudioEvent.TsAnimNotifyAudioEvent_C";

	// Token: 0x040016C9 RID: 5833
	private static IntPtr _ClassPtr;

	// Token: 0x040016CA RID: 5834
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016CB RID: 5835
	private static int __PropertyOffset_AudioEvent;

	// Token: 0x040016CC RID: 5836
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAkAudioEvent> _AudioEvent;

	// Token: 0x040016CD RID: 5837
	private static int __PropertyOffset_SocketName;

	// Token: 0x040016CE RID: 5838
	private static int __PropertyOffset_Follow;

	// Token: 0x040016CF RID: 5839
	private static int __PropertyOffset_TagProbabilityInfo;

	// Token: 0x040016D0 RID: 5840
	[Nullable(2)]
	private SAudioEventProbabilityCooldownInfo _TagProbabilityInfo;
}
