using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055BC RID: 21948
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaDialogItem : UiPanelBase
	{
		// Token: 0x06037E3A RID: 228922 RVA: 0x00E293EB File Offset: 0x00E275EB
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037E3B RID: 228923 RVA: 0x00E2940E File Offset: 0x00E2760E
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06037E3C RID: 228924 RVA: 0x00E29438 File Offset: 0x00E27638
		protected override void OnDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037E3D RID: 228925 RVA: 0x00E29445 File Offset: 0x00E27645
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037E3E RID: 228926 RVA: 0x00E2945B File Offset: 0x00E2765B
		public UUIText GetDialog()
		{
			return base.GetText(0);
		}

		// Token: 0x06037E3F RID: 228927 RVA: 0x00E29464 File Offset: 0x00E27664
		public void SetDialogActive(bool active)
		{
			if (active)
			{
				this.SetActive(true);
				this.Sequence.StopPrevSequence(false, true);
				this.Sequence.PlaySequencePurely("Start", false, false);
				return;
			}
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely("Close", false, false);
		}

		// Token: 0x0401FFC1 RID: 131009
		protected UiSequencePlayer Sequence;

		// Token: 0x0200B582 RID: 46466
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040382B7 RID: 230071
			public const int DialogText = 0;
		}
	}
}
