using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CAB RID: 3243
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeSkillWeight.TsTaskChangeSkillWeight_C")]
public class TsTaskChangeSkillWeight : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000200 RID: 512
	// (get) Token: 0x06003CED RID: 15597 RVA: 0x00054E35 File Offset: 0x00053035
	// (set) Token: 0x06003CEE RID: 15598 RVA: 0x00054E45 File Offset: 0x00053045
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillInfoId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskChangeSkillWeight.__PropertyOffset_SkillInfoId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskChangeSkillWeight.__PropertyOffset_SkillInfoId) = value;
		}
	}

	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06003CEF RID: 15599 RVA: 0x00054E56 File Offset: 0x00053056
	// (set) Token: 0x06003CF0 RID: 15600 RVA: 0x00054E66 File Offset: 0x00053066
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Weight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskChangeSkillWeight.__PropertyOffset_Weight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskChangeSkillWeight.__PropertyOffset_Weight) = value;
		}
	}

	// Token: 0x06003CF1 RID: 15601 RVA: 0x00054E77 File Offset: 0x00053077
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsSkillInfoId = this.SkillInfoId;
			this.TsWeight = this.Weight;
		}
	}

	// Token: 0x06003CF2 RID: 15602 RVA: 0x00054EA8 File Offset: 0x000530A8
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

	// Token: 0x06003CF3 RID: 15603 RVA: 0x00054F48 File Offset: 0x00053148
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
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
		if (aiController.AiSkill == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "没有技能信息";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		aiController.AiSkill.ChangeSkillWeight(this.TsSkillInfoId, this.TsWeight);
		base.FinishExecute(true);
	}

	// Token: 0x06003CF4 RID: 15604 RVA: 0x00055018 File Offset: 0x00053218
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskChangeSkillWeight._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeSkillWeight.TsTaskChangeSkillWeight_C");
		}
		return TsTaskChangeSkillWeight._ClassPtr;
	}

	// Token: 0x06003CF5 RID: 15605 RVA: 0x0005503C File Offset: 0x0005323C
	public TsTaskChangeSkillWeight() : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeSkillWeight.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003CF6 RID: 15606 RVA: 0x00055064 File Offset: 0x00053264
	[NullableContext(1)]
	public TsTaskChangeSkillWeight(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeSkillWeight.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003CF7 RID: 15607 RVA: 0x00055097 File Offset: 0x00053297
	protected TsTaskChangeSkillWeight(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003CF8 RID: 15608 RVA: 0x000550A0 File Offset: 0x000532A0
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000BE4 RID: 3044
	private bool IsInitTsVariables;

	// Token: 0x04000BE5 RID: 3045
	private int TsSkillInfoId;

	// Token: 0x04000BE6 RID: 3046
	private float TsWeight;

	// Token: 0x04000BE7 RID: 3047
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeSkillWeight.TsTaskChangeSkillWeight_C";

	// Token: 0x04000BE8 RID: 3048
	private static IntPtr _ClassPtr;

	// Token: 0x04000BE9 RID: 3049
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BEA RID: 3050
	private static int __PropertyOffset_SkillInfoId;

	// Token: 0x04000BEB RID: 3051
	private static int __PropertyOffset_Weight;
}
