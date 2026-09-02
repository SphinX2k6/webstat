using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Base;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x0200582F RID: 22575
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkResourceComponent : MapComponent
	{
		// Token: 0x0603962A RID: 235050 RVA: 0x00E9197B File Offset: 0x00E8FB7B
		public MarkResourceComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x1700925A RID: 37466
		// (get) Token: 0x0603962B RID: 235051 RVA: 0x00E91984 File Offset: 0x00E8FB84
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkResource;
			}
		}

		// Token: 0x1700925B RID: 37467
		// (get) Token: 0x0603962D RID: 235053 RVA: 0x00E919A4 File Offset: 0x00E8FBA4
		// (set) Token: 0x0603962C RID: 235052 RVA: 0x00E91988 File Offset: 0x00E8FB88
		public string TopRightIconPath
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				if (this.PropertyMap.TryGetValue(0, out oneOf))
				{
					return oneOf.AsT4;
				}
				return string.Empty;
			}
			set
			{
				this.PropertyMap[0] = value;
			}
		}

		// Token: 0x1700925C RID: 37468
		// (get) Token: 0x0603962F RID: 235055 RVA: 0x00E919EC File Offset: 0x00E8FBEC
		// (set) Token: 0x0603962E RID: 235054 RVA: 0x00E919D3 File Offset: 0x00E8FBD3
		public float RangeSize
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				if (this.PropertyMap.TryGetValue(2, out oneOf))
				{
					return oneOf.AsT5;
				}
				return 0f;
			}
			set
			{
				this.PropertyMap[2] = value;
			}
		}

		// Token: 0x1700925D RID: 37469
		// (get) Token: 0x06039631 RID: 235057 RVA: 0x00E91A34 File Offset: 0x00E8FC34
		// (set) Token: 0x06039630 RID: 235056 RVA: 0x00E91A1B File Offset: 0x00E8FC1B
		public bool RangeSetAsFirstChild
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				return this.PropertyMap.TryGetValue(6, out oneOf) && oneOf.AsT2;
			}
			set
			{
				this.PropertyMap[6] = value;
			}
		}

		// Token: 0x1700925E RID: 37470
		// (get) Token: 0x06039633 RID: 235059 RVA: 0x00E91A78 File Offset: 0x00E8FC78
		// (set) Token: 0x06039632 RID: 235058 RVA: 0x00E91A5F File Offset: 0x00E8FC5F
		public Vector2D OutOfBoundDirection
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				if (this.PropertyMap.TryGetValue(3, out oneOf))
				{
					return oneOf.AsT1;
				}
				return new Vector2D();
			}
			set
			{
				this.PropertyMap[3] = value;
			}
		}

		// Token: 0x1700925F RID: 37471
		// (get) Token: 0x06039634 RID: 235060 RVA: 0x00E91AA7 File Offset: 0x00E8FCA7
		public bool IsOutOfBoundDirectionDirty
		{
			get
			{
				return this.PropertyMap.IsDirty(3);
			}
		}

		// Token: 0x06039635 RID: 235061 RVA: 0x00E91ABA File Offset: 0x00E8FCBA
		public void SetOutOfBoundDirectionClean()
		{
			this.PropertyMap.CleanDirty(3);
		}

		// Token: 0x17009260 RID: 37472
		// (get) Token: 0x06039637 RID: 235063 RVA: 0x00E91AE8 File Offset: 0x00E8FCE8
		// (set) Token: 0x06039636 RID: 235062 RVA: 0x00E91ACD File Offset: 0x00E8FCCD
		public string ChildIconPath
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				if (this.PropertyMap.TryGetValue(4, out oneOf))
				{
					return oneOf.AsT4;
				}
				return string.Empty;
			}
			set
			{
				this.PropertyMap[4] = value;
			}
		}

		// Token: 0x17009261 RID: 37473
		// (get) Token: 0x06039638 RID: 235064 RVA: 0x00E91B17 File Offset: 0x00E8FD17
		public bool IsChildIconPathDirty
		{
			get
			{
				return this.PropertyMap.IsDirty(4);
			}
		}

		// Token: 0x06039639 RID: 235065 RVA: 0x00E91B2A File Offset: 0x00E8FD2A
		public void SetChildIconPathClean()
		{
			this.PropertyMap.CleanDirty(4);
		}

		// Token: 0x0200B8A4 RID: 47268
		[NullableContext(0)]
		private enum EPropertyType
		{
			// Token: 0x04039162 RID: 233826
			TopRightIconPath,
			// Token: 0x04039163 RID: 233827
			RangeResourceId,
			// Token: 0x04039164 RID: 233828
			RangeSize,
			// Token: 0x04039165 RID: 233829
			OutOfBoundDirection,
			// Token: 0x04039166 RID: 233830
			ChildIconPath,
			// Token: 0x04039167 RID: 233831
			EnableVerticalPointer,
			// Token: 0x04039168 RID: 233832
			RangeSetAsFirstChild
		}
	}
}
