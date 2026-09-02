using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x0200532D RID: 21293
	public class QuestMultiLineMapMoveComponent : BuildingMapMoveComponent
	{
		// Token: 0x06036557 RID: 222551 RVA: 0x00DB1D57 File Offset: 0x00DAFF57
		[NullableContext(1)]
		public QuestMultiLineMapMoveComponent(UUIDraggableComponent draggable) : base(draggable, true, false, false)
		{
		}

		// Token: 0x06036558 RID: 222552 RVA: 0x00DB1D64 File Offset: 0x00DAFF64
		[return: TupleElementNames(new string[]
		{
			"offsetX",
			"offsetY"
		})]
		private static ValueTuple<int, int> GetSafeOffset()
		{
			int item = Math.Max(0, ConfigCommonParamById.GetIntConfig("QuestMultiLineDragOffsetX").GetValueOrDefault(100));
			int item2 = Math.Max(0, ConfigCommonParamById.GetIntConfig("QuestMultiLineDragOffsetY").GetValueOrDefault(100));
			return new ValueTuple<int, int>(item, item2);
		}

		// Token: 0x06036559 RID: 222553 RVA: 0x00DB1DAC File Offset: 0x00DAFFAC
		protected override void UpdateMoveSafeArea()
		{
			ValueTuple<int, int> safeOffset = QuestMultiLineMapMoveComponent.GetSafeOffset();
			int item = safeOffset.Item1;
			int item2 = safeOffset.Item2;
			this.MoveSafeArea.MinX = (double)(-(double)item);
			this.MoveSafeArea.MaxX = (double)item;
			this.MoveSafeArea.MinY = (double)(-(double)item2);
			this.MoveSafeArea.MaxY = (double)item2;
		}

		// Token: 0x0603655A RID: 222554 RVA: 0x00DB1E04 File Offset: 0x00DB0004
		protected override void UpdateMoveDangerousArea()
		{
			ValueTuple<int, int> safeOffset = QuestMultiLineMapMoveComponent.GetSafeOffset();
			int item = safeOffset.Item1;
			int item2 = safeOffset.Item2;
			int num = item + 100;
			int num2 = item2 + 100;
			this.MoveDangerousArea.MinX = (double)(-(double)num);
			this.MoveDangerousArea.MaxX = (double)num;
			this.MoveDangerousArea.MinY = (double)(-(double)num2);
			this.MoveDangerousArea.MaxY = (double)num2;
		}
	}
}
