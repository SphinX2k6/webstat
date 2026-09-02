using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x0200663D RID: 26173
	public class PinballBattleRoleDetailTabItem : GridProxyAbstract<EPinballBattleRoleDetailTabType>
	{
		// Token: 0x060415FE RID: 267774 RVA: 0x010C5270 File Offset: 0x010C3470
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060415FF RID: 267775 RVA: 0x010C5318 File Offset: 0x010C3518
		public override void Refresh(EPinballBattleRoleDetailTabType data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			string textStringId = null;
			switch (data)
			{
			case EPinballBattleRoleDetailTabType.Buff:
				textStringId = "Pinaball_inside_State";
				break;
			case EPinballBattleRoleDetailTabType.Attr:
				textStringId = "Pinaball_inside_Attribute";
				break;
			case EPinballBattleRoleDetailTabType.Skill:
				textStringId = "Pinaball_inside_Skill";
				break;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}

		// Token: 0x06041600 RID: 267776 RVA: 0x010C536F File Offset: 0x010C356F
		private void OnToggleStateChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				IScrollViewDelegate<IGridProxy<EPinballBattleRoleDetailTabType>, EPinballBattleRoleDetailTabType> scrollViewDelegate = base.ScrollViewDelegate;
				if (scrollViewDelegate == null)
				{
					return;
				}
				scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, true);
			}
		}

		// Token: 0x06041601 RID: 267777 RVA: 0x010C5392 File Offset: 0x010C3592
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
			}
			Action<EPinballBattleRoleDetailTabType> onSelectCallBack = this.OnSelectCallBack;
			if (onSelectCallBack == null)
			{
				return;
			}
			onSelectCallBack(this.Data);
		}

		// Token: 0x06041602 RID: 267778 RVA: 0x010C53C1 File Offset: 0x010C35C1
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x040248F7 RID: 149751
		private EPinballBattleRoleDetailTabType Data;

		// Token: 0x040248F8 RID: 149752
		[Nullable(2)]
		public Action<EPinballBattleRoleDetailTabType> OnSelectCallBack;

		// Token: 0x0200C663 RID: 50787
		private enum EPinballBattleRoleDetailTabItemComp
		{
			// Token: 0x0403D13B RID: 250171
			Toggle,
			// Token: 0x0403D13C RID: 250172
			Name
		}
	}
}
