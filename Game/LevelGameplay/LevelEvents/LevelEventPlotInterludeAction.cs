using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BCC RID: 27596
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelEventPlotInterludeAction : LevelEventBase
	{
		// Token: 0x0604406F RID: 278639 RVA: 0x011A43DD File Offset: 0x011A25DD
		public LevelEventPlotInterludeAction(int id) : base(id)
		{
		}

		// Token: 0x06044070 RID: 278640 RVA: 0x011A43E8 File Offset: 0x011A25E8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.Param = (inParams as ActionPlotInterludeAction);
			this.Context = context;
			this.Color = new FLinearColor?(new FLinearColor(0f, 0f, 0f, 1f));
			this.CameraManager = Global.CharacterCameraManager;
			if (!ObjectUtils.IsValid(this.CameraManager))
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.CameraManager.StartCameraFade(0f, 1f, this.Param.FadeInTime, this.Color.Value, false, true, ECameraFadeMode.CFM_Linear);
			TimerSystem.Instance.Delay(new TTimerAction(this.OnFadeInEnded), this.Param.FadeInTime * 1000f, null, null, true, 1f);
		}

		// Token: 0x06044071 RID: 278641 RVA: 0x011A44B9 File Offset: 0x011A26B9
		private void OnFadeInEnded(float _)
		{
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(this.Param.ActionList, GeneralContext.Copy(this.Context), delegate(ELevelEventState _)
			{
				TimerSystem.Instance.Delay(new TTimerAction(this.OnActionDone), 2000f, null, null, true, 1f);
			});
		}

		// Token: 0x06044072 RID: 278642 RVA: 0x011A44E8 File Offset: 0x011A26E8
		private void OnActionDone(float _)
		{
			if (!ObjectUtils.IsValid(this.CameraManager))
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.CameraManager.StartCameraFade(1f, 0f, this.Param.FadeOutTime, this.Color.Value, false, false, ECameraFadeMode.CFM_Linear);
			TimerSystem.Instance.Delay(new TTimerAction(this.OnInterludeEnded), this.Param.FadeOutTime, null, null, true, 1f);
		}

		// Token: 0x06044073 RID: 278643 RVA: 0x011A4564 File Offset: 0x011A2764
		private void OnInterludeEnded(float _)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044074 RID: 278644 RVA: 0x011A456F File Offset: 0x011A276F
		protected override void OnReset()
		{
			this.Param = null;
			this.Context = null;
			this.Color = null;
			this.CameraManager = null;
		}

		// Token: 0x0402605A RID: 155738
		private ActionPlotInterludeAction Param;

		// Token: 0x0402605B RID: 155739
		private GeneralContext Context;

		// Token: 0x0402605C RID: 155740
		private FLinearColor? Color;

		// Token: 0x0402605D RID: 155741
		private APlayerCameraManager CameraManager;
	}
}
