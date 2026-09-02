using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006835 RID: 26677
	public class FishingTechTabItem : CommonTabItemBase, ITabViewRegister
	{
		// Token: 0x06042828 RID: 272424 RVA: 0x0111262C File Offset: 0x0111082C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042829 RID: 272425 RVA: 0x011126B1 File Offset: 0x011108B1
		private void OnToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> selectedCallBack = this.SelectedCallBack;
				if (selectedCallBack == null)
				{
					return;
				}
				selectedCallBack(base.GridIndex);
			}
		}

		// Token: 0x0604282A RID: 272426 RVA: 0x011126CF File Offset: 0x011108CF
		[NullableContext(1)]
		protected override void OnUpdateTabIcon(string iconPath)
		{
		}

		// Token: 0x0604282B RID: 272427 RVA: 0x011126D1 File Offset: 0x011108D1
		protected override void OnSetToggleState(EToggleState state, bool bFire)
		{
			base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
		}

		// Token: 0x0604282C RID: 272428 RVA: 0x011126E4 File Offset: 0x011108E4
		[NullableContext(1)]
		protected override UUIExtendToggle GetTabToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x0604282D RID: 272429 RVA: 0x011126ED File Offset: 0x011108ED
		[NullableContext(1)]
		public void RegisterViewModule(UiTabViewBase tabView)
		{
			tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
		}

		// Token: 0x0200C878 RID: 51320
		private class EComponentDefine
		{
			// Token: 0x0403DB40 RID: 252736
			public const int Toggle = 0;
		}
	}
}
