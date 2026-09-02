using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C43 RID: 23619
	public class RoleTrialExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA99 RID: 244377 RVA: 0x00F1D4B4 File Offset: 0x00F1B6B4
		public override bool Checker()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType == 40;
		}

		// Token: 0x0603BA9A RID: 244378 RVA: 0x00F1D508 File Offset: 0x00F1B708
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			RoleTrialExitHandler.<>c__DisplayClass1_0 CS$<>8__locals1 = new RoleTrialExitHandler.<>c__DisplayClass1_0();
			CS$<>8__locals1.data = data;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(this.IsCyberPunkRoleTrialInstance() ? EConfirmBoxConfigId.CyberPunkRoleTrialExitConfirm : EConfirmBoxConfigId.RoleTrialLeaveInstanceConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			Dictionary<int, Action> functionMap = confirmBoxDataNew.FunctionMap;
			int key = 0;
			InstanceDungeonExitHandlerData data2 = CS$<>8__locals1.data;
			functionMap[key] = ((data2 != null) ? data2.CancelBack : null);
			confirmBoxDataNew.FunctionMap[1] = new Action(CS$<>8__locals1.<HandleExit>g__ReChallenge|1);
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<HandleExit>g__Leave|0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603BA9B RID: 244379 RVA: 0x00F1D5A0 File Offset: 0x00F1B7A0
		private bool IsCyberPunkRoleTrialInstance()
		{
			foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(8))
			{
				ActivityRoleTrialData activityRoleTrialData = activityBaseData as ActivityRoleTrialData;
				if (activityRoleTrialData != null && activityRoleTrialData.IsRoleInstanceOn())
				{
					CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
					IReadOnlyList<EdgeRunnerTrial> readOnlyList = (instance != null) ? instance.GetTrialRoleListByTrialActivityId(activityRoleTrialData.Id) : null;
					if (readOnlyList != null && readOnlyList.Count > 0)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
