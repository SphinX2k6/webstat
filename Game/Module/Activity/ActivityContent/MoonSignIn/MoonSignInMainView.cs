using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x0200672B RID: 26411
	[NullableContext(1)]
	[Nullable(0)]
	public class MoonSignInMainView : UiViewBase
	{
		// Token: 0x06041E18 RID: 269848 RVA: 0x010E7437 File Offset: 0x010E5637
		public MoonSignInMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041E19 RID: 269849 RVA: 0x010E7440 File Offset: 0x010E5640
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickIllustratedBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickWishBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCurrentMoonDesBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickCurrentMoonTipsCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041E1A RID: 269850 RVA: 0x010E76A0 File Offset: 0x010E58A0
		protected override UniTask OnBeforeStartAsync()
		{
			MoonSignInMainView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoonSignInMainView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041E1B RID: 269851 RVA: 0x010E76E4 File Offset: 0x010E58E4
		protected override void OnStart()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.BindSequenceCloseEvent(delegate(string name)
				{
					if (name == "TjStart")
					{
						base.GetItem(6).SetUIActive(false);
					}
					if (name == "TjHideView")
					{
						MoonSignInIllustrated illustratedView = this.IllustratedView;
						if (illustratedView == null)
						{
							return;
						}
						illustratedView.SetUiActive(false);
					}
				}, false);
			}
			base.GetButton(13).RootUIComp.Get().SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (((data != null) ? data.GetCurrentItemCount() : 0) > 0)
			{
				this.OpenWishView(false);
				return;
			}
			this.OpenIllustratedView();
		}

		// Token: 0x06041E1C RID: 269852 RVA: 0x010E776B File Offset: 0x010E596B
		protected override void OnBeforeShow()
		{
			this.RefreshTitle();
			this.RefreshRedDot();
		}

		// Token: 0x06041E1D RID: 269853 RVA: 0x010E777C File Offset: 0x010E597C
		private void RefreshTitle()
		{
			base.GetItem(7).SetUIActive(false);
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			int? num = (data != null) ? new int?(data.CurrentMoonId) : null;
			if (num == null || num.Value == 0)
			{
				base.GetItem(9).SetUIActive(false);
				return;
			}
			PhaseOfMoon? phaseOfMoonById = ConfigBase<MoonSignInConfig>.Instance.GetPhaseOfMoonById(num.Value);
			if (phaseOfMoonById == null)
			{
				return;
			}
			base.GetItem(9).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phaseOfMoonById.Value.MoonName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), phaseOfMoonById.Value.BuffDes, Array.Empty<object>());
		}

		// Token: 0x06041E1E RID: 269854 RVA: 0x010E784F File Offset: 0x010E5A4F
		private void RefreshRedDot()
		{
			UUIItem item = base.GetItem(10);
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			item.SetUIActive(((data != null) ? data.GetCurrentItemCount() : 0) >= 1);
		}

		// Token: 0x06041E1F RID: 269855 RVA: 0x010E787C File Offset: 0x010E5A7C
		private void OpenWishView(bool playWishShow = false)
		{
			base.GetItem(6).SetUIActive(true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("TjHideView", false, null, false);
			}
			if (playWishShow)
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlayLevelSequenceByName("WishShowView", true, null, false);
				}
			}
			this.RefreshRedDot();
		}

		// Token: 0x06041E20 RID: 269856 RVA: 0x010E78E4 File Offset: 0x010E5AE4
		private void OpenIllustratedView()
		{
			MoonSignInIllustrated illustratedView = this.IllustratedView;
			if (illustratedView != null)
			{
				illustratedView.SetUiActive(true);
			}
			MoonSignInIllustrated illustratedView2 = this.IllustratedView;
			if (illustratedView2 != null)
			{
				illustratedView2.RefreshPhaseView();
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("TjStart", true, null, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("WishHideView", false, null, false);
		}

		// Token: 0x06041E21 RID: 269857 RVA: 0x010E7955 File Offset: 0x010E5B55
		private void OnClickIllustratedBtn()
		{
			this.OpenIllustratedView();
		}

		// Token: 0x06041E22 RID: 269858 RVA: 0x010E7960 File Offset: 0x010E5B60
		private void OnClickWishBtn()
		{
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			if (data.GetCurrentItemCount() > 0)
			{
				ControllerBase<MoonSignInController>.Instance.MoonPhaseRandomRequest(data.Id);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MoonSignInItemCountNotEnough", Array.Empty<object>());
		}

		// Token: 0x06041E23 RID: 269859 RVA: 0x010E79AC File Offset: 0x010E5BAC
		private void OnClickCurrentMoonDesBtn()
		{
			base.GetItem(7).SetUIActive(true);
			UUIButtonComponent button = base.GetButton(13);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x06041E24 RID: 269860 RVA: 0x010E79E8 File Offset: 0x010E5BE8
		private void OnClickCurrentMoonTipsCloseBtn()
		{
			base.GetItem(7).SetUIActive(false);
			UUIButtonComponent button = base.GetButton(13);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06041E25 RID: 269861 RVA: 0x010E7A22 File Offset: 0x010E5C22
		private void OnClickIllustratedViewSwitchBtn()
		{
			this.OpenWishView(true);
		}

		// Token: 0x06041E26 RID: 269862 RVA: 0x010E7A2B File Offset: 0x010E5C2B
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x04024C21 RID: 150561
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024C22 RID: 150562
		private MoonSignInIllustrated IllustratedView;

		// Token: 0x04024C23 RID: 150563
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C75F RID: 51039
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D604 RID: 251396
			public const int CaptionItem = 0;

			// Token: 0x0403D605 RID: 251397
			public const int CurrentMoonNameText = 1;

			// Token: 0x0403D606 RID: 251398
			public const int CurrentMoonDesBtn = 2;

			// Token: 0x0403D607 RID: 251399
			public const int IllustratedBtn = 3;

			// Token: 0x0403D608 RID: 251400
			public const int WishBtn = 4;

			// Token: 0x0403D609 RID: 251401
			public const int IllustratedItem = 5;

			// Token: 0x0403D60A RID: 251402
			public const int WishItem = 6;

			// Token: 0x0403D60B RID: 251403
			public const int CurrentMoonTipsItem = 7;

			// Token: 0x0403D60C RID: 251404
			public const int CurrentMoonTipsText = 8;

			// Token: 0x0403D60D RID: 251405
			public const int CurrentMoonNameItem = 9;

			// Token: 0x0403D60E RID: 251406
			public const int WishBtnRedDotItem = 10;

			// Token: 0x0403D60F RID: 251407
			public const int CurrentMoonTipsCloseBtn = 13;
		}
	}
}
