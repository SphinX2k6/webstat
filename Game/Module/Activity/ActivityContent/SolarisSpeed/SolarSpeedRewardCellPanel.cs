using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006395 RID: 25493
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class SolarSpeedRewardCellPanel : GridProxyAbstract<ISolarSpeedRewardCellPanelData>
	{
		// Token: 0x0604003F RID: 262207 RVA: 0x010684FC File Offset: 0x010666FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040040 RID: 262208 RVA: 0x0106860C File Offset: 0x0106680C
		protected override UniTask OnBeforeStartAsync()
		{
			SolarSpeedRewardCellPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SolarSpeedRewardCellPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040041 RID: 262209 RVA: 0x01068650 File Offset: 0x01066850
		public override void Refresh(ISolarSpeedRewardCellPanelData data, bool isSelected, int gridIndex)
		{
			this.OpenParam = data;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), data.TitleTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), data.ProgressTextId, data.ProgressTextArgs);
			ButtonItem buttonItem = this.ButtonItem;
			if (buttonItem != null)
			{
				buttonItem.SetUiActive(data.ButtonActive);
			}
			if (data.ButtonActive)
			{
				ButtonItem buttonItem2 = this.ButtonItem;
				if (buttonItem2 != null)
				{
					buttonItem2.SetFunction(new Action<int>(this.HandleOnClickReward));
				}
				ButtonItem buttonItem3 = this.ButtonItem;
				if (buttonItem3 != null)
				{
					buttonItem3.SetLocalTextNew(data.ButtonTextId, Array.Empty<object>());
				}
			}
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(data.RightActive);
			}
			UUISprite sprite = base.GetSprite(6);
			if (sprite != null)
			{
				sprite.SetUIActive(data.DoneSpriteActive);
			}
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardItems = this.RewardItems;
			if (rewardItems == null)
			{
				return;
			}
			rewardItems.RefreshByData(data.ItemsData.ToList<TItem>(), null, false);
		}

		// Token: 0x06040042 RID: 262210 RVA: 0x01068742 File Offset: 0x01066942
		private CommonItemSmallItemGrid BuildRewardSmallItemGrid()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06040043 RID: 262211 RVA: 0x0106874C File Offset: 0x0106694C
		private void HandleOnClickReward(int _)
		{
			ISolarSpeedRewardCellPanelData solarSpeedRewardCellPanelData = this.OpenParam as ISolarSpeedRewardCellPanelData;
			ControllerBase<ActivitySolarSpeedController>.Instance.RequestTeamParkourRewardRequest(solarSpeedRewardCellPanelData.RewardId);
		}

		// Token: 0x04023F11 RID: 147217
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardItems;

		// Token: 0x04023F12 RID: 147218
		private ButtonItem ButtonItem;

		// Token: 0x0200C3F4 RID: 50164
		[NullableContext(0)]
		private class ERewardCellComponent
		{
			// Token: 0x0403C5AE RID: 247214
			public const int NameText = 0;

			// Token: 0x0403C5AF RID: 247215
			public const int NumberText = 1;

			// Token: 0x0403C5B0 RID: 247216
			public const int ContentLayout = 2;

			// Token: 0x0403C5B1 RID: 247217
			public const int ContentCellItem = 3;

			// Token: 0x0403C5B2 RID: 247218
			public const int ConfirmButtonItem = 4;

			// Token: 0x0403C5B3 RID: 247219
			public const int RightText = 5;

			// Token: 0x0403C5B4 RID: 247220
			public const int DoneSprite = 6;
		}
	}
}
