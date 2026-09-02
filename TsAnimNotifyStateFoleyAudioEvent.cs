using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Audio;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D4C RID: 3404
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateFoleyAudioEvent.TsAnimNotifyStateFoleyAudioEvent_C")]
public class TsAnimNotifyStateFoleyAudioEvent : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003D9 RID: 985
	// (get) Token: 0x060047F8 RID: 18424 RVA: 0x00097544 File Offset: 0x00095744
	// (set) Token: 0x060047F9 RID: 18425 RVA: 0x00097554 File Offset: 0x00095754
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe E_FoleyVariant Variant
	{
		get
		{
			return (E_FoleyVariant)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateFoleyAudioEvent.__PropertyOffset_Variant));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateFoleyAudioEvent.__PropertyOffset_Variant) = (byte)value;
		}
	}

	// Token: 0x170003DA RID: 986
	// (get) Token: 0x060047FA RID: 18426 RVA: 0x00097565 File Offset: 0x00095765
	// (set) Token: 0x060047FB RID: 18427 RVA: 0x00097575 File Offset: 0x00095775
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FadeDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateFoleyAudioEvent.__PropertyOffset_FadeDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateFoleyAudioEvent.__PropertyOffset_FadeDuration) = value;
		}
	}

	// Token: 0x170003DB RID: 987
	// (get) Token: 0x060047FC RID: 18428 RVA: 0x00097586 File Offset: 0x00095786
	// (set) Token: 0x060047FD RID: 18429 RVA: 0x00097596 File Offset: 0x00095796
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAudioFadeCurve FadeCurve
	{
		get
		{
			return (EAudioFadeCurve)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateFoleyAudioEvent.__PropertyOffset_FadeCurve));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateFoleyAudioEvent.__PropertyOffset_FadeCurve) = (byte)value;
		}
	}

	// Token: 0x060047FE RID: 18430 RVA: 0x000975A8 File Offset: 0x000957A8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
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

	// Token: 0x060047FF RID: 18431 RVA: 0x00097650 File Offset: 0x00095850
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (!this.InitVariables)
		{
			this.InitVariables = true;
			this.HandleMap = new Dictionary<int, FoleyEventHandle>();
		}
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
		BaseTagComponent baseTagComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent != null && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["系统.活动.声骸对战.bvb镜头"]))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entityNoBlueprint2 = (owner as TsBaseCharacter).GetEntityNoBlueprint();
		RoleAudioComponent roleAudioComponent = (entityNoBlueprint2 != null) ? entityNoBlueprint2.GetComponent<RoleAudioComponent>() : null;
		if (characterActorComponent == null || roleAudioComponent == null)
		{
			return false;
		}
		roleAudioComponent.ChangeFoleyVariant(this.Variant);
		UAkComponent uakComponent = (roleAudioComponent != null) ? roleAudioComponent.GetAkComponent(null) : null;
		string foleyEvent = roleAudioComponent.GetFoleyEvent();
		if (uakComponent != null && foleyEvent != null)
		{
			int id = Singleton<AudioSystem>.Instance.PostEvent(foleyEvent, uakComponent, null);
			this.HandleMap[characterActorComponent.Entity.Id] = new FoleyEventHandle(id, foleyEvent);
		}
		return true;
	}

	// Token: 0x06004800 RID: 18432 RVA: 0x00097758 File Offset: 0x00095958
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004801 RID: 18433 RVA: 0x000977F8 File Offset: 0x000959F8
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return false;
		}
		Dictionary<int, FoleyEventHandle> handleMap = this.HandleMap;
		FoleyEventHandle foleyEventHandle = (handleMap != null) ? handleMap.GetValueOrDefault(characterActorComponent.Entity.Id) : null;
		if (foleyEventHandle != null)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(foleyEventHandle.Id, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(this.FadeDuration),
				TransitionFadeCurve = new EAudioFadeCurve?(this.FadeCurve)
			}));
			this.HandleMap.Remove(characterActorComponent.Entity.Id);
		}
		return true;
	}

	// Token: 0x06004802 RID: 18434 RVA: 0x000978A3 File Offset: 0x00095AA3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateFoleyAudioEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateFoleyAudioEvent.TsAnimNotifyStateFoleyAudioEvent_C");
		}
		return TsAnimNotifyStateFoleyAudioEvent._ClassPtr;
	}

	// Token: 0x06004803 RID: 18435 RVA: 0x000978C8 File Offset: 0x00095AC8
	public TsAnimNotifyStateFoleyAudioEvent() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateFoleyAudioEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004804 RID: 18436 RVA: 0x000978F0 File Offset: 0x00095AF0
	[NullableContext(1)]
	public TsAnimNotifyStateFoleyAudioEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateFoleyAudioEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004805 RID: 18437 RVA: 0x00097923 File Offset: 0x00095B23
	protected TsAnimNotifyStateFoleyAudioEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004806 RID: 18438 RVA: 0x0009792C File Offset: 0x00095B2C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004807 RID: 18439 RVA: 0x00097968 File Offset: 0x00095B68
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040013FB RID: 5115
	private const int DEFAULT_FADE_DURATION = 500;

	// Token: 0x040013FC RID: 5116
	private bool InitVariables;

	// Token: 0x040013FD RID: 5117
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, FoleyEventHandle> HandleMap;

	// Token: 0x040013FE RID: 5118
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateFoleyAudioEvent.TsAnimNotifyStateFoleyAudioEvent_C";

	// Token: 0x040013FF RID: 5119
	private static IntPtr _ClassPtr;

	// Token: 0x04001400 RID: 5120
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001401 RID: 5121
	private static int __PropertyOffset_Variant;

	// Token: 0x04001402 RID: 5122
	private static int __PropertyOffset_FadeDuration;

	// Token: 0x04001403 RID: 5123
	private static int __PropertyOffset_FadeCurve;
}
