using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F8D RID: 28557
	public class LevelFlowDeadEyeMode : LevelFlowActionBase
	{
		// Token: 0x0604518C RID: 283020 RVA: 0x01206148 File Offset: 0x01204348
		[NullableContext(1)]
		public LevelFlowDeadEyeMode Init(DeadEyeModeParams params_)
		{
			this.Params = params_;
			return this;
		}

		// Token: 0x0604518D RID: 283021 RVA: 0x01206152 File Offset: 0x01204352
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnDeadEyeModeFinish, new Action(this.OnDeadEyeModeFinish));
		}

		// Token: 0x0604518E RID: 283022 RVA: 0x01206170 File Offset: 0x01204370
		protected override void OnExecute()
		{
			if (this.Params == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "执行行为LevelFlowDeadEyeMode失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			ControllerBase<DeadEyeModeController>.Instance.EnterDeadEyeModeWithoutEntity(this.Params);
		}

		// Token: 0x0604518F RID: 283023 RVA: 0x012061BD File Offset: 0x012043BD
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnDeadEyeModeFinish, new Action(this.OnDeadEyeModeFinish));
		}

		// Token: 0x06045190 RID: 283024 RVA: 0x012061DB File Offset: 0x012043DB
		private void OnDeadEyeModeFinish()
		{
			base.FinishExecute(true);
		}

		// Token: 0x040268EC RID: 157932
		[Nullable(2)]
		private DeadEyeModeParams Params;
	}
}
