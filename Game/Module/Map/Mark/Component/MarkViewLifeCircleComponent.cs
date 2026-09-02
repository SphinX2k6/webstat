using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Base;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x02005830 RID: 22576
	public class MarkViewLifeCircleComponent : MapComponent
	{
		// Token: 0x0603963A RID: 235066 RVA: 0x00E91B3D File Offset: 0x00E8FD3D
		public MarkViewLifeCircleComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17009262 RID: 37474
		// (get) Token: 0x0603963B RID: 235067 RVA: 0x00E91B51 File Offset: 0x00E8FD51
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkViewLifeCircle;
			}
		}

		// Token: 0x0603963C RID: 235068 RVA: 0x00E91B55 File Offset: 0x00E8FD55
		public void SetChildViewVisibility(EMarkViewComponentType childViewType, bool visible)
		{
			this.ChildViewVisibleStateMap.Set(childViewType, visible);
		}

		// Token: 0x0603963D RID: 235069 RVA: 0x00E91B65 File Offset: 0x00E8FD65
		public bool IsChildViewVisible(EMarkViewComponentType childViewType, bool defaultValue = false)
		{
			return this.ChildViewVisibleStateMap.TryGet(childViewType, defaultValue, false);
		}

		// Token: 0x0603963E RID: 235070 RVA: 0x00E91B75 File Offset: 0x00E8FD75
		public void SetChildViewVisibleClean(EMarkViewComponentType childViewType)
		{
			this.ChildViewVisibleStateMap.CleanDirty(childViewType);
		}

		// Token: 0x0603963F RID: 235071 RVA: 0x00E91B83 File Offset: 0x00E8FD83
		public bool IsChildViewStateDirty(EMarkViewComponentType childViewType)
		{
			return this.ChildViewVisibleStateMap.IsDirty(childViewType);
		}

		// Token: 0x06039640 RID: 235072 RVA: 0x00E91B94 File Offset: 0x00E8FD94
		public void SetAllChildViewStateDirty()
		{
			foreach (KeyValuePair<EMarkViewComponentType, bool> keyValuePair in this.ChildViewVisibleStateMap)
			{
				if (keyValuePair.Key != EMarkViewComponentType.MarkView)
				{
					this.ChildViewVisibleStateMap.SetDirty(keyValuePair.Key);
				}
			}
		}

		// Token: 0x06039641 RID: 235073 RVA: 0x00E91BF8 File Offset: 0x00E8FDF8
		protected override void OnRemove()
		{
			this.ChildViewVisibleStateMap.Clear();
		}

		// Token: 0x17009263 RID: 37475
		// (get) Token: 0x06039643 RID: 235075 RVA: 0x00E91C20 File Offset: 0x00E8FE20
		// (set) Token: 0x06039642 RID: 235074 RVA: 0x00E91C05 File Offset: 0x00E8FE05
		public bool EnableVerticalPointer
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				return !this.PropertyMap.TryGetValue(0, out oneOf) || oneOf.AsT2;
			}
			set
			{
				this.PropertyMap[0] = value;
			}
		}

		// Token: 0x17009264 RID: 37476
		// (get) Token: 0x06039645 RID: 235077 RVA: 0x00E91C64 File Offset: 0x00E8FE64
		// (set) Token: 0x06039644 RID: 235076 RVA: 0x00E91C4B File Offset: 0x00E8FE4B
		public EVerticalPointerType VerticalPointerType
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				if (this.PropertyMap.TryGetValue(1, out oneOf))
				{
					return (EVerticalPointerType)oneOf.AsT3;
				}
				return EVerticalPointerType.None;
			}
			set
			{
				this.PropertyMap[1] = (int)value;
			}
		}

		// Token: 0x17009265 RID: 37477
		// (get) Token: 0x06039646 RID: 235078 RVA: 0x00E91C8F File Offset: 0x00E8FE8F
		public bool IsVerticalPointerTypeDirty
		{
			get
			{
				return this.PropertyMap.IsDirty(1);
			}
		}

		// Token: 0x06039647 RID: 235079 RVA: 0x00E91CA2 File Offset: 0x00E8FEA2
		public void SetVerticalPointerTypeClean()
		{
			this.PropertyMap.CleanDirty(1);
		}

		// Token: 0x17009266 RID: 37478
		// (get) Token: 0x06039649 RID: 235081 RVA: 0x00E91CC8 File Offset: 0x00E8FEC8
		// (set) Token: 0x06039648 RID: 235080 RVA: 0x00E91CB5 File Offset: 0x00E8FEB5
		public bool IsInAoiRange
		{
			get
			{
				return this._isInAoiRangeInner;
			}
			set
			{
				if (this._isInAoiRangeInner == value)
				{
					return;
				}
				this._isInAoiRangeInner = value;
			}
		}

		// Token: 0x17009267 RID: 37479
		// (get) Token: 0x0603964B RID: 235083 RVA: 0x00E91CEA File Offset: 0x00E8FEEA
		// (set) Token: 0x0603964A RID: 235082 RVA: 0x00E91CD0 File Offset: 0x00E8FED0
		public bool IsSelected
		{
			get
			{
				return this._isSelectedInner;
			}
			set
			{
				if (this._isSelectedInner == value)
				{
					return;
				}
				this._isSelectedInner = value;
				this._isSelectedDirtyInner = true;
			}
		}

		// Token: 0x17009268 RID: 37480
		// (get) Token: 0x0603964C RID: 235084 RVA: 0x00E91CF2 File Offset: 0x00E8FEF2
		public bool IsSelectedDirty
		{
			get
			{
				return this._isSelectedDirtyInner;
			}
		}

		// Token: 0x17009269 RID: 37481
		// (get) Token: 0x0603964E RID: 235086 RVA: 0x00E91D14 File Offset: 0x00E8FF14
		// (set) Token: 0x0603964D RID: 235085 RVA: 0x00E91CFA File Offset: 0x00E8FEFA
		public bool IsTracked
		{
			get
			{
				return this._isTrackedInner;
			}
			set
			{
				if (this._isTrackedInner == value)
				{
					return;
				}
				this._isTrackedInner = value;
				this._isTrackedDirtyInner = true;
			}
		}

		// Token: 0x1700926A RID: 37482
		// (get) Token: 0x0603964F RID: 235087 RVA: 0x00E91D1C File Offset: 0x00E8FF1C
		public bool IsTrackedDirty
		{
			get
			{
				return this._isTrackedDirtyInner;
			}
		}

		// Token: 0x1700926B RID: 37483
		// (get) Token: 0x06039651 RID: 235089 RVA: 0x00E91D3E File Offset: 0x00E8FF3E
		// (set) Token: 0x06039650 RID: 235088 RVA: 0x00E91D24 File Offset: 0x00E8FF24
		public bool IsAutoPilotTracked
		{
			get
			{
				return this._isAutoPilotTrackedInner;
			}
			set
			{
				if (this._isAutoPilotTrackedInner == value)
				{
					return;
				}
				this._isAutoPilotTrackedInner = value;
				this._isAutoPilotTrackedDirtyInner = true;
			}
		}

		// Token: 0x1700926C RID: 37484
		// (get) Token: 0x06039652 RID: 235090 RVA: 0x00E91D46 File Offset: 0x00E8FF46
		public bool IsAutoPilotTrackedDirty
		{
			get
			{
				return this._isAutoPilotTrackedDirtyInner;
			}
		}

		// Token: 0x04020A29 RID: 133673
		private bool _isInAoiRangeInner;

		// Token: 0x04020A2A RID: 133674
		private bool _isSelectedInner;

		// Token: 0x04020A2B RID: 133675
		private bool _isSelectedDirtyInner;

		// Token: 0x04020A2C RID: 133676
		private bool _isTrackedInner;

		// Token: 0x04020A2D RID: 133677
		private bool _isTrackedDirtyInner;

		// Token: 0x04020A2E RID: 133678
		private bool _isAutoPilotTrackedInner;

		// Token: 0x04020A2F RID: 133679
		private bool _isAutoPilotTrackedDirtyInner;

		// Token: 0x04020A30 RID: 133680
		[Nullable(1)]
		protected PropertyMap<EMarkViewComponentType, bool> ChildViewVisibleStateMap = new PropertyMap<EMarkViewComponentType, bool>();

		// Token: 0x0200B8A5 RID: 47269
		private enum EPropertyType
		{
			// Token: 0x0403916A RID: 233834
			EnableVerticalPointer,
			// Token: 0x0403916B RID: 233835
			VerticalPointerType
		}
	}
}
