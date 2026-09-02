using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020034F3 RID: 13555
[UClass("/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/TsCharacterEntityBase.TsCharacterEntityBase_C")]
public class TsCharacterEntityBase : AKuroEffectActor, ITsEntityBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601CA4B RID: 117323 RVA: 0x008987C0 File Offset: 0x008969C0
	[UFunction(EFunctionFlags.FUNC_BlueprintImplementableEvent)]
	public unsafe override void EditorFocusIn()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorFocusIn"), out num);
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

	// Token: 0x0601CA4C RID: 117324 RVA: 0x00898830 File Offset: 0x00896A30
	[UFunction(EFunctionFlags.FUNC_BlueprintImplementableEvent)]
	public unsafe override void EditorFocusOut()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorFocusOut"), out num);
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

	// Token: 0x0601CA4D RID: 117325 RVA: 0x008988A0 File Offset: 0x00896AA0
	[UFunction(EFunctionFlags.FUNC_BlueprintImplementableEvent)]
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

	// Token: 0x0601CA4E RID: 117326 RVA: 0x00898910 File Offset: 0x00896B10
	[UFunction(EFunctionFlags.FUNC_BlueprintImplementableEvent)]
	public unsafe override void EditorTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AKuroEffectActor.__EditorTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AKuroEffectActor.__EditorTick_FunctionParams*)ptr + 15L / (long)sizeof(AKuroEffectActor.__EditorTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x170026F3 RID: 9971
	// (get) Token: 0x0601CA4F RID: 117327 RVA: 0x00898986 File Offset: 0x00896B86
	// (set) Token: 0x0601CA50 RID: 117328 RVA: 0x00898996 File Offset: 0x00896B96
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterEntityBase.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterEntityBase.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x0601CA51 RID: 117329 RVA: 0x008989A7 File Offset: 0x00896BA7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsCharacterEntityBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/TsCharacterEntityBase.TsCharacterEntityBase_C");
		}
		return TsCharacterEntityBase._ClassPtr;
	}

	// Token: 0x0601CA52 RID: 117330 RVA: 0x008989CC File Offset: 0x00896BCC
	public TsCharacterEntityBase() : this(BuiltinUtils.AllocNativeUObject(TsCharacterEntityBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601CA53 RID: 117331 RVA: 0x008989F4 File Offset: 0x00896BF4
	[NullableContext(1)]
	public TsCharacterEntityBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCharacterEntityBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CA54 RID: 117332 RVA: 0x00898A27 File Offset: 0x00896C27
	protected TsCharacterEntityBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E694 RID: 59028
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/UniverseEditor/Common/TsEntity/TsCharacterEntityBase.TsCharacterEntityBase_C";

	// Token: 0x0400E695 RID: 59029
	private static IntPtr _ClassPtr;

	// Token: 0x0400E696 RID: 59030
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E697 RID: 59031
	private static int __PropertyOffset_Id;
}
