using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AF8 RID: 6904
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssRankItem : GridProxyAbstract<DangoRankItemData>
{
	// Token: 0x0600C6D4 RID: 50900 RVA: 0x003491D9 File Offset: 0x003473D9
	public DangoAbyssRankItem(bool isShowInBottom)
	{
		this.IsShowInBottom = isShowInBottom;
	}

	// Token: 0x0600C6D5 RID: 50901 RVA: 0x003491E8 File Offset: 0x003473E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C6D6 RID: 50902 RVA: 0x0034935B File Offset: 0x0034755B
	protected override void OnStart()
	{
		this.InitOnlineNameLayout();
		this.InitRankGridLayout();
	}

	// Token: 0x0600C6D7 RID: 50903 RVA: 0x00349369 File Offset: 0x00347569
	private void InitOnlineNameLayout()
	{
		this.OnlineNameLayout = new GenericLayout<OnlineItem, OnlineData>(base.GetLayoutBase(4), new Func<OnlineItem>(this.InitOnlineItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600C6D8 RID: 50904 RVA: 0x0034939C File Offset: 0x0034759C
	private void InitRankGridLayout()
	{
		this.RankGridLayout = new GenericLayout<RankRoleGridItem, DangoAbyssRankRoleData>(base.GetLayoutBase(7), new Func<RankRoleGridItem>(this.InitRankGridItem), base.GetItem(8).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600C6D9 RID: 50905 RVA: 0x003493CF File Offset: 0x003475CF
	private OnlineItem InitOnlineItem()
	{
		return new OnlineItem(this.IsShowInBottom);
	}

	// Token: 0x0600C6DA RID: 50906 RVA: 0x003493DC File Offset: 0x003475DC
	private RankRoleGridItem InitRankGridItem()
	{
		return new RankRoleGridItem();
	}

	// Token: 0x0600C6DB RID: 50907 RVA: 0x003493E4 File Offset: 0x003475E4
	private void RefreshEmpty()
	{
		base.GetText(1).SetUIActive(false);
		base.GetItem(2).SetUIActive(true);
		UUIItem rootUiItem = this.OnlineNameLayout.GetRootUiItem();
		if (rootUiItem != null)
		{
			rootUiItem.SetUIActive(false);
		}
		string newText = ModelBase<PlayerInfoModel>.Instance.GetAccountName(true) ?? "";
		base.GetText(3).SetText(newText, true);
		base.GetText(3).SetUIActive(true);
		base.GetText(6).SetUIActive(false);
		UUIItem rootUiItem2 = this.RankGridLayout.GetRootUiItem();
		if (rootUiItem2 != null)
		{
			rootUiItem2.SetUIActive(false);
		}
		base.GetItem(9).SetUIActive(true);
		this.RefreshRankBg();
	}

	// Token: 0x0600C6DC RID: 50908 RVA: 0x0034948C File Offset: 0x0034768C
	private void RefreshRankBg()
	{
		base.GetTexture(0).SetUIActive(true);
		string resourceId = this.IfRankData ? this.RankItemData.AbyssChallengeInfo.RankBg : "T_AnniversaryCelebrationRankOwnBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
	}

	// Token: 0x0600C6DD RID: 50909 RVA: 0x003494EC File Offset: 0x003476EC
	private void RefreshRankNum()
	{
		UUIText text = base.GetText(1);
		text.SetUIActive(true);
		base.GetItem(2).SetUIActive(!this.RankItemData.AbyssChallengeInfo.IsInRank);
		text.SetText(this.RankItemData.AbyssChallengeInfo.Rank.ToString(), true);
	}

	// Token: 0x0600C6DE RID: 50910 RVA: 0x00349544 File Offset: 0x00347744
	private void RefreshTimeScore()
	{
		base.GetText(6).SetUIActive(true);
		if (!ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(this.RankItemData.AbyssChallengeInfo.GetChallengeId()).Value.IsEndless)
		{
			string timeDataFormat = Singleton<TimeUtil>.Instance.GetTimeDataFormat((double)this.RankItemData.AbyssChallengeInfo.GetPassTime());
			base.GetText(6).SetText(timeDataFormat, true);
			return;
		}
		int progress = this.RankItemData.AbyssChallengeInfo.GetProgress();
		if (progress == 100)
		{
			string timeDataFormat2 = Singleton<TimeUtil>.Instance.GetTimeDataFormat((double)this.RankItemData.AbyssChallengeInfo.GetPassTime());
			base.GetText(6).SetText(timeDataFormat2, true);
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(progress);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		base.GetText(6).SetText(newText, true);
	}

	// Token: 0x0600C6DF RID: 50911 RVA: 0x00349630 File Offset: 0x00347830
	public UniTask RefreshPlayerName()
	{
		DangoAbyssRankItem.<RefreshPlayerName>d__17 <RefreshPlayerName>d__;
		<RefreshPlayerName>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshPlayerName>d__.<>4__this = this;
		<RefreshPlayerName>d__.<>1__state = -1;
		<RefreshPlayerName>d__.<>t__builder.Start<DangoAbyssRankItem.<RefreshPlayerName>d__17>(ref <RefreshPlayerName>d__);
		return <RefreshPlayerName>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6E0 RID: 50912 RVA: 0x00349674 File Offset: 0x00347874
	private UniTask RefreshRankGrid()
	{
		DangoAbyssRankItem.<RefreshRankGrid>d__18 <RefreshRankGrid>d__;
		<RefreshRankGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRankGrid>d__.<>4__this = this;
		<RefreshRankGrid>d__.<>1__state = -1;
		<RefreshRankGrid>d__.<>t__builder.Start<DangoAbyssRankItem.<RefreshRankGrid>d__18>(ref <RefreshRankGrid>d__);
		return <RefreshRankGrid>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6E1 RID: 50913 RVA: 0x003496B7 File Offset: 0x003478B7
	public override void Refresh(DangoRankItemData data, bool isSelected = false, int gridIndex = 0)
	{
		this.Refresh(data, isSelected, gridIndex, true);
	}

	// Token: 0x0600C6E2 RID: 50914 RVA: 0x003496C4 File Offset: 0x003478C4
	public void Refresh(DangoRankItemData data, bool isSelected, int gridIndex, bool ifRankData)
	{
		this.IfRankData = ifRankData;
		this.RankItemData = data;
		if (data.AbyssChallengeInfo.IsEmpty)
		{
			this.RefreshEmpty();
			return;
		}
		this.RefreshRankBg();
		this.RefreshRankNum();
		this.RefreshPlayerName();
		this.RefreshTimeScore();
		this.RefreshRankGrid();
	}

	// Token: 0x0600C6E3 RID: 50915 RVA: 0x00349714 File Offset: 0x00347914
	public bool IsSelfItem()
	{
		return this.RankItemData.AbyssChallengeInfo.IsSelfInData;
	}

	// Token: 0x04005F3D RID: 24381
	private readonly bool IsShowInBottom;

	// Token: 0x04005F3E RID: 24382
	private bool IfRankData;

	// Token: 0x04005F3F RID: 24383
	private DangoRankItemData RankItemData;

	// Token: 0x04005F40 RID: 24384
	private GenericLayout<OnlineItem, OnlineData> OnlineNameLayout;

	// Token: 0x04005F41 RID: 24385
	private GenericLayout<RankRoleGridItem, DangoAbyssRankRoleData> RankGridLayout;

	// Token: 0x02007DCB RID: 32203
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402AD92 RID: 175506
		public const int RankBg = 0;

		// Token: 0x0402AD93 RID: 175507
		public const int RankNum = 1;

		// Token: 0x0402AD94 RID: 175508
		public const int NoneRankItem = 2;

		// Token: 0x0402AD95 RID: 175509
		public const int Name = 3;

		// Token: 0x0402AD96 RID: 175510
		public const int OnlineNameLayout = 4;

		// Token: 0x0402AD97 RID: 175511
		public const int OnlineNameItem = 5;

		// Token: 0x0402AD98 RID: 175512
		public const int ScoreText = 6;

		// Token: 0x0402AD99 RID: 175513
		public const int RankGridLayout = 7;

		// Token: 0x0402AD9A RID: 175514
		public const int RankGridItem = 8;

		// Token: 0x0402AD9B RID: 175515
		public const int NoneScoreText = 9;
	}
}
