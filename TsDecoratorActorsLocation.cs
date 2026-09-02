using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C45 RID: 3141
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorActorsLocation.TsDecoratorActorsLocation_C")]
public class TsDecoratorActorsLocation : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000113 RID: 275
	// (get) Token: 0x06003703 RID: 14083 RVA: 0x00037BD7 File Offset: 0x00035DD7
	// (set) Token: 0x06003704 RID: 14084 RVA: 0x00037BEB File Offset: 0x00035DEB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string KeyActorA
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorActorsLocation.__PropertyOffset_KeyActorA)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorActorsLocation.__PropertyOffset_KeyActorA)), value);
		}
	}

	// Token: 0x17000114 RID: 276
	// (get) Token: 0x06003705 RID: 14085 RVA: 0x00037C00 File Offset: 0x00035E00
	// (set) Token: 0x06003706 RID: 14086 RVA: 0x00037C14 File Offset: 0x00035E14
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string KeyActorB
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorActorsLocation.__PropertyOffset_KeyActorB)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorActorsLocation.__PropertyOffset_KeyActorB)), value);
		}
	}

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x06003707 RID: 14087 RVA: 0x00037C29 File Offset: 0x00035E29
	// (set) Token: 0x06003708 RID: 14088 RVA: 0x00037C3D File Offset: 0x00035E3D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FFloatRange DistanceRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorActorsLocation.__PropertyOffset_DistanceRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorActorsLocation.__PropertyOffset_DistanceRange) = value;
		}
	}

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x06003709 RID: 14089 RVA: 0x00037C52 File Offset: 0x00035E52
	// (set) Token: 0x0600370A RID: 14090 RVA: 0x00037C66 File Offset: 0x00035E66
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FFloatRange AngleRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorActorsLocation.__PropertyOffset_AngleRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorActorsLocation.__PropertyOffset_AngleRange) = value;
		}
	}

	// Token: 0x17000117 RID: 279
	// (get) Token: 0x0600370B RID: 14091 RVA: 0x00037C7B File Offset: 0x00035E7B
	// (set) Token: 0x0600370C RID: 14092 RVA: 0x00037C8F File Offset: 0x00035E8F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FFloatRange HeightRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorActorsLocation.__PropertyOffset_HeightRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorActorsLocation.__PropertyOffset_HeightRange) = value;
		}
	}

	// Token: 0x0600370D RID: 14093 RVA: 0x00037CA4 File Offset: 0x00035EA4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsKeyActorA = this.KeyActorA;
			this.TsKeyActorB = this.KeyActorB;
			this.TsDistanceRange = new FastUeFloatRange(this.DistanceRange);
			this.TsAngleRange = new FastUeFloatRange(this.AngleRange);
			this.TsHeightRange = new FastUeFloatRange(this.HeightRange);
		}
	}

	// Token: 0x0600370E RID: 14094 RVA: 0x00037D14 File Offset: 0x00035F14
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

	// Token: 0x0600370F RID: 14095 RVA: 0x00037DB4 File Offset: 0x00035FB4
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
		int id = charActorComp.Entity.Id;
		CharacterActorComponent characterActorComponent = charActorComp;
		if (!string.IsNullOrEmpty(this.TsKeyActorA))
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(id, this.TsKeyActorA);
			if (entityIdByEntity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.BehaviorTree;
				ELogAuthor author2 = ELogAuthor.LCZ;
				string message2 = "不存在BlackboardKey";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", this.TsKeyActorA);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AI", (ownerController != null) ? ownerController.GetName() : null);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			CharacterActorComponent characterActorComponentById = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(entityIdByEntity.Value);
			if (characterActorComponentById == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.BehaviorTree;
				ELogAuthor author3 = ELogAuthor.LCZ;
				string message3 = "不存在Entity";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", entityIdByEntity);
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			characterActorComponent = characterActorComponentById;
		}
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		BaseCharacterComponent baseCharacterComponent;
		if (currentTarget == null)
		{
			baseCharacterComponent = null;
		}
		else
		{
			WorldEntity entity = currentTarget.Entity;
			baseCharacterComponent = ((entity != null) ? entity.GetComponent<BaseCharacterComponent>() : null);
		}
		BaseCharacterComponent baseCharacterComponent2 = baseCharacterComponent;
		if (this.TsKeyActorB == "_currentPlayer")
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			BaseCharacterComponent baseCharacterComponent3;
			if (baseCharacter == null)
			{
				baseCharacterComponent3 = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent2 = baseCharacter.CharacterActorComponent;
				if (characterActorComponent2 == null)
				{
					baseCharacterComponent3 = null;
				}
				else
				{
					Entity entity2 = characterActorComponent2.Entity;
					baseCharacterComponent3 = ((entity2 != null) ? entity2.GetComponent<BaseCharacterComponent>() : null);
				}
			}
			BaseCharacterComponent baseCharacterComponent4 = baseCharacterComponent3;
			if (baseCharacterComponent4 == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.BehaviorTree, ELogAuthor.LCZ, "不存在玩家", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			baseCharacterComponent2 = baseCharacterComponent4;
		}
		else if (!string.IsNullOrEmpty(this.TsKeyActorB))
		{
			int? entityIdByEntity2 = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(id, this.TsKeyActorB);
			if (entityIdByEntity2 == null)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.BehaviorTree;
				ELogAuthor author4 = ELogAuthor.LCZ;
				string message4 = "不存在BlackboardKey";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Key", this.TsKeyActorB);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("AI", (ownerController != null) ? ownerController.GetName() : null);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			BaseCharacterComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseCharacterComponent>(entityIdByEntity2.Value);
			if (component == null)
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.BehaviorTree;
				ELogAuthor author5 = ELogAuthor.LCZ;
				string message5 = "不存在Entity";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Id", entityIdByEntity2);
				instance5.Warn(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return false;
			}
			baseCharacterComponent2 = component;
		}
		if (baseCharacterComponent2 == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent3 = baseCharacterComponent2 as CharacterActorComponent;
		Vector location;
		if (characterActorComponent3 != null)
		{
			location = characterActorComponent3.FloorLocation;
		}
		else
		{
			location = baseCharacterComponent2.ActorLocationProxy;
		}
		return Singleton<MathUtils>.Instance.LocationInFastUeRange(characterActorComponent.FloorLocation, characterActorComponent.ActorRotationProxy, location, (double)(characterActorComponent.ScaledRadius + baseCharacterComponent2.ScaledRadius), this.TsDistanceRange, this.TsAngleRange, this.TsHeightRange);
	}

	// Token: 0x06003710 RID: 14096 RVA: 0x000380B9 File Offset: 0x000362B9
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorActorsLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorActorsLocation.TsDecoratorActorsLocation_C");
		}
		return TsDecoratorActorsLocation._ClassPtr;
	}

	// Token: 0x06003711 RID: 14097 RVA: 0x000380E0 File Offset: 0x000362E0
	public TsDecoratorActorsLocation() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorActorsLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003712 RID: 14098 RVA: 0x00038108 File Offset: 0x00036308
	public TsDecoratorActorsLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorActorsLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003713 RID: 14099 RVA: 0x0003813B File Offset: 0x0003633B
	protected TsDecoratorActorsLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003714 RID: 14100 RVA: 0x0003815C File Offset: 0x0003635C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000774 RID: 1908
	private const string CURRENT_PLAYER = "_currentPlayer";

	// Token: 0x04000775 RID: 1909
	private bool IsInitTsVariables;

	// Token: 0x04000776 RID: 1910
	private string TsKeyActorA = "";

	// Token: 0x04000777 RID: 1911
	private string TsKeyActorB = "";

	// Token: 0x04000778 RID: 1912
	[Nullable(2)]
	private FastUeFloatRange TsDistanceRange;

	// Token: 0x04000779 RID: 1913
	[Nullable(2)]
	private FastUeFloatRange TsAngleRange;

	// Token: 0x0400077A RID: 1914
	[Nullable(2)]
	private FastUeFloatRange TsHeightRange;

	// Token: 0x0400077B RID: 1915
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorActorsLocation.TsDecoratorActorsLocation_C";

	// Token: 0x0400077C RID: 1916
	private static IntPtr _ClassPtr;

	// Token: 0x0400077D RID: 1917
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400077E RID: 1918
	private static int __PropertyOffset_KeyActorA;

	// Token: 0x0400077F RID: 1919
	private static int __PropertyOffset_KeyActorB;

	// Token: 0x04000780 RID: 1920
	private static int __PropertyOffset_DistanceRange;

	// Token: 0x04000781 RID: 1921
	private static int __PropertyOffset_AngleRange;

	// Token: 0x04000782 RID: 1922
	private static int __PropertyOffset_HeightRange;
}
