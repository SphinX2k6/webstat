using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200273D RID: 10045
public class RacingBetsHistoryView : UiViewBase
{
	// Token: 0x06013D30 RID: 81200 RVA: 0x00585547 File Offset: 0x00583747
	[NullableContext(1)]
	public RacingBetsHistoryView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013D31 RID: 81201 RVA: 0x00585550 File Offset: 0x00583750
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x06013D32 RID: 81202 RVA: 0x005855F9 File Offset: 0x005837F9
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsPlayerInfoUpdate, new Action(this.RefreshView));
	}

	// Token: 0x06013D33 RID: 81203 RVA: 0x00585617 File Offset: 0x00583817
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsPlayerInfoUpdate, new Action(this.RefreshView));
	}

	// Token: 0x06013D34 RID: 81204 RVA: 0x00585638 File Offset: 0x00583838
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsHistoryView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsHistoryView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013D35 RID: 81205 RVA: 0x0058567C File Offset: 0x0058387C
	protected override void OnStart()
	{
		UUIInturnAnimController uuiinturnAnimController = base.GetScrollViewWithScrollbar(0).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController == null)
		{
			return;
		}
		uuiinturnAnimController.Play("", -1, false);
	}

	// Token: 0x06013D36 RID: 81206 RVA: 0x005856C4 File Offset: 0x005838C4
	private void RefreshLoopView()
	{
		List<RacingBetsLegMatchData> racingBetsHistoryData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsHistoryData();
		this.RefreshPanelVisible(racingBetsHistoryData);
		if (racingBetsHistoryData != null && racingBetsHistoryData.Count > 0)
		{
			this.HistoryLoopView.RefreshByData(racingBetsHistoryData, null, false);
		}
	}

	// Token: 0x06013D37 RID: 81207 RVA: 0x00585700 File Offset: 0x00583900
	private void RefreshPanelVisible([Nullable(new byte[]
	{
		2,
		1
	})] List<RacingBetsLegMatchData> historyDataList)
	{
		if (historyDataList == null)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			int count = historyDataList.Count;
			base.GetItem(3).SetUIActive(count == 0);
			UUIItem item2 = base.GetItem(0);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(count > 0);
			return;
		}
	}

	// Token: 0x06013D38 RID: 81208 RVA: 0x0058574F File Offset: 0x0058394F
	private void RefreshView()
	{
		this.RefreshLoopView();
	}

	// Token: 0x06013D39 RID: 81209 RVA: 0x00585757 File Offset: 0x00583957
	[NullableContext(1)]
	private RacingBetsHistoryItem CreateHistoryItem()
	{
		return new RacingBetsHistoryItem();
	}

	// Token: 0x06013D3A RID: 81210 RVA: 0x0058575E File Offset: 0x0058395E
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009A3B RID: 39483
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<RacingBetsHistoryItem, RacingBetsLegMatchData> HistoryLoopView;

	// Token: 0x02008AF6 RID: 35574
	private class EComponent
	{
		// Token: 0x0402EDD2 RID: 191954
		public const int HistoryLoopView = 0;

		// Token: 0x0402EDD3 RID: 191955
		public const int LoopViewContent = 1;

		// Token: 0x0402EDD4 RID: 191956
		public const int HistoryViewItem = 2;

		// Token: 0x0402EDD5 RID: 191957
		public const int PanelEmpty = 3;

		// Token: 0x0402EDD6 RID: 191958
		public const int CloseBtn = 4;
	}
}
