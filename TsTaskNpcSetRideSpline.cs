using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C96 RID: 3222
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcSetRideSpline.TsTaskNpcSetRideSpline_C")]
public class TsTaskNpcSetRideSpline : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001CD RID: 461
	// (get) Token: 0x06003B96 RID: 15254 RVA: 0x0004E1E5 File Offset: 0x0004C3E5
	// (set) Token: 0x06003B97 RID: 15255 RVA: 0x0004E1F5 File Offset: 0x0004C3F5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SplineEntityPbDataId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSetRideSpline.__PropertyOffset_SplineEntityPbDataId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSetRideSpline.__PropertyOffset_SplineEntityPbDataId) = value;
		}
	}

	// Token: 0x06003B98 RID: 15256 RVA: 0x0004E208 File Offset: 0x0004C408
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

	// Token: 0x06003B99 RID: 15257 RVA: 0x0004E2A4 File Offset: 0x0004C4A4
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (!(ownerController is TsAiController))
		{
			base.FinishExecute(false);
			return;
		}
		AiController aiController = ((TsAiController)ownerController).AiController;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			base.FinishExecute(false);
			return;
		}
		int id = charActorComp.Entity.Id;
		if (ControllerBase<NpcVehicleRiderController>.Instance.GetRidingVehicle(id) == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[TsTaskNpcSetRideSpline] 失败:NPC未绑定任何载具";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("NpcEntityId", id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		if (this.SplineEntityPbDataId <= 0)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Vehicle;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "[TsTaskNpcSetRideSpline] 失败:未从获取到有效样条PbDataId";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("SplineEntityPbDataId", this.SplineEntityPbDataId);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			base.FinishExecute(false);
			return;
		}
		if (!ControllerBase<NpcVehicleRiderController>.Instance.SetNpcTargetSplinePbDataId(id, this.SplineEntityPbDataId))
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Vehicle;
			ELogAuthor author4 = ELogAuthor.ZJL;
			string message4 = "[TsTaskNpcSetRideSpline] 失败:登记样条PbDataId到座位信息失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineEntityPbDataId", this.SplineEntityPbDataId);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.FinishExecute(false);
			return;
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003B9A RID: 15258 RVA: 0x0004E444 File Offset: 0x0004C644
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcSetRideSpline._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcSetRideSpline.TsTaskNpcSetRideSpline_C");
		}
		return TsTaskNpcSetRideSpline._ClassPtr;
	}

	// Token: 0x06003B9B RID: 15259 RVA: 0x0004E468 File Offset: 0x0004C668
	public TsTaskNpcSetRideSpline() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcSetRideSpline.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B9C RID: 15260 RVA: 0x0004E490 File Offset: 0x0004C690
	[NullableContext(1)]
	public TsTaskNpcSetRideSpline(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcSetRideSpline.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B9D RID: 15261 RVA: 0x0004E4C3 File Offset: 0x0004C6C3
	protected TsTaskNpcSetRideSpline(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B9E RID: 15262 RVA: 0x0004E4CC File Offset: 0x0004C6CC
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000AE8 RID: 2792
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcSetRideSpline.TsTaskNpcSetRideSpline_C";

	// Token: 0x04000AE9 RID: 2793
	private static IntPtr _ClassPtr;

	// Token: 0x04000AEA RID: 2794
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000AEB RID: 2795
	private static int __PropertyOffset_SplineEntityPbDataId;
}
