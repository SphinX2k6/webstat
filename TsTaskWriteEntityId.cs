using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE8 RID: 3304
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWriteEntityId.TsTaskWriteEntityId_C")]
public class TsTaskWriteEntityId : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000311 RID: 785
	// (get) Token: 0x060041AF RID: 16815 RVA: 0x0006D637 File Offset: 0x0006B837
	// (set) Token: 0x060041B0 RID: 16816 RVA: 0x0006D64B File Offset: 0x0006B84B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyTarget
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskWriteEntityId.__PropertyOffset_BlackboardKeyTarget)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskWriteEntityId.__PropertyOffset_BlackboardKeyTarget)), value);
		}
	}

	// Token: 0x17000312 RID: 786
	// (get) Token: 0x060041B1 RID: 16817 RVA: 0x0006D660 File Offset: 0x0006B860
	// (set) Token: 0x060041B2 RID: 16818 RVA: 0x0006D674 File Offset: 0x0006B874
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyWriteTo
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskWriteEntityId.__PropertyOffset_BlackboardKeyWriteTo)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskWriteEntityId.__PropertyOffset_BlackboardKeyWriteTo)), value);
		}
	}

	// Token: 0x060041B3 RID: 16819 RVA: 0x0006D689 File Offset: 0x0006B889
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKeyTarget = this.BlackboardKeyTarget;
			this.TsBlackboardKeyWriteTo = this.BlackboardKeyWriteTo;
		}
	}

	// Token: 0x060041B4 RID: 16820 RVA: 0x0006D6BC File Offset: 0x0006B8BC
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

	// Token: 0x060041B5 RID: 16821 RVA: 0x0006D75C File Offset: 0x0006B95C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
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
		this.InitTsVariables();
		if (this.TsBlackboardKeyTarget == "")
		{
			base.FinishExecute(false);
			return;
		}
		int num = 0;
		if (this.TsBlackboardKeyTarget != "")
		{
			num = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyTarget).GetValueOrDefault();
			if (num == 0)
			{
				base.FinishExecute(false);
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(num);
			object obj;
			if (entityById == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = entityById.Entity;
				if (entity == null)
				{
					obj = null;
				}
				else
				{
					BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
					obj = ((component != null) ? component.Owner : null);
				}
			}
			if (!(obj is TsBaseCharacter))
			{
				base.FinishExecute(false);
				return;
			}
		}
		ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(num, this.TsBlackboardKeyWriteTo, aiController.CharAiDesignComp.Entity.Id);
		base.FinishExecute(true);
	}

	// Token: 0x060041B6 RID: 16822 RVA: 0x0006D889 File Offset: 0x0006BA89
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskWriteEntityId._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWriteEntityId.TsTaskWriteEntityId_C");
		}
		return TsTaskWriteEntityId._ClassPtr;
	}

	// Token: 0x060041B7 RID: 16823 RVA: 0x0006D8B0 File Offset: 0x0006BAB0
	public TsTaskWriteEntityId() : this(BuiltinUtils.AllocNativeUObject(TsTaskWriteEntityId.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060041B8 RID: 16824 RVA: 0x0006D8D8 File Offset: 0x0006BAD8
	public TsTaskWriteEntityId(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskWriteEntityId.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060041B9 RID: 16825 RVA: 0x0006D90B File Offset: 0x0006BB0B
	protected TsTaskWriteEntityId(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060041BA RID: 16826 RVA: 0x0006D92C File Offset: 0x0006BB2C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04001013 RID: 4115
	private bool IsInitTsVariables;

	// Token: 0x04001014 RID: 4116
	private string TsBlackboardKeyTarget = "";

	// Token: 0x04001015 RID: 4117
	private string TsBlackboardKeyWriteTo = "";

	// Token: 0x04001016 RID: 4118
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskWriteEntityId.TsTaskWriteEntityId_C";

	// Token: 0x04001017 RID: 4119
	private static IntPtr _ClassPtr;

	// Token: 0x04001018 RID: 4120
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001019 RID: 4121
	private static int __PropertyOffset_BlackboardKeyTarget;

	// Token: 0x0400101A RID: 4122
	private static int __PropertyOffset_BlackboardKeyWriteTo;
}
