using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C6A RID: 3178
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorTagCount.TsDecoratorTagCount_C")]
public class TsDecoratorTagCount : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000155 RID: 341
	// (get) Token: 0x060038AF RID: 14511 RVA: 0x0003E9E3 File Offset: 0x0003CBE3
	// (set) Token: 0x060038B0 RID: 14512 RVA: 0x0003E9F7 File Offset: 0x0003CBF7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyTarget
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorTagCount.__PropertyOffset_BlackboardKeyTarget)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorTagCount.__PropertyOffset_BlackboardKeyTarget)), value);
		}
	}

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x060038B1 RID: 14513 RVA: 0x0003EA0C File Offset: 0x0003CC0C
	// (set) Token: 0x060038B2 RID: 14514 RVA: 0x0003EA20 File Offset: 0x0003CC20
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorTagCount.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorTagCount.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x060038B3 RID: 14515 RVA: 0x0003EA35 File Offset: 0x0003CC35
	// (set) Token: 0x060038B4 RID: 14516 RVA: 0x0003EA49 File Offset: 0x0003CC49
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FFloatRange Range
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorTagCount.__PropertyOffset_Range);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorTagCount.__PropertyOffset_Range) = value;
		}
	}

	// Token: 0x060038B5 RID: 14517 RVA: 0x0003EA60 File Offset: 0x0003CC60
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKeyTarget = this.BlackboardKeyTarget;
			this.TsTag = new FGameplayTag?(this.Tag);
			this.TsRange = new FastUeFloatRange(this.Range);
		}
	}

	// Token: 0x060038B6 RID: 14518 RVA: 0x0003EAB4 File Offset: 0x0003CCB4
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

	// Token: 0x060038B7 RID: 14519 RVA: 0x0003EB54 File Offset: 0x0003CD54
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
		this.InitTsVariables();
		CharacterActorComponent characterActorComponent = aiController.CharActorComp;
		if (this.TsBlackboardKeyTarget != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyTarget);
			if (entityIdByEntity == null)
			{
				return false;
			}
			CharacterActorComponent characterActorComponentById = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityIdByEntity.Value);
			if (characterActorComponentById == null)
			{
				return false;
			}
			characterActorComponent = characterActorComponentById;
		}
		int tagCount = characterActorComponent.Entity.CheckGetComponent<BaseTagComponent>().GetTagCount(this.TsTag.Value.TagId());
		return Singleton<MathUtils>.Instance.InFastUeRange((double)tagCount, this.TsRange);
	}

	// Token: 0x060038B8 RID: 14520 RVA: 0x0003EC43 File Offset: 0x0003CE43
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorTagCount._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorTagCount.TsDecoratorTagCount_C");
		}
		return TsDecoratorTagCount._ClassPtr;
	}

	// Token: 0x060038B9 RID: 14521 RVA: 0x0003EC68 File Offset: 0x0003CE68
	public TsDecoratorTagCount() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTagCount.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060038BA RID: 14522 RVA: 0x0003EC90 File Offset: 0x0003CE90
	public TsDecoratorTagCount(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTagCount.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060038BB RID: 14523 RVA: 0x0003ECC3 File Offset: 0x0003CEC3
	protected TsDecoratorTagCount(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060038BC RID: 14524 RVA: 0x0003ECCC File Offset: 0x0003CECC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000890 RID: 2192
	private bool IsInitTsVariables;

	// Token: 0x04000891 RID: 2193
	private string TsBlackboardKeyTarget;

	// Token: 0x04000892 RID: 2194
	private FGameplayTag? TsTag;

	// Token: 0x04000893 RID: 2195
	[Nullable(2)]
	private FastUeFloatRange TsRange;

	// Token: 0x04000894 RID: 2196
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorTagCount.TsDecoratorTagCount_C";

	// Token: 0x04000895 RID: 2197
	private static IntPtr _ClassPtr;

	// Token: 0x04000896 RID: 2198
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000897 RID: 2199
	private static int __PropertyOffset_BlackboardKeyTarget;

	// Token: 0x04000898 RID: 2200
	private static int __PropertyOffset_Tag;

	// Token: 0x04000899 RID: 2201
	private static int __PropertyOffset_Range;
}
