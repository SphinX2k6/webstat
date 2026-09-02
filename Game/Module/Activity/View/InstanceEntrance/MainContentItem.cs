using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061EF RID: 25071
	[NullableContext(1)]
	[Nullable(0)]
	internal class MainContentItem : UiPanelBase
	{
		// Token: 0x0603F412 RID: 259090 RVA: 0x0103BEA0 File Offset: 0x0103A0A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F413 RID: 259091 RVA: 0x0103C050 File Offset: 0x0103A250
		public void RefreshView(ActivityEntranceItemData data)
		{
			this.ItemData = data;
			this.RefreshToggleState(data);
			this.RefreshPointItem(data);
			this.RefreshLockItem(data);
			this.RefreshFinishItem(data);
			this.RefreshOffsetItem(data);
			this.RefreshDifficultIcon(data);
			this.RefreshTitle(data);
			this.RefreshSubTitle(data);
			this.RefreshDisplayGrid(data);
			this.RefreshRedDotState(data);
		}

		// Token: 0x0603F414 RID: 259092 RVA: 0x0103C0AC File Offset: 0x0103A2AC
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

		// Token: 0x0603F415 RID: 259093 RVA: 0x0103C0DC File Offset: 0x0103A2DC
		private void OnClickExtendToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				bool flag = this.ItemData.HaveChildData();
				Action<int> selectCallBack = this.ItemData.GetSelectCallBack();
				if (selectCallBack != null)
				{
					selectCallBack(this.ItemData.GetSelectDataIndex());
				}
				if (flag)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityEntranceScroller, this.ItemData.GetSelectUiLogicIndex());
					return;
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityEntranceItemContent, this.ItemData.GetSelectUiLogicIndex());
			}
		}

		// Token: 0x0603F416 RID: 259094 RVA: 0x0103C154 File Offset: 0x0103A354
		private void RefreshPointItem(ActivityEntranceItemData data)
		{
			bool selectState = data.GetSelectState();
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(selectState);
		}

		// Token: 0x0603F417 RID: 259095 RVA: 0x0103C17C File Offset: 0x0103A37C
		private void RefreshLockItem(ActivityEntranceItemData data)
		{
			bool lockState = data.GetLockState();
			base.GetItem(7).SetUIActive(lockState);
		}

		// Token: 0x0603F418 RID: 259096 RVA: 0x0103C1A0 File Offset: 0x0103A3A0
		private void RefreshFinishItem(ActivityEntranceItemData data)
		{
			bool finishState = data.GetFinishState();
			base.GetItem(6).SetUIActive(finishState);
		}

		// Token: 0x0603F419 RID: 259097 RVA: 0x0103C1C4 File Offset: 0x0103A3C4
		private void RefreshOffsetItem(ActivityEntranceItemData data)
		{
			bool flag = data.HaveChildData();
			bool selectState = data.GetSelectState();
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag && selectState);
		}

		// Token: 0x0603F41A RID: 259098 RVA: 0x0103C1F4 File Offset: 0x0103A3F4
		private void RefreshDifficultIcon(ActivityEntranceItemData data)
		{
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			string instanceDifficultIconPath = data.GetInstanceDifficultIconPath();
			if (instanceDifficultIconPath == null)
			{
				return;
			}
			base.SetTextureByPath(instanceDifficultIconPath, base.GetTexture(2), null, null);
		}

		// Token: 0x0603F41B RID: 259099 RVA: 0x0103C238 File Offset: 0x0103A438
		private void RefreshTitle(ActivityEntranceItemData data)
		{
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetText("", true);
			}
			string instanceName = data.GetInstanceName();
			if (instanceName == "")
			{
				return;
			}
			UUIText text2 = base.GetText(3);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(instanceName, true);
		}

		// Token: 0x0603F41C RID: 259100 RVA: 0x0103C288 File Offset: 0x0103A488
		private void RefreshSubTitle(ActivityEntranceItemData data)
		{
			if (data.GetLockState())
			{
				string unLockDesc = data.GetUnLockDesc();
				UUIText text = base.GetText(8);
				if (text == null)
				{
					return;
				}
				text.SetText(unLockDesc, true);
				return;
			}
			else
			{
				string subTitle = data.GetSubTitle();
				UUIText text2 = base.GetText(8);
				if (text2 == null)
				{
					return;
				}
				text2.SetText(subTitle, true);
				return;
			}
		}

		// Token: 0x0603F41D RID: 259101 RVA: 0x0103C2D4 File Offset: 0x0103A4D4
		private void RefreshDisplayGrid(ActivityEntranceItemData data)
		{
			bool uiactive = data.HaveChildData();
			base.GetItem(4).SetUIActive(uiactive);
		}

		// Token: 0x0603F41E RID: 259102 RVA: 0x0103C2F8 File Offset: 0x0103A4F8
		private void RefreshRedDotState(ActivityEntranceItemData data)
		{
			bool redDotState = data.GetRedDotState();
			base.GetItem(9).SetUIActive(redDotState);
		}

		// Token: 0x04023835 RID: 145461
		[Nullable(2)]
		private ActivityEntranceItemData ItemData;

		// Token: 0x0200C332 RID: 49970
		[NullableContext(0)]
		private enum EMainContentComponent
		{
			// Token: 0x0403C289 RID: 246409
			Toggle,
			// Token: 0x0403C28A RID: 246410
			OffsetItem,
			// Token: 0x0403C28B RID: 246411
			IconTexture,
			// Token: 0x0403C28C RID: 246412
			Title,
			// Token: 0x0403C28D RID: 246413
			DisplayGridItem,
			// Token: 0x0403C28E RID: 246414
			PointItem,
			// Token: 0x0403C28F RID: 246415
			FinishItem,
			// Token: 0x0403C290 RID: 246416
			LockItem,
			// Token: 0x0403C291 RID: 246417
			SubTitle,
			// Token: 0x0403C292 RID: 246418
			RedDotItem
		}
	}
}
