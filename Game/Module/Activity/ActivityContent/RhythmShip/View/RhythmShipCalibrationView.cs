using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064D5 RID: 25813
	[NullableContext(2)]
	[Nullable(0)]
	public class RhythmShipCalibrationView : UiTickViewBase
	{
		// Token: 0x06040AAB RID: 264875 RVA: 0x01093C7A File Offset: 0x01091E7A
		[NullableContext(1)]
		public RhythmShipCalibrationView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040AAC RID: 264876 RVA: 0x01093C98 File Offset: 0x01091E98
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickShowNoteToggle)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickReduceBtn)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnClickAddBtn)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickCalibrationBtn)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickConfirmBtn))
			};
		}

		// Token: 0x06040AAD RID: 264877 RVA: 0x01093E58 File Offset: 0x01092058
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipCalibrationView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipCalibrationView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040AAE RID: 264878 RVA: 0x01093E9C File Offset: 0x0109209C
		private void OnClickCloseBtn()
		{
			if (ModelBase<RhythmShipModel>.Instance.LocalCalibrationValue == this.CurrentCalibrationValue)
			{
				base.CloseMe(null);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RhythmCalibrationExitConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				base.CloseMe(null);
			});
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.OnClickConfirmBtn));
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06040AAF RID: 264879 RVA: 0x01093F14 File Offset: 0x01092114
		protected override void OnStart()
		{
			this.CurrentAudioHandle = ControllerBase<RhythmShipController>.Instance.LastLoopAudio;
			this.CurrentCalibrationValue = ModelBase<RhythmShipModel>.Instance.LocalCalibrationValue;
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			base.GetItem(12).SetAlpha(0f);
			base.GetItem(12).SetUIActive(true);
			this.MaxOffsetX = base.GetItem(3).GetWidth();
			this.CircleItemLevelSequencePlayer = new LevelSequencePlayer(base.GetItem(12));
			this.CircleItemLevelSequencePlayer.BindSequenceCloseEvent(delegate(string name)
			{
				if (name == "Click")
				{
					base.GetItem(12).SetAlpha(0f);
				}
			}, false);
			this.RefreshView();
		}

		// Token: 0x06040AB0 RID: 264880 RVA: 0x01093FB5 File Offset: 0x010921B5
		protected override void OnBeforeDestroy()
		{
			if (!StringUtils.IsEmpty(this.CurrentAudioHandle))
			{
				ControllerBase<RhythmShipController>.Instance.PlayLoopAudioEvent(this.CurrentAudioHandle);
				return;
			}
			ControllerBase<RhythmShipController>.Instance.StopLoopAudioEvent();
		}

		// Token: 0x06040AB1 RID: 264881 RVA: 0x01093FE0 File Offset: 0x010921E0
		private void RefreshView()
		{
			base.GetText(4).SetText(this.CurrentCalibrationValue.ToString(), true);
			base.GetItem(10).SetAnchorOffsetX((float)this.CurrentCalibrationValue / 150f * (this.MaxOffsetX / 2f));
			base.GetButton(5).SetSelfInteractive(this.CurrentCalibrationValue > -150);
			base.GetButton(6).SetSelfInteractive(this.CurrentCalibrationValue < 150);
		}

		// Token: 0x06040AB2 RID: 264882 RVA: 0x0109405E File Offset: 0x0109225E
		private void StartCalibration()
		{
			base.GetItem(11).SetAnchorOffsetX(0f);
			ControllerBase<RhythmShipController>.Instance.PlayLoopAudioEvent("play_ui_rhythmship_rhythm_set");
			this.StarMoveTick = true;
		}

		// Token: 0x06040AB3 RID: 264883 RVA: 0x01094088 File Offset: 0x01092288
		private void EndCalibration()
		{
			base.GetItem(11).SetAlpha(0f);
			this.ShowStopMoveShowCircleItem();
		}

		// Token: 0x06040AB4 RID: 264884 RVA: 0x010940A4 File Offset: 0x010922A4
		private void ShowStopMoveShowCircleItem()
		{
			base.GetItem(12).SetAlpha(1f);
			base.GetItem(12).SetAnchorOffsetX(base.GetItem(11).GetAnchorOffsetX());
			LevelSequencePlayer circleItemLevelSequencePlayer = this.CircleItemLevelSequencePlayer;
			if (circleItemLevelSequencePlayer == null || !circleItemLevelSequencePlayer.IsPlayingSequence("Click"))
			{
				LevelSequencePlayer circleItemLevelSequencePlayer2 = this.CircleItemLevelSequencePlayer;
				if (circleItemLevelSequencePlayer2 == null)
				{
					return;
				}
				circleItemLevelSequencePlayer2.PlayLevelSequenceByName("Click", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer circleItemLevelSequencePlayer3 = this.CircleItemLevelSequencePlayer;
				if (circleItemLevelSequencePlayer3 == null)
				{
					return;
				}
				circleItemLevelSequencePlayer3.ReplaySequenceByKey("Click");
				return;
			}
		}

		// Token: 0x06040AB5 RID: 264885 RVA: 0x01094130 File Offset: 0x01092330
		protected override void OnTick(float delta)
		{
			if (this.AddBtnStartPointerDown)
			{
				if (this.BtnLongClickTime > 100f)
				{
					this.OnClickAddBtn();
					this.BtnLongClickTime = 0f;
				}
				this.BtnLongClickTime += delta;
			}
			else if (this.ReduceBtnStartPointerDown)
			{
				if (this.BtnLongClickTime > 100f)
				{
					this.OnClickReduceBtn();
					this.BtnLongClickTime = 0f;
				}
				this.BtnLongClickTime += delta;
			}
			if (!this.StarMoveTick)
			{
				return;
			}
			this.MoveTime += delta;
			float num = this.MoveTime / 3000f * this.MaxOffsetX;
			if (num > this.MaxOffsetX)
			{
				num = 0f;
			}
			base.GetItem(11).SetAlpha(this.CurrentShowNoteFlag > false);
			base.GetItem(11).SetAnchorOffsetX(num);
			if (this.MoveTime >= 3000f)
			{
				this.MoveTime -= 3000f;
			}
		}

		// Token: 0x06040AB6 RID: 264886 RVA: 0x01094225 File Offset: 0x01092425
		private void OnClickShowNoteToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.CurrentShowNoteFlag = true;
				base.GetItem(11).SetAlpha(1f);
				return;
			}
			this.CurrentShowNoteFlag = false;
			base.GetItem(11).SetAlpha(0f);
		}

		// Token: 0x06040AB7 RID: 264887 RVA: 0x0109425E File Offset: 0x0109245E
		private void OnClickReduceBtn()
		{
			if (this.CurrentCalibrationValue <= -150)
			{
				return;
			}
			this.CurrentCalibrationValue--;
			this.RefreshView();
		}

		// Token: 0x06040AB8 RID: 264888 RVA: 0x01094282 File Offset: 0x01092482
		private void OnClickAddBtn()
		{
			if (this.CurrentCalibrationValue >= 150)
			{
				return;
			}
			this.CurrentCalibrationValue++;
			this.RefreshView();
		}

		// Token: 0x06040AB9 RID: 264889 RVA: 0x010942A6 File Offset: 0x010924A6
		private void OnClickCalibrationBtn()
		{
			if (!this.StarMoveTick)
			{
				this.StartCalibration();
				return;
			}
			this.EndCalibration();
		}

		// Token: 0x06040ABA RID: 264890 RVA: 0x010942BD File Offset: 0x010924BD
		private void OnClickConfirmBtn()
		{
			ModelBase<RhythmShipModel>.Instance.SetLocalCalibrationValue(this.CurrentCalibrationValue);
			base.CloseMe(null);
		}

		// Token: 0x06040ABB RID: 264891 RVA: 0x010942D6 File Offset: 0x010924D6
		private void OnAddBtnPointerDown()
		{
			this.AddBtnStartPointerDown = true;
		}

		// Token: 0x06040ABC RID: 264892 RVA: 0x010942DF File Offset: 0x010924DF
		private void OnAddBtnPointerEnd()
		{
			this.AddBtnStartPointerDown = false;
			this.BtnLongClickTime = 0f;
		}

		// Token: 0x06040ABD RID: 264893 RVA: 0x010942F3 File Offset: 0x010924F3
		private void OnReduceBtnPointerDown()
		{
			this.ReduceBtnStartPointerDown = true;
		}

		// Token: 0x06040ABE RID: 264894 RVA: 0x010942FC File Offset: 0x010924FC
		private void OnReduceBtnPointerEnd()
		{
			this.ReduceBtnStartPointerDown = false;
			this.BtnLongClickTime = 0f;
		}

		// Token: 0x0402437C RID: 148348
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402437D RID: 148349
		private int CurrentCalibrationValue;

		// Token: 0x0402437E RID: 148350
		private bool CurrentShowNoteFlag = true;

		// Token: 0x0402437F RID: 148351
		private float MaxOffsetX;

		// Token: 0x04024380 RID: 148352
		private LevelSequencePlayer CircleItemLevelSequencePlayer;

		// Token: 0x04024381 RID: 148353
		private LongPressButtonItem AddLongPress;

		// Token: 0x04024382 RID: 148354
		private LongPressButtonItem ReduceLongPress;

		// Token: 0x04024383 RID: 148355
		[Nullable(1)]
		private string CurrentAudioHandle = "";

		// Token: 0x04024384 RID: 148356
		private bool StarMoveTick;

		// Token: 0x04024385 RID: 148357
		private float MoveTime;

		// Token: 0x04024386 RID: 148358
		private float BtnLongClickTime;

		// Token: 0x04024387 RID: 148359
		private bool AddBtnStartPointerDown;

		// Token: 0x04024388 RID: 148360
		private bool ReduceBtnStartPointerDown;
	}
}
