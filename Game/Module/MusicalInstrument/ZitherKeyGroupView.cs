using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D2 RID: 22226
	public class ZitherKeyGroupView : UiPanelBase
	{
		// Token: 0x0603893B RID: 231739 RVA: 0x00E55840 File Offset: 0x00E53A40
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603893C RID: 231740 RVA: 0x00E558AC File Offset: 0x00E53AAC
		public void Refresh(bool isInteractive)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!isInteractive);
			}
			if (isInteractive != this.IsInteractive)
			{
				base.GetRootItem().PlayUIItemAlphaTween(this.IsInteractive ? 1f : 0.5f, isInteractive ? 1f : 0.5f, 0.2f);
				foreach (MusicalInstrumentKeyItem musicalInstrumentKeyItem in this.KeyItems)
				{
					((GuqinKeyItem)musicalInstrumentKeyItem).SetInteractive(isInteractive);
				}
				this.IsInteractive = isInteractive;
			}
		}

		// Token: 0x04020475 RID: 132213
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<MusicalInstrumentKeyItem> KeyItems;

		// Token: 0x04020476 RID: 132214
		private bool IsInteractive = true;

		// Token: 0x0200B755 RID: 46933
		private enum EZitherKeyGroupViewComponent
		{
			// Token: 0x04038B4A RID: 232266
			NoteLayout,
			// Token: 0x04038B4B RID: 232267
			DisableMask
		}
	}
}
