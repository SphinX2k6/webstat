using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EE1 RID: 20193
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseRewardMenuItem : GridProxyAbstract<TowerDefenseRewardMenuItemData>
	{
		// Token: 0x06034276 RID: 213622 RVA: 0x00D0A798 File Offset: 0x00D08998
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034277 RID: 213623 RVA: 0x00D0A860 File Offset: 0x00D08A60
		[NullableContext(1)]
		public override void Refresh(TowerDefenseRewardMenuItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GetText(1).SetText(data.Page.TabName ?? "", true);
			base.GetExtendToggle(0).SetToggleState(data.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			base.GetItem(2).SetUIActive(data.HasRedDot);
		}

		// Token: 0x06034278 RID: 213624 RVA: 0x00D0A8C3 File Offset: 0x00D08AC3
		public void SetSelected(bool isSelected)
		{
			if (this.Data != null)
			{
				this.Data.IsSelected = isSelected;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06034279 RID: 213625 RVA: 0x00D0A8F5 File Offset: 0x00D08AF5
		public void SetRedDot(bool hasRedDot)
		{
			if (this.Data != null)
			{
				this.Data.HasRedDot = hasRedDot;
			}
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(hasRedDot);
		}

		// Token: 0x0603427A RID: 213626 RVA: 0x00D0A91D File Offset: 0x00D08B1D
		private void OnClickToggle(EToggleState state)
		{
			if (this.Data != null)
			{
				Action<int> onClick = this.OnClick;
				if (onClick == null)
				{
					return;
				}
				onClick(this.Data.Index);
			}
		}

		// Token: 0x0401E1CC RID: 123340
		public Action<int> OnClick;

		// Token: 0x0401E1CD RID: 123341
		private TowerDefenseRewardMenuItemData Data;

		// Token: 0x0200AE95 RID: 44693
		[NullableContext(0)]
		private class EMenuComponent
		{
			// Token: 0x04036345 RID: 222021
			public const int Toggle = 0;

			// Token: 0x04036346 RID: 222022
			public const int Text = 1;

			// Token: 0x04036347 RID: 222023
			public const int RedDotItem = 2;
		}
	}
}
