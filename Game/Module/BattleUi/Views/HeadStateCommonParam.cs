using System;
using Aki.Config;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200602C RID: 24620
	public class HeadStateCommonParam
	{
		// Token: 0x0603E126 RID: 254246 RVA: 0x00FD7904 File Offset: 0x00FD5B04
		public void Init()
		{
			this.OutMonsterHalfHeight = ConfigCommonParamById.GetFloatConfig("HeadStateOutMonsterHeight").Value / 2f;
			this.OutTopMargin = ConfigCommonParamById.GetFloatConfig("HeadStateOutTopMargin").Value;
			this.OutHorizontalMargin = ConfigCommonParamById.GetFloatConfig("HeadStateOutHorizontalMargin").Value;
		}

		// Token: 0x04022CAD RID: 142509
		public float OutMonsterHalfHeight;

		// Token: 0x04022CAE RID: 142510
		public float OutTopMargin;

		// Token: 0x04022CAF RID: 142511
		public float OutHorizontalMargin;

		// Token: 0x04022CB0 RID: 142512
		public bool DrawHeadStateSocket;
	}
}
