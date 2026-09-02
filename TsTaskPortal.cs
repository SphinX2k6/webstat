using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CCB RID: 3275
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPortal.TsTaskPortal_C")]
public class TsTaskPortal : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x06003FB5 RID: 16309 RVA: 0x000634A1 File Offset: 0x000616A1
	// (set) Token: 0x06003FB6 RID: 16310 RVA: 0x000634B1 File Offset: 0x000616B1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Distance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_Distance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_Distance) = value;
		}
	}

	// Token: 0x170002A6 RID: 678
	// (get) Token: 0x06003FB7 RID: 16311 RVA: 0x000634C2 File Offset: 0x000616C2
	// (set) Token: 0x06003FB8 RID: 16312 RVA: 0x000634D2 File Offset: 0x000616D2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EffectDieTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_EffectDieTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_EffectDieTime) = value;
		}
	}

	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x06003FB9 RID: 16313 RVA: 0x000634E3 File Offset: 0x000616E3
	// (set) Token: 0x06003FBA RID: 16314 RVA: 0x000634F3 File Offset: 0x000616F3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EffectBornTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_EffectBornTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_EffectBornTime) = value;
		}
	}

	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x06003FBB RID: 16315 RVA: 0x00063504 File Offset: 0x00061704
	// (set) Token: 0x06003FBC RID: 16316 RVA: 0x00063514 File Offset: 0x00061714
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ActiveModel
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_ActiveModel) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_ActiveModel) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x06003FBD RID: 16317 RVA: 0x00063525 File Offset: 0x00061725
	// (set) Token: 0x06003FBE RID: 16318 RVA: 0x00063535 File Offset: 0x00061735
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float WaitTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_WaitTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPortal.__PropertyOffset_WaitTime) = value;
		}
	}

	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06003FBF RID: 16319 RVA: 0x00063546 File Offset: 0x00061746
	// (set) Token: 0x06003FC0 RID: 16320 RVA: 0x0006355A File Offset: 0x0006175A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UObject StartMaterialControllerData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + TsTaskPortal.__PropertyOffset_StartMaterialControllerData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTaskPortal.__PropertyOffset_StartMaterialControllerData, value);
		}
	}

	// Token: 0x170002AB RID: 683
	// (get) Token: 0x06003FC1 RID: 16321 RVA: 0x0006356F File Offset: 0x0006176F
	// (set) Token: 0x06003FC2 RID: 16322 RVA: 0x00063583 File Offset: 0x00061783
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UObject EndMaterialControllerData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + TsTaskPortal.__PropertyOffset_EndMaterialControllerData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTaskPortal.__PropertyOffset_EndMaterialControllerData, value);
		}
	}

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06003FC3 RID: 16323 RVA: 0x00063598 File Offset: 0x00061798
	// (set) Token: 0x06003FC4 RID: 16324 RVA: 0x000635AC File Offset: 0x000617AC
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FollowPointName
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPortal.__PropertyOffset_FollowPointName)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPortal.__PropertyOffset_FollowPointName)), value);
		}
	}

	// Token: 0x06003FC5 RID: 16325 RVA: 0x000635C4 File Offset: 0x000617C4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsEffectDieTime = this.EffectDieTime;
			this.TsEffectBornTime = this.EffectBornTime;
			this.TsActiveModel = this.ActiveModel;
			this.TsWaitTime = (double)this.WaitTime;
			this.TsStartMaterialControllerData = this.StartMaterialControllerData;
			this.TsEndMaterialControllerData = this.EndMaterialControllerData;
			this.TsFollowPointName = this.FollowPointName;
		}
	}

	// Token: 0x06003FC6 RID: 16326 RVA: 0x0006363C File Offset: 0x0006183C
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

	// Token: 0x06003FC7 RID: 16327 RVA: 0x000636D8 File Offset: 0x000618D8
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		if (((tsAiController != null) ? tsAiController.AiController : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.TsActiveModel)
		{
			return;
		}
		base.FinishExecute(false);
	}

	// Token: 0x06003FC8 RID: 16328 RVA: 0x00063744 File Offset: 0x00061944
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003FC9 RID: 16329 RVA: 0x000637E4 File Offset: 0x000619E4
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		this.FollowPoint = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsFollowPointName);
		FVectorDouble zeroVectorDouble = global::Vector.ZeroVectorDouble;
		if (this.FollowPoint != null)
		{
			zeroVectorDouble = new FVectorDouble((double)this.FollowPoint.X, (double)this.FollowPoint.Y, (double)this.FollowPoint.Z);
		}
		if (this.TsActiveModel)
		{
			if (this.TsWaitTime <= Singleton<Time>.Instance.WorldTime)
			{
				charActorComp.Actor.CharRenderingComponent.RemoveMaterialControllerData(this.EffectId);
				charActorComp.Actor.CharRenderingComponent.AddMaterialControllerData(this.TsStartMaterialControllerData);
				this.TsActiveModel = false;
				FVectorDouble fvectorDouble = UKismetMathLibrary.D_ProjectPointOnToPlane(charActorComp.ActorLocation, zeroVectorDouble, new FVectorDouble(0.0, 0.0, 1.0));
				FRotator rotation = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, zeroVectorDouble);
				charActorComp.SetActorLocationAndRotation(zeroVectorDouble, rotation, "行为树节点.传送", true, null);
				this.TsWaitTime = (double)this.TsEffectBornTime + Singleton<Time>.Instance.WorldTime;
				return;
			}
		}
		else if (this.TsWaitTime <= Singleton<Time>.Instance.WorldTime && zeroVectorDouble != global::Vector.ZeroVectorDouble)
		{
			this.TsActiveModel = true;
			this.EffectId = charActorComp.Actor.CharRenderingComponent.AddMaterialControllerData(this.TsEndMaterialControllerData);
			this.TsWaitTime = (double)this.TsEffectDieTime + Singleton<Time>.Instance.WorldTime;
		}
	}

	// Token: 0x06003FCA RID: 16330 RVA: 0x0006398E File Offset: 0x00061B8E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPortal._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPortal.TsTaskPortal_C");
		}
		return TsTaskPortal._ClassPtr;
	}

	// Token: 0x06003FCB RID: 16331 RVA: 0x000639B4 File Offset: 0x00061BB4
	public TsTaskPortal() : this(BuiltinUtils.AllocNativeUObject(TsTaskPortal.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003FCC RID: 16332 RVA: 0x000639DC File Offset: 0x00061BDC
	[NullableContext(1)]
	public TsTaskPortal(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPortal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003FCD RID: 16333 RVA: 0x00063A0F File Offset: 0x00061C0F
	protected TsTaskPortal(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003FCE RID: 16334 RVA: 0x00063A24 File Offset: 0x00061C24
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003FCF RID: 16335 RVA: 0x00063A54 File Offset: 0x00061C54
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000E60 RID: 3680
	private int EffectId;

	// Token: 0x04000E61 RID: 3681
	private Aki.Protocol.Vector FollowPoint;

	// Token: 0x04000E62 RID: 3682
	private bool IsInitTsVariables;

	// Token: 0x04000E63 RID: 3683
	private float TsEffectDieTime;

	// Token: 0x04000E64 RID: 3684
	private float TsEffectBornTime;

	// Token: 0x04000E65 RID: 3685
	private bool TsActiveModel;

	// Token: 0x04000E66 RID: 3686
	private double TsWaitTime;

	// Token: 0x04000E67 RID: 3687
	private UObject TsStartMaterialControllerData;

	// Token: 0x04000E68 RID: 3688
	private UObject TsEndMaterialControllerData;

	// Token: 0x04000E69 RID: 3689
	[Nullable(1)]
	private string TsFollowPointName = "";

	// Token: 0x04000E6A RID: 3690
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPortal.TsTaskPortal_C";

	// Token: 0x04000E6B RID: 3691
	private static IntPtr _ClassPtr;

	// Token: 0x04000E6C RID: 3692
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E6D RID: 3693
	private static int __PropertyOffset_Distance;

	// Token: 0x04000E6E RID: 3694
	private static int __PropertyOffset_EffectDieTime;

	// Token: 0x04000E6F RID: 3695
	private static int __PropertyOffset_EffectBornTime;

	// Token: 0x04000E70 RID: 3696
	private static int __PropertyOffset_ActiveModel;

	// Token: 0x04000E71 RID: 3697
	private static int __PropertyOffset_WaitTime;

	// Token: 0x04000E72 RID: 3698
	private static int __PropertyOffset_StartMaterialControllerData;

	// Token: 0x04000E73 RID: 3699
	private static int __PropertyOffset_EndMaterialControllerData;

	// Token: 0x04000E74 RID: 3700
	private static int __PropertyOffset_FollowPointName;
}
