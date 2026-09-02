using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006816 RID: 26646
	[NullableContext(1)]
	[Nullable(0)]
	public class ShipSkinView : UiViewBase
	{
		// Token: 0x060426A3 RID: 272035 RVA: 0x01106B0A File Offset: 0x01104D0A
		public ShipSkinView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060426A4 RID: 272036 RVA: 0x01106B14 File Offset: 0x01104D14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirmBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060426A5 RID: 272037 RVA: 0x01106CA4 File Offset: 0x01104EA4
		protected override void OnStart()
		{
			this.ScrollView = new GenericScrollViewNew<ShipSkinItem, int>(base.GetScrollViewWithScrollbar(2), new Func<ShipSkinItem>(this.OnCreateGrid), null, false, null);
			IEnumerable<FishingShipSkin> allFishingSkinConfig = ConfigBase<FishingConfig>.Instance.GetAllFishingSkinConfig();
			List<int> list = new List<int>();
			foreach (FishingShipSkin fishingShipSkin in allFishingSkinConfig)
			{
				list.Add(fishingShipSkin.Id);
			}
			this.ScrollView.RefreshByData(list, delegate
			{
				this.SelectShipSkinId = ModelBase<FishingModel>.Instance.CurrentShipSkin;
				List<ShipSkinItem> scrollItemList = this.ScrollView.GetScrollItemList();
				foreach (ShipSkinItem shipSkinItem in scrollItemList)
				{
					if (shipSkinItem.SkinId == this.SelectShipSkinId)
					{
						shipSkinItem.SelectToggle();
						return;
					}
				}
				ShipSkinItem shipSkinItem2 = scrollItemList.ElementAtOrDefault(0);
				if (shipSkinItem2 == null)
				{
					return;
				}
				shipSkinItem2.SelectToggle();
			}, false);
		}

		// Token: 0x060426A6 RID: 272038 RVA: 0x01106D3C File Offset: 0x01104F3C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingShipSkinChangeSuccess, new Action(this.FishingShipSkinChangeSuccess));
		}

		// Token: 0x060426A7 RID: 272039 RVA: 0x01106D5A File Offset: 0x01104F5A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingShipSkinChangeSuccess, new Action(this.FishingShipSkinChangeSuccess));
		}

		// Token: 0x060426A8 RID: 272040 RVA: 0x01106D78 File Offset: 0x01104F78
		private void FishingShipSkinChangeSuccess()
		{
			base.CloseMe(null);
		}

		// Token: 0x060426A9 RID: 272041 RVA: 0x01106D84 File Offset: 0x01104F84
		private void RefreshView(int skinId)
		{
			this.SelectShipSkinId = skinId;
			FishingShipSkin fishingShipSkinConfig = ConfigBase<FishingConfig>.Instance.GetFishingShipSkinConfig(skinId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), fishingShipSkinConfig.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), fishingShipSkinConfig.DesText, Array.Empty<object>());
			if (ModelBase<FishingModel>.Instance.UnlockShipSkin.Contains(this.SelectShipSkinId))
			{
				base.GetButton(6).RootUIComp.Get().SetUIActive(true);
				base.GetItem(7).SetUIActive(false);
			}
			else
			{
				base.GetButton(6).RootUIComp.Get().SetUIActive(false);
				base.GetItem(7).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), fishingShipSkinConfig.LockText, Array.Empty<object>());
			}
			this.ReadItemNewFlag();
		}

		// Token: 0x060426AA RID: 272042 RVA: 0x01106E68 File Offset: 0x01105068
		private ShipSkinItem OnCreateGrid()
		{
			return new ShipSkinItem
			{
				ClickFunc = new Action<UUIExtendToggle, int>(this.OnClickShipSkinItem)
			};
		}

		// Token: 0x060426AB RID: 272043 RVA: 0x01106E81 File Offset: 0x01105081
		private void OnClickShipSkinItem(UUIExtendToggle toggle, int skinId)
		{
			UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
			if (currentSelectToggle != null)
			{
				currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentSelectToggle = toggle;
			this.RefreshView(skinId);
		}

		// Token: 0x060426AC RID: 272044 RVA: 0x01106EA7 File Offset: 0x011050A7
		private void OnClickConfirmBtn()
		{
			ControllerBase<FishingController>.Instance.RequestFishingShipSkinChange(this.SelectShipSkinId);
		}

		// Token: 0x060426AD RID: 272045 RVA: 0x01106EBC File Offset: 0x011050BC
		private void ReadItemNewFlag()
		{
			if (!ModelBase<FishingModel>.Instance.UnlockShipSkin.Contains(this.SelectShipSkinId))
			{
				return;
			}
			ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.FishingShipSkinRecord, this.SelectShipSkinId);
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.FishingShipSkinRecord);
			Singleton<EventSystem>.Instance.Emit(EEventName.FishingShipSkinClick);
		}

		// Token: 0x04024FA7 RID: 151463
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<ShipSkinItem, int> ScrollView;

		// Token: 0x04024FA8 RID: 151464
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x04024FA9 RID: 151465
		private int SelectShipSkinId;

		// Token: 0x0200C84B RID: 51275
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DA2D RID: 252461
			public const int TitleText = 0;

			// Token: 0x0403DA2E RID: 252462
			public const int DesText = 1;

			// Token: 0x0403DA2F RID: 252463
			public const int ShipSkinScrollView = 2;

			// Token: 0x0403DA30 RID: 252464
			public const int ShipSkinLoopScrollItem = 3;

			// Token: 0x0403DA31 RID: 252465
			public const int ShipSkinNameText = 4;

			// Token: 0x0403DA32 RID: 252466
			public const int EffectText = 5;

			// Token: 0x0403DA33 RID: 252467
			public const int ConfirmBtn = 6;

			// Token: 0x0403DA34 RID: 252468
			public const int LockItem = 7;

			// Token: 0x0403DA35 RID: 252469
			public const int LockText = 8;
		}
	}
}
