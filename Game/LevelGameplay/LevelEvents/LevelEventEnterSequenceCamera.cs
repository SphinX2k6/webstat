using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B95 RID: 27541
	public class LevelEventEnterSequenceCamera : LevelEventBase
	{
		// Token: 0x06043F63 RID: 278371 RVA: 0x0119BA94 File Offset: 0x01199C94
		public LevelEventEnterSequenceCamera(int id) : base(id)
		{
		}

		// Token: 0x06043F64 RID: 278372 RVA: 0x0119BA9D File Offset: 0x01199C9D
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			if ((inParams as ActionEnterSequenceCamera).ShouldEnter)
			{
				ModelBase<PlotModel>.Instance.SwitchCameraMode(EPlotCameraMode.PlotMain);
				return;
			}
			ModelBase<PlotModel>.Instance.SwitchCameraMode(EPlotCameraMode.Main);
		}
	}
}
