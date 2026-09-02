using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x020057A1 RID: 22433
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SetItem : GridProxyAbstract<ISetItemData>
	{
		// Token: 0x060390AA RID: 233642 RVA: 0x00E747CC File Offset: 0x00E729CC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItemToggle))
			};
		}

		// Token: 0x060390AB RID: 233643 RVA: 0x00E74834 File Offset: 0x00E72A34
		public override void Refresh(ISetItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		}

		// Token: 0x060390AC RID: 233644 RVA: 0x00E7487D File Offset: 0x00E72A7D
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060390AD RID: 233645 RVA: 0x00E74890 File Offset: 0x00E72A90
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060390AE RID: 233646 RVA: 0x00E748A3 File Offset: 0x00E72AA3
		private void OnClickItemToggle(EToggleState toggleState)
		{
			if (this.Data != null && this.CallbackClickItem != null)
			{
				this.CallbackClickItem(this.Data);
			}
		}

		// Token: 0x0402079B RID: 133019
		[Nullable(2)]
		private ISetItemData Data;

		// Token: 0x0402079C RID: 133020
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ISetItemData> CallbackClickItem;
	}
}
