using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C94 RID: 3220
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcPlayFlow.TsTaskNpcPlayFlow_C")]
public class TsTaskNpcPlayFlow : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001CB RID: 459
	// (get) Token: 0x06003B79 RID: 15225 RVA: 0x0004D875 File Offset: 0x0004BA75
	// (set) Token: 0x06003B7A RID: 15226 RVA: 0x0004D889 File Offset: 0x0004BA89
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FlowListName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcPlayFlow.__PropertyOffset_FlowListName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcPlayFlow.__PropertyOffset_FlowListName)), value);
		}
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x06003B7B RID: 15227 RVA: 0x0004D89E File Offset: 0x0004BA9E
	// (set) Token: 0x06003B7C RID: 15228 RVA: 0x0004D8B2 File Offset: 0x0004BAB2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FlowSubTitle
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcPlayFlow.__PropertyOffset_FlowSubTitle)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcPlayFlow.__PropertyOffset_FlowSubTitle)), value);
		}
	}

	// Token: 0x06003B7D RID: 15229 RVA: 0x0004D8C7 File Offset: 0x0004BAC7
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsFlowListName = this.FlowListName;
			this.TsFlowSubTitle = this.FlowSubTitle;
		}
	}

	// Token: 0x06003B7E RID: 15230 RVA: 0x0004D8F8 File Offset: 0x0004BAF8
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

	// Token: 0x06003B7F RID: 15231 RVA: 0x0004D994 File Offset: 0x0004BB94
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			base.FinishExecute(false);
			return;
		}
		if (string.IsNullOrEmpty(this.TsFlowListName) || string.IsNullOrEmpty(this.TsFlowSubTitle))
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = ((TsAiController)ownerController).AiController.CharActorComp;
		if (charActorComp == null)
		{
			base.FinishExecute(false);
			return;
		}
		this.Reset();
		this.HeadInfoComp = charActorComp.Entity.GetComponent<PawnHeadInfoComponent>();
		this.AnimComp = charActorComp.Entity.GetComponent<CharacterAnimationComponent>();
		this.PerformComp = charActorComp.Entity.GetComponent<BasePerformComponent>();
		if (!this.HandlePlayFlow())
		{
			base.Finish(false);
			return;
		}
		this.HandleFlowAction(0);
	}

	// Token: 0x06003B80 RID: 15232 RVA: 0x0004DA48 File Offset: 0x0004BC48
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

	// Token: 0x06003B81 RID: 15233 RVA: 0x0004DAE8 File Offset: 0x0004BCE8
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.FlowEnd)
		{
			base.Finish(true);
			return;
		}
		if (this.TimeRemain > 0f)
		{
			this.TimeRemain -= deltaSeconds;
			if (this.TimeRemain < 0f)
			{
				this.HandleFlowAction(this.TempFlowIndex + 1);
			}
		}
	}

	// Token: 0x06003B82 RID: 15234 RVA: 0x0004DB3C File Offset: 0x0004BD3C
	private bool HandlePlayFlow()
	{
		int flowId;
		if (!int.TryParse(this.TsFlowSubTitle, out flowId))
		{
			flowId = 0;
		}
		ShowTalk randomFlow = ConfigBase<FlowConfig>.Instance.GetRandomFlow(this.TsFlowListName, flowId, null, null);
		if (randomFlow != null)
		{
			this.TempTalkItems = randomFlow.TalkItems;
			return true;
		}
		return false;
	}

	// Token: 0x06003B83 RID: 15235 RVA: 0x0004DB88 File Offset: 0x0004BD88
	private void HandleFlowAction(int index)
	{
		this.TempFlowIndex = index;
		List<ITalkItem> tempTalkItems = this.TempTalkItems;
		if (tempTalkItems.Count <= index)
		{
			this.FlowEnd = true;
			return;
		}
		ITalkItem talkItem = tempTalkItems[index];
		if (this.ExecuteNpcFlow(talkItem))
		{
			this.FlowEnd = false;
			this.TimeRemain = ((talkItem.WaitTime != null && talkItem.WaitTime.Value > 0f) ? talkItem.WaitTime.Value : 3f);
			return;
		}
		this.HandleFlowAction(index + 1);
	}

	// Token: 0x06003B84 RID: 15236 RVA: 0x0004DC18 File Offset: 0x0004BE18
	private bool ExecuteNpcFlow(ITalkItem config)
	{
		bool result = false;
		string flowText = this.GetFlowText(config.TidTalk);
		if (!string.IsNullOrEmpty(flowText))
		{
			result = true;
			if (this.HeadInfoComp != null)
			{
				this.HeadInfoComp.SetDialogueText(flowText, -1f, false);
			}
		}
		if (this.AnimComp != null)
		{
			if (config.Montage != null)
			{
				result = true;
				string path = config.Montage.ActionMontage.Path;
				Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(path, delegate([Nullable(2)] UAnimMontage montageObject, string _)
				{
					if (montageObject == null || !montageObject.IsValid())
					{
						return;
					}
					if (this.PerformComp != null)
					{
						this.PerformComp.PlayPerformMontage(EPerformMode.Ecology, new IPlayMontageParam
						{
							MontageAsset = montageObject
						}, null, null, false);
					}
				}, 100, "js_undefined");
			}
			else if (this.PerformComp != null)
			{
				this.PerformComp.StopPerformMontage(EPerformMode.Ecology, new IStopMontageParam
				{
					Method = new EStopMethod?(EStopMethod.BlendOut),
					BlendOutTime = new float?(0.1f)
				}, null, null);
			}
		}
		return result;
	}

	// Token: 0x06003B85 RID: 15237 RVA: 0x0004DCD6 File Offset: 0x0004BED6
	[NullableContext(2)]
	private string GetFlowText(string textId)
	{
		if (!string.IsNullOrEmpty(textId) && !StringUtils.IsEmpty(textId))
		{
			return ConfigMultiTextLang.GetLocalTextNew(textId, null);
		}
		return null;
	}

	// Token: 0x06003B86 RID: 15238 RVA: 0x0004DCF1 File Offset: 0x0004BEF1
	private void Reset()
	{
		this.TempTalkItems = null;
		this.TempFlowIndex = 0;
		this.TimeRemain = 0f;
		this.FlowEnd = true;
	}

	// Token: 0x06003B87 RID: 15239 RVA: 0x0004DD14 File Offset: 0x0004BF14
	protected override void OnClear()
	{
		this.Reset();
		if (this.HeadInfoComp != null)
		{
			this.HeadInfoComp.HideDialogueText();
			this.HeadInfoComp = null;
		}
		if (this.PerformComp != null)
		{
			this.PerformComp.StopPerformMontage(EPerformMode.Ecology, new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0.1f)
			}, null, null);
		}
	}

	// Token: 0x06003B88 RID: 15240 RVA: 0x0004DD79 File Offset: 0x0004BF79
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcPlayFlow._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcPlayFlow.TsTaskNpcPlayFlow_C");
		}
		return TsTaskNpcPlayFlow._ClassPtr;
	}

	// Token: 0x06003B89 RID: 15241 RVA: 0x0004DDA0 File Offset: 0x0004BFA0
	public TsTaskNpcPlayFlow() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcPlayFlow.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B8A RID: 15242 RVA: 0x0004DDC8 File Offset: 0x0004BFC8
	public TsTaskNpcPlayFlow(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcPlayFlow.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B8B RID: 15243 RVA: 0x0004DDFB File Offset: 0x0004BFFB
	protected TsTaskNpcPlayFlow(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B8C RID: 15244 RVA: 0x0004DE24 File Offset: 0x0004C024
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003B8D RID: 15245 RVA: 0x0004DE54 File Offset: 0x0004C054
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000AD4 RID: 2772
	private const float DEFAULT_WAIT_TIME = 3f;

	// Token: 0x04000AD5 RID: 2773
	private const float STOP_MONTAGE_BLEND_OUT_TIME = 0.1f;

	// Token: 0x04000AD6 RID: 2774
	private bool IsInitTsVariables;

	// Token: 0x04000AD7 RID: 2775
	private string TsFlowListName = "";

	// Token: 0x04000AD8 RID: 2776
	private string TsFlowSubTitle = "";

	// Token: 0x04000AD9 RID: 2777
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ITalkItem> TempTalkItems;

	// Token: 0x04000ADA RID: 2778
	private int TempFlowIndex;

	// Token: 0x04000ADB RID: 2779
	private float TimeRemain;

	// Token: 0x04000ADC RID: 2780
	private bool FlowEnd = true;

	// Token: 0x04000ADD RID: 2781
	[Nullable(2)]
	private PawnHeadInfoComponent HeadInfoComp;

	// Token: 0x04000ADE RID: 2782
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x04000ADF RID: 2783
	[Nullable(2)]
	private BasePerformComponent PerformComp;

	// Token: 0x04000AE0 RID: 2784
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcPlayFlow.TsTaskNpcPlayFlow_C";

	// Token: 0x04000AE1 RID: 2785
	private static IntPtr _ClassPtr;

	// Token: 0x04000AE2 RID: 2786
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000AE3 RID: 2787
	private static int __PropertyOffset_FlowListName;

	// Token: 0x04000AE4 RID: 2788
	private static int __PropertyOffset_FlowSubTitle;
}
