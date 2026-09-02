using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059ED RID: 23021
	public class ManufactureHelpRoleView : UiViewBase
	{
		// Token: 0x0603A529 RID: 238889 RVA: 0x00EC975E File Offset: 0x00EC795E
		[NullableContext(1)]
		public ManufactureHelpRoleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A52A RID: 238890 RVA: 0x00EC9768 File Offset: 0x00EC7968
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A52B RID: 238891 RVA: 0x00EC9850 File Offset: 0x00EC7A50
		protected override void OnBeforeDestroy()
		{
			if (this.RoleItemScrollView != null)
			{
				this.RoleItemScrollView.ClearGridProxies();
				this.RoleItemScrollView = null;
			}
		}

		// Token: 0x0603A52C RID: 238892 RVA: 0x00EC986C File Offset: 0x00EC7A6C
		protected override void OnStart()
		{
			this.RoleItemScrollView = new LoopScrollView<ManufactureHelpRoleView.HelpRoleItem, ICommonRoleItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<ManufactureHelpRoleView.HelpRoleItem>(this.OnGridProxyCreate), false);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "ComposeSelectRoleButtonText", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit<EViewType>(EEventName.SwitchViewType, EViewType.RoleViewType);
			this.ItemId = (int)this.OpenParam;
			this.CurrentSelectedRoleId = Singleton<CommonManager>.Instance.GetCurrentRoleId().Value;
			this.RefreshHelpRoleScroll();
		}

		// Token: 0x0603A52D RID: 238893 RVA: 0x00EC9904 File Offset: 0x00EC7B04
		protected override void OnBeforeShow()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			CommonPopViewBase popItem = childPopView.PopItem;
			if (popItem == null)
			{
				return;
			}
			popItem.SetTexBgVisible(false);
		}

		// Token: 0x0603A52E RID: 238894 RVA: 0x00EC9921 File Offset: 0x00EC7B21
		[NullableContext(1)]
		private ManufactureHelpRoleView.HelpRoleItem OnGridProxyCreate()
		{
			ManufactureHelpRoleView.HelpRoleItem helpRoleItem = new ManufactureHelpRoleView.HelpRoleItem();
			helpRoleItem.BindOnClickedCallback(new Action<int>(this.RefreshConfirm));
			return helpRoleItem;
		}

		// Token: 0x0603A52F RID: 238895 RVA: 0x00EC993A File Offset: 0x00EC7B3A
		private void RefreshHelpRoleScroll()
		{
			this.RoleItemDataList = Singleton<CommonManager>.Instance.GetHelpRoleItemDataList(this.ItemId);
			this.RoleItemScrollView.ReloadData(this.RoleItemDataList, false);
			this.SetSelectedRoleItem();
		}

		// Token: 0x0603A530 RID: 238896 RVA: 0x00EC996C File Offset: 0x00EC7B6C
		private void SetSelectedRoleItem()
		{
			int num = 0;
			this.RoleItemScrollView.DeselectCurrentGridProxy(false);
			while (num < this.RoleItemDataList.Count && this.CurrentSelectedRoleId != this.RoleItemDataList[num].RoleId)
			{
				num++;
			}
			this.RoleItemScrollView.ScrollToGridIndex(num, true);
			this.RoleItemScrollView.SelectGridProxy(num, false);
		}

		// Token: 0x0603A531 RID: 238897 RVA: 0x00EC99D0 File Offset: 0x00EC7BD0
		private void RefreshConfirm(int roleId)
		{
			this.CurrentSelectedRoleId = roleId;
			int num = 0;
			this.RoleItemScrollView.DeselectCurrentGridProxy(false);
			while (num < this.RoleItemDataList.Count && roleId != this.RoleItemDataList[num].RoleId)
			{
				num++;
			}
			if (!this.RoleItemScrollView.IsGridDisplaying(num))
			{
				return;
			}
			this.RoleItemScrollView.SelectGridProxy(num, false);
			this.RoleItemScrollView.RefreshGridProxy(num);
		}

		// Token: 0x0603A532 RID: 238898 RVA: 0x00EC9A42 File Offset: 0x00EC7C42
		private void OnConfirm()
		{
			Singleton<CommonManager>.Instance.SetCurrentRoleId(this.CurrentSelectedRoleId);
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ManufactureHelpRoleView, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.CloseHelpRole);
		}

		// Token: 0x04021099 RID: 135321
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<ManufactureHelpRoleView.HelpRoleItem, ICommonRoleItemData> RoleItemScrollView;

		// Token: 0x0402109A RID: 135322
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICommonRoleItemData> RoleItemDataList;

		// Token: 0x0402109B RID: 135323
		private int ItemId;

		// Token: 0x0402109C RID: 135324
		private int CurrentSelectedRoleId;

		// Token: 0x0200B9BA RID: 47546
		private class EHelpRoleDefine
		{
			// Token: 0x04039641 RID: 235073
			public const int HelpRoleLoopScroll = 0;

			// Token: 0x04039642 RID: 235074
			public const int HelpRoleItem = 1;

			// Token: 0x04039643 RID: 235075
			public const int ConfirmButton = 2;

			// Token: 0x04039644 RID: 235076
			public const int TxtConfirm = 3;
		}

		// Token: 0x0200B9BB RID: 47547
		[NullableContext(2)]
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public class HelpRoleItem : GridProxyAbstract<ICommonRoleItemData>
		{
			// Token: 0x0604D6B3 RID: 317107 RVA: 0x0155F318 File Offset: 0x0155D518
			protected unsafe override void OnRegisterComponent()
			{
				int num = 4;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				num2 = 1;
				List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
				Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
				num = 0;
				*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick));
				this.BtnBindInfo = list2;
			}

			// Token: 0x0604D6B4 RID: 317108 RVA: 0x0155F400 File Offset: 0x0155D600
			protected override void OnStart()
			{
				this.ItemGrid = new SmallItemGrid();
				this.ItemGrid.Initialize(base.GetItem(3).GetOwner());
			}

			// Token: 0x0604D6B5 RID: 317109 RVA: 0x0155F424 File Offset: 0x0155D624
			[NullableContext(1)]
			public override void Refresh(ICommonRoleItemData data, bool isSelected, int gridIndex)
			{
				this.ItemData = data;
				CharacterSmallItemGrid characterSmallItemGrid = new CharacterSmallItemGrid();
				characterSmallItemGrid.Data = data;
				characterSmallItemGrid.ItemConfigId = new int?(data.RoleId);
				characterSmallItemGrid.IsCookUp = new bool?(data.IsBuff);
				int? currentCookRoleId = ModelBase<CookModel>.Instance.CurrentCookRoleId;
				int roleId = data.RoleId;
				characterSmallItemGrid.IsReceivedVisible = new bool?(currentCookRoleId.GetValueOrDefault() == roleId & currentCookRoleId != null);
				CharacterSmallItemGrid parameters = characterSmallItemGrid;
				this.ItemGrid.Apply<CharacterSmallItemGrid>(parameters);
				this.SetName();
				this.SetInfoText();
				this.Selected(isSelected, false);
				base.GetText(2).OnSelfLanguageChange.Bind(new Action(this.SetInfoText));
			}

			// Token: 0x0604D6B6 RID: 317110 RVA: 0x0155F4D3 File Offset: 0x0155D6D3
			public override void Clear()
			{
				base.GetText(2).OnSelfLanguageChange.Unbind();
			}

			// Token: 0x0604D6B7 RID: 317111 RVA: 0x0155F4E6 File Offset: 0x0155D6E6
			protected override void OnBeforeDestroy()
			{
				this.ItemGrid = null;
			}

			// Token: 0x0604D6B8 RID: 317112 RVA: 0x0155F4EF File Offset: 0x0155D6EF
			private void SetName()
			{
				base.GetText(1).SetText(this.ItemData.RoleName, true);
			}

			// Token: 0x0604D6B9 RID: 317113 RVA: 0x0155F50C File Offset: 0x0155D70C
			private void SetInfoText()
			{
				if (Singleton<CommonManager>.Instance.CheckIsBuff(this.ItemData.RoleId, this.ItemData.ItemId))
				{
					string infoText = Singleton<CommonManager>.Instance.GetInfoText(this.ItemData.RoleId);
					base.GetText(2).SetText(infoText, true);
					return;
				}
				string textById = ConfigBase<TextConfig>.Instance.GetTextById(Singleton<CommonManager>.Instance.GetDefaultRoleText());
				base.GetText(2).SetText(textById, true);
			}

			// Token: 0x0604D6BA RID: 317114 RVA: 0x0155F583 File Offset: 0x0155D783
			[NullableContext(1)]
			public void BindOnClickedCallback(Action<int> onItemButtonClicked)
			{
				this.OnClickedCallback = onItemButtonClicked;
			}

			// Token: 0x0604D6BB RID: 317115 RVA: 0x0155F58C File Offset: 0x0155D78C
			public override void OnSelected(bool fireEvent)
			{
				this.Selected(true, true);
			}

			// Token: 0x0604D6BC RID: 317116 RVA: 0x0155F596 File Offset: 0x0155D796
			public override void OnDeselected(bool fireEvent)
			{
				this.Selected(false, true);
			}

			// Token: 0x0604D6BD RID: 317117 RVA: 0x0155F5A0 File Offset: 0x0155D7A0
			private void Selected(bool bSelected, bool fireEvent = true)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (bSelected)
				{
					extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}

			// Token: 0x0604D6BE RID: 317118 RVA: 0x0155F5CF File Offset: 0x0155D7CF
			private void OnClick(EToggleState state)
			{
				if (this.OnClickedCallback != null)
				{
					this.OnClickedCallback(this.ItemData.RoleId);
				}
			}

			// Token: 0x04039645 RID: 235077
			private ICommonRoleItemData ItemData;

			// Token: 0x04039646 RID: 235078
			private SmallItemGrid ItemGrid;

			// Token: 0x04039647 RID: 235079
			private Action<int> OnClickedCallback;

			// Token: 0x0200CF3B RID: 53051
			[NullableContext(0)]
			private class EHelpRoleItemDefine
			{
				// Token: 0x0403FD70 RID: 261488
				public const int HelpRoleExtendToggle = 0;

				// Token: 0x0403FD71 RID: 261489
				public const int RoleNameText = 1;

				// Token: 0x0403FD72 RID: 261490
				public const int CommonInfoText = 2;

				// Token: 0x0403FD73 RID: 261491
				public const int ItemGridItem = 3;
			}
		}
	}
}
