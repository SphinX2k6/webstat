using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C40 RID: 23616
	public class MultiMotorExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA8D RID: 244365 RVA: 0x00F1D220 File Offset: 0x00F1B420
		public override bool Checker()
		{
			MultiMotorController instance = ControllerBase<MultiMotorController>.Instance;
			return instance != null && instance.CheckInMultiMotorParkourDungeon();
		}

		// Token: 0x0603BA8E RID: 244366 RVA: 0x00F1D23C File Offset: 0x00F1B43C
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BattleViewLeaveInstance);
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (ModelBase<OnlineModel>.Instance.GetIsMyTeam())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MultiMotorHostCannotExit", Array.Empty<object>());
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.BattleViewLeaveInstance);
			confirmBoxDataNew2.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew2.FunctionMap[2] = delegate()
			{
				ControllerBase<OnlineController>.Instance.LeaveWorldTeamRequest(ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault(), null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
		}
	}
}
