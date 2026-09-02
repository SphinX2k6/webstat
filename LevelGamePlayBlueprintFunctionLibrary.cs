using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.Module.Scan;
using CSharpScript.Game.Render;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000F9D RID: 3997
[UClass("/Game/Aki/TypeScript/Game/LevelGamePlay/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGamePlayBlueprintFunctionLibrary.LevelGamePlayBlueprintFunctionLibrary_C")]
public class LevelGamePlayBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x060065F3 RID: 26099 RVA: 0x0019B1CA File Offset: 0x001993CA
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool ApplyScanEffect(AActor inActor, int type)
	{
		return ControllerBase<LevelGamePlayController>.Instance.HandleScanResponse(inActor, type);
	}

	// Token: 0x060065F4 RID: 26100 RVA: 0x0019B1D8 File Offset: 0x001993D8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ClearAllScanEffects()
	{
		ControllerBase<LevelGamePlayController>.Instance.HandleClearAllScanEffect();
	}

	// Token: 0x060065F5 RID: 26101 RVA: 0x0019B1E4 File Offset: 0x001993E4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SceneInteractionBind(AActor actor, string seqName, string eventName)
	{
		SceneInteractionManager.Get().EmitActor(actor, seqName, eventName);
	}

	// Token: 0x060065F6 RID: 26102 RVA: 0x0019B1F3 File Offset: 0x001993F3
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetScanMaxDistance()
	{
		LevelGamePlayConfig instance = ConfigBase<LevelGamePlayConfig>.Instance;
		if (instance == null)
		{
			return 0;
		}
		return instance.ScanMaxDistance;
	}

	// Token: 0x060065F7 RID: 26103 RVA: 0x0019B205 File Offset: 0x00199405
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetScanInteractionEffectMaxDistance()
	{
		LevelGamePlayConfig instance = ConfigBase<LevelGamePlayConfig>.Instance;
		if (instance == null)
		{
			return 0;
		}
		return instance.ScanShowInteractionEffectMaxDistance;
	}

	// Token: 0x060065F8 RID: 26104 RVA: 0x0019B218 File Offset: 0x00199418
	[NullableContext(1)]
	private static FKuroGeometryGeneralPolygonList GetPolygonListFromSplines(TArray<USplineComponent> splines)
	{
		TArray<FKuroGeometrySimplePolygon> tarray = new TArray<FKuroGeometrySimplePolygon>();
		for (int i = 0; i < splines.Num(); i++)
		{
			USplineComponent usplineComponent = splines.Get(i);
			if (usplineComponent != null && usplineComponent.IsValid())
			{
				FKuroGeometrySimplePolygon value = new FKuroGeometrySimplePolygon();
				UKuroSimplePolygonLibrary.SampleSplineToPolygon(usplineComponent, ref value, new FKuroSplineSamplingOptions
				{
					SampleSpacing = EKuroMathSampleSpacing.OriginPoints
				});
				tarray.Add(value);
			}
		}
		return UKuroPolygonListLibrary.CreatePolygonListFromSimplePolygons(tarray);
	}

	// Token: 0x060065F9 RID: 26105 RVA: 0x0019B27C File Offset: 0x0019947C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FKuroGeometryGeneralPolygonList PolygonsOpenPathsDifferenceViaSplines(ref TArray<USplineComponent> subjects, ref TArray<USplineComponent> openPaths, float strokeWidth, EJoinType joinType, EEndType endType)
	{
		FKuroGeometryGeneralPolygonList polygonListFromSplines = LevelGamePlayBlueprintFunctionLibrary.GetPolygonListFromSplines(subjects);
		FKuroGeometryGeneralPolygonList polygonListFromSplines2 = LevelGamePlayBlueprintFunctionLibrary.GetPolygonListFromSplines(openPaths);
		return UKuroPolygonListLibrary.PolygonsOpenPathsDifference(polygonListFromSplines, polygonListFromSplines2, (double)strokeWidth, joinType, endType);
	}

	// Token: 0x060065FA RID: 26106 RVA: 0x0019B2A3 File Offset: 0x001994A3
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FKuroGeometryGeneralPolygonList DifferenceSelectedActorsSplines()
	{
		return new FKuroGeometryGeneralPolygonList();
	}

	// Token: 0x060065FB RID: 26107 RVA: 0x0019B2AA File Offset: 0x001994AA
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool UseNewScanSystem()
	{
		return ControllerBase<LevelGamePlayController>.Instance.UseNewScanSystem;
	}

	// Token: 0x060065FC RID: 26108 RVA: 0x0019B2B6 File Offset: 0x001994B6
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StartScan()
	{
		ControllerBase<ScanController>.Instance.StartScan();
	}

	// Token: 0x060065FD RID: 26109 RVA: 0x0019B2C2 File Offset: 0x001994C2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LevelGamePlayBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGamePlayBlueprintFunctionLibrary.LevelGamePlayBlueprintFunctionLibrary_C");
		}
		return LevelGamePlayBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060065FE RID: 26110 RVA: 0x0019B2E8 File Offset: 0x001994E8
	public LevelGamePlayBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(LevelGamePlayBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060065FF RID: 26111 RVA: 0x0019B310 File Offset: 0x00199510
	[NullableContext(1)]
	public LevelGamePlayBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGamePlayBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06006600 RID: 26112 RVA: 0x0019B343 File Offset: 0x00199543
	protected LevelGamePlayBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06006601 RID: 26113 RVA: 0x0019B34C File Offset: 0x0019954C
	protected unsafe static void __CPPCALL_ApplyScanEffect_Implementation(LevelGamePlayBlueprintFunctionLibrary.__ApplyScanEffect_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inActor);
		__Params->__Result = LevelGamePlayBlueprintFunctionLibrary.ApplyScanEffect(orCreateUObjectByNativePointer, __Params->type);
	}

	// Token: 0x06006602 RID: 26114 RVA: 0x0019B377 File Offset: 0x00199577
	protected unsafe static void __CPPCALL_ClearAllScanEffects_Implementation(LevelGamePlayBlueprintFunctionLibrary.__ClearAllScanEffects_FunctionParams* __Params)
	{
		LevelGamePlayBlueprintFunctionLibrary.ClearAllScanEffects();
	}

	// Token: 0x06006603 RID: 26115 RVA: 0x0019B380 File Offset: 0x00199580
	protected unsafe static void __CPPCALL_SceneInteractionBind_Implementation(LevelGamePlayBlueprintFunctionLibrary.__SceneInteractionBind_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		string seqName = FString.ToString((void*)(&__Params->seqName));
		string eventName = FString.ToString((void*)(&__Params->eventName));
		LevelGamePlayBlueprintFunctionLibrary.SceneInteractionBind(orCreateUObjectByNativePointer, seqName, eventName);
	}

	// Token: 0x06006604 RID: 26116 RVA: 0x0019B3B9 File Offset: 0x001995B9
	protected unsafe static void __CPPCALL_GetScanMaxDistance_Implementation(LevelGamePlayBlueprintFunctionLibrary.__GetScanMaxDistance_FunctionParams* __Params)
	{
		__Params->__Result = LevelGamePlayBlueprintFunctionLibrary.GetScanMaxDistance();
	}

	// Token: 0x06006605 RID: 26117 RVA: 0x0019B3C6 File Offset: 0x001995C6
	protected unsafe static void __CPPCALL_GetScanInteractionEffectMaxDistance_Implementation(LevelGamePlayBlueprintFunctionLibrary.__GetScanInteractionEffectMaxDistance_FunctionParams* __Params)
	{
		__Params->__Result = LevelGamePlayBlueprintFunctionLibrary.GetScanInteractionEffectMaxDistance();
	}

	// Token: 0x06006606 RID: 26118 RVA: 0x0019B3D4 File Offset: 0x001995D4
	protected unsafe static void __CPPCALL_PolygonsOpenPathsDifferenceViaSplines_Implementation(LevelGamePlayBlueprintFunctionLibrary.__PolygonsOpenPathsDifferenceViaSplines_FunctionParams* __Params)
	{
		TArray<USplineComponent> tarray = new TArray<USplineComponent>(&__Params->subjects, true, true);
		TArray<USplineComponent> tarray2 = new TArray<USplineComponent>(&__Params->openPaths, true, true);
		EJoinType joinType = (EJoinType)__Params->joinType;
		EEndType endType = (EEndType)__Params->endType;
		UScriptStructStackOnlyPtr nativeUStructPtr = FKuroGeometryGeneralPolygonList.StaticStruct();
		IntPtr dest = &__Params->__Result;
		FKuroGeometryGeneralPolygonList fkuroGeometryGeneralPolygonList = LevelGamePlayBlueprintFunctionLibrary.PolygonsOpenPathsDifferenceViaSplines(ref tarray, ref tarray2, __Params->strokeWidth, joinType, endType);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (fkuroGeometryGeneralPolygonList != null) ? fkuroGeometryGeneralPolygonList.NativePtr : ((IntPtr)0), 1, false);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->subjects, default(UScriptStructStackOnlyPtr));
		}
		if (tarray2 != null)
		{
			tarray2.CopyTo(&__Params->openPaths, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x06006607 RID: 26119 RVA: 0x0019B472 File Offset: 0x00199672
	protected unsafe static void __CPPCALL_DifferenceSelectedActorsSplines_Implementation(LevelGamePlayBlueprintFunctionLibrary.__DifferenceSelectedActorsSplines_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = FKuroGeometryGeneralPolygonList.StaticStruct();
		IntPtr dest = &__Params->__Result;
		FKuroGeometryGeneralPolygonList fkuroGeometryGeneralPolygonList = LevelGamePlayBlueprintFunctionLibrary.DifferenceSelectedActorsSplines();
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (fkuroGeometryGeneralPolygonList != null) ? fkuroGeometryGeneralPolygonList.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06006608 RID: 26120 RVA: 0x0019B499 File Offset: 0x00199699
	protected unsafe static void __CPPCALL_UseNewScanSystem_Implementation(LevelGamePlayBlueprintFunctionLibrary.__UseNewScanSystem_FunctionParams* __Params)
	{
		__Params->__Result = LevelGamePlayBlueprintFunctionLibrary.UseNewScanSystem();
	}

	// Token: 0x06006609 RID: 26121 RVA: 0x0019B4A6 File Offset: 0x001996A6
	protected unsafe static void __CPPCALL_StartScan_Implementation(LevelGamePlayBlueprintFunctionLibrary.__StartScan_FunctionParams* __Params)
	{
		LevelGamePlayBlueprintFunctionLibrary.StartScan();
	}

	// Token: 0x04003083 RID: 12419
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGamePlayBlueprintFunctionLibrary.LevelGamePlayBlueprintFunctionLibrary_C";

	// Token: 0x04003084 RID: 12420
	private static IntPtr _ClassPtr;

	// Token: 0x04003085 RID: 12421
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02007382 RID: 29570
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ApplyScanEffect_FunctionParams
	{
		// Token: 0x04027FE3 RID: 163811
		[FieldOffset(0)]
		public IntPtr inActor;

		// Token: 0x04027FE4 RID: 163812
		[FieldOffset(8)]
		public int type;

		// Token: 0x04027FE5 RID: 163813
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04027FE6 RID: 163814
		[FieldOffset(24)]
		public bool __Result;
	}

	// Token: 0x02007383 RID: 29571
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ClearAllScanEffects_FunctionParams
	{
		// Token: 0x04027FE7 RID: 163815
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007384 RID: 29572
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __SceneInteractionBind_FunctionParams
	{
		// Token: 0x04027FE8 RID: 163816
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x04027FE9 RID: 163817
		[FieldOffset(8)]
		public FString seqName;

		// Token: 0x04027FEA RID: 163818
		[FieldOffset(24)]
		public FString eventName;

		// Token: 0x04027FEB RID: 163819
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007385 RID: 29573
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetScanMaxDistance_FunctionParams
	{
		// Token: 0x04027FEC RID: 163820
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027FED RID: 163821
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x02007386 RID: 29574
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetScanInteractionEffectMaxDistance_FunctionParams
	{
		// Token: 0x04027FEE RID: 163822
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027FEF RID: 163823
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x02007387 RID: 29575
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __PolygonsOpenPathsDifferenceViaSplines_FunctionParams
	{
		// Token: 0x04027FF0 RID: 163824
		[FieldOffset(0)]
		public byte subjects;

		// Token: 0x04027FF1 RID: 163825
		[FieldOffset(16)]
		public byte openPaths;

		// Token: 0x04027FF2 RID: 163826
		[FieldOffset(32)]
		public float strokeWidth;

		// Token: 0x04027FF3 RID: 163827
		[FieldOffset(36)]
		public byte joinType;

		// Token: 0x04027FF4 RID: 163828
		[FieldOffset(37)]
		public byte endType;

		// Token: 0x04027FF5 RID: 163829
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04027FF6 RID: 163830
		[FieldOffset(48)]
		public byte __Result;
	}

	// Token: 0x02007388 RID: 29576
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __DifferenceSelectedActorsSplines_FunctionParams
	{
		// Token: 0x04027FF7 RID: 163831
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027FF8 RID: 163832
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02007389 RID: 29577
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __UseNewScanSystem_FunctionParams
	{
		// Token: 0x04027FF9 RID: 163833
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027FFA RID: 163834
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x0200738A RID: 29578
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __StartScan_FunctionParams
	{
		// Token: 0x04027FFB RID: 163835
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}
}
