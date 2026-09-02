using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Assistant
{
	// Token: 0x020053A2 RID: 21410
	public class FlowAssistant : SeqBaseAssistant
	{
		// Token: 0x06036990 RID: 223632 RVA: 0x00DD0A18 File Offset: 0x00DCEC18
		[NullableContext(2)]
		public override void PreAllPlay(Action<bool> callback = null)
		{
			this.Model.SubSeqLen = new int?(this.Model.SequenceData.剧情资源.Num());
			this.Model.LastIndex = 0;
			this.Model.SubSeqIndex = 0;
			this.Model.NextIndex = 0;
		}

		// Token: 0x06036991 RID: 223633 RVA: 0x00DD0A70 File Offset: 0x00DCEC70
		public override void PreEachPlay()
		{
			this.Model.NextIndex++;
			int nextIndex = this.Model.NextIndex;
			int? subSeqLen = this.Model.SubSeqLen;
			if (nextIndex == subSeqLen.GetValueOrDefault() & subSeqLen != null)
			{
				this.Model.NextIndex = -1;
			}
		}

		// Token: 0x06036992 RID: 223634 RVA: 0x00DD0AC6 File Offset: 0x00DCECC6
		public override void EachStop()
		{
			this.Model.LastIndex = this.Model.SubSeqIndex;
			this.Model.SubSeqIndex = this.Model.NextIndex;
		}

		// Token: 0x06036993 RID: 223635 RVA: 0x00DD0AF4 File Offset: 0x00DCECF4
		public void SetNextSequenceIndex(int index)
		{
			this.Model.NextIndex = index;
		}
	}
}
