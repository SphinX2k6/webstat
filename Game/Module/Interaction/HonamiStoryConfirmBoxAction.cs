using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B9D RID: 23453
	public class HonamiStoryConfirmBoxAction : InteractConfirmBoxActionBase
	{
		// Token: 0x0603B527 RID: 242983 RVA: 0x00F06030 File Offset: 0x00F04230
		[NullableContext(2)]
		protected override ConfirmBoxDataNew ConfigConfirmBoxData()
		{
			IHonamiStoryCorruptedChestConfirmBox honamiStoryCorruptedChestConfirmBox = this.Context.Option.ConfirmBox.Type as IHonamiStoryCorruptedChestConfirmBox;
			if (honamiStoryCorruptedChestConfirmBox == null)
			{
				return null;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((EConfirmBoxConfigId)honamiStoryCorruptedChestConfirmBox.Id);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				this.GetLifeSupportCost().ToString()
			});
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				base.ExecuteFinish(false);
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				base.ExecuteFinish(true);
			};
			return confirmBoxDataNew;
		}

		// Token: 0x0603B528 RID: 242984 RVA: 0x00F060B7 File Offset: 0x00F042B7
		public float GetHonamiStoryLifeSupport()
		{
			return ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.HonamiStoryLifeSupport);
		}

		// Token: 0x0603B529 RID: 242985 RVA: 0x00F060C8 File Offset: 0x00F042C8
		public int GetLifeSupportCost()
		{
			InteractSecondConfirmContext context = this.Context;
			object obj;
			if (context == null)
			{
				obj = null;
			}
			else
			{
				CommonInteractOption option = context.Option;
				obj = ((option != null) ? option.Type : null);
			}
			IInteractActions interactActions = obj as IInteractActions;
			int num = 0;
			if (interactActions != null)
			{
				foreach (ActionInfo actionInfo in interactActions.Actions)
				{
					if (actionInfo.Name == EAction.HonamiStoryReceiveCorruptedChestReward)
					{
						HonamiStoryReceiveCorruptedChestReward honamiStoryReceiveCorruptedChestReward = actionInfo.Params as HonamiStoryReceiveCorruptedChestReward;
						if (honamiStoryReceiveCorruptedChestReward != null)
						{
							int? costGroup = honamiStoryReceiveCorruptedChestReward.CostGroup;
							int num2 = 0;
							if (costGroup.GetValueOrDefault() > num2 & costGroup != null)
							{
								num += HonamiStoryUtil.GetSteadyConsumeByCostGroup(honamiStoryReceiveCorruptedChestReward.CostGroup.GetValueOrDefault());
								continue;
							}
						}
						if (honamiStoryReceiveCorruptedChestReward != null)
						{
							num += honamiStoryReceiveCorruptedChestReward.Cost;
						}
					}
				}
			}
			return num;
		}
	}
}
