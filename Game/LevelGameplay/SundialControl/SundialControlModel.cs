using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SundialControl
{
	// Token: 0x02006AB6 RID: 27318
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SundialControlModel : ModelBase<SundialControlModel>
	{
		// Token: 0x1700A27A RID: 41594
		// (get) Token: 0x060438B2 RID: 276658 RVA: 0x0116A106 File Offset: 0x01168306
		public SModelConfig ModelConfig
		{
			get
			{
				if (this.ModelConfigInternal == null)
				{
					this.ModelConfigInternal = DataTableUtil.GetDataTableRowFromName<SModelConfig>(EDataTable.ModelConfig, "518056");
				}
				return this.ModelConfigInternal;
			}
		}

		// Token: 0x1700A27B RID: 41595
		// (get) Token: 0x060438B3 RID: 276659 RVA: 0x0116A12D File Offset: 0x0116832D
		public FVectorDouble TargetLocation
		{
			get
			{
				if (!this.TargetActorInternal)
				{
					this.InitTargetActor();
				}
				return this.TargetLocationInternal.Value;
			}
		}

		// Token: 0x1700A27C RID: 41596
		// (get) Token: 0x060438B4 RID: 276660 RVA: 0x0116A148 File Offset: 0x01168348
		public FRotator TargetRotation
		{
			get
			{
				if (!this.TargetActorInternal)
				{
					this.InitTargetActor();
				}
				return this.TargetRotationInternal.Value;
			}
		}

		// Token: 0x060438B5 RID: 276661 RVA: 0x0116A164 File Offset: 0x01168364
		private void InitTargetActor()
		{
			if (!this.TargetActorInternal)
			{
				this.TargetActorInternal = true;
				BP_CineCamera_C cineCamera = ControllerBase<CameraController>.Instance.MainModel.WidgetCamera.DisplayComponent.CineCamera;
				this.TargetLocationInternal = new FVectorDouble?(cineCamera.D_K2_GetActorLocation());
				this.TargetRotationInternal = new FRotator?(cineCamera.K2_GetActorRotation());
				FVectorDouble fvectorDouble = this.TargetRotationInternal.Value.VectorDouble();
				fvectorDouble.Normalize(9.99999993922529E-09);
				FVectorDouble? targetLocationInternal = this.TargetLocationInternal;
				FVectorDouble fvectorDouble2 = fvectorDouble * 200.0;
				FVectorDouble? targetLocationInternal2;
				if (targetLocationInternal == null)
				{
					targetLocationInternal2 = null;
				}
				else
				{
					FVectorDouble valueOrDefault = targetLocationInternal.GetValueOrDefault();
					targetLocationInternal2 = new FVectorDouble?(valueOrDefault + fvectorDouble2);
				}
				this.TargetLocationInternal = targetLocationInternal2;
			}
		}

		// Token: 0x060438B6 RID: 276662 RVA: 0x0116A230 File Offset: 0x01168430
		public void InitRingActors(SceneInteractionLevel sceneInteractionInfo)
		{
			this.Rings = new List<RotatingRing>();
			float rotateSpeed = 0f;
			float rotateSpeed2 = 0f;
			GlobalConfigFromCsv? config = ConfigGlobalConfigFromCsvByName.GetConfig("SundialGamePlay.AngularSpeed1", true);
			if (config != null)
			{
				rotateSpeed = float.Parse(config.Value.Value);
			}
			config = ConfigGlobalConfigFromCsvByName.GetConfig("SundialGamePlay.AngularSpeed2", true);
			if (config != null)
			{
				rotateSpeed2 = float.Parse(config.Value.Value);
			}
			RotatingRing rotatingRing = new RotatingRing(sceneInteractionInfo.GetActorByKey("Ring_1"), 30f, rotateSpeed);
			if (rotatingRing != null)
			{
				this.Rings.Add(rotatingRing);
			}
			RotatingRing rotatingRing2 = new RotatingRing(sceneInteractionInfo.GetActorByKey("Ring_2"), 90f, rotateSpeed2);
			if (rotatingRing2 != null)
			{
				this.Rings.Add(rotatingRing2);
			}
			this.CurrentRingIndex = 0;
		}

		// Token: 0x060438B7 RID: 276663 RVA: 0x0116A300 File Offset: 0x01168500
		public void ChangeCurrentRingIndex(int offset = 1)
		{
			this.CurrentRingIndex = (this.CurrentRingIndex + offset) % this.Rings.Count;
			this.UpdateTips();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSundialRingSwitch, this.CurrentRingIndex);
		}

		// Token: 0x060438B8 RID: 276664 RVA: 0x0116A338 File Offset: 0x01168538
		public void SimpleAddCurRingSocket(int offset = 1)
		{
			RotatingRing rotatingRing = this.Rings[this.CurrentRingIndex];
			rotatingRing.CurSocket = (rotatingRing.CurSocket + offset) % rotatingRing.TotalSocket;
			Audio? audio;
			string text = (ConfigBase<AudioConfig>.Instance.GetAudioPath((this.CurrentRingIndex == 0) ? "play_amb_interact_sundial_outer_circle_loop" : "play_amb_interact_sundial_inner_circle_loop") != null) ? audio.GetValueOrDefault().Path : null;
			if (!string.IsNullOrEmpty(text))
			{
				Singleton<AudioController>.Instance.PostEvent(text, ControllerBase<SundialControlController>.Instance.GetMainActor(), null, null, null, null, true, "");
			}
		}

		// Token: 0x060438B9 RID: 276665 RVA: 0x0116A3E0 File Offset: 0x011685E0
		public bool RotateCurrentRing(double delta)
		{
			RotatingRing rotatingRing = this.Rings[this.CurrentRingIndex];
			USceneComponent rootComponent = rotatingRing.RingActor.RootComponent;
			if (rootComponent != null)
			{
				float rotateSpeed = rotatingRing.RotateSpeed;
				double num = delta * Singleton<TimeUtil>.Instance.Millisecond * (double)rotateSpeed;
				this.RotatedAngle += num;
				bool flag = false;
				if (this.RotatedAngle > rotatingRing.SimpleRotateAngle)
				{
					num -= this.RotatedAngle - rotatingRing.SimpleRotateAngle;
					flag = true;
				}
				rootComponent.K2_AddRelativeRotation(new FRotator(0f, (float)num, 0f), false, ref WorldGlobal.SweepHitResult, false);
				if (flag)
				{
					Audio? audio;
					string text = (ConfigBase<AudioConfig>.Instance.GetAudioPath((this.CurrentRingIndex == 0) ? "play_amb_interact_sundial_outer_circle_stuck" : "play_amb_interact_sundial_inner_circle_stuck") != null) ? audio.GetValueOrDefault().Path : null;
					if (!string.IsNullOrEmpty(text))
					{
						Singleton<AudioController>.Instance.PostEvent(text, ControllerBase<SundialControlController>.Instance.GetMainActor(), null, null, null, null, true, "");
					}
					this.RotatedAngle = 0.0;
					this.CheckRingShine();
					this.CheckFinish();
					return true;
				}
			}
			return false;
		}

		// Token: 0x060438BA RID: 276666 RVA: 0x0116A518 File Offset: 0x01168718
		public void ClearCacheActor()
		{
			if (this.TargetActorInternal)
			{
				this.TargetActorInternal = false;
				this.TargetLocationInternal = null;
				this.TargetRotationInternal = null;
			}
			if (this.Rings != null && this.Rings.Count > 0)
			{
				this.Rings = new List<RotatingRing>();
			}
		}

		// Token: 0x060438BB RID: 276667 RVA: 0x0116A570 File Offset: 0x01168770
		public void ResetAll()
		{
			this.CurrentRingIndex = 0;
			for (int i = 0; i < this.Rings.Count; i++)
			{
				RotatingRing rotatingRing = this.Rings[i];
				USceneComponent rootComponent = rotatingRing.RingActor.RootComponent;
				FRotator relativeRotation = rootComponent.RelativeRotation;
				relativeRotation.Yaw = rotatingRing.InitYaw;
				rootComponent.K2_SetRelativeRotation(relativeRotation, false, ref WorldGlobal.SweepHitResult, false);
				rotatingRing.IsShine = false;
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnSundialRingChangeShine, i, false);
				rotatingRing.CurSocket = 0;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSundialRingSwitch, 0);
		}

		// Token: 0x060438BC RID: 276668 RVA: 0x0116A604 File Offset: 0x01168804
		private void CheckRingShine()
		{
			for (int i = 0; i < this.Rings.Count; i++)
			{
				if (this.Rings[i].IsShine)
				{
					if (this.Rings[i].CurSocket != SundialControlModel.finalSocket[i])
					{
						this.Rings[i].IsShine = false;
						Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnSundialRingChangeShine, i, false);
						Audio? audioPath = ConfigBase<AudioConfig>.Instance.GetAudioPath("play_amb_interact_sundial_deactivate");
						string text = (audioPath != null) ? audioPath.GetValueOrDefault().Path : null;
						if (!string.IsNullOrEmpty(text))
						{
							Singleton<AudioController>.Instance.PostEvent(text, ControllerBase<SundialControlController>.Instance.GetMainActor(), null, null, null, null, true, "");
						}
					}
				}
				else if (this.Rings[i].CurSocket == SundialControlModel.finalSocket[i])
				{
					this.Rings[i].IsShine = true;
					Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnSundialRingChangeShine, i, true);
					Audio? audioPath = ConfigBase<AudioConfig>.Instance.GetAudioPath("play_amb_interact_sundial_activate");
					string text2 = (audioPath != null) ? audioPath.GetValueOrDefault().Path : null;
					if (!string.IsNullOrEmpty(text2))
					{
						Singleton<AudioController>.Instance.PostEvent(text2, ControllerBase<SundialControlController>.Instance.GetMainActor(), null, null, null, null, true, "");
					}
				}
			}
		}

		// Token: 0x060438BD RID: 276669 RVA: 0x0116A79C File Offset: 0x0116899C
		private void CheckFinish()
		{
			for (int i = 0; i < this.Rings.Count; i++)
			{
				if (this.Rings[i].CurSocket != SundialControlModel.finalSocket[i])
				{
					return;
				}
			}
			Audio? audio;
			string text = (ConfigBase<AudioConfig>.Instance.GetAudioPath("play_amb_interact_sundial_finish") != null) ? audio.GetValueOrDefault().Path : null;
			if (!string.IsNullOrEmpty(text))
			{
				Singleton<AudioController>.Instance.PostEvent(text, ControllerBase<SundialControlController>.Instance.GetMainActor(), null, null, null, null, true, "");
			}
			ControllerBase<SundialControlController>.Instance.PlayFinishAnimation();
		}

		// Token: 0x060438BE RID: 276670 RVA: 0x0116A849 File Offset: 0x01168A49
		public void UpdateTips()
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnNeedUpdateSundialTips, this.CurrentRingIndex, this.Rings[this.CurrentRingIndex].CurSocket);
		}

		// Token: 0x04025BC4 RID: 154564
		[StaticVariableRuleIgnore]
		public static readonly int[] finalSocket = new int[]
		{
			5,
			2
		};

		// Token: 0x04025BC5 RID: 154565
		public const string SUNDIAL_MODEL_CONFIG_ID = "518056";

		// Token: 0x04025BC6 RID: 154566
		public const string RING_ONE = "Ring_1";

		// Token: 0x04025BC7 RID: 154567
		public const string RING_TWO = "Ring_2";

		// Token: 0x04025BC8 RID: 154568
		public const string AK_ROTATING_1 = "play_amb_interact_sundial_outer_circle_loop";

		// Token: 0x04025BC9 RID: 154569
		public const string AK_STOP_ROTATING_1 = "play_amb_interact_sundial_outer_circle_stuck";

		// Token: 0x04025BCA RID: 154570
		public const string AK_ROTATING_2 = "play_amb_interact_sundial_inner_circle_loop";

		// Token: 0x04025BCB RID: 154571
		public const string AK_STOP_ROTATING_2 = "play_amb_interact_sundial_inner_circle_stuck";

		// Token: 0x04025BCC RID: 154572
		public const string AK_SHOW_SHINE = "play_amb_interact_sundial_activate";

		// Token: 0x04025BCD RID: 154573
		public const string AK_HIDE_SHINE = "play_amb_interact_sundial_deactivate";

		// Token: 0x04025BCE RID: 154574
		public const string AK_FINISH = "play_amb_interact_sundial_finish";

		// Token: 0x04025BCF RID: 154575
		[Nullable(2)]
		private SModelConfig ModelConfigInternal;

		// Token: 0x04025BD0 RID: 154576
		private bool TargetActorInternal;

		// Token: 0x04025BD1 RID: 154577
		private FVectorDouble? TargetLocationInternal;

		// Token: 0x04025BD2 RID: 154578
		private FRotator? TargetRotationInternal;

		// Token: 0x04025BD3 RID: 154579
		private List<RotatingRing> Rings = new List<RotatingRing>();

		// Token: 0x04025BD4 RID: 154580
		private int CurrentRingIndex;

		// Token: 0x04025BD5 RID: 154581
		private double RotatedAngle;
	}
}
