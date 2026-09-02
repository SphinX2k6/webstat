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
	// Token: 0x02005E29 RID: 24105
	[NullableContext(1)]
	[Nullable(0)]
	public class CookTipsView : UiPanelBase
	{
		// Token: 0x0603CA84 RID: 248452 RVA: 0x00F67B39 File Offset: 0x00F65D39
		public CookTipsView(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CA85 RID: 248453 RVA: 0x00F67B50 File Offset: 0x00F65D50
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(23, new Action(delegate()
			{
				this.OnDisableCook();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CA86 RID: 248454 RVA: 0x00F67DF2 File Offset: 0x00F65FF2
		protected override void OnBeforeDestroy()
		{
			this.MaterialHorizontal.ClearChildren();
			this.MaterialHorizontal = null;
			this.MachiningVertical.ClearChildren();
			this.MachiningVertical = null;
		}

		// Token: 0x0603CA87 RID: 248455 RVA: 0x00F67E18 File Offset: 0x00F66018
		protected override void OnStart()
		{
			this.ConfirmButtonCompose = new ConfirmButtonCompose(base.GetItem(8));
			this.ConfirmButtonCompose.BindClickFunction(new Action(this.OnClickConfirmButton));
			this.MaterialHorizontal = new GenericLayoutNew<MaterialItem>(base.GetHorizontalLayout(18), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MaterialItem>(this.InitMaterial), null);
			this.MachiningVertical = new GenericLayoutNew<MachiningClueItem>(base.GetVerticalLayout(21), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MachiningClueItem>(this.InitMachining), null);
		}

		// Token: 0x0603CA88 RID: 248456 RVA: 0x00F67E90 File Offset: 0x00F66090
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
			materialItem.BindOnClickedCallback(new Action<ISingleItemInfo, int>(this.OnClicked));
			return new LayoutItem<MaterialItem>
			{
				Key = index,
				Value = materialItem
			};
		}

		// Token: 0x0603CA89 RID: 248457 RVA: 0x00F67EE2 File Offset: 0x00F660E2
		private void OnClicked(ISingleItemInfo itemData, int _)
		{
			if (!itemData.Proto_IsUnlock)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemData.Proto_ItemId, true, null);
		}

		// Token: 0x0603CA8A RID: 248458 RVA: 0x00F67F00 File Offset: 0x00F66100
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<MachiningClueItem> InitMachining([Nullable(2)] object data, UUIItem uiItem, int index)
		{
			IMachiningClueData machiningClueData = data as IMachiningClueData;
			if (machiningClueData == null)
			{
				return null;
			}
			MachiningClueItem machiningClueItem = new MachiningClueItem(uiItem);
			machiningClueItem.Update(machiningClueData.IsUnlock, machiningClueData.ContentText);
			return new LayoutItem<MachiningClueItem>
			{
				Key = index,
				Value = machiningClueItem
			};
		}

		// Token: 0x0603CA8B RID: 248459 RVA: 0x00F67F4C File Offset: 0x00F6614C
		public void RefreshTips(ICookingData itemData)
		{
			this.ItemData = itemData;
			ECookListType mainType = itemData.MainType;
			if (mainType == ECookListType.Cooking)
			{
				this.RefreshCooking();
				return;
			}
			if (mainType != ECookListType.Machining)
			{
				return;
			}
			this.RefreshMachining();
		}

		// Token: 0x0603CA8C RID: 248460 RVA: 0x00F67F7C File Offset: 0x00F6617C
		private void RefreshCooking()
		{
			ICookingData cookingData = this.ItemData as ICookingData;
			ESubCookDataType subType = cookingData.SubType;
			if (subType != ESubCookDataType.CookFood)
			{
				if (subType == ESubCookDataType.CookMenu)
				{
					this.SetCookMenuHide();
					this.RefreshCookMenu(cookingData);
					return;
				}
			}
			else
			{
				this.SetCookFoodHide();
				this.RefreshCookFood(cookingData);
			}
		}

		// Token: 0x0603CA8D RID: 248461 RVA: 0x00F67FC4 File Offset: 0x00F661C4
		private void RefreshCookMenu(ICookingData data)
		{
			CookFormula cookFormulaByFormulaItemId = ConfigBase<CookConfig>.Instance.GetCookFormulaByFormulaItemId(data.ItemId);
			this.SetHaveText(1);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Recipe");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookFormulaByFormulaItemId.Name);
			this.SetNameText(localText);
			this.SetIconTexture(ConfigBase<ItemConfig>.Instance.GetConfig(data.ItemId).Value.Icon);
			string localText2 = ConfigBase<CookConfig>.Instance.GetLocalText(cookFormulaByFormulaItemId.FoodContent);
			this.SetContentText(localText2);
			string localText3 = ConfigBase<CookConfig>.Instance.GetLocalText(cookFormulaByFormulaItemId.FoodBackground);
			this.SetAttributeText(localText3);
			this.RefreshDisableButton(true);
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Study");
			this.RefreshConfirmButton(textById2, true);
		}

		// Token: 0x0603CA8E RID: 248462 RVA: 0x00F68098 File Offset: 0x00F66298
		private void RefreshCookFood(ICookingData data)
		{
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(data.ItemId);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(cookFormulaById.FoodItemId, 0);
			this.SetHaveText(commonItemCount);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Dishes");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookFormulaById.Name);
			this.SetNameText(localText);
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(cookFormulaById.FoodItemId);
			this.SetIconTexture(config.Value.Icon);
			string localText2 = ConfigBase<CookConfig>.Instance.GetLocalText(config.Value.AttributesDescription);
			this.SetContentText(localText2);
			string localText3 = ConfigBase<CookConfig>.Instance.GetLocalText(config.Value.BgDescription);
			this.SetAttributeText(localText3);
			int proficiency = cookFormulaById.Proficiency;
			int maxProficiencyCount = cookFormulaById.MaxProficiencyCount;
			this.SetProficiencyText(data.CookCount, proficiency, maxProficiencyCount);
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Cooking");
			bool isEnable = ControllerBase<CookController>.Instance.CheckCanCook(data.ItemId);
			this.RefreshConfirmButton(textById2, isEnable);
			this.RefreshDisableButton(isEnable);
			this.SetMaterialList(data.ItemId, ECookListType.Cooking);
		}

		// Token: 0x0603CA8F RID: 248463 RVA: 0x00F681D8 File Offset: 0x00F663D8
		private void SetCookMenuHide()
		{
			base.GetText(3).SetUIActive(true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(17).SetUIActive(false);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(20).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
			base.GetText(16).SetUIActive(false);
		}

		// Token: 0x0603CA90 RID: 248464 RVA: 0x00F68248 File Offset: 0x00F66448
		private void SetCookFoodHide()
		{
			base.GetText(3).SetUIActive(true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(17).SetUIActive(true);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(20).SetUIActive(false);
			base.GetText(2).SetUIActive(true);
			base.GetText(16).SetUIActive(true);
		}

		// Token: 0x0603CA91 RID: 248465 RVA: 0x00F682B8 File Offset: 0x00F664B8
		private void RefreshMachining()
		{
			this.SetMachiningHide();
			IMachiningData machiningData = this.ItemData as IMachiningData;
			CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(machiningData.ItemId);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(cookProcessedById.FinalItemId, 0);
			this.SetHaveText(commonItemCount);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Accessory");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookProcessedById.Name);
			this.SetNameText(localText);
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(cookProcessedById.FinalItemId);
			this.SetIconTexture(config.Value.Icon);
			this.SetInterations();
			string localText2 = ConfigBase<CookConfig>.Instance.GetLocalText(config.Value.BgDescription);
			this.SetMachiningAttributeText(localText2);
			bool isEnable = true;
			string textById2;
			if (!machiningData.IsUnLock)
			{
				textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Research");
			}
			else
			{
				textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Cooking");
				isEnable = ControllerBase<CookController>.Instance.CheckCanProcessed(machiningData.ItemId);
			}
			this.RefreshConfirmButton(textById2, isEnable);
			this.RefreshDisableButton(isEnable);
			this.SetMaterialList(machiningData.ItemId, ECookListType.Machining);
		}

		// Token: 0x0603CA92 RID: 248466 RVA: 0x00F683EC File Offset: 0x00F665EC
		private void SetMachiningHide()
		{
			base.GetText(3).SetUIActive(false);
			base.GetText(12).SetUIActive(false);
			base.GetItem(19).SetUIActive(false);
			base.GetItem(20).SetUIActive(true);
			base.GetItem(17).SetUIActive(true);
			base.GetText(2).SetUIActive(false);
			base.GetText(16).SetUIActive(false);
		}

		// Token: 0x0603CA93 RID: 248467 RVA: 0x00F68459 File Offset: 0x00F66659
		private void SetNameText(string name)
		{
			base.GetText(0).SetText(name, true);
		}

		// Token: 0x0603CA94 RID: 248468 RVA: 0x00F6846C File Offset: 0x00F6666C
		private void SetIconTexture(string icon)
		{
			base.SetTextureByPath(icon, base.GetTexture(1), null, null);
		}

		// Token: 0x0603CA95 RID: 248469 RVA: 0x00F68491 File Offset: 0x00F66691
		private void SetContentText(string text)
		{
			base.GetText(3).SetText(text, true);
		}

		// Token: 0x0603CA96 RID: 248470 RVA: 0x00F684A1 File Offset: 0x00F666A1
		private void SetAttributeText(string text)
		{
			base.GetText(12).SetText(text, true);
		}

		// Token: 0x0603CA97 RID: 248471 RVA: 0x00F684B2 File Offset: 0x00F666B2
		private void SetMachiningAttributeText(string text)
		{
			base.GetText(22).SetText(text, true);
		}

		// Token: 0x0603CA98 RID: 248472 RVA: 0x00F684C3 File Offset: 0x00F666C3
		private void SetTypeNameText(string text)
		{
			base.GetText(15).SetText(text, true);
		}

		// Token: 0x0603CA99 RID: 248473 RVA: 0x00F684D4 File Offset: 0x00F666D4
		private void SetHaveText(int have)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(14), "Have", new <>z__ReadOnlySingleElementList<object>(have));
		}

		// Token: 0x0603CA9A RID: 248474 RVA: 0x00F684F8 File Offset: 0x00F666F8
		private void SetProficiencyText(int cookCount, int single, int sum)
		{
			int num = single * sum;
			int num2 = cookCount * single;
			if (num2 != num)
			{
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText text = base.GetText(2);
				string textTableId = "AddProficiency";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(single);
				instance.SetLocalText(text, textTableId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "Proficiency", Array.Empty<object>());
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(16), "CumulativeProficiency", new <>z__ReadOnlyArray<object>(new object[]
			{
				num2,
				num
			}));
		}

		// Token: 0x0603CA9B RID: 248475 RVA: 0x00F685A1 File Offset: 0x00F667A1
		private void RefreshConfirmButton(string text, bool isEnable)
		{
			this.ConfirmButtonCompose.UpdateText(text);
			this.ConfirmButtonCompose.RefreshButton(isEnable);
		}

		// Token: 0x0603CA9C RID: 248476 RVA: 0x00F685BB File Offset: 0x00F667BB
		private void RefreshDisableButton(bool isEnable)
		{
			(base.GetButton(23).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(!isEnable);
		}

		// Token: 0x0603CA9D RID: 248477 RVA: 0x00F685E0 File Offset: 0x00F667E0
		private void SetMaterialList(int itemId, ECookListType type)
		{
			List<ISingleItemInfo> cookMaterialList = ModelBase<CookModel>.Instance.GetCookMaterialList(itemId, type);
			this.MaterialHorizontal.RebuildLayoutByDataNew<ISingleItemInfo>(cookMaterialList, null);
		}

		// Token: 0x0603CA9E RID: 248478 RVA: 0x00F68610 File Offset: 0x00F66810
		private void SetInterations()
		{
			IMachiningData machiningData = this.ItemData as IMachiningData;
			CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(machiningData.ItemId);
			List<IMachiningClueData> list = new List<IMachiningClueData>();
			for (int i = 0; i < cookProcessedById.InterationIdLength; i++)
			{
				int num = cookProcessedById.InterationId(i);
				CookProcessMsg cookProcessMsgById = ConfigBase<CookConfig>.Instance.GetCookProcessMsgById(num);
				if (machiningData.InteractiveList.Contains(num))
				{
					string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookProcessMsgById.Introduce);
					list.Add(new MachiningClueData
					{
						IsUnlock = true,
						ContentText = localText
					});
				}
				else
				{
					string localText2 = ConfigBase<CookConfig>.Instance.GetLocalText(cookProcessMsgById.Description);
					list.Add(new MachiningClueData
					{
						IsUnlock = false,
						ContentText = localText2
					});
				}
			}
			this.MachiningVertical.RebuildLayoutByDataNew<IMachiningClueData>(list, null);
		}

		// Token: 0x0603CA9F RID: 248479 RVA: 0x00F686F4 File Offset: 0x00F668F4
		private void OnClickConfirmButton()
		{
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				ICookingData cookingData = this.ItemData as ICookingData;
				ESubCookDataType subType = cookingData.SubType;
				if (subType == ESubCookDataType.CookFood)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenCook, cookingData.ItemId);
					return;
				}
				if (subType == ESubCookDataType.CookMenu)
				{
					CookFormula cookFormulaByFormulaItemId = ConfigBase<CookConfig>.Instance.GetCookFormulaByFormulaItemId(cookingData.ItemId);
					ControllerBase<CookController>.Instance.SendCookFormulaRequest(cookFormulaByFormulaItemId.Id);
					return;
				}
			}
			else
			{
				IMachiningData machiningData = this.ItemData as IMachiningData;
				if (machiningData.IsUnLock)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenCook, machiningData.ItemId);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenProcessedStudy, machiningData.ItemId);
			}
		}

		// Token: 0x0603CAA0 RID: 248480 RVA: 0x00F687A6 File Offset: 0x00F669A6
		private void OnDisableCook()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MaterialShort", Array.Empty<object>());
		}

		// Token: 0x04022126 RID: 139558
		[Nullable(2)]
		private ICookItemData ItemData;

		// Token: 0x04022127 RID: 139559
		[Nullable(2)]
		private ConfirmButtonCompose ConfirmButtonCompose;

		// Token: 0x04022128 RID: 139560
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<MaterialItem> MaterialHorizontal;

		// Token: 0x04022129 RID: 139561
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<MachiningClueItem> MachiningVertical;

		// Token: 0x0200BE62 RID: 48738
		[NullableContext(0)]
		private enum ECookTipsDefine
		{
			// Token: 0x0403A9DA RID: 240090
			NameText,
			// Token: 0x0403A9DB RID: 240091
			IconTexture,
			// Token: 0x0403A9DC RID: 240092
			CookCountText,
			// Token: 0x0403A9DD RID: 240093
			ConTentText,
			// Token: 0x0403A9DE RID: 240094
			TipsBtnItem = 6,
			// Token: 0x0403A9DF RID: 240095
			TipsConfirmButton = 8,
			// Token: 0x0403A9E0 RID: 240096
			AttributeText = 12,
			// Token: 0x0403A9E1 RID: 240097
			HaveText = 14,
			// Token: 0x0403A9E2 RID: 240098
			TypeNameText,
			// Token: 0x0403A9E3 RID: 240099
			SumText,
			// Token: 0x0403A9E4 RID: 240100
			MaterialLayoutItem,
			// Token: 0x0403A9E5 RID: 240101
			MaterialHorizontalLayout,
			// Token: 0x0403A9E6 RID: 240102
			CookingIntroduceItem,
			// Token: 0x0403A9E7 RID: 240103
			MachiningConditionItem,
			// Token: 0x0403A9E8 RID: 240104
			MachiningVerticalLayout,
			// Token: 0x0403A9E9 RID: 240105
			MachiningAttributeText,
			// Token: 0x0403A9EA RID: 240106
			DisableButton
		}
	}
}
