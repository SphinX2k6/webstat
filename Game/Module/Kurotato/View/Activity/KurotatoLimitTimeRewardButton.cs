using System;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE6 RID: 23270
	public class KurotatoLimitTimeRewardButton : KurotatoRewardButton
	{
		// Token: 0x0603AD3C RID: 240956 RVA: 0x00EEB3AC File Offset: 0x00EE95AC
		public void BindRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotKurotatoLimitRewardBtn, base.GetItem(2), null, 0);
		}

		// Token: 0x0603AD3D RID: 240957 RVA: 0x00EEB3C6 File Offset: 0x00EE95C6
		public void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotKurotatoLimitRewardBtn, base.GetItem(2), 0);
		}
	}
}
