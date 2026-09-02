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
	// Token: 0x020049C7 RID: 18887
	[NullableContext(1)]
	[Nullable(0)]
	public class NpcSystemViewItem : CommonPopViewBase
	{
		// Token: 0x0603167F RID: 202367 RVA: 0x00C4B07E File Offset: 0x00C4927E
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(4);
		}

		// Token: 0x06031680 RID: 202368 RVA: 0x00C4B088 File Offset: 0x00C49288
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(base.OnClickMaskButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06031681 RID: 202369 RVA: 0x00C4B1F4 File Offset: 0x00C493F4
		protected override void OnStart()
		{
			this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(5));
			string commonPopBgKey = this.ViewInfo.CommonPopBgKey;
			NpcSystemBackground? npcSystemBackgroundByViewName = ConfigBase<UiCommonConfig>.Instance.GetNpcSystemBackgroundByViewName(commonPopBgKey);
			if (npcSystemBackgroundByViewName == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "u.Ui表现表中配置了通用背景面板(CommonPopBg)为5，但是t.通用背景-Npc系统界面通用背景中没有配置对应界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", commonPopBgKey);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.NpcSystemBackgroundConfig = npcSystemBackgroundByViewName;
			string title = npcSystemBackgroundByViewName.Value.Title;
			string titleTexturePath = npcSystemBackgroundByViewName.Value.TitleTexturePath;
			string titleBgTexturePath = npcSystemBackgroundByViewName.Value.TitleBgTexturePath;
			string titleSymbolColor = npcSystemBackgroundByViewName.Value.TitleSymbolColor;
			string captionTitle = npcSystemBackgroundByViewName.Value.CaptionTitle;
			string captionTitleSpritePath = npcSystemBackgroundByViewName.Value.CaptionTitleSpritePath;
			int[] costItemListArray = npcSystemBackgroundByViewName.Value.GetCostItemListArray();
			bool flag = !StringUtils.IsEmpty(title);
			bool flag2 = !StringUtils.IsEmpty(titleTexturePath);
			bool flag3 = !StringUtils.IsEmpty(titleBgTexturePath);
			bool flag4 = !StringUtils.IsEmpty(titleSymbolColor);
			bool flag5 = !StringUtils.IsEmpty(captionTitle);
			bool flag6 = !StringUtils.IsEmpty(captionTitleSpritePath);
			bool flag7 = costItemListArray != null && costItemListArray.Length != 0;
			this.SetTitleVisible(flag);
			if (flag)
			{
				this.SetTitleText(npcSystemBackgroundByViewName.Value.Title);
			}
			this.SetTitleTextureVisible(flag2);
			if (flag2)
			{
				this.SetTitleTexture(titleTexturePath);
			}
			this.SetTitleBackgroundTextureVisible(flag3);
			if (flag3)
			{
				this.SetTitleBackgroundTexture(titleBgTexturePath);
			}
			this.SetTitleSymbolVisible(flag4);
			if (flag4)
			{
				this.SetTitleSymbolColor(titleSymbolColor);
			}
			this.SetCaptionTitleVisible(flag5);
			if (flag5)
			{
				this.SetCaptionTitleText(captionTitle);
			}
			this.SetCaptionTitleIconVisible(flag6);
			if (flag6)
			{
				this.SetCaptionTitleSprite(captionTitleSpritePath);
			}
			this.SetCurrencyItemVisible(flag7);
			if (flag7 && costItemListArray != null)
			{
				this.SetCostItemList(costItemListArray);
			}
			this.SetHelpButtonVisible(npcSystemBackgroundByViewName.Value.IsHelpButtonVisible);
			this.PopupCaptionItem.SetHelpCallBack(new Action(this.OnClickedHelpButton));
			this.PopupCaptionItem.SetCloseCallBack(new Action(this.OnClickedCloseButton));
		}

		// Token: 0x06031682 RID: 202370 RVA: 0x00C4B411 File Offset: 0x00C49611
		protected override void OnBeforeDestroy()
		{
			this.NpcSystemBackgroundConfig = null;
			this.PopupCaptionItem = null;
		}

		// Token: 0x06031683 RID: 202371 RVA: 0x00C4B428 File Offset: 0x00C49628
		private void OnClickedHelpButton()
		{
			if (this.NpcSystemBackgroundConfig != null)
			{
				int helpGroupId = this.NpcSystemBackgroundConfig.Value.HelpGroupId;
				ControllerBase<HelpController>.Instance.OpenHelpById(helpGroupId);
			}
		}

		// Token: 0x06031684 RID: 202372 RVA: 0x00C4B464 File Offset: 0x00C49664
		private void OnClickedCloseButton()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "[CloseCookRootView]当点击关闭按钮时";
			string item = "viewName";
			UiViewInfo viewInfo = this.ViewInfo;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.ViewInfo != null)
			{
				Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			}
		}

		// Token: 0x06031685 RID: 202373 RVA: 0x00C4B4D9 File Offset: 0x00C496D9
		public override void SetTitleVisible(bool bVisible)
		{
			base.GetText(0).SetUIActive(bVisible);
		}

		// Token: 0x06031686 RID: 202374 RVA: 0x00C4B4E8 File Offset: 0x00C496E8
		public override void SetTitleText(string titleTextId)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, titleTextId, Array.Empty<object>());
		}

		// Token: 0x06031687 RID: 202375 RVA: 0x00C4B50E File Offset: 0x00C4970E
		public void SetTitleTextureVisible(bool bVisible)
		{
			base.GetTexture(2).SetUIActive(bVisible);
		}

		// Token: 0x06031688 RID: 202376 RVA: 0x00C4B520 File Offset: 0x00C49720
		public void SetTitleTexture(string texturePath)
		{
			UUITexture titleTexture = base.GetTexture(2);
			titleTexture.SetUIActive(false);
			base.SetTextureByPath(texturePath, titleTexture, null, delegate(bool _)
			{
				titleTexture.SetUIActive(true);
			});
		}

		// Token: 0x06031689 RID: 202377 RVA: 0x00C4B56E File Offset: 0x00C4976E
		public void SetTitleBackgroundTextureVisible(bool bVisible)
		{
			base.GetTexture(1).SetUIActive(bVisible);
		}

		// Token: 0x0603168A RID: 202378 RVA: 0x00C4B580 File Offset: 0x00C49780
		public void SetTitleBackgroundTexture(string texturePath)
		{
			UUITexture titleBgTexture = base.GetTexture(1);
			titleBgTexture.SetUIActive(false);
			base.SetTextureByPath(texturePath, titleBgTexture, null, delegate(bool _)
			{
				titleBgTexture.SetUIActive(true);
			});
		}

		// Token: 0x0603168B RID: 202379 RVA: 0x00C4B5CE File Offset: 0x00C497CE
		public void SetTitleSymbolVisible(bool bVisible)
		{
			base.GetSprite(3).SetUIActive(bVisible);
		}

		// Token: 0x0603168C RID: 202380 RVA: 0x00C4B5DD File Offset: 0x00C497DD
		public void SetTitleSymbolColor(string hexColor)
		{
			base.GetSprite(3).SetColor(FColor.FromHex(hexColor));
		}

		// Token: 0x0603168D RID: 202381 RVA: 0x00C4B5F1 File Offset: 0x00C497F1
		public void SetCaptionTitleText(string titleTextId)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetTitleLocalText(titleTextId);
		}

		// Token: 0x0603168E RID: 202382 RVA: 0x00C4B604 File Offset: 0x00C49804
		public void SetCaptionTitleVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetTitleTextActive(bVisible);
		}

		// Token: 0x0603168F RID: 202383 RVA: 0x00C4B617 File Offset: 0x00C49817
		public void SetCurrencyItemVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetCurrencyItemVisible(bVisible);
		}

		// Token: 0x06031690 RID: 202384 RVA: 0x00C4B62A File Offset: 0x00C4982A
		public void SetCaptionTitleSprite(string spriteTexture)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetTitleIcon(spriteTexture);
		}

		// Token: 0x06031691 RID: 202385 RVA: 0x00C4B63D File Offset: 0x00C4983D
		public void SetCaptionTitleIconVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetTitleIconVisible(bVisible);
		}

		// Token: 0x06031692 RID: 202386 RVA: 0x00C4B650 File Offset: 0x00C49850
		public UniTask SetCostItemList(int[] itemConfigList)
		{
			NpcSystemViewItem.<SetCostItemList>d__22 <SetCostItemList>d__;
			<SetCostItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetCostItemList>d__.<>4__this = this;
			<SetCostItemList>d__.itemConfigList = itemConfigList;
			<SetCostItemList>d__.<>1__state = -1;
			<SetCostItemList>d__.<>t__builder.Start<NpcSystemViewItem.<SetCostItemList>d__22>(ref <SetCostItemList>d__);
			return <SetCostItemList>d__.<>t__builder.Task;
		}

		// Token: 0x06031693 RID: 202387 RVA: 0x00C4B69B File Offset: 0x00C4989B
		public void SetHelpButtonVisible(bool bVisible)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem == null)
			{
				return;
			}
			popupCaptionItem.SetHelpBtnActive(bVisible);
		}

		// Token: 0x06031694 RID: 202388 RVA: 0x00C4B6AE File Offset: 0x00C498AE
		public override void SetTexBgVisible(bool bVisible)
		{
			base.GetItem(7).SetUIActive(bVisible);
		}

		// Token: 0x0401C5F8 RID: 116216
		[Nullable(2)]
		private PopupCaptionItem PopupCaptionItem;

		// Token: 0x0401C5F9 RID: 116217
		private NpcSystemBackground? NpcSystemBackgroundConfig;

		// Token: 0x0200AA4A RID: 43594
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04034B08 RID: 215816
			public const int TitleText = 0;

			// Token: 0x04034B09 RID: 215817
			public const int TitleBgTexture = 1;

			// Token: 0x04034B0A RID: 215818
			public const int TitleTexture = 2;

			// Token: 0x04034B0B RID: 215819
			public const int TitleSymbolSprite = 3;

			// Token: 0x04034B0C RID: 215820
			public const int ContentItem = 4;

			// Token: 0x04034B0D RID: 215821
			public const int CaptionItem = 5;

			// Token: 0x04034B0E RID: 215822
			public const int BtnMask = 6;

			// Token: 0x04034B0F RID: 215823
			public const int PnlTop = 7;
		}
	}
}
