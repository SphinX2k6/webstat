using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002369 RID: 9065
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PanoramicUiDeferController : ControllerBase<PanoramicUiDeferController>
{
	// Token: 0x06011586 RID: 71046 RVA: 0x004C7114 File Offset: 0x004C5314
	public void StartDefer()
	{
		if (this.Registered)
		{
			return;
		}
		this.Registered = true;
		this.ReplayWhiteSet.Clear();
		foreach (string text in ConfigBase<CommonConfig>.Instance.GetPanoramicUiDeferWhiteList())
		{
			EUiViewName euiViewName = (EUiViewName)text;
			if (Singleton<UiConfig>.Instance.TryGetViewInfo(euiViewName) == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Panoramic;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[环视] 重放白名单配置了无效界面名";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", text);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				this.ReplayWhiteSet.Add(euiViewName);
			}
		}
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "环视期间延迟打开界面");
		Singleton<Log>.Instance.Info(ELogModule.Panoramic, ELogAuthor.HYF, "[环视] 开始拦截并延迟其他UI的打开", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06011587 RID: 71047 RVA: 0x004C7208 File Offset: 0x004C5408
	public void StopDeferAndReplay()
	{
		if (!this.Registered)
		{
			return;
		}
		this.Registered = false;
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
		ValueTuple<EUiViewName, object>[] array = this.DeferredQueue.ToArray();
		this.DeferredQueue.Clear();
		this.DeferredNameSet.Clear();
		foreach (ValueTuple<EUiViewName, object> valueTuple in array)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Panoramic;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[环视] 重放延迟打开的UI";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", valueTuple.Item1);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Singleton<UiManager>.Instance.OpenView(valueTuple.Item1, valueTuple.Item2, null);
		}
	}

	// Token: 0x06011588 RID: 71048 RVA: 0x004C72C4 File Offset: 0x004C54C4
	public void ClearWithoutReplay()
	{
		if (this.Registered)
		{
			this.Registered = false;
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<Log>.Instance.Info(ELogModule.Panoramic, ELogAuthor.HYF, "[环视] 清理延迟队列(不重放)", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.DeferredQueue.Clear();
		this.DeferredNameSet.Clear();
	}

	// Token: 0x06011589 RID: 71049 RVA: 0x004C7330 File Offset: 0x004C5530
	protected override bool OnClear()
	{
		this.ClearWithoutReplay();
		return base.OnClear();
	}

	// Token: 0x0601158A RID: 71050 RVA: 0x004C733E File Offset: 0x004C553E
	protected override bool OnLeaveLevel()
	{
		this.ClearWithoutReplay();
		return base.OnLeaveLevel();
	}

	// Token: 0x0601158B RID: 71051 RVA: 0x004C734C File Offset: 0x004C554C
	[NullableContext(2)]
	private bool CheckCanOpen(EUiViewName viewName, object param)
	{
		if (this.WhiteList.Contains(viewName))
		{
			return true;
		}
		UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
		if (uiViewInfo == null)
		{
			return true;
		}
		if (uiViewInfo.Type != ELayerType.Normal && uiViewInfo.TimeDilation == 1f)
		{
			return true;
		}
		if (!this.ReplayWhiteSet.Contains(viewName))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Panoramic;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[环视] 拦截UI(不在重放白名单, 不重放)";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", viewName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (!this.DeferredNameSet.Contains(viewName))
		{
			this.DeferredNameSet.Add(viewName);
			this.DeferredQueue.Add(new ValueTuple<EUiViewName, object>(viewName, param));
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Panoramic;
		ELogAuthor author2 = ELogAuthor.HYF;
		string message2 = "[环视] 拦截UI并加入延迟队列";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", viewName);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		return false;
	}

	// Token: 0x04008852 RID: 34898
	private readonly HashSet<EUiViewName> WhiteList = new HashSet<EUiViewName>
	{
		EUiViewName.PlotViewHUD
	};

	// Token: 0x04008853 RID: 34899
	[TupleElementNames(new string[]
	{
		"Name",
		"Param"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		2
	})]
	private readonly List<ValueTuple<EUiViewName, object>> DeferredQueue = new List<ValueTuple<EUiViewName, object>>();

	// Token: 0x04008854 RID: 34900
	private readonly HashSet<EUiViewName> DeferredNameSet = new HashSet<EUiViewName>();

	// Token: 0x04008855 RID: 34901
	private readonly HashSet<EUiViewName> ReplayWhiteSet = new HashSet<EUiViewName>();

	// Token: 0x04008856 RID: 34902
	private bool Registered;
}
