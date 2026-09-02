using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CDD RID: 3293
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSwitchGazeAwareness.TsTaskSwitchGazeAwareness_C")]
public class TsTaskSwitchGazeAwareness : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002E3 RID: 739
	// (get) Token: 0x060040CB RID: 16587 RVA: 0x0006868B File Offset: 0x0006688B
	// (set) Token: 0x060040CC RID: 16588 RVA: 0x0006869B File Offset: 0x0006689B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsEnable
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_IsEnable) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_IsEnable) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002E4 RID: 740
	// (get) Token: 0x060040CD RID: 16589 RVA: 0x000686AC File Offset: 0x000668AC
	// (set) Token: 0x060040CE RID: 16590 RVA: 0x000686BC File Offset: 0x000668BC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AwarenessAngle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_AwarenessAngle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_AwarenessAngle) = value;
		}
	}

	// Token: 0x170002E5 RID: 741
	// (get) Token: 0x060040CF RID: 16591 RVA: 0x000686CD File Offset: 0x000668CD
	// (set) Token: 0x060040D0 RID: 16592 RVA: 0x000686DD File Offset: 0x000668DD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AwarenessDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_AwarenessDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_AwarenessDistance) = value;
		}
	}

	// Token: 0x170002E6 RID: 742
	// (get) Token: 0x060040D1 RID: 16593 RVA: 0x000686EE File Offset: 0x000668EE
	// (set) Token: 0x060040D2 RID: 16594 RVA: 0x000686FE File Offset: 0x000668FE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AwarenessHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_AwarenessHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_AwarenessHeight) = value;
		}
	}

	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x060040D3 RID: 16595 RVA: 0x0006870F File Offset: 0x0006690F
	// (set) Token: 0x060040D4 RID: 16596 RVA: 0x0006871F File Offset: 0x0006691F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float PlayerGazeAngle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_PlayerGazeAngle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_PlayerGazeAngle) = value;
		}
	}

	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x060040D5 RID: 16597 RVA: 0x00068730 File Offset: 0x00066930
	// (set) Token: 0x060040D6 RID: 16598 RVA: 0x00068740 File Offset: 0x00066940
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableDebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_EnableDebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSwitchGazeAwareness.__PropertyOffset_EnableDebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x060040D7 RID: 16599 RVA: 0x00068754 File Offset: 0x00066954
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsIsEnable = this.IsEnable;
			this.TsAwarenessAngle = this.AwarenessAngle;
			this.TsAwarenessDistance = this.AwarenessDistance;
			this.TsPlayerGazeAngle = this.PlayerGazeAngle;
			this.TsAwarenessHeight = this.AwarenessHeight;
			this.TsEnableDebugDraw = this.EnableDebugDraw;
		}
	}

	// Token: 0x060040D8 RID: 16600 RVA: 0x000687C0 File Offset: 0x000669C0
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

	// Token: 0x060040D9 RID: 16601 RVA: 0x0006885C File Offset: 0x00066A5C
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
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
		this.InitTsVariables();
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		IdlePerformModel instance2 = ModelBase<IdlePerformModel>.Instance;
		if (instance2 == null)
		{
			base.FinishExecute(false);
			return;
		}
		int id = charActorComp.Entity.Id;
		if (this.TsIsEnable)
		{
			instance2.StartGazeAwarenessCheckByEntityId(id, this.TsAwarenessAngle, this.TsAwarenessDistance, this.TsAwarenessHeight, this.TsPlayerGazeAngle, this.TsEnableDebugDraw);
		}
		else
		{
			instance2.StopGazeAwarenessCheckByEntityId(id);
		}
		base.FinishExecute(true);
	}

	// Token: 0x060040DA RID: 16602 RVA: 0x0006893C File Offset: 0x00066B3C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSwitchGazeAwareness._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSwitchGazeAwareness.TsTaskSwitchGazeAwareness_C");
		}
		return TsTaskSwitchGazeAwareness._ClassPtr;
	}

	// Token: 0x060040DB RID: 16603 RVA: 0x00068960 File Offset: 0x00066B60
	public TsTaskSwitchGazeAwareness() : this(BuiltinUtils.AllocNativeUObject(TsTaskSwitchGazeAwareness.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060040DC RID: 16604 RVA: 0x00068988 File Offset: 0x00066B88
	[NullableContext(1)]
	public TsTaskSwitchGazeAwareness(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSwitchGazeAwareness.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060040DD RID: 16605 RVA: 0x000689BB File Offset: 0x00066BBB
	protected TsTaskSwitchGazeAwareness(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060040DE RID: 16606 RVA: 0x000689CC File Offset: 0x00066BCC
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000F49 RID: 3913
	private bool IsInitTsVariables;

	// Token: 0x04000F4A RID: 3914
	private bool TsIsEnable = true;

	// Token: 0x04000F4B RID: 3915
	private float TsAwarenessAngle;

	// Token: 0x04000F4C RID: 3916
	private float TsAwarenessDistance;

	// Token: 0x04000F4D RID: 3917
	private float TsAwarenessHeight;

	// Token: 0x04000F4E RID: 3918
	private float TsPlayerGazeAngle;

	// Token: 0x04000F4F RID: 3919
	private bool TsEnableDebugDraw;

	// Token: 0x04000F50 RID: 3920
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSwitchGazeAwareness.TsTaskSwitchGazeAwareness_C";

	// Token: 0x04000F51 RID: 3921
	private static IntPtr _ClassPtr;

	// Token: 0x04000F52 RID: 3922
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F53 RID: 3923
	private static int __PropertyOffset_IsEnable;

	// Token: 0x04000F54 RID: 3924
	private static int __PropertyOffset_AwarenessAngle;

	// Token: 0x04000F55 RID: 3925
	private static int __PropertyOffset_AwarenessDistance;

	// Token: 0x04000F56 RID: 3926
	private static int __PropertyOffset_AwarenessHeight;

	// Token: 0x04000F57 RID: 3927
	private static int __PropertyOffset_PlayerGazeAngle;

	// Token: 0x04000F58 RID: 3928
	private static int __PropertyOffset_EnableDebugDraw;
}
