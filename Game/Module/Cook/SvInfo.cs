using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Cook.View;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DFB RID: 24059
	[NullableContext(1)]
	[Nullable(0)]
	public class SvInfo : UiPanelBase
	{
		// Token: 0x0603C874 RID: 247924 RVA: 0x00F5F5FC File Offset: 0x00F5D7FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603C875 RID: 247925 RVA: 0x00F5F6F4 File Offset: 0x00F5D8F4
		protected override void OnStart()
		{
			this.InventoryViewComponent = new GenericLayoutNew<MachiningClueItem>(base.GetVerticalLayout(6), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MachiningClueItem>(this.InitMachining), null);
			base.GetText(3).SetUIActive(false);
			this.AddEventListener();
			base.GetItem(1).SetUIActive(false);
			base.GetText(3).SetUIActive(true);
		}

		// Token: 0x0603C876 RID: 247926 RVA: 0x00F5F74D File Offset: 0x00F5D94D
		protected override void OnBeforeDestroy()
		{
			this.InventoryViewComponent = null;
			this.ItemData = null;
			this.RemoveEventListener();
		}

		// Token: 0x0603C877 RID: 247927 RVA: 0x00F5F763 File Offset: 0x00F5D963
		private void AddEventListener()
		{
		}

		// Token: 0x0603C878 RID: 247928 RVA: 0x00F5F765 File Offset: 0x00F5D965
		private void RemoveEventListener()
		{
		}

		// Token: 0x0603C879 RID: 247929 RVA: 0x00F5F768 File Offset: 0x00F5D968
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

		// Token: 0x0603C87A RID: 247930 RVA: 0x00F5F7B4 File Offset: 0x00F5D9B4
		[NullableContext(2)]
		public void SetTypeName(string tag = null)
		{
			UUIText text = base.GetText(0);
			if (tag != null)
			{
				text.SetUIActive(true);
				text.SetText(tag, true);
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0603C87B RID: 247931 RVA: 0x00F5F7E4 File Offset: 0x00F5D9E4
		public void RefreshCooking(ICookingData data, int times)
		{
			if (!this.CheckDataValid(data))
			{
				return;
			}
			if (this.ItemData != null && ((ICookItemData)this.ItemData).ItemId != data.ItemId)
			{
				ModelBase<CookModel>.Instance.CurrentCookRoleId = null;
			}
			this.ItemData = data;
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(data.ItemId);
			string itemAttributeDesc = ConfigBase<ItemConfig>.Instance.GetItemAttributeDesc(data.DataId);
			string newText = string.IsNullOrEmpty(cookFormulaById.FoodBackground) ? "" : ConfigBase<CookConfig>.Instance.GetLocalText(cookFormulaById.FoodBackground);
			this.InventoryViewComponent.SetActive(false);
			base.GetText(3).SetUIActive(true);
			base.GetText(3).SetText(itemAttributeDesc, true);
			base.GetText(5).SetText(newText, true);
		}

		// Token: 0x0603C87C RID: 247932 RVA: 0x00F5F8B4 File Offset: 0x00F5DAB4
		private bool CheckDataValid(object itemData)
		{
			if (itemData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Cook, ELogAuthor.LK, "缺少itemData数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x0603C87D RID: 247933 RVA: 0x00F5F8E8 File Offset: 0x00F5DAE8
		public void RefreshMachining(IMachiningData data)
		{
			if (!this.CheckDataValid(data))
			{
				return;
			}
			this.ItemData = data;
			this.InventoryViewComponent.SetActive(true);
			CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(data.ItemId);
			ItemInfo? config = ConfigItemInfoById.GetConfig(cookProcessedById.FinalItemId, true);
			string localText = ConfigBase<CookConfig>.Instance.GetLocalText(config.Value.BgDescription);
			base.GetText(3).SetUIActive(false);
			base.GetText(5).SetText(localText, true);
			List<IMachiningClueData> list = new List<IMachiningClueData>();
			for (int i = 0; i < cookProcessedById.InterationIdLength; i++)
			{
				int num = cookProcessedById.InterationId(i);
				CookProcessMsg cookProcessMsgById = ConfigBase<CookConfig>.Instance.GetCookProcessMsgById(num);
				if (data.InteractiveList.Contains(num))
				{
					string localText2 = ConfigBase<CookConfig>.Instance.GetLocalText(cookProcessMsgById.Introduce);
					list.Add(new MachiningClueData
					{
						IsUnlock = true,
						ContentText = localText2
					});
				}
				else
				{
					string localText3 = ConfigBase<CookConfig>.Instance.GetLocalText(cookProcessMsgById.Description);
					list.Add(new MachiningClueData
					{
						IsUnlock = false,
						ContentText = localText3
					});
				}
			}
			this.InventoryViewComponent.RebuildLayoutByDataNew<IMachiningClueData>(list, null);
		}

		// Token: 0x04022093 RID: 139411
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<MachiningClueItem> InventoryViewComponent;

		// Token: 0x04022094 RID: 139412
		[Nullable(2)]
		private object ItemData;
	}
}
