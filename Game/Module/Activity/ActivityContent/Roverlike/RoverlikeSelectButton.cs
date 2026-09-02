using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006427 RID: 25639
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSelectButton : UiPanelBase
	{
		// Token: 0x060405B9 RID: 263609 RVA: 0x0107F110 File Offset: 0x0107D310
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060405BA RID: 263610 RVA: 0x0107F23A File Offset: 0x0107D43A
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<RoverlikeLootStarItem, bool>(base.GetHorizontalLayout(6), new Func<RoverlikeLootStarItem>(this.CreateStarItem), null, false, true);
			this.SetLock(false, false);
		}

		// Token: 0x060405BB RID: 263611 RVA: 0x0107F265 File Offset: 0x0107D465
		private void OnClick()
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x060405BC RID: 263612 RVA: 0x0107F277 File Offset: 0x0107D477
		public void SetClickCallback(Action callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x060405BD RID: 263613 RVA: 0x0107F280 File Offset: 0x0107D480
		public void SetText(string text)
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x060405BE RID: 263614 RVA: 0x0107F295 File Offset: 0x0107D495
		public void SetLocalTextNew(string textId, [ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x060405BF RID: 263615 RVA: 0x0107F2AC File Offset: 0x0107D4AC
		public void SetImage(string path)
		{
			UUITexture texture = base.GetTexture(5);
			if (texture == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(path))
			{
				texture.SetUIActive(true);
				base.SetTextureByPath(path, texture, null, null);
				return;
			}
			texture.SetUIActive(false);
		}

		// Token: 0x060405C0 RID: 263616 RVA: 0x0107F2F0 File Offset: 0x0107D4F0
		public void SetLock(bool locked, bool interactiveWhenLocked = false)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(locked);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!locked);
			}
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(!locked || interactiveWhenLocked);
		}

		// Token: 0x060405C1 RID: 263617 RVA: 0x0107F340 File Offset: 0x0107D540
		public void SetStars(int level, int maxLevel)
		{
			List<bool> list = new List<bool>();
			for (int i = 0; i < maxLevel; i++)
			{
				list.Add(i < level);
			}
			GenericLayout<RoverlikeLootStarItem, bool> starLayout = this.StarLayout;
			if (starLayout == null)
			{
				return;
			}
			starLayout.RefreshByData(list, null, false);
		}

		// Token: 0x060405C2 RID: 263618 RVA: 0x0107F37C File Offset: 0x0107D57C
		public void SetStarListActive(bool active)
		{
			GenericLayout<RoverlikeLootStarItem, bool> starLayout = this.StarLayout;
			if (starLayout == null)
			{
				return;
			}
			starLayout.SetActive(active);
		}

		// Token: 0x060405C3 RID: 263619 RVA: 0x0107F38F File Offset: 0x0107D58F
		private RoverlikeLootStarItem CreateStarItem()
		{
			return new RoverlikeLootStarItem();
		}

		// Token: 0x040240F2 RID: 147698
		[Nullable(2)]
		private Action ClickCallback;

		// Token: 0x040240F3 RID: 147699
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeLootStarItem, bool> StarLayout;

		// Token: 0x0200C492 RID: 50322
		[NullableContext(0)]
		private class ERoverlikeSelectButton
		{
			// Token: 0x0403C808 RID: 247816
			public const int Button = 0;

			// Token: 0x0403C809 RID: 247817
			public const int TxtName = 1;

			// Token: 0x0403C80A RID: 247818
			public const int RedDotItem = 2;

			// Token: 0x0403C80B RID: 247819
			public const int SprIcon = 3;

			// Token: 0x0403C80C RID: 247820
			public const int SprLock = 4;

			// Token: 0x0403C80D RID: 247821
			public const int TexIcon = 5;

			// Token: 0x0403C80E RID: 247822
			public const int StarList = 6;
		}
	}
}
