using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059F0 RID: 23024
	[NullableContext(1)]
	[Nullable(0)]
	public class AmountItem : UiPanelBase
	{
		// Token: 0x0603A554 RID: 238932 RVA: 0x00ECA370 File Offset: 0x00EC8570
		public AmountItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A555 RID: 238933 RVA: 0x00ECA38C File Offset: 0x00EC858C
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnAdd));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnDel));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnShowButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A556 RID: 238934 RVA: 0x00ECA4BC File Offset: 0x00EC86BC
		private UniTask InitCommonItemCountPanel()
		{
			AmountItem.<InitCommonItemCountPanel>d__7 <InitCommonItemCountPanel>d__;
			<InitCommonItemCountPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCommonItemCountPanel>d__.<>4__this = this;
			<InitCommonItemCountPanel>d__.<>1__state = -1;
			<InitCommonItemCountPanel>d__.<>t__builder.Start<AmountItem.<InitCommonItemCountPanel>d__7>(ref <InitCommonItemCountPanel>d__);
			return <InitCommonItemCountPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603A557 RID: 238935 RVA: 0x00ECA500 File Offset: 0x00EC8700
		private void SetSumText(int sum)
		{
			int maxCallback = this.GetMaxCallback();
			this.Sum = ((maxCallback < sum) ? maxCallback : sum);
			if (this.Sum < 1)
			{
				this.Sum = 1;
			}
			if (this.OnSetSumCallback != null)
			{
				this.OnSetSumCallback(this.Sum);
			}
			base.GetText(3).SetText(this.Sum.ToString(), true);
			this.RefreshAddAndDelButton();
		}

		// Token: 0x0603A558 RID: 238936 RVA: 0x00ECA569 File Offset: 0x00EC8769
		protected override void OnStart()
		{
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603A559 RID: 238937 RVA: 0x00ECA583 File Offset: 0x00EC8783
		public void ResetSum()
		{
			this.Sum = 1;
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603A55A RID: 238938 RVA: 0x00ECA5A4 File Offset: 0x00EC87A4
		public void RefreshAddAndDelButton()
		{
			((base.GetButton(1).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup).SetInteractable(this.Sum != 1);
			((base.GetButton(0).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup).SetInteractable(this.Sum < this.GetMaxCallback());
		}

		// Token: 0x0603A55B RID: 238939 RVA: 0x00ECA61F File Offset: 0x00EC881F
		public void BindGetMaxCallback(Func<int> onGetMaxCallback)
		{
			this.OnGetMaxCallback = onGetMaxCallback;
		}

		// Token: 0x0603A55C RID: 238940 RVA: 0x00ECA628 File Offset: 0x00EC8828
		public void BindSetSumCallback(Action<int> onSetSumCallback)
		{
			this.OnSetSumCallback = onSetSumCallback;
		}

		// Token: 0x0603A55D RID: 238941 RVA: 0x00ECA634 File Offset: 0x00EC8834
		private int GetMaxCallback()
		{
			if (this.OnGetMaxCallback != null)
			{
				int num = this.OnGetMaxCallback();
				if (num != 0)
				{
					return num;
				}
			}
			return 1;
		}

		// Token: 0x0603A55E RID: 238942 RVA: 0x00ECA65C File Offset: 0x00EC885C
		private void OnAdd()
		{
			this.Sum++;
			if (this.OnSetSumCallback != null)
			{
				this.OnSetSumCallback(this.Sum);
			}
			this.RefreshAddAndDelButton();
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603A55F RID: 238943 RVA: 0x00ECA6B0 File Offset: 0x00EC88B0
		private void OnDel()
		{
			this.Sum--;
			if (this.OnSetSumCallback != null)
			{
				this.OnSetSumCallback(this.Sum);
			}
			this.RefreshAddAndDelButton();
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603A560 RID: 238944 RVA: 0x00ECA702 File Offset: 0x00EC8902
		private void OnShowButtonClick()
		{
			this.OnShowCommonItemCountPanel();
		}

		// Token: 0x0603A561 RID: 238945 RVA: 0x00ECA70C File Offset: 0x00EC890C
		private UniTask OnShowCommonItemCountPanel()
		{
			AmountItem.<OnShowCommonItemCountPanel>d__18 <OnShowCommonItemCountPanel>d__;
			<OnShowCommonItemCountPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowCommonItemCountPanel>d__.<>4__this = this;
			<OnShowCommonItemCountPanel>d__.<>1__state = -1;
			<OnShowCommonItemCountPanel>d__.<>t__builder.Start<AmountItem.<OnShowCommonItemCountPanel>d__18>(ref <OnShowCommonItemCountPanel>d__);
			return <OnShowCommonItemCountPanel>d__.<>t__builder.Task;
		}

		// Token: 0x040210A5 RID: 135333
		private int Sum = 1;

		// Token: 0x040210A6 RID: 135334
		[Nullable(2)]
		private Func<int> OnGetMaxCallback;

		// Token: 0x040210A7 RID: 135335
		[Nullable(2)]
		private Action<int> OnSetSumCallback;

		// Token: 0x040210A8 RID: 135336
		[Nullable(2)]
		private CommonItemCountPanel CommonItemCountPanel;

		// Token: 0x0200B9BE RID: 47550
		[NullableContext(0)]
		private class EAmountItemDefine
		{
			// Token: 0x04039652 RID: 235090
			public const int AddButton = 0;

			// Token: 0x04039653 RID: 235091
			public const int DelButton = 1;

			// Token: 0x04039654 RID: 235092
			public const int ShowButton = 2;

			// Token: 0x04039655 RID: 235093
			public const int SumText = 3;
		}
	}
}
