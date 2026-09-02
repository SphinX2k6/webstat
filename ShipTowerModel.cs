using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

// Token: 0x020029A1 RID: 10657
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ShipTowerModel : ModelBase<ShipTowerModel>
{
	// Token: 0x17001BD0 RID: 7120
	// (get) Token: 0x06015316 RID: 86806 RVA: 0x005DDE0F File Offset: 0x005DC00F
	public int CurSeason
	{
		get
		{
			return this.Season;
		}
	}

	// Token: 0x17001BD1 RID: 7121
	// (get) Token: 0x06015317 RID: 86807 RVA: 0x005DDE18 File Offset: 0x005DC018
	public SlashAndTowerSeason? CurSeasonCfg
	{
		get
		{
			if (this.CurSeason == 0)
			{
				return null;
			}
			return ConfigBase<ShipTowerConfig>.Instance.GetSeasonCfgById(this.CurSeason);
		}
	}

	// Token: 0x17001BD2 RID: 7122
	// (get) Token: 0x06015318 RID: 86808 RVA: 0x005DDE47 File Offset: 0x005DC047
	public long CurSeasonEndTime
	{
		get
		{
			return this.SeasonEndTime;
		}
	}

	// Token: 0x17001BD3 RID: 7123
	// (get) Token: 0x06015319 RID: 86809 RVA: 0x005DDE4F File Offset: 0x005DC04F
	public bool CurIsHaveRecord
	{
		get
		{
			return this.IsHaveRecord;
		}
	}

	// Token: 0x17001BD4 RID: 7124
	// (get) Token: 0x0601531A RID: 86810 RVA: 0x005DDE57 File Offset: 0x005DC057
	public IReadOnlyList<ShipTowerStageData> TowerStageDataList
	{
		get
		{
			return this.StageDataList;
		}
	}

	// Token: 0x17001BD5 RID: 7125
	// (get) Token: 0x0601531B RID: 86811 RVA: 0x005DDE5F File Offset: 0x005DC05F
	public IReadOnlyDictionary<int, ShipTowerStageData> TowerStageDataMap
	{
		get
		{
			return this.StageDataMap;
		}
	}

	// Token: 0x17001BD6 RID: 7126
	// (get) Token: 0x0601531C RID: 86812 RVA: 0x005DDE67 File Offset: 0x005DC067
	public int GetRewardTotalNum
	{
		get
		{
			return this.RewardTotalNum;
		}
	}

	// Token: 0x17001BD7 RID: 7127
	// (get) Token: 0x0601531D RID: 86813 RVA: 0x005DDE6F File Offset: 0x005DC06F
	public bool IsRewardAllReceived
	{
		get
		{
			return this.ReceivedAwardScoreIdSet.Count == this.RewardTotalNum;
		}
	}

	// Token: 0x0601531E RID: 86814 RVA: 0x005DDE84 File Offset: 0x005DC084
	protected override bool OnInit()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.ShipTowerView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "ShipTowerModel.CheckCanOpen");
		return true;
	}

	// Token: 0x0601531F RID: 86815 RVA: 0x005DDEA8 File Offset: 0x005DC0A8
	protected override bool OnClear()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.ShipTowerView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
		this.StageDataList.Clear();
		this.StageDataMap.Clear();
		this.BuffQualityList.Clear();
		this.BuffQualityMap.Clear();
		return true;
	}

	// Token: 0x06015320 RID: 86816 RVA: 0x005DDEFD File Offset: 0x005DC0FD
	protected override bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x06015321 RID: 86817 RVA: 0x005DDF00 File Offset: 0x005DC100
	public void InitData(bool force = false)
	{
		if (this.IsInitData && !force)
		{
			return;
		}
		this.IsInitData = true;
		this.InitAreaList();
		this.InitPlayerGetBuffList();
	}

	// Token: 0x06015322 RID: 86818 RVA: 0x005DDF24 File Offset: 0x005DC124
	private void InitPlayerGetBuffList()
	{
		HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.ShipTowerGetBuffSet, null);
		if (player != null)
		{
			foreach (int item in player)
			{
				this.PlayerGetBuffSet.Add(item);
			}
		}
	}

	// Token: 0x06015323 RID: 86819 RVA: 0x005DDF84 File Offset: 0x005DC184
	public void AddPlayerGetBuff(int buffId)
	{
		this.PlayerGetBuffSet.Add(buffId);
		LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.ShipTowerGetBuffSet, this.PlayerGetBuffSet);
		Singleton<EventSystem>.Instance.Emit(EEventName.ShipTowerBuffNewUpdate);
	}

	// Token: 0x06015324 RID: 86820 RVA: 0x005DDFB1 File Offset: 0x005DC1B1
	private void InitBuffQualityList()
	{
		this.AddBuffQualityListBySeason(0);
	}

	// Token: 0x06015325 RID: 86821 RVA: 0x005DDFBC File Offset: 0x005DC1BC
	private void AddBuffQualityListBySeason(int season)
	{
		IEnumerable<SlashBuffToItem> enumerable = ConfigBase<ShipTowerConfig>.Instance.GetBuffCfgBySeason(season) ?? new List<SlashBuffToItem>();
		int curSeason = this.CurSeason;
		List<SlashBuffToItem> list = new List<SlashBuffToItem>();
		foreach (SlashBuffToItem item in enumerable)
		{
			if (season != 0)
			{
				list.Add(item);
			}
			else
			{
				bool flag = curSeason >= item.StartSeason;
				bool flag2 = item.EndSeason == -1 || curSeason <= item.EndSeason;
				if (flag && flag2)
				{
					list.Add(item);
				}
			}
		}
		foreach (SlashBuffToItem cfg in list)
		{
			this.AddBuffData(cfg);
		}
		this.UpdateBuffQualityList();
	}

	// Token: 0x06015326 RID: 86822 RVA: 0x005DE0A4 File Offset: 0x005DC2A4
	public void CheckOldSeasonBuffQualityList()
	{
		foreach (ShipTowerBuffQuality shipTowerBuffQuality in this.BuffQualityList)
		{
			bool flag = false;
			foreach (ShipTowerBuffData buffData in shipTowerBuffQuality.BuffList)
			{
				if (this.IsOldSeasonByBuffData(buffData))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				List<ShipTowerBuffData> list = new List<ShipTowerBuffData>();
				foreach (ShipTowerBuffData shipTowerBuffData in shipTowerBuffQuality.BuffList)
				{
					if (!this.IsOldSeasonByBuffData(shipTowerBuffData))
					{
						list.Add(shipTowerBuffData);
					}
				}
				shipTowerBuffQuality.BuffList.Clear();
				shipTowerBuffQuality.BuffList.AddRange(list);
				if (shipTowerBuffQuality.BuffList.Count == 0)
				{
					this.BuffQualityMap.Remove(shipTowerBuffQuality.Quality);
				}
			}
		}
	}

	// Token: 0x06015327 RID: 86823 RVA: 0x005DE1D4 File Offset: 0x005DC3D4
	private bool IsOldSeasonByBuffData(ShipTowerBuffData buffData)
	{
		if (buffData.Season != 0)
		{
			return this.IsOldSeason(buffData.Season);
		}
		SlashBuffToItem? buffCfgByItemId = ConfigBase<ShipTowerConfig>.Instance.GetBuffCfgByItemId(buffData.ItemId);
		if (buffCfgByItemId == null)
		{
			return true;
		}
		bool flag = this.CurSeason >= buffCfgByItemId.Value.StartSeason;
		bool flag2 = buffCfgByItemId.Value.EndSeason == -1 || this.CurSeason <= buffCfgByItemId.Value.EndSeason;
		return !flag || !flag2;
	}

	// Token: 0x06015328 RID: 86824 RVA: 0x005DE264 File Offset: 0x005DC464
	public List<SlashAndTowerCfg> GetZeroSeasonInstConfig()
	{
		IReadOnlyList<SlashAndTowerCfg> stageCfgBySeason = ConfigBase<ShipTowerConfig>.Instance.GetStageCfgBySeason(0);
		if (stageCfgBySeason == null)
		{
			return new List<SlashAndTowerCfg>();
		}
		Dictionary<int, List<SlashAndTowerCfg>> dictionary = new Dictionary<int, List<SlashAndTowerCfg>>();
		foreach (SlashAndTowerCfg item in stageCfgBySeason)
		{
			if (!dictionary.ContainsKey(item.OrderIndex))
			{
				dictionary[item.OrderIndex] = new List<SlashAndTowerCfg>();
			}
			dictionary[item.OrderIndex].Add(item);
		}
		List<SlashAndTowerCfg> list = new List<SlashAndTowerCfg>();
		foreach (KeyValuePair<int, List<SlashAndTowerCfg>> keyValuePair in dictionary)
		{
			List<SlashAndTowerCfg> value = keyValuePair.Value;
			if (value.Count == 1)
			{
				list.Add(value[0]);
			}
			else
			{
				SlashAndTowerCfg? slashAndTowerCfg = null;
				int num = 0;
				foreach (SlashAndTowerCfg value2 in value)
				{
					if (num <= value2.SeasonVersion && this.CurSeason >= value2.SeasonVersion)
					{
						num = value2.SeasonVersion;
						slashAndTowerCfg = new SlashAndTowerCfg?(value2);
					}
				}
				if (slashAndTowerCfg != null)
				{
					list.Add(slashAndTowerCfg.Value);
				}
			}
		}
		list.Sort((SlashAndTowerCfg a, SlashAndTowerCfg b) => a.OrderIndex - b.OrderIndex);
		return list;
	}

	// Token: 0x06015329 RID: 86825 RVA: 0x005DE40C File Offset: 0x005DC60C
	public bool IsOldSeason(int season)
	{
		return season != 0 && season != this.CurSeason;
	}

	// Token: 0x0601532A RID: 86826 RVA: 0x005DE420 File Offset: 0x005DC620
	private void AddBuffData(SlashBuffToItem cfg)
	{
		if (this.BuffDataMap.ContainsKey(cfg.Id))
		{
			return;
		}
		ShipTowerBuffData shipTowerBuffData = new ShipTowerBuffData();
		shipTowerBuffData.Init(cfg);
		this.BuffDataMap[cfg.Id] = shipTowerBuffData;
		if (this.BuffQualityMap.ContainsKey(shipTowerBuffData.Quality))
		{
			this.BuffQualityMap[shipTowerBuffData.Quality].BuffList.Add(shipTowerBuffData);
			return;
		}
		ShipTowerBuffQuality value = new ShipTowerBuffQuality
		{
			Quality = shipTowerBuffData.Quality,
			Title = shipTowerBuffData.GetQualityTitle(),
			BuffList = new List<ShipTowerBuffData>
			{
				shipTowerBuffData
			}
		};
		this.BuffQualityMap[shipTowerBuffData.Quality] = value;
	}

	// Token: 0x0601532B RID: 86827 RVA: 0x005DE4D4 File Offset: 0x005DC6D4
	private void UpdateBuffQualityList()
	{
		this.BuffQualityList.Clear();
		this.BuffQualityList.AddRange(this.BuffQualityMap.Values);
		this.BuffQualityList.Sort((ShipTowerBuffQuality a, ShipTowerBuffQuality b) => b.Quality - a.Quality);
	}

	// Token: 0x0601532C RID: 86828 RVA: 0x005DE52C File Offset: 0x005DC72C
	[NullableContext(0)]
	public UniTask<bool> CheckInitProto(bool needInitAreaData = false)
	{
		ShipTowerModel.<CheckInitProto>d__64 <CheckInitProto>d__;
		<CheckInitProto>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<CheckInitProto>d__.<>4__this = this;
		<CheckInitProto>d__.needInitAreaData = needInitAreaData;
		<CheckInitProto>d__.<>1__state = -1;
		<CheckInitProto>d__.<>t__builder.Start<ShipTowerModel.<CheckInitProto>d__64>(ref <CheckInitProto>d__);
		return <CheckInitProto>d__.<>t__builder.Task;
	}

	// Token: 0x0601532D RID: 86829 RVA: 0x005DE578 File Offset: 0x005DC778
	private bool IsNeedRequestInitData()
	{
		return this.IsOpen() && (this.TowerStageDataList.Count == 0 || !this.TowerStageDataList[0].IsHaveProtoData || this.TimeIsOver() || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ShipTowerReviewView));
	}

	// Token: 0x0601532E RID: 86830 RVA: 0x005DE5CF File Offset: 0x005DC7CF
	private void InitAreaList()
	{
		this.AreaList.Clear();
		this.AreaList.Add(this.CreateAreaDataById(0, false));
	}

	// Token: 0x0601532F RID: 86831 RVA: 0x005DE5F0 File Offset: 0x005DC7F0
	public void CreateDefaultStageDataList()
	{
		if (this.TowerStageDataList.Count > 0)
		{
			return;
		}
		foreach (int season in new int[]
		{
			0,
			1
		})
		{
			IReadOnlyList<SlashAndTowerCfg> stageCfgBySeason = ConfigBase<ShipTowerConfig>.Instance.GetStageCfgBySeason(season);
			if (stageCfgBySeason != null)
			{
				foreach (SlashAndTowerCfg cfg in stageCfgBySeason)
				{
					this.CreateStageDataByCfg(cfg);
				}
			}
		}
	}

	// Token: 0x06015330 RID: 86832 RVA: 0x005DE67C File Offset: 0x005DC87C
	[NullableContext(2)]
	private ShipTowerStageData CreateStageDataById(int id)
	{
		SlashAndTowerCfg? stageCfgById = ConfigBase<ShipTowerConfig>.Instance.GetStageCfgById(id);
		if (stageCfgById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ShipTower;
			ELogAuthor author = ELogAuthor.CX;
			string message = "CreateStageDataById";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return this.CreateStageDataByCfg(stageCfgById.Value);
	}

	// Token: 0x06015331 RID: 86833 RVA: 0x005DE6DC File Offset: 0x005DC8DC
	private ShipTowerStageData CreateStageDataByCfg(SlashAndTowerCfg cfg)
	{
		if (this.StageDataMap.ContainsKey(cfg.Id))
		{
			ShipTowerStageData shipTowerStageData = this.StageDataMap[cfg.Id];
			if (!this.StageDataList.Contains(shipTowerStageData))
			{
				this.StageDataList.Add(shipTowerStageData);
			}
			return shipTowerStageData;
		}
		ShipTowerStageData shipTowerStageData2 = new ShipTowerStageData();
		shipTowerStageData2.Init(cfg);
		shipTowerStageData2.SetOrderIndex(this.StageDataList.Count + 1);
		this.StageDataList.Add(shipTowerStageData2);
		this.StageDataMap[cfg.Id] = shipTowerStageData2;
		return shipTowerStageData2;
	}

	// Token: 0x06015332 RID: 86834 RVA: 0x005DE76C File Offset: 0x005DC96C
	[NullableContext(2)]
	public ShipTowerStageData GetStageDataById(int id)
	{
		ShipTowerStageData result;
		if (!this.StageDataMap.TryGetValue(id, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06015333 RID: 86835 RVA: 0x005DE78C File Offset: 0x005DC98C
	[NullableContext(2)]
	public ShipTowerStageData GetEndlessStageData()
	{
		foreach (ShipTowerStageData shipTowerStageData in this.StageDataList)
		{
			if (shipTowerStageData.IsEndLess)
			{
				return shipTowerStageData;
			}
		}
		if (this.StageDataList.Count <= 0)
		{
			return null;
		}
		return this.StageDataList[0];
	}

	// Token: 0x06015334 RID: 86836 RVA: 0x005DE804 File Offset: 0x005DCA04
	public List<ShipTowerBuffQuality> GetBuffQualityList(bool isSortData = false)
	{
		if (isSortData)
		{
			this.BuffQualityListSortData();
		}
		return this.BuffQualityList;
	}

	// Token: 0x06015335 RID: 86837 RVA: 0x005DE818 File Offset: 0x005DCA18
	private void BuffQualityListSortData()
	{
		foreach (ShipTowerBuffQuality shipTowerBuffQuality in this.BuffQualityList)
		{
			shipTowerBuffQuality.BuffList.Sort((ShipTowerBuffData a, ShipTowerBuffData b) => a.Id - b.Id);
		}
	}

	// Token: 0x06015336 RID: 86838 RVA: 0x005DE88C File Offset: 0x005DCA8C
	[NullableContext(2)]
	public ShipTowerBuffData GetBuffDataByBuffId(int buffId)
	{
		ShipTowerBuffData result;
		if (!this.BuffDataMap.TryGetValue(buffId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06015337 RID: 86839 RVA: 0x005DE8AC File Offset: 0x005DCAAC
	public void SelectDefaultBuff(int? stageId = null)
	{
		foreach (ShipTowerBuffQuality shipTowerBuffQuality in this.GetBuffQualityList(true))
		{
			foreach (ShipTowerBuffData shipTowerBuffData in shipTowerBuffQuality.BuffList)
			{
				if (shipTowerBuffData.IsCanUse(stageId))
				{
					shipTowerBuffData.SetSelected(true);
					return;
				}
			}
		}
		List<ShipTowerBuffQuality> buffQualityList = this.GetBuffQualityList(false);
		if (buffQualityList.Count > 0 && buffQualityList[0].BuffList.Count > 0)
		{
			buffQualityList[0].BuffList[0].SetSelected(true);
		}
	}

	// Token: 0x06015338 RID: 86840 RVA: 0x005DE984 File Offset: 0x005DCB84
	public int GetRecommendLevelByInstId(int instId)
	{
		return ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
	}

	// Token: 0x06015339 RID: 86841 RVA: 0x005DE99C File Offset: 0x005DCB9C
	public List<ShipTowerTeamTab> GetTeamTabList()
	{
		if (this.TeamTabList.Count > 0)
		{
			return this.TeamTabList;
		}
		this.TeamTabList.Add(new ShipTowerTeamTab
		{
			TabType = EShipTowerTeamTabType.RoleList,
			Title = "GhostShipRoleList_Text"
		});
		this.TeamTabList.Add(new ShipTowerTeamTab
		{
			TabType = EShipTowerTeamTabType.UseTeam,
			Title = "GhostShipPreTeam_Text"
		});
		return this.TeamTabList;
	}

	// Token: 0x0601533A RID: 86842 RVA: 0x005DEA08 File Offset: 0x005DCC08
	public bool IsOtherTeamRoleData(int roleId)
	{
		return this.OtherTeamRoleMap.ContainsKey(roleId);
	}

	// Token: 0x0601533B RID: 86843 RVA: 0x005DEA18 File Offset: 0x005DCC18
	[NullableContext(2)]
	public ShipTowerRoleData GetOtherTeamRoleData(int roleId)
	{
		ShipTowerRoleData result;
		if (!this.OtherTeamRoleMap.TryGetValue(roleId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0601533C RID: 86844 RVA: 0x005DEA38 File Offset: 0x005DCC38
	public void AddOtherTeamRoleData(ShipTowerRoleData roleData)
	{
		this.OtherTeamRoleMap[roleData.RoleIdEdit] = roleData;
	}

	// Token: 0x0601533D RID: 86845 RVA: 0x005DEA4C File Offset: 0x005DCC4C
	[NullableContext(2)]
	public ShipTowerRoleData GetAllTeamRoleData(int roleId)
	{
		ShipTowerRoleData result;
		if (!this.AllTeamRoleMap.TryGetValue(roleId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0601533E RID: 86846 RVA: 0x005DEA6C File Offset: 0x005DCC6C
	public void AddAllTeamRoleData(ShipTowerRoleData roleData)
	{
		this.AllTeamRoleMap[roleData.RoleIdEdit] = roleData;
	}

	// Token: 0x0601533F RID: 86847 RVA: 0x005DEA80 File Offset: 0x005DCC80
	public void ClearAllTeamRoleData()
	{
		this.AllTeamRoleMap.Clear();
	}

	// Token: 0x06015340 RID: 86848 RVA: 0x005DEA8D File Offset: 0x005DCC8D
	public void ClearOtherTeamRoleData()
	{
		this.OtherTeamRoleMap.Clear();
	}

	// Token: 0x06015341 RID: 86849 RVA: 0x005DEA9C File Offset: 0x005DCC9C
	public ShipTowerStageData GetNextChallengeStageData([Nullable(2)] ShipTowerStageData ignoreData = null)
	{
		foreach (ShipTowerStageData shipTowerStageData in this.StageDataList)
		{
			if (!shipTowerStageData.IsPassed() && shipTowerStageData.IsUnLocked() && shipTowerStageData != ignoreData)
			{
				return shipTowerStageData;
			}
		}
		return this.StageDataList[this.StageDataList.Count - 1];
	}

	// Token: 0x06015342 RID: 86850 RVA: 0x005DEB1C File Offset: 0x005DCD1C
	[NullableContext(2)]
	public void OpenViewMain(ShipTowerViewParams param = null)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerView, param, null);
	}

	// Token: 0x06015343 RID: 86851 RVA: 0x005DEB2F File Offset: 0x005DCD2F
	public void AddNormalStackChildView(bool success, int viewId)
	{
		if (success)
		{
			UiViewBase uiViewBase = Singleton<UiModel>.Instance.NormalStack.Peek();
			if (uiViewBase == null)
			{
				return;
			}
			uiViewBase.AddChildViewById(viewId);
		}
	}

	// Token: 0x06015344 RID: 86852 RVA: 0x005DEB50 File Offset: 0x005DCD50
	public void OpenViewDesc(ShipTowerDescViewParams param, [Nullable(2)] TOpenViewCallBack finishCallback = null)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerDescView, param, delegate(bool success, int viewId)
		{
			this.AddNormalStackChildView(success, viewId);
			TOpenViewCallBack finishCallback2 = finishCallback;
			if (finishCallback2 == null)
			{
				return;
			}
			finishCallback2(success, viewId);
		});
	}

	// Token: 0x06015345 RID: 86853 RVA: 0x005DEB8D File Offset: 0x005DCD8D
	public void OpenViewBuff(ShipTowerBuffViewParams param)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerBuffView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x06015346 RID: 86854 RVA: 0x005DEBAB File Offset: 0x005DCDAB
	public void OpenViewCover(ShipTowerCoverViewParams param)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerCoverView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x06015347 RID: 86855 RVA: 0x005DEBC9 File Offset: 0x005DCDC9
	public void OpenViewReset(ShipTowerResetViewParams param)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerResetView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x06015348 RID: 86856 RVA: 0x005DEBE7 File Offset: 0x005DCDE7
	[NullableContext(2)]
	public void OpenViewReward(ShipTowerRewardViewParams param = null)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerRewardView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x06015349 RID: 86857 RVA: 0x005DEC05 File Offset: 0x005DCE05
	public void OpenViewPassBuffShow(ShipTowerPassBuffShowViewParams param)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerPassBuffShowView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x0601534A RID: 86858 RVA: 0x005DEC23 File Offset: 0x005DCE23
	public void OpenViewTeamRecommend(ShipTowerTeamRecommendViewParams param)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerTeamRecommendView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x0601534B RID: 86859 RVA: 0x005DEC41 File Offset: 0x005DCE41
	public void OpenViewMonsterDesc(ShipTowerMonsterDescViewParams param)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerMonsterDescView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x0601534C RID: 86860 RVA: 0x005DEC5F File Offset: 0x005DCE5F
	[NullableContext(2)]
	public void OpenViewRecord(ShipTowerRecordViewParams param = null)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerRecordView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x0601534D RID: 86861 RVA: 0x005DEC7D File Offset: 0x005DCE7D
	[NullableContext(2)]
	public void OpenViewReview(ShipTowerReviewViewParams param = null)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerReviewView, param, new TOpenViewCallBack(this.AddNormalStackChildView));
	}

	// Token: 0x0601534E RID: 86862 RVA: 0x005DEC9C File Offset: 0x005DCE9C
	[NullableContext(2)]
	private unsafe bool CheckErrorCode(TErrorCode response, EResponseMessageId msgId, bool isShowTip = true)
	{
		if (response == null)
		{
			return true;
		}
		if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ShipTower;
			ELogAuthor author = ELogAuthor.CX;
			string message = "CheckErrorCode";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ErrorCode", response.ErrorCode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MsgId", msgId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (isShowTip)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, (int)msgId, null, true, true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0601534F RID: 86863 RVA: 0x005DED35 File Offset: 0x005DCF35
	public void UpdateSeasonNotify(SlashAndTowerOverNotify notify)
	{
		this.OpenConfirmSeasonUpdate(null);
	}

	// Token: 0x06015350 RID: 86864 RVA: 0x005DED40 File Offset: 0x005DCF40
	public void UpdateResultNotify(SlashAndTowerResultNotify notify)
	{
		ShipTowerStageData stageDataById = this.GetStageDataById(notify.LevelsId);
		if (stageDataById == null)
		{
			this.LeaveBattle();
			return;
		}
		if (this.CheckIsNeedShowConfirmSeasonUpdate(null))
		{
			return;
		}
		stageDataById.ProtoTeamEditFromResult(notify);
		int newChallengeScore = stageDataById.NewChallengeScore;
		bool isNewRecord = stageDataById.IsNewRecord(new int?(newChallengeScore));
		string titleA = "GhostShipMonsterScore_Text";
		string titleB = "GhostShipTimeScore_Text";
		List<ShipTowerFightFinishItemData> list = new List<ShipTowerFightFinishItemData>();
		ShipTowerFightFinishItemData shipTowerFightFinishItemData = new ShipTowerFightFinishItemData();
		shipTowerFightFinishItemData.TotalTitle = stageDataById.TeamDataList[0].AreaName;
		shipTowerFightFinishItemData.TitleA = titleA;
		shipTowerFightFinishItemData.TitleB = titleB;
		shipTowerFightFinishItemData.ScoreA = notify.FirstKillMonsterScore;
		shipTowerFightFinishItemData.ScoreB = notify.FirstRoundScore;
		shipTowerFightFinishItemData.RoleList = ShipTowerModel.<UpdateResultNotify>g__MakeRoleList|100_0(stageDataById.TeamDataList[0]);
		ShipTowerBuffData buffDataEdit = stageDataById.TeamDataList[0].BuffDataEdit;
		shipTowerFightFinishItemData.BuffId = ((buffDataEdit != null) ? buffDataEdit.Id : 0);
		list.Add(shipTowerFightFinishItemData);
		ShipTowerFightFinishItemData shipTowerFightFinishItemData2 = new ShipTowerFightFinishItemData();
		shipTowerFightFinishItemData2.TotalTitle = stageDataById.TeamDataList[1].AreaName;
		shipTowerFightFinishItemData2.TitleA = titleA;
		shipTowerFightFinishItemData2.TitleB = titleB;
		shipTowerFightFinishItemData2.ScoreA = notify.SecondKillMonsterScore;
		shipTowerFightFinishItemData2.ScoreB = notify.SecondRoundScore;
		shipTowerFightFinishItemData2.RoleList = ShipTowerModel.<UpdateResultNotify>g__MakeRoleList|100_0(stageDataById.TeamDataList[1]);
		ShipTowerBuffData buffDataEdit2 = stageDataById.TeamDataList[1].BuffDataEdit;
		shipTowerFightFinishItemData2.BuffId = ((buffDataEdit2 != null) ? buffDataEdit2.Id : 0);
		list.Add(shipTowerFightFinishItemData2);
		List<ShipTowerFightFinishItemData> areaList = list;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerFightFinishView, new ShipTowerFightFinishViewParams
		{
			TotalScore = newChallengeScore,
			GradeResId = this.GetStageGradeResIdByStageId(stageDataById.Id, newChallengeScore),
			IsNewRecord = isNewRecord,
			ButtonList = this.GetFightFinishButtonList(stageDataById, newChallengeScore),
			AreaList = areaList,
			IsEndless = stageDataById.IsEndLess
		}, null);
	}

	// Token: 0x06015351 RID: 86865 RVA: 0x005DEEFC File Offset: 0x005DD0FC
	private unsafe List<IRewardExploreConfirmButton> GetFightFinishButtonList(ShipTowerStageData stageData, int newScore)
	{
		List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>
		{
			new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_252_ButtonText_0",
				DescriptionTextId = null,
				IsTimeDownCloseView = true,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					this.OpenViewMain(new ShipTowerViewParams
					{
						StageId = new int?(stageData.Id),
						IsFromInstanceDungeon = new bool?(true)
					});
				}
			},
			new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Text_ButtonTextConfirmResult_Text",
				DescriptionTextId = null,
				IsTimeDownCloseView = true,
				IsClickedCloseView = true,
				OnClickedCallback = null
			}
		};
		if (stageData.IsNeedSureScore)
		{
			list[0] = null;
			list[1].OnClickedCallback = delegate(int _)
			{
				stageData.SureResultFromInstance();
			};
		}
		else if (stageData.IsEndLess)
		{
			list[1].ButtonTextId = "Text_ButtonTextRetry_Text";
			list[1].OnClickedCallback = delegate(int _)
			{
				stageData.GotoDescFromInstance();
			};
			stageData.SaveLastData();
		}
		else if (!stageData.CheckPass(newScore))
		{
			list[1].ButtonTextId = "Text_ButtonTextRetry_Text";
			list[1].DescriptionTextId = "Text_NotFinished_Text";
			list[1].OnClickedCallback = delegate(int _)
			{
				stageData.GotoDescFromInstance();
			};
			stageData.SaveLastData();
		}
		else
		{
			ShipTowerStageData nextStageData = this.GetNextChallengeStageData(stageData);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(nextStageData.TitleKey);
			list[1].ButtonTextId = "Text_ButtonTextContinue_Text";
			list[1].DescriptionTextId = "Text_ButtonTextGoOnTower_Text";
			IRewardExploreConfirmButton rewardExploreConfirmButton = list[1];
			int num = 2;
			List<object> list2 = new List<object>(num);
			CollectionsMarshal.SetCount<object>(list2, num);
			Span<object> span = CollectionsMarshal.AsSpan<object>(list2);
			int num2 = 0;
			*span[num2] = multiTextByKey;
			num2++;
			*span[num2] = nextStageData.OrderIndex;
			rewardExploreConfirmButton.DescriptionArgs = list2;
			list[1].OnClickedCallback = delegate(int _)
			{
				stageData.GotoNextDescFromInstance(nextStageData);
			};
			stageData.SaveLastData();
		}
		return list;
	}

	// Token: 0x06015352 RID: 86866 RVA: 0x005DF13C File Offset: 0x005DD33C
	public void UpdateLevelPlayNotify(SlashAndTowerLevelPlayNotify notify)
	{
		foreach (SlashLevelPlayInfo slashLevelPlayInfo in notify.SlashLevelPlayInfos)
		{
			ShipTowerStageData stageDataById = this.GetStageDataById(slashLevelPlayInfo.Id);
			if (stageDataById != null)
			{
				stageDataById.ProtoNotifyUpdateData(slashLevelPlayInfo);
			}
			if (stageDataById != null && stageDataById.IsEndLess && !this.IsOldSeason(stageDataById.BelongToSeason) && stageDataById.IsTeamSetRoleFinish())
			{
				this.IsHaveRecord = true;
				Singleton<EventSystem>.Instance.Emit(EEventName.ShipTowerEndlessRecordUpdate);
			}
		}
		this.UpdateAreaListState();
	}

	// Token: 0x06015353 RID: 86867 RVA: 0x005DF1D8 File Offset: 0x005DD3D8
	[NullableContext(2)]
	public void SlashAndTowerInfoResponse(SlashAndTowerInfoResponse response)
	{
		object response2;
		if (response == null)
		{
			response2 = null;
		}
		else
		{
			(response2 = new TErrorCode()).ErrorCode = response.ErrorCode;
		}
		if (this.CheckErrorCode(response2, EResponseMessageId.SlashAndTowerInfoResponse, false))
		{
			return;
		}
		this.StageDataMap.Clear();
		this.StageDataList.Clear();
		if (((response != null) ? response.SlashLevelPlayInfos : null) != null)
		{
			foreach (SlashLevelPlayInfo slashLevelPlayInfo in response.SlashLevelPlayInfos)
			{
				this.CreateStageDataById(slashLevelPlayInfo.Id);
			}
		}
		this.Season = ((this.StageDataList.Count > 0) ? new int?(this.StageDataList[this.StageDataList.Count - 1].BelongToSeason) : null).GetValueOrDefault(1);
		this.InitBuffQualityList();
		this.SeasonEndTime = Singleton<MathUtils>.Instance.LongToNumber((response != null) ? response.SeasonEndTime : 0L);
		this.IsHaveRecord = (response != null && response.ExistEndlessRecord);
		this.IsNeedShowSeasonReview = (response != null && response.UpdateSeason);
		this.CheckOldSeasonBuffQualityList();
		this.AddBuffQualityListBySeason(this.CurSeason);
		if (((response != null) ? response.SlashLevelPlayInfos : null) != null)
		{
			foreach (SlashLevelPlayInfo slashLevelPlayInfo2 in response.SlashLevelPlayInfos)
			{
				ShipTowerStageData stageDataById = this.GetStageDataById(slashLevelPlayInfo2.Id);
				if (stageDataById != null)
				{
					stageDataById.ProtoNotifyInitData(slashLevelPlayInfo2);
				}
			}
		}
		this.ReceivedAwardScoreIdSet.Clear();
		if (((response != null) ? response.ReceivedAward : null) != null)
		{
			foreach (int item in response.ReceivedAward)
			{
				this.ReceivedAwardScoreIdSet.Add(item);
			}
		}
		this.SetChallengeBuffIdList((((response != null) ? response.BuffCache : null) != null) ? new List<int>(response.BuffCache) : new List<int>());
		ActivityShipTowerController instance = ControllerBase<ActivityShipTowerController>.Instance;
		ActivityShipTowerData activityShipTowerData = (instance != null) ? instance.Data : null;
		if (activityShipTowerData != null && activityShipTowerData.RedPointShowState)
		{
			ModelBase<AdventureGuideModel>.Instance.ReportPeriodicActivityRedAppear(EDungeonSubType.ShipTower);
		}
	}

	// Token: 0x06015354 RID: 86868 RVA: 0x005DF428 File Offset: 0x005DD628
	[NullableContext(2)]
	public void SlashAndTowerScoreRewardResponse(SlashAndTowerScoreRewardResponse response)
	{
		object response2;
		if (response == null)
		{
			response2 = null;
		}
		else
		{
			(response2 = new TErrorCode()).ErrorCode = response.ErrorCode;
		}
		if (this.CheckErrorCode(response2, EResponseMessageId.SlashAndTowerScoreRewardResponse, true))
		{
			return;
		}
		if (((response != null) ? response.RewardIds : null) != null)
		{
			foreach (int item in response.RewardIds)
			{
				this.ReceivedAwardScoreIdSet.Add(item);
			}
		}
		this.UpdateAreaListState();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerRewardReceive, this.ReceivingAwardId);
	}

	// Token: 0x06015355 RID: 86869 RVA: 0x005DF4CC File Offset: 0x005DD6CC
	[NullableContext(2)]
	public void EndLessHistoryResponse(EndLessHistoryResponse response)
	{
		object response2;
		if (response == null)
		{
			response2 = null;
		}
		else
		{
			(response2 = new TErrorCode()).ErrorCode = response.ErrorCode;
		}
		if (this.CheckErrorCode(response2, EResponseMessageId.EndLessHistoryResponse, true))
		{
			return;
		}
		this.RecordList.Clear();
		this.AddRecord("GhostShipCycle_Text1", (response != null) ? response.NowSeasonRecord : null);
		this.AddRecord("GhostShipCycle_Text2", (response != null) ? response.HistoryRecord : null);
	}

	// Token: 0x06015356 RID: 86870 RVA: 0x005DF538 File Offset: 0x005DD738
	private void AddRecord(string name, [Nullable(2)] EndlessBattleRecord protoInfo)
	{
		if (protoInfo == null || (protoInfo != null && protoInfo.Id == 0))
		{
			return;
		}
		string text = "GhostShipRecordTime_Text";
		double timeStampSecond = (double)Singleton<MathUtils>.Instance.LongToNumber(protoInfo.SaveTime);
		ShipTowerModel.<>c__DisplayClass106_0 CS$<>8__locals1;
		CS$<>8__locals1.data = new ShipTowerAreaItemData
		{
			Id = 0,
			Name = name,
			Desc = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text),
			TimeContent = Singleton<TimeUtil>.Instance.DateFormat4String(timeStampSecond),
			RecordList = new List<ShipTowerRecordItemData>()
		};
		ShipTowerModel.<AddRecord>g__functionAddTeam|106_0("GhostShipTeamName_Text1", protoInfo.FirstRecord, ref CS$<>8__locals1);
		ShipTowerModel.<AddRecord>g__functionAddTeam|106_0("GhostShipTeamName_Text2", protoInfo.SecondRecord, ref CS$<>8__locals1);
		this.RecordList.Add(CS$<>8__locals1.data);
	}

	// Token: 0x06015357 RID: 86871 RVA: 0x005DF5EC File Offset: 0x005DD7EC
	[NullableContext(2)]
	public void SlashAndTowerSaveRecordResponse(int id, SlashAndTowerSaveRecordResponse response)
	{
		object response2;
		if (response == null)
		{
			response2 = null;
		}
		else
		{
			(response2 = new TErrorCode()).ErrorCode = response.ErrorCode;
		}
		if (this.CheckErrorCode(response2, EResponseMessageId.SlashAndTowerSaveRecordResponse, true))
		{
			return;
		}
		ShipTowerStageData stageDataById = this.GetStageDataById(id);
		if (stageDataById != null)
		{
			stageDataById.CoverChallenge();
		}
		this.UpdateAreaListState();
		this.SetChallengeStageDataNull();
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GhostShipRecordSuccess_Text", Array.Empty<object>());
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerSureCoverChallenge, id);
	}

	// Token: 0x06015358 RID: 86872 RVA: 0x005DF664 File Offset: 0x005DD864
	[NullableContext(2)]
	public void SlashAndTowerResetResponse(int id, SlashAndTowerResetResponse response)
	{
		object response2;
		if (response == null)
		{
			response2 = null;
		}
		else
		{
			(response2 = new TErrorCode()).ErrorCode = response.ErrorCode;
		}
		if (this.CheckErrorCode(response2, EResponseMessageId.SlashAndTowerResetResponse, true))
		{
			return;
		}
		ShipTowerStageData stageDataById = this.GetStageDataById(id);
		if (stageDataById != null)
		{
			stageDataById.ResetStage();
		}
		this.UpdateAreaListState();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerSureResetStage, id);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GhostShipRecordReset_Text", Array.Empty<object>());
	}

	// Token: 0x06015359 RID: 86873 RVA: 0x005DF6D4 File Offset: 0x005DD8D4
	[NullableContext(2)]
	public void SlashAndTowerRecommendResponse(int id, SlashAndTowerRecommendResponse response)
	{
		object response2;
		if (response == null)
		{
			response2 = null;
		}
		else
		{
			(response2 = new TErrorCode()).ErrorCode = response.ErrorCode;
		}
		if (this.CheckErrorCode(response2, EResponseMessageId.SlashAndTowerRecommendResponse, true))
		{
			return;
		}
		ShipTowerStageData stageDataById = this.GetStageDataById(id);
		if (stageDataById == null)
		{
			return;
		}
		stageDataById.ProtoUpdateTeamRecommendList(response);
	}

	// Token: 0x0601535A RID: 86874 RVA: 0x005DF710 File Offset: 0x005DD910
	[NullableContext(2)]
	public void SlashAndTowerReviewResponse(LstBattleRecordResponse response)
	{
		object response2;
		if (response == null)
		{
			response2 = null;
		}
		else
		{
			(response2 = new TErrorCode()).ErrorCode = response.ErrorCode;
		}
		if (this.CheckErrorCode(response2, EResponseMessageId.LstBattleRecordResponse, true))
		{
			return;
		}
		this.ReviewList.Clear();
		if (((response != null) ? response.LstLevelInfos : null) != null)
		{
			foreach (LstLevelInfo lstLevelInfo in response.LstLevelInfos)
			{
				int levelId = lstLevelInfo.LevelId;
				int score = lstLevelInfo.Score;
				this.ReviewList.Add(new ShipTowerReviewItemData
				{
					Title = this.GetStageNameById(levelId),
					Score = score,
					Grade = this.GetStageGradeResIdByStageId(levelId, score),
					StageId = levelId,
					IsQuickPass = lstLevelInfo.EasyPassFlag
				});
			}
		}
		this.ReviewProgressList.Clear();
		this.ReviewProgressList.Add((response != null) ? response.LastCanRewardCount : 0);
		this.ReviewProgressList.Add((response != null) ? response.LastTotalRewardCount : 0);
	}

	// Token: 0x0601535B RID: 86875 RVA: 0x005DF824 File Offset: 0x005DDA24
	public bool CheckCanOpen(EUiViewName name, object ob)
	{
		if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_600064_Text", Array.Empty<object>());
			return false;
		}
		bool flag = this.IsOpen();
		if (!flag)
		{
			FunctionCondition? functionCondition = ConfigBase<FunctionConfig>.Instance.GetFunctionCondition(10081);
			int? num = (functionCondition != null) ? new int?(functionCondition.GetValueOrDefault().OpenConditionId) : null;
			if (num != null)
			{
				ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(num.Value);
				if (((conditionGroupConfig != null) ? conditionGroupConfig.GetValueOrDefault().HintText : null) != null)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(conditionGroupConfig.Value.HintText, Array.Empty<object>());
				}
			}
		}
		return flag;
	}

	// Token: 0x0601535C RID: 86876 RVA: 0x005DF8F4 File Offset: 0x005DDAF4
	public bool CheckInBattleShipTower()
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return false;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.Value.InstSubType == 27;
	}

	// Token: 0x0601535D RID: 86877 RVA: 0x005DF945 File Offset: 0x005DDB45
	public bool IsOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10081);
	}

	// Token: 0x0601535E RID: 86878 RVA: 0x005DF958 File Offset: 0x005DDB58
	public void StartChallenge(ShipTowerStageData stageData)
	{
		this.ChallengeStageData = stageData;
		List<int> list = new List<int>();
		foreach (ShipTowerTeamData shipTowerTeamData in stageData.TeamDataList)
		{
			List<int> list2 = list;
			ShipTowerBuffData buffDataEdit = shipTowerTeamData.BuffDataEdit;
			list2.Add((buffDataEdit != null) ? buffDataEdit.Id : 0);
		}
		this.SetChallengeBuffIdList(list);
		ControllerBase<ShipTowerController>.Instance.RequestChallenge(stageData, false, false);
	}

	// Token: 0x0601535F RID: 86879 RVA: 0x005DF9E0 File Offset: 0x005DDBE0
	private void SetChallengeBuffIdList(List<int> buffIdList)
	{
		this.ChallengeBuffIdList.Clear();
		this.ChallengeBuffIdList.AddRange(buffIdList);
	}

	// Token: 0x06015360 RID: 86880 RVA: 0x005DF9FC File Offset: 0x005DDBFC
	public void AgainChallenge()
	{
		if (this.CheckIsNeedShowConfirmSeasonUpdate(null))
		{
			return;
		}
		if (!this.CheckChallengeStageData())
		{
			return;
		}
		if (ModelBase<SceneTeamModel>.Instance.IsAllDid())
		{
			return;
		}
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("ShipTower");
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		ShipTowerStageData challengeStageData = this.ChallengeStageData;
		bool isFromLast = challengeStageData != null && challengeStageData.TeamDataList[1].InstId == instanceId;
		ControllerBase<ShipTowerController>.Instance.RequestChallenge(this.ChallengeStageData, isFromLast, true);
	}

	// Token: 0x06015361 RID: 86881 RVA: 0x005DFA78 File Offset: 0x005DDC78
	public void OpenViewMainFromFight()
	{
		if (!this.CheckChallengeStageData())
		{
			return;
		}
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("ShipTower");
		int id = this.ChallengeStageData.Id;
		this.OpenViewMain(new ShipTowerViewParams
		{
			StageId = new int?(id),
			IsFromInstanceDungeon = new bool?(true)
		});
	}

	// Token: 0x06015362 RID: 86882 RVA: 0x005DFACC File Offset: 0x005DDCCC
	private bool CheckChallengeStageData()
	{
		if (this.ChallengeStageData != null)
		{
			return true;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		foreach (ShipTowerStageData shipTowerStageData in this.StageDataList)
		{
			if (shipTowerStageData.InstIds.Contains(instanceId))
			{
				this.ChallengeStageData = shipTowerStageData;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015363 RID: 86883 RVA: 0x005DFB4C File Offset: 0x005DDD4C
	public void ClearChallengeStageData()
	{
		if (this.ChallengeStageData == null)
		{
			return;
		}
		this.ChallengeStageData.UpdateToEdit();
		this.SetChallengeStageDataNull();
	}

	// Token: 0x06015364 RID: 86884 RVA: 0x005DFB68 File Offset: 0x005DDD68
	public void SetChallengeStageDataNull()
	{
		this.ChallengeStageData = null;
	}

	// Token: 0x06015365 RID: 86885 RVA: 0x005DFB74 File Offset: 0x005DDD74
	[NullableContext(0)]
	public UniTask<bool> CheckIsNeedShowSeasonReview()
	{
		ShipTowerModel.<CheckIsNeedShowSeasonReview>d__121 <CheckIsNeedShowSeasonReview>d__;
		<CheckIsNeedShowSeasonReview>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<CheckIsNeedShowSeasonReview>d__.<>4__this = this;
		<CheckIsNeedShowSeasonReview>d__.<>1__state = -1;
		<CheckIsNeedShowSeasonReview>d__.<>t__builder.Start<ShipTowerModel.<CheckIsNeedShowSeasonReview>d__121>(ref <CheckIsNeedShowSeasonReview>d__);
		return <CheckIsNeedShowSeasonReview>d__.<>t__builder.Task;
	}

	// Token: 0x06015366 RID: 86886 RVA: 0x005DFBB8 File Offset: 0x005DDDB8
	private void CheckOldSeasonData()
	{
		List<ShipTowerStageData> list = new List<ShipTowerStageData>();
		foreach (ShipTowerStageData shipTowerStageData in this.StageDataList)
		{
			if (shipTowerStageData.IsOldSeasonData())
			{
				list.Add(shipTowerStageData);
			}
		}
		if (list.Count > 0)
		{
			foreach (ShipTowerStageData shipTowerStageData2 in list)
			{
				shipTowerStageData2.ResetStage();
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerStageUpdate, shipTowerStageData2.Id);
			}
			this.UpdateAreaListState();
		}
	}

	// Token: 0x06015367 RID: 86887 RVA: 0x005DFC7C File Offset: 0x005DDE7C
	public string GetStageGradeResId(string charStr)
	{
		ShipTowerScoreGrade shipTowerScoreGrade;
		ShipTowerDefine.shipTowerScoreGradeMap.TryGetValue(charStr, out shipTowerScoreGrade);
		if (shipTowerScoreGrade == null)
		{
			return ShipTowerDefine.shipTowerScoreGradeMap["D"].ResId;
		}
		return shipTowerScoreGrade.ResId;
	}

	// Token: 0x06015368 RID: 86888 RVA: 0x005DFCB8 File Offset: 0x005DDEB8
	public string GetShareStageGradeResId(string charStr)
	{
		ShipTowerScoreGrade shipTowerScoreGrade;
		ShipTowerDefine.shipTowerScoreGradeMap.TryGetValue(charStr, out shipTowerScoreGrade);
		if (shipTowerScoreGrade == null)
		{
			return ShipTowerDefine.shipTowerScoreGradeMap["D"].BigResId;
		}
		return shipTowerScoreGrade.BigResId;
	}

	// Token: 0x06015369 RID: 86889 RVA: 0x005DFCF4 File Offset: 0x005DDEF4
	[NullableContext(2)]
	public string GetStageGradeResIdByStageId(int stageId, int score)
	{
		ShipTowerStageData stageDataById = this.GetStageDataById(stageId);
		if (stageDataById != null)
		{
			return stageDataById.GetStageGradeResIdByScore(score);
		}
		SlashAndTowerCfg? stageCfgById = ConfigBase<ShipTowerConfig>.Instance.GetStageCfgById(stageId);
		if (stageCfgById != null)
		{
			return this.GetStageGradeResIdByScore(score, stageCfgById.Value.TargetScore(), stageCfgById.Value.ScoreStage());
		}
		return null;
	}

	// Token: 0x0601536A RID: 86890 RVA: 0x005DFD50 File Offset: 0x005DDF50
	[return: Nullable(2)]
	public string GetStageGradeResIdByScore(int score, int[] targetList, string[] stageList)
	{
		for (int i = targetList.Length - 1; i >= 0; i--)
		{
			if (score >= targetList[i])
			{
				return this.GetStageGradeResId(stageList[i]);
			}
		}
		return null;
	}

	// Token: 0x0601536B RID: 86891 RVA: 0x005DFD80 File Offset: 0x005DDF80
	[return: Nullable(2)]
	public string GetShareStageGradeResIdByScore(int score, int[] targetList, string[] stageList)
	{
		for (int i = targetList.Length - 1; i >= 0; i--)
		{
			if (score >= targetList[i])
			{
				return this.GetShareStageGradeResId(stageList[i]);
			}
		}
		return null;
	}

	// Token: 0x0601536C RID: 86892 RVA: 0x005DFDB0 File Offset: 0x005DDFB0
	public string GetStageNameById(int stageId)
	{
		ShipTowerStageData stageDataById = this.GetStageDataById(stageId);
		string text = null;
		if (stageDataById != null)
		{
			text = stageDataById.TitleKey;
		}
		SlashAndTowerCfg? stageCfgById = ConfigBase<ShipTowerConfig>.Instance.GetStageCfgById(stageId);
		if (stageCfgById != null)
		{
			text = stageCfgById.Value.Title;
		}
		if (text != null)
		{
			return ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
		}
		return "";
	}

	// Token: 0x0601536D RID: 86893 RVA: 0x005DFE0C File Offset: 0x005DE00C
	public int GetStageOrderIndexById(int stageId)
	{
		ShipTowerStageData stageDataById = this.GetStageDataById(stageId);
		int result = 0;
		if (stageDataById != null)
		{
			result = stageDataById.OrderIndex;
		}
		SlashAndTowerCfg? stageCfgById = ConfigBase<ShipTowerConfig>.Instance.GetStageCfgById(stageId);
		if (stageCfgById != null)
		{
			result = stageCfgById.Value.OrderIndex;
		}
		return result;
	}

	// Token: 0x0601536E RID: 86894 RVA: 0x005DFE54 File Offset: 0x005DE054
	public bool GetStageIsEndlessById(int stageId)
	{
		ShipTowerStageData stageDataById = this.GetStageDataById(stageId);
		if (stageDataById != null)
		{
			return stageDataById.IsEndLess;
		}
		SlashAndTowerCfg? stageCfgById = ConfigBase<ShipTowerConfig>.Instance.GetStageCfgById(stageId);
		return stageCfgById != null && stageCfgById.Value.EndLess;
	}

	// Token: 0x0601536F RID: 86895 RVA: 0x005DFE9C File Offset: 0x005DE09C
	public IBattleUiHoverTipsD GetInTheBattleBuffInfo()
	{
		object obj = this.CheckChallengeStageData() ? this.ChallengeStageData : this.StageDataList[0];
		int instId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		object obj2 = obj;
		int index = (obj2 != null) ? obj2.TeamDataList.FindIndex((ShipTowerTeamData data) => data.InstId == instId) : 0;
		int id = this.ChallengeBuffIdList[index];
		SlashBuffToItem? buffCfgById = ConfigBase<ShipTowerConfig>.Instance.GetBuffCfgById(id);
		int num;
		if (buffCfgById != null)
		{
			num = buffCfgById.Value.ItemId;
		}
		else
		{
			num = 0;
			using (Dictionary<int, ShipTowerBuffData>.Enumerator enumerator = this.BuffDataMap.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<int, ShipTowerBuffData> keyValuePair = enumerator.Current;
					num = keyValuePair.Value.ItemId;
				}
			}
		}
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(num);
		string name = itemConfig.Value.Name;
		string obtainedShowDescription = itemConfig.Value.ObtainedShowDescription;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GhostShipItemQuality_Text");
		defaultInterpolatedStringHandler.AppendFormatted<int>(itemConfig.Value.QualityId);
		string subTitleKey = defaultInterpolatedStringHandler.ToStringAndClear();
		return new BattleUiHoverTipsD
		{
			TitleKey = name,
			SubTitleKey = subTitleKey,
			ItemInfo = new PropSmallItemGrid
			{
				ItemConfigId = new int?(num),
				Data = null
			},
			DescInfoList = new List<IBattleUiHoverTipsDescInfo>
			{
				new BattleUiHoverTipsDescInfo
				{
					DescKey = obtainedShowDescription,
					DescUseChangeColor = new bool?(true)
				}
			},
			DescTitleKey = "GhostShipSkillTitle_Text"
		};
	}

	// Token: 0x06015370 RID: 86896 RVA: 0x005E0054 File Offset: 0x005DE254
	public void AddShowBuffId(int buffId, bool isShowTips = true)
	{
		this.GetBuffIdList.Add(buffId);
		if (isShowTips)
		{
			this.ShowBuffIdList.Add(buffId);
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ShipTowerShowBuffView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerShowBuffView, null, null);
			}
		}
	}

	// Token: 0x06015371 RID: 86897 RVA: 0x005E0094 File Offset: 0x005DE294
	[NullableContext(0)]
	public UniTask<bool> CheckShowGetBuff()
	{
		ShipTowerModel.<CheckShowGetBuff>d__133 <CheckShowGetBuff>d__;
		<CheckShowGetBuff>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<CheckShowGetBuff>d__.<>4__this = this;
		<CheckShowGetBuff>d__.<>1__state = -1;
		<CheckShowGetBuff>d__.<>t__builder.Start<ShipTowerModel.<CheckShowGetBuff>d__133>(ref <CheckShowGetBuff>d__);
		return <CheckShowGetBuff>d__.<>t__builder.Task;
	}

	// Token: 0x06015372 RID: 86898 RVA: 0x005E00D7 File Offset: 0x005DE2D7
	public void ClearGetBuffIdList()
	{
		this.GetBuffIdList.Clear();
	}

	// Token: 0x06015373 RID: 86899 RVA: 0x005E00E4 File Offset: 0x005DE2E4
	private List<TItem> GetShowGetBuffDataList()
	{
		List<TItem> list = new List<TItem>();
		Dictionary<int, TItem> dictionary = new Dictionary<int, TItem>();
		foreach (int buffId in this.GetBuffIdList)
		{
			ShipTowerBuffData buffDataByBuffId = this.GetBuffDataByBuffId(buffId);
			if (buffDataByBuffId != null)
			{
				TItem titem;
				if (dictionary.TryGetValue(buffDataByBuffId.ItemId, out titem))
				{
					titem.Count++;
				}
				else
				{
					TItem titem2 = new TItem(new InventoryDefine.GetItemData(buffDataByBuffId.ItemId, 0), 1);
					list.Add(titem2);
					dictionary[buffDataByBuffId.ItemId] = titem2;
				}
			}
		}
		return list;
	}

	// Token: 0x06015374 RID: 86900 RVA: 0x005E0198 File Offset: 0x005DE398
	public UniTask OpenWelcomeView()
	{
		ShipTowerModel.<OpenWelcomeView>d__136 <OpenWelcomeView>d__;
		<OpenWelcomeView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenWelcomeView>d__.<>4__this = this;
		<OpenWelcomeView>d__.<>1__state = -1;
		<OpenWelcomeView>d__.<>t__builder.Start<ShipTowerModel.<OpenWelcomeView>d__136>(ref <OpenWelcomeView>d__);
		return <OpenWelcomeView>d__.<>t__builder.Task;
	}

	// Token: 0x06015375 RID: 86901 RVA: 0x005E01DB File Offset: 0x005DE3DB
	public void CloseWelcomeView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ShipTowerWelcomeView, null);
	}

	// Token: 0x06015376 RID: 86902 RVA: 0x005E01ED File Offset: 0x005DE3ED
	[NullableContext(2)]
	public bool CheckIsNeedShowConfirmSeasonUpdate(Action confirmCallback = null)
	{
		if (this.IsShowConfirmSeasonUpdate())
		{
			this.OpenConfirmSeasonUpdate(confirmCallback);
			return true;
		}
		return false;
	}

	// Token: 0x06015377 RID: 86903 RVA: 0x005E0201 File Offset: 0x005DE401
	private bool IsShowConfirmSeasonUpdate()
	{
		return this.IsNeedShowSeasonReview || this.TimeIsOver();
	}

	// Token: 0x06015378 RID: 86904 RVA: 0x005E0218 File Offset: 0x005DE418
	[NullableContext(2)]
	private void OpenConfirmSeasonUpdate(Action confirmCallback = null)
	{
		if (this.IsOpenedSeasonUpdate)
		{
			return;
		}
		this.IsOpenedSeasonUpdate = true;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShipTowerSeasonUpdate);
		Action value = delegate()
		{
			Action action = confirmCallback ?? new Action(this.ConfirmSeasonUpdateCallback);
			if (action != null)
			{
				action();
			}
			this.IsOpenedSeasonUpdate = false;
		};
		confirmBoxDataNew.FunctionMap[1] = value;
		confirmBoxDataNew.FunctionMap[2] = value;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06015379 RID: 86905 RVA: 0x005E0288 File Offset: 0x005DE488
	public void OpenConfirmBackWorld()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShipTowerFromViewLeaveInst);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			this.LeaveBattle();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601537A RID: 86906 RVA: 0x005E02C4 File Offset: 0x005DE4C4
	private void ConfirmSeasonUpdateCallback()
	{
		if (this.LeaveBattle())
		{
			return;
		}
		this.CloseMainView();
	}

	// Token: 0x0601537B RID: 86907 RVA: 0x005E02D5 File Offset: 0x005DE4D5
	public bool LeaveBattle()
	{
		if (!this.CheckInBattleShipTower())
		{
			return false;
		}
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("ShipTower");
		ModelBase<TowerModel>.Instance.CurrentTowerId = -1;
		ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
		return true;
	}

	// Token: 0x0601537C RID: 86908 RVA: 0x005E030C File Offset: 0x005DE50C
	public bool IsExistFirstGetBuff()
	{
		foreach (ShipTowerBuffQuality shipTowerBuffQuality in this.BuffQualityList)
		{
			using (List<ShipTowerBuffData>.Enumerator enumerator2 = shipTowerBuffQuality.BuffList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.IsFirstGet())
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0601537D RID: 86909 RVA: 0x005E03A0 File Offset: 0x005DE5A0
	public void CloseMainView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ShipTowerView, null);
	}

	// Token: 0x0601537E RID: 86910 RVA: 0x005E03B2 File Offset: 0x005DE5B2
	public double GetRemainTime()
	{
		if (this.CurSeasonEndTime <= 0L)
		{
			return 0.0;
		}
		return (double)this.CurSeasonEndTime - Singleton<TimeUtil>.Instance.GetServerTime();
	}

	// Token: 0x0601537F RID: 86911 RVA: 0x005E03DA File Offset: 0x005DE5DA
	public bool TimeIsOver()
	{
		return this.GetRemainTime() <= 0.0;
	}

	// Token: 0x06015380 RID: 86912 RVA: 0x005E03F0 File Offset: 0x005DE5F0
	public string GetRewardCountDownDesc()
	{
		double remainTime = this.GetRemainTime();
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime);
		if (remainTimeDataFormat.CountDownText == null)
		{
			return "";
		}
		string key = "GhostShipTimeLimit_Text";
		return ConfigBase<TextConfig>.Instance.GetMultiText(key, new string[]
		{
			remainTimeDataFormat.CountDownText
		});
	}

	// Token: 0x06015381 RID: 86913 RVA: 0x005E0440 File Offset: 0x005DE640
	public UniTask ReceiveAward(int id, int[] ids)
	{
		ShipTowerModel.<ReceiveAward>d__149 <ReceiveAward>d__;
		<ReceiveAward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ReceiveAward>d__.<>4__this = this;
		<ReceiveAward>d__.id = id;
		<ReceiveAward>d__.ids = ids;
		<ReceiveAward>d__.<>1__state = -1;
		<ReceiveAward>d__.<>t__builder.Start<ShipTowerModel.<ReceiveAward>d__149>(ref <ReceiveAward>d__);
		return <ReceiveAward>d__.<>t__builder.Task;
	}

	// Token: 0x06015382 RID: 86914 RVA: 0x005E0493 File Offset: 0x005DE693
	public bool IsCanReceiveAward()
	{
		return this.RewardCanReceiveNum > 0;
	}

	// Token: 0x06015383 RID: 86915 RVA: 0x005E049E File Offset: 0x005DE69E
	public bool IsEndlessRecordOpen()
	{
		return this.CurIsHaveRecord;
	}

	// Token: 0x06015384 RID: 86916 RVA: 0x005E04A6 File Offset: 0x005DE6A6
	public bool IsCanUseRole(int roleId)
	{
		return ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId) != null;
	}

	// Token: 0x06015385 RID: 86917 RVA: 0x005E04B8 File Offset: 0x005DE6B8
	public UniTask RequestRecord()
	{
		ShipTowerModel.<RequestRecord>d__153 <RequestRecord>d__;
		<RequestRecord>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRecord>d__.<>1__state = -1;
		<RequestRecord>d__.<>t__builder.Start<ShipTowerModel.<RequestRecord>d__153>(ref <RequestRecord>d__);
		return <RequestRecord>d__.<>t__builder.Task;
	}

	// Token: 0x06015386 RID: 86918 RVA: 0x005E04F4 File Offset: 0x005DE6F4
	public CommonDefine.ICountDown GetSeasonCountDownData()
	{
		double num = this.GetRemainTime();
		if (num <= 1.0)
		{
			num = 1.0;
		}
		CommonDefine.ETimeType value = (num >= 86400.0) ? CommonDefine.ETimeType.Day : ((num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
		CommonDefine.ETimeType value2 = (num >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2));
	}

	// Token: 0x06015387 RID: 86919 RVA: 0x005E0578 File Offset: 0x005DE778
	public string GetStageAreaName(int? stageId = null)
	{
		ShipTowerStageData shipTowerStageData;
		if (stageId == null)
		{
			shipTowerStageData = this.GetCurrentStage();
		}
		else
		{
			shipTowerStageData = this.GetStageDataById(stageId.Value);
			if (shipTowerStageData == null)
			{
				shipTowerStageData = ((this.StageDataList.Count > 0) ? this.StageDataList[0] : null);
			}
		}
		int num = -1;
		for (int i = 0; i < this.StageDataList.Count; i++)
		{
			int id = this.StageDataList[i].Id;
			int? num2 = (shipTowerStageData != null) ? new int?(shipTowerStageData.Id) : null;
			if (id == num2.GetValueOrDefault() & num2 != null)
			{
				num = i;
				break;
			}
		}
		IReadOnlyList<SlashTowerShowStage> allShowStageCfg = ConfigBase<ShipTowerConfig>.Instance.GetAllShowStageCfg();
		if (allShowStageCfg != null)
		{
			foreach (SlashTowerShowStage slashTowerShowStage in allShowStageCfg)
			{
				if (slashTowerShowStage.OutIndex >= num)
				{
					return ConfigBase<TextConfig>.Instance.GetMultiTextByKey(slashTowerShowStage.Name, slashTowerShowStage.Name);
				}
			}
		}
		return "";
	}

	// Token: 0x06015388 RID: 86920 RVA: 0x005E0698 File Offset: 0x005DE898
	public string GetCurrentStageSeasonName()
	{
		ShipTowerStageData currentStage = this.GetCurrentStage();
		if ((currentStage != null && currentStage.BelongToSeason == 0) || !this.IsOpen())
		{
			string text = "GhostShipProgressName_Text1";
			return ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
		}
		string text2 = "GhostShipProgressName_Text2";
		return ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text2, text2);
	}

	// Token: 0x06015389 RID: 86921 RVA: 0x005E06EC File Offset: 0x005DE8EC
	public string GetCurrentStageSeasonName2()
	{
		ShipTowerStageData currentStage = this.GetCurrentStage();
		if (currentStage != null && currentStage.BelongToSeason == 0)
		{
			string text = "GhostShipLevelStage_Text1";
			return ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
		}
		string text2 = "GhostShipLevelStage_Text4";
		return ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text2, text2);
	}

	// Token: 0x0601538A RID: 86922 RVA: 0x005E0738 File Offset: 0x005DE938
	[NullableContext(2)]
	public ShipTowerStageData GetCurrentStage()
	{
		for (int i = this.StageDataList.Count - 1; i >= 0; i--)
		{
			ShipTowerStageData shipTowerStageData = this.StageDataList[i];
			if (shipTowerStageData.IsUnLocked())
			{
				return shipTowerStageData;
			}
		}
		if (this.StageDataList.Count <= 0)
		{
			return null;
		}
		return this.StageDataList[0];
	}

	// Token: 0x0601538B RID: 86923 RVA: 0x005E0790 File Offset: 0x005DE990
	public bool IsPassZeroSeason()
	{
		if (!this.IsOpen())
		{
			return false;
		}
		ShipTowerStageData currentStage = this.GetCurrentStage();
		return currentStage == null || currentStage.BelongToSeason != 0;
	}

	// Token: 0x0601538C RID: 86924 RVA: 0x005E07B0 File Offset: 0x005DE9B0
	public List<EditFormationData> GetPlayerTeamList()
	{
		List<EditFormationData> list = new List<EditFormationData>();
		for (int i = 1; i <= 10; i++)
		{
			EditFormationData formationData = ModelBase<EditFormationModel>.Instance.GetFormationData(i);
			if (formationData != null)
			{
				list.Add(formationData);
			}
			else
			{
				list.Add(new EditFormationData(i));
			}
		}
		return list;
	}

	// Token: 0x0601538D RID: 86925 RVA: 0x005E07F5 File Offset: 0x005DE9F5
	public void UpdateToEdit()
	{
		this.StageDataList.ForEach(delegate(ShipTowerStageData stageData)
		{
			stageData.UpdateToEdit();
		});
	}

	// Token: 0x0601538E RID: 86926 RVA: 0x005E0824 File Offset: 0x005DEA24
	public List<ShipTowerAreaItemData> GetAreaList()
	{
		if (this.AreaList.Count >= 2)
		{
			return this.AreaList;
		}
		if (this.AreaList.Count == 0)
		{
			this.InitAreaList();
		}
		int areaId = Math.Max(this.CurSeason, 1);
		this.AreaList.Add(this.CreateAreaDataById(areaId, false));
		this.AreaList.Add(this.CreateAreaDataById(areaId, true));
		this.UpdateAreaListState();
		return this.AreaList;
	}

	// Token: 0x0601538F RID: 86927 RVA: 0x005E0898 File Offset: 0x005DEA98
	public ShipTowerAreaItemData CreateAreaDataById(int areaId, bool isEndless = false)
	{
		List<ShipTowerRewardItemData> rewardListByAreaId = this.GetRewardListByAreaId(areaId, isEndless);
		string name = "GhostShipLevelStage_Text1";
		if (areaId != 0)
		{
			name = (isEndless ? "GhostShipLevelStage_Text3" : "GhostShipLevelStage_Text2");
		}
		return new ShipTowerAreaItemData
		{
			Id = areaId,
			Index = new int?(this.AreaList.Count),
			Name = name,
			Desc = "",
			RewardList = rewardListByAreaId,
			IsEndless = new bool?(isEndless),
			MaxScore = new int?(((rewardListByAreaId.Count > 0) ? new int?(rewardListByAreaId[rewardListByAreaId.Count - 1].TotalScore) : null).GetValueOrDefault())
		};
	}

	// Token: 0x06015390 RID: 86928 RVA: 0x005E0950 File Offset: 0x005DEB50
	public List<ShipTowerRewardItemData> GetRewardListByAreaId(int areaId, bool isEndless = false)
	{
		List<ShipTowerRewardItemData> list = new List<ShipTowerRewardItemData>();
		IReadOnlyList<SlashAndTowerReward> challengeRewardCfgBySeason = ConfigBase<ShipTowerConfig>.Instance.GetChallengeRewardCfgBySeason(areaId);
		if (challengeRewardCfgBySeason != null)
		{
			foreach (SlashAndTowerReward slashAndTowerReward in challengeRewardCfgBySeason)
			{
				if (isEndless == slashAndTowerReward.EndLessReward)
				{
					List<TItem> list2 = new List<TItem>();
					DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(slashAndTowerReward.RewardId);
					if (((dropPackage != null) ? dropPackage.GetValueOrDefault().DropPreview() : null) != null)
					{
						foreach (KeyValuePair<int, int> keyValuePair in dropPackage.Value.DropPreview())
						{
							InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0);
							list2.Add(new TItem
							{
								ItemData = itemData,
								Count = keyValuePair.Value
							});
						}
					}
					list.Add(new ShipTowerRewardItemData
					{
						Id = slashAndTowerReward.Id,
						TitleKey = slashAndTowerReward.Desc,
						TotalScore = slashAndTowerReward.SumScore,
						RewardList = list2,
						IsReceive = false,
						IsProgress = false,
						IsCompleted = false
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06015391 RID: 86929 RVA: 0x005E0ADC File Offset: 0x005DECDC
	public void ClearAreaList()
	{
		for (int i = this.AreaList.Count - 1; i >= 0; i--)
		{
			if (this.AreaList[i].Id != 0)
			{
				this.AreaList.RemoveAt(i);
			}
		}
	}

	// Token: 0x06015392 RID: 86930 RVA: 0x005E0B20 File Offset: 0x005DED20
	private void UpdateAreaListState()
	{
		this.RewardCanReceiveNum = 0;
		this.RewardTotalNum = 0;
		foreach (ShipTowerAreaItemData shipTowerAreaItemData in this.AreaList)
		{
			int id = shipTowerAreaItemData.Id;
			bool? isEndless = shipTowerAreaItemData.IsEndless;
			int num = 0;
			foreach (ShipTowerStageData shipTowerStageData in this.TowerStageDataList)
			{
				if (shipTowerStageData.BelongToSeason == id)
				{
					bool isEndLess = shipTowerStageData.IsEndLess;
					bool? flag = isEndless;
					if (isEndLess == flag.GetValueOrDefault() & flag != null)
					{
						num += shipTowerStageData.CurrentScore;
					}
				}
			}
			ShipTowerAreaItemData shipTowerAreaItemData2 = shipTowerAreaItemData;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#fee488ff>");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral("</color>/");
			defaultInterpolatedStringHandler.AppendFormatted<int?>(shipTowerAreaItemData.MaxScore);
			shipTowerAreaItemData2.Desc = defaultInterpolatedStringHandler.ToStringAndClear();
			bool value = true;
			bool value2 = false;
			foreach (ShipTowerRewardItemData shipTowerRewardItemData in shipTowerAreaItemData.RewardList)
			{
				bool flag2 = this.ReceivedAwardScoreIdSet.Contains(shipTowerRewardItemData.Id);
				shipTowerRewardItemData.IsReceive = (!flag2 && num >= shipTowerRewardItemData.TotalScore);
				shipTowerRewardItemData.IsProgress = (!flag2 && num < shipTowerRewardItemData.TotalScore);
				shipTowerRewardItemData.IsCompleted = flag2;
				if (!shipTowerRewardItemData.IsCompleted)
				{
					value = false;
				}
				if (shipTowerRewardItemData.IsReceive)
				{
					value2 = true;
					this.RewardCanReceiveNum++;
				}
				this.RewardTotalNum++;
			}
			shipTowerAreaItemData.IsFinish = new bool?(value);
			shipTowerAreaItemData.IsRedPoint = new bool?(value2);
			shipTowerAreaItemData.RewardList.Sort(delegate(ShipTowerRewardItemData a, ShipTowerRewardItemData b)
			{
				if (a.IsReceive != b.IsReceive)
				{
					if (!a.IsReceive)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (a.IsProgress == b.IsProgress)
					{
						return a.Id - b.Id;
					}
					if (!a.IsProgress)
					{
						return 1;
					}
					return -1;
				}
			});
		}
		this.AreaList.Sort(delegate(ShipTowerAreaItemData a, ShipTowerAreaItemData b)
		{
			bool? isFinish = a.IsFinish;
			bool? isFinish2 = b.IsFinish;
			if (isFinish.GetValueOrDefault() == isFinish2.GetValueOrDefault() & isFinish != null == (isFinish2 != null))
			{
				return a.Index.Value - b.Index.Value;
			}
			if (!a.IsFinish.GetValueOrDefault())
			{
				return -1;
			}
			return 1;
		});
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateShipTowerReward);
		ActivityShipTowerController.RefreshActivityRedDot();
	}

	// Token: 0x06015393 RID: 86931 RVA: 0x005E0DBC File Offset: 0x005DEFBC
	public string GetRewardProgressText(bool useColor = true)
	{
		ValueTuple<int, int> rewardProgressNumData = this.GetRewardProgressNumData();
		int item = rewardProgressNumData.Item1;
		int item2 = rewardProgressNumData.Item2;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (useColor)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#fadf85>");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("</color>/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015394 RID: 86932 RVA: 0x005E0E48 File Offset: 0x005DF048
	[NullableContext(0)]
	public ValueTuple<int, int> GetRewardProgressNumData()
	{
		int num = 0;
		int num2 = 0;
		bool flag = this.IsPassZeroSeason();
		List<ShipTowerAreaItemData> areaList = this.GetAreaList();
		List<ShipTowerAreaItemData> list = new List<ShipTowerAreaItemData>();
		foreach (ShipTowerAreaItemData shipTowerAreaItemData in areaList)
		{
			bool flag2 = shipTowerAreaItemData.Id == 0;
			if (flag ? (!flag2) : flag2)
			{
				list.Add(shipTowerAreaItemData);
			}
		}
		foreach (ShipTowerAreaItemData shipTowerAreaItemData2 in list)
		{
			int num3 = 0;
			using (List<ShipTowerRewardItemData>.Enumerator enumerator2 = shipTowerAreaItemData2.RewardList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.IsCompleted)
					{
						num3++;
					}
				}
			}
			num += num3;
			num2 += shipTowerAreaItemData2.RewardList.Count;
		}
		return new ValueTuple<int, int>(num, num2);
	}

	// Token: 0x06015395 RID: 86933 RVA: 0x005E0F68 File Offset: 0x005DF168
	[NullableContext(0)]
	public ValueTuple<int, int> GetEndlessRewardProgressNumData()
	{
		int num = 0;
		int num2 = 0;
		List<ShipTowerAreaItemData> list = new List<ShipTowerAreaItemData>();
		foreach (ShipTowerAreaItemData shipTowerAreaItemData in this.AreaList)
		{
			if (shipTowerAreaItemData.Id != 0)
			{
				list.Add(shipTowerAreaItemData);
			}
		}
		foreach (ShipTowerAreaItemData shipTowerAreaItemData2 in list)
		{
			num += shipTowerAreaItemData2.RewardList.FindAll((ShipTowerRewardItemData item) => item.IsCompleted).Count;
			num2 += shipTowerAreaItemData2.RewardList.Count;
		}
		return new ValueTuple<int, int>(num, num2);
	}

	// Token: 0x06015396 RID: 86934 RVA: 0x005E1054 File Offset: 0x005DF254
	public bool CheckIsScoreBattle()
	{
		if (this.CurSeasonCfg == null || !this.CurSeasonCfg.Value.IsOpenHot)
		{
			return false;
		}
		ShipTowerStageData challengeStageData = this.ChallengeStageData;
		return challengeStageData != null && challengeStageData.StageType > EShipTowerStageType.OneTimeStage;
	}

	// Token: 0x06015397 RID: 86935 RVA: 0x005E10A0 File Offset: 0x005DF2A0
	[NullableContext(2)]
	public ShipTowerTeamData GetCurrentStageTeamData()
	{
		ShipTowerStageData currentStage = this.GetCurrentStage();
		if (currentStage == null)
		{
			return null;
		}
		return currentStage.GetCurrentTeamData();
	}

	// Token: 0x06015398 RID: 86936 RVA: 0x005E10B4 File Offset: 0x005DF2B4
	[NullableContext(2)]
	public List<int> GetRewardIdsByDifficulties(bool isCanReceive)
	{
		if (this.RewardCanReceiveNum <= 0)
		{
			return null;
		}
		List<int> list = new List<int>();
		foreach (ShipTowerAreaItemData shipTowerAreaItemData in this.AreaList)
		{
			foreach (ShipTowerRewardItemData shipTowerRewardItemData in shipTowerAreaItemData.RewardList)
			{
				int id = shipTowerAreaItemData.Id;
				bool? isEndless = shipTowerAreaItemData.IsEndless;
				int num = 0;
				foreach (ShipTowerStageData shipTowerStageData in this.TowerStageDataList)
				{
					bool flag = shipTowerStageData.BelongToSeason == id;
					bool flag2 = shipTowerStageData.IsEndLess == isEndless.GetValueOrDefault();
					if (flag && flag2)
					{
						num += shipTowerStageData.CurrentScore;
					}
				}
				if (isCanReceive)
				{
					if (!this.ReceivedAwardScoreIdSet.Contains(shipTowerRewardItemData.Id) && num >= shipTowerRewardItemData.TotalScore)
					{
						list.Add(shipTowerRewardItemData.Id);
					}
				}
				else if (this.ReceivedAwardScoreIdSet.Contains(shipTowerRewardItemData.Id))
				{
					list.Add(shipTowerRewardItemData.Id);
				}
			}
		}
		return list;
	}

	// Token: 0x0601539A RID: 86938 RVA: 0x005E1324 File Offset: 0x005DF524
	[CompilerGenerated]
	internal static List<ShipTowerMediumItemData> <UpdateResultNotify>g__MakeRoleList|100_0(ShipTowerTeamData teamData)
	{
		List<ShipTowerMediumItemData> list = new List<ShipTowerMediumItemData>();
		foreach (ShipTowerRoleData shipTowerRoleData in teamData.RoleList)
		{
			List<ShipTowerMediumItemData> list2 = list;
			ShipTowerMediumItemData shipTowerMediumItemData = new ShipTowerMediumItemData();
			shipTowerMediumItemData.Id = shipTowerRoleData.RoleIdEdit;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(shipTowerRoleData.RoleIdEdit, true);
			shipTowerMediumItemData.Count = ((roleDataById != null) ? roleDataById.GetLevelData().GetLevel() : 0);
			shipTowerMediumItemData.SkillBranchId = shipTowerRoleData.SkillBranchIdEdit;
			list2.Add(shipTowerMediumItemData);
		}
		return list;
	}

	// Token: 0x0601539B RID: 86939 RVA: 0x005E13C4 File Offset: 0x005DF5C4
	[CompilerGenerated]
	internal static void <AddRecord>g__functionAddTeam|106_0(string teamTitle, [Nullable(2)] HalfEndlessBattleRecord teamInfo, ref ShipTowerModel.<>c__DisplayClass106_0 A_2)
	{
		if (teamInfo == null)
		{
			return;
		}
		BattleFormation battleFormation = teamInfo.BattleFormation;
		RepeatedField<int> repeatedField = (battleFormation != null) ? battleFormation.SelectRoles : null;
		List<int> list = (repeatedField != null) ? new List<int>(repeatedField) : new List<int>();
		List<int> list2 = new List<int>(teamInfo.RoleLevels);
		BattleFormation battleFormation2 = teamInfo.BattleFormation;
		RepeatedField<int> repeatedField2 = (battleFormation2 != null) ? battleFormation2.SkillBranchIds : null;
		List<ShipTowerMediumItemData> list3 = new List<ShipTowerMediumItemData>();
		for (int i = 0; i < list.Count; i++)
		{
			int id = list[i];
			int count = (i < list2.Count) ? list2[i] : 0;
			int skillBranchId = (repeatedField2 != null && i < repeatedField2.Count) ? repeatedField2[i] : 0;
			list3.Add(new ShipTowerMediumItemData
			{
				Id = id,
				Count = count,
				SkillBranchId = skillBranchId
			});
		}
		ShipTowerRecordItemData shipTowerRecordItemData = new ShipTowerRecordItemData();
		shipTowerRecordItemData.Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(teamTitle, teamTitle);
		shipTowerRecordItemData.Score = teamInfo.MaxScore;
		shipTowerRecordItemData.Wave = teamInfo.MaxRound;
		shipTowerRecordItemData.TeamList = list3;
		BattleFormation battleFormation3 = teamInfo.BattleFormation;
		shipTowerRecordItemData.BuffId = ((battleFormation3 != null) ? battleFormation3.BuffSelect : 0);
		ShipTowerRecordItemData item = shipTowerRecordItemData;
		A_2.data.RecordList.Add(item);
	}

	// Token: 0x0400A39F RID: 41887
	private bool IsInitData;

	// Token: 0x0400A3A0 RID: 41888
	private readonly List<ShipTowerStageData> StageDataList = new List<ShipTowerStageData>();

	// Token: 0x0400A3A1 RID: 41889
	private readonly Dictionary<int, ShipTowerStageData> StageDataMap = new Dictionary<int, ShipTowerStageData>();

	// Token: 0x0400A3A2 RID: 41890
	public bool DebugParallaxSub;

	// Token: 0x0400A3A3 RID: 41891
	private readonly List<ShipTowerBuffQuality> BuffQualityList = new List<ShipTowerBuffQuality>();

	// Token: 0x0400A3A4 RID: 41892
	private readonly Dictionary<int, ShipTowerBuffQuality> BuffQualityMap = new Dictionary<int, ShipTowerBuffQuality>();

	// Token: 0x0400A3A5 RID: 41893
	private readonly Dictionary<int, ShipTowerBuffData> BuffDataMap = new Dictionary<int, ShipTowerBuffData>();

	// Token: 0x0400A3A6 RID: 41894
	private readonly List<ShipTowerTeamTab> TeamTabList = new List<ShipTowerTeamTab>();

	// Token: 0x0400A3A7 RID: 41895
	private readonly Dictionary<int, ShipTowerRoleData> OtherTeamRoleMap = new Dictionary<int, ShipTowerRoleData>();

	// Token: 0x0400A3A8 RID: 41896
	private readonly Dictionary<int, ShipTowerRoleData> AllTeamRoleMap = new Dictionary<int, ShipTowerRoleData>();

	// Token: 0x0400A3A9 RID: 41897
	private int Season;

	// Token: 0x0400A3AA RID: 41898
	private long SeasonEndTime;

	// Token: 0x0400A3AB RID: 41899
	private bool IsHaveRecord;

	// Token: 0x0400A3AC RID: 41900
	private bool IsNeedShowSeasonReview;

	// Token: 0x0400A3AD RID: 41901
	private readonly List<ShipTowerAreaItemData> AreaList = new List<ShipTowerAreaItemData>();

	// Token: 0x0400A3AE RID: 41902
	private readonly HashSet<int> ReceivedAwardScoreIdSet = new HashSet<int>();

	// Token: 0x0400A3AF RID: 41903
	private int ReceivingAwardId;

	// Token: 0x0400A3B0 RID: 41904
	public List<ShipTowerAreaItemData> RecordList = new List<ShipTowerAreaItemData>();

	// Token: 0x0400A3B1 RID: 41905
	private int RewardCanReceiveNum;

	// Token: 0x0400A3B2 RID: 41906
	private int RewardTotalNum;

	// Token: 0x0400A3B3 RID: 41907
	[Nullable(2)]
	public ShipTowerStageData ChallengeStageData;

	// Token: 0x0400A3B4 RID: 41908
	public readonly List<int> ChallengeBuffIdList = new List<int>();

	// Token: 0x0400A3B5 RID: 41909
	public readonly List<ShipTowerReviewItemData> ReviewList = new List<ShipTowerReviewItemData>();

	// Token: 0x0400A3B6 RID: 41910
	public readonly List<int> ReviewProgressList = new List<int>();

	// Token: 0x0400A3B7 RID: 41911
	private readonly List<int> GetBuffIdList = new List<int>();

	// Token: 0x0400A3B8 RID: 41912
	public readonly List<int> ShowBuffIdList = new List<int>();

	// Token: 0x0400A3B9 RID: 41913
	[Nullable(2)]
	private CustomPromise<bool> WelcomeViewPromise;

	// Token: 0x0400A3BA RID: 41914
	[Nullable(2)]
	private CustomPromise<bool> SeasonReviewViewPromise;

	// Token: 0x0400A3BB RID: 41915
	[Nullable(2)]
	private CustomPromise<bool> GetBuffViewPromise;

	// Token: 0x0400A3BC RID: 41916
	[Nullable(2)]
	public ShipTowerBuffData CurSelectBuffData;

	// Token: 0x0400A3BD RID: 41917
	public readonly HashSet<int> PlayerGetBuffSet = new HashSet<int>();

	// Token: 0x0400A3BE RID: 41918
	public bool IsShowLeftTeamPanel;

	// Token: 0x0400A3BF RID: 41919
	public bool IsOpenedSeasonUpdate;

	// Token: 0x0400A3C0 RID: 41920
	public bool IsOpenedViewByWorld;
}
