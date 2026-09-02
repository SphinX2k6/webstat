using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005886 RID: 22662
	[NullableContext(1)]
	[Nullable(0)]
	public class TemporaryTeleportMarkItemView : ServerMarkItemView
	{
		// Token: 0x060399D0 RID: 235984 RVA: 0x00E9D75D File Offset: 0x00E9B95D
		public TemporaryTeleportMarkItemView(TemporaryTeleportMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060399D1 RID: 235985 RVA: 0x00E9D766 File Offset: 0x00E9B966
		public override void RegisterEvents()
		{
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x060399D2 RID: 235986 RVA: 0x00E9D79B File Offset: 0x00E9B99B
		public override void UnRegisterEvents()
		{
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x060399D3 RID: 235987 RVA: 0x00E9D7D0 File Offset: 0x00E9B9D0
		protected override void OnViewRefresh()
		{
			this.OnIconPathChanged(this.Holder.IconPath);
			this.UpdateDisableState();
		}

		// Token: 0x060399D4 RID: 235988 RVA: 0x00E9D7E9 File Offset: 0x00E9B9E9
		protected override void OnSelectedStateChange(bool newState)
		{
			if (((TemporaryTeleportMarkItem)this.Holder).IsServerDisable)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Map_TeleportMark_Disable_Tips", Array.Empty<object>());
			}
		}

		// Token: 0x060399D5 RID: 235989 RVA: 0x00E9D811 File Offset: 0x00E9BA11
		protected override void OnSafeUpdate(Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			if (this.Holder != null)
			{
				this.UpdateDisableState();
			}
		}

		// Token: 0x060399D6 RID: 235990 RVA: 0x00E9D824 File Offset: 0x00E9BA24
		private void UpdateDisableState()
		{
			TemporaryTeleportMarkItem temporaryTeleportMarkItem = (TemporaryTeleportMarkItem)this.Holder;
			UUISprite sprite = base.GetSprite(2);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(temporaryTeleportMarkItem.IsServerDisable);
		}

		// Token: 0x060399D7 RID: 235991 RVA: 0x00E9D854 File Offset: 0x00E9BA54
		[PreserveBaseOverrides]
		protected new virtual MarkItemChildIconHandle CreateChildIconHandle(IMarkItemComponentContext markComponentContext)
		{
			return new TemporaryTeleportMarkItemChildIconHandle(markComponentContext);
		}

		// Token: 0x060399D8 RID: 235992 RVA: 0x00E9D85C File Offset: 0x00E9BA5C
		public void UpdateIcon()
		{
			base.MarkItemChildIconHandle.Update();
			base.MarkItemChildIconHandle.ApplyModified();
		}

		// Token: 0x060399D9 RID: 235993 RVA: 0x00E9D874 File Offset: 0x00E9BA74
		private void OnSubMapChanged(int floorIndex)
		{
			TemporaryTeleportMarkItem temporaryTeleportMarkItem = this.Holder as TemporaryTeleportMarkItem;
			if (temporaryTeleportMarkItem == null)
			{
				return;
			}
			temporaryTeleportMarkItem.UpdateMultiMapFloorSelectedState();
		}
	}
}
