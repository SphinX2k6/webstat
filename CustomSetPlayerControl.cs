using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02002EAC RID: 11948
[NullableContext(2)]
[Nullable(0)]
public class CustomSetPlayerControl : CustomActionBase
{
	// Token: 0x0601884C RID: 100428 RVA: 0x006E0580 File Offset: 0x006DE780
	public CustomSetPlayerControl(bool forbid, [Nullable(1)] string reason, CharacterActorComponent actorComp = null, CharacterSkillComponent skillComp = null, CharacterUnifiedStateComponent stateComp = null, CharacterInputComponent inputComp = null, BaseTagComponent tagComp = null, Action callback = null)
	{
		this.Forbid = forbid;
		this.Reason = reason;
		this.ActorComp = actorComp;
		this.SkillComp = skillComp;
		this.StateComp = stateComp;
		this.InputComp = inputComp;
		this.TagComp = tagComp;
		this.Callback = callback;
	}

	// Token: 0x0601884D RID: 100429 RVA: 0x006E05D0 File Offset: 0x006DE7D0
	protected override void OnRunAction()
	{
		bool success = (!this.Forbid) ? this.RegainActivity() : this.StopActivity();
		base.Finish(success);
	}

	// Token: 0x0601884E RID: 100430 RVA: 0x006E05FB File Offset: 0x006DE7FB
	private bool RegainActivity()
	{
		CharacterInputComponent inputComp = this.InputComp;
		if (inputComp != null)
		{
			inputComp.ClearMoveVectorCache();
		}
		CharacterInputComponent inputComp2 = this.InputComp;
		if (inputComp2 != null)
		{
			inputComp2.SetActive(true);
		}
		this.SetPlayerTag(false);
		ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		return true;
	}

	// Token: 0x0601884F RID: 100431 RVA: 0x006E0634 File Offset: 0x006DE834
	private bool StopActivity()
	{
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, this.Reason);
		if (this.StateComp == null || this.ActorComp == null)
		{
			return false;
		}
		if (this.StateComp.DirectionState == ECharDirectionState.AimDirection)
		{
			this.StateComp.ExitAimStatus();
		}
		else
		{
			this.StateComp.SetDirectionState(this.StateComp.DirectionState);
		}
		if (this.SkillComp != null && this.SkillComp.CurrentSkill != null)
		{
			this.SkillComp.EndOwnerAndFollowSkills();
		}
		this.ActorComp.ClearInput(false, true);
		CharacterInputComponent inputComp = this.InputComp;
		if (inputComp != null)
		{
			inputComp.ClearMoveVectorCache();
		}
		CharacterInputComponent inputComp2 = this.InputComp;
		if (inputComp2 != null)
		{
			inputComp2.SetActive(false);
		}
		this.SetPlayerTag(true);
		ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		return true;
	}

	// Token: 0x06018850 RID: 100432 RVA: 0x006E06FC File Offset: 0x006DE8FC
	private void SetPlayerTag(bool addTag)
	{
		if (addTag)
		{
			foreach (int value in CustomSetPlayerControl.PlayerInputLimitTagList)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.AddTag(new int?(value));
				}
			}
			return;
		}
		foreach (int value2 in CustomSetPlayerControl.PlayerInputLimitTagList)
		{
			BaseTagComponent tagComp2 = this.TagComp;
			if (tagComp2 != null)
			{
				tagComp2.RemoveTag(new int?(value2));
			}
		}
	}

	// Token: 0x0400BD47 RID: 48455
	[Nullable(1)]
	private static readonly int[] PlayerInputLimitTagList = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止移动"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止跳跃"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攀爬"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止闪避"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象1"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象2"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止大招"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止锁定目标"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止瞄准开镜"]
	};

	// Token: 0x0400BD48 RID: 48456
	private readonly bool Forbid;

	// Token: 0x0400BD49 RID: 48457
	[Nullable(1)]
	private readonly string Reason;

	// Token: 0x0400BD4A RID: 48458
	private readonly CharacterActorComponent ActorComp;

	// Token: 0x0400BD4B RID: 48459
	private readonly CharacterSkillComponent SkillComp;

	// Token: 0x0400BD4C RID: 48460
	private readonly CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400BD4D RID: 48461
	private readonly CharacterInputComponent InputComp;

	// Token: 0x0400BD4E RID: 48462
	private readonly BaseTagComponent TagComp;
}
