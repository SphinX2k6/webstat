using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TimeTrackControl
{
	// Token: 0x02006A98 RID: 27288
	[NullableContext(2)]
	[Nullable(0)]
	public class TimeTrackControlView : UiTickViewBase
	{
		// Token: 0x060437A1 RID: 276385 RVA: 0x0116255D File Offset: 0x0116075D
		[NullableContext(1)]
		public TimeTrackControlView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060437A2 RID: 276386 RVA: 0x01162568 File Offset: 0x01160768
		protected unsafe override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUISprite))
			};
			int num = 1;
			List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
			Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickBackBtn));
			this.BtnBindInfo = list;
		}

		// Token: 0x060437A3 RID: 276387 RVA: 0x01162684 File Offset: 0x01160884
		protected override void OnStart()
		{
			this.BoxWidth = 26f;
			this.MaxCounts = ModelBase<TimeTrackControlModel>.Instance.GetConfigStatesCounts();
			this.SegmentTime = ModelBase<TimeTrackControlModel>.Instance.GetConfigSegmentTime();
			this.Notches = ((this.MaxCounts - 2 > 0) ? (this.MaxCounts - 2) : 0);
			if (this.Notches > 0)
			{
				this.InitNotches();
			}
			else
			{
				this.BaseDistance = this.BoxWidth;
				this.Notches = 0;
			}
			this.CurNotch = ModelBase<TimeTrackControlModel>.Instance.ControlPoint;
			this.CurLength = this.GetTargetLength(this.CurNotch);
			this.IndicatorCircle = base.GetItem(5);
			this.CurRotator = global::Rotator.Create(0f, this.CurLength, 0f);
			UUIItem indicatorCircle = this.IndicatorCircle;
			FRotator frotator = this.CurRotator.ToUeRotator();
			indicatorCircle.SetUIRelativeRotation(frotator);
			this.IsInAnimated = false;
			UUIItem item = base.GetItem(4);
			this.NotchListPanel = base.GetItem(3);
			this.ControlPoints = new TimeTrackControlPoint[this.MaxCounts];
			item.SetUIActive(false);
			for (int i = 0; i < this.MaxCounts; i++)
			{
				UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item, this.NotchListPanel);
				uuiitem.SetUIActive(true);
				float targetLength = this.GetTargetLength(i);
				TimeTrackControlPoint timeTrackControlPoint = new TimeTrackControlPoint(uuiitem, i, targetLength);
				timeTrackControlPoint.UpdateState(ModelBase<TimeTrackControlModel>.Instance.IsControlPointUsable(i));
				this.ControlPoints[i] = timeTrackControlPoint;
			}
			this.ControlPoints[this.CurNotch].ToggleSelected(true);
			this.HandleLockBar();
			this.LeftBtnLongPress = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(0)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressFourth), delegate(bool _)
			{
				this.OnClickLeftBtn();
			});
			this.RightBtnLongPress = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(1)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressFourth), delegate(bool _)
			{
				this.OnClickRightBtn();
			});
		}

		// Token: 0x060437A4 RID: 276388 RVA: 0x0116285E File Offset: 0x01160A5E
		private void InitNotches()
		{
			this.BaseDistance = this.BoxWidth / (float)(this.Notches + 1);
		}

		// Token: 0x060437A5 RID: 276389 RVA: 0x01162876 File Offset: 0x01160A76
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnTimeTrackControlUpdate, new Action<int, ErrorCode>(this.HandleInputUpdate));
		}

		// Token: 0x060437A6 RID: 276390 RVA: 0x01162894 File Offset: 0x01160A94
		protected override void OnAfterHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTimeTrackControlUpdate, new Action<int, ErrorCode>(this.HandleInputUpdate));
		}

		// Token: 0x060437A7 RID: 276391 RVA: 0x011628B2 File Offset: 0x01160AB2
		protected override void OnAddEventListener()
		{
			if (!Singleton<EventSystem>.Instance.HasWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnCharBeHit)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnCharBeHit));
			}
		}

		// Token: 0x060437A8 RID: 276392 RVA: 0x011628F1 File Offset: 0x01160AF1
		protected override void OnRemoveEventListener()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnCharBeHit)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnCharBeHit));
			}
		}

		// Token: 0x060437A9 RID: 276393 RVA: 0x01162930 File Offset: 0x01160B30
		[NullableContext(1)]
		private void OnCharBeHit(global::HitInformation hitData, HitContext hitContext)
		{
			if (hitData.CalculateType != 0)
			{
				return;
			}
			ControllerBase<TimeTrackController>.Instance.HandleTimeTrackControlViewClose();
			this.IsHitClose = true;
			base.CloseMe(null);
		}

		// Token: 0x060437AA RID: 276394 RVA: 0x01162954 File Offset: 0x01160B54
		protected override void OnBeforeDestroy()
		{
			LongPressButtonItem leftBtnLongPress = this.LeftBtnLongPress;
			if (leftBtnLongPress != null)
			{
				leftBtnLongPress.Clear();
			}
			LongPressButtonItem rightBtnLongPress = this.RightBtnLongPress;
			if (rightBtnLongPress != null)
			{
				rightBtnLongPress.Clear();
			}
			if (this.ControlPoints != null)
			{
				TimeTrackControlPoint[] controlPoints = this.ControlPoints;
				for (int i = 0; i < controlPoints.Length; i++)
				{
					controlPoints[i].Destroy(null);
				}
			}
			this.ControlPoints = null;
			Singleton<AudioSystem>.Instance.ExecuteAction("play_ui_com_time_loop", EAudioActionType.Stop, null);
			if (this.IsBtnClose || this.IsHitClose)
			{
				return;
			}
			ControllerBase<TimeTrackController>.Instance.HandleTimeTrackControlViewClose();
		}

		// Token: 0x060437AB RID: 276395 RVA: 0x011629E4 File Offset: 0x01160BE4
		private void HandleInputUpdate(int curPoint, ErrorCode code)
		{
			if (code == ErrorCode.ErrTimelineMove)
			{
				this.HandleLockHint();
				return;
			}
			if (this.CurNotch == curPoint)
			{
				return;
			}
			if (this.ControlPoints != null)
			{
				this.ControlPoints[this.CurNotch].ToggleSelected(false);
			}
			this.CurNotch = curPoint;
			this.TargetLength = this.GetTargetLength(curPoint);
			this.DeltaSpeed = (this.TargetLength - this.CurLength) / this.SegmentTime / 1000f;
			this.IsInAnimated = true;
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_time_loop");
		}

		// Token: 0x060437AC RID: 276396 RVA: 0x01162A70 File Offset: 0x01160C70
		protected override void OnTick(float deltaTime)
		{
			if (!this.IsInAnimated)
			{
				return;
			}
			float num = deltaTime * this.DeltaSpeed;
			this.CurLength += num;
			if (Math.Abs(this.TargetLength - this.CurLength) < Math.Abs(num))
			{
				this.FinishedAnim();
			}
			this.CurRotator.Yaw = this.CurLength;
			UUIItem indicatorCircle = this.IndicatorCircle;
			FRotator frotator = this.CurRotator.ToUeRotator();
			indicatorCircle.SetUIRelativeRotation(frotator);
		}

		// Token: 0x060437AD RID: 276397 RVA: 0x01162AE8 File Offset: 0x01160CE8
		private void FinishedAnim()
		{
			this.CurLength = this.TargetLength;
			this.CurRotator.Yaw = this.CurLength;
			UUIItem indicatorCircle = this.IndicatorCircle;
			FRotator frotator = this.CurRotator.ToUeRotator();
			indicatorCircle.SetUIRelativeRotation(frotator);
			Singleton<AudioSystem>.Instance.ExecuteAction("play_ui_com_time_loop", EAudioActionType.Stop, null);
			this.IsInAnimated = false;
			if (this.ControlPoints == null)
			{
				return;
			}
			this.ControlPoints[this.CurNotch].ToggleSelected(true);
			foreach (TimeTrackControlPoint timeTrackControlPoint in this.ControlPoints)
			{
				bool flag = ModelBase<TimeTrackControlModel>.Instance.IsControlPointUsable(timeTrackControlPoint.Index);
				timeTrackControlPoint.UpdateState(flag);
				if (flag)
				{
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_time_bell");
				}
			}
			this.HandleLockBar();
		}

		// Token: 0x060437AE RID: 276398 RVA: 0x01162BB7 File Offset: 0x01160DB7
		private float GetTargetLength(int inTargetPoint)
		{
			return Singleton<MathUtils>.Instance.RangeClamp((float)inTargetPoint * this.BaseDistance, 0f, 26f, -13f, 13f);
		}

		// Token: 0x060437AF RID: 276399 RVA: 0x01162BE0 File Offset: 0x01160DE0
		private void OnClickBackBtn()
		{
			ControllerBase<TimeTrackController>.Instance.HandleTimeTrackControlViewClose();
			this.IsBtnClose = true;
			base.CloseMe(null);
		}

		// Token: 0x060437B0 RID: 276400 RVA: 0x01162BFA File Offset: 0x01160DFA
		private void OnClickRightBtn()
		{
			this.HandleTraceControl(true);
		}

		// Token: 0x060437B1 RID: 276401 RVA: 0x01162C03 File Offset: 0x01160E03
		private void OnClickLeftBtn()
		{
			this.HandleTraceControl(false);
		}

		// Token: 0x060437B2 RID: 276402 RVA: 0x01162C0C File Offset: 0x01160E0C
		private void HandleTraceControl(bool inForward)
		{
			if (this.IsInAnimated)
			{
				return;
			}
			if (!ModelBase<TimeTrackControlModel>.Instance.CanUpdated)
			{
				return;
			}
			if (!inForward)
			{
				if (this.CurNotch > 0)
				{
					ControllerBase<TimeTrackController>.Instance.TimelineTraceControlRequest(false);
				}
				return;
			}
			if (this.CurNotch < this.MaxCounts - 1)
			{
				ControllerBase<TimeTrackController>.Instance.TimelineTraceControlRequest(true);
			}
		}

		// Token: 0x060437B3 RID: 276403 RVA: 0x01162C62 File Offset: 0x01160E62
		private void HandleLockHint()
		{
			this.UiViewSequence.PlaySequencePurely("Shake", true, false);
		}

		// Token: 0x060437B4 RID: 276404 RVA: 0x01162C78 File Offset: 0x01160E78
		private void HandleLockBar()
		{
			int num = this.CurNotch;
			int num2 = this.CurNotch;
			num--;
			while (num >= 0 && ModelBase<TimeTrackControlModel>.Instance.IsControlPointUsable(num))
			{
				num--;
			}
			if (num >= 0)
			{
				int num3 = (num + 1) / (this.MaxCounts - 1);
				base.GetSprite(2).SetUIActive(true);
				base.GetSprite(2).SetFillAmount((float)num3);
			}
			else
			{
				base.GetSprite(2).SetUIActive(false);
			}
			num2++;
			while (num2 < this.MaxCounts && ModelBase<TimeTrackControlModel>.Instance.IsControlPointUsable(num2))
			{
				num2++;
			}
			if (num2 < this.MaxCounts)
			{
				int num4 = (this.MaxCounts - num2) / (this.MaxCounts - 1);
				base.GetSprite(8).SetUIActive(true);
				base.GetSprite(8).SetFillAmount((float)num4);
				return;
			}
			base.GetSprite(8).SetUIActive(false);
		}

		// Token: 0x04025AFA RID: 154362
		private UUIItem NotchListPanel;

		// Token: 0x04025AFB RID: 154363
		private int Notches;

		// Token: 0x04025AFC RID: 154364
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TimeTrackControlPoint[] ControlPoints;

		// Token: 0x04025AFD RID: 154365
		private float BoxWidth;

		// Token: 0x04025AFE RID: 154366
		private float BaseDistance;

		// Token: 0x04025AFF RID: 154367
		private int CurNotch;

		// Token: 0x04025B00 RID: 154368
		private int MaxCounts;

		// Token: 0x04025B01 RID: 154369
		private float CurLength;

		// Token: 0x04025B02 RID: 154370
		private float TargetLength;

		// Token: 0x04025B03 RID: 154371
		private float DeltaSpeed;

		// Token: 0x04025B04 RID: 154372
		private bool IsInAnimated;

		// Token: 0x04025B05 RID: 154373
		private bool IsBtnClose;

		// Token: 0x04025B06 RID: 154374
		private bool IsHitClose;

		// Token: 0x04025B07 RID: 154375
		private float SegmentTime;

		// Token: 0x04025B08 RID: 154376
		private UUIItem IndicatorCircle;

		// Token: 0x04025B09 RID: 154377
		private global::Rotator CurRotator;

		// Token: 0x04025B0A RID: 154378
		private LongPressButtonItem LeftBtnLongPress;

		// Token: 0x04025B0B RID: 154379
		private LongPressButtonItem RightBtnLongPress;

		// Token: 0x0200C9D7 RID: 51671
		[NullableContext(0)]
		public enum ETimeTrackControlComponent
		{
			// Token: 0x0403E077 RID: 254071
			LeftBtn,
			// Token: 0x0403E078 RID: 254072
			RightBtn,
			// Token: 0x0403E079 RID: 254073
			LockBarL,
			// Token: 0x0403E07A RID: 254074
			NotchList,
			// Token: 0x0403E07B RID: 254075
			FirstNotch,
			// Token: 0x0403E07C RID: 254076
			IndicatorCircle,
			// Token: 0x0403E07D RID: 254077
			Indicator,
			// Token: 0x0403E07E RID: 254078
			CloseBtn,
			// Token: 0x0403E07F RID: 254079
			LockBarR
		}
	}
}
