using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Module.TowerDefenseEvent;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D9E RID: 19870
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBattleData : ISkillButtonUiEventInterface
	{
		// Token: 0x0603374B RID: 210763 RVA: 0x00CDEB16 File Offset: 0x00CDCD16
		public static TrapDefenseBattleData Create()
		{
			TrapDefenseBattleData trapDefenseBattleData = new TrapDefenseBattleData();
			trapDefenseBattleData.Init();
			return trapDefenseBattleData;
		}

		// Token: 0x0603374C RID: 210764 RVA: 0x00CDEB23 File Offset: 0x00CDCD23
		private void Init()
		{
		}

		// Token: 0x0603374D RID: 210765 RVA: 0x00CDEB28 File Offset: 0x00CDCD28
		private void AddTempTreeVarDelegate(ETrapDefenseSystemVarType key, TTreeVarUpdateDelegate @delegate)
		{
			HashSet<TTreeVarUpdateDelegate> hashSet;
			if (!this.TempTreeVarDelegateMap.TryGetValue(key, out hashSet))
			{
				hashSet = new HashSet<TTreeVarUpdateDelegate>();
				this.TempTreeVarDelegateMap[key] = hashSet;
			}
			hashSet.Add(@delegate);
		}

		// Token: 0x0603374E RID: 210766 RVA: 0x00CDEB60 File Offset: 0x00CDCD60
		private void RemoveTempTreeVarDelegate(ETrapDefenseSystemVarType key, TTreeVarUpdateDelegate @delegate)
		{
			HashSet<TTreeVarUpdateDelegate> hashSet;
			if (this.TempTreeVarDelegateMap.TryGetValue(key, out hashSet))
			{
				hashSet.Remove(@delegate);
			}
		}

		// Token: 0x0603374F RID: 210767 RVA: 0x00CDEB85 File Offset: 0x00CDCD85
		private void ClearTempTreeVarDelegate()
		{
			this.TempTreeVarDelegateMap.Clear();
		}

		// Token: 0x06033750 RID: 210768 RVA: 0x00CDEB92 File Offset: 0x00CDCD92
		public void Clear()
		{
			this.BehaviorTreeVarMap.Clear();
			this.TechParamMap.Clear();
			this.BattleSkillData.Clear();
			this.ClearTempTreeVarDelegate();
		}

		// Token: 0x06033751 RID: 210769 RVA: 0x00CDEBBC File Offset: 0x00CDCDBC
		public void AddTreeVarUpdateDelegate(ETrapDefenseSystemVarType key, TTreeVarUpdateDelegate @delegate)
		{
			InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
			if (instanceDungeonInfo == null || instanceDungeonInfo.Tree == null)
			{
				return;
			}
			string key2;
			if (this.BehaviorTreeVarMap.TryGetValue(key, out key2))
			{
				instanceDungeonInfo.Tree.AddTreeVarUpdateDelegate(key2, @delegate);
				return;
			}
			this.AddTempTreeVarDelegate(key, @delegate);
		}

		// Token: 0x06033752 RID: 210770 RVA: 0x00CDEC08 File Offset: 0x00CDCE08
		public void RemoveTreeVarUpdateDelegate(ETrapDefenseSystemVarType key, TTreeVarUpdateDelegate @delegate)
		{
			InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
			if (instanceDungeonInfo == null || instanceDungeonInfo.Tree == null)
			{
				return;
			}
			string key2;
			if (this.BehaviorTreeVarMap.TryGetValue(key, out key2))
			{
				instanceDungeonInfo.Tree.RemoveTreeVarUpdateDelegate(key2, @delegate);
				return;
			}
			this.RemoveTempTreeVarDelegate(key, @delegate);
		}

		// Token: 0x06033753 RID: 210771 RVA: 0x00CDEC54 File Offset: 0x00CDCE54
		public void SetBehaviorTreeVar(Dictionary<string, string> variableKeyNames)
		{
			this.BehaviorTreeVarMap.Clear();
			InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
			foreach (KeyValuePair<string, string> keyValuePair in variableKeyNames)
			{
				string text;
				string text2;
				keyValuePair.Deconstruct(out text, out text2);
				string value = text;
				string text3 = text2;
				ETrapDefenseSystemVarType key = (ETrapDefenseSystemVarType)Enum.Parse(typeof(ETrapDefenseSystemVarType), value);
				this.BehaviorTreeVarMap[key] = text3;
				HashSet<TTreeVarUpdateDelegate> hashSet;
				if (this.TempTreeVarDelegateMap.TryGetValue(key, out hashSet) && instanceDungeonInfo != null && instanceDungeonInfo.Tree != null)
				{
					foreach (TTreeVarUpdateDelegate ttreeVarUpdateDelegate in hashSet)
					{
						instanceDungeonInfo.Tree.AddTreeVarUpdateDelegate(text3, ttreeVarUpdateDelegate);
						ttreeVarUpdateDelegate(null, instanceDungeonInfo.Tree.GetTreeVarByKey(text3));
					}
					this.TempTreeVarDelegateMap.Remove(key);
				}
			}
		}

		// Token: 0x06033754 RID: 210772 RVA: 0x00CDED74 File Offset: 0x00CDCF74
		[NullableContext(2)]
		private VarDefinePb GetBehaviorTreeVar(ETrapDefenseSystemVarType key)
		{
			string key2;
			if (!this.BehaviorTreeVarMap.TryGetValue(key, out key2))
			{
				return null;
			}
			InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
			if (instanceDungeonInfo == null)
			{
				return null;
			}
			BaseBehaviorTree tree = instanceDungeonInfo.Tree;
			if (tree == null)
			{
				return null;
			}
			return tree.GetTreeVarByKey(key2);
		}

		// Token: 0x06033755 RID: 210773 RVA: 0x00CDEDB5 File Offset: 0x00CDCFB5
		public long GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType key)
		{
			VarDefinePb behaviorTreeVar = this.GetBehaviorTreeVar(key);
			if (behaviorTreeVar == null)
			{
				return 0L;
			}
			return behaviorTreeVar.Int;
		}

		// Token: 0x06033756 RID: 210774 RVA: 0x00CDEDCA File Offset: 0x00CDCFCA
		public long GetGoldNum()
		{
			return this.GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType.Gold);
		}

		// Token: 0x06033757 RID: 210775 RVA: 0x00CDEDD3 File Offset: 0x00CDCFD3
		public long GetHealth()
		{
			return this.GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType.Health);
		}

		// Token: 0x06033758 RID: 210776 RVA: 0x00CDEDDC File Offset: 0x00CDCFDC
		public int GetBatch()
		{
			return (int)this.GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType.Batch);
		}

		// Token: 0x06033759 RID: 210777 RVA: 0x00CDEDE6 File Offset: 0x00CDCFE6
		public long GetMaxBatch()
		{
			return this.GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType.MaxBatch);
		}

		// Token: 0x0603375A RID: 210778 RVA: 0x00CDEDEF File Offset: 0x00CDCFEF
		public long GetTrapCount()
		{
			return this.GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType.TrapCount);
		}

		// Token: 0x0603375B RID: 210779 RVA: 0x00CDEDF8 File Offset: 0x00CDCFF8
		public long GetMaxTrapCount()
		{
			return this.GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType.MaxTrapCount);
		}

		// Token: 0x0603375C RID: 210780 RVA: 0x00CDEE04 File Offset: 0x00CDD004
		public int GetCurrentPurificationItemCount()
		{
			TrapDefenseBattleItemData itemData = ModelBase<TrapDefenseModel>.Instance.BattleInventoryData.GetItemData(1);
			if (itemData == null)
			{
				return 0;
			}
			return itemData.InventoryCount;
		}

		// Token: 0x0603375D RID: 210781 RVA: 0x00CDEE2D File Offset: 0x00CDD02D
		public int GetPurificationItemConsume()
		{
			return ControllerBase<TowerDefenseEventController>.Instance.RaycastResult.PollutedNum;
		}

		// Token: 0x1700880D RID: 34829
		// (get) Token: 0x0603375E RID: 210782 RVA: 0x00CDEE3E File Offset: 0x00CDD03E
		public bool IsPurificationItemEnough
		{
			get
			{
				return this.GetCurrentPurificationItemCount() >= this.GetPurificationItemConsume();
			}
		}

		// Token: 0x0603375F RID: 210783 RVA: 0x00CDEE54 File Offset: 0x00CDD054
		public void SetTechParamMapVar(Dictionary<int, int> techParamMap)
		{
			if (techParamMap == null)
			{
				return;
			}
			this.TechParamMap.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in techParamMap)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int key = num;
				int num3 = num2;
				this.TechParamMap[(TrapDefenseParamType)key] = (float)num3;
			}
		}

		// Token: 0x06033760 RID: 210784 RVA: 0x00CDEECC File Offset: 0x00CDD0CC
		public float GetSlotCount()
		{
			float result;
			if (!this.TechParamMap.TryGetValue(TrapDefenseParamType.SlotCount, out result))
			{
				return 0f;
			}
			return result;
		}

		// Token: 0x06033761 RID: 210785 RVA: 0x00CDEEF0 File Offset: 0x00CDD0F0
		public float GetAuxiliaryLimit()
		{
			float result;
			if (!this.TechParamMap.TryGetValue(TrapDefenseParamType.AuxiliaryCount, out result))
			{
				return 1f;
			}
			return result;
		}

		// Token: 0x1700880E RID: 34830
		// (get) Token: 0x06033762 RID: 210786 RVA: 0x00CDEF14 File Offset: 0x00CDD114
		public bool IsCanBuildMachine
		{
			get
			{
				TrapDefenseWave? currentBatchData = ModelBase<TrapDefenseModel>.Instance.GetCurrentBatchData();
				if (currentBatchData == null)
				{
					return false;
				}
				bool flag = ControllerBase<TowerDefenseEventController>.Instance.IsInPreview();
				return currentBatchData.Value.CanBuildMachine && flag;
			}
		}

		// Token: 0x06033763 RID: 210787 RVA: 0x00CDEF53 File Offset: 0x00CDD153
		public void SetShopOpen(bool isOpen)
		{
			this.IsShopOpen = isOpen;
		}

		// Token: 0x06033764 RID: 210788 RVA: 0x00CDEF5C File Offset: 0x00CDD15C
		public void SetPreviewCountDown(float countDown)
		{
			this.PreviewCountDown = countDown;
		}

		// Token: 0x06033765 RID: 210789 RVA: 0x00CDEF65 File Offset: 0x00CDD165
		public void SetComboNum(int num)
		{
			this.ComboNum = num;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.TrapDefenseComboNumChange, num);
		}

		// Token: 0x06033766 RID: 210790 RVA: 0x00CDEF7F File Offset: 0x00CDD17F
		public void SetSpecialShow(bool isShow)
		{
			this.IsSpecialShow = isShow;
		}

		// Token: 0x06033767 RID: 210791 RVA: 0x00CDEF88 File Offset: 0x00CDD188
		public TrapDefenseBattleSkillData GetSkillData(string actionName)
		{
			TrapDefenseBattleSkillData trapDefenseBattleSkillData;
			if (!this.BattleSkillData.TryGetValue(actionName, out trapDefenseBattleSkillData))
			{
				if (actionName == "塔防道具")
				{
					trapDefenseBattleSkillData = new TrapDefenseBattleExploreSkillData();
				}
				else
				{
					trapDefenseBattleSkillData = new TrapDefenseBattleSkillData();
				}
				trapDefenseBattleSkillData.InitData(actionName);
				this.BattleSkillData[actionName] = trapDefenseBattleSkillData;
			}
			return trapDefenseBattleSkillData;
		}

		// Token: 0x06033768 RID: 210792 RVA: 0x00CDEFD8 File Offset: 0x00CDD1D8
		public void RefreshExploreSkillData()
		{
			int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
			ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(currentExploreSkillId);
			if (exploreConfigById == null || exploreConfigById.Value.SkillType != 5)
			{
				return;
			}
			TrapDefenseBattleExploreSkillData trapDefenseBattleExploreSkillData = this.GetSkillData("塔防道具") as TrapDefenseBattleExploreSkillData;
			trapDefenseBattleExploreSkillData.SetExploreSkillId(currentExploreSkillId);
			bool flag = ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false);
			bool curInstToLevelDataHasShop = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelDataHasShop();
			trapDefenseBattleExploreSkillData.SetVisible(flag && curInstToLevelDataHasShop);
			Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonSkillIdRefresh, trapDefenseBattleExploreSkillData.GetButtonType());
		}

		// Token: 0x06033769 RID: 210793 RVA: 0x00CDF06C File Offset: 0x00CDD26C
		private void RefreshSkillCd(GroupSkillCdInfo groupSkillCdInfo)
		{
			foreach (int num in groupSkillCdInfo.SkillCdInfoMap.Keys)
			{
				foreach (TrapDefenseBattleSkillData trapDefenseBattleSkillData in this.BattleSkillData.Values)
				{
					if (trapDefenseBattleSkillData.GetSkillId() == num)
					{
						trapDefenseBattleSkillData.RefreshSkillCd();
						Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, trapDefenseBattleSkillData.GetButtonType());
					}
				}
			}
		}

		// Token: 0x0603376A RID: 210794 RVA: 0x00CDF124 File Offset: 0x00CDD324
		public void EquipExplorePhantomSkill()
		{
			this.RefreshExploreSkillData();
		}

		// Token: 0x0603376B RID: 210795 RVA: 0x00CDF12C File Offset: 0x00CDD32C
		public void SkillCountChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
			this.RefreshSkillCd(groupSkillCdInfo);
		}

		// Token: 0x0603376C RID: 210796 RVA: 0x00CDF135 File Offset: 0x00CDD335
		public void SkillRemainCdChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
			this.RefreshSkillCd(groupSkillCdInfo);
		}

		// Token: 0x0603376D RID: 210797 RVA: 0x00CDF140 File Offset: 0x00CDD340
		public int? GetExploreSkillId()
		{
			TrapDefenseBattleExploreSkillData trapDefenseBattleExploreSkillData = this.GetSkillData("塔防道具") as TrapDefenseBattleExploreSkillData;
			if (trapDefenseBattleExploreSkillData == null)
			{
				return null;
			}
			return new int?(trapDefenseBattleExploreSkillData.GetSkillId());
		}

		// Token: 0x0603376E RID: 210798 RVA: 0x00CDF175 File Offset: 0x00CDD375
		public void SetHasStartAkEvent(bool value)
		{
			this.HasStartAkEvent = value;
		}

		// Token: 0x0401DCF5 RID: 122101
		private readonly Dictionary<ETrapDefenseSystemVarType, string> BehaviorTreeVarMap = new Dictionary<ETrapDefenseSystemVarType, string>();

		// Token: 0x0401DCF6 RID: 122102
		private readonly Dictionary<ETrapDefenseSystemVarType, HashSet<TTreeVarUpdateDelegate>> TempTreeVarDelegateMap = new Dictionary<ETrapDefenseSystemVarType, HashSet<TTreeVarUpdateDelegate>>();

		// Token: 0x0401DCF7 RID: 122103
		private readonly Dictionary<TrapDefenseParamType, float> TechParamMap = new Dictionary<TrapDefenseParamType, float>();

		// Token: 0x0401DCF8 RID: 122104
		private readonly Dictionary<string, TrapDefenseBattleSkillData> BattleSkillData = new Dictionary<string, TrapDefenseBattleSkillData>();

		// Token: 0x0401DCF9 RID: 122105
		public bool IsShopOpen;

		// Token: 0x0401DCFA RID: 122106
		public bool IsSpecialShow;

		// Token: 0x0401DCFB RID: 122107
		public float PreviewCountDown;

		// Token: 0x0401DCFC RID: 122108
		public int ComboNum;

		// Token: 0x0401DCFD RID: 122109
		public bool HasStartAkEvent;
	}
}
