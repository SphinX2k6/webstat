using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Interaction.Struct;
using CSharpScript.Game.Module.Interaction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000F9E RID: 3998
[UClass("/Game/Aki/TypeScript/Game/LevelGamePlay/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGeneralBlueprintFunctionLibrary.LevelGeneralBlueprintFunctionLibrary_C")]
public class LevelGeneralBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600660A RID: 26122 RVA: 0x0019B4AD File Offset: 0x001996AD
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void UpdateEntityTag(int inEntityId, string inTag, bool isAdd)
	{
		LevelGeneralCommons.UpdateEntityTag(inEntityId, inTag, isAdd);
	}

	// Token: 0x0600660B RID: 26123 RVA: 0x0019B4B7 File Offset: 0x001996B7
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool HandleConditionInteractOption(SInteractionOption inInteractOptionConfig, string inInteractionConfigId, float inOptionIndex, AActor inTrigger)
	{
		return false;
	}

	// Token: 0x0600660C RID: 26124 RVA: 0x0019B4BA File Offset: 0x001996BA
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void TriggerLevelGeneralEvents(float inEventGroupId, AActor inTrigger)
	{
	}

	// Token: 0x0600660D RID: 26125 RVA: 0x0019B4BC File Offset: 0x001996BC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void HandleConditionalEventListen(TMap<int, int> inTargetMap)
	{
	}

	// Token: 0x0600660E RID: 26126 RVA: 0x0019B4BE File Offset: 0x001996BE
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void HandleConditionPush(int inConditionGroupId)
	{
	}

	// Token: 0x0600660F RID: 26127 RVA: 0x0019B4C0 File Offset: 0x001996C0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenInteractHints()
	{
		TsInteractionUtils.OpenInteractHintView();
	}

	// Token: 0x06006610 RID: 26128 RVA: 0x0019B4C8 File Offset: 0x001996C8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CloseInteractHints()
	{
		TsInteractionUtils.CloseInteractHintView("Unknown");
	}

	// Token: 0x06006611 RID: 26129 RVA: 0x0019B4D4 File Offset: 0x001996D4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LevelGeneralBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGeneralBlueprintFunctionLibrary.LevelGeneralBlueprintFunctionLibrary_C");
		}
		return LevelGeneralBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06006612 RID: 26130 RVA: 0x0019B4F8 File Offset: 0x001996F8
	public LevelGeneralBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06006613 RID: 26131 RVA: 0x0019B520 File Offset: 0x00199720
	[NullableContext(1)]
	public LevelGeneralBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06006614 RID: 26132 RVA: 0x0019B553 File Offset: 0x00199753
	protected LevelGeneralBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06006615 RID: 26133 RVA: 0x0019B55C File Offset: 0x0019975C
	protected unsafe static void __CPPCALL_UpdateEntityTag_Implementation(LevelGeneralBlueprintFunctionLibrary.__UpdateEntityTag_FunctionParams* __Params)
	{
		string inTag = FString.ToString((void*)(&__Params->inTag));
		LevelGeneralBlueprintFunctionLibrary.UpdateEntityTag(__Params->inEntityId, inTag, __Params->isAdd);
	}

	// Token: 0x06006616 RID: 26134 RVA: 0x0019B588 File Offset: 0x00199788
	protected unsafe static void __CPPCALL_HandleConditionInteractOption_Implementation(LevelGeneralBlueprintFunctionLibrary.__HandleConditionInteractOption_FunctionParams* __Params)
	{
		SInteractionOption inInteractOptionConfig = new SInteractionOption(&__Params->inInteractOptionConfig, true, true);
		string inInteractionConfigId = FString.ToString((void*)(&__Params->inInteractionConfigId));
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inTrigger);
		__Params->__Result = LevelGeneralBlueprintFunctionLibrary.HandleConditionInteractOption(inInteractOptionConfig, inInteractionConfigId, __Params->inOptionIndex, orCreateUObjectByNativePointer);
	}

	// Token: 0x06006617 RID: 26135 RVA: 0x0019B5D4 File Offset: 0x001997D4
	protected unsafe static void __CPPCALL_TriggerLevelGeneralEvents_Implementation(LevelGeneralBlueprintFunctionLibrary.__TriggerLevelGeneralEvents_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inTrigger);
		LevelGeneralBlueprintFunctionLibrary.TriggerLevelGeneralEvents(__Params->inEventGroupId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06006618 RID: 26136 RVA: 0x0019B5F9 File Offset: 0x001997F9
	protected unsafe static void __CPPCALL_HandleConditionalEventListen_Implementation(LevelGeneralBlueprintFunctionLibrary.__HandleConditionalEventListen_FunctionParams* __Params)
	{
		LevelGeneralBlueprintFunctionLibrary.HandleConditionalEventListen(new TMap<int, int>(&__Params->inTargetMap, true, true));
	}

	// Token: 0x06006619 RID: 26137 RVA: 0x0019B60E File Offset: 0x0019980E
	protected unsafe static void __CPPCALL_HandleConditionPush_Implementation(LevelGeneralBlueprintFunctionLibrary.__HandleConditionPush_FunctionParams* __Params)
	{
		LevelGeneralBlueprintFunctionLibrary.HandleConditionPush(__Params->inConditionGroupId);
	}

	// Token: 0x0600661A RID: 26138 RVA: 0x0019B61B File Offset: 0x0019981B
	protected unsafe static void __CPPCALL_OpenInteractHints_Implementation(LevelGeneralBlueprintFunctionLibrary.__OpenInteractHints_FunctionParams* __Params)
	{
		LevelGeneralBlueprintFunctionLibrary.OpenInteractHints();
	}

	// Token: 0x0600661B RID: 26139 RVA: 0x0019B622 File Offset: 0x00199822
	protected unsafe static void __CPPCALL_CloseInteractHints_Implementation(LevelGeneralBlueprintFunctionLibrary.__CloseInteractHints_FunctionParams* __Params)
	{
		LevelGeneralBlueprintFunctionLibrary.CloseInteractHints();
	}

	// Token: 0x04003086 RID: 12422
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGeneralBlueprintFunctionLibrary.LevelGeneralBlueprintFunctionLibrary_C";

	// Token: 0x04003087 RID: 12423
	private static IntPtr _ClassPtr;

	// Token: 0x04003088 RID: 12424
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200738B RID: 29579
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __UpdateEntityTag_FunctionParams
	{
		// Token: 0x04027FFC RID: 163836
		[FieldOffset(0)]
		public int inEntityId;

		// Token: 0x04027FFD RID: 163837
		[FieldOffset(8)]
		public FString inTag;

		// Token: 0x04027FFE RID: 163838
		[FieldOffset(24)]
		public bool isAdd;

		// Token: 0x04027FFF RID: 163839
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200738C RID: 29580
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 296)]
	protected ref struct __HandleConditionInteractOption_FunctionParams
	{
		// Token: 0x04028000 RID: 163840
		[FieldOffset(0)]
		public byte inInteractOptionConfig;

		// Token: 0x04028001 RID: 163841
		[FieldOffset(248)]
		public FString inInteractionConfigId;

		// Token: 0x04028002 RID: 163842
		[FieldOffset(264)]
		public float inOptionIndex;

		// Token: 0x04028003 RID: 163843
		[FieldOffset(272)]
		public IntPtr inTrigger;

		// Token: 0x04028004 RID: 163844
		[FieldOffset(280)]
		public IntPtr __WorldContext;

		// Token: 0x04028005 RID: 163845
		[FieldOffset(288)]
		public bool __Result;
	}

	// Token: 0x0200738D RID: 29581
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __TriggerLevelGeneralEvents_FunctionParams
	{
		// Token: 0x04028006 RID: 163846
		[FieldOffset(0)]
		public float inEventGroupId;

		// Token: 0x04028007 RID: 163847
		[FieldOffset(8)]
		public IntPtr inTrigger;

		// Token: 0x04028008 RID: 163848
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200738E RID: 29582
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __HandleConditionalEventListen_FunctionParams
	{
		// Token: 0x04028009 RID: 163849
		[FieldOffset(0)]
		public byte inTargetMap;

		// Token: 0x0402800A RID: 163850
		[FieldOffset(64)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200738F RID: 29583
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __HandleConditionPush_FunctionParams
	{
		// Token: 0x0402800B RID: 163851
		[FieldOffset(0)]
		public int inConditionGroupId;

		// Token: 0x0402800C RID: 163852
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007390 RID: 29584
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __OpenInteractHints_FunctionParams
	{
		// Token: 0x0402800D RID: 163853
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007391 RID: 29585
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __CloseInteractHints_FunctionParams
	{
		// Token: 0x0402800E RID: 163854
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}
}
