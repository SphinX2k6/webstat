using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF7 RID: 27639
	public class LevelEventShowPlotPhoto : LevelEventBase
	{
		// Token: 0x0604410F RID: 278799 RVA: 0x011AB990 File Offset: 0x011A9B90
		public LevelEventShowPlotPhoto(int id) : base(id)
		{
		}

		// Token: 0x06044110 RID: 278800 RVA: 0x011AB99C File Offset: 0x011A9B9C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (!(inParams is TakePlotPhoto))
			{
				return;
			}
			ControllerBase<PhotographController>.Instance.CameraCaptureType = ECameraCaptureType.EntityCamera;
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhotographView) && ControllerBase<PhotographController>.Instance.TryOpenPhotograph(ECameraCaptureType.EntityCamera))
			{
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.PhotographView);
			}
			base.FinishExecute(true, false, true);
		}
	}
}
