using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F3B RID: 12091
[NullableContext(1)]
[Nullable(0)]
public class ModifyBuffDurationOrPeriod : BuffEffect
{
	// Token: 0x06018BF7 RID: 101367 RVA: 0x006FE491 File Offset: 0x006FC691
	public ModifyBuffDurationOrPeriod(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BF8 RID: 101368 RVA: 0x006FE4B8 File Offset: 0x006FC6B8
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.DurationRate = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
		this.PeriodRate = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters2, this.Level, 0f);
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
			this.InvolvedBuffIds = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.InvolvedBuffIds[i] = long.Parse(array[i].Trim());
			}
		}
	}

	// Token: 0x06018BF9 RID: 101369 RVA: 0x006FE548 File Offset: 0x006FC748
	public override void OnCreated()
	{
		BaseBuffComponent baseBuffComponent = base.ExactOwnerEntity.CheckGetComponent<BaseBuffComponent>();
		foreach (BaseBuffComponent baseBuffComponent2 in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseBuffComponent>(EComponent.BaseBuffComponent, null) : null) ?? new List<BaseBuffComponent>()))
		{
			if (baseBuffComponent2 != null && (this.DurationRate != 0f || this.PeriodRate != 0f))
			{
				foreach (long targetBuffId in this.InvolvedBuffIds)
				{
					baseBuffComponent2.AddBuffTimeModifier(targetBuffId, this.ActiveHandleId, this.PeriodRate, this.DurationRate, false);
				}
			}
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018BFA RID: 101370 RVA: 0x006FE648 File Offset: 0x006FC848
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BFB RID: 101371 RVA: 0x006FE64C File Offset: 0x006FC84C
	public override void OnRemoved(bool bPremature)
	{
		BaseBuffComponent baseBuffComponent = base.ExactOwnerEntity.CheckGetComponent<BaseBuffComponent>();
		foreach (BaseBuffComponent baseBuffComponent2 in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseBuffComponent>(EComponent.BaseBuffComponent, null) : null) ?? new List<BaseBuffComponent>()))
		{
			if (baseBuffComponent2 != null)
			{
				foreach (long targetBuffId in this.InvolvedBuffIds)
				{
					baseBuffComponent2.RemoveBuffTimeModifier(targetBuffId, this.ActiveHandleId, false);
				}
			}
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018BFC RID: 101372 RVA: 0x006FE71C File Offset: 0x006FC91C
	private void OnChangeTeam()
	{
		foreach (int id in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(this.TeamEntityIds, true))
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			BaseBuffComponent baseBuffComponent;
			if (instance == null)
			{
				baseBuffComponent = null;
			}
			else
			{
				EntityHandle handle = instance.GetHandle(id);
				if (handle == null)
				{
					baseBuffComponent = null;
				}
				else
				{
					WorldEntity entity = handle.Entity;
					baseBuffComponent = ((entity != null) ? entity.CheckGetComponent<BaseBuffComponent>() : null);
				}
			}
			BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
			if (baseBuffComponent2 != null && (this.DurationRate != 0f || this.PeriodRate != 0f))
			{
				foreach (long targetBuffId in this.InvolvedBuffIds)
				{
					baseBuffComponent2.AddBuffTimeModifier(targetBuffId, this.ActiveHandleId, this.PeriodRate, this.DurationRate, false);
				}
			}
		}
		foreach (int id2 in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(this.TeamEntityIds, false))
		{
			CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
			BaseBuffComponent baseBuffComponent3;
			if (instance2 == null)
			{
				baseBuffComponent3 = null;
			}
			else
			{
				EntityHandle handle2 = instance2.GetHandle(id2);
				if (handle2 == null)
				{
					baseBuffComponent3 = null;
				}
				else
				{
					WorldEntity entity2 = handle2.Entity;
					baseBuffComponent3 = ((entity2 != null) ? entity2.CheckGetComponent<BaseBuffComponent>() : null);
				}
			}
			BaseBuffComponent baseBuffComponent4 = baseBuffComponent3;
			if (baseBuffComponent4 != null)
			{
				foreach (long targetBuffId2 in this.InvolvedBuffIds)
				{
					baseBuffComponent4.RemoveBuffTimeModifier(targetBuffId2, this.ActiveHandleId, false);
				}
			}
		}
		this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
	}

	// Token: 0x06018BFD RID: 101373 RVA: 0x006FE8A4 File Offset: 0x006FCAA4
	public override string GetDebugEffectString()
	{
		BaseBuffComponent baseBuffComponent = base.ExactOwnerEntity.CheckGetComponent<BaseBuffComponent>();
		string str = ((baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent()) ? "编队buff" : "非编队buff") + "修改buff" + string.Join<long>(",", this.InvolvedBuffIds);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
		defaultInterpolatedStringHandler.AppendLiteral(" 持续时间");
		defaultInterpolatedStringHandler.AppendFormatted((this.DurationRate >= 0f) ? "+" : "");
		defaultInterpolatedStringHandler.AppendFormatted<double>((double)this.DurationRate * 0.01, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("%");
		string str2 = str + defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
		defaultInterpolatedStringHandler.AppendLiteral(" 周期");
		defaultInterpolatedStringHandler.AppendFormatted((this.DurationRate >= 0f) ? "+" : "");
		defaultInterpolatedStringHandler.AppendFormatted<double>((double)this.PeriodRate * 0.01, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return str2 + defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0BA RID: 49338
	protected long[] InvolvedBuffIds = Array.Empty<long>();

	// Token: 0x0400C0BB RID: 49339
	protected float DurationRate;

	// Token: 0x0400C0BC RID: 49340
	protected float PeriodRate;

	// Token: 0x0400C0BD RID: 49341
	private List<int> TeamEntityIds = new List<int>();
}
