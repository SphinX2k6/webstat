using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C68 RID: 3176
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorSightReachTarget.TsDecoratorSightReachTarget_C")]
public class TsDecoratorSightReachTarget : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000150 RID: 336
	// (get) Token: 0x06003896 RID: 14486 RVA: 0x0003E127 File Offset: 0x0003C327
	// (set) Token: 0x06003897 RID: 14487 RVA: 0x0003E137 File Offset: 0x0003C337
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ToleranceDegree
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorSightReachTarget.__PropertyOffset_ToleranceDegree);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorSightReachTarget.__PropertyOffset_ToleranceDegree) = value;
		}
	}

	// Token: 0x06003898 RID: 14488 RVA: 0x0003E148 File Offset: 0x0003C348
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

	// Token: 0x06003899 RID: 14489 RVA: 0x0003E1E8 File Offset: 0x0003C3E8
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			return false;
		}
		CharacterAnimationComponent component = charActorComp.Entity.GetComponent<CharacterAnimationComponent>();
		return component != null && component.Valid && component.IsSightDirectReachTarget(this.ToleranceDegree);
	}

	// Token: 0x0600389A RID: 14490 RVA: 0x0003E287 File Offset: 0x0003C487
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorSightReachTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorSightReachTarget.TsDecoratorSightReachTarget_C");
		}
		return TsDecoratorSightReachTarget._ClassPtr;
	}

	// Token: 0x0600389B RID: 14491 RVA: 0x0003E2AC File Offset: 0x0003C4AC
	public TsDecoratorSightReachTarget() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorSightReachTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600389C RID: 14492 RVA: 0x0003E2D4 File Offset: 0x0003C4D4
	[NullableContext(1)]
	public TsDecoratorSightReachTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorSightReachTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600389D RID: 14493 RVA: 0x0003E307 File Offset: 0x0003C507
	protected TsDecoratorSightReachTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600389E RID: 14494 RVA: 0x0003E310 File Offset: 0x0003C510
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400087E RID: 2174
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorSightReachTarget.TsDecoratorSightReachTarget_C";

	// Token: 0x0400087F RID: 2175
	private static IntPtr _ClassPtr;

	// Token: 0x04000880 RID: 2176
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000881 RID: 2177
	private static int __PropertyOffset_ToleranceDegree;
}
