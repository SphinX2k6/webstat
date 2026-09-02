using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005910 RID: 22800
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class MapRogueOp
	{
		// Token: 0x17009409 RID: 37897
		// (get) Token: 0x06039DF4 RID: 237044
		// (set) Token: 0x06039DF5 RID: 237045
		public abstract int StepSize { get; set; }

		// Token: 0x1700940A RID: 37898
		// (get) Token: 0x06039DF6 RID: 237046 RVA: 0x00EA7467 File Offset: 0x00EA5667
		public RogueResOpType Type
		{
			get
			{
				return this.Data.RogueResOpType;
			}
		}

		// Token: 0x06039DF7 RID: 237047 RVA: 0x00EA7474 File Offset: 0x00EA5674
		public void Update(RogueResOpData data, MapRogueGameInfo gameInfo)
		{
			this.Data = data;
			this.IncId = this.Data.IncId;
			this.OnUpdate(gameInfo);
		}

		// Token: 0x06039DF8 RID: 237048 RVA: 0x00EA7498 File Offset: 0x00EA5698
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 3);
			defaultInterpolatedStringHandler.AppendLiteral("IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" Type:");
			defaultInterpolatedStringHandler.AppendFormatted<RogueResOpType>(this.Data.RogueResOpType);
			defaultInterpolatedStringHandler.AppendLiteral(" Step:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentStep);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700940B RID: 37899
		// (get) Token: 0x06039DF9 RID: 237049 RVA: 0x00EA7506 File Offset: 0x00EA5706
		public bool IsFinished
		{
			get
			{
				return this.CurrentStep > this.StepSize;
			}
		}

		// Token: 0x1700940C RID: 37900
		// (get) Token: 0x06039DFA RID: 237050 RVA: 0x00EA7516 File Offset: 0x00EA5716
		public bool IsStartExecute
		{
			get
			{
				return this.CurrentStep >= 0;
			}
		}

		// Token: 0x06039DFB RID: 237051 RVA: 0x00EA7524 File Offset: 0x00EA5724
		public void BattleStateUpdate(bool inBattle, MapRogueGameInfo gameInfo)
		{
			this.OnBattleStateUpdate(inBattle, gameInfo);
		}

		// Token: 0x06039DFC RID: 237052 RVA: 0x00EA752E File Offset: 0x00EA572E
		public void StartExecute(MapRogueGameInfo gameInfo)
		{
			if (!this.OnBeforeStartExecuteCheck(gameInfo))
			{
				return;
			}
			if (this.CurrentStep != -1)
			{
				return;
			}
			this.StartExecuteAsync(gameInfo);
		}

		// Token: 0x06039DFD RID: 237053 RVA: 0x00EA754C File Offset: 0x00EA574C
		private UniTask StartExecuteAsync(MapRogueGameInfo gameInfo)
		{
			MapRogueOp.<StartExecuteAsync>d__20 <StartExecuteAsync>d__;
			<StartExecuteAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartExecuteAsync>d__.<>4__this = this;
			<StartExecuteAsync>d__.gameInfo = gameInfo;
			<StartExecuteAsync>d__.<>1__state = -1;
			<StartExecuteAsync>d__.<>t__builder.Start<MapRogueOp.<StartExecuteAsync>d__20>(ref <StartExecuteAsync>d__);
			return <StartExecuteAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039DFE RID: 237054 RVA: 0x00EA7598 File Offset: 0x00EA5798
		public void Execute(MapRogueGameInfo gameInfo, [Nullable(2)] Action<bool> callback = null)
		{
			if (this.IsFinished)
			{
				return;
			}
			this.CurrentStep++;
			if (this.CurrentStep > this.StepSize)
			{
				this.Finish(gameInfo, callback);
				return;
			}
			this.OnExecute(gameInfo);
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06039DFF RID: 237055 RVA: 0x00EA75E4 File Offset: 0x00EA57E4
		public void Delete(MapRogueGameInfo gameInfo)
		{
			this.OnDelete(gameInfo);
		}

		// Token: 0x06039E00 RID: 237056 RVA: 0x00EA75ED File Offset: 0x00EA57ED
		private void Finish(MapRogueGameInfo gameInfo, [Nullable(2)] Action<bool> callback = null)
		{
			this.OnFinish(gameInfo);
			this.ExecuteOp(callback);
		}

		// Token: 0x06039E01 RID: 237057 RVA: 0x00EA75FD File Offset: 0x00EA57FD
		[NullableContext(2)]
		protected void ExecuteOp(Action<bool> callback = null)
		{
			ControllerBase<MapRogueController>.Instance.RequestExecuteOp(this.IncId, this.OpExecuteClientId, callback);
		}

		// Token: 0x06039E02 RID: 237058 RVA: 0x00EA7616 File Offset: 0x00EA5816
		protected void ExecuteOpMultiSelect(List<int> ids, [Nullable(2)] Action<bool> callback = null)
		{
			ControllerBase<MapRogueController>.Instance.RequestExecuteOpMultiSelect(this.IncId, ids, callback);
		}

		// Token: 0x06039E03 RID: 237059 RVA: 0x00EA762A File Offset: 0x00EA582A
		protected virtual void OnUpdate(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E04 RID: 237060 RVA: 0x00EA762C File Offset: 0x00EA582C
		protected virtual void OnBattleStateUpdate(bool inBattle, MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E05 RID: 237061 RVA: 0x00EA762E File Offset: 0x00EA582E
		protected virtual void OnStartExecute(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E06 RID: 237062 RVA: 0x00EA7630 File Offset: 0x00EA5830
		protected virtual void OnExecute(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E07 RID: 237063 RVA: 0x00EA7632 File Offset: 0x00EA5832
		protected virtual void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E08 RID: 237064 RVA: 0x00EA7634 File Offset: 0x00EA5834
		protected virtual void OnDelete(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E09 RID: 237065 RVA: 0x00EA7636 File Offset: 0x00EA5836
		protected virtual bool OnBeforeStartExecuteCheck(MapRogueGameInfo gameInfo)
		{
			return true;
		}

		// Token: 0x04020CAA RID: 134314
		public int IncId = -1;

		// Token: 0x04020CAB RID: 134315
		public RogueResOpData Data;

		// Token: 0x04020CAC RID: 134316
		public bool ExecuteInMapView = true;

		// Token: 0x04020CAD RID: 134317
		public bool ExecuteAfterMapViewShow;

		// Token: 0x04020CAE RID: 134318
		protected int CurrentStep = -1;

		// Token: 0x04020CAF RID: 134319
		public int OpExecuteClientId;

		// Token: 0x04020CB0 RID: 134320
		public ERogueOpPriority Priority = ERogueOpPriority.Normal;
	}
}
