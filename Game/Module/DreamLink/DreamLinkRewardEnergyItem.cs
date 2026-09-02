using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DBD RID: 23997
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DreamLinkRewardEnergyItem : GridProxyAbstract<DreamLinkRewardData>
	{
		// Token: 0x0603C6B1 RID: 247473 RVA: 0x00F564D0 File Offset: 0x00F546D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C6B2 RID: 247474 RVA: 0x00F5663C File Offset: 0x00F5483C
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(6), new Func<ActivitySmallItemGrid>(this.InitGridItem), null, false, null);
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x0603C6B3 RID: 247475 RVA: 0x00F56691 File Offset: 0x00F54891
		private ActivitySmallItemGrid InitGridItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x0603C6B4 RID: 247476 RVA: 0x00F56698 File Offset: 0x00F54898
		public override void Refresh(DreamLinkRewardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RogueWhiteCatReward? energyRewardConfig = ConfigBase<DreamLinkConfig>.Instance.GetEnergyRewardConfig(data.Id);
			if (energyRewardConfig == null)
			{
				return;
			}
			bool uiactive = data.Status == EActivityTaskState.Active;
			bool flag = data.Status == EActivityTaskState.FinishedAndClaimed;
			bool uiactive2 = data.Status == EActivityTaskState.FinishedAndUnclaimed;
			this.RefreshReward(energyRewardConfig.Value.DropId, flag);
			base.GetText(3).SetText(energyRewardConfig.Value.NeedEnergy.ToString(), true);
			base.GetText(7).SetUIActive(uiactive);
			base.GetItem(2).SetUIActive(flag);
			base.GetButton(1).RootUIComp.Get().SetUIActive(uiactive2);
		}

		// Token: 0x0603C6B5 RID: 247477 RVA: 0x00F56757 File Offset: 0x00F54957
		public void SetBtnClickCallback(Action callback)
		{
			this.BtnClickCb = callback;
		}

		// Token: 0x0603C6B6 RID: 247478 RVA: 0x00F56760 File Offset: 0x00F54960
		private void RefreshReward(int dropId, bool hasClaimed)
		{
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
			List<IItemGridData> list = new List<IItemGridData>();
			foreach (TItem item in dropPackagePreviewItemList)
			{
				IItemGridData item2 = new ItemGridData
				{
					Item = item,
					HasClaimed = hasClaimed
				};
				list.Add(item2);
			}
			this.RewardScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x0603C6B7 RID: 247479 RVA: 0x00F567E0 File Offset: 0x00F549E0
		private void OnClickGetButton()
		{
			Action btnClickCb = this.BtnClickCb;
			if (btnClickCb == null)
			{
				return;
			}
			btnClickCb();
		}

		// Token: 0x04021F78 RID: 139128
		[Nullable(2)]
		protected DreamLinkRewardData Data;

		// Token: 0x04021F79 RID: 139129
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x04021F7A RID: 139130
		[Nullable(2)]
		private Action BtnClickCb;

		// Token: 0x0200BE0C RID: 48652
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A823 RID: 239651
			public const int Button = 0;

			// Token: 0x0403A824 RID: 239652
			public const int RewardButton = 1;

			// Token: 0x0403A825 RID: 239653
			public const int PanelDone = 2;

			// Token: 0x0403A826 RID: 239654
			public const int Text = 3;

			// Token: 0x0403A827 RID: 239655
			public const int PanelLock = 4;

			// Token: 0x0403A828 RID: 239656
			public const int TextLock = 5;

			// Token: 0x0403A829 RID: 239657
			public const int RewardLayout = 6;

			// Token: 0x0403A82A RID: 239658
			public const int TextGoing = 7;
		}
	}
}
