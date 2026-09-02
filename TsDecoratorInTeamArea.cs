using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C60 RID: 3168
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorInTeamArea.TsDecoratorInTeamArea_C")]
public class TsDecoratorInTeamArea : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06003841 RID: 14401 RVA: 0x0003CD10 File Offset: 0x0003AF10
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool PerformConditionCheckAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PerformConditionCheckAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06003842 RID: 14402 RVA: 0x0003CDB0 File Offset: 0x0003AFB0
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		AiController aiController = (ownerController as TsAiController).AiController;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		if (currentTarget == null || !currentTarget.Valid)
		{
			return true;
		}
		if (currentTarget.Entity.GetComponent<CharacterActorComponent>() == null)
		{
			return true;
		}
		int id = aiController.CharAiDesignComp.Entity.Id;
		if (this.TmpVector == null)
		{
			this.TmpVector = Vector.Create();
		}
		this.TmpVector.FromUeVector(ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(id, "TeamTargetLocation"));
		AiAreaMemberData aiTeamAreaMemberData = aiController.AiTeam.GetAiTeamAreaMemberData(aiController);
		return aiTeamAreaMemberData == null || AiControllerLibrary.InTeamArea(aiController, aiTeamAreaMemberData, 1f);
	}

	// Token: 0x06003843 RID: 14403 RVA: 0x0003CE8D File Offset: 0x0003B08D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorInTeamArea._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorInTeamArea.TsDecoratorInTeamArea_C");
		}
		return TsDecoratorInTeamArea._ClassPtr;
	}

	// Token: 0x06003844 RID: 14404 RVA: 0x0003CEB4 File Offset: 0x0003B0B4
	public TsDecoratorInTeamArea() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorInTeamArea.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003845 RID: 14405 RVA: 0x0003CEDC File Offset: 0x0003B0DC
	[NullableContext(1)]
	public TsDecoratorInTeamArea(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorInTeamArea.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003846 RID: 14406 RVA: 0x0003CF0F File Offset: 0x0003B10F
	protected TsDecoratorInTeamArea(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003847 RID: 14407 RVA: 0x0003CF18 File Offset: 0x0003B118
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000849 RID: 2121
	[Nullable(2)]
	private Vector TmpVector;

	// Token: 0x0400084A RID: 2122
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorInTeamArea.TsDecoratorInTeamArea_C";

	// Token: 0x0400084B RID: 2123
	private static IntPtr _ClassPtr;

	// Token: 0x0400084C RID: 2124
	private static IntPtr _ClassDefaultObjectPtr;
}
