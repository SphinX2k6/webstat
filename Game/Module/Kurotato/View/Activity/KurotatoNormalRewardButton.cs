using System;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE5 RID: 23269
	public class KurotatoNormalRewardButton : KurotatoRewardButton
	{
		// Token: 0x0603AD39 RID: 240953 RVA: 0x00EEB371 File Offset: 0x00EE9571
		public void BindRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotKurotatoNormalRewardBtn, base.GetItem(2), null, 0);
		}

		// Token: 0x0603AD3A RID: 240954 RVA: 0x00EEB38B File Offset: 0x00EE958B
		public void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotKurotatoNormalRewardBtn, base.GetItem(2), 0);
		}
	}
}
