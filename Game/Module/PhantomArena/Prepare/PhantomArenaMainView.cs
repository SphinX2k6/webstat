using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054A8 RID: 21672
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaMainView : PhantomArenaRootViewBase<PhantomArenaMainViewModel>
	{
		// Token: 0x06037299 RID: 225945 RVA: 0x00E01EAE File Offset: 0x00E000AE
		public PhantomArenaMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603729A RID: 225946 RVA: 0x00E01EC4 File Offset: 0x00E000C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x0603729B RID: 225947 RVA: 0x00E01F78 File Offset: 0x00E00178
		protected override void OnRegisterViewData()
		{
			IPhantomArenaMainViewOpenParam phantomArenaMainViewOpenParam = this.OpenParam as IPhantomArenaMainViewOpenParam;
			this.ViewModel = new PhantomArenaMainViewModel();
			this.ActivityId = phantomArenaMainViewOpenParam.ActivityId;
			this.ViewModel.ActivityId = this.ActivityId;
			this.ViewModel.RecommendDeck = phantomArenaMainViewOpenParam.RecommendDeck;
			this.ViewModel.Init(phantomArenaMainViewOpenParam.ChallengeId);
			this.ViewModel.SetGetSwitchItemFunc(new Func<PhantomArenaMainViewSwitchItem>(this.GetSwitchItem));
			this.ViewModel.RefreshRoleTexture = new Action(this.RefreshRoleTextureWithoutAnim);
			this.ViewModel.ChangeRoleTexture = new Action<int, bool>(this.ChangeRoleTexture);
			this.ViewModel.ShowRoleTexture = new Action<bool>(this.ShowRoleTexture);
			this.ViewModel.HideRoleTexture = new Action<bool>(this.HideRoleTexture);
			this.ViewModel.PlayRoleTextureShowAnim = new Action(this.PlayRoleTextureShowAnim);
			this.ViewModel.SetViewTitle = new Action<string>(this.SetViewTitle);
			this.ViewModel.SetViewIcon = new Action<string>(this.SetViewIcon);
			this.ViewModel.SetViewHelpId = new Action<int>(this.SetViewHelpId);
			this.ViewModel.SetViewHelpBtnActive = new Action<bool>(this.SetViewHelpBtnActive);
		}

		// Token: 0x0603729C RID: 225948 RVA: 0x00E020C1 File Offset: 0x00E002C1
		protected override void OnAddEventListener()
		{
			base.OnAddEventListener();
			Singleton<EventSystem>.Instance.Add(EEventName.GuideFocusNeedUiTabView, new Action<GuideStepInfo, GuideFocusNew>(this.OnGuideFocusNeedUiTabView));
		}

		// Token: 0x0603729D RID: 225949 RVA: 0x00E020E5 File Offset: 0x00E002E5
		protected override void OnRemoveEventListener()
		{
			base.OnRemoveEventListener();
			Singleton<EventSystem>.Instance.Remove(EEventName.GuideFocusNeedUiTabView, new Action<GuideStepInfo, GuideFocusNew>(this.OnGuideFocusNeedUiTabView));
		}

		// Token: 0x0603729E RID: 225950 RVA: 0x00E0210C File Offset: 0x00E0030C
		protected override void OnRegisterDefaultChildView()
		{
			IPhantomArenaMainViewOpenParam phantomArenaMainViewOpenParam = this.OpenParam as IPhantomArenaMainViewOpenParam;
			this.DefaultChildViewName = new EPhantomArenaChildViewName?(phantomArenaMainViewOpenParam.OpenView);
		}

		// Token: 0x0603729F RID: 225951 RVA: 0x00E02136 File Offset: 0x00E00336
		protected override void OnRegisterContentItem()
		{
			this.ContentItem = base.GetItem(1);
		}

		// Token: 0x060372A0 RID: 225952 RVA: 0x00E02148 File Offset: 0x00E00348
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaMainView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaMainView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060372A1 RID: 225953 RVA: 0x00E0218B File Offset: 0x00E0038B
		private void ChangeRoleTexture(int newTextureCardRoleId, bool bPlayAnim)
		{
			if (this.ViewModel.TextureCardRoleId == newTextureCardRoleId)
			{
				return;
			}
			this.ViewModel.TextureCardRoleId = newTextureCardRoleId;
			this.RefreshRoleTexture(bPlayAnim);
		}

		// Token: 0x060372A2 RID: 225954 RVA: 0x00E021AF File Offset: 0x00E003AF
		private void RefreshRoleTextureWithoutAnim()
		{
			this.RefreshRoleTexture(false);
		}

		// Token: 0x060372A3 RID: 225955 RVA: 0x00E021B8 File Offset: 0x00E003B8
		public void ShowRoleTexture(bool bPlayAnim)
		{
			if (this.ViewModel.RoleTextureActive)
			{
				return;
			}
			if (this.ViewModel.TextureCardRoleId <= 0)
			{
				return;
			}
			this.ViewModel.RoleTextureActive = true;
			this.SetRoleTextureUiActive(true);
			if (bPlayAnim)
			{
				string sequenceName = "RoleShow";
				if (this.SequencePlayer.CheckSeqActorIsSeqPlaying(sequenceName))
				{
					this.SequencePlayer.ReplaySequenceByKey(sequenceName);
					return;
				}
				this.SequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
			}
		}

		// Token: 0x060372A4 RID: 225956 RVA: 0x00E02234 File Offset: 0x00E00434
		public void PlayRoleTextureChangeAnim()
		{
			string sequenceName = "RoleShow";
			if (this.SequencePlayer.CheckSeqActorIsSeqPlaying(sequenceName))
			{
				this.SequencePlayer.ReplaySequenceByKey(sequenceName);
				return;
			}
			this.SequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}

		// Token: 0x060372A5 RID: 225957 RVA: 0x00E0227C File Offset: 0x00E0047C
		public void PlayRoleTextureShowAnim()
		{
			string sequenceName = "RoleShow";
			if (this.SequencePlayer.CheckSeqActorIsSeqPlaying(sequenceName))
			{
				this.SequencePlayer.ReplaySequenceByKey(sequenceName);
				return;
			}
			this.SequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}

		// Token: 0x060372A6 RID: 225958 RVA: 0x00E022C4 File Offset: 0x00E004C4
		public void HideRoleTexture(bool bPlayAnim)
		{
			if (!this.ViewModel.RoleTextureActive)
			{
				return;
			}
			this.ViewModel.RoleTextureActive = false;
			if (bPlayAnim)
			{
				string sequenceName = "RoleHide";
				if (this.SequencePlayer.CheckSeqActorIsSeqPlaying(sequenceName))
				{
					this.SequencePlayer.ReplaySequenceByKey(sequenceName);
					return;
				}
				this.SequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
			}
		}

		// Token: 0x060372A7 RID: 225959 RVA: 0x00E02328 File Offset: 0x00E00528
		public void SetRoleTextureUiActive(bool active)
		{
			base.GetTexture(2).SetUIActive(active);
			base.GetItem(6).SetUIActive(active);
		}

		// Token: 0x060372A8 RID: 225960 RVA: 0x00E02344 File Offset: 0x00E00544
		public void RefreshRoleTexture(bool bPlayAnim)
		{
			PhantomArenaMainView.<>c__DisplayClass21_0 CS$<>8__locals1 = new PhantomArenaMainView.<>c__DisplayClass21_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.bPlayAnim = bPlayAnim;
			UiAsyncTask task = new UiAsyncTask("PhantomArenaMainView", delegate()
			{
				PhantomArenaMainView.<>c__DisplayClass21_0.<<RefreshRoleTexture>b__0>d <<RefreshRoleTexture>b__0>d;
				<<RefreshRoleTexture>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshRoleTexture>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshRoleTexture>b__0>d.<>1__state = -1;
				<<RefreshRoleTexture>b__0>d.<>t__builder.Start<PhantomArenaMainView.<>c__DisplayClass21_0.<<RefreshRoleTexture>b__0>d>(ref <<RefreshRoleTexture>b__0>d);
				return <<RefreshRoleTexture>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x060372A9 RID: 225961 RVA: 0x00E02388 File Offset: 0x00E00588
		public UniTask RefreshRoleTextureAsync()
		{
			PhantomArenaMainView.<RefreshRoleTextureAsync>d__22 <RefreshRoleTextureAsync>d__;
			<RefreshRoleTextureAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleTextureAsync>d__.<>4__this = this;
			<RefreshRoleTextureAsync>d__.<>1__state = -1;
			<RefreshRoleTextureAsync>d__.<>t__builder.Start<PhantomArenaMainView.<RefreshRoleTextureAsync>d__22>(ref <RefreshRoleTextureAsync>d__);
			return <RefreshRoleTextureAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060372AA RID: 225962 RVA: 0x00E023CC File Offset: 0x00E005CC
		private void ChangeToShowRoleSpine(int newTextureCardRoleId)
		{
			if (this.CurShowRoleSpine != null)
			{
				this.CurShowRoleSpine.GetRootItem().SetUIActive(false);
			}
			PhantomArenaMainViewRoleSpineItem phantomArenaMainViewRoleSpineItem;
			if (this.RoleSpineMap.TryGetValue(newTextureCardRoleId, out phantomArenaMainViewRoleSpineItem))
			{
				phantomArenaMainViewRoleSpineItem.GetRootItem().SetUIActive(true);
				this.CurShowRoleSpine = phantomArenaMainViewRoleSpineItem;
			}
		}

		// Token: 0x060372AB RID: 225963 RVA: 0x00E02415 File Offset: 0x00E00615
		private void OnSeqStart(string seqName)
		{
		}

		// Token: 0x060372AC RID: 225964 RVA: 0x00E02417 File Offset: 0x00E00617
		private void OnSeqEnd(string seqName)
		{
			if (seqName == "RoleHide".ToString())
			{
				this.SetRoleTextureUiActive(false);
			}
		}

		// Token: 0x060372AD RID: 225965 RVA: 0x00E02434 File Offset: 0x00E00634
		private void OnBackBtnClick()
		{
			Action overrideCloseFunc = this.ViewModel.GetOverrideCloseFunc();
			if (overrideCloseFunc != null)
			{
				overrideCloseFunc();
				return;
			}
			base.Back();
		}

		// Token: 0x060372AE RID: 225966 RVA: 0x00E0245D File Offset: 0x00E0065D
		[NullableContext(2)]
		public PhantomArenaMainViewSwitchItem GetSwitchItem()
		{
			return this.SwitchItem;
		}

		// Token: 0x060372AF RID: 225967 RVA: 0x00E02465 File Offset: 0x00E00665
		public void SetViewTitle(string title)
		{
			this.CaptionItem.SetTitleLocalText(title);
		}

		// Token: 0x060372B0 RID: 225968 RVA: 0x00E02473 File Offset: 0x00E00673
		public void SetViewIcon(string icon)
		{
			this.CaptionItem.SetTitleIconByResourceId(icon);
		}

		// Token: 0x060372B1 RID: 225969 RVA: 0x00E02484 File Offset: 0x00E00684
		public void SetViewHelpId(int helpId)
		{
			this.CaptionItem.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
			});
		}

		// Token: 0x060372B2 RID: 225970 RVA: 0x00E024B5 File Offset: 0x00E006B5
		public void SetViewHelpBtnActive(bool bActive)
		{
			this.CaptionItem.SetHelpBtnActive(bActive);
		}

		// Token: 0x060372B3 RID: 225971 RVA: 0x00E024C3 File Offset: 0x00E006C3
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "SwitchItem"))
			{
				return base.GetCurChildView().GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			PhantomArenaMainViewSwitchItem switchItem = this.GetSwitchItem();
			if (switchItem == null)
			{
				return null;
			}
			return switchItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x060372B4 RID: 225972 RVA: 0x00E024FC File Offset: 0x00E006FC
		private void OnGuideFocusNeedUiTabView(GuideStepInfo stepInfo, GuideFocusNew focusConf)
		{
			PhantomArenaChildViewBase curChildView = base.GetCurChildView();
			EPhantomArenaChildViewName? ephantomArenaChildViewName;
			if (((curChildView.ViewName != null) ? ephantomArenaChildViewName.GetValueOrDefault().ToString() : null) != focusConf.DynamicTabName)
			{
				return;
			}
			stepInfo.ViewData.SetAttachedView(curChildView);
		}

		// Token: 0x0401FBEC RID: 130028
		[Nullable(2)]
		private PhantomArenaMainViewSwitchItem SwitchItem;

		// Token: 0x0401FBED RID: 130029
		[Nullable(2)]
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0401FBEE RID: 130030
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0401FBEF RID: 130031
		protected Dictionary<int, PhantomArenaMainViewRoleSpineItem> RoleSpineMap = new Dictionary<int, PhantomArenaMainViewRoleSpineItem>();

		// Token: 0x0401FBF0 RID: 130032
		[Nullable(2)]
		protected PhantomArenaMainViewRoleSpineItem CurShowRoleSpine;

		// Token: 0x0200B410 RID: 46096
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037B8D RID: 228237
			public const int CaptionItem = 0;

			// Token: 0x04037B8E RID: 228238
			public const int ContentItem = 1;

			// Token: 0x04037B8F RID: 228239
			public const int LightTextureA = 2;

			// Token: 0x04037B90 RID: 228240
			public const int SwitchItem = 3;

			// Token: 0x04037B91 RID: 228241
			public const int FrameItem = 4;

			// Token: 0x04037B92 RID: 228242
			public const int LightTextureB = 5;

			// Token: 0x04037B93 RID: 228243
			public const int RoleRootItem = 6;
		}
	}
}
