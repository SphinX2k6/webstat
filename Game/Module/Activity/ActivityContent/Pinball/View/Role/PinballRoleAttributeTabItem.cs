using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065CB RID: 26059
	public class PinballRoleAttributeTabItem : UiPanelBase
	{
		// Token: 0x060411B5 RID: 266677 RVA: 0x010B40E8 File Offset: 0x010B22E8
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(delegate(EToggleState _)
			{
				this.OnSelectedInternal();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060411B6 RID: 266678 RVA: 0x010B418E File Offset: 0x010B238E
		[NullableContext(1)]
		public void Refresh(IPinballRoleAttributeTabItemData data)
		{
			this.Data = data;
			this.OnSelectedDelegate = data.OnSelectedDelegate;
			this.RefreshSelectState(true);
		}

		// Token: 0x060411B7 RID: 266679 RVA: 0x010B41AC File Offset: 0x010B23AC
		public void RefreshSelectState(bool bJumpToLastFrame)
		{
			IPinballRoleAttributeTabItemData data = this.Data;
			EToggleState state = (data != null && data.IsSelected) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, bJumpToLastFrame);
		}

		// Token: 0x060411B8 RID: 266680 RVA: 0x010B41E8 File Offset: 0x010B23E8
		private void OnSelectedInternal()
		{
			IPinballRoleAttributeTabItemData data = this.Data;
			EPinballRoleAttributeTabIndex? epinballRoleAttributeTabIndex = (data != null) ? new EPinballRoleAttributeTabIndex?(data.TabIndex) : null;
			if (epinballRoleAttributeTabIndex == null)
			{
				return;
			}
			Action<EPinballRoleAttributeTabIndex> onSelectedDelegate = this.OnSelectedDelegate;
			if (onSelectedDelegate == null)
			{
				return;
			}
			onSelectedDelegate(epinballRoleAttributeTabIndex.Value);
		}

		// Token: 0x0402478B RID: 149387
		[Nullable(2)]
		protected IPinballRoleAttributeTabItemData Data;

		// Token: 0x0402478C RID: 149388
		[Nullable(2)]
		public Action<EPinballRoleAttributeTabIndex> OnSelectedDelegate;

		// Token: 0x0200C5CB RID: 50635
		private enum EComponent
		{
			// Token: 0x0403CE13 RID: 249363
			ItemToggle,
			// Token: 0x0403CE14 RID: 249364
			NameText
		}
	}
}
