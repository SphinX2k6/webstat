using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD7 RID: 27607
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventRestoreCameraLookAtPosition : LevelEventBase
	{
		// Token: 0x06044095 RID: 278677 RVA: 0x011A5CB6 File Offset: 0x011A3EB6
		public LevelEventRestoreCameraLookAtPosition(int id) : base(id)
		{
		}

		// Token: 0x06044096 RID: 278678 RVA: 0x011A5CC8 File Offset: 0x011A3EC8
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (this.EnableDebugLog)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraLookAt] LevelEventRestoreCameraLookAtPosition Start", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			if (fightCamera != null)
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				if (logicComponent != null)
				{
					logicComponent.ExitCameraGuide();
				}
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044097 RID: 278679 RVA: 0x011A5D27 File Offset: 0x011A3F27
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x04026062 RID: 155746
		private readonly bool EnableDebugLog = true;
	}
}
