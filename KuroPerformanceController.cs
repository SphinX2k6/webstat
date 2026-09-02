using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using UnrealEngine;

// Token: 0x020020AF RID: 8367
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class KuroPerformanceController : ControllerBase<KuroPerformanceController>
{
	// Token: 0x0600FF85 RID: 65413 RVA: 0x00462140 File Offset: 0x00460340
	protected override bool OnInit()
	{
		this.IsEnable = UKuroPerformanceBPLibrary.IsPerformanceAdaptiveInitialize();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Performance;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "KuroPerformanceController.OnInit";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IsEnable", this.IsEnable);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!this.IsEnable)
		{
			return true;
		}
		string currentActivePerformanceAdaptiveModuleName = UKuroPerformanceBPLibrary.GetCurrentActivePerformanceAdaptiveModuleName();
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Performance;
		ELogAuthor author2 = ELogAuthor.XWX;
		string message2 = "KuroPerformanceController.OnInit";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", currentActivePerformanceAdaptiveModuleName);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		UKuroPerformanceBPLibrary.StartService(79);
		UKuroPerformanceBPLibrary.InitGameConfigFPS(Singleton<GameSettingsDeviceRender>.Instance.FrameRate);
		UKuroPerformanceBPLibrary.InitGameConfigSceneTransition(false);
		Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasEnteredForegroundDelegate, new Action(this.ApplicationHasEnteredForeground));
		Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillEnterBackgroundDelegate, new Action(this.ApplicationWillEnterBackground));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SettingFrameRateChanged, new Action<int>(this.OnSettingFrameRateChanged));
		Singleton<EventSystem>.Instance.Add<bool, bool>(EEventName.ChangePerformanceLimitMode, new Action<bool, bool>(this.OnPerformanceLimitModeChanged));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		this.ReportDelegate = this.CreatePerformanceReportDelegate();
		return true;
	}

	// Token: 0x0600FF86 RID: 65414 RVA: 0x004622AC File Offset: 0x004604AC
	private void ApplicationHasEnteredForeground()
	{
		bool flag = UKuroPerformanceBPLibrary.SetForeground(true);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Performance;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "ApplicationHasEnteredForeground设置前台";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600FF87 RID: 65415 RVA: 0x004622F0 File Offset: 0x004604F0
	private void ApplicationWillEnterBackground()
	{
		bool flag = UKuroPerformanceBPLibrary.SetForeground(false);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Performance;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "ApplicationWillEnterBackground取消设置前台";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600FF88 RID: 65416 RVA: 0x00462334 File Offset: 0x00460534
	protected override bool OnClear()
	{
		if (!this.IsEnable)
		{
			return true;
		}
		Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasEnteredForegroundDelegate, new Action(this.ApplicationHasEnteredForeground));
		Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillEnterBackgroundDelegate, new Action(this.ApplicationWillEnterBackground));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.SettingFrameRateChanged, new Action<int>(this.OnSettingFrameRateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangePerformanceLimitMode, new Action<bool, bool>(this.OnPerformanceLimitModeChanged));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		this.ReportDelegate = null;
		UKuroPerformanceBPLibrary.StopService(79);
		return true;
	}

	// Token: 0x0600FF89 RID: 65417 RVA: 0x00462415 File Offset: 0x00460615
	protected override void OnTick(float delta)
	{
		if (!this.IsEnable)
		{
			return;
		}
		this.TimeCount += delta;
		if (this.TimeCount > 1000f)
		{
			this.TimeCount = 0f;
			this.TickPerformanceAdaptive();
		}
	}

	// Token: 0x0600FF8A RID: 65418 RVA: 0x0046244C File Offset: 0x0046064C
	private void OnBattleStateChanged(bool bStart)
	{
		if (bStart)
		{
			this.BattleHandle = this.Open("Battle");
			return;
		}
		this.Close(this.BattleHandle);
	}

	// Token: 0x0600FF8B RID: 65419 RVA: 0x0046246F File Offset: 0x0046066F
	private void OnSettingFrameRateChanged(int frameRate)
	{
		if (this.PerformanceMap.Count > 0)
		{
			UKuroPerformanceBPLibrary.SetTargetFPS(frameRate, 0);
		}
		UKuroPerformanceBPLibrary.UpdateGameConfigFPS(frameRate);
	}

	// Token: 0x0600FF8C RID: 65420 RVA: 0x0046248E File Offset: 0x0046068E
	private void OnPerformanceLimitModeChanged(bool isPerformanceLimitMode, bool forceDisable)
	{
		if (isPerformanceLimitMode && !forceDisable)
		{
			this.PerformanceLimitModeHandle = this.Open("PerformanceLimitMode");
			return;
		}
		this.Close(this.PerformanceLimitModeHandle);
	}

	// Token: 0x0600FF8D RID: 65421 RVA: 0x004624B4 File Offset: 0x004606B4
	private void OnTeleportStart(bool _)
	{
		bool flag = UKuroPerformanceBPLibrary.UpdateGameConfigSceneTransition(true);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Performance;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "KuroPerformanceController.OnTeleportStart";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600FF8E RID: 65422 RVA: 0x004624F8 File Offset: 0x004606F8
	private void OnTeleportComplete(TeleportContext _)
	{
		bool flag = UKuroPerformanceBPLibrary.UpdateGameConfigSceneTransition(false);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Performance;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "KuroPerformanceController.OnTeleportComplete";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600FF8F RID: 65423 RVA: 0x0046253C File Offset: 0x0046073C
	[NullableContext(1)]
	public unsafe int Open(string reason)
	{
		int num = this.PerformanceCount + 1;
		this.PerformanceCount = num;
		int num2 = num;
		this.PerformanceMap[num2] = reason;
		if (this.PerformanceMap.Count > 1)
		{
			return num2;
		}
		UKuroPerformanceBPLibrary.SetTargetFPS(Singleton<GameSettingsDeviceRender>.Instance.FrameRate, 0);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Performance;
		ELogAuthor author = ELogAuthor.HXY;
		string message = "KuroPerformanceController.Open";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Handle", num2);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return num2;
	}

	// Token: 0x0600FF90 RID: 65424 RVA: 0x004625E8 File Offset: 0x004607E8
	public unsafe void Close(int handle)
	{
		string item;
		if (!this.PerformanceMap.TryGetValue(handle, out item))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Performance;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "性能模式句柄不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Handle", handle);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.PerformanceMap.Remove(handle);
		if (this.PerformanceMap.Count > 0)
		{
			return;
		}
		UKuroPerformanceBPLibrary.SetTargetFPS(0, 0);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Performance;
		ELogAuthor author2 = ELogAuthor.HXY;
		string message2 = "KuroPerformanceController.Close";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", item);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Handle", handle);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600FF91 RID: 65425 RVA: 0x004626B4 File Offset: 0x004608B4
	private void TickPerformanceAdaptive()
	{
		if (this.PerformanceMap.Count > 0)
		{
			MethodInfo method = typeof(UKuroPerformanceBPLibrary).GetMethod("GetTickedPerformanceReportAndAdvice", BindingFlags.Static | BindingFlags.Public);
			if (method != null)
			{
				method.Invoke(null, new object[]
				{
					this.ReportDelegate
				});
			}
		}
	}

	// Token: 0x0600FF92 RID: 65426 RVA: 0x00462708 File Offset: 0x00460908
	private Delegate CreatePerformanceReportDelegate()
	{
		MethodInfo method = base.GetType().GetMethod("OnGetTickedPerformanceReportAndAdvice", BindingFlags.Instance | BindingFlags.NonPublic);
		MethodInfo method2 = typeof(UKuroPerformanceBPLibrary).GetMethod("GetTickedPerformanceReportAndAdvice", BindingFlags.Static | BindingFlags.Public);
		if (method == null || method2 == null)
		{
			return null;
		}
		ParameterInfo[] parameters = method2.GetParameters();
		if (parameters.Length != 1)
		{
			return null;
		}
		Delegate result;
		try
		{
			result = Delegate.CreateDelegate(parameters[0].ParameterType, this, method, false);
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600FF93 RID: 65427 RVA: 0x0046278C File Offset: 0x0046098C
	private void OnGetTickedPerformanceReportAndAdvice(FKuroPerformanceReport performanceReport)
	{
	}

	// Token: 0x04007A86 RID: 31366
	private const bool BOOST_SWITCH = true;

	// Token: 0x04007A87 RID: 31367
	private const float GAP_TIME = 1000f;

	// Token: 0x04007A88 RID: 31368
	private const int SERVICE_CODE = 79;

	// Token: 0x04007A89 RID: 31369
	public bool IsEnable = true;

	// Token: 0x04007A8A RID: 31370
	private float TimeCount;

	// Token: 0x04007A8B RID: 31371
	private int PerformanceCount;

	// Token: 0x04007A8C RID: 31372
	[Nullable(1)]
	private readonly Dictionary<int, string> PerformanceMap = new Dictionary<int, string>();

	// Token: 0x04007A8D RID: 31373
	private int BattleHandle;

	// Token: 0x04007A8E RID: 31374
	private int PerformanceLimitModeHandle;

	// Token: 0x04007A8F RID: 31375
	private const bool DebugLogEnabled = false;

	// Token: 0x04007A90 RID: 31376
	private Delegate ReportDelegate;
}
