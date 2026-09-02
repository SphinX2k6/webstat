using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Field
{
	// Token: 0x020055C5 RID: 21957
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaFieldEffectItem : UiPanelBase
	{
		// Token: 0x06037ED9 RID: 229081 RVA: 0x00E2B520 File Offset: 0x00E29720
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037EDA RID: 229082 RVA: 0x00E2B543 File Offset: 0x00E29743
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06037EDB RID: 229083 RVA: 0x00E2B56D File Offset: 0x00E2976D
		protected override void OnDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037EDC RID: 229084 RVA: 0x00E2B57A File Offset: 0x00E2977A
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037EDD RID: 229085 RVA: 0x00E2B590 File Offset: 0x00E29790
		public void SetName(string name)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), name, Array.Empty<object>());
		}

		// Token: 0x06037EDE RID: 229086 RVA: 0x00E2B5A9 File Offset: 0x00E297A9
		public void PlayStart()
		{
			this.SetActive(true);
			this.Sequence.PlaySequencePurely("Start", false, false);
		}

		// Token: 0x0401FFE7 RID: 131047
		protected UiSequencePlayer Sequence;

		// Token: 0x0200B5AD RID: 46509
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038377 RID: 230263
			public const int Name = 0;
		}
	}
}
