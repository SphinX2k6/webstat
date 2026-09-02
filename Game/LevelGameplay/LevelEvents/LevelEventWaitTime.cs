using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C2C RID: 27692
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventWaitTime : LevelEventBase
	{
		// Token: 0x060441D5 RID: 278997 RVA: 0x011B07BC File Offset: 0x011AE9BC
		public LevelEventWaitTime(int id) : base(id)
		{
		}

		// Token: 0x060441D6 RID: 278998 RVA: 0x011B07C5 File Offset: 0x011AE9C5
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x060441D7 RID: 278999 RVA: 0x011B07D0 File Offset: 0x011AE9D0
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			Wait wait = inParams as Wait;
			this.TotalTime = wait.Time * 1000f;
			if (wait.BanInput.GetValueOrDefault())
			{
				this.DisableInput = true;
				ModelBase<GeneralLogicTreeModel>.Instance.DisableInput = true;
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			}
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, "LevelEventWait");
			if (this.TotalTime <= 0f)
			{
				if (this.DisableInput)
				{
					ModelBase<GeneralLogicTreeModel>.Instance.DisableInput = false;
					ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
					this.DisableInput = false;
				}
				base.FinishExecute(false, false, true);
			}
		}

		// Token: 0x060441D8 RID: 279000 RVA: 0x011B0874 File Offset: 0x011AEA74
		protected override void OnTick(float deltaTime)
		{
			float num = (this.BaseContext != null) ? (deltaTime * LevelGamePlayUtils.GetCustomTimeDilationByContext(this.BaseContext).GetValueOrDefault(1f)) : deltaTime;
			this.TotalTime -= num;
			if (this.TotalTime < 0f)
			{
				if (this.DisableInput)
				{
					ModelBase<GeneralLogicTreeModel>.Instance.DisableInput = false;
					ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
					this.DisableInput = false;
				}
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x060441D9 RID: 279001 RVA: 0x011B08EF File Offset: 0x011AEAEF
		protected override void OnReset()
		{
			this.DisableInput = false;
			this.TotalTime = 0f;
		}

		// Token: 0x040260A2 RID: 155810
		private float TotalTime;

		// Token: 0x040260A3 RID: 155811
		private bool DisableInput;
	}
}
