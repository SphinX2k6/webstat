using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Sheriff
{
	// Token: 0x02004B89 RID: 19337
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffPopupRightItem : PopupTypeRightItem
	{
		// Token: 0x06032808 RID: 206856 RVA: 0x00CA2AC4 File Offset: 0x00CA0CC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(base.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032809 RID: 206857 RVA: 0x00CA2BCD File Offset: 0x00CA0DCD
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(0);
		}

		// Token: 0x0603280A RID: 206858 RVA: 0x00CA2BD8 File Offset: 0x00CA0DD8
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(4);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(false);
		}

		// Token: 0x0603280B RID: 206859 RVA: 0x00CA2C0C File Offset: 0x00CA0E0C
		public void SetTitleIcon(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.TrySetSpriteByPath(resourcePath, base.GetSprite(2), false, null, null);
		}

		// Token: 0x0603280C RID: 206860 RVA: 0x00CA2C40 File Offset: 0x00CA0E40
		[NullableContext(2)]
		public void SetTitleIconByPath(string path)
		{
			base.TrySetSpriteByPath(path, base.GetSprite(2), false, null, null);
		}

		// Token: 0x0603280D RID: 206861 RVA: 0x00CA2C66 File Offset: 0x00CA0E66
		public override void SetTitleText(string txt)
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(txt, true);
		}

		// Token: 0x0200AC5B RID: 44123
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04035973 RID: 219507
			public const int Content = 0;

			// Token: 0x04035974 RID: 219508
			public const int BackBtn = 1;

			// Token: 0x04035975 RID: 219509
			public const int SprIcon = 2;

			// Token: 0x04035976 RID: 219510
			public const int TextName = 3;

			// Token: 0x04035977 RID: 219511
			public const int BtnClose = 4;
		}
	}
}
