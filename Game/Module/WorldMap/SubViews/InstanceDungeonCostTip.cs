using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews
{
	// Token: 0x02004B5C RID: 19292
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonCostTip : UiPanelBase
	{
		// Token: 0x0603263F RID: 206399 RVA: 0x00C9C36C File Offset: 0x00C9A56C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelp));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032640 RID: 206400 RVA: 0x00C9C475 File Offset: 0x00C9A675
		private void OnClickHelp()
		{
			Action onClickDelegate = this.OnClickDelegate;
			if (onClickDelegate == null)
			{
				return;
			}
			onClickDelegate();
		}

		// Token: 0x06032641 RID: 206401 RVA: 0x00C9C487 File Offset: 0x00C9A687
		public void SetClickHelpFunc(Action func)
		{
			this.OnClickDelegate = func;
		}

		// Token: 0x06032642 RID: 206402 RVA: 0x00C9C490 File Offset: 0x00C9A690
		public void SetLeftText(string text)
		{
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x06032643 RID: 206403 RVA: 0x00C9C4A5 File Offset: 0x00C9A6A5
		public void SetLeftTextNew(string textStringId, [Nullable(new byte[]
		{
			1,
			2
		})] params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, args);
		}

		// Token: 0x06032644 RID: 206404 RVA: 0x00C9C4BA File Offset: 0x00C9A6BA
		public void SetRightText(string text)
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x06032645 RID: 206405 RVA: 0x00C9C4D0 File Offset: 0x00C9A6D0
		public void SetHelpButtonVisible(bool visible)
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(visible);
		}

		// Token: 0x06032646 RID: 206406 RVA: 0x00C9C4FC File Offset: 0x00C9A6FC
		public void SetIconVisible(bool visible)
		{
			UUITexture texture = base.GetTexture(3);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(visible);
		}

		// Token: 0x06032647 RID: 206407 RVA: 0x00C9C510 File Offset: 0x00C9A710
		public void SetStarVisible(bool visible)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(visible);
		}

		// Token: 0x06032648 RID: 206408 RVA: 0x00C9C524 File Offset: 0x00C9A724
		public void SetIconByPath(string path)
		{
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			base.SetTextureByPath(path, base.GetTexture(3), null, null);
		}

		// Token: 0x06032649 RID: 206409 RVA: 0x00C9C55C File Offset: 0x00C9A75C
		public void SetIconByItemId(int itemId)
		{
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			base.SetItemIcon(base.GetTexture(3), itemId, null, null);
		}

		// Token: 0x0603264A RID: 206410 RVA: 0x00C9C594 File Offset: 0x00C9A794
		public void SetSprStarByPath(string path)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			this.SetSpriteByPath(path, sprite, false, null, null);
		}

		// Token: 0x0603264B RID: 206411 RVA: 0x00C9C5C8 File Offset: 0x00C9A7C8
		public void SetSprStarChangeColor(bool useChangeColor)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite == null)
			{
				return;
			}
			UUIItem uuiitem = sprite;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(useChangeColor, fcolor);
		}

		// Token: 0x0401D6AD RID: 120493
		[Nullable(2)]
		private Action OnClickDelegate;

		// Token: 0x0200AC2A RID: 44074
		[NullableContext(0)]
		public static class EInstanceDungeonCostTipChildCom
		{
			// Token: 0x040358B5 RID: 219317
			public const int TxtL = 0;

			// Token: 0x040358B6 RID: 219318
			public const int TxtR = 1;

			// Token: 0x040358B7 RID: 219319
			public const int BtnHelp = 2;

			// Token: 0x040358B8 RID: 219320
			public const int Icon = 3;

			// Token: 0x040358B9 RID: 219321
			public const int SprStar = 4;
		}
	}
}
