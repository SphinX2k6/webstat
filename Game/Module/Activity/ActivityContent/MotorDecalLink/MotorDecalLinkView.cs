using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x02006707 RID: 26375
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorDecalLinkView : ActivitySubViewBase
	{
		// Token: 0x06041D00 RID: 269568 RVA: 0x010E2D7C File Offset: 0x010E0F7C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(delegate()
				{
					this.OnClickMoveBtn(-1);
				})),
				new ValueTuple<int, Delegate>(8, new Action(delegate()
				{
					this.OnClickMoveBtn(1);
				})),
				new ValueTuple<int, Delegate>(1, new Action(delegate()
				{
					this.ShowStickerItemTips(0);
				})),
				new ValueTuple<int, Delegate>(11, new Action(delegate()
				{
					this.ShowStickerItemTips(this.RightDecalIndex);
				}))
			};
		}

		// Token: 0x06041D01 RID: 269569 RVA: 0x010E2F24 File Offset: 0x010E1124
		protected override UniTask OnBeforeStartAsync()
		{
			MotorDecalLinkView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorDecalLinkView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041D02 RID: 269570 RVA: 0x010E2F68 File Offset: 0x010E1168
		protected override void OnStart()
		{
			MotorDecalLinkData motorDecalLinkData = this.ActivityBaseData as MotorDecalLinkData;
			if (motorDecalLinkData == null)
			{
				return;
			}
			ControllerBase<MotorDecalLinkController>.Instance.OnFirstRead(motorDecalLinkData.Id);
			this.OnRefreshView();
		}

		// Token: 0x06041D03 RID: 269571 RVA: 0x010E2F9C File Offset: 0x010E119C
		protected override void OnRefreshView()
		{
			MotorDecalLinkData motorDecalLinkData = this.ActivityBaseData as MotorDecalLinkData;
			if (motorDecalLinkData != null && motorDecalLinkData.MainViewModel != null)
			{
				this.ViewModel = motorDecalLinkData.MainViewModel;
				this.Refresh(motorDecalLinkData.MainViewModel);
			}
		}

		// Token: 0x06041D04 RID: 269572 RVA: 0x010E2FD8 File Offset: 0x010E11D8
		private void Refresh(MotorDecalLinkMainViewModel viewModel)
		{
			this.RefreshDotItem(viewModel);
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(viewModel.ProgressText, true);
			}
			MotorDecalLinkIpViewModel currentIpViewModel = viewModel.GetCurrentIpViewModel();
			if (currentIpViewModel == null)
			{
				return;
			}
			bool flag;
			if (this.CurrentIpId != null)
			{
				int? currentIpId = this.CurrentIpId;
				int ipId = currentIpViewModel.IpId;
				flag = !(currentIpId.GetValueOrDefault() == ipId & currentIpId != null);
			}
			else
			{
				flag = true;
			}
			this.CurrentIpId = new int?(currentIpViewModel.IpId);
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.SetFunctionRedDotVisible(viewModel.HasRewardCanReceive);
			}
			this.RefreshDecal(currentIpViewModel);
			UUITexture texture = base.GetTexture(6);
			string nameLogoPath = currentIpViewModel.GetNameLogoPath();
			base.SetTextureByPath(nameLogoPath, texture, null, null);
			string message = "LinkView Logo";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("nameLogoPath", nameLogoPath);
			MotorDecalLinkUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			UUITexture texture2 = base.GetTexture(5);
			base.SetTextureByPath(currentIpViewModel.MainPicturePath, texture2, null, null);
			string message2 = "LinkView MainPicture";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("mainPicturePath", currentIpViewModel.MainPicturePath);
			MotorDecalLinkUtil.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			if (flag)
			{
				LevelSequencePlayer stickerRootSeqPlayer = this.StickerRootSeqPlayer;
				if (stickerRootSeqPlayer == null)
				{
					return;
				}
				stickerRootSeqPlayer.PlayLevelSequenceByName("Sle", false, null, false);
			}
		}

		// Token: 0x06041D05 RID: 269573 RVA: 0x010E311C File Offset: 0x010E131C
		private void RefreshDecal(MotorDecalLinkIpViewModel ip)
		{
			List<string> decalTexturePaths = ip.DecalTexturePaths;
			bool flag = decalTexturePaths.Count >= 2;
			string path = flag ? decalTexturePaths[0] : "";
			string path2 = flag ? decalTexturePaths[1] : ((decalTexturePaths.Count > 0) ? decalTexturePaths[0] : "");
			this.RightDecalIndex = ((flag > false) ? 1 : 0);
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			if (flag)
			{
				base.SetTextureByPath(path, base.GetTexture(2), null, null);
			}
			base.SetTextureByPath(path2, base.GetTexture(3), null, null);
		}

		// Token: 0x06041D06 RID: 269574 RVA: 0x010E31D4 File Offset: 0x010E13D4
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

		// Token: 0x06041D07 RID: 269575 RVA: 0x010E325C File Offset: 0x010E145C
		private void GotoRewardView()
		{
			MotorDecalLinkUtil.Debug("GotoRewardView", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorDecalLinkRewardView, this.ViewModel, null);
		}

		// Token: 0x06041D08 RID: 269576 RVA: 0x010E3292 File Offset: 0x010E1492
		private void OnClickMoveBtn(int delta)
		{
			if (this.ViewModel == null)
			{
				return;
			}
			this.ViewModel.MoveSelectIpIndex(delta);
			this.OnRefreshView();
		}

		// Token: 0x06041D09 RID: 269577 RVA: 0x010E32B0 File Offset: 0x010E14B0
		private void ShowStickerItemTips(int index)
		{
			MotorDecalLinkMainViewModel viewModel = this.ViewModel;
			MotorDecalLinkIpViewModel motorDecalLinkIpViewModel = (viewModel != null) ? viewModel.GetCurrentIpViewModel() : null;
			if (motorDecalLinkIpViewModel == null)
			{
				return;
			}
			if (index < 0 || index >= motorDecalLinkIpViewModel.StickerList.Count)
			{
				return;
			}
			int itemId = motorDecalLinkIpViewModel.StickerList[index];
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, false, null);
		}

		// Token: 0x04024BA1 RID: 150433
		[Nullable(2)]
		private ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x04024BA2 RID: 150434
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MotorDecalLinkViewDotItem, bool> DotLayout;

		// Token: 0x04024BA3 RID: 150435
		[Nullable(2)]
		private MotorDecalLinkMainViewModel ViewModel;

		// Token: 0x04024BA4 RID: 150436
		private List<bool> DotDataList = new List<bool>();

		// Token: 0x04024BA5 RID: 150437
		private int RightDecalIndex;

		// Token: 0x04024BA6 RID: 150438
		private int? CurrentIpId;

		// Token: 0x04024BA7 RID: 150439
		[Nullable(2)]
		private LevelSequencePlayer StickerRootSeqPlayer;
	}
}
