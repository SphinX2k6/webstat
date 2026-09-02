using System;

namespace CSharpScript.Game.Module.BattleUi.SpecialRoleData
{
	// Token: 0x02006129 RID: 24873
	public class BattleUiSpecialRoleDataLuoSeLa : BattleUiSpecialRoleDataBase
	{
		// Token: 0x0603ED78 RID: 257400 RVA: 0x01019EA8 File Offset: 0x010180A8
		protected override void OnInit()
		{
			if (this.RoleData != null)
			{
				this.RoleData.CheckEnergyTag = true;
				this.RoleData.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1LuoselaMd10011.状态.大招解锁"], new BaseTagComponent.TTagSwitchedCallback(this.OnUltimateTagChanged), true);
				this.RoleData.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1LuoselaMd10011.状态.强化状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnStrongTagChanged), true);
			}
		}

		// Token: 0x0603ED79 RID: 257401 RVA: 0x01019F17 File Offset: 0x01018117
		private void OnUltimateTagChanged(int tagId, bool tagExist)
		{
			this.HasUltimateTag = tagExist;
			this.RefreshHasEnergyTag();
		}

		// Token: 0x0603ED7A RID: 257402 RVA: 0x01019F26 File Offset: 0x01018126
		private void OnStrongTagChanged(int tagId, bool tagExist)
		{
			this.HasStrongTag = tagExist;
			this.RefreshHasEnergyTag();
		}

		// Token: 0x0603ED7B RID: 257403 RVA: 0x01019F35 File Offset: 0x01018135
		private void RefreshHasEnergyTag()
		{
			this.RoleData.SetHasEnergyTag(this.HasUltimateTag && !this.HasStrongTag);
		}

		// Token: 0x0402341D RID: 144413
		private bool HasUltimateTag;

		// Token: 0x0402341E RID: 144414
		private bool HasStrongTag;
	}
}
