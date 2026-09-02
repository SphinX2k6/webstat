using System;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C29 RID: 23593
	public class InstanceDungeonEntranceFlowNormal : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA2C RID: 244268 RVA: 0x00F1C2A8 File Offset: 0x00F1A4A8
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				InstanceDungeonViewModelBase param;
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId == 9000)
				{
					param = new SolarSpeedInstanceDungeonViewModel();
				}
				else
				{
					param = new BaseInstanceDungeonViewModel();
				}
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
