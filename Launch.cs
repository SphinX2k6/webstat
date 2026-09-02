using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Aki.Common.ConsoleManagerGenerate;
using AkiClient.Game.Aki.Core;
using CSharpScript.ConsoleManagerGenerate;
using CSharpScript.Core.Utils;
using CSharpScript.Launcher;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.InputDevice;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using CSharpScript.ThirdParty.UniTaskExtensions;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x020034E2 RID: 13538
public class Launch
{
	// Token: 0x0601C9C4 RID: 117188 RVA: 0x00895690 File Offset: 0x00893890
	[NullableContext(1)]
	public static void DoLaunch(UGameInstance gameInstance)
	{
		CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
		Aki.Common.ConsoleManagerGenerate.ConsoleRegister.RegisterAll();
		CSharpScript.ConsoleManagerGenerate.ConsoleRegister.RegisterAll();
		StaticVariableRegister.ResetRequiredStaticDefaultValue();
		global::DelegateUtils.CreateStaticDefaultValue();
		UnobservedExceptionHandler.Initialize(gameInstance);
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[ScriptBuildInfo] Optimize: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(CSharpScriptBuildInfo.Optimized);
		instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		LauncherLog instance2 = Singleton<LauncherLog>.Instance;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(53, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[ScriptBuildInfo] ENABLE_SHARPHEREAL_NATIVE_WRAPPER: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(true);
		instance2.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		BP_MainGameInstance_C bp_MainGameInstance_C = Launch.LaunchGameInstance = (gameInstance as BP_MainGameInstance_C);
		UWorld world = bp_MainGameInstance_C.GetWorld();
		DllUtils.Initialize();
		StaticVariableRegister.CreateRequiredStaticDefaultValue();
		GeneratedUtils.Init();
		DecoratorManager.Init();
		bp_MainGameInstance_C.IsStartFromLaunch = true;
		AppUtil.SetWorldContext(world);
		Singleton<InputDevice>.Instance.Initialize();
		Singleton<CloudGameManagerLauncher>.Instance.Init();
		Singleton<LauncherStorageLib>.Instance.Initialize();
		Singleton<LauncherConfigLib>.Instance.Initialize();
		Singleton<LauncherLanguageLib>.Instance.Initialize(UKuroStaticLibrary.IsEditor(world));
		Singleton<LauncherResourceLib>.Instance.Initialize();
		Singleton<LauncherGameSettingLib>.Instance.InitInLaunch(world);
		Singleton<LauncherLog>.Instance.Info("cs launch called, starting HotPatch", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<HotPatchLogReport>.Instance.World = world;
		Singleton<HotPatch>.Instance.Start(world, gameInstance);
	}

	// Token: 0x0400E66B RID: 58987
	[Nullable(2)]
	[StaticVariableRuleIgnore]
	public static BP_MainGameInstance_C LaunchGameInstance;
}
