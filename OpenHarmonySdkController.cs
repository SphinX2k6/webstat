using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02000EFC RID: 3836
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class OpenHarmonySdkController : ControllerBase<OpenHarmonySdkController>
{
	// Token: 0x06005EB0 RID: 24240 RVA: 0x0017AA1C File Offset: 0x00178C1C
	public void SetEnable(bool enable)
	{
		this.IsEnable = enable;
	}

	// Token: 0x06005EB1 RID: 24241 RVA: 0x0017AA25 File Offset: 0x00178C25
	public bool CanUse()
	{
		return this.IsEnable && Singleton<Info>.Instance.IsOpenHarmonyPlatform();
	}

	// Token: 0x06005EB2 RID: 24242 RVA: 0x0017AA3B File Offset: 0x00178C3B
	protected override bool OnInit()
	{
		if (!this.CanUse())
		{
			return true;
		}
		this.InitGamePerformance();
		this.UpdateGameConfigInfo();
		this.RegisterSettingsListener();
		return true;
	}

	// Token: 0x06005EB3 RID: 24243 RVA: 0x0017AA5A File Offset: 0x00178C5A
	protected override bool OnClear()
	{
		if (this.EventBound)
		{
			this.UnRegisterSettingsListener();
		}
		this.IsInitialized = false;
		return true;
	}

	// Token: 0x06005EB4 RID: 24244 RVA: 0x0017AA74 File Offset: 0x00178C74
	public unsafe void InitGamePerformance()
	{
		if (!this.CanUse())
		{
			return;
		}
		string text = "com.kurogame.mingchao.hongmeng.huawei";
		string appVersion = UKuroLauncherLibrary.GetAppVersion();
		string engineVersion = UKismetSystemLibrary.GetEngineVersion();
		bool flag = Singleton<GameSettingsDeviceRender>.Instance.IsVulkanRHI() > 0;
		FKuroHarmonyGamePackageInfo fkuroHarmonyGamePackageInfo = new FKuroHarmonyGamePackageInfo(0, text, appVersion, 1, engineVersion, 2, flag);
		UKuroOpenHarmonyLibrary.InitGamePerformance(fkuroHarmonyGamePackageInfo);
		this.IsInitialized = true;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "[OpenHarmonySdk] InitGamePerformance";
		<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BundleName", text);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AppVersion", appVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EngineType", 1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("EngineVersion", engineVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("GameType", 2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("bVulkanSupported", flag);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
	}

	// Token: 0x06005EB5 RID: 24245 RVA: 0x0017AB88 File Offset: 0x00178D88
	public void UpdateGameConfigInfo()
	{
		if (!this.CanUse())
		{
			return;
		}
		if (!this.IsInitialized)
		{
			Singleton<Log>.Instance.Warn(ELogModule.KuroSdk, ELogAuthor.YZY, "[OpenHarmonySdk] UpdateGameConfigInfo skip: not initialized", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int currentValueSafely = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.MOBILERESOLUTION, 0, true);
		string currentResolutionStr = this.GetCurrentResolutionStr();
		int lastOptionsValue = this.GetLastOptionsValue(EFunction.MOBILERESOLUTION, currentValueSafely);
		int frameRate = Singleton<GameSettingsDeviceRender>.Instance.FrameRate;
		int maxFrameRate = GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony[GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony.Length - 1];
		string maxResolution = currentResolutionStr;
		bool bAntiAliasing = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.ANTIALISING, 0, true) != 0;
		FKuroHarmonyGameConfigInfo fkuroHarmonyGameConfigInfo = new FKuroHarmonyGameConfigInfo(1, lastOptionsValue, currentValueSafely, maxFrameRate, frameRate, maxResolution, currentResolutionStr, bAntiAliasing, false, false, false, false);
		UKuroOpenHarmonyLibrary.UpdateGameConfigInfo(fkuroHarmonyGameConfigInfo);
	}

	// Token: 0x06005EB6 RID: 24246 RVA: 0x0017AC34 File Offset: 0x00178E34
	private int GetLastOptionsValue(EFunction functionId, int fallback)
	{
		MenuConfig? valueOrNull = Singleton<GameSettingsManager>.Instance.ValidApplyConfigMap.GetValueOrNull(functionId);
		int[] array = (valueOrNull != null) ? valueOrNull.GetValueOrDefault().OptionsValue() : null;
		if (array == null || array.Length == 0)
		{
			return fallback;
		}
		return array[array.Length - 1];
	}

	// Token: 0x06005EB7 RID: 24247 RVA: 0x0017AC80 File Offset: 0x00178E80
	private void RegisterSettingsListener()
	{
		if (this.EventBound)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Add<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnMenuSettingChanged));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SettingFrameRateChanged, new Action<int>(this.OnFrameRateChanged));
		this.EventBound = true;
	}

	// Token: 0x06005EB8 RID: 24248 RVA: 0x0017ACD8 File Offset: 0x00178ED8
	private void UnRegisterSettingsListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnMenuSettingChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.SettingFrameRateChanged, new Action<int>(this.OnFrameRateChanged));
		this.EventBound = false;
	}

	// Token: 0x06005EB9 RID: 24249 RVA: 0x0017AD24 File Offset: 0x00178F24
	private void OnMenuSettingChanged(EFunction functionId)
	{
		if (functionId == EFunction.MOBILERESOLUTION || functionId == EFunction.HIGHESTFPS || functionId == EFunction.ANTIALISING)
		{
			this.UpdateGameConfigInfo();
		}
	}

	// Token: 0x06005EBA RID: 24250 RVA: 0x0017AD3B File Offset: 0x00178F3B
	private void OnFrameRateChanged(int frameRate)
	{
		this.UpdateGameConfigInfo();
	}

	// Token: 0x06005EBB RID: 24251 RVA: 0x0017AD44 File Offset: 0x00178F44
	private string GetCurrentResolutionStr()
	{
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		if (gameUserSettings == null)
		{
			return "";
		}
		FIntPoint screenResolution = gameUserSettings.GetScreenResolution();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(screenResolution.X);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<int>(screenResolution.Y);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x04002DDB RID: 11739
	private const int MESSAGE_TYPE_PACKAGE_INFO = 0;

	// Token: 0x04002DDC RID: 11740
	private const int MESSAGE_TYPE_CONFIG_INFO = 1;

	// Token: 0x04002DDD RID: 11741
	private const int ENGINE_TYPE_UE = 1;

	// Token: 0x04002DDE RID: 11742
	private const int GAME_TYPE = 2;

	// Token: 0x04002DDF RID: 11743
	private const string BUNDLE_NAME = "com.kurogame.mingchao.hongmeng.huawei";

	// Token: 0x04002DE0 RID: 11744
	public bool IsEnable = true;

	// Token: 0x04002DE1 RID: 11745
	private bool IsInitialized;

	// Token: 0x04002DE2 RID: 11746
	private bool EventBound;
}
