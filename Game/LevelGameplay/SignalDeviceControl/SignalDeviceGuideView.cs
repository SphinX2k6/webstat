using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl
{
	// Token: 0x02006AF4 RID: 27380
	[NullableContext(2)]
	[Nullable(0)]
	public class SignalDeviceGuideView : UiViewBase
	{
		// Token: 0x06043AF5 RID: 277237 RVA: 0x01174912 File Offset: 0x01172B12
		[NullableContext(1)]
		public SignalDeviceGuideView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043AF6 RID: 277238 RVA: 0x01174924 File Offset: 0x01172B24
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnCloseClick)),
				new ValueTuple<int, Delegate>(7, new Action(this.PrePage)),
				new ValueTuple<int, Delegate>(8, new Action(this.NextPage))
			};
		}

		// Token: 0x06043AF7 RID: 277239 RVA: 0x01174AC8 File Offset: 0x01172CC8
		private void PrePage()
		{
			if (this.MoveTween == null && this.NowPage > 0)
			{
				UUIItem rootItem = this.CurrentShowPanel.GetRootItem();
				FVector relativeLocation = rootItem.RelativeLocation;
				UUIItem item = base.GetItem(12);
				item.SetUIRelativeLocation(new FVector(-item.Width, item.RelativeLocation.Y, item.RelativeLocation.Z));
				this.InitLastPanel();
				this.LastShowPanel.GetRootItem().SetUIRelativeLocation(new FVector(rootItem.Width, relativeLocation.Y, relativeLocation.Z));
				this.RefreshView(this.NowPage - 1);
				this.MoveTween = ULTweenBPLibrary.LocalPositionXTo(item, 0f, 0.3f, 0f, LTweenEase.InOutCubic);
				this.MoveTween.OnCompleteCallBack.Bind(delegate()
				{
					this.MoveTween = null;
				});
			}
		}

		// Token: 0x06043AF8 RID: 277240 RVA: 0x01174BA4 File Offset: 0x01172DA4
		private void NextPage()
		{
			if (this.MoveTween == null && this.NowPage < this.PageArray.Length - 1)
			{
				UUIItem rootItem = this.CurrentShowPanel.GetRootItem();
				FVector relativeLocation = rootItem.RelativeLocation;
				UUIItem item = base.GetItem(12);
				item.SetUIRelativeLocation(new FVector(item.Width, item.RelativeLocation.Y, item.RelativeLocation.Z));
				this.InitLastPanel();
				this.LastShowPanel.GetRootItem().SetUIRelativeLocation(new FVector(-rootItem.Width, relativeLocation.Y, relativeLocation.Z));
				this.RefreshView(this.NowPage + 1);
				this.MoveTween = ULTweenBPLibrary.LocalPositionXTo(item, 0f, 0.3f, 0f, LTweenEase.InOutCubic);
				this.MoveTween.OnCompleteCallBack.Bind(delegate()
				{
					this.MoveTween = null;
				});
			}
		}

		// Token: 0x06043AF9 RID: 277241 RVA: 0x01174C88 File Offset: 0x01172E88
		protected override void OnBeforeDestroy()
		{
			if (this.PageDotLayout != null)
			{
				this.PageDotLayout.ClearChildren();
				this.PageDotLayout = null;
			}
			this.CurrentShowPanel.Destroy(null);
			this.CurrentShowPanel = null;
			if (this.LastShowPanel != null)
			{
				this.LastShowPanel.Destroy(null);
				this.LastShowPanel = null;
			}
			if (this.MoveTween != null)
			{
				this.MoveTween.Kill(false);
				this.MoveTween = null;
			}
		}

		// Token: 0x06043AFA RID: 277242 RVA: 0x01174CF8 File Offset: 0x01172EF8
		[NullableContext(1)]
		private ILayoutItem<TutorialPageItem> InitDetail(object p, UUIItem uiItem, int index)
		{
			TutorialPageItem tutorialPageItem = new TutorialPageItem(uiItem);
			tutorialPageItem.Init();
			tutorialPageItem.UpdateShow(false);
			return new LayoutItem<TutorialPageItem>
			{
				Key = index,
				Value = tutorialPageItem
			};
		}

		// Token: 0x06043AFB RID: 277243 RVA: 0x01174D34 File Offset: 0x01172F34
		private void PlayAtOnce()
		{
			this.UiViewSequence.PlaySequence("StartAtOnce", false, null);
		}

		// Token: 0x06043AFC RID: 277244 RVA: 0x01174D5C File Offset: 0x01172F5C
		private void InitLastPanel()
		{
			if (this.LastShowPanel == null)
			{
				UUIItem uiItem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(3), base.GetItem(12));
				this.LastShowPanel = new GuideTutorialPagePanel();
				this.LastShowPanel.Init(uiItem);
			}
			this.CurrentShowPanel.PlayAnime(true);
			this.LastShowPanel.PlayAnime(false);
		}

		// Token: 0x06043AFD RID: 277245 RVA: 0x01174DBC File Offset: 0x01172FBC
		protected override UniTask OnBeforeStartAsync()
		{
			SignalDeviceGuideView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SignalDeviceGuideView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043AFE RID: 277246 RVA: 0x01174E00 File Offset: 0x01173000
		protected override void OnStart()
		{
			this.PageDotLayout = new GenericLayoutNew<TutorialPageItem>(base.GetHorizontalLayout(5), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TutorialPageItem>(this.InitDetail), base.GetItem(6));
			this.PageArray = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPageIds(34033);
			if (this.PageArray.Length <= 1)
			{
				base.GetButton(7).RootUIComp.Get().SetUIActive(false);
				base.GetButton(8).RootUIComp.Get().SetUIActive(false);
				base.GetItem(4).SetUIActive(false);
			}
			else
			{
				base.GetButton(7).RootUIComp.Get().SetUIActive(true);
				base.GetButton(8).RootUIComp.Get().SetUIActive(true);
				base.GetItem(4).SetUIActive(true);
				this.PageDotLayout.RebuildLayoutByDataNew<int>(this.PageArray, null);
			}
			base.GetText(14).SetUIActive(false);
			this.RefreshView(0);
		}

		// Token: 0x06043AFF RID: 277247 RVA: 0x01174F05 File Offset: 0x01173105
		protected override void OnBeforeShow()
		{
			this.PlayAtOnce();
		}

		// Token: 0x06043B00 RID: 277248 RVA: 0x01174F10 File Offset: 0x01173110
		private void RefreshView(int index)
		{
			if (this.PageArray.Length > 1)
			{
				this.PageDotLayout.GetLayoutItemByIndex(this.NowPage).UpdateShow(false);
				this.PageDotLayout.GetLayoutItemByIndex(index).UpdateShow(true);
				base.GetButton(7).SetSelfInteractive(index > 0);
				base.GetButton(8).SetSelfInteractive(index < this.PageArray.Length - 1);
				if (this.LastShowPanel != null)
				{
					GuideTutorialPage? guideTutorialPage = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPage(this.PageArray[this.NowPage]);
					this.LastShowPanel.RefreshPage(guideTutorialPage);
				}
			}
			this.NowPage = index;
			GuideTutorialPage? guideTutorialPage2 = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPage(this.PageArray[this.NowPage]);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), guideTutorialPage2.Value.Title, Array.Empty<object>());
			this.CurrentShowPanel.RefreshPage(guideTutorialPage2);
		}

		// Token: 0x06043B01 RID: 277249 RVA: 0x01174FF6 File Offset: 0x011731F6
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04025D0B RID: 154891
		public const float TWEEN_TIME = 0.3f;

		// Token: 0x04025D0C RID: 154892
		public const int GUIDE_ID = 34033;

		// Token: 0x04025D0D RID: 154893
		public bool IsPopView = true;

		// Token: 0x04025D0E RID: 154894
		private int[] PageArray;

		// Token: 0x04025D0F RID: 154895
		private int NowPage;

		// Token: 0x04025D10 RID: 154896
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<TutorialPageItem> PageDotLayout;

		// Token: 0x04025D11 RID: 154897
		private GuideTutorialPagePanel CurrentShowPanel;

		// Token: 0x04025D12 RID: 154898
		private GuideTutorialPagePanel LastShowPanel;

		// Token: 0x04025D13 RID: 154899
		private ULTweener MoveTween;
	}
}
