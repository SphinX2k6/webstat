using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200324B RID: 12875
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/BaseItem/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/BaseItem/TsBaseItem.TsBaseItem_C")]
public class TsBaseItem : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601ACDB RID: 109787 RVA: 0x007FDA40 File Offset: 0x007FBC40
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

	// Token: 0x0601ACDC RID: 109788 RVA: 0x007FDAB0 File Offset: 0x007FBCB0
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.EntityHandle = ActorUtils.GetEntityByActor(this, true);
		this.DebugComp = this.EntityHandle.Entity.GetComponent<SceneItemDebugComponent>();
	}

	// Token: 0x0601ACDD RID: 109789 RVA: 0x007FDAD8 File Offset: 0x007FBCD8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual string GetTagDebugStrings()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetTagDebugStrings"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBaseItem.__GetTagDebugStrings_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBaseItem.__GetTagDebugStrings_FunctionParams*)ptr + 15L / (long)sizeof(TsBaseItem.__GetTagDebugStrings_FunctionParams) & -16L);
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

	// Token: 0x0601ACDE RID: 109790 RVA: 0x007FDB53 File Offset: 0x007FBD53
	protected string GetTagDebugStrings_Implementation()
	{
		return this.DebugComp.GetTagDebugStrings();
	}

	// Token: 0x0601ACDF RID: 109791 RVA: 0x007FDB60 File Offset: 0x007FBD60
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsBaseItem._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/BaseItem/TsBaseItem.TsBaseItem_C");
		}
		return TsBaseItem._ClassPtr;
	}

	// Token: 0x0601ACE0 RID: 109792 RVA: 0x007FDB84 File Offset: 0x007FBD84
	public TsBaseItem() : this(BuiltinUtils.AllocNativeUObject(TsBaseItem.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601ACE1 RID: 109793 RVA: 0x007FDBAC File Offset: 0x007FBDAC
	public TsBaseItem(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBaseItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601ACE2 RID: 109794 RVA: 0x007FDBDF File Offset: 0x007FBDDF
	protected TsBaseItem(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x17002460 RID: 9312
	// (get) Token: 0x0601ACE3 RID: 109795 RVA: 0x007FDBE8 File Offset: 0x007FBDE8
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsBaseItem.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x17002461 RID: 9313
	// (get) Token: 0x0601ACE4 RID: 109796 RVA: 0x007FDBF8 File Offset: 0x007FBDF8
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsBaseItem.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x0601ACE5 RID: 109797 RVA: 0x007FDC0C File Offset: 0x007FBE0C
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601ACE6 RID: 109798 RVA: 0x007FDC14 File Offset: 0x007FBE14
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetTagDebugStrings_Implementation(TsBaseItem.__GetTagDebugStrings_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetTagDebugStrings_Implementation());
	}

	// Token: 0x0400D962 RID: 55650
	[Nullable(2)]
	public EntityHandle EntityHandle;

	// Token: 0x0400D963 RID: 55651
	[Nullable(2)]
	private SceneItemDebugComponent DebugComp;

	// Token: 0x0400D964 RID: 55652
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/BaseItem/TsBaseItem.TsBaseItem_C";

	// Token: 0x0400D965 RID: 55653
	private static IntPtr _ClassPtr;

	// Token: 0x0400D966 RID: 55654
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400D967 RID: 55655
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400D968 RID: 55656
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x02009421 RID: 37921
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetTagDebugStrings_FunctionParams
	{
		// Token: 0x04031336 RID: 201526
		[FieldOffset(0)]
		public FString __Result;
	}
}
