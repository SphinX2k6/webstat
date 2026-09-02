using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C89 RID: 3209
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPlayBubble.TsTaskPlayBubble_C")]
public class TsTaskPlayBubble : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x06003A9E RID: 15006 RVA: 0x00048691 File Offset: 0x00046891
	// (set) Token: 0x06003A9F RID: 15007 RVA: 0x000486A5 File Offset: 0x000468A5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FlowListName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayBubble.__PropertyOffset_FlowListName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayBubble.__PropertyOffset_FlowListName)), value);
		}
	}

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x06003AA0 RID: 15008 RVA: 0x000486BA File Offset: 0x000468BA
	// (set) Token: 0x06003AA1 RID: 15009 RVA: 0x000486CA File Offset: 0x000468CA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FlowId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayBubble.__PropertyOffset_FlowId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayBubble.__PropertyOffset_FlowId) = value;
		}
	}

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x06003AA2 RID: 15010 RVA: 0x000486DB File Offset: 0x000468DB
	// (set) Token: 0x06003AA3 RID: 15011 RVA: 0x000486EB File Offset: 0x000468EB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int StateId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayBubble.__PropertyOffset_StateId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayBubble.__PropertyOffset_StateId) = value;
		}
	}

	// Token: 0x06003AA4 RID: 15012 RVA: 0x000486FC File Offset: 0x000468FC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsFlowListName = this.FlowListName;
			this.TsFlowId = this.FlowId;
			this.TsStateId = this.StateId;
		}
	}

	// Token: 0x06003AA5 RID: 15013 RVA: 0x00048738 File Offset: 0x00046938
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

	// Token: 0x06003AA6 RID: 15014 RVA: 0x000487D4 File Offset: 0x000469D4
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(true);
			return;
		}
		if (this.TsFlowListName == "")
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.YJX;
			string message2 = "[TsTaskPlayBubble]无效的FlowListName";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(true);
			return;
		}
		CharacterActorComponent charActorComp = ((TsAiController)ownerController).AiController.CharActorComp;
		if (charActorComp == null)
		{
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.YJX;
			string message3 = "[TsTaskPlayBubble]无效的ActorComp";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			base.FinishExecute(true);
			return;
		}
		IBubbleIndex flowIndex = new IBubbleIndex
		{
			FlowListName = this.TsFlowListName,
			FlowId = this.TsFlowId,
			StateId = new int?(this.TsStateId)
		};
		long creatureDataId = charActorComp.CreatureData.GetCreatureDataId();
		CharacterDynamicFlowData data = this.CreateCharacterFlowData(creatureDataId, flowIndex);
		ControllerBase<DynamicFlowController>.Instance.AddDynamicFlow(data);
		base.FinishExecute(true);
	}

	// Token: 0x06003AA7 RID: 15015 RVA: 0x00048924 File Offset: 0x00046B24
	private CharacterDynamicFlowData CreateCharacterFlowData(long creatureId, IFlowIndex flowIndex)
	{
		CharacterDynamicFlowData characterDynamicFlowData = new CharacterDynamicFlowData();
		AddPlayBubble bubbleData = new AddPlayBubble
		{
			EntityIds = new List<int>(),
			Flow = (IBubbleIndex)flowIndex,
			WaitTime = new int?(0),
			RedDot = new bool?(false)
		};
		DynamicFlowActorInfo masterInfo = new DynamicFlowActorInfo();
		masterInfo.CreatureId = creatureId;
		characterDynamicFlowData.MasterInfo = masterInfo;
		characterDynamicFlowData.BubbleData = bubbleData;
		characterDynamicFlowData.Callback = delegate()
		{
			ControllerBase<DynamicFlowController>.Instance.RemoveDynamicFlow(masterInfo);
		};
		return characterDynamicFlowData;
	}

	// Token: 0x06003AA8 RID: 15016 RVA: 0x000489AD File Offset: 0x00046BAD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPlayBubble._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPlayBubble.TsTaskPlayBubble_C");
		}
		return TsTaskPlayBubble._ClassPtr;
	}

	// Token: 0x06003AA9 RID: 15017 RVA: 0x000489D4 File Offset: 0x00046BD4
	public TsTaskPlayBubble() : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayBubble.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003AAA RID: 15018 RVA: 0x000489FC File Offset: 0x00046BFC
	public TsTaskPlayBubble(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayBubble.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003AAB RID: 15019 RVA: 0x00048A2F File Offset: 0x00046C2F
	protected TsTaskPlayBubble(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003AAC RID: 15020 RVA: 0x00048A44 File Offset: 0x00046C44
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000A1C RID: 2588
	private bool IsInitTsVariables;

	// Token: 0x04000A1D RID: 2589
	private string TsFlowListName = "";

	// Token: 0x04000A1E RID: 2590
	private int TsFlowId;

	// Token: 0x04000A1F RID: 2591
	private int TsStateId;

	// Token: 0x04000A20 RID: 2592
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPlayBubble.TsTaskPlayBubble_C";

	// Token: 0x04000A21 RID: 2593
	private static IntPtr _ClassPtr;

	// Token: 0x04000A22 RID: 2594
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A23 RID: 2595
	private static int __PropertyOffset_FlowListName;

	// Token: 0x04000A24 RID: 2596
	private static int __PropertyOffset_FlowId;

	// Token: 0x04000A25 RID: 2597
	private static int __PropertyOffset_StateId;
}
