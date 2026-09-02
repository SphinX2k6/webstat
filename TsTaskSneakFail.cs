using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD9 RID: 3289
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSneakFail.TsTaskSneakFail_C")]
public class TsTaskSneakFail : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x060040A9 RID: 16553 RVA: 0x00067E10 File Offset: 0x00066010
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

	// Token: 0x060040AA RID: 16554 RVA: 0x00067EAC File Offset: 0x000660AC
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (((tsAiController != null) ? tsAiController.AiController : null) == null)
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
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(controlledPawn, true);
		if (entityByActor != null)
		{
			WorldEntity entity = entityByActor.Entity;
			if (entity != null)
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				if (component != null)
				{
					TagContainer tagContainer = component.TagContainer;
					if (tagContainer != null)
					{
						tagContainer.UpdateExactTag(ETagChannel.LevelServer, GameplayTagDefine.EGameplayTagId["怪物.common.躲猫猫计数器"], 0);
					}
				}
			}
		}
		base.FinishExecute(true);
	}

	// Token: 0x060040AB RID: 16555 RVA: 0x00067F53 File Offset: 0x00066153
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSneakFail._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSneakFail.TsTaskSneakFail_C");
		}
		return TsTaskSneakFail._ClassPtr;
	}

	// Token: 0x060040AC RID: 16556 RVA: 0x00067F78 File Offset: 0x00066178
	public TsTaskSneakFail() : this(BuiltinUtils.AllocNativeUObject(TsTaskSneakFail.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060040AD RID: 16557 RVA: 0x00067FA0 File Offset: 0x000661A0
	[NullableContext(1)]
	public TsTaskSneakFail(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSneakFail.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060040AE RID: 16558 RVA: 0x00067FD3 File Offset: 0x000661D3
	protected TsTaskSneakFail(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060040AF RID: 16559 RVA: 0x00067FDC File Offset: 0x000661DC
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000F38 RID: 3896
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSneakFail.TsTaskSneakFail_C";

	// Token: 0x04000F39 RID: 3897
	private static IntPtr _ClassPtr;

	// Token: 0x04000F3A RID: 3898
	private static IntPtr _ClassDefaultObjectPtr;
}
