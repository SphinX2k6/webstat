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
	// Token: 0x0200675D RID: 26461
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LinkageRewardRewardItem : GridProxyAbstract<TimePointRewardData>
	{
		// Token: 0x06041F61 RID: 270177 RVA: 0x010EC4D8 File Offset: 0x010EA6D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041F62 RID: 270178 RVA: 0x010EC688 File Offset: 0x010EA888
		protected override UniTask OnBeforeStartAsync()
		{
			LinkageRewardRewardItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LinkageRewardRewardItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041F63 RID: 270179 RVA: 0x010EC6CC File Offset: 0x010EA8CC
		[NullableContext(1)]
		public override void Refresh(TimePointRewardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GridIndex = gridIndex;
			this.ClearRewardVisual();
			if (data == null)
			{
				return;
			}
			LinkageReward? byId = ConfigBase<LinkageRewardActivityConfig>.Instance.GetById(data.Id);
			int num = (byId != null) ? byId.GetValueOrDefault().DropId : 0;
			if (num <= 0)
			{
				return;
			}
			ETimePointRewardState rewardState = data.RewardState;
			this.ApplyRewardState(rewardState, gridIndex);
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

		// Token: 0x06041F64 RID: 270180 RVA: 0x010EC7E0 File Offset: 0x010EA9E0
		public UUIItem GetNavigationFocusItem()
		{
			UUIButtonComponent button = base.GetButton(0);
			UUIItem uuiitem = (button != null) ? button.RootUIComp.Get() : null;
			if (uuiitem != null && uuiitem.IsValid())
			{
				return uuiitem;
			}
			SmallItemGrid rewardItemGrid = this.RewardItemGrid;
			UUIItem uuiitem2;
			if (rewardItemGrid == null)
			{
				uuiitem2 = null;
			}
			else
			{
				UUIExtendToggle itemGridExtendToggle = rewardItemGrid.GetItemGridExtendToggle();
				uuiitem2 = ((itemGridExtendToggle != null) ? itemGridExtendToggle.RootUIComp.Get() : null);
			}
			UUIItem uuiitem3 = uuiitem2;
			if (uuiitem3 != null && uuiitem3.IsValid())
			{
				return uuiitem3;
			}
			UUIItem rootItem = base.GetRootItem();
			if (rootItem == null || !rootItem.IsValid())
			{
				return null;
			}
			return rootItem;
		}

		// Token: 0x06041F65 RID: 270181 RVA: 0x010EC860 File Offset: 0x010EAA60
		private void ClearRewardVisual()
		{
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(8);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			UUISprite sprite3 = base.GetSprite(4);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(false);
			}
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(9);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
		}

		// Token: 0x06041F66 RID: 270182 RVA: 0x010EC908 File Offset: 0x010EAB08
		private void ApplyRewardState(ETimePointRewardState state, int gridIndex)
		{
			bool uiactive = state == ETimePointRewardState.Lock;
			bool uiactive2 = state == ETimePointRewardState.UnlockAndUnClaimed;
			bool uiactive3 = state == ETimePointRewardState.UnlockAndClaimed;
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetUIActive(uiactive);
			}
			UUIText text = base.GetText(1);
			if (text != null)
			{
				TimePointRewardData data = this.Data;
				long num = (data != null) ? data.RewardTime : 0L;
				text.SetUIActive(num > 0L);
				if (num > 0L)
				{
					string item2 = num.ToString().PadLeft(2, '0');
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Dreamchasers_SignDay", new <>z__ReadOnlySingleElementList<object>(item2));
					LinkageRewardDayTextUtil.ApplyLinkageRewardDayTextStyle(text, state);
				}
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(uiactive2);
			}
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(uiactive2);
			}
			UUIItem item4 = base.GetItem(9);
			if (item4 != null)
			{
				item4.SetUIActive(uiactive2);
			}
			UUIItem item5 = base.GetItem(8);
			if (item5 != null)
			{
				item5.SetUIActive(uiactive3);
			}
			UUISprite sprite3 = base.GetSprite(4);
			if (sprite3 == null)
			{
				return;
			}
			sprite3.SetUIActive(uiactive3);
		}

		// Token: 0x06041F67 RID: 270183 RVA: 0x010ECA0A File Offset: 0x010EAC0A
		private void OnClickedButton()
		{
			this.TryHandleRewardClick();
		}

		// Token: 0x06041F68 RID: 270184 RVA: 0x010ECA12 File Offset: 0x010EAC12
		private void OnClickedGrid()
		{
			this.TryHandleRewardClick();
		}

		// Token: 0x06041F69 RID: 270185 RVA: 0x010ECA1C File Offset: 0x010EAC1C
		private void TryHandleRewardClick()
		{
			TimePointRewardData data = this.Data;
			if (data == null || data.RewardState != ETimePointRewardState.UnlockAndUnClaimed)
			{
				if (this.TipItemConfigId > 0)
				{
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.TipItemConfigId, true, null);
				}
				return;
			}
			Action<int, int, bool> onClickToGet = this.OnClickToGet;
			if (onClickToGet == null)
			{
				return;
			}
			onClickToGet(this.Data.Id, base.GridIndex, false);
		}

		// Token: 0x04024CD2 RID: 150738
		private TimePointRewardData Data;

		// Token: 0x04024CD3 RID: 150739
		private SmallItemGrid RewardItemGrid;

		// Token: 0x04024CD4 RID: 150740
		private int TipItemConfigId;

		// Token: 0x04024CD5 RID: 150741
		public Action<int, int, bool> OnClickToGet;

		// Token: 0x0200C777 RID: 51063
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x0403D68D RID: 251533
			public const int BtnReward = 0;

			// Token: 0x0403D68E RID: 251534
			public const int TxtDay = 1;

			// Token: 0x0403D68F RID: 251535
			public const int SprBgLock = 2;

			// Token: 0x0403D690 RID: 251536
			public const int SprBgSelect = 3;

			// Token: 0x0403D691 RID: 251537
			public const int SprBgFinish = 4;

			// Token: 0x0403D692 RID: 251538
			public const int UiItemItemBaseB = 5;

			// Token: 0x0403D693 RID: 251539
			public const int PnlRectLock = 6;

			// Token: 0x0403D694 RID: 251540
			public const int PnlRectSelect = 7;

			// Token: 0x0403D695 RID: 251541
			public const int PnlRectFinish = 8;

			// Token: 0x0403D696 RID: 251542
			public const int ItemRedDot = 9;
		}
	}
}
