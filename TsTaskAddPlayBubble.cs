using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C7C RID: 3196
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskAddPlayBubble.TsTaskAddPlayBubble_C")]
public class TsTaskAddPlayBubble : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000176 RID: 374
	// (get) Token: 0x060039A4 RID: 14756 RVA: 0x00043EFD File Offset: 0x000420FD
	// (set) Token: 0x060039A5 RID: 14757 RVA: 0x00043F11 File Offset: 0x00042111
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FlowListName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAddPlayBubble.__PropertyOffset_FlowListName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAddPlayBubble.__PropertyOffset_FlowListName)), value);
		}
	}

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x060039A6 RID: 14758 RVA: 0x00043F26 File Offset: 0x00042126
	// (set) Token: 0x060039A7 RID: 14759 RVA: 0x00043F36 File Offset: 0x00042136
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FlowId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_FlowId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_FlowId) = value;
		}
	}

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x060039A8 RID: 14760 RVA: 0x00043F47 File Offset: 0x00042147
	// (set) Token: 0x060039A9 RID: 14761 RVA: 0x00043F57 File Offset: 0x00042157
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float StateId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_StateId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_StateId) = value;
		}
	}

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x060039AA RID: 14762 RVA: 0x00043F68 File Offset: 0x00042168
	// (set) Token: 0x060039AB RID: 14763 RVA: 0x00043FA1 File Offset: 0x000421A1
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> PbDataIds
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._PbDataIds) == null)
			{
				result = (this._PbDataIds = new TArray<int>(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_PbDataIds, this));
			}
			return result;
		}
		set
		{
			this.PbDataIds.CopyAssign(value);
		}
	}

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x060039AC RID: 14764 RVA: 0x00043FAF File Offset: 0x000421AF
	// (set) Token: 0x060039AD RID: 14765 RVA: 0x00043FBF File Offset: 0x000421BF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EnterRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_EnterRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_EnterRadius) = value;
		}
	}

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x060039AE RID: 14766 RVA: 0x00043FD0 File Offset: 0x000421D0
	// (set) Token: 0x060039AF RID: 14767 RVA: 0x00043FE0 File Offset: 0x000421E0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LeaveRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_LeaveRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_LeaveRadius) = value;
		}
	}

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x060039B0 RID: 14768 RVA: 0x00043FF1 File Offset: 0x000421F1
	// (set) Token: 0x060039B1 RID: 14769 RVA: 0x00044001 File Offset: 0x00042201
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EnterHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_EnterHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_EnterHeight) = value;
		}
	}

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x060039B2 RID: 14770 RVA: 0x00044012 File Offset: 0x00042212
	// (set) Token: 0x060039B3 RID: 14771 RVA: 0x00044022 File Offset: 0x00042222
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LeaveHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_LeaveHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddPlayBubble.__PropertyOffset_LeaveHeight) = value;
		}
	}

	// Token: 0x060039B4 RID: 14772 RVA: 0x00044034 File Offset: 0x00042234
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsFlowListName = this.FlowListName;
			this.TsFlowId = this.FlowId;
			this.TsStateId = this.StateId;
			this.TsEnterRadius = this.EnterRadius;
			this.TsLeaveRadius = this.LeaveRadius;
			this.TsEnterHeight = this.EnterHeight;
			this.TsLeaveHeight = this.LeaveHeight;
			this.TsPbDataIds.Clear();
			TArray<int> pbDataIds = this.PbDataIds;
			int num = (pbDataIds != null) ? pbDataIds.Num() : 0;
			for (int i = 0; i < num; i++)
			{
				int item = this.PbDataIds.Get(i);
				this.TsPbDataIds.Add(item);
			}
		}
	}

	// Token: 0x060039B5 RID: 14773 RVA: 0x000440F4 File Offset: 0x000422F4
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

	// Token: 0x060039B6 RID: 14774 RVA: 0x00044190 File Offset: 0x00042390
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		if (this.TsPbDataIds.Count == 0)
		{
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
		int pbDataId = charActorComp.CreatureData.GetPbDataId();
		List<int> list = new List<int>
		{
			pbDataId
		};
		bool flag = false;
		foreach (int num in this.TsPbDataIds)
		{
			if (num == pbDataId)
			{
				flag = true;
			}
			else
			{
				list.Add(num);
			}
		}
		if (!flag)
		{
			global::Log instance4 = Singleton<global::Log>.Instance;
			ELogModule module4 = ELogModule.LevelAi;
			ELogAuthor author4 = ELogAuthor.YJX;
			string message4 = "禁止添加非自身参与的多人冒泡";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowName", this.TsFlowListName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowId", this.TsFlowId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("StateId", this.TsStateId);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			base.FinishExecute(true);
			return;
		}
		CharacterDynamicFlowData data = this.CreateCharacterFlowData();
		ControllerBase<DynamicFlowController>.Instance.AddDynamicFlow(data);
		base.FinishExecute(true);
	}

	// Token: 0x060039B7 RID: 14775 RVA: 0x000443D4 File Offset: 0x000425D4
	private CharacterDynamicFlowData CreateCharacterFlowData()
	{
		List<int> list = new List<int>(this.TsPbDataIds);
		CharacterDynamicFlowData characterDynamicFlowData = new CharacterDynamicFlowData();
		IFlowIndex flowIndex = new IBubbleIndex
		{
			FlowListName = this.TsFlowListName,
			FlowId = this.TsFlowId,
			StateId = new int?((int)this.TsStateId)
		};
		IBubbleCylinderConfig innerConfig = new IBubbleCylinderConfig
		{
			Radius = this.TsEnterRadius,
			Height = this.TsEnterHeight
		};
		IBubbleCylinderConfig outerConfig = new IBubbleCylinderConfig
		{
			Radius = this.TsLeaveRadius,
			Height = this.TsLeaveHeight
		};
		IBubbleRangeCylinderConfig bubbleRangeCylinderConfig = new IBubbleRangeCylinderConfig
		{
			InnerConfig = innerConfig,
			OuterConfig = outerConfig
		};
		AddPlayBubble bubbleData = new AddPlayBubble
		{
			EntityIds = list,
			EnterRadius = ((this.TsEnterRadius != 0f) ? new float?(this.TsEnterRadius) : null),
			LeaveRadius = ((this.TsLeaveRadius != 0f) ? new float?(this.TsLeaveRadius) : null),
			TriggerCylinderConfig = ((this.TsLeaveHeight != 0f) ? bubbleRangeCylinderConfig : null),
			Flow = (IBubbleIndex)flowIndex,
			WaitTime = new int?(0),
			RedDot = new bool?(false)
		};
		characterDynamicFlowData.MasterInfo = new DynamicFlowActorInfo
		{
			PbDataId = list[0]
		};
		characterDynamicFlowData.BubbleData = bubbleData;
		characterDynamicFlowData.Type = new EDynamicFlowType?(EDynamicFlowType.LevelAi);
		return characterDynamicFlowData;
	}

	// Token: 0x060039B8 RID: 14776 RVA: 0x00044542 File Offset: 0x00042742
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAddPlayBubble._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskAddPlayBubble.TsTaskAddPlayBubble_C");
		}
		return TsTaskAddPlayBubble._ClassPtr;
	}

	// Token: 0x060039B9 RID: 14777 RVA: 0x00044568 File Offset: 0x00042768
	public TsTaskAddPlayBubble() : this(BuiltinUtils.AllocNativeUObject(TsTaskAddPlayBubble.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060039BA RID: 14778 RVA: 0x00044590 File Offset: 0x00042790
	public TsTaskAddPlayBubble(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAddPlayBubble.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060039BB RID: 14779 RVA: 0x000445C3 File Offset: 0x000427C3
	protected TsTaskAddPlayBubble(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060039BC RID: 14780 RVA: 0x000445E4 File Offset: 0x000427E4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000951 RID: 2385
	private bool IsInitTsVariables;

	// Token: 0x04000952 RID: 2386
	private string TsFlowListName = "";

	// Token: 0x04000953 RID: 2387
	private int TsFlowId;

	// Token: 0x04000954 RID: 2388
	private float TsStateId;

	// Token: 0x04000955 RID: 2389
	private readonly List<int> TsPbDataIds = new List<int>();

	// Token: 0x04000956 RID: 2390
	private float TsEnterRadius;

	// Token: 0x04000957 RID: 2391
	private float TsLeaveRadius;

	// Token: 0x04000958 RID: 2392
	protected float TsEnterHeight;

	// Token: 0x04000959 RID: 2393
	protected float TsLeaveHeight;

	// Token: 0x0400095A RID: 2394
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskAddPlayBubble.TsTaskAddPlayBubble_C";

	// Token: 0x0400095B RID: 2395
	private static IntPtr _ClassPtr;

	// Token: 0x0400095C RID: 2396
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400095D RID: 2397
	private static int __PropertyOffset_FlowListName;

	// Token: 0x0400095E RID: 2398
	private static int __PropertyOffset_FlowId;

	// Token: 0x0400095F RID: 2399
	private static int __PropertyOffset_StateId;

	// Token: 0x04000960 RID: 2400
	private static int __PropertyOffset_PbDataIds;

	// Token: 0x04000961 RID: 2401
	[Nullable(2)]
	private TArray<int> _PbDataIds;

	// Token: 0x04000962 RID: 2402
	private static int __PropertyOffset_EnterRadius;

	// Token: 0x04000963 RID: 2403
	private static int __PropertyOffset_LeaveRadius;

	// Token: 0x04000964 RID: 2404
	private static int __PropertyOffset_EnterHeight;

	// Token: 0x04000965 RID: 2405
	private static int __PropertyOffset_LeaveHeight;
}
