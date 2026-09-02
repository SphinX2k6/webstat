using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F6B RID: 28523
	public class PrepareCountDownItem : UiPanelBase
	{
		// Token: 0x06045080 RID: 282752 RVA: 0x011F9AF0 File Offset: 0x011F7CF0
		protected override void OnRegisterComponent()
		{
		}

		// Token: 0x06045081 RID: 282753 RVA: 0x011F9AF2 File Offset: 0x011F7CF2
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x06045082 RID: 282754 RVA: 0x011F9B1D File Offset: 0x011F7D1D
		[NullableContext(1)]
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				base.HideAsync();
				ModelBase<BigStuffedDollModel>.Instance.EnterNextGameStage();
			}
		}

		// Token: 0x06045083 RID: 282755 RVA: 0x011F9B40 File Offset: 0x011F7D40
		public UniTask StartCountDown()
		{
			PrepareCountDownItem.<StartCountDown>d__5 <StartCountDown>d__;
			<StartCountDown>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartCountDown>d__.<>4__this = this;
			<StartCountDown>d__.<>1__state = -1;
			<StartCountDown>d__.<>t__builder.Start<PrepareCountDownItem.<StartCountDown>d__5>(ref <StartCountDown>d__);
			return <StartCountDown>d__.<>t__builder.Task;
		}

		// Token: 0x0402682A RID: 157738
		protected float RemainTime;

		// Token: 0x0402682B RID: 157739
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;
	}
}
