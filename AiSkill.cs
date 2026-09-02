using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02000D0E RID: 3342
[NullableContext(1)]
[Nullable(0)]
public class AiSkill
{
	// Token: 0x06004315 RID: 17173 RVA: 0x0007C7F4 File Offset: 0x0007A9F4
	public AiSkill(AiController aiController)
	{
		this.AiController = aiController;
	}

	// Token: 0x06004316 RID: 17174 RVA: 0x0007C848 File Offset: 0x0007AA48
	public void ActivateSkillGroup(int skillGroupIndex, bool activate)
	{
		if (skillGroupIndex >= 0 && skillGroupIndex < this.BaseSkill.Value.RandomSkillsLength)
		{
			if (activate)
			{
				this.ActiveSkillGroup.Add(skillGroupIndex);
				return;
			}
			this.ActiveSkillGroup.Remove(skillGroupIndex);
		}
	}

	// Token: 0x06004317 RID: 17175 RVA: 0x0007C88D File Offset: 0x0007AA8D
	public void AddSkillCd(int skillInfoId, float cdAdd)
	{
		this.AiController.AddCoolDownTime(skillInfoId, (double)cdAdd);
	}

	// Token: 0x06004318 RID: 17176 RVA: 0x0007C89D File Offset: 0x0007AA9D
	public bool CanActivate(int skillInfoId)
	{
		return this.AiController.GetCoolDownReady(skillInfoId);
	}

	// Token: 0x06004319 RID: 17177 RVA: 0x0007C8AC File Offset: 0x0007AAAC
	public void SetSkillCdFromNow(int? skillInfoId)
	{
		if (skillInfoId == null)
		{
			return;
		}
		AiSkillInfos aiSkillInfos;
		if (this.SkillInfos.TryGetValue(skillInfoId.Value, out aiSkillInfos))
		{
			this.AiController.AddCoolDownTime(skillInfoId.Value, Singleton<MathUtils>.Instance.GetRandomRange((double)aiSkillInfos.SkillCdRange.Value.Min, (double)aiSkillInfos.SkillCdRange.Value.Max));
		}
	}

	// Token: 0x0600431A RID: 17178 RVA: 0x0007C928 File Offset: 0x0007AB28
	public float GetSkillWeight(int skillInfoId)
	{
		float result;
		if (this.ChangedSkillWeights.TryGetValue(skillInfoId, out result))
		{
			return result;
		}
		AiSkillInfos aiSkillInfos;
		if (!this.SkillInfos.TryGetValue(skillInfoId, out aiSkillInfos))
		{
			return 0f;
		}
		return (float)aiSkillInfos.SkillWeight;
	}

	// Token: 0x0600431B RID: 17179 RVA: 0x0007C965 File Offset: 0x0007AB65
	public void ChangeSkillWeight(int skillInfoId, float weight)
	{
		if (weight > 0f)
		{
			this.ChangedSkillWeights[skillInfoId] = weight;
			return;
		}
		this.ChangedSkillWeights.Remove(skillInfoId);
	}

	// Token: 0x0600431C RID: 17180 RVA: 0x0007C98C File Offset: 0x0007AB8C
	public void InitTagMap()
	{
		this.PreconditionTagMap.Clear();
		foreach (KeyValuePair<int, AiSkillPrecondition> keyValuePair in this.SkillPreconditionMap)
		{
			if (!string.IsNullOrEmpty(keyValuePair.Value.NeedTag))
			{
				FGameplayTag? gameplayTagByName = GameplayTagUtils.GetGameplayTagByName(keyValuePair.Value.NeedTag);
				if (gameplayTagByName != null)
				{
					this.PreconditionTagMap[keyValuePair.Key] = gameplayTagByName.Value;
				}
			}
		}
	}

	// Token: 0x0600431D RID: 17181 RVA: 0x0007CA30 File Offset: 0x0007AC30
	public string GetCdDebugString()
	{
		string text = "";
		double num = ModelBase<GameModeModel>.Instance.IsMulti ? Singleton<TimeUtil>.Instance.GetServerTimeStamp() : Singleton<Time>.Instance.WorldTime;
		foreach (KeyValuePair<int, ValueTuple<double, bool>> keyValuePair in this.AiController.AiCoolDownList)
		{
			int key = keyValuePair.Key;
			double item = keyValuePair.Value.Item1;
			text = string.Concat(new string[]
			{
				text,
				"\n\t\t\t",
				key.ToString(),
				" : ",
				MathF.Max(0f, (float)(item - num)).ToString()
			});
		}
		return text;
	}

	// Token: 0x0400116C RID: 4460
	private readonly AiController AiController;

	// Token: 0x0400116D RID: 4461
	public AiBaseSkill? BaseSkill;

	// Token: 0x0400116E RID: 4462
	public readonly Dictionary<int, AiSkillInfos> SkillInfos = new Dictionary<int, AiSkillInfos>();

	// Token: 0x0400116F RID: 4463
	public readonly Dictionary<int, AiSkillPrecondition> SkillPreconditionMap = new Dictionary<int, AiSkillPrecondition>();

	// Token: 0x04001170 RID: 4464
	public readonly Dictionary<int, FGameplayTag> PreconditionTagMap = new Dictionary<int, FGameplayTag>();

	// Token: 0x04001171 RID: 4465
	private readonly Dictionary<int, float> ChangedSkillWeights = new Dictionary<int, float>();

	// Token: 0x04001172 RID: 4466
	public readonly HashSet<int> ActiveSkillGroup = new HashSet<int>();
}
