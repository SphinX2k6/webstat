using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Enum;
using AkiClient.Game.Aki.Data.Condition.Enum;
using CSharpScript.Game.Module.Weather;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C4F RID: 3151
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckDayWeather.TsDecoratorCheckDayWeather_C")]
public class TsDecoratorCheckDayWeather : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700012D RID: 301
	// (get) Token: 0x06003786 RID: 14214 RVA: 0x00039E67 File Offset: 0x00038067
	// (set) Token: 0x06003787 RID: 14215 RVA: 0x00039E77 File Offset: 0x00038077
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EDayState CheckDayState
	{
		get
		{
			return (EDayState)(*(base.NativePtr + (IntPtr)TsDecoratorCheckDayWeather.__PropertyOffset_CheckDayState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckDayWeather.__PropertyOffset_CheckDayState) = (byte)value;
		}
	}

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x06003788 RID: 14216 RVA: 0x00039E88 File Offset: 0x00038088
	// (set) Token: 0x06003789 RID: 14217 RVA: 0x00039E98 File Offset: 0x00038098
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EWeatherState CheckWeatherState
	{
		get
		{
			return (EWeatherState)(*(base.NativePtr + (IntPtr)TsDecoratorCheckDayWeather.__PropertyOffset_CheckWeatherState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckDayWeather.__PropertyOffset_CheckWeatherState) = (byte)value;
		}
	}

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x0600378A RID: 14218 RVA: 0x00039EA9 File Offset: 0x000380A9
	// (set) Token: 0x0600378B RID: 14219 RVA: 0x00039EB9 File Offset: 0x000380B9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe SConditionGroupType ConditionType
	{
		get
		{
			return (SConditionGroupType)(*(base.NativePtr + (IntPtr)TsDecoratorCheckDayWeather.__PropertyOffset_ConditionType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckDayWeather.__PropertyOffset_ConditionType) = (byte)value;
		}
	}

	// Token: 0x0600378C RID: 14220 RVA: 0x00039ECC File Offset: 0x000380CC
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

	// Token: 0x0600378D RID: 14221 RVA: 0x00039F6C File Offset: 0x0003816C
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		WeatherDefines.EWeatherType currentWeatherType = ModelBase<WeatherModel>.Instance.GetCurrentWeatherType();
		bool flag;
		if (this.CheckDayState == EDayState.白天)
		{
			flag = ControllerBase<TimeOfDayController>.Instance.CheckInMinuteSpan(360, 1080);
		}
		else
		{
			flag = !ControllerBase<TimeOfDayController>.Instance.CheckInMinuteSpan(360, 1080);
		}
		bool flag2 = false;
		switch (currentWeatherType)
		{
		case WeatherDefines.EWeatherType.Sunny:
			flag2 = (this.CheckWeatherState == EWeatherState.晴天);
			break;
		case WeatherDefines.EWeatherType.Cloudy:
			flag2 = (this.CheckWeatherState == EWeatherState.多云);
			break;
		case WeatherDefines.EWeatherType.Rainy:
			flag2 = (this.CheckWeatherState == EWeatherState.下雨);
			break;
		case WeatherDefines.EWeatherType.ThunderRain:
			flag2 = (this.CheckWeatherState == EWeatherState.打雷);
			break;
		case WeatherDefines.EWeatherType.Snowy:
			flag2 = (this.CheckWeatherState == EWeatherState.下雪);
			break;
		}
		if (this.ConditionType != SConditionGroupType.AND)
		{
			return flag || flag2;
		}
		return flag && flag2;
	}

	// Token: 0x0600378E RID: 14222 RVA: 0x0003A029 File Offset: 0x00038229
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckDayWeather._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckDayWeather.TsDecoratorCheckDayWeather_C");
		}
		return TsDecoratorCheckDayWeather._ClassPtr;
	}

	// Token: 0x0600378F RID: 14223 RVA: 0x0003A050 File Offset: 0x00038250
	public TsDecoratorCheckDayWeather() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckDayWeather.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003790 RID: 14224 RVA: 0x0003A078 File Offset: 0x00038278
	[NullableContext(1)]
	public TsDecoratorCheckDayWeather(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckDayWeather.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003791 RID: 14225 RVA: 0x0003A0AB File Offset: 0x000382AB
	protected TsDecoratorCheckDayWeather(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003792 RID: 14226 RVA: 0x0003A0B4 File Offset: 0x000382B4
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007D4 RID: 2004
	private const int DAY_MINITE_START = 360;

	// Token: 0x040007D5 RID: 2005
	private const int DAY_MINITE_END = 1080;

	// Token: 0x040007D6 RID: 2006
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckDayWeather.TsDecoratorCheckDayWeather_C";

	// Token: 0x040007D7 RID: 2007
	private static IntPtr _ClassPtr;

	// Token: 0x040007D8 RID: 2008
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007D9 RID: 2009
	private static int __PropertyOffset_CheckDayState;

	// Token: 0x040007DA RID: 2010
	private static int __PropertyOffset_CheckWeatherState;

	// Token: 0x040007DB RID: 2011
	private static int __PropertyOffset_ConditionType;
}
