using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C47 RID: 23623
	public class WheelTowerExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BAA6 RID: 244390 RVA: 0x00F1D7AC File Offset: 0x00F1B9AC
		public override bool Checker()
		{
			return ModelBase<WheelTowerModel>.Instance.CheckInInstanceDungeon();
		}

		// Token: 0x0603BAA7 RID: 244391 RVA: 0x00F1D7B8 File Offset: 0x00F1B9B8
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			bool flag = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.WheelTowerModeSelectView);
			bool flag2 = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.WheelTowerMainView);
			if (flag || flag2)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerReturnWorldConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerInstanceExitConfirm);
			confirmBoxDataNew2.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew2.FunctionMap[1] = delegate()
			{
				ControllerBase<WheelTowerController>.Instance.SetBanTimeStop(false);
				ControllerBase<WheelTowerController>.Instance.RequestEndChallenge(delegate
				{
					int selectedRound = ModelBase<WheelTowerModel>.Instance.SelectedRound;
					Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerPrepareView, selectedRound, null);
				});
			};
			confirmBoxDataNew2.FunctionMap[2] = delegate()
			{
				ControllerBase<WheelTowerController>.Instance.RequestSelectedRoundChallenge();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
		}
	}
}
