using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E12 RID: 24082
	[NullableContext(1)]
	[Nullable(0)]
	public class MachiningClueItem : UiPanelBase
	{
		// Token: 0x0603C994 RID: 248212 RVA: 0x00F63512 File Offset: 0x00F61712
		public MachiningClueItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C995 RID: 248213 RVA: 0x00F63528 File Offset: 0x00F61728
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C996 RID: 248214 RVA: 0x00F63594 File Offset: 0x00F61794
		public void Update(bool isUnlock, string contentText)
		{
			base.GetSprite(0).SetUIActive(isUnlock);
			base.GetText(1).SetText(contentText, true);
			if (isUnlock)
			{
				base.GetText(1).SetColor(FColor.FromHex("aa9b6a"));
				return;
			}
			base.GetText(1).SetColor(FColor.FromHex("ece5d8"));
		}
	}
}
