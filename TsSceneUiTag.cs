using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002949 RID: 10569
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/Scene3DUI/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/Scene3DUI/TsSceneUiTag.TsSceneUiTag_C")]
public class TsSceneUiTag : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001B88 RID: 7048
	// (get) Token: 0x06015005 RID: 86021 RVA: 0x005CF330 File Offset: 0x005CD530
	// (set) Token: 0x06015006 RID: 86022 RVA: 0x005CF344 File Offset: 0x005CD544
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string SceneUiTag
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsSceneUiTag.__PropertyOffset_SceneUiTag)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsSceneUiTag.__PropertyOffset_SceneUiTag)), value);
		}
	}

	// Token: 0x17001B89 RID: 7049
	// (get) Token: 0x06015007 RID: 86023 RVA: 0x005CF359 File Offset: 0x005CD559
	// (set) Token: 0x06015008 RID: 86024 RVA: 0x005CF369 File Offset: 0x005CD569
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CalculateCamera
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSceneUiTag.__PropertyOffset_CalculateCamera) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSceneUiTag.__PropertyOffset_CalculateCamera) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001B8A RID: 7050
	// (get) Token: 0x06015009 RID: 86025 RVA: 0x005CF37C File Offset: 0x005CD57C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<TsSceneUiTag> BindUiTagArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<TsSceneUiTag> result;
			if ((result = this._BindUiTagArray) == null)
			{
				result = (this._BindUiTagArray = new TArray<TsSceneUiTag>(base.NativePtr + (IntPtr)TsSceneUiTag.__PropertyOffset_BindUiTagArray, this));
			}
			return result;
		}
	}

	// Token: 0x0601500A RID: 86026 RVA: 0x005CF3B8 File Offset: 0x005CD5B8
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

	// Token: 0x0601500B RID: 86027 RVA: 0x005CF428 File Offset: 0x005CD628
	protected virtual void ReceiveBeginPlay_Implementation()
	{
	}

	// Token: 0x0601500C RID: 86028 RVA: 0x005CF42C File Offset: 0x005CD62C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)EndPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601500D RID: 86029 RVA: 0x005CF4A5 File Offset: 0x005CD6A5
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
	{
	}

	// Token: 0x0601500E RID: 86030 RVA: 0x005CF4A8 File Offset: 0x005CD6A8
	public double CalculateSquaredDistance()
	{
		if (ControllerBase<CameraController>.Instance.MainModel == null)
		{
			return 0.0;
		}
		FTransformDouble ftransformDouble;
		if (this.CalculateCamera)
		{
			CameraModelInstance mainModel = ControllerBase<CameraController>.Instance.MainModel;
			if (mainModel == null)
			{
				return 0.0;
			}
			ftransformDouble = mainModel.CameraTransform.Value;
		}
		else
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return 0.0;
			}
			ftransformDouble = baseCharacter.D_GetTransform();
		}
		FVectorDouble fvectorDouble = base.D_K2_GetActorLocation();
		return Vector.Create(ftransformDouble.InverseTransformPositionNoScale(fvectorDouble)).SizeSquared();
	}

	// Token: 0x0601500F RID: 86031 RVA: 0x005CF532 File Offset: 0x005CD732
	public bool CanTick()
	{
		return this.OnCanTick();
	}

	// Token: 0x06015010 RID: 86032 RVA: 0x005CF53C File Offset: 0x005CD73C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual bool OnCanTick()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnCanTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsSceneUiTag.__OnCanTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsSceneUiTag.__OnCanTick_FunctionParams*)ptr + 15L / (long)sizeof(TsSceneUiTag.__OnCanTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06015011 RID: 86033 RVA: 0x005CF5B1 File Offset: 0x005CD7B1
	protected bool OnCanTick_Implementation()
	{
		return false;
	}

	// Token: 0x06015012 RID: 86034 RVA: 0x005CF5B4 File Offset: 0x005CD7B4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSceneUiTag._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/Scene3DUI/TsSceneUiTag.TsSceneUiTag_C");
		}
		return TsSceneUiTag._ClassPtr;
	}

	// Token: 0x06015013 RID: 86035 RVA: 0x005CF5D8 File Offset: 0x005CD7D8
	public TsSceneUiTag() : this(BuiltinUtils.AllocNativeUObject(TsSceneUiTag.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06015014 RID: 86036 RVA: 0x005CF600 File Offset: 0x005CD800
	public TsSceneUiTag(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSceneUiTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06015015 RID: 86037 RVA: 0x005CF633 File Offset: 0x005CD833
	protected TsSceneUiTag(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x17001B8B RID: 7051
	// (get) Token: 0x06015016 RID: 86038 RVA: 0x005CF63C File Offset: 0x005CD83C
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSceneUiTag.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x17001B8C RID: 7052
	// (get) Token: 0x06015017 RID: 86039 RVA: 0x005CF64C File Offset: 0x005CD84C
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsSceneUiTag.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x06015018 RID: 86040 RVA: 0x005CF660 File Offset: 0x005CD860
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x06015019 RID: 86041 RVA: 0x005CF668 File Offset: 0x005CD868
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601501A RID: 86042 RVA: 0x005CF688 File Offset: 0x005CD888
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnCanTick_Implementation(TsSceneUiTag.__OnCanTick_FunctionParams* __Params)
	{
		__Params->__Result = this.OnCanTick_Implementation();
	}

	// Token: 0x0400A1B6 RID: 41398
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/Scene3DUI/TsSceneUiTag.TsSceneUiTag_C";

	// Token: 0x0400A1B7 RID: 41399
	private static IntPtr _ClassPtr;

	// Token: 0x0400A1B8 RID: 41400
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400A1B9 RID: 41401
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400A1BA RID: 41402
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x0400A1BB RID: 41403
	private static int __PropertyOffset_SceneUiTag;

	// Token: 0x0400A1BC RID: 41404
	private static int __PropertyOffset_CalculateCamera;

	// Token: 0x0400A1BD RID: 41405
	private static int __PropertyOffset_BindUiTagArray;

	// Token: 0x0400A1BE RID: 41406
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<TsSceneUiTag> _BindUiTagArray;

	// Token: 0x02008C6D RID: 35949
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __OnCanTick_FunctionParams
	{
		// Token: 0x0402F496 RID: 193686
		[FieldOffset(0)]
		public bool __Result;
	}
}
