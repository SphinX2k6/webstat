using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005915 RID: 22805
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpGridEvent : MapRogueOp
	{
		// Token: 0x17009410 RID: 37904
		// (get) Token: 0x06039E25 RID: 237093 RVA: 0x00EA7A1C File Offset: 0x00EA5C1C
		// (set) Token: 0x06039E26 RID: 237094 RVA: 0x00EA7A24 File Offset: 0x00EA5C24
		public override int StepSize { get; set; } = 2;

		// Token: 0x06039E27 RID: 237095 RVA: 0x00EA7A30 File Offset: 0x00EA5C30
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 4);
			defaultInterpolatedStringHandler.AppendLiteral("[GridEvent] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" InStart:");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(this.IsInStart);
			defaultInterpolatedStringHandler.AppendLiteral(" InPlot:");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(this.IsInPlot);
			defaultInterpolatedStringHandler.AppendLiteral(" PlotStepId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentStepId);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E28 RID: 237096 RVA: 0x00EA7AB2 File Offset: 0x00EA5CB2
		protected override void OnUpdate(MapRogueGameInfo gameInfo)
		{
			if (!base.IsStartExecute)
			{
				return;
			}
			this.RefreshEvent(gameInfo);
		}

		// Token: 0x06039E29 RID: 237097 RVA: 0x00EA7AC4 File Offset: 0x00EA5CC4
		private void RefreshEvent(MapRogueGameInfo gameInfo)
		{
			if (!this.IsInStart)
			{
				if (this.IsInPlot && !gameInfo.InBattle)
				{
					if (!this.InEventView)
					{
						RogueResEventStep? rogueEventStepById = ConfigBase<MapRogueConfig>.Instance.GetRogueEventStepById(this.CurrentStepId);
						if (rogueEventStepById != null && rogueEventStepById.GetValueOrDefault().Type == 3)
						{
							this.ExecuteStep(this.CurrentStepId, 0);
							return;
						}
						Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueGridEventView, this.IncId, delegate(bool success, int viewId)
						{
							this.InEventView = success;
						});
						return;
					}
					else
					{
						Action<int> eventStepUpdateFunc = this.EventStepUpdateFunc;
						if (eventStepUpdateFunc == null)
						{
							return;
						}
						eventStepUpdateFunc(this.CurrentStepId);
					}
				}
				return;
			}
			GridEventOp gridEventOp = this.Data.GridEventOp;
			int? num;
			if (gridEventOp == null)
			{
				num = null;
			}
			else
			{
				GridEventData gridEventData = gridEventOp.GridEventData;
				num = ((gridEventData != null) ? new int?(gridEventData.EventId) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			RogueResGridEvent? gridEventConfigById = ConfigBase<MapRogueConfig>.Instance.GetGridEventConfigById(valueOrDefault);
			if (gridEventConfigById == null)
			{
				base.Execute(gameInfo, null);
				return;
			}
			RogueResGlobalParam? globalParamConfig = ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig();
			int[] array = globalParamConfig.Value.GetEventStartSpineTypeArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == gridEventConfigById.Value.EventType)
				{
					gameInfo.RoleAnimProxy(EMapRogueSpineAnim.Fight, false);
					break;
				}
			}
			bool flag = true;
			array = globalParamConfig.Value.GetEventStartSeqTypeArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == gridEventConfigById.Value.EventType)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				base.Execute(gameInfo, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueEventStartView, this.IncId, null);
		}

		// Token: 0x06039E2A RID: 237098 RVA: 0x00EA7C95 File Offset: 0x00EA5E95
		protected override void OnBattleStateUpdate(bool inBattle, MapRogueGameInfo gameInfo)
		{
			if (inBattle && this.InEventView)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.MapRogueGridEventView, delegate(bool _)
				{
					this.InEventView = false;
				});
			}
		}

		// Token: 0x06039E2B RID: 237099 RVA: 0x00EA7CBD File Offset: 0x00EA5EBD
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			this.RefreshEvent(gameInfo);
		}

		// Token: 0x06039E2C RID: 237100 RVA: 0x00EA7CC6 File Offset: 0x00EA5EC6
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			if (this.CurrentStep == 1)
			{
				base.ExecuteOp(null);
			}
		}

		// Token: 0x06039E2D RID: 237101 RVA: 0x00EA7CD8 File Offset: 0x00EA5ED8
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E2E RID: 237102 RVA: 0x00EA7CDA File Offset: 0x00EA5EDA
		protected override void OnDelete(MapRogueGameInfo gameInfo)
		{
			if (this.InEventView)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.MapRogueGridEventView, delegate(bool _)
				{
					this.InEventView = false;
				});
			}
		}

		// Token: 0x06039E2F RID: 237103 RVA: 0x00EA7D00 File Offset: 0x00EA5F00
		public void ExecuteStep(int stepId, int optionId)
		{
			if (this.CurrentStepId != stepId)
			{
				return;
			}
			if (this.ExecutingStepIdSet.Contains(stepId))
			{
				return;
			}
			if (this.Data.GridEventOp.EventPlotInfo.StepState == StepState.WaitConfirm)
			{
				this.ExecutingStepIdSet.Add(stepId);
				this.OpExecuteClientId = optionId;
				base.ExecuteOp(delegate(bool _)
				{
					this.ExecutingStepIdSet.Remove(stepId);
				});
			}
		}

		// Token: 0x17009411 RID: 37905
		// (get) Token: 0x06039E30 RID: 237104 RVA: 0x00EA7D88 File Offset: 0x00EA5F88
		public bool IsInStart
		{
			get
			{
				GridEventOp gridEventOp = this.Data.GridEventOp;
				return ((gridEventOp != null) ? new ClientStepState?(gridEventOp.ClientStepState) : null).GetValueOrDefault() == ClientStepState.SpecialEffect;
			}
		}

		// Token: 0x17009412 RID: 37906
		// (get) Token: 0x06039E31 RID: 237105 RVA: 0x00EA7DC4 File Offset: 0x00EA5FC4
		public bool IsInPlot
		{
			get
			{
				GridEventOp gridEventOp = this.Data.GridEventOp;
				return ((gridEventOp != null) ? new ClientStepState?(gridEventOp.ClientStepState) : null).GetValueOrDefault() == ClientStepState.EventPloting;
			}
		}

		// Token: 0x17009413 RID: 37907
		// (get) Token: 0x06039E32 RID: 237106 RVA: 0x00EA7E00 File Offset: 0x00EA6000
		public int CurrentPlotId
		{
			get
			{
				if (!this.IsInPlot)
				{
					return 0;
				}
				GridEventOp gridEventOp = this.Data.GridEventOp;
				int? num;
				if (gridEventOp == null)
				{
					num = null;
				}
				else
				{
					EventPlotInfo eventPlotInfo = gridEventOp.EventPlotInfo;
					num = ((eventPlotInfo != null) ? new int?(eventPlotInfo.PlotId) : null);
				}
				int? num2 = num;
				return num2.GetValueOrDefault();
			}
		}

		// Token: 0x17009414 RID: 37908
		// (get) Token: 0x06039E33 RID: 237107 RVA: 0x00EA7E58 File Offset: 0x00EA6058
		public int CurrentStepId
		{
			get
			{
				if (!this.IsInPlot)
				{
					return 0;
				}
				GridEventOp gridEventOp = this.Data.GridEventOp;
				int? num;
				if (gridEventOp == null)
				{
					num = null;
				}
				else
				{
					EventPlotInfo eventPlotInfo = gridEventOp.EventPlotInfo;
					num = ((eventPlotInfo != null) ? new int?(eventPlotInfo.StepId) : null);
				}
				int? num2 = num;
				return num2.GetValueOrDefault();
			}
		}

		// Token: 0x17009415 RID: 37909
		// (get) Token: 0x06039E34 RID: 237108 RVA: 0x00EA7EB0 File Offset: 0x00EA60B0
		public int CurrentPlotBgId
		{
			get
			{
				if (!this.IsInPlot)
				{
					return 0;
				}
				GridEventOp gridEventOp = this.Data.GridEventOp;
				int? num;
				if (gridEventOp == null)
				{
					num = null;
				}
				else
				{
					EventPlotInfo eventPlotInfo = gridEventOp.EventPlotInfo;
					num = ((eventPlotInfo != null) ? new int?(eventPlotInfo.ModifyImage) : null);
				}
				int? num2 = num;
				return num2.GetValueOrDefault();
			}
		}

		// Token: 0x17009416 RID: 37910
		// (get) Token: 0x06039E35 RID: 237109 RVA: 0x00EA7F08 File Offset: 0x00EA6108
		public int CurrentPlotBgmId
		{
			get
			{
				if (!this.IsInPlot)
				{
					return 0;
				}
				GridEventOp gridEventOp = this.Data.GridEventOp;
				int? num;
				if (gridEventOp == null)
				{
					num = null;
				}
				else
				{
					EventPlotInfo eventPlotInfo = gridEventOp.EventPlotInfo;
					num = ((eventPlotInfo != null) ? new int?(eventPlotInfo.ModifyBgm) : null);
				}
				int? num2 = num;
				return num2.GetValueOrDefault();
			}
		}

		// Token: 0x17009417 RID: 37911
		// (get) Token: 0x06039E36 RID: 237110 RVA: 0x00EA7F60 File Offset: 0x00EA6160
		public IList<EventOption> CurrentOptions
		{
			get
			{
				if (!this.IsInPlot)
				{
					return new List<EventOption>();
				}
				if (this.Data.GridEventOp.EventPlotInfo.Options == null)
				{
					return new List<EventOption>();
				}
				return this.Data.GridEventOp.EventPlotInfo.Options.ToList<EventOption>();
			}
		}

		// Token: 0x04020CBC RID: 134332
		protected bool InEventView;

		// Token: 0x04020CBE RID: 134334
		private readonly HashSet<int> ExecutingStepIdSet = new HashSet<int>();

		// Token: 0x04020CBF RID: 134335
		[Nullable(2)]
		public Action<int> EventStepUpdateFunc;
	}
}
