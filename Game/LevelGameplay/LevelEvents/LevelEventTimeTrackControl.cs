using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.TimeTrackControl;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C1A RID: 27674
	public class LevelEventTimeTrackControl : LevelEventBase
	{
		// Token: 0x0604419A RID: 278938 RVA: 0x011AEDA3 File Offset: 0x011ACFA3
		public LevelEventTimeTrackControl(int id) : base(id)
		{
		}

		// Token: 0x0604419B RID: 278939 RVA: 0x011AEDAC File Offset: 0x011ACFAC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ActionTimeTrackControl actionTimeTrackControl = inParams as ActionTimeTrackControl;
			if (actionTimeTrackControl == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:LevelEventTimeTrackControl params转换失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			long entityId = actionTimeTrackControl.EntityId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			if (entity == null || !entity.Valid)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:LevelEventTimeTrackControl entity不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			TsInteractionUtils.RegisterOpenViewName(EUiViewName.TimeTrackControlView);
			ControllerBase<TimeTrackController>.Instance.OpenTimeTrackControlView(entityId, actionTimeTrackControl.ConfigIndex, new Action<bool>(this.OnResponse));
		}

		// Token: 0x0604419C RID: 278940 RVA: 0x011AEE59 File Offset: 0x011AD059
		private void OnResponse(bool isSuccess)
		{
			base.FinishExecute(isSuccess, false, true);
		}
	}
}
