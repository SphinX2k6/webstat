using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005547 RID: 21831
	[NullableContext(1)]
	[Nullable(0)]
	public class CardCommonComponent : CardComponentBase
	{
		// Token: 0x06037A6B RID: 227947 RVA: 0x00E1E2BD File Offset: 0x00E1C4BD
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06037A6C RID: 227948 RVA: 0x00E1E2E7 File Offset: 0x00E1C4E7
		protected override void OnDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037A6D RID: 227949 RVA: 0x00E1E2F4 File Offset: 0x00E1C4F4
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close".ToString())
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037A6E RID: 227950 RVA: 0x00E1E30F File Offset: 0x00E1C50F
		public void SetComponentActive(bool isActive)
		{
			this.Sequence.StopPrevSequence(false, true);
			if (isActive)
			{
				this.SetActive(true);
				this.Sequence.PlaySequencePurely("Start", false, false);
				return;
			}
			this.Sequence.PlaySequencePurely("Close", false, false);
		}

		// Token: 0x06037A6F RID: 227951 RVA: 0x00E1E34D File Offset: 0x00E1C54D
		public void SetComponentDisActiveWithoutSequence()
		{
			this.SetActive(false);
		}

		// Token: 0x06037A70 RID: 227952 RVA: 0x00E1E356 File Offset: 0x00E1C556
		public override void Refresh(object data)
		{
		}

		// Token: 0x0401FE5A RID: 130650
		protected UiSequencePlayer Sequence;
	}
}
