using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200536F RID: 21359
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotConfig
	{
		// Token: 0x06036751 RID: 223057 RVA: 0x00DBCCBC File Offset: 0x00DBAEBC
		public void SetMode(SetPlotMode plotMode, bool isInInteraction = false)
		{
			this.SkipHiddenBlackScreenAtEnd = plotMode.DisableAutoFadeOut.GetValueOrDefault();
			if (this.IsGmPlayPlotOnce)
			{
				this.IsGmPlayPlotOnce = false;
				this.SkipHiddenBlackScreenAtEnd = false;
			}
			if (!string.IsNullOrEmpty(plotMode.Mode))
			{
				switch (EPlotModeExtensions.FromString(plotMode.Mode))
				{
				case EPlotMode.LevelA:
					this.HandleLevelA(plotMode);
					break;
				case EPlotMode.LevelB:
					this.HandleLevelB(plotMode);
					break;
				case EPlotMode.LevelC:
				case EPlotMode.Avg:
					this.HandleLevelC(plotMode, isInInteraction);
					break;
				case EPlotMode.LevelD:
					this.HandleLevelD(plotMode);
					break;
				case EPlotMode.Prompt:
					this.HandleLevelE(plotMode);
					break;
				case EPlotMode.ControlEntity:
					this.HandleLevelControlEntity(plotMode);
					break;
				}
			}
			this.SetPlotViewName(plotMode);
			if (plotMode.SubtitleStyle != null)
			{
				if (plotMode.SubtitleStyle.Type == ESubtitleStyle.LevelA)
				{
					this.SubtitleLevel = new EPlotLevel?(EPlotLevel.LevelA);
				}
				else if (plotMode.SubtitleStyle.Type == ESubtitleStyle.NewLevelB)
				{
					this.SubtitleLevel = this.PlotLevel;
				}
			}
			else
			{
				this.SubtitleLevel = this.PlotLevel;
			}
			string key = (plotMode.MainCharacterSkin != null) ? plotMode.MainCharacterSkin.ToString() : "Default";
			int playerSkinId;
			if (PlotConfig.SkinMap.TryGetValue(key, out playerSkinId))
			{
				this.PlayerSkinId = playerSkinId;
			}
			else
			{
				this.PlayerSkinId = PlotConfig.SkinMap["Default"];
			}
			this.OverrideAudioLevel = plotMode.OverrideAudioLevel;
			IEntityControlConfig entityControlConfig = plotMode.EntityControlConfig;
			this.HandlePlayerInControlEntityMode = ((entityControlConfig != null) ? entityControlConfig.IsControlPlayer : null).GetValueOrDefault();
		}

		// Token: 0x06036752 RID: 223058 RVA: 0x00DBCE50 File Offset: 0x00DBB050
		private void HandleLevelA(SetPlotMode plotMode)
		{
			this.CameraMode = new EPlotCameraMode?(EPlotCameraMode.Plot);
			this.CanInteractive = false;
			bool isTeleportTransitionSeq = ModelBase<PlotModel>.Instance.IsTeleportTransitionSeq;
			this.CanSkip = ((!plotMode.NoSkip.GetValueOrDefault() && !isTeleportTransitionSeq) || this.CanSkipDebug);
			this.DisableInput = true;
			this.CanPause = false;
			this.PlotLevel = new EPlotLevel?(EPlotLevel.LevelA);
			this.AutoPlayState = EAutoPlayState.Auto;
			this.ShouldSwitchMainRole = false;
			this.PauseTime = true;
			this.SkipTalkWhenFighting = false;
			ControllerBase<PlotController>.Instance.TogglePlotProtect(true);
			ControllerBase<PlotController>.Instance.EnableViewControl(false);
		}

		// Token: 0x06036753 RID: 223059 RVA: 0x00DBCEEC File Offset: 0x00DBB0EC
		private void HandleLevelB(SetPlotMode plotMode)
		{
			this.CameraMode = new EPlotCameraMode?(EPlotCameraMode.Plot);
			this.CanInteractive = true;
			bool isTeleportTransitionSeq = ModelBase<PlotModel>.Instance.IsTeleportTransitionSeq;
			this.CanSkip = ((!plotMode.NoSkip.GetValueOrDefault() && !isTeleportTransitionSeq) || this.CanSkipDebug);
			this.DisableInput = true;
			this.CanPause = true;
			this.AutoPlayState = this.AutoPlayStateCache;
			this.PlotLevel = new EPlotLevel?(EPlotLevel.LevelB);
			this.ShouldSwitchMainRole = false;
			this.PauseTime = true;
			this.SkipTalkWhenFighting = false;
			ControllerBase<PlotController>.Instance.TogglePlotProtect(true);
			ControllerBase<PlotController>.Instance.EnableViewControl(false);
		}

		// Token: 0x06036754 RID: 223060 RVA: 0x00DBCF8C File Offset: 0x00DBB18C
		private void HandleLevelC(SetPlotMode plotMode, bool isInInteraction = false)
		{
			if (plotMode.UseFlowCamera == null)
			{
				this.CameraMode = new EPlotCameraMode?(EPlotCameraMode.MainPlot);
			}
			else
			{
				this.CameraMode = new EPlotCameraMode?(plotMode.UseFlowCamera.Value ? EPlotCameraMode.MainPlot : EPlotCameraMode.Main);
			}
			this.CanInteractive = true;
			this.CanSkip = (!plotMode.NoSkip.GetValueOrDefault() || this.CanSkipDebug);
			this.DisableInput = true;
			this.CanPause = !isInInteraction;
			this.AutoPlayState = this.AutoPlayStateCache;
			this.PlotLevel = new EPlotLevel?(EPlotLevel.LevelC);
			this.ShouldSwitchMainRole = plotMode.IsSwitchMainRole.GetValueOrDefault();
			this.PauseTime = !isInInteraction;
			this.SkipTalkWhenFighting = false;
			this.ActivityGamePlayPlotConfig = plotMode.SystemGameDialogConfigId;
			ControllerBase<PlotController>.Instance.TogglePlotProtect(true);
			ControllerBase<PlotController>.Instance.EnableViewControl(ControllerBase<FlowController>.Instance.CheckViewControlBeginForC());
			ControllerBase<PlotController>.Instance.HideSummonedEntity();
		}

		// Token: 0x06036755 RID: 223061 RVA: 0x00DBD080 File Offset: 0x00DBB280
		private void HandleLevelD(SetPlotMode plotMode)
		{
			this.CameraMode = new EPlotCameraMode?(EPlotCameraMode.Main);
			this.CanInteractive = false;
			this.CanSkip = false;
			this.DisableInput = false;
			this.CanPause = false;
			this.AutoPlayState = EAutoPlayState.Auto;
			this.ShouldSwitchMainRole = false;
			this.PlotLevel = new EPlotLevel?(EPlotLevel.LevelD);
			this.PauseTime = false;
			this.SkipTalkWhenFighting = plotMode.Interruptible.GetValueOrDefault(false);
			this.SkipHiddenBlackScreenAtEnd = true;
			ControllerBase<PlotController>.Instance.EnableViewControl(false);
		}

		// Token: 0x06036756 RID: 223062 RVA: 0x00DBD100 File Offset: 0x00DBB300
		private void HandleLevelE(SetPlotMode plotMode)
		{
			this.CameraMode = new EPlotCameraMode?(EPlotCameraMode.Main);
			this.CanInteractive = false;
			this.CanSkip = false;
			this.DisableInput = false;
			this.CanPause = false;
			this.AutoPlayState = this.AutoPlayStateCache;
			this.PlotLevel = new EPlotLevel?(EPlotLevel.LevelE);
			this.PauseTime = false;
			this.SkipTalkWhenFighting = plotMode.Interruptible.GetValueOrDefault();
			this.SkipHiddenBlackScreenAtEnd = true;
			ControllerBase<PlotController>.Instance.EnableViewControl(false);
		}

		// Token: 0x06036757 RID: 223063 RVA: 0x00DBD17C File Offset: 0x00DBB37C
		private void HandleLevelControlEntity(SetPlotMode plotMode)
		{
			this.CameraMode = new EPlotCameraMode?(EPlotCameraMode.Main);
			this.CanInteractive = false;
			this.CanSkip = false;
			IEntityControlConfig entityControlConfig = plotMode.EntityControlConfig;
			this.DisableInput = ((entityControlConfig != null) ? entityControlConfig.IsControlPlayer : null).GetValueOrDefault();
			this.CanPause = false;
			this.AutoPlayState = EAutoPlayState.Auto;
			this.ShouldSwitchMainRole = false;
			this.PlotLevel = new EPlotLevel?(EPlotLevel.ControlEntity);
			this.PauseTime = false;
			this.SkipTalkWhenFighting = false;
			ControllerBase<PlotController>.Instance.EnableViewControl(false);
		}

		// Token: 0x06036758 RID: 223064 RVA: 0x00DBD208 File Offset: 0x00DBB408
		public EUiViewName? GetPlotViewNameByMode(SetPlotMode plotMode)
		{
			if (plotMode.Mp4Mode.GetValueOrDefault())
			{
				return null;
			}
			if (!string.IsNullOrEmpty(plotMode.Mode))
			{
				switch (EPlotModeExtensions.FromString(plotMode.Mode))
				{
				case EPlotMode.LevelA:
				case EPlotMode.LevelB:
					return new EUiViewName?(EUiViewName.PlotSubtitleView);
				case EPlotMode.LevelC:
				{
					int? systemGameDialogConfigId = plotMode.SystemGameDialogConfigId;
					if (systemGameDialogConfigId != null && systemGameDialogConfigId.GetValueOrDefault() != 0)
					{
						return new EUiViewName?(EUiViewName.ActivityGamePlayPlotView);
					}
					return new EUiViewName?(EUiViewName.PlotView);
				}
				case EPlotMode.LevelD:
					return new EUiViewName?(EUiViewName.PlotViewHUD);
				case EPlotMode.Avg:
					return new EUiViewName?(EUiViewName.PinballPlotView);
				case EPlotMode.ControlEntity:
					return new EUiViewName?(EUiViewName.PlotViewHUD);
				}
				return null;
			}
			return null;
		}

		// Token: 0x06036759 RID: 223065 RVA: 0x00DBD2E5 File Offset: 0x00DBB4E5
		private void SetPlotViewName(SetPlotMode plotMode)
		{
			this.PlotViewName = this.GetPlotViewNameByMode(plotMode);
		}

		// Token: 0x0401F55B RID: 128347
		public const string AUDIO_STATE_PLOT_LEVEL_GROUP = "plot_level";

		// Token: 0x0401F55C RID: 128348
		public const string AUDIO_STATE_NOT_PLOT = "none";

		// Token: 0x0401F55D RID: 128349
		public const string PLOT_END_AUDIO_EVENT = "plot_controller_end_plot";

		// Token: 0x0401F55E RID: 128350
		private const bool CAN_SKIP = true;

		// Token: 0x0401F55F RID: 128351
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EPlotLevel, string> AudioStatePlotLevel = new Dictionary<EPlotLevel, string>
		{
			{
				EPlotLevel.LevelA,
				"level_a"
			},
			{
				EPlotLevel.LevelB,
				"level_b"
			},
			{
				EPlotLevel.LevelC,
				"level_c"
			},
			{
				EPlotLevel.LevelD,
				"level_d"
			},
			{
				EPlotLevel.LevelE,
				"level_d"
			},
			{
				EPlotLevel.ControlEntity,
				"level_d"
			}
		};

		// Token: 0x0401F560 RID: 128352
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EOverrideAudioLevel, string> AudioStateOverrideAudioLevel = new Dictionary<EOverrideAudioLevel, string>
		{
			{
				EOverrideAudioLevel.LevelA,
				"level_a"
			},
			{
				EOverrideAudioLevel.LevelB,
				"level_b"
			},
			{
				EOverrideAudioLevel.LevelC,
				"level_c"
			},
			{
				EOverrideAudioLevel.LevelD,
				"level_d"
			}
		};

		// Token: 0x0401F561 RID: 128353
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, int> SkinMap = new Dictionary<string, int>
		{
			{
				"Default",
				1000
			},
			{
				"Uniform",
				2000
			}
		};

		// Token: 0x0401F562 RID: 128354
		public bool DisableInput;

		// Token: 0x0401F563 RID: 128355
		public bool CanSkip;

		// Token: 0x0401F564 RID: 128356
		public bool CanSkipDebug;

		// Token: 0x0401F565 RID: 128357
		public bool CanInteractive;

		// Token: 0x0401F566 RID: 128358
		public bool CanPause;

		// Token: 0x0401F567 RID: 128359
		public EPlotCameraMode? CameraMode;

		// Token: 0x0401F568 RID: 128360
		public EAutoPlayState AutoPlayState;

		// Token: 0x0401F569 RID: 128361
		public EAutoPlayState AutoPlayStateCache;

		// Token: 0x0401F56A RID: 128362
		public EPlotLevel? PlotLevel;

		// Token: 0x0401F56B RID: 128363
		public EPlotLevel? SubtitleLevel;

		// Token: 0x0401F56C RID: 128364
		public EUiViewName? PlotViewName;

		// Token: 0x0401F56D RID: 128365
		public bool ShouldSwitchMainRole;

		// Token: 0x0401F56E RID: 128366
		public bool PauseTime;

		// Token: 0x0401F56F RID: 128367
		public bool SkipTalkWhenFighting;

		// Token: 0x0401F570 RID: 128368
		public bool SkipHiddenBlackScreenAtEnd;

		// Token: 0x0401F571 RID: 128369
		public bool IsGmPlayPlotOnce;

		// Token: 0x0401F572 RID: 128370
		public bool IsPreStreaming;

		// Token: 0x0401F573 RID: 128371
		public bool IsSkipConfirmBoxShow = true;

		// Token: 0x0401F574 RID: 128372
		public int? ActivityGamePlayPlotConfig;

		// Token: 0x0401F575 RID: 128373
		public int PlayerSkinId = -1;

		// Token: 0x0401F576 RID: 128374
		public EOverrideAudioLevel? OverrideAudioLevel;

		// Token: 0x0401F577 RID: 128375
		public bool HandlePlayerInControlEntityMode;
	}
}
