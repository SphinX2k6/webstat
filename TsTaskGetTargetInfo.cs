using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C8E RID: 3214
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskGetTargetInfo.TsTaskGetTargetInfo_C")]
public class TsTaskGetTargetInfo : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x06003AF6 RID: 15094 RVA: 0x00049F79 File Offset: 0x00048179
	// (set) Token: 0x06003AF7 RID: 15095 RVA: 0x00049F8D File Offset: 0x0004818D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskGetTargetInfo.__PropertyOffset_TargetKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskGetTargetInfo.__PropertyOffset_TargetKey)), value);
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x06003AF8 RID: 15096 RVA: 0x00049FA2 File Offset: 0x000481A2
	// (set) Token: 0x06003AF9 RID: 15097 RVA: 0x00049FB6 File Offset: 0x000481B6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string PositionKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskGetTargetInfo.__PropertyOffset_PositionKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskGetTargetInfo.__PropertyOffset_PositionKey)), value);
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x06003AFA RID: 15098 RVA: 0x00049FCB File Offset: 0x000481CB
	// (set) Token: 0x06003AFB RID: 15099 RVA: 0x00049FDF File Offset: 0x000481DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string HpKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskGetTargetInfo.__PropertyOffset_HpKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskGetTargetInfo.__PropertyOffset_HpKey)), value);
		}
	}

	// Token: 0x06003AFC RID: 15100 RVA: 0x00049FF4 File Offset: 0x000481F4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTargetKey = this.TargetKey;
			this.TsPositionKey = this.PositionKey;
			this.TsHpKey = this.HpKey;
		}
	}

	// Token: 0x06003AFD RID: 15101 RVA: 0x0004A030 File Offset: 0x00048230
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

	// Token: 0x06003AFE RID: 15102 RVA: 0x0004A0CC File Offset: 0x000482CC
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent characterActorComponent = ((TsAiController)ownerController).AiController.CharActorComp;
		if (!string.IsNullOrEmpty(this.TsTargetKey))
		{
			int valueOrDefault = ControllerBase<BlackboardController>.Instance.GetIntValueByWorld(this.TsTargetKey).GetValueOrDefault();
			if (valueOrDefault == 0)
			{
				base.FinishExecute(false);
				return;
			}
			characterActorComponent = Singleton<EntitySystem>.Instance.Get(valueOrDefault).GetComponent<CharacterActorComponent>();
		}
		if (characterActorComponent == null)
		{
			base.FinishExecute(false);
			return;
		}
		FVectorDouble actorLocation = characterActorComponent.ActorLocation;
		ControllerBase<BlackboardController>.Instance.SetVectorValueByGlobal(this.TsPositionKey, (float)actorLocation.X, (float)actorLocation.Y, (float)actorLocation.Z);
		BaseAttributeComponent component = characterActorComponent.Entity.GetComponent<BaseAttributeComponent>();
		if (component != null)
		{
			float currentValue = component.GetCurrentValue(EAttributeType.Life);
			ControllerBase<BlackboardController>.Instance.SetIntValueByWorld(this.TsHpKey, (int)currentValue);
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003AFF RID: 15103 RVA: 0x0004A1AC File Offset: 0x000483AC
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskGetTargetInfo._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskGetTargetInfo.TsTaskGetTargetInfo_C");
		}
		return TsTaskGetTargetInfo._ClassPtr;
	}

	// Token: 0x06003B00 RID: 15104 RVA: 0x0004A1D0 File Offset: 0x000483D0
	public TsTaskGetTargetInfo() : this(BuiltinUtils.AllocNativeUObject(TsTaskGetTargetInfo.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B01 RID: 15105 RVA: 0x0004A1F8 File Offset: 0x000483F8
	public TsTaskGetTargetInfo(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskGetTargetInfo.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B02 RID: 15106 RVA: 0x0004A22B File Offset: 0x0004842B
	protected TsTaskGetTargetInfo(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B03 RID: 15107 RVA: 0x0004A258 File Offset: 0x00048458
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000A5E RID: 2654
	private bool IsInitTsVariables;

	// Token: 0x04000A5F RID: 2655
	private string TsTargetKey = "";

	// Token: 0x04000A60 RID: 2656
	private string TsPositionKey = "";

	// Token: 0x04000A61 RID: 2657
	private string TsHpKey = "";

	// Token: 0x04000A62 RID: 2658
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskGetTargetInfo.TsTaskGetTargetInfo_C";

	// Token: 0x04000A63 RID: 2659
	private static IntPtr _ClassPtr;

	// Token: 0x04000A64 RID: 2660
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A65 RID: 2661
	private static int __PropertyOffset_TargetKey;

	// Token: 0x04000A66 RID: 2662
	private static int __PropertyOffset_PositionKey;

	// Token: 0x04000A67 RID: 2663
	private static int __PropertyOffset_HpKey;
}
