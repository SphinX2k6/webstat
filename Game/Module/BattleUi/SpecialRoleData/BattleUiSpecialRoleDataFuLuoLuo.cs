using System;

namespace CSharpScript.Game.Module.BattleUi.SpecialRoleData
{
	// Token: 0x02006128 RID: 24872
	public class BattleUiSpecialRoleDataFuLuoLuo : BattleUiSpecialRoleDataBase
	{
		// Token: 0x0603ED75 RID: 257397 RVA: 0x01019E4D File Offset: 0x0101804D
		protected override void OnInit()
		{
			if (this.RoleData != null)
			{
				this.RoleData.CheckEnergyTag = true;
				this.RoleData.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1FuluoluoMd10011.状态标识.大招解禁"], new BaseTagComponent.TTagSwitchedCallback(this.OnEnergyTagChanged), true);
			}
		}

		// Token: 0x0603ED76 RID: 257398 RVA: 0x01019E8A File Offset: 0x0101808A
		private void OnEnergyTagChanged(int tagId, bool tagExist)
		{
			BattleUiRoleData roleData = this.RoleData;
			if (roleData == null)
			{
				return;
			}
			roleData.SetHasEnergyTag(tagExist);
		}
	}
}
