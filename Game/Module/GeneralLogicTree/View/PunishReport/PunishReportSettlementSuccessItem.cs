using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.GeneralLogicTree.View.PunishReport
{
	// Token: 0x02005CCD RID: 23757
	[NullableContext(1)]
	[Nullable(0)]
	public class PunishReportSettlementSuccessItem : UiPanelBase
	{
		// Token: 0x0603BE85 RID: 245381 RVA: 0x00F2EC1D File Offset: 0x00F2CE1D
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x0603BE86 RID: 245382 RVA: 0x00F2EC4E File Offset: 0x00F2CE4E
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x0603BE87 RID: 245383 RVA: 0x00F2EC68 File Offset: 0x00F2CE68
		public UniTask ShowTip()
		{
			PunishReportSettlementSuccessItem.<ShowTip>d__4 <ShowTip>d__;
			<ShowTip>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowTip>d__.<>4__this = this;
			<ShowTip>d__.<>1__state = -1;
			<ShowTip>d__.<>t__builder.Start<PunishReportSettlementSuccessItem.<ShowTip>d__4>(ref <ShowTip>d__);
			return <ShowTip>d__.<>t__builder.Task;
		}

		// Token: 0x0603BE88 RID: 245384 RVA: 0x00F2ECAB File Offset: 0x00F2CEAB
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.CustomPromise.SetResult(true);
			}
		}

		// Token: 0x04021ACD RID: 137933
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04021ACE RID: 137934
		private readonly CustomPromise<bool> CustomPromise = new CustomPromise<bool>();
	}
}
