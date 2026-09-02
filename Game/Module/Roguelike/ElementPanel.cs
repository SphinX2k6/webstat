using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200514F RID: 20815
	[NullableContext(1)]
	[Nullable(0)]
	public class ElementPanel : UiPanelBase
	{
		// Token: 0x06035931 RID: 219441 RVA: 0x00D739AC File Offset: 0x00D71BAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.AreaToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.TipToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.BtnMask));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035932 RID: 219442 RVA: 0x00D73B40 File Offset: 0x00D71D40
		protected override UniTask OnBeforeStartAsync()
		{
			ElementPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ElementPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035933 RID: 219443 RVA: 0x00D73B84 File Offset: 0x00D71D84
		protected override void OnStart()
		{
			this.ElementLayout = new GenericLayout<ElementItem, ElementInfo>(base.GetHorizontalLayout(2), new Func<ElementItem>(this.CreateElementItem), null, false, true);
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x06035934 RID: 219444 RVA: 0x00D73BD0 File Offset: 0x00D71DD0
		private ElementItem CreateElementItem()
		{
			return new ElementItem();
		}

		// Token: 0x06035935 RID: 219445 RVA: 0x00D73BD8 File Offset: 0x00D71DD8
		private void AreaToggle(EToggleState state)
		{
			if (state != EToggleState.ETT_UnChecked)
			{
				if (state == EToggleState.ETT_Checked)
				{
					base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
					base.GetItem(4).SetUIActive(true);
					return;
				}
			}
			else
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				base.GetItem(4).SetUIActive(false);
			}
		}

		// Token: 0x06035936 RID: 219446 RVA: 0x00D73C2C File Offset: 0x00D71E2C
		private void TipToggle(EToggleState state)
		{
			if (state != EToggleState.ETT_UnChecked)
			{
				if (state == EToggleState.ETT_Checked)
				{
					base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_Checked, false, false, false);
					base.GetItem(4).SetUIActive(true);
					return;
				}
			}
			else
			{
				base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				base.GetItem(4).SetUIActive(false);
			}
		}

		// Token: 0x06035937 RID: 219447 RVA: 0x00D73C7D File Offset: 0x00D71E7D
		private void BtnMask()
		{
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x06035938 RID: 219448 RVA: 0x00D73C90 File Offset: 0x00D71E90
		public void Refresh(List<ElementInfo> elementInfoList)
		{
			this.RefreshInternal(elementInfoList, false);
		}

		// Token: 0x06035939 RID: 219449 RVA: 0x00D73C9C File Offset: 0x00D71E9C
		[NullableContext(2)]
		public void Refresh(RogueGainEntry rogueGainEntry = null)
		{
			List<ElementInfo> list = new List<ElementInfo>();
			Dictionary<EElementType, ElementInfo> item = ModelBase<RoguelikeModel>.Instance.GetSortElementInfoArrayMap((rogueGainEntry != null) ? rogueGainEntry.ElementDict : null).Item2;
			foreach (int num in ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null).Value.ElementList())
			{
				ElementInfo item2;
				if (!item.TryGetValue((EElementType)num, out item2))
				{
					item2 = new ElementInfo(num, 0, null);
				}
				list.Add(item2);
			}
			bool isPreview = rogueGainEntry != null && rogueGainEntry.ElementDict.Count > 0;
			this.RefreshInternal(list, isPreview);
		}

		// Token: 0x0603593A RID: 219450 RVA: 0x00D73D48 File Offset: 0x00D71F48
		private void RefreshInternal(List<ElementInfo> elementInfoArray, bool isPreview)
		{
			this.ElementLayout.RefreshByData(elementInfoArray, null, false);
			int num = 0;
			foreach (ElementInfo elementInfo in elementInfoArray)
			{
				if (elementInfo.ElementId != 7)
				{
					num += elementInfo.Count;
				}
			}
			if (!isPreview)
			{
				base.GetText(1).SetText(num.ToString(), true);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RoguelikeView_17_Text", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
			}
			this.TipPanel.UpdateNum(num);
		}

		// Token: 0x0401EC69 RID: 126057
		private TipPanel TipPanel;

		// Token: 0x0401EC6A RID: 126058
		private GenericLayout<ElementItem, ElementInfo> ElementLayout;

		// Token: 0x0200B0F0 RID: 45296
		[NullableContext(0)]
		private class EElementPanelCom
		{
			// Token: 0x04036E22 RID: 224802
			public const int TipToggle = 0;

			// Token: 0x04036E23 RID: 224803
			public const int TotalNumText = 1;

			// Token: 0x04036E24 RID: 224804
			public const int ElementsLayout = 2;

			// Token: 0x04036E25 RID: 224805
			public const int ElementItem = 3;

			// Token: 0x04036E26 RID: 224806
			public const int TipItem = 4;

			// Token: 0x04036E27 RID: 224807
			public const int AreaToggle = 5;

			// Token: 0x04036E28 RID: 224808
			public const int BtnMask = 6;
		}
	}
}
