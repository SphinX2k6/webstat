using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE5 RID: 3301
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskUseSkillDesignated.TsTaskUseSkillDesignated_C")]
public class TsTaskUseSkillDesignated : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002FF RID: 767
	// (get) Token: 0x0600415F RID: 16735 RVA: 0x0006B65F File Offset: 0x0006985F
	// (set) Token: 0x06004160 RID: 16736 RVA: 0x0006B673 File Offset: 0x00069873
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyTarget
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskUseSkillDesignated.__PropertyOffset_BlackboardKeyTarget)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskUseSkillDesignated.__PropertyOffset_BlackboardKeyTarget)), value);
		}
	}

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x06004161 RID: 16737 RVA: 0x0006B688 File Offset: 0x00069888
	// (set) Token: 0x06004162 RID: 16738 RVA: 0x0006B698 File Offset: 0x00069898
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillInfoId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskUseSkillDesignated.__PropertyOffset_SkillInfoId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskUseSkillDesignated.__PropertyOffset_SkillInfoId) = value;
		}
	}

	// Token: 0x17000301 RID: 769
	// (get) Token: 0x06004163 RID: 16739 RVA: 0x0006B6A9 File Offset: 0x000698A9
	// (set) Token: 0x06004164 RID: 16740 RVA: 0x0006B6B9 File Offset: 0x000698B9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugLog
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskUseSkillDesignated.__PropertyOffset_DebugLog) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskUseSkillDesignated.__PropertyOffset_DebugLog) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004165 RID: 16741 RVA: 0x0006B6CA File Offset: 0x000698CA
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKeyTarget = this.BlackboardKeyTarget;
			this.TsSkillInfoId = this.SkillInfoId;
			this.TsDebugLog = this.DebugLog;
		}
	}

	// Token: 0x06004166 RID: 16742 RVA: 0x0006B708 File Offset: 0x00069908
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

	// Token: 0x06004167 RID: 16743 RVA: 0x0006B7A1 File Offset: 0x000699A1
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.WaitingSkill = false;
	}

	// Token: 0x06004168 RID: 16744 RVA: 0x0006B7AC File Offset: 0x000699AC
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

	// Token: 0x06004169 RID: 16745 RVA: 0x0006B84C File Offset: 0x00069A4C
	[NullableContext(2)]
	protected unsafe virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsTaskUseSkillDesignated.<>c__DisplayClass18_0 CS$<>8__locals1 = new TsTaskUseSkillDesignated.<>c__DisplayClass18_0();
		CS$<>8__locals1.<>4__this = this;
		TsTaskUseSkillDesignated.<>c__DisplayClass18_0 CS$<>8__locals2 = CS$<>8__locals1;
		TsAiController tsAiController = ownerController as TsAiController;
		CS$<>8__locals2.aiController = ((tsAiController != null) ? tsAiController.AiController : null);
		if (CS$<>8__locals1.aiController == null)
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
		if (CS$<>8__locals1.aiController.AiSkill == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "没有技能信息";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AiBaseId", CS$<>8__locals1.aiController.AiBase.Value.Id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables();
		if (this.TsDebugLog)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "UseSkillDesignated";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("controller", (ownerController != null) ? ownerController.GetName() : null);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		}
		AiSkillInfos aiSkillInfos;
		if (!CS$<>8__locals1.aiController.AiSkill.SkillInfos.TryGetValue(this.TsSkillInfoId, out aiSkillInfos))
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.BehaviorTree;
			ELogAuthor author4 = ELogAuthor.LCZ;
			string message4 = "当前AI没有对应的技能ID";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AiBaseId", CS$<>8__locals1.aiController.AiBase.Value.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkillInfoId", this.TsSkillInfoId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Tree", base.TreeAsset);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			base.FinishExecute(false);
			return;
		}
		EntityHandle entityHandle = CS$<>8__locals1.aiController.AiHateList.GetCurrentTarget();
		if (this.TsBlackboardKeyTarget != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(CS$<>8__locals1.aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyTarget);
			if (entityIdByEntity != null)
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityIdByEntity.Value);
				if (entityById != null)
				{
					entityHandle = entityById;
				}
			}
		}
		CharacterSkillComponent component = CS$<>8__locals1.aiController.CharAiDesignComp.Entity.GetComponent<CharacterSkillComponent>();
		if (!component.Valid)
		{
			if (this.TsDebugLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.BehaviorTree, ELogAuthor.LCZ, "UseSkillDesignated No SkillComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			base.FinishExecute(false);
			return;
		}
		if (this.TsDebugLog)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.BehaviorTree;
			ELogAuthor author5 = ELogAuthor.LCZ;
			string message5 = "UseSkillDesignated TrySkill";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("skill", aiSkillInfos.SkillId);
			instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		}
		if (this.WaitingSkill)
		{
			return;
		}
		this.WaitingSkill = true;
		component.BeginSkillAsync(int.Parse(aiSkillInfos.SkillId), new SkillParam
		{
			Target = ((entityHandle != null) ? entityHandle.Entity : null),
			Reason = "TsTaskUseSkillDesignated.ReceiveTickAI"
		}).ContinueWith(delegate(bool result)
		{
			CS$<>8__locals1.<>4__this.FinishExecute(result);
			if (result && CS$<>8__locals1.aiController.AiSkill != null)
			{
				CS$<>8__locals1.aiController.AiSkill.SetSkillCdFromNow(new int?(CS$<>8__locals1.<>4__this.TsSkillInfoId));
			}
		});
	}

	// Token: 0x0600416A RID: 16746 RVA: 0x0006BB5A File Offset: 0x00069D5A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskUseSkillDesignated._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskUseSkillDesignated.TsTaskUseSkillDesignated_C");
		}
		return TsTaskUseSkillDesignated._ClassPtr;
	}

	// Token: 0x0600416B RID: 16747 RVA: 0x0006BB80 File Offset: 0x00069D80
	public TsTaskUseSkillDesignated() : this(BuiltinUtils.AllocNativeUObject(TsTaskUseSkillDesignated.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600416C RID: 16748 RVA: 0x0006BBA8 File Offset: 0x00069DA8
	public TsTaskUseSkillDesignated(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskUseSkillDesignated.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600416D RID: 16749 RVA: 0x0006BBDB File Offset: 0x00069DDB
	protected TsTaskUseSkillDesignated(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600416E RID: 16750 RVA: 0x0006BBF0 File Offset: 0x00069DF0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600416F RID: 16751 RVA: 0x0006BC20 File Offset: 0x00069E20
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000FCD RID: 4045
	private bool IsInitTsVariables;

	// Token: 0x04000FCE RID: 4046
	private string TsBlackboardKeyTarget = "";

	// Token: 0x04000FCF RID: 4047
	private int TsSkillInfoId;

	// Token: 0x04000FD0 RID: 4048
	private bool TsDebugLog;

	// Token: 0x04000FD1 RID: 4049
	private bool WaitingSkill;

	// Token: 0x04000FD2 RID: 4050
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskUseSkillDesignated.TsTaskUseSkillDesignated_C";

	// Token: 0x04000FD3 RID: 4051
	private static IntPtr _ClassPtr;

	// Token: 0x04000FD4 RID: 4052
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000FD5 RID: 4053
	private static int __PropertyOffset_BlackboardKeyTarget;

	// Token: 0x04000FD6 RID: 4054
	private static int __PropertyOffset_SkillInfoId;

	// Token: 0x04000FD7 RID: 4055
	private static int __PropertyOffset_DebugLog;
}
