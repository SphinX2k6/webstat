using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE6 RID: 3302
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWait.TsTaskWait_C")]
public class TsTaskWait : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000302 RID: 770
	// (get) Token: 0x06004170 RID: 16752 RVA: 0x0006BC53 File Offset: 0x00069E53
	// (set) Token: 0x06004171 RID: 16753 RVA: 0x0006BC63 File Offset: 0x00069E63
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TimeMillisecond
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWait.__PropertyOffset_TimeMillisecond);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWait.__PropertyOffset_TimeMillisecond) = value;
		}
	}

	// Token: 0x17000303 RID: 771
	// (get) Token: 0x06004172 RID: 16754 RVA: 0x0006BC74 File Offset: 0x00069E74
	// (set) Token: 0x06004173 RID: 16755 RVA: 0x0006BC88 File Offset: 0x00069E88
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyTime
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskWait.__PropertyOffset_BlackboardKeyTime)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskWait.__PropertyOffset_BlackboardKeyTime)), value);
		}
	}

	// Token: 0x17000304 RID: 772
	// (get) Token: 0x06004174 RID: 16756 RVA: 0x0006BC9D File Offset: 0x00069E9D
	// (set) Token: 0x06004175 RID: 16757 RVA: 0x0006BCAD File Offset: 0x00069EAD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RandomTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskWait.__PropertyOffset_RandomTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskWait.__PropertyOffset_RandomTime) = value;
		}
	}

	// Token: 0x06004176 RID: 16758 RVA: 0x0006BCBE File Offset: 0x00069EBE
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTimeMillisecond = this.TimeMillisecond;
			this.TsBlackboardKeyTime = this.BlackboardKeyTime;
			this.TsRandomTime = this.RandomTime;
		}
	}

	// Token: 0x06004177 RID: 16759 RVA: 0x0006BCFC File Offset: 0x00069EFC
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

	// Token: 0x06004178 RID: 16760 RVA: 0x0006BD98 File Offset: 0x00069F98
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		int num = this.TsTimeMillisecond;
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController != null && this.TsBlackboardKeyTime != "")
		{
			int valueOrDefault = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyTime).GetValueOrDefault();
			if (valueOrDefault != 0)
			{
				num = valueOrDefault;
			}
		}
		this.EndTime = Singleton<Time>.Instance.Now + (double)num + Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)this.TsRandomTime);
	}

	// Token: 0x06004179 RID: 16761 RVA: 0x0006BE38 File Offset: 0x0006A038
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

	// Token: 0x0600417A RID: 16762 RVA: 0x0006BED8 File Offset: 0x0006A0D8
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.EndTime < Singleton<Time>.Instance.Now)
		{
			base.Finish(true);
		}
	}

	// Token: 0x0600417B RID: 16763 RVA: 0x0006BEF3 File Offset: 0x0006A0F3
	protected override void OnClear()
	{
		this.EndTime = 0.0;
	}

	// Token: 0x0600417C RID: 16764 RVA: 0x0006BF04 File Offset: 0x0006A104
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskWait._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWait.TsTaskWait_C");
		}
		return TsTaskWait._ClassPtr;
	}

	// Token: 0x0600417D RID: 16765 RVA: 0x0006BF28 File Offset: 0x0006A128
	public TsTaskWait() : this(BuiltinUtils.AllocNativeUObject(TsTaskWait.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600417E RID: 16766 RVA: 0x0006BF50 File Offset: 0x0006A150
	public TsTaskWait(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskWait.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600417F RID: 16767 RVA: 0x0006BF83 File Offset: 0x0006A183
	protected TsTaskWait(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004180 RID: 16768 RVA: 0x0006BF98 File Offset: 0x0006A198
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004181 RID: 16769 RVA: 0x0006BFC8 File Offset: 0x0006A1C8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000FD8 RID: 4056
	private bool IsInitTsVariables;

	// Token: 0x04000FD9 RID: 4057
	private int TsTimeMillisecond;

	// Token: 0x04000FDA RID: 4058
	private string TsBlackboardKeyTime = "";

	// Token: 0x04000FDB RID: 4059
	private int TsRandomTime;

	// Token: 0x04000FDC RID: 4060
	private double EndTime;

	// Token: 0x04000FDD RID: 4061
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWait.TsTaskWait_C";

	// Token: 0x04000FDE RID: 4062
	private static IntPtr _ClassPtr;

	// Token: 0x04000FDF RID: 4063
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000FE0 RID: 4064
	private static int __PropertyOffset_TimeMillisecond;

	// Token: 0x04000FE1 RID: 4065
	private static int __PropertyOffset_BlackboardKeyTime;

	// Token: 0x04000FE2 RID: 4066
	private static int __PropertyOffset_RandomTime;
}
