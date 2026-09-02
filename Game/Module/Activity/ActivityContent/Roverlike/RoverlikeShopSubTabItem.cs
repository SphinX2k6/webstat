using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006439 RID: 25657
	public class RoverlikeShopSubTabItem : GridProxyAbstract<int>
	{
		// Token: 0x060406A1 RID: 263841 RVA: 0x0108378C File Offset: 0x0108198C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060406A2 RID: 263842 RVA: 0x01083832 File Offset: 0x01081A32
		public void SetShopId(int shopId)
		{
			this.ShopId = shopId;
		}

		// Token: 0x060406A3 RID: 263843 RVA: 0x0108383B File Offset: 0x01081A3B
		[NullableContext(1)]
		public void SetOnToggle(Action<int> callback)
		{
			this.OnToggle = callback;
		}

		// Token: 0x060406A4 RID: 263844 RVA: 0x01083844 File Offset: 0x01081A44
		public override void Refresh(int dataId, bool isSelected, int gridIndex)
		{
			this.TabId = dataId;
			PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId((PayShopDefine.EPayShopTabType)this.ShopId, dataId);
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText((payShopTabDataByPayShopIdAndTabId != null) ? payShopTabDataByPayShopIdAndTabId.Name : "", true);
		}

		// Token: 0x060406A5 RID: 263845 RVA: 0x0108388C File Offset: 0x01081A8C
		public void SetToggleState(bool bSelected)
		{
			EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x060406A6 RID: 263846 RVA: 0x010838B7 File Offset: 0x01081AB7
		[NullableContext(1)]
		public override object GetKey(int data, int displayIndex)
		{
			return data;
		}

		// Token: 0x060406A7 RID: 263847 RVA: 0x010838BF File Offset: 0x01081ABF
		private void OnToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> onToggle = this.OnToggle;
				if (onToggle == null)
				{
					return;
				}
				onToggle(this.TabId);
			}
		}

		// Token: 0x0402412C RID: 147756
		private int ShopId;

		// Token: 0x0402412D RID: 147757
		private int TabId;

		// Token: 0x0402412E RID: 147758
		[Nullable(2)]
		private Action<int> OnToggle;

		// Token: 0x0200C4AD RID: 50349
		private class EComponent
		{
			// Token: 0x0403C897 RID: 247959
			public const int Name = 0;

			// Token: 0x0403C898 RID: 247960
			public const int Toggle = 1;

			// Token: 0x0403C899 RID: 247961
			public const int Reddot = 2;
		}
	}
}
