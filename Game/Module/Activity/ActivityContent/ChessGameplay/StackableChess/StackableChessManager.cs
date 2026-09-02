using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component;

namespace CSharpScript.Game.Module.Activity.ActivityContent.ChessGameplay.StackableChess
{
	// Token: 0x020069B7 RID: 27063
	[NullableContext(1)]
	[Nullable(0)]
	public class StackableChessManager : IChessManager
	{
		// Token: 0x060431AA RID: 274858 RVA: 0x0113C11B File Offset: 0x0113A31B
		public ChessboardPoint CreateChessboardPoint()
		{
			return new StackableChessboardPoint();
		}

		// Token: 0x060431AB RID: 274859 RVA: 0x0113C122 File Offset: 0x0113A322
		public ChessItem CreateChessItem()
		{
			return new StackableChessItem();
		}

		// Token: 0x060431AC RID: 274860 RVA: 0x0113C12C File Offset: 0x0113A32C
		[NullableContext(2)]
		public IChessAgent GetChessAgent(EChessAgentType type, EntityHandle entityHandle = null)
		{
			if (type == EChessAgentType.EntityComponent)
			{
				WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
				if (worldEntity != null && worldEntity.Valid)
				{
					return worldEntity.GetComponent<StackableChessComponent>();
				}
			}
			return null;
		}

		// Token: 0x060431AD RID: 274861 RVA: 0x0113C15C File Offset: 0x0113A35C
		public void BatchTeleportItemsToPointSorted(List<IChessTransmitData> transmitDataList)
		{
			Dictionary<int, List<IChessTransmitData>> dictionary = new Dictionary<int, List<IChessTransmitData>>();
			foreach (IChessTransmitData chessTransmitData in transmitDataList)
			{
				if (!dictionary.ContainsKey(chessTransmitData.TargetPointId))
				{
					dictionary[chessTransmitData.TargetPointId] = new List<IChessTransmitData>();
				}
				dictionary[chessTransmitData.TargetPointId].Add(chessTransmitData);
			}
			foreach (KeyValuePair<int, List<IChessTransmitData>> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				List<IChessTransmitData> value = keyValuePair.Value;
				value.Sort((IChessTransmitData a, IChessTransmitData b) => a.High - b.High);
				StackableChessboardPoint stackableChessboardPoint = ModelBase<ChessModel>.Instance.GetChessboardPoint(key) as StackableChessboardPoint;
				if (stackableChessboardPoint != null)
				{
					List<StackableChessItem> list = new List<StackableChessItem>();
					foreach (IChessTransmitData chessTransmitData2 in value)
					{
						StackableChessItem stackableChessItem = ModelBase<ChessModel>.Instance.GetChessItem(chessTransmitData2.ItemId) as StackableChessItem;
						if (stackableChessItem != null)
						{
							ChessboardPoint currentPoint = stackableChessItem.GetCurrentPoint();
							if (currentPoint != null)
							{
								stackableChessItem.DetachSelfFromChain();
								currentPoint.ItemLeave(stackableChessItem);
							}
							list.Add(stackableChessItem);
						}
					}
					foreach (StackableChessItem chessItem in list)
					{
						stackableChessboardPoint.ItemEnter(chessItem);
					}
					StackableChessItem stackableChessItem2 = stackableChessboardPoint.GetHeadItem();
					Vector vector = stackableChessboardPoint.GetPointLocation();
					while (stackableChessItem2 != null)
					{
						Rotator pointRotator = stackableChessboardPoint.GetPointRotator(stackableChessItem2.RotationIsForward());
						stackableChessItem2.Teleport(vector, pointRotator);
						vector = (stackableChessItem2.GetStackableLocation() ?? vector);
						stackableChessItem2 = stackableChessItem2.GetNextItem();
					}
				}
			}
		}
	}
}
