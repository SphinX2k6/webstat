using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059F2 RID: 23026
	public class RewardPopView : UiViewBase
	{
		// Token: 0x0603A566 RID: 238950 RVA: 0x00ECA81E File Offset: 0x00EC8A1E
		[NullableContext(1)]
		public RewardPopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A567 RID: 238951 RVA: 0x00ECA828 File Offset: 0x00EC8A28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnCancel));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnSingleConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnDisable));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A568 RID: 238952 RVA: 0x00ECAA44 File Offset: 0x00EC8C44
		protected override void OnStart()
		{
			RewardPopViewData rewardPopViewData = this.OpenParam as RewardPopViewData;
			if (rewardPopViewData == null)
			{
				return;
			}
			this.Type = rewardPopViewData.RewardPopType.Value;
			this.RewardPopScroll = new GenericScrollView<RewardPopItem>(base.GetScrollViewWithScrollbar(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<RewardPopItem>(this.InitCommonPopItem), null);
			base.GetItem(2).SetUIActive(this.Type == ERewardPopType.Unlock || this.Type == ERewardPopType.StudyFail);
			base.GetItem(4).SetUIActive(this.Type == ERewardPopType.Unlock);
			bool flag = this.Type == ERewardPopType.Cook || Singleton<CommonManager>.Instance.CheckCanShowExpItem().GetValueOrDefault();
			base.GetItem(7).SetUIActive(flag);
			if (flag)
			{
				this.ExpItem = new ExpItem(base.GetItem(7));
			}
			(base.GetButton(8).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(this.Type > ERewardPopType.Unlock);
		}

		// Token: 0x0603A569 RID: 238953 RVA: 0x00ECAB2C File Offset: 0x00EC8D2C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<RewardPopItem> InitCommonPopItem(object data, UUIItem item, int index)
		{
			ICommonPopItemData commonPopItemData = data as ICommonPopItemData;
			if (commonPopItemData == null)
			{
				return null;
			}
			RewardPopItem rewardPopItem = new RewardPopItem(item);
			rewardPopItem.Update(commonPopItemData);
			return new LayoutItem<RewardPopItem>
			{
				Key = index,
				Value = rewardPopItem
			};
		}

		// Token: 0x0603A56A RID: 238954 RVA: 0x00ECAB6B File Offset: 0x00EC8D6B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FixSuccess, new Action(this.OnClose));
		}

		// Token: 0x0603A56B RID: 238955 RVA: 0x00ECAB89 File Offset: 0x00EC8D89
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FixSuccess, new Action(this.OnClose));
		}

		// Token: 0x0603A56C RID: 238956 RVA: 0x00ECABA7 File Offset: 0x00EC8DA7
		protected override void OnBeforeDestroy()
		{
			if (this.RewardPopScroll != null)
			{
				this.RewardPopScroll.ClearChildren();
				this.RewardPopScroll = null;
			}
			if (this.ExpItem != null)
			{
				this.ExpItem.Destroy(null);
				this.ExpItem = null;
			}
		}

		// Token: 0x0603A56D RID: 238957 RVA: 0x00ECABE0 File Offset: 0x00EC8DE0
		protected override void OnAfterShow()
		{
			this.SetTitle();
			this.SetItemScroll();
			switch (this.Type)
			{
			case ERewardPopType.Unlock:
				this.SetInfoText();
				this.RefreshDoubleConfirmButton();
				return;
			case ERewardPopType.Cook:
				this.SetExpItem();
				return;
			case ERewardPopType.Machining:
			case ERewardPopType.Forging:
				break;
			case ERewardPopType.StudyFail:
				this.SetInfoText();
				return;
			case ERewardPopType.Compose:
				if (Singleton<CommonManager>.Instance.CheckCanShowExpItem().GetValueOrDefault())
				{
					this.SetExpItem();
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0603A56E RID: 238958 RVA: 0x00ECAC54 File Offset: 0x00EC8E54
		private void SetTitle()
		{
			switch (this.Type)
			{
			case ERewardPopType.Unlock:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "UnlockTitle", Array.Empty<object>());
				return;
			case ERewardPopType.Cook:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "GetItem", Array.Empty<object>());
				return;
			case ERewardPopType.Machining:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "GetItem", Array.Empty<object>());
				return;
			case ERewardPopType.StudyFail:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "StudyFail", Array.Empty<object>());
				return;
			case ERewardPopType.Compose:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "ComposeSuccess", Array.Empty<object>());
				return;
			case ERewardPopType.Forging:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "ForgingSuccess", Array.Empty<object>());
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A56F RID: 238959 RVA: 0x00ECAD30 File Offset: 0x00EC8F30
		private void SetItemScroll()
		{
			if (this.Type == ERewardPopType.Unlock)
			{
				List<ICommonPopItemData> list = new List<ICommonPopItemData>();
				CookFixTool cookFixToolById = ConfigBase<CookConfig>.Instance.GetCookFixToolById(Singleton<CommonManager>.Instance.GetCurrentFixId());
				for (int i = 0; i < cookFixToolById.ItemsLength; i++)
				{
					DicIntInt? dicIntInt = cookFixToolById.Items(i);
					if (dicIntInt != null)
					{
						int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(dicIntInt.Value.Key, 0);
						list.Add(new ICommonPopItemData
						{
							ItemId = dicIntInt.Value.Key,
							ItemNum = itemCountByConfigId
						});
					}
				}
				this.RewardPopScroll.RefreshByData<ICommonPopItemData>(list, null);
				return;
			}
			this.RewardPopScroll.RefreshByData<ICommonPopItemData>(Singleton<CommonManager>.Instance.GetCommonItemList(), null);
		}

		// Token: 0x0603A570 RID: 238960 RVA: 0x00ECAE04 File Offset: 0x00EC9004
		private void SetInfoText()
		{
			if (this.Type == ERewardPopType.Unlock)
			{
				CookFixTool cookFixToolById = ConfigBase<CookConfig>.Instance.GetCookFixToolById(Singleton<CommonManager>.Instance.GetCurrentFixId());
				string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookFixToolById.Description);
				int num = 0;
				string text = string.Empty;
				cookFixToolById.Items(0);
				for (int i = 0; i < cookFixToolById.ItemsLength; i++)
				{
					DicIntInt? dicIntInt = cookFixToolById.Items(i);
					if (dicIntInt != null)
					{
						num = dicIntInt.Value.Value;
						ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(dicIntInt.Value.Key);
						text = ConfigBase<CookConfig>.Instance.GetLocalText(config.Value.Name);
					}
				}
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "FixText", new <>z__ReadOnlyArray<object>(new object[]
				{
					num,
					text,
					localText
				}));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "MaciningStudyFail", Array.Empty<object>());
		}

		// Token: 0x0603A571 RID: 238961 RVA: 0x00ECAF14 File Offset: 0x00EC9114
		private void SetExpItem()
		{
			int? sumExpByLevel = Singleton<CommonManager>.Instance.GetSumExpByLevel(Singleton<CommonManager>.Instance.GetCurrentRewardLevel().Value);
			int? currentRewardTotalProficiency = Singleton<CommonManager>.Instance.GetCurrentRewardTotalProficiency();
			this.ExpItem.SetExpSprite(currentRewardTotalProficiency.Value, sumExpByLevel.Value);
			this.ExpItem.SetAddText(Singleton<CommonManager>.Instance.GetCurrentRewardAddExp().Value);
			this.ExpItem.SetLastText(currentRewardTotalProficiency.Value);
			this.ExpItem.SetSumText(sumExpByLevel.Value);
		}

		// Token: 0x0603A572 RID: 238962 RVA: 0x00ECAFA4 File Offset: 0x00EC91A4
		private void RefreshDoubleConfirmButton()
		{
			UUIInteractionGroup uuiinteractionGroup = (base.GetButton(6).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup;
			bool flag = Singleton<CommonManager>.Instance.CheckCanFix();
			uuiinteractionGroup.SetInteractable(flag);
			(base.GetButton(9).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(!flag);
		}

		// Token: 0x0603A573 RID: 238963 RVA: 0x00ECB007 File Offset: 0x00EC9207
		private void OnClose()
		{
			this.DoClose();
		}

		// Token: 0x0603A574 RID: 238964 RVA: 0x00ECB00F File Offset: 0x00EC920F
		private void OnCancel()
		{
			this.DoClose();
		}

		// Token: 0x0603A575 RID: 238965 RVA: 0x00ECB017 File Offset: 0x00EC9217
		private void OnConfirm()
		{
			Singleton<CommonManager>.Instance.SendFixToolRequest();
			this.DoClose();
		}

		// Token: 0x0603A576 RID: 238966 RVA: 0x00ECB029 File Offset: 0x00EC9229
		private void OnSingleConfirm()
		{
			this.DoClose();
		}

		// Token: 0x0603A577 RID: 238967 RVA: 0x00ECB034 File Offset: 0x00EC9234
		private void DoClose()
		{
			ERewardPopType type = this.Type;
			if (type == ERewardPopType.Unlock)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CookPopFixView, null);
				return;
			}
			if (type == ERewardPopType.Compose)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RewardPopView, null);
				return;
			}
			if (type != ERewardPopType.Forging)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CookPopView, null);
				return;
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.RewardPopView, null);
		}

		// Token: 0x0603A578 RID: 238968 RVA: 0x00ECB098 File Offset: 0x00EC9298
		private void OnDisable()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MaterialShort", Array.Empty<object>());
		}

		// Token: 0x040210A9 RID: 135337
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollView<RewardPopItem> RewardPopScroll;

		// Token: 0x040210AA RID: 135338
		[Nullable(2)]
		private ExpItem ExpItem;

		// Token: 0x040210AB RID: 135339
		private ERewardPopType Type;

		// Token: 0x0200B9C2 RID: 47554
		private class ERewardPopDefine
		{
			// Token: 0x04039660 RID: 235104
			public const int TitleText = 0;

			// Token: 0x04039661 RID: 235105
			public const int ItemScrollView = 1;

			// Token: 0x04039662 RID: 235106
			public const int InfoTextItem = 2;

			// Token: 0x04039663 RID: 235107
			public const int InfoText = 3;

			// Token: 0x04039664 RID: 235108
			public const int DoubleButtonItem = 4;

			// Token: 0x04039665 RID: 235109
			public const int CancelButton = 5;

			// Token: 0x04039666 RID: 235110
			public const int ConfirmButton = 6;

			// Token: 0x04039667 RID: 235111
			public const int ExpItem = 7;

			// Token: 0x04039668 RID: 235112
			public const int SingleConfirmButton = 8;

			// Token: 0x04039669 RID: 235113
			public const int DisableButton = 9;
		}
	}
}
