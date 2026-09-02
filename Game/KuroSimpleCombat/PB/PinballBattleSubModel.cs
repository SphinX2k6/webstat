using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FC7 RID: 28615
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleSubModel : KscSubModelBase
	{
		// Token: 0x06045371 RID: 283505 RVA: 0x012120F8 File Offset: 0x012102F8
		protected override bool OnInit()
		{
			PinballWorldConfig? worldConfigCache = null;
			int mapId = ModelBase<GameModeModel>.Instance.MapConfig.MapId;
			if (mapId != 0)
			{
				worldConfigCache = ConfigBase<PinballBattleConfig>.Instance.GetWorldConfigByMapId(mapId);
			}
			if (worldConfigCache == null)
			{
				worldConfigCache = ConfigBase<PinballBattleConfig>.Instance.GetWorldConfig(1);
			}
			this.WorldConfigCache = worldConfigCache;
			PinballBattleHeadStateManager pinballBattleHeadStateManager = this.PinballBattleHeadStateManager;
			if (pinballBattleHeadStateManager != null)
			{
				pinballBattleHeadStateManager.Init();
			}
			return true;
		}

		// Token: 0x06045372 RID: 283506 RVA: 0x01212160 File Offset: 0x01210360
		protected override bool OnClear()
		{
			this.WorldConfigCache = null;
			this.BulletDataTable = null;
			this.ShapeWorldDa = null;
			this.ShapeWorldBoundsDa = null;
			this.ShapeMaterialDt = null;
			this.DefaultAttrs = null;
			PinballBattleHeadStateManager pinballBattleHeadStateManager = this.PinballBattleHeadStateManager;
			if (pinballBattleHeadStateManager != null)
			{
				pinballBattleHeadStateManager.Clear();
			}
			this.PinballPropertyConfigs.Clear();
			this.LoadedBuffDaMap.Clear();
			this.RoleBornBuffsMap.Clear();
			this.PinballMonsterAttrConfigs.Clear();
			this.MonsterAttrRate.Clear();
			this.RoleBaseAttrsRecord.Clear();
			this.GameState = 0;
			this.LevelId = 0;
			this.CurWave = 1;
			this.UsedReviveTime = 0;
			this.MaxReviveTime = 0;
			this.FormationData = null;
			this.Score = 0f;
			this.Combo = 0;
			this.LevelScoreTargetList.Clear();
			this.MaxScore = 0f;
			this.StarInfo = new int[3];
			this.PreloadFormationData = null;
			this.RoleTotalMap.Clear();
			this.DashTimes = 0;
			this.FullEnergyTimes = 0;
			this.AttackTimes = 0;
			this.BossSkillTimes = 0;
			this.FirstWaveMonsterTracker.Reset();
			this.CurWaveMachineTracker.Reset();
			return true;
		}

		// Token: 0x06045373 RID: 283507 RVA: 0x01212294 File Offset: 0x01210494
		public override string GetSkillDtPath()
		{
			return ((this.WorldConfigCache != null) ? this.WorldConfigCache.GetValueOrDefault().SkillDtPath : null) ?? "";
		}

		// Token: 0x06045374 RID: 283508 RVA: 0x012122CC File Offset: 0x012104CC
		public override string GetEntityDtPath()
		{
			return ((this.WorldConfigCache != null) ? this.WorldConfigCache.GetValueOrDefault().EntityDtPath : null) ?? "";
		}

		// Token: 0x06045375 RID: 283509 RVA: 0x01212304 File Offset: 0x01210504
		public string GetBulletDtPath()
		{
			return ((this.WorldConfigCache != null) ? this.WorldConfigCache.GetValueOrDefault().BulletDtPath : null) ?? "";
		}

		// Token: 0x06045376 RID: 283510 RVA: 0x0121233C File Offset: 0x0121053C
		public string GetWorldDaPath()
		{
			return ((this.WorldConfigCache != null) ? this.WorldConfigCache.GetValueOrDefault().ShapeWorldDaPath : null) ?? "";
		}

		// Token: 0x06045377 RID: 283511 RVA: 0x01212374 File Offset: 0x01210574
		public string GetWorldBoundsDaPath()
		{
			return ((this.WorldConfigCache != null) ? this.WorldConfigCache.GetValueOrDefault().ShapeWorldBoundsDaPath : null) ?? "";
		}

		// Token: 0x06045378 RID: 283512 RVA: 0x012123AC File Offset: 0x012105AC
		public string GetShapeMaterialDtPath()
		{
			return ((this.WorldConfigCache != null) ? this.WorldConfigCache.GetValueOrDefault().ShapeMaterialDtPath : null) ?? "";
		}

		// Token: 0x06045379 RID: 283513 RVA: 0x012123E4 File Offset: 0x012105E4
		[NullableContext(2)]
		public IPinballBattleCombatInfo GetEntity(int uid)
		{
			IPinballBattleCombatInfo result;
			if (!this.AllEntities.TryGetValue(uid, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0604537A RID: 283514 RVA: 0x01212404 File Offset: 0x01210604
		public void GetAllEntities(List<IPinballBattleCombatInfo> entities)
		{
			entities.Clear();
			foreach (IPinballBattleCombatInfo item in this.AllEntities.Values)
			{
				entities.Add(item);
			}
		}

		// Token: 0x0604537B RID: 283515 RVA: 0x01212464 File Offset: 0x01210664
		[return: Nullable(2)]
		public string TryAddEntity(IPinballBattleCombatInfo entityModel)
		{
			if (entityModel == null || !entityModel.IsValid())
			{
				return "实体数据无效";
			}
			int uid = entityModel.Uid;
			if (this.AllEntities.ContainsKey(uid))
			{
				return "实体数据已存在";
			}
			this.AllEntities[uid] = entityModel;
			return null;
		}

		// Token: 0x0604537C RID: 283516 RVA: 0x012124AC File Offset: 0x012106AC
		[NullableContext(2)]
		public IPinballBattleCombatInfo RemoveEntity(int uid)
		{
			IPinballBattleCombatInfo result;
			if (this.AllEntities.TryGetValue(uid, out result))
			{
				this.AllEntities.Remove(uid);
			}
			return result;
		}

		// Token: 0x0604537D RID: 283517 RVA: 0x012124D7 File Offset: 0x012106D7
		public void SetRoleId2CreatureId(int roleId, int creatureId)
		{
			this.TeamRoleId2CreatureId[roleId] = creatureId;
		}

		// Token: 0x0604537E RID: 283518 RVA: 0x012124E8 File Offset: 0x012106E8
		[NullableContext(2)]
		public KscEntityHandle GetKscEntityByRoleId(int roleId)
		{
			int num;
			if (!this.TeamRoleId2CreatureId.TryGetValue(roleId, out num))
			{
				return null;
			}
			return base.GetKscEntityHandle((long)num);
		}

		// Token: 0x0604537F RID: 283519 RVA: 0x01212510 File Offset: 0x01210710
		public int? GetRoleIdByEntityId(int entityId)
		{
			long entityCreatureId = base.GetEntityCreatureId(entityId);
			foreach (KeyValuePair<int, int> keyValuePair in this.TeamRoleId2CreatureId)
			{
				if ((long)keyValuePair.Value == entityCreatureId)
				{
					return new int?(keyValuePair.Key);
				}
			}
			return null;
		}

		// Token: 0x06045380 RID: 283520 RVA: 0x0121258C File Offset: 0x0121078C
		public int? GetRoleSlotIndex(int roleId)
		{
			if (this.FormationData == null)
			{
				return null;
			}
			for (int i = 0; i < this.FormationData.Count; i++)
			{
				if (this.FormationData[i].RoleId == roleId)
				{
					return new int?(i);
				}
			}
			return null;
		}

		// Token: 0x06045381 RID: 283521 RVA: 0x012125E8 File Offset: 0x012107E8
		public void SetFormationData(List<PinballFormationRolePb> formationData)
		{
			if (this.FormationData != null)
			{
				return;
			}
			this.FormationData = formationData;
			this.RoleTotalMap.Clear();
			foreach (PinballFormationRolePb pinballFormationRolePb in this.FormationData)
			{
				this.RoleTotalMap[pinballFormationRolePb.RoleId] = new PinballRoleTotalInfo
				{
					Damage = 0f,
					SkillTimes = 0,
					DropCostHp = 0f,
					HitCostHp = 0f,
					DieTimes = 0,
					ReviveTimes = 0
				};
			}
		}

		// Token: 0x06045382 RID: 283522 RVA: 0x0121269C File Offset: 0x0121089C
		public void SetLevelScoreTargetList(List<float> levelScoreTargetList)
		{
			this.LevelScoreTargetList.Clear();
			this.LevelScoreTargetList.AddRange(levelScoreTargetList);
			this.MaxScore = this.LevelScoreTargetList[this.LevelScoreTargetList.Count - 1];
		}

		// Token: 0x06045383 RID: 283523 RVA: 0x012126D4 File Offset: 0x012108D4
		public void SetScore(float newScore)
		{
			if (this.MaxScore > 0f && this.Score >= this.MaxScore)
			{
				return;
			}
			float num = (this.MaxScore > 0f) ? 1f : newScore;
			float num2 = (newScore < num) ? num : newScore;
			if (num2 == this.Score)
			{
				return;
			}
			if (this.MaxScore > 0f && num2 > this.MaxScore)
			{
				this.Score = this.MaxScore;
			}
			else
			{
				this.Score = num2;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPinballScoreChanged, (int)num2);
		}

		// Token: 0x06045384 RID: 283524 RVA: 0x01212765 File Offset: 0x01210965
		public void SetCombo(int newCombo)
		{
			if (newCombo == this.Combo)
			{
				return;
			}
			this.Combo = newCombo;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPinballComboChanged, newCombo);
		}

		// Token: 0x06045385 RID: 283525 RVA: 0x0121278C File Offset: 0x0121098C
		public void UpdateDamageInfo(TMap<int, int> damageInfo)
		{
			float num = 0f;
			foreach (KeyValuePair<int, int> keyValuePair in damageInfo)
			{
				int num2;
				int num3;
				keyValuePair.Deconstruct(out num2, out num3);
				int entityId = num2;
				int num4 = num3;
				int valueOrDefault = this.GetRoleIdByEntityId(entityId).GetValueOrDefault();
				if (valueOrDefault != 0)
				{
					PinballRoleTotalInfo pinballRoleTotalInfo;
					if (this.RoleTotalMap.TryGetValue(valueOrDefault, out pinballRoleTotalInfo))
					{
						pinballRoleTotalInfo.Damage = (float)num4;
					}
					num += (float)num4;
				}
			}
			float score = num * this.ScoreRatio;
			this.SetScore(score);
		}

		// Token: 0x06045386 RID: 283526 RVA: 0x01212830 File Offset: 0x01210A30
		public PinballSettlePayload GetPayloadData()
		{
			PinballSettlePayload pinballSettlePayload = PinballSettlePayload.Create();
			pinballSettlePayload.Score = (int)this.Score;
			pinballSettlePayload.DashTimes = this.DashTimes;
			pinballSettlePayload.FullEnergyTimes = this.FullEnergyTimes;
			pinballSettlePayload.AttackTimes = this.AttackTimes;
			pinballSettlePayload.BossSkillTimes = this.BossSkillTimes;
			if (this.FormationData != null)
			{
				foreach (PinballFormationRolePb pinballFormationRolePb in this.FormationData)
				{
					PinballResultRolePb pinballResultRolePb = PinballResultRolePb.Create();
					pinballResultRolePb.RoleId = pinballFormationRolePb.RoleId;
					PinballRoleTotalInfo pinballRoleTotalInfo;
					if (this.RoleTotalMap.TryGetValue(pinballFormationRolePb.RoleId, out pinballRoleTotalInfo))
					{
						pinballResultRolePb.Damage = (long)((int)pinballRoleTotalInfo.Damage);
						pinballResultRolePb.SkillTimes = pinballRoleTotalInfo.SkillTimes;
						pinballResultRolePb.DropCostHp = (long)((int)pinballRoleTotalInfo.DropCostHp);
						pinballResultRolePb.HitCostHp = (long)((int)pinballRoleTotalInfo.HitCostHp);
						pinballResultRolePb.TempDieTimes = pinballRoleTotalInfo.DieTimes;
						pinballResultRolePb.TempReviveTimes = pinballRoleTotalInfo.ReviveTimes;
					}
					pinballSettlePayload.RolePbs.Add(pinballResultRolePb);
				}
			}
			return pinballSettlePayload;
		}

		// Token: 0x06045387 RID: 283527 RVA: 0x01212958 File Offset: 0x01210B58
		public bool CheckBonusFullWin()
		{
			return this.MaxScore > 0f && this.Score >= this.MaxScore;
		}

		// Token: 0x06045388 RID: 283528 RVA: 0x0121297C File Offset: 0x01210B7C
		public void GetRoleBornAttrs(PinballFormationRolePb roleData, Dictionary<EKSC_AttrType, float> outAttrs)
		{
			PinballBattleConfig instance = ConfigBase<PinballBattleConfig>.Instance;
			if (instance.GetRoleConfig(roleData.RoleId) != null)
			{
				PinballRoleLevelConfig? roleLevelConfig = instance.GetRoleLevelConfig(roleData.LevelId);
				if (roleLevelConfig != null)
				{
					PinballAttr? attrConfig = instance.GetAttrConfig(roleLevelConfig.Value.Prop);
					if (attrConfig != null)
					{
						this.LoadAttrFromConfig(outAttrs, attrConfig.Value, false);
					}
				}
			}
			if (roleData.HasWeapon)
			{
				PinballWeaponConfig? weaponConfig = instance.GetWeaponConfig(roleData.WeaponId);
				if (weaponConfig != null)
				{
					for (int i = 0; i < weaponConfig.Value.PropListLength; i++)
					{
						int configId = weaponConfig.Value.PropList(i);
						PinballWeaponAttr? weaponAttrConfig = instance.GetWeaponAttrConfig(configId);
						if (weaponAttrConfig != null && weaponAttrConfig.Value.KscAttrType != 0)
						{
							EKSC_AttrType eksc_AttrType = (EKSC_AttrType)weaponAttrConfig.Value.KscAttrType;
							this.AddToAttrMap(outAttrs, eksc_AttrType, weaponAttrConfig.Value.ProperVal);
							if (eksc_AttrType == EKSC_AttrType.LifeMax)
							{
								this.AddToAttrMap(outAttrs, EKSC_AttrType.Life, weaponAttrConfig.Value.ProperVal);
								this.AddToAttrMap(outAttrs, EKSC_AttrType.BaseLife, weaponAttrConfig.Value.ProperVal);
							}
						}
					}
				}
			}
		}

		// Token: 0x06045389 RID: 283529 RVA: 0x01212AD0 File Offset: 0x01210CD0
		[return: Nullable(2)]
		public HashSet<int> GetRoleBornBuffs(PinballFormationRolePb roleData, bool isLeader)
		{
			PinballBattleConfig instance = ConfigBase<PinballBattleConfig>.Instance;
			PinballRoleConfig? roleConfig = instance.GetRoleConfig(roleData.RoleId);
			if (roleConfig == null)
			{
				return null;
			}
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < roleConfig.Value.BornBuffLength; i++)
			{
				int num = roleConfig.Value.BornBuff(i);
				if (num != 0)
				{
					hashSet.Add(num);
				}
			}
			if (isLeader)
			{
				for (int j = 0; j < roleConfig.Value.LeaderBuffLength; j++)
				{
					int num2 = roleConfig.Value.LeaderBuff(j);
					if (num2 != 0)
					{
						hashSet.Add(num2);
					}
				}
			}
			if (roleData.HasWeapon)
			{
				PinballWeaponConfig? weaponConfig = instance.GetWeaponConfig(roleData.WeaponId);
				if (weaponConfig != null)
				{
					PinballWeaponMainEntry? weaponMainEntryConfig = instance.GetWeaponMainEntryConfig(weaponConfig.Value.MainEntry);
					if (weaponMainEntryConfig != null && weaponMainEntryConfig.Value.Buff != 0)
					{
						hashSet.Add(weaponMainEntryConfig.Value.Buff);
					}
				}
			}
			for (int k = 0; k < roleData.RandomAffixIds.Count; k++)
			{
				int configId = roleData.RandomAffixIds[k];
				PinballWeaponSubEntry? weaponSubEntryConfig = instance.GetWeaponSubEntryConfig(configId);
				if (weaponSubEntryConfig != null && weaponSubEntryConfig.Value.Buff != 0)
				{
					hashSet.Add(weaponSubEntryConfig.Value.Buff);
				}
			}
			return hashSet;
		}

		// Token: 0x0604538A RID: 283530 RVA: 0x01212C50 File Offset: 0x01210E50
		public void GetTeamAttrs(int attrId, Dictionary<EKSC_AttrType, float> outAttrs)
		{
			PinballAttr? attrConfig = ConfigBase<PinballBattleConfig>.Instance.GetAttrConfig(attrId);
			if (attrConfig != null)
			{
				this.LoadAttrFromConfig(outAttrs, attrConfig.Value, true);
			}
		}

		// Token: 0x0604538B RID: 283531 RVA: 0x01212C84 File Offset: 0x01210E84
		public void GetCommonAttrs(Dictionary<EKSC_AttrType, float> attrMap, PinballAttr attrConfig)
		{
			attrMap[EKSC_AttrType.LifeMax] = (float)attrConfig.LifeMax;
			attrMap[EKSC_AttrType.Life] = (float)attrConfig.Life;
			attrMap[EKSC_AttrType.BaseLife] = (float)attrConfig.Life;
			attrMap[EKSC_AttrType.Atk] = (float)attrConfig.Atk;
			attrMap[EKSC_AttrType.Def] = (float)attrConfig.Def;
			attrMap[EKSC_AttrType.Crit] = (float)attrConfig.Crit;
			attrMap[EKSC_AttrType.CritDamage] = (float)attrConfig.CritDamage;
			attrMap[EKSC_AttrType.DamageChange] = (float)attrConfig.DamageChange;
			attrMap[EKSC_AttrType.DamageAmplify1] = (float)attrConfig.DamageAmplify1;
			attrMap[EKSC_AttrType.SpecialDamageChange1] = (float)attrConfig.DamageChangeAuto;
			attrMap[EKSC_AttrType.SpecialDamageChange2] = (float)attrConfig.DamageChangeStrong;
			attrMap[EKSC_AttrType.SpecialDamageChange3] = (float)attrConfig.DamageChangeSkill;
			attrMap[EKSC_AttrType.SpecialDamageChange4] = (float)attrConfig.DamageChangeSprint;
			attrMap[EKSC_AttrType.SpecialDamageChange5] = (float)attrConfig.DamageChangeSummon;
			attrMap[EKSC_AttrType.DamageReduce] = (float)attrConfig.DamageReduce;
			attrMap[EKSC_AttrType.SpecialDamageReduce1] = (float)attrConfig.DamageReduceAuto;
			attrMap[EKSC_AttrType.SpecialDamageReduce2] = (float)attrConfig.DamageReduceStrong;
			attrMap[EKSC_AttrType.SpecialDamageReduce3] = (float)attrConfig.DamageReduceSkill;
			attrMap[EKSC_AttrType.SpecialDamageReduce4] = (float)attrConfig.DamageReduceSprint;
			attrMap[EKSC_AttrType.SpecialDamageReduce5] = (float)attrConfig.DamageReduceSummon;
			attrMap[EKSC_AttrType.HealChange] = (float)attrConfig.HealEfficiency;
			attrMap[EKSC_AttrType.ShieldChange] = (float)attrConfig.ProtectEfficiency;
			attrMap[EKSC_AttrType.ShieldMax] = (float)attrConfig.ProtectMax;
		}

		// Token: 0x0604538C RID: 283532 RVA: 0x01212E1C File Offset: 0x0121101C
		private void LoadAttrFromConfig(Dictionary<EKSC_AttrType, float> attrMap, PinballAttr attrConfig, bool isTeam = false)
		{
			this.GetCommonAttrs(attrMap, attrConfig);
			if (!isTeam)
			{
				attrMap[EKSC_AttrType.SpecialEnergy1Max] = (float)attrConfig.EnergyMax;
				attrMap[EKSC_AttrType.SpecialEnergy1] = (float)attrConfig.Energy;
				attrMap[EKSC_AttrType.SpecialEnergy1RecoverSpeed] = (float)attrConfig.EnergyRecoverSpeed;
				attrMap[EKSC_AttrType.SpecialEnergy1ChargeEfficiency] = (float)attrConfig.EnergyEfficiency;
				return;
			}
			attrMap[EKSC_AttrType.SpecialEnergy2Max] = (float)attrConfig.SprintEnergyMax;
			attrMap[EKSC_AttrType.SpecialEnergy2] = (float)attrConfig.SprintEnergy;
			attrMap[EKSC_AttrType.SpecialEnergy2RecoverSpeed] = (float)attrConfig.SprintEnergyRecoverSpeed;
			attrMap[EKSC_AttrType.SpecialEnergy2ChargeEfficiency] = (float)attrConfig.SprintEnergyEfficiency;
			attrMap[EKSC_AttrType.SpecialEnergy3Max] = (float)attrConfig.FeverEnergyMax;
			attrMap[EKSC_AttrType.SpecialEnergy3] = (float)attrConfig.FeverEnergy;
			attrMap[EKSC_AttrType.SpecialEnergy3RecoverSpeed] = (float)attrConfig.FeverEnergyRecoverSpeed;
			attrMap[EKSC_AttrType.SpecialEnergy3ChargeEfficiency] = (float)attrConfig.FeverEnergyEfficiency;
		}

		// Token: 0x0604538D RID: 283533 RVA: 0x01212EF8 File Offset: 0x012110F8
		private void AddToAttrMap(Dictionary<EKSC_AttrType, float> attrMap, EKSC_AttrType attrType, float value)
		{
			if (attrType == EKSC_AttrType.EAttributeType_None)
			{
				return;
			}
			float num;
			attrMap.TryGetValue(attrType, out num);
			attrMap[attrType] = num + value;
		}

		// Token: 0x0604538E RID: 283534 RVA: 0x01212F20 File Offset: 0x01211120
		public Dictionary<EKSC_AttrType, int> GetDefaultAttrs(TMap<EKSC_AttrType, int> attrs)
		{
			if (this.DefaultAttrs == null)
			{
				this.DefaultAttrs = new Dictionary<EKSC_AttrType, int>(attrs.Num());
				foreach (KeyValuePair<EKSC_AttrType, int> keyValuePair in attrs)
				{
					EKSC_AttrType eksc_AttrType;
					int num;
					keyValuePair.Deconstruct(out eksc_AttrType, out num);
					EKSC_AttrType key = eksc_AttrType;
					int value = num;
					this.DefaultAttrs[key] = value;
				}
			}
			return this.DefaultAttrs;
		}

		// Token: 0x0604538F RID: 283535 RVA: 0x01212FA0 File Offset: 0x012111A0
		public void InitMonsterAttrConfigs()
		{
			IReadOnlyList<PinballMonsterAttr> allMonsterAttrConfigs = ConfigBase<PinballBattleConfig>.Instance.GetAllMonsterAttrConfigs();
			if (allMonsterAttrConfigs != null)
			{
				foreach (PinballMonsterAttr pinballMonsterAttr in allMonsterAttrConfigs)
				{
					Dictionary<EKSC_AttrType, float> dictionary = new Dictionary<EKSC_AttrType, float>();
					dictionary[EKSC_AttrType.LifeMax] = (float)pinballMonsterAttr.LifeMax;
					dictionary[EKSC_AttrType.Life] = (float)pinballMonsterAttr.Life;
					dictionary[EKSC_AttrType.BaseLife] = (float)pinballMonsterAttr.Life;
					dictionary[EKSC_AttrType.Atk] = (float)pinballMonsterAttr.Atk;
					dictionary[EKSC_AttrType.Def] = (float)pinballMonsterAttr.Def;
					dictionary[EKSC_AttrType.Crit] = (float)pinballMonsterAttr.Crit;
					dictionary[EKSC_AttrType.CritDamage] = (float)pinballMonsterAttr.CritDamage;
					dictionary[EKSC_AttrType.DamageAmplify1] = (float)pinballMonsterAttr.DamageAmplify1;
					dictionary[EKSC_AttrType.DamageReduce] = (float)pinballMonsterAttr.DamageReduce;
					dictionary[EKSC_AttrType.SpecialDamageReduce1] = (float)pinballMonsterAttr.DamageReduceAuto;
					dictionary[EKSC_AttrType.SpecialDamageReduce2] = (float)pinballMonsterAttr.DamageReduceStrong;
					dictionary[EKSC_AttrType.SpecialDamageReduce3] = (float)pinballMonsterAttr.DamageReduceSkill;
					dictionary[EKSC_AttrType.SpecialDamageReduce4] = (float)pinballMonsterAttr.DamageReduceSprint;
					dictionary[EKSC_AttrType.SpecialDamageReduce5] = (float)pinballMonsterAttr.DamageReduceSummon;
					dictionary[EKSC_AttrType.ShieldMax] = (float)pinballMonsterAttr.ProtectMax;
					this.PinballMonsterAttrConfigs[pinballMonsterAttr.Id] = dictionary;
				}
			}
		}

		// Token: 0x06045390 RID: 283536 RVA: 0x01213118 File Offset: 0x01211318
		public void SetLevelConfig(PinballLevelConfig? config)
		{
			int num = (config != null) ? config.Value.ScoreRatio : 0;
			this.ScoreRatio = 1f + (float)num * 0.0001f;
		}

		// Token: 0x06045391 RID: 283537 RVA: 0x01213158 File Offset: 0x01211358
		public int GetMaxWave()
		{
			PinballConfig instance = ConfigBase<PinballConfig>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				IReadOnlyList<PinballWaveConfig> pinballWaveConfigListByLevel = instance.GetPinballWaveConfigListByLevel(this.LevelId);
				num = ((pinballWaveConfigListByLevel != null) ? new int?(pinballWaveConfigListByLevel.Count) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x06045392 RID: 283538 RVA: 0x012131A5 File Offset: 0x012113A5
		public bool IsRoleLeader(int roleId)
		{
			return this.FormationData != null && this.FormationData.Count > 0 && this.FormationData[0].RoleId == roleId;
		}

		// Token: 0x06045393 RID: 283539 RVA: 0x012131D4 File Offset: 0x012113D4
		public void SetRoleBaseAttrsRecord(PinballFormationRolePb roleData, Dictionary<EKSC_AttrType, float> attrs)
		{
			Dictionary<EKSC_AttrType, float> dictionary;
			if (!this.RoleBaseAttrsRecord.TryGetValue(roleData.RoleId, out dictionary))
			{
				dictionary = new Dictionary<EKSC_AttrType, float>();
				this.RoleBaseAttrsRecord[roleData.RoleId] = dictionary;
			}
			float num;
			dictionary[EKSC_AttrType.LifeMax] = (attrs.TryGetValue(EKSC_AttrType.LifeMax, out num) ? num : 0f);
			float num2;
			dictionary[EKSC_AttrType.Atk] = (attrs.TryGetValue(EKSC_AttrType.Atk, out num2) ? num2 : 0f);
		}

		// Token: 0x06045394 RID: 283540 RVA: 0x01213244 File Offset: 0x01211444
		public float GetRoleContribution(PinballResultRolePb rolePb, float totalDamage)
		{
			PinballWorldConfig? worldConfigCache = this.WorldConfigCache;
			if (worldConfigCache == null)
			{
				return 0f;
			}
			float num = 0f;
			float num2 = 0f;
			Dictionary<EKSC_AttrType, float> dictionary;
			if (this.RoleBaseAttrsRecord.TryGetValue(rolePb.RoleId, out dictionary))
			{
				dictionary.TryGetValue(EKSC_AttrType.Atk, out num);
				dictionary.TryGetValue(EKSC_AttrType.LifeMax, out num2);
			}
			float num3 = totalDamage * (num * num2 / (float)worldConfigCache.Value.DamageResultAttrRatio);
			if (worldConfigCache.Value.DamageResultTeamRatiosLength > 1)
			{
				num3 *= (this.IsRoleLeader(rolePb.RoleId) ? worldConfigCache.Value.DamageResultTeamRatios(0) : worldConfigCache.Value.DamageResultTeamRatios(1));
			}
			if (worldConfigCache.Value.DamageResultClassRatiosLength > 2)
			{
				PinballRoleConfig? roleConfig = ConfigBase<PinballBattleConfig>.Instance.GetRoleConfig(rolePb.RoleId);
				if (roleConfig != null && roleConfig.Value.PinballClassLength > 0)
				{
					int num4 = roleConfig.Value.PinballClass(0);
					if (num4 == 1)
					{
						num3 *= worldConfigCache.Value.DamageResultClassRatios(0);
					}
					else if (num4 == 2)
					{
						num3 *= worldConfigCache.Value.DamageResultClassRatios(1);
					}
					else if (num4 == 3)
					{
						num3 *= worldConfigCache.Value.DamageResultClassRatios(2);
					}
				}
			}
			return num3 * (1f + (float)rolePb.SkillTimes * worldConfigCache.Value.DamageResultSkillRatio);
		}

		// Token: 0x040269D3 RID: 158163
		public PinballWorldConfig? WorldConfigCache;

		// Token: 0x040269D4 RID: 158164
		[Nullable(2)]
		public UDataTable BulletDataTable;

		// Token: 0x040269D5 RID: 158165
		[Nullable(2)]
		public UKSC_DA_Shape2D_World ShapeWorldDa;

		// Token: 0x040269D6 RID: 158166
		[Nullable(2)]
		public UKSC_DA_Shape2D_WorldBounds ShapeWorldBoundsDa;

		// Token: 0x040269D7 RID: 158167
		[Nullable(2)]
		public UDataTable ShapeMaterialDt;

		// Token: 0x040269D8 RID: 158168
		public readonly PinballBattleHeadStateManager PinballBattleHeadStateManager = new PinballBattleHeadStateManager();

		// Token: 0x040269D9 RID: 158169
		public Dictionary<int, PinballAttr> PinballPropertyConfigs = new Dictionary<int, PinballAttr>();

		// Token: 0x040269DA RID: 158170
		public Dictionary<int, UKSC_DA_Buff> LoadedBuffDaMap = new Dictionary<int, UKSC_DA_Buff>();

		// Token: 0x040269DB RID: 158171
		public Dictionary<int, HashSet<int>> RoleBornBuffsMap = new Dictionary<int, HashSet<int>>();

		// Token: 0x040269DC RID: 158172
		public Dictionary<int, Dictionary<EKSC_AttrType, float>> PinballMonsterAttrConfigs = new Dictionary<int, Dictionary<EKSC_AttrType, float>>();

		// Token: 0x040269DD RID: 158173
		private readonly Dictionary<int, Dictionary<EKSC_AttrType, float>> RoleBaseAttrsRecord = new Dictionary<int, Dictionary<EKSC_AttrType, float>>();

		// Token: 0x040269DE RID: 158174
		[Nullable(2)]
		private Dictionary<EKSC_AttrType, int> DefaultAttrs;

		// Token: 0x040269DF RID: 158175
		public float ComboEfficiency;

		// Token: 0x040269E0 RID: 158176
		private readonly Dictionary<int, IPinballBattleCombatInfo> AllEntities = new Dictionary<int, IPinballBattleCombatInfo>();

		// Token: 0x040269E1 RID: 158177
		private readonly Dictionary<int, int> TeamRoleId2CreatureId = new Dictionary<int, int>();

		// Token: 0x040269E2 RID: 158178
		public int GameState;

		// Token: 0x040269E3 RID: 158179
		public int LevelId;

		// Token: 0x040269E4 RID: 158180
		public int CurWave = 1;

		// Token: 0x040269E5 RID: 158181
		public int UsedReviveTime;

		// Token: 0x040269E6 RID: 158182
		public int MaxReviveTime;

		// Token: 0x040269E7 RID: 158183
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<PinballFormationRolePb> FormationData;

		// Token: 0x040269E8 RID: 158184
		public float Score;

		// Token: 0x040269E9 RID: 158185
		public int Combo;

		// Token: 0x040269EA RID: 158186
		public List<float> LevelScoreTargetList = new List<float>();

		// Token: 0x040269EB RID: 158187
		public float MaxScore;

		// Token: 0x040269EC RID: 158188
		public int[] StarInfo = new int[3];

		// Token: 0x040269ED RID: 158189
		public Dictionary<EKSC_AttrType, float> MonsterAttrRate = new Dictionary<EKSC_AttrType, float>();

		// Token: 0x040269EE RID: 158190
		private float ScoreRatio = 1f;

		// Token: 0x040269EF RID: 158191
		[Nullable(2)]
		public List<int> TeamBuffList;

		// Token: 0x040269F0 RID: 158192
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<PinballFormationRolePb> PreloadFormationData;

		// Token: 0x040269F1 RID: 158193
		public Dictionary<int, PinballRoleTotalInfo> RoleTotalMap = new Dictionary<int, PinballRoleTotalInfo>();

		// Token: 0x040269F2 RID: 158194
		public int DashTimes;

		// Token: 0x040269F3 RID: 158195
		public int FullEnergyTimes;

		// Token: 0x040269F4 RID: 158196
		public int AttackTimes;

		// Token: 0x040269F5 RID: 158197
		public int BossSkillTimes;

		// Token: 0x040269F6 RID: 158198
		public readonly EntitySpawnTracker FirstWaveMonsterTracker = new EntitySpawnTracker();

		// Token: 0x040269F7 RID: 158199
		public readonly EntitySpawnTracker CurWaveMachineTracker = new EntitySpawnTracker();
	}
}
