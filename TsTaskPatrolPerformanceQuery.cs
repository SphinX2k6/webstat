using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC4 RID: 3268
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrolPerformanceQuery.TsTaskPatrolPerformanceQuery_C")]
public class TsTaskPatrolPerformanceQuery : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06003F21 RID: 16161 RVA: 0x00060E38 File Offset: 0x0005F038
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

	// Token: 0x06003F22 RID: 16162 RVA: 0x00060ED4 File Offset: 0x0005F0D4
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.Finish(false);
			return;
		}
		AiController aiController = tsAiController.AiController;
		AiPatrolController aiPatrolController = (aiController != null) ? aiController.AiPatrol : null;
		if (aiPatrolController == null)
		{
			base.Finish(false);
			return;
		}
		Entity entity = tsAiController.AiController.CharActorComp.Entity;
		BaseAbilityComponent component = entity.GetComponent<BaseAbilityComponent>();
		BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
		if (component == null || component2 == null)
		{
			base.Finish(false);
			return;
		}
		component.ClearLastPerformanceTag();
		string nextPerformanceTag = aiPatrolController.GetNextPerformanceTag();
		if (nextPerformanceTag != null)
		{
			component.AddPerformanceTag(nextPerformanceTag);
		}
		else
		{
			int num = GameplayTagDefine.EGameplayTagId["怪物.common.关卡.开始表演"];
			if (component2.HasTag(num))
			{
				component2.RemoveTag(new int?(num));
			}
		}
		base.Finish(true);
	}

	// Token: 0x06003F23 RID: 16163 RVA: 0x00060FBC File Offset: 0x0005F1BC
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPatrolPerformanceQuery._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrolPerformanceQuery.TsTaskPatrolPerformanceQuery_C");
		}
		return TsTaskPatrolPerformanceQuery._ClassPtr;
	}

	// Token: 0x06003F24 RID: 16164 RVA: 0x00060FE0 File Offset: 0x0005F1E0
	public TsTaskPatrolPerformanceQuery() : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolPerformanceQuery.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003F25 RID: 16165 RVA: 0x00061008 File Offset: 0x0005F208
	[NullableContext(1)]
	public TsTaskPatrolPerformanceQuery(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolPerformanceQuery.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003F26 RID: 16166 RVA: 0x0006103B File Offset: 0x0005F23B
	protected TsTaskPatrolPerformanceQuery(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003F27 RID: 16167 RVA: 0x00061044 File Offset: 0x0005F244
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000DEE RID: 3566
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrolPerformanceQuery.TsTaskPatrolPerformanceQuery_C";

	// Token: 0x04000DEF RID: 3567
	private static IntPtr _ClassPtr;

	// Token: 0x04000DF0 RID: 3568
	private static IntPtr _ClassDefaultObjectPtr;
}
