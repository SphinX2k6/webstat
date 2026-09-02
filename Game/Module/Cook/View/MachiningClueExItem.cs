using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E13 RID: 24083
	[NullableContext(1)]
	[Nullable(0)]
	public class MachiningClueExItem : UiPanelBase
	{
		// Token: 0x0603C997 RID: 248215 RVA: 0x00F635EC File Offset: 0x00F617EC
		public MachiningClueExItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C998 RID: 248216 RVA: 0x00F63604 File Offset: 0x00F61804
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C999 RID: 248217 RVA: 0x00F63690 File Offset: 0x00F61890
		public void Update(bool isUnlock, string contentText)
		{
			base.GetSprite(0).SetUIActive(isUnlock);
			base.GetText(2).SetUIActive(isUnlock);
			base.GetText(1).SetUIActive(!isUnlock);
			if (isUnlock)
			{
				base.GetText(2).SetText(contentText, true);
				return;
			}
			base.GetText(1).SetText(contentText, true);
		}
	}
}
