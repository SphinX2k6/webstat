using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE4 RID: 23268
	public class KurotatoRewardButton : UiPanelBase
	{
		// Token: 0x0603AD32 RID: 240946 RVA: 0x00EEB1A4 File Offset: 0x00EE93A4
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AD33 RID: 240947 RVA: 0x00EEB2CE File Offset: 0x00EE94CE
		public void SetLimitTimeTextShow(bool isShow)
		{
			base.GetItem(5).SetUIActive(isShow);
		}

		// Token: 0x0603AD34 RID: 240948 RVA: 0x00EEB2DD File Offset: 0x00EE94DD
		[NullableContext(1)]
		public void SetLimitTimeText(string text)
		{
			base.GetText(4).SetText(text, true);
		}

		// Token: 0x0603AD35 RID: 240949 RVA: 0x00EEB2F0 File Offset: 0x00EE94F0
		public void SetProgressNumText(int curNum, int totalNum)
		{
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(curNum);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalNum);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603AD36 RID: 240950 RVA: 0x00EEB338 File Offset: 0x00EE9538
		public void SetRedDotShow(bool isShow)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(isShow);
			}
		}

		// Token: 0x0603AD37 RID: 240951 RVA: 0x00EEB357 File Offset: 0x00EE9557
		private void OnClickBtn()
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x040213D1 RID: 136145
		[Nullable(2)]
		public Action ClickCallback;

		// Token: 0x0200BB17 RID: 47895
		protected enum ERewardBtnComponent
		{
			// Token: 0x04039BEA RID: 236522
			RootBtn,
			// Token: 0x04039BEB RID: 236523
			TxtNum,
			// Token: 0x04039BEC RID: 236524
			RedDot,
			// Token: 0x04039BED RID: 236525
			TxtName,
			// Token: 0x04039BEE RID: 236526
			TxtTime,
			// Token: 0x04039BEF RID: 236527
			PanelTime
		}
	}
}
