using System;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063DB RID: 25563
	public class RoverlikeQuestRewardButton : RoverlikeRewardButton
	{
		// Token: 0x06040318 RID: 262936 RVA: 0x01073973 File Offset: 0x01071B73
		protected override void OnStart()
		{
			this.ClickCallback = delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeQuestRewardView, null, null);
			};
		}

		// Token: 0x06040319 RID: 262937 RVA: 0x0107399A File Offset: 0x01071B9A
		public void BindRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotRoverlikeQuestRewardBtn, base.GetItem(2), null, 0);
		}

		// Token: 0x0604031A RID: 262938 RVA: 0x010739B4 File Offset: 0x01071BB4
		public void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotRoverlikeQuestRewardBtn, base.GetItem(2), 0);
		}
	}
}
