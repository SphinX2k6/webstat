using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02002255 RID: 8789
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MarqueeController : UiControllerBase<MarqueeController>
{
	// Token: 0x06010943 RID: 67907 RVA: 0x0048845C File Offset: 0x0048665C
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LocalStorageInitPlayerId, new Action(this.InitScrollingTimeMap));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.LaunchMarquee));
		Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.CancelCurrentTimer));
	}

	// Token: 0x06010944 RID: 67908 RVA: 0x004884C0 File Offset: 0x004866C0
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LocalStorageInitPlayerId, new Action(this.InitScrollingTimeMap));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.LaunchMarquee));
		Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.CancelCurrentTimer));
	}

	// Token: 0x06010945 RID: 67909 RVA: 0x00488521 File Offset: 0x00486721
	private void InitScrollingTimeMap()
	{
		ModelBase<MarqueeModel>.Instance.InitMarqueeStorageDataMap();
	}

	// Token: 0x06010946 RID: 67910 RVA: 0x0048852D File Offset: 0x0048672D
	private void CancelCurrentTimer()
	{
		if (ModelBase<MarqueeModel>.Instance.TimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(ModelBase<MarqueeModel>.Instance.TimerId);
			ModelBase<MarqueeModel>.Instance.TimerId = null;
		}
	}

	// Token: 0x06010947 RID: 67911 RVA: 0x0048855C File Offset: 0x0048675C
	private void LaunchMarquee()
	{
		if (!ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.EnterGameRet))
		{
			return;
		}
		if (ModelBase<MarqueeModel>.Instance.TimerId != null)
		{
			return;
		}
		ModelBase<MarqueeModel>.Instance.TimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.GetMarqueeFromUrl), (float)((int)(Singleton<TimeUtil>.Instance.Minute * (double)Singleton<TimeUtil>.Instance.InverseMillisecond - new Random().NextDouble() * 5.0 * (double)Singleton<TimeUtil>.Instance.InverseMillisecond)), 1f, null, null, true);
	}

	// Token: 0x06010948 RID: 67912 RVA: 0x004885E8 File Offset: 0x004867E8
	private void GetMarqueeFromUrl(float delta)
	{
		string currentLoginServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		if (StringUtils.IsEmpty(currentLoginServerId))
		{
			return;
		}
		string text = Singleton<PublicUtil>.Instance.GetMarqueeUrl2(Singleton<PublicUtil>.Instance.GetGameId(), currentLoginServerId);
		text = Singleton<CdnServerDebugConfig>.Instance.TryGetMarqueeDebugUrl(text);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		Http.Get(text, null, delegate(bool success, int code, string data)
		{
			this.HandleHttpData(code, data);
			this.CheckMarquee();
		}, null);
	}

	// Token: 0x06010949 RID: 67913 RVA: 0x00488650 File Offset: 0x00486850
	public void TestMarquee(string id)
	{
		string text = "[{\"contents\":[{\"language\":\"zh-Hans\",\"content\":\"10047跑马灯已上架\"},{\"language\":\"en\",\"content\":\"10047跑马灯已上架\"},{\"language\":\"ja\",\"content\":\"\"},{\"language\":\"ko\",\"content\":\"\"},{\"language\":\"ru\",\"content\":\"\"},{\"language\":\"zh-Hant\",\"content\":\"\"},{\"language\":\"de\",\"content\":\"\"},{\"language\":\"es\",\"content\":\"\"},{\"language\":\"pt\",\"content\":\"\"},{\"language\":\"id\",\"content\":\"\"},{\"language\":\"fr\",\"content\":\"\"},{\"language\":\"vi\",\"content\":\"\"},{\"language\":\"th\",\"content\":\"\"}],\"id\":10048,\"startTimeMs\":1698313421000,\"endTimeMs\":1703148916000,\"timeInterval\":0,\"times\":999,\"platform\":[1,2,3],\"channel\":[\"0\",\"18\"]},{\"contents\":[{\"language\":\"zh-Hans\",\"content\":\"第二条跑马灯5444545454545445454545454\"},{\"language\":\"en\",\"content\":\"en 第二条跑马灯\"},{\"language\":\"ja\",\"content\":\"\"},{\"language\":\"ko\",\"content\":\"\"},{\"language\":\"ru\",\"content\":\"\"},{\"language\":\"zh-Hant\",\"content\":\"\"},{\"language\":\"de\",\"content\":\"\"},{\"language\":\"es\",\"content\":\"\"},{\"language\":\"pt\",\"content\":\"\"},{\"language\":\"id\",\"content\":\"\"},{\"language\":\"fr\",\"content\":\"\"},{\"language\":\"vi\",\"content\":\"\"},{\"language\":\"th\",\"content\":\"\"}],\"id\":{0},\"startTimeMs\":1701846026000,\"endTimeMs\":1708142026000,\"timeInterval\":10,\"times\":2,\"platform\":[1,3],\"channel\":[]}]";
		text = text.Replace("{0}", id);
		this.HandleHttpData(200, text);
		this.CloseMarqueeView(true);
	}

	// Token: 0x0601094A RID: 67914 RVA: 0x00488684 File Offset: 0x00486884
	private void HandleHttpData(int code, string data)
	{
		MarqueeModel instance = ModelBase<MarqueeModel>.Instance;
		if (code != 200 && code == 404)
		{
			this.RemoveServerMarqueeData();
			return;
		}
		if (string.IsNullOrEmpty(data) || !data.Contains("contents"))
		{
			return;
		}
		MarqueeDataEx[] array = Json.Parse<MarqueeDataEx[]>(data, null);
		if (array == null)
		{
			this.RemoveServerMarqueeData();
			return;
		}
		foreach (MarqueeDataEx data2 in array)
		{
			MarqueeData marqueeData = new MarqueeData();
			marqueeData.Phrase(data2);
			instance.AddOrUpdateMarqueeDate(marqueeData);
		}
		if (instance.CurMarquee != null && !Singleton<PublicUtil>.Instance.IsInIpWhiteList(instance.CurMarquee.WhiteLists))
		{
			this.CloseMarqueeView(false);
		}
	}

	// Token: 0x0601094B RID: 67915 RVA: 0x00488729 File Offset: 0x00486929
	public void AddClientMarqueeData(MarqueeData data)
	{
		if (!data.IsClientMarquee)
		{
			return;
		}
		ModelBase<MarqueeModel>.Instance.AddOrUpdateMarqueeDate(data);
		this.CheckMarquee();
	}

	// Token: 0x0601094C RID: 67916 RVA: 0x00488745 File Offset: 0x00486945
	private void RemoveServerMarqueeData()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MarqueeView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.MarqueeView, null);
		}
		ModelBase<MarqueeModel>.Instance.RemoveServerMarqueeData();
	}

	// Token: 0x0601094D RID: 67917 RVA: 0x00488774 File Offset: 0x00486974
	public void CloseMarqueeView(bool checkMarquee = true)
	{
		MarqueeData curMarquee = ModelBase<MarqueeModel>.Instance.CurMarquee;
		if (ModelBase<MarqueeModel>.Instance.RemoveMarqueeData((curMarquee != null) ? curMarquee.Id : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Marquee;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "跑马灯数据异常, 数据重复删除";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("incId", (curMarquee != null) ? curMarquee.Id : null);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		ModelBase<MarqueeModel>.Instance.CurMarquee = null;
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MarqueeView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.MarqueeView, delegate(bool _)
			{
				if (checkMarquee)
				{
					Singleton<Log>.Instance.Info(ELogModule.Marquee, ELogAuthor.YZY, "关闭跑马灯检查下一个跑马灯", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.CheckMarquee();
				}
			});
			return;
		}
		if (checkMarquee)
		{
			Singleton<Log>.Instance.Info(ELogModule.Marquee, ELogAuthor.YZY, "检查下一个跑马灯", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CheckMarquee();
		}
	}

	// Token: 0x0601094E RID: 67918 RVA: 0x0048884C File Offset: 0x00486A4C
	private unsafe void CheckMarquee()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MarqueeView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MarqueeView))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Marquee;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "CheckMarquee";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsViewShow", Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MarqueeView));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsViewOpen", Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MarqueeView));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		ModelBase<MarqueeModel>.Instance.SortMarqueeQueue();
		MarqueeData marqueeData = ModelBase<MarqueeModel>.Instance.PeekMarqueeData();
		if (marqueeData == null)
		{
			return;
		}
		if (!this.CheckCurMarqueeValid(marqueeData) || !Singleton<PublicUtil>.Instance.IsInIpWhiteList(marqueeData.WhiteLists))
		{
			ModelBase<MarqueeModel>.Instance.RemoveMarqueeData(marqueeData.Id);
			this.CheckMarquee();
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MarqueeView, null, null);
	}

	// Token: 0x0601094F RID: 67919 RVA: 0x00488954 File Offset: 0x00486B54
	[NullableContext(2)]
	public bool CheckCurMarqueeValid(MarqueeData marqueeData)
	{
		if (marqueeData == null)
		{
			return false;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		int scrollingTime = ModelBase<MarqueeModel>.Instance.GetScrollingTime(marqueeData);
		return serverTime <= marqueeData.EndTime && serverTime >= marqueeData.BeginTime && scrollingTime < marqueeData.ScrollTimes;
	}

	// Token: 0x04008279 RID: 33401
	private const int INTERVAL_OFFSET = 5;
}
