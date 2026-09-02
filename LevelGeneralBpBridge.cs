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

// Token: 0x02000F9F RID: 3999
[UClass("/Game/Aki/TypeScript/Game/LevelGamePlay/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGeneralBpBridge.LevelGeneralBpBridge_C")]
public class LevelGeneralBpBridge : UObject, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600661C RID: 26140 RVA: 0x0019B62C File Offset: 0x0019982C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool HandleCoditionInteractOption(SInteractionOption inInteractOptionConfig, string inInteractionConfigId, float inOptionIndex, AActor inTrigger)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("HandleCoditionInteractOption"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SInteractionOption.StaticStruct(), &ptr2->inInteractOptionConfig, (inInteractOptionConfig != null) ? inInteractOptionConfig.NativePtr : ((IntPtr)0), 1, false);
			FString.CopyFrom((void*)(&ptr2->inInteractionConfigId), inInteractionConfigId);
			ptr2->inOptionIndex = inOptionIndex;
			*(&ptr2->inTrigger) = ((inTrigger != null) ? inTrigger.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600661D RID: 26141 RVA: 0x0019B6EC File Offset: 0x001998EC
	[NullableContext(1)]
	protected bool HandleCoditionInteractOption_Implementation(SInteractionOption inInteractOptionConfig, string inInteractionConfigId, float inOptionIndex, AActor inTrigger)
	{
		return false;
	}

	// Token: 0x0600661E RID: 26142 RVA: 0x0019B6F0 File Offset: 0x001998F0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void TriggerLevelGeneralEvents(float inEventGroupId, AActor inTrigger)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TriggerLevelGeneralEvents"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inEventGroupId = inEventGroupId;
			*(&ptr2->inTrigger) = ((inTrigger != null) ? inTrigger.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600661F RID: 26143 RVA: 0x0019B77B File Offset: 0x0019997B
	[NullableContext(1)]
	protected void TriggerLevelGeneralEvents_Implementation(float inEventGroupId, AActor inTrigger)
	{
	}

	// Token: 0x06006620 RID: 26144 RVA: 0x0019B780 File Offset: 0x00199980
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void HandleConditionalEventListen(TMap<int, int> inTargetMap)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("HandleConditionalEventListen"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			if (inTargetMap != null)
			{
				inTargetMap.CopyTo(&ptr2->inTargetMap, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06006621 RID: 26145 RVA: 0x0019B809 File Offset: 0x00199A09
	[NullableContext(1)]
	protected void HandleConditionalEventListen_Implementation(TMap<int, int> inTargetMap)
	{
	}

	// Token: 0x06006622 RID: 26146 RVA: 0x0019B80C File Offset: 0x00199A0C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void HandleConditionPush(int inConditionGroupId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("HandleConditionPush"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__HandleConditionPush_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__HandleConditionPush_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__HandleConditionPush_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inConditionGroupId = inConditionGroupId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06006623 RID: 26147 RVA: 0x0019B882 File Offset: 0x00199A82
	protected void HandleConditionPush_Implementation(int inConditionGroupId)
	{
	}

	// Token: 0x06006624 RID: 26148 RVA: 0x0019B884 File Offset: 0x00199A84
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OpenInteractHints()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OpenInteractHints"), out num);
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

	// Token: 0x06006625 RID: 26149 RVA: 0x0019B8F4 File Offset: 0x00199AF4
	protected void OpenInteractHints_Implementation()
	{
		TsInteractionUtils.OpenInteractHintView();
	}

	// Token: 0x06006626 RID: 26150 RVA: 0x0019B8FC File Offset: 0x00199AFC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void CloseInteractHints()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("CloseInteractHints"), out num);
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

	// Token: 0x06006627 RID: 26151 RVA: 0x0019B96C File Offset: 0x00199B6C
	protected void CloseInteractHints_Implementation()
	{
		TsInteractionUtils.CloseInteractHintView("Unknown");
	}

	// Token: 0x06006628 RID: 26152 RVA: 0x0019B978 File Offset: 0x00199B78
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LevelGeneralBpBridge._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGeneralBpBridge.LevelGeneralBpBridge_C");
		}
		return LevelGeneralBpBridge._ClassPtr;
	}

	// Token: 0x06006629 RID: 26153 RVA: 0x0019B99C File Offset: 0x00199B9C
	public LevelGeneralBpBridge() : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBpBridge.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600662A RID: 26154 RVA: 0x0019B9C4 File Offset: 0x00199BC4
	[NullableContext(1)]
	public LevelGeneralBpBridge(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBpBridge.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600662B RID: 26155 RVA: 0x0019B9F7 File Offset: 0x00199BF7
	protected LevelGeneralBpBridge(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600662C RID: 26156 RVA: 0x0019BA00 File Offset: 0x00199C00
	protected unsafe virtual void __CPPCALL_HandleCoditionInteractOption_Implementation(LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams* __Params)
	{
		SInteractionOption inInteractOptionConfig = new SInteractionOption(&__Params->inInteractOptionConfig, true, true);
		string inInteractionConfigId = FString.ToString((void*)(&__Params->inInteractionConfigId));
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inTrigger);
		__Params->__Result = this.HandleCoditionInteractOption_Implementation(inInteractOptionConfig, inInteractionConfigId, __Params->inOptionIndex, orCreateUObjectByNativePointer);
	}

	// Token: 0x0600662D RID: 26157 RVA: 0x0019BA4C File Offset: 0x00199C4C
	protected unsafe virtual void __CPPCALL_TriggerLevelGeneralEvents_Implementation(LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inTrigger);
		this.TriggerLevelGeneralEvents_Implementation(__Params->inEventGroupId, orCreateUObjectByNativePointer);
	}

	// Token: 0x0600662E RID: 26158 RVA: 0x0019BA74 File Offset: 0x00199C74
	protected unsafe virtual void __CPPCALL_HandleConditionalEventListen_Implementation(LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams* __Params)
	{
		TMap<int, int> inTargetMap = new TMap<int, int>(&__Params->inTargetMap, true, true);
		this.HandleConditionalEventListen_Implementation(inTargetMap);
	}

	// Token: 0x0600662F RID: 26159 RVA: 0x0019BA97 File Offset: 0x00199C97
	protected unsafe virtual void __CPPCALL_HandleConditionPush_Implementation(LevelGeneralBpBridge.__HandleConditionPush_FunctionParams* __Params)
	{
		this.HandleConditionPush_Implementation(__Params->inConditionGroupId);
	}

	// Token: 0x06006630 RID: 26160 RVA: 0x0019BAA5 File Offset: 0x00199CA5
	protected virtual void __CPPCALL_OpenInteractHints_Implementation()
	{
		this.OpenInteractHints_Implementation();
	}

	// Token: 0x06006631 RID: 26161 RVA: 0x0019BAAD File Offset: 0x00199CAD
	protected virtual void __CPPCALL_CloseInteractHints_Implementation()
	{
		this.CloseInteractHints_Implementation();
	}

	// Token: 0x04003089 RID: 12425
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/LevelGamePlay/LevelGeneralBpBridge.LevelGeneralBpBridge_C";

	// Token: 0x0400308A RID: 12426
	private static IntPtr _ClassPtr;

	// Token: 0x0400308B RID: 12427
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02007392 RID: 29586
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 288)]
	protected ref struct __HandleCoditionInteractOption_FunctionParams
	{
		// Token: 0x0402800F RID: 163855
		[FieldOffset(0)]
		public byte inInteractOptionConfig;

		// Token: 0x04028010 RID: 163856
		[FieldOffset(248)]
		public FString inInteractionConfigId;

		// Token: 0x04028011 RID: 163857
		[FieldOffset(264)]
		public float inOptionIndex;

		// Token: 0x04028012 RID: 163858
		[FieldOffset(272)]
		public IntPtr inTrigger;

		// Token: 0x04028013 RID: 163859
		[FieldOffset(280)]
		public bool __Result;
	}

	// Token: 0x02007393 RID: 29587
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __TriggerLevelGeneralEvents_FunctionParams
	{
		// Token: 0x04028014 RID: 163860
		[FieldOffset(0)]
		public float inEventGroupId;

		// Token: 0x04028015 RID: 163861
		[FieldOffset(8)]
		public IntPtr inTrigger;
	}

	// Token: 0x02007394 RID: 29588
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 60)]
	protected ref struct __HandleConditionalEventListen_FunctionParams
	{
		// Token: 0x04028016 RID: 163862
		[FieldOffset(0)]
		public byte inTargetMap;
	}

	// Token: 0x02007395 RID: 29589
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __HandleConditionPush_FunctionParams
	{
		// Token: 0x04028017 RID: 163863
		[FieldOffset(0)]
		public int inConditionGroupId;
	}
}
