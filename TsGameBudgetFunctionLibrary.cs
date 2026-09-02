using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.World.Define;
using CSharpScript.Game.World.GameBudget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020034AB RID: 13483
[UClass("/Game/Aki/TypeScript/Game/World/GameBudget/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/World/GameBudget/TsGameBudgetFunctionLibrary.TsGameBudgetFunctionLibrary_C")]
public class TsGameBudgetFunctionLibrary : UBlueprintFunctionLibrary, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601C705 RID: 116485 RVA: 0x008866CC File Offset: 0x008848CC
	static TsGameBudgetFunctionLibrary()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsGameBudgetFunctionLibrary.CreateStaticDefaultValue), new Action(TsGameBudgetFunctionLibrary.ResetStaticDefaultValue));
	}

	// Token: 0x0601C706 RID: 116486 RVA: 0x008866EC File Offset: 0x008848EC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RegisterGameBudget(AActor actor, bool isCollisionPlant)
	{
		TsBlueprintGameBudgetObject tsBlueprintGameBudgetObject = new TsBlueprintGameBudgetObject(actor);
		if (!tsBlueprintGameBudgetObject.HasScheduledTickMethod())
		{
			return;
		}
		TsGameBudgetGroupConfigCache groupConfig;
		if (isCollisionPlant)
		{
			groupConfig = Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsCollisionPlantConfig;
		}
		else
		{
			groupConfig = Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsNormalEntityGroupConfig;
		}
		if (tsBlueprintGameBudgetObject.RegisterTick(groupConfig) != 0U)
		{
			TsGameBudgetFunctionLibrary.TsGameBudgetObjectMap[actor] = tsBlueprintGameBudgetObject;
		}
	}

	// Token: 0x0601C707 RID: 116487 RVA: 0x0088673C File Offset: 0x0088493C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void UnregisterGameBudget(AActor actor)
	{
		TsBlueprintGameBudgetObject tsBlueprintGameBudgetObject;
		if (TsGameBudgetFunctionLibrary.TsGameBudgetObjectMap.TryGetValue(actor, out tsBlueprintGameBudgetObject))
		{
			tsBlueprintGameBudgetObject.UnregisterTick();
			TsGameBudgetFunctionLibrary.TsGameBudgetObjectMap.Remove(actor);
		}
	}

	// Token: 0x0601C708 RID: 116488 RVA: 0x0088676A File Offset: 0x0088496A
	public static void CreateStaticDefaultValue()
	{
		TsGameBudgetFunctionLibrary.TsGameBudgetObjectMap = new Dictionary<AActor, TsBlueprintGameBudgetObject>();
	}

	// Token: 0x0601C709 RID: 116489 RVA: 0x00886776 File Offset: 0x00884976
	public static void ResetStaticDefaultValue()
	{
		TsGameBudgetFunctionLibrary.TsGameBudgetObjectMap = null;
	}

	// Token: 0x0601C70A RID: 116490 RVA: 0x0088677E File Offset: 0x0088497E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsGameBudgetFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/World/GameBudget/TsGameBudgetFunctionLibrary.TsGameBudgetFunctionLibrary_C");
		}
		return TsGameBudgetFunctionLibrary._ClassPtr;
	}

	// Token: 0x0601C70B RID: 116491 RVA: 0x008867A4 File Offset: 0x008849A4
	public TsGameBudgetFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsGameBudgetFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C70C RID: 116492 RVA: 0x008867CC File Offset: 0x008849CC
	[NullableContext(1)]
	public TsGameBudgetFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsGameBudgetFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C70D RID: 116493 RVA: 0x008867FF File Offset: 0x008849FF
	protected TsGameBudgetFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C70E RID: 116494 RVA: 0x00886808 File Offset: 0x00884A08
	protected unsafe static void __CPPCALL_RegisterGameBudget_Implementation(TsGameBudgetFunctionLibrary.__RegisterGameBudget_FunctionParams* __Params)
	{
		TsGameBudgetFunctionLibrary.RegisterGameBudget(BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor), __Params->isCollisionPlant);
	}

	// Token: 0x0601C70F RID: 116495 RVA: 0x00886820 File Offset: 0x00884A20
	protected unsafe static void __CPPCALL_UnregisterGameBudget_Implementation(TsGameBudgetFunctionLibrary.__UnregisterGameBudget_FunctionParams* __Params)
	{
		TsGameBudgetFunctionLibrary.UnregisterGameBudget(BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor));
	}

	// Token: 0x0400E4DE RID: 58590
	[Nullable(1)]
	private static Dictionary<AActor, TsBlueprintGameBudgetObject> TsGameBudgetObjectMap;

	// Token: 0x0400E4DF RID: 58591
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/World/GameBudget/TsGameBudgetFunctionLibrary.TsGameBudgetFunctionLibrary_C";

	// Token: 0x0400E4E0 RID: 58592
	private static IntPtr _ClassPtr;

	// Token: 0x0400E4E1 RID: 58593
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02009688 RID: 38536
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __RegisterGameBudget_FunctionParams
	{
		// Token: 0x04031ABF RID: 203455
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x04031AC0 RID: 203456
		[FieldOffset(8)]
		public bool isCollisionPlant;

		// Token: 0x04031AC1 RID: 203457
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009689 RID: 38537
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __UnregisterGameBudget_FunctionParams
	{
		// Token: 0x04031AC2 RID: 203458
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x04031AC3 RID: 203459
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
