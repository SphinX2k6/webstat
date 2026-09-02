using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA6 RID: 3238
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskCalculateBackwardPosition.TsTaskCalculateBackwardPosition_C")]
public class TsTaskCalculateBackwardPosition : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001F8 RID: 504
	// (get) Token: 0x06003CAF RID: 15535 RVA: 0x00053F4D File Offset: 0x0005214D
	// (set) Token: 0x06003CB0 RID: 15536 RVA: 0x00053F5D File Offset: 0x0005215D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Distance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskCalculateBackwardPosition.__PropertyOffset_Distance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCalculateBackwardPosition.__PropertyOffset_Distance) = value;
		}
	}

	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x06003CB1 RID: 15537 RVA: 0x00053F6E File Offset: 0x0005216E
	// (set) Token: 0x06003CB2 RID: 15538 RVA: 0x00053F82 File Offset: 0x00052182
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskCalculateBackwardPosition.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskCalculateBackwardPosition.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x06003CB3 RID: 15539 RVA: 0x00053F98 File Offset: 0x00052198
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void InitTsVariables()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitTsVariables"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003CB4 RID: 15540 RVA: 0x00054008 File Offset: 0x00052208
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsDistance = this.Distance;
			this.TsBlackboardKey = this.BlackboardKey;
		}
	}

	// Token: 0x06003CB5 RID: 15541 RVA: 0x00054038 File Offset: 0x00052238
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003CB6 RID: 15542 RVA: 0x000540D4 File Offset: 0x000522D4
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables();
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		global::Vector actorLocationProxy = charActorComp.ActorLocationProxy;
		global::Vector vector = charActorComp.ActorForwardProxy;
		Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(charActorComp.Entity.Id, "InputDirect");
		if (vectorValueByEntity != null)
		{
			vector = global::Vector.Create(vectorValueByEntity);
			if (vector.IsNearlyZero(9.999999747378752E-05))
			{
				vector = charActorComp.ActorForwardProxy;
			}
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(charActorComp.Entity.Id, "InputDirect");
		}
		global::Vector vector2 = global::Vector.Create(vector);
		vector2.MultiplyEqual((double)(-(double)this.TsDistance));
		vector2.AdditionEqual(actorLocationProxy);
		ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(charActorComp.Entity.Id, this.TsBlackboardKey, (double)((float)vector2.X), (double)((float)vector2.Y), (double)((float)vector2.Z));
		base.FinishExecute(true);
	}

	// Token: 0x06003CB7 RID: 15543 RVA: 0x00054206 File Offset: 0x00052406
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskCalculateBackwardPosition._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskCalculateBackwardPosition.TsTaskCalculateBackwardPosition_C");
		}
		return TsTaskCalculateBackwardPosition._ClassPtr;
	}

	// Token: 0x06003CB8 RID: 15544 RVA: 0x0005422C File Offset: 0x0005242C
	public TsTaskCalculateBackwardPosition() : this(BuiltinUtils.AllocNativeUObject(TsTaskCalculateBackwardPosition.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003CB9 RID: 15545 RVA: 0x00054254 File Offset: 0x00052454
	public TsTaskCalculateBackwardPosition(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskCalculateBackwardPosition.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003CBA RID: 15546 RVA: 0x00054287 File Offset: 0x00052487
	protected TsTaskCalculateBackwardPosition(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003CBB RID: 15547 RVA: 0x0005429B File Offset: 0x0005249B
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003CBC RID: 15548 RVA: 0x000542A4 File Offset: 0x000524A4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000BC0 RID: 3008
	private bool IsInitTsVariables;

	// Token: 0x04000BC1 RID: 3009
	private float TsDistance;

	// Token: 0x04000BC2 RID: 3010
	private string TsBlackboardKey = "";

	// Token: 0x04000BC3 RID: 3011
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskCalculateBackwardPosition.TsTaskCalculateBackwardPosition_C";

	// Token: 0x04000BC4 RID: 3012
	private static IntPtr _ClassPtr;

	// Token: 0x04000BC5 RID: 3013
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BC6 RID: 3014
	private static int __PropertyOffset_Distance;

	// Token: 0x04000BC7 RID: 3015
	private static int __PropertyOffset_BlackboardKey;
}
