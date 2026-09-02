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
	// Token: 0x02005DBE RID: 23998
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DreamLinkRewardLimitTimeItem : GridProxyAbstract<DreamLinkRewardData>
	{
		// Token: 0x0603C6B9 RID: 247481 RVA: 0x00F567FC File Offset: 0x00F549FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C6BA RID: 247482 RVA: 0x00F5698C File Offset: 0x00F54B8C
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(6), new Func<ActivitySmallItemGrid>(this.InitGridItem), null, false, null);
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x0603C6BB RID: 247483 RVA: 0x00F569E1 File Offset: 0x00F54BE1
		private ActivitySmallItemGrid InitGridItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x0603C6BC RID: 247484 RVA: 0x00F569E8 File Offset: 0x00F54BE8
		public override void Refresh(DreamLinkRewardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RogueLimitTimeReward? limitTimeRewardConfig = ConfigBase<DreamLinkConfig>.Instance.GetLimitTimeRewardConfig(data.Id);
			if (limitTimeRewardConfig == null)
			{
				return;
			}
			bool uiactive = data.Status == EActivityTaskState.Active;
			bool flag = data.Status == EActivityTaskState.FinishedAndClaimed;
			bool uiactive2 = data.Status == EActivityTaskState.FinishedAndUnclaimed;
			this.RefreshReward(limitTimeRewardConfig.Value.TargetReward, flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), limitTimeRewardConfig.Value.TargetName, Array.Empty<object>());
			base.GetText(7).SetUIActive(uiactive);
			base.GetItem(2).SetUIActive(flag);
			base.GetButton(1).RootUIComp.Get().SetUIActive(uiactive2);
			int current = data.Current;
			int target = data.Target;
			UUIText text = base.GetText(8);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(current, target));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603C6BD RID: 247485 RVA: 0x00F56AFC File Offset: 0x00F54CFC
		private void RefreshReward(int dropId, bool hasClaimed)
		{
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
			List<IItemGridData> list = new List<IItemGridData>();
			foreach (TItem item in dropPackagePreviewItemList)
			{
				ItemGridData item2 = new ItemGridData
				{
					Item = item,
					HasClaimed = hasClaimed
				};
				list.Add(item2);
			}
			this.RewardScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x0603C6BE RID: 247486 RVA: 0x00F56B7C File Offset: 0x00F54D7C
		private void OnClickGetButton()
		{
			ControllerBase<DreamLinkController>.Instance.LimitTimeRewardRequest(this.Data.Id);
		}

		// Token: 0x04021F7B RID: 139131
		[Nullable(2)]
		protected DreamLinkRewardData Data;

		// Token: 0x04021F7C RID: 139132
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x0200BE0D RID: 48653
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A82B RID: 239659
			public const int Button = 0;

			// Token: 0x0403A82C RID: 239660
			public const int RewardButton = 1;

			// Token: 0x0403A82D RID: 239661
			public const int PanelDone = 2;

			// Token: 0x0403A82E RID: 239662
			public const int Text = 3;

			// Token: 0x0403A82F RID: 239663
			public const int PanelLock = 4;

			// Token: 0x0403A830 RID: 239664
			public const int TextLock = 5;

			// Token: 0x0403A831 RID: 239665
			public const int RewardLayout = 6;

			// Token: 0x0403A832 RID: 239666
			public const int TextGoing = 7;

			// Token: 0x0403A833 RID: 239667
			public const int TextProgress = 8;
		}
	}
}
