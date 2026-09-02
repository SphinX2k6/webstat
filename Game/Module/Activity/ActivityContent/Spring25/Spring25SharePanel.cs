using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x0200636B RID: 25451
	public class Spring25SharePanel : UiPanelBase
	{
		// Token: 0x0603FE79 RID: 261753 RVA: 0x01064578 File Offset: 0x01062778
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FE7A RID: 261754 RVA: 0x01064644 File Offset: 0x01062844
		protected override void OnStart()
		{
			Spring25ShareData spring25ShareData = this.OpenParam as Spring25ShareData;
			if (spring25ShareData == null)
			{
				return;
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
			UUIText text3 = base.GetText(3);
			if (text3 != null)
			{
				text3.SetUIActive(false);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			base.SetTextureByPath(spring25ShareData.PhotoPath, base.GetTexture(0), null, null);
		}

		// Token: 0x0200C3DB RID: 50139
		private static class EComponents
		{
			// Token: 0x0403C54C RID: 247116
			public const int Texture = 0;

			// Token: 0x0403C54D RID: 247117
			public const int Name = 1;

			// Token: 0x0403C54E RID: 247118
			public const int Time = 2;

			// Token: 0x0403C54F RID: 247119
			public const int Desc = 3;

			// Token: 0x0403C550 RID: 247120
			public const int LineItem = 4;
		}
	}
}
