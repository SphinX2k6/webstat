using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D0 RID: 25040
	[NullableContext(1)]
	[Nullable(0)]
	public class GuQinActivityMainViewToggleItem : UiPanelBase
	{
		// Token: 0x0603F2F2 RID: 258802 RVA: 0x01038408 File Offset: 0x01036608
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F2F3 RID: 258803 RVA: 0x010385DA File Offset: 0x010367DA
		protected override void OnStart()
		{
			base.GetExtendToggle(8).bLockStateOnSelect = true;
			base.GetExtendToggle(8).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteCallback));
			this.SetToggleState(EToggleState.ETT_UnChecked, true);
		}

		// Token: 0x0603F2F4 RID: 258804 RVA: 0x0103860E File Offset: 0x0103680E
		private bool CanExecuteCallback()
		{
			if (this.Data.GetStatus() == EGuQinActivityTabStatus.Lock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(this.Data.GetLockTip());
				Action focusBackCallback = this.FocusBackCallback;
				if (focusBackCallback != null)
				{
					focusBackCallback();
				}
				return false;
			}
			return true;
		}

		// Token: 0x0603F2F5 RID: 258805 RVA: 0x01038648 File Offset: 0x01036848
		private void OnToggleClick(EToggleState state)
		{
			bool flag = state == EToggleState.ETT_Checked;
			if (flag)
			{
				this.SelectCallback(this, this.Data);
			}
			this.RefreshDisplay(flag);
		}

		// Token: 0x0603F2F6 RID: 258806 RVA: 0x01038678 File Offset: 0x01036878
		public void RefreshDisplay(bool isSelected)
		{
			EGuQinActivityTabStatus status = this.Data.GetStatus();
			bool flag = status == EGuQinActivityTabStatus.Progressing;
			bool flag2 = status == EGuQinActivityTabStatus.Lock;
			bool flag3 = status == EGuQinActivityTabStatus.Completed;
			base.GetItem(0).SetUIActive(!isSelected);
			base.GetItem(1).SetUIActive(!isSelected && flag);
			base.GetItem(2).SetUIActive(!isSelected && flag2);
			base.GetItem(3).SetUIActive(!isSelected && flag3);
			base.GetItem(5).SetUIActive(isSelected);
			base.GetItem(7).SetUIActive(isSelected && flag3);
			base.GetText(6).SetUIActive(isSelected);
			base.GetText(4).SetUIActive(!isSelected);
			base.GetItem(9).SetUIActive(this.Data.GetIsRedDot());
			base.GetItem(10).SetUIActive(this.Data.GetIsRedDot());
		}

		// Token: 0x0603F2F7 RID: 258807 RVA: 0x0103874D File Offset: 0x0103694D
		public void SetToggleState(EToggleState state, bool fireEvent)
		{
			base.GetExtendToggle(8).SetToggleStateForce(state, fireEvent, false, false);
		}

		// Token: 0x0603F2F8 RID: 258808 RVA: 0x0103875F File Offset: 0x0103695F
		public void Refresh(GuQinActivityTabData data)
		{
			this.Data = data;
		}

		// Token: 0x0603F2F9 RID: 258809 RVA: 0x01038768 File Offset: 0x01036968
		public void RefreshRedDot()
		{
			base.GetItem(9).SetUIActive(this.Data.GetIsRedDot());
			base.GetItem(10).SetUIActive(this.Data.GetIsRedDot());
		}

		// Token: 0x040237D1 RID: 145361
		public GuQinActivityTabData Data;

		// Token: 0x040237D2 RID: 145362
		public Action<GuQinActivityMainViewToggleItem, GuQinActivityTabData> SelectCallback;

		// Token: 0x040237D3 RID: 145363
		[Nullable(2)]
		public Action FocusBackCallback;

		// Token: 0x0200C30F RID: 49935
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C1F8 RID: 246264
			public const int PnlNotSelect = 0;

			// Token: 0x0403C1F9 RID: 246265
			public const int PnlNotSelectUnlock = 1;

			// Token: 0x0403C1FA RID: 246266
			public const int PnlNotSelectLock = 2;

			// Token: 0x0403C1FB RID: 246267
			public const int PnlNotSelectCompleted = 3;

			// Token: 0x0403C1FC RID: 246268
			public const int TextNotSelectName = 4;

			// Token: 0x0403C1FD RID: 246269
			public const int PnlSelect = 5;

			// Token: 0x0403C1FE RID: 246270
			public const int TextSelectName = 6;

			// Token: 0x0403C1FF RID: 246271
			public const int PnlSelectCompleted = 7;

			// Token: 0x0403C200 RID: 246272
			public const int Toggle = 8;

			// Token: 0x0403C201 RID: 246273
			public const int SelectRedDot = 9;

			// Token: 0x0403C202 RID: 246274
			public const int NotSelectRedDot = 10;
		}
	}
}
