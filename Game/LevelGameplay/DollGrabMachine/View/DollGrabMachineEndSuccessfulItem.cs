using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F10 RID: 28432
	public class DollGrabMachineEndSuccessfulItem : UiPanelBase
	{
		// Token: 0x06044DF4 RID: 282100 RVA: 0x011EC4E4 File Offset: 0x011EA6E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044DF5 RID: 282101 RVA: 0x011EC550 File Offset: 0x011EA750
		protected override void OnBeforeShow()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x04026623 RID: 157219
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;
	}
}
