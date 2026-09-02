using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.SlidingBlocks;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005357 RID: 21335
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotInfo : IStaticVariableResetter
	{
		// Token: 0x060366E6 RID: 222950 RVA: 0x00DBAF7D File Offset: 0x00DB917D
		static PlotInfo()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PlotInfo.CreateStaticDefaultValue), new Action(PlotInfo.ResetStaticDefaultValue));
		}

		// Token: 0x17008D68 RID: 36200
		// (get) Token: 0x060366E7 RID: 222951 RVA: 0x00DBAF9C File Offset: 0x00DB919C
		[Nullable(1)]
		private static Pool<PlotInfo> Pool
		{
			[NullableContext(1)]
			get
			{
				return PlotInfo._pool;
			}
		}

		// Token: 0x060366E8 RID: 222952 RVA: 0x00DBAFA4 File Offset: 0x00DB91A4
		public PlotInfo()
		{
			this.FlowListName = "";
			this.FlowId = 0;
			this.StateId = new int?(0);
			this.StateActions = null;
			this.KeepMusic = false;
			this.Context = null;
			this.IsServerNotify = false;
			this.FlowIncId = 0L;
			this.IsBackground = false;
			this.IsBreakdown = false;
			this.IsServerEnd = false;
			this.IsAsync = false;
			this.PlotLevel = EPlotLevel.LevelC;
			this.IsWaitAnim = false;
			this.UiParam = null;
			this.CanBeAbandoned = false;
			this.FadeBegin = null;
			this.Pos = null;
			this.KeepMainRolePose = false;
			this.CheckPreload = false;
			this.Seamless = false;
			this.PreloadSequenceUiData = new List<string>();
		}

		// Token: 0x060366E9 RID: 222953 RVA: 0x00DBB064 File Offset: 0x00DB9264
		public void Init(bool isServerNotify, long flowIncId, [Nullable(1)] string flowListName, int flowId, int stateId, [Nullable(1)] List<ActionInfo> stateActions, bool keepMusic, GeneralContext context, bool isAsync, UiParam uiParam = null, bool canBeAbandoned = false, bool isSkip = false, global::Vector pos = null, bool checkPreload = false, Action callback = null, bool isTeleportTransition = false, IStateProgramSpecialProcessChangeTeamOptimization programSpecialProcess = null)
		{
			this.FlowListName = flowListName;
			this.FlowId = flowId;
			this.StateId = new int?(stateId);
			this.StateActions = stateActions;
			this.KeepMusic = keepMusic;
			this.IsServerNotify = isServerNotify;
			this.Context = context;
			this.FlowIncId = flowIncId;
			this.IsBackground = isSkip;
			this.IsBreakdown = false;
			this.IsAsync = isAsync;
			this.UiParam = (uiParam ?? new UiParam());
			this.CanBeAbandoned = canBeAbandoned;
			this.Pos = pos;
			this.CheckPreload = checkPreload;
			this.Callback = callback;
			this.IsTeleportTransition = isTeleportTransition;
			this.ProgramSpecialProcess = programSpecialProcess;
			this.Seamless = checkPreload;
			PlotInfo.AnalyzeLevel(this, stateActions);
		}

		// Token: 0x060366EA RID: 222954 RVA: 0x00DBB11C File Offset: 0x00DB931C
		[NullableContext(1)]
		public static void AnalyzeLevel(PlotInfo plotInfo, List<ActionInfo> actions)
		{
			EPlotLevel eplotLevel = EPlotLevel.LevelC;
			EPromptStyle? epromptStyle = null;
			bool isWaitAnim = false;
			bool value = false;
			EFadeInScreenShowType? fadeBegin = null;
			bool keepMainRolePose = false;
			if (actions.Count > 0)
			{
				ActionInfo actionInfo = actions[0];
				if (actionInfo.Name == EAction.SetPlotMode)
				{
					SetPlotMode setPlotMode = actionInfo.Params as SetPlotMode;
					eplotLevel = PlotInfo.GetPlotLevelByMode(setPlotMode.Mode);
					IPromptStyleBase promptStyle = setPlotMode.PromptStyle;
					epromptStyle = ((promptStyle != null) ? new EPromptStyle?(promptStyle.Type) : null);
					isWaitAnim = setPlotMode.WaitForPlayerMotionEnd.GetValueOrDefault();
					value = (setPlotMode.NoUiEnterAnimation.GetValueOrDefault() || plotInfo.Seamless);
					if (setPlotMode.FastFadeIn != null)
					{
						fadeBegin = new EFadeInScreenShowType?(setPlotMode.FastFadeIn.ScreenType.GetValueOrDefault(EFadeInScreenShowType.Black));
					}
					if (setPlotMode.KeepMainRolePose != null && setPlotMode.KeepMainRolePose.Value)
					{
						keepMainRolePose = true;
					}
				}
			}
			if (fadeBegin == null && actions.Count > 1)
			{
				ActionInfo actionInfo2 = actions[1];
				if (actionInfo2.Name == EAction.FadeInScreen)
				{
					FadeInScreen fadeInScreen = actionInfo2.Params as FadeInScreen;
					fadeBegin = new EFadeInScreenShowType?(fadeInScreen.ScreenType.GetValueOrDefault(EFadeInScreenShowType.Black));
				}
			}
			if (plotInfo.Seamless)
			{
				string a = "";
				foreach (ActionInfo actionInfo3 in actions)
				{
					if (actionInfo3.Name == EAction.SetPlotMode)
					{
						a = (actionInfo3.Params as SetPlotMode).Mode;
					}
					else if (actionInfo3.Name == EAction.ShowTalk && (a == EPlotLevel.LevelB.ToEnumString() || a == EPlotLevel.LevelA.ToEnumString()))
					{
						ShowTalk showTalk = actionInfo3.Params as ShowTalk;
						plotInfo.PreloadSequenceUiData.Add(showTalk.SequenceDataAsset);
					}
				}
			}
			plotInfo.PlotLevel = eplotLevel;
			plotInfo.IsWaitAnim = isWaitAnim;
			if (plotInfo.UiParam != null)
			{
				plotInfo.UiParam.DisableAnim = new bool?(value);
			}
			plotInfo.FadeBegin = fadeBegin;
			plotInfo.KeepMainRolePose = keepMainRolePose;
			if (eplotLevel == EPlotLevel.LevelD || eplotLevel == EPlotLevel.LevelE)
			{
				UiParam uiParam = plotInfo.UiParam;
				if ((uiParam == null || uiParam.ViewName == null) && plotInfo.UiParam != null)
				{
					plotInfo.UiParam.ViewName = new EUiViewName?(PlotInfo.GetViewName());
				}
			}
			if (eplotLevel == EPlotLevel.LevelE)
			{
				PlotInfo.ExtractIconTexturePathAndFirstAudio(actions, plotInfo);
				plotInfo.PromptStyle = new EPromptStyle?(epromptStyle.GetValueOrDefault());
			}
		}

		// Token: 0x060366EB RID: 222955 RVA: 0x00DBB3BC File Offset: 0x00DB95BC
		[NullableContext(1)]
		private static EPlotLevel GetPlotLevelByMode(string mode)
		{
			switch (EPlotModeExtensions.FromString(mode))
			{
			case EPlotMode.LevelA:
				return EPlotLevel.LevelA;
			case EPlotMode.LevelB:
				return EPlotLevel.LevelB;
			case EPlotMode.LevelC:
				return EPlotLevel.LevelC;
			case EPlotMode.LevelD:
				return EPlotLevel.LevelD;
			case EPlotMode.Prompt:
				return EPlotLevel.LevelE;
			case EPlotMode.Avg:
				return EPlotLevel.LevelC;
			case EPlotMode.ControlEntity:
				return EPlotLevel.ControlEntity;
			}
			return EPlotLevel.LevelC;
		}

		// Token: 0x060366EC RID: 222956 RVA: 0x00DBB41B File Offset: 0x00DB961B
		private static EUiViewName GetViewName()
		{
			if (ModelBase<SlidingBlocksModel>.Instance.IsInGame)
			{
				return EUiViewName.TetrisGameView;
			}
			if (ModelBase<SplineConstrainedDragModel>.Instance.GetDragActorPlayActive())
			{
				return EUiViewName.SplineConstrainedDrag;
			}
			return Singleton<UiModel>.Instance.MainViewName;
		}

		// Token: 0x060366ED RID: 222957 RVA: 0x00DBB44C File Offset: 0x00DB964C
		[NullableContext(1)]
		private unsafe static void ExtractIconTexturePathAndFirstAudio(List<ActionInfo> actions, PlotInfo plotInfo)
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			foreach (ActionInfo actionInfo in actions)
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					foreach (ITalkItem talkItem in (actionInfo.Params as ShowTalk).TalkItems)
					{
						if (string.IsNullOrEmpty(plotInfo.BlockAudio) && talkItem.PlayVoice.GetValueOrDefault())
						{
							plotInfo.BlockAudio = talkItem.TidTalk;
						}
						if (talkItem.WhoId != null)
						{
							Speaker? config = ConfigSpeakerById.GetConfig(talkItem.WhoId.Value, true);
							if (!string.IsNullOrEmpty((config != null) ? config.GetValueOrDefault().HeadRoundIconAsset : null))
							{
								PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
								bool flag = instance != null && instance.GetPlayerGender() == EPlayerGender.Male && !string.IsNullOrEmpty(config.Value.HeadRoundIconAssetMaleVariant);
								dictionary[config.Value.Id] = (flag ? config.Value.HeadRoundIconAssetMaleVariant : config.Value.HeadRoundIconAsset);
							}
							else
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
								defaultInterpolatedStringHandler.AppendFormatted(plotInfo.FlowListName);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted<int>(plotInfo.FlowId);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted<int?>(plotInfo.StateId);
								string item = defaultInterpolatedStringHandler.ToStringAndClear();
								FlowController instance2 = ControllerBase<FlowController>.Instance;
								string text = "[PlotTips]  没有头像路径，检查对话人配置";
								<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", talkItem.WhoId);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("flow", item);
								instance2.LogError(text, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
							}
						}
					}
				}
			}
			if (plotInfo.UiParam != null)
			{
				plotInfo.UiParam.TipsTalkTexturePaths = dictionary;
			}
		}

		// Token: 0x060366EE RID: 222958 RVA: 0x00DBB6C4 File Offset: 0x00DB98C4
		public void Clear()
		{
			this.FlowListName = null;
			this.StateId = null;
			this.StateActions = null;
			this.KeepMusic = false;
			this.FlowId = 0;
			this.Context = null;
			this.IsServerNotify = false;
			this.FlowIncId = 0L;
			this.IsBackground = false;
			this.IsBreakdown = false;
			this.IsServerEnd = false;
			this.IsAsync = false;
			this.UiParam = null;
			this.CanBeAbandoned = false;
			this.FadeBegin = null;
			this.Pos = null;
			this.Seamless = false;
			this.PreloadSequenceUiData.Clear();
			this.PromptStyle = null;
			this.BlockAudio = null;
			this.FormatIdInner = null;
			this.Callback = null;
			this.IsTeleportTransition = false;
			this.ProgramSpecialProcess = null;
		}

		// Token: 0x060366EF RID: 222959 RVA: 0x00DBB790 File Offset: 0x00DB9990
		[NullableContext(1)]
		public static PlotInfo Create()
		{
			PlotInfo plotInfo = PlotInfo.Pool.Get();
			if (plotInfo == null)
			{
				plotInfo = PlotInfo.Pool.Create();
			}
			return plotInfo;
		}

		// Token: 0x060366F0 RID: 222960 RVA: 0x00DBB7B7 File Offset: 0x00DB99B7
		public void Recycle()
		{
			this.Clear();
			PlotInfo.Pool.Put(this);
		}

		// Token: 0x17008D69 RID: 36201
		// (get) Token: 0x060366F1 RID: 222961 RVA: 0x00DBB7CC File Offset: 0x00DB99CC
		[Nullable(1)]
		public string FormatId
		{
			[NullableContext(1)]
			get
			{
				if (this.FormatIdInner == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
					defaultInterpolatedStringHandler.AppendFormatted(this.FlowListName);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.FlowId);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int?>(this.StateId);
					this.FormatIdInner = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				return this.FormatIdInner;
			}
		}

		// Token: 0x060366F2 RID: 222962 RVA: 0x00DBB83C File Offset: 0x00DB9A3C
		public static void CreateStaticDefaultValue()
		{
			PlotInfo._pool = new Pool<PlotInfo>(20, () => new PlotInfo(), null);
		}

		// Token: 0x060366F3 RID: 222963 RVA: 0x00DBB86A File Offset: 0x00DB9A6A
		public static void ResetStaticDefaultValue()
		{
			PlotInfo._pool = null;
		}

		// Token: 0x0401F4B8 RID: 128184
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Pool<PlotInfo> _pool;

		// Token: 0x0401F4B9 RID: 128185
		public string FlowListName;

		// Token: 0x0401F4BA RID: 128186
		public int FlowId;

		// Token: 0x0401F4BB RID: 128187
		public int? StateId;

		// Token: 0x0401F4BC RID: 128188
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> StateActions;

		// Token: 0x0401F4BD RID: 128189
		public bool KeepMusic;

		// Token: 0x0401F4BE RID: 128190
		public GeneralContext Context;

		// Token: 0x0401F4BF RID: 128191
		public bool IsServerNotify;

		// Token: 0x0401F4C0 RID: 128192
		public long FlowIncId;

		// Token: 0x0401F4C1 RID: 128193
		public bool IsBackground;

		// Token: 0x0401F4C2 RID: 128194
		public bool IsBreakdown;

		// Token: 0x0401F4C3 RID: 128195
		public bool IsServerEnd;

		// Token: 0x0401F4C4 RID: 128196
		public bool IsAsync;

		// Token: 0x0401F4C5 RID: 128197
		public EPlotLevel PlotLevel;

		// Token: 0x0401F4C6 RID: 128198
		public bool IsWaitAnim;

		// Token: 0x0401F4C7 RID: 128199
		public UiParam UiParam;

		// Token: 0x0401F4C8 RID: 128200
		public bool CanBeAbandoned;

		// Token: 0x0401F4C9 RID: 128201
		public EFadeInScreenShowType? FadeBegin;

		// Token: 0x0401F4CA RID: 128202
		public global::Vector Pos;

		// Token: 0x0401F4CB RID: 128203
		public bool KeepMainRolePose;

		// Token: 0x0401F4CC RID: 128204
		public bool CheckPreload;

		// Token: 0x0401F4CD RID: 128205
		public bool Seamless;

		// Token: 0x0401F4CE RID: 128206
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> PreloadSequenceUiData;

		// Token: 0x0401F4CF RID: 128207
		public EPromptStyle? PromptStyle;

		// Token: 0x0401F4D0 RID: 128208
		public string BlockAudio;

		// Token: 0x0401F4D1 RID: 128209
		public Action Callback;

		// Token: 0x0401F4D2 RID: 128210
		public bool IsTeleportTransition;

		// Token: 0x0401F4D3 RID: 128211
		public IStateProgramSpecialProcessChangeTeamOptimization ProgramSpecialProcess;

		// Token: 0x0401F4D4 RID: 128212
		private string FormatIdInner;
	}
}
