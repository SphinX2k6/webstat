using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward
{
	// Token: 0x0200675E RID: 26462
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LinkageRewardRewardItemA : GridProxyAbstract<TimePointRewardData>
	{
		// Token: 0x06041F6C RID: 270188 RVA: 0x010ECA90 File Offset: 0x010EAC90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x06041F6D RID: 270189 RVA: 0x010ECBEC File Offset: 0x010EADEC
		protected override UniTask OnBeforeStartAsync()
		{
			LinkageRewardRewardItemA.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LinkageRewardRewardItemA.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041F6E RID: 270190 RVA: 0x010ECC2F File Offset: 0x010EAE2F
		[NullableContext(1)]
		public override void Refresh(TimePointRewardData data, bool isSelected, int gridIndex)
		{
			this.RefreshWithNextState(data, isSelected, gridIndex, false);
		}

		// Token: 0x06041F6F RID: 270191 RVA: 0x010ECC3C File Offset: 0x010EAE3C
		[NullableContext(1)]
		public void RefreshWithNextState(TimePointRewardData data, bool isSelected, int gridIndex, bool hasConnector)
		{
			this.Data = data;
			base.GridIndex = gridIndex;
			UUISprite sprite = base.GetSprite(4);
			UUISprite sprite2 = base.GetSprite(5);
			UUISprite sprite3 = base.GetSprite(6);
			UUIItem item = base.GetItem(8);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			if (sprite3 != null)
			{
				sprite3.SetUIActive(false);
			}
			if (item != null)
			{
				item.SetUIActive(false);
			}
			if (data == null)
			{
				return;
			}
			LinkageReward? byId = ConfigBase<LinkageRewardActivityConfig>.Instance.GetById(data.Id);
			int num = (((byId != null) ? byId.GetValueOrDefault().KeepDropId : 0) > 0) ? byId.Value.KeepDropId : ((byId != null) ? byId.GetValueOrDefault().DropId : 0);
			if (num <= 0)
			{
				return;
			}
			ETimePointRewardState rewardState = data.RewardState;
			this.ApplyConnectorLineState(hasConnector, rewardState > ETimePointRewardState.Lock);
			this.ApplyBackgroundState(rewardState);
			if (sprite != null)
			{
				sprite.SetUIActive(rewardState == ETimePointRewardState.Lock);
			}
			if (sprite2 != null)
			{
				sprite2.SetUIActive(rewardState == ETimePointRewardState.UnlockAndUnClaimed);
			}
			if (sprite3 != null)
			{
				sprite3.SetUIActive(rewardState == ETimePointRewardState.UnlockAndClaimed);
			}
			if (item != null)
			{
				item.SetUIActive(rewardState == ETimePointRewardState.UnlockAndUnClaimed);
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(num);
			if (dropPackagePreviewItemList.Count <= 0 || this.RewardItemGrid == null)
			{
				return;
			}
			TItem titem = dropPackagePreviewItemList[0];
			this.TipItemConfigId = titem.ItemData.ItemId;
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = this.Data,
				ItemConfigId = new int?(titem.ItemData.ItemId),
				BottomText = titem.Count.ToString(),
				IsLockVisible = new bool?(rewardState == ETimePointRewardState.Lock),
				IsReceivableVisible = new bool?(false),
				IsReceivedVisible = new bool?(rewardState == ETimePointRewardState.UnlockAndClaimed)
			};
			this.RewardItemGrid.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x06041F70 RID: 270192 RVA: 0x010ECE14 File Offset: 0x010EB014
		private void ApplyConnectorLineState(bool hasConnector, bool isConnectorCompleted)
		{
			UUISprite[] array = new UUISprite[]
			{
				base.GetSprite(1),
				base.GetSprite(2),
				base.GetSprite(3)
			};
			UUISprite uuisprite = array[1];
			foreach (UUISprite uuisprite2 in array)
			{
				if (uuisprite2 != null)
				{
					uuisprite2.SetUIActive(hasConnector);
				}
			}
			if (!hasConnector || uuisprite == null)
			{
				return;
			}
			FColor changeColor = uuisprite.changeColor;
			foreach (UUISprite uuisprite3 in array)
			{
				if (uuisprite3 != null)
				{
					uuisprite3.changeColor = changeColor;
					uuisprite3.useChangeColor = isConnectorCompleted;
					UUIItem uuiitem = uuisprite3;
					FColor? fcolor = new FColor?(changeColor);
					uuiitem.SetChangeColor(isConnectorCompleted, fcolor);
				}
			}
		}

		// Token: 0x06041F71 RID: 270193 RVA: 0x010ECEBC File Offset: 0x010EB0BC
		private void ApplyBackgroundState(ETimePointRewardState state)
		{
			UUISprite bg = base.GetSprite(0);
			if (bg == null)
			{
				return;
			}
			string resourceId = "SP_CyberWelfareItemABgLock";
			if (state == ETimePointRewardState.UnlockAndUnClaimed)
			{
				resourceId = "SP_CyberWelfareItemABgSelect";
			}
			else if (state == ETimePointRewardState.UnlockAndClaimed)
			{
				resourceId = "SP_CyberWelfareItemABgFinish";
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (string.IsNullOrEmpty(resourcePath))
			{
				return;
			}
			bg.SetUIActive(false);
			this.SetSpriteByPath(resourcePath, bg, false, null, delegate(bool _)
			{
				bg.SetUIActive(true);
			});
		}

		// Token: 0x06041F72 RID: 270194 RVA: 0x010ECF48 File Offset: 0x010EB148
		private void OnClickedGrid()
		{
			TimePointRewardData data = this.Data;
			if (data == null || data.RewardState != ETimePointRewardState.UnlockAndUnClaimed)
			{
				if (this.TipItemConfigId > 0)
				{
					this.TryFocusCurrentItem();
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.TipItemConfigId, true, delegate(bool _, int _)
					{
						TimerSystem.Instance.Next(delegate(float _)
						{
							this.TryFocusCurrentItem();
						}, null, null);
					});
				}
				return;
			}
			Action<int, int, bool> onClickToGet = this.OnClickToGet;
			if (onClickToGet == null)
			{
				return;
			}
			onClickToGet(this.Data.Id, base.GridIndex, true);
		}

		// Token: 0x06041F73 RID: 270195 RVA: 0x010ECFBC File Offset: 0x010EB1BC
		private void TryFocusCurrentItem()
		{
			SmallItemGrid rewardItemGrid = this.RewardItemGrid;
			UUIItem uuiitem;
			if (rewardItemGrid == null)
			{
				uuiitem = null;
			}
			else
			{
				UUIExtendToggle itemGridExtendToggle = rewardItemGrid.GetItemGridExtendToggle();
				uuiitem = ((itemGridExtendToggle != null) ? itemGridExtendToggle.RootUIComp.Get() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null || !uuiitem2.IsValid())
			{
				UUIItem rootItem = base.GetRootItem();
				if (rootItem != null && rootItem.IsValid())
				{
					UiNavigationNewController instance = ControllerBase<UiNavigationNewController>.Instance;
					if (instance == null)
					{
						return;
					}
					instance.SetNavigationFocusForView(rootItem, true, false, false);
				}
				return;
			}
			UiNavigationNewController instance2 = ControllerBase<UiNavigationNewController>.Instance;
			if (instance2 == null)
			{
				return;
			}
			instance2.SetNavigationFocusForView(uuiitem2, true, false, false);
		}

		// Token: 0x04024CD6 RID: 150742
		private TimePointRewardData Data;

		// Token: 0x04024CD7 RID: 150743
		private SmallItemGrid RewardItemGrid;

		// Token: 0x04024CD8 RID: 150744
		private int TipItemConfigId;

		// Token: 0x04024CD9 RID: 150745
		public Action<int, int, bool> OnClickToGet;

		// Token: 0x0200C77A RID: 51066
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x0403D69D RID: 251549
			public const int SprBg = 0;

			// Token: 0x0403D69E RID: 251550
			public const int SprLine = 1;

			// Token: 0x0403D69F RID: 251551
			public const int SprLine2 = 2;

			// Token: 0x0403D6A0 RID: 251552
			public const int SprLine3 = 3;

			// Token: 0x0403D6A1 RID: 251553
			public const int SprLock = 4;

			// Token: 0x0403D6A2 RID: 251554
			public const int SprSelect = 5;

			// Token: 0x0403D6A3 RID: 251555
			public const int SprFinish = 6;

			// Token: 0x0403D6A4 RID: 251556
			public const int ItemBaseB2 = 7;

			// Token: 0x0403D6A5 RID: 251557
			public const int ItemRedDot = 8;
		}
	}
}
