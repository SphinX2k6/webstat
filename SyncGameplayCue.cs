using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F69 RID: 12137
[NullableContext(1)]
[Nullable(0)]
public class SyncGameplayCue : BuffEffect
{
	// Token: 0x06018CD2 RID: 101586 RVA: 0x00703384 File Offset: 0x00701584
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018CD3 RID: 101587 RVA: 0x00703388 File Offset: 0x00701588
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null)
		{
			string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
			this.SyncCueIds = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.SyncCueIds[i] = long.Parse(array[i]);
			}
		}
	}

	// Token: 0x06018CD4 RID: 101588 RVA: 0x007033D8 File Offset: 0x007015D8
	public override void OnCreated()
	{
		EntityHandle instigatorEntity = base.InstigatorEntity;
		if (instigatorEntity != null && instigatorEntity.Valid)
		{
			int instigatorEntityId = this.InstigatorEntityId;
			Entity ownerEntity = base.OwnerEntity;
			int? num = (ownerEntity != null) ? new int?(ownerEntity.Id) : null;
			if (!(instigatorEntityId == num.GetValueOrDefault() & num != null))
			{
				this.Instigator = base.InstigatorEntity;
				Entity ownerEntity2 = base.OwnerEntity;
				this.OwnerCueComp = ((ownerEntity2 != null) ? ownerEntity2.GetComponent<BaseGameplayCueComponent>() : null);
				EntityHandle instigator = this.Instigator;
				BaseGameplayCueComponent instigatorCueComp;
				if (instigator == null)
				{
					instigatorCueComp = null;
				}
				else
				{
					WorldEntity entity = instigator.Entity;
					instigatorCueComp = ((entity != null) ? entity.GetComponent<BaseGameplayCueComponent>() : null);
				}
				this.InstigatorCueComp = instigatorCueComp;
				if (this.InstigatorCueComp != null && this.OwnerCueComp != null)
				{
					this.SyncCueOnCreated(this.InstigatorCueComp);
				}
				Singleton<EventSystem>.Instance.AddWithTarget<bool, long>(this.Instigator, EEventName.CharGameplayCueChanged, new Action<bool, long>(this.OnCharGameplayCueChanged));
				return;
			}
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
		Entity ownerEntity3 = base.OwnerEntity;
		string message = "SyncGameplayCue效果的双方不能是同一人";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Buff", this.BuffId);
		instance.Error(flag, ownerEntity3, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06018CD5 RID: 101589 RVA: 0x007034ED File Offset: 0x007016ED
	public override void OnRemoved(bool bPremature)
	{
		if (this.Instigator == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<bool, long>(this.Instigator, EEventName.CharGameplayCueChanged, new Action<bool, long>(this.OnCharGameplayCueChanged));
	}

	// Token: 0x06018CD6 RID: 101590 RVA: 0x00703517 File Offset: 0x00701717
	private void OnCharGameplayCueChanged(bool enable, long cueId)
	{
		if (!this.ShouldSyncCue(cueId))
		{
			return;
		}
		if (enable)
		{
			this.AddCue(cueId, true);
			return;
		}
		this.RemoveCue(cueId);
	}

	// Token: 0x06018CD7 RID: 101591 RVA: 0x00703538 File Offset: 0x00701738
	private void SyncCueOnCreated(BaseGameplayCueComponent instigatorCueComp)
	{
		BaseGameplayCueComponent ownerCueComp = this.OwnerCueComp;
		if (ownerCueComp == null)
		{
			return;
		}
		HashSet<long> hashSet = new HashSet<long>();
		foreach (GameplayCueBase gameplayCueBase in instigatorCueComp.GetAllCurrentCueRef())
		{
			hashSet.Add(gameplayCueBase.CueConfig.Id);
		}
		HashSet<long> hashSet2 = new HashSet<long>();
		foreach (GameplayCueBase gameplayCueBase2 in ownerCueComp.GetAllCurrentCueRef())
		{
			hashSet2.Add(gameplayCueBase2.CueConfig.Id);
		}
		foreach (long num in hashSet)
		{
			if (this.ShouldSyncCue(num))
			{
				if (!hashSet2.Contains(num))
				{
					this.AddCue(num, true);
				}
				else
				{
					this.SyncMagnitudeIfNeeded(num);
				}
			}
		}
		foreach (long num2 in hashSet2)
		{
			if (!hashSet.Contains(num2) || !this.ShouldSyncCue(num2))
			{
				this.RemoveCue(num2);
			}
		}
	}

	// Token: 0x06018CD8 RID: 101592 RVA: 0x007036A8 File Offset: 0x007018A8
	private void AddCue(long cueId, bool bSyncMagnitude)
	{
		BaseGameplayCueComponent ownerCueComp = this.OwnerCueComp;
		if (ownerCueComp != null)
		{
			ownerCueComp.AddCue(cueId, null);
		}
		if (bSyncMagnitude)
		{
			this.SyncMagnitudeIfNeeded(cueId);
		}
	}

	// Token: 0x06018CD9 RID: 101593 RVA: 0x007036DB File Offset: 0x007018DB
	private void RemoveCue(long cueId)
	{
		BaseGameplayCueComponent ownerCueComp = this.OwnerCueComp;
		if (ownerCueComp == null)
		{
			return;
		}
		ownerCueComp.RemoveCue(cueId);
	}

	// Token: 0x06018CDA RID: 101594 RVA: 0x007036F0 File Offset: 0x007018F0
	private void SyncMagnitudeIfNeeded(long cueId)
	{
		if (this.OwnerCueComp == null || this.InstigatorCueComp == null)
		{
			return;
		}
		GameplayCueBase cueByCueId = this.OwnerCueComp.GetCueByCueId(cueId);
		GameplayCueBase cueByCueId2 = this.InstigatorCueComp.GetCueByCueId(cueId);
		GameplayCueMagnitude gameplayCueMagnitude = cueByCueId as GameplayCueMagnitude;
		if (gameplayCueMagnitude != null)
		{
			GameplayCueMagnitude gameplayCueMagnitude2 = cueByCueId2 as GameplayCueMagnitude;
			if (gameplayCueMagnitude2 != null)
			{
				gameplayCueMagnitude.SyncMagnitude(gameplayCueMagnitude2);
			}
		}
	}

	// Token: 0x06018CDB RID: 101595 RVA: 0x00703744 File Offset: 0x00701944
	private bool ShouldSyncCue(long cueId)
	{
		if (this.SyncCueIds.Length == 0)
		{
			return false;
		}
		for (int i = 0; i < this.SyncCueIds.Length; i++)
		{
			if (this.SyncCueIds[i] == cueId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018CDC RID: 101596 RVA: 0x0070377D File Offset: 0x0070197D
	public SyncGameplayCue(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x0400C168 RID: 49512
	[Nullable(2)]
	private EntityHandle Instigator;

	// Token: 0x0400C169 RID: 49513
	[Nullable(2)]
	private BaseGameplayCueComponent OwnerCueComp;

	// Token: 0x0400C16A RID: 49514
	[Nullable(2)]
	private BaseGameplayCueComponent InstigatorCueComp;

	// Token: 0x0400C16B RID: 49515
	private long[] SyncCueIds = Array.Empty<long>();
}
