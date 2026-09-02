using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card
{
	// Token: 0x02005622 RID: 22050
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardShowComponent : UiPanelBase
	{
		// Token: 0x06038326 RID: 230182 RVA: 0x00E3B0C3 File Offset: 0x00E392C3
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06038327 RID: 230183 RVA: 0x00E3B0ED File Offset: 0x00E392ED
		protected override void OnDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06038328 RID: 230184 RVA: 0x00E3B0FA File Offset: 0x00E392FA
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Start" && !this.SkipDisActive)
			{
				this.PlayClose();
				return;
			}
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06038329 RID: 230185 RVA: 0x00E3B12C File Offset: 0x00E3932C
		public void PlayStart()
		{
			this.SkipDisActive = false;
			this.SetActive(true);
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely("Start", false, false);
		}

		// Token: 0x0603832A RID: 230186 RVA: 0x00E3B15B File Offset: 0x00E3935B
		public void PlayClose()
		{
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely("Close", false, false);
		}

		// Token: 0x0603832B RID: 230187 RVA: 0x00E3B17C File Offset: 0x00E3937C
		public void PlayLoop()
		{
			this.SkipDisActive = true;
			this.SetActive(true);
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely("Start", false, false);
			this.Sequence.PlaySequencePurely("Loop", false, false);
		}

		// Token: 0x04020192 RID: 131474
		protected UiSequencePlayer Sequence;

		// Token: 0x04020193 RID: 131475
		protected bool SkipDisActive;
	}
}
