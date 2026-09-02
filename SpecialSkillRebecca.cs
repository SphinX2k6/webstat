using System;
using System.Runtime.CompilerServices;

// Token: 0x02003150 RID: 12624
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillRebecca : SpecialSkillAimingBase
{
	// Token: 0x1700238A RID: 9098
	// (get) Token: 0x0601A252 RID: 107090 RVA: 0x007AC9F2 File Offset: 0x007AABF2
	protected override int AimingTagId
	{
		get
		{
			return GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.Rebecca瞄准"];
		}
	}

	// Token: 0x1700238B RID: 9099
	// (get) Token: 0x0601A253 RID: 107091 RVA: 0x007ACA03 File Offset: 0x007AAC03
	protected override EEventName SwitchLockTargetEventName
	{
		get
		{
			return EEventName.SpecialSkillRebeccaSwitchLockTarget;
		}
	}

	// Token: 0x0601A254 RID: 107092 RVA: 0x007ACA07 File Offset: 0x007AAC07
	public SpecialSkillRebecca(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A255 RID: 107093 RVA: 0x007ACA26 File Offset: 0x007AAC26
	public override void OnStart()
	{
		this.SkillComp = this.SpecialSkillComponent.Entity.GetComponent<CharacterSkillComponent>();
		this.LockOnComp = this.SpecialSkillComponent.Entity.GetComponent<BaseLockOnComponent>();
		base.OnStart();
	}

	// Token: 0x0601A256 RID: 107094 RVA: 0x007ACA5A File Offset: 0x007AAC5A
	protected override void OnAimingStart()
	{
		if (this.SkillComp != null)
		{
			this.SkillComp.SkillTarget = null;
			this.SkillComp.SkillTargetSocket = "";
		}
		this.LockOn();
	}

	// Token: 0x0601A257 RID: 107095 RVA: 0x007ACA86 File Offset: 0x007AAC86
	protected override void LockOn()
	{
		base.LockOnRect(this.Distance, this.HalfWidth, this.HalfHeight);
	}

	// Token: 0x0601A258 RID: 107096 RVA: 0x007ACAA0 File Offset: 0x007AACA0
	protected override void DoOnTargetLocked(EntityHandle target, string socketName)
	{
		BaseLockOnComponent lockOnComp = this.LockOnComp;
		if (lockOnComp != null)
		{
			lockOnComp.LockOnSpecifyTarget(target, socketName);
		}
		if (this.SkillComp != null && this.LockOnComp != null)
		{
			this.SkillComp.SkillTarget = this.LockOnComp.GetCurrentTarget();
			this.SkillComp.SkillTargetSocket = this.LockOnComp.GetCurrentTargetSocketName();
		}
		this.AddAimMarkCue(target, socketName);
	}

	// Token: 0x0601A259 RID: 107097 RVA: 0x007ACB04 File Offset: 0x007AAD04
	protected override void DoOnTargetUnlocked(EntityHandle target, string socketName)
	{
		BaseLockOnComponent lockOnComp = this.LockOnComp;
		if (lockOnComp != null)
		{
			lockOnComp.LockOnSpecifyTarget(null, "");
		}
		if (this.SkillComp != null)
		{
			this.SkillComp.SkillTarget = null;
			this.SkillComp.SkillTargetSocket = "";
		}
		this.RemoveAimMarkCue();
	}

	// Token: 0x0601A25A RID: 107098 RVA: 0x007ACB54 File Offset: 0x007AAD54
	private void AddAimMarkCue(EntityHandle target, string socketName)
	{
		this.RemoveAimMarkCue();
		WorldEntity entity = target.Entity;
		CharacterGameplayCueComponent characterGameplayCueComponent = (entity != null) ? entity.GetComponent<CharacterGameplayCueComponent>() : null;
		if (characterGameplayCueComponent == null)
		{
			return;
		}
		this.TargetCueComp = characterGameplayCueComponent;
		this.AimMarkCueHandle = characterGameplayCueComponent.AddCue(1308503001L, null);
		if (this.AimMarkCueHandle == 0)
		{
			return;
		}
		this.AimMarkCue = (characterGameplayCueComponent.GetCueByHandle((long)this.AimMarkCueHandle) as GameplayCueEffect);
		if (this.AimMarkCue != null && !string.IsNullOrEmpty(socketName))
		{
			this.AimMarkCue.SetSocketAndReattach(socketName);
		}
	}

	// Token: 0x0601A25B RID: 107099 RVA: 0x007ACBDD File Offset: 0x007AADDD
	private void RemoveAimMarkCue()
	{
		if (this.TargetCueComp != null && this.AimMarkCueHandle != 0)
		{
			this.TargetCueComp.RemoveCueByHandle((long)this.AimMarkCueHandle);
		}
		this.AimMarkCueHandle = 0;
		this.AimMarkCue = null;
		this.TargetCueComp = null;
	}

	// Token: 0x0400D1FD RID: 53757
	private const long REBECCA_AIM_MARK_CUE_ID = 1308503001L;

	// Token: 0x0400D1FE RID: 53758
	[Nullable(2)]
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400D1FF RID: 53759
	private readonly int HalfWidth = 750;

	// Token: 0x0400D200 RID: 53760
	private readonly int HalfHeight = 400;

	// Token: 0x0400D201 RID: 53761
	[Nullable(2)]
	private BaseLockOnComponent LockOnComp;

	// Token: 0x0400D202 RID: 53762
	private int AimMarkCueHandle;

	// Token: 0x0400D203 RID: 53763
	[Nullable(2)]
	private GameplayCueEffect AimMarkCue;

	// Token: 0x0400D204 RID: 53764
	[Nullable(2)]
	private CharacterGameplayCueComponent TargetCueComp;
}
