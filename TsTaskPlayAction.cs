using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.World.Controller;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC5 RID: 3269
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayAction.TsTaskPlayAction_C")]
public class TsTaskPlayAction : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000284 RID: 644
	// (get) Token: 0x06003F28 RID: 16168 RVA: 0x00061071 File Offset: 0x0005F271
	// (set) Token: 0x06003F29 RID: 16169 RVA: 0x00061085 File Offset: 0x0005F285
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string MontageName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayAction.__PropertyOffset_MontageName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayAction.__PropertyOffset_MontageName)), value);
		}
	}

	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06003F2A RID: 16170 RVA: 0x0006109A File Offset: 0x0005F29A
	// (set) Token: 0x06003F2B RID: 16171 RVA: 0x000610AA File Offset: 0x0005F2AA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int LoopTimeMillisecond
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayAction.__PropertyOffset_LoopTimeMillisecond);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayAction.__PropertyOffset_LoopTimeMillisecond) = value;
		}
	}

	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06003F2C RID: 16172 RVA: 0x000610BB File Offset: 0x0005F2BB
	// (set) Token: 0x06003F2D RID: 16173 RVA: 0x000610CF File Offset: 0x0005F2CF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyTime
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayAction.__PropertyOffset_BlackboardKeyTime)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayAction.__PropertyOffset_BlackboardKeyTime)), value);
		}
	}

	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06003F2E RID: 16174 RVA: 0x000610E4 File Offset: 0x0005F2E4
	// (set) Token: 0x06003F2F RID: 16175 RVA: 0x000610F4 File Offset: 0x0005F2F4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool MaskInteract
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayAction.__PropertyOffset_MaskInteract) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayAction.__PropertyOffset_MaskInteract) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003F30 RID: 16176 RVA: 0x00061108 File Offset: 0x0005F308
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMontageName = this.MontageName;
			this.TsLoopTimeMillisecond = this.LoopTimeMillisecond;
			this.TsBlackboardKeyTime = this.BlackboardKeyTime;
			this.TsMaskInteract = this.MaskInteract;
		}
	}

	// Token: 0x06003F31 RID: 16177 RVA: 0x0006115C File Offset: 0x0005F35C
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

	// Token: 0x06003F32 RID: 16178 RVA: 0x000611F8 File Offset: 0x0005F3F8
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		bool log = ControllerBase<ServerGmController>.Instance.AnimalDebug;
		if (log)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "AnimalDebug PlayAction";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Tree", base.TreeAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("aiController", aiController != null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("aiComp", ((aiController != null) ? aiController.CharAiDesignComp : null) != null);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item = "SelfId";
			int? num;
			if (aiController == null)
			{
				num = null;
			}
			else
			{
				CharacterActorComponent charActorComp = aiController.CharActorComp;
				num = ((charActorComp != null) ? new int?(charActorComp.Entity.Id) : null);
			}
			ptr = new ValueTuple<string, object>(item, num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		if (aiController == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		if (this.OnMontageEnded == null)
		{
			this.OnMontageEnded = delegate(UAnimMontage montage, bool interrupted)
			{
				this.EndTime = Singleton<Time>.Instance.WorldTime;
			};
		}
		Entity entity = aiController.CharActorComp.Entity;
		int time = this.TsLoopTimeMillisecond;
		if (!string.IsNullOrEmpty(this.TsBlackboardKeyTime))
		{
			int valueOrDefault = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(entity.Id, this.TsBlackboardKeyTime).GetValueOrDefault();
			if (valueOrDefault != 0)
			{
				time = valueOrDefault;
			}
		}
		string text = this.TsMontageName;
		string stringValueByEntity = ControllerBase<BlackboardController>.Instance.GetStringValueByEntity(entity.Id, "TargetMontageName");
		if (!string.IsNullOrEmpty(stringValueByEntity))
		{
			text = stringValueByEntity;
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(entity.Id, "TargetMontageName");
		}
		if (log)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.AI;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "AnimalDebug PlayAction2";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TsLoopTimeMillisecond", this.TsLoopTimeMillisecond);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("time", time);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("TsMontageName", this.TsMontageName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("spMontageName", stringValueByEntity);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("montageName", text);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
		}
		this.InteractComponent = entity.GetComponent<PawnInteractNewComponent>();
		if (this.TsMaskInteract && this.InteractComponent != null)
		{
			this.InteractComponent.SetInteractionState(false, "TsTaskPlayAction ReceiveExecuteAI");
		}
		this.EndTime = (double)time + Singleton<Time>.Instance.WorldTime;
		this.AnimComp = entity.GetComponent<CharacterAnimationComponent>();
		if (this.AnimComp != null)
		{
			string montageResPathByName = this.AnimComp.GetMontageResPathByName(text);
			if (log)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.AI;
				ELogAuthor author4 = ELogAuthor.LCZ;
				string message4 = "AnimalDebug PlayAction3";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("montageResPath", montageResPathByName);
				instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			if (montageResPathByName != null && montageResPathByName.Contains("/"))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(montageResPathByName, delegate([Nullable(2)] UAnimMontage montageAsset, string _)
				{
					if (log)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.AI;
						ELogAuthor author5 = ELogAuthor.LCZ;
						string message5 = "AnimalDebug PlayAction4";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("montageAsset", montageAsset);
						ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
						string item2 = "MainAnimInstance";
						CharacterAnimationComponent animComp = this.AnimComp;
						ptr2 = new ValueTuple<string, object>(item2, (animComp != null) ? animComp.MainAnimInstance : null);
						instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
					}
					if (ObjectUtils.IsValid(montageAsset))
					{
						CharacterAnimationComponent animComp2 = this.AnimComp;
						if (((animComp2 != null) ? animComp2.MainAnimInstance : null) != null)
						{
							if (time == 0)
							{
								this.EndTime = 60000.0 + Singleton<Time>.Instance.WorldTime;
								if (this.OnMontageEnded != null)
								{
									this.AnimComp.MainAnimInstance.OnMontageEnded.Add(this.OnMontageEnded);
								}
							}
							this.AnimComp.MainAnimInstance.Montage_Play(montageAsset, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
						}
					}
				}, 100, "js_undefined");
			}
		}
	}

	// Token: 0x06003F33 RID: 16179 RVA: 0x00061594 File Offset: 0x0005F794
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

	// Token: 0x06003F34 RID: 16180 RVA: 0x00061634 File Offset: 0x0005F834
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.EndTime < Singleton<Time>.Instance.WorldTime)
		{
			if (this.TsMaskInteract && this.InteractComponent != null)
			{
				this.InteractComponent.SetInteractionState(true, "TsTaskPlayAction ReceiveTickAI");
			}
			base.Finish(true);
		}
	}

	// Token: 0x06003F35 RID: 16181 RVA: 0x00061670 File Offset: 0x0005F870
	protected override void OnClear()
	{
		this.EndTime = 0.0;
		if (this.AnimComp != null)
		{
			if (this.AnimComp.MainAnimInstance != null && this.OnMontageEnded != null)
			{
				this.AnimComp.MainAnimInstance.OnMontageEnded.Remove(this.OnMontageEnded);
			}
			this.AnimComp = null;
		}
	}

	// Token: 0x06003F36 RID: 16182 RVA: 0x000616CB File Offset: 0x0005F8CB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPlayAction._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayAction.TsTaskPlayAction_C");
		}
		return TsTaskPlayAction._ClassPtr;
	}

	// Token: 0x06003F37 RID: 16183 RVA: 0x000616F0 File Offset: 0x0005F8F0
	public TsTaskPlayAction() : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayAction.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003F38 RID: 16184 RVA: 0x00061718 File Offset: 0x0005F918
	public TsTaskPlayAction(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayAction.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003F39 RID: 16185 RVA: 0x0006174B File Offset: 0x0005F94B
	protected TsTaskPlayAction(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003F3A RID: 16186 RVA: 0x0006176C File Offset: 0x0005F96C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003F3B RID: 16187 RVA: 0x0006179C File Offset: 0x0005F99C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000DF1 RID: 3569
	private const int DEFAULT_FINISHED_TIME = 60000;

	// Token: 0x04000DF2 RID: 3570
	private bool IsInitTsVariables;

	// Token: 0x04000DF3 RID: 3571
	private string TsMontageName = "";

	// Token: 0x04000DF4 RID: 3572
	private int TsLoopTimeMillisecond;

	// Token: 0x04000DF5 RID: 3573
	private string TsBlackboardKeyTime = "";

	// Token: 0x04000DF6 RID: 3574
	private bool TsMaskInteract;

	// Token: 0x04000DF7 RID: 3575
	private double EndTime;

	// Token: 0x04000DF8 RID: 3576
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x04000DF9 RID: 3577
	[Nullable(2)]
	private PawnInteractNewComponent InteractComponent;

	// Token: 0x04000DFA RID: 3578
	[Nullable(2)]
	private Action<UAnimMontage, bool> OnMontageEnded;

	// Token: 0x04000DFB RID: 3579
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayAction.TsTaskPlayAction_C";

	// Token: 0x04000DFC RID: 3580
	private static IntPtr _ClassPtr;

	// Token: 0x04000DFD RID: 3581
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000DFE RID: 3582
	private static int __PropertyOffset_MontageName;

	// Token: 0x04000DFF RID: 3583
	private static int __PropertyOffset_LoopTimeMillisecond;

	// Token: 0x04000E00 RID: 3584
	private static int __PropertyOffset_BlackboardKeyTime;

	// Token: 0x04000E01 RID: 3585
	private static int __PropertyOffset_MaskInteract;
}
