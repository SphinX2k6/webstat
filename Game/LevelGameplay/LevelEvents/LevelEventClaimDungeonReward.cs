using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B79 RID: 27513
	public class LevelEventClaimDungeonReward : LevelEventBase
	{
		// Token: 0x06043EFC RID: 278268 RVA: 0x01198215 File Offset: 0x01196415
		public LevelEventClaimDungeonReward(int id) : base(id)
		{
		}

		// Token: 0x06043EFD RID: 278269 RVA: 0x01198220 File Offset: 0x01196420
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			int? costPower = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(instanceId);
			if (costPower != null)
			{
				int? costPower2 = costPower;
				int num = 0;
				if (!(costPower2.GetValueOrDefault() <= num & costPower2 != null))
				{
					if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanReward(instanceId))
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonRewardTimeNotEnough", Array.Empty<object>());
						return;
					}
					bool powerEnough = ModelBase<PowerModel>.Instance.IsPowerEnough(costPower);
					if (!powerEnough)
					{
						string textById = ConfigBase<TextConfig>.Instance.GetTextById("ReceiveLevelPlayPowerNotEnough");
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
						ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, costPower.Value);
						return;
					}
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ReceiveLevelPlayReward);
					confirmBoxDataNew.ShowPowerItem = true;
					confirmBoxDataNew.SetTextArgs(new string[]
					{
						costPower.ToString()
					});
					confirmBoxDataNew.FunctionMap[2] = delegate()
					{
						if (!powerEnough)
						{
							string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("ReceiveLevelPlayPowerNotEnough");
							ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById2);
							ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, costPower.Value);
							return;
						}
						ControllerBase<InstanceDungeonController>.Instance.GetInstExchangeRewardRequest(1);
					};
					ActivityDoubleRewardData dungeonUpActivity = ControllerBase<ActivityDoubleRewardController>.Instance.GetDungeonUpActivity(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.CustomTypes(), true);
					if (dungeonUpActivity != null && dungeonUpActivity.LeftUpCount > 0)
					{
						confirmBoxDataNew.Tip = dungeonUpActivity.GetFullTip();
					}
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return;
				}
			}
		}
	}
}
