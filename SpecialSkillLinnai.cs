using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;

// Token: 0x0200314B RID: 12619
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillLinnai : SpecialSkillBase
{
	// Token: 0x0601A217 RID: 107031 RVA: 0x007AB04A File Offset: 0x007A924A
	[NullableContext(1)]
	public SpecialSkillLinnai(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A218 RID: 107032 RVA: 0x007AB054 File Offset: 0x007A9254
	public override void OnStart()
	{
		Entity entity = this.SpecialSkillComponent.Entity;
		this.MoveComp = entity.GetComponent<CharacterMoveComponent>();
		this.SpecialTagComp = entity.GetComponent<CharacterSpecialTagComponent>();
		this.ClimbComp = entity.GetComponent<CharacterClimbComponent>();
		this.TagComp = entity.GetComponent<BaseTagComponent>();
		this.UnifiedComp = entity.GetComponent<BaseUnifiedStateComponent>();
		CharacterSpecialTagComponent specialTagComp = this.SpecialTagComp;
		this.SpecialTagListenerHandle = ((specialTagComp != null) ? specialTagComp.InitTagListenerConfig("/Game/Aki/Character/Role/FemaleM/LinNai/Data/DA_SpecialTagConfig.DA_SpecialTagConfig", new Func<double, bool>(this.CheckLinnaiSpecialState)) : 0);
		BaseTagComponent tagComp = this.TagComp;
		this.SpecialTagListener = ((tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.轮滑状态"]), new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialTagChanged), null) : null);
	}

	// Token: 0x0601A219 RID: 107033 RVA: 0x007AB10C File Offset: 0x007A930C
	public override void OnEnd()
	{
		CharacterSpecialTagComponent specialTagComp = this.SpecialTagComp;
		if (specialTagComp != null)
		{
			specialTagComp.RemoveTagListenerConfig(this.SpecialTagListenerHandle);
		}
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null)
		{
			tagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.LinnaiMd10011.轮滑状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialTagChanged));
		}
		ITagTask specialTagListener = this.SpecialTagListener;
		if (specialTagListener != null)
		{
			specialTagListener.EndTask();
		}
		this.SpecialTagListener = null;
	}

	// Token: 0x0601A21A RID: 107034 RVA: 0x007AB174 File Offset: 0x007A9374
	private bool CheckLinnaiSpecialState(double delta)
	{
		BaseUnifiedStateComponent unifiedComp = this.UnifiedComp;
		bool flag = unifiedComp != null && unifiedComp.PositionState == ECharPositionState.Ground;
		BaseUnifiedStateComponent unifiedComp2 = this.UnifiedComp;
		object obj = unifiedComp2 != null && unifiedComp2.PositionState == ECharPositionState.Air;
		CharacterMoveComponent moveComp = this.MoveComp;
		double num = (moveComp != null) ? moveComp.LastJumpTime : 0.0;
		CharacterMoveComponent moveComp2 = this.MoveComp;
		bool flag2 = (moveComp2 != null && moveComp2.IsJump) || Singleton<Time>.Instance.PlayerWorldTime - num < 500.0;
		object obj2 = obj;
		bool flag3 = ((obj2 | flag) & flag2) != null;
		CharacterClimbComponent climbComp = this.ClimbComp;
		bool flag4;
		if (climbComp != null && climbComp.LastExitClimbType == EExitClimb.蹬墙退出)
		{
			double playerWorldTime = Singleton<Time>.Instance.PlayerWorldTime;
			CharacterClimbComponent climbComp2 = this.ClimbComp;
			flag4 = (playerWorldTime - (double)((climbComp2 != null) ? climbComp2.LastExitClimbTime : 0f) < 800.0);
		}
		else
		{
			flag4 = false;
		}
		bool flag5 = flag4;
		bool flag6 = (obj2 & flag5) != null;
		CharacterClimbComponent climbComp3 = this.ClimbComp;
		AkiClient.Game.Aki.Character.BaseCharacter.SClimbState? sclimbState = (climbComp3 != null) ? new AkiClient.Game.Aki.Character.BaseCharacter.SClimbState?(climbComp3.GetClimbState()) : null;
		bool flag7 = ((sclimbState != null) ? new TEnumAsByte<EClimbState>?(sclimbState.GetValueOrDefault().攀爬状态) : null) != EClimbState.退出攀爬 || ((sclimbState != null) ? new TEnumAsByte<EExitClimb>?(sclimbState.GetValueOrDefault().退出攀爬类型) : null) == EExitClimb.反斜登顶;
		return !flag3 && flag7 && !flag6;
	}

	// Token: 0x0601A21B RID: 107035 RVA: 0x007AB318 File Offset: 0x007A9518
	private void OnSpecialTagChanged(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			CharacterClimbComponent climbComp = this.ClimbComp;
			if (climbComp == null)
			{
				return;
			}
			climbComp.ResetClimbObjectConfig("FemaleLinnaiSpecial");
			return;
		}
		else
		{
			CharacterClimbComponent climbComp2 = this.ClimbComp;
			if (climbComp2 == null)
			{
				return;
			}
			climbComp2.ResetClimbObjectConfig("FemaleM");
			return;
		}
	}

	// Token: 0x0400D1C7 RID: 53703
	private const int JUMP_DELAY_TIME = 500;

	// Token: 0x0400D1C8 RID: 53704
	private const int JUMP_EXIT_CLIMB_DELAY_TIME = 800;

	// Token: 0x0400D1C9 RID: 53705
	[Nullable(1)]
	private const string SPECIAL_TAG_LISTENER_DA = "/Game/Aki/Character/Role/FemaleM/LinNai/Data/DA_SpecialTagConfig.DA_SpecialTagConfig";

	// Token: 0x0400D1CA RID: 53706
	private int SpecialTagListenerHandle;

	// Token: 0x0400D1CB RID: 53707
	private CharacterClimbComponent ClimbComp;

	// Token: 0x0400D1CC RID: 53708
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400D1CD RID: 53709
	private BaseTagComponent TagComp;

	// Token: 0x0400D1CE RID: 53710
	private BaseUnifiedStateComponent UnifiedComp;

	// Token: 0x0400D1CF RID: 53711
	private CharacterSpecialTagComponent SpecialTagComp;

	// Token: 0x0400D1D0 RID: 53712
	private ITagTask SpecialTagListener;
}
