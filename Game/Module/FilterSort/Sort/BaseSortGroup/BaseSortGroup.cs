using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FilterSort.Sort.BaseSortGroup
{
	// Token: 0x02005E3A RID: 24122
	[NullableContext(1)]
	[Nullable(0)]
	public class BaseSortGroup : UiPanelBase
	{
		// Token: 0x0603CB41 RID: 248641 RVA: 0x00F6AB14 File Offset: 0x00F68D14
		public BaseSortGroup(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CB42 RID: 248642 RVA: 0x00F6AB30 File Offset: 0x00F68D30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CB43 RID: 248643 RVA: 0x00F6AB99 File Offset: 0x00F68D99
		protected override void OnStart()
		{
			this.Layout = new GenericLayoutNew<SortItem>(base.GetLayoutBase(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<SortItem>(this.InitSortItem), base.GetItem(1));
		}

		// Token: 0x0603CB44 RID: 248644 RVA: 0x00F6ABC0 File Offset: 0x00F68DC0
		private ILayoutItem<SortItem> InitSortItem(object tempRuleId, UUIItem uiItem, int index)
		{
			int num = (int)tempRuleId;
			SortItem sortItem = new SortItem(uiItem);
			sortItem.SetToggleFunction(new TSortItemToggleEvent(this.SortItemToggleEvent));
			sortItem.SetCanExecuteChange(new TCanExecuteChange(this.CanExecuteChange));
			sortItem.ShowSortItem(num, this.DataType, this.TempSelect.Value.Item1 == num);
			return new LayoutItem<SortItem>
			{
				Key = num,
				Value = sortItem
			};
		}

		// Token: 0x0603CB45 RID: 248645 RVA: 0x00F6AC37 File Offset: 0x00F68E37
		private void SortItemToggleEvent(int ruleId, string name)
		{
			this.ResetLastSelect();
			this.TempSelect = new ValueTuple<int, string>?(new ValueTuple<int, string>(ruleId, name));
		}

		// Token: 0x0603CB46 RID: 248646 RVA: 0x00F6AC51 File Offset: 0x00F68E51
		private bool CanExecuteChange(int ruleId)
		{
			return this.TempSelect.Value.Item1 != ruleId;
		}

		// Token: 0x0603CB47 RID: 248647 RVA: 0x00F6AC69 File Offset: 0x00F68E69
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603CB48 RID: 248648 RVA: 0x00F6AC6B File Offset: 0x00F68E6B
		private void ResetLastSelect()
		{
			this.Layout.GetLayoutItemByKey(this.TempSelect.Value.Item1).SetToggleStateForce(false);
		}

		// Token: 0x0603CB49 RID: 248649 RVA: 0x00F6AC94 File Offset: 0x00F68E94
		private void InitConfigId()
		{
			SortResultData sortResultData = ModelBase<SortModel>.Instance.GetSortResultData(this.UniqueId);
			this.ConfigId = sortResultData.ConfigId;
		}

		// Token: 0x0603CB4A RID: 248650 RVA: 0x00F6ACC0 File Offset: 0x00F68EC0
		private void InitTempSelect()
		{
			SortViewBaseSort selectBaseSort = ModelBase<SortModel>.Instance.GetSortResultData(this.UniqueId).GetSelectBaseSort();
			this.TempSelect = new ValueTuple<int, string>?(new ValueTuple<int, string>(selectBaseSort.RuleId, selectBaseSort.RuleName));
		}

		// Token: 0x0603CB4B RID: 248651 RVA: 0x00F6AD00 File Offset: 0x00F68F00
		private void InitSort()
		{
			Sort value = ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId).Value;
			this.DataType = (ESortDataType)value.DataId;
			this.Layout.RebuildLayoutByDataNew<int>(value.BaseSortList(), null);
		}

		// Token: 0x0603CB4C RID: 248652 RVA: 0x00F6AD4E File Offset: 0x00F68F4E
		public void Init(int uniqueId)
		{
			this.UniqueId = uniqueId;
			this.InitConfigId();
			this.InitTempSelect();
			this.InitSort();
		}

		// Token: 0x0603CB4D RID: 248653 RVA: 0x00F6AD6C File Offset: 0x00F68F6C
		public void Reset()
		{
			int num = ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId).Value.BaseSortList()[0];
			string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(num, this.DataType);
			this.TempSelect = new ValueTuple<int, string>?(new ValueTuple<int, string>(num, sortRuleName));
			foreach (KeyValuePair<object, SortItem> keyValuePair in this.Layout.GetLayoutItemMap())
			{
				int num2 = (int)keyValuePair.Key;
				keyValuePair.Value.ShowSortItem(num2, this.DataType, num == num2);
			}
		}

		// Token: 0x0603CB4E RID: 248654 RVA: 0x00F6AE30 File Offset: 0x00F69030
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<int, string>? GetTempSelect()
		{
			return this.TempSelect;
		}

		// Token: 0x04022163 RID: 139619
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<SortItem> Layout;

		// Token: 0x04022164 RID: 139620
		[Nullable(new byte[]
		{
			0,
			1
		})]
		private ValueTuple<int, string>? TempSelect;

		// Token: 0x04022165 RID: 139621
		private int ConfigId;

		// Token: 0x04022166 RID: 139622
		private int UniqueId;

		// Token: 0x04022167 RID: 139623
		private ESortDataType DataType = ESortDataType.Role;

		// Token: 0x0200BE6C RID: 48748
		[NullableContext(0)]
		private enum ECompDefine
		{
			// Token: 0x0403AA1C RID: 240156
			Layout,
			// Token: 0x0403AA1D RID: 240157
			LayoutItem
		}
	}
}
