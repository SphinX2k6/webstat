using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.LevelplayCapability
{
	// Token: 0x02006CA5 RID: 27813
	public class LevelEventToggleDragActorPlay : LevelEventBase
	{
		// Token: 0x0604434C RID: 279372 RVA: 0x011B3FBD File Offset: 0x011B21BD
		public LevelEventToggleDragActorPlay(int id) : base(id)
		{
		}

		// Token: 0x0604434D RID: 279373 RVA: 0x011B3FC8 File Offset: 0x011B21C8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ToggleDragActorPlay toggleDragActorPlay = inParams as ToggleDragActorPlay;
			EToggleDragActorPlayType type = toggleDragActorPlay.Config.Type;
			if (type == EToggleDragActorPlayType.Enable)
			{
				ControllerBase<SplineConstrainedDragController>.Instance.EnableDragActorPlay(toggleDragActorPlay.Config as IToggleDragActorPlayEnable);
				return;
			}
			if (type != EToggleDragActorPlayType.Disable)
			{
				return;
			}
			ControllerBase<SplineConstrainedDragController>.Instance.DisableDragActorPlay();
		}
	}
}
