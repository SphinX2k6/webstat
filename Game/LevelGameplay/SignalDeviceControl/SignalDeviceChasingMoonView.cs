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
	// Token: 0x02006AF1 RID: 27377
	[NullableContext(2)]
	[Nullable(0)]
	public class SignalDeviceChasingMoonView : UiViewBase
	{
		// Token: 0x06043AD9 RID: 277209 RVA: 0x01173D15 File Offset: 0x01171F15
		[NullableContext(1)]
		public SignalDeviceChasingMoonView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043ADA RID: 277210 RVA: 0x01173D34 File Offset: 0x01171F34
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

		// Token: 0x06043ADB RID: 277211 RVA: 0x01173EC4 File Offset: 0x011720C4
		protected override UniTask OnCreateAsync()
		{
			SignalDeviceChasingMoonView.<OnCreateAsync>d__13 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<SignalDeviceChasingMoonView.<OnCreateAsync>d__13>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043ADC RID: 277212 RVA: 0x01173F08 File Offset: 0x01172108
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			LinkingEmptyToggle linkingEmptyToggle = new LinkingEmptyToggle();
			linkingEmptyToggle.CreateThenShowByActor(base.GetExtendToggle(5).GetOwner(), null);
			this.GridToggleList.Add(linkingEmptyToggle);
			UUIItem item = base.GetItem(6);
			TWeakObjectPtr<UUIItem> rootUIComp = base.GetExtendToggle(5).RootUIComp;
			this.GridUiItemList.Add(rootUIComp);
			for (int i = 1; i < SignalDeviceChasingMoonViewConstants.GRIDNUM; i++)
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

		// Token: 0x06043ADD RID: 277213 RVA: 0x01173FF8 File Offset: 0x011721F8
		private void InitTemp()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignalDeviceLinking, new Action<bool, int, bool, int, bool>(this.OnSignalDeviceLinking));
			Singleton<EventSystem>.Instance.Add<bool, IReadOnlyList<int>>(EEventName.OnSignalDeviceLinkingCheck, new Action<bool, IReadOnlyList<int>>(this.OnSignalDeviceLinkingCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignalDeviceReset, new Action(this.OnSignalDeviceReset));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignalDeviceFinish, new Action(this.OnSignalDeviceFinish));
			this.Config = (this.OpenParam as List<IColorPiece>);
			if (this.Config == null || this.Config.Count != SignalDeviceChasingMoonViewConstants.GRIDNUM)
			{
				return;
			}
			for (int i = 0; i < SignalDeviceChasingMoonViewConstants.GRIDNUM; i++)
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

		// Token: 0x06043ADE RID: 277214 RVA: 0x0117414C File Offset: 0x0117234C
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceLinking, new Action<bool, int, bool, int, bool>(this.OnSignalDeviceLinking));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceLinkingCheck, new Action<bool, IReadOnlyList<int>>(this.OnSignalDeviceLinkingCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceReset, new Action(this.OnSignalDeviceReset));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceFinish, new Action(this.OnSignalDeviceFinish));
		}

		// Token: 0x06043ADF RID: 277215 RVA: 0x011741CC File Offset: 0x011723CC
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

		// Token: 0x06043AE0 RID: 277216 RVA: 0x01174224 File Offset: 0x01172424
		private void OnBtnResetClicked()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ButtonReset);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Signal, ELoadingPerform.CameraFade, null, delegate
				{
					ControllerBase<SignalDeviceController>.Instance.ResetAll();
					base.GetButton(0).SetSelfInteractive(false);
					this.NeedTipExit = false;
					ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Signal, null, null, null);
				}, Array.Empty<object>());
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06043AE1 RID: 277217 RVA: 0x0117425D File Offset: 0x0117245D
		private void OnBtnHelpClicked()
		{
		}

		// Token: 0x06043AE2 RID: 277218 RVA: 0x01174260 File Offset: 0x01172460
		private void LoadDotNode(int index, EPieceColorType color)
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(this.LinkingDotItem.GetRootItem(), this.GridUiItemList[index]);
			uuiitem.SetHierarchyIndex(0);
			this.GridToggleList[index].SetDotData(uuiitem, color);
		}

		// Token: 0x06043AE3 RID: 277219 RVA: 0x011742AC File Offset: 0x011724AC
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

		// Token: 0x06043AE4 RID: 277220 RVA: 0x0117458C File Offset: 0x0117278C
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

		// Token: 0x06043AE5 RID: 277221 RVA: 0x01174618 File Offset: 0x01172818
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

		// Token: 0x06043AE6 RID: 277222 RVA: 0x011746F8 File Offset: 0x011728F8
		[NullableContext(1)]
		private void OnSignalDeviceLinkingCheck(bool isSuccess, IReadOnlyList<int> indexArray)
		{
			if (isSuccess)
			{
				base.GetButton(0).SetSelfInteractive(true);
				Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_conncet");
			}
		}

		// Token: 0x06043AE7 RID: 277223 RVA: 0x0117471A File Offset: 0x0117291A
		private void OnSignalDeviceReset()
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_reset");
		}

		// Token: 0x06043AE8 RID: 277224 RVA: 0x0117472C File Offset: 0x0117292C
		private void OnSignalDeviceFinish()
		{
			base.GetButton(0).SetSelfInteractive(false);
			this.SetBgFx(true);
		}

		// Token: 0x06043AE9 RID: 277225 RVA: 0x01174744 File Offset: 0x01172944
		private UniTask SetBgFx(bool isOpen)
		{
			SignalDeviceChasingMoonView.<SetBgFx>d__27 <SetBgFx>d__;
			<SetBgFx>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetBgFx>d__.<>4__this = this;
			<SetBgFx>d__.isOpen = isOpen;
			<SetBgFx>d__.<>1__state = -1;
			<SetBgFx>d__.<>t__builder.Start<SignalDeviceChasingMoonView.<SetBgFx>d__27>(ref <SetBgFx>d__);
			return <SetBgFx>d__.<>t__builder.Task;
		}

		// Token: 0x04025CEF RID: 154863
		private LinkingDotItem LinkingDotItem;

		// Token: 0x04025CF0 RID: 154864
		private LinkingLineItem LinkingLineCorner;

		// Token: 0x04025CF1 RID: 154865
		private LinkingLineItem LinkingLineStraight;

		// Token: 0x04025CF2 RID: 154866
		private LinkingLineItem LinkingLineWithDotCornerLeft;

		// Token: 0x04025CF3 RID: 154867
		private LinkingLineItem LinkingLineWithDotCornerRight;

		// Token: 0x04025CF4 RID: 154868
		private LinkingLineItem LinkingLineWithDotStraight;

		// Token: 0x04025CF5 RID: 154869
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04025CF6 RID: 154870
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IColorPiece> Config;

		// Token: 0x04025CF7 RID: 154871
		[Nullable(1)]
		private readonly List<UUIItem> GridUiItemList = new List<UUIItem>();

		// Token: 0x04025CF8 RID: 154872
		[Nullable(1)]
		private readonly List<LinkingEmptyToggle> GridToggleList = new List<LinkingEmptyToggle>();

		// Token: 0x04025CF9 RID: 154873
		private bool NeedTipExit;
	}
}
