using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common
{
	// Token: 0x02004BCE RID: 19406
	public class WorldMapChangeGravityButtonItem : UiPanelBase
	{
		// Token: 0x06032A61 RID: 207457 RVA: 0x00CAFF00 File Offset: 0x00CAE100
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISpriteTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032A62 RID: 207458 RVA: 0x00CAFFE8 File Offset: 0x00CAE1E8
		private void ButtonClick()
		{
			Action buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction();
		}

		// Token: 0x06032A63 RID: 207459 RVA: 0x00CAFFFA File Offset: 0x00CAE1FA
		public void SetEnableClick(bool state)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(state);
		}

		// Token: 0x06032A64 RID: 207460 RVA: 0x00CB000E File Offset: 0x00CAE20E
		[NullableContext(1)]
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x06032A65 RID: 207461 RVA: 0x00CB0018 File Offset: 0x00CAE218
		[NullableContext(1)]
		public void SetSprite(string path)
		{
			UUISprite sprite = base.GetSprite(1);
			sprite.SetUIActive(false);
			this.SetSpriteByPath(path, sprite, false, null, delegate(bool success)
			{
				this.GetUiSpriteTransition(3).SetAllTransitionSprite(sprite.GetSprite());
				sprite.SetUIActive(success);
			});
		}

		// Token: 0x0401D80D RID: 120845
		[Nullable(2)]
		private Action ButtonFunction;

		// Token: 0x0200ACB7 RID: 44215
		public static class EButtonItemDefine
		{
			// Token: 0x04035A77 RID: 219767
			public const int Button = 0;

			// Token: 0x04035A78 RID: 219768
			public const int Sprite = 1;

			// Token: 0x04035A79 RID: 219769
			public const int Text = 2;

			// Token: 0x04035A7A RID: 219770
			public const int SpriteTransition = 3;
		}
	}
}
