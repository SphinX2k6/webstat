using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E1C RID: 24092
	public class CookPopView : UiViewBase
	{
		// Token: 0x0603C9D9 RID: 248281 RVA: 0x00F64863 File Offset: 0x00F62A63
		[NullableContext(1)]
		public CookPopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C9DA RID: 248282 RVA: 0x00F6486C File Offset: 0x00F62A6C
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
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(delegate()
			{
				this.OnCancel();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(delegate()
			{
				this.OnConfirm();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(delegate()
			{
				this.OnSingleConfirm();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(delegate()
			{
				this.OnDisable();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C9DB RID: 248283 RVA: 0x00F64A88 File Offset: 0x00F62C88
		protected override void OnStart()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
			}
			CookRewardPopData cookRewardPopData = this.OpenParam as CookRewardPopData;
			this.Type = cookRewardPopData.CookRewardPopType;
			this.CookPopScroll = new GenericScrollView<CookPopItem>(base.GetScrollViewWithScrollbar(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CookPopItem>(this.InitCookPopItem), null);
			base.GetItem(2).SetUIActive(this.Type == ECookPopType.Unlock || this.Type == ECookPopType.StudyFail);
			base.GetItem(4).SetUIActive(this.Type == ECookPopType.Unlock);
			bool uiactive = this.Type == ECookPopType.Cook && ControllerBase<CookController>.Instance.CheckCanShowExpItem();
			base.GetItem(7).SetUIActive(uiactive);
			if (this.Type == ECookPopType.Cook)
			{
				this.ExpItem = new ExpItem(base.GetItem(7));
			}
			(base.GetButton(8).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(this.Type > ECookPopType.Unlock);
		}

		// Token: 0x0603C9DC RID: 248284 RVA: 0x00F64B88 File Offset: 0x00F62D88
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<CookPopItem> InitCookPopItem([Nullable(2)] object data, UUIItem item, int index)
		{
			ICookPopItem cookPopItem = data as ICookPopItem;
			if (cookPopItem == null)
			{
				return null;
			}
			CookPopItem cookPopItem2 = new CookPopItem(item);
			cookPopItem2.Update(cookPopItem);
			return new LayoutItem<CookPopItem>
			{
				Key = index,
				Value = cookPopItem2
			};
		}

		// Token: 0x0603C9DD RID: 248285 RVA: 0x00F64BC7 File Offset: 0x00F62DC7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FixSuccess, new Action(this.OnClose));
		}

		// Token: 0x0603C9DE RID: 248286 RVA: 0x00F64BE5 File Offset: 0x00F62DE5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FixSuccess, new Action(this.OnClose));
		}

		// Token: 0x0603C9DF RID: 248287 RVA: 0x00F64C03 File Offset: 0x00F62E03
		protected override void OnBeforeDestroy()
		{
			if (this.CookPopScroll != null)
			{
				this.CookPopScroll.ClearChildren();
				this.CookPopScroll = null;
			}
			if (this.ExpItem != null)
			{
				this.ExpItem.Destroy(null);
				this.ExpItem = null;
			}
		}

		// Token: 0x0603C9E0 RID: 248288 RVA: 0x00F64C3C File Offset: 0x00F62E3C
		protected override void OnAfterShow()
		{
			this.SetTitle();
			this.SetItemScroll();
			switch (this.Type)
			{
			case ECookPopType.Unlock:
				this.SetInfoText();
				this.RefreshDoubleConfirmButton();
				return;
			case ECookPopType.Cook:
				this.SetExpItem();
				return;
			case ECookPopType.Machining:
				break;
			case ECookPopType.StudyFail:
				this.SetInfoText();
				break;
			default:
				return;
			}
		}

		// Token: 0x0603C9E1 RID: 248289 RVA: 0x00F64C90 File Offset: 0x00F62E90
		private void SetTitle()
		{
			switch (this.Type)
			{
			case ECookPopType.Unlock:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "UnlockTitle", Array.Empty<object>());
				return;
			case ECookPopType.Cook:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "GetItem", Array.Empty<object>());
				return;
			case ECookPopType.Machining:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "GetItem", Array.Empty<object>());
				return;
			case ECookPopType.StudyFail:
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "StudyFail", Array.Empty<object>());
				return;
			default:
				return;
			}
		}

		// Token: 0x0603C9E2 RID: 248290 RVA: 0x00F64D2C File Offset: 0x00F62F2C
		private void SetItemScroll()
		{
			if (this.Type == ECookPopType.Unlock)
			{
				List<ICookPopItem> list = new List<ICookPopItem>();
				CookFixTool cookFixToolById = ConfigBase<CookConfig>.Instance.GetCookFixToolById(ControllerBase<CookController>.Instance.GetCurrentFixId());
				for (int i = 0; i < cookFixToolById.ItemsLength; i++)
				{
					DicIntInt? dicIntInt = cookFixToolById.Items(i);
					if (dicIntInt != null)
					{
						int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(dicIntInt.Value.Key, 0);
						list.Add(new CookPopItem
						{
							ItemId = dicIntInt.Value.Key,
							ItemNum = itemCountByConfigId
						});
					}
				}
				this.CookPopScroll.RefreshByData<ICookPopItem>(list, null);
				return;
			}
			this.CookPopScroll.RefreshByData<ICookPopItem>(ModelBase<CookModel>.Instance.GetCookItemList(), null);
		}

		// Token: 0x0603C9E3 RID: 248291 RVA: 0x00F64E00 File Offset: 0x00F63000
		private void SetInfoText()
		{
			if (this.Type == ECookPopType.Unlock)
			{
				CookFixTool cookFixToolById = ConfigBase<CookConfig>.Instance.GetCookFixToolById(ControllerBase<CookController>.Instance.GetCurrentFixId());
				string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookFixToolById.Description);
				int num = 0;
				string text = "";
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

		// Token: 0x0603C9E4 RID: 248292 RVA: 0x00F64F08 File Offset: 0x00F63108
		private void SetExpItem()
		{
			ICookerInfoData cookerInfo = ModelBase<CookModel>.Instance.GetCookerInfo();
			int sumExpByLevel = ModelBase<CookModel>.Instance.GetSumExpByLevel(ModelBase<CookModel>.Instance.GetCookerInfo().CookingLevel);
			this.ExpItem.SetExpSprite(cookerInfo.TotalProficiencys, sumExpByLevel);
			this.ExpItem.SetAddText(cookerInfo.AddExp);
			this.ExpItem.SetLastText(cookerInfo.TotalProficiencys);
			this.ExpItem.SetSumText(sumExpByLevel);
		}

		// Token: 0x0603C9E5 RID: 248293 RVA: 0x00F64F7C File Offset: 0x00F6317C
		private void RefreshDoubleConfirmButton()
		{
			UUIInteractionGroup uuiinteractionGroup = (base.GetButton(6).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup;
			bool flag = ControllerBase<CookController>.Instance.CheckCanFix();
			uuiinteractionGroup.SetInteractable(flag);
			(base.GetButton(9).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(!flag);
		}

		// Token: 0x0603C9E6 RID: 248294 RVA: 0x00F64FDF File Offset: 0x00F631DF
		private void OnClose()
		{
			this.DoClose();
		}

		// Token: 0x0603C9E7 RID: 248295 RVA: 0x00F64FE7 File Offset: 0x00F631E7
		private void OnCancel()
		{
			this.DoClose();
		}

		// Token: 0x0603C9E8 RID: 248296 RVA: 0x00F64FF0 File Offset: 0x00F631F0
		private void OnConfirm()
		{
			ControllerBase<CookController>.Instance.SendFixToolRequest(ControllerBase<CookController>.Instance.GetCurrentFixId(), ControllerBase<CookController>.Instance.GetCurrentEntityId().Value);
			this.DoClose();
		}

		// Token: 0x0603C9E9 RID: 248297 RVA: 0x00F65029 File Offset: 0x00F63229
		private void OnSingleConfirm()
		{
			this.DoClose();
		}

		// Token: 0x0603C9EA RID: 248298 RVA: 0x00F65031 File Offset: 0x00F63231
		private void DoClose()
		{
			if (this.Type == ECookPopType.Unlock)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CookPopFixView, null);
				return;
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CookPopView, null);
		}

		// Token: 0x0603C9EB RID: 248299 RVA: 0x00F6505C File Offset: 0x00F6325C
		private void OnDisable()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MaterialShort", Array.Empty<object>());
		}

		// Token: 0x040220F6 RID: 139510
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollView<CookPopItem> CookPopScroll;

		// Token: 0x040220F7 RID: 139511
		[Nullable(2)]
		private ExpItem ExpItem;

		// Token: 0x040220F8 RID: 139512
		private ECookPopType Type;

		// Token: 0x0200BE52 RID: 48722
		public enum ECookPopDefine
		{
			// Token: 0x0403A982 RID: 240002
			TitleText,
			// Token: 0x0403A983 RID: 240003
			ItemScrollView,
			// Token: 0x0403A984 RID: 240004
			InfoTextItem,
			// Token: 0x0403A985 RID: 240005
			InfoText,
			// Token: 0x0403A986 RID: 240006
			DoubleButtonItem,
			// Token: 0x0403A987 RID: 240007
			CancelButton,
			// Token: 0x0403A988 RID: 240008
			ConfirmButton,
			// Token: 0x0403A989 RID: 240009
			ExpItem,
			// Token: 0x0403A98A RID: 240010
			SingleConfirmButton,
			// Token: 0x0403A98B RID: 240011
			DisableButton
		}
	}
}
