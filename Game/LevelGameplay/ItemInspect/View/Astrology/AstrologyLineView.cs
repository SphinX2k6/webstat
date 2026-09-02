using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.View.Astrology
{
	// Token: 0x02006E4F RID: 28239
	public class AstrologyLineView : UiPanelBase
	{
		// Token: 0x060448C0 RID: 280768 RVA: 0x011D2700 File Offset: 0x011D0900
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x060448C1 RID: 280769 RVA: 0x011D272A File Offset: 0x011D092A
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x060448C2 RID: 280770 RVA: 0x011D2744 File Offset: 0x011D0944
		[NullableContext(1)]
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x060448C3 RID: 280771 RVA: 0x011D275C File Offset: 0x011D095C
		public void SetLineActive(bool isActive)
		{
			if (isActive == this.IsActive)
			{
				return;
			}
			this.IsActive = isActive;
			this.SequencePlayer.StopPrevSequence(false, true);
			if (isActive)
			{
				this.SetActive(true);
				this.SequencePlayer.PlaySequencePurely("Start", false, false);
				return;
			}
			this.SequencePlayer.PlaySequencePurely("Close", false, false);
		}

		// Token: 0x04026292 RID: 156306
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04026293 RID: 156307
		private bool IsActive;
	}
}
