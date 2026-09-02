using System;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.BattleUi.Views;

// Token: 0x02001D8F RID: 7567
public class TrapDefenseBattleSkillItem : BattleSkillItem
{
	// Token: 0x0600DF02 RID: 57090 RVA: 0x003C0090 File Offset: 0x003BE290
	public void RefreshTrapDefenseSkillCoolDown()
	{
		int? followerProxyId = TowerDefensePlayerController.GetFollowerProxyId();
		if (followerProxyId == null)
		{
			return;
		}
		float followerSkillRemainCD = TowerDefensePlayerController.GetFollowerSkillRemainCD(followerProxyId.Value);
		if (followerSkillRemainCD > 0f)
		{
			base.PlaySkillCd(followerSkillRemainCD, TowerDefensePlayerController.GetFollowerSkillCD(followerProxyId.Value), false);
		}
	}

	// Token: 0x0600DF03 RID: 57091 RVA: 0x003C00D8 File Offset: 0x003BE2D8
	protected override bool IsNeedLongPress()
	{
		return !this.IsBanLongPress && this.SkillButtonData.GetIsLongPressControlCamera().Value;
	}

	// Token: 0x0600DF04 RID: 57092 RVA: 0x003C0104 File Offset: 0x003BE304
	public override void RefreshSkillName()
	{
		string skillIconName = this.SkillButtonData.GetSkillIconName();
		if (!StringUtils.IsBlank(skillIconName) && Singleton<Info>.Instance.IsInTouch())
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.SkillNameText, skillIconName, Array.Empty<object>());
			this.SkillNameText.SetUIActive(true);
			return;
		}
		this.SkillNameText.SetUIActive(false);
	}

	// Token: 0x0600DF05 RID: 57093 RVA: 0x003C0160 File Offset: 0x003BE360
	public void SetIsBanLongPress(bool isBanLongPress)
	{
		this.IsBanLongPress = isBanLongPress;
	}

	// Token: 0x04006B3B RID: 27451
	private bool IsBanLongPress;
}
