using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Enum;
using CSharpScript.Game.Module.Weather;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C57 RID: 3159
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckWeather.TsDecoratorCheckWeather_C")]
public class TsDecoratorCheckWeather : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000136 RID: 310
	// (get) Token: 0x060037DD RID: 14301 RVA: 0x0003B5C7 File Offset: 0x000397C7
	// (set) Token: 0x060037DE RID: 14302 RVA: 0x0003B5D7 File Offset: 0x000397D7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EWeatherState CheckWeatherState
	{
		get
		{
			return (EWeatherState)(*(base.NativePtr + (IntPtr)TsDecoratorCheckWeather.__PropertyOffset_CheckWeatherState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckWeather.__PropertyOffset_CheckWeatherState) = (byte)value;
		}
	}

	// Token: 0x060037DF RID: 14303 RVA: 0x0003B5E8 File Offset: 0x000397E8
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

	// Token: 0x060037E0 RID: 14304 RVA: 0x0003B688 File Offset: 0x00039888
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		WeatherDefines.EWeatherType currentWeatherType = ModelBase<WeatherModel>.Instance.GetCurrentWeatherType();
		bool result = false;
		switch (currentWeatherType)
		{
		case WeatherDefines.EWeatherType.Sunny:
			result = (this.CheckWeatherState == EWeatherState.晴天);
			break;
		case WeatherDefines.EWeatherType.Cloudy:
			result = (this.CheckWeatherState == EWeatherState.多云);
			break;
		case WeatherDefines.EWeatherType.Rainy:
			result = (this.CheckWeatherState == EWeatherState.下雨);
			break;
		case WeatherDefines.EWeatherType.ThunderRain:
			result = (this.CheckWeatherState == EWeatherState.打雷);
			break;
		case WeatherDefines.EWeatherType.Snowy:
			result = (this.CheckWeatherState == EWeatherState.下雪);
			break;
		}
		return result;
	}

	// Token: 0x060037E1 RID: 14305 RVA: 0x0003B6FB File Offset: 0x000398FB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckWeather._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckWeather.TsDecoratorCheckWeather_C");
		}
		return TsDecoratorCheckWeather._ClassPtr;
	}

	// Token: 0x060037E2 RID: 14306 RVA: 0x0003B720 File Offset: 0x00039920
	public TsDecoratorCheckWeather() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckWeather.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060037E3 RID: 14307 RVA: 0x0003B748 File Offset: 0x00039948
	[NullableContext(1)]
	public TsDecoratorCheckWeather(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckWeather.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060037E4 RID: 14308 RVA: 0x0003B77B File Offset: 0x0003997B
	protected TsDecoratorCheckWeather(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060037E5 RID: 14309 RVA: 0x0003B784 File Offset: 0x00039984
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000809 RID: 2057
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckWeather.TsDecoratorCheckWeather_C";

	// Token: 0x0400080A RID: 2058
	private static IntPtr _ClassPtr;

	// Token: 0x0400080B RID: 2059
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400080C RID: 2060
	private static int __PropertyOffset_CheckWeatherState;
}
