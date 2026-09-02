using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.GravityFlip
{
	// Token: 0x02006E80 RID: 28288
	[NullableContext(2)]
	[Nullable(0)]
	public class GravityFlipView : UiViewBase
	{
		// Token: 0x060449B0 RID: 281008 RVA: 0x011D5B95 File Offset: 0x011D3D95
		[NullableContext(1)]
		public GravityFlipView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060449B1 RID: 281009 RVA: 0x011D5BA8 File Offset: 0x011D3DA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
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
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnUpArrowClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnLeftArrowClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnRightArrowClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnCloseClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnDownArrowClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060449B2 RID: 281010 RVA: 0x011D5D80 File Offset: 0x011D3F80
		protected override void OnStart()
		{
			this.BtnUpArrow = base.GetButton(0);
			this.BtnLeftArrow = base.GetButton(1);
			this.BtnRightArrow = base.GetButton(2);
			this.BtnDownArrow = base.GetButton(4);
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			this.DownArrowSeqPlayer = new LevelSequencePlayer(this.BtnDownArrow.RootUIComp);
			this.TargetDirection = (int)ModelBase<GravityFlipModel>.Instance.TargetDirection;
			if (this.TargetDirection == -1)
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(false);
				}
			}
			GravityFlipViewOpenParam gravityFlipViewOpenParam = this.OpenParam as GravityFlipViewOpenParam;
			ModelBase<GravityFlipModel>.Instance.ViewCallBackCache = ((gravityFlipViewOpenParam != null) ? gravityFlipViewOpenParam.SelectCallback : null);
		}

		// Token: 0x060449B3 RID: 281011 RVA: 0x011D5E3B File Offset: 0x011D403B
		protected override void OnBeforeShow()
		{
			this.SetBtnState(true);
		}

		// Token: 0x060449B4 RID: 281012 RVA: 0x011D5E44 File Offset: 0x011D4044
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnGravityFlipAnimFinish, new Action(this.OnGravityFlipAnimFinish));
		}

		// Token: 0x060449B5 RID: 281013 RVA: 0x011D5E62 File Offset: 0x011D4062
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnGravityFlipAnimFinish, new Action(this.OnGravityFlipAnimFinish));
		}

		// Token: 0x060449B6 RID: 281014 RVA: 0x011D5E80 File Offset: 0x011D4080
		private void OnCloseClick()
		{
			if (this.IsPlayingTurnAnim)
			{
				return;
			}
			GravityFlipViewOpenParam gravityFlipViewOpenParam = this.OpenParam as GravityFlipViewOpenParam;
			Action<int> callback = (gravityFlipViewOpenParam != null) ? gravityFlipViewOpenParam.SelectCallback : null;
			ControllerBase<GravityFlipController>.Instance.ListenTeleportCompleteEvent(callback);
			SceneItemGravityFlipComponent gravityFlipComp = ModelBase<GravityFlipModel>.Instance.GravityFlipComp;
			if (gravityFlipComp != null)
			{
				gravityFlipComp.OnExitInteract(false);
			}
			this.RequestGravityFlip();
			base.CloseMe(null);
		}

		// Token: 0x060449B7 RID: 281015 RVA: 0x011D5EDC File Offset: 0x011D40DC
		private void OnUpArrowClick()
		{
			this.OnArrowBtnClick(0);
		}

		// Token: 0x060449B8 RID: 281016 RVA: 0x011D5EE5 File Offset: 0x011D40E5
		private void OnLeftArrowClick()
		{
			this.OnArrowBtnClick(1);
		}

		// Token: 0x060449B9 RID: 281017 RVA: 0x011D5EEE File Offset: 0x011D40EE
		private void OnRightArrowClick()
		{
			this.OnArrowBtnClick(2);
		}

		// Token: 0x060449BA RID: 281018 RVA: 0x011D5EF7 File Offset: 0x011D40F7
		private void OnDownArrowClick()
		{
			this.OnArrowBtnClick(4);
		}

		// Token: 0x060449BB RID: 281019 RVA: 0x011D5F00 File Offset: 0x011D4100
		private void OnArrowBtnClick(int btn)
		{
			if (this.IsPlayingTurnAnim)
			{
				return;
			}
			int num = -1;
			int num2 = 0;
			string sequenceName = "Turn_180";
			switch (btn)
			{
			case 0:
				num2 = 180;
				num = 2;
				sequenceName = "Turn_180";
				break;
			case 1:
				num2 = 90;
				num = 1;
				sequenceName = "Turn_90_Zheng";
				break;
			case 2:
				num2 = 270;
				num = 0;
				sequenceName = "Turn_90_Fu";
				break;
			case 4:
				num2 = 0;
				break;
			}
			EGravityDirection currentGravityDirection = ModelBase<GravityFlipModel>.Instance.CurrentGravityDirection;
			ModelBase<GravityFlipModel>.Instance.CurrentGravityDirection = (num2 + currentGravityDirection) % (EGravityDirection)360;
			if (num != -1)
			{
				GravityFlipViewOpenParam gravityFlipViewOpenParam = this.OpenParam as GravityFlipViewOpenParam;
				Action<int> action = (gravityFlipViewOpenParam != null) ? gravityFlipViewOpenParam.SelectCallback : null;
				if (action != null)
				{
					action(num);
				}
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer != null)
				{
					seqPlayer.PlayLevelSequenceByName("Turn", false, null, false);
				}
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequence(sequenceName, false, null);
				}
				ControllerBase<GravityFlipController>.Instance.OnChangeGravityDirection((EGravityDirection)num2);
				this.IsPlayingTurnAnim = true;
			}
			this.SetAllBtnInteractive(false);
		}

		// Token: 0x060449BC RID: 281020 RVA: 0x011D6008 File Offset: 0x011D4208
		private void OnGravityFlipAnimFinish()
		{
			this.SetBtnState(false);
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Turn_Finish", false, null, false);
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequence("Turn_Finish", false, null);
			}
			this.IsPlayingTurnAnim = false;
		}

		// Token: 0x060449BD RID: 281021 RVA: 0x011D6064 File Offset: 0x011D4264
		private void SetBtnState(bool isInit = false)
		{
			this.SetAllBtnInteractive(false);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num = (this.TargetDirection == -1) ? 0 : this.TargetDirection;
			EGravityDirection curGravityDirection = ModelBase<GravityFlipModel>.Instance.GravityFlipComp.CurGravityDirection;
			int num2 = (360 + curGravityDirection - (EGravityDirection)num) % 360;
			if (isInit && this.TargetDirection != -1)
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					FRotator frotator = new FRotator(0f, (float)num2, 0f);
					item.SetUIRelativeRotation(frotator);
				}
			}
			foreach (EGravityDirection egravityDirection in ModelBase<GravityFlipModel>.Instance.ValidGravityDirections)
			{
				int num3 = (int)(((EGravityDirection)360 - (int)ModelBase<GravityFlipModel>.Instance.CurrentGravityDirection + (int)egravityDirection) % (EGravityDirection)360);
				if (num3 != 90)
				{
					if (num3 != 180)
					{
						if (num3 == 270)
						{
							flag2 = true;
						}
					}
					else
					{
						flag3 = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			if (flag2 != this.BtnRightArrow.GetSelfInteractive())
			{
				UUIButtonComponent btnRightArrow = this.BtnRightArrow;
				if (btnRightArrow != null)
				{
					btnRightArrow.SetSelfInteractive(flag2);
				}
				UUIButtonComponent btnRightArrow2 = this.BtnRightArrow;
				if (btnRightArrow2 != null)
				{
					btnRightArrow2.RootUIComp.Get().SetUIActive(flag2);
				}
			}
			if (flag != this.BtnLeftArrow.GetSelfInteractive())
			{
				UUIButtonComponent btnLeftArrow = this.BtnLeftArrow;
				if (btnLeftArrow != null)
				{
					btnLeftArrow.SetSelfInteractive(flag);
				}
				UUIButtonComponent btnLeftArrow2 = this.BtnLeftArrow;
				if (btnLeftArrow2 != null)
				{
					btnLeftArrow2.RootUIComp.Get().SetUIActive(flag);
				}
			}
			if (flag3 != this.BtnUpArrow.GetSelfInteractive())
			{
				UUIButtonComponent btnUpArrow = this.BtnUpArrow;
				if (btnUpArrow != null)
				{
					btnUpArrow.SetSelfInteractive(flag3);
				}
				UUIButtonComponent btnUpArrow2 = this.BtnUpArrow;
				if (btnUpArrow2 != null)
				{
					btnUpArrow2.RootUIComp.Get().SetUIActive(flag3);
				}
			}
			LevelSequencePlayer downArrowSeqPlayer = this.DownArrowSeqPlayer;
			if (downArrowSeqPlayer != null)
			{
				downArrowSeqPlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer downArrowSeqPlayer2 = this.DownArrowSeqPlayer;
			if (downArrowSeqPlayer2 == null)
			{
				return;
			}
			downArrowSeqPlayer2.PlayLevelSequenceByName("Gray", false, null, false);
		}

		// Token: 0x060449BE RID: 281022 RVA: 0x011D6260 File Offset: 0x011D4460
		private void SetAllBtnInteractive(bool interactiveEnable)
		{
			UUIButtonComponent btnUpArrow = this.BtnUpArrow;
			if (btnUpArrow != null)
			{
				btnUpArrow.SetSelfInteractive(interactiveEnable);
			}
			UUIButtonComponent btnUpArrow2 = this.BtnUpArrow;
			if (btnUpArrow2 != null)
			{
				btnUpArrow2.RootUIComp.Get().SetUIActive(interactiveEnable);
			}
			UUIButtonComponent btnLeftArrow = this.BtnLeftArrow;
			if (btnLeftArrow != null)
			{
				btnLeftArrow.SetSelfInteractive(interactiveEnable);
			}
			UUIButtonComponent btnLeftArrow2 = this.BtnLeftArrow;
			if (btnLeftArrow2 != null)
			{
				btnLeftArrow2.RootUIComp.Get().SetUIActive(interactiveEnable);
			}
			UUIButtonComponent btnRightArrow = this.BtnRightArrow;
			if (btnRightArrow != null)
			{
				btnRightArrow.SetSelfInteractive(interactiveEnable);
			}
			UUIButtonComponent btnRightArrow2 = this.BtnRightArrow;
			if (btnRightArrow2 != null)
			{
				btnRightArrow2.RootUIComp.Get().SetUIActive(interactiveEnable);
			}
			UUIButtonComponent btnDownArrow = this.BtnDownArrow;
			if (btnDownArrow == null)
			{
				return;
			}
			btnDownArrow.SetSelfInteractive(interactiveEnable);
		}

		// Token: 0x060449BF RID: 281023 RVA: 0x011D6314 File Offset: 0x011D4514
		private void RequestGravityFlip()
		{
			if (!ModelBase<GravityFlipModel>.Instance.NeedChangeGravity())
			{
				ControllerBase<GravityFlipController>.Instance.CancelWaitTeleport();
				return;
			}
			long gravityFlipEntityCreatureDataId = ModelBase<GravityFlipModel>.Instance.GravityFlipEntityCreatureDataId;
			if (gravityFlipEntityCreatureDataId == -1L)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "[GravityFlipView] 未找到重力翻转实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<GravityFlipController>.Instance.CancelWaitTeleport();
				return;
			}
			GravityFlipType flipType = ModelBase<GravityFlipModel>.Instance.CurGravityFlipType;
			GravityFlipInteractRequest gravityFlipInteractRequest = GravityFlipInteractRequest.Create();
			gravityFlipInteractRequest.GravityFlipEntityId = Singleton<MathUtils>.Instance.NumberToLong(gravityFlipEntityCreatureDataId);
			gravityFlipInteractRequest.TargetGravityFlipType = flipType;
			Singleton<Net>.Instance.Call<GravityFlipInteractResponse>(ERequestMessageId.GravityFlipInteractRequest, gravityFlipInteractRequest, delegate(GravityFlipInteractResponse response, Net.CallbackStatus _)
			{
				ErrorCode errorCode = response.ErrorCode;
				if (errorCode != ErrorCode.Success)
				{
					if (errorCode - ErrorCode.ErrOnlineInteractNoPermission <= 1 || errorCode == ErrorCode.GravityFlipLocked)
					{
						ControllerBase<GravityFlipController>.Instance.CancelWaitTeleport();
					}
					else
					{
						ControllerBase<GravityFlipController>.Instance.CancelWaitTeleport();
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.BeControlledResponse, null, true, true);
					}
				}
				ModelBase<GravityFlipModel>.Instance.GravityFlipComp.SetGravityDirection(new GravityFlipType?(flipType));
				if (flipType != response.CurGravityFlipType)
				{
					Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
					ModelBase<GravityFlipModel>.Instance.CacheCorrectDirection = response.CurGravityFlipType;
				}
			}, 0);
		}

		// Token: 0x060449C0 RID: 281024 RVA: 0x011D63CC File Offset: 0x011D45CC
		[NullableContext(1)]
		private void OnPlotNetworkEnd(PlotResultInfo _)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
			ModelBase<GravityFlipModel>.Instance.GravityFlipComp.OnNotifyUpdateGravityDirection(ModelBase<GravityFlipModel>.Instance.CacheCorrectDirection);
		}

		// Token: 0x04026304 RID: 156420
		private UUIButtonComponent BtnUpArrow;

		// Token: 0x04026305 RID: 156421
		private UUIButtonComponent BtnRightArrow;

		// Token: 0x04026306 RID: 156422
		private UUIButtonComponent BtnLeftArrow;

		// Token: 0x04026307 RID: 156423
		private UUIButtonComponent BtnDownArrow;

		// Token: 0x04026308 RID: 156424
		private LevelSequencePlayer DownArrowSeqPlayer;

		// Token: 0x04026309 RID: 156425
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0402630A RID: 156426
		private int TargetDirection = -1;

		// Token: 0x0402630B RID: 156427
		private bool IsPlayingTurnAnim;

		// Token: 0x0200CB51 RID: 52049
		[NullableContext(0)]
		private class EGravityFlipView
		{
			// Token: 0x0403E66E RID: 255598
			public const int BtnUpArrow = 0;

			// Token: 0x0403E66F RID: 255599
			public const int BtnLeftArrow = 1;

			// Token: 0x0403E670 RID: 255600
			public const int BtnRightArrow = 2;

			// Token: 0x0403E671 RID: 255601
			public const int BtnClose = 3;

			// Token: 0x0403E672 RID: 255602
			public const int BtnDownArrow = 4;

			// Token: 0x0403E673 RID: 255603
			public const int ArrowPanel = 5;

			// Token: 0x0403E674 RID: 255604
			public const int TargetArrow = 6;
		}
	}
}
