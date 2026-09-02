using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200678D RID: 26509
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FishingRewardTargetTabItem : GridProxyAbstract<FishingRewardTargetTabData>
	{
		// Token: 0x0604213E RID: 270654 RVA: 0x010F4100 File Offset: 0x010F2300
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnTabToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604213F RID: 270655 RVA: 0x010F41C8 File Offset: 0x010F23C8
		public void SetToggleState(bool bSelect, bool bFire)
		{
			EToggleState state = bSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, bFire, false, false);
		}

		// Token: 0x06042140 RID: 270656 RVA: 0x010F41F3 File Offset: 0x010F23F3
		private void SetRedDotVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(bVisible);
		}

		// Token: 0x06042141 RID: 270657 RVA: 0x010F4208 File Offset: 0x010F2408
		public void RefreshRedDot()
		{
			FishingRewardTargetTabData tabData = this.TabData;
			bool? flag;
			if (tabData == null)
			{
				flag = null;
			}
			else
			{
				Func<int, bool> refreshRedDot = tabData.RefreshRedDot;
				flag = ((refreshRedDot != null) ? new bool?(refreshRedDot(this.TabIndex + 1)) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault();
			this.SetRedDotVisible(valueOrDefault);
		}

		// Token: 0x06042142 RID: 270658 RVA: 0x010F4260 File Offset: 0x010F2460
		[NullableContext(1)]
		public override void Refresh(FishingRewardTargetTabData data, bool isSelected, int gridIndex)
		{
			this.TabData = data;
			this.TabIndex = data.Index;
			if (!StringUtils.IsEmpty(data.NameTextId))
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.ShowTextNew(data.NameTextId);
				}
			}
			this.RefreshRedDot();
		}

		// Token: 0x06042143 RID: 270659 RVA: 0x010F42A0 File Offset: 0x010F24A0
		private void OnTabToggle(EToggleState _)
		{
			FishingRewardTargetTabData tabData = this.TabData;
			if (tabData == null)
			{
				return;
			}
			Action<int> clickedCallback = tabData.ClickedCallback;
			if (clickedCallback == null)
			{
				return;
			}
			clickedCallback(this.TabIndex);
		}

		// Token: 0x04024D61 RID: 150881
		[Nullable(2)]
		private FishingRewardTargetTabData TabData;

		// Token: 0x04024D62 RID: 150882
		private int TabIndex = -1;

		// Token: 0x0200C7AB RID: 51115
		private class EComponentDefine
		{
			// Token: 0x0403D786 RID: 251782
			public const int Name = 0;

			// Token: 0x0403D787 RID: 251783
			public const int Toggle = 1;

			// Token: 0x0403D788 RID: 251784
			public const int RedDot = 2;
		}
	}
}
