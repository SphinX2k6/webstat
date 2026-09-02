using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Weather;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DBB RID: 3515
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeWeather.TsAnimNotifyChangeWeather_C")]
public class TsAnimNotifyChangeWeather : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000511 RID: 1297
	// (get) Token: 0x06004FAC RID: 20396 RVA: 0x000B736B File Offset: 0x000B556B
	// (set) Token: 0x06004FAD RID: 20397 RVA: 0x000B737B File Offset: 0x000B557B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Weather
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyChangeWeather.__PropertyOffset_Weather);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeWeather.__PropertyOffset_Weather) = value;
		}
	}

	// Token: 0x06004FAE RID: 20398 RVA: 0x000B738C File Offset: 0x000B558C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.Weather == 0)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.GHY, "[TsAnimNotifyChangeWeather] Weather 未设置!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		ControllerBase<WeatherController>.Instance.RequestChangeWeather(this.Weather, new ChangeWeatherReason?(ChangeWeatherReason.ClientSkill));
		return true;
	}

	// Token: 0x06004FAF RID: 20399 RVA: 0x000B73D6 File Offset: 0x000B55D6
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "切换天气";
	}

	// Token: 0x06004FB0 RID: 20400 RVA: 0x000B73DD File Offset: 0x000B55DD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyChangeWeather._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeWeather.TsAnimNotifyChangeWeather_C");
		}
		return TsAnimNotifyChangeWeather._ClassPtr;
	}

	// Token: 0x06004FB1 RID: 20401 RVA: 0x000B7404 File Offset: 0x000B5604
	public TsAnimNotifyChangeWeather() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeWeather.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004FB2 RID: 20402 RVA: 0x000B742C File Offset: 0x000B562C
	[NullableContext(1)]
	public TsAnimNotifyChangeWeather(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeWeather.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004FB3 RID: 20403 RVA: 0x000B745F File Offset: 0x000B565F
	protected TsAnimNotifyChangeWeather(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004FB4 RID: 20404 RVA: 0x000B7468 File Offset: 0x000B5668
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004FB5 RID: 20405 RVA: 0x000B749B File Offset: 0x000B569B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x0400173D RID: 5949
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeWeather.TsAnimNotifyChangeWeather_C";

	// Token: 0x0400173E RID: 5950
	private static IntPtr _ClassPtr;

	// Token: 0x0400173F RID: 5951
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001740 RID: 5952
	private static int __PropertyOffset_Weather;
}
