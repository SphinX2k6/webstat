using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;

// Token: 0x02002EB2 RID: 11954
[NullableContext(1)]
[Nullable(0)]
public class CharacterGameplayCueComponent : BaseGameplayCueComponent
{
	// Token: 0x06018879 RID: 100473 RVA: 0x006E209A File Offset: 0x006E029A
	protected override bool OnStart()
	{
		base.OnStart();
		this.TimeScaleComponent = base.Entity.GetComponent<PawnTimeScaleComponent>();
		return true;
	}

	// Token: 0x0601887A RID: 100474 RVA: 0x006E20B5 File Offset: 0x006E02B5
	protected override void OnEnable()
	{
		this.SetHidden(false);
	}

	// Token: 0x0601887B RID: 100475 RVA: 0x006E20BE File Offset: 0x006E02BE
	protected override void OnDisable(string reason)
	{
		this.SetHidden(true);
	}

	// Token: 0x0601887C RID: 100476 RVA: 0x006E20C8 File Offset: 0x006E02C8
	protected override void OnChangeTimeDilation(float timeDilation)
	{
		foreach (int num in this.EffectMap.Keys.ToArray<int>())
		{
			if (Singleton<EffectSystem>.Instance.IsValid(num))
			{
				if (this.TimeScaleComponent != null)
				{
					CharacterGameplayCueComponent.CueEffectInfo cueEffectInfo = this.EffectMap[num];
					EffectUtil.SetEffectTimeScale(num, this.TimeScaleComponent, timeDilation, cueEffectInfo.TimeScaleType);
				}
			}
			else
			{
				this.EffectMap.Remove(num);
			}
		}
	}

	// Token: 0x0601887D RID: 100477 RVA: 0x006E213D File Offset: 0x006E033D
	[NullableContext(2)]
	protected override EntityHandle GetEntityHandle()
	{
		return ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity);
	}

	// Token: 0x0601887E RID: 100478 RVA: 0x006E2150 File Offset: 0x006E0350
	public override void AddCueEffectToSet(int effectViewHandle, ETimeScaleType timeScaleType, ECueHideRule hideRule)
	{
		this.EffectMap[effectViewHandle] = new CharacterGameplayCueComponent.CueEffectInfo(timeScaleType, hideRule);
		Singleton<EffectSystem>.Instance.AddFinishCallback(effectViewHandle, delegate(int finishedHandle)
		{
			this.EffectMap.Remove(finishedHandle);
		});
		if (this.TimeScaleComponent != null)
		{
			EffectUtil.SetEffectTimeScale(effectViewHandle, this.TimeScaleComponent, base.Entity.TimeDilation, timeScaleType);
		}
		if (!base.Active && hideRule != ECueHideRule.NotFollowEntity)
		{
			Singleton<EffectSystem>.Instance.SetEffectHidden(effectViewHandle, true, "CharacterGameplayCueComponent.AddCueEffectToSet", false);
		}
	}

	// Token: 0x0601887F RID: 100479 RVA: 0x006E21C8 File Offset: 0x006E03C8
	public void SetHidden(bool hidden)
	{
		foreach (GameplayCueBase gameplayCueBase in base.GetAllCurrentCueRef())
		{
			if (hidden)
			{
				gameplayCueBase.OnDisable();
			}
			else
			{
				gameplayCueBase.OnEnable();
			}
		}
		foreach (int num in this.EffectMap.Keys.ToArray<int>())
		{
			if (Singleton<EffectSystem>.Instance.IsValid(num))
			{
				if (this.EffectMap[num].HideRule != ECueHideRule.NotFollowEntity)
				{
					Singleton<EffectSystem>.Instance.SetEffectHidden(num, hidden, "CharacterGameplayCueComponent.SetHidden", false);
				}
			}
			else
			{
				this.EffectMap.Remove(num);
			}
		}
	}

	// Token: 0x06018880 RID: 100480 RVA: 0x006E2290 File Offset: 0x006E0490
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterGameplayCueComponent characterGameplayCueComponent = (CharacterGameplayCueComponent)componentTemplate;
		if (base.CanResetComponentProperty("TimeScaleComponent"))
		{
			if (characterGameplayCueComponent.TimeScaleComponent == null)
			{
				this.TimeScaleComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.TimeScaleComponent), "TimeScaleComponent"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("EffectMap") || characterGameplayCueComponent.EffectMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, CharacterGameplayCueComponent.CueEffectInfo>>(this.EffectMap), "EffectMap");
	}

	// Token: 0x0400BD76 RID: 48502
	[Nullable(2)]
	private PawnTimeScaleComponent TimeScaleComponent;

	// Token: 0x0400BD77 RID: 48503
	private readonly Dictionary<int, CharacterGameplayCueComponent.CueEffectInfo> EffectMap = new Dictionary<int, CharacterGameplayCueComponent.CueEffectInfo>();

	// Token: 0x02009318 RID: 37656
	[NullableContext(0)]
	private readonly struct CueEffectInfo
	{
		// Token: 0x0604A017 RID: 303127 RVA: 0x0140D1F2 File Offset: 0x0140B3F2
		public CueEffectInfo(ETimeScaleType timeScaleType, ECueHideRule hideRule)
		{
			this.TimeScaleType = timeScaleType;
			this.HideRule = hideRule;
		}

		// Token: 0x1700A8D7 RID: 43223
		// (get) Token: 0x0604A018 RID: 303128 RVA: 0x0140D202 File Offset: 0x0140B402
		public ETimeScaleType TimeScaleType { get; }

		// Token: 0x1700A8D8 RID: 43224
		// (get) Token: 0x0604A019 RID: 303129 RVA: 0x0140D20A File Offset: 0x0140B40A
		public ECueHideRule HideRule { get; }
	}
}
