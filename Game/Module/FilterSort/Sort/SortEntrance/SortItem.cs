using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FilterSort.Sort.SortEntrance
{
	// Token: 0x02005E35 RID: 24117
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class SortItem : GridProxyAbstract<ISortData>
	{
		// Token: 0x0603CB01 RID: 248577 RVA: 0x00F69BF0 File Offset: 0x00F67DF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleEvent));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CB02 RID: 248578 RVA: 0x00F69C96 File Offset: 0x00F67E96
		private void ToggleEvent(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				TSortItemToggleEvent toggleFunction = this.ToggleFunction;
				if (toggleFunction == null)
				{
					return;
				}
				toggleFunction(this.SortData.RuleId, this.Name);
			}
		}

		// Token: 0x0603CB03 RID: 248579 RVA: 0x00F69CBD File Offset: 0x00F67EBD
		protected override void OnStart()
		{
			base.GetExtendToggle(1).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x0603CB04 RID: 248580 RVA: 0x00F69CDC File Offset: 0x00F67EDC
		private bool CanExecuteChange()
		{
			return this.CanExecuteChangeInternal == null || this.CanExecuteChangeInternal(this.SortData.RuleId);
		}

		// Token: 0x0603CB05 RID: 248581 RVA: 0x00F69CFE File Offset: 0x00F67EFE
		private void SetName()
		{
			this.Name = ConfigBase<SortConfig>.Instance.GetSortRuleName(this.SortData.RuleId, this.SortData.DataType);
			base.GetText(0).SetText(this.Name, true);
		}

		// Token: 0x0603CB06 RID: 248582 RVA: 0x00F69D3C File Offset: 0x00F67F3C
		private void SetDefaultToggleState(bool bSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603CB07 RID: 248583 RVA: 0x00F69D61 File Offset: 0x00F67F61
		public void SetToggleFunction(TSortItemToggleEvent toggleFunction)
		{
			this.ToggleFunction = toggleFunction;
		}

		// Token: 0x0603CB08 RID: 248584 RVA: 0x00F69D6A File Offset: 0x00F67F6A
		public void SetCanExecuteChange(TCanExecuteChange callback)
		{
			this.CanExecuteChangeInternal = callback;
		}

		// Token: 0x0603CB09 RID: 248585 RVA: 0x00F69D74 File Offset: 0x00F67F74
		public void SetToggleStateForce(bool bSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603CB0A RID: 248586 RVA: 0x00F69D99 File Offset: 0x00F67F99
		public override void Refresh(ISortData data, bool isSelected, int gridIndex)
		{
			this.SortData = data;
			this.SetName();
			this.SetDefaultToggleState(this.SortData.SelectedRule == this.SortData.RuleId);
		}

		// Token: 0x0603CB0B RID: 248587 RVA: 0x00F69DC6 File Offset: 0x00F67FC6
		public override object GetKey(ISortData data, int displayIndex)
		{
			return data.RuleId;
		}

		// Token: 0x0402214B RID: 139595
		[Nullable(2)]
		private ISortData SortData;

		// Token: 0x0402214C RID: 139596
		private string Name = "";

		// Token: 0x0402214D RID: 139597
		[Nullable(2)]
		private TSortItemToggleEvent ToggleFunction;

		// Token: 0x0402214E RID: 139598
		[Nullable(2)]
		private TCanExecuteChange CanExecuteChangeInternal;

		// Token: 0x0200BE68 RID: 48744
		[NullableContext(0)]
		private enum ESortItemDefine
		{
			// Token: 0x0403AA0B RID: 240139
			Name,
			// Token: 0x0403AA0C RID: 240140
			Toggle
		}
	}
}
