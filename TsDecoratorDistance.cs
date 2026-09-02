using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C5A RID: 3162
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorDistance.TsDecoratorDistance_C")]
public class TsDecoratorDistance : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700013D RID: 317
	// (get) Token: 0x06003803 RID: 14339 RVA: 0x0003BD57 File Offset: 0x00039F57
	// (set) Token: 0x06003804 RID: 14340 RVA: 0x0003BD67 File Offset: 0x00039F67
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Distance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistance.__PropertyOffset_Distance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistance.__PropertyOffset_Distance) = value;
		}
	}

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x06003805 RID: 14341 RVA: 0x0003BD78 File Offset: 0x00039F78
	// (set) Token: 0x06003806 RID: 14342 RVA: 0x0003BD88 File Offset: 0x00039F88
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int CompareType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorDistance.__PropertyOffset_CompareType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorDistance.__PropertyOffset_CompareType) = value;
		}
	}

	// Token: 0x06003807 RID: 14343 RVA: 0x0003BD99 File Offset: 0x00039F99
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsDistance = this.Distance;
			this.TsCompareType = this.CompareType;
		}
	}

	// Token: 0x06003808 RID: 14344 RVA: 0x0003BDCC File Offset: 0x00039FCC
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

	// Token: 0x06003809 RID: 14345 RVA: 0x0003BE6C File Offset: 0x0003A06C
	[NullableContext(2)]
	protected unsafe virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		CreatureDataComponent creatureDataComponent = charActorComp.Entity.CheckGetComponent<CreatureDataComponent>();
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(creatureDataComponent.GetSummonerId());
		if (entityId != 0)
		{
			CharacterActorComponent characterActorComponentById = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityId);
			if (!characterActorComponentById)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.BehaviorTree;
				ELogAuthor author2 = ELogAuthor.LCZ;
				string message2 = "主人已经被销毁";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", (charActorComp != null) ? new int?(charActorComp.Entity.Id) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Self", charActorComp.Actor.GetName());
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			FVectorDouble actorLocation = characterActorComponentById.ActorLocation;
			FVectorDouble actorLocation2 = charActorComp.ActorLocation;
			double num = FVectorDouble.DistSquared(actorLocation, actorLocation2);
			switch (this.TsCompareType)
			{
			case 0:
				if (num == (double)(this.TsDistance * this.TsDistance))
				{
					return true;
				}
				break;
			case 1:
				if (num < (double)(this.TsDistance * this.TsDistance))
				{
					return true;
				}
				break;
			case 2:
				if (num > (double)(this.TsDistance * this.TsDistance))
				{
					return true;
				}
				break;
			}
		}
		return false;
	}

	// Token: 0x0600380A RID: 14346 RVA: 0x0003BFFE File Offset: 0x0003A1FE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorDistance._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorDistance.TsDecoratorDistance_C");
		}
		return TsDecoratorDistance._ClassPtr;
	}

	// Token: 0x0600380B RID: 14347 RVA: 0x0003C024 File Offset: 0x0003A224
	public TsDecoratorDistance() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDistance.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600380C RID: 14348 RVA: 0x0003C04C File Offset: 0x0003A24C
	[NullableContext(1)]
	public TsDecoratorDistance(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDistance.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600380D RID: 14349 RVA: 0x0003C07F File Offset: 0x0003A27F
	protected TsDecoratorDistance(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600380E RID: 14350 RVA: 0x0003C088 File Offset: 0x0003A288
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000822 RID: 2082
	private bool IsInitTsVariables;

	// Token: 0x04000823 RID: 2083
	private float TsDistance;

	// Token: 0x04000824 RID: 2084
	private int TsCompareType;

	// Token: 0x04000825 RID: 2085
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorDistance.TsDecoratorDistance_C";

	// Token: 0x04000826 RID: 2086
	private static IntPtr _ClassPtr;

	// Token: 0x04000827 RID: 2087
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000828 RID: 2088
	private static int __PropertyOffset_Distance;

	// Token: 0x04000829 RID: 2089
	private static int __PropertyOffset_CompareType;
}
