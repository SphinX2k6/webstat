using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DC0 RID: 24000
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkRewardSpecialItem : UiPanelBase
	{
		// Token: 0x0603C6C4 RID: 247492 RVA: 0x00F56C7D File Offset: 0x00F54E7D
		public DreamLinkRewardSpecialItem(DreamLinkRewardData rewardData)
		{
			this.RewardData = rewardData;
		}

		// Token: 0x0603C6C5 RID: 247493 RVA: 0x00F56C8C File Offset: 0x00F54E8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C6C6 RID: 247494 RVA: 0x00F56D79 File Offset: 0x00F54F79
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<DreamLinkRewardSmallGrid, IDreamLinkRewardGridData>(base.GetScrollViewWithScrollbar(4), new Func<DreamLinkRewardSmallGrid>(this.InitGridItem), null, false, null);
		}

		// Token: 0x0603C6C7 RID: 247495 RVA: 0x00F56D9C File Offset: 0x00F54F9C
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0603C6C8 RID: 247496 RVA: 0x00F56DA4 File Offset: 0x00F54FA4
		private DreamLinkRewardSmallGrid InitGridItem()
		{
			return new DreamLinkRewardSmallGrid();
		}

		// Token: 0x0603C6C9 RID: 247497 RVA: 0x00F56DAB File Offset: 0x00F54FAB
		public void Refresh()
		{
			this.RefreshProgress();
			this.RefreshReward();
		}

		// Token: 0x0603C6CA RID: 247498 RVA: 0x00F56DBC File Offset: 0x00F54FBC
		private void RefreshProgress()
		{
			int current = this.RewardData.Current;
			int target = this.RewardData.Target;
			UUIText text = base.GetText(2);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.GetSprite(3).SetFillAmount((float)current / (float)target);
		}

		// Token: 0x0603C6CB RID: 247499 RVA: 0x00F56E2C File Offset: 0x00F5502C
		private void RefreshReward()
		{
			RogueLimitTimeReward? limitTimeRewardConfig = ConfigBase<DreamLinkConfig>.Instance.GetLimitTimeRewardConfig(this.RewardData.Id);
			if (limitTimeRewardConfig == null)
			{
				return;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(limitTimeRewardConfig.Value.TargetReward);
			IDreamLinkRewardGridData[] array = new IDreamLinkRewardGridData[dropPackagePreviewItemList.Count];
			for (int i = 0; i < dropPackagePreviewItemList.Count; i++)
			{
				TItem item = dropPackagePreviewItemList[i];
				array[i] = new DreamLinkRewardGridData
				{
					RewardId = this.RewardData.Id,
					Item = item,
					Status = this.RewardData.Status,
					ReceiveDelegate = new Action(this.OnReceiveDelegate)
				};
			}
			this.RewardScrollView.RefreshByData(array.ToList<IDreamLinkRewardGridData>(), null, false);
		}

		// Token: 0x0603C6CC RID: 247500 RVA: 0x00F56EF6 File Offset: 0x00F550F6
		private void OnReceiveDelegate()
		{
			ControllerBase<DreamLinkController>.Instance.LimitTimeRewardRequest(this.RewardData.Id);
		}

		// Token: 0x04021F7F RID: 139135
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<DreamLinkRewardSmallGrid, IDreamLinkRewardGridData> RewardScrollView;

		// Token: 0x04021F80 RID: 139136
		protected DreamLinkRewardData RewardData;

		// Token: 0x0200BE0E RID: 48654
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A834 RID: 239668
			public const int Panel = 0;

			// Token: 0x0403A835 RID: 239669
			public const int TxtTitle = 1;

			// Token: 0x0403A836 RID: 239670
			public const int TxtProgress = 2;

			// Token: 0x0403A837 RID: 239671
			public const int SpriteProgress = 3;

			// Token: 0x0403A838 RID: 239672
			public const int RewardLayout = 4;

			// Token: 0x0403A839 RID: 239673
			public const int RewardItem = 5;
		}
	}
}
