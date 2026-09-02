using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EF2 RID: 20210
	[NullableContext(1)]
	[Nullable(0)]
	public class TeleportTransitionHelper : TeleportContextHolder
	{
		// Token: 0x0603438E RID: 213902 RVA: 0x00D0F565 File Offset: 0x00D0D765
		public TeleportTransitionHelper(TeleportContext context) : base(context)
		{
		}

		// Token: 0x0603438F RID: 213903 RVA: 0x00D0F570 File Offset: 0x00D0D770
		[NullableContext(0)]
		public UniTask<bool> PlayTeleportTransition()
		{
			TeleportTransitionHelper.<PlayTeleportTransition>d__1 <PlayTeleportTransition>d__;
			<PlayTeleportTransition>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlayTeleportTransition>d__.<>4__this = this;
			<PlayTeleportTransition>d__.<>1__state = -1;
			<PlayTeleportTransition>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTeleportTransition>d__1>(ref <PlayTeleportTransition>d__);
			return <PlayTeleportTransition>d__.<>t__builder.Task;
		}

		// Token: 0x06034390 RID: 213904 RVA: 0x00D0F5B4 File Offset: 0x00D0D7B4
		[NullableContext(0)]
		public UniTask<bool> WaitTeleportTransition()
		{
			TeleportTransitionHelper.<WaitTeleportTransition>d__2 <WaitTeleportTransition>d__;
			<WaitTeleportTransition>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<WaitTeleportTransition>d__.<>4__this = this;
			<WaitTeleportTransition>d__.<>1__state = -1;
			<WaitTeleportTransition>d__.<>t__builder.Start<TeleportTransitionHelper.<WaitTeleportTransition>d__2>(ref <WaitTeleportTransition>d__);
			return <WaitTeleportTransition>d__.<>t__builder.Task;
		}

		// Token: 0x06034391 RID: 213905 RVA: 0x00D0F5F8 File Offset: 0x00D0D7F8
		private UniTask PlayTransition()
		{
			TeleportTransitionHelper.<PlayTransition>d__3 <PlayTransition>d__;
			<PlayTransition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransition>d__.<>4__this = this;
			<PlayTransition>d__.<>1__state = -1;
			<PlayTransition>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransition>d__3>(ref <PlayTransition>d__);
			return <PlayTransition>d__.<>t__builder.Task;
		}

		// Token: 0x06034392 RID: 213906 RVA: 0x00D0F63C File Offset: 0x00D0D83C
		[NullableContext(2)]
		private UniTask WaitTransition(TransitionOptionPb option)
		{
			TeleportTransitionHelper.<WaitTransition>d__4 <WaitTransition>d__;
			<WaitTransition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitTransition>d__.<>4__this = this;
			<WaitTransition>d__.option = option;
			<WaitTransition>d__.<>1__state = -1;
			<WaitTransition>d__.<>t__builder.Start<TeleportTransitionHelper.<WaitTransition>d__4>(ref <WaitTransition>d__);
			return <WaitTransition>d__.<>t__builder.Task;
		}

		// Token: 0x06034393 RID: 213907 RVA: 0x00D0F688 File Offset: 0x00D0D888
		private UniTask PlayTransitionByConfig(ITeleportTransitionType option)
		{
			TeleportTransitionHelper.<PlayTransitionByConfig>d__5 <PlayTransitionByConfig>d__;
			<PlayTransitionByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionByConfig>d__.<>4__this = this;
			<PlayTransitionByConfig>d__.option = option;
			<PlayTransitionByConfig>d__.<>1__state = -1;
			<PlayTransitionByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionByConfig>d__5>(ref <PlayTransitionByConfig>d__);
			return <PlayTransitionByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06034394 RID: 213908 RVA: 0x00D0F6D4 File Offset: 0x00D0D8D4
		private UniTask WaitTransitionByConfig(ITeleportTransitionType option)
		{
			TeleportTransitionHelper.<WaitTransitionByConfig>d__6 <WaitTransitionByConfig>d__;
			<WaitTransitionByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitTransitionByConfig>d__.<>4__this = this;
			<WaitTransitionByConfig>d__.option = option;
			<WaitTransitionByConfig>d__.<>1__state = -1;
			<WaitTransitionByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<WaitTransitionByConfig>d__6>(ref <WaitTransitionByConfig>d__);
			return <WaitTransitionByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06034395 RID: 213909 RVA: 0x00D0F720 File Offset: 0x00D0D920
		private UniTask PlayTransitionMp4ByConfig(ITeleportTransitionWithMp4 mp4Option)
		{
			TeleportTransitionHelper.<PlayTransitionMp4ByConfig>d__7 <PlayTransitionMp4ByConfig>d__;
			<PlayTransitionMp4ByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionMp4ByConfig>d__.<>4__this = this;
			<PlayTransitionMp4ByConfig>d__.mp4Option = mp4Option;
			<PlayTransitionMp4ByConfig>d__.<>1__state = -1;
			<PlayTransitionMp4ByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionMp4ByConfig>d__7>(ref <PlayTransitionMp4ByConfig>d__);
			return <PlayTransitionMp4ByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06034396 RID: 213910 RVA: 0x00D0F76C File Offset: 0x00D0D96C
		private static UniTask PlayTransitionCenterTextByConfig(ITeleportTransitionWithCenterText option, bool? needGuarantee = null)
		{
			TeleportTransitionHelper.<PlayTransitionCenterTextByConfig>d__8 <PlayTransitionCenterTextByConfig>d__;
			<PlayTransitionCenterTextByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionCenterTextByConfig>d__.option = option;
			<PlayTransitionCenterTextByConfig>d__.needGuarantee = needGuarantee;
			<PlayTransitionCenterTextByConfig>d__.<>1__state = -1;
			<PlayTransitionCenterTextByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionCenterTextByConfig>d__8>(ref <PlayTransitionCenterTextByConfig>d__);
			return <PlayTransitionCenterTextByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06034397 RID: 213911 RVA: 0x00D0F7B8 File Offset: 0x00D0D9B8
		private static void PlayTransitionEffectByConfig(ITeleportTransitionWithEffect option)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.TeleportMisc;
			ELogAuthor author = ELogAuthor.CK;
			string message = "传送过渡: PlayEffect开始";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EffectDaPath", option.EffectDaPath);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (option.EffectDaPath != "")
			{
				ScreenEffectModel instance2 = ModelBase<ScreenEffectModel>.Instance;
				if (instance2 != null)
				{
					instance2.PlayScreenEffect(option.EffectDaPath, "Teleport", null);
				}
			}
			Singleton<global::Log>.Instance.Info(ELogModule.TeleportMisc, ELogAuthor.CK, "传送过渡: PlayEffect完成", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06034398 RID: 213912 RVA: 0x00D0F844 File Offset: 0x00D0DA44
		private static UniTask PlayTransitionFadeInScreenByConfig(ITeleportTransitionWithFadeInScreen option)
		{
			TeleportTransitionHelper.<PlayTransitionFadeInScreenByConfig>d__10 <PlayTransitionFadeInScreenByConfig>d__;
			<PlayTransitionFadeInScreenByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionFadeInScreenByConfig>d__.option = option;
			<PlayTransitionFadeInScreenByConfig>d__.<>1__state = -1;
			<PlayTransitionFadeInScreenByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionFadeInScreenByConfig>d__10>(ref <PlayTransitionFadeInScreenByConfig>d__);
			return <PlayTransitionFadeInScreenByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06034399 RID: 213913 RVA: 0x00D0F888 File Offset: 0x00D0DA88
		private static UniTask PlayTransitionSpecialByConfig(ITeleportTransitionWithCustomScreen option)
		{
			TeleportTransitionHelper.<PlayTransitionSpecialByConfig>d__11 <PlayTransitionSpecialByConfig>d__;
			<PlayTransitionSpecialByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionSpecialByConfig>d__.option = option;
			<PlayTransitionSpecialByConfig>d__.<>1__state = -1;
			<PlayTransitionSpecialByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionSpecialByConfig>d__11>(ref <PlayTransitionSpecialByConfig>d__);
			return <PlayTransitionSpecialByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0603439A RID: 213914 RVA: 0x00D0F8CC File Offset: 0x00D0DACC
		private static UniTask PlayTransitionSpecialCustomLoadingByConfig(ITeleportTransitionWithSpecialCustomLoading option)
		{
			TeleportTransitionHelper.<PlayTransitionSpecialCustomLoadingByConfig>d__12 <PlayTransitionSpecialCustomLoadingByConfig>d__;
			<PlayTransitionSpecialCustomLoadingByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionSpecialCustomLoadingByConfig>d__.option = option;
			<PlayTransitionSpecialCustomLoadingByConfig>d__.<>1__state = -1;
			<PlayTransitionSpecialCustomLoadingByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionSpecialCustomLoadingByConfig>d__12>(ref <PlayTransitionSpecialCustomLoadingByConfig>d__);
			return <PlayTransitionSpecialCustomLoadingByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0603439B RID: 213915 RVA: 0x00D0F910 File Offset: 0x00D0DB10
		private static UniTask PlayTransitionWithPlayFlowByConfig(ITeleportTransitionWithPlayFlow option, Action onFlowEnd)
		{
			TeleportTransitionHelper.<PlayTransitionWithPlayFlowByConfig>d__13 <PlayTransitionWithPlayFlowByConfig>d__;
			<PlayTransitionWithPlayFlowByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionWithPlayFlowByConfig>d__.option = option;
			<PlayTransitionWithPlayFlowByConfig>d__.onFlowEnd = onFlowEnd;
			<PlayTransitionWithPlayFlowByConfig>d__.<>1__state = -1;
			<PlayTransitionWithPlayFlowByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionWithPlayFlowByConfig>d__13>(ref <PlayTransitionWithPlayFlowByConfig>d__);
			return <PlayTransitionWithPlayFlowByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0603439C RID: 213916 RVA: 0x00D0F95C File Offset: 0x00D0DB5C
		private static UniTask WaitPlayFlowFadeOutByConfig(ITeleportTransitionWithPlayFlow option)
		{
			TeleportTransitionHelper.<WaitPlayFlowFadeOutByConfig>d__14 <WaitPlayFlowFadeOutByConfig>d__;
			<WaitPlayFlowFadeOutByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitPlayFlowFadeOutByConfig>d__.option = option;
			<WaitPlayFlowFadeOutByConfig>d__.<>1__state = -1;
			<WaitPlayFlowFadeOutByConfig>d__.<>t__builder.Start<TeleportTransitionHelper.<WaitPlayFlowFadeOutByConfig>d__14>(ref <WaitPlayFlowFadeOutByConfig>d__);
			return <WaitPlayFlowFadeOutByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0603439D RID: 213917 RVA: 0x00D0F9A0 File Offset: 0x00D0DBA0
		private UniTask PlayTransitionFallback()
		{
			TeleportTransitionHelper.<PlayTransitionFallback>d__15 <PlayTransitionFallback>d__;
			<PlayTransitionFallback>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionFallback>d__.<>4__this = this;
			<PlayTransitionFallback>d__.<>1__state = -1;
			<PlayTransitionFallback>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionFallback>d__15>(ref <PlayTransitionFallback>d__);
			return <PlayTransitionFallback>d__.<>t__builder.Task;
		}

		// Token: 0x0603439E RID: 213918 RVA: 0x00D0F9E4 File Offset: 0x00D0DBE4
		private UniTask PlayTransitionMp4(TransitionMp4Pb protoTransitionMp4)
		{
			TeleportTransitionHelper.<PlayTransitionMp4>d__16 <PlayTransitionMp4>d__;
			<PlayTransitionMp4>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionMp4>d__.<>4__this = this;
			<PlayTransitionMp4>d__.protoTransitionMp4 = protoTransitionMp4;
			<PlayTransitionMp4>d__.<>1__state = -1;
			<PlayTransitionMp4>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionMp4>d__16>(ref <PlayTransitionMp4>d__);
			return <PlayTransitionMp4>d__.<>t__builder.Task;
		}

		// Token: 0x0603439F RID: 213919 RVA: 0x00D0FA30 File Offset: 0x00D0DC30
		[NullableContext(2)]
		public static UniTask PlayTransitionCenterText(TransitionFlowPb transitionFlow, bool? needGuarantee = null)
		{
			TeleportTransitionHelper.<PlayTransitionCenterText>d__17 <PlayTransitionCenterText>d__;
			<PlayTransitionCenterText>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionCenterText>d__.transitionFlow = transitionFlow;
			<PlayTransitionCenterText>d__.needGuarantee = needGuarantee;
			<PlayTransitionCenterText>d__.<>1__state = -1;
			<PlayTransitionCenterText>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionCenterText>d__17>(ref <PlayTransitionCenterText>d__);
			return <PlayTransitionCenterText>d__.<>t__builder.Task;
		}

		// Token: 0x060343A0 RID: 213920 RVA: 0x00D0FA7C File Offset: 0x00D0DC7C
		private static void PlayTransitionEffect(TransitionMp4Pb protoTransitionMp4)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.TeleportMisc, ELogAuthor.WRY, "传送过渡: PlayEffect 开始执行 PlayTransitionEffect", default(ReadOnlySpan<ValueTuple<string, object>>));
			try
			{
				TeleportTransitionHelper.<PlayTransitionEffect>g__PlayTransitionEffectWithoutLog|18_0(protoTransitionMp4);
				Singleton<global::Log>.Instance.Info(ELogModule.TeleportMisc, ELogAuthor.WRY, "传送过渡: PlayEffect 执行完成 PlayTransitionEffect", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			catch (Exception ex)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.TeleportMisc;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "传送过渡: PlayEffect 执行异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				throw;
			}
		}

		// Token: 0x060343A1 RID: 213921 RVA: 0x00D0FB14 File Offset: 0x00D0DD14
		private static UniTask PlayTransitionFadeInScreen(int? fadeInScreenShowType)
		{
			TeleportTransitionHelper.<PlayTransitionFadeInScreen>d__19 <PlayTransitionFadeInScreen>d__;
			<PlayTransitionFadeInScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionFadeInScreen>d__.fadeInScreenShowType = fadeInScreenShowType;
			<PlayTransitionFadeInScreen>d__.<>1__state = -1;
			<PlayTransitionFadeInScreen>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionFadeInScreen>d__19>(ref <PlayTransitionFadeInScreen>d__);
			return <PlayTransitionFadeInScreen>d__.<>t__builder.Task;
		}

		// Token: 0x060343A2 RID: 213922 RVA: 0x00D0FB58 File Offset: 0x00D0DD58
		private static UniTask PlayTransitionCharacterDisplay(int? styleId)
		{
			TeleportTransitionHelper.<PlayTransitionCharacterDisplay>d__20 <PlayTransitionCharacterDisplay>d__;
			<PlayTransitionCharacterDisplay>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionCharacterDisplay>d__.styleId = styleId;
			<PlayTransitionCharacterDisplay>d__.<>1__state = -1;
			<PlayTransitionCharacterDisplay>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionCharacterDisplay>d__20>(ref <PlayTransitionCharacterDisplay>d__);
			return <PlayTransitionCharacterDisplay>d__.<>t__builder.Task;
		}

		// Token: 0x060343A3 RID: 213923 RVA: 0x00D0FB9C File Offset: 0x00D0DD9C
		private static UniTask PlayTransitionCustomLoading(int? configId)
		{
			TeleportTransitionHelper.<PlayTransitionCustomLoading>d__21 <PlayTransitionCustomLoading>d__;
			<PlayTransitionCustomLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionCustomLoading>d__.configId = configId;
			<PlayTransitionCustomLoading>d__.<>1__state = -1;
			<PlayTransitionCustomLoading>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionCustomLoading>d__21>(ref <PlayTransitionCustomLoading>d__);
			return <PlayTransitionCustomLoading>d__.<>t__builder.Task;
		}

		// Token: 0x060343A4 RID: 213924 RVA: 0x00D0FBE0 File Offset: 0x00D0DDE0
		private static UniTask PlayTransitionSpecialCustomLoading(TransitionWithSpecialCustomLoadingPb protoTransition)
		{
			TeleportTransitionHelper.<PlayTransitionSpecialCustomLoading>d__22 <PlayTransitionSpecialCustomLoading>d__;
			<PlayTransitionSpecialCustomLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionSpecialCustomLoading>d__.protoTransition = protoTransition;
			<PlayTransitionSpecialCustomLoading>d__.<>1__state = -1;
			<PlayTransitionSpecialCustomLoading>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionSpecialCustomLoading>d__22>(ref <PlayTransitionSpecialCustomLoading>d__);
			return <PlayTransitionSpecialCustomLoading>d__.<>t__builder.Task;
		}

		// Token: 0x060343A5 RID: 213925 RVA: 0x00D0FC24 File Offset: 0x00D0DE24
		[NullableContext(2)]
		public static UniTask PlayTransitionSpecial(TransitionWithSpineLoadingPb pb, string tag = null)
		{
			TeleportTransitionHelper.<PlayTransitionSpecial>d__23 <PlayTransitionSpecial>d__;
			<PlayTransitionSpecial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionSpecial>d__.pb = pb;
			<PlayTransitionSpecial>d__.tag = tag;
			<PlayTransitionSpecial>d__.<>1__state = -1;
			<PlayTransitionSpecial>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionSpecial>d__23>(ref <PlayTransitionSpecial>d__);
			return <PlayTransitionSpecial>d__.<>t__builder.Task;
		}

		// Token: 0x060343A6 RID: 213926 RVA: 0x00D0FC70 File Offset: 0x00D0DE70
		public static TransitionOptionPb ParseTeleportTransitionOptionToPb([Nullable(2)] ITeleportTransitionType optionCfg)
		{
			TransitionOptionPb transitionOptionPb = TransitionOptionPb.Create();
			ETeleportTransitionType? eteleportTransitionType = (optionCfg != null) ? new ETeleportTransitionType?(optionCfg.Type) : null;
			if (eteleportTransitionType != null)
			{
				switch (eteleportTransitionType.GetValueOrDefault())
				{
				case ETeleportTransitionType.PlayMp4:
				{
					ITeleportTransitionWithMp4 teleportTransitionWithMp = (ITeleportTransitionWithMp4)optionCfg;
					transitionOptionPb.TransitionType = TransitionType.PlayMp4;
					transitionOptionPb.TransitionMp4.ResourePath = teleportTransitionWithMp.Mp4Path;
					return transitionOptionPb;
				}
				case ETeleportTransitionType.PlayEffect:
				{
					ITeleportTransitionWithEffect teleportTransitionWithEffect = (ITeleportTransitionWithEffect)optionCfg;
					transitionOptionPb.TransitionType = TransitionType.PlayEffect;
					transitionOptionPb.TransitionMp4.ResourePath = teleportTransitionWithEffect.EffectDaPath;
					return transitionOptionPb;
				}
				case ETeleportTransitionType.CenterText:
				{
					ITeleportTransitionWithCenterText teleportTransitionWithCenterText = (ITeleportTransitionWithCenterText)optionCfg;
					transitionOptionPb.TransitionType = TransitionType.CenterText;
					transitionOptionPb.TransitionFlow = TransitionFlowPb.Create();
					transitionOptionPb.TransitionFlow.FlowId = teleportTransitionWithCenterText.CenterTextFlow.FlowId;
					transitionOptionPb.TransitionFlow.FlowListName = teleportTransitionWithCenterText.CenterTextFlow.FlowListName;
					transitionOptionPb.TransitionFlow.StateId = teleportTransitionWithCenterText.CenterTextFlow.StateId;
					return transitionOptionPb;
				}
				case ETeleportTransitionType.Seamless:
				{
					ITeleportTransitionInSeamlessType teleportTransitionInSeamlessType = (ITeleportTransitionInSeamlessType)optionCfg;
					transitionOptionPb.TransitionType = TransitionType.Seamless;
					transitionOptionPb.TransitionInSeamless = TransitionInSeamlessPb.Create();
					transitionOptionPb.TransitionInSeamless.IsTeleportInPlace = teleportTransitionInSeamlessType.IsTeleportInPlace.GetValueOrDefault();
					transitionOptionPb.TransitionInSeamless.TransitionWeatherDaPath = teleportTransitionInSeamlessType.TransitionWeatherDaPath;
					transitionOptionPb.TransitionInSeamless.EffectDaPath = teleportTransitionInSeamlessType.EffectDaPath;
					transitionOptionPb.TransitionInSeamless.LeastTime = teleportTransitionInSeamlessType.LeastTime;
					transitionOptionPb.TransitionInSeamless.EffectExpandTime = teleportTransitionInSeamlessType.EffectExpandTime;
					transitionOptionPb.TransitionInSeamless.EffectCollapseTime = teleportTransitionInSeamlessType.EffectCollapseTime;
					transitionOptionPb.TransitionInSeamless.IsTeleportInPlace = teleportTransitionInSeamlessType.IsTeleportInPlace.GetValueOrDefault();
					transitionOptionPb.TransitionInSeamless.HasFloorSettings = (teleportTransitionInSeamlessType.FloorSettings != null);
					if (teleportTransitionInSeamlessType.FloorSettings != null)
					{
						FloorSettingsPb floorSettingsPb = FloorSettingsPb.Create();
						floorSettingsPb.MaterialPath = teleportTransitionInSeamlessType.FloorSettings.MaterialPath;
						floorSettingsPb.MeshPath = teleportTransitionInSeamlessType.FloorSettings.MeshPath;
						floorSettingsPb.ScaleX = teleportTransitionInSeamlessType.FloorSettings.Scale.X.GetValueOrDefault(1f);
						floorSettingsPb.ScaleY = teleportTransitionInSeamlessType.FloorSettings.Scale.Y.GetValueOrDefault(1f);
						floorSettingsPb.ShowTime = teleportTransitionInSeamlessType.FloorSettings.ShowTime;
						floorSettingsPb.DisappearTime = teleportTransitionInSeamlessType.FloorSettings.DisappearTime;
						transitionOptionPb.TransitionInSeamless.FloorSettings = floorSettingsPb;
					}
					if (teleportTransitionInSeamlessType.KeepMovementStates == null || teleportTransitionInSeamlessType.KeepMovementStates.Count <= 0)
					{
						return transitionOptionPb;
					}
					using (List<EKeepMovementState>.Enumerator enumerator = teleportTransitionInSeamlessType.KeepMovementStates.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current == EKeepMovementState.Kite)
							{
								transitionOptionPb.TransitionInSeamless.KeepStates.Add(KeepMovementState.Kite);
							}
						}
						return transitionOptionPb;
					}
					break;
				}
				case ETeleportTransitionType.FadeInScreen:
					break;
				case ETeleportTransitionType.DigitalScreen:
				case ETeleportTransitionType.CharacterDisplay:
				case ETeleportTransitionType.CustomLoading:
					goto IL_331;
				case ETeleportTransitionType.CustomScreen:
					TeleportTransitionHelper.CreateSpecialTransitionPb(transitionOptionPb, (ITeleportTransitionWithCustomScreen)optionCfg);
					return transitionOptionPb;
				case ETeleportTransitionType.SpecialCustomLoading:
					TeleportTransitionHelper.CreateSpecialCustomLoadingTransitionPb(transitionOptionPb, (ITeleportTransitionWithSpecialCustomLoading)optionCfg);
					return transitionOptionPb;
				default:
					goto IL_331;
				}
				ITeleportTransitionWithFadeInScreen teleportTransitionWithFadeInScreen = (ITeleportTransitionWithFadeInScreen)optionCfg;
				transitionOptionPb.TransitionType = TransitionType.FadeInScreen;
				transitionOptionPb.FadeInScreenShowType = ((teleportTransitionWithFadeInScreen.ScreenType.GetValueOrDefault() == EFadeInScreenShowType.Black) ? 1 : 0);
				return transitionOptionPb;
			}
			IL_331:
			transitionOptionPb.TransitionType = TransitionType.Empty;
			return transitionOptionPb;
		}

		// Token: 0x060343A7 RID: 213927 RVA: 0x00D0FFC8 File Offset: 0x00D0E1C8
		private static void CreateSpecialTransitionPb(TransitionOptionPb transitionOption, ITeleportTransitionWithCustomScreen optionCfg)
		{
			transitionOption.TransitionType = TransitionType.WithSpine;
			transitionOption.TransitionWithSpineLoadingPb = TransitionWithSpineLoadingPb.Create();
			transitionOption.TransitionWithSpineLoadingPb.ICustomScreenTypeBasePb = ICustomScreenTypeBasePb.Create();
			if (optionCfg.ScreenType.Type == ECustomScreenType.Spine)
			{
				(transitionOption.TransitionWithSpineLoadingPb.ICustomScreenTypeBasePb.ICustomScreenSpinePb = ICustomScreenSpinePb.Create()).SpineId = ((ICustomScreenSpine)optionCfg.ScreenType).SpineId;
			}
			else if (optionCfg.ScreenType.Type == ECustomScreenType.BackgroundImage)
			{
				(transitionOption.TransitionWithSpineLoadingPb.ICustomScreenTypeBasePb.ICustomScreenBackgroundImagePb = ICustomScreenBackgroundImagePb.Create()).BackgroundImagePath = ((ICustomScreenBackgroundImage)optionCfg.ScreenType).BackgroundImagePath;
			}
			if (optionCfg.FadeInEffect != null)
			{
				transitionOption.TransitionWithSpineLoadingPb.FadeBackgroundFadeInEffectPb = FadeBackgroundFadeInEffectPb.Create();
			}
			if (optionCfg.FadeOutEffect != null)
			{
				transitionOption.TransitionWithSpineLoadingPb.FadeBackgroundFadeOutEffectPb = FadeBackgroundFadeOutEffectPb.Create();
			}
			if (optionCfg.KeepTime != null)
			{
				transitionOption.TransitionWithSpineLoadingPb.KeepTime = optionCfg.KeepTime.Value;
			}
			if (optionCfg.CustomShowUi != null)
			{
				transitionOption.TransitionWithSpineLoadingPb.ICustomShowUiPb = ICustomShowUiPb.Create();
			}
			if (optionCfg.StartAkEvent != null)
			{
				transitionOption.TransitionWithSpineLoadingPb.StartAkEvent = optionCfg.StartAkEvent;
			}
		}

		// Token: 0x060343A8 RID: 213928 RVA: 0x00D100F8 File Offset: 0x00D0E2F8
		private static void CreateSpecialCustomLoadingTransitionPb(TransitionOptionPb transitionOption, ITeleportTransitionWithSpecialCustomLoading optionCfg)
		{
			transitionOption.TransitionType = TransitionType.WithSpecialCustomLoading;
			transitionOption.TransitionWithSpecialCustomLoadingPb = TransitionWithSpecialCustomLoadingPb.Create();
			IHonamiStoryCustomLoading loadingType = optionCfg.LoadingType;
			if (loadingType != null)
			{
				transitionOption.TransitionWithSpecialCustomLoadingPb.HonamiStoryCustomLoadingPb = HonamiStoryCustomLoadingPb.Create();
				transitionOption.TransitionWithSpecialCustomLoadingPb.HonamiStoryCustomLoadingPb.LoadingId = loadingType.LoadingId;
			}
		}

		// Token: 0x060343A9 RID: 213929 RVA: 0x00D10148 File Offset: 0x00D0E348
		public static UniTask PlayTransitionWithPlayFlow([Nullable(2)] TransitionPlayFlowPb playFlowPb, Action onFlowEnd)
		{
			TeleportTransitionHelper.<PlayTransitionWithPlayFlow>d__27 <PlayTransitionWithPlayFlow>d__;
			<PlayTransitionWithPlayFlow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionWithPlayFlow>d__.playFlowPb = playFlowPb;
			<PlayTransitionWithPlayFlow>d__.onFlowEnd = onFlowEnd;
			<PlayTransitionWithPlayFlow>d__.<>1__state = -1;
			<PlayTransitionWithPlayFlow>d__.<>t__builder.Start<TeleportTransitionHelper.<PlayTransitionWithPlayFlow>d__27>(ref <PlayTransitionWithPlayFlow>d__);
			return <PlayTransitionWithPlayFlow>d__.<>t__builder.Task;
		}

		// Token: 0x060343AA RID: 213930 RVA: 0x00D10194 File Offset: 0x00D0E394
		[NullableContext(2)]
		public static UniTask WaitPlayFlowFadeOut(TransitionPlayFlowPb playFlowPb)
		{
			TeleportTransitionHelper.<WaitPlayFlowFadeOut>d__28 <WaitPlayFlowFadeOut>d__;
			<WaitPlayFlowFadeOut>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitPlayFlowFadeOut>d__.playFlowPb = playFlowPb;
			<WaitPlayFlowFadeOut>d__.<>1__state = -1;
			<WaitPlayFlowFadeOut>d__.<>t__builder.Start<TeleportTransitionHelper.<WaitPlayFlowFadeOut>d__28>(ref <WaitPlayFlowFadeOut>d__);
			return <WaitPlayFlowFadeOut>d__.<>t__builder.Task;
		}

		// Token: 0x060343AB RID: 213931 RVA: 0x00D101D8 File Offset: 0x00D0E3D8
		private ELoadingPerform QueryDefaultTeleportMode()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return ELoadingPerform.CameraFade;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return ELoadingPerform.FadeLoading;
			}
			FVectorDouble actorLocation = Global.BaseCharacter.CharacterActorComponent.ActorLocation;
			FVectorDouble targetPosition = this.TeleportContext.TargetPosition;
			double num = FVectorDouble.Dist(actorLocation, targetPosition);
			int? intConfig = ConfigCommonParamById.GetIntConfig("TeleportRatingRange");
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.TeleportMisc;
			ELogAuthor author = ELogAuthor.CK;
			string message = "QueryDefaultTeleportMode";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("threshold", intConfig);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (num < (double)intConfig.Value)
			{
				return ELoadingPerform.CameraFade;
			}
			return ELoadingPerform.FadeLoading;
		}

		// Token: 0x060343AC RID: 213932 RVA: 0x00D10278 File Offset: 0x00D0E478
		[CompilerGenerated]
		private UniTask <PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0()
		{
			TeleportTransitionHelper.<<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d <<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d;
			<<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d.<>4__this = this;
			<<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d.<>1__state = -1;
			<<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d>(ref <<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d);
			return <<PlayTransitionFallback>g__PlayTransitionFallbackWithoutLog|15_0>d.<>t__builder.Task;
		}

		// Token: 0x060343AD RID: 213933 RVA: 0x00D102BC File Offset: 0x00D0E4BC
		[CompilerGenerated]
		private UniTask <PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0(TransitionMp4Pb protoTransitionMp4)
		{
			TeleportTransitionHelper.<<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d <<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d;
			<<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d.<>4__this = this;
			<<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d.protoTransitionMp4 = protoTransitionMp4;
			<<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d.<>1__state = -1;
			<<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d>(ref <<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d);
			return <<PlayTransitionMp4>g__PlayTransitionMp4WithoutLog|16_0>d.<>t__builder.Task;
		}

		// Token: 0x060343AF RID: 213935 RVA: 0x00D1036C File Offset: 0x00D0E56C
		[NullableContext(2)]
		[CompilerGenerated]
		internal static UniTask <PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0(TransitionFlowPb transitionFlow, bool? needGuarantee = null)
		{
			TeleportTransitionHelper.<<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d <<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d;
			<<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d.transitionFlow = transitionFlow;
			<<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d.needGuarantee = needGuarantee;
			<<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d.<>1__state = -1;
			<<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d>(ref <<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d);
			return <<PlayTransitionCenterText>g__PlayTransitionCenterTextWithoutLog|17_0>d.<>t__builder.Task;
		}

		// Token: 0x060343B0 RID: 213936 RVA: 0x00D103B7 File Offset: 0x00D0E5B7
		[CompilerGenerated]
		internal static void <PlayTransitionEffect>g__PlayTransitionEffectWithoutLog|18_0(TransitionMp4Pb protoTransitionMp4)
		{
			if (protoTransitionMp4.ResourePath != "")
			{
				ScreenEffectModel instance = ModelBase<ScreenEffectModel>.Instance;
				if (instance == null)
				{
					return;
				}
				instance.PlayScreenEffectForce(protoTransitionMp4.ResourePath, "Teleport");
			}
		}

		// Token: 0x060343B1 RID: 213937 RVA: 0x00D103E8 File Offset: 0x00D0E5E8
		[CompilerGenerated]
		internal static UniTask <PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0(int? fadeInScreenShowType)
		{
			TeleportTransitionHelper.<<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d <<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d;
			<<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d.fadeInScreenShowType = fadeInScreenShowType;
			<<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d.<>1__state = -1;
			<<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d>(ref <<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d);
			return <<PlayTransitionFadeInScreen>g__PlayTransitionFadeInScreenWithoutLog|19_0>d.<>t__builder.Task;
		}

		// Token: 0x060343B2 RID: 213938 RVA: 0x00D1042C File Offset: 0x00D0E62C
		[CompilerGenerated]
		internal static UniTask <PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0(int? styleId)
		{
			TeleportTransitionHelper.<<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d <<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d;
			<<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d.styleId = styleId;
			<<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d.<>1__state = -1;
			<<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d>(ref <<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d);
			return <<PlayTransitionCharacterDisplay>g__PlayTransitionCharacterDisplayWithoutLog|20_0>d.<>t__builder.Task;
		}

		// Token: 0x060343B3 RID: 213939 RVA: 0x00D10470 File Offset: 0x00D0E670
		[CompilerGenerated]
		internal static UniTask <PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0(int? configId)
		{
			TeleportTransitionHelper.<<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d <<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d;
			<<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d.configId = configId;
			<<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d.<>1__state = -1;
			<<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d>(ref <<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d);
			return <<PlayTransitionCustomLoading>g__PlayTransitionCustomLoadingWithoutLog|21_0>d.<>t__builder.Task;
		}

		// Token: 0x060343B4 RID: 213940 RVA: 0x00D104B4 File Offset: 0x00D0E6B4
		[CompilerGenerated]
		internal static UniTask <PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0(TransitionWithSpecialCustomLoadingPb protoTransition)
		{
			TeleportTransitionHelper.<<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d <<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d;
			<<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d.protoTransition = protoTransition;
			<<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d.<>1__state = -1;
			<<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d>(ref <<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d);
			return <<PlayTransitionSpecialCustomLoading>g__PlayTransitionSpecialCustomLoadingWithoutLog|22_0>d.<>t__builder.Task;
		}

		// Token: 0x060343B5 RID: 213941 RVA: 0x00D104F8 File Offset: 0x00D0E6F8
		[NullableContext(2)]
		[CompilerGenerated]
		internal static UniTask <PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0(TransitionWithSpineLoadingPb pb, string tag = null)
		{
			TeleportTransitionHelper.<<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d <<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d;
			<<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d.pb = pb;
			<<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d.tag = tag;
			<<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d.<>1__state = -1;
			<<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d>(ref <<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d);
			return <<PlayTransitionSpecial>g__PlayTransitionSpecialWithoutLog|23_0>d.<>t__builder.Task;
		}

		// Token: 0x060343B6 RID: 213942 RVA: 0x00D10544 File Offset: 0x00D0E744
		[CompilerGenerated]
		internal static UniTask <PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0([Nullable(2)] TransitionPlayFlowPb playFlowPb, Action onFlowEnd)
		{
			TeleportTransitionHelper.<<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d <<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d;
			<<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d.playFlowPb = playFlowPb;
			<<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d.onFlowEnd = onFlowEnd;
			<<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d.<>1__state = -1;
			<<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d.<>t__builder.Start<TeleportTransitionHelper.<<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d>(ref <<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d);
			return <<PlayTransitionWithPlayFlow>g__PlayTransitionWithPlayFlowWithoutLog|27_0>d.<>t__builder.Task;
		}
	}
}
