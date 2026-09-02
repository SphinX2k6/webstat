using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.View.BaseMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B4F RID: 19279
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapScaleComponent : MapComponent
	{
		// Token: 0x0603259B RID: 206235 RVA: 0x00C9993E File Offset: 0x00C97B3E
		public WorldMapScaleComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17008678 RID: 34424
		// (get) Token: 0x0603259C RID: 206236 RVA: 0x00C99947 File Offset: 0x00C97B47
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapScale;
			}
		}

		// Token: 0x17008679 RID: 34425
		// (get) Token: 0x0603259D RID: 206237 RVA: 0x00C9994A File Offset: 0x00C97B4A
		// (set) Token: 0x0603259E RID: 206238 RVA: 0x00C99952 File Offset: 0x00C97B52
		public float MapScale
		{
			get
			{
				return this._mapScaleInner;
			}
			set
			{
				if (this._mapScaleInner.Equals(value))
				{
					return;
				}
				this._mapScaleInner = value;
				this._mapScaleDirty = true;
			}
		}

		// Token: 0x1700867A RID: 34426
		// (get) Token: 0x0603259F RID: 206239 RVA: 0x00C99971 File Offset: 0x00C97B71
		public bool IsScaleDirty
		{
			get
			{
				return this._mapScaleDirty;
			}
		}

		// Token: 0x060325A0 RID: 206240 RVA: 0x00C99979 File Offset: 0x00C97B79
		public void FlushScaleDirty()
		{
			this._mapScaleDirty = false;
		}

		// Token: 0x1700867B RID: 34427
		// (get) Token: 0x060325A1 RID: 206241 RVA: 0x00C99984 File Offset: 0x00C97B84
		private WorldMapUiEntity WorldMapUiComponent
		{
			get
			{
				WorldMapUiEntity worldMapUiEntity = base.Parent.AsT3 as WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					base.LogError(ELogAuthor.LRX, "[地图系统]->二级界面组件没有附加到容器下！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return worldMapUiEntity;
			}
		}

		// Token: 0x1700867C RID: 34428
		// (get) Token: 0x060325A2 RID: 206242 RVA: 0x00C999C1 File Offset: 0x00C97BC1
		// (set) Token: 0x060325A3 RID: 206243 RVA: 0x00C999C9 File Offset: 0x00C97BC9
		public WorldMapScaleComponent.TScaleChangeEvent ScaleChangeEvent { get; set; }

		// Token: 0x1700867D RID: 34429
		// (get) Token: 0x060325A4 RID: 206244 RVA: 0x00C999D2 File Offset: 0x00C97BD2
		// (set) Token: 0x060325A5 RID: 206245 RVA: 0x00C999DA File Offset: 0x00C97BDA
		public UUISliderComponent ScaleSlider { get; set; }

		// Token: 0x060325A6 RID: 206246 RVA: 0x00C999E4 File Offset: 0x00C97BE4
		public void Initialize()
		{
			this.ScaleSlider.OnValueChangeCb.Unbind();
			this.ScaleSlider.OnValueChangeCb.Bind(new Action<float>(this.OnScaleSliderValueChanged));
			this.SetMapScale(ModelBase<WorldMapModel>.Instance.MapScale, EMapScaleSetType.Initialize, true, true);
			this.ScaleSlider.SetMinValue(ModelBase<WorldMapModel>.Instance.MapScaleMin, false, false);
			this.ScaleSlider.SetMaxValue(ModelBase<WorldMapModel>.Instance.MapScaleMax, false, false);
			this.ScaleSlider.SetValue(this.MapScale, false);
		}

		// Token: 0x060325A7 RID: 206247 RVA: 0x00C99A70 File Offset: 0x00C97C70
		private void OnScaleSliderValueChanged(float value)
		{
			this.SetMapScale(value, EMapScaleSetType.Slider, true, false);
		}

		// Token: 0x060325A8 RID: 206248 RVA: 0x00C99A7C File Offset: 0x00C97C7C
		public void AddMapScale(float delta, EMapScaleSetType type)
		{
			this.SetMapScale(this.MapScale + delta, type, true, true);
		}

		// Token: 0x060325A9 RID: 206249 RVA: 0x00C99A90 File Offset: 0x00C97C90
		public void SetMapScale(float value, EMapScaleSetType type, bool sendEvent = true, bool reAssign = true)
		{
			float mapScale = this.MapScale;
			float num = MathCommon.Clamp(value, ModelBase<WorldMapModel>.Instance.MapScaleMin, ModelBase<WorldMapModel>.Instance.MapScaleMax);
			this.MapScale = num;
			ModelBase<WorldMapModel>.Instance.MapScale = num;
			BaseMap map = this.WorldMapUiComponent.Map;
			map.SetMapScale(num);
			map.SelfPlayerNode.D_SetRelativeScale3D(new FVectorDouble((double)(1f / num), (double)(1f / num), (double)(1f / num)));
			if (reAssign)
			{
				this.ScaleSlider.SetValue(num, false);
			}
			if (sendEvent)
			{
				WorldMapScaleComponent.TScaleChangeEvent scaleChangeEvent = this.ScaleChangeEvent;
				if (scaleChangeEvent == null)
				{
					return;
				}
				scaleChangeEvent(mapScale, num, type);
			}
		}

		// Token: 0x0401D68C RID: 120460
		private float _mapScaleInner;

		// Token: 0x0401D68D RID: 120461
		private bool _mapScaleDirty;

		// Token: 0x0200AC19 RID: 44057
		// (Invoke) Token: 0x0604BC6D RID: 310381
		[NullableContext(0)]
		public delegate void TScaleChangeEvent(float oldScale, float newScale, EMapScaleSetType type);
	}
}
