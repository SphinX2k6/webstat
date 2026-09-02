using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD5 RID: 3285
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetSightToTarget.TsTaskSetSightToTarget_C")]
public class TsTaskSetSightToTarget : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002D1 RID: 721
	// (get) Token: 0x06004063 RID: 16483 RVA: 0x00066093 File Offset: 0x00064293
	// (set) Token: 0x06004064 RID: 16484 RVA: 0x000660A7 File Offset: 0x000642A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetSightToTarget.__PropertyOffset_TargetBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetSightToTarget.__PropertyOffset_TargetBlackboardKey)), value);
		}
	}

	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06004065 RID: 16485 RVA: 0x000660BC File Offset: 0x000642BC
	// (set) Token: 0x06004066 RID: 16486 RVA: 0x000660D0 File Offset: 0x000642D0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BoneName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetSightToTarget.__PropertyOffset_BoneName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetSightToTarget.__PropertyOffset_BoneName)), value);
		}
	}

	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06004067 RID: 16487 RVA: 0x000660E5 File Offset: 0x000642E5
	// (set) Token: 0x06004068 RID: 16488 RVA: 0x000660F5 File Offset: 0x000642F5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableDebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSetSightToTarget.__PropertyOffset_EnableDebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSetSightToTarget.__PropertyOffset_EnableDebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004069 RID: 16489 RVA: 0x00066106 File Offset: 0x00064306
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTargetBlackboardKey = this.TargetBlackboardKey;
			this.TsBoneName = FNameUtil.GetDynamicFName(this.BoneName);
		}
	}

	// Token: 0x0600406A RID: 16490 RVA: 0x0006613C File Offset: 0x0006433C
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

	// Token: 0x0600406B RID: 16491 RVA: 0x000661D8 File Offset: 0x000643D8
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
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
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		int id = charActorComp.Entity.Id;
		if (string.IsNullOrEmpty(this.TsTargetBlackboardKey))
		{
			Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.ZJL, "TsTaskSetSightToTarget 未配置目标黑板键", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false);
			return;
		}
		CharacterAnimationComponent component = charActorComp.Entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "TsTaskSetSightToTarget 拿不到AnimationComponent";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		if (!component.EnableSightDirect)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "TsTaskSetSightToTarget 没有开启视线驱动";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("EntityId", id);
			instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			base.FinishExecute(false);
			return;
		}
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(id, this.TsTargetBlackboardKey);
		BaseActorComponent baseActorComponent;
		if (intValueByEntity != null)
		{
			int? num = intValueByEntity;
			int num2 = 0;
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				baseActorComponent = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(intValueByEntity.Value);
				goto IL_193;
			}
		}
		baseActorComponent = null;
		IL_193:
		BaseActorComponent baseActorComponent2 = baseActorComponent;
		if (baseActorComponent2 != null && baseActorComponent2.Valid)
		{
			component.SetSightTargetItem(baseActorComponent2);
		}
		else
		{
			Vector inB = (this.TsBoneName != null) ? component.GetBoneWorldLocation(this.TsBoneName.Value, this.TmpBoneLocation) : charActorComp.ActorLocationProxy;
			component.GetWorldDefaultSightDirect(this.SightForwardPoint);
			this.SightForwardPoint.MultiplyEqual(10000.0);
			this.SightForwardPoint.AdditionEqual(inB);
			component.SetSightTargetPoint(this.SightForwardPoint);
		}
		if (this.EnableDebugDraw)
		{
			Vector vector = (this.TsBoneName != null) ? component.GetBoneWorldLocation(this.TsBoneName.Value, this.TmpBoneLocation) : charActorComp.ActorLocationProxy;
			Vector worldSightDirect = component.GetWorldSightDirect(this.TmpSightDir);
			this.TmpArrowEnd.DeepCopy(worldSightDirect);
			this.TmpArrowEnd.MultiplyEqual(500.0);
			this.TmpArrowEnd.AdditionEqual(vector);
			UKismetSystemLibrary.D_DrawDebugArrow(this, vector.ToUeVector(false), this.TmpArrowEnd.ToUeVector(false), 100f, TsTaskSetSightToTarget.currentDirColor, 1f, 2f);
			if (baseActorComponent2 != null && baseActorComponent2.Valid)
			{
				this.TmpTargetDir.DeepCopy(baseActorComponent2.ActorLocationProxy);
				this.TmpTargetDir.SubtractionEqual(vector);
				this.TmpTargetDir.Normalize(9.99999993922529E-09);
			}
			else
			{
				component.GetWorldDefaultSightDirect(this.TmpTargetDir);
			}
			this.TmpArrowEnd.DeepCopy(this.TmpTargetDir);
			this.TmpArrowEnd.MultiplyEqual(500.0);
			this.TmpArrowEnd.AdditionEqual(vector);
			UKismetSystemLibrary.D_DrawDebugArrow(this, vector.ToUeVector(false), this.TmpArrowEnd.ToUeVector(false), 100f, TsTaskSetSightToTarget.targetDirColor, 1f, 2f);
		}
		base.FinishExecute(true);
	}

	// Token: 0x0600406C RID: 16492 RVA: 0x0006655A File Offset: 0x0006475A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSetSightToTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetSightToTarget.TsTaskSetSightToTarget_C");
		}
		return TsTaskSetSightToTarget._ClassPtr;
	}

	// Token: 0x0600406D RID: 16493 RVA: 0x00066580 File Offset: 0x00064780
	public TsTaskSetSightToTarget() : this(BuiltinUtils.AllocNativeUObject(TsTaskSetSightToTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600406E RID: 16494 RVA: 0x000665A8 File Offset: 0x000647A8
	public TsTaskSetSightToTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetSightToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600406F RID: 16495 RVA: 0x000665DC File Offset: 0x000647DC
	protected TsTaskSetSightToTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004070 RID: 16496 RVA: 0x00066634 File Offset: 0x00064834
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000EF2 RID: 3826
	private const float FORWARD_TARGET_DISTANCE = 10000f;

	// Token: 0x04000EF3 RID: 3827
	private const float SIGHT_DEBUG_LENGTH = 500f;

	// Token: 0x04000EF4 RID: 3828
	private const float SIGHT_DEBUG_ARROW_SIZE = 100f;

	// Token: 0x04000EF5 RID: 3829
	private const float SIGHT_DEBUG_DURATION = 1f;

	// Token: 0x04000EF6 RID: 3830
	private const float SIGHT_DEBUG_THICKNESS = 2f;

	// Token: 0x04000EF7 RID: 3831
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor currentDirColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x04000EF8 RID: 3832
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor targetDirColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x04000EF9 RID: 3833
	private bool IsInitTsVariables;

	// Token: 0x04000EFA RID: 3834
	private string TsTargetBlackboardKey = "";

	// Token: 0x04000EFB RID: 3835
	private FName? TsBoneName;

	// Token: 0x04000EFC RID: 3836
	private readonly Vector TmpBoneLocation = Vector.Create();

	// Token: 0x04000EFD RID: 3837
	private readonly Vector SightForwardPoint = Vector.Create();

	// Token: 0x04000EFE RID: 3838
	private readonly Vector TmpSightDir = Vector.Create();

	// Token: 0x04000EFF RID: 3839
	private readonly Vector TmpTargetDir = Vector.Create();

	// Token: 0x04000F00 RID: 3840
	private readonly Vector TmpArrowEnd = Vector.Create();

	// Token: 0x04000F01 RID: 3841
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetSightToTarget.TsTaskSetSightToTarget_C";

	// Token: 0x04000F02 RID: 3842
	private static IntPtr _ClassPtr;

	// Token: 0x04000F03 RID: 3843
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F04 RID: 3844
	private static int __PropertyOffset_TargetBlackboardKey;

	// Token: 0x04000F05 RID: 3845
	private static int __PropertyOffset_BoneName;

	// Token: 0x04000F06 RID: 3846
	private static int __PropertyOffset_EnableDebugDraw;
}
