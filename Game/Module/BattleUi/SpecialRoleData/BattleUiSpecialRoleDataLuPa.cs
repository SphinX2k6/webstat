using System;

namespace CSharpScript.Game.Module.BattleUi.SpecialRoleData
{
	// Token: 0x0200612A RID: 24874
	public class BattleUiSpecialRoleDataLuPa : BattleUiSpecialRoleDataBase
	{
		// Token: 0x0603ED7D RID: 257405 RVA: 0x01019F60 File Offset: 0x01018160
		protected override void OnInit()
		{
			BattleUiRoleData roleData = this.RoleData;
			bool flag;
			if (roleData == null)
			{
				flag = false;
			}
			else
			{
				CharacterActorComponent actorComp = roleData.ActorComp;
				flag = ((actorComp != null) ? new bool?(actorComp.IsAutonomousProxy) : null).GetValueOrDefault();
			}
			if (flag)
			{
				ControllerBase<HudUnitController>.Instance.TryCreateHud(EHudUnitType.LuPaAim);
			}
		}

		// Token: 0x0603ED7E RID: 257406 RVA: 0x01019FB0 File Offset: 0x010181B0
		protected override void OnClear()
		{
			BattleUiRoleData roleData = this.RoleData;
			bool flag;
			if (roleData == null)
			{
				flag = false;
			}
			else
			{
				CharacterActorComponent actorComp = roleData.ActorComp;
				flag = ((actorComp != null) ? new bool?(actorComp.IsAutonomousProxy) : null).GetValueOrDefault();
			}
			if (flag)
			{
				ControllerBase<HudUnitController>.Instance.TryDestroyHud(EHudUnitType.LuPaAim);
			}
		}
	}
}
