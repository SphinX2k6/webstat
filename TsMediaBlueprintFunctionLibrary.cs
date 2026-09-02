using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E35 RID: 11829
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMediaBlueprintFunctionLibrary.TsMediaBlueprintFunctionLibrary_C")]
public class TsMediaBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x06018291 RID: 98961 RVA: 0x006C13F4 File Offset: 0x006BF5F4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetAffectedByP1orP3(int entityId)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		return component == null || component.IsP1;
	}

	// Token: 0x06018292 RID: 98962 RVA: 0x006C1418 File Offset: 0x006BF618
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void PostAkEventByTs(int entityId, UAkComponent charAkComponent, UAkAudioEvent eventPtr, string attachName, ref TArray<string> switchDataRef, bool bFollow)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component != null)
		{
			TArray<string> switchData = switchDataRef;
			component.PostAkEvent(charAkComponent, eventPtr, attachName, switchData, bFollow);
		}
	}

	// Token: 0x06018293 RID: 98963 RVA: 0x006C1448 File Offset: 0x006BF648
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float PostAkEventByTsWithoutData(int entityId, UAkComponent charAkComponent, UAkAudioEvent eventPtr, string attachName, ref TArray<string> switchData, bool bFollow)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component == null)
		{
			return -1f;
		}
		return (float)component.PostAkEvent(charAkComponent, eventPtr, attachName, switchData, bFollow);
	}

	// Token: 0x06018294 RID: 98964 RVA: 0x006C147C File Offset: 0x006BF67C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDebug(int entityId, bool bDebug)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetDebug(bDebug);
	}

	// Token: 0x06018295 RID: 98965 RVA: 0x006C14A0 File Offset: 0x006BF6A0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	protected static UAkComponent GetAkComponentBySocketName(int entityId, string socketName)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetAkComponentBySocketName(FNameUtil.GetDynamicFName(socketName).Value);
	}

	// Token: 0x06018296 RID: 98966 RVA: 0x006C14D4 File Offset: 0x006BF6D4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetFootSwitch(int entityId, string footSwitch)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.FootSwitch = footSwitch;
	}

	// Token: 0x06018297 RID: 98967 RVA: 0x006C14F8 File Offset: 0x006BF6F8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetFootSwitch(int entityId)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		return component.FootSwitch;
	}

	// Token: 0x06018298 RID: 98968 RVA: 0x006C1520 File Offset: 0x006BF720
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetWaterDepth(int entityId)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return (float)component.WaterDepth;
	}

	// Token: 0x06018299 RID: 98969 RVA: 0x006C1549 File Offset: 0x006BF749
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void PostRoleAudioEvent(int entityId, string action)
	{
		CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.PostAudioEvent(action);
	}

	// Token: 0x0601829A RID: 98970 RVA: 0x006C1561 File Offset: 0x006BF761
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EmitFootOnTheGroundEvent()
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnCharFootOnTheGround, false);
	}

	// Token: 0x0601829B RID: 98971 RVA: 0x006C1574 File Offset: 0x006BF774
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsMediaBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMediaBlueprintFunctionLibrary.TsMediaBlueprintFunctionLibrary_C");
		}
		return TsMediaBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x0601829C RID: 98972 RVA: 0x006C1598 File Offset: 0x006BF798
	public TsMediaBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsMediaBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601829D RID: 98973 RVA: 0x006C15C0 File Offset: 0x006BF7C0
	[NullableContext(1)]
	public TsMediaBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMediaBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601829E RID: 98974 RVA: 0x006C15F3 File Offset: 0x006BF7F3
	protected TsMediaBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601829F RID: 98975 RVA: 0x006C15FC File Offset: 0x006BF7FC
	protected unsafe static void __CPPCALL_GetAffectedByP1orP3_Implementation(TsMediaBlueprintFunctionLibrary.__GetAffectedByP1orP3_FunctionParams* __Params)
	{
		__Params->__Result = TsMediaBlueprintFunctionLibrary.GetAffectedByP1orP3(__Params->entityId);
	}

	// Token: 0x060182A0 RID: 98976 RVA: 0x006C1610 File Offset: 0x006BF810
	protected unsafe static void __CPPCALL_PostAkEventByTs_Implementation(TsMediaBlueprintFunctionLibrary.__PostAkEventByTs_FunctionParams* __Params)
	{
		UAkComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkComponent>(__Params->charAkComponent);
		UAkAudioEvent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkAudioEvent>(__Params->eventPtr);
		string attachName = FString.ToString((void*)(&__Params->attachName));
		TArray<string> tarray = new TArray<string>(&__Params->switchDataRef, true, true);
		TsMediaBlueprintFunctionLibrary.PostAkEventByTs(__Params->entityId, orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, attachName, ref tarray, __Params->bFollow);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->switchDataRef, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060182A1 RID: 98977 RVA: 0x006C1684 File Offset: 0x006BF884
	protected unsafe static void __CPPCALL_PostAkEventByTsWithoutData_Implementation(TsMediaBlueprintFunctionLibrary.__PostAkEventByTsWithoutData_FunctionParams* __Params)
	{
		UAkComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkComponent>(__Params->charAkComponent);
		UAkAudioEvent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkAudioEvent>(__Params->eventPtr);
		string attachName = FString.ToString((void*)(&__Params->attachName));
		TArray<string> tarray = new TArray<string>(&__Params->switchData, true, true);
		__Params->__Result = TsMediaBlueprintFunctionLibrary.PostAkEventByTsWithoutData(__Params->entityId, orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, attachName, ref tarray, __Params->bFollow);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->switchData, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060182A2 RID: 98978 RVA: 0x006C16FB File Offset: 0x006BF8FB
	protected unsafe static void __CPPCALL_SetDebug_Implementation(TsMediaBlueprintFunctionLibrary.__SetDebug_FunctionParams* __Params)
	{
		TsMediaBlueprintFunctionLibrary.SetDebug(__Params->entityId, __Params->bDebug);
	}

	// Token: 0x060182A3 RID: 98979 RVA: 0x006C1710 File Offset: 0x006BF910
	protected unsafe static void __CPPCALL_GetAkComponentBySocketName_Implementation(TsMediaBlueprintFunctionLibrary.__GetAkComponentBySocketName_FunctionParams* __Params)
	{
		string socketName = FString.ToString((void*)(&__Params->socketName));
		ref IntPtr ptr = ref *(&__Params->__Result);
		UAkComponent akComponentBySocketName = TsMediaBlueprintFunctionLibrary.GetAkComponentBySocketName(__Params->entityId, socketName);
		ptr = ((akComponentBySocketName != null) ? akComponentBySocketName.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060182A4 RID: 98980 RVA: 0x006C174C File Offset: 0x006BF94C
	protected unsafe static void __CPPCALL_SetFootSwitch_Implementation(TsMediaBlueprintFunctionLibrary.__SetFootSwitch_FunctionParams* __Params)
	{
		string footSwitch = FString.ToString((void*)(&__Params->footSwitch));
		TsMediaBlueprintFunctionLibrary.SetFootSwitch(__Params->entityId, footSwitch);
	}

	// Token: 0x060182A5 RID: 98981 RVA: 0x006C1772 File Offset: 0x006BF972
	protected unsafe static void __CPPCALL_GetFootSwitch_Implementation(TsMediaBlueprintFunctionLibrary.__GetFootSwitch_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsMediaBlueprintFunctionLibrary.GetFootSwitch(__Params->entityId));
	}

	// Token: 0x060182A6 RID: 98982 RVA: 0x006C178B File Offset: 0x006BF98B
	protected unsafe static void __CPPCALL_GetWaterDepth_Implementation(TsMediaBlueprintFunctionLibrary.__GetWaterDepth_FunctionParams* __Params)
	{
		__Params->__Result = TsMediaBlueprintFunctionLibrary.GetWaterDepth(__Params->entityId);
	}

	// Token: 0x060182A7 RID: 98983 RVA: 0x006C17A0 File Offset: 0x006BF9A0
	protected unsafe static void __CPPCALL_PostRoleAudioEvent_Implementation(TsMediaBlueprintFunctionLibrary.__PostRoleAudioEvent_FunctionParams* __Params)
	{
		string action = FString.ToString((void*)(&__Params->action));
		TsMediaBlueprintFunctionLibrary.PostRoleAudioEvent(__Params->entityId, action);
	}

	// Token: 0x060182A8 RID: 98984 RVA: 0x006C17C6 File Offset: 0x006BF9C6
	protected unsafe static void __CPPCALL_EmitFootOnTheGroundEvent_Implementation(TsMediaBlueprintFunctionLibrary.__EmitFootOnTheGroundEvent_FunctionParams* __Params)
	{
		TsMediaBlueprintFunctionLibrary.EmitFootOnTheGroundEvent();
	}

	// Token: 0x0400BA21 RID: 47649
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMediaBlueprintFunctionLibrary.TsMediaBlueprintFunctionLibrary_C";

	// Token: 0x0400BA22 RID: 47650
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA23 RID: 47651
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02009232 RID: 37426
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAffectedByP1orP3_FunctionParams
	{
		// Token: 0x04030C7B RID: 199803
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C7C RID: 199804
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C7D RID: 199805
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009233 RID: 37427
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __PostAkEventByTs_FunctionParams
	{
		// Token: 0x04030C7E RID: 199806
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C7F RID: 199807
		[FieldOffset(8)]
		public IntPtr charAkComponent;

		// Token: 0x04030C80 RID: 199808
		[FieldOffset(16)]
		public IntPtr eventPtr;

		// Token: 0x04030C81 RID: 199809
		[FieldOffset(24)]
		public FString attachName;

		// Token: 0x04030C82 RID: 199810
		[FieldOffset(40)]
		public byte switchDataRef;

		// Token: 0x04030C83 RID: 199811
		[FieldOffset(56)]
		public bool bFollow;

		// Token: 0x04030C84 RID: 199812
		[FieldOffset(64)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009234 RID: 37428
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __PostAkEventByTsWithoutData_FunctionParams
	{
		// Token: 0x04030C85 RID: 199813
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C86 RID: 199814
		[FieldOffset(8)]
		public IntPtr charAkComponent;

		// Token: 0x04030C87 RID: 199815
		[FieldOffset(16)]
		public IntPtr eventPtr;

		// Token: 0x04030C88 RID: 199816
		[FieldOffset(24)]
		public FString attachName;

		// Token: 0x04030C89 RID: 199817
		[FieldOffset(40)]
		public byte switchData;

		// Token: 0x04030C8A RID: 199818
		[FieldOffset(56)]
		public bool bFollow;

		// Token: 0x04030C8B RID: 199819
		[FieldOffset(64)]
		public IntPtr __WorldContext;

		// Token: 0x04030C8C RID: 199820
		[FieldOffset(72)]
		public float __Result;
	}

	// Token: 0x02009235 RID: 37429
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDebug_FunctionParams
	{
		// Token: 0x04030C8D RID: 199821
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C8E RID: 199822
		[FieldOffset(4)]
		public bool bDebug;

		// Token: 0x04030C8F RID: 199823
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009236 RID: 37430
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetAkComponentBySocketName_FunctionParams
	{
		// Token: 0x04030C90 RID: 199824
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C91 RID: 199825
		[FieldOffset(8)]
		public FString socketName;

		// Token: 0x04030C92 RID: 199826
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030C93 RID: 199827
		[FieldOffset(32)]
		public IntPtr __Result;
	}

	// Token: 0x02009237 RID: 37431
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetFootSwitch_FunctionParams
	{
		// Token: 0x04030C94 RID: 199828
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C95 RID: 199829
		[FieldOffset(8)]
		public FString footSwitch;

		// Token: 0x04030C96 RID: 199830
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009238 RID: 37432
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetFootSwitch_FunctionParams
	{
		// Token: 0x04030C97 RID: 199831
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C98 RID: 199832
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C99 RID: 199833
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009239 RID: 37433
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetWaterDepth_FunctionParams
	{
		// Token: 0x04030C9A RID: 199834
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C9B RID: 199835
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C9C RID: 199836
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200923A RID: 37434
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __PostRoleAudioEvent_FunctionParams
	{
		// Token: 0x04030C9D RID: 199837
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C9E RID: 199838
		[FieldOffset(8)]
		public FString action;

		// Token: 0x04030C9F RID: 199839
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200923B RID: 37435
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __EmitFootOnTheGroundEvent_FunctionParams
	{
		// Token: 0x04030CA0 RID: 199840
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}
}
