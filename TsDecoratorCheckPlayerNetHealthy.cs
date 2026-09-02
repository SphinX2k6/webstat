using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C55 RID: 3157
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckPlayerNetHealthy.TsDecoratorCheckPlayerNetHealthy_C")]
public class TsDecoratorCheckPlayerNetHealthy : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x060037CC RID: 14284 RVA: 0x0003B1C8 File Offset: 0x000393C8
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

	// Token: 0x060037CD RID: 14285 RVA: 0x0003B268 File Offset: 0x00039468
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
		int playerId = aiController.CharAiDesignComp.Entity.GetComponent<CreatureDataComponent>().GetPlayerId();
		return ControllerBase<OnlineController>.Instance.CheckPlayerNetHealthy(playerId);
	}

	// Token: 0x060037CE RID: 14286 RVA: 0x0003B2DA File Offset: 0x000394DA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckPlayerNetHealthy._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckPlayerNetHealthy.TsDecoratorCheckPlayerNetHealthy_C");
		}
		return TsDecoratorCheckPlayerNetHealthy._ClassPtr;
	}

	// Token: 0x060037CF RID: 14287 RVA: 0x0003B300 File Offset: 0x00039500
	public TsDecoratorCheckPlayerNetHealthy() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckPlayerNetHealthy.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060037D0 RID: 14288 RVA: 0x0003B328 File Offset: 0x00039528
	[NullableContext(1)]
	public TsDecoratorCheckPlayerNetHealthy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckPlayerNetHealthy.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060037D1 RID: 14289 RVA: 0x0003B35B File Offset: 0x0003955B
	protected TsDecoratorCheckPlayerNetHealthy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060037D2 RID: 14290 RVA: 0x0003B364 File Offset: 0x00039564
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000800 RID: 2048
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckPlayerNetHealthy.TsDecoratorCheckPlayerNetHealthy_C";

	// Token: 0x04000801 RID: 2049
	private static IntPtr _ClassPtr;

	// Token: 0x04000802 RID: 2050
	private static IntPtr _ClassDefaultObjectPtr;
}
