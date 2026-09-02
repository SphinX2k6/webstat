using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006429 RID: 25641
	public class RoverlikeCommonButton : UiPanelBase
	{
		// Token: 0x060405F8 RID: 263672 RVA: 0x010806A8 File Offset: 0x0107E8A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060405F9 RID: 263673 RVA: 0x01080790 File Offset: 0x0107E990
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x060405FA RID: 263674 RVA: 0x010807A4 File Offset: 0x0107E9A4
		[NullableContext(1)]
		public void SetClickCallback(Action callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x060405FB RID: 263675 RVA: 0x010807B0 File Offset: 0x0107E9B0
		public void RefreshByDifficulty(int difficulty)
		{
			int index = Math.Min(Math.Max(((difficulty == 0) ? 1 : difficulty) - 1, 0), 2);
			UUISprite sprite = base.GetSprite(3);
			if (sprite == null)
			{
				return;
			}
			sprite.SetColor(RoverlikeCommonButton.CommonButtonColors[index]);
		}

		// Token: 0x060405FC RID: 263676 RVA: 0x010807EF File Offset: 0x0107E9EF
		private void OnClick()
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x040240FE RID: 147710
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<FColor> CommonButtonColors = new List<FColor>
		{
			FColor.FromHex("#469ffb"),
			FColor.FromHex("#7960ff"),
			FColor.FromHex("#f22647")
		};

		// Token: 0x040240FF RID: 147711
		[Nullable(2)]
		private Action ClickCallback;

		// Token: 0x0200C498 RID: 50328
		private class ERoverlikeCommonButton
		{
			// Token: 0x0403C830 RID: 247856
			public const int BtnCommon = 0;

			// Token: 0x0403C831 RID: 247857
			public const int TxtName = 1;

			// Token: 0x0403C832 RID: 247858
			public const int RedDot = 2;

			// Token: 0x0403C833 RID: 247859
			public const int SprColor = 3;
		}
	}
}
