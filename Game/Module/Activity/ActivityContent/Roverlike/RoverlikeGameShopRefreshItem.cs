using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200641F RID: 25631
	public class RoverlikeGameShopRefreshItem : UiPanelBase
	{
		// Token: 0x0604057A RID: 263546 RVA: 0x0107DAF6 File Offset: 0x0107BCF6
		[NullableContext(1)]
		public void BindOnRefresh(Action cb)
		{
			this.OnRefresh = cb;
		}

		// Token: 0x0604057B RID: 263547 RVA: 0x0107DB00 File Offset: 0x0107BD00
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnRefresh));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604057C RID: 263548 RVA: 0x0107DBE8 File Offset: 0x0107BDE8
		private void OnClickBtnRefresh()
		{
			Action onRefresh = this.OnRefresh;
			if (onRefresh == null)
			{
				return;
			}
			onRefresh();
		}

		// Token: 0x0604057D RID: 263549 RVA: 0x0107DBFC File Offset: 0x0107BDFC
		public void Refresh(int nextRefreshCost, int refreshCount, int maxRefreshCount, int insideCurrencyItemId, int currencyCount)
		{
			UUIText text = base.GetText(1);
			UUIText text2 = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoverRogue_RefreshCount", new <>z__ReadOnlyArray<object>(new object[]
			{
				refreshCount,
				maxRefreshCount
			}));
			bool flag = currencyCount < nextRefreshCost;
			UUIItem uuiitem = text2;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(text2.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "RoverRogue_RefreshCost", new <>z__ReadOnlySingleElementList<object>(nextRefreshCost));
			UUITexture texture = base.GetTexture(3);
			base.SetItemIcon(texture, insideCurrencyItemId, null, null);
			base.GetButton(0).SetSelfInteractive(refreshCount < maxRefreshCount);
		}

		// Token: 0x040240DC RID: 147676
		[Nullable(2)]
		private Action OnRefresh;

		// Token: 0x0200C489 RID: 50313
		private class EComponents
		{
			// Token: 0x0403C7E8 RID: 247784
			public const int BtnRefresh = 0;

			// Token: 0x0403C7E9 RID: 247785
			public const int TxtRefresh = 1;

			// Token: 0x0403C7EA RID: 247786
			public const int TxtRefreshCount = 2;

			// Token: 0x0403C7EB RID: 247787
			public const int TextureIcon = 3;
		}
	}
}
