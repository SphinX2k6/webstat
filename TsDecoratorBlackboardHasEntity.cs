using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.World.Controller;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C4A RID: 3146
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardHasEntity.TsDecoratorBlackboardHasEntity_C")]
public class TsDecoratorBlackboardHasEntity : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000122 RID: 290
	// (get) Token: 0x06003749 RID: 14153 RVA: 0x00038EAB File Offset: 0x000370AB
	// (set) Token: 0x0600374A RID: 14154 RVA: 0x00038EBF File Offset: 0x000370BF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardHasEntity.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardHasEntity.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x17000123 RID: 291
	// (get) Token: 0x0600374B RID: 14155 RVA: 0x00038ED4 File Offset: 0x000370D4
	// (set) Token: 0x0600374C RID: 14156 RVA: 0x00038EE4 File Offset: 0x000370E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardHasEntity.__PropertyOffset_CompareValue) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardHasEntity.__PropertyOffset_CompareValue) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600374D RID: 14157 RVA: 0x00038EF5 File Offset: 0x000370F5
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TsCompareValue = this.CompareValue;
		}
	}

	// Token: 0x0600374E RID: 14158 RVA: 0x00038F28 File Offset: 0x00037128
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

	// Token: 0x0600374F RID: 14159 RVA: 0x00038FC8 File Offset: 0x000371C8
	[NullableContext(2)]
	protected unsafe virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		AiController aiController = (ownerController as TsAiController).AiController;
		bool flag = ControllerBase<ServerGmController>.Instance.AnimalDebug && this.BlackboardKey == "NearerPlayerId";
		if (flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "AnimalDebug BlackboardHasEntity";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Tree", base.TreeAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("aiController", aiController != null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("aiComp", !(!((aiController != null) ? aiController.CharAiDesignComp : null)));
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item = "SelfId";
			int? num;
			if (aiController == null)
			{
				num = null;
			}
			else
			{
				CharacterActorComponent charActorComp = aiController.CharActorComp;
				num = ((charActorComp != null) ? new int?(charActorComp.Entity.Id) : null);
			}
			ptr = new ValueTuple<string, object>(item, num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		if (aiController == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
		if (charAiDesignComp == null)
		{
			return false;
		}
		this.InitTsVariables();
		if (this.TsBlackboardKey != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(charAiDesignComp.Entity.Id, this.TsBlackboardKey);
			if (flag)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.AI;
				ELogAuthor author3 = ELogAuthor.LCZ;
				string message3 = "AnimalDebug BlackboardHasEntity2";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("value", entityIdByEntity);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				if (entityIdByEntity != null)
				{
					CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityIdByEntity.Value);
					EEntityType? eentityType = (component != null) ? new EEntityType?(component.CreatureData.GetEntityType()) : null;
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.AI;
					ELogAuthor author4 = ELogAuthor.LCZ;
					string message4 = "AnimalDebug BlackboardHasEntity3";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entityType", eentityType);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item2 = "Player";
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					ptr2 = new ValueTuple<string, object>(item2, (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null);
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2);
					string item3 = "MainAnims";
					CharacterAnimationComponent component2 = charAiDesignComp.Entity.GetComponent<CharacterAnimationComponent>();
					object item4;
					if (component2 == null)
					{
						item4 = null;
					}
					else
					{
						UAnimInstance mainAnimInstance = component2.MainAnimInstance;
						item4 = ((mainAnimInstance != null) ? mainAnimInstance.GetMainAnimsDebugText() : null);
					}
					ptr3 = new ValueTuple<string, object>(item3, item4);
					instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
			}
			if (entityIdByEntity != null && Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value) != null)
			{
				return this.TsCompareValue;
			}
		}
		return !this.TsCompareValue;
	}

	// Token: 0x06003750 RID: 14160 RVA: 0x000392B4 File Offset: 0x000374B4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboardHasEntity._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardHasEntity.TsDecoratorBlackboardHasEntity_C");
		}
		return TsDecoratorBlackboardHasEntity._ClassPtr;
	}

	// Token: 0x06003751 RID: 14161 RVA: 0x000392D8 File Offset: 0x000374D8
	public TsDecoratorBlackboardHasEntity() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardHasEntity.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003752 RID: 14162 RVA: 0x00039300 File Offset: 0x00037500
	public TsDecoratorBlackboardHasEntity(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardHasEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003753 RID: 14163 RVA: 0x00039333 File Offset: 0x00037533
	protected TsDecoratorBlackboardHasEntity(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003754 RID: 14164 RVA: 0x00039348 File Offset: 0x00037548
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007AA RID: 1962
	private bool IsInitTsVariables;

	// Token: 0x040007AB RID: 1963
	private string TsBlackboardKey = "";

	// Token: 0x040007AC RID: 1964
	private bool TsCompareValue;

	// Token: 0x040007AD RID: 1965
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardHasEntity.TsDecoratorBlackboardHasEntity_C";

	// Token: 0x040007AE RID: 1966
	private static IntPtr _ClassPtr;

	// Token: 0x040007AF RID: 1967
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007B0 RID: 1968
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x040007B1 RID: 1969
	private static int __PropertyOffset_CompareValue;
}
