using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020034F5 RID: 13557
[UClass("/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/TsEntityBase.TsEntityBase_C")]
public class TsEntityBase : AKuroEffectActor, ITsEntityBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170026F5 RID: 9973
	// (get) Token: 0x0601CA57 RID: 117335 RVA: 0x00898A30 File Offset: 0x00896C30
	// (set) Token: 0x0601CA58 RID: 117336 RVA: 0x00898A40 File Offset: 0x00896C40
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsEntityBase.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsEntityBase.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x0601CA59 RID: 117337 RVA: 0x00898A54 File Offset: 0x00896C54
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void EditorInit()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorInit"), out num);
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

	// Token: 0x0601CA5A RID: 117338 RVA: 0x00898AC4 File Offset: 0x00896CC4
	protected virtual void EditorInit_Implementation()
	{
		base.bSetActorComponentTickEnabledByFocus = true;
		base.EditorSetActorComponentsTickEnabled(false);
	}

	// Token: 0x0601CA5B RID: 117339 RVA: 0x00898AD4 File Offset: 0x00896CD4
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

	// Token: 0x0601CA5C RID: 117340 RVA: 0x00898B44 File Offset: 0x00896D44
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		base.K2_DestroyActor();
	}

	// Token: 0x0601CA5D RID: 117341 RVA: 0x00898B4C File Offset: 0x00896D4C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsEntityBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/TsEntityBase.TsEntityBase_C");
		}
		return TsEntityBase._ClassPtr;
	}

	// Token: 0x0601CA5E RID: 117342 RVA: 0x00898B70 File Offset: 0x00896D70
	public TsEntityBase() : this(BuiltinUtils.AllocNativeUObject(TsEntityBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601CA5F RID: 117343 RVA: 0x00898B98 File Offset: 0x00896D98
	[NullableContext(1)]
	public TsEntityBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEntityBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CA60 RID: 117344 RVA: 0x00898BCB File Offset: 0x00896DCB
	protected TsEntityBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CA61 RID: 117345 RVA: 0x00898BD4 File Offset: 0x00896DD4
	protected virtual void __CPPCALL_EditorInit_Implementation()
	{
		this.EditorInit_Implementation();
	}

	// Token: 0x0601CA62 RID: 117346 RVA: 0x00898BDC File Offset: 0x00896DDC
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0400E698 RID: 59032
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/TsEntityBase.TsEntityBase_C";

	// Token: 0x0400E699 RID: 59033
	private static IntPtr _ClassPtr;

	// Token: 0x0400E69A RID: 59034
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E69B RID: 59035
	private static int __PropertyOffset_Id;
}
