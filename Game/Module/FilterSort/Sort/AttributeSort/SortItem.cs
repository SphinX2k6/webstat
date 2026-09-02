using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FilterSort.Sort.AttributeSort
{
	// Token: 0x02005E3D RID: 24125
	[NullableContext(1)]
	[Nullable(0)]
	internal class SortItem : UiPanelBase
	{
		// Token: 0x0603CB57 RID: 248663 RVA: 0x00F6AE38 File Offset: 0x00F69038
		public SortItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CB58 RID: 248664 RVA: 0x00F6AE60 File Offset: 0x00F69060
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleEvent));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CB59 RID: 248665 RVA: 0x00F6AF48 File Offset: 0x00F69148
		private void ToggleEvent(EToggleState state)
		{
			TSortItemToggleEventWithState toggleFunction = this.ToggleFunction;
			if (toggleFunction == null)
			{
				return;
			}
			toggleFunction(state, this.RuleId, this.Name);
		}

		// Token: 0x0603CB5A RID: 248666 RVA: 0x00F6AF67 File Offset: 0x00F69167
		protected override void OnStart()
		{
			base.GetExtendToggle(1).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x0603CB5B RID: 248667 RVA: 0x00F6AF86 File Offset: 0x00F69186
		private bool CanExecuteChange()
		{
			return base.GetExtendToggle(1).ToggleState == EToggleState.ETT_Checked || this.CanExecuteChangeInternal == null || this.CanExecuteChangeInternal();
		}

		// Token: 0x0603CB5C RID: 248668 RVA: 0x00F6AFAE File Offset: 0x00F691AE
		protected override void OnBeforeDestroy()
		{
			base.GetExtendToggle(1).CanExecuteChange.Unbind();
		}

		// Token: 0x0603CB5D RID: 248669 RVA: 0x00F6AFC1 File Offset: 0x00F691C1
		private void SetName()
		{
			this.Name = ConfigBase<SortConfig>.Instance.GetSortRuleName(this.RuleId, this.DataType);
			base.GetText(0).SetText(this.Name, true);
		}

		// Token: 0x0603CB5E RID: 248670 RVA: 0x00F6AFF4 File Offset: 0x00F691F4
		private void SetTexture()
		{
			int sortRuleAttributeId = ConfigBase<SortConfig>.Instance.GetSortRuleAttributeId(this.RuleId, this.DataType);
			bool flag = sortRuleAttributeId > 0;
			string text = flag ? ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexIcon(sortRuleAttributeId) : ConfigBase<SortConfig>.Instance.GetSortRuleIcon(this.RuleId, this.DataType);
			UUITexture texture = base.GetTexture(2);
			if (StringUtils.IsBlank(text))
			{
				texture.SetUIActive(false);
				return;
			}
			texture.SetUIActive(true);
			base.SetTextureByPath(text, texture, null, null);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0603CB5F RID: 248671 RVA: 0x00F6B08C File Offset: 0x00F6928C
		private void SetToggleState(bool bSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603CB60 RID: 248672 RVA: 0x00F6B0B1 File Offset: 0x00F692B1
		public void SetToggleFunction(TSortItemToggleEventWithState toggleFunction)
		{
			this.ToggleFunction = toggleFunction;
		}

		// Token: 0x0603CB61 RID: 248673 RVA: 0x00F6B0BA File Offset: 0x00F692BA
		public void SetCanExecuteChange(TCanExecuteChangeSimple callback)
		{
			this.CanExecuteChangeInternal = callback;
		}

		// Token: 0x0603CB62 RID: 248674 RVA: 0x00F6B0C3 File Offset: 0x00F692C3
		public void ShowSortItem(int ruleId, ESortDataType dataType, int sortIndex)
		{
			this.RuleId = ruleId;
			this.DataType = dataType;
			this.SetName();
			this.SetTexture();
			this.SetToggleState(sortIndex > 0);
			this.RefreshIndex(sortIndex);
		}

		// Token: 0x0603CB63 RID: 248675 RVA: 0x00F6B0F0 File Offset: 0x00F692F0
		public void RefreshIndex(int sortIndex)
		{
			UUIText text = base.GetText(3);
			if (sortIndex == 0)
			{
				text.SetUIActive(false);
				return;
			}
			text.SetUIActive(true);
			text.SetText(sortIndex.ToString(), true);
		}

		// Token: 0x04022168 RID: 139624
		private int RuleId;

		// Token: 0x04022169 RID: 139625
		private string Name = "";

		// Token: 0x0402216A RID: 139626
		private ESortDataType DataType = ESortDataType.Role;

		// Token: 0x0402216B RID: 139627
		[Nullable(2)]
		private TSortItemToggleEventWithState ToggleFunction;

		// Token: 0x0402216C RID: 139628
		[Nullable(2)]
		private TCanExecuteChangeSimple CanExecuteChangeInternal;

		// Token: 0x0200BE6D RID: 48749
		[NullableContext(0)]
		private enum ESortItemDefine
		{
			// Token: 0x0403AA1F RID: 240159
			Name,
			// Token: 0x0403AA20 RID: 240160
			Toggle,
			// Token: 0x0403AA21 RID: 240161
			Icon,
			// Token: 0x0403AA22 RID: 240162
			LimitNum
		}
	}
}
