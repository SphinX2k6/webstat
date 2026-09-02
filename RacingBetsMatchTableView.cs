using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002740 RID: 10048
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsMatchTableView : UiViewBase
{
	// Token: 0x06013D7B RID: 81275 RVA: 0x00587A24 File Offset: 0x00585C24
	public RacingBetsMatchTableView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013D7C RID: 81276 RVA: 0x00587A34 File Offset: 0x00585C34
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick))
		};
	}

	// Token: 0x06013D7D RID: 81277 RVA: 0x00587AC7 File Offset: 0x00585CC7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsReplay, new Action(this.OnCloseBtnClick));
	}

	// Token: 0x06013D7E RID: 81278 RVA: 0x00587AE5 File Offset: 0x00585CE5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsReplay, new Action(this.OnCloseBtnClick));
	}

	// Token: 0x06013D7F RID: 81279 RVA: 0x00587B04 File Offset: 0x00585D04
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsMatchTableView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsMatchTableView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013D80 RID: 81280 RVA: 0x00587B48 File Offset: 0x00585D48
	private ERacingBetsMatchTableType GetCurTabId(List<ERacingBetsMatchTableType> tabList, int curLegMatchDataId)
	{
		foreach (ERacingBetsMatchTableType eracingBetsMatchTableType in tabList)
		{
			RacingBetsMatch? matchTableConfigById = ConfigBase<RacingBetsConfig>.Instance.GetMatchTableConfigById((int)eracingBetsMatchTableType);
			List<int> list = new List<int>();
			foreach (int matchId in matchTableConfigById.Value.GetGroupMatchListArray())
			{
				foreach (RacingBetsLegMatchData racingBetsLegMatchData in ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(matchId).GetLegMatchList())
				{
					list.Add(racingBetsLegMatchData.Id);
				}
			}
			if (list.Contains(curLegMatchDataId))
			{
				return eracingBetsMatchTableType;
			}
		}
		if (tabList.Count <= 0)
		{
			return ERacingBetsMatchTableType.GroupMatch;
		}
		return tabList[0];
	}

	// Token: 0x06013D81 RID: 81281 RVA: 0x00587C4C File Offset: 0x00585E4C
	public UniTask ShowContent(ERacingBetsMatchTableType type)
	{
		RacingBetsMatchTableView.<ShowContent>d__12 <ShowContent>d__;
		<ShowContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowContent>d__.<>4__this = this;
		<ShowContent>d__.type = type;
		<ShowContent>d__.<>1__state = -1;
		<ShowContent>d__.<>t__builder.Start<RacingBetsMatchTableView.<ShowContent>d__12>(ref <ShowContent>d__);
		return <ShowContent>d__.<>t__builder.Task;
	}

	// Token: 0x06013D82 RID: 81282 RVA: 0x00587C97 File Offset: 0x00585E97
	private void OnTabClick(ERacingBetsMatchTableType type)
	{
		GenericLayout<RacingBetsMatchTableTabItem, ERacingBetsMatchTableType> tabLayout = this.TabLayout;
		if (tabLayout != null)
		{
			tabLayout.SelectGridProxyByKey(type, false);
		}
		this.ShowContent(type).Forget();
	}

	// Token: 0x06013D83 RID: 81283 RVA: 0x00587CBD File Offset: 0x00585EBD
	private RacingBetsMatchTableTabItem CreateTabItem()
	{
		return new RacingBetsMatchTableTabItem
		{
			OnToggleCallBack = new Action<ERacingBetsMatchTableType>(this.OnTabClick)
		};
	}

	// Token: 0x06013D84 RID: 81284 RVA: 0x00587CD6 File Offset: 0x00585ED6
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009A5D RID: 39517
	private ERacingBetsMatchTableType SelectedTabType = ERacingBetsMatchTableType.GroupMatch;

	// Token: 0x04009A5E RID: 39518
	[Nullable(2)]
	private RacingBetsGroupMatchPanel GroupMatchPanel;

	// Token: 0x04009A5F RID: 39519
	[Nullable(2)]
	private RacingBetsEliminationMatchPanel EliminationMatchPanel;

	// Token: 0x04009A60 RID: 39520
	[Nullable(2)]
	private RacingBetsFinalMatchPanel FinalMatchPanel;

	// Token: 0x04009A61 RID: 39521
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RacingBetsMatchTableTabItem, ERacingBetsMatchTableType> TabLayout;

	// Token: 0x02008B03 RID: 35587
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402EE2A RID: 192042
		public const int BtnClose = 0;

		// Token: 0x0402EE2B RID: 192043
		public const int ItemSponsor = 1;

		// Token: 0x0402EE2C RID: 192044
		public const int LayoutTab = 2;

		// Token: 0x0402EE2D RID: 192045
		public const int ItemTab = 3;

		// Token: 0x0402EE2E RID: 192046
		public const int ItemParent = 4;
	}
}
