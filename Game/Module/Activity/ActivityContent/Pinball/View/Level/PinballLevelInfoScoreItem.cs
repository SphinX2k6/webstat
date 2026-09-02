using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level
{
	// Token: 0x02006603 RID: 26115
	public class PinballLevelInfoScoreItem : UiPanelBase
	{
		// Token: 0x0604141F RID: 267295 RVA: 0x010BDF4C File Offset: 0x010BC14C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickIcon));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041420 RID: 267296 RVA: 0x010BE098 File Offset: 0x010BC298
		[NullableContext(1)]
		public void Refresh(IPinballLevelScoreData data)
		{
			TItem titem = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(data.ConfigDropId)[0];
			int itemId = titem.ItemData.ItemId;
			int count = titem.Count;
			this.RewardItemId = itemId;
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			base.SetTextureByPath(itemConfigData.Icon, base.GetTexture(6), null, null);
			base.GetItem(0).SetUIActive(data.CurScore >= data.ConfigScore);
			base.GetSprite(5).SetUIActive(data.CurScore >= data.ConfigScore);
			base.GetText(1).SetText(count.ToString(), true);
			base.GetText(2).SetText(data.ConfigScore.ToString(), true);
			base.GetText(3).SetText(data.ConfigScore.ToString(), true);
		}

		// Token: 0x06041421 RID: 267297 RVA: 0x010BE183 File Offset: 0x010BC383
		private void OnClickIcon()
		{
			if (this.RewardItemId == 0)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItemId, true, null);
		}

		// Token: 0x04024872 RID: 149618
		private int RewardItemId;

		// Token: 0x0200C625 RID: 50725
		private enum EComponent
		{
			// Token: 0x0403CFE4 RID: 249828
			DoneItem,
			// Token: 0x0403CFE5 RID: 249829
			TxtScoreRewardNum,
			// Token: 0x0403CFE6 RID: 249830
			TxtScore,
			// Token: 0x0403CFE7 RID: 249831
			TxtLightScore,
			// Token: 0x0403CFE8 RID: 249832
			BtnIcon,
			// Token: 0x0403CFE9 RID: 249833
			SprIconDone,
			// Token: 0x0403CFEA RID: 249834
			TexItemIcon
		}
	}
}
