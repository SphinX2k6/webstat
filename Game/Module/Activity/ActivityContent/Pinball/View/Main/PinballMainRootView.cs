using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065FA RID: 26106
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballMainRootView : PinballMainRootViewBase<PinballMainViewModel>
	{
		// Token: 0x0604137D RID: 267133 RVA: 0x010BAB12 File Offset: 0x010B8D12
		public PinballMainRootView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604137E RID: 267134 RVA: 0x010BAB1C File Offset: 0x010B8D1C
		protected override void OnRegisterDefaultChildView()
		{
			IPinballMainRootViewOpenParam pinballMainRootViewOpenParam = this.OpenParam as IPinballMainRootViewOpenParam;
			this.DefaultChildViewName = pinballMainRootViewOpenParam.ChildView;
			this.CheckChildViewParam(pinballMainRootViewOpenParam);
		}

		// Token: 0x0604137F RID: 267135 RVA: 0x010BAB48 File Offset: 0x010B8D48
		protected override void OnRegisterContentItem()
		{
			this.ContentItem = base.GetItem(1);
		}

		// Token: 0x06041380 RID: 267136 RVA: 0x010BAB58 File Offset: 0x010B8D58
		protected override void OnRegisterViewData()
		{
			base.ViewModel = new PinballMainViewModel();
			base.ViewModel.ChangePlanetTexture = new Action<string>(this.ChangePlanetTexture);
			base.ViewModel.ChangePlanetMaskTexture = new Action<string>(this.ChangePlanetMaskTexture);
			base.ViewModel.ChangePlanetSwitchTexture = new Action<string>(this.ChangePlanetSwitchTexture);
			base.ViewModel.SetViewTitle = new Action<string>(this.SetViewTitle);
			base.ViewModel.SetViewIcon = new Action<string>(this.SetViewIcon);
			base.ViewModel.SetViewHelpId = new Action<int>(this.SetViewHelpId);
			base.ViewModel.SetViewHelpBtnActive = new Action<bool>(this.SetViewHelpBtnActive);
		}

		// Token: 0x06041381 RID: 267137 RVA: 0x010BAC14 File Offset: 0x010B8E14
		private void CheckChildViewParam(IPinballMainRootViewOpenParam openParam)
		{
			if (openParam.LevelId != null)
			{
				int value = openParam.LevelId.Value;
				PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
				int chapterIdByLevel = activityData.GetChapterIdByLevel(value);
				PinballChapterData chapterData = activityData.GetChapterData(chapterIdByLevel);
				PinballLevelRecordData levelData = activityData.GetLevelData(value);
				List<PinballLevelRecordData> levelDataListInChapter = activityData.GetLevelDataListInChapter(value);
				if (levelData != null)
				{
					base.ViewModel.SetSelectLevelData(levelData);
				}
				if (chapterData != null)
				{
					base.ViewModel.SetChapterData(chapterData);
				}
				if (levelDataListInChapter.Count > 0)
				{
					base.ViewModel.SetLevelDataList(levelDataListInChapter);
				}
			}
		}

		// Token: 0x06041382 RID: 267138 RVA: 0x010BACA4 File Offset: 0x010B8EA4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041383 RID: 267139 RVA: 0x010BAD50 File Offset: 0x010B8F50
		protected override UniTask OnBeforeStartAsync()
		{
			PinballMainRootView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballMainRootView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041384 RID: 267140 RVA: 0x010BAD93 File Offset: 0x010B8F93
		protected override void OnStart()
		{
			this.AddHomeBtnExtraCallback();
		}

		// Token: 0x06041385 RID: 267141 RVA: 0x010BAD9C File Offset: 0x010B8F9C
		protected override void OnBeforeHide()
		{
			PinballModel instance = ModelBase<PinballModel>.Instance;
			PinballActivityData pinballActivityData = (instance != null) ? instance.ActivityData : null;
			if (pinballActivityData != null)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, pinballActivityData.Id);
			}
		}

		// Token: 0x06041386 RID: 267142 RVA: 0x010BADD4 File Offset: 0x010B8FD4
		public void ChangePlanetTexture(string path)
		{
			base.SetTextureByPath(path, base.GetTexture(2), null, null);
		}

		// Token: 0x06041387 RID: 267143 RVA: 0x010BADFC File Offset: 0x010B8FFC
		public void ChangePlanetMaskTexture(string path)
		{
			base.SetTextureByPath(path, base.GetTexture(3), null, null);
		}

		// Token: 0x06041388 RID: 267144 RVA: 0x010BAE24 File Offset: 0x010B9024
		public void ChangePlanetSwitchTexture(string path)
		{
			base.SetTextureByPath(path, base.GetTexture(4), null, null);
		}

		// Token: 0x06041389 RID: 267145 RVA: 0x010BAE49 File Offset: 0x010B9049
		public void SetViewTitle(string title)
		{
			this.CaptionItem.SetTitleLocalText(title);
		}

		// Token: 0x0604138A RID: 267146 RVA: 0x010BAE57 File Offset: 0x010B9057
		public void SetViewIcon(string icon)
		{
			this.CaptionItem.SetTitleIconByResourceId(icon).Forget();
		}

		// Token: 0x0604138B RID: 267147 RVA: 0x010BAE6C File Offset: 0x010B906C
		public void SetViewHelpId(int helpId)
		{
			this.CaptionItem.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
			});
		}

		// Token: 0x0604138C RID: 267148 RVA: 0x010BAE9D File Offset: 0x010B909D
		public void SetViewHelpBtnActive(bool bActive)
		{
			this.CaptionItem.SetHelpBtnActive(bActive);
		}

		// Token: 0x0604138D RID: 267149 RVA: 0x010BAEAB File Offset: 0x010B90AB
		private void OnBackBtnClick()
		{
			Action overrideCloseFunc = base.ViewModel.GetOverrideCloseFunc();
			if (overrideCloseFunc == null)
			{
				return;
			}
			overrideCloseFunc();
		}

		// Token: 0x0604138E RID: 267150 RVA: 0x010BAEC2 File Offset: 0x010B90C2
		private void AddHomeBtnExtraCallback()
		{
			UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
			if (uiBehaviourHomeBtn == null)
			{
				return;
			}
			uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
			{
				PinballMainRootView.<>c.<<AddHomeBtnExtraCallback>b__19_0>d <<AddHomeBtnExtraCallback>b__19_0>d;
				<<AddHomeBtnExtraCallback>b__19_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<AddHomeBtnExtraCallback>b__19_0>d.<>1__state = -1;
				<<AddHomeBtnExtraCallback>b__19_0>d.<>t__builder.Start<PinballMainRootView.<>c.<<AddHomeBtnExtraCallback>b__19_0>d>(ref <<AddHomeBtnExtraCallback>b__19_0>d);
				return <<AddHomeBtnExtraCallback>b__19_0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0402482A RID: 149546
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0200C603 RID: 50691
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CF3D RID: 249661
			CaptionItem,
			// Token: 0x0403CF3E RID: 249662
			Content,
			// Token: 0x0403CF3F RID: 249663
			TexPlanet,
			// Token: 0x0403CF40 RID: 249664
			TexPlanetMask,
			// Token: 0x0403CF41 RID: 249665
			TexPlanetChange
		}
	}
}
