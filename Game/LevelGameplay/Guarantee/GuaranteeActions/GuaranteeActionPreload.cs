using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E76 RID: 28278
	public class GuaranteeActionPreload : GuaranteeActionBase
	{
		// Token: 0x06044991 RID: 280977 RVA: 0x011D53B0 File Offset: 0x011D35B0
		[NullableContext(2)]
		protected override void OnExecute(ActionParams @params = null)
		{
			IGuaranteePreloadParams guaranteePreloadParams = @params as IGuaranteePreloadParams;
			if (guaranteePreloadParams == null)
			{
				return;
			}
			if (guaranteePreloadParams.Mp4Names != null)
			{
				ControllerBase<VideoBpController>.Instance.RemovePreload();
			}
		}
	}
}
