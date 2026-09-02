using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005840 RID: 22592
	[NullableContext(1)]
	[Nullable(0)]
	public class EnrichmentAreaItem : ServerMarkItem
	{
		// Token: 0x17009289 RID: 37513
		// (get) Token: 0x060396F3 RID: 235251 RVA: 0x00E94AFE File Offset: 0x00E92CFE
		// (set) Token: 0x060396F4 RID: 235252 RVA: 0x00E94B0B File Offset: 0x00E92D0B
		public MapMark MarkConfig
		{
			get
			{
				return this.MarkConfigInternal.Value;
			}
			set
			{
				this.MarkConfigInternal = new MapMark?(value);
			}
		}

		// Token: 0x1700928A RID: 37514
		// (get) Token: 0x060396F5 RID: 235253 RVA: 0x00E94B1C File Offset: 0x00E92D1C
		public EnrichmentAreaConfig EnrichmentAreaConf
		{
			get
			{
				EnrichmentAreaConfig? enrichmentAreaConfInner = this.EnrichmentAreaConfInner;
				if (enrichmentAreaConfInner == null)
				{
					this.EnrichmentAreaConfInner = ConfigBase<MapConfig>.Instance.GetEnrichmentAreaConfigByEnrichmentId(base.EntityConfigId);
				}
				return this.EnrichmentAreaConfInner.Value;
			}
		}

		// Token: 0x1700928B RID: 37515
		// (get) Token: 0x060396F6 RID: 235254 RVA: 0x00E94B5A File Offset: 0x00E92D5A
		public override EMarkType MarkType
		{
			get
			{
				return EMarkType.EnrichmentArea;
			}
		}

		// Token: 0x1700928C RID: 37516
		// (get) Token: 0x060396F7 RID: 235255 RVA: 0x00E94B60 File Offset: 0x00E92D60
		public override int MapId
		{
			get
			{
				return this.EnrichmentAreaConf.LevelId;
			}
		}

		// Token: 0x1700928D RID: 37517
		// (get) Token: 0x060396F8 RID: 235256 RVA: 0x00E94B7B File Offset: 0x00E92D7B
		public override int? InstanceDungeonId
		{
			get
			{
				return this.ServerMarkInfo.InstanceDungeonId;
			}
		}

		// Token: 0x060396F9 RID: 235257 RVA: 0x00E94B88 File Offset: 0x00E92D88
		public EnrichmentAreaItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x060396FA RID: 235258 RVA: 0x00E94B95 File Offset: 0x00E92D95
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.EnrichmentAreaItemView;
		}

		// Token: 0x060396FB RID: 235259 RVA: 0x00E94B98 File Offset: 0x00E92D98
		[PreserveBaseOverrides]
		protected new virtual EnrichmentAreaItemView CreateView()
		{
			return new EnrichmentAreaItemView(this);
		}

		// Token: 0x060396FC RID: 235260 RVA: 0x00E94BA0 File Offset: 0x00E92DA0
		protected unsafe override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			base.SetTrackData(serverMarkInfo.TrackTarget);
			int cacheEnrichmentAreaEntityId = ModelBase<MapModel>.Instance.CacheEnrichmentAreaEntityId;
			int? entityConfigId = serverMarkInfo.EntityConfigId;
			if (!(cacheEnrichmentAreaEntityId == entityConfigId.GetValueOrDefault() & entityConfigId != null))
			{
				int[] array = this.EnrichmentAreaConf.EntityIds();
				if (array != null)
				{
					List<Vector2D> list = new List<Vector2D>();
					foreach (int num in array)
					{
						global::Vector entityPositionByConfig = MapUtil.GetEntityPositionByConfig(num, this.MapId, null);
						if (entityPositionByConfig.Equality(global::Vector.ZeroVectorProxy))
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.Map;
							ELogAuthor author = ELogAuthor.LRX;
							string message = "[地图系统]_富集区标记->采集物实体坐标异常，请检查配置";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("富集区Id", serverMarkInfo.EntityConfigId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("采集物Id", num);
							instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						}
						else
						{
							global::Vector vector = MapUtil.WorldPosition2UiPosition(entityPositionByConfig, null);
							list.Add(Vector2D.Create(vector.X, vector.Y));
						}
					}
					Circle cacheEnrichmentAreaWorldMapCircle = MapUtil.FindMinCircle(list);
					ModelBase<MapModel>.Instance.CacheEnrichmentAreaWorldMapCircle = cacheEnrichmentAreaWorldMapCircle;
				}
				ModelBase<MapModel>.Instance.CacheEnrichmentAreaEntityId = serverMarkInfo.EntityConfigId.GetValueOrDefault();
			}
			Circle cacheEnrichmentAreaWorldMapCircle2 = ModelBase<MapModel>.Instance.CacheEnrichmentAreaWorldMapCircle;
			if (cacheEnrichmentAreaWorldMapCircle2 != null)
			{
				global::Vector value = MapUtil.UiPosition2WorldPosition(global::Vector.Create((double)cacheEnrichmentAreaWorldMapCircle2.X, (double)cacheEnrichmentAreaWorldMapCircle2.Y, 0.0), null);
				float value2 = ConfigCommonParamById.GetFloatConfig("RichZoneExtraRadius").Value;
				base.MarkItemEntity.GetComponent<MarkResourceComponent>(EMapComponent.MarkResource).RangeSize = cacheEnrichmentAreaWorldMapCircle2.R + value2;
				base.SetTrackData(value);
			}
			int configId = 5;
			this.SetConfigId(configId);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060396FD RID: 235261 RVA: 0x00E94D84 File Offset: 0x00E92F84
		public void SetConfigId(int configId)
		{
			this.OnSetConfigId(configId);
		}

		// Token: 0x060396FE RID: 235262 RVA: 0x00E94D90 File Offset: 0x00E92F90
		public void OnSetConfigId(int configId)
		{
			MapMark value = ConfigBase<MapConfig>.Instance.GetConfigMark(configId).Value;
			this.MarkConfigInternal = new MapMark?(value);
			this.OnAfterSetConfigId(new MarkItemData
			{
				ShowRange = value.ShowRange(),
				MarkPic = value.UnlockMarkPic,
				ShowPriority = new int?(value.ShowPriority),
				Scale = new float?(value.Scale),
				CornerScale = new float?(value.CornerScale)
			});
		}

		// Token: 0x060396FF RID: 235263 RVA: 0x00E94E18 File Offset: 0x00E93018
		public string GetEnrichmentItemNameId()
		{
			return ConfigBase<ItemConfig>.Instance.GetConfig(this.EnrichmentAreaConf.ItemId).Value.Name;
		}

		// Token: 0x06039700 RID: 235264 RVA: 0x00E94E50 File Offset: 0x00E93050
		public bool CheckCanShowIcon()
		{
			EMapType mapType = base.MapType;
			if ((this.MarkConfig.MapShow == 1 && mapType != EMapType.MiniMap) || (this.MarkConfig.MapShow == 2 && mapType == EMapType.MiniMap))
			{
				return this.IsTracking();
			}
			return base.CheckCanShowView();
		}

		// Token: 0x06039701 RID: 235265 RVA: 0x00E94E9C File Offset: 0x00E9309C
		public override void SetTitleText(UUIText uiText)
		{
			string markTitle = this.MarkConfig.MarkTitle;
			string localText = ConfigBase<MapConfig>.Instance.GetLocalText(this.GetEnrichmentItemNameId());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(uiText, markTitle, new <>z__ReadOnlySingleElementList<object>(localText));
		}

		// Token: 0x04020A49 RID: 133705
		private MapMark? MarkConfigInternal;

		// Token: 0x04020A4A RID: 133706
		private EnrichmentAreaConfig? EnrichmentAreaConfInner;
	}
}
