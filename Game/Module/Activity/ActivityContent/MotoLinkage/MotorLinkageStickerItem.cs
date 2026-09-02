using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x0200671A RID: 26394
	public class MotorLinkageStickerItem : UiPanelBase
	{
		// Token: 0x06041D9A RID: 269722 RVA: 0x010E52B4 File Offset: 0x010E34B4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x06041D9B RID: 269723 RVA: 0x010E531C File Offset: 0x010E351C
		public void Refresh(int stickerId)
		{
			this.StickerId = stickerId;
			bool uiactive = this.IsReceived();
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06041D9C RID: 269724 RVA: 0x010E5349 File Offset: 0x010E3549
		public bool IsReceived()
		{
			return ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData.IsStickerReceived(this.StickerId);
		}

		// Token: 0x06041D9D RID: 269725 RVA: 0x010E5360 File Offset: 0x010E3560
		public void SetToggleSelect(bool isSelected, bool? fireEvent = null)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent.GetValueOrDefault(), false, false);
		}

		// Token: 0x06041D9E RID: 269726 RVA: 0x010E5383 File Offset: 0x010E3583
		private void OnClickToggle(EToggleState state)
		{
			if (this.StickerId == 0)
			{
				return;
			}
			Action clickToggleCallback = this.ClickToggleCallback;
			if (clickToggleCallback == null)
			{
				return;
			}
			clickToggleCallback();
		}

		// Token: 0x04024BF6 RID: 150518
		private int StickerId;

		// Token: 0x04024BF7 RID: 150519
		[Nullable(2)]
		public Action ClickToggleCallback;
	}
}
