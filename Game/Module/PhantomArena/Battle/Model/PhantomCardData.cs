using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005606 RID: 22022
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomCardData
	{
		// Token: 0x1700904E RID: 36942
		// (get) Token: 0x06038258 RID: 229976 RVA: 0x00E38366 File Offset: 0x00E36566
		public bool HasActiveSkill
		{
			get
			{
				return this.ActiveSkillId > 0;
			}
		}

		// Token: 0x1700904F RID: 36943
		// (get) Token: 0x06038259 RID: 229977 RVA: 0x00E38371 File Offset: 0x00E36571
		public bool HasClickActiveSkill
		{
			get
			{
				return this.ClickActiveSkillId > 0;
			}
		}

		// Token: 0x17009050 RID: 36944
		// (get) Token: 0x0603825A RID: 229978 RVA: 0x00E3837C File Offset: 0x00E3657C
		public bool HasCountSkill
		{
			get
			{
				return this.CountSkillId > 0;
			}
		}

		// Token: 0x17009051 RID: 36945
		// (get) Token: 0x0603825B RID: 229979 RVA: 0x00E38387 File Offset: 0x00E36587
		public bool HasDurability
		{
			get
			{
				return this.Durable > 0;
			}
		}

		// Token: 0x17009052 RID: 36946
		// (get) Token: 0x0603825C RID: 229980 RVA: 0x00E38392 File Offset: 0x00E36592
		public bool InSkillCd
		{
			get
			{
				return this.SkillCd > 0;
			}
		}

		// Token: 0x17009053 RID: 36947
		// (get) Token: 0x0603825D RID: 229981 RVA: 0x00E383A0 File Offset: 0x00E365A0
		public int SkillCd
		{
			get
			{
				int result;
				if (this.AttrMap.TryGetValue(PhantomBattleCardAttr.CardSkillCd, out result))
				{
					return result;
				}
				return 0;
			}
		}

		// Token: 0x17009054 RID: 36948
		// (get) Token: 0x0603825E RID: 229982 RVA: 0x00E383C4 File Offset: 0x00E365C4
		public int SkillCdMax
		{
			get
			{
				int result;
				if (this.AttrMap.TryGetValue(PhantomBattleCardAttr.CardSkillCdmax, out result))
				{
					return result;
				}
				return 0;
			}
		}

		// Token: 0x17009055 RID: 36949
		// (get) Token: 0x0603825F RID: 229983 RVA: 0x00E383E8 File Offset: 0x00E365E8
		public int Durable
		{
			get
			{
				int result;
				if (this.AttrMap.TryGetValue(PhantomBattleCardAttr.Durable, out result))
				{
					return result;
				}
				return 0;
			}
		}

		// Token: 0x17009056 RID: 36950
		// (get) Token: 0x06038260 RID: 229984 RVA: 0x00E3840C File Offset: 0x00E3660C
		public int DurableMax
		{
			get
			{
				int result;
				if (this.AttrMap.TryGetValue(PhantomBattleCardAttr.DurableMax, out result))
				{
					return result;
				}
				return 0;
			}
		}

		// Token: 0x17009057 RID: 36951
		// (get) Token: 0x06038261 RID: 229985 RVA: 0x00E38430 File Offset: 0x00E36630
		public int CurEffectCount
		{
			get
			{
				int result;
				if (this.AttrMap.TryGetValue(PhantomBattleCardAttr.CurEffectCount, out result))
				{
					return result;
				}
				return 0;
			}
		}

		// Token: 0x17009058 RID: 36952
		// (get) Token: 0x06038262 RID: 229986 RVA: 0x00E38454 File Offset: 0x00E36654
		public int MaxEffectCount
		{
			get
			{
				int result;
				if (this.AttrMap.TryGetValue(PhantomBattleCardAttr.MaxEffectCount, out result))
				{
					return result;
				}
				return 0;
			}
		}

		// Token: 0x17009059 RID: 36953
		// (get) Token: 0x06038263 RID: 229987 RVA: 0x00E38478 File Offset: 0x00E36678
		public bool IsFourCost
		{
			get
			{
				int phantomArenaCardCoreCost = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaCardCoreCost();
				return this.ConfigCost == phantomArenaCardCoreCost;
			}
		}

		// Token: 0x1700905A RID: 36954
		// (get) Token: 0x06038264 RID: 229988 RVA: 0x00E38499 File Offset: 0x00E36699
		public bool IsField
		{
			get
			{
				return this.CardType == EPhantomArenaCardType.Field;
			}
		}

		// Token: 0x1700905B RID: 36955
		// (get) Token: 0x06038265 RID: 229989 RVA: 0x00E384A4 File Offset: 0x00E366A4
		public bool IsTool
		{
			get
			{
				return this.CardType == EPhantomArenaCardType.Tool;
			}
		}

		// Token: 0x1700905C RID: 36956
		// (get) Token: 0x06038266 RID: 229990 RVA: 0x00E384AF File Offset: 0x00E366AF
		public bool IsNormal
		{
			get
			{
				return this.CardType == EPhantomArenaCardType.Normal;
			}
		}

		// Token: 0x1700905D RID: 36957
		// (get) Token: 0x06038267 RID: 229991 RVA: 0x00E384BA File Offset: 0x00E366BA
		public bool IsNoAllowDiscard
		{
			get
			{
				return this.IsField || this.IsFourCost;
			}
		}

		// Token: 0x1700905E RID: 36958
		// (get) Token: 0x06038268 RID: 229992 RVA: 0x00E384CC File Offset: 0x00E366CC
		public bool IsInFight
		{
			get
			{
				return this.Index != -1;
			}
		}

		// Token: 0x06038269 RID: 229993 RVA: 0x00E384DA File Offset: 0x00E366DA
		public EPhantomArenaCardType GetCardType()
		{
			return this.CardType;
		}

		// Token: 0x0603826A RID: 229994 RVA: 0x00E384E4 File Offset: 0x00E366E4
		public PhantomCardData(bool isNpcCard = false)
		{
			this.IsNpcCard = isNpcCard;
		}

		// Token: 0x0603826B RID: 229995 RVA: 0x00E38538 File Offset: 0x00E36738
		public void InitData(PhantomBattleHandCardInfo dataInfo)
		{
			this.CardId = dataInfo.CardUid;
			this.ConfigId = dataInfo.CardConfId;
			this.CanUse = dataInfo.CanUse;
			this.EvolveNum = 0;
			this.Index = -1;
			this.FightId = -1;
			this.IsUnLimitEvolve = false;
			this.IsCopy = false;
			this.InitFactorsByList();
			this.RefreshHasActiveSkill();
			this.InitAttrMap();
			this.RefreshCost();
			this.RefreshCardType();
		}

		// Token: 0x0603826C RID: 229996 RVA: 0x00E385AC File Offset: 0x00E367AC
		public void InitDataByNpc(int cardId, int configId)
		{
			this.CardId = cardId;
			this.ConfigId = configId;
			this.CanUse = true;
			this.EvolveNum = 0;
			this.Index = -1;
			this.FightId = cardId;
			this.IsCopy = false;
			this.InitFactorsByList();
			this.RefreshHasActiveSkill();
			this.InitAttrMap();
			this.RefreshCost();
			this.RefreshCardType();
		}

		// Token: 0x0603826D RID: 229997 RVA: 0x00E38608 File Offset: 0x00E36808
		private void RefreshHasActiveSkill()
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.ConfigId);
			this.ActiveSkillId = phantomBattleCardConfig.ActiveSkillId;
			this.ClickActiveSkillId = phantomBattleCardConfig.DurableSkillId;
			this.CountSkillId = phantomBattleCardConfig.CountSkill;
		}

		// Token: 0x0603826E RID: 229998 RVA: 0x00E38650 File Offset: 0x00E36850
		private void InitAttrMap()
		{
			this.AttrMap.Clear();
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.ConfigId);
			int value;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(0, out value))
			{
				this.AttrMap[PhantomBattleCardAttr.AttackAbility] = value;
			}
			int value2;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(1, out value2))
			{
				this.AttrMap[PhantomBattleCardAttr.LifeAbility] = value2;
			}
			this.AttrMap[PhantomBattleCardAttr.CostAbility] = phantomBattleCardConfig.Cost;
			int value3;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(3, out value3))
			{
				this.AttrMap[PhantomBattleCardAttr.Crit] = value3;
			}
			int value4;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(4, out value4))
			{
				this.AttrMap[PhantomBattleCardAttr.CritDamage] = value4;
			}
			int value5;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(9, out value5))
			{
				this.AttrMap[PhantomBattleCardAttr.CardSkillCd] = value5;
			}
			int value6;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(10, out value6))
			{
				this.AttrMap[PhantomBattleCardAttr.CardSkillCdmax] = value6;
			}
			int value7;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(11, out value7))
			{
				this.AttrMap[PhantomBattleCardAttr.Durable] = value7;
			}
			int value8;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(12, out value8))
			{
				this.AttrMap[PhantomBattleCardAttr.DurableMax] = value8;
			}
			int value9;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(13, out value9))
			{
				this.AttrMap[PhantomBattleCardAttr.CurEffectCount] = value9;
			}
			int value10;
			if (phantomBattleCardConfig.InitAttack().TryGetValue(14, out value10))
			{
				this.AttrMap[PhantomBattleCardAttr.MaxEffectCount] = value10;
			}
		}

		// Token: 0x0603826F RID: 229999 RVA: 0x00E387CC File Offset: 0x00E369CC
		private void RefreshCost()
		{
			this.ConfigCost = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.ConfigId).Cost;
			this.UseCost = (this.IsFourCost ? 0 : this.ConfigCost);
		}

		// Token: 0x06038270 RID: 230000 RVA: 0x00E38810 File Offset: 0x00E36A10
		private void RefreshCardType()
		{
			this.CardType = (EPhantomArenaCardType)ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.ConfigId).Type;
		}

		// Token: 0x06038271 RID: 230001 RVA: 0x00E3883C File Offset: 0x00E36A3C
		public void RefreshFightData(PhantomBattleFighterInfo data)
		{
			PhantomBattleCardFighterInfoCtx phantomBattleCardFighterInfoCtx = data.PhantomBattleCardFighterInfoCtx;
			this.RefreshFightAttr(phantomBattleCardFighterInfoCtx.Attrs.ToDictionary<int, int>());
			this.CardId = phantomBattleCardFighterInfoCtx.CardUid;
			this.ConfigId = phantomBattleCardFighterInfoCtx.CardConfId;
			this.Index = phantomBattleCardFighterInfoCtx.SlotIndex;
			this.FightId = data.UId;
			this.IsCopy = phantomBattleCardFighterInfoCtx.IsCopy;
			this.RefreshFactorsByList(phantomBattleCardFighterInfoCtx.Factors.ToList<int>(), phantomBattleCardFighterInfoCtx.LockFactors.ToList<int>());
			this.RefreshHasActiveSkill();
			this.CanUse = true;
			this.EvolveNum = phantomBattleCardFighterInfoCtx.EvolveCount;
			this.IsUnLimitEvolve = phantomBattleCardFighterInfoCtx.CanUnlimitedEvolve;
			this.RefreshCost();
			this.RefreshCardType();
			this.SkillData.RefreshData(phantomBattleCardFighterInfoCtx.SkillUnlockInfo);
		}

		// Token: 0x06038272 RID: 230002 RVA: 0x00E388FC File Offset: 0x00E36AFC
		public void RefreshFightAttr(Dictionary<int, int> battleAttrMap)
		{
			this.LastEffectCount = this.CurEffectCount;
			this.AttrMap.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in battleAttrMap)
			{
				PhantomBattleCardAttr key = (PhantomBattleCardAttr)keyValuePair.Key;
				this.AttrMap[key] = keyValuePair.Value;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PhantomArenaCardAttrRefresh, this.CardId);
		}

		// Token: 0x06038273 RID: 230003 RVA: 0x00E3898C File Offset: 0x00E36B8C
		private void InitFactorsByList()
		{
			this.ExtraFactors.Clear();
			this.UnActiveFactors = new List<int>(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.ConfigId).GetCardFactorIdBytes().ToArray());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PhantomArenaCardFactorsRefresh, this.CardId);
		}

		// Token: 0x06038274 RID: 230004 RVA: 0x00E389E8 File Offset: 0x00E36BE8
		private void RefreshFactorsByList(List<int> factors, List<int> unActiveFactors)
		{
			this.ExtraFactors.Clear();
			this.UnActiveFactors.Clear();
			foreach (int item in factors)
			{
				this.ExtraFactors.Add(item);
			}
			foreach (int item2 in unActiveFactors)
			{
				this.UnActiveFactors.Add(item2);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PhantomArenaCardFactorsRefresh, this.CardId);
		}

		// Token: 0x06038275 RID: 230005 RVA: 0x00E38AAC File Offset: 0x00E36CAC
		public void NotifyRefreshCardData(Dictionary<int, int> factorMap, List<int> unActiveFactors, bool canUnlimitedEvolve)
		{
			this.ExtraFactors.Clear();
			this.UnActiveFactors.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in factorMap)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				for (int i = 0; i < value; i++)
				{
					this.ExtraFactors.Add(key);
				}
			}
			foreach (int item in unActiveFactors)
			{
				this.UnActiveFactors.Add(item);
			}
			this.IsUnLimitEvolve = canUnlimitedEvolve;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PhantomArenaCardFactorsRefresh, this.CardId);
		}

		// Token: 0x06038276 RID: 230006 RVA: 0x00E38B98 File Offset: 0x00E36D98
		public int GetFightValueByAttr(PhantomBattleCardAttr attr)
		{
			int result;
			if (this.AttrMap.TryGetValue(attr, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06038277 RID: 230007 RVA: 0x00E38BB8 File Offset: 0x00E36DB8
		public EPhantomArenaCardValueChangeType ValueChangeTypeByBuff(PhantomBattleCardAttr attr)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.ConfigId);
			int num;
			if (!this.AttrMap.TryGetValue(attr, out num))
			{
				num = 0;
			}
			int num2 = 0;
			int num3;
			if (attr == PhantomBattleCardAttr.CostAbility)
			{
				num2 = phantomBattleCardConfig.Cost;
			}
			else if (phantomBattleCardConfig.InitAttack().TryGetValue((int)attr, out num3))
			{
				num2 = num3;
			}
			if (num == num2)
			{
				return EPhantomArenaCardValueChangeType.None;
			}
			if (num > num2)
			{
				return EPhantomArenaCardValueChangeType.Add;
			}
			return EPhantomArenaCardValueChangeType.Subtract;
		}

		// Token: 0x06038278 RID: 230008 RVA: 0x00E38C18 File Offset: 0x00E36E18
		[NullableContext(0)]
		public ValueTuple<bool, EPhantomCardSettingFailReason> IsOtherCardCanEvolve([Nullable(1)] PhantomCardData card)
		{
			if (card.IsFourCost)
			{
				return new ValueTuple<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.FourCostCantEvolve);
			}
			if (this.IsFourCost)
			{
				return new ValueTuple<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.FourCostCantBeEvolved);
			}
			if (this.IsUnLimitEvolve)
			{
				return new ValueTuple<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
			}
			if (this.CardType == EPhantomArenaCardType.Tool)
			{
				return new ValueTuple<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.ToolCantEvolve);
			}
			int configCost = card.ConfigCost;
			if (configCost == 1 && (this.EvolveNum > 0 || this.ConfigCost == 3))
			{
				return new ValueTuple<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.OneCostCantEvolveOther);
			}
			if (configCost == 3 && this.EvolveNum != 1)
			{
				return new ValueTuple<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.ThreeCostCantEvolveOther);
			}
			return new ValueTuple<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x04020142 RID: 131394
		private EPhantomArenaCardType CardType;

		// Token: 0x04020143 RID: 131395
		public bool IsNpcCard;

		// Token: 0x04020144 RID: 131396
		public int Index = -1;

		// Token: 0x04020145 RID: 131397
		public int CardId;

		// Token: 0x04020146 RID: 131398
		public int FightId = -1;

		// Token: 0x04020147 RID: 131399
		public int ConfigId;

		// Token: 0x04020148 RID: 131400
		public bool CanUse;

		// Token: 0x04020149 RID: 131401
		public bool IsCopy;

		// Token: 0x0402014A RID: 131402
		public int EvolveNum;

		// Token: 0x0402014B RID: 131403
		public int ConfigCost;

		// Token: 0x0402014C RID: 131404
		public int UseCost;

		// Token: 0x0402014D RID: 131405
		public List<int> ExtraFactors = new List<int>();

		// Token: 0x0402014E RID: 131406
		public List<int> UnActiveFactors = new List<int>();

		// Token: 0x0402014F RID: 131407
		public Dictionary<PhantomBattleCardAttr, int> AttrMap = new Dictionary<PhantomBattleCardAttr, int>();

		// Token: 0x04020150 RID: 131408
		public int ActiveSkillId;

		// Token: 0x04020151 RID: 131409
		public int ClickActiveSkillId;

		// Token: 0x04020152 RID: 131410
		public int CountSkillId;

		// Token: 0x04020153 RID: 131411
		public bool IsUnLimitEvolve;

		// Token: 0x04020154 RID: 131412
		public PhantomCardSkillData SkillData = new PhantomCardSkillData();

		// Token: 0x04020155 RID: 131413
		public int LastEffectCount;
	}
}
