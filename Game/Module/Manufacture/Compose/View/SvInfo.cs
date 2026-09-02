using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059C7 RID: 22983
	public class SvInfo : UiPanelBase
	{
		// Token: 0x0603A387 RID: 238471 RVA: 0x00EC0008 File Offset: 0x00EBE208
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603A388 RID: 238472 RVA: 0x00EC0100 File Offset: 0x00EBE300
		protected override void OnStart()
		{
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x0603A389 RID: 238473 RVA: 0x00EC0110 File Offset: 0x00EBE310
		[NullableContext(2)]
		public void SetTypeName(string tag = null)
		{
			UUIText text = base.GetText(0);
			if (!string.IsNullOrEmpty(tag))
			{
				text.SetUIActive(true);
				text.SetText(tag, true);
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0603A38A RID: 238474 RVA: 0x00EC0144 File Offset: 0x00EBE344
		public void SetDescVisible(bool visible)
		{
			base.GetText(3).SetUIActive(visible);
		}

		// Token: 0x0603A38B RID: 238475 RVA: 0x00EC0153 File Offset: 0x00EBE353
		public void SetDescBgVisible(bool visible)
		{
			base.GetText(5).SetUIActive(visible);
		}

		// Token: 0x0603A38C RID: 238476 RVA: 0x00EC0162 File Offset: 0x00EBE362
		[NullableContext(1)]
		public void SetDesc(string text)
		{
			base.GetText(3).SetText(text, true);
		}

		// Token: 0x0603A38D RID: 238477 RVA: 0x00EC0172 File Offset: 0x00EBE372
		[NullableContext(1)]
		public void SetDescBg(string text)
		{
			base.GetText(5).SetText(text, true);
		}

		// Token: 0x0200B993 RID: 47507
		private class ESvInfoComponents
		{
			// Token: 0x0403955F RID: 234847
			public const int TxtType = 0;

			// Token: 0x04039560 RID: 234848
			public const int WeaponView = 1;

			// Token: 0x04039561 RID: 234849
			public const int Desc = 3;

			// Token: 0x04039562 RID: 234850
			public const int Line = 4;

			// Token: 0x04039563 RID: 234851
			public const int DescBg = 5;

			// Token: 0x04039564 RID: 234852
			public const int InventoryView = 6;
		}
	}
}
