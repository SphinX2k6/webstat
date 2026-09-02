using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Module.WorldMap.ViewComponent.SteamingLoad;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200584E RID: 22606
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class MarkItem : IWorldMapStreamingObject
	{
		// Token: 0x1700929A RID: 37530
		// (get) Token: 0x06039771 RID: 235377 RVA: 0x00E95D52 File Offset: 0x00E93F52
		// (set) Token: 0x06039772 RID: 235378 RVA: 0x00E95D5A File Offset: 0x00E93F5A
		public bool IsVisible { get; set; }

		// Token: 0x1700929B RID: 37531
		// (get) Token: 0x06039773 RID: 235379 RVA: 0x00E95D64 File Offset: 0x00E93F64
		// (set) Token: 0x06039774 RID: 235380 RVA: 0x00E95DEA File Offset: 0x00E93FEA
		[Nullable(2)]
		public unsafe MarkItemEntity MarkItemEntity
		{
			[NullableContext(2)]
			get
			{
				if (this.MarkItemEntityInner == null)
				{
					object key = this.MarkId;
					ELogAuthor author = ELogAuthor.LRX;
					string message = "没有初始化标记逻辑实体，请检查代码逻辑!";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MarkId", this.MarkId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MarkType", this.MarkType);
					MapLogger.ErrorOnce(key, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				return this.MarkItemEntityInner;
			}
			[NullableContext(2)]
			set
			{
				this.MarkItemEntityInner = value;
			}
		}

		// Token: 0x1700929C RID: 37532
		// (get) Token: 0x06039775 RID: 235381
		// (set) Token: 0x06039776 RID: 235382
		public abstract int MarkId { get; set; }

		// Token: 0x1700929D RID: 37533
		// (get) Token: 0x06039777 RID: 235383
		public abstract EMarkType MarkType { get; }

		// Token: 0x1700929E RID: 37534
		// (get) Token: 0x06039778 RID: 235384 RVA: 0x00E95DF3 File Offset: 0x00E93FF3
		public virtual EMarkItemType MarkItemType
		{
			get
			{
				return EMarkItemType.Common;
			}
		}

		// Token: 0x1700929F RID: 37535
		// (get) Token: 0x06039779 RID: 235385 RVA: 0x00E95DF6 File Offset: 0x00E93FF6
		// (set) Token: 0x0603977A RID: 235386 RVA: 0x00E95DFE File Offset: 0x00E93FFE
		public EMapType MapType { get; set; }

		// Token: 0x170092A0 RID: 37536
		// (get) Token: 0x0603977B RID: 235387 RVA: 0x00E95E07 File Offset: 0x00E94007
		// (set) Token: 0x0603977C RID: 235388 RVA: 0x00E95E0F File Offset: 0x00E9400F
		public int ShowPriority { get; set; }

		// Token: 0x170092A1 RID: 37537
		// (get) Token: 0x0603977D RID: 235389 RVA: 0x00E95E18 File Offset: 0x00E94018
		// (set) Token: 0x0603977E RID: 235390 RVA: 0x00E95E20 File Offset: 0x00E94020
		public bool IsDestroy { get; set; }

		// Token: 0x170092A2 RID: 37538
		// (get) Token: 0x0603977F RID: 235391 RVA: 0x00E95E29 File Offset: 0x00E94029
		// (set) Token: 0x06039780 RID: 235392 RVA: 0x00E95E31 File Offset: 0x00E94031
		public bool IsIgnoreScaleShow { get; set; }

		// Token: 0x170092A3 RID: 37539
		// (get) Token: 0x06039781 RID: 235393 RVA: 0x00E95E3A File Offset: 0x00E9403A
		// (set) Token: 0x06039782 RID: 235394 RVA: 0x00E95E42 File Offset: 0x00E94042
		public float ConfigScale { get; set; } = 1f;

		// Token: 0x170092A4 RID: 37540
		// (get) Token: 0x06039784 RID: 235396 RVA: 0x00E95E65 File Offset: 0x00E94065
		// (set) Token: 0x06039783 RID: 235395 RVA: 0x00E95E4B File Offset: 0x00E9404B
		public float CornerScale
		{
			get
			{
				return this.CornerScaleInner;
			}
			set
			{
				this.CornerScaleInner = value;
				this.CornerScaleVector = new global::Vector((double)value, (double)value, (double)value);
			}
		}

		// Token: 0x170092A5 RID: 37541
		// (get) Token: 0x06039785 RID: 235397 RVA: 0x00E95E6D File Offset: 0x00E9406D
		// (set) Token: 0x06039786 RID: 235398 RVA: 0x00E95E75 File Offset: 0x00E94075
		public global::Vector CornerScaleVector { get; private set; } = new global::Vector(1.0, 1.0, 1.0);

		// Token: 0x170092A6 RID: 37542
		// (get) Token: 0x06039787 RID: 235399 RVA: 0x00E95E7E File Offset: 0x00E9407E
		// (set) Token: 0x06039788 RID: 235400 RVA: 0x00E95E86 File Offset: 0x00E94086
		public float TrackFxScale { get; set; } = 1f;

		// Token: 0x170092A7 RID: 37543
		// (get) Token: 0x06039789 RID: 235401 RVA: 0x00E95E8F File Offset: 0x00E9408F
		private bool IsTeleporting
		{
			get
			{
				TeleportModel instance = ModelBase<TeleportModel>.Instance;
				return instance != null && instance.IsTeleport;
			}
		}

		// Token: 0x170092A8 RID: 37544
		// (get) Token: 0x0603978A RID: 235402 RVA: 0x00E95EA1 File Offset: 0x00E940A1
		// (set) Token: 0x0603978B RID: 235403 RVA: 0x00E95EA9 File Offset: 0x00E940A9
		public int GridId { get; set; }

		// Token: 0x170092A9 RID: 37545
		// (get) Token: 0x0603978C RID: 235404 RVA: 0x00E95EB2 File Offset: 0x00E940B2
		public virtual int MapId
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170092AA RID: 37546
		// (get) Token: 0x0603978D RID: 235405 RVA: 0x00E95EB8 File Offset: 0x00E940B8
		public virtual int? InstanceDungeonId
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170092AB RID: 37547
		// (get) Token: 0x0603978E RID: 235406 RVA: 0x00E95ECE File Offset: 0x00E940CE
		public virtual int? RelativeInstanceDungeonId
		{
			get
			{
				return this.InstanceDungeonId;
			}
		}

		// Token: 0x170092AC RID: 37548
		// (get) Token: 0x0603978F RID: 235407 RVA: 0x00E95ED8 File Offset: 0x00E940D8
		public int InstanceDungeonOrMapConfigId
		{
			get
			{
				if (this.InstanceDungeonId != null)
				{
					int? instanceDungeonId = this.InstanceDungeonId;
					int num = 0;
					if (!(instanceDungeonId.GetValueOrDefault() == num & instanceDungeonId != null))
					{
						return this.InstanceDungeonId.Value;
					}
				}
				return this.MapId;
			}
		}

		// Token: 0x170092AD RID: 37549
		// (get) Token: 0x06039790 RID: 235408 RVA: 0x00E95F27 File Offset: 0x00E94127
		// (set) Token: 0x06039791 RID: 235409 RVA: 0x00E95F2F File Offset: 0x00E9412F
		[Nullable(2)]
		public string NeedPlayShowOrHideSeq { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170092AE RID: 37550
		// (get) Token: 0x06039792 RID: 235410 RVA: 0x00E95F38 File Offset: 0x00E94138
		// (set) Token: 0x06039793 RID: 235411 RVA: 0x00E95F40 File Offset: 0x00E94140
		public bool NeedPlayStartSequence { get; set; }

		// Token: 0x170092AF RID: 37551
		// (get) Token: 0x06039794 RID: 235412 RVA: 0x00E95F49 File Offset: 0x00E94149
		// (set) Token: 0x06039795 RID: 235413 RVA: 0x00E95F51 File Offset: 0x00E94151
		public float MarkScale { get; set; } = 1f;

		// Token: 0x170092B0 RID: 37552
		// (get) Token: 0x06039796 RID: 235414 RVA: 0x00E95F5A File Offset: 0x00E9415A
		public global::Vector UiPosition
		{
			get
			{
				if (this.UiPositionVector == null)
				{
					return MapUtil.WorldPosition2UiPosition(this.WorldPosition, this.UiPositionVector);
				}
				return this.UiPositionVector;
			}
		}

		// Token: 0x170092B1 RID: 37553
		// (get) Token: 0x06039797 RID: 235415 RVA: 0x00E95F7C File Offset: 0x00E9417C
		public global::Vector InitUiPosition
		{
			get
			{
				if (this.AnchorOffsetVector != null)
				{
					return this.AnchorOffsetVector;
				}
				return this.UiPosition;
			}
		}

		// Token: 0x06039798 RID: 235416 RVA: 0x00E95F94 File Offset: 0x00E94194
		public void SetAnchorOffset(Vector2D value)
		{
			double x = value.X;
			global::Vector anchorOffsetVector = this.AnchorOffsetVector;
			bool flag;
			if (Math.Abs(x - ((anchorOffsetVector != null) ? anchorOffsetVector.X : 0.0)) <= 1E-08)
			{
				double y = value.Y;
				global::Vector anchorOffsetVector2 = this.AnchorOffsetVector;
				flag = (Math.Abs(y - ((anchorOffsetVector2 != null) ? anchorOffsetVector2.Y : 0.0)) > 1E-08);
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				MarkItemView view = this.View;
				UUIItem uuiitem = (view != null) ? view.GetRootItem() : null;
				this.AnchorOffsetVector = global::Vector.Create(value.X, value.Y, 0.0);
				if (ObjectUtils.IsValid(uuiitem))
				{
					FVector2D anchorOffset = value.ToUeVector2D(false);
					uuiitem.SetAnchorOffset(anchorOffset);
				}
			}
		}

		// Token: 0x06039799 RID: 235417 RVA: 0x00E96052 File Offset: 0x00E94252
		public virtual bool IsMultiMap()
		{
			return false;
		}

		// Token: 0x0603979A RID: 235418 RVA: 0x00E96055 File Offset: 0x00E94255
		public virtual bool LocateInGround()
		{
			return true;
		}

		// Token: 0x0603979B RID: 235419 RVA: 0x00E96058 File Offset: 0x00E94258
		public virtual bool ConnectGround()
		{
			return true;
		}

		// Token: 0x0603979C RID: 235420 RVA: 0x00E9605B File Offset: 0x00E9425B
		public virtual int GetMultiMapId()
		{
			return 0;
		}

		// Token: 0x0603979D RID: 235421 RVA: 0x00E9605E File Offset: 0x00E9425E
		public virtual bool ShowSecondaryUiMultiMapIcon()
		{
			return this.IsMultiMap() && !this.LocateInGround();
		}

		// Token: 0x170092B2 RID: 37554
		// (get) Token: 0x0603979E RID: 235422 RVA: 0x00E96073 File Offset: 0x00E94273
		// (set) Token: 0x0603979F RID: 235423 RVA: 0x00E96085 File Offset: 0x00E94285
		public bool IsSelectThisFloor
		{
			get
			{
				return this.MarkItemEntity.MultiFloor.IsSelectThisFloor;
			}
			set
			{
				this.MarkItemEntity.MultiFloor.IsSelectThisFloor = value;
			}
		}

		// Token: 0x060397A0 RID: 235424 RVA: 0x00E96098 File Offset: 0x00E94298
		public virtual bool GetIsSelectThisFloor()
		{
			if (!this.IsMultiMap())
			{
				return false;
			}
			int multiMapId = this.GetMultiMapId();
			if (this.MapType == EMapType.MiniMap)
			{
				return this.InMultiMapArea(multiMapId);
			}
			int? worldMapCurrentMultiMapId = ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId;
			int num = multiMapId;
			return worldMapCurrentMultiMapId.GetValueOrDefault() == num & worldMapCurrentMultiMapId != null;
		}

		// Token: 0x060397A1 RID: 235425 RVA: 0x00E960E8 File Offset: 0x00E942E8
		protected bool InMultiMapArea(int multiMapId)
		{
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
			MapConfig instance = ConfigBase<MapConfig>.Instance;
			return instance != null && instance.IsAreaInSubMap(multiMapId, currentAreaId);
		}

		// Token: 0x060397A2 RID: 235426 RVA: 0x00E9611B File Offset: 0x00E9431B
		private double VectorSquareDistance(global::Vector vector3D, Vector2D vector2D)
		{
			return Math.Pow(vector3D.X - vector2D.X, 2.0) + Math.Pow(vector3D.Y - vector2D.Y, 2.0);
		}

		// Token: 0x170092B3 RID: 37555
		// (get) Token: 0x060397A3 RID: 235427 RVA: 0x00E96154 File Offset: 0x00E94354
		public global::Vector WorldPosition
		{
			get
			{
				if (this.MapType != EMapType.WorldMap && this.TrackTarget is TTrackTarget_Vector2D)
				{
					global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
					Vector2D value = (this.TrackTarget as TTrackTarget_Vector2D).Value;
					if (this.VectorSquareDistance(playerLocation, value) * 0.009999999776482582 * 0.009999999776482582 < 3600.0 && !this.IsTeleporting)
					{
						global::Vector vector = MapUtil.WorldPosition2UiPosition(global::Vector.Create(value.X, value.Y, 0.0), null);
						global::Vector markPosition = ControllerBase<MapController>.Instance.GetMarkPosition(vector.X, -vector.Y);
						if (markPosition != null)
						{
							this.UpdateCustomMapMarkPosition(markPosition);
						}
						else
						{
							this.TrackTarget = new TTrackTarget_Vector(global::Vector.Create(value.X, value.Y, 0.0));
						}
					}
				}
				if (this.WorldPositionVector == null || !this.EnableCachePosition)
				{
					this.WorldPositionVector = MapUtil.GetTrackPositionByTrackTargetConfig(this.TrackTarget, this.MapId, this.WorldPositionVector);
					if (this.WorldPositionVector == null)
					{
						this.WorldPositionVector = new global::Vector();
					}
					this.UiPositionVector = MapUtil.WorldPosition2UiPosition(this.WorldPositionVector, this.UiPositionVector);
				}
				return this.WorldPositionVector;
			}
		}

		// Token: 0x060397A4 RID: 235428 RVA: 0x00E96290 File Offset: 0x00E94490
		public void UpdateCustomMapMarkPosition(global::Vector hitResult)
		{
			if (this.MarkType != EMarkType.Custom)
			{
				return;
			}
			global::Vector position = global::Vector.Create(hitResult.X, -hitResult.Y, hitResult.Z);
			global::Vector markPos = global::Vector.Create(hitResult.X, hitResult.Y, hitResult.Z);
			global::Vector vector = MapUtil.UiPosition2WorldPosition(position, null);
			this.TrackTarget = new TTrackTarget_Vector(vector);
			ControllerBase<MapController>.Instance.UpdateCustomMapMarkPosition(this.MarkId, markPos);
			global::Vector vector2 = global::Vector.Create();
			vector.Multiply(0.009999999776482582, vector2);
			ModelBase<MapModel>.Instance.UpdateCustomMarkInfo(this.MarkId, vector2);
			ModelBase<TrackModel>.Instance.UpdateTrackData(this.TrackSourceInner, this.MarkId, this.TrackTarget);
		}

		// Token: 0x060397A5 RID: 235429 RVA: 0x00E96340 File Offset: 0x00E94540
		public MarkItem(UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark)
		{
			this.MapType = mapType;
			this.MarkScale = markScale;
			this.InnerViewRoot = parent;
			this.TrackSourceInner = trackSource;
			this.UiPositionVector = null;
			this.WorldPositionVector = global::Vector.Create();
		}

		// Token: 0x170092B4 RID: 37556
		// (get) Token: 0x060397A6 RID: 235430 RVA: 0x00E96411 File Offset: 0x00E94611
		// (set) Token: 0x060397A7 RID: 235431 RVA: 0x00E96419 File Offset: 0x00E94619
		public virtual bool IsStreaming { get; set; } = true;

		// Token: 0x060397A8 RID: 235432 RVA: 0x00E96422 File Offset: 0x00E94622
		public void OnLoad()
		{
		}

		// Token: 0x060397A9 RID: 235433 RVA: 0x00E96424 File Offset: 0x00E94624
		public void OnUnload()
		{
		}

		// Token: 0x060397AA RID: 235434 RVA: 0x00E96426 File Offset: 0x00E94626
		public Vector2D GetPreloadThreshold()
		{
			return this.PreloadThreshold;
		}

		// Token: 0x060397AB RID: 235435 RVA: 0x00E9642E File Offset: 0x00E9462E
		public global::Vector GetUiPosition()
		{
			return this.UiPosition;
		}

		// Token: 0x060397AC RID: 235436 RVA: 0x00E96438 File Offset: 0x00E94638
		public void Initialize()
		{
			this.MarkItemEntity.Init();
			this.IsOutOfBound = false;
			this.IsInAoiRange = false;
			int instanceDungeonOrMapConfigId = this.InstanceDungeonOrMapConfigId;
			this.CachedDungeonMapConfigId = ModelBase<MapModel>.Instance.GetDungeonMapConfigId(instanceDungeonOrMapConfigId);
			this.CachedDungeonLocateWorldMapId = ModelBase<MapModel>.Instance.GetDungeonLocateWorldMapId(instanceDungeonOrMapConfigId);
			WorldMapConfig instance = ConfigBase<WorldMapConfig>.Instance;
			this.CachedIsBelongWorld = (instance != null && instance.IsMapInWorld(instanceDungeonOrMapConfigId));
			this.OnInitialize();
		}

		// Token: 0x060397AD RID: 235437 RVA: 0x00E964A5 File Offset: 0x00E946A5
		protected virtual void OnInitialize()
		{
		}

		// Token: 0x060397AE RID: 235438 RVA: 0x00E964A7 File Offset: 0x00E946A7
		public void SetTrackData(TTrackTarget trackTarget)
		{
			this.TrackTarget = trackTarget;
		}

		// Token: 0x060397AF RID: 235439 RVA: 0x00E964B0 File Offset: 0x00E946B0
		public void LogicUpdate(global::Vector playerLocation)
		{
			this.OnUpdate(playerLocation);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060397B0 RID: 235440 RVA: 0x00E964C0 File Offset: 0x00E946C0
		public UniTask ViewUpdateAsync(global::Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			MarkItem.<ViewUpdateAsync>d__112 <ViewUpdateAsync>d__;
			<ViewUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ViewUpdateAsync>d__.<>4__this = this;
			<ViewUpdateAsync>d__.playerLocation = playerLocation;
			<ViewUpdateAsync>d__.bDragging = bDragging;
			<ViewUpdateAsync>d__.bIsScale = bIsScale;
			<ViewUpdateAsync>d__.<>1__state = -1;
			<ViewUpdateAsync>d__.<>t__builder.Start<MarkItem.<ViewUpdateAsync>d__112>(ref <ViewUpdateAsync>d__);
			return <ViewUpdateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060397B1 RID: 235441 RVA: 0x00E9651C File Offset: 0x00E9471C
		public unsafe virtual void Destroy(bool recycleToPoolImmediately = true)
		{
			ELogAuthor author = ELogAuthor.LRX;
			string message = "标记系统->MarkItem.Destroy";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markType", this.MarkType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MarkId", this.MarkId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("InstanceDungeonId", this.InstanceDungeonId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("MapId", this.MapId);
			MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			this.IsDestroy = true;
			this.OnDestroy();
			this.RecycleView(recycleToPoolImmediately);
			this.MarkItemEntity.Dispose();
			this.InnerViewRoot = null;
		}

		// Token: 0x170092B5 RID: 37557
		// (get) Token: 0x060397B2 RID: 235442 RVA: 0x00E965F3 File Offset: 0x00E947F3
		// (set) Token: 0x060397B3 RID: 235443 RVA: 0x00E96605 File Offset: 0x00E94805
		public bool IsInAoiRange
		{
			get
			{
				return this.MarkItemEntity.ViewLifeCircle.IsInAoiRange;
			}
			set
			{
				this.MarkItemEntity.ViewLifeCircle.IsInAoiRange = value;
			}
		}

		// Token: 0x060397B4 RID: 235444
		protected abstract MarkItemView CreateView();

		// Token: 0x060397B5 RID: 235445
		protected abstract EMarkItemViewType GetMarkItemViewType();

		// Token: 0x060397B6 RID: 235446 RVA: 0x00E96618 File Offset: 0x00E94818
		private void ShowView()
		{
			if (this.View != null)
			{
				this.InitInnerView();
				return;
			}
			EMarkItemViewType markItemViewType = this.GetMarkItemViewType();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<EMarkItemViewType>(markItemViewType);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<EMapType>(this.MapType);
			MarkItemView markItemView = MarkItemViewPoolFactory.Get<MarkItemView>(defaultInterpolatedStringHandler.ToStringAndClear());
			if (markItemView != null)
			{
				this.View = markItemView;
				this.InitInnerView();
				return;
			}
			this.View = this.CreateView();
			MarkItemView view = this.View;
			this.InitInnerViewAsync(view);
		}

		// Token: 0x060397B7 RID: 235447 RVA: 0x00E966A0 File Offset: 0x00E948A0
		private UniTask InitInnerViewAsync(MarkItemView view)
		{
			MarkItem.<InitInnerViewAsync>d__120 <InitInnerViewAsync>d__;
			<InitInnerViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitInnerViewAsync>d__.<>4__this = this;
			<InitInnerViewAsync>d__.view = view;
			<InitInnerViewAsync>d__.<>1__state = -1;
			<InitInnerViewAsync>d__.<>t__builder.Start<MarkItem.<InitInnerViewAsync>d__120>(ref <InitInnerViewAsync>d__);
			return <InitInnerViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060397B8 RID: 235448 RVA: 0x00E966EC File Offset: 0x00E948EC
		private void InitInnerView()
		{
			if (this.View == null)
			{
				return;
			}
			if (this.View.LoadingPromise != null)
			{
				return;
			}
			if (!this.IsDestroy && !this.View.IsDestroyOrDestroying)
			{
				this.MarkItemEntity.ViewLifeCircle.SetAllChildViewStateDirty();
				this.View.InitializeData(this);
				this.View.InitializeView();
				this.View.RefreshView();
			}
		}

		// Token: 0x060397B9 RID: 235449 RVA: 0x00E96758 File Offset: 0x00E94958
		private void RecycleView(bool recycleToPoolImmediately = false)
		{
			if (this.View == null)
			{
				return;
			}
			this.MarkItemEntity.ViewLifeCircle.SetAllChildViewStateDirty();
			EMarkItemViewType markItemViewType = this.GetMarkItemViewType();
			if (!this.View.ViewInitialized)
			{
				this.View.RecycleToPool();
				this.View = null;
				return;
			}
			this.View.RecycleView(new bool?(recycleToPoolImmediately));
			if (!recycleToPoolImmediately)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<EMarkItemViewType>(markItemViewType);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted<EMapType>(this.MapType);
				MarkItemViewPoolFactory.Recycle(defaultInterpolatedStringHandler.ToStringAndClear(), this.View);
			}
			this.View = null;
		}

		// Token: 0x170092B6 RID: 37558
		// (get) Token: 0x060397BA RID: 235450 RVA: 0x00E967FC File Offset: 0x00E949FC
		// (set) Token: 0x060397BB RID: 235451 RVA: 0x00E96804 File Offset: 0x00E94A04
		[Nullable(2)]
		public TTrackTarget TrackTarget
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
				this.UiPositionVector = null;
				this.WorldPositionVector = null;
				this.AnchorOffsetVector = null;
			}
		}

		// Token: 0x170092B7 RID: 37559
		// (get) Token: 0x060397BC RID: 235452 RVA: 0x00E96824 File Offset: 0x00E94A24
		public virtual int? TrackAreaId
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170092B8 RID: 37560
		// (get) Token: 0x060397BD RID: 235453 RVA: 0x00E9683A File Offset: 0x00E94A3A
		public ETrackSource TrackSource
		{
			get
			{
				return this.TrackSourceInner;
			}
		}

		// Token: 0x170092B9 RID: 37561
		// (get) Token: 0x060397BE RID: 235454 RVA: 0x00E96842 File Offset: 0x00E94A42
		// (set) Token: 0x060397BF RID: 235455 RVA: 0x00E96854 File Offset: 0x00E94A54
		public bool IsTracked
		{
			get
			{
				return this.MarkItemEntity.ViewLifeCircle.IsTracked;
			}
			set
			{
				MarkViewLifeCircleComponent viewLifeCircle = this.MarkItemEntity.ViewLifeCircle;
				viewLifeCircle.IsTracked = value;
				if (viewLifeCircle.IsTrackedDirty)
				{
					if (value)
					{
						this.OnStartTrack();
						return;
					}
					this.OnEndTrack();
				}
			}
		}

		// Token: 0x170092BA RID: 37562
		// (get) Token: 0x060397C0 RID: 235456 RVA: 0x00E9687F File Offset: 0x00E94A7F
		// (set) Token: 0x060397C1 RID: 235457 RVA: 0x00E96891 File Offset: 0x00E94A91
		public bool IsAutoPilotTracked
		{
			get
			{
				return this.MarkItemEntity.ViewLifeCircle.IsAutoPilotTracked;
			}
			set
			{
				this.MarkItemEntity.ViewLifeCircle.IsAutoPilotTracked = value;
			}
		}

		// Token: 0x170092BB RID: 37563
		// (get) Token: 0x060397C2 RID: 235458 RVA: 0x00E968A4 File Offset: 0x00E94AA4
		public virtual bool PermanentUpdate
		{
			get
			{
				MarkViewLifeCircleComponent viewLifeCircle = this.MarkItemEntity.ViewLifeCircle;
				return viewLifeCircle.IsTracked || viewLifeCircle.IsSelected || MarkDefine.PermanentUpdateTypeSet.Contains(this.MarkType);
			}
		}

		// Token: 0x170092BC RID: 37564
		// (get) Token: 0x060397C3 RID: 235459 RVA: 0x00E968DF File Offset: 0x00E94ADF
		public bool CanOutOfBound
		{
			get
			{
				return this.IsTracked || MarkDefine.CanOutOfBoundUpdateTypeSet.Contains(this.MarkType);
			}
		}

		// Token: 0x060397C4 RID: 235460 RVA: 0x00E968FC File Offset: 0x00E94AFC
		protected virtual void UpdateVisibleRelativeState()
		{
			MarkItemEntity markItemEntity = this.MarkItemEntity;
			MarkViewLifeCircleComponent viewLifeCircle = markItemEntity.ViewLifeCircle;
			EMapType mapType = this.MapType;
			bool flag = !this.IsInConsistentDistrict(false);
			bool isSelected = viewLifeCircle.IsSelected;
			bool flag2 = this.IsTracking();
			bool flag3 = this.CheckCanShowInGravityLayer(flag2);
			bool flag4 = this.CheckCanShowInMultiMap();
			bool flag5 = ((this.CheckCanShowView() && flag4) || isSelected || flag2) && flag3;
			bool flag6 = flag && flag5;
			if (this.MarkItemType != EMarkItemType.Config)
			{
				flag6 &= this.IsTempMapMarkShow();
			}
			this.IsCanShowView = flag6;
			this.IsTracked = flag2;
			int markId = this.MarkId;
			if (markId > 0)
			{
				this.IsAutoPilotTracked = ModelBase<AutoPilotModel>.Instance.GetIsTracking(markId);
			}
			bool flag7;
			if (!flag6 || !flag)
			{
				flag7 = false;
			}
			else
			{
				if (mapType != EMapType.MiniMap || flag2)
				{
					viewLifeCircle.IsInAoiRange = true;
				}
				flag7 = (flag2 || viewLifeCircle.IsInAoiRange);
			}
			viewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.GravityReverse, markItemEntity.GamePlay.CanShowGravityChildIcon);
			flag7 = this.CheckExtraUiMarkVisible(flag7, mapType, markId);
			viewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.MarkView, flag7);
		}

		// Token: 0x060397C5 RID: 235461 RVA: 0x00E96A00 File Offset: 0x00E94C00
		private bool CheckExtraUiMarkVisible(bool showMarkView, EMapType mapType, int markId)
		{
			MapModel instance = ModelBase<MapModel>.Instance;
			bool flag = showMarkView;
			if (instance.HasExtraUiMarkType(mapType))
			{
				flag = instance.IsExtraUiMarkType(mapType, this.MarkType);
			}
			if (markId != 0 && instance.HasExtraUiMarkId(mapType))
			{
				flag = (flag || instance.IsExtraUiMarkId(mapType, markId));
			}
			flag = (flag && this.CheckCanShowViewInExtraUi());
			if (instance.HasExtraUiTileRange(mapType))
			{
				flag = (flag && instance.IsInExtraUiTileRange(mapType, this.UiPosition));
			}
			return flag;
		}

		// Token: 0x060397C6 RID: 235462 RVA: 0x00E96A74 File Offset: 0x00E94C74
		public void CreateOrCycleView()
		{
			if (this.MarkItemEntity.ViewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.MarkView))
			{
				bool flag = this.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.MarkView, false);
				this.MarkItemEntity.ViewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.MarkView);
				if (flag)
				{
					this.ShowView();
					return;
				}
				this.RecycleView(false);
			}
		}

		// Token: 0x060397C7 RID: 235463 RVA: 0x00E96AC7 File Offset: 0x00E94CC7
		protected bool IsTempMapMarkShow()
		{
			return this.MapType != EMapType.MiniMap || !this.MarkItemEntity.IsTempMapMark || this.IsTracked;
		}

		// Token: 0x060397C8 RID: 235464 RVA: 0x00E96AE7 File Offset: 0x00E94CE7
		protected virtual bool IsTracking()
		{
			return ModelBase<TrackModel>.Instance.IsTracking(this.TrackSource, this.MarkId);
		}

		// Token: 0x060397C9 RID: 235465 RVA: 0x00E96AFF File Offset: 0x00E94CFF
		protected virtual void OnStartTrack()
		{
			MarkItemView view = this.View;
			if (view == null)
			{
				return;
			}
			view.OnStartTrack();
		}

		// Token: 0x060397CA RID: 235466 RVA: 0x00E96B11 File Offset: 0x00E94D11
		protected virtual void OnEndTrack()
		{
			MarkItemView view = this.View;
			if (view == null)
			{
				return;
			}
			view.OnEndTrack();
		}

		// Token: 0x060397CB RID: 235467 RVA: 0x00E96B23 File Offset: 0x00E94D23
		protected virtual void OnUpdate(global::Vector playerLocation)
		{
		}

		// Token: 0x060397CC RID: 235468 RVA: 0x00E96B25 File Offset: 0x00E94D25
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x170092BD RID: 37565
		// (get) Token: 0x060397CD RID: 235469 RVA: 0x00E96B27 File Offset: 0x00E94D27
		[Nullable(2)]
		public UUIItem ViewRoot
		{
			[NullableContext(2)]
			get
			{
				return this.InnerViewRoot;
			}
		}

		// Token: 0x170092BE RID: 37566
		// (get) Token: 0x060397CE RID: 235470 RVA: 0x00E96B2F File Offset: 0x00E94D2F
		// (set) Token: 0x060397CF RID: 235471 RVA: 0x00E96B37 File Offset: 0x00E94D37
		[Nullable(2)]
		public MarkItemView View { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170092BF RID: 37567
		// (get) Token: 0x060397D0 RID: 235472 RVA: 0x00E96B40 File Offset: 0x00E94D40
		// (set) Token: 0x060397D1 RID: 235473 RVA: 0x00E96B48 File Offset: 0x00E94D48
		public virtual string IconPath
		{
			get
			{
				return this.Icon;
			}
			set
			{
				if (!string.Equals(this.Icon, value, StringComparison.Ordinal))
				{
					this.Icon = value;
				}
			}
		}

		// Token: 0x170092C0 RID: 37568
		// (get) Token: 0x060397D2 RID: 235474 RVA: 0x00E96B60 File Offset: 0x00E94D60
		// (set) Token: 0x060397D3 RID: 235475 RVA: 0x00E96B74 File Offset: 0x00E94D74
		public bool IsOutOfBound
		{
			get
			{
				return this.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.OutOfBound, false);
			}
			set
			{
				this.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.OutOfBound, value);
				if (this.View != null && this.View.IsViewReady)
				{
					this.View.ApplyOutOfBoundActive();
				}
			}
		}

		// Token: 0x060397D4 RID: 235476 RVA: 0x00E96BA8 File Offset: 0x00E94DA8
		public void SetSelected(bool value)
		{
			this.MarkItemEntity.ViewLifeCircle.IsSelected = value;
			if (this.View == null || this.IsDestroy)
			{
				return;
			}
			this.View.IsSelected = value;
		}

		// Token: 0x060397D5 RID: 235477 RVA: 0x00E96BD8 File Offset: 0x00E94DD8
		public bool IsViewReady()
		{
			return this.View != null && !this.View.IsCreating;
		}

		// Token: 0x060397D6 RID: 235478 RVA: 0x00E96BF2 File Offset: 0x00E94DF2
		[NullableContext(2)]
		public UUIItem GetRootItemSync()
		{
			if (!this.IsViewReady())
			{
				return null;
			}
			MarkItemView view = this.View;
			if (view == null)
			{
				return null;
			}
			return view.GetRootItem();
		}

		// Token: 0x060397D7 RID: 235479 RVA: 0x00E96C10 File Offset: 0x00E94E10
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UUIItem> GetRootItemAsync()
		{
			MarkItem.<GetRootItemAsync>d__169 <GetRootItemAsync>d__;
			<GetRootItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UUIItem>.Create();
			<GetRootItemAsync>d__.<>4__this = this;
			<GetRootItemAsync>d__.<>1__state = -1;
			<GetRootItemAsync>d__.<>t__builder.Start<MarkItem.<GetRootItemAsync>d__169>(ref <GetRootItemAsync>d__);
			return <GetRootItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060397D8 RID: 235480 RVA: 0x00E96C53 File Offset: 0x00E94E53
		[NullableContext(2)]
		public virtual string GetTitleText()
		{
			return null;
		}

		// Token: 0x060397D9 RID: 235481 RVA: 0x00E96C58 File Offset: 0x00E94E58
		public virtual void SetTitleText(UUIText uiText)
		{
			string titleText = this.GetTitleText();
			if (!string.IsNullOrEmpty(titleText))
			{
				uiText.SetText(titleText, true);
			}
		}

		// Token: 0x060397DA RID: 235482 RVA: 0x00E96C7C File Offset: 0x00E94E7C
		[NullableContext(2)]
		public virtual string GetStateIconPath()
		{
			if (this.IsMultiMap() && (!this.LocateInGround() || !this.IsSelectThisFloor))
			{
				return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.IsSelectThisFloor ? "SP_MarkMultiMapSelect" : "SP_MarkMultiMap") ?? string.Empty;
			}
			return null;
		}

		// Token: 0x060397DB RID: 235483 RVA: 0x00E96CCD File Offset: 0x00E94ECD
		[NullableContext(2)]
		public virtual string GetLocaleDesc()
		{
			return null;
		}

		// Token: 0x060397DC RID: 235484 RVA: 0x00E96CD0 File Offset: 0x00E94ED0
		protected void SetConfigScale(float scale)
		{
			this.ConfigScale = scale;
		}

		// Token: 0x060397DD RID: 235485 RVA: 0x00E96CD9 File Offset: 0x00E94ED9
		protected void SetCornerScale(float cornerScale)
		{
			this.CornerScale = cornerScale;
		}

		// Token: 0x170092C1 RID: 37569
		// (get) Token: 0x060397DE RID: 235486 RVA: 0x00E96CE2 File Offset: 0x00E94EE2
		private bool IsCanShowViewExtra
		{
			get
			{
				return ModelBase<MapModel>.Instance.GetMarkForceVisible(this.MarkType, this.MarkId);
			}
		}

		// Token: 0x170092C2 RID: 37570
		// (get) Token: 0x060397DF RID: 235487 RVA: 0x00E96CFA File Offset: 0x00E94EFA
		protected bool IsCanShowViewIntermediately
		{
			get
			{
				return this.IsCanShowViewInner && this.IsCanShowViewExtra;
			}
		}

		// Token: 0x170092C3 RID: 37571
		// (get) Token: 0x060397E0 RID: 235488 RVA: 0x00E96D0C File Offset: 0x00E94F0C
		// (set) Token: 0x060397E1 RID: 235489 RVA: 0x00E96D1E File Offset: 0x00E94F1E
		public bool IsCanShowView
		{
			get
			{
				return this.IsCanShowViewIntermediately || this.IsCanShowViewFinally;
			}
			set
			{
				this.IsCanShowViewInner = value;
			}
		}

		// Token: 0x060397E2 RID: 235490 RVA: 0x00E96D27 File Offset: 0x00E94F27
		public virtual bool CheckCanShowView()
		{
			return this.MapType == EMapType.WorldMap;
		}

		// Token: 0x060397E3 RID: 235491 RVA: 0x00E96D32 File Offset: 0x00E94F32
		public virtual bool CheckCanShowViewInExtraUi()
		{
			return true;
		}

		// Token: 0x060397E4 RID: 235492 RVA: 0x00E96D38 File Offset: 0x00E94F38
		public bool IsInConsistentDistrict(bool strictMode = false)
		{
			bool flag = this.MapType == EMapType.MiniMap;
			int? num = (strictMode || flag) ? new int?(this.CachedDungeonMapConfigId) : this.CachedDungeonLocateWorldMapId;
			WorldMapModel instance = ModelBase<WorldMapModel>.Instance;
			int? num2 = num;
			int currentWorldMapConfigId = instance.CurrentWorldMapConfigId;
			if (!(num2.GetValueOrDefault() == currentWorldMapConfigId & num2 != null))
			{
				return true;
			}
			bool flag2 = this.MarkType != EMarkType.AreaMark;
			bool flag3 = instance.IsPlayerInStoryInstanceDungeon();
			if (flag2 && !flag3 && !instance.IsPlayerInBigWorldInstanceDungeon() && instance.EnableInstanceDungeonFilterMark)
			{
				int currentMapConfigId = ModelBase<MapModel>.Instance.CurrentMapConfigId;
				num2 = num;
				if (currentMapConfigId == num2.GetValueOrDefault() & num2 != null)
				{
					return this.IsInConsistentDungeonByActivityRule();
				}
			}
			if (flag3 && flag2)
			{
				return this.IsInConsistentDungeonByStoryRule();
			}
			bool cachedIsBelongWorld = this.CachedIsBelongWorld;
			if (flag)
			{
				if (cachedIsBelongWorld)
				{
					return this.IsInConsistentBigWorldDungeon();
				}
				return this.InstanceDungeonId != null && this.IsInConsistentDungeon();
			}
			else
			{
				if (instance.IsPlayerInWorldInstanceDungeon())
				{
					return this.IsInConsistentLocateBigWorldDungeon(cachedIsBelongWorld);
				}
				return this.IsInConsistentBigWorldDungeon();
			}
		}

		// Token: 0x060397E5 RID: 235493 RVA: 0x00E96E38 File Offset: 0x00E95038
		private bool IsInConsistentBigWorldDungeon()
		{
			int? instanceDungeonId = this.InstanceDungeonId;
			int num = 0;
			if ((instanceDungeonId.GetValueOrDefault() == num & instanceDungeonId != null) || this.InstanceDungeonId == null)
			{
				return false;
			}
			instanceDungeonId = this.InstanceDungeonId;
			num = ModelBase<WorldMapModel>.Instance.CurrentWorldMapInstanceId;
			return !(instanceDungeonId.GetValueOrDefault() == num & instanceDungeonId != null);
		}

		// Token: 0x060397E6 RID: 235494 RVA: 0x00E96E9C File Offset: 0x00E9509C
		private bool IsInConsistentLocateBigWorldDungeon(bool targetBelongWorld)
		{
			int? instanceDungeonId = this.InstanceDungeonId;
			int num = 0;
			if ((instanceDungeonId.GetValueOrDefault() == num & instanceDungeonId != null) || this.InstanceDungeonId == null)
			{
				return false;
			}
			instanceDungeonId = this.InstanceDungeonId;
			num = ModelBase<WorldMapModel>.Instance.GetCurrentLocateWorldMapInstanceId(targetBelongWorld);
			return !(instanceDungeonId.GetValueOrDefault() == num & instanceDungeonId != null);
		}

		// Token: 0x060397E7 RID: 235495 RVA: 0x00E96F00 File Offset: 0x00E95100
		private bool IsInConsistentDungeon()
		{
			int? instanceDungeonId = this.InstanceDungeonId;
			int currentWorldMapInstanceId = ModelBase<WorldMapModel>.Instance.CurrentWorldMapInstanceId;
			return !(instanceDungeonId.GetValueOrDefault() == currentWorldMapInstanceId & instanceDungeonId != null);
		}

		// Token: 0x060397E8 RID: 235496 RVA: 0x00E96F34 File Offset: 0x00E95134
		private bool IsInConsistentDungeonByStoryRule()
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<WorldMapModel>.Instance.CurrentWorldMapInstanceId);
			int num = (config != null) ? config.GetValueOrDefault().MapMarkFilterRule : 0;
			if (num != 0)
			{
				return num == 1 && this.IsInConsistentDungeon();
			}
			if (this.MarkType == EMarkType.Quest && this.MapType == EMapType.WorldMap)
			{
				return false;
			}
			if (this.MapType == EMapType.MiniMap)
			{
				return this.IsInConsistentDungeon();
			}
			return this.IsInConsistentBigWorldDungeon();
		}

		// Token: 0x060397E9 RID: 235497 RVA: 0x00E96FB0 File Offset: 0x00E951B0
		private bool IsInConsistentDungeonByActivityRule()
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<WorldMapModel>.Instance.CurrentWorldMapInstanceId);
			int num = (config != null) ? config.GetValueOrDefault().MapMarkFilterRule : 0;
			if (num != 0 && num == 1)
			{
				return this.IsInConsistentDungeon();
			}
			return this.InstanceDungeonId == null || this.IsInConsistentDungeon();
		}

		// Token: 0x060397EA RID: 235498 RVA: 0x00E97014 File Offset: 0x00E95214
		protected bool CheckCanShowInGravityLayer(bool isTracking)
		{
			return isTracking || MarkDefine.PermanentShowInGravityLayerTypeSet.Contains(this.MarkType) || this.MarkItemEntity.GamePlay.InGravityLayer;
		}

		// Token: 0x060397EB RID: 235499 RVA: 0x00E97040 File Offset: 0x00E95240
		protected bool CheckCanShowInMultiMap()
		{
			if (this.MapType == EMapType.MiniMap)
			{
				return true;
			}
			if (MarkDefine.AllFloorShowMarkTypeSet.Contains(this.MarkType))
			{
				return true;
			}
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkId);
			if (configMark != null && configMark.GetValueOrDefault().MultiFloorShowCondition == 0)
			{
				return true;
			}
			if (this.IsMultiMap())
			{
				return this.GetIsSelectThisFloor();
			}
			int? worldMapCurrentMultiMapId = ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId;
			if (worldMapCurrentMultiMapId == null)
			{
				return true;
			}
			MultiMap? subMapConfigById = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(worldMapCurrentMultiMapId.Value);
			return subMapConfigById == null || subMapConfigById.Value.Floor == 0;
		}

		// Token: 0x060397EC RID: 235500 RVA: 0x00E970F4 File Offset: 0x00E952F4
		public virtual float GetShowScale()
		{
			float currentMapShowScale = this.GetCurrentMapShowScale();
			return Math.Max(0f, currentMapShowScale);
		}

		// Token: 0x060397ED RID: 235501 RVA: 0x00E97113 File Offset: 0x00E95313
		protected virtual float GetCurrentMapShowScale()
		{
			return ModelBase<WorldMapModel>.Instance.MapScale * 100f - 100f;
		}

		// Token: 0x060397EE RID: 235502 RVA: 0x00E9712B File Offset: 0x00E9532B
		public void OnLevelSequenceStart(string sequenceName)
		{
			if (sequenceName == "ShowView" || sequenceName == "HideView")
			{
				this.IsCanShowViewFinally = true;
			}
		}

		// Token: 0x060397EF RID: 235503 RVA: 0x00E9714E File Offset: 0x00E9534E
		public void OnLevelSequenceStop(string sequenceName)
		{
			if (sequenceName == "ShowView" || sequenceName == "HideView")
			{
				this.IsCanShowViewFinally = false;
			}
		}

		// Token: 0x060397F0 RID: 235504 RVA: 0x00E97171 File Offset: 0x00E95371
		public virtual bool GetInteractiveFlag()
		{
			return this.IsCanShowView;
		}

		// Token: 0x060397F1 RID: 235505 RVA: 0x00E97179 File Offset: 0x00E95379
		public virtual bool GamePlayIsDiscover()
		{
			return false;
		}

		// Token: 0x060397F2 RID: 235506 RVA: 0x00E9717C File Offset: 0x00E9537C
		public virtual ESecondaryPanel GetSecondaryUiType()
		{
			return WorldMapSecondaryUiDefine.MarkPanelTypeMap.GetValueOrDefault(this.MarkType, ESecondaryPanel.GeneralPanel);
		}

		// Token: 0x060397F3 RID: 235507 RVA: 0x00E9718F File Offset: 0x00E9538F
		public bool GetIsStrictConfigMark()
		{
			return this.MarkItemEntity.IsConfigMark && this.MarkItemType == EMarkItemType.Config;
		}

		// Token: 0x04020A57 RID: 133719
		[Nullable(2)]
		private MarkItemEntity MarkItemEntityInner;

		// Token: 0x04020A5D RID: 133725
		private float CornerScaleInner = 1f;

		// Token: 0x04020A60 RID: 133728
		[Nullable(2)]
		private global::Vector UiPositionVector;

		// Token: 0x04020A61 RID: 133729
		[Nullable(2)]
		private global::Vector WorldPositionVector;

		// Token: 0x04020A62 RID: 133730
		private readonly Vector2D PreloadThreshold = Vector2D.Create(0.0, 0.0);

		// Token: 0x04020A64 RID: 133732
		private int CachedDungeonMapConfigId;

		// Token: 0x04020A65 RID: 133733
		private int? CachedDungeonLocateWorldMapId;

		// Token: 0x04020A66 RID: 133734
		private bool CachedIsBelongWorld;

		// Token: 0x04020A6A RID: 133738
		[Nullable(2)]
		private global::Vector AnchorOffsetVector;

		// Token: 0x04020A6C RID: 133740
		[Nullable(2)]
		private TTrackTarget TrackTargetInner;

		// Token: 0x04020A6D RID: 133741
		protected bool EnableCachePosition = true;

		// Token: 0x04020A6E RID: 133742
		private ETrackSource TrackSourceInner = ETrackSource.Instance;

		// Token: 0x04020A6F RID: 133743
		[Nullable(2)]
		private UUIItem InnerViewRoot;

		// Token: 0x04020A71 RID: 133745
		private string Icon = string.Empty;

		// Token: 0x04020A72 RID: 133746
		private bool IsCanShowViewInner;

		// Token: 0x04020A73 RID: 133747
		protected bool IsCanShowViewFinally;
	}
}
