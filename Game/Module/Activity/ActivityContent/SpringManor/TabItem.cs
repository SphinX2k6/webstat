using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006336 RID: 25398
	public class TabItem : GridProxyAbstract<int>
	{
		// Token: 0x0603FCC4 RID: 261316 RVA: 0x0105C008 File Offset: 0x0105A208
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
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FCC5 RID: 261317 RVA: 0x0105C0D0 File Offset: 0x0105A2D0
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.TabIndex = data;
			SpringFestivalRewardTab? rewardTabConfigById = ConfigBase<SpringManorConfig>.Instance.GetRewardTabConfigById(data);
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(rewardTabConfigById.Value.Name);
			}
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(ModelBase<SpringManorModel>.Instance.ActivityData.IsTabHasAnyClaimable(data));
		}

		// Token: 0x0603FCC6 RID: 261318 RVA: 0x0105C132 File Offset: 0x0105A332
		private void OnClickToggle(EToggleState state)
		{
			Action<int> onTabClickCallBack = this.OnTabClickCallBack;
			if (onTabClickCallBack == null)
			{
				return;
			}
			onTabClickCallBack(this.TabIndex);
		}

		// Token: 0x0603FCC7 RID: 261319 RVA: 0x0105C14A File Offset: 0x0105A34A
		[NullableContext(1)]
		public void SetTabClickCallback(Action<int> callback)
		{
			this.OnTabClickCallBack = callback;
		}

		// Token: 0x0603FCC8 RID: 261320 RVA: 0x0105C153 File Offset: 0x0105A353
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelect(false, false);
		}

		// Token: 0x0603FCC9 RID: 261321 RVA: 0x0105C15D File Offset: 0x0105A35D
		public void SetToggleSelect(bool isSelected, bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x04023D44 RID: 146756
		private int TabIndex = -1;

		// Token: 0x04023D45 RID: 146757
		[Nullable(2)]
		private Action<int> OnTabClickCallBack;
	}
}
