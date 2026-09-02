using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F59 RID: 12121
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectSkillLimitCount : BuffEffect
{
	// Token: 0x06018C94 RID: 101524 RVA: 0x00701EF0 File Offset: 0x007000F0
	public ExtraEffectSkillLimitCount(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C95 RID: 101525 RVA: 0x00701F0C File Offset: 0x0070010C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.SkillInfoIds = ((extraEffectParameters_.Length != 0) ? extraEffectParameters_[0].Split('#', StringSplitOptions.None) : Array.Empty<string>());
		if (extraEffectParameters_.Length > 1)
		{
			string[] array = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
			this.SkillLimitCounts = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.SkillLimitCounts[i] = int.Parse(array[i]);
			}
		}
		else
		{
			this.SkillLimitCounts = Array.Empty<int>();
		}
		ETargetType etargetType = (ETargetType)((extraEffectParameters_.Length > 2) ? int.Parse(extraEffectParameters_[2]) : 0);
		if (etargetType != ETargetType.Owner)
		{
			if (etargetType != ETargetType.Instigator)
			{
			}
			this.TargetType = ETargetType.Instigator;
			return;
		}
		this.TargetType = ETargetType.Owner;
	}

	// Token: 0x06018C96 RID: 101526 RVA: 0x00701FB4 File Offset: 0x007001B4
	public override void OnCreated()
	{
		BaseBuffComponent baseBuffComponent = this.GetEffectTarget().CheckGetComponent<BaseBuffComponent>();
		foreach (CharacterSkillCdComponent characterSkillCdComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<CharacterSkillCdComponent>(EComponent.CharacterSkillCdComponent, null) : null) ?? new List<CharacterSkillCdComponent>()))
		{
			string[] skillInfoIds = this.SkillInfoIds;
			int num = (skillInfoIds != null) ? skillInfoIds.Length : 0;
			int[] skillLimitCounts = this.SkillLimitCounts;
			int num2 = (skillLimitCounts != null) ? skillLimitCounts.Length : 0;
			int num3 = (num < num2) ? num : num2;
			for (int i = 0; i < num3; i++)
			{
				int skillId = int.Parse(this.SkillInfoIds[i]);
				characterSkillCdComponent.IsSkillInCd(skillId, true);
				characterSkillCdComponent.SetLimitCount(skillId, new int?(this.SkillLimitCounts[i]));
			}
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018C97 RID: 101527 RVA: 0x007020D0 File Offset: 0x007002D0
	public override void OnRemoved(bool bPremature)
	{
		BaseBuffComponent baseBuffComponent = this.GetEffectTarget().CheckGetComponent<BaseBuffComponent>();
		foreach (CharacterSkillCdComponent characterSkillCdComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<CharacterSkillCdComponent>(EComponent.CharacterSkillCdComponent, null) : null) ?? new List<CharacterSkillCdComponent>()))
		{
			if (this.SkillInfoIds != null)
			{
				string[] skillInfoIds = this.SkillInfoIds;
				for (int i = 0; i < skillInfoIds.Length; i++)
				{
					int skillId = int.Parse(skillInfoIds[i]);
					characterSkillCdComponent.IsSkillInCd(skillId, true);
					characterSkillCdComponent.SetLimitCount(skillId, null);
				}
			}
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018C98 RID: 101528 RVA: 0x007021B8 File Offset: 0x007003B8
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C99 RID: 101529 RVA: 0x007021BC File Offset: 0x007003BC
	private Entity GetEffectTarget()
	{
		ETargetType targetType = this.TargetType;
		if (targetType != ETargetType.Owner)
		{
			if (targetType != ETargetType.Instigator)
			{
			}
			return base.InstigatorEntity.Entity;
		}
		return base.ExactOwnerEntity;
	}

	// Token: 0x06018C9A RID: 101530 RVA: 0x007021EC File Offset: 0x007003EC
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
			string[] skillInfoIds = this.SkillInfoIds;
			int num = (skillInfoIds != null) ? skillInfoIds.Length : 0;
			int[] skillLimitCounts = this.SkillLimitCounts;
			int num2 = (skillLimitCounts != null) ? skillLimitCounts.Length : 0;
			int num3 = (num < num2) ? num : num2;
			for (int i = 0; i < num3; i++)
			{
				int skillId = int.Parse(this.SkillInfoIds[i]);
				if (characterSkillCdComponent2 != null)
				{
					characterSkillCdComponent2.IsSkillInCd(skillId, true);
				}
				if (characterSkillCdComponent2 != null)
				{
					characterSkillCdComponent2.SetLimitCount(skillId, new int?(this.SkillLimitCounts[i]));
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
			if (this.SkillInfoIds != null)
			{
				string[] skillInfoIds2 = this.SkillInfoIds;
				for (int j = 0; j < skillInfoIds2.Length; j++)
				{
					int skillId2 = int.Parse(skillInfoIds2[j]);
					if (characterSkillCdComponent4 != null)
					{
						characterSkillCdComponent4.IsSkillInCd(skillId2, true);
					}
					if (characterSkillCdComponent4 != null)
					{
						characterSkillCdComponent4.SetLimitCount(skillId2, null);
					}
				}
			}
		}
		this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
	}

	// Token: 0x0400C12F RID: 49455
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] SkillInfoIds;

	// Token: 0x0400C130 RID: 49456
	[Nullable(2)]
	private int[] SkillLimitCounts;

	// Token: 0x0400C131 RID: 49457
	private ETargetType TargetType;

	// Token: 0x0400C132 RID: 49458
	private List<int> TeamEntityIds = new List<int>();
}
