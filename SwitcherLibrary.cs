using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003460 RID: 13408
[UClass("/Game/Aki/TypeScript/Game/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Utils/SwitcherLibrary.SwitcherLibrary_C")]
public class SwitcherLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601C209 RID: 115209 RVA: 0x00864A48 File Offset: 0x00862C48
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<string> GetAllSwitcher()
	{
		Dictionary<string, ValueTuple<Func<bool>, Action<bool>>> allSwitcher = Singleton<SwitcherManager>.Instance.AllSwitcher;
		TArray<string> tarray = new TArray<string>();
		foreach (KeyValuePair<string, ValueTuple<Func<bool>, Action<bool>>> keyValuePair in allSwitcher)
		{
			tarray.Add(keyValuePair.Key);
		}
		return tarray;
	}

	// Token: 0x0601C20A RID: 115210 RVA: 0x00864AAC File Offset: 0x00862CAC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetSwitcher(string switcherName, bool value)
	{
		ValueTuple<Func<bool>, Action<bool>> valueTuple;
		if (Singleton<SwitcherManager>.Instance.AllSwitcher.TryGetValue(switcherName, out valueTuple))
		{
			valueTuple.Item2(value);
		}
	}

	// Token: 0x0601C20B RID: 115211 RVA: 0x00864ADC File Offset: 0x00862CDC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetSwitcher(string switcherName)
	{
		ValueTuple<Func<bool>, Action<bool>> valueTuple;
		return Singleton<SwitcherManager>.Instance.AllSwitcher.TryGetValue(switcherName, out valueTuple) && valueTuple.Item1();
	}

	// Token: 0x0601C20C RID: 115212 RVA: 0x00864B0A File Offset: 0x00862D0A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (SwitcherLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Utils/SwitcherLibrary.SwitcherLibrary_C");
		}
		return SwitcherLibrary._ClassPtr;
	}

	// Token: 0x0601C20D RID: 115213 RVA: 0x00864B30 File Offset: 0x00862D30
	public SwitcherLibrary() : this(BuiltinUtils.AllocNativeUObject(SwitcherLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C20E RID: 115214 RVA: 0x00864B58 File Offset: 0x00862D58
	[NullableContext(1)]
	public SwitcherLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SwitcherLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C20F RID: 115215 RVA: 0x00864B8B File Offset: 0x00862D8B
	protected SwitcherLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C210 RID: 115216 RVA: 0x00864B94 File Offset: 0x00862D94
	protected unsafe static void __CPPCALL_GetAllSwitcher_Implementation(SwitcherLibrary.__GetAllSwitcher_FunctionParams* __Params)
	{
		TArray<string> allSwitcher = SwitcherLibrary.GetAllSwitcher();
		if (allSwitcher == null)
		{
			return;
		}
		allSwitcher.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x0601C211 RID: 115217 RVA: 0x00864BC0 File Offset: 0x00862DC0
	protected unsafe static void __CPPCALL_SetSwitcher_Implementation(SwitcherLibrary.__SetSwitcher_FunctionParams* __Params)
	{
		SwitcherLibrary.SetSwitcher(FString.ToString((void*)(&__Params->switcherName)), __Params->value);
	}

	// Token: 0x0601C212 RID: 115218 RVA: 0x00864BDC File Offset: 0x00862DDC
	protected unsafe static void __CPPCALL_GetSwitcher_Implementation(SwitcherLibrary.__GetSwitcher_FunctionParams* __Params)
	{
		string switcherName = FString.ToString((void*)(&__Params->switcherName));
		__Params->__Result = SwitcherLibrary.GetSwitcher(switcherName);
	}

	// Token: 0x0400E317 RID: 58135
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Utils/SwitcherLibrary.SwitcherLibrary_C";

	// Token: 0x0400E318 RID: 58136
	private static IntPtr _ClassPtr;

	// Token: 0x0400E319 RID: 58137
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200954C RID: 38220
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAllSwitcher_FunctionParams
	{
		// Token: 0x040315FF RID: 202239
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04031600 RID: 202240
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x0200954D RID: 38221
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetSwitcher_FunctionParams
	{
		// Token: 0x04031601 RID: 202241
		[FieldOffset(0)]
		public FString switcherName;

		// Token: 0x04031602 RID: 202242
		[FieldOffset(16)]
		public bool value;

		// Token: 0x04031603 RID: 202243
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200954E RID: 38222
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetSwitcher_FunctionParams
	{
		// Token: 0x04031604 RID: 202244
		[FieldOffset(0)]
		public FString switcherName;

		// Token: 0x04031605 RID: 202245
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04031606 RID: 202246
		[FieldOffset(24)]
		public bool __Result;
	}
}
