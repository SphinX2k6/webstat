using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200248D RID: 9357
[NullableContext(1)]
[Nullable(0)]
public class PhantomBattleFettersViewItem : UiPanelBase
{
	// Token: 0x06012281 RID: 74369 RVA: 0x004FE35C File Offset: 0x004FC55C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent))
		};
		if (this.OnFastFilter != null)
		{
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, this.OnFastFilter)
			};
		}
		else
		{
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}
		this.BtnBindInfo.Add(new ValueTuple<int, Delegate>(12, new Action(this.OnClickDetect)));
	}

	// Token: 0x06012282 RID: 74370 RVA: 0x004FE500 File Offset: 0x004FC700
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.PhantomFettersScrollView = new LoopScrollView<PhantomFettersItem, PhantomFetterItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<PhantomFettersItem>(this.OnGridProxyCreate), false);
		this.FilterEntrance = new FilterEntrance<PhantomFetterGroup>(base.GetItem(6), new TUpdateDataListFunction<PhantomFetterGroup>(this.OnFilterRefresh));
		this.SortEntrance = new SortEntrance<PhantomFetterGroup>(base.GetItem(7), new TUpdateDataListFunction<PhantomFetterGroup>(this.OnFilterRefresh));
		this.Layout = new GenericLayout<VisionFetterDescItem, VisionFetterDescData>(base.GetVerticalLayout(3), new Func<VisionFetterDescItem>(this.InitItem), null, false, true);
		this.MonsterLayout = new GenericLayout<VisionFetterMonsterItem, VisionFetterMonsterData>(base.GetVerticalLayout(10), new Func<VisionFetterMonsterItem>(this.InitMonsterItem), null, false, true);
		this.FilterEntrance.SetUiActive(!ModelBase<CalabashModel>.Instance.OnlyShowBattleFettersTab);
		this.SortEntrance.SetUiActive(!ModelBase<CalabashModel>.Instance.OnlyShowBattleFettersTab);
	}

	// Token: 0x06012283 RID: 74371 RVA: 0x004FE5FD File Offset: 0x004FC7FD
	private VisionFetterMonsterItem InitMonsterItem()
	{
		return new VisionFetterMonsterItem();
	}

	// Token: 0x06012284 RID: 74372 RVA: 0x004FE604 File Offset: 0x004FC804
	public UniTask PlayStartSequence()
	{
		PhantomBattleFettersViewItem.<PlayStartSequence>d__18 <PlayStartSequence>d__;
		<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayStartSequence>d__.<>4__this = this;
		<PlayStartSequence>d__.<>1__state = -1;
		<PlayStartSequence>d__.<>t__builder.Start<PhantomBattleFettersViewItem.<PlayStartSequence>d__18>(ref <PlayStartSequence>d__);
		return <PlayStartSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06012285 RID: 74373 RVA: 0x004FE648 File Offset: 0x004FC848
	public UniTask PlayHideSequence()
	{
		PhantomBattleFettersViewItem.<PlayHideSequence>d__19 <PlayHideSequence>d__;
		<PlayHideSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideSequence>d__.<>4__this = this;
		<PlayHideSequence>d__.<>1__state = -1;
		<PlayHideSequence>d__.<>t__builder.Start<PhantomBattleFettersViewItem.<PlayHideSequence>d__19>(ref <PlayHideSequence>d__);
		return <PlayHideSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06012286 RID: 74374 RVA: 0x004FE68B File Offset: 0x004FC88B
	private VisionFetterDescItem InitItem()
	{
		return new VisionFetterDescItem();
	}

	// Token: 0x06012287 RID: 74375 RVA: 0x004FE694 File Offset: 0x004FC894
	private void OnClickDetect()
	{
		SkipTaskManager.RunByConfigId(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.CurrentSelectGroupId).AccessId, null);
	}

	// Token: 0x06012288 RID: 74376 RVA: 0x004FE6BF File Offset: 0x004FC8BF
	private PhantomFettersItem OnGridProxyCreate()
	{
		PhantomFettersItem phantomFettersItem = new PhantomFettersItem();
		phantomFettersItem.BindOnItemButtonClickedCallback(new Action<PhantomFetterItemData>(this.OnItemButtonClicked));
		return phantomFettersItem;
	}

	// Token: 0x06012289 RID: 74377 RVA: 0x004FE6D8 File Offset: 0x004FC8D8
	protected override void OnBeforeShow()
	{
		object openParam = this.OpenParam;
		bool flag;
		bool flag2;
		if (openParam is bool)
		{
			flag = (bool)openParam;
			flag2 = true;
		}
		else
		{
			flag2 = false;
		}
		this.NeedProcessObserver = (flag2 && flag);
		if (Singleton<UiSceneManager>.Instance.HasVisionSkeletalHandle() && this.NeedProcessObserver)
		{
			UiModelBase model = Singleton<UiSceneManager>.Instance.GetVisionSkeletalHandle().Model;
			UiModelDataComponent uiModelDataComponent = (model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null;
			this.ObserverShowState = (uiModelDataComponent != null && uiModelDataComponent.GetVisible());
			if (uiModelDataComponent != null)
			{
				uiModelDataComponent.SetVisible(false);
			}
		}
		this.UpdateFliterComponent();
	}

	// Token: 0x0601228A RID: 74378 RVA: 0x004FE75C File Offset: 0x004FC95C
	private void UpdateFliterComponent()
	{
		PhantomFetterGroup[] phantomFetterGroupList = ModelBase<CalabashModel>.Instance.GetPhantomFetterGroupList();
		this.FilterEntrance.UpdateData(this.UseWayId, phantomFetterGroupList.ToList<PhantomFetterGroup>(), new object[]
		{
			this.RoleId
		});
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(this.UseWayId);
		this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId);
		this.SortEntrance.UpdateData(this.UseWayId, phantomFetterGroupList.ToList<PhantomFetterGroup>(), new object[]
		{
			this.RoleId
		});
		int uniqueIdByGroupId2 = this.SortEntrance.GetUniqueIdByGroupId(this.UseWayId);
		this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId2);
	}

	// Token: 0x0601228B RID: 74379 RVA: 0x004FE808 File Offset: 0x004FCA08
	private void SortFetterDataListByRecommend()
	{
		if (this.PhantomFetterDataList == null || this.PhantomFetterDataList.Count == 0)
		{
			return;
		}
		if (this.RecommendGroupIds.Count == 0)
		{
			return;
		}
		Dictionary<int, int> orderMap = new Dictionary<int, int>();
		for (int i = 0; i < this.RecommendGroupIds.Count; i++)
		{
			orderMap[this.RecommendGroupIds[i]] = i;
		}
		this.PhantomFetterDataList.Sort(delegate(PhantomFetterItemData a, PhantomFetterItemData b)
		{
			int value;
			int? num = orderMap.TryGetValue(a.PhantomFetterGroup.Value.Id, out value) ? new int?(value) : null;
			int value2;
			int? num2 = orderMap.TryGetValue(b.PhantomFetterGroup.Value.Id, out value2) ? new int?(value2) : null;
			if (num != null && num2 != null)
			{
				return num.Value - num2.Value;
			}
			if (num != null)
			{
				return -1;
			}
			if (num2 != null)
			{
				return 1;
			}
			return 0;
		});
	}

	// Token: 0x0601228C RID: 74380 RVA: 0x004FE890 File Offset: 0x004FCA90
	private void OnFilterRefresh(List<PhantomFetterGroup> list, bool isOutSideChange, EFilterSortType operationType)
	{
		this.PhantomFetterDataList = new List<PhantomFetterItemData>();
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			PhantomFetterItemData phantomFetterItemData = new PhantomFetterItemData();
			phantomFetterItemData.PhantomFetterGroup = new PhantomFetterGroup?(list[i]);
			phantomFetterItemData.RoleId = this.RoleId;
			phantomFetterItemData.RecommendGroupIds = this.RecommendGroupIds;
			this.PhantomFetterDataList.Add(phantomFetterItemData);
		}
		this.SortFetterDataListByRecommend();
		this.RefreshScrollView();
		this.RefreshRightItem(list);
	}

	// Token: 0x0601228D RID: 74381 RVA: 0x004FE90C File Offset: 0x004FCB0C
	private void RefreshRightItem(IList list)
	{
		base.GetItem(8).SetUIActive(list.Count > 0);
		base.GetButton(5).RootUIComp.Get().SetUIActive(list.Count > 0 && this.OnFastFilter != null);
	}

	// Token: 0x0601228E RID: 74382 RVA: 0x004FE95C File Offset: 0x004FCB5C
	private void RefreshMonster(List<int> monsterList)
	{
		int count = monsterList.Count;
		Dictionary<int, List<VisionDetailMonsterItemData>> dictionary = new Dictionary<int, List<VisionDetailMonsterItemData>>();
		for (int i = 0; i < count; i++)
		{
			int rarity = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterList[i])[0].Rarity;
			int cost = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost;
			List<VisionDetailMonsterItemData> list;
			if (!dictionary.TryGetValue(cost, out list))
			{
				list = new List<VisionDetailMonsterItemData>();
				dictionary.Add(cost, list);
			}
			list.Add(new VisionDetailMonsterItemData(monsterList[i], 0, this.RoleId));
		}
		int? onlyMonsterCostShowMaxLevel = ModelBase<CalabashModel>.Instance.OnlyMonsterCostShowMaxLevel;
		List<VisionFetterMonsterData> list2 = new List<VisionFetterMonsterData>();
		foreach (KeyValuePair<int, List<VisionDetailMonsterItemData>> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			List<VisionDetailMonsterItemData> value = keyValuePair.Value;
			if (onlyMonsterCostShowMaxLevel != null)
			{
				int? num = onlyMonsterCostShowMaxLevel;
				int num2 = key;
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					continue;
				}
			}
			list2.Add(new VisionFetterMonsterData
			{
				Cost = key,
				MonsterList = value
			});
		}
		list2.Sort((VisionFetterMonsterData a, VisionFetterMonsterData b) => b.Cost - a.Cost);
		if (list2.Count > 0)
		{
			this.MonsterLayout.RefreshByData(list2, null, false);
		}
		int monsterFindCountByMonsterIdArray = ModelBase<PhantomBattleModel>.Instance.GetMonsterFindCountByMonsterIdArray(monsterList.ToArray());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "Illustration_Progress_Iteration", new <>z__ReadOnlyArray<object>(new object[]
		{
			monsterFindCountByMonsterIdArray,
			monsterList.Count
		}));
	}

	// Token: 0x0601228F RID: 74383 RVA: 0x004FEB38 File Offset: 0x004FCD38
	private void RefreshScrollView()
	{
		if (this.PhantomFetterDataList == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YZY, "没有羁绊幻象", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PhantomFettersScrollView.DeselectCurrentGridProxy(false);
		this.PhantomFettersScrollView.ReloadData(this.PhantomFetterDataList, false);
		if (this.OutSizeSelectFetterGroupId == 0)
		{
			this.PhantomFettersScrollView.SelectGridProxy(0, false);
			this.PhantomFettersScrollView.RefreshGridProxy(0);
			this.RefreshRight(this.PhantomFetterDataList[0].PhantomFetterGroup.Value);
			return;
		}
		int gridIndex = 0;
		int count = this.PhantomFetterDataList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.PhantomFetterDataList[i].PhantomFetterGroup.Value.Id == this.OutSizeSelectFetterGroupId)
			{
				gridIndex = i;
				break;
			}
		}
		this.PhantomFettersScrollView.ScrollToGridIndex(gridIndex, true);
		this.PhantomFettersScrollView.SelectGridProxy(gridIndex, false);
		this.PhantomFettersScrollView.RefreshGridProxy(gridIndex);
	}

	// Token: 0x06012290 RID: 74384 RVA: 0x004FEC34 File Offset: 0x004FCE34
	public void SelectByFetterId(int id)
	{
		int num = this.PhantomFetterDataList.FindIndex((PhantomFetterItemData data) => data.PhantomFetterGroup.Value.Id == id);
		if (num >= 0)
		{
			this.PhantomFettersScrollView.ScrollToGridIndex(num, true);
			this.PhantomFettersScrollView.SelectGridProxy(num, false);
		}
	}

	// Token: 0x06012291 RID: 74385 RVA: 0x004FEC84 File Offset: 0x004FCE84
	public void SetSelectRoleId(int roleId)
	{
		this.RoleId = roleId;
	}

	// Token: 0x06012292 RID: 74386 RVA: 0x004FEC8D File Offset: 0x004FCE8D
	public void SetRecommendGroupIds(List<int> groupIds)
	{
		this.RecommendGroupIds = groupIds;
	}

	// Token: 0x06012293 RID: 74387 RVA: 0x004FEC98 File Offset: 0x004FCE98
	private void RefreshRight(PhantomFetterGroup itemData)
	{
		this.CurrentSelectGroupId = itemData.Id;
		this.RefreshName(itemData.FetterGroupName);
		this.RefreshInfo(itemData.FetterMap());
		this.RefreshConfigInfo(itemData.FetterGroupDesc);
		List<int> monsterList = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(this.CurrentSelectGroupId).ToList<int>();
		this.RefreshMonster(monsterList);
		base.GetScrollViewWithScrollbar(13).SetScrollProgress(0f);
	}

	// Token: 0x06012294 RID: 74388 RVA: 0x004FED08 File Offset: 0x004FCF08
	private void RefreshName(string name)
	{
		base.GetText(2).ShowTextNew(name);
	}

	// Token: 0x06012295 RID: 74389 RVA: 0x004FED18 File Offset: 0x004FCF18
	private void RefreshInfo(Dictionary<int, int> data)
	{
		List<VisionFetterDescData> list = new List<VisionFetterDescData>();
		foreach (KeyValuePair<int, int> keyValuePair in data)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			list.Add(new VisionFetterDescData
			{
				Key = key,
				Value = value
			});
		}
		this.Layout.RefreshByData(list, null, true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) == "Switch")
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.ReplaySequenceByKey("Switch");
			return;
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
			if (levelSequencePlayer4 == null)
			{
				return;
			}
			levelSequencePlayer4.PlayLevelSequenceByName("Switch", false, null, false);
			return;
		}
	}

	// Token: 0x06012296 RID: 74390 RVA: 0x004FEE0C File Offset: 0x004FD00C
	private void RefreshConfigInfo(string configInfo)
	{
		base.GetText(4).ShowTextNew(configInfo);
	}

	// Token: 0x06012297 RID: 74391 RVA: 0x004FEE1C File Offset: 0x004FD01C
	private void OnItemButtonClicked(PhantomFetterItemData itemData)
	{
		this.PhantomFettersScrollView.DeselectCurrentGridProxy(false);
		int gridIndex = this.PhantomFetterDataList.IndexOf(itemData);
		if (!this.PhantomFettersScrollView.IsGridDisplaying(gridIndex))
		{
			return;
		}
		this.RefreshRight(itemData.PhantomFetterGroup.Value);
		this.PhantomFettersScrollView.SelectGridProxy(gridIndex, false);
		this.PhantomFettersScrollView.RefreshGridProxy(gridIndex);
	}

	// Token: 0x06012298 RID: 74392 RVA: 0x004FEE7B File Offset: 0x004FD07B
	public int GetCurrentSelectGroupId()
	{
		return this.CurrentSelectGroupId;
	}

	// Token: 0x06012299 RID: 74393 RVA: 0x004FEE84 File Offset: 0x004FD084
	protected override void OnBeforeDestroy()
	{
		ModelBase<PhantomBattleModel>.Instance.CurrentSelectedFetter = null;
		if (Singleton<UiSceneManager>.Instance.HasVisionSkeletalHandle() && this.NeedProcessObserver)
		{
			SkeletalObserverHandle visionSkeletalHandle = Singleton<UiSceneManager>.Instance.GetVisionSkeletalHandle();
			UiModelBase uiModelBase = (visionSkeletalHandle != null) ? visionSkeletalHandle.Model : null;
			if (uiModelBase != null)
			{
				Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, this.ObserverShowState);
			}
		}
		if (this.PhantomFettersScrollView != null)
		{
			this.PhantomFettersScrollView.ClearGridProxies();
			this.PhantomFettersScrollView = null;
		}
	}

	// Token: 0x04008DB3 RID: 36275
	private readonly EFilterSortGroupId UseWayId = EFilterSortGroupId.PhantomFetter;

	// Token: 0x04008DB4 RID: 36276
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<PhantomFettersItem, PhantomFetterItemData> PhantomFettersScrollView;

	// Token: 0x04008DB5 RID: 36277
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<PhantomFetterItemData> PhantomFetterDataList;

	// Token: 0x04008DB6 RID: 36278
	[Nullable(2)]
	private FilterEntrance<PhantomFetterGroup> FilterEntrance;

	// Token: 0x04008DB7 RID: 36279
	[Nullable(2)]
	private SortEntrance<PhantomFetterGroup> SortEntrance;

	// Token: 0x04008DB8 RID: 36280
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionFetterDescItem, VisionFetterDescData> Layout;

	// Token: 0x04008DB9 RID: 36281
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionFetterMonsterItem, VisionFetterMonsterData> MonsterLayout;

	// Token: 0x04008DBA RID: 36282
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04008DBB RID: 36283
	private int CurrentSelectGroupId;

	// Token: 0x04008DBC RID: 36284
	private int RoleId;

	// Token: 0x04008DBD RID: 36285
	private List<int> RecommendGroupIds = new List<int>();

	// Token: 0x04008DBE RID: 36286
	private readonly int OutSizeSelectFetterGroupId;

	// Token: 0x04008DBF RID: 36287
	private bool ObserverShowState;

	// Token: 0x04008DC0 RID: 36288
	private bool NeedProcessObserver;

	// Token: 0x04008DC1 RID: 36289
	[Nullable(2)]
	public Action OnFastFilter;
}
