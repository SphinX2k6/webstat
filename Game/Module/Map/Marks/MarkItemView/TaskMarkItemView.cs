using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005884 RID: 22660
	[NullableContext(1)]
	[Nullable(0)]
	public class TaskMarkItemView : ServerMarkItemView
	{
		// Token: 0x060399B6 RID: 235958 RVA: 0x00E9CFEC File Offset: 0x00E9B1EC
		public TaskMarkItemView(ServerMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060399B7 RID: 235959 RVA: 0x00E9CFF5 File Offset: 0x00E9B1F5
		public override void RegisterEvents()
		{
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x060399B8 RID: 235960 RVA: 0x00E9D02A File Offset: 0x00E9B22A
		public override void UnRegisterEvents()
		{
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x060399B9 RID: 235961 RVA: 0x00E9D05F File Offset: 0x00E9B25F
		private void OnSubMapChanged(int floorIndex)
		{
			TaskMarkItem taskMarkItem = this.Holder as TaskMarkItem;
			if (taskMarkItem == null)
			{
				return;
			}
			taskMarkItem.UpdateMultiMapFloorSelectedState();
		}

		// Token: 0x060399BA RID: 235962 RVA: 0x00E9D076 File Offset: 0x00E9B276
		public void UpdateIcon()
		{
			base.MarkItemChildIconHandle.Update();
			base.MarkItemChildIconHandle.ApplyModified();
		}

		// Token: 0x060399BB RID: 235963 RVA: 0x00E9D090 File Offset: 0x00E9B290
		protected override void OnViewRefresh()
		{
			base.GetSprite(1).SetUIActive(true);
			base.MarkItemRangeHandle.SetVisible(false);
			this.Refresh();
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				((TaskMarkItem)this.Holder).UpdateMultiMapFloorSelectedState();
			}
		}

		// Token: 0x060399BC RID: 235964 RVA: 0x00E9D0E3 File Offset: 0x00E9B2E3
		private void Refresh()
		{
			this.InitRangeImage();
			this.OnIconPathChanged(this.Holder.IconPath);
			base.MarkItemTopRightIconHandle.Update();
			base.MarkItemTopRightIconHandle.ApplyModified();
		}

		// Token: 0x060399BD RID: 235965 RVA: 0x00E9D114 File Offset: 0x00E9B314
		private void InitRangeImage()
		{
			this.IsCanShowRangeImage = false;
			float rangeSize = this.Holder.MarkItemEntity.Resource.RangeSize;
			this.IsRangeTrack = (rangeSize > 0f);
			if (rangeSize <= 0f)
			{
				return;
			}
			this.UpdateRangeShow(Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation() ?? global::Vector.ZeroVectorProxy, false);
			this.Flag = true;
		}

		// Token: 0x060399BE RID: 235966 RVA: 0x00E9D176 File Offset: 0x00E9B376
		protected override IMarkItemHandle CreateRangeHandle<[Nullable(0)] T>(IMarkItemComponentContext markComponentContext)
		{
			return new TaskMarkItemRangeHandle(markComponentContext);
		}

		// Token: 0x060399BF RID: 235967 RVA: 0x00E9D17E File Offset: 0x00E9B37E
		protected override void OnSafeUpdate(global::Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				this.Refresh();
			}
			this.UpdateRangeShow(playerLocation, bDragging);
		}

		// Token: 0x060399C0 RID: 235968 RVA: 0x00E9D1A5 File Offset: 0x00E9B3A5
		public bool IsRangeImageActive()
		{
			return this.Holder.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Range, false);
		}

		// Token: 0x060399C1 RID: 235969 RVA: 0x00E9D1C0 File Offset: 0x00E9B3C0
		private void UpdateRangeShow(global::Vector playerLocation, bool bDragging = false)
		{
			if (!this.IsRangeTrack)
			{
				base.MarkItemTrackHandle.SetVisible(this.Holder.IsTracked && !bDragging);
				return;
			}
			if (!this.Holder.IsCanShowView)
			{
				this.UpdateRangeImageActive(false);
				return;
			}
			TaskMarkItem taskMarkItem = (TaskMarkItem)this.Holder;
			double rangeMarkShowDis = taskMarkItem.RangeMarkShowDis;
			double num = rangeMarkShowDis + 2.0;
			bool flag = true;
			double num3;
			bool flag2;
			if (taskMarkItem.RangeMarkShowDisUp != 0.0 || taskMarkItem.RangeMarkShowDisDown != 0.0)
			{
				double num2 = (playerLocation.Z - this.Holder.WorldPosition.Z) * 0.009999999776482582;
				num3 = global::Vector.Dist2D(playerLocation, this.Holder.WorldPosition) * 0.009999999776482582;
				flag = (num2 < taskMarkItem.RangeMarkShowDisUp && num2 > taskMarkItem.RangeMarkShowDisDown);
				flag2 = (num3 > rangeMarkShowDis && num2 > taskMarkItem.RangeMarkShowDisUp && num2 < taskMarkItem.RangeMarkShowDisDown);
			}
			else
			{
				num3 = global::Vector.Dist(playerLocation, this.Holder.WorldPosition) * 0.009999999776482582;
				flag2 = (num3 > rangeMarkShowDis);
			}
			base.MarkItemTrackHandle.SetVisible(flag2 && this.Holder.IsTracked);
			if (this.Flag)
			{
				this.UpdateRangeImageActive(!flag2);
				this.Flag = false;
				return;
			}
			this.UpdateRangeImageActive(num3 < num && flag);
		}

		// Token: 0x060399C2 RID: 235970 RVA: 0x00E9D33C File Offset: 0x00E9B53C
		private void UpdateRangeImageActive(bool active)
		{
			TaskMarkItem taskMarkItem = (TaskMarkItem)this.Holder;
			int? num = (taskMarkItem != null) ? new int?(taskMarkItem.RawInstanceDungeonId) : null;
			int num2 = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(num2);
			if (config != null && config.GetValueOrDefault().EntranceEntitiesLength > 0)
			{
				num2 = config.Value.EntranceEntities(0).Value.DungeonId;
			}
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				int? num3 = num;
				int num4 = num2;
				bool flag = !(num3.GetValueOrDefault() == num4 & num3 != null);
				this.SetRangeImageActive(active && !flag);
				return;
			}
			this.SetRangeImageActive(active);
		}

		// Token: 0x060399C3 RID: 235971 RVA: 0x00E9D418 File Offset: 0x00E9B618
		private void SetRangeImageActive(bool active)
		{
			if (!this.IsRangeTrack)
			{
				return;
			}
			if (this.IsCanShowRangeImage == active)
			{
				MarkItem holder = this.Holder;
				if (holder != null && holder.MapType == EMapType.MiniMap)
				{
					return;
				}
			}
			this.IsCanShowRangeImage = active;
			base.MarkItemRangeHandle.SetVisible(active);
			if (this.Holder.MarkItemEntity.ViewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.Range) && this.Holder.MapType == EMapType.MiniMap)
			{
				TaskMarkItem taskMarkItem = (TaskMarkItem)this.Holder;
				Singleton<EventSystem>.Instance.Emit<ETrackSource, long, int, int, bool>(EEventName.TaskRangeTrackStateChange, taskMarkItem.TrackSource, taskMarkItem.TreeIncId.Value, taskMarkItem.NodeId, taskMarkItem.MarkId, active);
			}
			bool flag = this.Holder.IsOutOfBound || !active;
			base.GetSprite(1).SetUIActive(flag);
			this.IsShowIcon = flag;
			if (!flag)
			{
				base.MarkItemChildIconHandle.SetVisible(false);
			}
		}

		// Token: 0x04020ADB RID: 133851
		public readonly int QuestStepId;

		// Token: 0x04020ADC RID: 133852
		private bool IsRangeTrack;

		// Token: 0x04020ADD RID: 133853
		private bool IsCanShowRangeImage;

		// Token: 0x04020ADE RID: 133854
		private bool Flag;
	}
}
