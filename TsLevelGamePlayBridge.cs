using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.MingSu;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000FAA RID: 4010
[UClass("/Game/Aki/TypeScript/Game/LevelGamePlay/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/LevelGamePlay/TsLevelGamePlayBridge.TsLevelGamePlayBridge_C")]
public class TsLevelGamePlayBridge : UObject, IUnrealUObject, IUnrealObject
{
	// Token: 0x060066BC RID: 26300 RVA: 0x0019E3C8 File Offset: 0x0019C5C8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void UpdateGamePlayTimerBridge(float inGamePlayTimerId, float inActivate)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("UpdateGamePlayTimerBridge"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams*)ptr + 15L / (long)sizeof(TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inGamePlayTimerId = inGamePlayTimerId;
			ptr2->inActivate = inActivate;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060066BD RID: 26301 RVA: 0x0019E445 File Offset: 0x0019C645
	protected void UpdateGamePlayTimerBridge_Implementation(float inGamePlayTimerId, float inActivate)
	{
	}

	// Token: 0x060066BE RID: 26302 RVA: 0x0019E448 File Offset: 0x0019C648
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float GetDragonPoolState(float inDragonId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDragonPoolState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams*)ptr + 15L / (long)sizeof(TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inDragonId = inDragonId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060066BF RID: 26303 RVA: 0x0019E4C4 File Offset: 0x0019C6C4
	protected float GetDragonPoolState_Implementation(float inDragonId)
	{
		return (float)ModelBase<MingSuModel>.Instance.GetTargetDragonPoolActiveById((int)inDragonId);
	}

	// Token: 0x060066C0 RID: 26304 RVA: 0x0019E4D4 File Offset: 0x0019C6D4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ApplyScanEffect(AActor inActor)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ApplyScanEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams*)ptr + 15L / (long)sizeof(TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->inActor) = ((inActor != null) ? inActor.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060066C1 RID: 26305 RVA: 0x0019E558 File Offset: 0x0019C758
	[NullableContext(1)]
	protected void ApplyScanEffect_Implementation(AActor inActor)
	{
		ControllerBase<LevelGamePlayController>.Instance.HandleScanResponse(inActor, 0);
	}

	// Token: 0x060066C2 RID: 26306 RVA: 0x0019E568 File Offset: 0x0019C768
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ClearAllScanEffects()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ClearAllScanEffects"), out num);
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

	// Token: 0x060066C3 RID: 26307 RVA: 0x0019E5D8 File Offset: 0x0019C7D8
	protected void ClearAllScanEffects_Implementation()
	{
		ControllerBase<LevelGamePlayController>.Instance.HandleClearAllScanEffect();
	}

	// Token: 0x060066C4 RID: 26308 RVA: 0x0019E5E4 File Offset: 0x0019C7E4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsLevelGamePlayBridge._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/LevelGamePlay/TsLevelGamePlayBridge.TsLevelGamePlayBridge_C");
		}
		return TsLevelGamePlayBridge._ClassPtr;
	}

	// Token: 0x060066C5 RID: 26309 RVA: 0x0019E608 File Offset: 0x0019C808
	public TsLevelGamePlayBridge() : this(BuiltinUtils.AllocNativeUObject(TsLevelGamePlayBridge.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060066C6 RID: 26310 RVA: 0x0019E630 File Offset: 0x0019C830
	[NullableContext(1)]
	public TsLevelGamePlayBridge(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsLevelGamePlayBridge.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060066C7 RID: 26311 RVA: 0x0019E663 File Offset: 0x0019C863
	protected TsLevelGamePlayBridge(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060066C8 RID: 26312 RVA: 0x0019E66C File Offset: 0x0019C86C
	protected unsafe virtual void __CPPCALL_UpdateGamePlayTimerBridge_Implementation(TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams* __Params)
	{
		this.UpdateGamePlayTimerBridge_Implementation(__Params->inGamePlayTimerId, __Params->inActivate);
	}

	// Token: 0x060066C9 RID: 26313 RVA: 0x0019E680 File Offset: 0x0019C880
	protected unsafe virtual void __CPPCALL_GetDragonPoolState_Implementation(TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams* __Params)
	{
		__Params->__Result = this.GetDragonPoolState_Implementation(__Params->inDragonId);
	}

	// Token: 0x060066CA RID: 26314 RVA: 0x0019E694 File Offset: 0x0019C894
	protected unsafe virtual void __CPPCALL_ApplyScanEffect_Implementation(TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inActor);
		this.ApplyScanEffect_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x060066CB RID: 26315 RVA: 0x0019E6B4 File Offset: 0x0019C8B4
	protected virtual void __CPPCALL_ClearAllScanEffects_Implementation()
	{
		this.ClearAllScanEffects_Implementation();
	}

	// Token: 0x040030DC RID: 12508
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/LevelGamePlay/TsLevelGamePlayBridge.TsLevelGamePlayBridge_C";

	// Token: 0x040030DD RID: 12509
	private static IntPtr _ClassPtr;

	// Token: 0x040030DE RID: 12510
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020073A3 RID: 29603
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __UpdateGamePlayTimerBridge_FunctionParams
	{
		// Token: 0x04028051 RID: 163921
		[FieldOffset(0)]
		public float inGamePlayTimerId;

		// Token: 0x04028052 RID: 163922
		[FieldOffset(4)]
		public float inActivate;
	}

	// Token: 0x020073A4 RID: 29604
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetDragonPoolState_FunctionParams
	{
		// Token: 0x04028053 RID: 163923
		[FieldOffset(0)]
		public float inDragonId;

		// Token: 0x04028054 RID: 163924
		[FieldOffset(4)]
		public float __Result;
	}

	// Token: 0x020073A5 RID: 29605
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ApplyScanEffect_FunctionParams
	{
		// Token: 0x04028055 RID: 163925
		[FieldOffset(0)]
		public IntPtr inActor;
	}
}
