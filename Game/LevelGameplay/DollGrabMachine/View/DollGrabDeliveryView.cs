using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F14 RID: 28436
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabDeliveryView : UiViewBase
	{
		// Token: 0x06044E04 RID: 282116 RVA: 0x011EC635 File Offset: 0x011EA835
		public DollGrabDeliveryView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044E05 RID: 282117 RVA: 0x011EC640 File Offset: 0x011EA840
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUITexture)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickedConfirmButton)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickedBackButton))
			};
		}

		// Token: 0x06044E06 RID: 282118 RVA: 0x011EC7D0 File Offset: 0x011EA9D0
		protected override void OnStart()
		{
			UUILayoutBase layout = base.GetItem(3).GetOwner().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase;
			this.RewardItemScrollView = new GenericLayout<DollCollectSmallItemGrid, IDollRewardItemData>(layout, new Func<DollCollectSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
			this.ProgressBarSprite = base.GetSprite(0);
			this.Refresh();
		}

		// Token: 0x06044E07 RID: 282119 RVA: 0x011EC82C File Offset: 0x011EAA2C
		private void Refresh()
		{
			this.RefreshProgressBar();
			this.RefreshReward();
			this.RefreshConfirmButton();
		}

		// Token: 0x06044E08 RID: 282120 RVA: 0x011EC840 File Offset: 0x011EAA40
		private void RefreshReward()
		{
			Dictionary<int, IDollRewardItemData> dictionary = new Dictionary<int, IDollRewardItemData>();
			List<IShowcaseDeliveryReward> deliveryRewards = ControllerBase<DollGrabShowcaseController>.Instance.DeliveryRewards;
			if (deliveryRewards == null)
			{
				this.RewardItemScrollView.SetActive(false);
				return;
			}
			IDollCollectData collectData = ControllerBase<DollGrabShowcaseController>.Instance.GetCollectData();
			if (collectData == null)
			{
				return;
			}
			int num = 0;
			List<int> list = new List<int>();
			foreach (IShowcaseDeliveryReward showcaseDeliveryReward in deliveryRewards)
			{
				num += showcaseDeliveryReward.AchievedDollCount;
				list.Add(showcaseDeliveryReward.DropId);
				Dictionary<int, int> dropPackagePreview = ConfigBase<RewardConfig>.Instance.GetDropPackagePreview(showcaseDeliveryReward.DropId);
				if (dropPackagePreview != null && dropPackagePreview.Count > 0)
				{
					foreach (KeyValuePair<int, int> keyValuePair in dropPackagePreview)
					{
						int num2;
						int num3;
						keyValuePair.Deconstruct(out num2, out num3);
						int num4 = num2;
						int num5 = num3;
						if (!dictionary.ContainsKey(num4))
						{
							dictionary.Add(num4, new IDollRewardItemData
							{
								ItemInfo = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num4),
								Count = num5
							});
						}
						else
						{
							dictionary[num4].Count += num5;
						}
					}
				}
			}
			bool flag = collectData.CurrentCollectItemCount >= num;
			List<IDollRewardItemData> list2 = new List<IDollRewardItemData>();
			foreach (IDollRewardItemData item in dictionary.Values)
			{
				list2.Add(item);
			}
			this.RewardItemScrollView.RefreshByData(list2, null, false);
			if (flag)
			{
				int displayGridNum = this.RewardItemScrollView.GetDisplayGridNum();
				for (int i = 0; i < displayGridNum; i++)
				{
					this.RewardItemScrollView.GetLayoutItemByIndex(i).SetReceivableVisible(true);
				}
			}
		}

		// Token: 0x06044E09 RID: 282121 RVA: 0x011ECA3C File Offset: 0x011EAC3C
		private DollCollectSmallItemGrid OnCreateRewardItem()
		{
			DollCollectSmallItemGrid dollCollectSmallItemGrid = new DollCollectSmallItemGrid();
			dollCollectSmallItemGrid.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleRelease));
			dollCollectSmallItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			return dollCollectSmallItemGrid;
		}

		// Token: 0x06044E0A RID: 282122 RVA: 0x011ECA7C File Offset: 0x011EAC7C
		private void OnExtendToggleRelease(MediumItemGridExtendCallback callback)
		{
			if (!callback.MediumItemGrid.IsHover)
			{
				return;
			}
			IDollRewardItemData dollRewardItemData = callback.Data as IDollRewardItemData;
			if (dollRewardItemData == null)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(dollRewardItemData.ItemInfo.Id, true, null);
		}

		// Token: 0x06044E0B RID: 282123 RVA: 0x011ECAC0 File Offset: 0x011EACC0
		private void RefreshProgressBar()
		{
			IDollCollectData collectData = ControllerBase<DollGrabShowcaseController>.Instance.GetCollectData();
			if (collectData == null)
			{
				return;
			}
			int currentCollectItemCount = collectData.CurrentCollectItemCount;
			int totalCollectItemCount = collectData.TotalCollectItemCount;
			UUIText text = base.GetText(2);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentCollectItemCount);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(totalCollectItemCount);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUISprite progressBarSprite = this.ProgressBarSprite;
			if (progressBarSprite != null)
			{
				progressBarSprite.SetFillAmount((totalCollectItemCount == 0) ? 0f : ((float)currentCollectItemCount / (float)totalCollectItemCount));
			}
			UUIItem item = base.GetItem(13);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(currentCollectItemCount >= totalCollectItemCount);
		}

		// Token: 0x06044E0C RID: 282124 RVA: 0x011ECB64 File Offset: 0x011EAD64
		private void RefreshConfirmButton()
		{
			IDollCollectData collectData = ControllerBase<DollGrabShowcaseController>.Instance.GetCollectData();
			if (collectData == null)
			{
				return;
			}
			if (collectData.CurrentCollectCount >= collectData.TotalCollectCount)
			{
				UUIText text = base.GetText(5);
				if (text != null)
				{
					text.ShowTextNew("KClawDeliver_Btn_Complete_Text");
				}
				UUIButtonComponent button = base.GetButton(4);
				if (button != null)
				{
					button.SetSelfInteractive(false);
				}
				object obj;
				if (button == null)
				{
					obj = null;
				}
				else
				{
					AActor owner = button.GetOwner();
					obj = ((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null);
				}
				UUIItem uuiitem = obj as UUIItem;
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(false);
				}
				this.RefreshCountText(0);
				return;
			}
			int deliveryItemCount = this.GetDeliveryItemCount();
			this.RefreshCountText(deliveryItemCount);
			if (deliveryItemCount > 0)
			{
				UUIText text2 = base.GetText(5);
				if (text2 != null)
				{
					text2.ShowTextNew("KClawDeliver_Btn_Text");
				}
				UUIButtonComponent button2 = base.GetButton(4);
				if (button2 == null)
				{
					return;
				}
				button2.SetSelfInteractive(true);
				return;
			}
			else
			{
				UUIText text3 = base.GetText(5);
				if (text3 != null)
				{
					text3.ShowTextNew("KClawDeliver_Btn_Lack_Text");
				}
				UUIButtonComponent button3 = base.GetButton(4);
				if (button3 == null)
				{
					return;
				}
				button3.SetSelfInteractive(false);
				return;
			}
		}

		// Token: 0x06044E0D RID: 282125 RVA: 0x011ECC60 File Offset: 0x011EAE60
		private int GetDeliveryItemCount()
		{
			int num = 0;
			foreach (int itemConfigId in ControllerBase<DollGrabShowcaseController>.Instance.GetShowcaseBindingItemIds())
			{
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemConfigId, 0) > 0)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06044E0E RID: 282126 RVA: 0x011ECCC8 File Offset: 0x011EAEC8
		private void RefreshCountText(int count)
		{
			UUIText text = base.GetText(7);
			if (text == null)
			{
				return;
			}
			text.SetText(count.ToString(), true);
		}

		// Token: 0x06044E0F RID: 282127 RVA: 0x011ECCE4 File Offset: 0x011EAEE4
		private void OnClickedConfirmButton()
		{
			if (this.IsRequesting)
			{
				return;
			}
			this.IsRequesting = true;
			UUIButtonComponent button = base.GetButton(4);
			if (button != null)
			{
				button.SetSelfInteractive(false);
			}
			UUIButtonComponent button2 = base.GetButton(9);
			if (button2 != null)
			{
				button2.SetSelfInteractive(false);
			}
			Singleton<EventSystem>.Instance.Once<bool, bool>(EEventName.OnDollGrabMachineDelivery, new Action<bool, bool>(this.OnDollGrabMachineDelivery));
			Singleton<EventSystem>.Instance.Once<bool>(EEventName.OnDollGrabMachineDeliveryFinish, new Action<bool>(this.OnDollGrabMachineDeliveryFinish));
			ControllerBase<DollGrabShowcaseController>.Instance.OnClickDelivery();
		}

		// Token: 0x06044E10 RID: 282128 RVA: 0x011ECD6A File Offset: 0x011EAF6A
		private void OnDollGrabMachineDelivery(bool isAlreadyFirst, bool isComplete)
		{
			this.IsRequesting = false;
			this.Refresh();
		}

		// Token: 0x06044E11 RID: 282129 RVA: 0x011ECD79 File Offset: 0x011EAF79
		private void OnDollGrabMachineDeliveryFinish(bool isSuccess)
		{
			if (isSuccess)
			{
				ControllerBase<DollGrabShowcaseController>.Instance.StartDollGrabShowcaseViewByDelivery();
				return;
			}
			base.GetButton(4).SetSelfInteractive(true);
			base.GetButton(9).SetSelfInteractive(true);
		}

		// Token: 0x06044E12 RID: 282130 RVA: 0x011ECDA4 File Offset: 0x011EAFA4
		private void OnClickedBackButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x04026638 RID: 157240
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DollCollectSmallItemGrid, IDollRewardItemData> RewardItemScrollView;

		// Token: 0x04026639 RID: 157241
		[Nullable(2)]
		private UUISprite ProgressBarSprite;

		// Token: 0x0402663A RID: 157242
		private bool IsRequesting;
	}
}
