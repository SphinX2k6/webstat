using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x02006702 RID: 26370
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorDecalLinkRewardView : UiViewBase
	{
		// Token: 0x06041CDB RID: 269531 RVA: 0x010E212B File Offset: 0x010E032B
		public MotorDecalLinkRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06041CDC RID: 269532 RVA: 0x010E2158 File Offset: 0x010E0358
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUITexture)),
				new ValueTuple<int, Type>(13, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(delegate()
				{
					this.OnClickMoveBtn(-1);
				})),
				new ValueTuple<int, Delegate>(2, new Action(delegate()
				{
					this.OnClickMoveBtn(1);
				})),
				new ValueTuple<int, Delegate>(6, new Action<EToggleState>(delegate(EToggleState _)
				{
					this.OnDecalToggleStateChanged(0);
				})),
				new ValueTuple<int, Delegate>(8, new Action<EToggleState>(delegate(EToggleState _)
				{
					this.OnDecalToggleStateChanged(1);
				}))
			};
		}

		// Token: 0x06041CDD RID: 269533 RVA: 0x010E2314 File Offset: 0x010E0514
		protected override UniTask OnBeforeStartAsync()
		{
			MotorDecalLinkRewardView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorDecalLinkRewardView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041CDE RID: 269534 RVA: 0x010E2358 File Offset: 0x010E0558
		private void OnSequencePlayEvent(string sequenceName, string eventName)
		{
			if ((sequenceName == "Sle" && eventName == "On") || (sequenceName == "Change" && eventName == "On"))
			{
				MotorDecalLinkMainViewModel viewModel = this.ViewModel;
				MotorDecalLinkIpViewModel motorDecalLinkIpViewModel = (viewModel != null) ? viewModel.GetCurrentIpViewModel() : null;
				if (motorDecalLinkIpViewModel != null)
				{
					this.RefreshStickerPreview(motorDecalLinkIpViewModel);
				}
			}
		}

		// Token: 0x06041CDF RID: 269535 RVA: 0x010E23B6 File Offset: 0x010E05B6
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityRefresh));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnActivityRefresh));
		}

		// Token: 0x06041CE0 RID: 269536 RVA: 0x010E23F0 File Offset: 0x010E05F0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnActivityRefresh));
		}

		// Token: 0x06041CE1 RID: 269537 RVA: 0x010E242A File Offset: 0x010E062A
		private void OnActivityRefresh(int eventActivityId)
		{
			if (eventActivityId != this.ActivityId || this.ViewModel == null)
			{
				return;
			}
			this.Refresh(this.ViewModel, true);
		}

		// Token: 0x06041CE2 RID: 269538 RVA: 0x010E244B File Offset: 0x010E064B
		private MotorDecalLinkQuestItem QuestItemProxyCreate()
		{
			return new MotorDecalLinkQuestItem();
		}

		// Token: 0x06041CE3 RID: 269539 RVA: 0x010E2452 File Offset: 0x010E0652
		private MotorDecalLinkRewardViewDotItem CreateDotItem()
		{
			return new MotorDecalLinkRewardViewDotItem();
		}

		// Token: 0x06041CE4 RID: 269540 RVA: 0x010E245C File Offset: 0x010E065C
		private void OnDecalToggleStateChanged(int index)
		{
			this.SelectedDecalIndex = index;
			for (int i = 0; i < this.DecalToggleList.Count; i++)
			{
				if (i != index)
				{
					UUIExtendToggle uuiextendToggle = this.DecalToggleList[i];
					if (uuiextendToggle != null)
					{
						uuiextendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
					}
				}
			}
			LevelSequencePlayer viewRootSeqPlayer = this.ViewRootSeqPlayer;
			if (viewRootSeqPlayer == null)
			{
				return;
			}
			viewRootSeqPlayer.PlayLevelSequenceByName("Sle", false, null, false);
		}

		// Token: 0x06041CE5 RID: 269541 RVA: 0x010E24C8 File Offset: 0x010E06C8
		public void Refresh(MotorDecalLinkMainViewModel viewModel, bool isFastMode)
		{
			this.RefreshDotItem(viewModel);
			MotorDecalLinkIpViewModel currentIpViewModel = viewModel.GetCurrentIpViewModel();
			if (currentIpViewModel == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(5);
			string nameLogoPath = currentIpViewModel.GetNameLogoPath();
			base.SetTextureByPath(nameLogoPath, texture, null, null);
			string message = "Reward Logo";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("nameLogoPath", nameLogoPath);
			MotorDecalLinkUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.RefreshDecal(currentIpViewModel, isFastMode);
			List<MotorDecalLinkQuestViewModel> questViewModelList = currentIpViewModel.QuestViewModelList;
			GenericScrollViewNew<MotorDecalLinkQuestItem, MotorDecalLinkQuestViewModel> questScrollView = this.QuestScrollView;
			if (questScrollView == null)
			{
				return;
			}
			questScrollView.RefreshByData(questViewModelList, delegate
			{
				UUIInturnAnimController questAnimController = this.QuestAnimController;
				if (questAnimController == null)
				{
					return;
				}
				questAnimController.Play("", -1, false);
			}, false);
		}

		// Token: 0x06041CE6 RID: 269542 RVA: 0x010E2554 File Offset: 0x010E0754
		private void RefreshDecal(MotorDecalLinkIpViewModel ip, bool isFastMode)
		{
			int ipId = ip.IpId;
			int? currentIpId = this.CurrentIpId;
			if (ipId == currentIpId.GetValueOrDefault() & currentIpId != null)
			{
				return;
			}
			this.CurrentIpId = new int?(ip.IpId);
			List<string> decalTexturePaths = ip.DecalTexturePaths;
			bool flag = decalTexturePaths.Count >= 1;
			bool flag2 = decalTexturePaths.Count >= 2;
			string text = (decalTexturePaths.Count > 0) ? (decalTexturePaths[0] ?? "") : "";
			string path = (decalTexturePaths.Count >= 2) ? (decalTexturePaths[1] ?? "") : "";
			UUIExtendToggle uuiextendToggle = this.DecalToggleList[0];
			if (uuiextendToggle != null)
			{
				uuiextendToggle.RootUIComp.Get().SetUIActive(flag);
			}
			if (flag && !string.IsNullOrEmpty(text))
			{
				UUITexture texture = base.GetTexture(7);
				if (texture != null)
				{
					texture.SetUIActive(true);
				}
				base.SetTextureByPath(text, base.GetTexture(7), null, null);
			}
			else
			{
				UUITexture texture2 = base.GetTexture(7);
				if (texture2 != null)
				{
					texture2.SetUIActive(false);
				}
			}
			UUIExtendToggle uuiextendToggle2 = this.DecalToggleList[1];
			if (uuiextendToggle2 != null)
			{
				uuiextendToggle2.RootUIComp.Get().SetUIActive(flag2);
			}
			if (flag2)
			{
				UUITexture texture3 = base.GetTexture(9);
				if (texture3 != null)
				{
					texture3.SetUIActive(true);
				}
				base.SetTextureByPath(path, base.GetTexture(9), null, null);
			}
			else
			{
				UUITexture texture4 = base.GetTexture(9);
				if (texture4 != null)
				{
					texture4.SetUIActive(false);
				}
			}
			if (decalTexturePaths.Count >= 1)
			{
				UUIExtendToggle uuiextendToggle3 = this.DecalToggleList[0];
				if (uuiextendToggle3 != null)
				{
					uuiextendToggle3.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				}
				UUIExtendToggle uuiextendToggle4 = this.DecalToggleList[1];
				if (uuiextendToggle4 != null)
				{
					uuiextendToggle4.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				this.SelectedDecalIndex = 0;
			}
			if (!isFastMode)
			{
				LevelSequencePlayer stickerRootSeqPlayer = this.StickerRootSeqPlayer;
				if (stickerRootSeqPlayer != null)
				{
					stickerRootSeqPlayer.PlayLevelSequenceByName("Sle", false, null, false);
				}
				LevelSequencePlayer viewRootSeqPlayer = this.ViewRootSeqPlayer;
				if (viewRootSeqPlayer == null)
				{
					return;
				}
				viewRootSeqPlayer.PlayLevelSequenceByName("Change", false, null, false);
			}
		}

		// Token: 0x06041CE7 RID: 269543 RVA: 0x010E2768 File Offset: 0x010E0968
		private void RefreshStickerPreview(MotorDecalLinkIpViewModel ip)
		{
			string text = (this.SelectedDecalIndex >= 0 && this.SelectedDecalIndex < ip.DecalPreviewPaths.Count) ? ip.DecalPreviewPaths[this.SelectedDecalIndex] : "";
			UUITexture texture = base.GetTexture(12);
			string message = "Reward 贴纸预览";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", text);
			MotorDecalLinkUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (!string.IsNullOrEmpty(text) && texture != null)
			{
				base.SetTextureByPath(text, texture, null, null);
			}
		}

		// Token: 0x06041CE8 RID: 269544 RVA: 0x010E27F0 File Offset: 0x010E09F0
		private void RefreshDotItem(MotorDecalLinkMainViewModel viewModel)
		{
			if (this.DotLayout == null)
			{
				return;
			}
			int count = viewModel.IpList.Count;
			if (this.DotDataList.Count != count)
			{
				this.DotDataList.Clear();
				for (int i = 0; i < count; i++)
				{
					this.DotDataList.Add(false);
				}
			}
			for (int j = 0; j < count; j++)
			{
				this.DotDataList[j] = (j == viewModel.CurrentIpIndex);
			}
			this.DotLayout.RefreshByData(this.DotDataList, null, false);
		}

		// Token: 0x06041CE9 RID: 269545 RVA: 0x010E2877 File Offset: 0x010E0A77
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041CEA RID: 269546 RVA: 0x010E2880 File Offset: 0x010E0A80
		private void OnClickMoveBtn(int delta)
		{
			if (this.ViewModel == null)
			{
				return;
			}
			this.ViewModel.MoveSelectIpIndex(delta);
			this.Refresh(this.ViewModel, false);
		}

		// Token: 0x04024B83 RID: 150403
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B84 RID: 150404
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MotorDecalLinkRewardViewDotItem, bool> DotLayout;

		// Token: 0x04024B85 RID: 150405
		[Nullable(2)]
		private MotorDecalLinkMainViewModel ViewModel;

		// Token: 0x04024B86 RID: 150406
		private List<bool> DotDataList = new List<bool>();

		// Token: 0x04024B87 RID: 150407
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<MotorDecalLinkQuestItem, MotorDecalLinkQuestViewModel> QuestScrollView;

		// Token: 0x04024B88 RID: 150408
		private int ActivityId;

		// Token: 0x04024B89 RID: 150409
		private int? CurrentIpId = new int?(0);

		// Token: 0x04024B8A RID: 150410
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private List<UUIExtendToggle> DecalToggleList = new List<UUIExtendToggle>();

		// Token: 0x04024B8B RID: 150411
		private int SelectedDecalIndex;

		// Token: 0x04024B8C RID: 150412
		[Nullable(2)]
		private LevelSequencePlayer StickerRootSeqPlayer;

		// Token: 0x04024B8D RID: 150413
		[Nullable(2)]
		private LevelSequencePlayer ViewRootSeqPlayer;

		// Token: 0x04024B8E RID: 150414
		[Nullable(2)]
		private UUIInturnAnimController QuestAnimController;
	}
}
