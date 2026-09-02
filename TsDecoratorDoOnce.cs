using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C3C RID: 3132
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorDoOnce.TsDecoratorDoOnce_C")]
public class TsDecoratorDoOnce : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000FF RID: 255
	// (get) Token: 0x06003687 RID: 13959 RVA: 0x00035D83 File Offset: 0x00033F83
	// (set) Token: 0x06003688 RID: 13960 RVA: 0x00035D97 File Offset: 0x00033F97
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackBoardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorDoOnce.__PropertyOffset_BlackBoardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorDoOnce.__PropertyOffset_BlackBoardKey)), value);
		}
	}

	// Token: 0x06003689 RID: 13961 RVA: 0x00035DAC File Offset: 0x00033FAC
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

	// Token: 0x0600368A RID: 13962 RVA: 0x00035E4C File Offset: 0x0003404C
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Entity entity = (charActorComp != null) ? charActorComp.Entity : null;
		if (!entity)
		{
			return false;
		}
		if (this.HasDone)
		{
			return false;
		}
		this.HasDone = ControllerBase<BlackboardController>.Instance.GetBooleanValueByEntity(entity.Id, this.BlackBoardKey).GetValueOrDefault();
		if (this.HasDone)
		{
			return false;
		}
		this.HasDone = true;
		ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(entity.Id, this.BlackBoardKey, true);
		return true;
	}

	// Token: 0x0600368B RID: 13963 RVA: 0x00035F12 File Offset: 0x00034112
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorDoOnce._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorDoOnce.TsDecoratorDoOnce_C");
		}
		return TsDecoratorDoOnce._ClassPtr;
	}

	// Token: 0x0600368C RID: 13964 RVA: 0x00035F38 File Offset: 0x00034138
	public TsDecoratorDoOnce() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDoOnce.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600368D RID: 13965 RVA: 0x00035F60 File Offset: 0x00034160
	public TsDecoratorDoOnce(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDoOnce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600368E RID: 13966 RVA: 0x00035F93 File Offset: 0x00034193
	protected TsDecoratorDoOnce(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600368F RID: 13967 RVA: 0x00035F9C File Offset: 0x0003419C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000720 RID: 1824
	private bool HasDone;

	// Token: 0x04000721 RID: 1825
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorDoOnce.TsDecoratorDoOnce_C";

	// Token: 0x04000722 RID: 1826
	private static IntPtr _ClassPtr;

	// Token: 0x04000723 RID: 1827
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000724 RID: 1828
	private static int __PropertyOffset_BlackBoardKey;
}
