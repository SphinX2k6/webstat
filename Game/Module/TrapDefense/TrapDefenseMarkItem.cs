using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB7 RID: 19895
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class TrapDefenseMarkItem
	{
		// Token: 0x17008821 RID: 34849
		// (get) Token: 0x0603387C RID: 211068
		public abstract TrapDefenseDefine.ETrapDefenseMarkType MarkType { get; }

		// Token: 0x17008822 RID: 34850
		// (get) Token: 0x0603387D RID: 211069 RVA: 0x00CE3642 File Offset: 0x00CE1842
		// (set) Token: 0x0603387E RID: 211070 RVA: 0x00CE364A File Offset: 0x00CE184A
		public int MarkId
		{
			get
			{
				return this.InnerMarkId;
			}
			set
			{
				this.InnerMarkId = value;
			}
		}

		// Token: 0x17008823 RID: 34851
		// (get) Token: 0x0603387F RID: 211071 RVA: 0x00CE3653 File Offset: 0x00CE1853
		// (set) Token: 0x06033880 RID: 211072 RVA: 0x00CE365B File Offset: 0x00CE185B
		[Nullable(2)]
		public AActor TrackTarget
		{
			[NullableContext(2)]
			get
			{
				return this.TrackTargetInner;
			}
			[NullableContext(2)]
			set
			{
				this.TrackTargetInner = value;
			}
		}

		// Token: 0x17008824 RID: 34852
		// (get) Token: 0x06033881 RID: 211073 RVA: 0x00CE3664 File Offset: 0x00CE1864
		public virtual Vector WorldPosition
		{
			get
			{
				if (!this.EnableCachePosition)
				{
					if (this.TrackTarget != null)
					{
						Vector worldPositionVector = this.WorldPositionVector;
						FVectorDouble fvectorDouble = this.TrackTarget.D_K2_GetActorLocation();
						worldPositionVector.FromUeVector(fvectorDouble);
					}
					this.UiPositionVector = this.WorldPosition2UiPosition(this.WorldPositionVector, this.UiPositionVector);
				}
				return this.WorldPositionVector;
			}
		}

		// Token: 0x17008825 RID: 34853
		// (get) Token: 0x06033882 RID: 211074 RVA: 0x00CE36B8 File Offset: 0x00CE18B8
		public Vector UiPosition
		{
			get
			{
				this.UiPositionVector = this.WorldPosition2UiPosition(this.WorldPosition, this.UiPositionVector);
				return this.UiPositionVector;
			}
		}

		// Token: 0x06033883 RID: 211075 RVA: 0x00CE36D8 File Offset: 0x00CE18D8
		private Vector WorldPosition2UiPosition(Vector position, [Nullable(2)] Vector receiveVector = null)
		{
			Vector vector = receiveVector ?? Vector.Create();
			position.Multiply(TrapDefenseDefine.worldToTrapDefenseUiUnit, vector);
			return vector;
		}

		// Token: 0x06033884 RID: 211076 RVA: 0x00CE36FE File Offset: 0x00CE18FE
		[NullableContext(2)]
		public TrapDefenseMarkItem(int markId, object extraParam = null)
		{
			this.InnerMarkId = markId;
			this.EnableCachePosition = true;
		}

		// Token: 0x06033885 RID: 211077 RVA: 0x00CE372A File Offset: 0x00CE192A
		public void Initialize(AActor trackEntity)
		{
			this.TrackTargetInner = trackEntity;
			this.OnInitialize();
		}

		// Token: 0x06033886 RID: 211078
		protected abstract void OnInitialize();

		// Token: 0x0401DD60 RID: 122208
		private int InnerMarkId;

		// Token: 0x0401DD61 RID: 122209
		protected Vector WorldPositionVector = Vector.Create();

		// Token: 0x0401DD62 RID: 122210
		private Vector UiPositionVector = Vector.Create();

		// Token: 0x0401DD63 RID: 122211
		[Nullable(2)]
		private AActor TrackTargetInner;

		// Token: 0x0401DD64 RID: 122212
		protected bool EnableCachePosition;
	}
}
