using System;

namespace CSharpScript.Game.Module.BattleUi.SpecialRoleData
{
	// Token: 0x02006126 RID: 24870
	public class BattleUiSpecialRoleDataAiMiSi : BattleUiSpecialRoleDataBase
	{
		// Token: 0x0603ED6C RID: 257388 RVA: 0x01019D4C File Offset: 0x01017F4C
		protected override void OnInit()
		{
			BattleUiRoleData roleData = this.RoleData;
			bool? flag;
			if (roleData == null)
			{
				flag = null;
			}
			else
			{
				CharacterActorComponent actorComp = roleData.ActorComp;
				flag = ((actorComp != null) ? new bool?(actorComp.IsAutonomousProxy) : null);
			}
			bool? flag2 = flag;
			this.IsAutonomousProxy = flag2.GetValueOrDefault();
			if (!this.IsAutonomousProxy)
			{
				return;
			}
			int count = ModelBase<BattleUiModel>.Instance.GetCount(EBattleUiCountType.AimisiRoleCount) + 1;
			ModelBase<BattleUiModel>.Instance.SetCount(EBattleUiCountType.AimisiRoleCount, count);
			ControllerBase<HudUnitController>.Instance.TryCreateHud(EHudUnitType.AiMiSiHud);
		}

		// Token: 0x0603ED6D RID: 257389 RVA: 0x01019DCC File Offset: 0x01017FCC
		protected override void OnClear()
		{
			if (!this.IsAutonomousProxy)
			{
				return;
			}
			this.IsAutonomousProxy = false;
			int num = Math.Max(ModelBase<BattleUiModel>.Instance.GetCount(EBattleUiCountType.AimisiRoleCount) - 1, 0);
			ModelBase<BattleUiModel>.Instance.SetCount(EBattleUiCountType.AimisiRoleCount, num);
			if (num <= 0)
			{
				ControllerBase<HudUnitController>.Instance.TryDestroyHud(EHudUnitType.AiMiSiHud);
			}
		}

		// Token: 0x0402341B RID: 144411
		private bool IsAutonomousProxy;
	}
}
