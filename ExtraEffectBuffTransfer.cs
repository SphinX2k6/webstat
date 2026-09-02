using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CombatMessage;
using UnrealEngine;

// Token: 0x02002F18 RID: 12056
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectBuffTransfer : BuffEffect
{
	// Token: 0x06018B2B RID: 101163 RVA: 0x006F8DFC File Offset: 0x006F6FFC
	public ExtraEffectBuffTransfer(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B2C RID: 101164 RVA: 0x006F8E5C File Offset: 0x006F705C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		this.BuffStack = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array[i]);
		}
		this.RecordDuration = (int)(double.Parse(extraEffectParameters_[1]) * 1000.0);
		this.EffectInternal = (int)(double.Parse(extraEffectParameters_[2]) * 1000.0);
		this.AbnormalMessageId = ModelBase<CombatMessageModel>.Instance.GenMessageId();
		this.AbnormalDamageType = ConfigCommonParamById.GetIntConfig("AbnormalDamageType").GetValueOrDefault(-1);
	}

	// Token: 0x06018B2D RID: 101165 RVA: 0x006F8F14 File Offset: 0x006F7114
	public override void OnCreated()
	{
		Entity ownerEntity = base.OwnerEntity;
		if (ownerEntity != null && !Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnDamageEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(ownerEntity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnDamageEvent));
		}
		if (ownerEntity != null && !Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnKillEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(ownerEntity, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnKillEvent));
		}
	}

	// Token: 0x06018B2E RID: 101166 RVA: 0x006F8F98 File Offset: 0x006F7198
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"SkillMessageId",
		"BulletMessageId",
		"IsAbnormalDamage"
	})]
	protected ValueTuple<long?, long?, bool> GetEffectiveMessageIds([Nullable(1)] RequirementPayload req)
	{
		if (req.SkillMessageId != null && req.BulletMessageId != null)
		{
			return new ValueTuple<long?, long?, bool>(req.SkillMessageId, req.BulletMessageId, false);
		}
		int? damageType = req.DamageType;
		int abnormalDamageType = this.AbnormalDamageType;
		if (damageType.GetValueOrDefault() == abnormalDamageType & damageType != null)
		{
			return new ValueTuple<long?, long?, bool>(new long?(this.AbnormalMessageId), new long?(this.AbnormalMessageId), true);
		}
		return new ValueTuple<long?, long?, bool>(null, null, false);
	}

	// Token: 0x06018B2F RID: 101167 RVA: 0x006F902C File Offset: 0x006F722C
	protected void AddBuff(BaseBuffComponent buffComp, BuffTransferRecord record)
	{
		int[] buffStack = record.BuffStack;
		if (record.TransferEntity.Contains(buffComp.Entity.Id))
		{
			return;
		}
		for (int i = 0; i < this.BuffIds.Length; i++)
		{
			if (buffStack[i] > 0)
			{
				buffComp.AddIterativeBuff(this.BuffIds[i], base.Buff, new int?(buffStack[i]), true, "buff的82额外效果:Buff转移", null, null);
			}
		}
		record.TransferEntity.Add(buffComp.Entity.Id);
	}

	// Token: 0x06018B30 RID: 101168 RVA: 0x006F90B8 File Offset: 0x006F72B8
	protected bool GetBuffStack(BaseBuffComponent buffComp)
	{
		bool flag = false;
		for (int i = 0; i < this.BuffIds.Length; i++)
		{
			int buffTotalStackById = buffComp.GetBuffTotalStackById(this.BuffIds[i], false);
			flag = (flag || buffTotalStackById > 0);
			this.BuffStack[i] = buffTotalStackById;
		}
		return flag;
	}

	// Token: 0x06018B31 RID: 101169 RVA: 0x006F9100 File Offset: 0x006F7300
	protected bool UpdateMaxBuffStack(BaseBuffComponent buffComp, BuffTransferRecord record)
	{
		int[] buffStack = record.BuffStack;
		bool result = false;
		for (int i = 0; i < this.BuffIds.Length; i++)
		{
			int buffTotalStackById = buffComp.GetBuffTotalStackById(this.BuffIds[i], false);
			if (buffTotalStackById > buffStack[i])
			{
				buffStack[i] = buffTotalStackById;
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06018B32 RID: 101170 RVA: 0x006F9146 File Offset: 0x006F7346
	protected void OnDamageEvent(Entity attacker, Entity victim, RequirementPayload req, DamageResult result, FVectorDouble damagePosition)
	{
		if (result.IsTargetKilled)
		{
			return;
		}
		this.HandleDamageOrKillEvent(attacker, victim, req, result, damagePosition);
	}

	// Token: 0x06018B33 RID: 101171 RVA: 0x006F915F File Offset: 0x006F735F
	protected void OnKillEvent(Entity attacker, Entity victim, RequirementPayload req, DamageResult result, FVectorDouble damagePosition)
	{
		this.HandleDamageOrKillEvent(attacker, victim, req, result, damagePosition);
	}

	// Token: 0x06018B34 RID: 101172 RVA: 0x006F9170 File Offset: 0x006F7370
	protected void HandleDamageOrKillEvent(Entity attacker, Entity victim, RequirementPayload req, DamageResult result, FVectorDouble damagePosition)
	{
		if (!this.CheckAuthority())
		{
			return;
		}
		ValueTuple<long?, long?, bool> effectiveMessageIds = this.GetEffectiveMessageIds(req);
		long? item = effectiveMessageIds.Item1;
		long? item2 = effectiveMessageIds.Item2;
		bool item3 = effectiveMessageIds.Item3;
		if (item == null || item2 == null)
		{
			return;
		}
		BaseBuffComponent component = victim.GetComponent<BaseBuffComponent>();
		if (component == null)
		{
			return;
		}
		int num = -1;
		int num2 = -1;
		for (int i = 0; i < this.BuffTransferRecords.Count; i++)
		{
			BuffTransferRecord buffTransferRecord = this.BuffTransferRecords[i];
			if (num == -1 && buffTransferRecord.RecordSkillMessageId == item.Value)
			{
				num = i;
			}
			if (num2 == -1 && buffTransferRecord.TargetSkillMessageId == item.Value)
			{
				num2 = i;
			}
		}
		if (num2 != -1 && num2 == this.BuffTransferRecords.Count - 1)
		{
			this.AddBuff(component, this.BuffTransferRecords[num2]);
			return;
		}
		if (num != -1 || num2 != -1)
		{
			return;
		}
		if (this.KillRecord == null || Singleton<Time>.Instance.FlowTime > this.RecordValidTime)
		{
			if (this.NextExecutionTime > Singleton<Time>.Instance.FlowTime || !result.IsTargetKilled)
			{
				return;
			}
			if (!this.GetBuffStack(component))
			{
				return;
			}
			int[] array = new int[this.BuffStack.Length];
			for (int j = 0; j < this.BuffStack.Length; j++)
			{
				array[j] = this.BuffStack[j];
			}
			this.KillRecord = new BuffTransferRecord
			{
				BulletMessageId = item2.Value,
				RecordSkillMessageId = item.Value,
				BuffStack = array,
				TargetSkillMessageId = 0L,
				TransferEntity = new HashSet<int>(),
				IsAbnormalDamage = item3,
				VictimEntityId = victim.Id
			};
			this.RecordValidTime = Singleton<Time>.Instance.FlowTime + (double)this.RecordDuration;
			return;
		}
		else
		{
			if ((this.KillRecord.RecordSkillMessageId == item.Value && this.KillRecord.BulletMessageId == item2.Value) || item3)
			{
				if (result.IsTargetKilled)
				{
					if (this.UpdateMaxBuffStack(component, this.KillRecord))
					{
						this.RecordValidTime = Singleton<Time>.Instance.FlowTime + (double)this.RecordDuration;
					}
					this.KillRecord.IsAbnormalDamage = (this.KillRecord.IsAbnormalDamage || item3);
				}
				return;
			}
			if (this.KillRecord.VictimEntityId == victim.Id)
			{
				return;
			}
			this.AddBuff(component, this.KillRecord);
			this.NextExecutionTime = Singleton<Time>.Instance.FlowTime + (double)this.EffectInternal;
			this.KillRecord.TargetSkillMessageId = item.Value;
			this.BuffTransferRecords.Add(this.KillRecord);
			if (this.KillRecord.IsAbnormalDamage)
			{
				this.AbnormalMessageId = ModelBase<CombatMessageModel>.Instance.GenMessageId();
			}
			this.KillRecord = null;
			if (this.BuffTransferRecords.Count > ExtraEffectBuffTransfer.MaxRecordCount)
			{
				this.BuffTransferRecords.RemoveAt(0);
			}
			return;
		}
	}

	// Token: 0x06018B35 RID: 101173 RVA: 0x006F9450 File Offset: 0x006F7650
	public override void OnRemoved(bool bPremature)
	{
		Entity ownerEntity = base.OwnerEntity;
		if (ownerEntity != null && Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnDamageEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(ownerEntity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnDamageEvent));
		}
		if (ownerEntity != null && Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnKillEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(ownerEntity, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnKillEvent));
		}
	}

	// Token: 0x06018B36 RID: 101174 RVA: 0x006F94D4 File Offset: 0x006F76D4
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B37 RID: 101175 RVA: 0x006F94D8 File Offset: 0x006F76D8
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(61, 3);
		defaultInterpolatedStringHandler.AppendLiteral("buff持有者击杀拥有buff ");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>(",", this.BuffIds));
		defaultInterpolatedStringHandler.AppendLiteral("时记录buff层数,");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.RecordDuration / 1000);
		defaultInterpolatedStringHandler.AppendLiteral("秒内的下一次技能伤害的所有目标都会叠加buff的层数,每轮循环的CD为");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.EffectInternal / 1000);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C049 RID: 49225
	protected static readonly int MaxRecordCount = 5;

	// Token: 0x0400C04A RID: 49226
	protected int AbnormalDamageType = -1;

	// Token: 0x0400C04B RID: 49227
	protected long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400C04C RID: 49228
	protected int RecordDuration;

	// Token: 0x0400C04D RID: 49229
	protected int EffectInternal;

	// Token: 0x0400C04E RID: 49230
	protected List<BuffTransferRecord> BuffTransferRecords = new List<BuffTransferRecord>();

	// Token: 0x0400C04F RID: 49231
	[Nullable(2)]
	protected BuffTransferRecord KillRecord;

	// Token: 0x0400C050 RID: 49232
	protected double NextExecutionTime = -1.0;

	// Token: 0x0400C051 RID: 49233
	protected double RecordValidTime = -1.0;

	// Token: 0x0400C052 RID: 49234
	protected int[] BuffStack = Array.Empty<int>();

	// Token: 0x0400C053 RID: 49235
	protected long AbnormalMessageId;
}
