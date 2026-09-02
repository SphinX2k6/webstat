using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FilterSort.Sort.BaseSortGroup
{
	// Token: 0x02005E39 RID: 24121
	[NullableContext(1)]
	[Nullable(0)]
	internal class SortItem : UiPanelBase
	{
		// Token: 0x0603CB35 RID: 248629 RVA: 0x00F6A88A File Offset: 0x00F68A8A
		public SortItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CB36 RID: 248630 RVA: 0x00F6A8B4 File Offset: 0x00F68AB4
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleEvent));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CB37 RID: 248631 RVA: 0x00F6A97B File Offset: 0x00F68B7B
		private void ToggleEvent(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				TSortItemToggleEvent toggleFunction = this.ToggleFunction;
				if (toggleFunction == null)
				{
					return;
				}
				toggleFunction(this.RuleId, this.Name);
			}
		}

		// Token: 0x0603CB38 RID: 248632 RVA: 0x00F6A99D File Offset: 0x00F68B9D
		protected override void OnStart()
		{
			base.GetExtendToggle(1).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x0603CB39 RID: 248633 RVA: 0x00F6A9BC File Offset: 0x00F68BBC
		private bool CanExecuteChange()
		{
			return this.CanExecuteChangeInternal == null || this.CanExecuteChangeInternal(this.RuleId);
		}

		// Token: 0x0603CB3A RID: 248634 RVA: 0x00F6A9D9 File Offset: 0x00F68BD9
		protected override void OnBeforeDestroy()
		{
			base.GetExtendToggle(1).CanExecuteChange.Unbind();
		}

		// Token: 0x0603CB3B RID: 248635 RVA: 0x00F6A9EC File Offset: 0x00F68BEC
		private void SetName()
		{
			this.Name = ConfigBase<SortConfig>.Instance.GetSortRuleName(this.RuleId, this.DataType);
			base.GetText(0).SetText(this.Name, true);
		}

		// Token: 0x0603CB3C RID: 248636 RVA: 0x00F6AA20 File Offset: 0x00F68C20
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

		// Token: 0x0603CB3D RID: 248637 RVA: 0x00F6AAB8 File Offset: 0x00F68CB8
		public void SetToggleFunction(TSortItemToggleEvent toggleFunction)
		{
			this.ToggleFunction = toggleFunction;
		}

		// Token: 0x0603CB3E RID: 248638 RVA: 0x00F6AAC1 File Offset: 0x00F68CC1
		public void SetCanExecuteChange(TCanExecuteChange callback)
		{
			this.CanExecuteChangeInternal = callback;
		}

		// Token: 0x0603CB3F RID: 248639 RVA: 0x00F6AACC File Offset: 0x00F68CCC
		public void SetToggleStateForce(bool bSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603CB40 RID: 248640 RVA: 0x00F6AAF1 File Offset: 0x00F68CF1
		public void ShowSortItem(int ruleId, ESortDataType dateType, bool bSelected)
		{
			this.RuleId = ruleId;
			this.DataType = dateType;
			this.SetName();
			this.SetTexture();
			this.SetToggleStateForce(bSelected);
		}

		// Token: 0x0402215E RID: 139614
		private int RuleId;

		// Token: 0x0402215F RID: 139615
		private ESortDataType DataType = ESortDataType.Role;

		// Token: 0x04022160 RID: 139616
		private string Name = "";

		// Token: 0x04022161 RID: 139617
		[Nullable(2)]
		private TSortItemToggleEvent ToggleFunction;

		// Token: 0x04022162 RID: 139618
		[Nullable(2)]
		private TCanExecuteChange CanExecuteChangeInternal;

		// Token: 0x0200BE6B RID: 48747
		[NullableContext(0)]
		private enum ESortItemDefine
		{
			// Token: 0x0403AA18 RID: 240152
			Name,
			// Token: 0x0403AA19 RID: 240153
			Toggle,
			// Token: 0x0403AA1A RID: 240154
			Icon
		}
	}
}
