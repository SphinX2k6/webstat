using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005ADB RID: 23259
	internal class GiftItem : GridProxyAbstract<int>
	{
		// Token: 0x0603ACDB RID: 240859 RVA: 0x00EE9814 File Offset: 0x00EE7A14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ACDC RID: 240860 RVA: 0x00EE98A0 File Offset: 0x00EE7AA0
		protected override void OnStart()
		{
			this.ItemGridGrid = new SmallItemGrid();
			this.ItemGridGrid.Initialize(base.GetItem(2).GetOwner());
			this.ItemGridGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			this.ItemGridGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
		}

		// Token: 0x0603ACDD RID: 240861 RVA: 0x00EE9910 File Offset: 0x00EE7B10
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.ConfigId = data;
			KurotatoScoreAward value = ConfigBase<KurotatoConfig>.Instance.GetKurotatoScoreAwardConfigById(data).Value;
			base.GetText(1).SetText(value.Score.ToString(), true);
			bool uiactive = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetCurrentMilestone() >= value.Score;
			base.GetSprite(0).SetUIActive(uiactive);
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(value.DropId);
			this.ItemGrid = new TItem?(dropPackagePreviewItemList[0]);
			this.RefreshGrid(value);
		}

		// Token: 0x0603ACDE RID: 240862 RVA: 0x00EE99AC File Offset: 0x00EE7BAC
		private void RefreshGrid(KurotatoScoreAward config)
		{
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			bool flag = activityData.IsScoreRewardCanReceived(config.Id);
			bool flag2 = activityData.IsScoreRewardReceived(config.Id);
			bool lockBlackVisible = !flag && !flag2;
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = config,
				ItemConfigId = new int?(this.ItemGrid.Value.ItemData.ItemId),
				BottomText = this.ItemGrid.Value.Count.ToString(),
				IsReceivableVisible = new bool?(flag),
				IsReceivedVisible = new bool?(flag2),
				IsRedDotVisible = new bool?(flag)
			};
			this.ItemGridGrid.Apply<PropSmallItemGrid>(parameters);
			this.ItemGridGrid.SetLockBlackVisible(lockBlackVisible);
		}

		// Token: 0x0603ACDF RID: 240863 RVA: 0x00EE9A78 File Offset: 0x00EE7C78
		[NullableContext(1)]
		private void OnClickedGrid(MediumItemGridExtendCallback cb)
		{
			KurotatoScoreAward value = ConfigBase<KurotatoConfig>.Instance.GetKurotatoScoreAwardConfigById(this.ConfigId).Value;
			if (ControllerBase<KurotatoActivityController>.Instance.GetActivityData().IsScoreRewardCanReceived(value.Id))
			{
				ControllerBase<KurotatoActivityController>.Instance.RequestScoreRewardReceive(this.ReceiveCallback);
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemGrid.Value.ItemData.ItemId, true, null);
		}

		// Token: 0x040213B2 RID: 136114
		private int ConfigId;

		// Token: 0x040213B3 RID: 136115
		[Nullable(2)]
		private SmallItemGrid ItemGridGrid;

		// Token: 0x040213B4 RID: 136116
		private TItem? ItemGrid;

		// Token: 0x040213B5 RID: 136117
		[Nullable(2)]
		public Action ReceiveCallback;

		// Token: 0x0200BB09 RID: 47881
		private enum EGift
		{
			// Token: 0x04039BA6 RID: 236454
			SpriteBackground,
			// Token: 0x04039BA7 RID: 236455
			TextNum,
			// Token: 0x04039BA8 RID: 236456
			ItemGrid
		}
	}
}
