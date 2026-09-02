using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C7 RID: 26567
	public class DockyardShopTabItem : CommonTabItemBase, ITabViewRegister
	{
		// Token: 0x0604247D RID: 271485 RVA: 0x01100570 File Offset: 0x010FE770
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604247E RID: 271486 RVA: 0x01100616 File Offset: 0x010FE816
		protected override void OnStart()
		{
			base.OnStart();
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x0604247F RID: 271487 RVA: 0x0110062B File Offset: 0x010FE82B
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

		// Token: 0x06042480 RID: 271488 RVA: 0x01100649 File Offset: 0x010FE849
		[NullableContext(1)]
		protected override void OnUpdateTabIcon(string iconPath)
		{
		}

		// Token: 0x06042481 RID: 271489 RVA: 0x0110064B File Offset: 0x010FE84B
		protected override void OnSetToggleState(EToggleState state, bool bFire)
		{
			base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
		}

		// Token: 0x06042482 RID: 271490 RVA: 0x0110065E File Offset: 0x010FE85E
		[NullableContext(1)]
		protected override UUIExtendToggle GetTabToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06042483 RID: 271491 RVA: 0x01100667 File Offset: 0x010FE867
		[NullableContext(1)]
		public void RegisterViewModule(UiTabViewBase tabView)
		{
			tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
		}

		// Token: 0x06042484 RID: 271492 RVA: 0x01100675 File Offset: 0x010FE875
		public void SetRedDotActive(bool bActive)
		{
			base.GetItem(1).SetUIActive(bActive);
		}

		// Token: 0x0200C810 RID: 51216
		private class EComponentDefine
		{
			// Token: 0x0403D922 RID: 252194
			public const int Toggle = 0;

			// Token: 0x0403D923 RID: 252195
			public const int RedDot = 1;
		}
	}
}
