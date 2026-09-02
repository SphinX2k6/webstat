using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CBD RID: 3261
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskInteractTarget.TsTaskInteractTarget_C")]
public class TsTaskInteractTarget : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06003E59 RID: 15961 RVA: 0x0005D169 File Offset: 0x0005B369
	// (set) Token: 0x06003E5A RID: 15962 RVA: 0x0005D17D File Offset: 0x0005B37D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskInteractTarget.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskInteractTarget.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x06003E5B RID: 15963 RVA: 0x0005D192 File Offset: 0x0005B392
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
		}
	}

	// Token: 0x06003E5C RID: 15964 RVA: 0x0005D1B8 File Offset: 0x0005B3B8
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

	// Token: 0x06003E5D RID: 15965 RVA: 0x0005D254 File Offset: 0x0005B454
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		if (string.IsNullOrEmpty(this.TsBlackboardKey))
		{
			base.FinishExecute(false);
			return;
		}
		if (this.OnMontageEnded == null)
		{
			this.OnMontageEnded = delegate(UAnimMontage montage, bool interrupted)
			{
				this.EndTime = Singleton<Time>.Instance.WorldTime;
			};
		}
		this.EndTime = Singleton<Time>.Instance.WorldTime;
		int id = aiController.CharActorComp.Entity.Id;
		int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(id, this.TsBlackboardKey);
		if (entityIdByEntity == null)
		{
			base.FinishExecute(false);
			return;
		}
		AActor dynamicEntity = WorldFunctionLibrary.GetDynamicEntity(entityIdByEntity.Value);
		if (dynamicEntity == null)
		{
			base.FinishExecute(false);
			return;
		}
		this.AnimComp = aiController.CharActorComp.Entity.GetComponent<CharacterAnimationComponent>();
		this.ExecuteInteractTarget(dynamicEntity, aiController.CharActorComp);
	}

	// Token: 0x06003E5E RID: 15966 RVA: 0x0005D368 File Offset: 0x0005B568
	private void ExecuteInteractTarget(AActor actor, CharacterActorComponent self)
	{
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(actor, true);
		BaseActorComponent actorComponent = ControllerBase<CharacterController>.Instance.GetActorComponent(entityByActor);
		FVectorDouble location = actorComponent.ActorLocation;
		FRotator frotator = actorComponent.ActorRotation;
		InteractItemComponent component = entityByActor.Entity.GetComponent<InteractItemComponent>();
		if (component != null && component.IsInit)
		{
			FVectorDouble? interactPosition = component.GetInteractPosition();
			if (interactPosition != null)
			{
				location = interactPosition.Value;
			}
			FRotator? interactRotator = component.GetInteractRotator();
			if (interactRotator != null)
			{
				frotator = interactRotator.Value;
			}
			self.SetInputRotator(frotator);
			self.SetActorLocationAndRotation(location, frotator, "行为树节点.目标交互.强制切换目前", false, null);
		}
	}

	// Token: 0x06003E5F RID: 15967 RVA: 0x0005D404 File Offset: 0x0005B604
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

	// Token: 0x06003E60 RID: 15968 RVA: 0x0005D4A4 File Offset: 0x0005B6A4
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.EndTime < Singleton<Time>.Instance.WorldTime)
		{
			base.Finish(true);
		}
	}

	// Token: 0x06003E61 RID: 15969 RVA: 0x0005D4BF File Offset: 0x0005B6BF
	protected override void OnClear()
	{
		this.EndTime = 0.0;
		if (this.AnimComp != null)
		{
			this.AnimComp.MainAnimInstance.OnMontageEnded.Remove(this.OnMontageEnded);
			this.AnimComp = null;
		}
	}

	// Token: 0x06003E62 RID: 15970 RVA: 0x0005D4FA File Offset: 0x0005B6FA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskInteractTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskInteractTarget.TsTaskInteractTarget_C");
		}
		return TsTaskInteractTarget._ClassPtr;
	}

	// Token: 0x06003E63 RID: 15971 RVA: 0x0005D520 File Offset: 0x0005B720
	public TsTaskInteractTarget() : this(BuiltinUtils.AllocNativeUObject(TsTaskInteractTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003E64 RID: 15972 RVA: 0x0005D548 File Offset: 0x0005B748
	public TsTaskInteractTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskInteractTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003E65 RID: 15973 RVA: 0x0005D57B File Offset: 0x0005B77B
	protected TsTaskInteractTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003E66 RID: 15974 RVA: 0x0005D590 File Offset: 0x0005B790
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003E67 RID: 15975 RVA: 0x0005D5C0 File Offset: 0x0005B7C0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000D49 RID: 3401
	private bool IsInitTsVariables;

	// Token: 0x04000D4A RID: 3402
	private string TsBlackboardKey = "";

	// Token: 0x04000D4B RID: 3403
	private double EndTime;

	// Token: 0x04000D4C RID: 3404
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x04000D4D RID: 3405
	[Nullable(2)]
	private Action<UAnimMontage, bool> OnMontageEnded;

	// Token: 0x04000D4E RID: 3406
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskInteractTarget.TsTaskInteractTarget_C";

	// Token: 0x04000D4F RID: 3407
	private static IntPtr _ClassPtr;

	// Token: 0x04000D50 RID: 3408
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000D51 RID: 3409
	private static int __PropertyOffset_BlackboardKey;
}
