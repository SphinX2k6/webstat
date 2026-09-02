using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.World.Model;
using UnrealEngine;

// Token: 0x02002ED2 RID: 11986
[NullableContext(1)]
[Nullable(0)]
public class CharacterStatisticsComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x060189A8 RID: 100776 RVA: 0x006EDE70 File Offset: 0x006EC070
	static CharacterStatisticsComponent()
	{
		Dictionary<global::ECharMoveState, string> dictionary = new Dictionary<global::ECharMoveState, string>();
		dictionary[global::ECharMoveState.Walk] = "走";
		dictionary[global::ECharMoveState.Run] = "跑";
		dictionary[global::ECharMoveState.Sprint] = "冲刺";
		dictionary[global::ECharMoveState.Dodge] = "闪避";
		CharacterStatisticsComponent.MoveStateToString = dictionary;
		CharacterStatisticsComponent.SkillGenreName = new string[]
		{
			"普攻0",
			"蓄力1",
			"E技能2",
			"大招3",
			"QTE4",
			"极限闪避反击5",
			"地面闪避6",
			"极限闪避7",
			"被动技能8",
			"战斗幻象技9",
			"探索幻象技10",
			"空中闪避11",
			"无类别"
		};
		CharacterStatisticsComponent.OperationRecordTitle = "角色ID,角色名称,配置ID,技能/阶段,时间,次数\n";
		CharacterStatisticsComponent.IsCombatStarted = false;
		CharacterStatisticsComponent.CurrentAttackerId = 0;
		CharacterStatisticsComponent.CurrentTargetId = 0;
		CharacterStatisticsComponent.ItemsResetInternal = false;
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterStatisticsComponent.CreateStaticDefaultValue), new Action(CharacterStatisticsComponent.ResetStaticDefaultValue));
	}

	// Token: 0x060189A9 RID: 100777 RVA: 0x006EE020 File Offset: 0x006EC220
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(base.Entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnCharDamageAll));
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnBeginSkillCombat));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRevive, new Action(this.OnCharReviveAll));
		return true;
	}

	// Token: 0x060189AA RID: 100778 RVA: 0x006EE08E File Offset: 0x006EC28E
	protected override bool OnStart()
	{
		this.InitStageBeginTime();
		return true;
	}

	// Token: 0x060189AB RID: 100779 RVA: 0x006EE097 File Offset: 0x006EC297
	protected override void OnActivate()
	{
		if (CharacterStatisticsComponent.OpenOperationRecord)
		{
			this.StatisticsEnable = CharacterStatisticsComponent.IsInRecordArea(base.Entity);
		}
		this.OnActivateOperationRecord();
	}

	// Token: 0x060189AC RID: 100780 RVA: 0x006EE0B8 File Offset: 0x006EC2B8
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(base.Entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnCharDamageAll));
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnBeginSkillCombat));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRevive, new Action(this.OnCharReviveAll));
		if (CharacterStatisticsComponent.OpenOperationRecordInternal)
		{
			this.RemoveListenOperation();
		}
		return true;
	}

	// Token: 0x060189AD RID: 100781 RVA: 0x006EE134 File Offset: 0x006EC334
	private void OnCharDamageAll(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition)
	{
		int num = (int)damageResult.Damage;
		Damage damageData = damageResult.DamageData;
		ECalculationType calculateType = (ECalculationType)damageData.CalculateType;
		if (calculateType != ECalculationType.Hurt)
		{
			if (calculateType == ECalculationType.Heal)
			{
				if (this.StatisticsEnable)
				{
					this.OnCharHealStatistic(-num, attacker, victim, damageResult);
				}
				this.OnCharHealCombat(-num, attacker, victim, damageResult, requirements);
				return;
			}
		}
		else
		{
			if (this.StatisticsEnable)
			{
				this.OnCharDamageStatistic(num, (int)damageResult.Element, damagePosition, attacker, victim, requirements.IsCritical.GetValueOrDefault(), damageData.DamageTextType, requirements.IsImmune.GetValueOrDefault(), damageData.Id, requirements.BulletId, requirements.BuffId);
			}
			this.OnCharDamageCombat(num, (int)damageResult.Element, damagePosition, attacker, victim, requirements.IsCritical.GetValueOrDefault(), damageData.DamageTextType, requirements.IsImmune.GetValueOrDefault(), damageData.Id, requirements.BulletId, requirements.BuffId, requirements.IsTargetKilled, requirements);
		}
	}

	// Token: 0x060189AE RID: 100782 RVA: 0x006EE219 File Offset: 0x006EC419
	public void OnBuffAdded(ActiveBuffInternal buff)
	{
		this.OnBuffAddedCombat(buff);
	}

	// Token: 0x060189AF RID: 100783 RVA: 0x006EE222 File Offset: 0x006EC422
	public void OnBuffRemoved(ActiveBuffInternal buff)
	{
		this.OnBuffRemovedCombat(buff);
	}

	// Token: 0x060189B0 RID: 100784 RVA: 0x006EE22B File Offset: 0x006EC42B
	private void OnCharReviveAll()
	{
		this.OnCharReviveCombat();
	}

	// Token: 0x060189B1 RID: 100785 RVA: 0x006EE233 File Offset: 0x006EC433
	public bool GetStatisticsEnable()
	{
		return this.StatisticsEnable;
	}

	// Token: 0x17002144 RID: 8516
	// (get) Token: 0x060189B2 RID: 100786 RVA: 0x006EE23B File Offset: 0x006EC43B
	private static List<int> AllStatisticsEnableEntityId
	{
		get
		{
			return CharacterStatisticsComponent._allStatisticsEnableEntityId;
		}
	}

	// Token: 0x060189B3 RID: 100787 RVA: 0x006EE244 File Offset: 0x006EC444
	public static void SetStatisticsEnable(bool enable)
	{
		if (enable)
		{
			using (IEnumerator<EntityHandle> enumerator = ModelBase<CreatureModel>.Instance.GetAllEntities().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EntityHandle entityHandle = enumerator.Current;
					if (CharacterStatisticsComponent.IsInRecordArea(entityHandle.Entity))
					{
						CharacterStatisticsComponent component = entityHandle.Entity.GetComponent<CharacterStatisticsComponent>();
						if (component != null && component.Valid)
						{
							component.StatisticsEnable = true;
							CharacterStatisticsComponent.AllStatisticsEnableEntityId.Add(entityHandle.Id);
						}
					}
				}
				return;
			}
		}
		foreach (int id in CharacterStatisticsComponent.AllStatisticsEnableEntityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(id);
			if (entity != null && entity.Valid)
			{
				entity.GetComponent<CharacterStatisticsComponent>().StatisticsEnable = false;
			}
		}
		CharacterStatisticsComponent.AllStatisticsEnableEntityId.Clear();
	}

	// Token: 0x17002145 RID: 8517
	// (get) Token: 0x060189B4 RID: 100788 RVA: 0x006EE348 File Offset: 0x006EC548
	private static Dictionary<int, Dictionary<EDamageType, DamageStatisticsData>> DamageStaticsBySkillTypeMap
	{
		get
		{
			return CharacterStatisticsComponent._damageStaticsBySkillTypeMap;
		}
	}

	// Token: 0x17002146 RID: 8518
	// (get) Token: 0x060189B5 RID: 100789 RVA: 0x006EE34F File Offset: 0x006EC54F
	private static Dictionary<int, Dictionary<global::EAttackType, DamageStatisticsData>> DamageStaticsByAttackTypeMap
	{
		get
		{
			return CharacterStatisticsComponent._damageStaticsByAttackTypeMap;
		}
	}

	// Token: 0x17002147 RID: 8519
	// (get) Token: 0x060189B6 RID: 100790 RVA: 0x006EE356 File Offset: 0x006EC556
	private static Dictionary<int, Dictionary<EDamageType, DamageStatisticsData>> HealStaticsBySkillTypeMap
	{
		get
		{
			return CharacterStatisticsComponent._healStaticsBySkillTypeMap;
		}
	}

	// Token: 0x17002148 RID: 8520
	// (get) Token: 0x060189B7 RID: 100791 RVA: 0x006EE35D File Offset: 0x006EC55D
	private static Dictionary<int, Dictionary<global::EAttackType, DamageStatisticsData>> HealStaticsByAttackTypeMap
	{
		get
		{
			return CharacterStatisticsComponent._healStaticsByAttackTypeMap;
		}
	}

	// Token: 0x060189B8 RID: 100792 RVA: 0x006EE364 File Offset: 0x006EC564
	public static void CleanupRecordData()
	{
		CharacterStatisticsComponent.DamageStaticsByAttackTypeMap.Clear();
		CharacterStatisticsComponent.HealStaticsByAttackTypeMap.Clear();
		CharacterStatisticsComponent.DamageStaticsBySkillTypeMap.Clear();
		CharacterStatisticsComponent.HealStaticsBySkillTypeMap.Clear();
	}

	// Token: 0x060189B9 RID: 100793 RVA: 0x006EE390 File Offset: 0x006EC590
	private void OnCharHealStatistic(int healMagnitude, Entity healer, Entity target, DamageResult parameters)
	{
		int damage = (int)parameters.Damage;
		long id = parameters.DamageData.Id;
		CharacterStatisticsComponent.ProcessRecordBySkillType(damage, healer, target, id, true, null, null);
		CharacterStatisticsComponent.ProcessRecordByAttackType(damage, healer, target, id, true);
	}

	// Token: 0x060189BA RID: 100794 RVA: 0x006EE3D7 File Offset: 0x006EC5D7
	private void OnCharDamageStatistic(int damage, int elementId, FVectorDouble damagePosition, Entity attacker, Entity victim, bool bCritical, int damageTextType, bool bImmune, long damageId, long? bulletId = null, long? buffId = null)
	{
		CharacterStatisticsComponent.ProcessRecordBySkillType(damage, attacker, victim, damageId, false, bulletId, buffId);
		CharacterStatisticsComponent.ProcessRecordByAttackType(damage, attacker, victim, damageId, false);
	}

	// Token: 0x060189BB RID: 100795 RVA: 0x006EE3F8 File Offset: 0x006EC5F8
	public static void ProcessRecordBySkillType(int damage, Entity attacker, Entity victim, long damageId, bool isHeal, long? bulletId = null, long? buffId = null)
	{
		CreatureDataComponent component = attacker.GetComponent<CreatureDataComponent>();
		if (component.GetEntityType() != EEntityType.Player)
		{
			return;
		}
		int num = component.Valid ? component.GetRoleId() : 0;
		int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(num);
		if (baseRoleId == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "获取不到roleData";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", num);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
		if (roleConfig == null)
		{
			return;
		}
		string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
		IReadOnlyList<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleConfig.Value.SkillId);
		int num2 = 0;
		if (skillList != null)
		{
			foreach (Aki.Config.Skill skill in skillList)
			{
				if (CharacterStatisticsComponent.TryGetSkillContainsDamage(skill, damageId))
				{
					num2 = skill.SkillType;
					break;
				}
			}
		}
		Dictionary<int, Dictionary<EDamageType, DamageStatisticsData>> dictionary = isHeal ? CharacterStatisticsComponent.HealStaticsBySkillTypeMap : CharacterStatisticsComponent.DamageStaticsBySkillTypeMap;
		Dictionary<EDamageType, DamageStatisticsData> dictionary2;
		if (!dictionary.TryGetValue(baseRoleId, out dictionary2))
		{
			dictionary2 = new Dictionary<EDamageType, DamageStatisticsData>();
			dictionary[baseRoleId] = dictionary2;
		}
		if (num2 > 0)
		{
			EDamageType key = (EDamageType)(num2 - 1);
			DamageStatisticsData damageStatisticsData;
			if (!dictionary2.TryGetValue(key, out damageStatisticsData))
			{
				string damageType = CharacterStatisticsComponent.skillTypeToString[num2 - 1];
				damageStatisticsData = new DamageStatisticsData(baseRoleId, roleName, damageType, isHeal);
				dictionary2[key] = damageStatisticsData;
			}
			damageStatisticsData.AddDamageValue(victim.Id, damage);
			if (damageStatisticsData.GetTargetCount() > CharacterStatisticsComponent.TargetMaxCountSkillType)
			{
				CharacterStatisticsComponent.TargetMaxCountSkillType = damageStatisticsData.GetTargetCount();
				return;
			}
		}
		else
		{
			Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageId);
			if (((damageConfigById != null) ? damageConfigById.GetValueOrDefault().Type : -1) != 5)
			{
				return;
			}
			DamageStatisticsData damageStatisticsData2;
			if (!dictionary2.TryGetValue(EDamageType.Vision, out damageStatisticsData2))
			{
				damageStatisticsData2 = new DamageStatisticsData(baseRoleId, roleName, CharacterStatisticsComponent.skillTypeToString[6], isHeal);
				dictionary2[EDamageType.Vision] = damageStatisticsData2;
			}
			damageStatisticsData2.AddDamageValue(victim.Id, damage);
			if (damageStatisticsData2.GetTargetCount() > CharacterStatisticsComponent.TargetMaxCountSkillType)
			{
				CharacterStatisticsComponent.TargetMaxCountSkillType = damageStatisticsData2.GetTargetCount();
			}
		}
	}

	// Token: 0x060189BC RID: 100796 RVA: 0x006EE620 File Offset: 0x006EC820
	private static void ProcessRecordByAttackType(int damage, Entity attacker, Entity victim, long damageId, bool isHeal)
	{
		CreatureDataComponent component = attacker.GetComponent<CreatureDataComponent>();
		if (!component.IsRole())
		{
			return;
		}
		Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageId);
		if (damageConfigById == null)
		{
			return;
		}
		int num = component.Valid ? component.GetRoleId() : 0;
		int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(num);
		if (baseRoleId == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "获取不到roleData";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", num);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
		if (roleConfig == null)
		{
			return;
		}
		string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
		Dictionary<int, Dictionary<global::EAttackType, DamageStatisticsData>> dictionary = isHeal ? CharacterStatisticsComponent.HealStaticsByAttackTypeMap : CharacterStatisticsComponent.DamageStaticsByAttackTypeMap;
		Dictionary<global::EAttackType, DamageStatisticsData> dictionary2;
		if (!dictionary.TryGetValue(baseRoleId, out dictionary2))
		{
			dictionary2 = new Dictionary<global::EAttackType, DamageStatisticsData>();
			dictionary[baseRoleId] = dictionary2;
		}
		global::EAttackType type = (global::EAttackType)damageConfigById.Value.Type;
		DamageStatisticsData damageStatisticsData;
		if (!dictionary2.TryGetValue(type, out damageStatisticsData))
		{
			damageStatisticsData = new DamageStatisticsData(baseRoleId, roleName, CharacterStatisticsComponent.attackTypeToString[(int)type], isHeal);
			dictionary2[type] = damageStatisticsData;
		}
		damageStatisticsData.AddDamageValue(victim.Id, damage);
		if (CharacterStatisticsComponent.TargetMaxCountAttackType < damageStatisticsData.GetTargetCount())
		{
			CharacterStatisticsComponent.TargetMaxCountAttackType = damageStatisticsData.GetTargetCount();
		}
	}

	// Token: 0x060189BD RID: 100797 RVA: 0x006EE769 File Offset: 0x006EC969
	private static bool TryGetSkillContainsDamage(Aki.Config.Skill skill, long damageId)
	{
		return CharacterStatisticsComponent.SkillContainsDamageInternal(skill, damageId);
	}

	// Token: 0x060189BE RID: 100798 RVA: 0x006EE774 File Offset: 0x006EC974
	private unsafe static bool SkillContainsDamageInternal(Aki.Config.Skill skill, long damageId)
	{
		try
		{
			Span<long> damageListBytes = skill.GetDamageListBytes();
			for (int i = 0; i < damageListBytes.Length; i++)
			{
				long num = *damageListBytes[i];
				if (num == damageId || num == (long)((int)damageId))
				{
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	// Token: 0x060189BF RID: 100799 RVA: 0x006EE7CC File Offset: 0x006EC9CC
	public static string ExportStatisticsBySkillType()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("角色Id,名称,治疗/伤害,技能");
		for (int i = 0; i < CharacterStatisticsComponent.TargetMaxCountSkillType; i++)
		{
			string text = (i + 1).ToString();
			stringBuilder.Append(StringUtils.Format(CharacterStatisticsComponent.TargetTitleFormat, new string[]
			{
				text,
				text,
				text,
				text,
				text
			}));
		}
		stringBuilder.Append('\n');
		foreach (Dictionary<EDamageType, DamageStatisticsData> dictionary in CharacterStatisticsComponent.DamageStaticsBySkillTypeMap.Values)
		{
			foreach (DamageStatisticsData damageStatisticsData in dictionary.Values)
			{
				stringBuilder.Append(damageStatisticsData.ToString());
			}
		}
		foreach (Dictionary<EDamageType, DamageStatisticsData> dictionary2 in CharacterStatisticsComponent.HealStaticsBySkillTypeMap.Values)
		{
			foreach (DamageStatisticsData damageStatisticsData2 in dictionary2.Values)
			{
				stringBuilder.Append(damageStatisticsData2.ToString());
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060189C0 RID: 100800 RVA: 0x006EE958 File Offset: 0x006ECB58
	public static string ExportStatisticsByAttackType()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("角色Id,名称,治疗/伤害,伤害类型");
		for (int i = 0; i < CharacterStatisticsComponent.TargetMaxCountAttackType; i++)
		{
			string text = (i + 1).ToString();
			stringBuilder.Append(StringUtils.Format(CharacterStatisticsComponent.TargetTitleFormat, new string[]
			{
				text,
				text,
				text,
				text,
				text
			}));
		}
		stringBuilder.Append('\n');
		foreach (Dictionary<global::EAttackType, DamageStatisticsData> dictionary in CharacterStatisticsComponent.DamageStaticsByAttackTypeMap.Values)
		{
			foreach (DamageStatisticsData damageStatisticsData in dictionary.Values)
			{
				stringBuilder.Append(damageStatisticsData.ToString());
			}
		}
		foreach (Dictionary<global::EAttackType, DamageStatisticsData> dictionary2 in CharacterStatisticsComponent.HealStaticsByAttackTypeMap.Values)
		{
			foreach (DamageStatisticsData damageStatisticsData2 in dictionary2.Values)
			{
				stringBuilder.Append(damageStatisticsData2.ToString());
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x17002149 RID: 8521
	// (get) Token: 0x060189C1 RID: 100801 RVA: 0x006EEAE4 File Offset: 0x006ECCE4
	private static Dictionary<int, CharacterOperationRecord> CharacterOperationRecordMap
	{
		get
		{
			return CharacterStatisticsComponent._characterOperationRecordMap;
		}
	}

	// Token: 0x1700214A RID: 8522
	// (get) Token: 0x060189C2 RID: 100802 RVA: 0x006EEAEB File Offset: 0x006ECCEB
	public static bool OpenOperationRecord
	{
		get
		{
			return CharacterStatisticsComponent.OpenOperationRecordInternal;
		}
	}

	// Token: 0x060189C3 RID: 100803 RVA: 0x006EEAF2 File Offset: 0x006ECCF2
	private void OnActivateOperationRecord()
	{
		if (!CharacterStatisticsComponent.OpenOperationRecordInternal)
		{
			return;
		}
		if (CharacterStatisticsComponent.CharacterOperationRecordMap.ContainsKey(base.Entity.Id))
		{
			return;
		}
		if (CharacterStatisticsComponent.IsInRecordArea(base.Entity))
		{
			this.ListenOperation();
		}
	}

	// Token: 0x060189C4 RID: 100804 RVA: 0x006EEB28 File Offset: 0x006ECD28
	private void ListenOperation()
	{
		this.OperationBeginTimeMap.Clear();
		this.MoveOperationBeginTimeMap.Clear();
		this.TagOperationBeginTimeMap.Clear();
		if (base.Entity.GetComponent<CreatureDataComponent>().IsRole())
		{
			CharacterStatisticsComponent.InAreaEntityId.Add(base.Entity.Id);
			Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OperationRecordBeginSkill));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OperationRecordEndSkill));
			Singleton<EventSystem>.Instance.AddWithTarget<global::ECharMoveState, global::ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChange));
			CharacterUnifiedStateComponent component = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
			if (component != null && component.Valid)
			{
				this.OnMoveStateStart(component.MoveState);
			}
			BaseTagComponent baseTagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
			if (baseTagComponent != null && baseTagComponent.Valid)
			{
				ITagTask tagTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"]), new BaseTagComponent.TTagSwitchedCallback(this.OnTagChanged), null);
				if (tagTask != null)
				{
					this.ListenOperationTasks.Add(tagTask);
				}
			}
			using (Dictionary<int, string>.KeyCollection.Enumerator enumerator = CharacterStatisticsComponent.RoleStageInfo.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int num = enumerator.Current;
					if (baseTagComponent.HasTag(num))
					{
						this.TagOperationBeginTimeMap[num] = Singleton<Time>.Instance.NowSeconds;
					}
				}
				return;
			}
		}
		BaseTagComponent baseTagComponent2 = base.Entity.CheckGetComponent<BaseTagComponent>();
		if (baseTagComponent2 != null && baseTagComponent2.Valid)
		{
			CharacterStatisticsComponent.InAreaEntityId.Add(base.Entity.Id);
			this.AddListenTagTask(baseTagComponent2, GameplayTagDefine.EGameplayTagId["Damage.Vulnerable"]);
			this.AddListenTagTask(baseTagComponent2, GameplayTagDefine.EGameplayTagId["功能.功能制作.白条生效"]);
			this.AddListenTagTask(baseTagComponent2, GameplayTagDefine.EGameplayTagId["功能.功能制作.狂暴生效"]);
			this.AddListenTagTask(baseTagComponent2, GameplayTagDefine.EGameplayTagId["怪物.common.状态标识.瘫痪中"]);
			foreach (int num2 in CharacterStatisticsComponent.MonsterStageInfo.Keys)
			{
				if (baseTagComponent2.HasTag(num2))
				{
					this.TagOperationBeginTimeMap[num2] = Singleton<Time>.Instance.NowSeconds;
				}
			}
		}
	}

	// Token: 0x060189C5 RID: 100805 RVA: 0x006EEDAC File Offset: 0x006ECFAC
	private void AddListenTagTask(BaseTagComponent tagComp, int tagId)
	{
		ITagTask tagTask = tagComp.ListenForTagAddOrRemove(new int?(tagId), new BaseTagComponent.TTagSwitchedCallback(this.OnTagChanged), null);
		if (tagTask != null)
		{
			this.ListenOperationTasks.Add(tagTask);
		}
	}

	// Token: 0x060189C6 RID: 100806 RVA: 0x006EEDE4 File Offset: 0x006ECFE4
	private void RemoveListenOperation()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component != null && component.IsRole())
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OperationRecordBeginSkill));
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OperationRecordEndSkill));
			Singleton<EventSystem>.Instance.RemoveWithTarget<global::ECharMoveState, global::ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChange));
		}
		foreach (ITagTask tagTask in this.ListenOperationTasks)
		{
			tagTask.EndTask();
		}
		this.ListenOperationTasks.Clear();
	}

	// Token: 0x060189C7 RID: 100807 RVA: 0x006EEEB8 File Offset: 0x006ED0B8
	private void OnMoveStateChange(global::ECharMoveState oldMoveState, global::ECharMoveState newMoveState)
	{
		if (!CharacterStatisticsComponent.OpenOperationRecordInternal || !base.Entity.GetComponent<CreatureDataComponent>().IsRole())
		{
			return;
		}
		this.OnMoveStateEnd(oldMoveState);
		this.OnMoveStateStart(newMoveState);
	}

	// Token: 0x060189C8 RID: 100808 RVA: 0x006EEEE4 File Offset: 0x006ED0E4
	private unsafe void OnMoveStateStart(global::ECharMoveState state)
	{
		if (!CharacterStatisticsComponent.MoveStateToString.ContainsKey(state))
		{
			return;
		}
		double? num;
		if (this.MoveOperationBeginTimeMap.TryGetValue(state, out num) && num != null)
		{
			RoleInfo? roleConfig = base.Entity.GetComponent<CreatureDataComponent>().GetRoleConfig();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "记录移动开始时间时有未执行OnMoveStateEnd";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoleName", ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("State", state);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.MoveOperationBeginTimeMap[state] = new double?(Singleton<Time>.Instance.NowSeconds);
	}

	// Token: 0x060189C9 RID: 100809 RVA: 0x006EEFBC File Offset: 0x006ED1BC
	private unsafe void OnMoveStateEnd(global::ECharMoveState state)
	{
		if (!CharacterStatisticsComponent.MoveStateToString.ContainsKey(state))
		{
			return;
		}
		int id = base.Entity.Id;
		CharacterOperationRecord characterOperationRecord;
		if (!CharacterStatisticsComponent.CharacterOperationRecordMap.TryGetValue(id, out characterOperationRecord))
		{
			RoleInfo? roleConfig = base.Entity.GetComponent<CreatureDataComponent>().GetRoleConfig();
			characterOperationRecord = new CharacterOperationRecord(ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name), id, roleConfig.Value.Id);
			CharacterStatisticsComponent.CharacterOperationRecordMap[id] = characterOperationRecord;
		}
		SkillOperationRecord skillOperationRecord;
		if (!characterOperationRecord.MoveOperationMap.TryGetValue(state, out skillOperationRecord))
		{
			skillOperationRecord = new SkillOperationRecord(CharacterStatisticsComponent.MoveStateToString[state]);
			characterOperationRecord.MoveOperationMap[state] = skillOperationRecord;
		}
		double? num;
		if (!this.MoveOperationBeginTimeMap.TryGetValue(state, out num) || num == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "计算出现异常 OnMoveStateEnd";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", characterOperationRecord.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", characterOperationRecord.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Map", this.MoveOperationBeginTimeMap);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		else
		{
			skillOperationRecord.AddOptCountAndTime((int)(Singleton<Time>.Instance.NowSeconds - num.Value), 1);
		}
		this.MoveOperationBeginTimeMap[state] = null;
	}

	// Token: 0x060189CA RID: 100810 RVA: 0x006EF13C File Offset: 0x006ED33C
	private unsafe void OperationRecordBeginSkill(int entityId, int skillId, bool isAutonomousProxy)
	{
		if (!CharacterStatisticsComponent.OpenOperationRecordInternal || !base.Entity.GetComponent<CreatureDataComponent>().IsRole())
		{
			return;
		}
		double? num;
		if (this.OperationBeginTimeMap.TryGetValue((long)skillId, out num) && num != null)
		{
			RoleInfo? roleConfig = base.Entity.GetComponent<CreatureDataComponent>().GetRoleConfig();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "记录技能开始使用时间时有技能未执行EndSkill";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoleName", ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkillId", skillId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.OperationBeginTimeMap[(long)skillId] = new double?(Singleton<Time>.Instance.NowSeconds);
	}

	// Token: 0x060189CB RID: 100811 RVA: 0x006EF220 File Offset: 0x006ED420
	private unsafe void OperationRecordEndSkill(int entityId, int skillId)
	{
		if (!CharacterStatisticsComponent.OpenOperationRecordInternal || !base.Entity.GetComponent<CreatureDataComponent>().IsRole())
		{
			return;
		}
		CharacterOperationRecord characterOperationRecord;
		if (!CharacterStatisticsComponent.CharacterOperationRecordMap.TryGetValue(entityId, out characterOperationRecord))
		{
			RoleInfo? roleConfig = base.Entity.GetComponent<CreatureDataComponent>().GetRoleConfig();
			characterOperationRecord = new CharacterOperationRecord(ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name), entityId, roleConfig.Value.Id);
			CharacterStatisticsComponent.CharacterOperationRecordMap[entityId] = characterOperationRecord;
		}
		TEnumAsByte<ESkillGenre> skillGenre = base.Entity.GetComponent<BaseSkillComponent>().GetSkillInfo(skillId).SkillGenre;
		SkillOperationRecord skillOperationRecord;
		if (!characterOperationRecord.SkillOperationMap.TryGetValue((int)skillGenre, out skillOperationRecord))
		{
			skillOperationRecord = new SkillOperationRecord((skillGenre >= 0 && (int)skillGenre < CharacterStatisticsComponent.SkillGenreName.Length) ? CharacterStatisticsComponent.SkillGenreName[(int)skillGenre] : CharacterStatisticsComponent.SkillGenreName[CharacterStatisticsComponent.SkillGenreName.Length - 1]);
			characterOperationRecord.SkillOperationMap[(int)skillGenre] = skillOperationRecord;
		}
		double? num;
		if (!this.OperationBeginTimeMap.TryGetValue((long)skillId, out num) || num == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "计算出现异常 EndSkill";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", characterOperationRecord.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", characterOperationRecord.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Map", this.OperationBeginTimeMap);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		else
		{
			skillOperationRecord.AddOptCountAndTime((int)(Singleton<Time>.Instance.NowSeconds - num.Value), 1);
		}
		this.OperationBeginTimeMap[(long)skillId] = null;
	}

	// Token: 0x1700214B RID: 8523
	// (get) Token: 0x060189CC RID: 100812 RVA: 0x006EF3ED File Offset: 0x006ED5ED
	private static Dictionary<int, string> MonsterStageInfo
	{
		get
		{
			return CharacterStatisticsComponent._monsterStageInfo;
		}
	}

	// Token: 0x1700214C RID: 8524
	// (get) Token: 0x060189CD RID: 100813 RVA: 0x006EF3F4 File Offset: 0x006ED5F4
	private static Dictionary<int, string> RoleStageInfo
	{
		get
		{
			return CharacterStatisticsComponent._roleStageInfo;
		}
	}

	// Token: 0x060189CE RID: 100814 RVA: 0x006EF3FB File Offset: 0x006ED5FB
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<int, string> StageInfo(EEntityType entityType)
	{
		if (entityType == EEntityType.Monster)
		{
			return CharacterStatisticsComponent.MonsterStageInfo;
		}
		if (entityType == EEntityType.Player)
		{
			return CharacterStatisticsComponent.RoleStageInfo;
		}
		return null;
	}

	// Token: 0x060189CF RID: 100815 RVA: 0x006EF414 File Offset: 0x006ED614
	private void InitStageBeginTime()
	{
		if (!CharacterStatisticsComponent.OpenOperationRecordInternal)
		{
			return;
		}
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component == null)
		{
			return;
		}
		Dictionary<int, string> dictionary = CharacterStatisticsComponent.StageInfo(base.Entity.GetComponent<CreatureDataComponent>().GetEntityType());
		if (dictionary == null)
		{
			return;
		}
		foreach (int tagId in dictionary.Keys)
		{
			if (component.HasTag(tagId))
			{
				this.OnTagChanged(tagId, true);
			}
		}
	}

	// Token: 0x060189D0 RID: 100816 RVA: 0x006EF4A4 File Offset: 0x006ED6A4
	private unsafe void OnTagChanged(int tagId, bool exists)
	{
		if (!CharacterStatisticsComponent.OpenOperationRecordInternal)
		{
			return;
		}
		if (exists)
		{
			this.TagOperationBeginTimeMap[tagId] = Singleton<Time>.Instance.NowSeconds;
			return;
		}
		double num;
		this.TagOperationBeginTimeMap.TryGetValue(tagId, out num);
		double num2 = Singleton<Time>.Instance.NowSeconds - num;
		int id = base.Entity.Id;
		CharacterOperationRecord characterOperationRecord;
		if (!CharacterStatisticsComponent.CharacterOperationRecordMap.TryGetValue(id, out characterOperationRecord))
		{
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			EEntityType entityType = component.GetEntityType();
			if (entityType == EEntityType.Monster)
			{
				characterOperationRecord = new CharacterOperationRecord(Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? ""), id, component.GetPbDataId());
			}
			else
			{
				if (entityType != EEntityType.Player)
				{
					return;
				}
				RoleInfo? roleConfig = component.GetRoleConfig();
				characterOperationRecord = new CharacterOperationRecord(ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name), id, roleConfig.Value.Id);
			}
			CharacterStatisticsComponent.CharacterOperationRecordMap[id] = characterOperationRecord;
		}
		Dictionary<int, string> dictionary = CharacterStatisticsComponent.StageInfo(base.Entity.GetComponent<CreatureDataComponent>().GetEntityType());
		if (dictionary == null)
		{
			return;
		}
		SkillOperationRecord skillOperationRecord;
		if (!characterOperationRecord.TagOperationMap.TryGetValue(tagId, out skillOperationRecord))
		{
			skillOperationRecord = new SkillOperationRecord(dictionary[tagId]);
			characterOperationRecord.TagOperationMap[tagId] = skillOperationRecord;
		}
		if (double.IsNaN(num2))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "计算出现异常 OnTagChanged";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("beginTime", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Map", this.TagOperationBeginTimeMap);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TagId", tagId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		skillOperationRecord.AddOptCountAndTime((int)num2, 1);
	}

	// Token: 0x1700214D RID: 8525
	// (get) Token: 0x060189D1 RID: 100817 RVA: 0x006EF69F File Offset: 0x006ED89F
	private static List<int> InAreaEntityId
	{
		get
		{
			return CharacterStatisticsComponent._inAreaEntityId;
		}
	}

	// Token: 0x060189D2 RID: 100818 RVA: 0x006EF6A8 File Offset: 0x006ED8A8
	public static void OperationRecord(bool open)
	{
		CharacterStatisticsComponent.OpenOperationRecordInternal = open;
		if (!open)
		{
			foreach (int id in CharacterStatisticsComponent.InAreaEntityId)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(id);
				if (entity != null && entity.Valid)
				{
					CharacterStatisticsComponent component = entity.GetComponent<CharacterStatisticsComponent>();
					if (component != null)
					{
						component.StatisticsEnable = false;
						component.RemoveListenOperation();
					}
				}
			}
			CharacterStatisticsComponent.InAreaEntityId.Clear();
			return;
		}
		foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
		{
			CharacterStatisticsComponent component2 = entityHandle.Entity.GetComponent<CharacterStatisticsComponent>();
			if (component2 != null)
			{
				CharacterAbilityComponent component3 = entityHandle.Entity.GetComponent<CharacterAbilityComponent>();
				if (component3 != null && component3.Valid && CharacterStatisticsComponent.IsInRecordArea(entityHandle.Entity))
				{
					component2.StatisticsEnable = true;
					component2.ListenOperation();
				}
			}
		}
	}

	// Token: 0x060189D3 RID: 100819 RVA: 0x006EF7C8 File Offset: 0x006ED9C8
	public static bool IsInRecordArea(Entity entity)
	{
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component.IsRole())
		{
			return true;
		}
		if (component.IsMonster())
		{
			BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
			if (component2 == null)
			{
				return false;
			}
			if (global::Vector.DistSquaredXY(component2.ActorLocationProxy, ModelBase<CameraModel>.Instance.MainModel.CameraLocation) < CharacterStatisticsComponent.HalfLengthRecordSquared)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060189D4 RID: 100820 RVA: 0x006EF834 File Offset: 0x006EDA34
	[NullableContext(2)]
	public static string ExportRecord()
	{
		if (CharacterStatisticsComponent.CharacterOperationRecordMap.Count == 0)
		{
			return null;
		}
		if (CharacterStatisticsComponent.OpenOperationRecordInternal)
		{
			CharacterStatisticsComponent.OperationRecord(false);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(CharacterStatisticsComponent.OperationRecordTitle);
		foreach (CharacterOperationRecord characterOperationRecord in CharacterStatisticsComponent.CharacterOperationRecordMap.Values)
		{
			stringBuilder.Append(characterOperationRecord.ToString());
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060189D5 RID: 100821 RVA: 0x006EF8C4 File Offset: 0x006EDAC4
	public static int OperationRecordCount()
	{
		int num = 0;
		foreach (CharacterOperationRecord characterOperationRecord in CharacterStatisticsComponent.CharacterOperationRecordMap.Values)
		{
			num += characterOperationRecord.SkillOperationMap.Count;
			num += characterOperationRecord.MoveOperationMap.Count;
			num += characterOperationRecord.TagOperationMap.Count;
		}
		return num;
	}

	// Token: 0x060189D6 RID: 100822 RVA: 0x006EF944 File Offset: 0x006EDB44
	public static void CleanupOperationRecord()
	{
		CharacterStatisticsComponent.CharacterOperationRecordMap.Clear();
	}

	// Token: 0x1700214E RID: 8526
	// (get) Token: 0x060189D7 RID: 100823 RVA: 0x006EF950 File Offset: 0x006EDB50
	private static Dictionary<ECombatDataType, bool> MapCombatDataType
	{
		get
		{
			return CharacterStatisticsComponent._mapCombatDataType;
		}
	}

	// Token: 0x060189D8 RID: 100824 RVA: 0x006EF957 File Offset: 0x006EDB57
	public static void SetCombatStarted(bool isCombatStarted, IList<ECombatDataType> combatTypeOpen, int attackerIndex, int targetIndex)
	{
		CharacterStatisticsComponent.IsCombatStarted = isCombatStarted;
		if (isCombatStarted)
		{
			CharacterStatisticsComponent.SetTypeOpen(combatTypeOpen);
			CharacterStatisticsComponent.SetCurrentAttacker(attackerIndex);
			CharacterStatisticsComponent.SetCurrentTarget(targetIndex);
		}
	}

	// Token: 0x1700214F RID: 8527
	// (get) Token: 0x060189D9 RID: 100825 RVA: 0x006EF974 File Offset: 0x006EDB74
	private static List<int> ArrayAttackerEntityId
	{
		get
		{
			return CharacterStatisticsComponent._arrayAttackerEntityId;
		}
	}

	// Token: 0x060189DA RID: 100826 RVA: 0x006EF97C File Offset: 0x006EDB7C
	public static TArray<string> GetAttackerCombatEntities()
	{
		CharacterStatisticsComponent.ArrayAttackerEntityId.Clear();
		TArray<string> tarray = new TArray<string>();
		tarray.Add("无");
		CharacterStatisticsComponent.ArrayAttackerEntityId.Add(0);
		foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
		{
			string entityName = CharacterStatisticsComponent.GetEntityName(entityHandle);
			if (!string.IsNullOrEmpty(entityName))
			{
				tarray.Add(entityName);
				CharacterStatisticsComponent.ArrayAttackerEntityId.Add(entityHandle.Id);
			}
		}
		return tarray;
	}

	// Token: 0x17002150 RID: 8528
	// (get) Token: 0x060189DB RID: 100827 RVA: 0x006EFA14 File Offset: 0x006EDC14
	private static List<int> ArrayTargetEntityId
	{
		get
		{
			return CharacterStatisticsComponent._arrayTargetEntityId;
		}
	}

	// Token: 0x060189DC RID: 100828 RVA: 0x006EFA1C File Offset: 0x006EDC1C
	public static TArray<string> GetTargetCombatEntities()
	{
		CharacterStatisticsComponent.ArrayTargetEntityId.Clear();
		TArray<string> tarray = new TArray<string>();
		tarray.Add("无");
		CharacterStatisticsComponent.ArrayTargetEntityId.Add(0);
		foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
		{
			string entityName = CharacterStatisticsComponent.GetEntityName(entityHandle);
			if (!string.IsNullOrEmpty(entityName))
			{
				tarray.Add(entityName);
				CharacterStatisticsComponent.ArrayTargetEntityId.Add(entityHandle.Id);
			}
		}
		return tarray;
	}

	// Token: 0x060189DD RID: 100829 RVA: 0x006EFAB4 File Offset: 0x006EDCB4
	[return: Nullable(2)]
	public static string GetEntityName(EntityHandle handle)
	{
		if (handle == null)
		{
			return null;
		}
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		EEntityType entityType = component.GetEntityType();
		if (entityType == EEntityType.Player)
		{
			int id = component.Valid ? component.GetRoleId() : 0;
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
			if (baseRoleId == 0)
			{
				return null;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
			if (roleConfig == null)
			{
				return null;
			}
			return ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
		}
		else
		{
			if (entityType == EEntityType.Monster)
			{
				return Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
			}
			return null;
		}
	}

	// Token: 0x060189DE RID: 100830 RVA: 0x006EFB54 File Offset: 0x006EDD54
	public static void SetTypeOpen(IList<ECombatDataType> combatTypeOpen)
	{
		if (!CharacterStatisticsComponent.ItemsResetInternal)
		{
			if (CharacterStatisticsComponent.MapCombatDataType.Count != combatTypeOpen.Count)
			{
				CharacterStatisticsComponent.ItemsResetInternal = true;
			}
			else
			{
				for (int i = 0; i < combatTypeOpen.Count; i++)
				{
					bool flag;
					if (!CharacterStatisticsComponent.MapCombatDataType.TryGetValue(combatTypeOpen[i], out flag) || !flag)
					{
						CharacterStatisticsComponent.ItemsResetInternal = true;
						break;
					}
				}
			}
		}
		CharacterStatisticsComponent.MapCombatDataType.Clear();
		for (int j = 0; j < combatTypeOpen.Count; j++)
		{
			CharacterStatisticsComponent.MapCombatDataType[combatTypeOpen[j]] = true;
		}
	}

	// Token: 0x060189DF RID: 100831 RVA: 0x006EFBE0 File Offset: 0x006EDDE0
	public static void SetCurrentAttacker(int index)
	{
		int num = (index >= 0 && index < CharacterStatisticsComponent.ArrayAttackerEntityId.Count) ? CharacterStatisticsComponent.ArrayAttackerEntityId[index] : 0;
		if (CharacterStatisticsComponent.CurrentAttackerId != num)
		{
			CharacterStatisticsComponent.ItemsResetInternal = true;
		}
		CharacterStatisticsComponent.CurrentAttackerId = num;
	}

	// Token: 0x060189E0 RID: 100832 RVA: 0x006EFC24 File Offset: 0x006EDE24
	public static void SetCurrentTarget(int index)
	{
		int num = (index >= 0 && index < CharacterStatisticsComponent.ArrayTargetEntityId.Count) ? CharacterStatisticsComponent.ArrayTargetEntityId[index] : 0;
		if (CharacterStatisticsComponent.CurrentTargetId != num)
		{
			CharacterStatisticsComponent.ItemsResetInternal = true;
		}
		CharacterStatisticsComponent.CurrentTargetId = num;
	}

	// Token: 0x17002151 RID: 8529
	// (get) Token: 0x060189E1 RID: 100833 RVA: 0x006EFC65 File Offset: 0x006EDE65
	public static bool ItemReset
	{
		get
		{
			return CharacterStatisticsComponent.ItemsResetInternal;
		}
	}

	// Token: 0x060189E2 RID: 100834 RVA: 0x006EFC6C File Offset: 0x006EDE6C
	public static void OnItemsResetFinished()
	{
		CharacterStatisticsComponent.ItemsResetInternal = false;
		CharacterStatisticsComponent.ListCombatData.Clear();
		foreach (CombatDataBase combatDataBase in CharacterStatisticsComponent.ListCombatDataAll)
		{
			if (CharacterStatisticsComponent.ListViewFilter(combatDataBase))
			{
				CharacterStatisticsComponent.ListCombatData.Add(combatDataBase);
			}
		}
	}

	// Token: 0x060189E3 RID: 100835 RVA: 0x006EFCDC File Offset: 0x006EDEDC
	public static TArray<string> GetSubItemsListView(int startIndex, int length)
	{
		TArray<string> tarray = new TArray<string>();
		for (int i = 0; i < length; i++)
		{
			tarray.Add(CharacterStatisticsComponent.ListCombatData[startIndex + i].ToString());
		}
		return tarray;
	}

	// Token: 0x060189E4 RID: 100836 RVA: 0x006EFD14 File Offset: 0x006EDF14
	public static int GetItemListViewCount()
	{
		return CharacterStatisticsComponent.ListCombatData.Count;
	}

	// Token: 0x17002152 RID: 8530
	// (get) Token: 0x060189E5 RID: 100837 RVA: 0x006EFD20 File Offset: 0x006EDF20
	private static List<CombatDataBase> ListCombatData
	{
		get
		{
			return CharacterStatisticsComponent._listCombatData;
		}
	}

	// Token: 0x17002153 RID: 8531
	// (get) Token: 0x060189E6 RID: 100838 RVA: 0x006EFD27 File Offset: 0x006EDF27
	private static List<CombatDataBase> ListCombatDataAll
	{
		get
		{
			return CharacterStatisticsComponent._listCombatDataAll;
		}
	}

	// Token: 0x060189E7 RID: 100839 RVA: 0x006EFD30 File Offset: 0x006EDF30
	private void OnCharHealCombat(int healMagnitude, Entity healer, Entity target, DamageResult parameters, RequirementPayload requirements)
	{
		if (!CharacterStatisticsComponent.IsCombatStarted)
		{
			return;
		}
		CombatDataHeal combatDataHeal = new CombatDataHeal(healer.Id, parameters.DamageData.Id, (int)parameters.Damage, requirements.SkillId.GetValueOrDefault(), target.Id);
		combatDataHeal.ToString();
		CharacterStatisticsComponent.ListCombatDataAll.Add(combatDataHeal);
		if (CharacterStatisticsComponent.ListViewFilter(combatDataHeal))
		{
			CharacterStatisticsComponent.ListCombatData.Add(combatDataHeal);
		}
	}

	// Token: 0x060189E8 RID: 100840 RVA: 0x006EFD9C File Offset: 0x006EDF9C
	private void OnCharDamageCombat(int damage, int elementId, FVectorDouble damagePosition, Entity attacker, Entity victim, bool bCritical, int damageTextType, bool bImmune, long damageId, long? bulletId = null, long? buffId = null, bool? isTargetKilled = null, [Nullable(2)] RequirementPayload requirements = null)
	{
		if (!CharacterStatisticsComponent.IsCombatStarted)
		{
			return;
		}
		CombatDataDamage combatDataDamage = new CombatDataDamage(attacker.Id, damageId, damage, ((requirements != null) ? requirements.SkillId : null).GetValueOrDefault(), victim.Id);
		combatDataDamage.ToString();
		CharacterStatisticsComponent.ListCombatDataAll.Add(combatDataDamage);
		if (CharacterStatisticsComponent.ListViewFilter(combatDataDamage))
		{
			CharacterStatisticsComponent.ListCombatData.Add(combatDataDamage);
		}
		if (isTargetKilled.GetValueOrDefault())
		{
			CombatDataKilled combatDataKilled = new CombatDataKilled(attacker.Id, victim.Id);
			combatDataKilled.ToString();
			CharacterStatisticsComponent.ListCombatDataAll.Add(combatDataKilled);
			if (CharacterStatisticsComponent.ListViewFilter(combatDataKilled))
			{
				CharacterStatisticsComponent.ListCombatData.Add(combatDataKilled);
			}
		}
	}

	// Token: 0x060189E9 RID: 100841 RVA: 0x006EFE50 File Offset: 0x006EE050
	private void OnBeginSkillCombat(int entityId, int skillId, bool isAutonomousProxy)
	{
		if (!CharacterStatisticsComponent.IsCombatStarted)
		{
			return;
		}
		CombatDataSkill combatDataSkill = new CombatDataSkill(base.Entity.Id, skillId, 0);
		combatDataSkill.ToString();
		CharacterStatisticsComponent.ListCombatDataAll.Add(combatDataSkill);
		if (CharacterStatisticsComponent.ListViewFilter(combatDataSkill))
		{
			CharacterStatisticsComponent.ListCombatData.Add(combatDataSkill);
		}
	}

	// Token: 0x060189EA RID: 100842 RVA: 0x006EFEA0 File Offset: 0x006EE0A0
	private void OnBuffAddedCombat(ActiveBuffInternal buff)
	{
		long? id = buff.Config.Id;
		if (!CharacterStatisticsComponent.IsCombatStarted || id == null || id.Value <= 0L)
		{
			return;
		}
		CombatDataBuffAdded combatDataBuffAdded = new CombatDataBuffAdded(buff.GetInstigator().Id, id.Value, buff.GetOwner().Id);
		combatDataBuffAdded.ToString();
		CharacterStatisticsComponent.ListCombatDataAll.Add(combatDataBuffAdded);
		if (CharacterStatisticsComponent.ListViewFilter(combatDataBuffAdded))
		{
			CharacterStatisticsComponent.ListCombatData.Add(combatDataBuffAdded);
		}
	}

	// Token: 0x060189EB RID: 100843 RVA: 0x006EFF20 File Offset: 0x006EE120
	private void OnBuffRemovedCombat(ActiveBuffInternal buff)
	{
		long? id = buff.Config.Id;
		if (!CharacterStatisticsComponent.IsCombatStarted || id == null || id.Value <= 0L)
		{
			return;
		}
		CombatDataBuffRemoved combatDataBuffRemoved = new CombatDataBuffRemoved(buff.GetInstigator().Id, id.Value, buff.GetOwner().Id);
		combatDataBuffRemoved.ToString();
		CharacterStatisticsComponent.ListCombatDataAll.Add(combatDataBuffRemoved);
		if (CharacterStatisticsComponent.ListViewFilter(combatDataBuffRemoved))
		{
			CharacterStatisticsComponent.ListCombatData.Add(combatDataBuffRemoved);
		}
	}

	// Token: 0x060189EC RID: 100844 RVA: 0x006EFFA0 File Offset: 0x006EE1A0
	private void OnCharReviveCombat()
	{
		if (!CharacterStatisticsComponent.IsCombatStarted)
		{
			return;
		}
		CombatDataRevive combatDataRevive = new CombatDataRevive(base.Entity.Id);
		combatDataRevive.ToString();
		CharacterStatisticsComponent.ListCombatDataAll.Add(combatDataRevive);
		if (CharacterStatisticsComponent.ListViewFilter(combatDataRevive))
		{
			CharacterStatisticsComponent.ListCombatData.Add(combatDataRevive);
		}
	}

	// Token: 0x060189ED RID: 100845 RVA: 0x006EFFEC File Offset: 0x006EE1EC
	private static bool ListViewFilter(CombatDataBase data)
	{
		return (CharacterStatisticsComponent.CurrentAttackerId <= 0 || CharacterStatisticsComponent.CurrentAttackerId == data.AttackerId) && (CharacterStatisticsComponent.CurrentTargetId <= 0 || CharacterStatisticsComponent.CurrentTargetId == data.TargetId) && (CharacterStatisticsComponent.MapCombatDataType.ContainsKey(ECombatDataType.Damage) || !(data is CombatDataDamage)) && (CharacterStatisticsComponent.MapCombatDataType.ContainsKey(ECombatDataType.Heal) || !(data is CombatDataHeal)) && (CharacterStatisticsComponent.MapCombatDataType.ContainsKey(ECombatDataType.SkillUsed) || !(data is CombatDataSkill)) && (CharacterStatisticsComponent.MapCombatDataType.ContainsKey(ECombatDataType.State) || (!(data is CombatDataBuffRemoved) && !(data is CombatDataBuffAdded))) && (CharacterStatisticsComponent.MapCombatDataType.ContainsKey(ECombatDataType.Kill) || !(data is CombatDataKilled)) && (CharacterStatisticsComponent.MapCombatDataType.ContainsKey(ECombatDataType.Revive) || !(data is CombatDataRevive));
	}

	// Token: 0x060189EE RID: 100846 RVA: 0x006F00BC File Offset: 0x006EE2BC
	public static void CreateStaticDefaultValue()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		int key = GameplayTagDefine.EGameplayTagId["功能.功能制作.白条生效"];
		dictionary[key] = "正常时间";
		int key2 = GameplayTagDefine.EGameplayTagId["功能.功能制作.狂暴生效"];
		dictionary[key2] = "狂暴时间";
		int key3 = GameplayTagDefine.EGameplayTagId["怪物.common.状态标识.瘫痪中"];
		dictionary[key3] = "瘫痪时间";
		int key4 = GameplayTagDefine.EGameplayTagId["Damage.Vulnerable"];
		dictionary[key4] = "脆弱时间";
		CharacterStatisticsComponent._monsterStageInfo = dictionary;
		Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
		key4 = GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"];
		dictionary2[key4] = "受击硬直";
		CharacterStatisticsComponent._roleStageInfo = dictionary2;
		CharacterStatisticsComponent._allStatisticsEnableEntityId = new List<int>();
		CharacterStatisticsComponent._damageStaticsBySkillTypeMap = new Dictionary<int, Dictionary<EDamageType, DamageStatisticsData>>();
		CharacterStatisticsComponent._damageStaticsByAttackTypeMap = new Dictionary<int, Dictionary<global::EAttackType, DamageStatisticsData>>();
		CharacterStatisticsComponent._healStaticsBySkillTypeMap = new Dictionary<int, Dictionary<EDamageType, DamageStatisticsData>>();
		CharacterStatisticsComponent._healStaticsByAttackTypeMap = new Dictionary<int, Dictionary<global::EAttackType, DamageStatisticsData>>();
		CharacterStatisticsComponent.TargetMaxCountSkillType = 0;
		CharacterStatisticsComponent.TargetMaxCountAttackType = 0;
		CharacterStatisticsComponent.HalfLengthRecordSquared = 25000000.0;
		CharacterStatisticsComponent._characterOperationRecordMap = new Dictionary<int, CharacterOperationRecord>();
		CharacterStatisticsComponent.OpenOperationRecordInternal = false;
		CharacterStatisticsComponent._inAreaEntityId = new List<int>();
		CharacterStatisticsComponent._mapCombatDataType = new Dictionary<ECombatDataType, bool>();
		CharacterStatisticsComponent._arrayAttackerEntityId = new List<int>();
		CharacterStatisticsComponent._arrayTargetEntityId = new List<int>();
		CharacterStatisticsComponent.CurrentAttackerId = 0;
		CharacterStatisticsComponent.CurrentTargetId = 0;
		CharacterStatisticsComponent.ItemsResetInternal = false;
		CharacterStatisticsComponent._listCombatData = new List<CombatDataBase>();
		CharacterStatisticsComponent._listCombatDataAll = new List<CombatDataBase>();
	}

	// Token: 0x060189EF RID: 100847 RVA: 0x006F0214 File Offset: 0x006EE414
	public static void ResetStaticDefaultValue()
	{
		CharacterStatisticsComponent._monsterStageInfo = null;
		CharacterStatisticsComponent._roleStageInfo = null;
		CharacterStatisticsComponent._allStatisticsEnableEntityId = null;
		CharacterStatisticsComponent._damageStaticsBySkillTypeMap = null;
		CharacterStatisticsComponent._damageStaticsByAttackTypeMap = null;
		CharacterStatisticsComponent._healStaticsBySkillTypeMap = null;
		CharacterStatisticsComponent._healStaticsByAttackTypeMap = null;
		CharacterStatisticsComponent.TargetMaxCountSkillType = 0;
		CharacterStatisticsComponent.TargetMaxCountAttackType = 0;
		CharacterStatisticsComponent.HalfLengthRecordSquared = 25000000.0;
		CharacterStatisticsComponent._characterOperationRecordMap = null;
		CharacterStatisticsComponent.OpenOperationRecordInternal = false;
		CharacterStatisticsComponent._inAreaEntityId = null;
		CharacterStatisticsComponent.IsCombatStarted = false;
		CharacterStatisticsComponent._mapCombatDataType = null;
		CharacterStatisticsComponent._arrayAttackerEntityId = null;
		CharacterStatisticsComponent._arrayTargetEntityId = null;
		CharacterStatisticsComponent.CurrentAttackerId = 0;
		CharacterStatisticsComponent.CurrentTargetId = 0;
		CharacterStatisticsComponent.ItemsResetInternal = false;
		CharacterStatisticsComponent._listCombatData = null;
		CharacterStatisticsComponent._listCombatDataAll = null;
	}

	// Token: 0x060189F0 RID: 100848 RVA: 0x006F02B0 File Offset: 0x006EE4B0
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterStatisticsComponent characterStatisticsComponent = (CharacterStatisticsComponent)componentTemplate;
		if (base.CanResetComponentProperty("StatisticsEnable"))
		{
			this.StatisticsEnable = characterStatisticsComponent.StatisticsEnable;
		}
		return (!base.CanResetComponentProperty("OperationBeginTimeMap") || characterStatisticsComponent.OperationBeginTimeMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, double?>>(this.OperationBeginTimeMap), "OperationBeginTimeMap")) && (!base.CanResetComponentProperty("TagOperationBeginTimeMap") || characterStatisticsComponent.TagOperationBeginTimeMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, double>>(this.TagOperationBeginTimeMap), "TagOperationBeginTimeMap")) && (!base.CanResetComponentProperty("MoveOperationBeginTimeMap") || characterStatisticsComponent.MoveOperationBeginTimeMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<global::ECharMoveState, double?>>(this.MoveOperationBeginTimeMap), "MoveOperationBeginTimeMap")) && (!base.CanResetComponentProperty("ListenOperationTasks") || characterStatisticsComponent.ListenOperationTasks == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.ListenOperationTasks), "ListenOperationTasks"));
	}

	// Token: 0x0400BE72 RID: 48754
	[StaticVariableRuleIgnore]
	internal static readonly string[] skillTypeToString = new string[]
	{
		"常态攻击",
		"共鸣技能",
		"共鸣解放",
		"固有技能",
		"连携技能",
		"异能力",
		"声骸技能"
	};

	// Token: 0x0400BE73 RID: 48755
	[StaticVariableRuleIgnore]
	private static readonly string[] attackTypeToString = new string[]
	{
		"普攻伤害",
		"蓄力攻击伤害",
		"大招伤害",
		"QTE伤害",
		"普通技能伤害",
		"战斗幻象技能伤害",
		"探索幻象技能伤害"
	};

	// Token: 0x0400BE74 RID: 48756
	private bool StatisticsEnable;

	// Token: 0x0400BE75 RID: 48757
	[Nullable(2)]
	private static List<int> _allStatisticsEnableEntityId;

	// Token: 0x0400BE76 RID: 48758
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<int, Dictionary<EDamageType, DamageStatisticsData>> _damageStaticsBySkillTypeMap;

	// Token: 0x0400BE77 RID: 48759
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<int, Dictionary<global::EAttackType, DamageStatisticsData>> _damageStaticsByAttackTypeMap;

	// Token: 0x0400BE78 RID: 48760
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<int, Dictionary<EDamageType, DamageStatisticsData>> _healStaticsBySkillTypeMap;

	// Token: 0x0400BE79 RID: 48761
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<int, Dictionary<global::EAttackType, DamageStatisticsData>> _healStaticsByAttackTypeMap;

	// Token: 0x0400BE7A RID: 48762
	private static readonly string TargetTitleFormat = ",目标{0}类型,目标{1}名称,目标{2}配置ID,目标{3}单位Id,目标{4}伤害";

	// Token: 0x0400BE7B RID: 48763
	private static int TargetMaxCountSkillType = 0;

	// Token: 0x0400BE7C RID: 48764
	private static int TargetMaxCountAttackType = 0;

	// Token: 0x0400BE7D RID: 48765
	public static double HalfLengthRecordSquared = 0.0;

	// Token: 0x0400BE7E RID: 48766
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, CharacterOperationRecord> _characterOperationRecordMap;

	// Token: 0x0400BE7F RID: 48767
	private readonly Dictionary<long, double?> OperationBeginTimeMap = new Dictionary<long, double?>();

	// Token: 0x0400BE80 RID: 48768
	private readonly Dictionary<int, double> TagOperationBeginTimeMap = new Dictionary<int, double>();

	// Token: 0x0400BE81 RID: 48769
	private readonly Dictionary<global::ECharMoveState, double?> MoveOperationBeginTimeMap = new Dictionary<global::ECharMoveState, double?>();

	// Token: 0x0400BE82 RID: 48770
	private static bool OpenOperationRecordInternal = false;

	// Token: 0x0400BE83 RID: 48771
	private readonly List<ITagTask> ListenOperationTasks = new List<ITagTask>();

	// Token: 0x0400BE84 RID: 48772
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<global::ECharMoveState, string> MoveStateToString;

	// Token: 0x0400BE85 RID: 48773
	[StaticVariableRuleIgnore]
	private static readonly string[] SkillGenreName;

	// Token: 0x0400BE86 RID: 48774
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, string> _monsterStageInfo;

	// Token: 0x0400BE87 RID: 48775
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, string> _roleStageInfo;

	// Token: 0x0400BE88 RID: 48776
	[Nullable(2)]
	private static List<int> _inAreaEntityId;

	// Token: 0x0400BE89 RID: 48777
	private static readonly string OperationRecordTitle;

	// Token: 0x0400BE8A RID: 48778
	private static bool IsCombatStarted;

	// Token: 0x0400BE8B RID: 48779
	[Nullable(2)]
	private static Dictionary<ECombatDataType, bool> _mapCombatDataType;

	// Token: 0x0400BE8C RID: 48780
	[Nullable(2)]
	private static List<int> _arrayAttackerEntityId;

	// Token: 0x0400BE8D RID: 48781
	[Nullable(2)]
	private static List<int> _arrayTargetEntityId;

	// Token: 0x0400BE8E RID: 48782
	private static int CurrentAttackerId;

	// Token: 0x0400BE8F RID: 48783
	private static int CurrentTargetId;

	// Token: 0x0400BE90 RID: 48784
	private static bool ItemsResetInternal;

	// Token: 0x0400BE91 RID: 48785
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<CombatDataBase> _listCombatData;

	// Token: 0x0400BE92 RID: 48786
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<CombatDataBase> _listCombatDataAll;
}
