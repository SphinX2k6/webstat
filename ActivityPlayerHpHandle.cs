using System;
using System.Runtime.CompilerServices;

// Token: 0x02000F7A RID: 3962
[NullableContext(2)]
[Nullable(0)]
public class ActivityPlayerHpHandle
{
	// Token: 0x06006478 RID: 25720 RVA: 0x00192E08 File Offset: 0x00191008
	public void Init(long? lowHpCueId = null, float? lowHpPercent = null, long? hurtCueId = null, int? duration = null)
	{
		this.IsInit = true;
		if (lowHpCueId != null)
		{
			this.LowHpCueId = lowHpCueId.Value;
		}
		if (hurtCueId != null)
		{
			this.HurtCueId = hurtCueId.Value;
		}
		if (lowHpPercent != null)
		{
			this.LowHpPercent = lowHpPercent.Value;
		}
		if (duration != null)
		{
			this.Duration = duration.Value;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetCurrentEntity : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		this.CueComp = entityHandle.Entity.GetComponent<CharacterGameplayCueComponent>();
	}

	// Token: 0x06006479 RID: 25721 RVA: 0x00192EAC File Offset: 0x001910AC
	[NullableContext(1)]
	public void OnPlayerHpChange(KscHeadStateData kscPlayerHeadStateData)
	{
		if (!this.IsInit)
		{
			return;
		}
		if (kscPlayerHeadStateData.MaxHp <= 0)
		{
			return;
		}
		if ((float)kscPlayerHeadStateData.Hp < this.LastHp && kscPlayerHeadStateData.Hp < kscPlayerHeadStateData.MaxHp)
		{
			this.AddHurtGameplayCue();
		}
		this.LastHp = (float)kscPlayerHeadStateData.Hp;
		if ((float)kscPlayerHeadStateData.Hp / (float)kscPlayerHeadStateData.MaxHp <= this.LowHpPercent)
		{
			this.AddLowHpGameplayCue();
			return;
		}
		this.RemoveLowHpGameplayCue();
	}

	// Token: 0x0600647A RID: 25722 RVA: 0x00192F20 File Offset: 0x00191120
	private void AddLowHpGameplayCue()
	{
		if (this.LowHpCueHandleId > 0)
		{
			return;
		}
		if (this.CueComp != null && this.LowHpCueId > 0L)
		{
			this.LowHpCueHandleId = this.CueComp.AddCue(this.LowHpCueId, null);
		}
	}

	// Token: 0x0600647B RID: 25723 RVA: 0x00192F69 File Offset: 0x00191169
	private void RemoveLowHpGameplayCue()
	{
		if (this.LowHpCueHandleId <= 0)
		{
			return;
		}
		CharacterGameplayCueComponent cueComp = this.CueComp;
		if (cueComp != null)
		{
			cueComp.RemoveCueByHandle((long)this.LowHpCueHandleId);
		}
		this.LowHpCueHandleId = 0;
	}

	// Token: 0x0600647C RID: 25724 RVA: 0x00192F94 File Offset: 0x00191194
	private void AddHurtGameplayCue()
	{
		if (this.HurtCueHandleId > 0)
		{
			return;
		}
		if (this.CueComp != null && this.HurtCueId > 0L)
		{
			this.HurtCueHandleId = this.CueComp.AddCue(this.HurtCueId, null);
			this.AddTimer();
		}
	}

	// Token: 0x0600647D RID: 25725 RVA: 0x00192FE3 File Offset: 0x001911E3
	private void RemoveHurtGameplayCue()
	{
		if (this.HurtCueHandleId <= 0)
		{
			return;
		}
		CharacterGameplayCueComponent cueComp = this.CueComp;
		if (cueComp != null)
		{
			cueComp.RemoveCueByHandle((long)this.HurtCueHandleId);
		}
		this.HurtCueHandleId = 0;
	}

	// Token: 0x0600647E RID: 25726 RVA: 0x0019300E File Offset: 0x0019120E
	private void AddTimer()
	{
		this.TimerId = TimerSystem.Instance.Delay(new TTimerAction(this.OnTimer), (float)this.Duration, null, null, true, 1f);
	}

	// Token: 0x0600647F RID: 25727 RVA: 0x0019303B File Offset: 0x0019123B
	private void RemoveTimer()
	{
		if (this.TimerId != null)
		{
			TimerSystem.Instance.Remove(this.TimerId);
			this.TimerId = null;
		}
	}

	// Token: 0x06006480 RID: 25728 RVA: 0x0019305D File Offset: 0x0019125D
	private void OnTimer(float time)
	{
		this.TimerId = null;
		this.RemoveHurtGameplayCue();
	}

	// Token: 0x06006481 RID: 25729 RVA: 0x0019306C File Offset: 0x0019126C
	public void Clear()
	{
		this.RemoveLowHpGameplayCue();
		this.RemoveHurtGameplayCue();
		this.RemoveTimer();
		this.IsInit = false;
	}

	// Token: 0x04002FF5 RID: 12277
	private bool IsInit;

	// Token: 0x04002FF6 RID: 12278
	private float LastHp;

	// Token: 0x04002FF7 RID: 12279
	private CharacterGameplayCueComponent CueComp;

	// Token: 0x04002FF8 RID: 12280
	private int LowHpCueHandleId;

	// Token: 0x04002FF9 RID: 12281
	private int HurtCueHandleId;

	// Token: 0x04002FFA RID: 12282
	private TimerHandle TimerId;

	// Token: 0x04002FFB RID: 12283
	private int Duration = 500;

	// Token: 0x04002FFC RID: 12284
	public long LowHpCueId = (long)((ulong)-1584967294);

	// Token: 0x04002FFD RID: 12285
	public long HurtCueId = (long)((ulong)-1584967295);

	// Token: 0x04002FFE RID: 12286
	public float LowHpPercent = 0.3f;
}
