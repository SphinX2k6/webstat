using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049E9 RID: 18921
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewInfo
	{
		// Token: 0x17008427 RID: 33831
		// (get) Token: 0x060317A5 RID: 202661 RVA: 0x00C55723 File Offset: 0x00C53923
		// (set) Token: 0x060317A6 RID: 202662 RVA: 0x00C5572B File Offset: 0x00C5392B
		[Nullable(2)]
		public ViewInfoDynamicData ExtraDynamicData { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x060317A7 RID: 202663 RVA: 0x00C55734 File Offset: 0x00C53934
		public void SetContainerLayerType(ELayerType? type)
		{
			if (type == null)
			{
				UiShow? uiShowConfig = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(this.Name);
				ELayerType containerType = (ELayerType)Enum.Parse(typeof(ELayerType), uiShowConfig.Value.Type);
				this.ContainerType = containerType;
				return;
			}
			this.ContainerType = type.Value;
			if (this.Type < type.Value)
			{
				this.Type = type.Value;
			}
		}

		// Token: 0x060317A8 RID: 202664 RVA: 0x00C557B0 File Offset: 0x00C539B0
		public ELayerType GetContainerLayerType()
		{
			return this.ContainerType;
		}

		// Token: 0x060317A9 RID: 202665 RVA: 0x00C557B8 File Offset: 0x00C539B8
		public UiViewInfo(EUiViewName name, ELayerType type, TUiViewCtor ctor, string path, string pcPath, string[] beObstructView, string audioEvent, string openAudioEvent, string loopAudioEvent, string closeAudioEvent, bool keepLoopEvent, float timeDilation, EShowCursorType showCursorType, bool canOpenViewByShortcutKey, bool isShortKeysExitView, ESourceType sourceType, bool loadAsync, bool needGc, bool isFullScreen, int sortIndex, EUiBehaviourPopType configCommonPopBg, string commonPopBgKey, string sceneIdInternal, bool isPermanent, List<string> skipAnimActions, int functionCondition, string scenePointTag = "", EViewLockWorldRenderType lockWorldRender = EViewLockWorldRenderType.Default, bool lockFrameRate = false)
		{
			this.Name = name;
			this.Type = type;
			this.Ctor = ctor;
			this.ConfigPath = path;
			this.ConfigPcPath = pcPath;
			this.Path = this.ConfigPath;
			this.PcPath = this.ConfigPcPath;
			this.BeObstructView = beObstructView;
			this.AudioEvent = audioEvent;
			this.OpenAudioEvent = openAudioEvent;
			this.LoopAudioEvent = loopAudioEvent;
			this.CloseAudioEvent = closeAudioEvent;
			this.KeepLoopEvent = keepLoopEvent;
			this.TimeDilation = timeDilation;
			this.ShowCursorType = showCursorType;
			this.CanOpenViewByShortcutKey = canOpenViewByShortcutKey;
			this.IsShortKeysExitView = isShortKeysExitView;
			this.SourceType = sourceType;
			this.LoadAsync = loadAsync;
			this.NeedGc = needGc;
			this.IsFullScreen = isFullScreen;
			this.SortIndex = sortIndex;
			this.ConfigCommonPopBg = configCommonPopBg;
			this.CommonPopBgKey = commonPopBgKey;
			this.SceneIdInternal = sceneIdInternal;
			this.IsPermanent = isPermanent;
			this.SkipAnimActions = skipAnimActions;
			this.FunctionCondition = functionCondition;
			this.ScenePointTag = scenePointTag;
			this.LockWorldRender = lockWorldRender;
			this.LockFrameRate = lockFrameRate;
			this.ContainerType = this.Type;
			this.CommonPopBg = this.ConfigCommonPopBg;
		}

		// Token: 0x17008428 RID: 33832
		// (get) Token: 0x060317AA RID: 202666 RVA: 0x00C558E7 File Offset: 0x00C53AE7
		public EUiViewName Name { get; }

		// Token: 0x17008429 RID: 33833
		// (get) Token: 0x060317AB RID: 202667 RVA: 0x00C558EF File Offset: 0x00C53AEF
		// (set) Token: 0x060317AC RID: 202668 RVA: 0x00C558F7 File Offset: 0x00C53AF7
		public ELayerType Type { get; set; }

		// Token: 0x1700842A RID: 33834
		// (get) Token: 0x060317AD RID: 202669 RVA: 0x00C55900 File Offset: 0x00C53B00
		public TUiViewCtor Ctor { get; }

		// Token: 0x1700842B RID: 33835
		// (get) Token: 0x060317AE RID: 202670 RVA: 0x00C55908 File Offset: 0x00C53B08
		// (set) Token: 0x060317AF RID: 202671 RVA: 0x00C55910 File Offset: 0x00C53B10
		public string ConfigPath { get; set; }

		// Token: 0x1700842C RID: 33836
		// (get) Token: 0x060317B0 RID: 202672 RVA: 0x00C55919 File Offset: 0x00C53B19
		// (set) Token: 0x060317B1 RID: 202673 RVA: 0x00C55921 File Offset: 0x00C53B21
		public string ConfigPcPath { get; set; }

		// Token: 0x1700842D RID: 33837
		// (get) Token: 0x060317B2 RID: 202674 RVA: 0x00C5592A File Offset: 0x00C53B2A
		// (set) Token: 0x060317B3 RID: 202675 RVA: 0x00C55932 File Offset: 0x00C53B32
		public string Path { get; set; }

		// Token: 0x1700842E RID: 33838
		// (get) Token: 0x060317B4 RID: 202676 RVA: 0x00C5593B File Offset: 0x00C53B3B
		// (set) Token: 0x060317B5 RID: 202677 RVA: 0x00C55943 File Offset: 0x00C53B43
		public string PcPath { get; set; }

		// Token: 0x1700842F RID: 33839
		// (get) Token: 0x060317B6 RID: 202678 RVA: 0x00C5594C File Offset: 0x00C53B4C
		public string[] BeObstructView { get; }

		// Token: 0x17008430 RID: 33840
		// (get) Token: 0x060317B7 RID: 202679 RVA: 0x00C55954 File Offset: 0x00C53B54
		public string AudioEvent { get; }

		// Token: 0x17008431 RID: 33841
		// (get) Token: 0x060317B8 RID: 202680 RVA: 0x00C5595C File Offset: 0x00C53B5C
		public string OpenAudioEvent { get; }

		// Token: 0x17008432 RID: 33842
		// (get) Token: 0x060317B9 RID: 202681 RVA: 0x00C55964 File Offset: 0x00C53B64
		public string LoopAudioEvent { get; }

		// Token: 0x17008433 RID: 33843
		// (get) Token: 0x060317BA RID: 202682 RVA: 0x00C5596C File Offset: 0x00C53B6C
		public string CloseAudioEvent { get; }

		// Token: 0x17008434 RID: 33844
		// (get) Token: 0x060317BB RID: 202683 RVA: 0x00C55974 File Offset: 0x00C53B74
		public bool KeepLoopEvent { get; }

		// Token: 0x17008435 RID: 33845
		// (get) Token: 0x060317BC RID: 202684 RVA: 0x00C5597C File Offset: 0x00C53B7C
		public float TimeDilation { get; }

		// Token: 0x17008436 RID: 33846
		// (get) Token: 0x060317BD RID: 202685 RVA: 0x00C55984 File Offset: 0x00C53B84
		public EShowCursorType ShowCursorType { get; }

		// Token: 0x17008437 RID: 33847
		// (get) Token: 0x060317BE RID: 202686 RVA: 0x00C5598C File Offset: 0x00C53B8C
		public bool CanOpenViewByShortcutKey { get; }

		// Token: 0x17008438 RID: 33848
		// (get) Token: 0x060317BF RID: 202687 RVA: 0x00C55994 File Offset: 0x00C53B94
		public bool IsShortKeysExitView { get; }

		// Token: 0x17008439 RID: 33849
		// (get) Token: 0x060317C0 RID: 202688 RVA: 0x00C5599C File Offset: 0x00C53B9C
		public ESourceType SourceType { get; }

		// Token: 0x1700843A RID: 33850
		// (get) Token: 0x060317C1 RID: 202689 RVA: 0x00C559A4 File Offset: 0x00C53BA4
		public bool LoadAsync { get; }

		// Token: 0x1700843B RID: 33851
		// (get) Token: 0x060317C2 RID: 202690 RVA: 0x00C559AC File Offset: 0x00C53BAC
		public bool NeedGc { get; }

		// Token: 0x1700843C RID: 33852
		// (get) Token: 0x060317C3 RID: 202691 RVA: 0x00C559B4 File Offset: 0x00C53BB4
		public bool IsFullScreen { get; }

		// Token: 0x1700843D RID: 33853
		// (get) Token: 0x060317C4 RID: 202692 RVA: 0x00C559BC File Offset: 0x00C53BBC
		public int SortIndex { get; }

		// Token: 0x1700843E RID: 33854
		// (get) Token: 0x060317C5 RID: 202693 RVA: 0x00C559C4 File Offset: 0x00C53BC4
		public EUiBehaviourPopType ConfigCommonPopBg { get; }

		// Token: 0x1700843F RID: 33855
		// (get) Token: 0x060317C6 RID: 202694 RVA: 0x00C559CC File Offset: 0x00C53BCC
		// (set) Token: 0x060317C7 RID: 202695 RVA: 0x00C559D4 File Offset: 0x00C53BD4
		public string CommonPopBgKey { get; set; }

		// Token: 0x17008440 RID: 33856
		// (get) Token: 0x060317C8 RID: 202696 RVA: 0x00C559DD File Offset: 0x00C53BDD
		public string SceneIdInternal { get; }

		// Token: 0x17008441 RID: 33857
		// (get) Token: 0x060317C9 RID: 202697 RVA: 0x00C559E5 File Offset: 0x00C53BE5
		public bool IsPermanent { get; }

		// Token: 0x17008442 RID: 33858
		// (get) Token: 0x060317CA RID: 202698 RVA: 0x00C559ED File Offset: 0x00C53BED
		public List<string> SkipAnimActions { get; }

		// Token: 0x17008443 RID: 33859
		// (get) Token: 0x060317CB RID: 202699 RVA: 0x00C559F5 File Offset: 0x00C53BF5
		public int FunctionCondition { get; }

		// Token: 0x17008444 RID: 33860
		// (get) Token: 0x060317CC RID: 202700 RVA: 0x00C559FD File Offset: 0x00C53BFD
		public string ScenePointTag { get; }

		// Token: 0x17008445 RID: 33861
		// (get) Token: 0x060317CD RID: 202701 RVA: 0x00C55A05 File Offset: 0x00C53C05
		public EViewLockWorldRenderType LockWorldRender { get; }

		// Token: 0x17008446 RID: 33862
		// (get) Token: 0x060317CE RID: 202702 RVA: 0x00C55A0D File Offset: 0x00C53C0D
		public bool LockFrameRate { get; }

		// Token: 0x17008447 RID: 33863
		// (get) Token: 0x060317CF RID: 202703 RVA: 0x00C55A15 File Offset: 0x00C53C15
		public string UiPath
		{
			get
			{
				if (!Singleton<Info>.Instance.IsInTouch() && !string.IsNullOrEmpty(this.PcPath))
				{
					return this.PcPath;
				}
				return this.Path;
			}
		}

		// Token: 0x17008448 RID: 33864
		// (get) Token: 0x060317D0 RID: 202704 RVA: 0x00C55A40 File Offset: 0x00C53C40
		public string SceneId
		{
			get
			{
				if (this.Type != ELayerType.Normal)
				{
					return string.Empty;
				}
				EUiViewName name;
				if (UiScenePathResolver.UiViewToRootViewForUiScene.TryGetValue(this.Name, out name))
				{
					UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(name);
					if (uiViewInfo != null)
					{
						return uiViewInfo.SceneId;
					}
				}
				IViewInfoDynamicSceneData viewInfoDynamicSceneData = this.ExtraDynamicData as IViewInfoDynamicSceneData;
				if (viewInfoDynamicSceneData != null)
				{
					string sceneId = viewInfoDynamicSceneData.GetSceneId();
					if (!string.IsNullOrEmpty(sceneId))
					{
						return sceneId;
					}
				}
				return this.SceneIdInternal;
			}
		}

		// Token: 0x0401CC88 RID: 117896
		private ELayerType ContainerType = ELayerType.Normal;

		// Token: 0x0401CC89 RID: 117897
		public EUiBehaviourPopType CommonPopBg;
	}
}
