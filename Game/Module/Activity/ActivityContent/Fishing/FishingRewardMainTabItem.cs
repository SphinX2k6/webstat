using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200678A RID: 26506
	public class FishingRewardMainTabItem : CommonTabItemBase, ITabViewRegister
	{
		// Token: 0x0604212A RID: 270634 RVA: 0x010F3BC0 File Offset: 0x010F1DC0
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

		// Token: 0x0604212B RID: 270635 RVA: 0x010F3C66 File Offset: 0x010F1E66
		protected override void OnStart()
		{
			this.SetRedDotVisible(false);
		}

		// Token: 0x0604212C RID: 270636 RVA: 0x010F3C6F File Offset: 0x010F1E6F
		[NullableContext(1)]
		public void RegisterViewModule(UiTabViewBase tabView)
		{
			tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
		}

		// Token: 0x0604212D RID: 270637 RVA: 0x010F3C7D File Offset: 0x010F1E7D
		public void SetRedDotVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(bVisible);
		}

		// Token: 0x0604212E RID: 270638 RVA: 0x010F3C91 File Offset: 0x010F1E91
		[NullableContext(1)]
		protected override void OnUpdateTabIcon(string iconPath)
		{
		}

		// Token: 0x0604212F RID: 270639 RVA: 0x010F3C93 File Offset: 0x010F1E93
		protected override void OnSetToggleState(EToggleState state, bool bFire)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, bFire, false, false);
		}

		// Token: 0x06042130 RID: 270640 RVA: 0x010F3CAB File Offset: 0x010F1EAB
		[NullableContext(1)]
		protected override UUIExtendToggle GetTabToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06042131 RID: 270641 RVA: 0x010F3CB4 File Offset: 0x010F1EB4
		protected void OnToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> selectedCallBack = this.SelectedCallBack;
				if (selectedCallBack == null)
				{
					return;
				}
				selectedCallBack(this.TabIndex);
			}
		}

		// Token: 0x04024D58 RID: 150872
		public int TabIndex;

		// Token: 0x0200C7A6 RID: 51110
		private class EComponentDefine
		{
			// Token: 0x0403D774 RID: 251764
			public const int Toggle = 0;

			// Token: 0x0403D775 RID: 251765
			public const int RedDot = 1;
		}
	}
}
