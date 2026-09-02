using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053D8 RID: 21464
	public class SummaryPopView : UiViewBase
	{
		// Token: 0x06036CAF RID: 224431 RVA: 0x00DE637E File Offset: 0x00DE457E
		[NullableContext(1)]
		public SummaryPopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036CB0 RID: 224432 RVA: 0x00DE6388 File Offset: 0x00DE4588
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnCancel));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCancel));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06036CB1 RID: 224433 RVA: 0x00DE64B8 File Offset: 0x00DE46B8
		protected override void OnStart()
		{
			this.Done = false;
			SummaryData summaryData = this.OpenParam as SummaryData;
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(((summaryData != null) ? summaryData.Text : null) ?? string.Empty, true);
		}

		// Token: 0x06036CB2 RID: 224434 RVA: 0x00DE6500 File Offset: 0x00DE4700
		protected void OnConfirm()
		{
			if (this.Done)
			{
				return;
			}
			this.Done = true;
			SummaryData summaryData = this.OpenParam as SummaryData;
			Action confirmFunc = (summaryData != null) ? summaryData.ConfirmFunc : null;
			base.CloseMe(delegate(bool _)
			{
				Action confirmFunc = confirmFunc;
				if (confirmFunc == null)
				{
					return;
				}
				confirmFunc();
			});
		}

		// Token: 0x06036CB3 RID: 224435 RVA: 0x00DE6554 File Offset: 0x00DE4754
		protected void OnCancel()
		{
			if (this.Done)
			{
				return;
			}
			this.Done = true;
			SummaryData summaryData = this.OpenParam as SummaryData;
			Action cancelFunc = (summaryData != null) ? summaryData.CancelFunc : null;
			base.CloseMe(delegate(bool _)
			{
				Action cancelFunc = cancelFunc;
				if (cancelFunc == null)
				{
					return;
				}
				cancelFunc();
			});
		}

		// Token: 0x0401F8E1 RID: 129249
		private bool Done;

		// Token: 0x0200B382 RID: 45954
		private static class EChildComp
		{
			// Token: 0x04037994 RID: 227732
			public const int Exit = 0;

			// Token: 0x04037995 RID: 227733
			public const int ConfirmButton = 1;

			// Token: 0x04037996 RID: 227734
			public const int CancelButton = 2;

			// Token: 0x04037997 RID: 227735
			public const int Text = 3;
		}
	}
}
