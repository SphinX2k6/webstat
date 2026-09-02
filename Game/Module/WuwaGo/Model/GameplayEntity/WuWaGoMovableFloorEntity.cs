using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE7 RID: 19175
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoMovableFloorEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x06031FE6 RID: 204774 RVA: 0x00C83507 File Offset: 0x00C81707
		public WuWaGoMovableFloorEntity(int pbDataId, Vector coordinate, Rotator rotator, IWuWaGoMovableFloor config) : base(EWuWaGoEntityType.MovableFloor, pbDataId, coordinate, rotator)
		{
		}

		// Token: 0x17008558 RID: 34136
		// (get) Token: 0x06031FE7 RID: 204775 RVA: 0x00C8352B File Offset: 0x00C8172B
		// (set) Token: 0x06031FE8 RID: 204776 RVA: 0x00C83533 File Offset: 0x00C81733
		public int StateIndex { get; private set; }

		// Token: 0x17008559 RID: 34137
		// (get) Token: 0x06031FE9 RID: 204777 RVA: 0x00C8353C File Offset: 0x00C8173C
		// (set) Token: 0x06031FEA RID: 204778 RVA: 0x00C83544 File Offset: 0x00C81744
		public bool NeedMove { get; private set; }

		// Token: 0x1700855A RID: 34138
		// (get) Token: 0x06031FEB RID: 204779 RVA: 0x00C8354D File Offset: 0x00C8174D
		// (set) Token: 0x06031FEC RID: 204780 RVA: 0x00C83555 File Offset: 0x00C81755
		public int TargetIndex { get; private set; }

		// Token: 0x06031FED RID: 204781 RVA: 0x00C8355E File Offset: 0x00C8175E
		public void InitializeMoveCoordinates(Transform originTransform)
		{
			this.InitMoveCoordinates(originTransform);
		}

		// Token: 0x06031FEE RID: 204782 RVA: 0x00C83567 File Offset: 0x00C81767
		public override void Unlock()
		{
			base.Unlock();
			this.InitialStateIndex = this.ResolveStateIndex(base.State);
			this.StateIndex = this.InitialStateIndex;
			this.TargetIndex = this.StateIndex;
			this.NeedMove = false;
		}

		// Token: 0x06031FEF RID: 204783 RVA: 0x00C835A0 File Offset: 0x00C817A0
		public override void Destroy()
		{
			this.ResetToInitialState();
			base.Destroy();
		}

		// Token: 0x06031FF0 RID: 204784 RVA: 0x00C835AE File Offset: 0x00C817AE
		public override IRollbackCapture CaptureRollback()
		{
			return new MovableFloorRollbackCapture(this);
		}

		// Token: 0x06031FF1 RID: 204785 RVA: 0x00C835B6 File Offset: 0x00C817B6
		public void RestoreMoveStateForRollback(int stateIndex)
		{
			this.StateIndex = stateIndex;
			this.TargetIndex = stateIndex;
			this.NeedMove = false;
		}

		// Token: 0x06031FF2 RID: 204786 RVA: 0x00C835D0 File Offset: 0x00C817D0
		public void RequestMove(EGameplayEntityState targetState)
		{
			int num = this.MoveData.ToList<IWuWaGoMovableGridStatePos>().FindIndex(delegate(IWuWaGoMovableGridStatePos d)
			{
				EGameplayEntityState egameplayEntityState;
				return EGameplayEntityStateExtensions.TryFromString(d.EntityState, out egameplayEntityState) && egameplayEntityState == targetState;
			});
			if (num < 0 || num == this.StateIndex)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.TargetIndex = num;
			this.NeedMove = true;
		}

		// Token: 0x06031FF3 RID: 204787 RVA: 0x00C83629 File Offset: 0x00C81829
		public void FinishMove()
		{
			if (this.StateIndex == this.TargetIndex && !this.NeedMove)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.StateIndex = this.TargetIndex;
			this.NeedMove = false;
		}

		// Token: 0x06031FF4 RID: 204788 RVA: 0x00C8365C File Offset: 0x00C8185C
		public void CancelPendingMove()
		{
			if (this.TargetIndex == this.StateIndex && !this.NeedMove)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.TargetIndex = this.StateIndex;
			this.NeedMove = false;
			base.SetStateSilently(this.GetStateByIndex(this.StateIndex));
		}

		// Token: 0x06031FF5 RID: 204789 RVA: 0x00C836AB File Offset: 0x00C818AB
		[NullableContext(2)]
		public IWuWaGoMovableGridStatePos GetTargetPositionConfig()
		{
			if (this.TargetIndex < 0 || this.TargetIndex >= this.MoveData.Count)
			{
				return null;
			}
			return this.MoveData[this.TargetIndex];
		}

		// Token: 0x06031FF6 RID: 204790 RVA: 0x00C836DC File Offset: 0x00C818DC
		[NullableContext(2)]
		public Vector GetTargetCoordinate()
		{
			if (this.TargetIndex < 0 || this.TargetIndex >= this.MoveCoordinates.Count)
			{
				return null;
			}
			return this.MoveCoordinates[this.TargetIndex];
		}

		// Token: 0x06031FF7 RID: 204791 RVA: 0x00C8370D File Offset: 0x00C8190D
		[NullableContext(2)]
		public IWuWaGoMovableGridStatePos GetCurrentPositionConfig()
		{
			if (this.StateIndex < 0 || this.StateIndex >= this.MoveData.Count)
			{
				return null;
			}
			return this.MoveData[this.StateIndex];
		}

		// Token: 0x06031FF8 RID: 204792 RVA: 0x00C8373E File Offset: 0x00C8193E
		[NullableContext(2)]
		public Vector GetCurrentCoordinate()
		{
			if (this.StateIndex < 0 || this.StateIndex >= this.MoveCoordinates.Count)
			{
				return null;
			}
			return this.MoveCoordinates[this.StateIndex];
		}

		// Token: 0x06031FF9 RID: 204793 RVA: 0x00C8376F File Offset: 0x00C8196F
		[NullableContext(2)]
		public Vector GetInitialCoordinate()
		{
			if (this.InitialStateIndex < 0 || this.InitialStateIndex >= this.MoveCoordinates.Count)
			{
				return null;
			}
			return this.MoveCoordinates[this.InitialStateIndex];
		}

		// Token: 0x06031FFA RID: 204794 RVA: 0x00C837A0 File Offset: 0x00C819A0
		public void ResetToInitialState()
		{
			this.StateIndex = this.InitialStateIndex;
			this.TargetIndex = this.InitialStateIndex;
			this.NeedMove = false;
			Vector initialCoordinate = this.GetInitialCoordinate();
			if (initialCoordinate != null)
			{
				base.SetCoordinate(initialCoordinate);
			}
		}

		// Token: 0x06031FFB RID: 204795 RVA: 0x00C837DD File Offset: 0x00C819DD
		protected override void OnStateChanged(EGameplayEntityState newState)
		{
			if (newState == EGameplayEntityState.Locked || newState == EGameplayEntityState.Completed)
			{
				return;
			}
			this.RequestMove(newState);
		}

		// Token: 0x06031FFC RID: 204796 RVA: 0x00C837F0 File Offset: 0x00C819F0
		private EGameplayEntityState GetStateByIndex(int index)
		{
			if (index < 0 || index >= this.MoveData.Count)
			{
				return base.State;
			}
			EGameplayEntityState result;
			if (!EGameplayEntityStateExtensions.TryFromString(this.MoveData[index].EntityState, out result))
			{
				return base.State;
			}
			return result;
		}

		// Token: 0x06031FFD RID: 204797 RVA: 0x00C83838 File Offset: 0x00C81A38
		private int ResolveStateIndex(EGameplayEntityState state)
		{
			if (state == EGameplayEntityState.Locked || state == EGameplayEntityState.Completed)
			{
				return 0;
			}
			int num = this.MoveData.ToList<IWuWaGoMovableGridStatePos>().FindIndex(delegate(IWuWaGoMovableGridStatePos d)
			{
				EGameplayEntityState egameplayEntityState;
				return EGameplayEntityStateExtensions.TryFromString(d.EntityState, out egameplayEntityState) && egameplayEntityState == state;
			});
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x06031FFE RID: 204798 RVA: 0x00C8388C File Offset: 0x00C81A8C
		private unsafe void InitMoveCoordinates(Transform originTransform)
		{
			this.MoveCoordinates.Clear();
			for (int i = 0; i < this.MoveData.Count; i++)
			{
				IWuWaGoMovableGridStatePos wuWaGoMovableGridStatePos = this.MoveData[i];
				Vector vector = Vector.Create((double)wuWaGoMovableGridStatePos.GridPos.X.GetValueOrDefault(), (double)wuWaGoMovableGridStatePos.GridPos.Y.GetValueOrDefault(), (double)wuWaGoMovableGridStatePos.GridPos.Z.GetValueOrDefault());
				Vector vector2 = Vector.Create();
				if (WuWaGoUtil.ConvertWorldPositionToGridCoordinate(originTransform, vector, vector2) == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.WuWaGo;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "移动板状态坐标不合法，无法推断Shape";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", this.EntityPbDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("stateIndex", i);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("worldPosition", vector.ToString());
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				this.MoveCoordinates.Add(vector2);
			}
		}

		// Token: 0x0401D3F3 RID: 119795
		public readonly IReadOnlyList<IWuWaGoMovableGridStatePos> MoveData = config.MoveData;

		// Token: 0x0401D3F4 RID: 119796
		private readonly List<Vector> MoveCoordinates = new List<Vector>();

		// Token: 0x0401D3F5 RID: 119797
		private int InitialStateIndex;
	}
}
