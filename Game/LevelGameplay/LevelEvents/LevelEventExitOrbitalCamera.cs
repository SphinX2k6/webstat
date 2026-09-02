using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B9F RID: 27551
	public class LevelEventExitOrbitalCamera : LevelEventBase
	{
		// Token: 0x06043FA8 RID: 278440 RVA: 0x0119D6C5 File Offset: 0x0119B8C5
		public LevelEventExitOrbitalCamera(int id) : base(id)
		{
		}

		// Token: 0x06043FA9 RID: 278441 RVA: 0x0119D6CE File Offset: 0x0119B8CE
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			ControllerBase<CameraController>.Instance.MainModel.OrbitalCamera.PlayerComponent.StopCameraOrbital();
		}

		// Token: 0x06043FAA RID: 278442 RVA: 0x0119D6F8 File Offset: 0x0119B8F8
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.ExitOrbitalCamera
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, null);
		}
	}
}
