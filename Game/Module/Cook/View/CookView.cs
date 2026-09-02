using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E2A RID: 24106
	[NullableContext(1)]
	[Nullable(0)]
	public class CookView : UiNavigationView
	{
		// Token: 0x0603CAA2 RID: 248482 RVA: 0x00F687C4 File Offset: 0x00F669C4
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
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(delegate()
			{
				this.OnConfirm();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(delegate()
			{
				this.OnDisableCook();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CAA3 RID: 248483 RVA: 0x00F68934 File Offset: 0x00F66B34
		protected override void OnStart()
		{
			this.OpenCookRoleButton = new OpenCookRoleButton(base.GetItem(4));
			this.OpenCookRoleButton.BindOnCallback(new Action(this.OpenCookRoleView));
			this.MaterialHorizontal = new GenericLayoutNew<MaterialItem>(base.GetHorizontalLayout(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MaterialItem>(this.InitMaterial), null);
			this.AmountItem = new AmountItem(base.GetItem(5));
			this.AmountItem.BindGetMaxCallback(new Func<int>(this.GetMaxCount));
			this.AmountItem.BindSetSumCallback(new Action<int>(this.SetSum));
			this.IconItem = new IconItem(base.GetItem(1));
		}

		// Token: 0x0603CAA4 RID: 248484 RVA: 0x00F689DC File Offset: 0x00F66BDC
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
			materialItem.Update(singleItemInfo, index);
			materialItem.BindOnClickedCallback(new Action<ISingleItemInfo, int>(this.OnClickMaterial));
			return new LayoutItem<MaterialItem>
			{
				Key = index,
				Value = materialItem
			};
		}

		// Token: 0x0603CAA5 RID: 248485 RVA: 0x00F68A2E File Offset: 0x00F66C2E
		private int GetMaxCount()
		{
			return ControllerBase<CookController>.Instance.GetMaxCreateCount(this.ItemId, ModelBase<CookModel>.Instance.CurrentCookListType);
		}

		// Token: 0x0603CAA6 RID: 248486 RVA: 0x00F68A4A File Offset: 0x00F66C4A
		private void SetSum(int sum)
		{
			this.Count = sum;
			this.RefreshMaterialNeedNum();
		}

		// Token: 0x0603CAA7 RID: 248487 RVA: 0x00F68A59 File Offset: 0x00F66C59
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
			this.MaterialHorizontal.ClearChildren();
			this.MaterialHorizontal = null;
			this.AmountItem = null;
		}

		// Token: 0x0603CAA8 RID: 248488 RVA: 0x00F68A7C File Offset: 0x00F66C7C
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.CookSuccess, new Action(this.OnCookSuccess));
			Singleton<EventSystem>.Instance.Add(EEventName.MachiningSuccess, new Action(this.OnOpenMachiningCookPopView));
			Singleton<EventSystem>.Instance.Add(EEventName.MachiningSuccess, new Action(this.Refresh));
			Singleton<EventSystem>.Instance.Add(EEventName.CloseCookRole, new Action(this.RefreshCurrentCookRole));
		}

		// Token: 0x0603CAA9 RID: 248489 RVA: 0x00F68AFC File Offset: 0x00F66CFC
		private void RemoveEventListener()
		{
			if (!this.IsFirstShow)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.CookSuccess, new Action(this.OnCookSuccess));
				Singleton<EventSystem>.Instance.Remove(EEventName.MachiningSuccess, new Action(this.OnOpenMachiningCookPopView));
				Singleton<EventSystem>.Instance.Remove(EEventName.MachiningSuccess, new Action(this.Refresh));
				Singleton<EventSystem>.Instance.Remove(EEventName.CloseCookRole, new Action(this.RefreshCurrentCookRole));
			}
		}

		// Token: 0x0603CAAA RID: 248490 RVA: 0x00F68B81 File Offset: 0x00F66D81
		public void HideView(bool isHide)
		{
			this.SetActive(!isHide);
			if (!isHide)
			{
				ModelBase<CookModel>.Instance.CurrentCookViewType = ECookDataType.Cook;
			}
		}

		// Token: 0x0603CAAB RID: 248491 RVA: 0x00F68B9B File Offset: 0x00F66D9B
		public void ShowView(int itemId)
		{
			ModelBase<CookModel>.Instance.CurrentCookViewType = ECookDataType.Cook;
			this.SetActive(true);
			if (this.IsFirstShow)
			{
				this.AddEventListener();
				this.IsFirstShow = false;
			}
			this.ItemId = itemId;
			this.Refresh();
		}

		// Token: 0x0603CAAC RID: 248492 RVA: 0x00F68BD4 File Offset: 0x00F66DD4
		private void Refresh()
		{
			if (!base.GetActive())
			{
				return;
			}
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				this.RoleId = ModelBase<CookModel>.Instance.GetCookRoleId(this.ItemId);
				ModelBase<CookModel>.Instance.CurrentCookRoleId = new int?(this.RoleId);
				this.CookFormula = new CookFormula?(ConfigBase<CookConfig>.Instance.GetCookFormulaById(this.ItemId));
			}
			else
			{
				this.CookProcessed = new CookProcessed?(ConfigBase<CookConfig>.Instance.GetCookProcessedById(this.ItemId));
			}
			this.Count = 1;
			this.RefreshText();
			this.RefreshItemIcon();
			this.RefreshOpenCookRoleButton();
			this.RefreshMaterialList();
			this.RefreshConfirmButton();
			this.RefreshAmountItem();
		}

		// Token: 0x0603CAAD RID: 248493 RVA: 0x00F68C84 File Offset: 0x00F66E84
		private void RefreshText()
		{
			string name;
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				name = this.CookFormula.Value.Name;
				base.GetText(0).ShowTextNew(name);
				return;
			}
			name = this.CookProcessed.Value.Name;
			base.GetText(0).ShowTextNew(name);
		}

		// Token: 0x0603CAAE RID: 248494 RVA: 0x00F68CE4 File Offset: 0x00F66EE4
		private void RefreshItemIcon()
		{
			int? num = null;
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				num = new int?(this.CookFormula.Value.FoodItemId);
			}
			else
			{
				num = new int?(this.CookProcessed.Value.FinalItemId);
			}
			this.IconItem.SetIcon(num.Value);
			this.IconItem.SetQuality(num.Value);
		}

		// Token: 0x0603CAAF RID: 248495 RVA: 0x00F68D60 File Offset: 0x00F66F60
		private void RefreshOpenCookRoleButton()
		{
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				this.OpenCookRoleButton.SetActive(true);
				this.OpenCookRoleButton.RefreshIcon(this.RoleId);
				this.OpenCookRoleButton.RefreshRedDot(this.RoleId, this.ItemId);
				return;
			}
			this.OpenCookRoleButton.SetActive(false);
		}

		// Token: 0x0603CAB0 RID: 248496 RVA: 0x00F68DBC File Offset: 0x00F66FBC
		private void RefreshCurrentCookRole()
		{
			this.RoleId = ModelBase<CookModel>.Instance.CurrentCookRoleId.Value;
			this.RefreshOpenCookRoleButton();
		}

		// Token: 0x0603CAB1 RID: 248497 RVA: 0x00F68DE8 File Offset: 0x00F66FE8
		private void RefreshMaterialList()
		{
			List<ISingleItemInfo> cookMaterialList = ModelBase<CookModel>.Instance.GetCookMaterialList(this.ItemId, ModelBase<CookModel>.Instance.CurrentCookListType);
			this.MaterialHorizontal.RebuildLayoutByDataNew<ISingleItemInfo>(cookMaterialList, null);
		}

		// Token: 0x0603CAB2 RID: 248498 RVA: 0x00F68E28 File Offset: 0x00F67028
		private void RefreshMaterialNeedNum()
		{
			foreach (MaterialItem materialItem in this.MaterialHorizontal.GetLayoutItemMap().Values)
			{
				materialItem.RefreshNeed(this.Count);
			}
		}

		// Token: 0x0603CAB3 RID: 248499 RVA: 0x00F68E88 File Offset: 0x00F67088
		private void RefreshConfirmButton()
		{
			UUIInteractionGroup uuiinteractionGroup = (base.GetButton(3).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup;
			AUIBaseActor auibaseActor = base.GetButton(6).GetOwner() as AUIBaseActor;
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				bool flag = ControllerBase<CookController>.Instance.CheckCanCook(this.ItemId);
				uuiinteractionGroup.SetInteractable(flag);
				auibaseActor.GetUIItem().SetUIActive(!flag);
				return;
			}
			bool flag2 = ControllerBase<CookController>.Instance.CheckCanProcessed(this.ItemId);
			uuiinteractionGroup.SetInteractable(flag2);
			auibaseActor.GetUIItem().SetUIActive(!flag2);
		}

		// Token: 0x0603CAB4 RID: 248500 RVA: 0x00F68F28 File Offset: 0x00F67128
		private void RefreshAmountItem()
		{
			this.AmountItem.ResetSum();
			this.AmountItem.RefreshAddAndDelButton();
		}

		// Token: 0x0603CAB5 RID: 248501 RVA: 0x00F68F40 File Offset: 0x00F67140
		private void OpenCookRoleView()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenCookRole, this.ItemId);
		}

		// Token: 0x0603CAB6 RID: 248502 RVA: 0x00F68F58 File Offset: 0x00F67158
		private void OnConfirm()
		{
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				ModelBase<CookModel>.Instance.CleanAddExp();
				ControllerBase<CookController>.Instance.SendCookFoodRequest(this.ItemId, this.RoleId, this.Count);
				return;
			}
			ControllerBase<CookController>.Instance.SendFoodProcessRequest(this.ItemId, ModelBase<CookModel>.Instance.GetTmpMachiningItemList(), this.Count);
		}

		// Token: 0x0603CAB7 RID: 248503 RVA: 0x00F68FB8 File Offset: 0x00F671B8
		private void OnDisableCook()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MaterialShort", Array.Empty<object>());
		}

		// Token: 0x0603CAB8 RID: 248504 RVA: 0x00F68FCE File Offset: 0x00F671CE
		private void OnClickMaterial(ISingleItemInfo itemData, int _)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemData.Proto_ItemId, true, null);
		}

		// Token: 0x0603CAB9 RID: 248505 RVA: 0x00F68FE2 File Offset: 0x00F671E2
		private void OnCookSuccess()
		{
			this.Refresh();
		}

		// Token: 0x0603CABA RID: 248506 RVA: 0x00F68FEC File Offset: 0x00F671EC
		private void OnOpenMachiningCookPopView()
		{
			if (!base.GetActive())
			{
				return;
			}
			CookRewardPopData cookRewardPopData = new CookRewardPopData();
			cookRewardPopData.CookRewardPopType = ECookPopType.Machining;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CookSuccessView, cookRewardPopData, null);
		}

		// Token: 0x0603CABB RID: 248507 RVA: 0x00F69020 File Offset: 0x00F67220
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

		// Token: 0x0402212A RID: 139562
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<MaterialItem> MaterialHorizontal;

		// Token: 0x0402212B RID: 139563
		[Nullable(2)]
		private OpenCookRoleButton OpenCookRoleButton;

		// Token: 0x0402212C RID: 139564
		[Nullable(2)]
		private IconItem IconItem;

		// Token: 0x0402212D RID: 139565
		[Nullable(2)]
		private AmountItem AmountItem;

		// Token: 0x0402212E RID: 139566
		private bool IsFirstShow = true;

		// Token: 0x0402212F RID: 139567
		private int ItemId;

		// Token: 0x04022130 RID: 139568
		private int RoleId;

		// Token: 0x04022131 RID: 139569
		private int Count = 1;

		// Token: 0x04022132 RID: 139570
		private CookFormula? CookFormula;

		// Token: 0x04022133 RID: 139571
		private CookProcessed? CookProcessed;

		// Token: 0x0200BE63 RID: 48739
		[NullableContext(0)]
		public enum ECookViewDefine
		{
			// Token: 0x0403A9EC RID: 240108
			CookNameText,
			// Token: 0x0403A9ED RID: 240109
			CookIconItem,
			// Token: 0x0403A9EE RID: 240110
			CookMaterialHorizontalLayout,
			// Token: 0x0403A9EF RID: 240111
			CookConfirmButton,
			// Token: 0x0403A9F0 RID: 240112
			CookRoleItem,
			// Token: 0x0403A9F1 RID: 240113
			AmountItem,
			// Token: 0x0403A9F2 RID: 240114
			CookDefaultButton
		}
	}
}
