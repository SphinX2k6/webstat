using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C33 RID: 3123
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckNpcArrivedRideLocation.TsDecoratorCheckNpcArrivedRideLocation_C")]
public class TsDecoratorCheckNpcArrivedRideLocation : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000F7 RID: 247
	// (get) Token: 0x06003635 RID: 13877 RVA: 0x0003496F File Offset: 0x00032B6F
	// (set) Token: 0x06003636 RID: 13878 RVA: 0x0003497F File Offset: 0x00032B7F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Tolerance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckNpcArrivedRideLocation.__PropertyOffset_Tolerance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckNpcArrivedRideLocation.__PropertyOffset_Tolerance) = value;
		}
	}

	// Token: 0x06003637 RID: 13879 RVA: 0x00034990 File Offset: 0x00032B90
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTolerance = this.Tolerance;
		}
	}

	// Token: 0x06003638 RID: 13880 RVA: 0x000349B4 File Offset: 0x00032BB4
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

	// Token: 0x06003639 RID: 13881 RVA: 0x00034A54 File Offset: 0x00032C54
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
			return false;
		}
		this.InitTsVariables();
		int id = charActorComp.Entity.Id;
		int? ridingVehicle = ControllerBase<NpcVehicleRiderController>.Instance.GetRidingVehicle(id);
		return ridingVehicle != null && ControllerBase<NpcVehicleRiderController>.Instance.IsNpcAtVehicleRideLocation(id, ridingVehicle.Value, this.TsTolerance);
	}

	// Token: 0x0600363A RID: 13882 RVA: 0x00034AF4 File Offset: 0x00032CF4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckNpcArrivedRideLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckNpcArrivedRideLocation.TsDecoratorCheckNpcArrivedRideLocation_C");
		}
		return TsDecoratorCheckNpcArrivedRideLocation._ClassPtr;
	}

	// Token: 0x0600363B RID: 13883 RVA: 0x00034B18 File Offset: 0x00032D18
	public TsDecoratorCheckNpcArrivedRideLocation() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckNpcArrivedRideLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600363C RID: 13884 RVA: 0x00034B40 File Offset: 0x00032D40
	[NullableContext(1)]
	public TsDecoratorCheckNpcArrivedRideLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckNpcArrivedRideLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600363D RID: 13885 RVA: 0x00034B73 File Offset: 0x00032D73
	protected TsDecoratorCheckNpcArrivedRideLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600363E RID: 13886 RVA: 0x00034B7C File Offset: 0x00032D7C
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040006F0 RID: 1776
	private bool IsInitTsVariables;

	// Token: 0x040006F1 RID: 1777
	private float TsTolerance;

	// Token: 0x040006F2 RID: 1778
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorCheckNpcArrivedRideLocation.TsDecoratorCheckNpcArrivedRideLocation_C";

	// Token: 0x040006F3 RID: 1779
	private static IntPtr _ClassPtr;

	// Token: 0x040006F4 RID: 1780
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040006F5 RID: 1781
	private static int __PropertyOffset_Tolerance;
}
