using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005911 RID: 22801
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpChangeEvent : MapRogueOp
	{
		// Token: 0x1700940D RID: 37901
		// (get) Token: 0x06039E0B RID: 237067 RVA: 0x00EA765D File Offset: 0x00EA585D
		// (set) Token: 0x06039E0C RID: 237068 RVA: 0x00EA7665 File Offset: 0x00EA5865
		public override int StepSize { get; set; } = 1;

		// Token: 0x06039E0D RID: 237069 RVA: 0x00EA7670 File Offset: 0x00EA5870
		public MapRogueOpChangeEvent()
		{
			this.ExecuteInMapView = true;
			this.ExecuteAfterMapViewShow = true;
		}

		// Token: 0x06039E0E RID: 237070 RVA: 0x00EA76BC File Offset: 0x00EA58BC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[ChangeEvent] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E0F RID: 237071 RVA: 0x00EA76F3 File Offset: 0x00EA58F3
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			base.Execute(gameInfo, null);
		}

		// Token: 0x06039E10 RID: 237072 RVA: 0x00EA7700 File Offset: 0x00EA5900
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			ChangeEventByPosOp changeEventByPosOp = this.Data.ChangeEventByPosOp;
			if (changeEventByPosOp == null)
			{
				return;
			}
			gameInfo.SetInteractAvailable(EMapForbiddenTag.FocusLock, false);
			for (int i = 0; i < changeEventByPosOp.ChangeEventDatas.Count; i++)
			{
				ChangeEventData changeEventData = changeEventByPosOp.ChangeEventDatas[i];
				bool finishChangeFlow = i == changeEventByPosOp.ChangeEventDatas.Count - 1;
				this.SingleGridChangeFlow(gameInfo, changeEventData.Index, changeEventData.RogueResGridData, finishChangeFlow);
			}
		}

		// Token: 0x06039E11 RID: 237073 RVA: 0x00EA7770 File Offset: 0x00EA5970
		private void SingleGridChangeFlow(MapRogueGameInfo gameInfo, int gridIndex, RogueResGridData gridInfo, bool finishChangeFlow)
		{
			MapRogueOpChangeEvent.<>c__DisplayClass10_0 CS$<>8__locals1 = new MapRogueOpChangeEvent.<>c__DisplayClass10_0();
			CS$<>8__locals1.gameInfo = gameInfo;
			CS$<>8__locals1.gridIndex = gridIndex;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.gridInfo = gridInfo;
			CS$<>8__locals1.finishChangeFlow = finishChangeFlow;
			AsyncTask task = new AsyncTask("MapRogueOpChangeEvent.SingleGridChangeFlow", delegate()
			{
				MapRogueOpChangeEvent.<>c__DisplayClass10_0.<<SingleGridChangeFlow>b__0>d <<SingleGridChangeFlow>b__0>d;
				<<SingleGridChangeFlow>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
				<<SingleGridChangeFlow>b__0>d.<>4__this = CS$<>8__locals1;
				<<SingleGridChangeFlow>b__0>d.<>1__state = -1;
				<<SingleGridChangeFlow>b__0>d.<>t__builder.Start<MapRogueOpChangeEvent.<>c__DisplayClass10_0.<<SingleGridChangeFlow>b__0>d>(ref <<SingleGridChangeFlow>b__0>d);
				return <<SingleGridChangeFlow>b__0>d.<>t__builder.Task;
			}, null, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run();
		}

		// Token: 0x06039E12 RID: 237074 RVA: 0x00EA77D7 File Offset: 0x00EA59D7
		private void FinishChangeFlow(MapRogueGameInfo gameInfo)
		{
			gameInfo.SetInteractAvailable(EMapForbiddenTag.FocusLock, true);
			base.Execute(gameInfo, null);
		}

		// Token: 0x06039E13 RID: 237075 RVA: 0x00EA77E9 File Offset: 0x00EA59E9
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x04020CB1 RID: 134321
		private readonly float FocusTweenTime = (float)ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.FocusTime;

		// Token: 0x04020CB3 RID: 134323
		private const int EVENT_CHANGE_ANIM_TIME = 500;
	}
}
