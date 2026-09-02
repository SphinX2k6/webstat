using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005869 RID: 22633
	[NullableContext(1)]
	[Nullable(0)]
	public class EnrichmentAreaItemView : ServerMarkItemView
	{
		// Token: 0x060398EE RID: 235758 RVA: 0x00E9A9CA File Offset: 0x00E98BCA
		public EnrichmentAreaItemView(EnrichmentAreaItem holder) : base(holder)
		{
		}

		// Token: 0x060398EF RID: 235759 RVA: 0x00E9A9D4 File Offset: 0x00E98BD4
		protected override void OnViewRefresh()
		{
			this.Holder.MarkItemEntity.ViewLifeCircle.EnableVerticalPointer = false;
			bool visible = this.Holder.CheckCanShowView();
			base.MarkItemRangeHandle.SetVisible(visible);
			this.UpdateMultiMapFloorSelectedState();
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x060398F0 RID: 235760 RVA: 0x00E9AA26 File Offset: 0x00E98C26
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSelectMultiMap, new Action<int>(this.OnSubMapChanged));
			Singleton<EventSystem>.Instance.Add<EMarkType, int, bool>(EEventName.TrackMapMark, new Action<EMarkType, int, bool>(this.OnTrackMapMark));
		}

		// Token: 0x060398F1 RID: 235761 RVA: 0x00E9AA60 File Offset: 0x00E98C60
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapSelectMultiMap, new Action<int>(this.OnSubMapChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrackMapMark, new Action<EMarkType, int, bool>(this.OnTrackMapMark));
		}

		// Token: 0x060398F2 RID: 235762 RVA: 0x00E9AA9C File Offset: 0x00E98C9C
		private void OnSubMapChanged(int subMapId)
		{
			EnrichmentAreaItem enrichmentAreaItem = (EnrichmentAreaItem)this.Holder;
			enrichmentAreaItem.IsSelectThisFloor = (enrichmentAreaItem.GetMultiMapId() == subMapId);
			this.OnIconPathChanged(enrichmentAreaItem.IconPath);
		}

		// Token: 0x060398F3 RID: 235763 RVA: 0x00E9AAD0 File Offset: 0x00E98CD0
		private void OnTrackMapMark(EMarkType eMarkType, int i, bool arg3)
		{
			EnrichmentAreaItem enrichmentAreaItem = (EnrichmentAreaItem)this.Holder;
			this.OnIconPathChanged(enrichmentAreaItem.IconPath);
		}

		// Token: 0x060398F4 RID: 235764 RVA: 0x00E9AAF8 File Offset: 0x00E98CF8
		public override void OnIconPathChanged(string iconPath)
		{
			bool flag = ((EnrichmentAreaItem)this.Holder).CheckCanShowIcon();
			UUISprite sprite = base.GetSprite(1);
			if (flag)
			{
				base.LoadIcon(sprite, iconPath);
			}
			else
			{
				sprite.SetUIActive(flag);
			}
			base.MarkItemChildIconHandle.Update();
		}

		// Token: 0x060398F5 RID: 235765 RVA: 0x00E9AB40 File Offset: 0x00E98D40
		public void UpdateMultiMapFloorSelectedState()
		{
			EnrichmentAreaItem enrichmentAreaItem = (EnrichmentAreaItem)this.Holder;
			bool isSelectThisFloor = this.Holder.IsSelectThisFloor;
			this.Holder.IsSelectThisFloor = enrichmentAreaItem.GetIsSelectThisFloor();
			if (isSelectThisFloor != this.Holder.IsSelectThisFloor)
			{
				this.OnIconPathChanged(enrichmentAreaItem.IconPath);
			}
		}

		// Token: 0x060398F6 RID: 235766 RVA: 0x00E9AB8E File Offset: 0x00E98D8E
		protected override IMarkItemHandle CreateRangeHandle<[Nullable(0)] T>(IMarkItemComponentContext markComponentContext)
		{
			return new EnrichmentAreaItemRangeHandle(markComponentContext);
		}
	}
}
