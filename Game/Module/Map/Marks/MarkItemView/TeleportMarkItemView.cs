using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005885 RID: 22661
	[NullableContext(1)]
	[Nullable(0)]
	public class TeleportMarkItemView : ConfigMarkItemView
	{
		// Token: 0x060399C4 RID: 235972 RVA: 0x00E9D4FA File Offset: 0x00E9B6FA
		public TeleportMarkItemView(TeleportMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060399C5 RID: 235973 RVA: 0x00E9D504 File Offset: 0x00E9B704
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMarkItemShowStateChange, new Action<int>(this.OnMarkItemStateChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSelectMultiMap, new Action<int>(this.OnSubMapChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.UnlockTeleport, new Action<int>(this.OnUnlockTeleport));
		}

		// Token: 0x060399C6 RID: 235974 RVA: 0x00E9D568 File Offset: 0x00E9B768
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMarkItemShowStateChange, new Action<int>(this.OnMarkItemStateChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapSelectMultiMap, new Action<int>(this.OnSubMapChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.UnlockTeleport, new Action<int>(this.OnUnlockTeleport));
		}

		// Token: 0x060399C7 RID: 235975 RVA: 0x00E9D5CA File Offset: 0x00E9B7CA
		protected override void OnViewRefresh()
		{
			this.Refresh();
		}

		// Token: 0x060399C8 RID: 235976 RVA: 0x00E9D5D2 File Offset: 0x00E9B7D2
		private void Refresh()
		{
			base.UpdateMultiMapFloorSelectState(true);
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x060399C9 RID: 235977 RVA: 0x00E9D5EC File Offset: 0x00E9B7EC
		protected override void OnSafeUpdate(global::Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			base.UpdateMultiMapFloorSelectState(false);
		}

		// Token: 0x060399CA RID: 235978 RVA: 0x00E9D5F8 File Offset: 0x00E9B7F8
		protected override void OnSubMapChanged(int subMapId)
		{
			TeleportMarkItem teleportMarkItem = (TeleportMarkItem)this.Holder;
			teleportMarkItem.IsSelectThisFloor = (teleportMarkItem.GetMultiMapId() == subMapId);
			this.OnIconPathChanged(teleportMarkItem.IconPath);
		}

		// Token: 0x060399CB RID: 235979 RVA: 0x00E9D62C File Offset: 0x00E9B82C
		private void OnUnlockTeleport(int markId)
		{
			if (base.MarkConfig.Value.MarkId == markId)
			{
				this.OnIconPathChanged(this.Holder.IconPath);
			}
		}

		// Token: 0x060399CC RID: 235980 RVA: 0x00E9D663 File Offset: 0x00E9B863
		public void OnMarkItemStateChange(int markId)
		{
			if (ModelBase<MapModel>.Instance.GetMarkExtraShowState(this.Holder.MarkId).ShowFlag == MapMarkShowFlag.ShowDisable)
			{
				base.GetSprite(2).SetUIActive(true);
				return;
			}
			base.GetSprite(2).SetUIActive(false);
		}

		// Token: 0x060399CD RID: 235981 RVA: 0x00E9D6A0 File Offset: 0x00E9B8A0
		public override void OnIconPathChanged(string iconPath)
		{
			if (base.MarkItemChildIconHandle == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(1);
			base.LoadIcon(sprite, iconPath);
			base.MarkItemChildIconHandle.Update();
			base.MarkItemChildIconHandle.ApplyModified();
		}

		// Token: 0x060399CE RID: 235982 RVA: 0x00E9D6DC File Offset: 0x00E9B8DC
		protected override void OnSelectedStateChange(bool newState)
		{
			if (!newState)
			{
				return;
			}
			if (ModelBase<MapModel>.Instance.GetMarkExtraShowState(this.Holder.MarkId).ShowFlag == MapMarkShowFlag.ShowDisable)
			{
				if (ModelBase<MapModel>.Instance.IsMarkForbidGravityTeleport(this.Holder.MarkId, this.Holder.MarkType))
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MultiModeCannotTeleport", Array.Empty<object>());
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Map_TeleportMark_Disable_Tips", Array.Empty<object>());
			}
		}

		// Token: 0x060399CF RID: 235983 RVA: 0x00E9D755 File Offset: 0x00E9B955
		[PreserveBaseOverrides]
		protected new virtual MarkItemChildIconHandle CreateChildIconHandle(IMarkItemComponentContext markComponentContext)
		{
			return new TeleportMarkItemChildIconHandle(markComponentContext);
		}
	}
}
