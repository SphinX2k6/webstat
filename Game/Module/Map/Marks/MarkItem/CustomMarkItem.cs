using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200583B RID: 22587
	[NullableContext(1)]
	[Nullable(0)]
	public class CustomMarkItem : ServerMarkItem
	{
		// Token: 0x1700927E RID: 37502
		// (get) Token: 0x060396C1 RID: 235201 RVA: 0x00E94216 File Offset: 0x00E92416
		public override EMarkType MarkType
		{
			get
			{
				return EMarkType.Custom;
			}
		}

		// Token: 0x1700927F RID: 37503
		// (get) Token: 0x060396C2 RID: 235202 RVA: 0x00E9421A File Offset: 0x00E9241A
		public bool IsNewCustomMarkItem
		{
			get
			{
				return this.IsNew;
			}
		}

		// Token: 0x17009280 RID: 37504
		// (get) Token: 0x060396C3 RID: 235203 RVA: 0x00E94222 File Offset: 0x00E92422
		public override bool PermanentUpdate
		{
			get
			{
				return base.PermanentUpdate || this.IsNewCustomMarkItem;
			}
		}

		// Token: 0x060396C4 RID: 235204 RVA: 0x00E94234 File Offset: 0x00E92434
		public override bool IsMultiMap()
		{
			return false;
		}

		// Token: 0x060396C5 RID: 235205 RVA: 0x00E94237 File Offset: 0x00E92437
		public CustomMarkItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x060396C6 RID: 235206 RVA: 0x00E94244 File Offset: 0x00E92444
		protected override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			TTrackTarget_Vector ttrackTarget_Vector = serverMarkInfo.TrackTarget as TTrackTarget_Vector;
			if (ttrackTarget_Vector != null)
			{
				global::Vector vector = global::Vector.Create(ttrackTarget_Vector.Value.X, -ttrackTarget_Vector.Value.Y, ttrackTarget_Vector.Value.Z);
				global::Vector value = MapUtil.UiPosition2WorldPosition(vector, vector);
				base.SetTrackData(new TTrackTarget_Vector(value));
			}
			else
			{
				TTrackTarget_Vector2D ttrackTarget_Vector2D = serverMarkInfo.TrackTarget as TTrackTarget_Vector2D;
				if (ttrackTarget_Vector2D != null)
				{
					global::Vector vector2 = global::Vector.Create(ttrackTarget_Vector2D.Value.X, ttrackTarget_Vector2D.Value.Y, 0.0);
					global::Vector vector3 = MapUtil.UiPosition2WorldPosition(vector2, vector2);
					base.SetTrackData(new TTrackTarget_Vector2D(new Vector2D(vector3.X, vector3.Y)));
				}
				else
				{
					Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LK, "未定义的类型", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			base.MarkItemEntity.ViewLifeCircle.EnableVerticalPointer = false;
			this.SetConfigId(base.ConfigId);
			CustomMark? config = ConfigCustomMarkByMarkId.GetConfig(base.ConfigId, true);
			base.ShowPriority = ((config != null) ? config.GetValueOrDefault().ShowPriority : 0);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060396C7 RID: 235207 RVA: 0x00E94377 File Offset: 0x00E92577
		[PreserveBaseOverrides]
		protected new virtual CustomMarkItemView CreateView()
		{
			return new CustomMarkItemView(this);
		}

		// Token: 0x060396C8 RID: 235208 RVA: 0x00E9437F File Offset: 0x00E9257F
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.CustomMarkItemView;
		}

		// Token: 0x060396C9 RID: 235209 RVA: 0x00E94382 File Offset: 0x00E92582
		public void SetConfigId(int configId)
		{
			this.ServerMarkInfo.MarkConfigId = configId;
			this.OnSetConfigId(configId);
		}

		// Token: 0x060396CA RID: 235210 RVA: 0x00E94398 File Offset: 0x00E92598
		public void OnSetConfigId(int configId)
		{
			CustomMark? customMarkConfig = ConfigBase<MapConfig>.Instance.GetCustomMarkConfig(configId);
			this.OnAfterSetConfigId(new MarkItemData
			{
				ShowRange = customMarkConfig.Value.ShowRange(),
				MarkPic = customMarkConfig.Value.MarkPic,
				ShowPriority = new int?(customMarkConfig.Value.ShowPriority),
				Scale = new float?(customMarkConfig.Value.Scale)
			});
		}

		// Token: 0x060396CB RID: 235211 RVA: 0x00E9441A File Offset: 0x00E9261A
		public void SetIsNew(bool isNew)
		{
			this.IsNew = isNew;
		}

		// Token: 0x060396CC RID: 235212 RVA: 0x00E94423 File Offset: 0x00E92623
		[NullableContext(2)]
		public override string GetTitleText()
		{
			return ConfigBase<TextConfig>.Instance.GetTextById("CustomMarkName");
		}

		// Token: 0x060396CD RID: 235213 RVA: 0x00E94434 File Offset: 0x00E92634
		public override bool CheckCanShowView()
		{
			if (base.MapType == EMapType.MiniMap)
			{
				return ModelBase<WorldMapModel>.Instance.CustomMarksIsShow;
			}
			return ModelBase<WorldMapModel>.Instance.CustomMarksIsShow && base.CheckCanShowView();
		}

		// Token: 0x060396CE RID: 235214 RVA: 0x00E9445E File Offset: 0x00E9265E
		public override bool GetInteractiveFlag()
		{
			return !this.IsNewCustomMarkItem && base.GetInteractiveFlag();
		}

		// Token: 0x060396CF RID: 235215 RVA: 0x00E94470 File Offset: 0x00E92670
		public override ESecondaryPanel GetSecondaryUiType()
		{
			return ESecondaryPanel.CustomMarkPanel;
		}

		// Token: 0x04020A43 RID: 133699
		public bool IsCreated;

		// Token: 0x04020A44 RID: 133700
		private bool IsNew;
	}
}
