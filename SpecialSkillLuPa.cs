using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x0200314C RID: 12620
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillLuPa : SpecialSkillAimingBase
{
	// Token: 0x17002380 RID: 9088
	// (get) Token: 0x0601A21C RID: 107036 RVA: 0x007AB348 File Offset: 0x007A9548
	protected override int AimingTagId
	{
		get
		{
			return GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.露帕瞄准"];
		}
	}

	// Token: 0x17002381 RID: 9089
	// (get) Token: 0x0601A21D RID: 107037 RVA: 0x007AB359 File Offset: 0x007A9559
	protected override EEventName SwitchLockTargetEventName
	{
		get
		{
			return EEventName.SpecialSkillLuPaSwitchLockTarget;
		}
	}

	// Token: 0x0601A21E RID: 107038 RVA: 0x007AB35D File Offset: 0x007A955D
	public SpecialSkillLuPa(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A21F RID: 107039 RVA: 0x007AB374 File Offset: 0x007A9574
	public override void OnStart()
	{
		this.SkillComp = this.SpecialSkillComponent.Entity.GetComponent<CharacterSkillComponent>();
		this.CreatureDataComp = this.SpecialSkillComponent.Entity.GetComponent<CreatureDataComponent>();
		CharacterSkillComponent skillComp = this.SkillComp;
		this.SpecialSkill = ((skillComp != null) ? skillComp.GetSkill(1207601) : null);
		if (this.LockOnBuffId == 0L)
		{
			Skill specialSkill = this.SpecialSkill;
			TArray<long> tarray;
			if (specialSkill == null)
			{
				tarray = null;
			}
			else
			{
				SSkillInfo skillInfo = specialSkill.SkillInfo;
				tarray = ((skillInfo != null) ? skillInfo.SpecialBuffInCode : null);
			}
			TArray<long> tarray2 = tarray;
			if (tarray2 != null && tarray2.Num() > 0)
			{
				this.LockOnBuffId = tarray2.Get(0);
			}
		}
		base.OnStart();
	}

	// Token: 0x0601A220 RID: 107040 RVA: 0x007AB410 File Offset: 0x007A9610
	protected override void LockOn()
	{
		base.LockOnCircle(this.Distance, this.Radius);
	}

	// Token: 0x0601A221 RID: 107041 RVA: 0x007AB424 File Offset: 0x007A9624
	protected override void DoOnTargetLocked(EntityHandle target, string socketName)
	{
		WorldEntity entity = target.Entity;
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent == null)
		{
			return;
		}
		long lockOnBuffId = this.LockOnBuffId;
		AddBuffParam addBuffParam = new AddBuffParam();
		addBuffParam.InstigatorId = this.CreatureDataComp.GetCreatureDataId();
		addBuffParam.Reason = "露帕特殊技能瞄准目标加Buff";
		Skill specialSkill = this.SpecialSkill;
		addBuffParam.PreMessageId = ((specialSkill != null) ? specialSkill.CombatMessageId : null);
		characterBuffComponent.AddBuff(lockOnBuffId, addBuffParam);
	}

	// Token: 0x0601A222 RID: 107042 RVA: 0x007AB494 File Offset: 0x007A9694
	protected override void DoOnTargetUnlocked(EntityHandle target, string socketName)
	{
		if (target.Valid)
		{
			WorldEntity entity = target.Entity;
			CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
			if (characterBuffComponent == null)
			{
				return;
			}
			long lockOnBuffId = this.LockOnBuffId;
			int stackCount = -1;
			string reason = "露帕特殊技能瞄准目标移除Buff";
			Skill specialSkill = this.SpecialSkill;
			characterBuffComponent.RemoveBuff(lockOnBuffId, stackCount, reason, (specialSkill != null) ? specialSkill.CombatMessageId : null, null, null);
		}
	}

	// Token: 0x0400D1D1 RID: 53713
	private const int SpecialSkillId = 1207601;

	// Token: 0x0400D1D2 RID: 53714
	private readonly int Radius = 500;

	// Token: 0x0400D1D3 RID: 53715
	[Nullable(2)]
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400D1D4 RID: 53716
	[Nullable(2)]
	private CreatureDataComponent CreatureDataComp;

	// Token: 0x0400D1D5 RID: 53717
	[Nullable(2)]
	private Skill SpecialSkill;

	// Token: 0x0400D1D6 RID: 53718
	private long LockOnBuffId;
}
