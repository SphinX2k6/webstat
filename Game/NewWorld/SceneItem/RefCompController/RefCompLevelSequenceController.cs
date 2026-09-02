using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using CSharpScript.Game.LevelGamePlay.StaticScene;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.RefCompController
{
	// Token: 0x0200482E RID: 18478
	[NullableContext(1)]
	[Nullable(0)]
	public class RefCompLevelSequenceController : RefCompControllerBase
	{
		// Token: 0x06030151 RID: 196945 RVA: 0x00BA8A23 File Offset: 0x00BA6C23
		public RefCompLevelSequenceController(Entity entity, long creatureDataId, int pbDataId) : base(entity, creatureDataId, pbDataId)
		{
		}

		// Token: 0x17008243 RID: 33347
		// (get) Token: 0x06030152 RID: 196946 RVA: 0x00BA8A35 File Offset: 0x00BA6C35
		public override RefCompDefine.ERefCompControllerType Type
		{
			get
			{
				return RefCompDefine.ERefCompControllerType.LevelSequence;
			}
		}

		// Token: 0x06030153 RID: 196947 RVA: 0x00BA8A38 File Offset: 0x00BA6C38
		public override void OnStart()
		{
			this.EventComp = this.Entity.GetComponent<LevelSequenceFrameEventComponent>();
		}

		// Token: 0x06030154 RID: 196948 RVA: 0x00BA8A4C File Offset: 0x00BA6C4C
		public override void OnEnd()
		{
			while (this.ResourceLoadCallbackHandleQueue != null && this.ResourceLoadCallbackHandleQueue.Size > 0)
			{
				RefCompLevelSequenceController.ResourceLoadCallbackHandle resourceLoadCallbackHandle = this.ResourceLoadCallbackHandleQueue.Pop();
				if (resourceLoadCallbackHandle != null && !resourceLoadCallbackHandle.LoadAsyncFinished && resourceLoadCallbackHandle.ResourceSystemId != -1)
				{
					Singleton<ResourceSystem>.Instance.CancelAsyncLoad(resourceLoadCallbackHandle.ResourceSystemId);
				}
			}
			if (this.SimpleSequenceActor != null)
			{
				this.SimpleSequenceActor.Clear();
			}
		}

		// Token: 0x06030155 RID: 196949 RVA: 0x00BA8AB4 File Offset: 0x00BA6CB4
		public void OnActorRemove()
		{
			this.NextSequenceJumpToEnd = true;
			SimpleLevelSequenceActor simpleSequenceActor = this.SimpleSequenceActor;
			if (simpleSequenceActor != null)
			{
				simpleSequenceActor.Clear();
			}
			this.SimpleSequenceActor = null;
		}

		// Token: 0x06030156 RID: 196950 RVA: 0x00BA8AD8 File Offset: 0x00BA6CD8
		public void HandleSequence(PlayLevelSequence inSequenceConfig)
		{
			RefCompLevelSequenceController.<>c__DisplayClass12_0 CS$<>8__locals1 = new RefCompLevelSequenceController.<>c__DisplayClass12_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.inSequenceConfig = inSequenceConfig;
			if (string.IsNullOrEmpty(CS$<>8__locals1.inSequenceConfig.LevelSequencePath) || CS$<>8__locals1.inSequenceConfig.LevelSequencePath == "None")
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Interaction, ELogAuthor.YZH, "LevelSequence", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			CS$<>8__locals1.jumpToEnd = this.NextSequenceJumpToEnd;
			CS$<>8__locals1.tempInTransit = null;
			CS$<>8__locals1.tempOutTransit = null;
			if (CS$<>8__locals1.inSequenceConfig.Intro == null)
			{
				CS$<>8__locals1.tempInTransit = new RefCompDefine.TransitStruct(ELevelSequenceTransition.Camera, new float?(0f), new float?(0f), new float?(0f), new bool?(false), null);
			}
			else
			{
				ILevelSequenceTransitionType intro = CS$<>8__locals1.inSequenceConfig.Intro;
				if (intro != null && intro.Type == ELevelSequenceTransition.Camera)
				{
					ILevelSequenceTransitionType levelSequenceTransitionType = CS$<>8__locals1.inSequenceConfig.Intro as ICameraTransition;
					RefCompLevelSequenceController.<>c__DisplayClass12_0 CS$<>8__locals2 = CS$<>8__locals1;
					ELevelSequenceTransition transitType = ELevelSequenceTransition.Camera;
					float? duration;
					if (levelSequenceTransitionType.Duration == null)
					{
						duration = new float?(0f);
					}
					else
					{
						float? duration2 = levelSequenceTransitionType.Duration;
						float num = 0f;
						duration = ((duration2.GetValueOrDefault() > num & duration2 != null) ? levelSequenceTransitionType.Duration : new float?(0f));
					}
					CS$<>8__locals2.tempInTransit = new RefCompDefine.TransitStruct(transitType, duration, new float?(0f), new float?(0f), new bool?(true), null);
				}
				else
				{
					ILevelSequenceTransitionType levelSequenceTransitionType = CS$<>8__locals1.inSequenceConfig.Intro as IMaskTransition;
					IMaskTransition maskTransition = levelSequenceTransitionType as IMaskTransition;
					RefCompLevelSequenceController.<>c__DisplayClass12_0 CS$<>8__locals3 = CS$<>8__locals1;
					ELevelSequenceTransition transitType2 = ELevelSequenceTransition.Mask;
					float? duration3;
					if (levelSequenceTransitionType.Duration == null)
					{
						duration3 = new float?(0f);
					}
					else
					{
						float? duration2 = levelSequenceTransitionType.Duration;
						float num = 0f;
						duration3 = ((duration2.GetValueOrDefault() > num & duration2 != null) ? levelSequenceTransitionType.Duration : new float?(0f));
					}
					CS$<>8__locals3.tempInTransit = new RefCompDefine.TransitStruct(transitType2, duration3, new float?((maskTransition.FadeIn != null) ? ((maskTransition.FadeIn.Duration > 0f) ? maskTransition.FadeIn.Duration : 1f) : 1f), new float?((maskTransition.FadeOut != null) ? ((maskTransition.FadeOut.Duration > 0f) ? maskTransition.FadeOut.Duration : 1f) : 1f), new bool?(true), new ETransitionMask?(maskTransition.Mask));
				}
			}
			if (CS$<>8__locals1.inSequenceConfig.Outro == null)
			{
				CS$<>8__locals1.tempOutTransit = new RefCompDefine.TransitStruct(ELevelSequenceTransition.Camera, new float?(0f), new float?(0f), new float?(0f), new bool?(false), null);
			}
			else
			{
				ILevelSequenceTransitionType outro = CS$<>8__locals1.inSequenceConfig.Outro;
				if (outro != null && outro.Type == ELevelSequenceTransition.Camera)
				{
					ILevelSequenceTransitionType levelSequenceTransitionType = CS$<>8__locals1.inSequenceConfig.Outro as ICameraTransition;
					RefCompLevelSequenceController.<>c__DisplayClass12_0 CS$<>8__locals4 = CS$<>8__locals1;
					ELevelSequenceTransition transitType3 = ELevelSequenceTransition.Camera;
					float? duration4;
					if (levelSequenceTransitionType.Duration == null)
					{
						duration4 = new float?(0f);
					}
					else
					{
						float? duration2 = levelSequenceTransitionType.Duration;
						float num = 0f;
						duration4 = ((duration2.GetValueOrDefault() > num & duration2 != null) ? levelSequenceTransitionType.Duration : new float?(0f));
					}
					CS$<>8__locals4.tempOutTransit = new RefCompDefine.TransitStruct(transitType3, duration4, new float?(0f), new float?(0f), new bool?(true), null);
				}
				else
				{
					ILevelSequenceTransitionType levelSequenceTransitionType = CS$<>8__locals1.inSequenceConfig.Outro as IMaskTransition;
					IMaskTransition maskTransition2 = levelSequenceTransitionType as IMaskTransition;
					RefCompLevelSequenceController.<>c__DisplayClass12_0 CS$<>8__locals5 = CS$<>8__locals1;
					ELevelSequenceTransition transitType4 = ELevelSequenceTransition.Mask;
					float? duration5;
					if (levelSequenceTransitionType.Duration == null)
					{
						duration5 = new float?(0f);
					}
					else
					{
						float? duration2 = levelSequenceTransitionType.Duration;
						float num = 0f;
						duration5 = ((duration2.GetValueOrDefault() > num & duration2 != null) ? levelSequenceTransitionType.Duration : new float?(0f));
					}
					CS$<>8__locals5.tempOutTransit = new RefCompDefine.TransitStruct(transitType4, duration5, new float?((maskTransition2.FadeIn != null) ? ((maskTransition2.FadeIn.Duration > 0f) ? maskTransition2.FadeIn.Duration : 1f) : 1f), new float?((maskTransition2.FadeOut != null) ? ((maskTransition2.FadeOut.Duration > 0f) ? maskTransition2.FadeOut.Duration : 1f) : 1f), new bool?(true), new ETransitionMask?(maskTransition2.Mask));
				}
			}
			RefCompLevelSequenceController.<>c__DisplayClass12_0 CS$<>8__locals6 = CS$<>8__locals1;
			float? playRateAbs = new float?(Math.Abs(CS$<>8__locals1.inSequenceConfig.Rate.GetValueOrDefault(1f)));
			EKuroEasingFuncType easeType = EKuroEasingFuncType.KEF_Linear;
			IEaseData rateEase = CS$<>8__locals1.inSequenceConfig.RateEase;
			CS$<>8__locals6.tempPlayRateStruct = new RefCompDefine.PlayRateStruct(playRateAbs, easeType, new float?((rateEase != null) ? rateEase.Duration : 0f), new float?(0f));
			IEaseData rateEase2 = CS$<>8__locals1.inSequenceConfig.RateEase;
			EEaseType? eeaseType = (rateEase2 != null) ? new EEaseType?(rateEase2.Type) : null;
			if (eeaseType != null)
			{
				switch (eeaseType.GetValueOrDefault())
				{
				case EEaseType.Transient:
					CS$<>8__locals1.tempPlayRateStruct.EaseType = EKuroEasingFuncType.KEF_Linear;
					CS$<>8__locals1.tempPlayRateStruct.EaseDuration = new float?(0f);
					goto IL_5AA;
				case EEaseType.InOutCubic:
					CS$<>8__locals1.tempPlayRateStruct.EaseType = EKuroEasingFuncType.KEF_EaseInOut;
					CS$<>8__locals1.tempPlayRateStruct.EaseExponent = new float?((float)3);
					goto IL_5AA;
				case EEaseType.OutSine:
					CS$<>8__locals1.tempPlayRateStruct.EaseType = EKuroEasingFuncType.KEF_SinOut;
					goto IL_5AA;
				case EEaseType.OutQuart:
					CS$<>8__locals1.tempPlayRateStruct.EaseType = EKuroEasingFuncType.KEF_EaseOut;
					CS$<>8__locals1.tempPlayRateStruct.EaseExponent = new float?((float)4);
					goto IL_5AA;
				}
			}
			CS$<>8__locals1.tempPlayRateStruct.EaseType = EKuroEasingFuncType.KEF_Linear;
			IL_5AA:
			this.LoadResourceAsyncWithQueue<ULevelSequence>(CS$<>8__locals1.inSequenceConfig.LevelSequencePath, delegate([Nullable(2)] UObject data, string _)
			{
				if (data == null || !data.IsValid())
				{
					Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YZH, "此LevelEvent只能配置在SceneActorRefComponent中", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				if (CS$<>8__locals1.<>4__this.SimpleSequenceActor == null)
				{
					CS$<>8__locals1.<>4__this.SimpleSequenceActor = new SimpleLevelSequenceActor((ULevelSequence)data);
				}
				else
				{
					CS$<>8__locals1.<>4__this.SimpleSequenceActor.SetSequenceData((ULevelSequence)data);
				}
				CS$<>8__locals1.<>4__this.SimpleSequenceActor.UpdateSettings(new bool?(CS$<>8__locals1.inSequenceConfig.KeepUI.GetValueOrDefault()));
				CS$<>8__locals1.<>4__this.SimpleSequenceActor.SetCanPlayInLoading(CS$<>8__locals1.inSequenceConfig.IsPlayOnTeleport.GetValueOrDefault());
				if (CS$<>8__locals1.inSequenceConfig.IsEnableCenterOffset.GetValueOrDefault())
				{
					CS$<>8__locals1.<>4__this.SimpleSequenceActor.SetOriginTransform();
				}
				if (!string.IsNullOrEmpty(CS$<>8__locals1.inSequenceConfig.Mark))
				{
					LevelSequenceFrameEventComponent eventComp = CS$<>8__locals1.<>4__this.EventComp;
					if (eventComp != null)
					{
						eventComp.OnSequencePlayToMark(CS$<>8__locals1.inSequenceConfig.Mark, CS$<>8__locals1.<>4__this.SimpleSequenceActor.GetCurrentFrame(), CS$<>8__locals1.jumpToEnd, CS$<>8__locals1.inSequenceConfig.LevelSequencePath);
					}
					if (CS$<>8__locals1.<>4__this.EventComp != null)
					{
						CS$<>8__locals1.<>4__this.SimpleSequenceActor.AddOnPauseCallback(new Action(CS$<>8__locals1.<>4__this.EventComp.OnSequencePaused));
					}
					else
					{
						CS$<>8__locals1.<>4__this.SimpleSequenceActor.AddOnPauseCallback(null);
					}
				}
				else
				{
					ILoopRange loopRange = CS$<>8__locals1.inSequenceConfig.LoopRange;
					if (!string.IsNullOrEmpty((loopRange != null) ? loopRange.LeftMark : null))
					{
						CS$<>8__locals1.<>4__this.SimpleSequenceActor.PlayToMark(CS$<>8__locals1.inSequenceConfig.LoopRange.LeftMark, CS$<>8__locals1.tempInTransit, CS$<>8__locals1.tempOutTransit, CS$<>8__locals1.tempPlayRateStruct, CS$<>8__locals1.jumpToEnd);
					}
				}
				if (RefCompDefine.PrePhysicsSequenceConfig.Check(CS$<>8__locals1.inSequenceConfig.LevelSequencePath))
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 0", null);
				}
				TPlayMode? tplayMode;
				string a = (CS$<>8__locals1.inSequenceConfig.PlayMode != null) ? tplayMode.GetValueOrDefault().ToEnumString() : null;
				if (a == EPlayLevelSequenceType.ShortestPath.ToEnumString())
				{
					CS$<>8__locals1.<>4__this.SimpleSequenceActor.PlayToMarkByCheckWay(CS$<>8__locals1.inSequenceConfig.Mark, CS$<>8__locals1.tempInTransit, CS$<>8__locals1.tempOutTransit, CS$<>8__locals1.tempPlayRateStruct, CS$<>8__locals1.jumpToEnd);
				}
				else if (a == EPlayLevelSequenceType.Instant.ToEnumString())
				{
					CS$<>8__locals1.<>4__this.SimpleSequenceActor.PlayToMark(CS$<>8__locals1.inSequenceConfig.Mark, CS$<>8__locals1.tempInTransit, CS$<>8__locals1.tempOutTransit, CS$<>8__locals1.tempPlayRateStruct, true);
				}
				else if (a == EPlayLevelSequenceType.Loop.ToEnumString())
				{
					if (CS$<>8__locals1.inSequenceConfig.LoopRange != null)
					{
						CS$<>8__locals1.<>4__this.SimpleSequenceActor.PlayLoopBetweenMarks(CS$<>8__locals1.inSequenceConfig.LoopRange, CS$<>8__locals1.inSequenceConfig.Rate.GetValueOrDefault(1f) < 0f, CS$<>8__locals1.tempInTransit, CS$<>8__locals1.tempOutTransit, CS$<>8__locals1.tempPlayRateStruct, CS$<>8__locals1.jumpToEnd);
					}
					else
					{
						CS$<>8__locals1.<>4__this.SimpleSequenceActor.PlayLoop(CS$<>8__locals1.inSequenceConfig.Rate.GetValueOrDefault(1f) < 0f, -1, CS$<>8__locals1.tempInTransit, CS$<>8__locals1.tempOutTransit, CS$<>8__locals1.tempPlayRateStruct);
					}
				}
				else
				{
					CS$<>8__locals1.<>4__this.SimpleSequenceActor.PlayToMark(CS$<>8__locals1.inSequenceConfig.Mark, CS$<>8__locals1.tempInTransit, CS$<>8__locals1.tempOutTransit, CS$<>8__locals1.tempPlayRateStruct, CS$<>8__locals1.jumpToEnd);
				}
				if (RefCompDefine.PrePhysicsSequenceConfig.Check(CS$<>8__locals1.inSequenceConfig.LevelSequencePath))
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 1", null);
				}
			}, ResourceSystem.EResourceLoadPriority.Default);
		}

		// Token: 0x06030157 RID: 196951 RVA: 0x00BA90B0 File Offset: 0x00BA72B0
		private int LoadResourceAsyncWithQueue<[Nullable(0)] T>(string path, [Nullable(new byte[]
		{
			1,
			2,
			1
		})] Action<UObject, string> callback, ResourceSystem.EResourceLoadPriority priority = ResourceSystem.EResourceLoadPriority.Default) where T : UObject
		{
			if (this.ResourceLoadCallbackHandleQueue == null)
			{
				this.ResourceLoadCallbackHandleQueue = new Queue<RefCompLevelSequenceController.ResourceLoadCallbackHandle>(4);
			}
			RefCompLevelSequenceController.ResourceLoadCallbackHandle handle = new RefCompLevelSequenceController.ResourceLoadCallbackHandle(path, callback);
			this.ResourceLoadCallbackHandleQueue.Push(handle);
			handle.ResourceSystemId = Singleton<ResourceSystem>.Instance.LoadAsync<T>(path, delegate([Nullable(2)] T asset, string loadPath)
			{
				this.OnResourceLoadAsyncCallback(handle, asset);
			}, priority, "js_undefined");
			return handle.ResourceSystemId;
		}

		// Token: 0x06030158 RID: 196952 RVA: 0x00BA9130 File Offset: 0x00BA7330
		private void OnResourceLoadAsyncCallback(RefCompLevelSequenceController.ResourceLoadCallbackHandle handle, [Nullable(2)] UObject asset)
		{
			handle.Asset = asset;
			handle.LoadAsyncFinished = true;
			while (this.ResourceLoadCallbackHandleQueue != null && !this.ResourceLoadCallbackHandleQueue.Empty)
			{
				RefCompLevelSequenceController.ResourceLoadCallbackHandle front = this.ResourceLoadCallbackHandleQueue.Front;
				if (front == null || !front.LoadAsyncFinished)
				{
					break;
				}
				RefCompLevelSequenceController.ResourceLoadCallbackHandle frontHandle = this.ResourceLoadCallbackHandleQueue.Pop();
				RefCompLevelSequenceController.ResourceLoadCallbackHandle frontHandle4 = frontHandle;
				if (RefCompDefine.PrePhysicsSequenceConfig.Check((frontHandle4 != null) ? frontHandle4.Path : null))
				{
					ControllerBase<PlotController>.Instance.NextAfterTick(delegate(float _)
					{
						RefCompLevelSequenceController.ResourceLoadCallbackHandle frontHandle3 = frontHandle;
						if (frontHandle3 == null)
						{
							return;
						}
						Action<UObject, string> callback2 = frontHandle3.Callback;
						if (callback2 == null)
						{
							return;
						}
						callback2(frontHandle.Asset, frontHandle.Path);
					});
				}
				else
				{
					RefCompLevelSequenceController.ResourceLoadCallbackHandle frontHandle2 = frontHandle;
					if (frontHandle2 != null)
					{
						Action<UObject, string> callback = frontHandle2.Callback;
						if (callback != null)
						{
							callback(frontHandle.Asset, frontHandle.Path);
						}
					}
				}
			}
		}

		// Token: 0x06030159 RID: 196953 RVA: 0x00BA91FC File Offset: 0x00BA73FC
		public bool ForceSwitchSceneCamera(bool bEnable)
		{
			if (this.SimpleSequenceActor == null)
			{
				if (bEnable)
				{
					Singleton<global::Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.JYS, "时间控制装置启动请求:失败，SimpleSequenceActor为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return false;
			}
			return this.SimpleSequenceActor.ForceSwitchSceneCamera(bEnable);
		}

		// Token: 0x0603015A RID: 196954 RVA: 0x00BA923E File Offset: 0x00BA743E
		public void OnChangeTimeDilation(float timeDilation)
		{
			SimpleLevelSequenceActor simpleSequenceActor = this.SimpleSequenceActor;
			if (simpleSequenceActor == null)
			{
				return;
			}
			simpleSequenceActor.SetTimeDilation(timeDilation);
		}

		// Token: 0x0603015B RID: 196955 RVA: 0x00BA9251 File Offset: 0x00BA7451
		public bool IsPlaying()
		{
			SimpleLevelSequenceActor simpleSequenceActor = this.SimpleSequenceActor;
			return simpleSequenceActor != null && simpleSequenceActor.IsPlaying();
		}

		// Token: 0x0603015C RID: 196956 RVA: 0x00BA9264 File Offset: 0x00BA7464
		public bool IsPlayToMarkFinished(string mark)
		{
			if (this.SimpleSequenceActor == null)
			{
				return false;
			}
			double? markValue = this.SimpleSequenceActor.GetMarkValue(mark);
			int? num = (markValue != null) ? new int?((int)markValue.GetValueOrDefault()) : null;
			return num != null && !this.IsPlaying() && this.SimpleSequenceActor.GetCurrentFrame() == num.Value;
		}

		// Token: 0x0603015D RID: 196957 RVA: 0x00BA92D4 File Offset: 0x00BA74D4
		[return: Nullable(2)]
		public ISequenceProgressController CreateSequenceProgressController(string sequencePath)
		{
			if (StringUtils.IsBlank(sequencePath) || sequencePath == "None")
			{
				return null;
			}
			SplineConstrainedDragSequenceProgressController controller = new SplineConstrainedDragSequenceProgressController();
			this.LoadResourceAsyncWithQueue<ULevelSequence>(sequencePath, delegate([Nullable(2)] UObject data, string _)
			{
				controller.OnSequenceLoaded((ULevelSequence)data, sequencePath);
			}, ResourceSystem.EResourceLoadPriority.Default);
			return controller;
		}

		// Token: 0x0401B9C6 RID: 113094
		[StaticVariableRuleIgnore]
		private static readonly Stat StatInstance = Stat.Create("RefCompLevelSequenceController", "", "");

		// Token: 0x0401B9C7 RID: 113095
		[Nullable(2)]
		private LevelSequenceFrameEventComponent EventComp;

		// Token: 0x0401B9C8 RID: 113096
		[Nullable(2)]
		public SimpleLevelSequenceActor SimpleSequenceActor;

		// Token: 0x0401B9C9 RID: 113097
		public bool NextSequenceJumpToEnd = true;

		// Token: 0x0401B9CA RID: 113098
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Queue<RefCompLevelSequenceController.ResourceLoadCallbackHandle> ResourceLoadCallbackHandleQueue;

		// Token: 0x0200A915 RID: 43285
		[Nullable(0)]
		private class ResourceLoadCallbackHandle
		{
			// Token: 0x0604B0DE RID: 307422 RVA: 0x0146E494 File Offset: 0x0146C694
			public ResourceLoadCallbackHandle(string path, [Nullable(new byte[]
			{
				1,
				2,
				1
			})] Action<UObject, string> callback)
			{
			}

			// Token: 0x0403469E RID: 214686
			public string Path = path;

			// Token: 0x0403469F RID: 214687
			[Nullable(new byte[]
			{
				1,
				2,
				1
			})]
			public Action<UObject, string> Callback = callback;

			// Token: 0x040346A0 RID: 214688
			public int ResourceSystemId = -1;

			// Token: 0x040346A1 RID: 214689
			[Nullable(2)]
			public UObject Asset;

			// Token: 0x040346A2 RID: 214690
			public bool LoadAsyncFinished;
		}
	}
}
