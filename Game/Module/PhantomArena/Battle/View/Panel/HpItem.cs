using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055BD RID: 21949
	public class HpItem : UiPanelBase
	{
		// Token: 0x06037E41 RID: 228929 RVA: 0x00E294C2 File Offset: 0x00E276C2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037E42 RID: 228930 RVA: 0x00E294E5 File Offset: 0x00E276E5
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06037E43 RID: 228931 RVA: 0x00E2950F File Offset: 0x00E2770F
		protected override void OnDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037E44 RID: 228932 RVA: 0x00E2951C File Offset: 0x00E2771C
		[NullableContext(1)]
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.PlayClose();
				return;
			}
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037E45 RID: 228933 RVA: 0x00E29546 File Offset: 0x00E27746
		public void RefreshHpNum(int cost)
		{
			base.GetText(0).SetText(cost.ToString(), true);
		}

		// Token: 0x06037E46 RID: 228934 RVA: 0x00E2955C File Offset: 0x00E2775C
		public UniTask PlayStart()
		{
			HpItem.<PlayStart>d__7 <PlayStart>d__;
			<PlayStart>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStart>d__.<>4__this = this;
			<PlayStart>d__.<>1__state = -1;
			<PlayStart>d__.<>t__builder.Start<HpItem.<PlayStart>d__7>(ref <PlayStart>d__);
			return <PlayStart>d__.<>t__builder.Task;
		}

		// Token: 0x06037E47 RID: 228935 RVA: 0x00E2959F File Offset: 0x00E2779F
		public void PlayClose()
		{
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely("Close", false, false);
		}

		// Token: 0x0401FFC2 RID: 131010
		[Nullable(1)]
		protected UiSequencePlayer Sequence;

		// Token: 0x0200B583 RID: 46467
		private class EHpItem
		{
			// Token: 0x040382B8 RID: 230072
			public const int NumText = 0;
		}
	}
}
