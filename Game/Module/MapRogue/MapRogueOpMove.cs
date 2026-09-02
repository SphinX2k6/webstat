using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005917 RID: 22807
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpMove : MapRogueOp
	{
		// Token: 0x17009419 RID: 37913
		// (get) Token: 0x06039E43 RID: 237123 RVA: 0x00EA819F File Offset: 0x00EA639F
		// (set) Token: 0x06039E44 RID: 237124 RVA: 0x00EA81A7 File Offset: 0x00EA63A7
		public override int StepSize { get; set; } = 1;

		// Token: 0x06039E45 RID: 237125 RVA: 0x00EA81B0 File Offset: 0x00EA63B0
		public MapRogueOpMove(int lastGridIndex)
		{
			this.ExecuteInMapView = true;
			this.ExecuteAfterMapViewShow = true;
			this.LastGridIndex = lastGridIndex;
		}

		// Token: 0x06039E46 RID: 237126 RVA: 0x00EA8214 File Offset: 0x00EA6414
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 3);
			defaultInterpolatedStringHandler.AppendLiteral("[Move] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" Step:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentStep);
			defaultInterpolatedStringHandler.AppendLiteral(" StepSize:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.StepSize);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E47 RID: 237127 RVA: 0x00EA8280 File Offset: 0x00EA6480
		protected override void OnUpdate(MapRogueGameInfo gameInfo)
		{
			MoveOp moveOp = this.Data.MoveOp;
			RepeatedField<int> repeatedField = (moveOp != null) ? moveOp.Paths : null;
			MoveOp moveOp2 = this.Data.MoveOp;
			RepeatedField<GridVision> repeatedField2 = (moveOp2 != null) ? moveOp2.GridVisions : null;
			if (repeatedField != null)
			{
				this.Path.Clear();
				this.Path.AddRange(repeatedField);
				this.StepSize = this.Path.Count;
				this.InitPathInfo();
			}
			if (repeatedField2 != null)
			{
				foreach (GridVision gridVision in repeatedField2)
				{
					List<int> list = new List<int>();
					list.AddRange(gridVision.Grids);
					this.UnlockGridVisions.Add(list);
				}
			}
		}

		// Token: 0x06039E48 RID: 237128 RVA: 0x00EA8348 File Offset: 0x00EA6548
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			int num = this.Path[this.Path.Count - 1];
			gameInfo.SetMoveTimeGap(this.Path.Count);
			if (gameInfo.CurSelectedIndex >= 0 && gameInfo.CurSelectedIndex != num)
			{
				gameInfo.SetMapGridBgStateProxy(gameInfo.CurSelectedIndex, false, null);
				gameInfo.SetMapGridBgStateProxy(num, true, null);
			}
			this.StartMoveAsync(gameInfo);
		}

		// Token: 0x06039E49 RID: 237129 RVA: 0x00EA83C0 File Offset: 0x00EA65C0
		private UniTask StartMoveAsync(MapRogueGameInfo gameInfo)
		{
			MapRogueOpMove.<StartMoveAsync>d__17 <StartMoveAsync>d__;
			<StartMoveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartMoveAsync>d__.<>4__this = this;
			<StartMoveAsync>d__.gameInfo = gameInfo;
			<StartMoveAsync>d__.<>1__state = -1;
			<StartMoveAsync>d__.<>t__builder.Start<MapRogueOpMove.<StartMoveAsync>d__17>(ref <StartMoveAsync>d__);
			return <StartMoveAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039E4A RID: 237130 RVA: 0x00EA840C File Offset: 0x00EA660C
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			int num = this.Path[this.CurrentStep - 1];
			foreach (int index in this.UnlockGridVisions[this.CurrentStep - 1])
			{
				gameInfo.SetGridVisionProxy(index, true);
			}
			if (this.CurrentFocusGridIndex == num)
			{
				this.FocusNextPath(gameInfo);
			}
			gameInfo.MoveOneStep(this.LastGridIndex, num);
			this.LastGridIndex = num;
			gameInfo.GameStage = EMapRogueGameStage.Move;
		}

		// Token: 0x06039E4B RID: 237131 RVA: 0x00EA84AC File Offset: 0x00EA66AC
		private void FocusNextPath(MapRogueGameInfo gameInfo)
		{
			if (this.CornerIndex.Count == 0)
			{
				return;
			}
			this.CurrentFocusGridIndex = this.CornerIndex[0];
			this.CornerIndex.RemoveAt(0);
			int num = this.CornerSingleLength[0];
			this.CornerSingleLength.RemoveAt(0);
			gameInfo.FocusOnGrid(this.CurrentFocusGridIndex, true, null, new float?(gameInfo.MoveTimeGap * (float)num / 1000f));
		}

		// Token: 0x06039E4C RID: 237132 RVA: 0x00EA8520 File Offset: 0x00EA6720
		private List<int> GetWholePath()
		{
			List<int> list = new List<int>();
			list.Add(this.LastGridIndex);
			list.AddRange(this.Path);
			return list;
		}

		// Token: 0x06039E4D RID: 237133 RVA: 0x00EA8540 File Offset: 0x00EA6740
		private void InitPathInfo()
		{
			int num = 0;
			List<int> wholePath = this.GetWholePath();
			for (int i = 1; i < wholePath.Count - 1; i++)
			{
				num++;
				int num2 = wholePath[i];
				int preId = wholePath[i - 1];
				int nextId = wholePath[i + 1];
				if (num >= 3 && this.IsShapeCorner(num2, preId, nextId))
				{
					this.CornerIndex.Add(num2);
					this.CornerSingleLength.Add(num);
					num = 0;
				}
			}
			this.CornerIndex.Add(wholePath[wholePath.Count - 1]);
			this.CornerSingleLength.Add(num + 1);
		}

		// Token: 0x06039E4E RID: 237134 RVA: 0x00EA85E0 File Offset: 0x00EA67E0
		protected bool IsShapeCorner(int curId, int preId, int nextId)
		{
			int num = MapRogueOpMove.<IsShapeCorner>g__directionFunc|22_0(curId, preId);
			int num2 = MapRogueOpMove.<IsShapeCorner>g__directionFunc|22_0(curId, nextId);
			return num != num2;
		}

		// Token: 0x06039E4F RID: 237135 RVA: 0x00EA8602 File Offset: 0x00EA6802
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
			gameInfo.SetInteractAvailable(EMapForbiddenTag.WaitExecuteOp, false);
			gameInfo.EndMove();
		}

		// Token: 0x06039E50 RID: 237136 RVA: 0x00EA8612 File Offset: 0x00EA6812
		[CompilerGenerated]
		internal static int <IsShapeCorner>g__directionFunc|22_0(int g0, int g1)
		{
			if (g0 + 1 == g1 || g0 - 1 == g1)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x04020CC3 RID: 134339
		private List<int> Path = new List<int>();

		// Token: 0x04020CC4 RID: 134340
		private readonly List<List<int>> UnlockGridVisions = new List<List<int>>();

		// Token: 0x04020CC5 RID: 134341
		public List<int> CornerIndex = new List<int>();

		// Token: 0x04020CC6 RID: 134342
		public List<int> CornerSingleLength = new List<int>();

		// Token: 0x04020CC7 RID: 134343
		public int CurrentFocusGridIndex = -1;

		// Token: 0x04020CC8 RID: 134344
		public int LastGridIndex;

		// Token: 0x04020CC9 RID: 134345
		private const int THOUSANDTH_RATIO = 1000;

		// Token: 0x04020CCA RID: 134346
		private const float FOCUS_PLAYER_TWEEN_TIME = 0.25f;

		// Token: 0x04020CCB RID: 134347
		private const int MIN_FOCUS_PATH_COUNT = 3;
	}
}
