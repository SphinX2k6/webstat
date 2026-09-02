using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x0200317E RID: 12670
public class MonsterFrozenComponent : BaseFrozenComponent
{
	// Token: 0x0601A41F RID: 107551 RVA: 0x007B9508 File Offset: 0x007B7708
	public override bool IsFrozen()
	{
		return this.IsFrozenInternal;
	}

	// Token: 0x0601A420 RID: 107552 RVA: 0x007B9510 File Offset: 0x007B7710
	protected override void SetFrozen(bool bFrozen)
	{
		if (this.IsFrozenInternal == bFrozen)
		{
			return;
		}
		this.IsFrozenInternal = bFrozen;
		PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
		CharacterGameplayCueComponent cueComponent = base.Entity.GetComponent<CharacterGameplayCueComponent>();
		BaseTagComponent component2 = base.Entity.GetComponent<BaseTagComponent>();
		TagContainer tagContainer = (component2 != null) ? component2.TagContainer : null;
		if (bFrozen)
		{
			int? frozenHandle = this.FrozenHandle;
			this.FrozenHandle = ((frozenHandle != null) ? frozenHandle : ((component != null) ? new int?(component.SetTimeScale(int.MaxValue, 0f, null, float.PositiveInfinity, ETimeScaleSourceType.Buff, false, false)) : null));
			if (this.FrozenCueHandle == 0)
			{
				CharacterGameplayCueComponent cueComponent5 = cueComponent;
				this.FrozenCueHandle = ((cueComponent5 != null) ? cueComponent5.AddCue(1003L, null) : 0);
			}
			if (tagContainer != null)
			{
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["Damage.Frozen"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.霸体"]);
				return;
			}
		}
		else
		{
			if (this.FrozenHandle != null)
			{
				if (component != null)
				{
					component.RemoveTimeScale(this.FrozenHandle.Value);
				}
				this.FrozenHandle = null;
			}
			CharacterGameplayCueComponent cueComponent2 = cueComponent;
			if (cueComponent2 != null)
			{
				cueComponent2.RemoveCueByHandle((long)this.FrozenCueHandle);
			}
			CharacterGameplayCueComponent cueComponent3 = cueComponent;
			this.FrozenCueHandle = ((cueComponent3 != null) ? cueComponent3.AddCue(100302L, new GameplayCueParam?(new GameplayCueParam
			{
				EndCallback = delegate()
				{
					CharacterGameplayCueComponent cueComponent4 = cueComponent;
					if (cueComponent4 != null)
					{
						cueComponent4.RemoveCueByHandle((long)this.FrozenCueHandle);
					}
					this.FrozenCueHandle = 0;
				}
			})) : 0);
			if (tagContainer != null)
			{
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["Damage.Frozen"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.霸体"]);
			}
		}
	}

	// Token: 0x0601A421 RID: 107553 RVA: 0x007B96D4 File Offset: 0x007B78D4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MonsterFrozenComponent monsterFrozenComponent = (MonsterFrozenComponent)componentTemplate;
		if (base.CanResetComponentProperty("FrozenHandle"))
		{
			this.FrozenHandle = monsterFrozenComponent.FrozenHandle;
		}
		if (base.CanResetComponentProperty("FrozenCueHandle"))
		{
			this.FrozenCueHandle = monsterFrozenComponent.FrozenCueHandle;
		}
		if (base.CanResetComponentProperty("IsFrozenInternal"))
		{
			this.IsFrozenInternal = monsterFrozenComponent.IsFrozenInternal;
		}
		return true;
	}

	// Token: 0x0400D370 RID: 54128
	protected int? FrozenHandle;

	// Token: 0x0400D371 RID: 54129
	protected int FrozenCueHandle;

	// Token: 0x0400D372 RID: 54130
	protected bool IsFrozenInternal;
}
