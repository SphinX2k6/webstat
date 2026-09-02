using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C32 RID: 3122
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckHasRideableVehicle.TsDecoratorCheckHasRideableVehicle_C")]
public class TsDecoratorCheckHasRideableVehicle : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000F6 RID: 246
	// (get) Token: 0x0600362C RID: 13868 RVA: 0x000346E3 File Offset: 0x000328E3
	// (set) Token: 0x0600362D RID: 13869 RVA: 0x000346F3 File Offset: 0x000328F3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SearchRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckHasRideableVehicle.__PropertyOffset_SearchRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckHasRideableVehicle.__PropertyOffset_SearchRange) = value;
		}
	}

	// Token: 0x0600362E RID: 13870 RVA: 0x00034704 File Offset: 0x00032904
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

	// Token: 0x0600362F RID: 13871 RVA: 0x000347A4 File Offset: 0x000329A4
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		AiController aiController = (ownerController as TsAiController).AiController;
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
		if (charActorComp == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "Controller缺少CharActorComp";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ControllerType", ownerController.GetClass().GetName());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		Entity entity = charActorComp.Entity;
		if (entity == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "CharActorComp缺少Entity";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("ControllerType", ownerController.GetClass().GetName());
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		int? nearestFreeVehicleInRange = ControllerBase<NpcVehicleRiderController>.Instance.GetNearestFreeVehicleInRange(entity.Id, this.SearchRange);
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "SearchedRideableVehicleEntityId", nearestFreeVehicleInRange.GetValueOrDefault(-1));
		return nearestFreeVehicleInRange != null;
	}

	// Token: 0x06003630 RID: 13872 RVA: 0x000348B4 File Offset: 0x00032AB4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckHasRideableVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckHasRideableVehicle.TsDecoratorCheckHasRideableVehicle_C");
		}
		return TsDecoratorCheckHasRideableVehicle._ClassPtr;
	}

	// Token: 0x06003631 RID: 13873 RVA: 0x000348D8 File Offset: 0x00032AD8
	public TsDecoratorCheckHasRideableVehicle() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckHasRideableVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003632 RID: 13874 RVA: 0x00034900 File Offset: 0x00032B00
	[NullableContext(1)]
	public TsDecoratorCheckHasRideableVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckHasRideableVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003633 RID: 13875 RVA: 0x00034933 File Offset: 0x00032B33
	protected TsDecoratorCheckHasRideableVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003634 RID: 13876 RVA: 0x0003493C File Offset: 0x00032B3C
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040006EC RID: 1772
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckHasRideableVehicle.TsDecoratorCheckHasRideableVehicle_C";

	// Token: 0x040006ED RID: 1773
	private static IntPtr _ClassPtr;

	// Token: 0x040006EE RID: 1774
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040006EF RID: 1775
	private static int __PropertyOffset_SearchRange;
}
