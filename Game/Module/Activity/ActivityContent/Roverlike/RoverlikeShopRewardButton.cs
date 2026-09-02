using System;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063DA RID: 25562
	public class RoverlikeShopRewardButton : RoverlikeRewardButton
	{
		// Token: 0x06040314 RID: 262932 RVA: 0x01073911 File Offset: 0x01071B11
		protected override void OnStart()
		{
			this.ClickCallback = delegate()
			{
				RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
				int? num;
				if (instance == null)
				{
					num = null;
				}
				else
				{
					RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
					RoverRogueActivity? roverRogueActivity;
					num = ((currentActivityData != null) ? ((currentActivityData.GetParamConfig() != null) ? new int?(roverRogueActivity.GetValueOrDefault().ShopId) : null) : null);
				}
				int? num2 = num;
				if (num2.GetValueOrDefault() <= 0)
				{
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeShopView, null, null);
			};
		}

		// Token: 0x06040315 RID: 262933 RVA: 0x01073938 File Offset: 0x01071B38
		public void BindRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotRoverlikeShopRewardBtn, base.GetItem(2), null, 0);
		}

		// Token: 0x06040316 RID: 262934 RVA: 0x01073952 File Offset: 0x01071B52
		public void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotRoverlikeShopRewardBtn, base.GetItem(2), 0);
		}
	}
}
