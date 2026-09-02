using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006039 RID: 24633
	public class BattleHonamiStoryPlayerLevelView : UiPanelBase
	{
		// Token: 0x0603E237 RID: 254519 RVA: 0x00FDC550 File Offset: 0x00FDA750
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E238 RID: 254520 RVA: 0x00FDC598 File Offset: 0x00FDA798
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x0603E239 RID: 254521 RVA: 0x00FDC5AB File Offset: 0x00FDA7AB
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x0603E23A RID: 254522 RVA: 0x00FDC5C8 File Offset: 0x00FDA7C8
		public void RefreshLevel(int oldValue, int newValue, bool isInit = false)
		{
			base.GetText(0).SetText(newValue.ToString(), true);
			if (isInit || oldValue == newValue || this.SequencePlayer == null)
			{
				return;
			}
			this.SequencePlayer.StopPrevSequence(false, true);
			this.SequencePlayer.PlaySequencePurely((oldValue > newValue) ? "Down" : "Upd", false, false);
		}

		// Token: 0x04022D57 RID: 142679
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0200C0F8 RID: 49400
		private enum EComponentType
		{
			// Token: 0x0403B6C3 RID: 243395
			LevelText
		}
	}
}
