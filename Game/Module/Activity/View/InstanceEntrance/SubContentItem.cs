using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061EE RID: 25070
	[NullableContext(1)]
	[Nullable(0)]
	internal class SubContentItem : UiPanelBase
	{
		// Token: 0x0603F408 RID: 259080 RVA: 0x0103BC1C File Offset: 0x01039E1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F409 RID: 259081 RVA: 0x0103BD28 File Offset: 0x01039F28
		public void RefreshView(ActivityEntranceItemData data)
		{
			this.ItemData = data;
			this.RefreshToggleState(this.ItemData);
			this.RefreshLockItem(this.ItemData);
			this.RefreshFinishItem(this.ItemData);
			this.RefreshDifficultIcon(this.ItemData);
			this.RefreshDescText(this.ItemData);
		}

		// Token: 0x0603F40A RID: 259082 RVA: 0x0103BD78 File Offset: 0x01039F78
		private void RefreshToggleState(ActivityEntranceItemData data)
		{
			bool selectState = data.GetSelectState();
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(selectState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603F40B RID: 259083 RVA: 0x0103BDA8 File Offset: 0x01039FA8
		private void RefreshLockItem(ActivityEntranceItemData data)
		{
			bool lockState = data.GetLockState();
			base.GetItem(3).SetUIActive(lockState);
		}

		// Token: 0x0603F40C RID: 259084 RVA: 0x0103BDCC File Offset: 0x01039FCC
		private void RefreshFinishItem(ActivityEntranceItemData data)
		{
			bool finishState = data.GetFinishState();
			base.GetItem(4).SetUIActive(finishState);
		}

		// Token: 0x0603F40D RID: 259085 RVA: 0x0103BDF0 File Offset: 0x01039FF0
		private void RefreshDifficultIcon(ActivityEntranceItemData data)
		{
			string instanceDifficultIconPath = data.GetInstanceDifficultIconPath();
			if (instanceDifficultIconPath == null)
			{
				return;
			}
			base.SetTextureByPath(instanceDifficultIconPath, base.GetTexture(1), null, null);
		}

		// Token: 0x0603F40E RID: 259086 RVA: 0x0103BE20 File Offset: 0x0103A020
		private void RefreshDescText(ActivityEntranceItemData data)
		{
			if (data.GetLockState())
			{
				string unLockDesc = data.GetUnLockDesc();
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				text.SetText(unLockDesc, true);
				return;
			}
			else
			{
				string desc = data.GetDesc();
				UUIText text2 = base.GetText(2);
				if (text2 == null)
				{
					return;
				}
				text2.SetText(desc, true);
				return;
			}
		}

		// Token: 0x0603F40F RID: 259087 RVA: 0x0103BE6A File Offset: 0x0103A06A
		public void OnClickExtendToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> selectCallBack = this.ItemData.GetSelectCallBack();
				if (selectCallBack == null)
				{
					return;
				}
				selectCallBack(this.ItemData.GetSelectDataIndex());
			}
		}

		// Token: 0x04023834 RID: 145460
		[Nullable(2)]
		private ActivityEntranceItemData ItemData;

		// Token: 0x0200C331 RID: 49969
		[NullableContext(0)]
		private enum ESubContentComponent
		{
			// Token: 0x0403C283 RID: 246403
			Toggle,
			// Token: 0x0403C284 RID: 246404
			IconTexture,
			// Token: 0x0403C285 RID: 246405
			DescText,
			// Token: 0x0403C286 RID: 246406
			LockItem,
			// Token: 0x0403C287 RID: 246407
			FinishItem
		}
	}
}
