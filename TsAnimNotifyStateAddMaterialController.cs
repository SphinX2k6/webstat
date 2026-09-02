using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020032C6 RID: 12998
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Recorder/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddMaterialController.TsAnimNotifyStateAddMaterialController_C")]
public class TsAnimNotifyStateAddMaterialController : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002525 RID: 9509
	// (get) Token: 0x0601B3E5 RID: 111589 RVA: 0x0082F299 File Offset: 0x0082D499
	// (set) Token: 0x0601B3E6 RID: 111590 RVA: 0x0082F2AD File Offset: 0x0082D4AD
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C ControllerData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddMaterialController.__PropertyOffset_ControllerData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddMaterialController.__PropertyOffset_ControllerData, value);
		}
	}

	// Token: 0x17002526 RID: 9510
	// (get) Token: 0x0601B3E7 RID: 111591 RVA: 0x0082F2C2 File Offset: 0x0082D4C2
	// (set) Token: 0x0601B3E8 RID: 111592 RVA: 0x0082F2D6 File Offset: 0x0082D4D6
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UObject UserData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddMaterialController.__PropertyOffset_UserData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddMaterialController.__PropertyOffset_UserData, value);
		}
	}

	// Token: 0x17002527 RID: 9511
	// (get) Token: 0x0601B3E9 RID: 111593 RVA: 0x0082F2EB File Offset: 0x0082D4EB
	// (set) Token: 0x0601B3EA RID: 111594 RVA: 0x0082F2F3 File Offset: 0x0082D4F3
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<USkeletalMeshComponent, int> Handles { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x0601B3EB RID: 111595 RVA: 0x0082F2FC File Offset: 0x0082D4FC
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

	// Token: 0x0601B3EC RID: 111596 RVA: 0x0082F3A4 File Offset: 0x0082D5A4
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		CharRenderingComponent charRenderingComponent = owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return false;
		}
		if (this.Handles == null)
		{
			this.Handles = new Dictionary<USkeletalMeshComponent, int>();
		}
		int value = charRenderingComponent.AddMaterialControllerDataWithUserData(this.ControllerData, this.UserData);
		this.Handles[meshComp] = value;
		return true;
	}

	// Token: 0x0601B3ED RID: 111597 RVA: 0x0082F410 File Offset: 0x0082D610
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

	// Token: 0x0601B3EE RID: 111598 RVA: 0x0082F4B0 File Offset: 0x0082D6B0
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		CharRenderingComponent charRenderingComponent = owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return false;
		}
		if (this.Handles == null)
		{
			return false;
		}
		int handle;
		if (!this.Handles.TryGetValue(meshComp, out handle))
		{
			return false;
		}
		this.Handles.Remove(meshComp);
		charRenderingComponent.RemoveMaterialControllerData(handle);
		return true;
	}

	// Token: 0x0601B3EF RID: 111599 RVA: 0x0082F515 File Offset: 0x0082D715
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAddMaterialController._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddMaterialController.TsAnimNotifyStateAddMaterialController_C");
		}
		return TsAnimNotifyStateAddMaterialController._ClassPtr;
	}

	// Token: 0x0601B3F0 RID: 111600 RVA: 0x0082F53C File Offset: 0x0082D73C
	public TsAnimNotifyStateAddMaterialController() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddMaterialController.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601B3F1 RID: 111601 RVA: 0x0082F564 File Offset: 0x0082D764
	public TsAnimNotifyStateAddMaterialController(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddMaterialController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601B3F2 RID: 111602 RVA: 0x0082F597 File Offset: 0x0082D797
	protected TsAnimNotifyStateAddMaterialController(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601B3F3 RID: 111603 RVA: 0x0082F5A0 File Offset: 0x0082D7A0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601B3F4 RID: 111604 RVA: 0x0082F5DC File Offset: 0x0082D7DC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400DE13 RID: 56851
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddMaterialController.TsAnimNotifyStateAddMaterialController_C";

	// Token: 0x0400DE14 RID: 56852
	private static IntPtr _ClassPtr;

	// Token: 0x0400DE15 RID: 56853
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DE16 RID: 56854
	private static int __PropertyOffset_ControllerData;

	// Token: 0x0400DE17 RID: 56855
	private static int __PropertyOffset_UserData;
}
