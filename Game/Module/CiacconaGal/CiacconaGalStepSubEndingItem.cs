using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC6 RID: 24262
	public class CiacconaGalStepSubEndingItem : UiPanelBase
	{
		// Token: 0x0603CFA1 RID: 249761 RVA: 0x00F7C474 File Offset: 0x00F7A674
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

		// Token: 0x0603CFA2 RID: 249762 RVA: 0x00F7C4BC File Offset: 0x00F7A6BC
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603CFA3 RID: 249763 RVA: 0x00F7C4D0 File Offset: 0x00F7A6D0
		public void PlayStart()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603CFA4 RID: 249764 RVA: 0x00F7C4FD File Offset: 0x00F7A6FD
		[NullableContext(1)]
		public void Refresh(CiacconaGalSubEndingData subEndingData)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), subEndingData.Desc, Array.Empty<object>());
		}

		// Token: 0x04022392 RID: 140178
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BEBF RID: 48831
		private class EComponentDefine
		{
			// Token: 0x0403AB61 RID: 240481
			public const int TextContent = 0;
		}
	}
}
