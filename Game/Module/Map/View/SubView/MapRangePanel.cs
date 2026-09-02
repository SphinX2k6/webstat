using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.SubView
{
	// Token: 0x020057EB RID: 22507
	[NullableContext(2)]
	[Nullable(0)]
	public class MapRangePanel
	{
		// Token: 0x170091D7 RID: 37335
		// (get) Token: 0x060393B6 RID: 234422 RVA: 0x00E84376 File Offset: 0x00E82576
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<BaseMap, MiniMap> Map { [return: Nullable(new byte[]
		{
			0,
			1,
			1
		})] get; }

		// Token: 0x060393B7 RID: 234423 RVA: 0x00E8437E File Offset: 0x00E8257E
		public MapRangePanel([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<BaseMap, MiniMap> map)
		{
			this.Map = map;
			Singleton<EventSystem>.Instance.Add(EEventName.HideNavigateMarkRange, new Action(this.EventHideNavigateMarkRange));
		}

		// Token: 0x060393B8 RID: 234424 RVA: 0x00E843AC File Offset: 0x00E825AC
		private UUIItem GetRootItem()
		{
			if (this.Map.IsT1)
			{
				return this.Map.AsT1.GetRootItem();
			}
			if (this.Map.IsT2)
			{
				return this.Map.AsT2.GetRootItem();
			}
			return null;
		}

		// Token: 0x170091D8 RID: 37336
		// (get) Token: 0x060393B9 RID: 234425 RVA: 0x00E84404 File Offset: 0x00E82604
		private int? MapId
		{
			get
			{
				if (this.Map.IsT1)
				{
					return new int?(this.Map.AsT1.MapId);
				}
				if (this.Map.IsT2)
				{
					return new int?(this.Map.AsT2.MapId);
				}
				return null;
			}
		}

		// Token: 0x170091D9 RID: 37337
		// (get) Token: 0x060393BA RID: 234426 RVA: 0x00E8446C File Offset: 0x00E8266C
		private EMapGravityDirection? MapGravity
		{
			get
			{
				if (this.Map.IsT1)
				{
					return new EMapGravityDirection?(this.Map.AsT1.MapGravity);
				}
				if (this.Map.IsT2)
				{
					return new EMapGravityDirection?(this.Map.AsT2.MapGravity);
				}
				return null;
			}
		}

		// Token: 0x060393BB RID: 234427 RVA: 0x00E844D4 File Offset: 0x00E826D4
		private UniTask InitRangeComponentAsync()
		{
			MapRangePanel.<InitRangeComponentAsync>d__14 <InitRangeComponentAsync>d__;
			<InitRangeComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRangeComponentAsync>d__.<>4__this = this;
			<InitRangeComponentAsync>d__.<>1__state = -1;
			<InitRangeComponentAsync>d__.<>t__builder.Start<MapRangePanel.<InitRangeComponentAsync>d__14>(ref <InitRangeComponentAsync>d__);
			return <InitRangeComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060393BC RID: 234428 RVA: 0x00E84518 File Offset: 0x00E82718
		[NullableContext(1)]
		public UniTask SetRangeComponentShow(Vector2D pos, float? width = null, float? height = null)
		{
			MapRangePanel.<SetRangeComponentShow>d__15 <SetRangeComponentShow>d__;
			<SetRangeComponentShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetRangeComponentShow>d__.<>4__this = this;
			<SetRangeComponentShow>d__.pos = pos;
			<SetRangeComponentShow>d__.width = width;
			<SetRangeComponentShow>d__.height = height;
			<SetRangeComponentShow>d__.<>1__state = -1;
			<SetRangeComponentShow>d__.<>t__builder.Start<MapRangePanel.<SetRangeComponentShow>d__15>(ref <SetRangeComponentShow>d__);
			return <SetRangeComponentShow>d__.<>t__builder.Task;
		}

		// Token: 0x060393BD RID: 234429 RVA: 0x00E84574 File Offset: 0x00E82774
		public UniTask SetRangeComponentHide(bool isClearInfo = true)
		{
			MapRangePanel.<SetRangeComponentHide>d__16 <SetRangeComponentHide>d__;
			<SetRangeComponentHide>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetRangeComponentHide>d__.<>4__this = this;
			<SetRangeComponentHide>d__.isClearInfo = isClearInfo;
			<SetRangeComponentHide>d__.<>1__state = -1;
			<SetRangeComponentHide>d__.<>t__builder.Start<MapRangePanel.<SetRangeComponentHide>d__16>(ref <SetRangeComponentHide>d__);
			return <SetRangeComponentHide>d__.<>t__builder.Task;
		}

		// Token: 0x060393BE RID: 234430 RVA: 0x00E845C0 File Offset: 0x00E827C0
		private UniTask WaitRangeComponent()
		{
			MapRangePanel.<WaitRangeComponent>d__17 <WaitRangeComponent>d__;
			<WaitRangeComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitRangeComponent>d__.<>4__this = this;
			<WaitRangeComponent>d__.<>1__state = -1;
			<WaitRangeComponent>d__.<>t__builder.Start<MapRangePanel.<WaitRangeComponent>d__17>(ref <WaitRangeComponent>d__);
			return <WaitRangeComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060393BF RID: 234431 RVA: 0x00E84604 File Offset: 0x00E82804
		public void CheckExploreMarkRangeInfo()
		{
			IMapMarkRangeInfo mapRangeInfo = ModelBase<WorldMapModel>.Instance.MapRangeInfo;
			if (mapRangeInfo != null)
			{
				int? mapId = mapRangeInfo.MapId;
				int? mapId2 = this.MapId;
				if (mapId.GetValueOrDefault() == mapId2.GetValueOrDefault() & mapId != null == (mapId2 != null))
				{
					EMapGravityDirection? gravity = mapRangeInfo.Gravity;
					EMapGravityDirection? mapGravity = this.MapGravity;
					if (gravity.GetValueOrDefault() == mapGravity.GetValueOrDefault() & gravity != null == (mapGravity != null))
					{
						if (this.CheckShowRangeMarkIsDiscover())
						{
							this.SetRangeComponentHide(true).Forget();
							return;
						}
						if (!ModelBase<WorldMapModel>.Instance.IsMapRangeVisible)
						{
							this.SetRangeComponentHide(false).Forget();
							return;
						}
						this.SetRangeComponentShow(mapRangeInfo.Position, mapRangeInfo.Width, mapRangeInfo.Height).Forget();
						return;
					}
				}
			}
		}

		// Token: 0x060393C0 RID: 234432 RVA: 0x00E846D0 File Offset: 0x00E828D0
		public void MiniMapUpdate()
		{
			IMapMarkRangeInfo mapRangeInfo = ModelBase<WorldMapModel>.Instance.MapRangeInfo;
			if (mapRangeInfo != null)
			{
				int? mapId = mapRangeInfo.MapId;
				int? num = this.MapId;
				if (mapId.GetValueOrDefault() == num.GetValueOrDefault() & mapId != null == (num != null))
				{
					EMapGravityDirection? gravity = mapRangeInfo.Gravity;
					EMapGravityDirection? emapGravityDirection = this.MapGravity;
					if (gravity.GetValueOrDefault() == emapGravityDirection.GetValueOrDefault() & gravity != null == (emapGravityDirection != null))
					{
						if (this.CacheRangePosition != null && Math.Abs(this.CacheRangePosition.X - mapRangeInfo.Position.X) <= 9.99999993922529E-09 && Math.Abs(this.CacheRangePosition.Y - mapRangeInfo.Position.Y) <= 9.99999993922529E-09)
						{
							emapGravityDirection = this.CacheGravity;
							gravity = mapRangeInfo.Gravity;
							if (emapGravityDirection.GetValueOrDefault() == gravity.GetValueOrDefault() & emapGravityDirection != null == (gravity != null))
							{
								num = this.CacheMapId;
								mapId = mapRangeInfo.MapId;
								if ((num.GetValueOrDefault() == mapId.GetValueOrDefault() & num != null == (mapId != null)) && !this.CheckShowRangeMarkIsDiscover())
								{
									return;
								}
							}
						}
						this.CheckExploreMarkRangeInfo();
						this.CacheRangePosition = Vector2D.Create(mapRangeInfo.Position.X, mapRangeInfo.Position.Y);
						this.CacheGravity = mapRangeInfo.Gravity;
						this.CacheMapId = mapRangeInfo.MapId;
						return;
					}
				}
			}
			this.SetRangeComponentHide(true).Forget();
		}

		// Token: 0x060393C1 RID: 234433 RVA: 0x00E84864 File Offset: 0x00E82A64
		private bool CheckShowRangeMarkIsDiscover()
		{
			NavigateMarkShowRange navigateMarkShowRangeInfo = ModelBase<WorldMapModel>.Instance.NavigateMarkShowRangeInfo;
			if (navigateMarkShowRangeInfo == null)
			{
				return false;
			}
			if (navigateMarkShowRangeInfo.IsDiscover.GetValueOrDefault())
			{
				return true;
			}
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(navigateMarkShowRangeInfo.MarkId);
			if (configMark == null)
			{
				return false;
			}
			int relativeDungeonId = configMark.Value.RelativeDungeonId;
			int relativeId = configMark.Value.RelativeId;
			return ModelBase<LevelPlayReportModel>.Instance.IsCommonLevelPlayDiscover(relativeDungeonId, relativeId);
		}

		// Token: 0x060393C2 RID: 234434 RVA: 0x00E848DC File Offset: 0x00E82ADC
		public void Destroy()
		{
			if (this.RangeComponent != null)
			{
				this.RangeComponent.SkipDestroyActor = false;
				this.RangeComponent.Destroy(null);
				this.RangeComponent = null;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.HideNavigateMarkRange, new Action(this.EventHideNavigateMarkRange));
		}

		// Token: 0x060393C3 RID: 234435 RVA: 0x00E8492C File Offset: 0x00E82B2C
		private void EventHideNavigateMarkRange()
		{
			this.SetRangeComponentHide(true).Forget();
		}

		// Token: 0x040208B3 RID: 133299
		private MarkRangeImageComponent RangeComponent;

		// Token: 0x040208B4 RID: 133300
		private UniTaskCompletionSource RangeComponentPromise;

		// Token: 0x040208B5 RID: 133301
		private Vector2D CacheRangePosition;

		// Token: 0x040208B6 RID: 133302
		private int? CacheMapId;

		// Token: 0x040208B7 RID: 133303
		private EMapGravityDirection? CacheGravity;
	}
}
