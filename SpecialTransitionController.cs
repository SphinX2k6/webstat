using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002A85 RID: 10885
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SpecialTransitionController : ControllerBase<SpecialTransitionController>
{
	// Token: 0x06015C9F RID: 89247 RVA: 0x0060B46F File Offset: 0x0060966F
	[NullableContext(2)]
	public static bool IsTeleportPbLoadingMode(TransitionWithSpineLoadingPb pb)
	{
		object obj;
		if (pb == null)
		{
			obj = null;
		}
		else
		{
			ICustomScreenTypeBasePb icustomScreenTypeBasePb = pb.ICustomScreenTypeBasePb;
			obj = ((icustomScreenTypeBasePb != null) ? icustomScreenTypeBasePb.ICustomScreenLoadingPb : null);
		}
		return obj != null;
	}

	// Token: 0x06015CA0 RID: 89248 RVA: 0x0060B48C File Offset: 0x0060968C
	[NullableContext(2)]
	public bool HasScreenEffectFadeIn(TransitionWithSpineLoadingPb pb)
	{
		object obj;
		if (pb == null)
		{
			obj = null;
		}
		else
		{
			FadeBackgroundFadeInEffectPb fadeBackgroundFadeInEffectPb = pb.FadeBackgroundFadeInEffectPb;
			obj = ((fadeBackgroundFadeInEffectPb != null) ? fadeBackgroundFadeInEffectPb.FadeBackgroundFadeInEffectScreenPb : null);
		}
		return obj != null;
	}

	// Token: 0x06015CA1 RID: 89249 RVA: 0x0060B4AC File Offset: 0x006096AC
	public UniTask OpenSpecialTransitionLoadingByFadeScreen(IFadeBackgroundType fadeBackground, float? keepTime, [Nullable(2)] Action finishCallback = null)
	{
		SpecialTransitionController.<OpenSpecialTransitionLoadingByFadeScreen>d__2 <OpenSpecialTransitionLoadingByFadeScreen>d__;
		<OpenSpecialTransitionLoadingByFadeScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSpecialTransitionLoadingByFadeScreen>d__.fadeBackground = fadeBackground;
		<OpenSpecialTransitionLoadingByFadeScreen>d__.keepTime = keepTime;
		<OpenSpecialTransitionLoadingByFadeScreen>d__.finishCallback = finishCallback;
		<OpenSpecialTransitionLoadingByFadeScreen>d__.<>1__state = -1;
		<OpenSpecialTransitionLoadingByFadeScreen>d__.<>t__builder.Start<SpecialTransitionController.<OpenSpecialTransitionLoadingByFadeScreen>d__2>(ref <OpenSpecialTransitionLoadingByFadeScreen>d__);
		return <OpenSpecialTransitionLoadingByFadeScreen>d__.<>t__builder.Task;
	}

	// Token: 0x06015CA2 RID: 89250 RVA: 0x0060B500 File Offset: 0x00609700
	public UniTask OpenSpecialTransitionLoadingByTeleportPb(TransitionWithSpineLoadingPb spineLoadingPb, [Nullable(2)] Action finishCallback = null)
	{
		SpecialTransitionController.<OpenSpecialTransitionLoadingByTeleportPb>d__3 <OpenSpecialTransitionLoadingByTeleportPb>d__;
		<OpenSpecialTransitionLoadingByTeleportPb>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSpecialTransitionLoadingByTeleportPb>d__.<>4__this = this;
		<OpenSpecialTransitionLoadingByTeleportPb>d__.spineLoadingPb = spineLoadingPb;
		<OpenSpecialTransitionLoadingByTeleportPb>d__.finishCallback = finishCallback;
		<OpenSpecialTransitionLoadingByTeleportPb>d__.<>1__state = -1;
		<OpenSpecialTransitionLoadingByTeleportPb>d__.<>t__builder.Start<SpecialTransitionController.<OpenSpecialTransitionLoadingByTeleportPb>d__3>(ref <OpenSpecialTransitionLoadingByTeleportPb>d__);
		return <OpenSpecialTransitionLoadingByTeleportPb>d__.<>t__builder.Task;
	}

	// Token: 0x06015CA3 RID: 89251 RVA: 0x0060B554 File Offset: 0x00609754
	public UniTask OpenSpecialTransitionLoadingByConfig(ITeleportTransitionWithCustomScreen option, [Nullable(2)] Action finishCallback = null)
	{
		SpecialTransitionController.<OpenSpecialTransitionLoadingByConfig>d__4 <OpenSpecialTransitionLoadingByConfig>d__;
		<OpenSpecialTransitionLoadingByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSpecialTransitionLoadingByConfig>d__.<>4__this = this;
		<OpenSpecialTransitionLoadingByConfig>d__.option = option;
		<OpenSpecialTransitionLoadingByConfig>d__.finishCallback = finishCallback;
		<OpenSpecialTransitionLoadingByConfig>d__.<>1__state = -1;
		<OpenSpecialTransitionLoadingByConfig>d__.<>t__builder.Start<SpecialTransitionController.<OpenSpecialTransitionLoadingByConfig>d__4>(ref <OpenSpecialTransitionLoadingByConfig>d__);
		return <OpenSpecialTransitionLoadingByConfig>d__.<>t__builder.Task;
	}

	// Token: 0x06015CA4 RID: 89252 RVA: 0x0060B5A8 File Offset: 0x006097A8
	public UniTask OpenSpecialTransitionLoading(ISpecialTransitionParams @params, bool? closeBySelf = null)
	{
		SpecialTransitionController.<OpenSpecialTransitionLoading>d__5 <OpenSpecialTransitionLoading>d__;
		<OpenSpecialTransitionLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSpecialTransitionLoading>d__.<>4__this = this;
		<OpenSpecialTransitionLoading>d__.@params = @params;
		<OpenSpecialTransitionLoading>d__.closeBySelf = closeBySelf;
		<OpenSpecialTransitionLoading>d__.<>1__state = -1;
		<OpenSpecialTransitionLoading>d__.<>t__builder.Start<SpecialTransitionController.<OpenSpecialTransitionLoading>d__5>(ref <OpenSpecialTransitionLoading>d__);
		return <OpenSpecialTransitionLoading>d__.<>t__builder.Task;
	}

	// Token: 0x06015CA5 RID: 89253 RVA: 0x0060B5FC File Offset: 0x006097FC
	private UniTask OpenSpecialTransitionLoadingForLoadingMode(ISpecialTransitionParams @params, bool? closeBySelf)
	{
		SpecialTransitionController.<OpenSpecialTransitionLoadingForLoadingMode>d__6 <OpenSpecialTransitionLoadingForLoadingMode>d__;
		<OpenSpecialTransitionLoadingForLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSpecialTransitionLoadingForLoadingMode>d__.<>4__this = this;
		<OpenSpecialTransitionLoadingForLoadingMode>d__.@params = @params;
		<OpenSpecialTransitionLoadingForLoadingMode>d__.closeBySelf = closeBySelf;
		<OpenSpecialTransitionLoadingForLoadingMode>d__.<>1__state = -1;
		<OpenSpecialTransitionLoadingForLoadingMode>d__.<>t__builder.Start<SpecialTransitionController.<OpenSpecialTransitionLoadingForLoadingMode>d__6>(ref <OpenSpecialTransitionLoadingForLoadingMode>d__);
		return <OpenSpecialTransitionLoadingForLoadingMode>d__.<>t__builder.Task;
	}

	// Token: 0x06015CA6 RID: 89254 RVA: 0x0060B650 File Offset: 0x00609850
	[NullableContext(2)]
	private void PlayFadeInEffect(IFadeEffect fadeInEffect)
	{
		if (fadeInEffect == null)
		{
			return;
		}
		string screenEffect = fadeInEffect.ScreenEffect;
		if (!string.IsNullOrEmpty(screenEffect))
		{
			ModelBase<ScreenEffectModel>.Instance.PlayScreenEffect(screenEffect, "Teleport", null);
			Singleton<global::Log>.Instance.Info(ELogModule.Loading, ELogAuthor.CB, "SpecialTransition:进入效果：屏幕特效淡入(开始)", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		float? fadeInTime = fadeInEffect.FadeInTime;
		EFadeInScreenShowType? fadeColor = fadeInEffect.FadeColor;
		if (fadeInTime != null && fadeColor != null)
		{
			ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Common, ELoadingPerform.CameraFade, "SpecialTransition", delegate
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Loading, ELogAuthor.CB, "SpecialTransition:进入效果：黑幕淡入(完成)", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, new object[]
			{
				fadeInTime,
				fadeColor
			});
		}
	}

	// Token: 0x06015CA7 RID: 89255 RVA: 0x0060B708 File Offset: 0x00609908
	[NullableContext(2)]
	private void PlayFadeInOutPhase(IFadeEffect fadeInEffect, float? fadeOutTime)
	{
		if (fadeInEffect == null || !string.IsNullOrEmpty(fadeInEffect.ScreenEffect))
		{
			return;
		}
		if (fadeOutTime != null)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "SpecialTransition", delegate
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Loading, ELogAuthor.CB, "SpecialTransition:进入效果：黑幕淡出(完成)", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, fadeOutTime);
		}
	}

	// Token: 0x06015CA8 RID: 89256 RVA: 0x0060B760 File Offset: 0x00609960
	private void KeepSpecialTransitionLoading(ISpecialTransitionParams @params)
	{
		if (@params.FlowParams.KeepTime == null)
		{
			return;
		}
		ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.SpecialTransitionKeep, ELoadingPerform.SpecialTransition, null, delegate
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Loading, ELogAuthor.CB, "SpecialTransitionView 等待显示完成", default(ReadOnlySpan<ValueTuple<string, object>>));
		}, new object[]
		{
			@params
		});
		ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.SpecialTransitionKeep, null, null, null);
	}

	// Token: 0x06015CA9 RID: 89257 RVA: 0x0060B7D4 File Offset: 0x006099D4
	public UniTask CloseSpecialTransitionLoading()
	{
		SpecialTransitionController.<CloseSpecialTransitionLoading>d__10 <CloseSpecialTransitionLoading>d__;
		<CloseSpecialTransitionLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseSpecialTransitionLoading>d__.<>4__this = this;
		<CloseSpecialTransitionLoading>d__.<>1__state = -1;
		<CloseSpecialTransitionLoading>d__.<>t__builder.Start<SpecialTransitionController.<CloseSpecialTransitionLoading>d__10>(ref <CloseSpecialTransitionLoading>d__);
		return <CloseSpecialTransitionLoading>d__.<>t__builder.Task;
	}

	// Token: 0x06015CAA RID: 89258 RVA: 0x0060B818 File Offset: 0x00609A18
	private UniTask CloseSpecialTransitionLoadingForLoadingMode(ISpecialTransitionParams @params)
	{
		SpecialTransitionController.<CloseSpecialTransitionLoadingForLoadingMode>d__11 <CloseSpecialTransitionLoadingForLoadingMode>d__;
		<CloseSpecialTransitionLoadingForLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseSpecialTransitionLoadingForLoadingMode>d__.<>4__this = this;
		<CloseSpecialTransitionLoadingForLoadingMode>d__.@params = @params;
		<CloseSpecialTransitionLoadingForLoadingMode>d__.<>1__state = -1;
		<CloseSpecialTransitionLoadingForLoadingMode>d__.<>t__builder.Start<SpecialTransitionController.<CloseSpecialTransitionLoadingForLoadingMode>d__11>(ref <CloseSpecialTransitionLoadingForLoadingMode>d__);
		return <CloseSpecialTransitionLoadingForLoadingMode>d__.<>t__builder.Task;
	}

	// Token: 0x06015CAB RID: 89259 RVA: 0x0060B864 File Offset: 0x00609A64
	[NullableContext(2)]
	private UniTask PlayFadeOutEffectIn(IFadeEffect fadeOutEffect)
	{
		SpecialTransitionController.<PlayFadeOutEffectIn>d__12 <PlayFadeOutEffectIn>d__;
		<PlayFadeOutEffectIn>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFadeOutEffectIn>d__.fadeOutEffect = fadeOutEffect;
		<PlayFadeOutEffectIn>d__.<>1__state = -1;
		<PlayFadeOutEffectIn>d__.<>t__builder.Start<SpecialTransitionController.<PlayFadeOutEffectIn>d__12>(ref <PlayFadeOutEffectIn>d__);
		return <PlayFadeOutEffectIn>d__.<>t__builder.Task;
	}

	// Token: 0x06015CAC RID: 89260 RVA: 0x0060B8A8 File Offset: 0x00609AA8
	[NullableContext(2)]
	private UniTask WaitFadeOutEffectEnd(IFadeEffect fadeOutEffect)
	{
		SpecialTransitionController.<WaitFadeOutEffectEnd>d__13 <WaitFadeOutEffectEnd>d__;
		<WaitFadeOutEffectEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitFadeOutEffectEnd>d__.fadeOutEffect = fadeOutEffect;
		<WaitFadeOutEffectEnd>d__.<>1__state = -1;
		<WaitFadeOutEffectEnd>d__.<>t__builder.Start<SpecialTransitionController.<WaitFadeOutEffectEnd>d__13>(ref <WaitFadeOutEffectEnd>d__);
		return <WaitFadeOutEffectEnd>d__.<>t__builder.Task;
	}

	// Token: 0x06015CAD RID: 89261 RVA: 0x0060B8EC File Offset: 0x00609AEC
	public UniTask PlayFadeInEffectBeforeLeavingLevel(TransitionWithSpineLoadingPb spineLoadingPb)
	{
		SpecialTransitionController.<PlayFadeInEffectBeforeLeavingLevel>d__14 <PlayFadeInEffectBeforeLeavingLevel>d__;
		<PlayFadeInEffectBeforeLeavingLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFadeInEffectBeforeLeavingLevel>d__.<>4__this = this;
		<PlayFadeInEffectBeforeLeavingLevel>d__.spineLoadingPb = spineLoadingPb;
		<PlayFadeInEffectBeforeLeavingLevel>d__.<>1__state = -1;
		<PlayFadeInEffectBeforeLeavingLevel>d__.<>t__builder.Start<SpecialTransitionController.<PlayFadeInEffectBeforeLeavingLevel>d__14>(ref <PlayFadeInEffectBeforeLeavingLevel>d__);
		return <PlayFadeInEffectBeforeLeavingLevel>d__.<>t__builder.Task;
	}

	// Token: 0x06015CAE RID: 89262 RVA: 0x0060B938 File Offset: 0x00609B38
	public void CloseFadeInEffectAfterOpeningLoading(TransitionWithSpineLoadingPb spineLoadingPb)
	{
		IFadeEffect fadeInEffect = this.ParsePbIntoSpecialTransitionParams(spineLoadingPb).FlowParams.FadeInEffect;
		if (fadeInEffect == null || string.IsNullOrEmpty(fadeInEffect.ScreenEffect))
		{
			return;
		}
		string screenEffect = fadeInEffect.ScreenEffect;
		ModelBase<ScreenEffectModel>.Instance.EndScreenEffectByPath(screenEffect);
	}

	// Token: 0x06015CAF RID: 89263 RVA: 0x0060B97C File Offset: 0x00609B7C
	private ISpecialTransitionParams ParsePbIntoSpecialTransitionParams(TransitionWithSpineLoadingPb spineLoadingPb)
	{
		IFadeEffect fadeInEffect = null;
		FadeBackgroundFadeInEffectPb fadeBackgroundFadeInEffectPb = spineLoadingPb.FadeBackgroundFadeInEffectPb;
		FadeBackgroundFadeInEffectBlackPb fadeBackgroundFadeInEffectBlackPb = (fadeBackgroundFadeInEffectPb != null) ? fadeBackgroundFadeInEffectPb.FadeBackgroundFadeInEffectBlackPb : null;
		FadeBackgroundFadeInEffectPb fadeBackgroundFadeInEffectPb2 = spineLoadingPb.FadeBackgroundFadeInEffectPb;
		FadeBackgroundFadeInEffectScreenPb fadeBackgroundFadeInEffectScreenPb = (fadeBackgroundFadeInEffectPb2 != null) ? fadeBackgroundFadeInEffectPb2.FadeBackgroundFadeInEffectScreenPb : null;
		if (fadeBackgroundFadeInEffectBlackPb != null)
		{
			fadeInEffect = new FadeEffect
			{
				FadeColor = new EFadeInScreenShowType?((fadeBackgroundFadeInEffectBlackPb.FadeColor == 0) ? EFadeInScreenShowType.White : EFadeInScreenShowType.Black),
				FadeInTime = new float?(fadeBackgroundFadeInEffectBlackPb.FadeInTime),
				FadeOutTime = new float?(fadeBackgroundFadeInEffectBlackPb.FadeOutTime)
			};
		}
		else if (fadeBackgroundFadeInEffectScreenPb != null)
		{
			fadeInEffect = new FadeEffect
			{
				ScreenEffect = fadeBackgroundFadeInEffectScreenPb.ScreenEffect
			};
		}
		IFadeEffect fadeOutEffect = null;
		FadeBackgroundFadeOutEffectPb fadeBackgroundFadeOutEffectPb = spineLoadingPb.FadeBackgroundFadeOutEffectPb;
		FadeBackgroundFadeOutEffectBlackPb fadeBackgroundFadeOutEffectBlackPb = (fadeBackgroundFadeOutEffectPb != null) ? fadeBackgroundFadeOutEffectPb.FadeBackgroundFadeOutEffectBlackPb : null;
		FadeBackgroundFadeOutEffectPb fadeBackgroundFadeOutEffectPb2 = spineLoadingPb.FadeBackgroundFadeOutEffectPb;
		FadeBackgroundFadeOutEffectSceenPb fadeBackgroundFadeOutEffectSceenPb = (fadeBackgroundFadeOutEffectPb2 != null) ? fadeBackgroundFadeOutEffectPb2.FadeBackgroundFadeOutEffectSceenPb : null;
		if (fadeBackgroundFadeOutEffectBlackPb != null)
		{
			fadeOutEffect = new FadeEffect
			{
				FadeColor = new EFadeInScreenShowType?((fadeBackgroundFadeOutEffectBlackPb.FadeColor == 0) ? EFadeInScreenShowType.White : EFadeInScreenShowType.Black),
				FadeInTime = new float?(fadeBackgroundFadeOutEffectBlackPb.FadeInTime),
				FadeOutTime = new float?(fadeBackgroundFadeOutEffectBlackPb.FadeOutTime)
			};
		}
		else if (fadeBackgroundFadeOutEffectSceenPb != null)
		{
			fadeOutEffect = new FadeEffect
			{
				ScreenEffect = fadeBackgroundFadeOutEffectSceenPb.ScreenEffect
			};
		}
		ICustomShowUi customShowUi = null;
		ICustomShowUiPb icustomShowUiPb = spineLoadingPb.ICustomShowUiPb;
		if (icustomShowUiPb != null)
		{
			customShowUi = new ICustomShowUi();
			ICustomScreenTextSettingPb icustomScreenTextSettingPb = icustomShowUiPb.ICustomScreenTextSettingPb;
			if (icustomScreenTextSettingPb != null)
			{
				customShowUi.TextSetting = new ICustomScreenTextSetting
				{
					IsShowTextInfo = new bool?(icustomScreenTextSettingPb.IsShowTextInfo),
					TidTextContent = icustomScreenTextSettingPb.TidTextContent,
					EdTidTextContent = icustomScreenTextSettingPb.EdTidTextContent
				};
			}
			customShowUi.IsHideCircle = new bool?(icustomShowUiPb.IsHideCircle);
		}
		ICustomScreenTypeBasePb icustomScreenTypeBasePb = spineLoadingPb.ICustomScreenTypeBasePb;
		ICustomScreenLoadingPb customScreenLoadingPb = (icustomScreenTypeBasePb != null) ? icustomScreenTypeBasePb.ICustomScreenLoadingPb : null;
		ECustomScreenLoading? loadingType = null;
		if (customScreenLoadingPb != null && customScreenLoadingPb.ICustomScreenLoadingCyberpunkPb != null)
		{
			loadingType = new ECustomScreenLoading?(ECustomScreenLoading.Cyberpunk);
		}
		SpecialTransitionParams specialTransitionParams = new SpecialTransitionParams();
		SpecialTransitionViewParams specialTransitionViewParams = new SpecialTransitionViewParams();
		ICustomScreenTypeBasePb icustomScreenTypeBasePb2 = spineLoadingPb.ICustomScreenTypeBasePb;
		int? spineId;
		if (icustomScreenTypeBasePb2 == null)
		{
			spineId = null;
		}
		else
		{
			ICustomScreenSpinePb icustomScreenSpinePb = icustomScreenTypeBasePb2.ICustomScreenSpinePb;
			spineId = ((icustomScreenSpinePb != null) ? new int?(icustomScreenSpinePb.SpineId) : null);
		}
		specialTransitionViewParams.SpineId = spineId;
		ICustomScreenTypeBasePb icustomScreenTypeBasePb3 = spineLoadingPb.ICustomScreenTypeBasePb;
		string bgPath;
		if (icustomScreenTypeBasePb3 == null)
		{
			bgPath = null;
		}
		else
		{
			ICustomScreenBackgroundImagePb icustomScreenBackgroundImagePb = icustomScreenTypeBasePb3.ICustomScreenBackgroundImagePb;
			bgPath = ((icustomScreenBackgroundImagePb != null) ? icustomScreenBackgroundImagePb.BackgroundImagePath : null);
		}
		specialTransitionViewParams.BgPath = bgPath;
		specialTransitionViewParams.CustomShowUi = customShowUi;
		specialTransitionViewParams.AkEvent = spineLoadingPb.StartAkEvent;
		specialTransitionParams.ViewParams = specialTransitionViewParams;
		specialTransitionParams.FlowParams = new SpecialTransitionFlowParams
		{
			FadeInEffect = fadeInEffect,
			FadeOutEffect = fadeOutEffect,
			KeepTime = new float?(spineLoadingPb.KeepTime)
		};
		specialTransitionParams.LoadingType = loadingType;
		return specialTransitionParams;
	}

	// Token: 0x06015CB0 RID: 89264 RVA: 0x0060BBE8 File Offset: 0x00609DE8
	private ISpecialTransitionParams ParseConfigIntoSpecialTransitionParams(ITeleportTransitionWithCustomScreen option)
	{
		IFadeEffect fadeInEffect = null;
		IFadeBackgroundFadeInEffect fadeInEffect2 = option.FadeInEffect;
		IFadeBackgroundFadeInEffectTypeBase fadeBackgroundFadeInEffectTypeBase = (fadeInEffect2 != null) ? fadeInEffect2.FadeInEffect : null;
		if (fadeBackgroundFadeInEffectTypeBase != null)
		{
			if (fadeBackgroundFadeInEffectTypeBase.Type == EFadeBackgroundFadeInEffectType.Black)
			{
				IFadeBackgroundFadeInEffectBlack fadeBackgroundFadeInEffectBlack = (IFadeBackgroundFadeInEffectBlack)fadeBackgroundFadeInEffectTypeBase;
				fadeInEffect = new FadeEffect
				{
					FadeColor = new EFadeInScreenShowType?(fadeBackgroundFadeInEffectBlack.FadeColor),
					FadeInTime = fadeBackgroundFadeInEffectBlack.FadeInTime,
					FadeOutTime = fadeBackgroundFadeInEffectBlack.FadeOutTime
				};
			}
			else if (fadeBackgroundFadeInEffectTypeBase.Type == EFadeBackgroundFadeInEffectType.ScreenEffect)
			{
				IFadeBackgroundFadeInEffectScreenEffect fadeBackgroundFadeInEffectScreenEffect = (IFadeBackgroundFadeInEffectScreenEffect)fadeBackgroundFadeInEffectTypeBase;
				fadeInEffect = new FadeEffect
				{
					ScreenEffect = fadeBackgroundFadeInEffectScreenEffect.ScreenEffect
				};
			}
		}
		IFadeEffect fadeOutEffect = null;
		IFadeBackgroundFadeOutEffect fadeOutEffect2 = option.FadeOutEffect;
		IFadeBackgroundFadeOutEffectTypeBase fadeBackgroundFadeOutEffectTypeBase = (fadeOutEffect2 != null) ? fadeOutEffect2.FadeOutEffect : null;
		if (fadeBackgroundFadeOutEffectTypeBase != null)
		{
			if (fadeBackgroundFadeOutEffectTypeBase.Type == EFadeBackgroundFadeOutEffectType.Black)
			{
				IFadeBackgroundFadeOutEffectBlack fadeBackgroundFadeOutEffectBlack = (IFadeBackgroundFadeOutEffectBlack)fadeBackgroundFadeOutEffectTypeBase;
				fadeOutEffect = new FadeEffect
				{
					FadeColor = new EFadeInScreenShowType?(fadeBackgroundFadeOutEffectBlack.FadeColor),
					FadeInTime = fadeBackgroundFadeOutEffectBlack.FadeInTime,
					FadeOutTime = fadeBackgroundFadeOutEffectBlack.FadeOutTime
				};
			}
			else if (fadeBackgroundFadeOutEffectTypeBase.Type == EFadeBackgroundFadeOutEffectType.ScreenEffect)
			{
				IFadeBackgroundFadeOutEffectScreenEffect fadeBackgroundFadeOutEffectScreenEffect = (IFadeBackgroundFadeOutEffectScreenEffect)fadeBackgroundFadeOutEffectTypeBase;
				fadeOutEffect = new FadeEffect
				{
					ScreenEffect = fadeBackgroundFadeOutEffectScreenEffect.ScreenEffect
				};
			}
		}
		int? spineId = null;
		string bgPath = null;
		ECustomScreenLoading? loadingType = null;
		ICustomScreenTypeBase screenType = option.ScreenType;
		switch (screenType.Type)
		{
		case ECustomScreenType.Spine:
			spineId = new int?(((ICustomScreenSpine)screenType).SpineId);
			break;
		case ECustomScreenType.BackgroundImage:
			bgPath = ((ICustomScreenBackgroundImage)screenType).BackgroundImagePath;
			break;
		case ECustomScreenType.Loading:
			if (((ICustomScreenLoading)screenType).LoadingType != null)
			{
				loadingType = new ECustomScreenLoading?(((ICustomScreenLoading)screenType).LoadingType.Type);
			}
			break;
		}
		return new SpecialTransitionParams
		{
			ViewParams = new SpecialTransitionViewParams
			{
				SpineId = spineId,
				BgPath = bgPath,
				CustomShowUi = option.CustomShowUi,
				AkEvent = option.StartAkEvent
			},
			FlowParams = new SpecialTransitionFlowParams
			{
				FadeInEffect = fadeInEffect,
				FadeOutEffect = fadeOutEffect,
				KeepTime = option.KeepTime
			},
			LoadingType = loadingType
		};
	}
}
