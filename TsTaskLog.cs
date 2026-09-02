using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C80 RID: 3200
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskLog.TsTaskLog_C")]
public class TsTaskLog : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000181 RID: 385
	// (get) Token: 0x060039DB RID: 14811 RVA: 0x00044D7D File Offset: 0x00042F7D
	// (set) Token: 0x060039DC RID: 14812 RVA: 0x00044D91 File Offset: 0x00042F91
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Level
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskLog.__PropertyOffset_Level)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskLog.__PropertyOffset_Level)), value);
		}
	}

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x060039DD RID: 14813 RVA: 0x00044DA6 File Offset: 0x00042FA6
	// (set) Token: 0x060039DE RID: 14814 RVA: 0x00044DBA File Offset: 0x00042FBA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Content
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskLog.__PropertyOffset_Content)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskLog.__PropertyOffset_Content)), value);
		}
	}

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x060039DF RID: 14815 RVA: 0x00044DCF File Offset: 0x00042FCF
	// (set) Token: 0x060039E0 RID: 14816 RVA: 0x00044DDF File Offset: 0x00042FDF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool LogOnTick
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskLog.__PropertyOffset_LogOnTick) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskLog.__PropertyOffset_LogOnTick) = (value ? 1 : 0);
		}
	}

	// Token: 0x060039E1 RID: 14817 RVA: 0x00044DF0 File Offset: 0x00042FF0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060039E2 RID: 14818 RVA: 0x00044E89 File Offset: 0x00043089
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (string.IsNullOrEmpty(this.Level) || string.IsNullOrEmpty(this.Content))
		{
			base.FinishExecute(false);
			return;
		}
		if (this.LogOnTick)
		{
			return;
		}
		this.PrintLog("Execute");
		base.FinishExecute(true);
	}

	// Token: 0x060039E3 RID: 14819 RVA: 0x00044EC8 File Offset: 0x000430C8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060039E4 RID: 14820 RVA: 0x00044F68 File Offset: 0x00043168
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!this.LogOnTick)
		{
			return;
		}
		this.PrintLog("Tick");
		base.FinishExecute(true);
	}

	// Token: 0x060039E5 RID: 14821 RVA: 0x00044F88 File Offset: 0x00043188
	private void PrintLog(string mainContext)
	{
		string level = this.Level;
		if (level == "Warn")
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.YJX;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Content", this.Content);
			instance.Warn(module, author, mainContext, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (level == "Info")
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.YJX;
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Content", this.Content);
			instance2.Info(module2, author2, mainContext, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		if (!(level == "Error"))
		{
			return;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.BehaviorTree;
		ELogAuthor author3 = ELogAuthor.YJX;
		ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Content", this.Content);
		instance3.Error(module3, author3, mainContext, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
	}

	// Token: 0x060039E6 RID: 14822 RVA: 0x0004503E File Offset: 0x0004323E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskLog._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskLog.TsTaskLog_C");
		}
		return TsTaskLog._ClassPtr;
	}

	// Token: 0x060039E7 RID: 14823 RVA: 0x00045064 File Offset: 0x00043264
	public TsTaskLog() : this(BuiltinUtils.AllocNativeUObject(TsTaskLog.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060039E8 RID: 14824 RVA: 0x0004508C File Offset: 0x0004328C
	public TsTaskLog(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskLog.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060039E9 RID: 14825 RVA: 0x000450BF File Offset: 0x000432BF
	protected TsTaskLog(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060039EA RID: 14826 RVA: 0x000450C8 File Offset: 0x000432C8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060039EB RID: 14827 RVA: 0x000450F8 File Offset: 0x000432F8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000976 RID: 2422
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskLog.TsTaskLog_C";

	// Token: 0x04000977 RID: 2423
	private static IntPtr _ClassPtr;

	// Token: 0x04000978 RID: 2424
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000979 RID: 2425
	private static int __PropertyOffset_Level;

	// Token: 0x0400097A RID: 2426
	private static int __PropertyOffset_Content;

	// Token: 0x0400097B RID: 2427
	private static int __PropertyOffset_LogOnTick;
}
