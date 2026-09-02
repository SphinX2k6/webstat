using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200123E RID: 4670
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerRankView : UiViewBase, IExtraUiPopFrameType
{
	// Token: 0x06007C63 RID: 31843 RVA: 0x0020B91B File Offset: 0x00209B1B
	public BabelTowerRankView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007C64 RID: 31844 RVA: 0x0020B941 File Offset: 0x00209B41
	[NullableContext(2)]
	public EUiBehaviourPopType? GetExtraPopFrameType(object param = null)
	{
		return new EUiBehaviourPopType?(EUiBehaviourPopType.BabelTowerRank);
	}

	// Token: 0x06007C65 RID: 31845 RVA: 0x0020B94A File Offset: 0x00209B4A
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnViewOpen));
	}

	// Token: 0x06007C66 RID: 31846 RVA: 0x0020B96A File Offset: 0x00209B6A
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnViewOpen));
	}

	// Token: 0x06007C67 RID: 31847 RVA: 0x0020B98A File Offset: 0x00209B8A
	private void OnViewOpen(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.PersonalRootView)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.BabelTowerRankView, null);
		}
	}

	// Token: 0x06007C68 RID: 31848 RVA: 0x0020B9AC File Offset: 0x00209BAC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007C69 RID: 31849 RVA: 0x0020BA78 File Offset: 0x00209C78
	private void OnToggleTabClick(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		this.ShowAnonymous = flag;
		this.BabelTowerData.SetSelfShowName(!this.ShowAnonymous);
		ControllerBase<BabelTowerController>.Instance.SetShowNameRequestAsync(this.BabelTowerData.Id, !this.ShowAnonymous).Forget();
		if (flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelRanking_Anonymousopen", Array.Empty<object>());
		}
		else
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelRanking_Anonymousstop", Array.Empty<object>());
		}
		this.RefreshRankListOnly();
	}

	// Token: 0x06007C6A RID: 31850 RVA: 0x0020BAFC File Offset: 0x00209CFC
	protected override void OnBeforeShow()
	{
		int? num = this.OpenParam as int?;
		if (num != null)
		{
			this.CurrentRankType = num.Value;
		}
		if (this.TogTabItemIns != null && this.BabelTowerData != null)
		{
			bool flag = !this.BabelTowerData.GetSelfShowName();
			this.ShowAnonymous = flag;
			this.TogTabItemIns.SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
		}
	}

	// Token: 0x06007C6B RID: 31851 RVA: 0x0020BB68 File Offset: 0x00209D68
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerRankView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerRankView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007C6C RID: 31852 RVA: 0x0020BBAC File Offset: 0x00209DAC
	private UniTask InitDropDown()
	{
		BabelTowerRankView.<InitDropDown>d__20 <InitDropDown>d__;
		<InitDropDown>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDropDown>d__.<>4__this = this;
		<InitDropDown>d__.<>1__state = -1;
		<InitDropDown>d__.<>t__builder.Start<BabelTowerRankView.<InitDropDown>d__20>(ref <InitDropDown>d__);
		return <InitDropDown>d__.<>t__builder.Task;
	}

	// Token: 0x06007C6D RID: 31853 RVA: 0x0020BBF0 File Offset: 0x00209DF0
	private TableTextArgNew GetLevelTextId(int levelId)
	{
		if (levelId == -1)
		{
			return new TableTextArgNew("BabelRanking_guanqia", Array.Empty<object>());
		}
		return new TableTextArgNew(ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId).NameText, Array.Empty<object>());
	}

	// Token: 0x06007C6E RID: 31854 RVA: 0x0020BC2E File Offset: 0x00209E2E
	private void OnDropDownSelect(int index, int levelId)
	{
		this.CurrentRankType = levelId;
		this.RefreshRankListByType();
	}

	// Token: 0x06007C6F RID: 31855 RVA: 0x0020BC3D File Offset: 0x00209E3D
	private void RefreshRankListByType()
	{
		this.RebuildRankListData();
		this.RefreshMyRankItem();
		this.RefreshScrollView();
	}

	// Token: 0x06007C70 RID: 31856 RVA: 0x0020BC51 File Offset: 0x00209E51
	private void RefreshRankListOnly()
	{
		this.RebuildRankListData();
		this.RefreshScrollView();
	}

	// Token: 0x06007C71 RID: 31857 RVA: 0x0020BC60 File Offset: 0x00209E60
	[return: Nullable(2)]
	private BabelTowerRankItemData TryAppendRankItem(List<BabelTowerRankItemData> list, PublicBabelTowerInfo protoData, bool isMyRank)
	{
		BabelTowerRankItemData babelTowerRankItemData = new BabelTowerRankItemData();
		babelTowerRankItemData.IsMyRank = isMyRank;
		if (!ControllerBase<BabelTowerController>.Instance.ConvertProtoToRankData(protoData, babelTowerRankItemData, this.CurrentRankType))
		{
			return null;
		}
		list.Add(babelTowerRankItemData);
		return babelTowerRankItemData;
	}

	// Token: 0x06007C72 RID: 31858 RVA: 0x0020BC98 File Offset: 0x00209E98
	private void RebuildRankListData()
	{
		List<BabelTowerRankItemData> rankListData = this.RankListData;
		rankListData.Clear();
		BabelTowerData babelTowerData = this.BabelTowerData;
		foreach (PublicBabelTowerInfo protoData in (((babelTowerData != null) ? babelTowerData.GetRawFriendData() : null) ?? new List<PublicBabelTowerInfo>()))
		{
			this.TryAppendRankItem(rankListData, protoData, false);
		}
		BabelTowerData babelTowerData2 = this.BabelTowerData;
		PublicBabelTowerInfo publicBabelTowerInfo = (babelTowerData2 != null) ? babelTowerData2.GetRawSelfData() : null;
		if (publicBabelTowerInfo != null)
		{
			this.TryAppendRankItem(rankListData, publicBabelTowerInfo, true);
		}
		rankListData.Sort(delegate(BabelTowerRankItemData a, BabelTowerRankItemData b)
		{
			if (a.PassStar != b.PassStar)
			{
				return b.PassStar - a.PassStar;
			}
			if (a.PassTime != b.PassTime)
			{
				return a.PassTime - b.PassTime;
			}
			return a.PlayerId - b.PlayerId;
		});
		for (int i = 0; i < rankListData.Count; i++)
		{
			rankListData[i].Ranking = i + 1;
		}
	}

	// Token: 0x06007C73 RID: 31859 RVA: 0x0020BD7C File Offset: 0x00209F7C
	private void RefreshMyRankItem()
	{
		if (this.MyRankItem == null)
		{
			return;
		}
		int num = this.RankListData.FindIndex((BabelTowerRankItemData d) => d.IsMyRank);
		if (num < 0)
		{
			this.MyRankItem.ShowLockState();
			return;
		}
		this.MyRankItemData.CopyFrom(this.RankListData[num]);
		this.MyRankItemData.ShowName = true;
		this.MyRankItem.Refresh(this.MyRankItemData, false, num);
	}

	// Token: 0x06007C74 RID: 31860 RVA: 0x0020BE04 File Offset: 0x0020A004
	private void RefreshScrollView()
	{
		bool flag = this.RankListData.Count > 0;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		this.RankScrollView.SetTargetRootComponentActive(flag);
		if (flag)
		{
			this.RankScrollView.RefreshByData(this.RankListData, false, null, false);
		}
	}

	// Token: 0x06007C75 RID: 31861 RVA: 0x0020BE56 File Offset: 0x0020A056
	private BabelTowerRankItem CreateItem()
	{
		return new BabelTowerRankItem();
	}

	// Token: 0x04003B86 RID: 15238
	private const int TOTAL_RANK_LEVEL_ID = -1;

	// Token: 0x04003B87 RID: 15239
	[Nullable(2)]
	private BabelTowerData BabelTowerData;

	// Token: 0x04003B88 RID: 15240
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BabelTowerRankItem, BabelTowerRankItemData> RankScrollView;

	// Token: 0x04003B89 RID: 15241
	[Nullable(2)]
	private BabelTowerRankItem MyRankItem;

	// Token: 0x04003B8A RID: 15242
	private bool ShowAnonymous;

	// Token: 0x04003B8B RID: 15243
	private readonly List<BabelTowerRankItemData> RankListData = new List<BabelTowerRankItemData>();

	// Token: 0x04003B8C RID: 15244
	private readonly BabelTowerRankItemData MyRankItemData = new BabelTowerRankItemData();

	// Token: 0x04003B8D RID: 15245
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonDropDown<TableTextArgNew, int> RankDropDown;

	// Token: 0x04003B8E RID: 15246
	private int CurrentRankType = -1;

	// Token: 0x04003B8F RID: 15247
	[Nullable(2)]
	private TogTabItemSubComponent TogTabItemIns;

	// Token: 0x020075AA RID: 30122
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028985 RID: 166277
		public const int DropDownItem = 0;

		// Token: 0x04028986 RID: 166278
		public const int TogTabItem = 1;

		// Token: 0x04028987 RID: 166279
		public const int LoopViewRank = 2;

		// Token: 0x04028988 RID: 166280
		public const int ItemRank = 3;

		// Token: 0x04028989 RID: 166281
		public const int ItemMyRank = 4;
	}
}
