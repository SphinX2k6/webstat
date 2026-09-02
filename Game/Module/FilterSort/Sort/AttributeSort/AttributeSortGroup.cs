using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FilterSort.Sort.AttributeSort
{
	// Token: 0x02005E3E RID: 24126
	[NullableContext(1)]
	[Nullable(0)]
	public class AttributeSortGroup : UiPanelBase
	{
		// Token: 0x0603CB64 RID: 248676 RVA: 0x00F6B125 File Offset: 0x00F69325
		public AttributeSortGroup(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CB65 RID: 248677 RVA: 0x00F6B14C File Offset: 0x00F6934C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CB66 RID: 248678 RVA: 0x00F6B1D6 File Offset: 0x00F693D6
		protected override void OnStart()
		{
			this.Layout = new GenericLayoutNew<SortItem>(base.GetLayoutBase(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<SortItem>(this.InitSortItem), base.GetItem(2));
		}

		// Token: 0x0603CB67 RID: 248679 RVA: 0x00F6B200 File Offset: 0x00F69400
		private ILayoutItem<SortItem> InitSortItem(object tempRuleId, UUIItem uiItem, int index)
		{
			int num = (int)tempRuleId;
			SortItem sortItem = new SortItem(uiItem);
			sortItem.SetToggleFunction(new TSortItemToggleEventWithState(this.SortItemToggleEvent));
			sortItem.SetCanExecuteChange(new TCanExecuteChangeSimple(this.CanExecuteChange));
			int num2 = this.FindSortIndex(num);
			sortItem.ShowSortItem(num, this.DataType, num2 + 1);
			return new LayoutItem<SortItem>
			{
				Key = num,
				Value = sortItem
			};
		}

		// Token: 0x0603CB68 RID: 248680 RVA: 0x00F6B26F File Offset: 0x00F6946F
		private void SortItemToggleEvent(EToggleState state, int ruleId, string name)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.TempSelectMap.Add(ruleId, name);
			}
			else
			{
				this.TempSelectMap.Remove(ruleId);
				this.CancelSortIndex(ruleId);
			}
			this.RefreshSortIndex();
			this.SetTitle();
		}

		// Token: 0x0603CB69 RID: 248681 RVA: 0x00F6B2A4 File Offset: 0x00F694A4
		private bool CanExecuteChange()
		{
			return this.LimitNum == 0 || this.TempSelectMap.Count < this.LimitNum;
		}

		// Token: 0x0603CB6A RID: 248682 RVA: 0x00F6B2C3 File Offset: 0x00F694C3
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603CB6B RID: 248683 RVA: 0x00F6B2C8 File Offset: 0x00F694C8
		private int FindSortIndex(int ruleId)
		{
			int num = 0;
			using (Dictionary<int, string>.KeyCollection.Enumerator enumerator = this.TempSelectMap.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == ruleId)
					{
						return num;
					}
					num++;
				}
			}
			return -1;
		}

		// Token: 0x0603CB6C RID: 248684 RVA: 0x00F6B328 File Offset: 0x00F69528
		private void CancelSortIndex(int ruleId)
		{
			this.Layout.GetLayoutItemByKey(ruleId).RefreshIndex(0);
		}

		// Token: 0x0603CB6D RID: 248685 RVA: 0x00F6B344 File Offset: 0x00F69544
		private void RefreshSortIndex()
		{
			int num = 0;
			foreach (int num2 in this.TempSelectMap.Keys)
			{
				this.Layout.GetLayoutItemByKey(num2).RefreshIndex(num + 1);
				num++;
			}
		}

		// Token: 0x0603CB6E RID: 248686 RVA: 0x00F6B3B4 File Offset: 0x00F695B4
		private void InitConfigId()
		{
			SortResultData sortResultData = ModelBase<SortModel>.Instance.GetSortResultData(this.UniqueId);
			this.ConfigId = sortResultData.ConfigId;
		}

		// Token: 0x0603CB6F RID: 248687 RVA: 0x00F6B3E0 File Offset: 0x00F695E0
		private void InitTempSelectList()
		{
			Dictionary<int, string> selectAttributeSort = ModelBase<SortModel>.Instance.GetSortResultData(this.UniqueId).GetSelectAttributeSort();
			if (selectAttributeSort == null)
			{
				return;
			}
			foreach (KeyValuePair<int, string> keyValuePair in selectAttributeSort)
			{
				this.TempSelectMap.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x0603CB70 RID: 248688 RVA: 0x00F6B45C File Offset: 0x00F6965C
		private void InitSort()
		{
			Sort value = ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId).Value;
			this.LimitNum = value.LimitNum;
			this.DataType = (ESortDataType)value.DataId;
			this.Layout.RebuildLayoutByDataNew<int>(value.AttributeSortList(), null);
		}

		// Token: 0x0603CB71 RID: 248689 RVA: 0x00F6B4B8 File Offset: 0x00F696B8
		private void SetTitle()
		{
			UUIText text = base.GetText(0);
			if (this.LimitNum == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "AttributeSortName", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(text, "AttributeSortLimitName", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.TempSelectMap.Count,
				this.LimitNum
			}));
		}

		// Token: 0x0603CB72 RID: 248690 RVA: 0x00F6B527 File Offset: 0x00F69727
		public void Init(int uniqueId)
		{
			this.UniqueId = uniqueId;
			this.InitConfigId();
			this.InitTempSelectList();
			this.InitSort();
			this.SetTitle();
		}

		// Token: 0x0603CB73 RID: 248691 RVA: 0x00F6B548 File Offset: 0x00F69748
		public void Reset()
		{
			this.TempSelectMap.Clear();
			foreach (KeyValuePair<object, SortItem> keyValuePair in this.Layout.GetLayoutItemMap())
			{
				int ruleId = (int)keyValuePair.Key;
				keyValuePair.Value.ShowSortItem(ruleId, this.DataType, 0);
			}
			this.SetTitle();
		}

		// Token: 0x0603CB74 RID: 248692 RVA: 0x00F6B5CC File Offset: 0x00F697CC
		public Dictionary<int, string> GetTempSelectMap()
		{
			return this.TempSelectMap;
		}

		// Token: 0x0402216D RID: 139629
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<SortItem> Layout;

		// Token: 0x0402216E RID: 139630
		private readonly Dictionary<int, string> TempSelectMap = new Dictionary<int, string>();

		// Token: 0x0402216F RID: 139631
		private int ConfigId;

		// Token: 0x04022170 RID: 139632
		private int UniqueId;

		// Token: 0x04022171 RID: 139633
		private ESortDataType DataType = ESortDataType.Role;

		// Token: 0x04022172 RID: 139634
		private int LimitNum;

		// Token: 0x0200BE6E RID: 48750
		[NullableContext(0)]
		private enum ECompDefine
		{
			// Token: 0x0403AA24 RID: 240164
			Title,
			// Token: 0x0403AA25 RID: 240165
			Layout,
			// Token: 0x0403AA26 RID: 240166
			LayoutItem
		}
	}
}
