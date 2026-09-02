using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006630 RID: 26160
	public class TagIconItem : UiPanelBase
	{
		// Token: 0x06041591 RID: 267665 RVA: 0x010C2B4C File Offset: 0x010C0D4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041592 RID: 267666 RVA: 0x010C2BB8 File Offset: 0x010C0DB8
		[NullableContext(1)]
		public void RefreshPanel(string path, string color)
		{
			base.SetTextureByPath(path, base.GetTexture(1), null, null);
			base.GetItem(0).SetColor(FColor.FromHex(color));
		}

		// Token: 0x0200C656 RID: 50774
		private enum ETagIconItem
		{
			// Token: 0x0403D0DC RID: 250076
			BgItem,
			// Token: 0x0403D0DD RID: 250077
			IconTexture
		}
	}
}
