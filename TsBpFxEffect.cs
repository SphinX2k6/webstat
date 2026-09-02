using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020032C7 RID: 12999
[UClass("/Game/Aki/TypeScript/Game/Recorder/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Recorder/TsBpFxEffect.TsBpFxEffect_C")]
public class TsBpFxEffect : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002528 RID: 9512
	// (get) Token: 0x0601B3F5 RID: 111605 RVA: 0x0082F60F File Offset: 0x0082D80F
	// (set) Token: 0x0601B3F6 RID: 111606 RVA: 0x0082F61F File Offset: 0x0082D81F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsRecorderActor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBpFxEffect.__PropertyOffset_IsRecorderActor) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBpFxEffect.__PropertyOffset_IsRecorderActor) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002529 RID: 9513
	// (get) Token: 0x0601B3F7 RID: 111607 RVA: 0x0082F630 File Offset: 0x0082D830
	// (set) Token: 0x0601B3F8 RID: 111608 RVA: 0x0082F640 File Offset: 0x0082D840
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float RecordTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBpFxEffect.__PropertyOffset_RecordTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsBpFxEffect.__PropertyOffset_RecordTime) = value;
		}
	}

	// Token: 0x1700252A RID: 9514
	// (get) Token: 0x0601B3F9 RID: 111609 RVA: 0x0082F651 File Offset: 0x0082D851
	// (set) Token: 0x0601B3FA RID: 111610 RVA: 0x0082F665 File Offset: 0x0082D865
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TsBpFxEffect RecorderShadow
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<TsBpFxEffect>(base.NativePtr / (IntPtr)sizeof(void*) + TsBpFxEffect.__PropertyOffset_RecorderShadow);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBpFxEffect.__PropertyOffset_RecorderShadow, value);
		}
	}

	// Token: 0x0601B3FB RID: 111611 RVA: 0x0082F67C File Offset: 0x0082D87C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601B3FC RID: 111612 RVA: 0x0082F6EC File Offset: 0x0082D8EC
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.OnPlay();
	}

	// Token: 0x0601B3FD RID: 111613 RVA: 0x0082F6F4 File Offset: 0x0082D8F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ReceiveEndPlay(TEnumAsByte<EEndPlayReason> endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBpFxEffect.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBpFxEffect.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(TsBpFxEffect.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->endPlayReason = endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B3FE RID: 111614 RVA: 0x0082F76A File Offset: 0x0082D96A
	protected virtual void ReceiveEndPlay_Implementation(TEnumAsByte<EEndPlayReason> endPlayReason)
	{
		this.OnStop();
	}

	// Token: 0x0601B3FF RID: 111615 RVA: 0x0082F774 File Offset: 0x0082D974
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void TryRecord()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TryRecord"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601B400 RID: 111616 RVA: 0x0082F7E4 File Offset: 0x0082D9E4
	protected void TryRecord_Implementation()
	{
		this.OnPlay();
	}

	// Token: 0x0601B401 RID: 111617 RVA: 0x0082F7EC File Offset: 0x0082D9EC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddAutoFloatTrack(FName propertyName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddAutoFloatTrack"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBpFxEffect.__AddAutoFloatTrack_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBpFxEffect.__AddAutoFloatTrack_FunctionParams*)ptr + 15L / (long)sizeof(TsBpFxEffect.__AddAutoFloatTrack_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->propertyName = propertyName;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B402 RID: 111618 RVA: 0x0082F862 File Offset: 0x0082DA62
	protected void AddAutoFloatTrack_Implementation(FName propertyName)
	{
	}

	// Token: 0x0601B403 RID: 111619 RVA: 0x0082F864 File Offset: 0x0082DA64
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddAutoVectorTrack(FName propertyName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddAutoVectorTrack"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBpFxEffect.__AddAutoVectorTrack_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBpFxEffect.__AddAutoVectorTrack_FunctionParams*)ptr + 15L / (long)sizeof(TsBpFxEffect.__AddAutoVectorTrack_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->propertyName = propertyName;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B404 RID: 111620 RVA: 0x0082F8DA File Offset: 0x0082DADA
	protected virtual void AddAutoVectorTrack_Implementation(FName propertyName)
	{
	}

	// Token: 0x0601B405 RID: 111621 RVA: 0x0082F8DC File Offset: 0x0082DADC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddAutoObjectTrack(FName propertyName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddAutoObjectTrack"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBpFxEffect.__AddAutoObjectTrack_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBpFxEffect.__AddAutoObjectTrack_FunctionParams*)ptr + 15L / (long)sizeof(TsBpFxEffect.__AddAutoObjectTrack_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->propertyName = propertyName;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B406 RID: 111622 RVA: 0x0082F952 File Offset: 0x0082DB52
	protected virtual void AddAutoObjectTrack_Implementation(FName propertyName)
	{
	}

	// Token: 0x0601B407 RID: 111623 RVA: 0x0082F954 File Offset: 0x0082DB54
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OnRecordStart()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnRecordStart"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601B408 RID: 111624 RVA: 0x0082F9C4 File Offset: 0x0082DBC4
	protected virtual void OnRecordStart_Implementation()
	{
	}

	// Token: 0x0601B409 RID: 111625 RVA: 0x0082F9C8 File Offset: 0x0082DBC8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OnRecordTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnRecordTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBpFxEffect.__OnRecordTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBpFxEffect.__OnRecordTick_FunctionParams*)ptr + 15L / (long)sizeof(TsBpFxEffect.__OnRecordTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->deltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B40A RID: 111626 RVA: 0x0082FA3E File Offset: 0x0082DC3E
	protected virtual void OnRecordTick_Implementation(float deltaSeconds)
	{
	}

	// Token: 0x0601B40B RID: 111627 RVA: 0x0082FA40 File Offset: 0x0082DC40
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OnRecordStop()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnRecordStop"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601B40C RID: 111628 RVA: 0x0082FAB0 File Offset: 0x0082DCB0
	protected virtual void OnRecordStop_Implementation()
	{
	}

	// Token: 0x0601B40D RID: 111629 RVA: 0x0082FAB2 File Offset: 0x0082DCB2
	private void OnPlay()
	{
	}

	// Token: 0x0601B40E RID: 111630 RVA: 0x0082FAB4 File Offset: 0x0082DCB4
	private void OnStop()
	{
	}

	// Token: 0x0601B40F RID: 111631 RVA: 0x0082FAB6 File Offset: 0x0082DCB6
	public void ClearRecorder()
	{
		this.RecorderShadow = null;
	}

	// Token: 0x0601B410 RID: 111632 RVA: 0x0082FABF File Offset: 0x0082DCBF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsBpFxEffect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Recorder/TsBpFxEffect.TsBpFxEffect_C");
		}
		return TsBpFxEffect._ClassPtr;
	}

	// Token: 0x0601B411 RID: 111633 RVA: 0x0082FAE4 File Offset: 0x0082DCE4
	public TsBpFxEffect() : this(BuiltinUtils.AllocNativeUObject(TsBpFxEffect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601B412 RID: 111634 RVA: 0x0082FB0C File Offset: 0x0082DD0C
	[NullableContext(1)]
	public TsBpFxEffect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBpFxEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601B413 RID: 111635 RVA: 0x0082FB3F File Offset: 0x0082DD3F
	protected TsBpFxEffect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x1700252B RID: 9515
	// (get) Token: 0x0601B414 RID: 111636 RVA: 0x0082FB48 File Offset: 0x0082DD48
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)TsBpFxEffect.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x1700252C RID: 9516
	// (get) Token: 0x0601B415 RID: 111637 RVA: 0x0082FB58 File Offset: 0x0082DD58
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsBpFxEffect.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x0601B416 RID: 111638 RVA: 0x0082FB6C File Offset: 0x0082DD6C
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601B417 RID: 111639 RVA: 0x0082FB74 File Offset: 0x0082DD74
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(TsBpFxEffect.__ReceiveEndPlay_FunctionParams* __Params)
	{
		this.ReceiveEndPlay_Implementation(__Params->endPlayReason);
	}

	// Token: 0x0601B418 RID: 111640 RVA: 0x0082FB82 File Offset: 0x0082DD82
	protected virtual void __CPPCALL_TryRecord_Implementation()
	{
		this.TryRecord_Implementation();
	}

	// Token: 0x0601B419 RID: 111641 RVA: 0x0082FB8A File Offset: 0x0082DD8A
	protected unsafe virtual void __CPPCALL_AddAutoFloatTrack_Implementation(TsBpFxEffect.__AddAutoFloatTrack_FunctionParams* __Params)
	{
		this.AddAutoFloatTrack_Implementation(__Params->propertyName);
	}

	// Token: 0x0601B41A RID: 111642 RVA: 0x0082FB98 File Offset: 0x0082DD98
	protected unsafe virtual void __CPPCALL_AddAutoVectorTrack_Implementation(TsBpFxEffect.__AddAutoVectorTrack_FunctionParams* __Params)
	{
		this.AddAutoVectorTrack_Implementation(__Params->propertyName);
	}

	// Token: 0x0601B41B RID: 111643 RVA: 0x0082FBA6 File Offset: 0x0082DDA6
	protected unsafe virtual void __CPPCALL_AddAutoObjectTrack_Implementation(TsBpFxEffect.__AddAutoObjectTrack_FunctionParams* __Params)
	{
		this.AddAutoObjectTrack_Implementation(__Params->propertyName);
	}

	// Token: 0x0601B41C RID: 111644 RVA: 0x0082FBB4 File Offset: 0x0082DDB4
	protected virtual void __CPPCALL_OnRecordStart_Implementation()
	{
		this.OnRecordStart_Implementation();
	}

	// Token: 0x0601B41D RID: 111645 RVA: 0x0082FBBC File Offset: 0x0082DDBC
	protected unsafe virtual void __CPPCALL_OnRecordTick_Implementation(TsBpFxEffect.__OnRecordTick_FunctionParams* __Params)
	{
		this.OnRecordTick_Implementation(__Params->deltaSeconds);
	}

	// Token: 0x0601B41E RID: 111646 RVA: 0x0082FBCA File Offset: 0x0082DDCA
	protected virtual void __CPPCALL_OnRecordStop_Implementation()
	{
		this.OnRecordStop_Implementation();
	}

	// Token: 0x0400DE18 RID: 56856
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Recorder/TsBpFxEffect.TsBpFxEffect_C";

	// Token: 0x0400DE19 RID: 56857
	private static IntPtr _ClassPtr;

	// Token: 0x0400DE1A RID: 56858
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DE1B RID: 56859
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400DE1C RID: 56860
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x0400DE1D RID: 56861
	private static int __PropertyOffset_IsRecorderActor;

	// Token: 0x0400DE1E RID: 56862
	private static int __PropertyOffset_RecordTime;

	// Token: 0x0400DE1F RID: 56863
	private static int __PropertyOffset_RecorderShadow;

	// Token: 0x0200947A RID: 38010
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected new ref struct __ReceiveEndPlay_FunctionParams
	{
		// Token: 0x04031426 RID: 201766
		[FieldOffset(0)]
		public TEnumAsByte<EEndPlayReason> endPlayReason;
	}

	// Token: 0x0200947B RID: 38011
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __AddAutoFloatTrack_FunctionParams
	{
		// Token: 0x04031427 RID: 201767
		[FieldOffset(0)]
		public FName propertyName;
	}

	// Token: 0x0200947C RID: 38012
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __AddAutoVectorTrack_FunctionParams
	{
		// Token: 0x04031428 RID: 201768
		[FieldOffset(0)]
		public FName propertyName;
	}

	// Token: 0x0200947D RID: 38013
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __AddAutoObjectTrack_FunctionParams
	{
		// Token: 0x04031429 RID: 201769
		[FieldOffset(0)]
		public FName propertyName;
	}

	// Token: 0x0200947E RID: 38014
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __OnRecordTick_FunctionParams
	{
		// Token: 0x0403142A RID: 201770
		[FieldOffset(0)]
		public float deltaSeconds;
	}
}
