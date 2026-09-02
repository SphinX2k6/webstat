using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F31 RID: 24369
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleLinkView : UiViewBase
	{
		// Token: 0x0603D368 RID: 250728 RVA: 0x00F90D3B File Offset: 0x00F8EF3B
		public BattleLinkView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603D369 RID: 250729 RVA: 0x00F90D5C File Offset: 0x00F8EF5C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnBattleLinkStop, new Action(this.OnBattleLinkStop));
			Singleton<EventSystem>.Instance.Add<double>(EEventName.OnBattleLinkRestart, new Action<double>(this.OnRestart));
			Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnUiTimeDilation));
		}

		// Token: 0x0603D36A RID: 250730 RVA: 0x00F90DBC File Offset: 0x00F8EFBC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleLinkStop, new Action(this.OnBattleLinkStop));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleLinkRestart, new Action<double>(this.OnRestart));
			Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnUiTimeDilation));
		}

		// Token: 0x0603D36B RID: 250731 RVA: 0x00F90E1C File Offset: 0x00F8F01C
		protected override void OnStart()
		{
			if (this.OpenParam != null)
			{
				this.StartTime = (double)this.OpenParam;
			}
			this.IsInRestart = false;
			this.LinkDuration = (float)(ModelBase<BattleLinkModel>.Instance.GetLinkDuration() / Singleton<TimeUtil>.Instance.InverseMillisecond);
			this.DefaultPlayRate = 1f / this.LinkDuration;
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnSequencePlayEvent));
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			this.SequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnSequenceStart));
			this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEnd), false);
		}

		// Token: 0x0603D36C RID: 250732 RVA: 0x00F90ED3 File Offset: 0x00F8F0D3
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer = null;
		}

		// Token: 0x0603D36D RID: 250733 RVA: 0x00F90EDC File Offset: 0x00F8F0DC
		protected override void OnAfterShow()
		{
			this.IsInRestart = false;
			this.OpenViewTime = (int)Singleton<Time>.Instance.Now;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("StartLink", false, null, false);
		}

		// Token: 0x0603D36E RID: 250734 RVA: 0x00F90F24 File Offset: 0x00F8F124
		protected override void OnBeforeHide()
		{
			ACameraActor cameraActor = ModelBase<CameraModel>.Instance.MainModel.FightCamera.DisplayComponent.CameraActor;
			if (cameraActor != null)
			{
				this.RecoverCameraSettings(cameraActor);
			}
		}

		// Token: 0x0603D36F RID: 250735 RVA: 0x00F90F55 File Offset: 0x00F8F155
		private void OnSequencePlayEvent(string sequenceName, string eventName)
		{
			if (eventName == "PlayProgress")
			{
				this.AnimDelay = Math.Max(0f, (float)Singleton<Time>.Instance.Now - (float)this.OpenViewTime);
				this.PlayProgressAnim();
			}
		}

		// Token: 0x0603D370 RID: 250736 RVA: 0x00F90F8D File Offset: 0x00F8F18D
		private void OnBattleLinkStop()
		{
			this.IsInRestart = false;
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.StopSequenceByKey("Progress", false, false);
			}
			base.CloseMe(null);
		}

		// Token: 0x0603D371 RID: 250737 RVA: 0x00F90FB8 File Offset: 0x00F8F1B8
		private void Close()
		{
			if (!this.IsInRestart)
			{
				base.CloseMe(null);
				return;
			}
			this.IsInRestart = false;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("StartLink", false, null, false);
		}

		// Token: 0x0603D372 RID: 250738 RVA: 0x00F90FFC File Offset: 0x00F8F1FC
		private void OnSequenceStart(string sequenceName)
		{
			if (sequenceName == "StartLink")
			{
				ACameraActor cameraActor = ModelBase<CameraModel>.Instance.MainModel.FightCamera.DisplayComponent.CameraActor;
				if (cameraActor != null)
				{
					this.SaveCameraSettings(cameraActor);
					this.ModifyCameraSettings(cameraActor);
					this.SequencePlayer.SetActorTag(sequenceName, new FName("CameraActor"), cameraActor);
				}
			}
		}

		// Token: 0x0603D373 RID: 250739 RVA: 0x00F91058 File Offset: 0x00F8F258
		private void OnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "StartLink")
			{
				ACameraActor cameraActor = ModelBase<CameraModel>.Instance.MainModel.FightCamera.DisplayComponent.CameraActor;
				if (cameraActor != null)
				{
					this.RecoverCameraSettings(cameraActor);
				}
			}
		}

		// Token: 0x0603D374 RID: 250740 RVA: 0x00F91098 File Offset: 0x00F8F298
		private void SaveCameraSettings(ACameraActor camera)
		{
			UCameraComponent cameraComponent = camera.CameraComponent;
			if (cameraComponent != null)
			{
				this.RadialBlurIntensityOverrideTemp = cameraComponent.PostProcessSettings.bOverride_KuroRadialBlurIntensity;
				this.RadialBlurIntensityTemp = cameraComponent.PostProcessSettings.KuroRadialBlurIntensity;
			}
		}

		// Token: 0x0603D375 RID: 250741 RVA: 0x00F910D4 File Offset: 0x00F8F2D4
		private void ModifyCameraSettings(ACameraActor camera)
		{
			if (this.IsCameraModify)
			{
				return;
			}
			this.IsCameraModify = true;
			UCameraComponent cameraComponent = camera.CameraComponent;
			if (cameraComponent != null)
			{
				cameraComponent.PostProcessSettings.bOverride_KuroRadialBlurIntensity = true;
			}
		}

		// Token: 0x0603D376 RID: 250742 RVA: 0x00F91108 File Offset: 0x00F8F308
		private void RecoverCameraSettings(ACameraActor camera)
		{
			if (!this.IsCameraModify)
			{
				return;
			}
			this.IsCameraModify = false;
			UCameraComponent cameraComponent = camera.CameraComponent;
			if (cameraComponent != null)
			{
				cameraComponent.PostProcessSettings.bOverride_KuroRadialBlurIntensity = this.RadialBlurIntensityOverrideTemp;
				cameraComponent.PostProcessSettings.KuroRadialBlurIntensity = this.RadialBlurIntensityTemp;
			}
		}

		// Token: 0x0603D377 RID: 250743 RVA: 0x00F91151 File Offset: 0x00F8F351
		private void OnRestart(double startTime)
		{
			this.IsInRestart = true;
			this.StartTime = startTime;
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.StopSequenceByKey("Progress", false, false);
		}

		// Token: 0x0603D378 RID: 250744 RVA: 0x00F91178 File Offset: 0x00F8F378
		private void OnUiTimeDilation()
		{
			float playRate = this.PlayRate * Singleton<Time>.Instance.TimeDilation;
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor == null)
			{
				return;
			}
			ALevelSequenceActor sequencePlayerByKey = rootActor.GetSequencePlayerByKey("Progress");
			if (sequencePlayerByKey == null)
			{
				return;
			}
			ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.SetPlayRate(playRate);
		}

		// Token: 0x0603D379 RID: 250745 RVA: 0x00F911C4 File Offset: 0x00F8F3C4
		private void UpdatePlayRate()
		{
			this.PlayRate = this.DefaultPlayRate;
			float playRate = this.DefaultPlayRate * Singleton<Time>.Instance.TimeDilation;
			if (this.StartTime != 0.0)
			{
				float num = (float)Singleton<TimeUtil>.Instance.GetServerTimeStamp();
				double num2 = Math.Max(0.0, (double)num - this.StartTime) + (double)this.AnimDelay;
				double num3 = Math.Max(1.0, (double)this.LinkDuration - num2 / (double)Singleton<TimeUtil>.Instance.InverseMillisecond - 0.20000000298023224);
				this.PlayRate = (float)(1.0 / num3);
				playRate = this.PlayRate * Singleton<Time>.Instance.TimeDilation;
			}
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor == null)
			{
				return;
			}
			ALevelSequenceActor sequencePlayerByKey = rootActor.GetSequencePlayerByKey("Progress");
			if (sequencePlayerByKey == null)
			{
				return;
			}
			ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.SetPlayRate(playRate);
		}

		// Token: 0x0603D37A RID: 250746 RVA: 0x00F912A8 File Offset: 0x00F8F4A8
		private void PlayProgressAnim()
		{
			base.PlaySequence("Progress", new Action(this.Close), false);
			this.UpdatePlayRate();
		}

		// Token: 0x04022545 RID: 140613
		private const float PROGRESS_SEQ_DURATION = 1f;

		// Token: 0x04022546 RID: 140614
		private bool IsInRestart;

		// Token: 0x04022547 RID: 140615
		private float LinkDuration;

		// Token: 0x04022548 RID: 140616
		private float DefaultPlayRate = 1f;

		// Token: 0x04022549 RID: 140617
		private double StartTime;

		// Token: 0x0402254A RID: 140618
		private int OpenViewTime;

		// Token: 0x0402254B RID: 140619
		private float AnimDelay;

		// Token: 0x0402254C RID: 140620
		private float PlayRate = 1f;

		// Token: 0x0402254D RID: 140621
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0402254E RID: 140622
		private bool IsCameraModify;

		// Token: 0x0402254F RID: 140623
		private bool RadialBlurIntensityOverrideTemp;

		// Token: 0x04022550 RID: 140624
		private float RadialBlurIntensityTemp;
	}
}
