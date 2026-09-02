using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x020022BC RID: 8892
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MotorcycleDevelopModel : ModelBase<MotorcycleDevelopModel>
{
	// Token: 0x06010CBB RID: 68795 RVA: 0x004981C0 File Offset: 0x004963C0
	public void UpdateMotorInfo(MotorPb data)
	{
		this.CurLevel = data.MotorLevel;
		this.CurExp = data.MotorExp;
		this.CurRewardedMaxLv = data.MotorRewardedLvMax;
		this.DailyLimitExp = data.MotorExpLimitGainDaily;
		this.DailyLimitMaxExp = data.MotorExpMonsterDropDailyLimit;
		this.CurTreeType = data.TreeInUse;
		this.IsFirstDailyExpLimit = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.MotorDevelopIsFirstDailyExpLimit, false);
		if (this.LastLevel == -1)
		{
			this.LastLevel = this.CurLevel;
		}
		if (this.LastExp == -1)
		{
			this.LastExp = this.CurExp;
		}
		this.UpdateTechTree(data.UnlockedTree.ToArray<MotorTechOneTreePb>());
		this.UpdateAllTreeTask(data.TaskTrees.ToArray<MotorTaskTreePb>());
		this.UpdateMotorLevelEffect();
	}

	// Token: 0x06010CBC RID: 68796 RVA: 0x00498278 File Offset: 0x00496478
	protected override bool OnClear()
	{
		this.RemoveSwitchTechTreeLockTimer();
		return true;
	}

	// Token: 0x06010CBD RID: 68797 RVA: 0x00498284 File Offset: 0x00496484
	public List<UiDynamicTab> GetMotorTabList()
	{
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.MotorcycleRootView);
		int count = viewTabList.Count;
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		for (int i = 0; i < count; i++)
		{
			UiDynamicTab item = viewTabList[i];
			if (ModelBase<FunctionModel>.Instance.IsOpen(item.FunctionId))
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06010CBE RID: 68798 RVA: 0x004982E4 File Offset: 0x004964E4
	public int GetLastLevel()
	{
		return this.LastLevel;
	}

	// Token: 0x06010CBF RID: 68799 RVA: 0x004982EC File Offset: 0x004964EC
	public int GetLastExp()
	{
		return this.LastExp;
	}

	// Token: 0x06010CC0 RID: 68800 RVA: 0x004982F4 File Offset: 0x004964F4
	public int GetCurLevel()
	{
		return this.CurLevel;
	}

	// Token: 0x06010CC1 RID: 68801 RVA: 0x004982FC File Offset: 0x004964FC
	public int GetCurExp()
	{
		return this.CurExp;
	}

	// Token: 0x06010CC2 RID: 68802 RVA: 0x00498304 File Offset: 0x00496504
	public int GetCurRewardedMaxLv()
	{
		return this.CurRewardedMaxLv;
	}

	// Token: 0x06010CC3 RID: 68803 RVA: 0x0049830C File Offset: 0x0049650C
	public float GetAttrValueByType(int attrType, int level)
	{
		float result = 0f;
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		MotorLvl? motorLevelConfig = ConfigBase<MotorConfig>.Instance.GetMotorLevelConfig(level);
		if (motorLevelConfig != null)
		{
			int? worldLv2Attack = motorLevelConfig.Value.GetWorldLv2Attack(curWorldLevel);
			int? worldLv2MotorShield = motorLevelConfig.Value.GetWorldLv2MotorShield(curWorldLevel);
			switch (attrType)
			{
			case 1:
				result = (float)motorLevelConfig.Value.Speed;
				break;
			case 2:
				result = (float)motorLevelConfig.Value.NitrogenValue;
				break;
			case 3:
				result = (float)((worldLv2Attack != null) ? worldLv2Attack.Value : 0);
				break;
			case 4:
				result = (float)((worldLv2MotorShield != null) ? worldLv2MotorShield.Value : 0);
				break;
			case 5:
				result = (float)motorLevelConfig.Value.NitrogenSpeedValue;
				break;
			case 6:
				result = (float)motorLevelConfig.Value.NitrogenConsumeRate;
				break;
			case 7:
				result = (float)motorLevelConfig.Value.NitrogenRecoverRate;
				break;
			case 8:
				result = motorLevelConfig.Value.NitrogenRecoverCoolDown;
				break;
			case 9:
				result = (float)motorLevelConfig.Value.MotorInitialShieldRate;
				break;
			case 10:
				result = (float)motorLevelConfig.Value.MotorShieldRecoverRate;
				break;
			case 11:
				result = motorLevelConfig.Value.MotorShieldCoolDown;
				break;
			case 12:
				result = (float)motorLevelConfig.Value.SoaringEnergy;
				break;
			}
		}
		return result;
	}

	// Token: 0x06010CC4 RID: 68804 RVA: 0x004984A8 File Offset: 0x004966A8
	public int GetNextLevelExp()
	{
		IReadOnlyList<MotorLvl> allMotorLevelList = ConfigBase<MotorConfig>.Instance.GetAllMotorLevelList();
		int level = Math.Min(this.CurLevel + 1, allMotorLevelList.Count);
		int result = 0;
		MotorLvl? motorLevelConfig = ConfigBase<MotorConfig>.Instance.GetMotorLevelConfig(level);
		if (motorLevelConfig != null)
		{
			result = motorLevelConfig.Value.Exp;
		}
		return result;
	}

	// Token: 0x06010CC5 RID: 68805 RVA: 0x00498500 File Offset: 0x00496700
	public List<TItem> GetPreviewRewardByLevel(int level)
	{
		List<TItem> list = new List<TItem>();
		MotorLvl? motorLevelConfig = ConfigBase<MotorConfig>.Instance.GetMotorLevelConfig(level);
		if (motorLevelConfig != null)
		{
			list = this.GetPreviewReward(motorLevelConfig.Value.RewardId);
		}
		list.Sort(delegate(TItem a, TItem b)
		{
			int itemId = a.ItemData.ItemId;
			int itemId2 = b.ItemData.ItemId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId2);
			int num = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			int num2 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			if (num != num2)
			{
				return num2 - num;
			}
			return itemId - itemId2;
		});
		return list;
	}

	// Token: 0x06010CC6 RID: 68806 RVA: 0x00498564 File Offset: 0x00496764
	public List<TItem> GetAllPreviewReward()
	{
		List<TItem> list = new List<TItem>();
		IEnumerable<MotorLvl> allMotorLevelList = ConfigBase<MotorConfig>.Instance.GetAllMotorLevelList();
		Dictionary<int, TItem> dictionary = new Dictionary<int, TItem>();
		foreach (MotorLvl motorLvl in allMotorLevelList)
		{
			int rewardId = motorLvl.RewardId;
			if (rewardId != 0)
			{
				DropPackage? dropPackage;
				Dictionary<int, int> dictionary2 = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(rewardId) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
				if (dictionary2 != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair in dictionary2)
					{
						int key = keyValuePair.Key;
						int value = keyValuePair.Value;
						TItem titem;
						if (!dictionary.TryGetValue(key, out titem))
						{
							titem = new TItem
							{
								ItemData = new InventoryDefine.GetItemData(key, 0),
								Count = value
							};
							dictionary[key] = titem;
						}
						else
						{
							titem.Count += value;
							dictionary[key] = titem;
						}
					}
				}
			}
		}
		foreach (KeyValuePair<int, TItem> keyValuePair2 in dictionary)
		{
			list.Add(keyValuePair2.Value);
		}
		list.Sort(delegate(TItem a, TItem b)
		{
			int itemId = a.ItemData.ItemId;
			int itemId2 = b.ItemData.ItemId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId2);
			int num = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			int num2 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			if (num != num2)
			{
				return num2 - num;
			}
			return itemId - itemId2;
		});
		return list;
	}

	// Token: 0x06010CC7 RID: 68807 RVA: 0x00498710 File Offset: 0x00496910
	public List<TItem> GetPreviewReward(int dropId)
	{
		List<TItem> list = new List<TItem>();
		if (dropId == 0)
		{
			return list;
		}
		DropPackage? dropPackage;
		Dictionary<int, int> dictionary = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
		if (dictionary == null)
		{
			return list;
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			TItem item = new TItem
			{
				ItemData = new InventoryDefine.GetItemData(key, 0),
				Count = value
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06010CC8 RID: 68808 RVA: 0x004987D0 File Offset: 0x004969D0
	public bool IsDailyExpToLimit()
	{
		return this.DailyLimitMaxExp > 0 && this.DailyLimitExp >= this.DailyLimitMaxExp;
	}

	// Token: 0x06010CC9 RID: 68809 RVA: 0x004987EE File Offset: 0x004969EE
	public void UpdateMotorExpAndLevel(MotorExpAddNotify data)
	{
		this.CurExp = data.CurExp;
		this.CurLevel = data.CurLevel;
		this.DailyLimitExp = data.MotorExpLimitGainDaily;
		this.DailyLimitMaxExp = data.MotorExpMonsterDropDailyLimit;
		this.UpdateMotorLevelEffect();
	}

	// Token: 0x06010CCA RID: 68810 RVA: 0x00498826 File Offset: 0x00496A26
	public void UpdateMotorRewardedMaxLevel(MotorLevelOneKeyRewardResponse data)
	{
		this.CurRewardedMaxLv = data.MotorRewardedLvMax;
	}

	// Token: 0x06010CCB RID: 68811 RVA: 0x00498834 File Offset: 0x00496A34
	public void CheckMotorExpChange()
	{
		if (this.LastLevel < this.CurLevel)
		{
			this.SetLevelUp(this.LastLevel, this.CurLevel, this.CurExp, this.LastExp);
			this.LastLevel = this.CurLevel;
		}
		this.LastExp = this.CurExp;
		if (this.DailyLimitExp == 0)
		{
			this.IsFirstDailyExpLimit = false;
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.MotorDevelopIsFirstDailyExpLimit, false);
		}
		if (this.IsDailyExpToLimit() && !this.IsFirstDailyExpLimit)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorBike_ExpLimit_Tips", Array.Empty<object>());
			this.IsFirstDailyExpLimit = true;
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.MotorDevelopIsFirstDailyExpLimit, true);
		}
	}

	// Token: 0x06010CCC RID: 68812 RVA: 0x004988D8 File Offset: 0x00496AD8
	public void SetExpChange(int currentLevel, int currentExp, int lastExp, int maxExp, int differenceExp)
	{
		LevelUpViewViedData data = new LevelUpViewViedData
		{
			AddExp = true,
			PreLevel = currentLevel,
			PreExp = lastExp,
			CurLevel = currentLevel,
			CurExp = currentExp
		};
		this.TryOpenLevelUpView(data);
	}

	// Token: 0x06010CCD RID: 68813 RVA: 0x00498918 File Offset: 0x00496B18
	public void SetLevelUp(int lastLevel, int currentLevel, int currentExp, int lastExp)
	{
		LevelUpViewViedData data = new LevelUpViewViedData
		{
			AddExp = true,
			PreLevel = lastLevel,
			PreExp = lastExp,
			CurLevel = currentLevel,
			CurExp = currentExp
		};
		this.TryOpenLevelUpView(data);
	}

	// Token: 0x06010CCE RID: 68814 RVA: 0x00498958 File Offset: 0x00496B58
	private void RefreshCacheData(ILevelUpViewViedData data)
	{
		if (this.CacheLvUpData == null)
		{
			return;
		}
		if (data.AddExp)
		{
			this.CacheLvUpData.AddExp = data.AddExp;
		}
		if (data.PreLevel < this.CacheLvUpData.PreLevel)
		{
			this.CacheLvUpData.PreLevel = data.PreLevel;
			this.CacheLvUpData.PreExp = data.PreExp;
		}
		else if (data.PreLevel == this.CacheLvUpData.PreLevel && data.PreExp <= this.CacheLvUpData.PreExp)
		{
			this.CacheLvUpData.PreExp = data.PreExp;
		}
		if (data.CurLevel > this.CacheLvUpData.CurLevel)
		{
			this.CacheLvUpData.CurLevel = data.CurLevel;
			this.CacheLvUpData.CurExp = data.CurExp;
			return;
		}
		if (data.CurLevel == this.CacheLvUpData.CurLevel && data.CurExp >= this.CacheLvUpData.CurExp)
		{
			this.CacheLvUpData.CurExp = data.CurExp;
		}
	}

	// Token: 0x06010CCF RID: 68815 RVA: 0x00498A64 File Offset: 0x00496C64
	private void TryOpenLevelUpView(ILevelUpViewViedData data)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MotorcycleLevelUpView) && this.CacheLvUpData != null)
		{
			this.RefreshCacheData(data);
			return;
		}
		this.CacheLvUpData = data;
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MotorcycleLevelUpView) == null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleLevelUpView, this.CacheLvUpData, null);
		}
	}

	// Token: 0x06010CD0 RID: 68816 RVA: 0x00498AC0 File Offset: 0x00496CC0
	public ILevelUpViewViedData GetCacheData()
	{
		return this.CacheLvUpData;
	}

	// Token: 0x06010CD1 RID: 68817 RVA: 0x00498AC8 File Offset: 0x00496CC8
	public void ClearCacheData()
	{
		this.CacheLvUpData = null;
	}

	// Token: 0x06010CD2 RID: 68818 RVA: 0x00498AD4 File Offset: 0x00496CD4
	public void UpdateMotorLevelEffect()
	{
		MotorLvl? motorLevelConfig = ConfigBase<MotorConfig>.Instance.GetMotorLevelConfig(this.CurLevel);
		if (motorLevelConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.TZQ;
			string message = "无效的等级";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Level", this.CurLevel);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		ControllerBase<FormationAttributeController>.Instance.AddSpeedModifier(this.ModifierHandle, EFormationAttributeId.MotorcycleStrength, EModifierType.Override, (float)motorLevelConfig.Value.NitrogenRecoverRate, 0);
	}

	// Token: 0x06010CD3 RID: 68819 RVA: 0x00498B54 File Offset: 0x00496D54
	public bool RedDotHasLevelUpReward()
	{
		return this.CurRewardedMaxLv < this.CurLevel;
	}

	// Token: 0x06010CD4 RID: 68820 RVA: 0x00498B64 File Offset: 0x00496D64
	private void InitTechNodes()
	{
		if (this.TechNodeMap.Count > 0)
		{
			return;
		}
		foreach (int treeType in ConfigBase<MotorConfig>.Instance.GetAllMotorTreeIds())
		{
			foreach (MotorTech motorTech in ConfigBase<MotorConfig>.Instance.GetMotorTechConfigList(treeType))
			{
				MotorTechTreeNode value = new MotorTechTreeNode(motorTech.Id, motorTech.TreeType, motorTech.PreNode());
				this.TechNodeMap[motorTech.Id] = value;
			}
		}
	}

	// Token: 0x06010CD5 RID: 68821 RVA: 0x00498C0C File Offset: 0x00496E0C
	public void UpdateCurTreeType(int treeType)
	{
		this.CurTreeType = treeType;
	}

	// Token: 0x06010CD6 RID: 68822 RVA: 0x00498C15 File Offset: 0x00496E15
	public void UpdateSelectedTreeType(int treeType)
	{
		this.SelectedTreeType = treeType;
	}

	// Token: 0x06010CD7 RID: 68823 RVA: 0x00498C20 File Offset: 0x00496E20
	public void UpdateDamgeIdToSkillLevel(int nodeId, int preLevel, int newLevel)
	{
		if (preLevel == newLevel)
		{
			return;
		}
		if (preLevel > 0)
		{
			MotorEffect? motorEffect = this.GetnodeEffectConfig(nodeId, preLevel);
			if (motorEffect != null)
			{
				foreach (long key in motorEffect.Value.GetDamageIdListArray())
				{
					this.DamgeIdToSkillLevel.Remove(key);
				}
			}
		}
		if (newLevel > 0)
		{
			MotorEffect? motorEffect2 = this.GetnodeEffectConfig(nodeId, newLevel);
			if (motorEffect2 != null && motorEffect2.Value.DamageIdListLength > 0)
			{
				foreach (long num in motorEffect2.Value.GetDamageIdListArray())
				{
					if (this.DamgeIdToSkillLevel.ContainsKey(num))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Vehicle;
						ELogAuthor author = ELogAuthor.TZQ;
						string message = "重复的结算ID";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ID", num);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else
					{
						this.DamgeIdToSkillLevel[num] = motorEffect2.Value.SkillLevel;
					}
				}
			}
		}
	}

	// Token: 0x06010CD8 RID: 68824 RVA: 0x00498D30 File Offset: 0x00496F30
	public void UpdateTechNodeList(MotorTechPb[] data)
	{
		foreach (MotorTechPb motorTechPb in data)
		{
			MotorTechTreeNode motorTechTreeNode;
			if (this.TechNodeMap.TryGetValue(motorTechPb.Id, out motorTechTreeNode))
			{
				this.UpdateDamgeIdToSkillLevel(motorTechPb.Id, motorTechTreeNode.NodeLevel, motorTechPb.Level);
				motorTechTreeNode.NodeLevel = motorTechPb.Level;
				motorTechTreeNode.CurrentValue = motorTechPb.Current;
				motorTechTreeNode.TargetValue = motorTechPb.Target;
				if (motorTechPb.Unlock)
				{
					motorTechTreeNode.Status = ((motorTechPb.Level >= 1) ? EMotorTechTreeNodeStatus.Activated : EMotorTechTreeNodeStatus.CanUnlock);
				}
			}
		}
	}

	// Token: 0x06010CD9 RID: 68825 RVA: 0x00498DC0 File Offset: 0x00496FC0
	public void UpdateOneTechTree(MotorTechOneTreePb data)
	{
		RepeatedField<MotorTechPb> tech = data.Tech;
		this.InitTechNodes();
		foreach (MotorTechPb motorTechPb in tech)
		{
			MotorTechTreeNode motorTechTreeNode;
			if (this.TechNodeMap.TryGetValue(motorTechPb.Id, out motorTechTreeNode))
			{
				this.UpdateDamgeIdToSkillLevel(motorTechPb.Id, motorTechTreeNode.NodeLevel, motorTechPb.Level);
				motorTechTreeNode.NodeLevel = motorTechPb.Level;
				motorTechTreeNode.CurrentValue = motorTechPb.Current;
				motorTechTreeNode.TargetValue = motorTechPb.Target;
				if (motorTechPb.Unlock)
				{
					motorTechTreeNode.Status = ((motorTechPb.Level >= 1) ? EMotorTechTreeNodeStatus.Activated : EMotorTechTreeNodeStatus.CanUnlock);
				}
			}
		}
	}

	// Token: 0x06010CDA RID: 68826 RVA: 0x00498E78 File Offset: 0x00497078
	public void UpdateTechTree(MotorTechOneTreePb[] dataList)
	{
		foreach (MotorTechOneTreePb motorTechOneTreePb in dataList)
		{
			this.UnlockTechTree(motorTechOneTreePb.TreeId);
			this.UpdateOneTechTree(motorTechOneTreePb);
		}
	}

	// Token: 0x06010CDB RID: 68827 RVA: 0x00498EAC File Offset: 0x004970AC
	public void UpdateTechTreeNewUnlocked(int treeType, bool isNew)
	{
		ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.MotorDevelopNewUnlockTree) as ServerStorageSet;
		if (isNew)
		{
			serverStorageSet.Add(treeType);
			return;
		}
		serverStorageSet.Remove(treeType);
	}

	// Token: 0x06010CDC RID: 68828 RVA: 0x00498EE0 File Offset: 0x004970E0
	public void UnlockTechNode(int[] nodeIds)
	{
		foreach (int nodeId in nodeIds)
		{
			this.RefreshTechTreeNode(nodeId, EMotorTechTreeNodeStatus.CanUnlock);
		}
	}

	// Token: 0x06010CDD RID: 68829 RVA: 0x00498F0C File Offset: 0x0049710C
	public void UnlockTechTree(int treeType)
	{
		if (!this.UnlockTreeTypeList.Contains(treeType))
		{
			this.UnlockTreeTypeList.Add(treeType);
		}
		this.UnlockTreeTypeList.Sort(delegate(int a, int b)
		{
			MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(a);
			MotorTechTree? motorTechTreeConfig2 = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(b);
			int num = (motorTechTreeConfig != null) ? motorTechTreeConfig.Value.Order : 0;
			int num2 = (motorTechTreeConfig2 != null) ? motorTechTreeConfig2.Value.Order : 0;
			return num - num2;
		});
	}

	// Token: 0x06010CDE RID: 68830 RVA: 0x00498F60 File Offset: 0x00497160
	public int[] GetCommonTechNodeIdList(int treeType)
	{
		List<MotorTech> list = new List<MotorTech>();
		List<int> list2 = new List<int>();
		foreach (MotorTech item in ConfigBase<MotorConfig>.Instance.GetMotorTechConfigList(treeType))
		{
			if (item.Type == 0)
			{
				list.Add(item);
			}
		}
		list.Sort((MotorTech a, MotorTech b) => a.GeneralNodeSortOrder - b.GeneralNodeSortOrder);
		foreach (MotorTech motorTech in list)
		{
			list2.Add(motorTech.Id);
		}
		return list2.ToArray();
	}

	// Token: 0x06010CDF RID: 68831 RVA: 0x00499038 File Offset: 0x00497238
	public int FindTechNodeIdByCoord(int[] coord, int treeType)
	{
		int result = -1;
		foreach (MotorTech motorTech in ConfigBase<MotorConfig>.Instance.GetMotorTechConfigList(treeType))
		{
			int[] exclusiveNodeSortOrderArray = motorTech.GetExclusiveNodeSortOrderArray();
			if (coord[0] == exclusiveNodeSortOrderArray[0] && coord[1] == exclusiveNodeSortOrderArray[1])
			{
				result = motorTech.Id;
				break;
			}
		}
		return result;
	}

	// Token: 0x06010CE0 RID: 68832 RVA: 0x004990A8 File Offset: 0x004972A8
	public int? GetSkillLevelByDamageId(long damageId)
	{
		int value;
		if (!this.DamgeIdToSkillLevel.TryGetValue(damageId, out value))
		{
			return null;
		}
		return new int?(value);
	}

	// Token: 0x06010CE1 RID: 68833 RVA: 0x004990D5 File Offset: 0x004972D5
	public int GetCurTreeType()
	{
		return this.CurTreeType;
	}

	// Token: 0x06010CE2 RID: 68834 RVA: 0x004990DD File Offset: 0x004972DD
	public int GetSelectedTreeType()
	{
		return this.SelectedTreeType;
	}

	// Token: 0x06010CE3 RID: 68835 RVA: 0x004990E5 File Offset: 0x004972E5
	public List<int> GetActivatedTreeTypeList()
	{
		return this.UnlockTreeTypeList;
	}

	// Token: 0x06010CE4 RID: 68836 RVA: 0x004990F0 File Offset: 0x004972F0
	[NullableContext(2)]
	public MotorTechTreeNode GetTechNodeById(int nodeId)
	{
		MotorTechTreeNode result;
		if (!this.TechNodeMap.TryGetValue(nodeId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06010CE5 RID: 68837 RVA: 0x00499110 File Offset: 0x00497310
	public List<IMotorTechNodeListData> GetExclusiveNodeParamList(int treeType)
	{
		List<IMotorTechNodeListData> list = new List<IMotorTechNodeListData>();
		IEnumerable<MotorTech> motorTechConfigList = ConfigBase<MotorConfig>.Instance.GetMotorTechConfigList(treeType);
		List<int[]> list2 = new List<int[]>();
		foreach (MotorTech motorTech in motorTechConfigList)
		{
			if (motorTech.Type == 1)
			{
				int[] exclusiveNodeSortOrderArray = motorTech.GetExclusiveNodeSortOrderArray();
				list2.Add(exclusiveNodeSortOrderArray);
			}
		}
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		foreach (int[] array in list2)
		{
			int num = array[0];
			int item = array[1];
			if (num > 0)
			{
				List<int> list3;
				if (!dictionary.TryGetValue(num, out list3))
				{
					list3 = new List<int>();
					dictionary[num] = list3;
				}
				if (!list3.Contains(item))
				{
					list3.Add(item);
				}
				list3.Sort((int a, int b) => a - b);
			}
		}
		foreach (KeyValuePair<int, List<int>> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			List<int> value = keyValuePair.Value;
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			foreach (int num2 in value)
			{
				if (num2 > 0)
				{
					list4.Add(this.FindTechNodeIdByCoord(new int[]
					{
						key,
						num2
					}, treeType));
				}
				else if (num2 < 0)
				{
					list5.Add(this.FindTechNodeIdByCoord(new int[]
					{
						key,
						num2
					}, treeType));
				}
			}
			int[] array2 = new int[2];
			array2[0] = key;
			int middleId = this.FindTechNodeIdByCoord(array2, treeType);
			MotorTechNodeListData item2 = new MotorTechNodeListData
			{
				TopIds = list4.ToArray(),
				BottomIds = list5.ToArray(),
				MiddleId = middleId
			};
			list.Add(item2);
		}
		return list;
	}

	// Token: 0x06010CE6 RID: 68838 RVA: 0x00499348 File Offset: 0x00497548
	public void RefreshTechTreeNode(int nodeId, EMotorTechTreeNodeStatus status)
	{
		MotorTechTreeNode techNodeById = this.GetTechNodeById(nodeId);
		if (techNodeById != null)
		{
			techNodeById.Status = status;
		}
	}

	// Token: 0x06010CE7 RID: 68839 RVA: 0x00499368 File Offset: 0x00497568
	public bool IsLinkTimeNodeActivated()
	{
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("MotorTechLinkTimeNodeId").GetValueOrDefault();
		MotorTechTreeNode techNodeById = this.GetTechNodeById(valueOrDefault);
		return techNodeById != null && techNodeById.Status == EMotorTechTreeNodeStatus.Activated;
	}

	// Token: 0x06010CE8 RID: 68840 RVA: 0x004993A0 File Offset: 0x004975A0
	public bool IsPreNodeActivated(MotorTechTreeNode node)
	{
		bool result = false;
		if (node.PreNodeIds == null || node.PreNodeIds.Length == 0)
		{
			result = true;
		}
		foreach (int num in node.PreNodeIds)
		{
			if (num == 0)
			{
				result = true;
				break;
			}
			MotorTechTreeNode techNodeById = this.GetTechNodeById(num);
			if (techNodeById != null && techNodeById.Status == EMotorTechTreeNodeStatus.Activated)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06010CE9 RID: 68841 RVA: 0x00499400 File Offset: 0x00497600
	public bool IsAllNodeMaxLevel(int treeType)
	{
		foreach (MotorTechTreeNode motorTechTreeNode in this.TechNodeMap.Values)
		{
			if (motorTechTreeNode.TreeType == treeType)
			{
				MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(motorTechTreeNode.NodeId);
				if (motorTechConfig == null)
				{
					return false;
				}
				if (motorTechTreeNode.NodeLevel < motorTechConfig.Value.GetTechLvArray().Length)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06010CEA RID: 68842 RVA: 0x0049949C File Offset: 0x0049769C
	public MotorEffect? GetnodeEffectConfig(int nodeId, int nodeLevel)
	{
		MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(nodeId);
		if (motorTechConfig == null || nodeLevel <= 0)
		{
			return null;
		}
		int id = motorTechConfig.Value.GetTechLvArray()[nodeLevel - 1];
		MotorTechLv? motorTechLvConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechLvConfig(id);
		if (motorTechLvConfig == null)
		{
			return null;
		}
		return ConfigBase<MotorConfig>.Instance.GetMotorEffectConfig(motorTechLvConfig.Value.Effect);
	}

	// Token: 0x06010CEB RID: 68843 RVA: 0x0049951C File Offset: 0x0049771C
	public bool CanUpgradeNode(MotorTechTreeNode node)
	{
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(node.TreeType);
		if (motorTechTreeConfig == null)
		{
			return false;
		}
		MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(node.NodeId);
		if (motorTechConfig == null)
		{
			return false;
		}
		int num = (node.NodeLevel == motorTechConfig.Value.GetTechLvArray().Length) ? node.NodeLevel : (node.NodeLevel + 1);
		int id = motorTechConfig.Value.GetTechLvArray()[num - 1];
		MotorTechLv? motorTechLvConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechLvConfig(id);
		if (motorTechLvConfig != null)
		{
			int consume = motorTechLvConfig.Value.Consume;
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(motorTechTreeConfig.Value.TpItemId, 0) - motorTechLvConfig.Value.Consume >= 0;
		}
		return false;
	}

	// Token: 0x06010CEC RID: 68844 RVA: 0x00499600 File Offset: 0x00497800
	public bool RedDotHasAnyNewTechTree()
	{
		foreach (int treeType in this.UnlockTreeTypeList)
		{
			if (this.RedDotHasNewTechTree(treeType))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010CED RID: 68845 RVA: 0x0049965C File Offset: 0x0049785C
	public bool RedDotHasNewTechTree(int treeType)
	{
		return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.MotorDevelopNewUnlockTree) as ServerStorageSet).Has(treeType);
	}

	// Token: 0x06010CEE RID: 68846 RVA: 0x00499678 File Offset: 0x00497878
	public bool RedDotHasUpgradableTechNode(int? treeType)
	{
		foreach (MotorTechTreeNode motorTechTreeNode in this.TechNodeMap.Values)
		{
			bool flag = treeType == null || motorTechTreeNode.TreeType == treeType.Value;
			MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(motorTechTreeNode.NodeId);
			bool flag2 = motorTechTreeNode.NodeLevel >= motorTechConfig.Value.GetTechLvArray().Length;
			bool flag3 = motorTechTreeNode.Status == EMotorTechTreeNodeStatus.Lock;
			if (flag && !flag2 && !flag3 && this.CanUpgradeNode(motorTechTreeNode))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010CEF RID: 68847 RVA: 0x0049973C File Offset: 0x0049793C
	public void UpdateOneTask(MotorTaskPb data)
	{
		MotorTechTaskNode motorTechTaskNode;
		if (!this.TaskNodeMap.TryGetValue(data.Id, out motorTechTaskNode))
		{
			MotorTask? motorTaskConfig = ConfigBase<MotorConfig>.Instance.GetMotorTaskConfig(data.Id);
			motorTechTaskNode = new MotorTechTaskNode();
			motorTechTaskNode.TaskId = motorTaskConfig.Value.Id;
			motorTechTaskNode.TreeType = motorTaskConfig.Value.TreeType;
			this.TaskNodeMap[data.Id] = motorTechTaskNode;
		}
		motorTechTaskNode.StartTime = Singleton<MathUtils>.Instance.LongToNumber(data.StartTime);
		motorTechTaskNode.EndTime = Singleton<MathUtils>.Instance.LongToNumber(data.EndTime);
		motorTechTaskNode.ProcessInfo.Current = data.Process.Current;
		motorTechTaskNode.ProcessInfo.Target = data.Process.Target;
		motorTechTaskNode.RewardInfo.WaitRewardCount = data.Reward.WaitReward;
		motorTechTaskNode.RewardInfo.RewardedCount = data.Reward.Rewarded;
		motorTechTaskNode.RewardInfo.MaxRewardCount = data.Reward.MaxReward;
		switch (data.Type)
		{
		case MotorTaskTypePb.Unknown:
			motorTechTaskNode.Type = EMotorTechTaskType.Unknown;
			return;
		case MotorTaskTypePb.Single:
			motorTechTaskNode.Type = EMotorTechTaskType.OnlyOnce;
			return;
		case MotorTaskTypePb.Limited:
			motorTechTaskNode.Type = EMotorTechTaskType.Limited;
			return;
		case MotorTaskTypePb.Cycle:
			motorTechTaskNode.Type = EMotorTechTaskType.Loop;
			return;
		default:
			return;
		}
	}

	// Token: 0x06010CF0 RID: 68848 RVA: 0x00499888 File Offset: 0x00497A88
	public void UpdateOneTreeTask(MotorTaskPb[] taskList)
	{
		foreach (MotorTaskPb data in taskList)
		{
			this.UpdateOneTask(data);
		}
	}

	// Token: 0x06010CF1 RID: 68849 RVA: 0x004998B0 File Offset: 0x00497AB0
	public void UpdateAllTreeTask(MotorTaskTreePb[] dataList)
	{
		foreach (MotorTaskTreePb motorTaskTreePb in dataList)
		{
			this.TaskRewardMap[motorTaskTreePb.TreeId] = motorTaskTreePb.TpRewarded;
			this.UpdateOneTreeTask(motorTaskTreePb.Tasks.ToArray<MotorTaskPb>());
		}
	}

	// Token: 0x06010CF2 RID: 68850 RVA: 0x004998FC File Offset: 0x00497AFC
	[NullableContext(2)]
	public MotorTechTaskNode GetTaskNodeInfo(int taskId)
	{
		MotorTechTaskNode result;
		if (!this.TaskNodeMap.TryGetValue(taskId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06010CF3 RID: 68851 RVA: 0x0049991C File Offset: 0x00497B1C
	public List<MotorTechTaskNode> GetTaskListByTree(int treeType)
	{
		List<MotorTechTaskNode> list = new List<MotorTechTaskNode>();
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		foreach (KeyValuePair<int, MotorTechTaskNode> keyValuePair in this.TaskNodeMap)
		{
			MotorTechTaskNode value = keyValuePair.Value;
			if (value.TreeType == treeType)
			{
				if (value.Type == EMotorTechTaskType.Limited)
				{
					if ((double)value.StartTime < serverTime && (double)value.EndTime > serverTime)
					{
						list.Add(value);
					}
				}
				else if (value.Type == EMotorTechTaskType.Loop)
				{
					if (value.RewardInfo.MaxRewardCount != 0 && value.RewardInfo.MaxRewardCount != -1)
					{
						list.Add(value);
					}
				}
				else
				{
					list.Add(value);
				}
			}
		}
		list.Sort(delegate(MotorTechTaskNode a, MotorTechTaskNode b)
		{
			int waitRewardCount = a.RewardInfo.WaitRewardCount;
			int waitRewardCount2 = b.RewardInfo.WaitRewardCount;
			if (waitRewardCount != waitRewardCount2)
			{
				return waitRewardCount2 - waitRewardCount;
			}
			int maxRewardCount = a.RewardInfo.MaxRewardCount;
			int maxRewardCount2 = b.RewardInfo.MaxRewardCount;
			int rewardedCount = a.RewardInfo.RewardedCount;
			int rewardedCount2 = b.RewardInfo.RewardedCount;
			int num = (maxRewardCount > 0 && rewardedCount >= maxRewardCount) ? 0 : 1;
			int num2 = (maxRewardCount2 > 0 && rewardedCount2 >= maxRewardCount2) ? 0 : 1;
			if (num != num2)
			{
				return num2 - num;
			}
			MotorTask? motorTaskConfig = ConfigBase<MotorConfig>.Instance.GetMotorTaskConfig(a.TaskId);
			MotorTask? motorTaskConfig2 = ConfigBase<MotorConfig>.Instance.GetMotorTaskConfig(b.TaskId);
			int num3 = (motorTaskConfig != null) ? motorTaskConfig.Value.SortOrder : 0;
			int num4 = (motorTaskConfig2 != null) ? motorTaskConfig2.Value.SortOrder : 0;
			return num3 - num4;
		});
		return list;
	}

	// Token: 0x06010CF4 RID: 68852 RVA: 0x00499A18 File Offset: 0x00497C18
	public int[] GetWaitRewardTaskIds(int treeType)
	{
		List<int> list = new List<int>();
		foreach (MotorTechTaskNode motorTechTaskNode in this.GetTaskListByTree(treeType))
		{
			if (motorTechTaskNode.RewardInfo.WaitRewardCount > 0)
			{
				list.Add(motorTechTaskNode.TaskId);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06010CF5 RID: 68853 RVA: 0x00499A8C File Offset: 0x00497C8C
	public int GetCostPointByTree(int treeType)
	{
		int num = 0;
		foreach (MotorTech motorTech in ConfigBase<MotorConfig>.Instance.GetMotorTechConfigList(treeType))
		{
			MotorTechTreeNode techNodeById = this.GetTechNodeById(motorTech.Id);
			if (techNodeById != null)
			{
				for (int i = 0; i < motorTech.GetTechLvArray().Length; i++)
				{
					int id = motorTech.GetTechLvArray()[i];
					MotorTechLv? motorTechLvConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechLvConfig(id);
					if (motorTechLvConfig != null && techNodeById.NodeLevel >= i + 1)
					{
						num += motorTechLvConfig.Value.Consume;
					}
				}
			}
		}
		return num;
	}

	// Token: 0x06010CF6 RID: 68854 RVA: 0x00499B48 File Offset: 0x00497D48
	public int GetFreePointByTree(int treeType)
	{
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(treeType);
		if (motorTechTreeConfig == null)
		{
			return 0;
		}
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(motorTechTreeConfig.Value.TpItemId, 0);
	}

	// Token: 0x06010CF7 RID: 68855 RVA: 0x00499B88 File Offset: 0x00497D88
	public int GetTotalPointByTree(int treeType)
	{
		int result = 0;
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(treeType);
		if (motorTechTreeConfig != null)
		{
			result = motorTechTreeConfig.Value.TaskLimitPointNum;
		}
		return result;
	}

	// Token: 0x06010CF8 RID: 68856 RVA: 0x00499BC0 File Offset: 0x00497DC0
	public bool IsOverLimitPointNum(int treeType)
	{
		int costPointByTree = this.GetCostPointByTree(treeType);
		int freePointByTree = this.GetFreePointByTree(treeType);
		int totalPointByTree = this.GetTotalPointByTree(treeType);
		return costPointByTree + freePointByTree >= totalPointByTree;
	}

	// Token: 0x06010CF9 RID: 68857 RVA: 0x00499BEC File Offset: 0x00497DEC
	public bool RedDotCanGetAnyTaskReward()
	{
		foreach (int value in this.GetActivatedTreeTypeList())
		{
			if (this.RedDotCanGetTaskReward(new int?(value)))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010CFA RID: 68858 RVA: 0x00499C50 File Offset: 0x00497E50
	public bool RedDotCanGetTaskReward(int? treeType)
	{
		if (treeType != null && this.IsOverLimitPointNum(treeType.Value))
		{
			return false;
		}
		foreach (MotorTechTaskNode motorTechTaskNode in this.TaskNodeMap.Values)
		{
			if ((treeType == null || motorTechTaskNode.TreeType == treeType.Value) && motorTechTaskNode.RewardInfo.WaitRewardCount > 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010CFB RID: 68859 RVA: 0x00499CF0 File Offset: 0x00497EF0
	public void StartSwitchTechTreeLockTimer(int duration)
	{
		this.RemoveSwitchTechTreeLockTimer();
		this.SwitchTechTreeLockTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.RemoveSwitchTechTreeLockTimer();
		}, (float)(duration * 1000), null, null, true, 1f);
	}

	// Token: 0x06010CFC RID: 68860 RVA: 0x00499D24 File Offset: 0x00497F24
	public void RemoveSwitchTechTreeLockTimer()
	{
		if (this.SwitchTechTreeLockTimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.SwitchTechTreeLockTimerId);
			this.SwitchTechTreeLockTimerId = null;
		}
	}

	// Token: 0x06010CFD RID: 68861 RVA: 0x00499D46 File Offset: 0x00497F46
	public bool IsSwitchTechTreeTimeLocked()
	{
		return this.SwitchTechTreeLockTimerId != null;
	}

	// Token: 0x06010CFE RID: 68862 RVA: 0x00499D54 File Offset: 0x00497F54
	public bool IsSwitchTechTreePlayerLocked()
	{
		BaseTagComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionInFight_Text", Array.Empty<object>());
			return true;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.状态.空中状态"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionMidair_Text", Array.Empty<object>());
			return true;
		}
		return false;
	}

	// Token: 0x0400847E RID: 33918
	private int LastLevel = -1;

	// Token: 0x0400847F RID: 33919
	private int LastExp = -1;

	// Token: 0x04008480 RID: 33920
	private int DailyLimitExp;

	// Token: 0x04008481 RID: 33921
	private int DailyLimitMaxExp;

	// Token: 0x04008482 RID: 33922
	private bool IsFirstDailyExpLimit;

	// Token: 0x04008483 RID: 33923
	private int CurLevel = 1;

	// Token: 0x04008484 RID: 33924
	private int CurExp;

	// Token: 0x04008485 RID: 33925
	private int CurRewardedMaxLv;

	// Token: 0x04008486 RID: 33926
	[Nullable(2)]
	private ILevelUpViewViedData CacheLvUpData;

	// Token: 0x04008487 RID: 33927
	private readonly string ModifierHandle = "MotorLevel";

	// Token: 0x04008488 RID: 33928
	private int CurTreeType;

	// Token: 0x04008489 RID: 33929
	private int SelectedTreeType;

	// Token: 0x0400848A RID: 33930
	private readonly List<int> UnlockTreeTypeList = new List<int>();

	// Token: 0x0400848B RID: 33931
	public Dictionary<int, MotorTechTreeNode> TechNodeMap = new Dictionary<int, MotorTechTreeNode>();

	// Token: 0x0400848C RID: 33932
	public Dictionary<long, int> DamgeIdToSkillLevel = new Dictionary<long, int>();

	// Token: 0x0400848D RID: 33933
	private readonly Dictionary<int, int> TaskRewardMap = new Dictionary<int, int>();

	// Token: 0x0400848E RID: 33934
	private readonly Dictionary<int, MotorTechTaskNode> TaskNodeMap = new Dictionary<int, MotorTechTaskNode>();

	// Token: 0x0400848F RID: 33935
	[Nullable(2)]
	private TimerHandle SwitchTechTreeLockTimerId;
}
