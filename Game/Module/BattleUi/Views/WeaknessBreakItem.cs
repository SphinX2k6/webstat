using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006124 RID: 24868
	[NullableContext(2)]
	[Nullable(0)]
	public class WeaknessBreakItem : UiPanelBase
	{
		// Token: 0x0603ED56 RID: 257366 RVA: 0x01019900 File Offset: 0x01017B00
		[NullableContext(1)]
		public UniTask InitializeAsync(UUIItem parentItem)
		{
			WeaknessBreakItem.<InitializeAsync>d__3 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.parentItem = parentItem;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<WeaknessBreakItem.<InitializeAsync>d__3>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ED57 RID: 257367 RVA: 0x0101994B File Offset: 0x01017B4B
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603ED58 RID: 257368 RVA: 0x0101995E File Offset: 0x01017B5E
		public void Play()
		{
			if (this.IsPlaying)
			{
				return;
			}
			this.IsPlaying = true;
			base.Show(null);
		}

		// Token: 0x0603ED59 RID: 257369 RVA: 0x01019978 File Offset: 0x01017B78
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
			this.RemoveBreakingTimer();
			this.BreakingTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnBreakingTimerEnd), 2000f, null, null, true, 1f);
		}

		// Token: 0x0603ED5A RID: 257370 RVA: 0x010199D5 File Offset: 0x01017BD5
		private void OnBreakingTimerEnd(float _)
		{
			this.BreakingTimer = null;
			this.IsPlaying = false;
			base.Hide(null);
		}

		// Token: 0x0603ED5B RID: 257371 RVA: 0x010199EC File Offset: 0x01017BEC
		private void RemoveBreakingTimer()
		{
			if (this.BreakingTimer != null)
			{
				TimerSystem.Instance.Remove(this.BreakingTimer);
				this.BreakingTimer = null;
			}
		}

		// Token: 0x0603ED5C RID: 257372 RVA: 0x01019A0E File Offset: 0x01017C0E
		protected override void OnBeforeHide()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopPlayingSequence(false, true);
			}
			this.IsPlaying = false;
			this.RemoveBreakingTimer();
		}

		// Token: 0x04023413 RID: 144403
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04023414 RID: 144404
		private bool IsPlaying;

		// Token: 0x04023415 RID: 144405
		private TimerHandle BreakingTimer;
	}
}
