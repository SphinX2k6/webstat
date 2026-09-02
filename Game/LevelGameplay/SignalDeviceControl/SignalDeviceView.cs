using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SignalDeviceControl.SiganalDeviceUIItem;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl
{
	// Token: 0x02006AFD RID: 27389
	[NullableContext(2)]
	[Nullable(0)]
	public class SignalDeviceView : UiViewBase
	{
		// Token: 0x06043B23 RID: 277283 RVA: 0x01175621 File Offset: 0x01173821
		[NullableContext(1)]
		public SignalDeviceView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043B24 RID: 277284 RVA: 0x01175640 File Offset: 0x01173840
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnResetClicked)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnBtnBackClicked)),
				new ValueTuple<int, Delegate>(2, new Action(this.OnBtnHelpClicked))
			};
		}

		// Token: 0x06043B25 RID: 277285 RVA: 0x011757D0 File Offset: 0x011739D0
		protected override UniTask OnCreateAsync()
		{
			SignalDeviceView.<OnCreateAsync>d__13 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<SignalDeviceView.<OnCreateAsync>d__13>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043B26 RID: 277286 RVA: 0x01175814 File Offset: 0x01173A14
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			LinkingEmptyToggle linkingEmptyToggle = new LinkingEmptyToggle();
			linkingEmptyToggle.CreateThenShowByActor(base.GetExtendToggle(5).GetOwner(), null);
			this.GridToggleList.Add(linkingEmptyToggle);
			UUIItem item = base.GetItem(6);
			TWeakObjectPtr<UUIItem> rootUIComp = base.GetExtendToggle(5).RootUIComp;
			this.GridUiItemList.Add(rootUIComp);
			for (int i = 1; i < SignalDeviceViewConstants.GRIDNUM; i++)
			{
				UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(rootUIComp, item);
				this.GridUiItemList.Add(uuiitem);
				LinkingEmptyToggle linkingEmptyToggle2 = new LinkingEmptyToggle();
				linkingEmptyToggle2.CreateThenShowByActor(uuiitem.GetOwner(), null);
				linkingEmptyToggle2.InitData(i);
				this.GridToggleList.Add(linkingEmptyToggle2);
			}
			linkingEmptyToggle.InitData(0);
			base.GetButton(0).SetSelfInteractive(false);
			this.InitTemp();
			Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_open");
		}

		// Token: 0x06043B27 RID: 277287 RVA: 0x01175904 File Offset: 0x01173B04
		private void InitTemp()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignalDeviceLinking, new Action<bool, int, bool, int, bool>(this.OnSignalDeviceLinking));
			Singleton<EventSystem>.Instance.Add<bool, IReadOnlyList<int>>(EEventName.OnSignalDeviceLinkingCheck, new Action<bool, IReadOnlyList<int>>(this.OnSignalDeviceLinkingCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignalDeviceReset, new Action(this.OnSignalDeviceReset));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignalDeviceFinish, new Action(this.OnSignalDeviceFinish));
			this.Config = (this.OpenParam as List<IColorPiece>);
			if (this.Config == null || this.Config.Count != SignalDeviceViewConstants.GRIDNUM)
			{
				return;
			}
			for (int i = 0; i < SignalDeviceViewConstants.GRIDNUM; i++)
			{
				if (this.Config[i].Color != EPieceColorType.White)
				{
					this.LoadDotNode(i, this.Config[i].Color);
				}
			}
			base.GetText(3).SetText(ConfigBase<TextConfig>.Instance.GetTextById("SignalDeviceTitleText") ?? "???", true);
			base.GetText(4).SetText(ConfigBase<TextConfig>.Instance.GetTextById("SignalDeviceDescriptionText") ?? "???", true);
			base.GetText(7).SetText(ConfigBase<TextConfig>.Instance.GetTextById("SignalDeviceResetText") ?? "???", true);
		}

		// Token: 0x06043B28 RID: 277288 RVA: 0x01175A58 File Offset: 0x01173C58
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceLinking, new Action<bool, int, bool, int, bool>(this.OnSignalDeviceLinking));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceLinkingCheck, new Action<bool, IReadOnlyList<int>>(this.OnSignalDeviceLinkingCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceReset, new Action(this.OnSignalDeviceReset));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceFinish, new Action(this.OnSignalDeviceFinish));
		}

		// Token: 0x06043B29 RID: 277289 RVA: 0x01175AD8 File Offset: 0x01173CD8
		private void OnBtnBackClicked()
		{
			if (!this.NeedTipExit)
			{
				Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ButtonReset);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06043B2A RID: 277290 RVA: 0x01175B30 File Offset: 0x01173D30
		private void OnBtnResetClicked()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ButtonReset);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Signal, ELoadingPerform.CameraFade, "SignalDeviceReset", delegate
				{
					ControllerBase<SignalDeviceController>.Instance.ResetAll();
					base.GetButton(0).SetSelfInteractive(false);
					this.NeedTipExit = false;
					ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Signal, "SignalDeviceReset", null, null);
				}, Array.Empty<object>());
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06043B2B RID: 277291 RVA: 0x01175B69 File Offset: 0x01173D69
		private void OnBtnHelpClicked()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SignalDeviceGuideView, null, null);
		}

		// Token: 0x06043B2C RID: 277292 RVA: 0x01175B7C File Offset: 0x01173D7C
		private void LoadDotNode(int index, EPieceColorType color)
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(this.LinkingDotItem.GetRootItem(), this.GridUiItemList[index]);
			uuiitem.SetHierarchyIndex(0);
			this.GridToggleList[index].SetDotData(uuiitem, color);
		}

		// Token: 0x06043B2D RID: 277293 RVA: 0x01175BC8 File Offset: 0x01173DC8
		private unsafe void OnSignalDeviceLinking(bool isAdd, int from, bool isFromDot, int to, bool isToDot)
		{
			this.SetDotUpper(isAdd, from, isFromDot, to, isToDot);
			if (isAdd)
			{
				if (this.Config[to].Color == EPieceColorType.White)
				{
					UUIItem item = isFromDot ? this.LinkingLineWithDotStraight.GetRootItem() : this.LinkingLineStraight.GetRootItem();
					UUIItem item2 = Singleton<LguiUtil>.Instance.CopyItem(item, this.GridUiItemList[to]);
					LinkingLineItem itemClass = isFromDot ? LinkingLineItem.Create(ELineType.LinkingLineWithDotStraight) : LinkingLineItem.Create(ELineType.LinkingLineStraight);
					ENeighborType neighborType = ModelBase<SignalDeviceModel>.Instance.NeighboringType(from, to);
					this.GridToggleList[to].SetLineData(item2, itemClass, neighborType, from, isFromDot);
				}
				if (this.Config[from].Color == EPieceColorType.White)
				{
					int fromIndex = this.GridToggleList[from].FromIndex;
					bool isFromDot2 = this.GridToggleList[from].IsFromDot;
					if (Math.Abs(fromIndex - to) == SignalDeviceModel.ROWNUM * 2 || Math.Abs(fromIndex - to) == 2)
					{
						bool flag = isFromDot2 || isToDot;
						UUIItem item3 = flag ? this.LinkingLineWithDotStraight.GetRootItem() : this.LinkingLineStraight.GetRootItem();
						UUIItem item4 = Singleton<LguiUtil>.Instance.CopyItem(item3, this.GridUiItemList[from]);
						LinkingLineItem itemClass2 = flag ? LinkingLineItem.Create(ELineType.LinkingLineWithDotStraight) : LinkingLineItem.Create(ELineType.LinkingLineWithDotStraight);
						this.GridToggleList[from].ResetStraightLineData(item4, itemClass2, to);
						return;
					}
					if (Math.Abs(fromIndex - to) == SignalDeviceModel.ROWNUM - 1 || Math.Abs(fromIndex - to) == SignalDeviceModel.ROWNUM + 1)
					{
						bool flag2 = isFromDot2 || isToDot;
						UUIItem item5 = flag2 ? (this.IsCornerLeftOrRight(fromIndex, isFromDot2, from, to, isToDot) ? this.LinkingLineWithDotCornerLeft.GetRootItem() : this.LinkingLineWithDotCornerRight.GetRootItem()) : this.LinkingLineCorner.GetRootItem();
						UUIItem item6 = Singleton<LguiUtil>.Instance.CopyItem(item5, this.GridUiItemList[from]);
						LinkingLineItem itemClass3 = flag2 ? (this.IsCornerLeftOrRight(fromIndex, isFromDot2, from, to, isToDot) ? LinkingLineItem.Create(ELineType.LinkingLineWithDotCornerLeft) : LinkingLineItem.Create(ELineType.LinkingLineWithDotCornerRight)) : LinkingLineItem.Create(ELineType.LinkingLineCorner);
						this.GridToggleList[from].ResetCornerLineData(item6, itemClass3, from, to, isToDot);
						return;
					}
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Temp;
					ELogAuthor author = ELogAuthor.ZFJ;
					string message = "OnSignalDeviceLinking From Error";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("from", from);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("beforeIndex", fromIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("to", to);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return;
				}
			}
			else
			{
				this.GridToggleList[from].ClearLineData();
				if (this.Config[to].Color == EPieceColorType.White)
				{
					this.GridToggleList[to].SetLineHalf();
				}
			}
		}

		// Token: 0x06043B2E RID: 277294 RVA: 0x01175EA8 File Offset: 0x011740A8
		private void SetDotUpper(bool isAdd, int from, bool isFromDot, int to, bool isToDot)
		{
			if (isAdd)
			{
				if (isFromDot)
				{
					ENeighborType neighborType = ModelBase<SignalDeviceModel>.Instance.NeighboringType(to, from);
					this.GridToggleList[from].SetDotRay(true, neighborType);
				}
				if (isToDot)
				{
					ENeighborType neighborType2 = ModelBase<SignalDeviceModel>.Instance.NeighboringType(from, to);
					this.GridToggleList[to].SetDotRay(true, neighborType2);
					return;
				}
			}
			else
			{
				if (isFromDot)
				{
					this.GridToggleList[from].SetDotRay(false, ENeighborType.None);
				}
				if (isToDot)
				{
					this.GridToggleList[to].SetDotRay(false, ENeighborType.None);
				}
			}
		}

		// Token: 0x06043B2F RID: 277295 RVA: 0x01175F34 File Offset: 0x01174134
		private bool IsCornerLeftOrRight(int beforeIndex, bool isBeforeDot, int from, int to, bool isToDot)
		{
			if (isBeforeDot)
			{
				if (Math.Abs(from - beforeIndex) == SignalDeviceModel.ROWNUM)
				{
					return (from - beforeIndex) * (to - from) == -SignalDeviceModel.ROWNUM;
				}
				if (Math.Abs(from - beforeIndex) == 1)
				{
					return (from - beforeIndex) * (to - from) == SignalDeviceModel.ROWNUM;
				}
				Singleton<global::Log>.Instance.Warn(ELogModule.Temp, ELogAuthor.ZFJ, "IsCornerLeftOrRight Error", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			else
			{
				if (!isToDot)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Temp, ELogAuthor.ZFJ, "IsCornerLeftOrRight no dot", default(ReadOnlySpan<ValueTuple<string, object>>));
					return false;
				}
				if (Math.Abs(from - beforeIndex) == 1)
				{
					return (from - beforeIndex) * (to - from) == -SignalDeviceModel.ROWNUM;
				}
				if (Math.Abs(from - beforeIndex) == SignalDeviceModel.ROWNUM)
				{
					return (from - beforeIndex) * (to - from) == SignalDeviceModel.ROWNUM;
				}
				Singleton<global::Log>.Instance.Warn(ELogModule.Temp, ELogAuthor.ZFJ, "IsCornerLeftOrRight Error", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}

		// Token: 0x06043B30 RID: 277296 RVA: 0x01176014 File Offset: 0x01174214
		[NullableContext(1)]
		private void OnSignalDeviceLinkingCheck(bool isSuccess, IReadOnlyList<int> indexArray)
		{
			if (isSuccess)
			{
				base.GetButton(0).SetSelfInteractive(true);
				Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_conncet");
			}
		}

		// Token: 0x06043B31 RID: 277297 RVA: 0x01176036 File Offset: 0x01174236
		private void OnSignalDeviceReset()
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_reset");
		}

		// Token: 0x06043B32 RID: 277298 RVA: 0x01176048 File Offset: 0x01174248
		private void OnSignalDeviceFinish()
		{
			base.GetButton(0).SetSelfInteractive(false);
			this.SetBgFx(true);
		}

		// Token: 0x06043B33 RID: 277299 RVA: 0x01176060 File Offset: 0x01174260
		private UniTask SetBgFx(bool isOpen)
		{
			SignalDeviceView.<SetBgFx>d__27 <SetBgFx>d__;
			<SetBgFx>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetBgFx>d__.<>4__this = this;
			<SetBgFx>d__.isOpen = isOpen;
			<SetBgFx>d__.<>1__state = -1;
			<SetBgFx>d__.<>t__builder.Start<SignalDeviceView.<SetBgFx>d__27>(ref <SetBgFx>d__);
			return <SetBgFx>d__.<>t__builder.Task;
		}

		// Token: 0x04025D35 RID: 154933
		private LinkingDotItem LinkingDotItem;

		// Token: 0x04025D36 RID: 154934
		private LinkingLineItem LinkingLineCorner;

		// Token: 0x04025D37 RID: 154935
		private LinkingLineItem LinkingLineStraight;

		// Token: 0x04025D38 RID: 154936
		private LinkingLineItem LinkingLineWithDotCornerLeft;

		// Token: 0x04025D39 RID: 154937
		private LinkingLineItem LinkingLineWithDotCornerRight;

		// Token: 0x04025D3A RID: 154938
		private LinkingLineItem LinkingLineWithDotStraight;

		// Token: 0x04025D3B RID: 154939
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04025D3C RID: 154940
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IColorPiece> Config;

		// Token: 0x04025D3D RID: 154941
		[Nullable(1)]
		private readonly List<UUIItem> GridUiItemList = new List<UUIItem>();

		// Token: 0x04025D3E RID: 154942
		[Nullable(1)]
		private readonly List<LinkingEmptyToggle> GridToggleList = new List<LinkingEmptyToggle>();

		// Token: 0x04025D3F RID: 154943
		private bool NeedTipExit;
	}
}
