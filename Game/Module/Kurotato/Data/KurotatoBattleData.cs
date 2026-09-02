using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AE9 RID: 23273
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoBattleData : ISkillButtonUiEventInterface
	{
		// Token: 0x0603AD8F RID: 241039 RVA: 0x00EED5AD File Offset: 0x00EEB7AD
		public static KurotatoBattleData Create()
		{
			return new KurotatoBattleData();
		}

		// Token: 0x0603AD90 RID: 241040 RVA: 0x00EED5B4 File Offset: 0x00EEB7B4
		public void InitBattleSkillData()
		{
			KurotatoBattleSkillData kurotatoBattleSkillData = new KurotatoBattleSkillData(700105);
			kurotatoBattleSkillData.InitData("闪避");
			this.BattleSkillData["闪避"] = kurotatoBattleSkillData;
		}

		// Token: 0x0603AD91 RID: 241041 RVA: 0x00EED5E8 File Offset: 0x00EEB7E8
		[return: Nullable(2)]
		public KurotatoBattleSkillData GetBattleSkillData(string actionName)
		{
			return this.BattleSkillData.GetValueOrDefault(actionName);
		}

		// Token: 0x0603AD92 RID: 241042 RVA: 0x00EED5F8 File Offset: 0x00EEB7F8
		public void Clear()
		{
			this.BehaviorDelegate.Clear();
			this.BattleSkillData.Clear();
			if (this.NextTickTimerId != null)
			{
				TimerSystem.Instance.Remove(this.NextTickTimerId);
				this.NextTickTimerId = null;
			}
			this.SkillCdChanged.Clear();
		}

		// Token: 0x0603AD93 RID: 241043 RVA: 0x00EED646 File Offset: 0x00EEB846
		public void SkillCountChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
			this.RefreshSkillCdNextTick(groupSkillCdInfo);
		}

		// Token: 0x0603AD94 RID: 241044 RVA: 0x00EED64F File Offset: 0x00EEB84F
		public void SkillRemainCdChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
			this.RefreshSkillCdNextTick(groupSkillCdInfo);
		}

		// Token: 0x0603AD95 RID: 241045 RVA: 0x00EED658 File Offset: 0x00EEB858
		private void RefreshSkillCdNextTick(GroupSkillCdInfo groupSkillCdInfo)
		{
			foreach (int num in groupSkillCdInfo.SkillCdInfoMap.Keys)
			{
				foreach (KurotatoBattleSkillData kurotatoBattleSkillData in this.BattleSkillData.Values)
				{
					if (kurotatoBattleSkillData.GetSkillId() == num)
					{
						this.SkillCdChanged.Add(kurotatoBattleSkillData);
					}
				}
			}
			if (this.NextTickTimerId != null)
			{
				return;
			}
			this.NextTickTimerId = TimerSystem.Instance.Next(new TTimerAction(this.NextTick), null, null);
		}

		// Token: 0x0603AD96 RID: 241046 RVA: 0x00EED728 File Offset: 0x00EEB928
		private void NextTick(float delta)
		{
			this.NextTickTimerId = null;
			foreach (KurotatoBattleSkillData kurotatoBattleSkillData in this.SkillCdChanged)
			{
				kurotatoBattleSkillData.RefreshSkillCd();
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, kurotatoBattleSkillData.GetButtonType());
			}
			this.SkillCdChanged.Clear();
		}

		// Token: 0x0603AD97 RID: 241047 RVA: 0x00EED7A4 File Offset: 0x00EEB9A4
		public void SetBehaviorTreeVar(IDictionary<string, string> variableKeyNames)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> keyValuePair in variableKeyNames)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
			this.BehaviorDelegate.SetBehaviorTreeVarRelation(dictionary);
		}

		// Token: 0x0603AD98 RID: 241048 RVA: 0x00EED80C File Offset: 0x00EEBA0C
		[NullableContext(2)]
		public VarDefinePb GetBehaviorTreeVar(EKurotatoSystemVarType varType)
		{
			return this.BehaviorDelegate.GetBehaviorTreeVar(varType.ToEnumString());
		}

		// Token: 0x0603AD99 RID: 241049 RVA: 0x00EED81F File Offset: 0x00EEBA1F
		public int GetBehaviorTreeVarToNumber(EKurotatoSystemVarType varType)
		{
			return (int)this.BehaviorDelegate.GetBehaviorTreeVarToNumber(varType.ToEnumString());
		}

		// Token: 0x0603AD9A RID: 241050 RVA: 0x00EED833 File Offset: 0x00EEBA33
		public int GetCurrencyCount()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.Gold);
		}

		// Token: 0x0603AD9B RID: 241051 RVA: 0x00EED83C File Offset: 0x00EEBA3C
		public int GetRoleLevel()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.RoleLevel);
		}

		// Token: 0x0603AD9C RID: 241052 RVA: 0x00EED845 File Offset: 0x00EEBA45
		public int GetRoleExp()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.TotalRoleExp);
		}

		// Token: 0x0603AD9D RID: 241053 RVA: 0x00EED84E File Offset: 0x00EEBA4E
		public int GetBatchConfigId()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.BatchConfigId);
		}

		// Token: 0x0603AD9E RID: 241054 RVA: 0x00EED857 File Offset: 0x00EEBA57
		public int GetBatch()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.Batch);
		}

		// Token: 0x0603AD9F RID: 241055 RVA: 0x00EED860 File Offset: 0x00EEBA60
		public EKurotatoBatchType GetBatchType()
		{
			return (EKurotatoBatchType)this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.BatchType);
		}

		// Token: 0x0603ADA0 RID: 241056 RVA: 0x00EED869 File Offset: 0x00EEBA69
		public int GetMaxBatch()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.MaxBatch);
		}

		// Token: 0x0603ADA1 RID: 241057 RVA: 0x00EED872 File Offset: 0x00EEBA72
		public int GetChestCount()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.TreasureBoxCount);
		}

		// Token: 0x0603ADA2 RID: 241058 RVA: 0x00EED87C File Offset: 0x00EEBA7C
		public int GetUpgradeCount()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.UpgradeCount);
		}

		// Token: 0x0603ADA3 RID: 241059 RVA: 0x00EED886 File Offset: 0x00EEBA86
		public int GetComboKillCount()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.ConsecutiveKillCount);
		}

		// Token: 0x0603ADA4 RID: 241060 RVA: 0x00EED890 File Offset: 0x00EEBA90
		public int GetGoldGainEfficiency()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.GoldGainEfficiency);
		}

		// Token: 0x0603ADA5 RID: 241061 RVA: 0x00EED89A File Offset: 0x00EEBA9A
		public int GetSpareGold()
		{
			return this.GetBehaviorTreeVarToNumber(EKurotatoSystemVarType.SpareGold);
		}

		// Token: 0x0603ADA6 RID: 241062 RVA: 0x00EED8A4 File Offset: 0x00EEBAA4
		public int GetPlayerPropertyValue(int propId)
		{
			UKSC_AttrSet playerAttrSet = this.GetPlayerAttrSet();
			int? num;
			if (playerAttrSet == null)
			{
				num = null;
			}
			else
			{
				TMap<EKSC_AttrType, int> attrs_ = playerAttrSet.Attrs_;
				num = ((attrs_ != null) ? attrs_.GetValueOrNull((EKSC_AttrType)propId) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x0603ADA7 RID: 241063 RVA: 0x00EED8E9 File Offset: 0x00EEBAE9
		[NullableContext(2)]
		public UKSC_AttrSet GetPlayerAttrSet()
		{
			KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
			if (curSubModel == null)
			{
				return null;
			}
			AKSC_Entity kscPlayerEntity = curSubModel.KscPlayerEntity;
			if (kscPlayerEntity == null)
			{
				return null;
			}
			UKSC_SkillComp skillComp = kscPlayerEntity.GetSkillComp();
			if (skillComp == null)
			{
				return null;
			}
			return skillComp.AttrSet_;
		}

		// Token: 0x0603ADA8 RID: 241064 RVA: 0x00EED916 File Offset: 0x00EEBB16
		public bool IsPlayerPropertyLocked(int propId)
		{
			UKSC_AttrSet playerAttrSet = this.GetPlayerAttrSet();
			return playerAttrSet != null && playerAttrSet.IsAttrValueLocked((EKSC_AttrType)propId);
		}

		// Token: 0x0603ADA9 RID: 241065 RVA: 0x00EED92C File Offset: 0x00EEBB2C
		public int GetPlayerPropertyLockedValue(int propId)
		{
			UKSC_AttrSet playerAttrSet = this.GetPlayerAttrSet();
			if (playerAttrSet == null)
			{
				return 0;
			}
			int result = 0;
			playerAttrSet.GetLockedAttrValue((EKSC_AttrType)propId, ref result);
			return result;
		}

		// Token: 0x0603ADAA RID: 241066 RVA: 0x00EED954 File Offset: 0x00EEBB54
		public bool AssignAllPlayerAttrListen(FOnKSCAllAttrChange delegateFunc)
		{
			UKSC_AttrSet playerAttrSet = this.GetPlayerAttrSet();
			if (playerAttrSet == null)
			{
				return false;
			}
			playerAttrSet.AssignAllAttrListen(delegateFunc);
			return true;
		}

		// Token: 0x0603ADAB RID: 241067 RVA: 0x00EED976 File Offset: 0x00EEBB76
		public void RemoveAllPlayerAttrListen(FOnKSCAllAttrChange delegateFunc)
		{
			UKSC_AttrSet playerAttrSet = this.GetPlayerAttrSet();
			if (playerAttrSet == null)
			{
				return;
			}
			playerAttrSet.RemoveAllAttrListen(delegateFunc);
		}

		// Token: 0x040213E4 RID: 136164
		private const int DODGE_SKILL_ID = 700105;

		// Token: 0x040213E5 RID: 136165
		public BehaviorTreeUpdateDelegateProxy BehaviorDelegate = new BehaviorTreeUpdateDelegateProxy();

		// Token: 0x040213E6 RID: 136166
		private readonly Dictionary<string, KurotatoBattleSkillData> BattleSkillData = new Dictionary<string, KurotatoBattleSkillData>();

		// Token: 0x040213E7 RID: 136167
		[Nullable(2)]
		private TimerHandle NextTickTimerId;

		// Token: 0x040213E8 RID: 136168
		private readonly HashSet<KurotatoBattleSkillData> SkillCdChanged = new HashSet<KurotatoBattleSkillData>();
	}
}
