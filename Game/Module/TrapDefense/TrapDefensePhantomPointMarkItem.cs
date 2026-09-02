using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB9 RID: 19897
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefensePhantomPointMarkItem : TrapDefenseMarkItem
	{
		// Token: 0x17008829 RID: 34857
		// (get) Token: 0x0603388E RID: 211086 RVA: 0x00CE37AE File Offset: 0x00CE19AE
		public global::Vector PhantomPoint
		{
			get
			{
				if (this.Points.Count <= 0)
				{
					return global::Vector.ZeroVectorProxy;
				}
				return this.Points[0];
			}
		}

		// Token: 0x1700882A RID: 34858
		// (get) Token: 0x0603388F RID: 211087 RVA: 0x00CE37D0 File Offset: 0x00CE19D0
		public List<global::Vector> PhantomRoutePoints
		{
			get
			{
				return this.Points;
			}
		}

		// Token: 0x1700882B RID: 34859
		// (get) Token: 0x06033890 RID: 211088 RVA: 0x00CE37D8 File Offset: 0x00CE19D8
		public int SplineId
		{
			get
			{
				return this.SplineIdInner;
			}
		}

		// Token: 0x06033891 RID: 211089 RVA: 0x00CE37E0 File Offset: 0x00CE19E0
		[NullableContext(2)]
		public TrapDefensePhantomPointMarkItem(int markId, object extraParam = null) : base(markId, extraParam)
		{
			object[] array = extraParam as object[];
			if (array != null && array.Length == 2)
			{
				object obj = array[0];
				if (obj is int)
				{
					int splineIdInner = (int)obj;
					this.SplineIdInner = splineIdInner;
				}
				List<global::Vector> list = array[1] as List<global::Vector>;
				if (list != null)
				{
					this.Points = list;
				}
			}
		}

		// Token: 0x1700882C RID: 34860
		// (get) Token: 0x06033892 RID: 211090 RVA: 0x00CE383D File Offset: 0x00CE1A3D
		public override TrapDefenseDefine.ETrapDefenseMarkType MarkType
		{
			get
			{
				return TrapDefenseDefine.ETrapDefenseMarkType.PhantomPoint;
			}
		}

		// Token: 0x06033893 RID: 211091 RVA: 0x00CE3840 File Offset: 0x00CE1A40
		protected override void OnInitialize()
		{
			this.EnableCachePosition = true;
		}

		// Token: 0x1700882D RID: 34861
		// (get) Token: 0x06033894 RID: 211092 RVA: 0x00CE3849 File Offset: 0x00CE1A49
		public override global::Vector WorldPosition
		{
			get
			{
				return this.PhantomPoint;
			}
		}

		// Token: 0x06033895 RID: 211093 RVA: 0x00CE3854 File Offset: 0x00CE1A54
		public bool IsActivated()
		{
			TrapDefenseWave? currentBatchData = ModelBase<TrapDefenseModel>.Instance.GetCurrentBatchData();
			return currentBatchData != null && currentBatchData.Value.SplineList().Contains(this.SplineId);
		}

		// Token: 0x0401DD66 RID: 122214
		private List<global::Vector> Points = new List<global::Vector>();

		// Token: 0x0401DD67 RID: 122215
		private int SplineIdInner;
	}
}
