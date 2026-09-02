using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.ChessGameplay.StackableChess
{
	// Token: 0x020069B6 RID: 27062
	[NullableContext(1)]
	[Nullable(0)]
	public class StackableChessboardPoint : ChessboardPoint
	{
		// Token: 0x060431A1 RID: 274849 RVA: 0x0113BD6C File Offset: 0x01139F6C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public override ValueTuple<Vector, Rotator> GetMoveLocationAndRotator(bool rotationIsForward = true)
		{
			StackableChessItem tailItem = this.TailItem;
			Vector vector = (tailItem != null) ? tailItem.GetStackableLocation() : null;
			StackableChessItem tailItem2 = this.TailItem;
			Rotator rotator = (tailItem2 != null) ? tailItem2.GetStackableRotator(rotationIsForward) : null;
			if (vector == null || rotator == null)
			{
				return base.GetMoveLocationAndRotator(rotationIsForward);
			}
			return new ValueTuple<Vector, Rotator>(vector, rotator);
		}

		// Token: 0x060431A2 RID: 274850 RVA: 0x0113BDB8 File Offset: 0x01139FB8
		public override void ItemEnter(ChessItem chessItem)
		{
			HashSet<int> hashSet = new HashSet<int>();
			StackableChessItem stackableChessItem = chessItem as StackableChessItem;
			if (stackableChessItem == null)
			{
				return;
			}
			int num = 1;
			stackableChessItem.SetCurrentPoint(this);
			StackableChessItem tailItem = stackableChessItem;
			for (StackableChessItem nextItem = stackableChessItem.GetNextItem(); nextItem != null; nextItem = nextItem.GetNextItem())
			{
				if (hashSet.Contains(nextItem.GetId()))
				{
					Singleton<Log>.Instance.Error(ELogModule.Chess, ELogAuthor.LYY, "ItemEnter 发生循环，数据错误", default(ReadOnlySpan<ValueTuple<string, object>>));
					break;
				}
				num++;
				nextItem.SetCurrentPoint(this);
				tailItem = nextItem;
				hashSet.Add(nextItem.GetId());
			}
			if (this.TailItem != null)
			{
				this.TailItem.SetNextItem(stackableChessItem);
				this.TailItem = tailItem;
			}
			else
			{
				this.HeadItem = stackableChessItem;
				this.TailItem = tailItem;
			}
			this.Length += num;
		}

		// Token: 0x060431A3 RID: 274851 RVA: 0x0113BE80 File Offset: 0x0113A080
		public override void ItemLeave(ChessItem chessItem)
		{
			StackableChessItem stackableChessItem = chessItem as StackableChessItem;
			if (stackableChessItem == null)
			{
				return;
			}
			if (stackableChessItem == this.HeadItem)
			{
				this.HeadItem = null;
				this.TailItem = null;
				this.Length = 0;
				return;
			}
			StackableChessItem tailItem = null;
			int num = 0;
			StackableChessItem stackableChessItem2 = this.HeadItem;
			while (num < this.Length && stackableChessItem2 != stackableChessItem)
			{
				tailItem = stackableChessItem2;
				stackableChessItem2 = ((stackableChessItem2 != null) ? stackableChessItem2.GetNextItem() : null);
				num++;
			}
			if (num == this.Length)
			{
				return;
			}
			this.TailItem = tailItem;
			StackableChessItem tailItem2 = this.TailItem;
			if (tailItem2 != null)
			{
				tailItem2.SetNextItem(null);
			}
			this.Length = num;
		}

		// Token: 0x060431A4 RID: 274852 RVA: 0x0113BF10 File Offset: 0x0113A110
		public override void ChangeItemToMaxPriority(ChessItem chessItem)
		{
			if (this.Length <= 1 || this.HeadItem == null || this.TailItem == null)
			{
				return;
			}
			StackableChessItem stackableChessItem = chessItem as StackableChessItem;
			if (stackableChessItem == null)
			{
				return;
			}
			int id = stackableChessItem.GetId();
			if (id == this.TailItem.GetId())
			{
				return;
			}
			StackableChessItem nextItem = stackableChessItem.GetNextItem();
			if (nextItem == null)
			{
				return;
			}
			Vector pointLocation = base.GetPointLocation();
			Rotator pointRotator = base.GetPointRotator(stackableChessItem.RotationIsForward());
			if (id == this.HeadItem.GetId())
			{
				stackableChessItem.SetNextItem(null);
				Vector stackableLocation = this.TailItem.GetStackableLocation();
				stackableChessItem.Teleport((stackableLocation != null) ? stackableLocation : pointLocation, pointRotator);
				this.TailItem.SetNextItem(stackableChessItem);
				this.TailItem = stackableChessItem;
				nextItem.Teleport(pointLocation, pointRotator);
				this.HeadItem = nextItem;
				return;
			}
			int i = 0;
			StackableChessItem stackableChessItem2 = this.HeadItem;
			while (i < this.Length)
			{
				StackableChessItem nextItem2 = stackableChessItem2.GetNextItem();
				if (nextItem2 == null)
				{
					return;
				}
				if (nextItem2.GetId() == id)
				{
					break;
				}
				stackableChessItem2 = nextItem2;
				i++;
			}
			stackableChessItem2.SetNextItem(null);
			stackableChessItem.SetNextItem(null);
			Vector stackableLocation2 = this.TailItem.GetStackableLocation();
			stackableChessItem.Teleport((stackableLocation2 != null) ? stackableLocation2 : pointLocation, pointRotator);
			this.TailItem.SetNextItem(stackableChessItem);
			this.TailItem = stackableChessItem;
			Vector stackableLocation3 = stackableChessItem2.GetStackableLocation();
			nextItem.Teleport((stackableLocation3 != null) ? stackableLocation3 : pointLocation, pointRotator);
			stackableChessItem2.SetNextItem(nextItem);
		}

		// Token: 0x060431A5 RID: 274853 RVA: 0x0113C06C File Offset: 0x0113A26C
		public override int ComparePriority(ChessItem a, ChessItem b)
		{
			int id = a.GetId();
			int id2 = b.GetId();
			int num = 0;
			StackableChessItem stackableChessItem = this.HeadItem;
			while (stackableChessItem != null && num < this.Length)
			{
				int id3 = stackableChessItem.GetId();
				if (id3 == id)
				{
					return 1;
				}
				if (id3 == id2)
				{
					return -1;
				}
				stackableChessItem = stackableChessItem.GetNextItem();
				num++;
			}
			return 0;
		}

		// Token: 0x060431A6 RID: 274854 RVA: 0x0113C0C0 File Offset: 0x0113A2C0
		public bool HasItem()
		{
			return this.Length > 0;
		}

		// Token: 0x060431A7 RID: 274855 RVA: 0x0113C0CC File Offset: 0x0113A2CC
		[return: Nullable(2)]
		public StackableChessItem FindPreviousItem(StackableChessItem targetItem)
		{
			if (this.HeadItem == null || targetItem == this.HeadItem)
			{
				return null;
			}
			for (StackableChessItem stackableChessItem = this.HeadItem; stackableChessItem != null; stackableChessItem = stackableChessItem.GetNextItem())
			{
				if (stackableChessItem.GetNextItem() == targetItem)
				{
					return stackableChessItem;
				}
			}
			return null;
		}

		// Token: 0x060431A8 RID: 274856 RVA: 0x0113C10B File Offset: 0x0113A30B
		[NullableContext(2)]
		public StackableChessItem GetHeadItem()
		{
			return this.HeadItem;
		}

		// Token: 0x0402564F RID: 153167
		[Nullable(2)]
		private StackableChessItem HeadItem;

		// Token: 0x04025650 RID: 153168
		[Nullable(2)]
		private StackableChessItem TailItem;

		// Token: 0x04025651 RID: 153169
		private int Length;
	}
}
