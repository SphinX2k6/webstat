using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CCC RID: 3276
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomFloat.TsTaskRandomFloat_C")]
public class TsTaskRandomFloat : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06003FD0 RID: 16336 RVA: 0x00063A87 File Offset: 0x00061C87
	// (set) Token: 0x06003FD1 RID: 16337 RVA: 0x00063A97 File Offset: 0x00061C97
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Min
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomFloat.__PropertyOffset_Min);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomFloat.__PropertyOffset_Min) = value;
		}
	}

	// Token: 0x170002AE RID: 686
	// (get) Token: 0x06003FD2 RID: 16338 RVA: 0x00063AA8 File Offset: 0x00061CA8
	// (set) Token: 0x06003FD3 RID: 16339 RVA: 0x00063AB8 File Offset: 0x00061CB8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Max
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomFloat.__PropertyOffset_Max);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomFloat.__PropertyOffset_Max) = value;
		}
	}

	// Token: 0x170002AF RID: 687
	// (get) Token: 0x06003FD4 RID: 16340 RVA: 0x00063AC9 File Offset: 0x00061CC9
	// (set) Token: 0x06003FD5 RID: 16341 RVA: 0x00063ADD File Offset: 0x00061CDD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyWriteTo
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskRandomFloat.__PropertyOffset_BlackboardKeyWriteTo)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskRandomFloat.__PropertyOffset_BlackboardKeyWriteTo)), value);
		}
	}

	// Token: 0x06003FD6 RID: 16342 RVA: 0x00063AF2 File Offset: 0x00061CF2
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMin = this.Min;
			this.TsMax = this.Max;
			this.TsBlackboardKeyWriteTo = this.BlackboardKeyWriteTo;
		}
	}

	// Token: 0x06003FD7 RID: 16343 RVA: 0x00063B30 File Offset: 0x00061D30
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

	// Token: 0x06003FD8 RID: 16344 RVA: 0x00063BD0 File Offset: 0x00061DD0
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		ControllerBase<BlackboardController>.Instance.SetFloatValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyWriteTo, (float)Singleton<MathUtils>.Instance.GetRandomRange((double)this.TsMin, (double)this.TsMax));
		base.FinishExecute(true);
	}

	// Token: 0x06003FD9 RID: 16345 RVA: 0x00063C74 File Offset: 0x00061E74
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskRandomFloat._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomFloat.TsTaskRandomFloat_C");
		}
		return TsTaskRandomFloat._ClassPtr;
	}

	// Token: 0x06003FDA RID: 16346 RVA: 0x00063C98 File Offset: 0x00061E98
	public TsTaskRandomFloat() : this(BuiltinUtils.AllocNativeUObject(TsTaskRandomFloat.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003FDB RID: 16347 RVA: 0x00063CC0 File Offset: 0x00061EC0
	public TsTaskRandomFloat(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskRandomFloat.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003FDC RID: 16348 RVA: 0x00063CF3 File Offset: 0x00061EF3
	protected TsTaskRandomFloat(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003FDD RID: 16349 RVA: 0x00063D08 File Offset: 0x00061F08
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000E75 RID: 3701
	private bool IsInitTsVariables;

	// Token: 0x04000E76 RID: 3702
	private float TsMin;

	// Token: 0x04000E77 RID: 3703
	private float TsMax;

	// Token: 0x04000E78 RID: 3704
	private string TsBlackboardKeyWriteTo = "";

	// Token: 0x04000E79 RID: 3705
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomFloat.TsTaskRandomFloat_C";

	// Token: 0x04000E7A RID: 3706
	private static IntPtr _ClassPtr;

	// Token: 0x04000E7B RID: 3707
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E7C RID: 3708
	private static int __PropertyOffset_Min;

	// Token: 0x04000E7D RID: 3709
	private static int __PropertyOffset_Max;

	// Token: 0x04000E7E RID: 3710
	private static int __PropertyOffset_BlackboardKeyWriteTo;
}
