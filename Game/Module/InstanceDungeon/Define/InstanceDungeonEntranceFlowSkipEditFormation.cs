using System;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C2B RID: 23595
	public class InstanceDungeonEntranceFlowSkipEditFormation : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA32 RID: 244274 RVA: 0x00F1C3D8 File Offset: 0x00F1A5D8
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonEntranceView, null, null);
			});
			base.AddStep(delegate
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterInstanceDungeonByAutoRole().ContinueWith(delegate(bool result)
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
