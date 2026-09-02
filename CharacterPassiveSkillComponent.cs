using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Utils;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02002EC4 RID: 11972
[NullableContext(1)]
[Nullable(0)]
public class CharacterPassiveSkillComponent : EntityComponent
{
	// Token: 0x0601895C RID: 100700 RVA: 0x006EAF0C File Offset: 0x006E910C
	protected override bool OnInit()
	{
		this.triggerComp = base.Entity.CheckGetComponent<CharacterTriggerComponent>();
		this.buffComp = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		this.cdComp = base.Entity.GetComponent<BaseSkillCdComponent>();
		this.actorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.Context = new ContextParam
		{
			SkillId = 0L,
			Owner = base.Entity,
			BuffComp = this.buffComp,
			PassiveSkillComp = this
		};
		return true;
	}

	// Token: 0x0601895D RID: 100701 RVA: 0x006EAF90 File Offset: 0x006E9190
	protected override bool OnStart()
	{
		return true;
	}

	// Token: 0x0601895E RID: 100702 RVA: 0x006EAF94 File Offset: 0x006E9194
	protected override void OnActivate()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		Dictionary<string, EntityComponentPb> dictionary = (component != null) ? component.ComponentDataMap : null;
		if (dictionary == null)
		{
			return;
		}
		EntityComponentPb entityComponentPb;
		if (!dictionary.TryGetValue("PassiveSkillComponentPb", out entityComponentPb) && !dictionary.TryGetValue("Proto_PassiveSkillComponentPb", out entityComponentPb))
		{
			return;
		}
		PassiveSkillComponentPb passiveSkillComponentPb = entityComponentPb.PassiveSkillComponentPb;
		if (passiveSkillComponentPb == null)
		{
			return;
		}
		foreach (PassiveSkillItemPb passiveSkillItemPb in passiveSkillComponentPb.PassiveSkillItemPbList)
		{
			CombatCommon combatCommon = passiveSkillItemPb.CombatCommon;
			long combatMessageId = (combatCommon != null) ? combatCommon.MessageId : 0L;
			this.LearnPassiveSkill(passiveSkillItemPb.SkillId, new AddPassiveSkillParam
			{
				CombatMessageId = combatMessageId
			});
		}
	}

	// Token: 0x0601895F RID: 100703 RVA: 0x006EB054 File Offset: 0x006E9254
	protected override bool OnClear()
	{
		bool result;
		using (PoolArray<long> poolArray = this.SkillMap.Keys.ToPoolArray<long>())
		{
			for (int i = 0; i < poolArray.Count; i++)
			{
				this.ForgetPassiveSkill(poolArray[i], false);
			}
			result = true;
		}
		return result;
	}

	// Token: 0x06018960 RID: 100704 RVA: 0x006EB0B8 File Offset: 0x006E92B8
	protected override void OnTick(float delta)
	{
		this.LockMap.Clear();
	}

	// Token: 0x06018961 RID: 100705 RVA: 0x006EB0C5 File Offset: 0x006E92C5
	public PassiveSkillData[] GetAllPassiveSkills()
	{
		return this.SkillMap.Values.ToArray<PassiveSkillData>();
	}

	// Token: 0x06018962 RID: 100706 RVA: 0x006EB0D7 File Offset: 0x006E92D7
	public bool HasSkill(long skillId)
	{
		return this.SkillMap.ContainsKey(skillId);
	}

	// Token: 0x06018963 RID: 100707 RVA: 0x006EB0E5 File Offset: 0x006E92E5
	[NullableContext(2)]
	public PassiveSkillData GetSKill(long skillId)
	{
		return this.SkillMap.GetValueOrDefault(skillId);
	}

	// Token: 0x06018964 RID: 100708 RVA: 0x006EB0F3 File Offset: 0x006E92F3
	private bool IsPassiveSkillInCd(long skillId, int cdEntityId)
	{
		BaseSkillCdComponent baseSkillCdComponent = this.cdComp;
		return baseSkillCdComponent != null && baseSkillCdComponent.IsPassiveSkillInCd(skillId, cdEntityId);
	}

	// Token: 0x06018965 RID: 100709 RVA: 0x006EB108 File Offset: 0x006E9308
	private void StartPassiveCd(long skillId, int cdEntityId)
	{
		BaseSkillCdComponent baseSkillCdComponent = this.cdComp;
		if (baseSkillCdComponent == null)
		{
			return;
		}
		baseSkillCdComponent.StartPassiveCd(skillId, cdEntityId, -1f);
	}

	// Token: 0x06018966 RID: 100710 RVA: 0x006EB122 File Offset: 0x006E9322
	private PassiveSkill? GetPassiveSkillConfig(long skillId)
	{
		return ConfigPassiveSkillById.GetConfig(skillId, true);
	}

	// Token: 0x06018967 RID: 100711 RVA: 0x006EB12C File Offset: 0x006E932C
	[return: Nullable(2)]
	private unsafe Entity GetEntityByKey(long skillId, string targetKey, [Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, TFormulaValue> parameters, [Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, TFormulaValue> extraParams)
	{
		object obj = base.Entity;
		if (!string.IsNullOrEmpty(targetKey))
		{
			TFormulaValue tformulaValue;
			TFormulaValue tformulaValue2;
			if (parameters != null && parameters.TryGetValue(targetKey, out tformulaValue))
			{
				Entity entity;
				obj = (tformulaValue.TryGetEntity(out entity) ? entity : null);
			}
			else if (extraParams != null && extraParams.TryGetValue(targetKey, out tformulaValue2))
			{
				Entity entity2;
				obj = (tformulaValue2.TryGetEntity(out entity2) ? entity2 : null);
			}
		}
		Entity entity3 = obj as Entity;
		if (entity3 != null)
		{
			return entity3;
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
		Entity entity4 = base.Entity;
		string message = "被动技能Entity非法";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetKey", targetKey);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillId", skillId);
		instance.Error(flag, entity4, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return null;
	}

	// Token: 0x06018968 RID: 100712 RVA: 0x006EB1F3 File Offset: 0x006E93F3
	private int GetCdEntityId(PassiveSkill config, Entity cdEntity)
	{
		if (!config.IsShareAllCdSkill || config.CDType != "Owner")
		{
			return cdEntity.Id;
		}
		return 0;
	}

	// Token: 0x06018969 RID: 100713 RVA: 0x006EB21C File Offset: 0x006E941C
	private static bool IsWhitelistSkill(long skillId)
	{
		for (int i = 0; i < CharacterPassiveSkillComponent.GlobalTriggerWhitelist.Length; i++)
		{
			if (CharacterPassiveSkillComponent.GlobalTriggerWhitelist[i] == skillId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601896A RID: 100714 RVA: 0x006EB248 File Offset: 0x006E9448
	public bool CheckAddSkillHasAuthority(PassiveSkill config)
	{
		return this.buffComp.HasBuffAuthority() || config.ActionExecuteFlag == 2;
	}

	// Token: 0x0601896B RID: 100715 RVA: 0x006EB263 File Offset: 0x006E9463
	public bool CheckSkillHasAuthority(PassiveSkill config)
	{
		return this.buffComp.HasBuffAuthority() || (Convert.ToInt32(config.ActionExecuteFlag) == 2 && this.actorComp.IsAutonomousProxy);
	}

	// Token: 0x0601896C RID: 100716 RVA: 0x006EB294 File Offset: 0x006E9494
	public unsafe bool LearnPassiveSkill(long skillId, AddPassiveSkillParam param)
	{
		PassiveSkill? config = this.GetPassiveSkillConfig(skillId);
		if (config == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			Entity entity = base.Entity;
			string message = "被动技能配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", skillId);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (this.HasSkill(skillId) || !this.CheckAddSkillHasAuthority(config.Value))
		{
			return false;
		}
		if (Convert.ToInt32(config.Value.ActionExecuteFlag) == 1)
		{
			if (param.NeedBroadcast.GetValueOrDefault())
			{
				ControllerBase<SkillMessageController>.Instance.PassiveSkillAddRequest(base.Entity, skillId, param.PreMessageId);
			}
			return true;
		}
		ETriggerEvent etriggerEvent;
		if (string.IsNullOrEmpty(config.Value.TriggerType) || !Enum.TryParse<ETriggerEvent>(config.Value.TriggerType, out etriggerEvent))
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.PassiveSkill;
			Entity entity2 = base.Entity;
			string message2 = "被动技能配置错误，缺少触发类型";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("skillId", skillId);
			instance2.Error(flag2, entity2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		if (etriggerEvent == ETriggerEvent.GlobalDamageTrigger && !CharacterPassiveSkillComponent.IsWhitelistSkill(skillId))
		{
			CombatLog instance3 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.PassiveSkill;
			Entity entity3 = base.Entity;
			string message3 = "禁止白名单之外的被动使用全局伤害监听";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("skillId", skillId);
			instance3.Error(flag3, entity3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.ZQR;
		string message4 = "角色添加被动技能";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("owner", base.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillId", skillId);
		instance4.Info(module, author, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		int num = this.triggerComp.AddTrigger(new TriggerConfigData
		{
			Type = config.Value.TriggerType,
			Preset = config.Value.TriggerPreset(),
			Params = config.Value.TriggerParams,
			Formula = config.Value.TriggerFormula,
			ExecuteType = (EExecuteType)Convert.ToInt32(config.Value.ExecuteType)
		}, delegate([Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<string, TFormulaValue> parameters, [Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<string, TFormulaValue> extraParams)
		{
			Entity entityByKey = this.GetEntityByKey(skillId, config.Value.InstigatorType, parameters, extraParams);
			if (entityByKey == null)
			{
				return;
			}
			Entity entityByKey2 = this.GetEntityByKey(skillId, config.Value.CDType, parameters, extraParams);
			if (entityByKey2 == null)
			{
				return;
			}
			int cdEntityId = this.GetCdEntityId(config.Value, entityByKey2);
			if (!this.CheckSkillHasAuthority(config.Value) || this.IsPassiveSkillInCd(skillId, cdEntityId))
			{
				return;
			}
			this.ExecuteAction(skillId, entityByKey, cdEntityId, extraParams);
		}, delegate
		{
			if (config.Value.CDType == "Owner")
			{
				int cdEntityId = this.GetCdEntityId(config.Value, this.Entity);
				if (this.IsPassiveSkillInCd(skillId, cdEntityId))
				{
					return false;
				}
			}
			return this.CheckSkillHasAuthority(config.Value);
		});
		this.SkillMap[skillId] = new PassiveSkillData
		{
			SkillId = skillId,
			TriggerHandle = num,
			Actions = this.ParseActions(config.Value, skillId),
			TargetKey = config.Value.InstigatorType,
			CombatMessageId = new long?(param.CombatMessageId)
		};
		this.OnPassiveSkillAdded(skillId, num, config.Value, param);
		return true;
	}

	// Token: 0x0601896D RID: 100717 RVA: 0x006EB5DC File Offset: 0x006E97DC
	public unsafe void ForgetPassiveSkill(long skillId, bool needBroadcast = false)
	{
		PassiveSkill? passiveSkillConfig = this.GetPassiveSkillConfig(skillId);
		if (passiveSkillConfig != null && Convert.ToInt32(passiveSkillConfig.Value.ActionExecuteFlag) == 1)
		{
			ControllerBase<SkillMessageController>.Instance.PassiveSkillRemoveRequest(base.Entity, skillId, null, null);
			return;
		}
		PassiveSkillData passiveSkillData;
		if (!this.SkillMap.TryGetValue(skillId, out passiveSkillData))
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.ZQR;
		string message = "角色失去被动技能";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("owner", base.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillId", skillId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.triggerComp.RemoveTrigger(passiveSkillData.TriggerHandle);
		foreach (SkillActionData skillActionData in passiveSkillData.Actions)
		{
			if (skillActionData.Action == ESkillAction.Customize)
			{
				Formula formula = skillActionData.Formula;
				if (formula != null)
				{
					formula.Dispose();
				}
			}
		}
		this.SkillMap.Remove(skillId);
		this.OnPassiveSkillRemoved(skillId, needBroadcast);
	}

	// Token: 0x0601896E RID: 100718 RVA: 0x006EB734 File Offset: 0x006E9934
	public void SetPassiveSkillActive(long skillId, bool active)
	{
		PassiveSkillData passiveSkillData;
		if (!this.SkillMap.TryGetValue(skillId, out passiveSkillData))
		{
			return;
		}
		if (passiveSkillData.TriggerHandle > 0)
		{
			this.triggerComp.SetTriggerActive(passiveSkillData.TriggerHandle, active);
		}
	}

	// Token: 0x0601896F RID: 100719 RVA: 0x006EB770 File Offset: 0x006E9970
	protected List<SkillActionData> ParseActions(PassiveSkill config, long skillId)
	{
		List<SkillActionData> list = new List<SkillActionData>();
		SkillActionData skillActionData = this.ParseAction(config, skillId);
		if (skillActionData != null)
		{
			list.Add(skillActionData);
		}
		foreach (long skillId2 in config.SubSkillActionIter())
		{
			PassiveSkill? passiveSkillConfig = this.GetPassiveSkillConfig(skillId2);
			if (passiveSkillConfig != null)
			{
				SkillActionData skillActionData2 = this.ParseAction(passiveSkillConfig.Value, skillId);
				if (skillActionData2 != null)
				{
					list.Add(skillActionData2);
				}
			}
		}
		return list;
	}

	// Token: 0x06018970 RID: 100720 RVA: 0x006EB800 File Offset: 0x006E9A00
	[NullableContext(2)]
	protected SkillActionData ParseAction(PassiveSkill config, long skillId)
	{
		ESkillAction action;
		if (!Enum.TryParse<ESkillAction>(Convert.ToString(config.SkillAction), out action))
		{
			return null;
		}
		string[] array = config.SkillActionParams() ?? Array.Empty<string>();
		SkillActionData skillActionData = new SkillActionData
		{
			Action = action
		};
		switch (action)
		{
		case ESkillAction.AddBullet:
			skillActionData.BulletRowNames = new string[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				skillActionData.BulletRowNames[i] = array[i].Trim();
			}
			return skillActionData;
		case ESkillAction.RemoveBullet:
			skillActionData.BulletRowNames = new string[array.Length];
			skillActionData.SummonChild = new bool[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				string[] array2 = array[j].Split('#', StringSplitOptions.None);
				skillActionData.BulletRowNames[j] = ((array2.Length != 0) ? array2[0].Trim() : string.Empty);
				skillActionData.SummonChild[j] = (array2.Length > 1 && array2[1].Trim() == "1");
			}
			return skillActionData;
		case ESkillAction.AddBuff:
			skillActionData.BuffId = new long[array.Length];
			for (int k = 0; k < array.Length; k++)
			{
				skillActionData.BuffId[k] = Convert.ToInt64(array[k]);
			}
			return skillActionData;
		case ESkillAction.RemoveBuff:
			skillActionData.BuffId = new long[array.Length];
			skillActionData.StackCount = new int[array.Length];
			for (int l = 0; l < array.Length; l++)
			{
				string[] array3 = array[l].Split('#', StringSplitOptions.None);
				skillActionData.BuffId[l] = ((array3.Length != 0) ? Convert.ToInt64(array3[0]) : 0L);
				skillActionData.StackCount[l] = ((array3.Length > 1) ? Convert.ToInt32(array3[1]) : -1);
			}
			return skillActionData;
		case ESkillAction.StartSkill:
			skillActionData.SkillId = ((array.Length != 0) ? Convert.ToInt32(array[0]) : 0);
			return skillActionData;
		case ESkillAction.LockOn:
			skillActionData.IsHardLock = (array.Length != 0 && array[0] == "1");
			skillActionData.LockOnConfigId = ((array.Length > 1) ? Convert.ToInt32(array[1]) : 0);
			skillActionData.SkillTargetPriority = ((array.Length > 2) ? ((ESkillTargetPriority)Convert.ToInt32(array[2])) : ESkillTargetPriority.系统设置);
			skillActionData.ShowTarget = (array.Length <= 3 || array[3] == "1");
			skillActionData.GlobalTarget = (array.Length > 4 && array[4] == "1");
			return skillActionData;
		case ESkillAction.Customize:
			skillActionData.Formula = CharacterPassiveSkillCustomAction.AddCustomAction(new PassiveSkill?(config), base.Entity, this.triggerComp.TriggerFormulaFunc);
			return skillActionData;
		case ESkillAction.ReduceSkillCd:
			skillActionData.ReduceSkillId = new long[array.Length];
			skillActionData.CdResetType = new ESkillCdReduceType[array.Length];
			skillActionData.DecreaseMagnitude = new float[array.Length];
			skillActionData.DecreaseRatio = new float[array.Length];
			for (int m = 0; m < array.Length; m++)
			{
				string[] array4 = array[m].Split('#', StringSplitOptions.None);
				skillActionData.ReduceSkillId[m] = ((array4.Length != 0) ? Convert.ToInt64(array4[0]) : 0L);
				skillActionData.CdResetType[m] = (ESkillCdReduceType)((array4.Length > 1) ? Convert.ToInt32(array4[1]) : 0);
				skillActionData.DecreaseMagnitude[m] = ((array4.Length > 2) ? Convert.ToSingle(array4[2]) : 0f);
				skillActionData.DecreaseRatio[m] = ((array4.Length > 3) ? Convert.ToSingle(array4[3]) : 0f);
			}
			return skillActionData;
		default:
			return null;
		}
	}

	// Token: 0x06018971 RID: 100721 RVA: 0x006EBB60 File Offset: 0x006E9D60
	protected unsafe void ExecuteAction(long skillId, Entity targetEntity, int passiveCdEntityId, [Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, TFormulaValue> extraParams)
	{
		if (this.LockMap.Contains(skillId))
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			Entity entity = base.Entity;
			string message = "被动技能在同一次调用栈中重复触发，需要检查技能配置";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", skillId);
			PassiveSkill? passiveSkill;
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("desc", ((this.GetPassiveSkillConfig(skillId) != null) ? passiveSkill.GetValueOrDefault().SkillDesc : null) ?? string.Empty);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("current executing skill ids", new List<long>(this.LockMap));
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		PassiveSkillData passiveSkillData;
		if (!this.SkillMap.TryGetValue(skillId, out passiveSkillData))
		{
			return;
		}
		this.StartPassiveCd(skillId, passiveCdEntityId);
		this.LockMap.Add(skillId);
		for (int i = 0; i < passiveSkillData.Actions.Count; i++)
		{
			SkillActionData skillActionData = passiveSkillData.Actions[i];
			switch (skillActionData.Action)
			{
			case ESkillAction.AddBullet:
			{
				BaseActorComponent component = targetEntity.GetComponent<BaseActorComponent>();
				FTransformDouble? initialTransform = (component != null) ? new FTransformDouble?(component.ActorTransform) : null;
				if (initialTransform == null)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.PassiveSkill;
					Entity entity2 = base.Entity;
					string message2 = "被动技能目标没有ActorTransform";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("skillId", skillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("targetEntity", targetEntity.Id);
					instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				else
				{
					for (int j = 0; j < skillActionData.BulletRowNames.Length; j++)
					{
						ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(base.Entity, skillActionData.BulletRowNames[j], initialTransform, null, passiveSkillData.CombatMessageId, global::EBulletCreateSource.Others);
					}
				}
				break;
			}
			case ESkillAction.RemoveBullet:
			{
				IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(base.Entity.Id);
				if (bulletSetByAttacker != null)
				{
					List<ValueTuple<long, bool>> list = new List<ValueTuple<long, bool>>();
					foreach (BulletEntity bulletEntity in bulletSetByAttacker)
					{
						BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
						for (int k = 0; k < skillActionData.BulletRowNames.Length; k++)
						{
							if (skillActionData.BulletRowNames[k] == bulletInfo.BulletRowName)
							{
								bool item = k < skillActionData.SummonChild.Length && skillActionData.SummonChild[k];
								list.Add(new ValueTuple<long, bool>((long)bulletInfo.BulletEntityId, item));
								break;
							}
						}
					}
					for (int l = 0; l < list.Count; l++)
					{
						ControllerBase<BulletController>.Instance.DestroyBullet(Convert.ToInt32(list[l].Item1), list[l].Item2, EBulletDestroyReason.FromPassiveSkill, false);
					}
				}
				break;
			}
			case ESkillAction.AddBuff:
			{
				CharacterBuffComponent component2 = targetEntity.GetComponent<CharacterBuffComponent>();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("被动技能");
				defaultInterpolatedStringHandler.AppendFormatted<long>(skillId);
				defaultInterpolatedStringHandler.AppendLiteral("添加");
				string reason = defaultInterpolatedStringHandler.ToStringAndClear();
				for (int m = 0; m < skillActionData.BuffId.Length; m++)
				{
					if (component2 != null)
					{
						component2.AddBuff(skillActionData.BuffId[m], new AddBuffParam
						{
							InstigatorId = this.buffComp.CreatureDataId,
							PreMessageId = passiveSkillData.CombatMessageId,
							Reason = reason
						});
					}
				}
				break;
			}
			case ESkillAction.RemoveBuff:
			{
				CharacterBuffComponent component3 = targetEntity.GetComponent<CharacterBuffComponent>();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("被动技能");
				defaultInterpolatedStringHandler.AppendFormatted<long>(skillId);
				defaultInterpolatedStringHandler.AppendLiteral("移除");
				string reason2 = defaultInterpolatedStringHandler.ToStringAndClear();
				for (int n = 0; n < skillActionData.BuffId.Length; n++)
				{
					int stackCount = (n < skillActionData.StackCount.Length) ? skillActionData.StackCount[n] : -1;
					if (component3 != null)
					{
						component3.RemoveBuff(skillActionData.BuffId[n], stackCount, reason2, null, null, null);
					}
				}
				break;
			}
			case ESkillAction.StartSkill:
			{
				CharacterSkillComponent component4 = targetEntity.GetComponent<CharacterSkillComponent>();
				if (component4 != null)
				{
					component4.BeginSkillAsync(skillActionData.SkillId, new SkillParam
					{
						ContextId = passiveSkillData.CombatMessageId,
						Reason = "PassiveSkillComponent.ExecuteAction"
					});
				}
				break;
			}
			case ESkillAction.LockOn:
			{
				CharacterLockOnComponent component5 = targetEntity.GetComponent<CharacterLockOnComponent>();
				CharacterSkillComponent component6 = targetEntity.GetComponent<CharacterSkillComponent>();
				if (skillActionData.IsHardLock)
				{
					if (component5 != null)
					{
						component5.EnterLockDirection();
					}
				}
				else if (component6 != null)
				{
					component6.LockOnTargetAndSetShow(new SSkillTarget
					{
						LockOnConfigId = skillActionData.LockOnConfigId,
						SkillTargetPriority = skillActionData.SkillTargetPriority,
						ShowTarget = skillActionData.ShowTarget,
						GlobalTarget = skillActionData.GlobalTarget
					}, true);
				}
				break;
			}
			case ESkillAction.Customize:
			{
				this.Context.SkillId = skillId;
				Formula formula = skillActionData.Formula;
				if (formula != null)
				{
					formula.Evaluate(extraParams, this.Context);
				}
				break;
			}
			case ESkillAction.ReduceSkillCd:
			{
				CharacterSkillCdComponent component7 = targetEntity.GetComponent<CharacterSkillCdComponent>();
				if (component7 != null)
				{
					for (int num = 0; num < skillActionData.ReduceSkillId.Length; num++)
					{
						float num2 = (num < skillActionData.DecreaseMagnitude.Length) ? skillActionData.DecreaseMagnitude[num] : 0f;
						float changeTimePercentage = -((num < skillActionData.DecreaseRatio.Length) ? skillActionData.DecreaseRatio[num] : 0f) * 0.0001f;
						float modifyTime = -num2;
						if (num < skillActionData.CdResetType.Length && skillActionData.CdResetType[num] == ESkillCdReduceType.SpecifiedSkillId)
						{
							component7.ModifyCdTime(new long[]
							{
								skillActionData.ReduceSkillId[num]
							}, modifyTime, changeTimePercentage);
						}
						else if (num < skillActionData.CdResetType.Length && skillActionData.CdResetType[num] == ESkillCdReduceType.SpecifiedSkillGenre)
						{
							component7.ModifyCdTimeBySkillGenres(new int[]
							{
								Convert.ToInt32(skillActionData.ReduceSkillId[num])
							}, modifyTime, changeTimePercentage);
						}
					}
				}
				break;
			}
			}
		}
		this.LockMap.Remove(skillId);
	}

	// Token: 0x06018972 RID: 100722 RVA: 0x006EC1C4 File Offset: 0x006EA3C4
	[NullableContext(2)]
	protected void OnPassiveSkillAdded(long skillId, int handle, PassiveSkill config, AddPassiveSkillParam param = null)
	{
		Trigger trigger = this.triggerComp.GetTrigger(handle);
		if (trigger != null)
		{
			Trigger trigger2 = trigger;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendLiteral("被动");
			defaultInterpolatedStringHandler.AppendFormatted<long>(skillId);
			trigger2.SetDebugName(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		BaseSkillCdComponent baseSkillCdComponent = this.cdComp;
		if (baseSkillCdComponent != null)
		{
			baseSkillCdComponent.InitPassiveSkill(config);
		}
		if (param != null && param.NeedBroadcast.GetValueOrDefault())
		{
			long value = ControllerBase<SkillMessageController>.Instance.PassiveSkillAddRequest(base.Entity, skillId, param.PreMessageId);
			PassiveSkillData passiveSkillData;
			if (this.SkillMap.TryGetValue(skillId, out passiveSkillData))
			{
				passiveSkillData.CombatMessageId = new long?(value);
			}
		}
		if (config.IsDefaultActivated)
		{
			this.triggerComp.SetTriggerActive(handle, true);
		}
	}

	// Token: 0x06018973 RID: 100723 RVA: 0x006EC280 File Offset: 0x006EA480
	protected void OnPassiveSkillRemoved(long skillId, bool needBroadcast)
	{
		if (needBroadcast)
		{
			ControllerBase<SkillMessageController>.Instance.PassiveSkillRemoveRequest(base.Entity, skillId, null, null);
		}
	}

	// Token: 0x06018974 RID: 100724 RVA: 0x006EC2B4 File Offset: 0x006EA4B4
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.PassiveSkillAddNotify, false, false)]
	public static void PassiveSkillAddNotify(Entity entity, [Nullable(1)] PassiveSkillAddNotify data, CombatCommon combatCommon = null)
	{
		CharacterPassiveSkillComponent characterPassiveSkillComponent = (entity != null) ? entity.GetComponent<CharacterPassiveSkillComponent>() : null;
		foreach (PassiveSkillItemPb passiveSkillItemPb in data.PassiveSkillItemPbList)
		{
			if (characterPassiveSkillComponent != null)
			{
				characterPassiveSkillComponent.LearnPassiveSkill(passiveSkillItemPb.SkillId, new AddPassiveSkillParam
				{
					CombatMessageId = passiveSkillItemPb.CombatCommon.MessageId
				});
			}
		}
	}

	// Token: 0x06018975 RID: 100725 RVA: 0x006EC330 File Offset: 0x006EA530
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.PassiveSkillRemoveNotify, false, false)]
	public static void PassiveSkillRemoveNotify(Entity entity, [Nullable(1)] PassiveSkillRemoveNotify data, CombatCommon combatCommon = null)
	{
		CharacterPassiveSkillComponent characterPassiveSkillComponent = (entity != null) ? entity.GetComponent<CharacterPassiveSkillComponent>() : null;
		foreach (long skillId in data.SkillIdList)
		{
			if (characterPassiveSkillComponent != null)
			{
				characterPassiveSkillComponent.ForgetPassiveSkill(skillId, false);
			}
		}
	}

	// Token: 0x06018976 RID: 100726 RVA: 0x006EC390 File Offset: 0x006EA590
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterPassiveSkillComponent characterPassiveSkillComponent = (CharacterPassiveSkillComponent)componentTemplate;
		if (base.CanResetComponentProperty("triggerComp"))
		{
			if (characterPassiveSkillComponent.triggerComp == null)
			{
				this.triggerComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterTriggerComponent>(this.triggerComp), "triggerComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("buffComp"))
		{
			if (characterPassiveSkillComponent.buffComp == null)
			{
				this.buffComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.buffComp), "buffComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("cdComp"))
		{
			if (characterPassiveSkillComponent.cdComp == null)
			{
				this.cdComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseSkillCdComponent>(this.cdComp), "cdComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("actorComp"))
		{
			if (characterPassiveSkillComponent.actorComp == null)
			{
				this.actorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.actorComp), "actorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillMap") && characterPassiveSkillComponent.SkillMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, PassiveSkillData>>(this.SkillMap), "SkillMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("Context"))
		{
			if (characterPassiveSkillComponent.Context == null)
			{
				this.Context = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ContextParam>(this.Context), "Context"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("LockMap") || characterPassiveSkillComponent.LockMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<long>(this.LockMap), "LockMap");
	}

	// Token: 0x0400BE3E RID: 48702
	private const float DIVIDED_TEN_THOUSAND = 0.0001f;

	// Token: 0x0400BE3F RID: 48703
	private const string OwnerType = "Owner";

	// Token: 0x0400BE40 RID: 48704
	private const int ShareAllCdSkillEntityId = 0;

	// Token: 0x0400BE41 RID: 48705
	[StaticVariableRuleIgnore]
	private static readonly long[] GlobalTriggerWhitelist = new long[]
	{
		1302101064L
	};

	// Token: 0x0400BE42 RID: 48706
	private CharacterTriggerComponent triggerComp;

	// Token: 0x0400BE43 RID: 48707
	private CharacterBuffComponent buffComp;

	// Token: 0x0400BE44 RID: 48708
	[Nullable(2)]
	private BaseSkillCdComponent cdComp;

	// Token: 0x0400BE45 RID: 48709
	private CharacterActorComponent actorComp;

	// Token: 0x0400BE46 RID: 48710
	private readonly Dictionary<long, PassiveSkillData> SkillMap = new Dictionary<long, PassiveSkillData>();

	// Token: 0x0400BE47 RID: 48711
	private ContextParam Context;

	// Token: 0x0400BE48 RID: 48712
	private readonly HashSet<long> LockMap = new HashSet<long>();
}
