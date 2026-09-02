using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B75 RID: 23413
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class ItemSelectRewardItem : GridProxyAbstract<ItemSelectRewardItemData>
	{
		// Token: 0x0603B327 RID: 242471 RVA: 0x00EFACB8 File Offset: 0x00EF8EB8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B328 RID: 242472 RVA: 0x00EFADC1 File Offset: 0x00EF8FC1
		private void OnClickToggle(EToggleState state)
		{
			this.Data.OnClickToggleCallBack(this.Data.Index);
		}

		// Token: 0x0603B329 RID: 242473 RVA: 0x00EFADDE File Offset: 0x00EF8FDE
		public override void Refresh(ItemSelectRewardItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshToggle(data);
			this.RefreshTexture(data);
			this.RefreshNameText(data);
			this.RefreshDoneItem(data);
			this.RefreshLimitInfoText(data);
		}

		// Token: 0x0603B32A RID: 242474 RVA: 0x00EFAE0C File Offset: 0x00EF900C
		private void RefreshToggle(ItemSelectRewardItemData data)
		{
			EToggleState state = data.SelectState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		}

		// Token: 0x0603B32B RID: 242475 RVA: 0x00EFAE38 File Offset: 0x00EF9038
		private void RefreshTexture(ItemSelectRewardItemData data)
		{
			UUITexture texture = base.GetTexture(1);
			base.SetItemIcon(texture, data.ItemId, null, null);
		}

		// Token: 0x0603B32C RID: 242476 RVA: 0x00EFAE64 File Offset: 0x00EF9064
		private void RefreshNameText(ItemSelectRewardItemData data)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.ItemId);
			base.GetText(2).ShowTextNew(itemConfigData.Name);
		}

		// Token: 0x0603B32D RID: 242477 RVA: 0x00EFAE94 File Offset: 0x00EF9094
		private bool IfHaveRoleCallBackItemNeedRole(int itemId)
		{
			int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(itemId);
			if (resonantItemRoleId == null)
			{
				return false;
			}
			int id = resonantItemRoleId[0];
			return ModelBase<RoleModel>.Instance.GetRoleInstanceById(id) != null;
		}

		// Token: 0x0603B32E RID: 242478 RVA: 0x00EFAEC6 File Offset: 0x00EF90C6
		private void RefreshDoneItem(ItemSelectRewardItemData data)
		{
			base.GetItem(3).SetUIActive(!this.IfHaveRoleCallBackItemNeedRole(data.ItemId));
		}

		// Token: 0x0603B32F RID: 242479 RVA: 0x00EFAEE4 File Offset: 0x00EF90E4
		private void RefreshLimitInfoText(ItemSelectRewardItemData data)
		{
			int num = 0;
			ResonantChainOptionLimitInfo limitInfo = data.LimitInfo;
			int num2 = (limitInfo != null) ? limitInfo.LimitNum : 0;
			if (data.LimitInfo != null)
			{
				foreach (ResonantChainOptionLimitItemInfo resonantChainOptionLimitItemInfo in data.LimitInfo.ItemInfos)
				{
					if (resonantChainOptionLimitItemInfo.ItemId == data.ItemId)
					{
						num = resonantChainOptionLimitItemInfo.Count;
						break;
					}
				}
			}
			int num3 = num2 - num;
			string textStringId = (num3 > 0) ? "ResonantChainOptionLimitInfoTextNormal" : "ResonantChainOptionLimitInfoTextMax";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				num3,
				num2
			}));
		}

		// Token: 0x040215F3 RID: 136691
		[Nullable(2)]
		public ItemSelectRewardItemData Data;
	}
}
