using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;

// Token: 0x02003126 RID: 12582
[NullableContext(1)]
[Nullable(0)]
public class MultiSkillData
{
	// Token: 0x0601A0C7 RID: 106695 RVA: 0x007A19FE File Offset: 0x0079FBFE
	public void Init(int entityId, int visionEntityId = 0)
	{
		this.EntityId = entityId;
		this.VisionEntityId = visionEntityId;
	}

	// Token: 0x0601A0C8 RID: 106696 RVA: 0x007A1A0E File Offset: 0x0079FC0E
	public bool IsMultiSkill(SSkillInfo skillInfo)
	{
		return skillInfo.CooldownConfig.SectionCount > 1;
	}

	// Token: 0x0601A0C9 RID: 106697 RVA: 0x007A1A20 File Offset: 0x0079FC20
	public bool CanStartMultiSkill(Skill skill)
	{
		int skillId = skill.SkillId;
		MultiSkillInfo valueOrDefault = this.MultiSkillInfoMap.GetValueOrDefault((long)skillId);
		SSkillCooldownInfo cooldownConfig = skill.SkillInfo.CooldownConfig;
		if (valueOrDefault == null)
		{
			return cooldownConfig.SectionCount - cooldownConfig.SectionRemaining == 1;
		}
		if (valueOrDefault.NextSkillId != null)
		{
			int? nextSkillId = valueOrDefault.NextSkillId;
			int num = 0;
			if (!(nextSkillId.GetValueOrDefault() == num & nextSkillId != null))
			{
				nextSkillId = valueOrDefault.NextSkillId;
				num = skillId;
				return (nextSkillId.GetValueOrDefault() == num & nextSkillId != null) && valueOrDefault.RemainingStartTime <= 0.0;
			}
		}
		return valueOrDefault.FirstSkillId == skillId;
	}

	// Token: 0x0601A0CA RID: 106698 RVA: 0x007A1AD4 File Offset: 0x0079FCD4
	public bool StartMultiSkill(Skill skill, bool bCheck = true)
	{
		if (bCheck && !this.CanStartMultiSkill(skill))
		{
			return false;
		}
		int skillId = skill.SkillId;
		SSkillCooldownInfo cooldownConfig = skill.SkillInfo.CooldownConfig;
		MultiSkillInfo multiSkillInfo;
		if (!this.MultiSkillInfoMap.TryGetValue((long)skillId, out multiSkillInfo))
		{
			multiSkillInfo = new MultiSkillInfo();
			multiSkillInfo.FirstSkillId = skillId;
			this.MultiSkillInfoMap[(long)skillId] = multiSkillInfo;
			this.MultiSkillInfos.Add(multiSkillInfo);
		}
		multiSkillInfo.CurSkillId = skillId;
		multiSkillInfo.NextSkillId = new int?((int)cooldownConfig.NextSkillId);
		multiSkillInfo.IsReset = cooldownConfig.IsReset;
		multiSkillInfo.IsResetOnChangeRole = cooldownConfig.IsResetOnChangeRole;
		int? nextSkillId = multiSkillInfo.NextSkillId;
		int num = 0;
		if (nextSkillId.GetValueOrDefault() == num & nextSkillId != null)
		{
			this.DispatchMultiSkillIdChangedEvent(multiSkillInfo);
			return true;
		}
		multiSkillInfo.StartTime = cooldownConfig.StartTime;
		multiSkillInfo.MultiSkillStartStamp = Singleton<Time>.Instance.FlowTime + (double)(cooldownConfig.StartTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		multiSkillInfo.StopTime = cooldownConfig.StopTime;
		multiSkillInfo.MultiSkillStopStamp = Singleton<Time>.Instance.FlowTime + (double)(cooldownConfig.StopTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		this.MultiSkillInfoMap[(long)multiSkillInfo.NextSkillId.Value] = multiSkillInfo;
		this.StartNextSkillTimer(multiSkillInfo);
		this.DispatchMultiSkillIdChangedEvent(multiSkillInfo);
		return true;
	}

	// Token: 0x0601A0CB RID: 106699 RVA: 0x007A1C1C File Offset: 0x0079FE1C
	private void RemoveTimers(MultiSkillInfo info)
	{
		if (info.MultiSkillStartTimer != null)
		{
			TimerSystem.FlowTimeInstance.Remove(info.MultiSkillStartTimer);
			info.MultiSkillStartTimer = null;
		}
		if (info.MultiSkillStopTimer != null)
		{
			TimerSystem.FlowTimeInstance.Remove(info.MultiSkillStopTimer);
			info.MultiSkillStopTimer = null;
		}
	}

	// Token: 0x0601A0CC RID: 106700 RVA: 0x007A1C6C File Offset: 0x0079FE6C
	public void InitMultiSkillInfo(Dictionary<int, Skill> skills)
	{
		foreach (KeyValuePair<int, Skill> keyValuePair in skills)
		{
			int key = keyValuePair.Key;
			SSkillInfo skillInfo = keyValuePair.Value.SkillInfo;
			if (!(skillInfo == null) && skillInfo.CooldownConfig.SectionCount != 0)
			{
				SSkillCooldownInfo cooldownConfig = skillInfo.CooldownConfig;
				if (cooldownConfig.SectionCount - cooldownConfig.SectionRemaining == 1)
				{
					MultiSkillInfo multiSkillInfo = new MultiSkillInfo();
					multiSkillInfo.FirstSkillId = key;
					this.MultiSkillInfoMap[(long)key] = multiSkillInfo;
					this.MultiSkillInfos.Add(multiSkillInfo);
					int num = (int)cooldownConfig.NextSkillId;
					int i = cooldownConfig.SectionCount - 1;
					while (i > 0)
					{
						i--;
						Skill skill;
						if (!skills.TryGetValue(num, out skill))
						{
							break;
						}
						this.MultiSkillInfoMap[(long)num] = multiSkillInfo;
						long? num2;
						if (skill == null)
						{
							num2 = null;
						}
						else
						{
							SSkillInfo skillInfo2 = skill.SkillInfo;
							num2 = ((skillInfo2 != null) ? new long?(skillInfo2.CooldownConfig.NextSkillId) : null);
						}
						long? num3 = num2;
						num = (int)num3.GetValueOrDefault();
						if (num == 0)
						{
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x0601A0CD RID: 106701 RVA: 0x007A1DC4 File Offset: 0x0079FFC4
	private void StartNextSkillTimer(MultiSkillInfo info)
	{
		this.RemoveTimers(info);
		if (info.StartTime > 0f)
		{
			info.MultiSkillStartTimer = TimerSystem.FlowTimeInstance.Delay(delegate(float _)
			{
				info.MultiSkillStartStamp = 0.0;
				this.DispatchMultiSkillEnableEvent(info);
				info.MultiSkillStartTimer = null;
			}, info.StartTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		}
		if (info.StopTime > 0f)
		{
			info.MultiSkillStopTimer = TimerSystem.FlowTimeInstance.Delay(delegate(float _)
			{
				info.MultiSkillStopStamp = 0.0;
				info.NextSkillId = new int?(0);
				this.DispatchMultiSkillIdChangedEvent(info);
				info.MultiSkillStopTimer = null;
			}, info.StopTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		}
	}

	// Token: 0x0601A0CE RID: 106702 RVA: 0x007A1E95 File Offset: 0x007A0095
	private void AheadFinishMultiSkill(MultiSkillInfo info, string reason)
	{
		info.NextSkillId = new int?(0);
		info.MultiSkillStartStamp = 0.0;
		info.MultiSkillStopStamp = 0.0;
		this.DispatchMultiSkillIdChangedEvent(info);
		this.RemoveTimers(info);
	}

	// Token: 0x0601A0CF RID: 106703 RVA: 0x007A1ED0 File Offset: 0x007A00D0
	public void ResetMultiSkills(int skillId, bool ignoreIsReset = false)
	{
		MultiSkillInfo multiSkillInfo;
		if (!this.MultiSkillInfoMap.TryGetValue((long)skillId, out multiSkillInfo))
		{
			return;
		}
		if (!multiSkillInfo.IsReset && !ignoreIsReset)
		{
			return;
		}
		if (multiSkillInfo.NextSkillId == null)
		{
			return;
		}
		if (multiSkillInfo.CurSkillId != skillId)
		{
			return;
		}
		this.AheadFinishMultiSkill(multiSkillInfo, "多段技能被打断");
	}

	// Token: 0x0601A0D0 RID: 106704 RVA: 0x007A1F20 File Offset: 0x007A0120
	public void ResetOnChangeRole()
	{
		foreach (MultiSkillInfo multiSkillInfo in this.MultiSkillInfos)
		{
			if (multiSkillInfo.IsResetOnChangeRole)
			{
				this.AheadFinishMultiSkill(multiSkillInfo, "换人时清理所有多段技能");
			}
		}
	}

	// Token: 0x0601A0D1 RID: 106705 RVA: 0x007A1F80 File Offset: 0x007A0180
	public void ClearAllSkill()
	{
		foreach (MultiSkillInfo multiSkillInfo in this.MultiSkillInfos)
		{
			int? nextSkillId = multiSkillInfo.NextSkillId;
			int num = 0;
			if (!(nextSkillId.GetValueOrDefault() == num & nextSkillId != null))
			{
				this.AheadFinishMultiSkill(multiSkillInfo, "清理所有多段技能");
			}
		}
	}

	// Token: 0x0601A0D2 RID: 106706 RVA: 0x007A1FF8 File Offset: 0x007A01F8
	public long GetNextMultiSkillId(int skillId)
	{
		MultiSkillInfo multiSkillInfo;
		if (!this.MultiSkillInfoMap.TryGetValue((long)skillId, out multiSkillInfo))
		{
			return (long)skillId;
		}
		if (multiSkillInfo.NextSkillId == null || multiSkillInfo.NextSkillId.Value == 0)
		{
			return (long)multiSkillInfo.FirstSkillId;
		}
		return (long)multiSkillInfo.NextSkillId.Value;
	}

	// Token: 0x0601A0D3 RID: 106707 RVA: 0x007A2047 File Offset: 0x007A0247
	[NullableContext(2)]
	public MultiSkillInfo GetMultiSkillInfo(int skillId)
	{
		return this.MultiSkillInfoMap.GetValueOrDefault((long)skillId);
	}

	// Token: 0x0601A0D4 RID: 106708 RVA: 0x007A2056 File Offset: 0x007A0256
	private void DispatchMultiSkillIdChangedEvent(MultiSkillInfo info)
	{
		Singleton<EventSystem>.Instance.Emit<int, MultiSkillInfo, int>(EEventName.OnMultiSkillIdChanged, this.EntityId, info, this.VisionEntityId);
	}

	// Token: 0x0601A0D5 RID: 106709 RVA: 0x007A2072 File Offset: 0x007A0272
	private void DispatchMultiSkillEnableEvent(MultiSkillInfo info)
	{
		Singleton<EventSystem>.Instance.Emit<int, MultiSkillInfo, int>(EEventName.OnMultiSkillEnable, this.EntityId, info, this.VisionEntityId);
	}

	// Token: 0x0400D0F0 RID: 53488
	public Dictionary<long, MultiSkillInfo> MultiSkillInfoMap = new Dictionary<long, MultiSkillInfo>();

	// Token: 0x0400D0F1 RID: 53489
	public List<MultiSkillInfo> MultiSkillInfos = new List<MultiSkillInfo>();

	// Token: 0x0400D0F2 RID: 53490
	public int EntityId;

	// Token: 0x0400D0F3 RID: 53491
	public int VisionEntityId;
}
