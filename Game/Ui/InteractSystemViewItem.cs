using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C6 RID: 18886
	[NullableContext(1)]
	[Nullable(0)]
	public class InteractSystemViewItem : CommonPopViewBase
	{
		// Token: 0x0603166C RID: 202348 RVA: 0x00C4ABAC File Offset: 0x00C48DAC
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(4);
		}

		// Token: 0x0603166D RID: 202349 RVA: 0x00C4ABB8 File Offset: 0x00C48DB8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603166E RID: 202350 RVA: 0x00C4AC84 File Offset: 0x00C48E84
		protected override void OnStart()
		{
			this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(3));
			string commonPopBgKey = this.ViewInfo.CommonPopBgKey;
			InteractBackGround? interactBackgroundByViewName = ConfigBase<UiCommonConfig>.Instance.GetInteractBackgroundByViewName(commonPopBgKey);
			if (interactBackgroundByViewName == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "u.Ui表现表中配置了通用背景面板(CommonPopBg)为5，但是t.通用背景-Npc系统界面通用背景中没有配置对应界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", commonPopBgKey);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.InteractBackgroundConfig = interactBackgroundByViewName;
			string title = this.InteractBackgroundConfig.Value.Title;
			string titleSpritePath = this.InteractBackgroundConfig.Value.TitleSpritePath;
			string contentSpritePath = this.InteractBackgroundConfig.Value.ContentSpritePath;
			int[] costItemListArray = this.InteractBackgroundConfig.Value.GetCostItemListArray();
			bool flag = !StringUtils.IsEmpty(title);
			bool flag2 = !StringUtils.IsEmpty(titleSpritePath);
			bool flag3 = !StringUtils.IsEmpty(contentSpritePath);
			bool flag4 = costItemListArray != null && costItemListArray.Length != 0;
			this.SetTitleVisible(flag);
			if (flag)
			{
				this.SetTitleText(title);
			}
			this.SetTitleSpriteVisible(flag2);
			if (flag2)
			{
				this.SetTitleSprite(titleSpritePath);
			}
			this.SetContentSpriteVisible(flag3);
			if (flag3)
			{
				this.SetContentSprite(contentSpritePath);
			}
			this.SetCurrencyItemVisible(flag4);
			if (flag4)
			{
				this.SetCostItemList(costItemListArray);
			}
			this.SetHelpButtonVisible(this.InteractBackgroundConfig.Value.IsHelpButtonVisible);
			this.PopupCaptionItem.SetHelpCallBack(new Action(this.OnClickedHelpButton));
			this.PopupCaptionItem.SetCloseCallBack(new Action(this.OnClickedCloseButton));
			this.PopupCaptionItem.SetTitleTextActive(false);
			this.PopupCaptionItem.SetTitleIconVisible(false);
		}

		// Token: 0x0603166F RID: 202351 RVA: 0x00C4AE29 File Offset: 0x00C49029
		protected override void OnBeforeDestroy()
		{
			this.InteractBackgroundConfig = null;
			this.PopupCaptionItem = null;
		}

		// Token: 0x06031670 RID: 202352 RVA: 0x00C4AE40 File Offset: 0x00C49040
		private void OnClickedHelpButton()
		{
			if (this.InteractBackgroundConfig != null)
			{
				int helpGroupId = this.InteractBackgroundConfig.Value.HelpGroupId;
				ControllerBase<HelpController>.Instance.OpenHelpById(helpGroupId);
			}
		}

		// Token: 0x06031671 RID: 202353 RVA: 0x00C4AE7C File Offset: 0x00C4907C
		private void OnClickedCloseButton()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "[CloseCookRootView]当点击关闭按钮时";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", this.ViewInfo.Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
		}

		// Token: 0x06031672 RID: 202354 RVA: 0x00C4AED5 File Offset: 0x00C490D5
		public override void SetTitleVisible(bool bVisible)
		{
			base.GetText(1).SetUIActive(bVisible);
		}

		// Token: 0x06031673 RID: 202355 RVA: 0x00C4AEE4 File Offset: 0x00C490E4
		public override void SetTitleText(string titleTextId)
		{
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, titleTextId, Array.Empty<object>());
		}

		// Token: 0x06031674 RID: 202356 RVA: 0x00C4AF0A File Offset: 0x00C4910A
		public void SetTitleSpriteVisible(bool bVisible)
		{
			base.GetSprite(0).SetUIActive(bVisible);
		}

		// Token: 0x06031675 RID: 202357 RVA: 0x00C4AF1C File Offset: 0x00C4911C
		public void SetTitleSprite(string spritePath)
		{
			UUISprite titleSprite = base.GetSprite(0);
			titleSprite.SetUIActive(false);
			this.SetSpriteByPath(spritePath, titleSprite, false, null, delegate(bool arg)
			{
				titleSprite.SetUIActive(true);
			});
		}

		// Token: 0x06031676 RID: 202358 RVA: 0x00C4AF6B File Offset: 0x00C4916B
		public void SetContentSpriteVisible(bool bVisible)
		{
			base.GetSprite(2).SetUIActive(bVisible);
		}

		// Token: 0x06031677 RID: 202359 RVA: 0x00C4AF7C File Offset: 0x00C4917C
		public void SetContentSprite(string spritePath)
		{
			UUISprite contentSprite = base.GetSprite(2);
			contentSprite.SetUIActive(false);
			this.SetSpriteByPath(spritePath, contentSprite, false, null, delegate(bool arg)
			{
				contentSprite.SetUIActive(true);
			});
		}

		// Token: 0x06031678 RID: 202360 RVA: 0x00C4AFCB File Offset: 0x00C491CB
		public void SetCaptionTitleVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetTitleTextActive(bVisible);
		}

		// Token: 0x06031679 RID: 202361 RVA: 0x00C4AFDE File Offset: 0x00C491DE
		public void SetCurrencyItemVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetCurrencyItemVisible(bVisible);
		}

		// Token: 0x0603167A RID: 202362 RVA: 0x00C4AFF1 File Offset: 0x00C491F1
		public void SetCaptionTitleSprite(string spriteTexture)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetTitleIcon(spriteTexture);
		}

		// Token: 0x0603167B RID: 202363 RVA: 0x00C4B004 File Offset: 0x00C49204
		public void SetCaptionTitleIconVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetTitleIconVisible(bVisible);
		}

		// Token: 0x0603167C RID: 202364 RVA: 0x00C4B018 File Offset: 0x00C49218
		public UniTask SetCostItemList(int[] itemConfigList)
		{
			InteractSystemViewItem.<SetCostItemList>d__19 <SetCostItemList>d__;
			<SetCostItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetCostItemList>d__.<>4__this = this;
			<SetCostItemList>d__.itemConfigList = itemConfigList;
			<SetCostItemList>d__.<>1__state = -1;
			<SetCostItemList>d__.<>t__builder.Start<InteractSystemViewItem.<SetCostItemList>d__19>(ref <SetCostItemList>d__);
			return <SetCostItemList>d__.<>t__builder.Task;
		}

		// Token: 0x0603167D RID: 202365 RVA: 0x00C4B063 File Offset: 0x00C49263
		public void SetHelpButtonVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetHelpBtnActive(bVisible);
		}

		// Token: 0x0401C5F6 RID: 116214
		[Nullable(2)]
		private PopupCaptionItem PopupCaptionItem;

		// Token: 0x0401C5F7 RID: 116215
		private InteractBackGround? InteractBackgroundConfig;

		// Token: 0x0200AA46 RID: 43590
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04034AFC RID: 215804
			public const int TitleSprite = 0;

			// Token: 0x04034AFD RID: 215805
			public const int TitleText = 1;

			// Token: 0x04034AFE RID: 215806
			public const int ContentSprite = 2;

			// Token: 0x04034AFF RID: 215807
			public const int CaptionItem = 3;

			// Token: 0x04034B00 RID: 215808
			public const int ContentItem = 4;
		}
	}
}
