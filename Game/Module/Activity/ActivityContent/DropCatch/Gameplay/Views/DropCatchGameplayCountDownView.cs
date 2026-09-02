using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x020068F8 RID: 26872
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchGameplayCountDownView : UiPanelBase
	{
		// Token: 0x06042C56 RID: 273494 RVA: 0x01122C92 File Offset: 0x01120E92
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequence));
		}

		// Token: 0x06042C57 RID: 273495 RVA: 0x01122CBC File Offset: 0x01120EBC
		protected override void OnAfterShow()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequence("Start", false, null);
		}

		// Token: 0x06042C58 RID: 273496 RVA: 0x01122CE8 File Offset: 0x01120EE8
		[NullableContext(1)]
		private void OnEndSequence(string sequenceName)
		{
			this.IsFinished = true;
			base.Destroy(null);
		}

		// Token: 0x06042C59 RID: 273497 RVA: 0x01122CF8 File Offset: 0x01120EF8
		public void Pause()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PauseSequence();
		}

		// Token: 0x06042C5A RID: 273498 RVA: 0x01122D0A File Offset: 0x01120F0A
		public void Resume()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.ResumeSequence();
		}

		// Token: 0x06042C5B RID: 273499 RVA: 0x01122D1C File Offset: 0x01120F1C
		protected override void OnBeforeDestroy()
		{
			if (this.IsFinished)
			{
				Action closeCallback = this.CloseCallback;
				if (closeCallback != null)
				{
					closeCallback();
				}
			}
			this.CloseCallback = null;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x0402532E RID: 152366
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0402532F RID: 152367
		public Action CloseCallback;

		// Token: 0x04025330 RID: 152368
		private bool IsFinished;
	}
}
