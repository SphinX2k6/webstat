using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020032C4 RID: 12996
[UClass("/Game/Aki/TypeScript/Game/Recorder/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyAddCharRendering.TsAnimNotifyAddCharRendering_C")]
public class TsAnimNotifyAddCharRendering : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002523 RID: 9507
	// (get) Token: 0x0601B3D3 RID: 111571 RVA: 0x0082EEA7 File Offset: 0x0082D0A7
	// (set) Token: 0x0601B3D4 RID: 111572 RVA: 0x0082EEB7 File Offset: 0x0082D0B7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECharacterRenderingType RenderType
	{
		get
		{
			return (ECharacterRenderingType)(*(base.NativePtr + (IntPtr)TsAnimNotifyAddCharRendering.__PropertyOffset_RenderType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAddCharRendering.__PropertyOffset_RenderType) = (byte)value;
		}
	}

	// Token: 0x0601B3D5 RID: 111573 RVA: 0x0082EEC8 File Offset: 0x0082D0C8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x0601B3D6 RID: 111574 RVA: 0x0082EF68 File Offset: 0x0082D168
	[NullableContext(1)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp == null)
		{
			return false;
		}
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

	// Token: 0x0601B3D7 RID: 111575 RVA: 0x0082EFE0 File Offset: 0x0082D1E0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyAddCharRendering._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyAddCharRendering.TsAnimNotifyAddCharRendering_C");
		}
		return TsAnimNotifyAddCharRendering._ClassPtr;
	}

	// Token: 0x0601B3D8 RID: 111576 RVA: 0x0082F004 File Offset: 0x0082D204
	public TsAnimNotifyAddCharRendering() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddCharRendering.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601B3D9 RID: 111577 RVA: 0x0082F02C File Offset: 0x0082D22C
	[NullableContext(1)]
	public TsAnimNotifyAddCharRendering(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddCharRendering.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601B3DA RID: 111578 RVA: 0x0082F05F File Offset: 0x0082D25F
	protected TsAnimNotifyAddCharRendering(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601B3DB RID: 111579 RVA: 0x0082F068 File Offset: 0x0082D268
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400DE0A RID: 56842
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyAddCharRendering.TsAnimNotifyAddCharRendering_C";

	// Token: 0x0400DE0B RID: 56843
	private static IntPtr _ClassPtr;

	// Token: 0x0400DE0C RID: 56844
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DE0D RID: 56845
	private static int __PropertyOffset_RenderType;
}
