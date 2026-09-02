using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.Consume
{
	// Token: 0x02005E83 RID: 24195
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonConditionFilterComponent : UiNavigationView
	{
		// Token: 0x0603CD97 RID: 249239 RVA: 0x00F71F95 File Offset: 0x00F70195
		public CommonConditionFilterComponent(UUIItem uiItem, TCommonConditionFilterFunction conditionFunction)
		{
			this.ConditionFunction = conditionFunction;
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CD98 RID: 249240 RVA: 0x00F71FB4 File Offset: 0x00F701B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.MaskClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CD99 RID: 249241 RVA: 0x00F7207C File Offset: 0x00F7027C
		private void MaskClick()
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("CommonConditionFilterComponent", true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("hide", false, null, false);
		}

		// Token: 0x0603CD9A RID: 249242 RVA: 0x00F720B4 File Offset: 0x00F702B4
		protected override void OnStart()
		{
			this.Layout = new GenericLayoutNew<CommonConditionFilterItem>(base.GetVerticalLayout(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonConditionFilterItem>(this.InitItem), null);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceFinishEvent), false);
		}

		// Token: 0x0603CD9B RID: 249243 RVA: 0x00F7210C File Offset: 0x00F7030C
		public void RefreshQualityList(IReadOnlyList<QualityInfo> data)
		{
			this.Layout.RebuildLayoutByDataNew<QualityInfo>(data.ToArray<QualityInfo>(), null);
			this.Layout.GetLayoutItemByKey(0).SetToggleState(true, true);
		}

		// Token: 0x0603CD9C RID: 249244 RVA: 0x00F7214B File Offset: 0x00F7034B
		private void SequenceFinishEvent(string sequenceName)
		{
			if (sequenceName == "hide")
			{
				this.SetActive(false);
				Singleton<UiLayer>.Instance.SetShowMaskLayer("CommonConditionFilterComponent", false);
			}
		}

		// Token: 0x0603CD9D RID: 249245 RVA: 0x00F72174 File Offset: 0x00F70374
		private ILayoutItem<CommonConditionFilterItem> InitItem(object qualityInfo, UUIItem uiItem, int index)
		{
			CommonConditionFilterItem commonConditionFilterItem = new CommonConditionFilterItem(uiItem, (QualityInfo)qualityInfo);
			commonConditionFilterItem.SetToggleFunction(new TCommonConditionFilterItemFunction(this.ToggleFunction));
			return new LayoutItem<CommonConditionFilterItem>
			{
				Key = index,
				Value = commonConditionFilterItem
			};
		}

		// Token: 0x0603CD9E RID: 249246 RVA: 0x00F721B8 File Offset: 0x00F703B8
		private void ToggleFunction(int qualityId, string text)
		{
			this.ResetComponent();
			this.SetActive(false);
			if (this.ConditionFunction != null)
			{
				this.ConditionFunction(qualityId, text);
			}
		}

		// Token: 0x0603CD9F RID: 249247 RVA: 0x00F721DC File Offset: 0x00F703DC
		protected void ResetComponent()
		{
			foreach (CommonConditionFilterItem commonConditionFilterItem in this.Layout.GetLayoutItemMap().Values)
			{
				commonConditionFilterItem.SetToggleState(false, false);
			}
		}

		// Token: 0x0603CDA0 RID: 249248 RVA: 0x00F72238 File Offset: 0x00F70438
		protected override void OnBeforeDestroy()
		{
			if (this.Layout != null)
			{
				this.Layout.ClearChildren();
				this.Layout = null;
			}
		}

		// Token: 0x0603CDA1 RID: 249249 RVA: 0x00F72254 File Offset: 0x00F70454
		public void UpdateComponent(int qualityId)
		{
			this.SetActive(true);
			foreach (CommonConditionFilterItem commonConditionFilterItem in this.Layout.GetLayoutItemMap().Values)
			{
				if (commonConditionFilterItem.GetQualityInfo().Id == qualityId)
				{
					commonConditionFilterItem.SetToggleState(true, false);
				}
			}
			this.LevelSequencePlayer.PlayLevelSequenceByName("show", false, null, false);
		}

		// Token: 0x04022297 RID: 139927
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayoutNew<CommonConditionFilterItem> Layout;

		// Token: 0x04022298 RID: 139928
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022299 RID: 139929
		protected TCommonConditionFilterFunction ConditionFunction;

		// Token: 0x0200BE8E RID: 48782
		[NullableContext(0)]
		private class ECommonConditionFilterComponent
		{
			// Token: 0x0403AAAA RID: 240298
			public const int MaskButton = 0;

			// Token: 0x0403AAAB RID: 240299
			public const int ConditionViewItem = 1;

			// Token: 0x0403AAAC RID: 240300
			public const int Layout = 2;
		}
	}
}
