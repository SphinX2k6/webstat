using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C50 RID: 3152
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckFsmState.TsDecoratorCheckFsmState_C")]
public class TsDecoratorCheckFsmState : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000130 RID: 304
	// (get) Token: 0x06003793 RID: 14227 RVA: 0x0003A0E7 File Offset: 0x000382E7
	// (set) Token: 0x06003794 RID: 14228 RVA: 0x0003A0FB File Offset: 0x000382FB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string State
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorCheckFsmState.__PropertyOffset_State)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorCheckFsmState.__PropertyOffset_State)), value);
		}
	}

	// Token: 0x06003795 RID: 14229 RVA: 0x0003A110 File Offset: 0x00038310
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

	// Token: 0x06003796 RID: 14230 RVA: 0x0003A1B0 File Offset: 0x000383B0
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
		CharacterStateMachineNewComponent component = aiController.CharActorComp.Entity.GetComponent<CharacterStateMachineNewComponent>();
		AiStateMachineGroup aiStateMachineGroup = (component != null) ? component.StateMachineGroup : null;
		AiStateMachineBase aiStateMachineBase = (aiStateMachineGroup != null) ? aiStateMachineGroup.GetNodeByName(this.State) : null;
		return aiStateMachineBase != null && aiStateMachineBase.Activated;
	}

	// Token: 0x06003797 RID: 14231 RVA: 0x0003A23A File Offset: 0x0003843A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckFsmState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckFsmState.TsDecoratorCheckFsmState_C");
		}
		return TsDecoratorCheckFsmState._ClassPtr;
	}

	// Token: 0x06003798 RID: 14232 RVA: 0x0003A260 File Offset: 0x00038460
	public TsDecoratorCheckFsmState() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckFsmState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003799 RID: 14233 RVA: 0x0003A288 File Offset: 0x00038488
	public TsDecoratorCheckFsmState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckFsmState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600379A RID: 14234 RVA: 0x0003A2BB File Offset: 0x000384BB
	protected TsDecoratorCheckFsmState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600379B RID: 14235 RVA: 0x0003A2C4 File Offset: 0x000384C4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007DC RID: 2012
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckFsmState.TsDecoratorCheckFsmState_C";

	// Token: 0x040007DD RID: 2013
	private static IntPtr _ClassPtr;

	// Token: 0x040007DE RID: 2014
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007DF RID: 2015
	private static int __PropertyOffset_State;
}
