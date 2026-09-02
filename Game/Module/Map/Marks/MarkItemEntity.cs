using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.Mark.Component;

namespace CSharpScript.Game.Module.Map.Marks
{
	// Token: 0x02005832 RID: 22578
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkItemEntity : MapEntity
	{
		// Token: 0x1700926D RID: 37485
		// (get) Token: 0x06039658 RID: 235096 RVA: 0x00E92198 File Offset: 0x00E90398
		// (set) Token: 0x06039659 RID: 235097 RVA: 0x00E921A0 File Offset: 0x00E903A0
		public bool IsTempMapMark { get; set; }

		// Token: 0x1700926E RID: 37486
		// (get) Token: 0x0603965A RID: 235098 RVA: 0x00E921AC File Offset: 0x00E903AC
		public MarkGamePlayComponent GamePlay
		{
			get
			{
				MarkGamePlayComponent result;
				if ((result = this._gamePlayCache) == null)
				{
					result = (this._gamePlayCache = base.GetOrAddComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay));
				}
				return result;
			}
		}

		// Token: 0x1700926F RID: 37487
		// (get) Token: 0x0603965B RID: 235099 RVA: 0x00E921D4 File Offset: 0x00E903D4
		public MarkResourceComponent Resource
		{
			get
			{
				MarkResourceComponent result;
				if ((result = this._resourceCache) == null)
				{
					result = (this._resourceCache = base.GetOrAddComponent<MarkResourceComponent>(EMapComponent.MarkResource));
				}
				return result;
			}
		}

		// Token: 0x17009270 RID: 37488
		// (get) Token: 0x0603965C RID: 235100 RVA: 0x00E921FC File Offset: 0x00E903FC
		public MarkViewLifeCircleComponent ViewLifeCircle
		{
			get
			{
				MarkViewLifeCircleComponent result;
				if ((result = this._viewLifeCircleCache) == null)
				{
					result = (this._viewLifeCircleCache = base.GetOrAddComponent<MarkViewLifeCircleComponent>(EMapComponent.MarkViewLifeCircle));
				}
				return result;
			}
		}

		// Token: 0x17009271 RID: 37489
		// (get) Token: 0x0603965D RID: 235101 RVA: 0x00E92224 File Offset: 0x00E90424
		public MarkMultiFloorComponent MultiFloor
		{
			get
			{
				MarkMultiFloorComponent result;
				if ((result = this._multiFloorCache) == null)
				{
					result = (this._multiFloorCache = base.GetOrAddComponent<MarkMultiFloorComponent>(EMapComponent.MarkMultiFloor));
				}
				return result;
			}
		}

		// Token: 0x0603965E RID: 235102 RVA: 0x00E9224C File Offset: 0x00E9044C
		protected override void OnInit()
		{
			this._gamePlayCache = base.GetOrAddComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay);
			this._resourceCache = base.GetOrAddComponent<MarkResourceComponent>(EMapComponent.MarkResource);
			this._viewLifeCircleCache = base.GetOrAddComponent<MarkViewLifeCircleComponent>(EMapComponent.MarkViewLifeCircle);
			this._multiFloorCache = base.GetOrAddComponent<MarkMultiFloorComponent>(EMapComponent.MarkMultiFloor);
		}

		// Token: 0x0603965F RID: 235103 RVA: 0x00E92286 File Offset: 0x00E90486
		protected override void OnDispose()
		{
			this._gamePlayCache = null;
			this._resourceCache = null;
			this._viewLifeCircleCache = null;
			this._multiFloorCache = null;
		}

		// Token: 0x17009272 RID: 37490
		// (get) Token: 0x06039660 RID: 235104 RVA: 0x00E922A4 File Offset: 0x00E904A4
		public bool IsConfigMark
		{
			get
			{
				MarkConfigComponent component = base.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig);
				return component != null && component.Config.HasValue;
			}
		}

		// Token: 0x04020A33 RID: 133683
		[Nullable(2)]
		private MarkGamePlayComponent _gamePlayCache;

		// Token: 0x04020A34 RID: 133684
		[Nullable(2)]
		private MarkResourceComponent _resourceCache;

		// Token: 0x04020A35 RID: 133685
		[Nullable(2)]
		private MarkViewLifeCircleComponent _viewLifeCircleCache;

		// Token: 0x04020A36 RID: 133686
		[Nullable(2)]
		private MarkMultiFloorComponent _multiFloorCache;
	}
}
