using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB6 RID: 3254
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindRandomPosition.TsTaskFindRandomPosition_C")]
public class TsTaskFindRandomPosition : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000233 RID: 563
	// (get) Token: 0x06003DC4 RID: 15812 RVA: 0x000592B1 File Offset: 0x000574B1
	// (set) Token: 0x06003DC5 RID: 15813 RVA: 0x000592C5 File Offset: 0x000574C5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector StartPositionOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_StartPositionOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_StartPositionOffset) = value;
		}
	}

	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06003DC6 RID: 15814 RVA: 0x000592DA File Offset: 0x000574DA
	// (set) Token: 0x06003DC7 RID: 15815 RVA: 0x000592EA File Offset: 0x000574EA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_MinRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_MinRange) = value;
		}
	}

	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06003DC8 RID: 15816 RVA: 0x000592FB File Offset: 0x000574FB
	// (set) Token: 0x06003DC9 RID: 15817 RVA: 0x0005930B File Offset: 0x0005750B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_MaxRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_MaxRange) = value;
		}
	}

	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06003DCA RID: 15818 RVA: 0x0005931C File Offset: 0x0005751C
	// (set) Token: 0x06003DCB RID: 15819 RVA: 0x0005932C File Offset: 0x0005752C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseFullRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_UseFullRange) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindRandomPosition.__PropertyOffset_UseFullRange) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000237 RID: 567
	// (get) Token: 0x06003DCC RID: 15820 RVA: 0x0005933D File Offset: 0x0005753D
	// (set) Token: 0x06003DCD RID: 15821 RVA: 0x00059351 File Offset: 0x00057551
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string SaveBlackBoardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindRandomPosition.__PropertyOffset_SaveBlackBoardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindRandomPosition.__PropertyOffset_SaveBlackBoardKey)), value);
		}
	}

	// Token: 0x06003DCE RID: 15822 RVA: 0x00059368 File Offset: 0x00057568
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsStartPositionOffset = Vector.Create(this.StartPositionOffset);
			this.TsMinRange = this.MinRange;
			this.TsMaxRange = this.MaxRange;
			this.TsUseFullRange = this.UseFullRange;
			this.TsSaveBlackBoardKey = this.SaveBlackBoardKey;
		}
	}

	// Token: 0x06003DCF RID: 15823 RVA: 0x000593D4 File Offset: 0x000575D4
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

	// Token: 0x06003DD0 RID: 15824 RVA: 0x00059470 File Offset: 0x00057670
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
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (!string.IsNullOrEmpty(this.TsSaveBlackBoardKey))
		{
			Vector vector = this.CalculateTargetPosition(charActorComp);
			ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(charActorComp.Entity.Id, this.TsSaveBlackBoardKey, (double)((float)vector.X), (double)((float)vector.Y), (double)((float)vector.Z));
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003DD1 RID: 15825 RVA: 0x00059530 File Offset: 0x00057730
	private Vector CalculateTargetPosition(CharacterActorComponent actorComp)
	{
		Vector actorLocationProxy = actorComp.ActorLocationProxy;
		IVector actorForwardProxy = actorComp.ActorForwardProxy;
		float randomFloatNumber = Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, 360f);
		Vector vector = Vector.Create(actorForwardProxy);
		vector.RotateAngleAxis((double)randomFloatNumber, Vector.UpVectorProxy, vector);
		Vector vector2 = Vector.Create(this.TsStartPositionOffset);
		vector2.AdditionEqual(actorLocationProxy);
		Vector inB = vector.MultiplyEqual((double)(this.TsUseFullRange ? this.TsMaxRange : Singleton<MathUtils>.Instance.GetRandomFloatNumber(this.TsMinRange, this.TsMaxRange)));
		return vector2.AdditionEqual(inB);
	}

	// Token: 0x06003DD2 RID: 15826 RVA: 0x000595BA File Offset: 0x000577BA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFindRandomPosition._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindRandomPosition.TsTaskFindRandomPosition_C");
		}
		return TsTaskFindRandomPosition._ClassPtr;
	}

	// Token: 0x06003DD3 RID: 15827 RVA: 0x000595E0 File Offset: 0x000577E0
	public TsTaskFindRandomPosition() : this(BuiltinUtils.AllocNativeUObject(TsTaskFindRandomPosition.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003DD4 RID: 15828 RVA: 0x00059608 File Offset: 0x00057808
	public TsTaskFindRandomPosition(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindRandomPosition.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003DD5 RID: 15829 RVA: 0x0005963B File Offset: 0x0005783B
	protected TsTaskFindRandomPosition(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003DD6 RID: 15830 RVA: 0x00059650 File Offset: 0x00057850
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000CAE RID: 3246
	private const float PI_DEG_DOUBLE = 360f;

	// Token: 0x04000CAF RID: 3247
	private bool IsInitTsVariables;

	// Token: 0x04000CB0 RID: 3248
	[Nullable(2)]
	private Vector TsStartPositionOffset;

	// Token: 0x04000CB1 RID: 3249
	private float TsMinRange;

	// Token: 0x04000CB2 RID: 3250
	private float TsMaxRange;

	// Token: 0x04000CB3 RID: 3251
	private bool TsUseFullRange;

	// Token: 0x04000CB4 RID: 3252
	private string TsSaveBlackBoardKey = "";

	// Token: 0x04000CB5 RID: 3253
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindRandomPosition.TsTaskFindRandomPosition_C";

	// Token: 0x04000CB6 RID: 3254
	private static IntPtr _ClassPtr;

	// Token: 0x04000CB7 RID: 3255
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000CB8 RID: 3256
	private static int __PropertyOffset_StartPositionOffset;

	// Token: 0x04000CB9 RID: 3257
	private static int __PropertyOffset_MinRange;

	// Token: 0x04000CBA RID: 3258
	private static int __PropertyOffset_MaxRange;

	// Token: 0x04000CBB RID: 3259
	private static int __PropertyOffset_UseFullRange;

	// Token: 0x04000CBC RID: 3260
	private static int __PropertyOffset_SaveBlackBoardKey;
}
