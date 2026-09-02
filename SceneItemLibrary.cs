using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003255 RID: 12885
[UClass("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/Util/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/Util/SceneItemLibrary.SceneItemLibrary_C")]
public class SceneItemLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601ADC8 RID: 110024 RVA: 0x008041BC File Offset: 0x008023BC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<TsSimpleInteractBase> FindInteractItemByTypeId(int typeId)
	{
		HashSet<TsSimpleInteractBase> tsSimpleInteractItemById = ModelBase<WorldModel>.Instance.GetTsSimpleInteractItemById((long)typeId);
		TArray<TsSimpleInteractBase> tarray = new TArray<TsSimpleInteractBase>();
		if (tsSimpleInteractItemById == null)
		{
			return tarray;
		}
		foreach (TsSimpleInteractBase value in tsSimpleInteractItemById)
		{
			tarray.Add(value);
		}
		return tarray;
	}

	// Token: 0x0601ADC9 RID: 110025 RVA: 0x00804224 File Offset: 0x00802424
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (SceneItemLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/Util/SceneItemLibrary.SceneItemLibrary_C");
		}
		return SceneItemLibrary._ClassPtr;
	}

	// Token: 0x0601ADCA RID: 110026 RVA: 0x00804248 File Offset: 0x00802448
	public SceneItemLibrary() : this(BuiltinUtils.AllocNativeUObject(SceneItemLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601ADCB RID: 110027 RVA: 0x00804270 File Offset: 0x00802470
	[NullableContext(1)]
	public SceneItemLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneItemLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601ADCC RID: 110028 RVA: 0x008042A3 File Offset: 0x008024A3
	protected SceneItemLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601ADCD RID: 110029 RVA: 0x008042AC File Offset: 0x008024AC
	protected unsafe static void __CPPCALL_FindInteractItemByTypeId_Implementation(SceneItemLibrary.__FindInteractItemByTypeId_FunctionParams* __Params)
	{
		TArray<TsSimpleInteractBase> tarray = SceneItemLibrary.FindInteractItemByTypeId(__Params->typeId);
		if (tarray == null)
		{
			return;
		}
		tarray.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x0400DA0B RID: 55819
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/Util/SceneItemLibrary.SceneItemLibrary_C";

	// Token: 0x0400DA0C RID: 55820
	private static IntPtr _ClassPtr;

	// Token: 0x0400DA0D RID: 55821
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200942C RID: 37932
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __FindInteractItemByTypeId_FunctionParams
	{
		// Token: 0x04031355 RID: 201557
		[FieldOffset(0)]
		public int typeId;

		// Token: 0x04031356 RID: 201558
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04031357 RID: 201559
		[FieldOffset(16)]
		public byte __Result;
	}
}
