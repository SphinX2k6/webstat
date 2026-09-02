using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.InputSetting;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E6B RID: 3691
[UClass("/Game/Aki/TypeScript/Game/Controller/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Controller/TsStartupPlayerController.TsStartupPlayerController_C")]
public class TsStartupPlayerController : TsBasePlayerController, IUnrealUObject, IUnrealObject
{
	// Token: 0x060059AB RID: 22955 RVA: 0x0010BFDC File Offset: 0x0010A1DC
	protected override void BindActionHandle()
	{
		base.BindActionHandle();
		foreach (ActionMapping actionMapping in ConfigBase<InputSettingsConfig>.Instance.GetAllActionMappingConfig())
		{
			base.AddActionHandle(actionMapping.ActionName);
		}
	}

	// Token: 0x060059AC RID: 22956 RVA: 0x0010C03C File Offset: 0x0010A23C
	protected override void BindAxisHandle()
	{
		base.BindAxisHandle();
		foreach (AxisMapping axisMapping in ConfigBase<InputSettingsConfig>.Instance.GetAllAxisMappingConfig())
		{
			this.AddAxisHandle(axisMapping.AxisName);
		}
	}

	// Token: 0x060059AD RID: 22957 RVA: 0x0010C09C File Offset: 0x0010A29C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsStartupPlayerController._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Controller/TsStartupPlayerController.TsStartupPlayerController_C");
		}
		return TsStartupPlayerController._ClassPtr;
	}

	// Token: 0x060059AE RID: 22958 RVA: 0x0010C0C0 File Offset: 0x0010A2C0
	public TsStartupPlayerController() : this(BuiltinUtils.AllocNativeUObject(TsStartupPlayerController.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060059AF RID: 22959 RVA: 0x0010C0E8 File Offset: 0x0010A2E8
	[NullableContext(1)]
	public TsStartupPlayerController(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsStartupPlayerController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060059B0 RID: 22960 RVA: 0x0010C11B File Offset: 0x0010A31B
	protected TsStartupPlayerController(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400297D RID: 10621
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Controller/TsStartupPlayerController.TsStartupPlayerController_C";

	// Token: 0x0400297E RID: 10622
	private static IntPtr _ClassPtr;

	// Token: 0x0400297F RID: 10623
	private static IntPtr _ClassDefaultObjectPtr;
}
