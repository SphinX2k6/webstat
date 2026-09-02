using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020032C5 RID: 12997
[UClass("/Game/Aki/TypeScript/Game/Recorder/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddCharRendering.TsAnimNotifyStateAddCharRendering_C")]
public class TsAnimNotifyStateAddCharRendering : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002524 RID: 9508
	// (get) Token: 0x0601B3DC RID: 111580 RVA: 0x0082F09B File Offset: 0x0082D29B
	// (set) Token: 0x0601B3DD RID: 111581 RVA: 0x0082F0AB File Offset: 0x0082D2AB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECharacterRenderingType RenderType
	{
		get
		{
			return (ECharacterRenderingType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddCharRendering.__PropertyOffset_RenderType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddCharRendering.__PropertyOffset_RenderType) = (byte)value;
		}
	}

	// Token: 0x0601B3DE RID: 111582 RVA: 0x0082F0BC File Offset: 0x0082D2BC
	[NullableContext(1)]
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

	// Token: 0x0601B3DF RID: 111583 RVA: 0x0082F164 File Offset: 0x0082D364
	[NullableContext(1)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AKuroRecordCharacter akuroRecordCharacter = meshComp.GetOwner() as AKuroRecordCharacter;
		if (akuroRecordCharacter == null)
		{
			return false;
		}
		AActor aactor = akuroRecordCharacter;
		TSubclassOf<UActorComponent> @class = CharRenderingComponent.StaticClass();
		bool bManualAttachment = false;
		FTransformDouble ftransformDouble = akuroRecordCharacter.D_GetTransform();
		CharRenderingComponent charRenderingComponent = aactor.D_AddComponentByClass(@class, bManualAttachment, ftransformDouble, false, FNameUtil.GetDynamicFName("CharRenderingComponent") ?? FName.NAME_None) as CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return false;
		}
		charRenderingComponent.Init(this.RenderType);
		return true;
	}

	// Token: 0x0601B3E0 RID: 111584 RVA: 0x0082F1D7 File Offset: 0x0082D3D7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAddCharRendering._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddCharRendering.TsAnimNotifyStateAddCharRendering_C");
		}
		return TsAnimNotifyStateAddCharRendering._ClassPtr;
	}

	// Token: 0x0601B3E1 RID: 111585 RVA: 0x0082F1FC File Offset: 0x0082D3FC
	public TsAnimNotifyStateAddCharRendering() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddCharRendering.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601B3E2 RID: 111586 RVA: 0x0082F224 File Offset: 0x0082D424
	[NullableContext(1)]
	public TsAnimNotifyStateAddCharRendering(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddCharRendering.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601B3E3 RID: 111587 RVA: 0x0082F257 File Offset: 0x0082D457
	protected TsAnimNotifyStateAddCharRendering(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601B3E4 RID: 111588 RVA: 0x0082F260 File Offset: 0x0082D460
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0400DE0E RID: 56846
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddCharRendering.TsAnimNotifyStateAddCharRendering_C";

	// Token: 0x0400DE0F RID: 56847
	private static IntPtr _ClassPtr;

	// Token: 0x0400DE10 RID: 56848
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DE11 RID: 56849
	private static int __PropertyOffset_RenderType;
}
