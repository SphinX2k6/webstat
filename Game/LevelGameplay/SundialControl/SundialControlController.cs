using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SundialControl
{
	// Token: 0x02006AB4 RID: 27316
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SundialControlController : UiControllerBase<SundialControlController>
	{
		// Token: 0x060438A0 RID: 276640 RVA: 0x01169C4C File Offset: 0x01167E4C
		[NullableContext(1)]
		public void GenerateModel(Action loadedCallback)
		{
			UObject world = GlobalData.World;
			string text = ModelBase<SundialControlModel>.Instance.ModelConfig.场景交互物.AssetPathName.ToString();
			if (text != null && text.Contains('.'))
			{
				text = text.Split('.', StringSplitOptions.None)[0];
			}
			bool flag = false;
			ULevelStreamingDynamic ulevelStreamingDynamic = ULevelStreamingDynamic.LoadLevelInstance(world, text, global::Vector.ZeroVector, global::Rotator.ZeroRotator, ref flag, "", default(TSubclassOf<ULevelStreamingDynamic>));
			if (flag && ulevelStreamingDynamic != null)
			{
				this.SceneInteractionInfo = new SceneInteractionLevel();
				this.SceneInteractionInfo.Init(ulevelStreamingDynamic, text, global::Vector.ZeroVectorDouble, global::Rotator.ZeroRotator, -1, new EKuroSceneInteractionState?(EKuroSceneInteractionState.State1), delegate
				{
					this.SetupSceneInteractionWhenLoadCompleted(loadedCallback);
				}, true, false, 0, null);
			}
		}

		// Token: 0x060438A1 RID: 276641 RVA: 0x01169D14 File Offset: 0x01167F14
		[NullableContext(1)]
		private void SetupSceneInteractionWhenLoadCompleted(Action loadedCallback)
		{
			this.SceneInteractionInfo.MainActor.D_K2_SetActorLocation(ModelBase<SundialControlModel>.Instance.TargetLocation, false, ref WorldGlobal.SweepHitResult, false);
			this.SceneInteractionInfo.MainActor.K2_SetActorRotation(ModelBase<SundialControlModel>.Instance.TargetRotation, false);
			ModelBase<SundialControlModel>.Instance.InitRingActors(this.SceneInteractionInfo);
			loadedCallback();
			this.SceneInteractionInfo.PlaySceneEffect(ESceneInteractionEffect.Effect3);
		}

		// Token: 0x060438A2 RID: 276642 RVA: 0x01169D81 File Offset: 0x01167F81
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSundialRingChangeShine, new Action<int, bool>(this.OnSundialRingChangeShine));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSundialRingSwitch, new Action<int>(this.OnSundialRingSwitch));
		}

		// Token: 0x060438A3 RID: 276643 RVA: 0x01169DBB File Offset: 0x01167FBB
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSundialRingChangeShine, new Action<int, bool>(this.OnSundialRingChangeShine));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSundialRingSwitch, new Action<int>(this.OnSundialRingSwitch));
		}

		// Token: 0x060438A4 RID: 276644 RVA: 0x01169DF8 File Offset: 0x01167FF8
		private void OnSundialRingChangeShine(int ring, bool isShine)
		{
			ESceneInteractionEffect? esceneInteractionEffect = null;
			if (ring != 0)
			{
				if (ring == 1)
				{
					esceneInteractionEffect = new ESceneInteractionEffect?(ESceneInteractionEffect.Effect1);
				}
			}
			else
			{
				esceneInteractionEffect = new ESceneInteractionEffect?(ESceneInteractionEffect.Effect0);
			}
			if (esceneInteractionEffect == null)
			{
				return;
			}
			if (isShine)
			{
				this.SceneInteractionInfo.PlaySceneEffect(esceneInteractionEffect.Value);
				return;
			}
			this.SceneInteractionInfo.EndSceneEffect(esceneInteractionEffect.Value);
		}

		// Token: 0x060438A5 RID: 276645 RVA: 0x01169E5A File Offset: 0x0116805A
		private void OnSundialRingSwitch(int ring)
		{
			this.SceneInteractionInfo.EndSceneEffect((ring == 0) ? ESceneInteractionEffect.Effect4 : ESceneInteractionEffect.Effect3);
			this.SceneInteractionInfo.PlaySceneEffect((ring == 0) ? ESceneInteractionEffect.Effect3 : ESceneInteractionEffect.Effect4);
		}

		// Token: 0x060438A6 RID: 276646 RVA: 0x01169E80 File Offset: 0x01168080
		public void DestroyModel()
		{
			if (this.SceneInteractionInfo != null)
			{
				this.SceneInteractionInfo.Destroy();
				this.SceneInteractionInfo = null;
				ModelBase<SundialControlModel>.Instance.ClearCacheActor();
			}
		}

		// Token: 0x060438A7 RID: 276647 RVA: 0x01169EA6 File Offset: 0x011680A6
		public void SwitchCurrentRing()
		{
			if (this.IsRotating)
			{
				return;
			}
			ModelBase<SundialControlModel>.Instance.ChangeCurrentRingIndex(1);
		}

		// Token: 0x060438A8 RID: 276648 RVA: 0x01169EBC File Offset: 0x011680BC
		public void SetOnFinishCallback(Action callback)
		{
			this.OnFinish = callback;
		}

		// Token: 0x060438A9 RID: 276649 RVA: 0x01169EC5 File Offset: 0x011680C5
		public void StartRotate(Action callback)
		{
			if (!this.IsRotating)
			{
				this.IsRotating = true;
				this.StopRotationCallback = callback;
				ModelBase<SundialControlModel>.Instance.SimpleAddCurRingSocket(1);
			}
		}

		// Token: 0x060438AA RID: 276650 RVA: 0x01169EE8 File Offset: 0x011680E8
		protected override void OnTick(float delta)
		{
			if (this.IsRotating && ModelBase<SundialControlModel>.Instance.RotateCurrentRing((double)delta))
			{
				this.IsRotating = false;
				if (this.StopRotationCallback != null)
				{
					ModelBase<SundialControlModel>.Instance.UpdateTips();
					this.StopRotationCallback();
					this.StopRotationCallback = null;
				}
			}
		}

		// Token: 0x060438AB RID: 276651 RVA: 0x01169F36 File Offset: 0x01168136
		public void ResetAll()
		{
			ModelBase<SundialControlModel>.Instance.ResetAll();
		}

		// Token: 0x060438AC RID: 276652 RVA: 0x01169F44 File Offset: 0x01168144
		public void PlayFinishAnimation()
		{
			if (this.OnFinish != null)
			{
				this.OnFinish();
			}
			this.SceneInteractionInfo.EndSceneEffect(ESceneInteractionEffect.Effect3);
			this.SceneInteractionInfo.EndSceneEffect(ESceneInteractionEffect.Effect4);
			this.SceneInteractionInfo.PlaySceneEffect(ESceneInteractionEffect.Effect2);
			ALevelSequenceActor directorActor = Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, false) as ALevelSequenceActor;
			TTimerAction <>9__2;
			Action <>9__1;
			Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>("/Game/Aki/Scene/InteractionLevel/Animation/Sundial/TPrefab_SM_Sundial_Finish.TPrefab_SM_Sundial_Finish", delegate([Nullable(2)] ULevelSequence result, string _)
			{
				if (result == null || !result.IsValid())
				{
					this.RequestFinish("MainQuest");
					return;
				}
				directorActor.SetActorTickEnabled(true);
				directorActor.SetSequence(result);
				AActor actorByKey = this.SceneInteractionInfo.GetActorByKey("Left");
				directorActor.AddBindingByTag(this.leftTag, actorByKey, false, false);
				AActor actorByKey2 = this.SceneInteractionInfo.GetActorByKey("Right");
				directorActor.AddBindingByTag(this.rightTag, actorByKey2, false, false);
				AActor actorByKey3 = this.SceneInteractionInfo.GetActorByKey("Roll");
				directorActor.AddBindingByTag(this.rollTag, actorByKey3, false, false);
				AActor actorByKey4 = this.SceneInteractionInfo.GetActorByKey("Decal");
				directorActor.AddBindingByTag(this.decalTag, actorByKey4, false, false);
				directorActor.SequencePlayer.SetPlayRate(1f);
				FOnMovieSceneSequencePlayerEvent onFinished = directorActor.SequencePlayer.OnFinished;
				Action callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						TimerSystemInstance instance = TimerSystem.Instance;
						TTimerAction action;
						if ((action = <>9__2) == null)
						{
							action = (<>9__2 = delegate(float _)
							{
								ControllerBase<SundialControlController>.Instance.RequestFinish("MainQuest");
								Singleton<ActorSystem>.Instance.Put("PlayFinishAnimation", directorActor, null);
							});
						}
						instance.Delay(action, 500f, null, null, true, 1f);
					});
				}
				onFinished.Add(callback);
				directorActor.SequencePlayer.Play();
			}, 100, "js_undefined");
		}

		// Token: 0x060438AD RID: 276653 RVA: 0x01169FE0 File Offset: 0x011681E0
		[NullableContext(1)]
		private void RequestFinish(string key = "MainQuest")
		{
			UiGamePlayRequest uiGamePlayRequest = UiGamePlayRequest.Create();
			uiGamePlayRequest.GamePlayKey = key;
			uiGamePlayRequest.Type = UiGamePlayType.SundialPuzzle;
			Singleton<Net>.Instance.Call<UiGamePlayResponse>(ERequestMessageId.UiGamePlayRequest, uiGamePlayRequest, delegate(UiGamePlayResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorId == ErrorCode.Success)
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.SundialControlView, null);
				}
			}, 0);
		}

		// Token: 0x060438AE RID: 276654 RVA: 0x0116A031 File Offset: 0x01168231
		public void UpdateViewTips()
		{
			ModelBase<SundialControlModel>.Instance.UpdateTips();
		}

		// Token: 0x060438AF RID: 276655 RVA: 0x0116A03D File Offset: 0x0116823D
		public AActor GetMainActor()
		{
			SceneInteractionLevel sceneInteractionInfo = this.SceneInteractionInfo;
			if (sceneInteractionInfo == null)
			{
				return null;
			}
			return sceneInteractionInfo.MainActor;
		}

		// Token: 0x04025BB4 RID: 154548
		[Nullable(1)]
		public const string SEQ_PATH = "/Game/Aki/Scene/InteractionLevel/Animation/Sundial/TPrefab_SM_Sundial_Finish.TPrefab_SM_Sundial_Finish";

		// Token: 0x04025BB5 RID: 154549
		public readonly FName leftTag = new FName("Left");

		// Token: 0x04025BB6 RID: 154550
		public readonly FName rightTag = new FName("Right");

		// Token: 0x04025BB7 RID: 154551
		public readonly FName rollTag = new FName("Roll");

		// Token: 0x04025BB8 RID: 154552
		public readonly FName decalTag = new FName("Decal");

		// Token: 0x04025BB9 RID: 154553
		private SceneInteractionLevel SceneInteractionInfo;

		// Token: 0x04025BBA RID: 154554
		private bool IsRotating;

		// Token: 0x04025BBB RID: 154555
		private Action StopRotationCallback;

		// Token: 0x04025BBC RID: 154556
		private Action OnFinish;
	}
}
