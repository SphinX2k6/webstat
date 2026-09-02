using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059CB RID: 22987
	[NullableContext(1)]
	[Nullable(0)]
	public class ComposeTipsView : UiPanelBase
	{
		// Token: 0x0603A3E8 RID: 238568 RVA: 0x00EC2B1F File Offset: 0x00EC0D1F
		public ComposeTipsView(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A3E9 RID: 238569 RVA: 0x00EC2B34 File Offset: 0x00EC0D34
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
			*span2[num] = new ValueTuple<int, Delegate>(23, new Action(this.OnDisable));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A3EA RID: 238570 RVA: 0x00EC2DD8 File Offset: 0x00EC0FD8
		protected override void OnStart()
		{
			this.ConfirmButtonCompose = new ConfirmButtonCompose(base.GetItem(8));
			this.ConfirmButtonCompose.BindClickFunction(new Action(this.OnClickConfirmButton));
			this.MaterialHorizontal = new GenericLayoutNew<MaterialItem>(base.GetHorizontalLayout(18), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MaterialItem>(this.InitMaterial), null);
		}

		// Token: 0x0603A3EB RID: 238571 RVA: 0x00EC2E30 File Offset: 0x00EC1030
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
			materialItem.BindOnClickedCallback(new Action<ISingleItemInfo>(this.OnClicked));
			return new LayoutItem<MaterialItem>
			{
				Key = index,
				Value = materialItem
			};
		}

		// Token: 0x0603A3EC RID: 238572 RVA: 0x00EC2E81 File Offset: 0x00EC1081
		private void OnClicked(ISingleItemInfo itemData)
		{
			if (!itemData.Proto_IsUnlock)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemData.Proto_ItemId, true, null);
		}

		// Token: 0x0603A3ED RID: 238573 RVA: 0x00EC2E9E File Offset: 0x00EC109E
		protected override void OnBeforeDestroy()
		{
			if (this.MaterialHorizontal != null)
			{
				this.MaterialHorizontal.ClearChildren();
				this.MaterialHorizontal = null;
			}
			this.OnDisableCallback = null;
		}

		// Token: 0x0603A3EE RID: 238574 RVA: 0x00EC2EC4 File Offset: 0x00EC10C4
		public void RefreshTips(IBaseItemData itemData)
		{
			this.ItemData = itemData;
			switch (itemData.MainType)
			{
			case EComposeListType.ReagentProduction:
				this.RefreshReagentProductionData();
				return;
			case EComposeListType.Structure:
				this.RefreshStructureData();
				return;
			case EComposeListType.Purification:
				this.RefreshPurificationData();
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A3EF RID: 238575 RVA: 0x00EC2F08 File Offset: 0x00EC1108
		private void RefreshReagentProductionData()
		{
			IReagentProductionData reagentProductionData = (IReagentProductionData)this.ItemData;
			ESubComposeDataType subType = reagentProductionData.SubType;
			if (subType != ESubComposeDataType.Compose)
			{
				if (subType == ESubComposeDataType.ComposeMenu)
				{
					this.SetRefreshReagentProductionMenuHide();
					this.RefreshReagentProductionMenu(reagentProductionData);
					return;
				}
			}
			else
			{
				this.SetRefreshReagentProductionHide();
				this.RefreshReagentProduction(reagentProductionData);
			}
		}

		// Token: 0x0603A3F0 RID: 238576 RVA: 0x00EC2F4C File Offset: 0x00EC114C
		private void RefreshReagentProductionMenu(IReagentProductionData data)
		{
			SynthesisFormula value = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaByFormulaItemId(data.ConfigId).Value;
			this.SetHaveText(1);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Formula");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.Name);
			this.SetNameText(localText);
			this.SetIconTexture(ConfigBase<ItemConfig>.Instance.GetConfig(data.ConfigId).Value.Icon);
			string localText2 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.ComposeContent);
			this.SetContentText(localText2);
			string localText3 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.ComposeBackground);
			this.SetAttributeText(localText3);
			this.RefreshDisableButton(true);
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Study");
			this.RefreshConfirmButton(textById2, true);
		}

		// Token: 0x0603A3F1 RID: 238577 RVA: 0x00EC3028 File Offset: 0x00EC1228
		private void RefreshReagentProduction(IReagentProductionData data)
		{
			SynthesisFormula value = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId).Value;
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(value.ItemId, 0);
			this.SetHaveText(commonItemCount);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Medicament");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.Name);
			this.SetNameText(localText);
			ItemInfo value2 = ConfigBase<ItemConfig>.Instance.GetConfig(value.ItemId).Value;
			this.SetIconTexture(value2.Icon);
			string localText2 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value2.AttributesDescription);
			this.SetContentText(localText2);
			string localText3 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value2.BgDescription);
			this.SetAttributeText(localText3);
			int proficiency = value.Proficiency;
			int maxProficiencyCount = value.MaxProficiencyCount;
			this.SetProficiencyText(data.ComposeCount, proficiency, maxProficiencyCount);
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Making");
			bool isEnable = ControllerBase<ComposeController>.Instance.CheckCanReagentProduction(data.ConfigId);
			this.RefreshConfirmButton(textById2, isEnable);
			this.RefreshDisableButton(isEnable);
			this.SetMaterialList(data.ConfigId);
		}

		// Token: 0x0603A3F2 RID: 238578 RVA: 0x00EC315C File Offset: 0x00EC135C
		private void SetRefreshReagentProductionMenuHide()
		{
			base.GetText(3).SetUIActive(true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(17).SetUIActive(false);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(20).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
			base.GetText(16).SetUIActive(false);
		}

		// Token: 0x0603A3F3 RID: 238579 RVA: 0x00EC31CC File Offset: 0x00EC13CC
		private void SetRefreshReagentProductionHide()
		{
			base.GetText(3).SetUIActive(true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(17).SetUIActive(true);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(20).SetUIActive(false);
			base.GetText(2).SetUIActive(true);
			base.GetText(16).SetUIActive(true);
		}

		// Token: 0x0603A3F4 RID: 238580 RVA: 0x00EC323C File Offset: 0x00EC143C
		public void RefreshStructureData()
		{
			IStructureData structureData = (IStructureData)this.ItemData;
			ESubStructureDataType subType = structureData.SubType;
			if (subType != ESubStructureDataType.Structure)
			{
				if (subType == ESubStructureDataType.StructureMenu)
				{
					this.SetStructureMenuHide();
					this.RefreshStructureMenu(structureData);
					return;
				}
			}
			else
			{
				this.SetStructureHide();
				this.RefreshStructure(structureData);
			}
		}

		// Token: 0x0603A3F5 RID: 238581 RVA: 0x00EC3280 File Offset: 0x00EC1480
		public void RefreshStructure(IStructureData data)
		{
			SynthesisFormula value = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId).Value;
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(value.ItemId, 0);
			this.SetHaveText(commonItemCount);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Prop");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.Name);
			this.SetNameText(localText);
			ItemInfo value2 = ConfigBase<ItemConfig>.Instance.GetConfig(value.ItemId).Value;
			this.SetIconTexture(value2.Icon);
			string localText2 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value2.AttributesDescription);
			this.SetContentText(localText2);
			string localText3 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value2.BgDescription);
			this.SetAttributeText(localText3);
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Making");
			bool isEnable = ControllerBase<ComposeController>.Instance.CheckCanStructure(data.ConfigId);
			this.RefreshConfirmButton(textById2, isEnable);
			this.RefreshDisableButton(isEnable);
			this.SetMaterialList(data.ConfigId);
		}

		// Token: 0x0603A3F6 RID: 238582 RVA: 0x00EC3394 File Offset: 0x00EC1594
		public void RefreshStructureMenu(IStructureData data)
		{
			SynthesisFormula value = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaByFormulaItemId(data.ConfigId).Value;
			this.SetHaveText(1);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Formula");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.Name);
			this.SetNameText(localText);
			this.SetIconTexture(ConfigBase<ItemConfig>.Instance.GetConfig(data.ConfigId).Value.Icon);
			string localText2 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.ComposeContent);
			this.SetContentText(localText2);
			string localText3 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.ComposeBackground);
			this.SetAttributeText(localText3);
			this.RefreshDisableButton(true);
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("Study");
			this.RefreshConfirmButton(textById2, true);
		}

		// Token: 0x0603A3F7 RID: 238583 RVA: 0x00EC3470 File Offset: 0x00EC1670
		private void SetStructureHide()
		{
			base.GetText(3).SetUIActive(true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(17).SetUIActive(true);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(20).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
			base.GetText(16).SetUIActive(false);
		}

		// Token: 0x0603A3F8 RID: 238584 RVA: 0x00EC34E0 File Offset: 0x00EC16E0
		private void SetStructureMenuHide()
		{
			base.GetText(3).SetUIActive(true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(17).SetUIActive(false);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(20).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
			base.GetText(16).SetUIActive(false);
		}

		// Token: 0x0603A3F9 RID: 238585 RVA: 0x00EC3550 File Offset: 0x00EC1750
		public void RefreshPurificationData()
		{
			IPurificationData data = (IPurificationData)this.ItemData;
			this.SetPurificationHide();
			this.RefreshPurification(data);
		}

		// Token: 0x0603A3FA RID: 238586 RVA: 0x00EC3578 File Offset: 0x00EC1778
		public void RefreshPurification(IPurificationData data)
		{
			SynthesisFormula value = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId).Value;
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(value.ItemId, 0);
			this.SetHaveText(commonItemCount);
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Material");
			this.SetTypeNameText(textById);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(value.Name);
			this.SetNameText(localText);
			ItemInfo value2 = ConfigBase<ItemConfig>.Instance.GetConfig(value.ItemId).Value;
			this.SetIconTexture(value2.Icon);
			string localText2 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value2.AttributesDescription);
			this.SetContentText(localText2);
			string localText3 = ConfigBase<ComposeConfig>.Instance.GetLocalText(value2.BgDescription);
			this.SetAttributeText(localText3);
			string text;
			bool isEnable;
			if (data.IsUnlock == 1)
			{
				text = ConfigBase<TextConfig>.Instance.GetTextById("Making");
				isEnable = ControllerBase<ComposeController>.Instance.CheckCanPurification(data.ConfigId);
				this.RefreshDisableButton(isEnable);
			}
			else
			{
				ConditionGroup value3 = ConfigBase<ComposeConfig>.Instance.GetConditionInfo(value.UnlockCondition).Value;
				text = ConfigBase<ComposeConfig>.Instance.GetLocalText(value3.HintText);
				isEnable = false;
				this.RefreshDisableButton(true);
			}
			this.RefreshConfirmButton(text, isEnable);
			this.SetMaterialList(data.ConfigId);
		}

		// Token: 0x0603A3FB RID: 238587 RVA: 0x00EC36D8 File Offset: 0x00EC18D8
		public void SetPurificationHide()
		{
			base.GetText(3).SetUIActive(true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(17).SetUIActive(true);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(20).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
			base.GetText(16).SetUIActive(false);
		}

		// Token: 0x0603A3FC RID: 238588 RVA: 0x00EC3745 File Offset: 0x00EC1945
		private void SetNameText(string name)
		{
			base.GetText(0).SetText(name, true);
		}

		// Token: 0x0603A3FD RID: 238589 RVA: 0x00EC3758 File Offset: 0x00EC1958
		private void SetIconTexture(string icon)
		{
			base.SetTextureByPath(icon, base.GetTexture(1), null, null);
		}

		// Token: 0x0603A3FE RID: 238590 RVA: 0x00EC377D File Offset: 0x00EC197D
		private void SetContentText(string text)
		{
			base.GetText(3).SetText(text, true);
		}

		// Token: 0x0603A3FF RID: 238591 RVA: 0x00EC378D File Offset: 0x00EC198D
		private void SetAttributeText(string text)
		{
			base.GetText(12).SetText(text, true);
		}

		// Token: 0x0603A400 RID: 238592 RVA: 0x00EC379E File Offset: 0x00EC199E
		private void SetTypeNameText(string text)
		{
			base.GetText(15).SetText(text, true);
		}

		// Token: 0x0603A401 RID: 238593 RVA: 0x00EC37AF File Offset: 0x00EC19AF
		private void SetHaveText(int have)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(14), "Have", new <>z__ReadOnlySingleElementList<object>(have));
		}

		// Token: 0x0603A402 RID: 238594 RVA: 0x00EC37D4 File Offset: 0x00EC19D4
		private void SetProficiencyText(int composeCount, int single, int sum)
		{
			int num = single * sum;
			int num2 = composeCount * single;
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

		// Token: 0x0603A403 RID: 238595 RVA: 0x00EC387D File Offset: 0x00EC1A7D
		private void RefreshConfirmButton(string text, bool isEnable)
		{
			this.ConfirmButtonCompose.UpdateText(text);
			this.ConfirmButtonCompose.RefreshButton(isEnable);
		}

		// Token: 0x0603A404 RID: 238596 RVA: 0x00EC3897 File Offset: 0x00EC1A97
		private void RefreshDisableButton(bool isEnable)
		{
			((AUIBaseActor)base.GetButton(23).GetOwner()).GetUIItem().SetUIActive(!isEnable);
		}

		// Token: 0x0603A405 RID: 238597 RVA: 0x00EC38BC File Offset: 0x00EC1ABC
		private void SetMaterialList(int itemId)
		{
			this.MaterialHorizontal.RebuildLayoutByDataNew<ISingleItemInfo>(ModelBase<ComposeModel>.Instance.GetComposeMaterialList(itemId), null);
		}

		// Token: 0x0603A406 RID: 238598 RVA: 0x00EC38E8 File Offset: 0x00EC1AE8
		private void OnClickConfirmButton()
		{
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
			{
				IReagentProductionData reagentProductionData = (IReagentProductionData)this.ItemData;
				if (reagentProductionData.SubType == ESubComposeDataType.ComposeMenu)
				{
					SynthesisFormula value = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaByFormulaItemId(reagentProductionData.ConfigId).Value;
					ControllerBase<ComposeController>.Instance.SendSynthesisFormulaUnlockRequest(value.Id);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenCompose, reagentProductionData.ConfigId);
				return;
			}
			case EComposeListType.Structure:
			{
				IStructureData structureData = (IStructureData)this.ItemData;
				if (structureData.SubType == ESubStructureDataType.StructureMenu)
				{
					SynthesisFormula value2 = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaByFormulaItemId(structureData.ConfigId).Value;
					ControllerBase<ComposeController>.Instance.SendSynthesisFormulaUnlockRequest(value2.Id);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenCompose, structureData.ConfigId);
				return;
			}
			case EComposeListType.Purification:
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenCompose, this.ItemData.ConfigId);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A407 RID: 238599 RVA: 0x00EC39E5 File Offset: 0x00EC1BE5
		private void OnDisable()
		{
			if (this.OnDisableCallback != null)
			{
				this.OnDisableCallback();
			}
		}

		// Token: 0x0603A408 RID: 238600 RVA: 0x00EC39FA File Offset: 0x00EC1BFA
		public void BindOnDisable(Action onDisable)
		{
			this.OnDisableCallback = onDisable;
		}

		// Token: 0x0402102F RID: 135215
		[Nullable(2)]
		private IBaseItemData ItemData;

		// Token: 0x04021030 RID: 135216
		[Nullable(2)]
		private ConfirmButtonCompose ConfirmButtonCompose;

		// Token: 0x04021031 RID: 135217
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<MaterialItem> MaterialHorizontal;

		// Token: 0x04021032 RID: 135218
		[Nullable(2)]
		private Action OnDisableCallback;

		// Token: 0x0200B9A1 RID: 47521
		[NullableContext(0)]
		private class EComposeTipsDefine
		{
			// Token: 0x040395C0 RID: 234944
			public const int NameText = 0;

			// Token: 0x040395C1 RID: 234945
			public const int IconTexture = 1;

			// Token: 0x040395C2 RID: 234946
			public const int ComposeCountText = 2;

			// Token: 0x040395C3 RID: 234947
			public const int ConTentText = 3;

			// Token: 0x040395C4 RID: 234948
			public const int TipsBtnItem = 6;

			// Token: 0x040395C5 RID: 234949
			public const int TipsConfirmButton = 8;

			// Token: 0x040395C6 RID: 234950
			public const int AttributeText = 12;

			// Token: 0x040395C7 RID: 234951
			public const int HaveText = 14;

			// Token: 0x040395C8 RID: 234952
			public const int TypeNameText = 15;

			// Token: 0x040395C9 RID: 234953
			public const int SumText = 16;

			// Token: 0x040395CA RID: 234954
			public const int MaterialLayoutItem = 17;

			// Token: 0x040395CB RID: 234955
			public const int MaterialHorizontalLayout = 18;

			// Token: 0x040395CC RID: 234956
			public const int ComposeIntroduceItem = 19;

			// Token: 0x040395CD RID: 234957
			public const int MachiningConditionItem = 20;

			// Token: 0x040395CE RID: 234958
			public const int MachiningVerticalLayout = 21;

			// Token: 0x040395CF RID: 234959
			public const int MachiningAttributeText = 22;

			// Token: 0x040395D0 RID: 234960
			public const int DisableButton = 23;
		}
	}
}
