using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002741 RID: 10049
public class RacingBetsRankView : UiTickViewBase
{
	// Token: 0x06013D85 RID: 81285 RVA: 0x00587CDF File Offset: 0x00585EDF
	[NullableContext(1)]
	public RacingBetsRankView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013D86 RID: 81286 RVA: 0x00587CE8 File Offset: 0x00585EE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIArtText)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x06013D87 RID: 81287 RVA: 0x00587E48 File Offset: 0x00586048
	protected override void OnStart()
	{
		this.RankLoopViewRoot = base.GetLoopScrollViewComponent(0).RootUIComp.Get();
		this.RankLoopView = new LoopScrollView<RacingBetsRankItem, IRacingBetsRankData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<RacingBetsRankItem>(this.CreateRankItem), false);
	}

	// Token: 0x06013D88 RID: 81288 RVA: 0x00587EA0 File Offset: 0x005860A0
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		UUIInturnAnimController uuiinturnAnimController = base.GetLoopScrollViewComponent(0).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController != null)
		{
			uuiinturnAnimController.Play("", -1, false);
		}
		this.NextUpdateTime = (double)ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().GetNextRankUpdateTime();
	}

	// Token: 0x06013D89 RID: 81289 RVA: 0x00587F04 File Offset: 0x00586104
	protected override void OnTick(float delta)
	{
		if (this.NextUpdateTime < 0.0)
		{
			UUIText text = base.GetText(12);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
			return;
		}
		else
		{
			RacingBetsSeasonData seasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (this.NextUpdateTime - serverTime >= 0.0)
			{
				this.CrossDayRefresh = false;
				CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(this.NextUpdateTime - serverTime);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "Dango_RankPage_Countdown", new <>z__ReadOnlySingleElementList<object>(((remainTimeDataFormat != null) ? remainTimeDataFormat.CountDownText : null) ?? ""));
			}
			else if (!this.CrossDayRefresh)
			{
				ControllerBase<RacingBetsController>.Instance.RacingBetsRankRequest(seasonData.Id, delegate
				{
					this.RefreshView();
					this.NextUpdateTime = (double)seasonData.GetNextRankUpdateTime();
				});
				this.CrossDayRefresh = true;
			}
			UUIText text2 = base.GetText(12);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(true);
			return;
		}
	}

	// Token: 0x06013D8A RID: 81290 RVA: 0x00588001 File Offset: 0x00586201
	[NullableContext(1)]
	private RacingBetsRankItem CreateRankItem()
	{
		return new RacingBetsRankItem();
	}

	// Token: 0x06013D8B RID: 81291 RVA: 0x00588008 File Offset: 0x00586208
	private void RefreshView()
	{
		List<IRacingBetsRankData> rankData = ModelBase<RacingBetsModel>.Instance.GetRankData();
		int count = rankData.Count;
		base.GetItem(10).SetUIActive(count == 0);
		UUIItem rankLoopViewRoot = this.RankLoopViewRoot;
		if (rankLoopViewRoot != null)
		{
			rankLoopViewRoot.SetUIActive(count > 0);
		}
		if (count > 0)
		{
			this.RankLoopView.RefreshByData(rankData, false, null, false);
		}
		this.RefreshSelfData();
	}

	// Token: 0x06013D8C RID: 81292 RVA: 0x00588068 File Offset: 0x00586268
	private void RefreshSelfData()
	{
		IRacingBetsSelfRankData selfRank = ModelBase<RacingBetsModel>.Instance.GetSelfRank();
		if (selfRank == null)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIText text = base.GetText(11);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
			return;
		}
		else
		{
			base.GetText(6).SetText(selfRank.Name, true);
			UUIText text2 = base.GetText(7);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(selfRank.HitNum);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			UUIText text3 = base.GetText(8);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(selfRank.CashNum);
			text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			UUITexture texture = base.GetTexture(5);
			PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(selfRank.HeadIcon, true);
			if (playerHeadData != null)
			{
				base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), texture, null);
			}
			RacingBetsRankStatus rankStatus = selfRank.RankStatus;
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(rankStatus == RacingBetsRankStatus.Rank);
			}
			UUIItem item4 = base.GetItem(3);
			if (item4 != null)
			{
				item4.SetUIActive(rankStatus == RacingBetsRankStatus.UnRank);
			}
			UUIText text4 = base.GetText(11);
			if (text4 != null)
			{
				text4.SetUIActive(false);
			}
			if (rankStatus == RacingBetsRankStatus.Top1)
			{
				UUIText text5 = base.GetText(11);
				if (text5 != null)
				{
					text5.SetUIActive(true);
				}
				UUIText text6 = base.GetText(11);
				if (text6 == null)
				{
					return;
				}
				text6.ShowTextNew("Dango_RankPage_Top1Percent");
				return;
			}
			else
			{
				if (rankStatus == RacingBetsRankStatus.Top50)
				{
					UUIText text7 = base.GetText(11);
					if (text7 != null)
					{
						text7.SetUIActive(true);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Dango_RankPage_Top50Percent", new <>z__ReadOnlySingleElementList<object>(selfRank.RankNum));
					return;
				}
				if (rankStatus == RacingBetsRankStatus.Rank)
				{
					UUIText text8 = base.GetText(11);
					if (text8 != null)
					{
						text8.SetUIActive(false);
					}
					UUIArtText artText = base.GetArtText(4);
					if (artText == null)
					{
						return;
					}
					artText.SetText(selfRank.RankNum.ToString());
				}
				return;
			}
		}
	}

	// Token: 0x06013D8D RID: 81293 RVA: 0x0058823D File Offset: 0x0058643D
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009A62 RID: 39522
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<RacingBetsRankItem, IRacingBetsRankData> RankLoopView;

	// Token: 0x04009A63 RID: 39523
	[Nullable(2)]
	private UUIItem RankLoopViewRoot;

	// Token: 0x04009A64 RID: 39524
	private bool CrossDayRefresh;

	// Token: 0x04009A65 RID: 39525
	private double NextUpdateTime;

	// Token: 0x02008B06 RID: 35590
	private class EComponent
	{
		// Token: 0x0402EE39 RID: 192057
		public const int RankLoopView = 0;

		// Token: 0x0402EE3A RID: 192058
		public const int RankViewItem = 1;

		// Token: 0x0402EE3B RID: 192059
		public const int SelfRankPanel = 2;

		// Token: 0x0402EE3C RID: 192060
		public const int SelfNoRankPanel = 3;

		// Token: 0x0402EE3D RID: 192061
		public const int SelfRankNumArtText = 4;

		// Token: 0x0402EE3E RID: 192062
		public const int SelfHeadIcon = 5;

		// Token: 0x0402EE3F RID: 192063
		public const int SelfNameText = 6;

		// Token: 0x0402EE40 RID: 192064
		public const int SelfHitNum = 7;

		// Token: 0x0402EE41 RID: 192065
		public const int SelfTotalMoney = 8;

		// Token: 0x0402EE42 RID: 192066
		public const int CloseBtn = 9;

		// Token: 0x0402EE43 RID: 192067
		public const int EmptyItem = 10;

		// Token: 0x0402EE44 RID: 192068
		public const int SelfPercentRankText = 11;

		// Token: 0x0402EE45 RID: 192069
		public const int RankUpdateTimeText = 12;
	}
}
