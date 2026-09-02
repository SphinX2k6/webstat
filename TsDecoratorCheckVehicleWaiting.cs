using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C3A RID: 3130
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckVehicleWaiting.TsDecoratorCheckVehicleWaiting_C")]
public class TsDecoratorCheckVehicleWaiting : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000F8 RID: 248
	// (get) Token: 0x06003669 RID: 13929 RVA: 0x000356AB File Offset: 0x000338AB
	// (set) Token: 0x0600366A RID: 13930 RVA: 0x000356BB File Offset: 0x000338BB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float VehicleWaitState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckVehicleWaiting.__PropertyOffset_VehicleWaitState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckVehicleWaiting.__PropertyOffset_VehicleWaitState) = value;
		}
	}

	// Token: 0x0600366B RID: 13931 RVA: 0x000356CC File Offset: 0x000338CC
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

	// Token: 0x0600366C RID: 13932 RVA: 0x0003576C File Offset: 0x0003396C
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (this.VehicleWaitState != 0f && this.VehicleWaitState != 1f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的VehicleWaitState值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Value", this.VehicleWaitState);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		AiController aiController = (ownerController as TsAiController).AiController;
		if (aiController == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "错误的Controller类型";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			return false;
		}
		int id = charActorComp.Entity.Id;
		return ControllerBase<NpcVehicleRiderController>.Instance.GetVehicleIsWaitingNpc(id, (int)this.VehicleWaitState);
	}

	// Token: 0x0600366D RID: 13933 RVA: 0x00035836 File Offset: 0x00033A36
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckVehicleWaiting._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckVehicleWaiting.TsDecoratorCheckVehicleWaiting_C");
		}
		return TsDecoratorCheckVehicleWaiting._ClassPtr;
	}

	// Token: 0x0600366E RID: 13934 RVA: 0x0003585C File Offset: 0x00033A5C
	public TsDecoratorCheckVehicleWaiting() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckVehicleWaiting.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600366F RID: 13935 RVA: 0x00035884 File Offset: 0x00033A84
	[NullableContext(1)]
	public TsDecoratorCheckVehicleWaiting(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckVehicleWaiting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003670 RID: 13936 RVA: 0x000358B7 File Offset: 0x00033AB7
	protected TsDecoratorCheckVehicleWaiting(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003671 RID: 13937 RVA: 0x000358C0 File Offset: 0x00033AC0
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000708 RID: 1800
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckVehicleWaiting.TsDecoratorCheckVehicleWaiting_C";

	// Token: 0x04000709 RID: 1801
	private static IntPtr _ClassPtr;

	// Token: 0x0400070A RID: 1802
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400070B RID: 1803
	private static int __PropertyOffset_VehicleWaitState;
}
