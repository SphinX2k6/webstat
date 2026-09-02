using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002EE8 RID: 12008
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectAddSkillLimitCount : BuffEffect
{
	// Token: 0x06018A99 RID: 101017 RVA: 0x006F540B File Offset: 0x006F360B
	public ExtraEffectAddSkillLimitCount(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018A9A RID: 101018 RVA: 0x006F5428 File Offset: 0x006F3628
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.SkillInfoIds = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		string[] array = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
		this.SkillLimitCounts = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.SkillLimitCounts[i] = int.Parse(array[i]);
		}
		ExtraEffectAddSkillLimitCount.ETargetType etargetType = (ExtraEffectAddSkillLimitCount.ETargetType)((extraEffectParameters_.Length > 2) ? int.Parse(extraEffectParameters_[2]) : 0);
		if (etargetType != ExtraEffectAddSkillLimitCount.ETargetType.Owner)
		{
			if (etargetType != ExtraEffectAddSkillLimitCount.ETargetType.Instigator)
			{
			}
			this.TargetType = ExtraEffectAddSkillLimitCount.ETargetType.Instigator;
			return;
		}
		this.TargetType = ExtraEffectAddSkillLimitCount.ETargetType.Owner;
	}

	// Token: 0x06018A9B RID: 101019 RVA: 0x006F54B0 File Offset: 0x006F36B0
	public override void OnCreated()
	{
		BaseBuffComponent component = this.GetEffectTarget().GetComponent<BaseBuffComponent>();
		foreach (CharacterSkillCdComponent characterSkillCdComponent in (((component != null) ? component.GetTargetComponents<CharacterSkillCdComponent>(EComponent.CharacterSkillCdComponent, null) : null) ?? new List<CharacterSkillCdComponent>()))
		{
			int num = this.SkillInfoIds.Length;
			if (this.SkillLimitCounts.Length < num)
			{
				num = this.SkillLimitCounts.Length;
			}
			for (int i = 0; i < num; i++)
			{
				int skillId = int.Parse(this.SkillInfoIds[i]);
				characterSkillCdComponent.AddLimitCount(skillId, this.SkillLimitCounts[i]);
			}
		}
		if (component != null && component.IsTeamBuffComponent())
		{
			this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018A9C RID: 101020 RVA: 0x006F55AC File Offset: 0x006F37AC
	public override void OnRemoved(bool bPremature)
	{
		BaseBuffComponent component = this.GetEffectTarget().GetComponent<BaseBuffComponent>();
		foreach (CharacterSkillCdComponent characterSkillCdComponent in (((component != null) ? component.GetTargetComponents<CharacterSkillCdComponent>(EComponent.CharacterSkillCdComponent, null) : null) ?? new List<CharacterSkillCdComponent>()))
		{
			int num = this.SkillInfoIds.Length;
			if (this.SkillLimitCounts.Length < num)
			{
				num = this.SkillLimitCounts.Length;
			}
			for (int i = 0; i < num; i++)
			{
				int skillId = int.Parse(this.SkillInfoIds[i]);
				characterSkillCdComponent.AddLimitCount(skillId, -this.SkillLimitCounts[i]);
			}
		}
		if (component != null && component.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018A9D RID: 101021 RVA: 0x006F569C File Offset: 0x006F389C
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018A9E RID: 101022 RVA: 0x006F56A0 File Offset: 0x006F38A0
	private Entity GetEffectTarget()
	{
		ExtraEffectAddSkillLimitCount.ETargetType targetType = this.TargetType;
		if (targetType != ExtraEffectAddSkillLimitCount.ETargetType.Owner)
		{
			if (targetType != ExtraEffectAddSkillLimitCount.ETargetType.Instigator)
			{
			}
			return base.InstigatorEntity.Entity;
		}
		return base.ExactOwnerEntity;
	}

	// Token: 0x06018A9F RID: 101023 RVA: 0x006F56D0 File Offset: 0x006F38D0
	private void OnChangeTeam()
	{
		foreach (int id in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(this.TeamEntityIds, true))
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			CharacterSkillCdComponent characterSkillCdComponent;
			if (instance == null)
			{
				characterSkillCdComponent = null;
			}
			else
			{
				EntityHandle handle = instance.GetHandle(id);
				if (handle == null)
				{
					characterSkillCdComponent = null;
				}
				else
				{
					WorldEntity entity = handle.Entity;
					characterSkillCdComponent = ((entity != null) ? entity.CheckGetComponent<CharacterSkillCdComponent>() : null);
				}
			}
			CharacterSkillCdComponent characterSkillCdComponent2 = characterSkillCdComponent;
			int num = this.SkillInfoIds.Length;
			if (this.SkillLimitCounts.Length < num)
			{
				num = this.SkillLimitCounts.Length;
			}
			for (int i = 0; i < num; i++)
			{
				int skillId = int.Parse(this.SkillInfoIds[i]);
				if (characterSkillCdComponent2 != null)
				{
					characterSkillCdComponent2.AddLimitCount(skillId, this.SkillLimitCounts[i]);
				}
			}
		}
		foreach (int id2 in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(this.TeamEntityIds, false))
		{
			CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
			CharacterSkillCdComponent characterSkillCdComponent3;
			if (instance2 == null)
			{
				characterSkillCdComponent3 = null;
			}
			else
			{
				EntityHandle handle2 = instance2.GetHandle(id2);
				if (handle2 == null)
				{
					characterSkillCdComponent3 = null;
				}
				else
				{
					WorldEntity entity2 = handle2.Entity;
					characterSkillCdComponent3 = ((entity2 != null) ? entity2.CheckGetComponent<CharacterSkillCdComponent>() : null);
				}
			}
			CharacterSkillCdComponent characterSkillCdComponent4 = characterSkillCdComponent3;
			int num2 = this.SkillInfoIds.Length;
			if (this.SkillLimitCounts.Length < num2)
			{
				num2 = this.SkillLimitCounts.Length;
			}
			for (int j = 0; j < num2; j++)
			{
				int skillId2 = int.Parse(this.SkillInfoIds[j]);
				if (characterSkillCdComponent4 != null)
				{
					characterSkillCdComponent4.AddLimitCount(skillId2, -this.SkillLimitCounts[j]);
				}
			}
		}
		this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
	}

	// Token: 0x0400BF30 RID: 48944
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] SkillInfoIds;

	// Token: 0x0400BF31 RID: 48945
	[Nullable(2)]
	private int[] SkillLimitCounts;

	// Token: 0x0400BF32 RID: 48946
	private ExtraEffectAddSkillLimitCount.ETargetType TargetType;

	// Token: 0x0400BF33 RID: 48947
	private List<int> TeamEntityIds = new List<int>();

	// Token: 0x02009327 RID: 37671
	[NullableContext(0)]
	public enum ETargetType
	{
		// Token: 0x04030FFD RID: 200701
		Owner,
		// Token: 0x04030FFE RID: 200702
		Instigator
	}
}
