using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002502 RID: 9474
[NullableContext(1)]
[Nullable(0)]
public class VisionEquipmentRecommendItem : UiPanelBase
{
	// Token: 0x06012651 RID: 75345 RVA: 0x0050E980 File Offset: 0x0050CB80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x06012652 RID: 75346 RVA: 0x0050EAD4 File Offset: 0x0050CCD4
	protected override UniTask OnBeforeStartAsync()
	{
		VisionEquipmentRecommendItem.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionEquipmentRecommendItem.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012653 RID: 75347 RVA: 0x0050EB18 File Offset: 0x0050CD18
	private void InitAllLayouts()
	{
		UUILayoutBase layoutBase = base.GetLayoutBase(0);
		Func<VisionRecommendFetterItem> gridProxyCreateFunction = new Func<VisionRecommendFetterItem>(this.InitSystemRecommendItem);
		UUIItem item = base.GetItem(1);
		this.SystemRecommendLayout = new GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo>(layoutBase, gridProxyCreateFunction, ((item != null) ? item.GetOwner() : null) as AUIBaseActor, false, true);
		UUILayoutBase layoutBase2 = base.GetLayoutBase(2);
		Func<VisionRecommendFetterItem> gridProxyCreateFunction2 = new Func<VisionRecommendFetterItem>(this.InitUsageRecommendItem);
		UUIItem item2 = base.GetItem(3);
		this.UsageRecommendLayout = new GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo>(layoutBase2, gridProxyCreateFunction2, ((item2 != null) ? item2.GetOwner() : null) as AUIBaseActor, false, true);
	}

	// Token: 0x06012654 RID: 75348 RVA: 0x0050EB95 File Offset: 0x0050CD95
	private VisionRecommendFetterItem InitSystemRecommendItem()
	{
		return new VisionRecommendFetterItem
		{
			OnSelectedCallback = new Action<int>(this.OnSystemRecommendItemSelected)
		};
	}

	// Token: 0x06012655 RID: 75349 RVA: 0x0050EBAE File Offset: 0x0050CDAE
	private VisionRecommendFetterItem InitUsageRecommendItem()
	{
		return new VisionRecommendFetterItem
		{
			OnSelectedCallback = new Action<int>(this.OnUsageRecommendItemSelected)
		};
	}

	// Token: 0x06012656 RID: 75350 RVA: 0x0050EBC8 File Offset: 0x0050CDC8
	private void OnSystemRecommendItemSelected(int index)
	{
		List<VisionFetterRecommendInfo> roleSystemFetterRecommendList = ModelBase<VisionRecommendModel>.Instance.GetRoleSystemFetterRecommendList(this.CurrentRoleId);
		if (roleSystemFetterRecommendList == null || index < 0 || index >= roleSystemFetterRecommendList.Count)
		{
			return;
		}
		VisionFetterRecommendInfo info = roleSystemFetterRecommendList[index];
		GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout = this.UsageRecommendLayout;
		if (usageRecommendLayout != null)
		{
			usageRecommendLayout.DeselectCurrentGridProxy();
		}
		GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout = this.SystemRecommendLayout;
		if (systemRecommendLayout != null)
		{
			systemRecommendLayout.SelectGridProxy(index, false);
		}
		this.RefreshSelectedRecommendDetail(info);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopPlayingSequence(false, true);
		}
		LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 == null)
		{
			return;
		}
		sequencePlayer2.PlayOrReplaySequenceByName("Switch", false, null);
	}

	// Token: 0x06012657 RID: 75351 RVA: 0x0050EC5C File Offset: 0x0050CE5C
	private void OnUsageRecommendItemSelected(int index)
	{
		List<VisionFetterRecommendInfo> roleUsageFetterRecommendList = ModelBase<VisionRecommendModel>.Instance.GetRoleUsageFetterRecommendList(this.CurrentRoleId);
		if (roleUsageFetterRecommendList == null || index < 0 || index >= roleUsageFetterRecommendList.Count)
		{
			return;
		}
		VisionFetterRecommendInfo info = roleUsageFetterRecommendList[index];
		GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout = this.SystemRecommendLayout;
		if (systemRecommendLayout != null)
		{
			systemRecommendLayout.DeselectCurrentGridProxy();
		}
		GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout = this.UsageRecommendLayout;
		if (usageRecommendLayout != null)
		{
			usageRecommendLayout.SelectGridProxy(index, false);
		}
		this.RefreshSelectedRecommendDetail(info);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopPlayingSequence(false, true);
		}
		LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 == null)
		{
			return;
		}
		sequencePlayer2.PlayOrReplaySequenceByName("Switch", false, null);
	}

	// Token: 0x06012658 RID: 75352 RVA: 0x0050ECF0 File Offset: 0x0050CEF0
	private void RefreshSelectedRecommendDetail(VisionFetterRecommendInfo info)
	{
		bool isOfficial = info.GetUsage() == 0;
		this.SetCurrentPlan(info, isOfficial);
	}

	// Token: 0x06012659 RID: 75353 RVA: 0x0050ED0F File Offset: 0x0050CF0F
	protected override void OnBeforeDestroy()
	{
		ModelBase<VisionRecommendModel>.Instance.CurrentSelectMainAttrArray = new List<VisionSelectRecommendData>();
		ModelBase<VisionRecommendModel>.Instance.CurrentSelectSubAttrArray = new List<VisionSelectRecommendData>();
		ModelBase<VisionRecommendModel>.Instance.CurrentMainPhantom = null;
	}

	// Token: 0x0601265A RID: 75354 RVA: 0x0050ED3A File Offset: 0x0050CF3A
	public void BindOnChangeAttrCallBack(Action callback)
	{
		this.OnChangeAttrCallBack = callback;
	}

	// Token: 0x0601265B RID: 75355 RVA: 0x0050ED44 File Offset: 0x0050CF44
	public void ChangeCost(int cost, int roleId)
	{
		this.CurrentRoleId = roleId;
		this.TabCost = cost;
		this.RefreshAttrListData(roleId);
		VisionFetterRecommendInfo visionFetterRecommendInfo = this.CurrentPlanInfo ?? this.MatchDefaultPlan(roleId);
		if (visionFetterRecommendInfo == null)
		{
			return;
		}
		if (visionFetterRecommendInfo == this.CurrentPlanInfo)
		{
			this.OnChangeCurrentSelectAttr();
			return;
		}
		this.RefreshRecommendLayout(visionFetterRecommendInfo);
	}

	// Token: 0x0601265C RID: 75356 RVA: 0x0050ED94 File Offset: 0x0050CF94
	private void RefreshRecommendLayout(VisionFetterRecommendInfo info)
	{
		List<VisionFetterRecommendInfo> roleSystemFetterRecommendList = ModelBase<VisionRecommendModel>.Instance.GetRoleSystemFetterRecommendList(this.CurrentRoleId);
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout = this.SystemRecommendLayout;
		if (systemRecommendLayout != null)
		{
			systemRecommendLayout.RefreshByData(roleSystemFetterRecommendList, delegate
			{
				GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout2 = this.SystemRecommendLayout;
				if (systemRecommendLayout2 == null)
				{
					return;
				}
				systemRecommendLayout2.SelectGridProxyByKey(info, true);
			}, false);
		}
		List<VisionFetterRecommendInfo> roleUsageFetterRecommendList = ModelBase<VisionRecommendModel>.Instance.GetRoleUsageFetterRecommendList(this.CurrentRoleId);
		if (roleUsageFetterRecommendList != null && roleUsageFetterRecommendList.Count > 0)
		{
			UUIItem item2 = base.GetItem(12);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout = this.UsageRecommendLayout;
			if (usageRecommendLayout == null)
			{
				return;
			}
			usageRecommendLayout.RefreshByData(roleUsageFetterRecommendList, delegate
			{
				GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout2 = this.UsageRecommendLayout;
				if (usageRecommendLayout2 == null)
				{
					return;
				}
				usageRecommendLayout2.SelectGridProxyByKey(info, true);
			}, false);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(12);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0601265D RID: 75357 RVA: 0x0050EE5C File Offset: 0x0050D05C
	[NullableContext(2)]
	public void SetCurrentPlan(VisionFetterRecommendInfo planInfo, bool isOfficial)
	{
		bool flag = this.CurrentPlanInfo == planInfo;
		this.CurrentPlanInfo = planInfo;
		this.IsOfficialPlan = isOfficial;
		if (!flag)
		{
			this.CurrentSelectMainAttrArray.Clear();
			this.CurrentSelectSubAttrArray.Clear();
			this.CurrentSelectMainPhantom = null;
		}
		this.RefreshTopItemFetterIcons();
		this.RefreshAttrListData(this.CurrentRoleId);
		this.OnChangeCurrentSelectAttr();
		Action<VisionFetterRecommendInfo> onPlanChangedCallback = this.OnPlanChangedCallback;
		if (onPlanChangedCallback == null)
		{
			return;
		}
		onPlanChangedCallback(this.CurrentPlanInfo);
	}

	// Token: 0x0601265E RID: 75358 RVA: 0x0050EECD File Offset: 0x0050D0CD
	private void RefreshTopItemFetterIcons()
	{
		VisionEquipmentRecommendItemTop topItem = this.TopItem;
		if (topItem == null)
		{
			return;
		}
		topItem.Refresh(this.CurrentPlanInfo.BuildFetterItemDataList());
	}

	// Token: 0x0601265F RID: 75359 RVA: 0x0050EEEC File Offset: 0x0050D0EC
	[NullableContext(2)]
	public VisionFetterRecommendInfo MatchDefaultPlan(int roleId)
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(roleId);
		if (roleFetterRecommendInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.CB, "recommendList is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		List<VisionFetterRecommendInfo> roleSystemFetterRecommendList = ModelBase<VisionRecommendModel>.Instance.GetRoleSystemFetterRecommendList(roleId);
		int coreGroupId = this.FindCoreGroupId(roleId);
		VisionFetterRecommendInfo visionFetterRecommendInfo;
		if (coreGroupId == 0)
		{
			visionFetterRecommendInfo = ((roleSystemFetterRecommendList.Count > 0) ? roleSystemFetterRecommendList[0] : null);
		}
		else
		{
			List<VisionFetterRecommendInfo> list = (from info in roleFetterRecommendInfo
			where info.GetRecommendFetterGroupId() == coreGroupId
			select info).ToList<VisionFetterRecommendInfo>();
			if (list.Count == 0)
			{
				visionFetterRecommendInfo = ((roleSystemFetterRecommendList.Count > 0) ? roleSystemFetterRecommendList[0] : null);
			}
			else
			{
				List<int> activatedGroupIds = this.GetActivatedFetterGroupIds(roleId);
				visionFetterRecommendInfo = list.Find(delegate(VisionFetterRecommendInfo info)
				{
					int recommendFetterGroupId = info.GetRecommendFetterGroupId();
					int specialFetterSubGroupId = info.GetSpecialFetterSubGroupId();
					return activatedGroupIds.Contains(recommendFetterGroupId) && (specialFetterSubGroupId == 0 || activatedGroupIds.Contains(specialFetterSubGroupId));
				});
				if (visionFetterRecommendInfo == null)
				{
					visionFetterRecommendInfo = list.Find((VisionFetterRecommendInfo info) => info.GetUsage() == 0);
					if (visionFetterRecommendInfo == null)
					{
						list.Sort((VisionFetterRecommendInfo a, VisionFetterRecommendInfo b) => b.GetUsage() - a.GetUsage());
						visionFetterRecommendInfo = ((list.Count > 0) ? list[0] : null);
					}
				}
			}
		}
		return visionFetterRecommendInfo;
	}

	// Token: 0x06012660 RID: 75360 RVA: 0x0050F038 File Offset: 0x0050D238
	private int FindCoreGroupId(int roleId)
	{
		List<int> activatedFetterGroupIds = this.GetActivatedFetterGroupIds(roleId);
		if (activatedFetterGroupIds.Count == 0)
		{
			return 0;
		}
		if (activatedFetterGroupIds.Count == 1)
		{
			return activatedFetterGroupIds[0];
		}
		if (activatedFetterGroupIds.Count != 2)
		{
			return 0;
		}
		int fetterGroupActivateCount = this.GetFetterGroupActivateCount(roleId, activatedFetterGroupIds[0]);
		int fetterGroupActivateCount2 = this.GetFetterGroupActivateCount(roleId, activatedFetterGroupIds[1]);
		if (fetterGroupActivateCount == fetterGroupActivateCount2)
		{
			return 0;
		}
		if (fetterGroupActivateCount <= fetterGroupActivateCount2)
		{
			return activatedFetterGroupIds[1];
		}
		return activatedFetterGroupIds[0];
	}

	// Token: 0x06012661 RID: 75361 RVA: 0x0050F0AC File Offset: 0x0050D2AC
	private List<int> GetActivatedFetterGroupIds(int roleId)
	{
		PhantomRoleEquipmentData battleDataById = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId);
		if (battleDataById == null)
		{
			return new List<int>();
		}
		List<int> incrIdList = battleDataById.GetIncrIdList();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int num in incrIdList)
		{
			if (num != 0)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(num);
				if (phantomBattleData != null)
				{
					int fetterGroupId = phantomBattleData.GetFetterGroupId();
					int num2;
					dictionary[fetterGroupId] = (dictionary.TryGetValue(fetterGroupId, out num2) ? num2 : 0) + 1;
				}
			}
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			Dictionary<int, int> dictionary2 = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(key).FetterMap();
			if (dictionary2 != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair2 in dictionary2)
				{
					int key2 = keyValuePair2.Key;
					if (value >= key2)
					{
						list.Add(key);
						break;
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06012662 RID: 75362 RVA: 0x0050F210 File Offset: 0x0050D410
	private int GetFetterGroupActivateCount(int roleId, int groupId)
	{
		PhantomRoleEquipmentData battleDataById = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId);
		if (battleDataById == null)
		{
			return 0;
		}
		List<int> incrIdList = battleDataById.GetIncrIdList();
		int num = 0;
		foreach (int num2 in incrIdList)
		{
			if (num2 != 0)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(num2);
				if (phantomBattleData != null && phantomBattleData.GetFetterGroupId() == groupId)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06012663 RID: 75363 RVA: 0x0050F294 File Offset: 0x0050D494
	public List<int> GetCurrentPlanFetterGroupIds()
	{
		VisionFetterRecommendInfo currentPlanInfo = this.CurrentPlanInfo;
		return ((currentPlanInfo != null) ? currentPlanInfo.BuildFetterList() : null) ?? new List<int>();
	}

	// Token: 0x06012664 RID: 75364 RVA: 0x0050F2B4 File Offset: 0x0050D4B4
	public void RefreshSelectAllToggleState(List<int> currentFilteredGroupIds)
	{
		if (this.TopItem == null || this.CurrentPlanInfo == null)
		{
			VisionEquipmentRecommendItemTop topItem = this.TopItem;
			if (topItem == null)
			{
				return;
			}
			topItem.SetToggleState(EToggleState.ETT_UnChecked);
			return;
		}
		else
		{
			List<int> currentPlanFetterGroupIds = this.GetCurrentPlanFetterGroupIds();
			if (currentPlanFetterGroupIds.Count == 0)
			{
				this.TopItem.SetToggleState(EToggleState.ETT_UnChecked);
				return;
			}
			List<int> list = new List<int>(currentFilteredGroupIds);
			list.Sort((int a, int b) => a - b);
			List<int> list2 = new List<int>(currentPlanFetterGroupIds);
			list2.Sort((int a, int b) => a - b);
			bool flag = list.Count == list2.Count;
			if (flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] != list2[i])
					{
						flag = false;
						break;
					}
				}
			}
			this.TopItem.SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
			return;
		}
	}

	// Token: 0x06012665 RID: 75365 RVA: 0x0050F3A8 File Offset: 0x0050D5A8
	public void OnSelectAllBtnClick(EToggleState state)
	{
		List<int> currentPlanFetterGroupIds = this.GetCurrentPlanFetterGroupIds();
		if (state == EToggleState.ETT_UnChecked)
		{
			this.CurrentSelectMainAttrArray.Clear();
			this.CurrentSelectSubAttrArray.Clear();
			this.CurrentSelectMainPhantom = null;
			Action<List<int>, bool> onSelectAllCallback = this.OnSelectAllCallback;
			if (onSelectAllCallback != null)
			{
				onSelectAllCallback(currentPlanFetterGroupIds, false);
			}
		}
		else
		{
			Action<List<int>, bool> onSelectAllCallback2 = this.OnSelectAllCallback;
			if (onSelectAllCallback2 != null)
			{
				onSelectAllCallback2(currentPlanFetterGroupIds, true);
			}
		}
		this.RefreshAttrListData(this.CurrentRoleId);
		this.OnChangeCurrentSelectAttr();
	}

	// Token: 0x06012666 RID: 75366 RVA: 0x0050F418 File Offset: 0x0050D618
	public void OnMainAttrSelectAllBtnClick(EToggleState state)
	{
		this.CurrentSelectMainAttrArray.Clear();
		if (state == EToggleState.ETT_Checked)
		{
			foreach (RecommendItemData recommendItemData in this.CurrentShowMainAttrArray)
			{
				VisionSelectRecommendData visionSelectRecommendData = new VisionSelectRecommendData();
				visionSelectRecommendData.AttrId = recommendItemData.AttrId;
				visionSelectRecommendData.AddType = recommendItemData.AddType;
				this.CurrentSelectMainAttrArray.Add(visionSelectRecommendData);
			}
		}
		this.OnChangeCurrentSelectAttr();
	}

	// Token: 0x06012667 RID: 75367 RVA: 0x0050F4A4 File Offset: 0x0050D6A4
	private bool IsMainAttrAllSelected()
	{
		return this.CurrentShowMainAttrArray.Count > 0 && this.CurrentSelectMainAttrArray.Count == this.CurrentShowMainAttrArray.Count;
	}

	// Token: 0x06012668 RID: 75368 RVA: 0x0050F4D0 File Offset: 0x0050D6D0
	public void OnSubAttrSelectAllBtnClick(EToggleState state)
	{
		this.CurrentSelectSubAttrArray.Clear();
		if (state == EToggleState.ETT_Checked)
		{
			foreach (RecommendItemData recommendItemData in this.CurrentShowSubAttrArray)
			{
				VisionSelectRecommendData visionSelectRecommendData = new VisionSelectRecommendData();
				visionSelectRecommendData.AttrId = recommendItemData.AttrId;
				visionSelectRecommendData.AddType = recommendItemData.AddType;
				this.CurrentSelectSubAttrArray.Add(visionSelectRecommendData);
			}
		}
		this.OnChangeCurrentSelectAttr();
	}

	// Token: 0x06012669 RID: 75369 RVA: 0x0050F55C File Offset: 0x0050D75C
	private bool IsSubAttrAllSelected()
	{
		return this.CurrentShowSubAttrArray.Count > 0 && this.CurrentSelectSubAttrArray.Count == this.CurrentShowSubAttrArray.Count;
	}

	// Token: 0x0601266A RID: 75370 RVA: 0x0050F588 File Offset: 0x0050D788
	public void CheckAndUpdateMainPhantomByFilter(List<int> currentSuitGroupIds, List<string> currentMonsterNames)
	{
		if (this.CurrentSelectMainPhantom == null)
		{
			return;
		}
		int fetterGroupId = this.CurrentSelectMainPhantom.FetterGroupId;
		bool flag = currentSuitGroupIds.Count == 0 || currentSuitGroupIds.Contains(fetterGroupId);
		bool flag2 = true;
		if (currentMonsterNames.Count > 0)
		{
			IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(this.CurrentSelectMainPhantom.MonsterId);
			if (phantomItemByMonsterId != null && phantomItemByMonsterId.Count > 0)
			{
				MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.CurrentSelectMainPhantom.MonsterId).Value.MonsterInfoId);
				if (monsterInfoConfig != null)
				{
					flag2 = currentMonsterNames.Contains(monsterInfoConfig.Value.Name);
				}
			}
		}
		if (!flag || !flag2)
		{
			this.CurrentSelectMainPhantom = null;
			this.RefreshAttrListData(this.CurrentRoleId);
			this.OnChangeCurrentSelectAttr();
		}
	}

	// Token: 0x0601266B RID: 75371 RVA: 0x0050F65C File Offset: 0x0050D85C
	private void RefreshAttrListData(int roleId)
	{
		int num = this.TabCost;
		if (this.CurrentSelectMainPhantom != null)
		{
			int rarity = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(this.CurrentSelectMainPhantom.MonsterId)[0].Rarity;
			num = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost;
		}
		this.CurrentCost = num;
		VisionAttrRecommendInfo roleCostAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleCostAttrRecommendInfo(roleId, num);
		if (roleCostAttrRecommendInfo != null)
		{
			List<AttrRecommendInfo> mainAttrRecommendInfo = roleCostAttrRecommendInfo.GetMainAttrRecommendInfo();
			for (int i = this.CurrentSelectMainAttrArray.Count - 1; i >= 0; i--)
			{
				bool flag = false;
				foreach (AttrRecommendInfo attrRecommendInfo in mainAttrRecommendInfo)
				{
					if (attrRecommendInfo.GetAttrId() == this.CurrentSelectMainAttrArray[i].AttrId && attrRecommendInfo.GetAddType() == this.CurrentSelectMainAttrArray[i].AddType)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.CurrentSelectMainAttrArray.RemoveAt(i);
				}
			}
		}
		List<AttrRecommendInfo> subAttrData = this.GetSubAttrData();
		if (subAttrData != null)
		{
			for (int j = this.CurrentSelectSubAttrArray.Count - 1; j >= 0; j--)
			{
				bool flag2 = false;
				foreach (AttrRecommendInfo attrRecommendInfo2 in subAttrData)
				{
					if (attrRecommendInfo2.GetAttrId() == this.CurrentSelectSubAttrArray[j].AttrId && attrRecommendInfo2.GetAddType() == this.CurrentSelectSubAttrArray[j].AddType)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					this.CurrentSelectSubAttrArray.RemoveAt(j);
				}
			}
		}
	}

	// Token: 0x0601266C RID: 75372 RVA: 0x0050F844 File Offset: 0x0050DA44
	private void OnChangeCurrentSelectAttr()
	{
		this.RefreshMainPhantomRecommend();
		this.RefreshAttrRecommend();
		this.RefreshCostDistribution();
		if (this.OnChangeAttrCallBack != null)
		{
			this.OnChangeAttrCallBack();
		}
	}

	// Token: 0x0601266D RID: 75373 RVA: 0x0050F86C File Offset: 0x0050DA6C
	private void RefreshMainPhantomRecommend()
	{
		MainRecommendPhantom mainPhantomRecommendItem = this.MainPhantomRecommendItem;
		if (mainPhantomRecommendItem != null)
		{
			mainPhantomRecommendItem.SetUiActive(true);
		}
		ModelBase<VisionRecommendModel>.Instance.CurrentMainPhantom = this.CurrentSelectMainPhantom;
		int count = 2;
		VisionFetterRecommendInfo currentPlanInfo = this.CurrentPlanInfo;
		List<MainPhantomRecommendInfo> list = ((currentPlanInfo != null) ? currentPlanInfo.GetMainPhantomList().Take(count).ToList<MainPhantomRecommendInfo>() : null) ?? new List<MainPhantomRecommendInfo>();
		this.CurrentShowMainPhantomArray.Clear();
		foreach (MainPhantomRecommendInfo info in list)
		{
			MainPhantomItemData item = new MainPhantomItemData
			{
				Info = info,
				CurrentSelectMainPhantom = this.CurrentSelectMainPhantom,
				OnMainPhantomCallBack = new Action<IMainPhantomItemData>(this.OnSelectMainAttr)
			};
			this.CurrentShowMainPhantomArray.Add(item);
		}
		MainRecommendPhantom mainPhantomRecommendItem2 = this.MainPhantomRecommendItem;
		if (mainPhantomRecommendItem2 == null)
		{
			return;
		}
		mainPhantomRecommendItem2.Refresh(this.CurrentShowMainPhantomArray);
	}

	// Token: 0x0601266E RID: 75374 RVA: 0x0050F954 File Offset: 0x0050DB54
	private void RefreshAttrRecommend()
	{
		ModelBase<VisionRecommendModel>.Instance.CurrentSelectMainAttrArray = this.CurrentSelectMainAttrArray;
		ModelBase<VisionRecommendModel>.Instance.CurrentSelectSubAttrArray = this.CurrentSelectSubAttrArray;
		if (this.CurrentCost == 0)
		{
			this.RefreshMainAttrForAllCost();
		}
		else
		{
			this.RefreshMainAttrForSpecificCost(this.CurrentCost);
		}
		MainRecommendAttr mainRecommendAttr = this.MainRecommendAttr;
		if (mainRecommendAttr != null)
		{
			mainRecommendAttr.SetToggleAllState(this.IsMainAttrAllSelected());
		}
		this.RefreshSubAttrRecommend();
		SubRecommendAttr subRecommendAttr = this.SubRecommendAttr;
		if (subRecommendAttr == null)
		{
			return;
		}
		subRecommendAttr.SetToggleAllState(this.IsSubAttrAllSelected());
	}

	// Token: 0x0601266F RID: 75375 RVA: 0x0050F9D0 File Offset: 0x0050DBD0
	private void RefreshMainAttrForAllCost()
	{
		List<int> list = new List<int>();
		list.Add(4);
		list.Add(3);
		list.Add(1);
		this.CurrentShowMainAttrArray.Clear();
		List<IMainRecommendAttrItemData> data = (from cost in list
		select this.BuildMainAttrGroup(cost, true, new int?(1))).ToList<IMainRecommendAttrItemData>();
		MainRecommendAttr mainRecommendAttr = this.MainRecommendAttr;
		if (mainRecommendAttr == null)
		{
			return;
		}
		mainRecommendAttr.Refresh(data);
	}

	// Token: 0x06012670 RID: 75376 RVA: 0x0050FA2C File Offset: 0x0050DC2C
	private void RefreshMainAttrForSpecificCost(int cost)
	{
		this.CurrentShowMainAttrArray.Clear();
		MainRecommendAttr mainRecommendAttr = this.MainRecommendAttr;
		if (mainRecommendAttr == null)
		{
			return;
		}
		mainRecommendAttr.Refresh(new List<IMainRecommendAttrItemData>
		{
			this.BuildMainAttrGroup(cost, true, null)
		});
	}

	// Token: 0x06012671 RID: 75377 RVA: 0x0050FA70 File Offset: 0x0050DC70
	private IMainRecommendAttrItemData BuildMainAttrGroup(int cost, bool showUsage, int? limit = null)
	{
		List<AttrRecommendInfo> roleMainAttrRecommendListByPlan = ModelBase<VisionRecommendModel>.Instance.GetRoleMainAttrRecommendListByPlan(this.CurrentRoleId, cost, this.IsOfficialPlan);
		List<RecommendItemData> list = new List<RecommendItemData>();
		if (roleMainAttrRecommendListByPlan.Count > 0)
		{
			List<AttrRecommendInfo> list2 = new List<AttrRecommendInfo>(roleMainAttrRecommendListByPlan);
			list2.Sort((AttrRecommendInfo a, AttrRecommendInfo b) => b.GetUsage() - a.GetUsage());
			foreach (AttrRecommendInfo attrRecommendInfo in ((limit != null) ? list2.Take(limit.Value).ToList<AttrRecommendInfo>() : list2))
			{
				RecommendItemData recommendItemData = new RecommendItemData();
				recommendItemData.AttrId = attrRecommendInfo.GetAttrId();
				recommendItemData.AddType = attrRecommendInfo.GetAddType();
				recommendItemData.CurrentSelectArray = this.CurrentSelectMainAttrArray;
				recommendItemData.UsageText = (showUsage ? attrRecommendInfo.GetUsageText() : "");
				recommendItemData.Type = 1;
				recommendItemData.OnSelectCallBack = new Action<RecommendItemData>(this.OnSelectAttr);
				list.Add(recommendItemData);
				this.CurrentShowMainAttrArray.Add(recommendItemData);
			}
		}
		return new MainRecommendAttrItemData
		{
			CostLabel = VisionEquipmentRecommendItem.costLabelTextIdMap.GetValueOrDefault(cost),
			Items = list
		};
	}

	// Token: 0x06012672 RID: 75378 RVA: 0x0050FBC8 File Offset: 0x0050DDC8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<AttrRecommendInfo> GetSubAttrData()
	{
		if (this.CurrentCost != 0)
		{
			VisionAttrRecommendInfo roleCostAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleCostAttrRecommendInfo(this.CurrentRoleId, this.CurrentCost);
			if (!this.IsOfficialPlan)
			{
				if (roleCostAttrRecommendInfo == null)
				{
					return null;
				}
				return roleCostAttrRecommendInfo.GetUsageSubAttrRecommendInfo();
			}
			else
			{
				if (roleCostAttrRecommendInfo == null)
				{
					return null;
				}
				return roleCostAttrRecommendInfo.GetOfficialSubAttrRecommendInfo();
			}
		}
		else
		{
			Dictionary<int, VisionAttrRecommendInfo> roleAllAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleAllAttrRecommendInfo(this.CurrentRoleId);
			if (roleAllAttrRecommendInfo == null)
			{
				return null;
			}
			foreach (KeyValuePair<int, VisionAttrRecommendInfo> keyValuePair in roleAllAttrRecommendInfo)
			{
				List<AttrRecommendInfo> list = this.IsOfficialPlan ? keyValuePair.Value.GetOfficialSubAttrRecommendInfo() : keyValuePair.Value.GetUsageSubAttrRecommendInfo();
				if (list.Count > 0)
				{
					return list;
				}
			}
			return null;
		}
	}

	// Token: 0x06012673 RID: 75379 RVA: 0x0050FC9C File Offset: 0x0050DE9C
	private void RefreshSubAttrRecommend()
	{
		List<AttrRecommendInfo> subAttrData = this.GetSubAttrData();
		if (subAttrData == null || subAttrData.Count == 0)
		{
			this.CurrentShowSubAttrArray.Clear();
			SubRecommendAttr subRecommendAttr = this.SubRecommendAttr;
			if (subRecommendAttr == null)
			{
				return;
			}
			subRecommendAttr.Refresh(this.CurrentShowSubAttrArray);
			return;
		}
		else
		{
			this.CurrentShowSubAttrArray.Clear();
			foreach (AttrRecommendInfo attrRecommendInfo in subAttrData)
			{
				RecommendItemData recommendItemData = new RecommendItemData();
				recommendItemData.AttrId = attrRecommendInfo.GetAttrId();
				recommendItemData.AddType = attrRecommendInfo.GetAddType();
				recommendItemData.CurrentSelectArray = this.CurrentSelectSubAttrArray;
				recommendItemData.UsageText = attrRecommendInfo.GetUsageText();
				recommendItemData.Type = 2;
				recommendItemData.OnSelectCallBack = new Action<RecommendItemData>(this.OnSelectAttr);
				this.CurrentShowSubAttrArray.Add(recommendItemData);
			}
			SubRecommendAttr subRecommendAttr2 = this.SubRecommendAttr;
			if (subRecommendAttr2 == null)
			{
				return;
			}
			subRecommendAttr2.Refresh(this.CurrentShowSubAttrArray);
			return;
		}
	}

	// Token: 0x06012674 RID: 75380 RVA: 0x0050FD94 File Offset: 0x0050DF94
	private void RefreshCostDistribution()
	{
		int firstCost = this.DetermineFirstVisionCost();
		UUIText text = base.GetText(8);
		if (text != null)
		{
			text.SetText(firstCost.ToString(), true);
		}
		List<int> data = this.DetermineOtherVisionCosts(firstCost);
		GenericLayout<CostDistributionItem, int> otherCostLayout = this.OtherCostLayout;
		if (otherCostLayout == null)
		{
			return;
		}
		otherCostLayout.RefreshByData(data, null, false);
	}

	// Token: 0x06012675 RID: 75381 RVA: 0x0050FDDD File Offset: 0x0050DFDD
	private CostDistributionItem InitCostDistributionItem()
	{
		return new CostDistributionItem();
	}

	// Token: 0x06012676 RID: 75382 RVA: 0x0050FDE4 File Offset: 0x0050DFE4
	private int DetermineFirstVisionCost()
	{
		if (this.CurrentSelectMainPhantom != null)
		{
			return this.GetCostByMonsterId(this.CurrentSelectMainPhantom.MonsterId);
		}
		PhantomRoleEquipmentData battleDataById = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(this.CurrentRoleId);
		if (battleDataById != null)
		{
			List<int> incrIdList = battleDataById.GetIncrIdList();
			if (incrIdList.Count > 0 && incrIdList[0] != 0)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incrIdList[0]);
				if (phantomBattleData != null)
				{
					int monsterId = phantomBattleData.GetMonsterId(false);
					int fetterGroupId = phantomBattleData.GetFetterGroupId();
					foreach (IMainPhantomItemData mainPhantomItemData in this.CurrentShowMainPhantomArray)
					{
						if (mainPhantomItemData.Info.GetMonsterId() == monsterId && mainPhantomItemData.Info.GetFetterGroupId() == fetterGroupId)
						{
							return phantomBattleData.GetCost();
						}
					}
				}
			}
		}
		VisionFetterRecommendInfo currentPlanInfo = this.CurrentPlanInfo;
		List<MainPhantomRecommendInfo> list = ((currentPlanInfo != null) ? currentPlanInfo.GetMainPhantomList() : null) ?? new List<MainPhantomRecommendInfo>();
		if (list.Count > 0)
		{
			MainPhantomRecommendInfo mainPhantomRecommendInfo = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].GetUsage() > mainPhantomRecommendInfo.GetUsage())
				{
					mainPhantomRecommendInfo = list[i];
				}
			}
			return this.GetCostByMonsterId(mainPhantomRecommendInfo.GetMonsterId());
		}
		return 0;
	}

	// Token: 0x06012677 RID: 75383 RVA: 0x0050FF4C File Offset: 0x0050E14C
	private List<int> DetermineOtherVisionCosts(int firstCost)
	{
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		int visionRecommendRuleLevel = ConfigBase<PhantomBattleConfig>.Instance.GetVisionRecommendRuleLevel();
		if (calabashLevel < 2)
		{
			if (firstCost != 1)
			{
				return new List<int>
				{
					1,
					1,
					1,
					1
				};
			}
			return new List<int>
			{
				PhantomBattleDefine.costListRecommendLowLevel[0],
				1,
				1,
				1
			};
		}
		else
		{
			if (calabashLevel < visionRecommendRuleLevel)
			{
				List<int> list = new List<int>(PhantomBattleDefine.costListRecommendLowLevel);
				int num = list.IndexOf(firstCost);
				if (num >= 0)
				{
					list.RemoveAt(num);
				}
				else
				{
					list.RemoveAt(list.Count - 1);
				}
				list.Sort((int a, int b) => b - a);
				return list;
			}
			return this.GetHighLevelOtherCosts(firstCost);
		}
	}

	// Token: 0x06012678 RID: 75384 RVA: 0x00510024 File Offset: 0x0050E224
	private List<int> GetHighLevelOtherCosts(int firstCost)
	{
		if (this.CurrentPlanInfo == null)
		{
			return new List<int>();
		}
		List<ICostCombinationData> costCombinations = this.CurrentPlanInfo.GetCostCombinations();
		if (costCombinations.Count == 0)
		{
			return new List<int>();
		}
		int num = -1;
		List<int> result = new List<int>();
		foreach (ICostCombinationData costCombinationData in costCombinations)
		{
			int num2 = costCombinationData.Costs.IndexOf(firstCost);
			if (num2 >= 0 && costCombinationData.Usage > num)
			{
				num = costCombinationData.Usage;
				List<int> list = new List<int>(costCombinationData.Costs);
				list.RemoveAt(num2);
				result = list;
			}
		}
		return result;
	}

	// Token: 0x06012679 RID: 75385 RVA: 0x005100D8 File Offset: 0x0050E2D8
	private int GetCostByMonsterId(int monsterId)
	{
		IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId);
		if (phantomItemByMonsterId != null && phantomItemByMonsterId.Count > 0)
		{
			PhantomRarity? phantomRareConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(phantomItemByMonsterId[0].Rarity);
			if (phantomRareConfig != null)
			{
				return phantomRareConfig.Value.Cost;
			}
		}
		return 0;
	}

	// Token: 0x0601267A RID: 75386 RVA: 0x00510134 File Offset: 0x0050E334
	private void OnSelectMainAttr(IMainPhantomItemData data)
	{
		if (this.CurrentSelectMainPhantom != null && data.Info.GetMonsterId() == this.CurrentSelectMainPhantom.MonsterId && data.Info.GetFetterGroupId() == this.CurrentSelectMainPhantom.FetterGroupId)
		{
			this.NotifyMainPhantomFilterChanged(data, true);
			this.ClearSelectMainPhantom(true);
			return;
		}
		this.CurrentSelectMainPhantom = new VisionMainSelectPhantomData
		{
			MonsterId = data.Info.GetMonsterId(),
			FetterGroupId = data.Info.GetFetterGroupId()
		};
		this.RefreshAttrListData(this.CurrentRoleId);
		this.OnChangeCurrentSelectAttr();
		this.NotifyMainPhantomFilterChanged(data, false);
	}

	// Token: 0x0601267B RID: 75387 RVA: 0x005101D4 File Offset: 0x0050E3D4
	private void NotifyMainPhantomFilterChanged(IMainPhantomItemData data, bool isDeselect)
	{
		if (this.OnMainPhantomFilterChanged == null)
		{
			return;
		}
		int cost = 0;
		IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(data.Info.GetMonsterId());
		if (phantomItemByMonsterId != null && phantomItemByMonsterId.Count > 0)
		{
			int rarity = phantomItemByMonsterId[0].Rarity;
			PhantomRarity? phantomRareConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity);
			if (phantomRareConfig != null)
			{
				cost = phantomRareConfig.Value.Cost;
			}
		}
		this.OnMainPhantomFilterChanged(new MainPhantomFilterChangedInfo
		{
			MonsterId = data.Info.GetMonsterId(),
			FetterGroupId = data.Info.GetFetterGroupId(),
			Cost = cost,
			IsDeselect = isDeselect
		});
	}

	// Token: 0x0601267C RID: 75388 RVA: 0x00510288 File Offset: 0x0050E488
	private void OnSelectAttr(RecommendItemData data)
	{
		if (data.Type == 1)
		{
			bool flag = false;
			int index = -1;
			for (int i = 0; i < this.CurrentSelectMainAttrArray.Count; i++)
			{
				if (this.CurrentSelectMainAttrArray[i].AttrId == data.AttrId && this.CurrentSelectMainAttrArray[i].AddType == data.AddType)
				{
					flag = true;
					index = i;
					break;
				}
			}
			if (flag)
			{
				this.CurrentSelectMainAttrArray.RemoveAt(index);
			}
			else
			{
				VisionSelectRecommendData visionSelectRecommendData = new VisionSelectRecommendData();
				visionSelectRecommendData.AttrId = data.AttrId;
				visionSelectRecommendData.AddType = data.AddType;
				this.CurrentSelectMainAttrArray.Add(visionSelectRecommendData);
			}
		}
		else
		{
			bool flag2 = false;
			int index2 = -1;
			for (int j = 0; j < this.CurrentSelectSubAttrArray.Count; j++)
			{
				if (this.CurrentSelectSubAttrArray[j].AttrId == data.AttrId && this.CurrentSelectSubAttrArray[j].AddType == data.AddType)
				{
					flag2 = true;
					index2 = j;
					break;
				}
			}
			if (flag2)
			{
				this.CurrentSelectSubAttrArray.RemoveAt(index2);
			}
			else
			{
				VisionSelectRecommendData visionSelectRecommendData2 = new VisionSelectRecommendData();
				visionSelectRecommendData2.AttrId = data.AttrId;
				visionSelectRecommendData2.AddType = data.AddType;
				this.CurrentSelectSubAttrArray.Add(visionSelectRecommendData2);
			}
		}
		this.OnChangeCurrentSelectAttr();
	}

	// Token: 0x0601267D RID: 75389 RVA: 0x005103DC File Offset: 0x0050E5DC
	public void ClearSelectMainPhantom(bool bTriggerDeselectCallback = true)
	{
		bool flag = false;
		if (this.CurrentSelectMainPhantom != null)
		{
			this.CurrentSelectMainPhantom = null;
			flag = true;
		}
		this.RefreshAttrListData(this.CurrentRoleId);
		if (!flag || !bTriggerDeselectCallback)
		{
			this.OnChangeCurrentSelectAttr();
			return;
		}
		Action onDeselectMainPhantomCallback = this.OnDeselectMainPhantomCallback;
		if (onDeselectMainPhantomCallback == null)
		{
			return;
		}
		onDeselectMainPhantomCallback();
	}

	// Token: 0x0601267E RID: 75390 RVA: 0x00510424 File Offset: 0x0050E624
	protected override void OnAfterShow()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(13);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.SetScrollProgress(0f);
		}
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopPlayingSequence(false, true);
		}
		LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 == null)
		{
			return;
		}
		sequencePlayer2.PlayLevelSequenceByName("Open", false, null, false);
	}

	// Token: 0x0601267F RID: 75391 RVA: 0x0051047C File Offset: 0x0050E67C
	protected override UniTask OnBeforeHideAsync()
	{
		VisionEquipmentRecommendItem.<OnBeforeHideAsync>d__73 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<VisionEquipmentRecommendItem.<OnBeforeHideAsync>d__73>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04008F72 RID: 36722
	private const int CALABASH_LOW_LEVEL = 2;

	// Token: 0x04008F73 RID: 36723
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<int, string> costLabelTextIdMap = new Dictionary<int, string>
	{
		{
			4,
			"PhantomRecommend_4Cost"
		},
		{
			3,
			"PhantomRecommend_3Cost"
		},
		{
			1,
			"PhantomRecommend_1Cost"
		}
	};

	// Token: 0x04008F74 RID: 36724
	[Nullable(2)]
	private VisionEquipmentRecommendItemTop TopItem;

	// Token: 0x04008F75 RID: 36725
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> SystemRecommendLayout;

	// Token: 0x04008F76 RID: 36726
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRecommendFetterItem, VisionFetterRecommendInfo> UsageRecommendLayout;

	// Token: 0x04008F77 RID: 36727
	private readonly List<VisionSelectRecommendData> CurrentSelectMainAttrArray = new List<VisionSelectRecommendData>();

	// Token: 0x04008F78 RID: 36728
	private readonly List<VisionSelectRecommendData> CurrentSelectSubAttrArray = new List<VisionSelectRecommendData>();

	// Token: 0x04008F79 RID: 36729
	[Nullable(2)]
	private VisionMainSelectPhantomData CurrentSelectMainPhantom;

	// Token: 0x04008F7A RID: 36730
	private readonly List<RecommendItemData> CurrentShowMainAttrArray = new List<RecommendItemData>();

	// Token: 0x04008F7B RID: 36731
	private readonly List<RecommendItemData> CurrentShowSubAttrArray = new List<RecommendItemData>();

	// Token: 0x04008F7C RID: 36732
	private readonly List<IMainPhantomItemData> CurrentShowMainPhantomArray = new List<IMainPhantomItemData>();

	// Token: 0x04008F7D RID: 36733
	[Nullable(2)]
	private MainRecommendPhantom MainPhantomRecommendItem;

	// Token: 0x04008F7E RID: 36734
	[Nullable(2)]
	private MainRecommendAttr MainRecommendAttr;

	// Token: 0x04008F7F RID: 36735
	[Nullable(2)]
	private SubRecommendAttr SubRecommendAttr;

	// Token: 0x04008F80 RID: 36736
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CostDistributionItem, int> OtherCostLayout;

	// Token: 0x04008F81 RID: 36737
	private int TabCost;

	// Token: 0x04008F82 RID: 36738
	private int CurrentCost;

	// Token: 0x04008F83 RID: 36739
	private int CurrentRoleId;

	// Token: 0x04008F84 RID: 36740
	[Nullable(2)]
	public VisionFetterRecommendInfo CurrentPlanInfo;

	// Token: 0x04008F85 RID: 36741
	private bool IsOfficialPlan;

	// Token: 0x04008F86 RID: 36742
	[Nullable(2)]
	private Action OnChangeAttrCallBack;

	// Token: 0x04008F87 RID: 36743
	[Nullable(2)]
	public Action OnDeselectMainPhantomCallback;

	// Token: 0x04008F88 RID: 36744
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IMainPhantomFilterChangedInfo> OnMainPhantomFilterChanged;

	// Token: 0x04008F89 RID: 36745
	[Nullable(2)]
	public Action<VisionFetterRecommendInfo> OnPlanChangedCallback;

	// Token: 0x04008F8A RID: 36746
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<List<int>, bool> OnSelectAllCallback;

	// Token: 0x04008F8B RID: 36747
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0200881B RID: 34843
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF8C RID: 188300
		SystemRecommendLayout,
		// Token: 0x0402DF8D RID: 188301
		SystemRecommendItem,
		// Token: 0x0402DF8E RID: 188302
		UsageRecommendLayout,
		// Token: 0x0402DF8F RID: 188303
		UsageRecommendItem,
		// Token: 0x0402DF90 RID: 188304
		TogTop,
		// Token: 0x0402DF91 RID: 188305
		PnlFirstVision,
		// Token: 0x0402DF92 RID: 188306
		PnlMainAttr,
		// Token: 0x0402DF93 RID: 188307
		PnlSubAttr,
		// Token: 0x0402DF94 RID: 188308
		TextFirstVisionCost,
		// Token: 0x0402DF95 RID: 188309
		OtherVisionCostLayout,
		// Token: 0x0402DF96 RID: 188310
		OtherVisionCostItem,
		// Token: 0x0402DF97 RID: 188311
		PnlSystemRecommend,
		// Token: 0x0402DF98 RID: 188312
		PnlUsageRecommend,
		// Token: 0x0402DF99 RID: 188313
		Scroll
	}
}
