using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C48 RID: 3144
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardDistanceCompare.TsDecoratorBlackboardDistanceCompare_C")]
public class TsDecoratorBlackboardDistanceCompare : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700011C RID: 284
	// (get) Token: 0x0600372D RID: 14125 RVA: 0x00038677 File Offset: 0x00036877
	// (set) Token: 0x0600372E RID: 14126 RVA: 0x0003868B File Offset: 0x0003688B
	[Nullable(0)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> CompareType
	{
		[NullableContext(0)]
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardDistanceCompare.__PropertyOffset_CompareType);
		}
		[NullableContext(0)]
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardDistanceCompare.__PropertyOffset_CompareType) = value;
		}
	}

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x0600372F RID: 14127 RVA: 0x000386A0 File Offset: 0x000368A0
	// (set) Token: 0x06003730 RID: 14128 RVA: 0x000386B4 File Offset: 0x000368B4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string OtherLocationKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardDistanceCompare.__PropertyOffset_OtherLocationKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardDistanceCompare.__PropertyOffset_OtherLocationKey)), value);
		}
	}

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x06003731 RID: 14129 RVA: 0x000386C9 File Offset: 0x000368C9
	// (set) Token: 0x06003732 RID: 14130 RVA: 0x000386D9 File Offset: 0x000368D9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardDistanceCompare.__PropertyOffset_CompareValue);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardDistanceCompare.__PropertyOffset_CompareValue) = value;
		}
	}

	// Token: 0x06003733 RID: 14131 RVA: 0x000386EC File Offset: 0x000368EC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsCompareType = this.CompareType;
			this.TsOtherLocationKey = this.OtherLocationKey;
			this.TsCompareValue = this.CompareValue;
			this.LocationCache = global::Vector.Create();
			this.OtherLocationCache = global::Vector.Create();
		}
	}

	// Token: 0x06003734 RID: 14132 RVA: 0x00038750 File Offset: 0x00036950
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

	// Token: 0x06003735 RID: 14133 RVA: 0x000387F0 File Offset: 0x000369F0
	[NullableContext(2)]
	protected unsafe virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		Entity entity = (ownerController as TsAiController).GetEntity();
		if (!entity)
		{
			return false;
		}
		this.InitTsVariables();
		CharacterActorComponent charActorComp = (ownerController as TsAiController).AiController.CharActorComp;
		this.LocationCache.DeepCopy(charActorComp.ActorLocationProxy);
		if (this.TsOtherLocationKey != "")
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(entity.Id, this.TsOtherLocationKey);
			if (vectorValueByEntity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.BehaviorTree;
				ELogAuthor author2 = ELogAuthor.CJH;
				string message2 = "不存在BlackboardKey";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", this.TsOtherLocationKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Tree", base.TreeAsset);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			this.OtherLocationCache.DeepCopy(vectorValueByEntity);
		}
		else
		{
			Aki.Protocol.Vector initLocation = charActorComp.CreatureData.GetInitLocation();
			if (initLocation == null)
			{
				return false;
			}
			this.OtherLocationCache.DeepCopy(initLocation);
		}
		if (this.LocationCache == null || this.OtherLocationCache == null)
		{
			return false;
		}
		double num = global::Vector.DistSquared(this.LocationCache, this.OtherLocationCache);
		float num2 = this.TsCompareValue * this.TsCompareValue;
		switch (this.TsCompareType)
		{
		case EArithmeticKeyOperation.Equal:
			return Math.Abs(num - (double)num2) <= 10.0;
		case EArithmeticKeyOperation.NotEqual:
			return Math.Abs(num - (double)num2) > 10.0;
		case EArithmeticKeyOperation.Less:
			return num < (double)num2;
		case EArithmeticKeyOperation.LessOrEqual:
			return num <= (double)num2;
		case EArithmeticKeyOperation.Greater:
			return num > (double)num2;
		case EArithmeticKeyOperation.GreaterOrEqual:
			return num >= (double)num2;
		default:
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.CJH;
			string message3 = "不支持的比较类型";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		}
	}

	// Token: 0x06003736 RID: 14134 RVA: 0x00038A19 File Offset: 0x00036C19
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboardDistanceCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardDistanceCompare.TsDecoratorBlackboardDistanceCompare_C");
		}
		return TsDecoratorBlackboardDistanceCompare._ClassPtr;
	}

	// Token: 0x06003737 RID: 14135 RVA: 0x00038A40 File Offset: 0x00036C40
	public TsDecoratorBlackboardDistanceCompare() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardDistanceCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003738 RID: 14136 RVA: 0x00038A68 File Offset: 0x00036C68
	public TsDecoratorBlackboardDistanceCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardDistanceCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003739 RID: 14137 RVA: 0x00038A9B File Offset: 0x00036C9B
	protected TsDecoratorBlackboardDistanceCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600373A RID: 14138 RVA: 0x00038AC8 File Offset: 0x00036CC8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000793 RID: 1939
	private const float MAX_ERROR = 10f;

	// Token: 0x04000794 RID: 1940
	private global::Vector LocationCache = global::Vector.Create();

	// Token: 0x04000795 RID: 1941
	private global::Vector OtherLocationCache = global::Vector.Create();

	// Token: 0x04000796 RID: 1942
	private bool IsInitTsVariables;

	// Token: 0x04000797 RID: 1943
	private EArithmeticKeyOperation TsCompareType;

	// Token: 0x04000798 RID: 1944
	private string TsOtherLocationKey = "";

	// Token: 0x04000799 RID: 1945
	private float TsCompareValue;

	// Token: 0x0400079A RID: 1946
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardDistanceCompare.TsDecoratorBlackboardDistanceCompare_C";

	// Token: 0x0400079B RID: 1947
	private static IntPtr _ClassPtr;

	// Token: 0x0400079C RID: 1948
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400079D RID: 1949
	private static int __PropertyOffset_CompareType;

	// Token: 0x0400079E RID: 1950
	private static int __PropertyOffset_OtherLocationKey;

	// Token: 0x0400079F RID: 1951
	private static int __PropertyOffset_CompareValue;
}
