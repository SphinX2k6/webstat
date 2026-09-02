using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CCE RID: 3278
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomNavMeshPathMove.TsTaskRandomNavMeshPathMove_C")]
public class TsTaskRandomNavMeshPathMove : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x06003FEF RID: 16367 RVA: 0x00064171 File Offset: 0x00062371
	// (set) Token: 0x06003FF0 RID: 16368 RVA: 0x00064181 File Offset: 0x00062381
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x06003FF1 RID: 16369 RVA: 0x00064192 File Offset: 0x00062392
	// (set) Token: 0x06003FF2 RID: 16370 RVA: 0x000641A6 File Offset: 0x000623A6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardLocation
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_BlackboardLocation)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_BlackboardLocation)), value);
		}
	}

	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x06003FF3 RID: 16371 RVA: 0x000641BB File Offset: 0x000623BB
	// (set) Token: 0x06003FF4 RID: 16372 RVA: 0x000641CB File Offset: 0x000623CB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Sampling
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_Sampling);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_Sampling) = value;
		}
	}

	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06003FF5 RID: 16373 RVA: 0x000641DC File Offset: 0x000623DC
	// (set) Token: 0x06003FF6 RID: 16374 RVA: 0x000641EC File Offset: 0x000623EC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RandomRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_RandomRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_RandomRange) = value;
		}
	}

	// Token: 0x170002BA RID: 698
	// (get) Token: 0x06003FF7 RID: 16375 RVA: 0x000641FD File Offset: 0x000623FD
	// (set) Token: 0x06003FF8 RID: 16376 RVA: 0x0006420D File Offset: 0x0006240D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_EndDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_EndDistance) = value;
		}
	}

	// Token: 0x170002BB RID: 699
	// (get) Token: 0x06003FF9 RID: 16377 RVA: 0x0006421E File Offset: 0x0006241E
	// (set) Token: 0x06003FFA RID: 16378 RVA: 0x0006422E File Offset: 0x0006242E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06003FFB RID: 16379 RVA: 0x0006423F File Offset: 0x0006243F
	// (set) Token: 0x06003FFC RID: 16380 RVA: 0x0006424F File Offset: 0x0006244F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OpenDebugNode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_OpenDebugNode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_OpenDebugNode) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06003FFD RID: 16381 RVA: 0x00064260 File Offset: 0x00062460
	// (set) Token: 0x06003FFE RID: 16382 RVA: 0x00064270 File Offset: 0x00062470
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe bool IsEditor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_IsEditor) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomNavMeshPathMove.__PropertyOffset_IsEditor) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003FFF RID: 16383 RVA: 0x00064284 File Offset: 0x00062484
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveState = this.MoveState;
			this.TsBlackboardLocation = this.BlackboardLocation;
			this.TsSampling = this.Sampling;
			this.TsRandomRange = this.RandomRange;
			this.TsEndDistance = this.EndDistance;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsOpenDebugNode = this.OpenDebugNode;
		}
	}

	// Token: 0x06004000 RID: 16384 RVA: 0x000642FC File Offset: 0x000624FC
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

	// Token: 0x06004001 RID: 16385 RVA: 0x00064398 File Offset: 0x00062598
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardLocation);
		if (vectorValueByEntity == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "TsTaskMoveToLocation没有获取到目标坐标";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BehaviorTree", base.TreeAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BlackboardLocation", this.TsBlackboardLocation);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.FoundPath = false;
			return;
		}
		this.SelectedTargetLocation = new FVectorDouble?(WorldGlobal.ToUeVector(vectorValueByEntity));
		this.FindRandomPath(ownerController, charActorComp.ActorLocation, this.SelectedTargetLocation.Value);
		this.FoundPath = (this.NavigationPath.Count > 0);
		this.CurrentNavigationIndex = 1;
		CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
		CharacterUnifiedStateComponent characterUnifiedStateComponent = (charAiDesignComp != null) ? charAiDesignComp.Entity.GetComponent<CharacterUnifiedStateComponent>() : null;
		if (characterUnifiedStateComponent != null && characterUnifiedStateComponent.Valid)
		{
			switch (this.TsMoveState)
			{
			case 1:
				characterUnifiedStateComponent.SetMoveState(global::ECharMoveState.Walk);
				break;
			case 2:
				characterUnifiedStateComponent.SetMoveState(global::ECharMoveState.Run);
				break;
			case 3:
				characterUnifiedStateComponent.SetMoveState(global::ECharMoveState.Sprint);
				break;
			}
		}
		this.IsEditor = GlobalData.IsPlayInEditor;
	}

	// Token: 0x06004002 RID: 16386 RVA: 0x00064538 File Offset: 0x00062738
	private void FindRandomPath(AAIController controller, FVectorDouble startPoint, FVectorDouble endPoint)
	{
		if (this.NavigationPath == null)
		{
			this.NavigationPath = new List<global::Vector>();
		}
		global::Vector vector = global::Vector.Create(startPoint);
		global::Vector v = global::Vector.Create(endPoint);
		global::Vector vector2 = global::Vector.Create(endPoint);
		vector2.Subtraction(vector, vector2);
		double num = global::Vector.Dist(vector, v);
		if (num < (double)this.TsRandomRange || this.TsSampling < 1)
		{
			this.FoundPath = AiControllerLibrary.NavigationFindPath(controller, startPoint, endPoint, this.NavigationPath, null, null);
			return;
		}
		FVectorDouble from = startPoint;
		double num2 = num / (double)(this.TsSampling + 1);
		for (int i = 0; i < this.TsSampling; i++)
		{
			global::Vector vector3 = global::Vector.Create();
			vector2.Multiply((double)(i + 1) * num2, vector3);
			vector3.Addition(global::Vector.Create(startPoint), vector3);
			vector3 = this.CalculateRandomPosition(vector3);
			List<global::Vector> list = new List<global::Vector>();
			if (AiControllerLibrary.NavigationFindPath(controller, from, vector3.ToUeVector(false), list, null, null))
			{
				this.NavigationPath.AddRange(list);
			}
			from = vector3.ToUeVector(false);
		}
		List<global::Vector> list2 = new List<global::Vector>();
		if (AiControllerLibrary.NavigationFindPath(controller, from, endPoint, list2, null, null))
		{
			this.NavigationPath.AddRange(list2);
		}
	}

	// Token: 0x06004003 RID: 16387 RVA: 0x000646A8 File Offset: 0x000628A8
	private global::Vector CalculateRandomPosition(global::Vector point)
	{
		float randomFloatNumber = Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, 360f);
		global::Vector vector = global::Vector.Create(global::Vector.ForwardVector);
		vector.RotateAngleAxis((double)randomFloatNumber, global::Vector.UpVectorProxy, vector);
		float randomFloatNumber2 = Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, (float)this.TsRandomRange);
		global::Vector vector2 = vector;
		vector2.Multiply((double)randomFloatNumber2, vector2).Addition(point, vector2);
		return vector2;
	}

	// Token: 0x06004004 RID: 16388 RVA: 0x00064714 File Offset: 0x00062914
	[NullableContext(2)]
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

	// Token: 0x06004005 RID: 16389 RVA: 0x000647B4 File Offset: 0x000629B4
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.FoundPath)
		{
			TsAiController tsAiController = ownerController as TsAiController;
			if (tsAiController != null)
			{
				CharacterActorComponent charActorComp = tsAiController.AiController.CharActorComp;
				global::Vector vector = this.NavigationPath[this.CurrentNavigationIndex];
				if (this.TsOpenDebugNode && this.IsEditor)
				{
					int segments = 10;
					int num = 30;
					UKismetSystemLibrary.D_DrawDebugSphere(this, vector.ToUeVector(false), (float)num, segments, new FLinearColor?(ColorUtils.LinearRed), 0f, 0f);
				}
				global::Vector vector2 = global::Vector.Create(vector);
				vector2.Subtraction(charActorComp.ActorLocationProxy, vector2);
				vector2.Z = 0.0;
				double num2 = vector2.Size();
				if (this.CurrentNavigationIndex == this.NavigationPath.Count - 1 && num2 < (double)this.TsEndDistance)
				{
					base.Finish(true);
					return;
				}
				if (num2 < 10.0)
				{
					this.CurrentNavigationIndex++;
				}
				vector2.DivisionEqual(num2);
				charActorComp.SetInputDirect(vector2, true);
				AiControllerLibrary.TurnToDirect(charActorComp, vector2, this.TsTurnSpeed, false, 0f);
				return;
			}
		}
		base.Finish(false);
	}

	// Token: 0x06004006 RID: 16390 RVA: 0x000648D0 File Offset: 0x00062AD0
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			AiControllerLibrary.ClearInput(tsAiController);
		}
	}

	// Token: 0x06004007 RID: 16391 RVA: 0x000648F2 File Offset: 0x00062AF2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskRandomNavMeshPathMove._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomNavMeshPathMove.TsTaskRandomNavMeshPathMove_C");
		}
		return TsTaskRandomNavMeshPathMove._ClassPtr;
	}

	// Token: 0x06004008 RID: 16392 RVA: 0x00064918 File Offset: 0x00062B18
	public TsTaskRandomNavMeshPathMove() : this(BuiltinUtils.AllocNativeUObject(TsTaskRandomNavMeshPathMove.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004009 RID: 16393 RVA: 0x00064940 File Offset: 0x00062B40
	public TsTaskRandomNavMeshPathMove(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskRandomNavMeshPathMove.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600400A RID: 16394 RVA: 0x00064973 File Offset: 0x00062B73
	protected TsTaskRandomNavMeshPathMove(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600400B RID: 16395 RVA: 0x00064988 File Offset: 0x00062B88
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600400C RID: 16396 RVA: 0x000649B8 File Offset: 0x00062BB8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000E92 RID: 3730
	private const double NAVIGATION_COMPLETE_DISTANCE = 10.0;

	// Token: 0x04000E93 RID: 3731
	private FVectorDouble? SelectedTargetLocation;

	// Token: 0x04000E94 RID: 3732
	private bool FoundPath;

	// Token: 0x04000E95 RID: 3733
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> NavigationPath;

	// Token: 0x04000E96 RID: 3734
	private int CurrentNavigationIndex;

	// Token: 0x04000E97 RID: 3735
	private bool IsInitTsVariables;

	// Token: 0x04000E98 RID: 3736
	private int TsMoveState;

	// Token: 0x04000E99 RID: 3737
	private string TsBlackboardLocation = "";

	// Token: 0x04000E9A RID: 3738
	private int TsSampling;

	// Token: 0x04000E9B RID: 3739
	private int TsRandomRange;

	// Token: 0x04000E9C RID: 3740
	private float TsEndDistance;

	// Token: 0x04000E9D RID: 3741
	private float TsTurnSpeed;

	// Token: 0x04000E9E RID: 3742
	private bool TsOpenDebugNode;

	// Token: 0x04000E9F RID: 3743
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomNavMeshPathMove.TsTaskRandomNavMeshPathMove_C";

	// Token: 0x04000EA0 RID: 3744
	private static IntPtr _ClassPtr;

	// Token: 0x04000EA1 RID: 3745
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000EA2 RID: 3746
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000EA3 RID: 3747
	private static int __PropertyOffset_BlackboardLocation;

	// Token: 0x04000EA4 RID: 3748
	private static int __PropertyOffset_Sampling;

	// Token: 0x04000EA5 RID: 3749
	private static int __PropertyOffset_RandomRange;

	// Token: 0x04000EA6 RID: 3750
	private static int __PropertyOffset_EndDistance;

	// Token: 0x04000EA7 RID: 3751
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000EA8 RID: 3752
	private static int __PropertyOffset_OpenDebugNode;

	// Token: 0x04000EA9 RID: 3753
	private static int __PropertyOffset_IsEditor;
}
