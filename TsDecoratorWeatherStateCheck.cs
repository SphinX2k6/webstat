using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Weather;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C6D RID: 3181
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorWeatherStateCheck.TsDecoratorWeatherStateCheck_C")]
public class TsDecoratorWeatherStateCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000158 RID: 344
	// (get) Token: 0x060038CB RID: 14539 RVA: 0x0003F0A7 File Offset: 0x0003D2A7
	// (set) Token: 0x060038CC RID: 14540 RVA: 0x0003F0B7 File Offset: 0x0003D2B7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int WeatherStateId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorWeatherStateCheck.__PropertyOffset_WeatherStateId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorWeatherStateCheck.__PropertyOffset_WeatherStateId) = value;
		}
	}

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x060038CD RID: 14541 RVA: 0x0003F0C8 File Offset: 0x0003D2C8
	// (set) Token: 0x060038CE RID: 14542 RVA: 0x0003F0DC File Offset: 0x0003D2DC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> CheckType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorWeatherStateCheck.__PropertyOffset_CheckType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorWeatherStateCheck.__PropertyOffset_CheckType) = value;
		}
	}

	// Token: 0x060038CF RID: 14543 RVA: 0x0003F0F1 File Offset: 0x0003D2F1
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsWeatherStateId = this.WeatherStateId;
			this.TsCheckType = this.CheckType;
		}
	}

	// Token: 0x060038D0 RID: 14544 RVA: 0x0003F128 File Offset: 0x0003D328
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

	// Token: 0x060038D1 RID: 14545 RVA: 0x0003F1C8 File Offset: 0x0003D3C8
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
		WeatherModel instance2 = ModelBase<WeatherModel>.Instance;
		if (instance2 == null)
		{
			return false;
		}
		int currentWeatherId = instance2.CurrentWeatherId;
		switch (this.TsCheckType)
		{
		case EArithmeticKeyOperation.Equal:
			return currentWeatherId == this.TsWeatherStateId;
		case EArithmeticKeyOperation.NotEqual:
			return currentWeatherId != this.TsWeatherStateId;
		case EArithmeticKeyOperation.Less:
			return currentWeatherId < this.TsWeatherStateId;
		case EArithmeticKeyOperation.LessOrEqual:
			return currentWeatherId <= this.TsWeatherStateId;
		case EArithmeticKeyOperation.Greater:
			return currentWeatherId > this.TsWeatherStateId;
		case EArithmeticKeyOperation.GreaterOrEqual:
			return currentWeatherId >= this.TsWeatherStateId;
		default:
			return false;
		}
	}

	// Token: 0x060038D2 RID: 14546 RVA: 0x0003F29E File Offset: 0x0003D49E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorWeatherStateCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorWeatherStateCheck.TsDecoratorWeatherStateCheck_C");
		}
		return TsDecoratorWeatherStateCheck._ClassPtr;
	}

	// Token: 0x060038D3 RID: 14547 RVA: 0x0003F2C4 File Offset: 0x0003D4C4
	public TsDecoratorWeatherStateCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorWeatherStateCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060038D4 RID: 14548 RVA: 0x0003F2EC File Offset: 0x0003D4EC
	[NullableContext(1)]
	public TsDecoratorWeatherStateCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorWeatherStateCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060038D5 RID: 14549 RVA: 0x0003F31F File Offset: 0x0003D51F
	protected TsDecoratorWeatherStateCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060038D6 RID: 14550 RVA: 0x0003F328 File Offset: 0x0003D528
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040008A0 RID: 2208
	private bool IsInitTsVariables;

	// Token: 0x040008A1 RID: 2209
	private int TsWeatherStateId;

	// Token: 0x040008A2 RID: 2210
	private EArithmeticKeyOperation TsCheckType;

	// Token: 0x040008A3 RID: 2211
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorWeatherStateCheck.TsDecoratorWeatherStateCheck_C";

	// Token: 0x040008A4 RID: 2212
	private static IntPtr _ClassPtr;

	// Token: 0x040008A5 RID: 2213
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040008A6 RID: 2214
	private static int __PropertyOffset_WeatherStateId;

	// Token: 0x040008A7 RID: 2215
	private static int __PropertyOffset_CheckType;
}
