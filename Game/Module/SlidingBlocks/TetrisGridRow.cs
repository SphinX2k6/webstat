using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F04 RID: 20228
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisGridRow
	{
		// Token: 0x06034491 RID: 214161 RVA: 0x00D14601 File Offset: 0x00D12801
		public TetrisGridRow(SlidingBlocksGameData gameData, double rowIndex, double rowSize)
		{
		}

		// Token: 0x06034492 RID: 214162 RVA: 0x00D14634 File Offset: 0x00D12834
		public void Clear()
		{
			this.MinoDataMap.Clear();
		}

		// Token: 0x06034493 RID: 214163 RVA: 0x00D14641 File Offset: 0x00D12841
		public bool AddData(double x, Mino minoData)
		{
			this.MinoDataMap[x] = minoData;
			return true;
		}

		// Token: 0x06034494 RID: 214164 RVA: 0x00D14651 File Offset: 0x00D12851
		public bool RemoveData(double x)
		{
			return this.MinoDataMap.Remove(x);
		}

		// Token: 0x06034495 RID: 214165 RVA: 0x00D1465F File Offset: 0x00D1285F
		public bool CheckCanLineClear()
		{
			return (double)this.MinoDataMap.Count >= this.RowSize;
		}

		// Token: 0x06034496 RID: 214166 RVA: 0x00D14678 File Offset: 0x00D12878
		public UniTask TryExecuteLineClear(SlidingBlocksGameData gameData)
		{
			TetrisGridRow.<TryExecuteLineClear>d__10 <TryExecuteLineClear>d__;
			<TryExecuteLineClear>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryExecuteLineClear>d__.<>4__this = this;
			<TryExecuteLineClear>d__.gameData = gameData;
			<TryExecuteLineClear>d__.<>1__state = -1;
			<TryExecuteLineClear>d__.<>t__builder.Start<TetrisGridRow.<TryExecuteLineClear>d__10>(ref <TryExecuteLineClear>d__);
			return <TryExecuteLineClear>d__.<>t__builder.Task;
		}

		// Token: 0x06034497 RID: 214167 RVA: 0x00D146C3 File Offset: 0x00D128C3
		public bool CheckEmpty()
		{
			return this.MinoDataMap.Count == 0;
		}

		// Token: 0x06034498 RID: 214168 RVA: 0x00D146D4 File Offset: 0x00D128D4
		[NullableContext(0)]
		private UniTask<int> SpawnLineClearEffect()
		{
			TetrisGridRow.<SpawnLineClearEffect>d__12 <SpawnLineClearEffect>d__;
			<SpawnLineClearEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
			<SpawnLineClearEffect>d__.<>4__this = this;
			<SpawnLineClearEffect>d__.<>1__state = -1;
			<SpawnLineClearEffect>d__.<>t__builder.Start<TetrisGridRow.<SpawnLineClearEffect>d__12>(ref <SpawnLineClearEffect>d__);
			return <SpawnLineClearEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06034499 RID: 214169 RVA: 0x00D14718 File Offset: 0x00D12918
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<ItemMaterialControllerActorData> LoadCubeDestroyEffectAsync([Nullable(2)] string path, Action<ItemMaterialControllerActorData> callback)
		{
			TetrisGridRow.<LoadCubeDestroyEffectAsync>d__13 <LoadCubeDestroyEffectAsync>d__;
			<LoadCubeDestroyEffectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ItemMaterialControllerActorData>.Create();
			<LoadCubeDestroyEffectAsync>d__.path = path;
			<LoadCubeDestroyEffectAsync>d__.callback = callback;
			<LoadCubeDestroyEffectAsync>d__.<>1__state = -1;
			<LoadCubeDestroyEffectAsync>d__.<>t__builder.Start<TetrisGridRow.<LoadCubeDestroyEffectAsync>d__13>(ref <LoadCubeDestroyEffectAsync>d__);
			return <LoadCubeDestroyEffectAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603449A RID: 214170 RVA: 0x00D14764 File Offset: 0x00D12964
		public void DrawDebug(FLinearColor color)
		{
			foreach (KeyValuePair<double, Mino> keyValuePair in this.MinoDataMap)
			{
				Mino value = keyValuePair.Value;
				UObject world = GlobalData.World;
				FVectorDouble textLocation = value.CubeActor.D_K2_GetActorLocation();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("\n\ny:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(value.Coord.Y, "F2");
				UKismetSystemLibrary.D_DrawDebugString(world, textLocation, defaultInterpolatedStringHandler.ToStringAndClear(), null, new FLinearColor?(color), 0f);
			}
		}

		// Token: 0x0401E2A6 RID: 123558
		private readonly Dictionary<double, Mino> MinoDataMap = new Dictionary<double, Mino>();

		// Token: 0x0401E2A7 RID: 123559
		private readonly Dictionary<double, int> MinoMaterialDataMap = new Dictionary<double, int>();

		// Token: 0x0401E2A8 RID: 123560
		public readonly SlidingBlocksGameData GameData = gameData;

		// Token: 0x0401E2A9 RID: 123561
		public readonly double RowIndex = rowIndex;

		// Token: 0x0401E2AA RID: 123562
		public readonly double RowSize = rowSize;
	}
}
