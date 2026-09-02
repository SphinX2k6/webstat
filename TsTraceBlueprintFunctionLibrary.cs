using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E39 RID: 11833
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsTraceBlueprintFunctionLibrary.TsTraceBlueprintFunctionLibrary_C")]
public class TsTraceBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060183F6 RID: 99318 RVA: 0x006C5910 File Offset: 0x006C3B10
	static TsTraceBlueprintFunctionLibrary()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsTraceBlueprintFunctionLibrary.CreateStaticDefaultValue), new Action(TsTraceBlueprintFunctionLibrary.ResetStaticDefaultValue));
	}

	// Token: 0x060183F7 RID: 99319 RVA: 0x006C5970 File Offset: 0x006C3B70
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool SphereDetect(float radius, FVectorDouble start, FVectorDouble end, [Nullable(new byte[]
	{
		1,
		0
	})] ref TArray<TEnumAsByte<EObjectTypeQuery>> objectTypes, bool isSingle = true, bool debugDraw = false)
	{
		if (TsTraceBlueprintFunctionLibrary.SphereElement == null)
		{
			TsTraceBlueprintFunctionLibrary.SphereElement = new UTraceSphereElement();
		}
		UTraceSphereElement sphereElement = TsTraceBlueprintFunctionLibrary.SphereElement;
		sphereElement.Radius = radius;
		sphereElement.WorldContextObject = GlobalData.World;
		sphereElement.SetStartLocation(start.X, start.Y, start.Z);
		sphereElement.SetEndLocation(end.X, end.Y, end.Z);
		sphereElement.SetObjectTypesQuery(ref objectTypes);
		sphereElement.bIsSingle = isSingle;
		if (debugDraw)
		{
			sphereElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
			sphereElement.DrawTime = 1f;
		}
		return Singleton<TraceElementCommon>.Instance.SphereTrace(sphereElement, "SphereDetect");
	}

	// Token: 0x060183F8 RID: 99320 RVA: 0x006C5A0C File Offset: 0x006C3C0C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool BoxDetect(FVector halfSize, FVectorDouble start, FVectorDouble end, [Nullable(new byte[]
	{
		1,
		0
	})] ref TArray<TEnumAsByte<EObjectTypeQuery>> objectTypes, bool isSingle = true, bool debugDraw = false)
	{
		if (TsTraceBlueprintFunctionLibrary.BoxElement == null)
		{
			TsTraceBlueprintFunctionLibrary.BoxElement = new UTraceBoxElement();
		}
		UTraceBoxElement boxElement = TsTraceBlueprintFunctionLibrary.BoxElement;
		boxElement.WorldContextObject = GlobalData.World;
		boxElement.SetBoxHalfSize(halfSize.X, halfSize.Y, halfSize.Z);
		boxElement.SetStartLocation(start.X, start.Y, start.Z);
		boxElement.SetEndLocation(end.X, end.Y, end.Z);
		TsTraceBlueprintFunctionLibrary.LookVector.FromUeVector(end);
		TsTraceBlueprintFunctionLibrary.LookVector.X -= end.X;
		TsTraceBlueprintFunctionLibrary.LookVector.Y -= end.Y;
		TsTraceBlueprintFunctionLibrary.LookVector.Z -= end.Z;
		TsTraceBlueprintFunctionLibrary.LookVector.Normalize(9.99999993922529E-09);
		Singleton<MathUtils>.Instance.LookRotationUpFirst(TsTraceBlueprintFunctionLibrary.LookVector, Vector.UpVectorProxy, TsTraceBlueprintFunctionLibrary.LookQuat);
		Rotator rotator = TsTraceBlueprintFunctionLibrary.LookQuat.Rotator(null);
		boxElement.SetBoxOrientation(rotator.Pitch, rotator.Yaw, rotator.Roll);
		boxElement.SetObjectTypesQuery(ref objectTypes);
		boxElement.bIsSingle = isSingle;
		if (debugDraw)
		{
			boxElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
			boxElement.DrawTime = 1f;
		}
		return Singleton<TraceElementCommon>.Instance.BoxTrace(boxElement, "BoxDetect");
	}

	// Token: 0x060183F9 RID: 99321 RVA: 0x006C5B5A File Offset: 0x006C3D5A
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060183FA RID: 99322 RVA: 0x006C5B5C File Offset: 0x006C3D5C
	public static void ResetStaticDefaultValue()
	{
		TsTraceBlueprintFunctionLibrary.SphereElement = null;
		TsTraceBlueprintFunctionLibrary.BoxElement = null;
	}

	// Token: 0x060183FB RID: 99323 RVA: 0x006C5B6A File Offset: 0x006C3D6A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTraceBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsTraceBlueprintFunctionLibrary.TsTraceBlueprintFunctionLibrary_C");
		}
		return TsTraceBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060183FC RID: 99324 RVA: 0x006C5B90 File Offset: 0x006C3D90
	public TsTraceBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsTraceBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060183FD RID: 99325 RVA: 0x006C5BB8 File Offset: 0x006C3DB8
	[NullableContext(1)]
	public TsTraceBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTraceBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060183FE RID: 99326 RVA: 0x006C5BEB File Offset: 0x006C3DEB
	protected TsTraceBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060183FF RID: 99327 RVA: 0x006C5BF4 File Offset: 0x006C3DF4
	protected unsafe static void __CPPCALL_SphereDetect_Implementation(TsTraceBlueprintFunctionLibrary.__SphereDetect_FunctionParams* __Params)
	{
		TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>(&__Params->objectTypes, true, true);
		__Params->__Result = TsTraceBlueprintFunctionLibrary.SphereDetect(__Params->radius, __Params->start, __Params->end, ref tarray, __Params->isSingle, __Params->debugDraw);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->objectTypes, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x06018400 RID: 99328 RVA: 0x006C5C54 File Offset: 0x006C3E54
	protected unsafe static void __CPPCALL_BoxDetect_Implementation(TsTraceBlueprintFunctionLibrary.__BoxDetect_FunctionParams* __Params)
	{
		TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>(&__Params->objectTypes, true, true);
		__Params->__Result = TsTraceBlueprintFunctionLibrary.BoxDetect(__Params->halfSize, __Params->start, __Params->end, ref tarray, __Params->isSingle, __Params->debugDraw);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->objectTypes, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x0400BA35 RID: 47669
	[Nullable(2)]
	private static UTraceSphereElement SphereElement = null;

	// Token: 0x0400BA36 RID: 47670
	[Nullable(2)]
	private static UTraceBoxElement BoxElement = null;

	// Token: 0x0400BA37 RID: 47671
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Vector LookVector = Vector.Create();

	// Token: 0x0400BA38 RID: 47672
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Quat LookQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400BA39 RID: 47673
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsTraceBlueprintFunctionLibrary.TsTraceBlueprintFunctionLibrary_C";

	// Token: 0x0400BA3A RID: 47674
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA3B RID: 47675
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020092D9 RID: 37593
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __SphereDetect_FunctionParams
	{
		// Token: 0x04030EB3 RID: 200371
		[FieldOffset(0)]
		public float radius;

		// Token: 0x04030EB4 RID: 200372
		[FieldOffset(8)]
		public FVectorDouble start;

		// Token: 0x04030EB5 RID: 200373
		[FieldOffset(32)]
		public FVectorDouble end;

		// Token: 0x04030EB6 RID: 200374
		[FieldOffset(56)]
		public byte objectTypes;

		// Token: 0x04030EB7 RID: 200375
		[FieldOffset(72)]
		public bool isSingle;

		// Token: 0x04030EB8 RID: 200376
		[FieldOffset(73)]
		public bool debugDraw;

		// Token: 0x04030EB9 RID: 200377
		[FieldOffset(80)]
		public IntPtr __WorldContext;

		// Token: 0x04030EBA RID: 200378
		[FieldOffset(88)]
		public bool __Result;
	}

	// Token: 0x020092DA RID: 37594
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 104)]
	protected ref struct __BoxDetect_FunctionParams
	{
		// Token: 0x04030EBB RID: 200379
		[FieldOffset(0)]
		public FVector halfSize;

		// Token: 0x04030EBC RID: 200380
		[FieldOffset(16)]
		public FVectorDouble start;

		// Token: 0x04030EBD RID: 200381
		[FieldOffset(40)]
		public FVectorDouble end;

		// Token: 0x04030EBE RID: 200382
		[FieldOffset(64)]
		public byte objectTypes;

		// Token: 0x04030EBF RID: 200383
		[FieldOffset(80)]
		public bool isSingle;

		// Token: 0x04030EC0 RID: 200384
		[FieldOffset(81)]
		public bool debugDraw;

		// Token: 0x04030EC1 RID: 200385
		[FieldOffset(88)]
		public IntPtr __WorldContext;

		// Token: 0x04030EC2 RID: 200386
		[FieldOffset(96)]
		public bool __Result;
	}
}
