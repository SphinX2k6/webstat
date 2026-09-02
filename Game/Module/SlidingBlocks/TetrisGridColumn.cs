using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F03 RID: 20227
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisGridColumn
	{
		// Token: 0x06034487 RID: 214151 RVA: 0x00D142FB File Offset: 0x00D124FB
		public TetrisGridColumn(SlidingBlocksGameData gameData, double columnIndex)
		{
		}

		// Token: 0x06034488 RID: 214152 RVA: 0x00D14328 File Offset: 0x00D12528
		public void Clear()
		{
			foreach (KeyValuePair<double, Mino> keyValuePair in this.MinoDataMap)
			{
				SlidingBlocksUtil.DestroyCube(keyValuePair.Value.CubeActor);
			}
			this.MinoDataMap.Clear();
		}

		// Token: 0x06034489 RID: 214153 RVA: 0x00D14394 File Offset: 0x00D12594
		public unsafe bool AddData(double y, Mino minoData)
		{
			if (this.MinoDataMap.TryAdd(y, minoData))
			{
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SlidingBlocks;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "AddColumnFailed:重复添加";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("x", this.ColumnIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("y", y);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}

		// Token: 0x0603448A RID: 214154 RVA: 0x00D14418 File Offset: 0x00D12618
		public bool RemoveData(double y)
		{
			return this.MinoDataMap.Remove(y);
		}

		// Token: 0x0603448B RID: 214155 RVA: 0x00D14428 File Offset: 0x00D12628
		public bool CheckOccupied(double y)
		{
			double key = SlidingBlocksUtil.MapToHalfInteger(y);
			return this.MinoDataMap.ContainsKey(key);
		}

		// Token: 0x0603448C RID: 214156 RVA: 0x00D14448 File Offset: 0x00D12648
		public double FindUnoccupiedGrid(double y)
		{
			double num = SlidingBlocksUtil.MapToHalfInteger(y);
			bool flag = true;
			while (flag)
			{
				flag = this.MinoDataMap.ContainsKey(num);
				num -= 1.0;
			}
			return num + 1.0;
		}

		// Token: 0x0603448D RID: 214157 RVA: 0x00D1448C File Offset: 0x00D1268C
		public UniTask TryFall(List<double> clearLineIndexArr)
		{
			TetrisGridColumn.<TryFall>d__10 <TryFall>d__;
			<TryFall>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryFall>d__.<>4__this = this;
			<TryFall>d__.clearLineIndexArr = clearLineIndexArr;
			<TryFall>d__.<>1__state = -1;
			<TryFall>d__.<>t__builder.Start<TetrisGridColumn.<TryFall>d__10>(ref <TryFall>d__);
			return <TryFall>d__.<>t__builder.Task;
		}

		// Token: 0x0603448E RID: 214158 RVA: 0x00D144D8 File Offset: 0x00D126D8
		private UniTask SingleMinoTryFall(Mino mino, double targetY)
		{
			TetrisGridColumn.<SingleMinoTryFall>d__11 <SingleMinoTryFall>d__;
			<SingleMinoTryFall>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SingleMinoTryFall>d__.<>4__this = this;
			<SingleMinoTryFall>d__.mino = mino;
			<SingleMinoTryFall>d__.targetY = targetY;
			<SingleMinoTryFall>d__.<>1__state = -1;
			<SingleMinoTryFall>d__.<>t__builder.Start<TetrisGridColumn.<SingleMinoTryFall>d__11>(ref <SingleMinoTryFall>d__);
			return <SingleMinoTryFall>d__.<>t__builder.Task;
		}

		// Token: 0x0603448F RID: 214159 RVA: 0x00D1452C File Offset: 0x00D1272C
		public void DrawDebug(FLinearColor color)
		{
			foreach (KeyValuePair<double, Mino> keyValuePair in this.MinoDataMap)
			{
				UObject world = GlobalData.World;
				FVectorDouble textLocation = keyValuePair.Value.CubeActor.D_K2_GetActorLocation();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("x:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(keyValuePair.Value.Coord.X, "F2");
				UKismetSystemLibrary.D_DrawDebugString(world, textLocation, defaultInterpolatedStringHandler.ToStringAndClear(), null, new FLinearColor?(color), 0f);
			}
		}

		// Token: 0x0401E2A2 RID: 123554
		private readonly Dictionary<double, Mino> MinoDataMap = new Dictionary<double, Mino>();

		// Token: 0x0401E2A3 RID: 123555
		private readonly Dictionary<Mino, int> RecordFallStep = new Dictionary<Mino, int>();

		// Token: 0x0401E2A4 RID: 123556
		public readonly SlidingBlocksGameData GameData = gameData;

		// Token: 0x0401E2A5 RID: 123557
		public readonly double ColumnIndex = columnIndex;
	}
}
