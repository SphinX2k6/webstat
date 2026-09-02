using System;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C21 RID: 23585
	public class InstanceDungeonEntranceFlowAttached : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA06 RID: 244230 RVA: 0x00F1BC88 File Offset: 0x00F19E88
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				MowingInstanceDungeonViewModel param = new MowingInstanceDungeonViewModel();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonEntranceView, param, null);
			});
			base.AddStep(delegate
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, false, true, false, null);
			});
			base.AddStep(delegate
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterInstanceDungeon().ContinueWith(delegate(bool result)
				{
					ControllerBase<EditBattleTeamController>.Instance.CloseEditBattleTeamView();
					if (result)
					{
						base.Reset();
						return;
					}
					base.RevertStep();
				});
			});
		}
	}
}
