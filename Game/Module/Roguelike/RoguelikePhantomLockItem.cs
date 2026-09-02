using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200516D RID: 20845
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikePhantomLockItem : UiPanelBase
	{
		// Token: 0x06035A4D RID: 219725 RVA: 0x00D796CC File Offset: 0x00D778CC
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035A4E RID: 219726 RVA: 0x00D79756 File Offset: 0x00D77956
		public void SetTextByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x06035A4F RID: 219727 RVA: 0x00D7976B File Offset: 0x00D7796B
		public void SetTextByText(string text)
		{
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x06035A50 RID: 219728 RVA: 0x00D7977B File Offset: 0x00D7797B
		public UUISprite GetIconSprite()
		{
			return base.GetSprite(0);
		}

		// Token: 0x06035A51 RID: 219729 RVA: 0x00D79784 File Offset: 0x00D77984
		public void SetSpriteVisible(bool bVisible)
		{
			base.GetSprite(0).SetUIActive(bVisible);
		}

		// Token: 0x0200B11C RID: 45340
		[NullableContext(0)]
		private class ERedComponents
		{
			// Token: 0x04036EFC RID: 225020
			public const int Sprite = 0;

			// Token: 0x04036EFD RID: 225021
			public const int Txt = 1;

			// Token: 0x04036EFE RID: 225022
			public const int Button = 2;
		}
	}
}
