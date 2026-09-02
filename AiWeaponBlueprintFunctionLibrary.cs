using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AiInteraction.AiWeapon;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02001793 RID: 6035
[UClass("/Game/Aki/TypeScript/Game/Module/AiInteraction/AiWeapon/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/AiInteraction/AiWeapon/AiWeaponBlueprintFunctionLibrary.AiWeaponBlueprintFunctionLibrary_C")]
public class AiWeaponBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600AA5F RID: 43615 RVA: 0x002D71CC File Offset: 0x002D53CC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CharacterRequestPickUpAiWeapon(int entityId, int itemEntityId)
	{
		ModelBase<AiWeaponModel>.Instance.Net.SendHoldWeaponPush(entityId, itemEntityId);
	}

	// Token: 0x0600AA60 RID: 43616 RVA: 0x002D71E0 File Offset: 0x002D53E0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AiWeaponBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/AiInteraction/AiWeapon/AiWeaponBlueprintFunctionLibrary.AiWeaponBlueprintFunctionLibrary_C");
		}
		return AiWeaponBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x0600AA61 RID: 43617 RVA: 0x002D7204 File Offset: 0x002D5404
	public AiWeaponBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(AiWeaponBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600AA62 RID: 43618 RVA: 0x002D722C File Offset: 0x002D542C
	[NullableContext(1)]
	public AiWeaponBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AiWeaponBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600AA63 RID: 43619 RVA: 0x002D725F File Offset: 0x002D545F
	protected AiWeaponBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600AA64 RID: 43620 RVA: 0x002D7268 File Offset: 0x002D5468
	protected unsafe static void __CPPCALL_CharacterRequestPickUpAiWeapon_Implementation(AiWeaponBlueprintFunctionLibrary.__CharacterRequestPickUpAiWeapon_FunctionParams* __Params)
	{
		AiWeaponBlueprintFunctionLibrary.CharacterRequestPickUpAiWeapon(__Params->entityId, __Params->itemEntityId);
	}

	// Token: 0x04005012 RID: 20498
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/AiInteraction/AiWeapon/AiWeaponBlueprintFunctionLibrary.AiWeaponBlueprintFunctionLibrary_C";

	// Token: 0x04005013 RID: 20499
	private static IntPtr _ClassPtr;

	// Token: 0x04005014 RID: 20500
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02007AF4 RID: 31476
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __CharacterRequestPickUpAiWeapon_FunctionParams
	{
		// Token: 0x0402A1A6 RID: 172454
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0402A1A7 RID: 172455
		[FieldOffset(4)]
		public int itemEntityId;

		// Token: 0x0402A1A8 RID: 172456
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
