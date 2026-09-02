using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C41 RID: 3137
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorTimeSpanCheck.TsDecoratorTimeSpanCheck_C")]
public class TsDecoratorTimeSpanCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700010B RID: 267
	// (get) Token: 0x060036C7 RID: 14023 RVA: 0x00036B17 File Offset: 0x00034D17
	// (set) Token: 0x060036C8 RID: 14024 RVA: 0x00036B2B File Offset: 0x00034D2B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> CheckType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorTimeSpanCheck.__PropertyOffset_CheckType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorTimeSpanCheck.__PropertyOffset_CheckType) = value;
		}
	}

	// Token: 0x1700010C RID: 268
	// (get) Token: 0x060036C9 RID: 14025 RVA: 0x00036B40 File Offset: 0x00034D40
	// (set) Token: 0x060036CA RID: 14026 RVA: 0x00036B54 File Offset: 0x00034D54
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FTimecode StartTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorTimeSpanCheck.__PropertyOffset_StartTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorTimeSpanCheck.__PropertyOffset_StartTime) = value;
		}
	}

	// Token: 0x1700010D RID: 269
	// (get) Token: 0x060036CB RID: 14027 RVA: 0x00036B69 File Offset: 0x00034D69
	// (set) Token: 0x060036CC RID: 14028 RVA: 0x00036B7D File Offset: 0x00034D7D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FTimecode EndTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorTimeSpanCheck.__PropertyOffset_EndTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorTimeSpanCheck.__PropertyOffset_EndTime) = value;
		}
	}

	// Token: 0x060036CD RID: 14029 RVA: 0x00036B94 File Offset: 0x00034D94
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsCheckType = this.CheckType;
			this.TsStartTime = this.StartTime;
			this.TsEndTime = this.EndTime;
		}
	}

	// Token: 0x060036CE RID: 14030 RVA: 0x00036BE0 File Offset: 0x00034DE0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool PerformConditionCheckAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PerformConditionCheckAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060036CF RID: 14031 RVA: 0x00036C80 File Offset: 0x00034E80
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if ((ownerController as TsAiController).AiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.InitTsVariables();
		int startMinute = this.TsStartTime.Hours * 60 + this.TsStartTime.Minutes;
		int endMinute = this.TsEndTime.Hours * 60 + this.TsEndTime.Minutes;
		bool flag = ControllerBase<TimeOfDayController>.Instance.CheckInMinuteSpan(startMinute, endMinute);
		EArithmeticKeyOperation tsCheckType = this.TsCheckType;
		if (tsCheckType != EArithmeticKeyOperation.Equal)
		{
			return tsCheckType == EArithmeticKeyOperation.NotEqual && !flag;
		}
		return flag;
	}

	// Token: 0x060036D0 RID: 14032 RVA: 0x00036D34 File Offset: 0x00034F34
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorTimeSpanCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorTimeSpanCheck.TsDecoratorTimeSpanCheck_C");
		}
		return TsDecoratorTimeSpanCheck._ClassPtr;
	}

	// Token: 0x060036D1 RID: 14033 RVA: 0x00036D58 File Offset: 0x00034F58
	public TsDecoratorTimeSpanCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTimeSpanCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060036D2 RID: 14034 RVA: 0x00036D80 File Offset: 0x00034F80
	[NullableContext(1)]
	public TsDecoratorTimeSpanCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTimeSpanCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060036D3 RID: 14035 RVA: 0x00036DB3 File Offset: 0x00034FB3
	protected TsDecoratorTimeSpanCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060036D4 RID: 14036 RVA: 0x00036DBC File Offset: 0x00034FBC
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400074F RID: 1871
	private bool IsInitTsVariables;

	// Token: 0x04000750 RID: 1872
	private EArithmeticKeyOperation TsCheckType;

	// Token: 0x04000751 RID: 1873
	private FTimecode TsStartTime;

	// Token: 0x04000752 RID: 1874
	private FTimecode TsEndTime;

	// Token: 0x04000753 RID: 1875
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorTimeSpanCheck.TsDecoratorTimeSpanCheck_C";

	// Token: 0x04000754 RID: 1876
	private static IntPtr _ClassPtr;

	// Token: 0x04000755 RID: 1877
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000756 RID: 1878
	private static int __PropertyOffset_CheckType;

	// Token: 0x04000757 RID: 1879
	private static int __PropertyOffset_StartTime;

	// Token: 0x04000758 RID: 1880
	private static int __PropertyOffset_EndTime;
}
