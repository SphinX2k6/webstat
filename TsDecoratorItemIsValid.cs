using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Util;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C62 RID: 3170
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorItemIsValid.TsDecoratorItemIsValid_C")]
public class TsDecoratorItemIsValid : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000145 RID: 325
	// (get) Token: 0x0600384F RID: 14415 RVA: 0x0003D103 File Offset: 0x0003B303
	// (set) Token: 0x06003850 RID: 14416 RVA: 0x0003D117 File Offset: 0x0003B317
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ItemBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorItemIsValid.__PropertyOffset_ItemBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorItemIsValid.__PropertyOffset_ItemBlackboardKey)), value);
		}
	}

	// Token: 0x06003851 RID: 14417 RVA: 0x0003D12C File Offset: 0x0003B32C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsItemBlackboardKey = this.ItemBlackboardKey;
		}
	}

	// Token: 0x06003852 RID: 14418 RVA: 0x0003D150 File Offset: 0x0003B350
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

	// Token: 0x06003853 RID: 14419 RVA: 0x0003D1F0 File Offset: 0x0003B3F0
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(charActorComp.Entity.Id, this.TsItemBlackboardKey);
		Entity entity = Singleton<EntitySystem>.Instance.Get(intValueByEntity.GetValueOrDefault());
		if (entity == null)
		{
			return false;
		}
		SceneItemAiInteractionComponent component = entity.GetComponent<SceneItemAiInteractionComponent>();
		return (component == null || !component.IsSearchByOther(charActorComp.Entity.Id)) && SceneItemUtility.GetBaseItemActor(entity) != null && entity.Active;
	}

	// Token: 0x06003854 RID: 14420 RVA: 0x0003D2B8 File Offset: 0x0003B4B8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorItemIsValid._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorItemIsValid.TsDecoratorItemIsValid_C");
		}
		return TsDecoratorItemIsValid._ClassPtr;
	}

	// Token: 0x06003855 RID: 14421 RVA: 0x0003D2DC File Offset: 0x0003B4DC
	public TsDecoratorItemIsValid() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorItemIsValid.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003856 RID: 14422 RVA: 0x0003D304 File Offset: 0x0003B504
	public TsDecoratorItemIsValid(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorItemIsValid.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003857 RID: 14423 RVA: 0x0003D337 File Offset: 0x0003B537
	protected TsDecoratorItemIsValid(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003858 RID: 14424 RVA: 0x0003D34C File Offset: 0x0003B54C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000850 RID: 2128
	private bool IsInitTsVariables;

	// Token: 0x04000851 RID: 2129
	private string TsItemBlackboardKey = "";

	// Token: 0x04000852 RID: 2130
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorItemIsValid.TsDecoratorItemIsValid_C";

	// Token: 0x04000853 RID: 2131
	private static IntPtr _ClassPtr;

	// Token: 0x04000854 RID: 2132
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000855 RID: 2133
	private static int __PropertyOffset_ItemBlackboardKey;
}
