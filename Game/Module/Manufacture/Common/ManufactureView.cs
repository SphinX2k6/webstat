using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059EE RID: 23022
	[NullableContext(1)]
	[Nullable(0)]
	public class ManufactureView : UiNavigationView
	{
		// Token: 0x0603A533 RID: 238899 RVA: 0x00EC9A74 File Offset: 0x00EC7C74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnDisable));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A534 RID: 238900 RVA: 0x00EC9BE4 File Offset: 0x00EC7DE4
		protected override void OnStart()
		{
			this.OpenHelpRoleButton = new OpenHelpRoleButton(base.GetItem(4));
			this.OpenHelpRoleButton.BindOnCallback(new Action(this.OpenHelpRoleView));
			this.MaterialHorizontal = new GenericLayoutNew<MaterialItem>(base.GetHorizontalLayout(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MaterialItem>(this.InitMaterial), null);
			if (Singleton<CommonManager>.Instance.CheckShowAmountItem().GetValueOrDefault())
			{
				base.GetItem(5).SetUIActive(true);
				this.AmountItem = new AmountItem(base.GetItem(5));
				this.AmountItem.BindGetMaxCallback(new Func<int>(this.GetMaxCount));
				this.AmountItem.BindSetSumCallback(new Action<int>(this.SetSum));
			}
			else
			{
				base.GetItem(5).SetUIActive(false);
			}
			this.IconItem = new IconItem(base.GetItem(1));
		}

		// Token: 0x0603A535 RID: 238901 RVA: 0x00EC9CBC File Offset: 0x00EC7EBC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<MaterialItem> InitMaterial([Nullable(2)] object data, UUIItem uiItem, int index)
		{
			ISingleItemInfo singleItemInfo = data as ISingleItemInfo;
			if (singleItemInfo == null)
			{
				return null;
			}
			MaterialItem materialItem = new MaterialItem(uiItem);
			materialItem.Update(singleItemInfo);
			materialItem.BindOnClickedCallback(new Action<ISingleItemInfo>(this.OnClickMaterial));
			return new LayoutItem<MaterialItem>
			{
				Key = index,
				Value = materialItem
			};
		}

		// Token: 0x0603A536 RID: 238902 RVA: 0x00EC9D0D File Offset: 0x00EC7F0D
		private int GetMaxCount()
		{
			return Singleton<CommonManager>.Instance.GetMaxCreateCount(this.ItemId);
		}

		// Token: 0x0603A537 RID: 238903 RVA: 0x00EC9D1F File Offset: 0x00EC7F1F
		private void SetSum(int sum)
		{
			this.Count = sum;
			this.RefreshMaterialNeedNum();
		}

		// Token: 0x0603A538 RID: 238904 RVA: 0x00EC9D2E File Offset: 0x00EC7F2E
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
			this.MaterialHorizontal.ClearChildren();
			this.MaterialHorizontal = null;
			this.AmountItem = null;
		}

		// Token: 0x0603A539 RID: 238905 RVA: 0x00EC9D50 File Offset: 0x00EC7F50
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeSuccess, new Action(this.OnComposeOpenRewardPopView));
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeSuccess, new Action(this.Refresh));
			Singleton<EventSystem>.Instance.Add(EEventName.ForgingSuccess, new Action(this.OnForgingOpenRewardPopView));
			Singleton<EventSystem>.Instance.Add(EEventName.ForgingSuccess, new Action(this.Refresh));
			Singleton<EventSystem>.Instance.Add(EEventName.CloseHelpRole, new Action(this.RefreshCurrentRole));
		}

		// Token: 0x0603A53A RID: 238906 RVA: 0x00EC9DEC File Offset: 0x00EC7FEC
		private void RemoveEventListener()
		{
			if (!this.IsFirstShow)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ComposeSuccess, new Action(this.OnComposeOpenRewardPopView));
				Singleton<EventSystem>.Instance.Remove(EEventName.ComposeSuccess, new Action(this.Refresh));
				Singleton<EventSystem>.Instance.Remove(EEventName.ForgingSuccess, new Action(this.OnForgingOpenRewardPopView));
				Singleton<EventSystem>.Instance.Remove(EEventName.ForgingSuccess, new Action(this.Refresh));
				Singleton<EventSystem>.Instance.Remove(EEventName.CloseHelpRole, new Action(this.RefreshCurrentRole));
			}
		}

		// Token: 0x0603A53B RID: 238907 RVA: 0x00EC9E90 File Offset: 0x00EC8090
		public void HideView(bool isHide)
		{
			this.SetActive(!isHide);
			if (!isHide)
			{
				Singleton<EventSystem>.Instance.Emit<EViewType>(EEventName.SwitchViewType, EViewType.ManufactureViewType);
			}
		}

		// Token: 0x0603A53C RID: 238908 RVA: 0x00EC9EB0 File Offset: 0x00EC80B0
		public void ShowView(int itemId)
		{
			Singleton<EventSystem>.Instance.Emit<EViewType>(EEventName.SwitchViewType, EViewType.ManufactureViewType);
			this.SetActive(true);
			if (this.IsFirstShow)
			{
				this.AddEventListener();
				this.IsFirstShow = false;
			}
			this.ItemId = itemId;
			this.Refresh();
		}

		// Token: 0x0603A53D RID: 238909 RVA: 0x00EC9EEC File Offset: 0x00EC80EC
		private void Refresh()
		{
			if (!base.GetActive())
			{
				return;
			}
			Singleton<CommonManager>.Instance.SetCurrentRoleId(Singleton<CommonManager>.Instance.GetManufactureRoleId(this.ItemId).Value);
			this.Count = 1;
			this.RefreshText();
			this.RefreshItemIcon();
			this.RefreshOpenRoleButton();
			this.RefreshMaterialList();
			this.RefreshConfirmButton();
			this.RefreshAmountItem();
		}

		// Token: 0x0603A53E RID: 238910 RVA: 0x00EC9F50 File Offset: 0x00EC8150
		private void RefreshText()
		{
			string commonManufactureText = Singleton<CommonManager>.Instance.GetCommonManufactureText(this.ItemId);
			base.GetText(0).SetText(commonManufactureText, true);
		}

		// Token: 0x0603A53F RID: 238911 RVA: 0x00EC9F7C File Offset: 0x00EC817C
		private void RefreshItemIcon()
		{
			int value = Singleton<CommonManager>.Instance.GetCommonManufactureId(this.ItemId).Value;
			this.IconItem.SetIcon(value);
			this.IconItem.SetQuality(value);
		}

		// Token: 0x0603A540 RID: 238912 RVA: 0x00EC9FBC File Offset: 0x00EC81BC
		private void RefreshOpenRoleButton()
		{
			if (Singleton<CommonManager>.Instance.CheckShowRoleView().GetValueOrDefault())
			{
				this.OpenHelpRoleButton.SetActive(true);
				this.OpenHelpRoleButton.RefreshIcon();
				this.OpenHelpRoleButton.RefreshRedDot(this.ItemId);
				return;
			}
			this.OpenHelpRoleButton.SetActive(false);
		}

		// Token: 0x0603A541 RID: 238913 RVA: 0x00ECA012 File Offset: 0x00EC8212
		private void RefreshCurrentRole()
		{
			this.RefreshOpenRoleButton();
		}

		// Token: 0x0603A542 RID: 238914 RVA: 0x00ECA01C File Offset: 0x00EC821C
		private void RefreshMaterialList()
		{
			this.MaterialHorizontal.RebuildLayoutByDataNew<ISingleItemInfo>(Singleton<CommonManager>.Instance.GetManufactureMaterialList(this.ItemId), null);
		}

		// Token: 0x0603A543 RID: 238915 RVA: 0x00ECA050 File Offset: 0x00EC8250
		private void RefreshMaterialNeedNum()
		{
			foreach (MaterialItem materialItem in this.MaterialHorizontal.GetLayoutItemMap().Values)
			{
				materialItem.RefreshNeed(this.Count);
			}
		}

		// Token: 0x0603A544 RID: 238916 RVA: 0x00ECA0B0 File Offset: 0x00EC82B0
		private void RefreshConfirmButton()
		{
			UUIInteractionGroup uuiinteractionGroup = (base.GetButton(3).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup;
			AUIBaseActor auibaseActor = base.GetButton(6).GetOwner() as AUIBaseActor;
			bool valueOrDefault = Singleton<CommonManager>.Instance.CheckCanManufacture(this.ItemId).GetValueOrDefault();
			uuiinteractionGroup.SetInteractable(valueOrDefault);
			auibaseActor.GetUIItem().SetUIActive(!valueOrDefault);
		}

		// Token: 0x0603A545 RID: 238917 RVA: 0x00ECA122 File Offset: 0x00EC8322
		private void RefreshAmountItem()
		{
			if (this.AmountItem == null)
			{
				return;
			}
			this.AmountItem.ResetSum();
			this.AmountItem.RefreshAddAndDelButton();
		}

		// Token: 0x0603A546 RID: 238918 RVA: 0x00ECA143 File Offset: 0x00EC8343
		private void OpenHelpRoleView()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenHelpRole, this.ItemId);
		}

		// Token: 0x0603A547 RID: 238919 RVA: 0x00ECA15B File Offset: 0x00EC835B
		private void OnConfirm()
		{
			Singleton<CommonManager>.Instance.SendManufacture(this.ItemId, this.Count);
		}

		// Token: 0x0603A548 RID: 238920 RVA: 0x00ECA173 File Offset: 0x00EC8373
		private void OnDisable()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MaterialShort", Array.Empty<object>());
		}

		// Token: 0x0603A549 RID: 238921 RVA: 0x00ECA189 File Offset: 0x00EC8389
		private void OnClickMaterial(ISingleItemInfo itemData)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemData.Proto_ItemId, true, null);
		}

		// Token: 0x0603A54A RID: 238922 RVA: 0x00ECA19D File Offset: 0x00EC839D
		private void OnForgingOpenRewardPopView()
		{
		}

		// Token: 0x0603A54B RID: 238923 RVA: 0x00ECA19F File Offset: 0x00EC839F
		private void OnComposeOpenRewardPopView()
		{
		}

		// Token: 0x0603A54C RID: 238924 RVA: 0x00ECA1A4 File Offset: 0x00EC83A4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			UUIItem guideUiItem = base.GetGuideUiItem(configParams[1]);
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}

		// Token: 0x0402109D RID: 135325
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<MaterialItem> MaterialHorizontal;

		// Token: 0x0402109E RID: 135326
		[Nullable(2)]
		private OpenHelpRoleButton OpenHelpRoleButton;

		// Token: 0x0402109F RID: 135327
		[Nullable(2)]
		private AmountItem AmountItem;

		// Token: 0x040210A0 RID: 135328
		[Nullable(2)]
		private IconItem IconItem;

		// Token: 0x040210A1 RID: 135329
		private bool IsFirstShow = true;

		// Token: 0x040210A2 RID: 135330
		private int ItemId;

		// Token: 0x040210A3 RID: 135331
		private int Count = 1;

		// Token: 0x0200B9BC RID: 47548
		[NullableContext(0)]
		private class EManufactureViewDefine
		{
			// Token: 0x04039648 RID: 235080
			public const int ManufactureNameText = 0;

			// Token: 0x04039649 RID: 235081
			public const int ManufactureIconItem = 1;

			// Token: 0x0403964A RID: 235082
			public const int ManufactureMaterialHorizontalLayout = 2;

			// Token: 0x0403964B RID: 235083
			public const int ManufactureConfirmButton = 3;

			// Token: 0x0403964C RID: 235084
			public const int ManufactureRoleItem = 4;

			// Token: 0x0403964D RID: 235085
			public const int AmountItem = 5;

			// Token: 0x0403964E RID: 235086
			public const int ManufactureDefaultButton = 6;
		}
	}
}
