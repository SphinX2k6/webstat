using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.TeleportPanel
{
	// Token: 0x02004B86 RID: 19334
	public class TeleportPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060327EF RID: 206831 RVA: 0x00CA207D File Offset: 0x00CA027D
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060327F0 RID: 206832 RVA: 0x00CA2084 File Offset: 0x00CA0284
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UnlockTeleport, new Action<int>(this.EventUnlockTeleport));
			base.OnBeforeShow();
		}

		// Token: 0x060327F1 RID: 206833 RVA: 0x00CA20A8 File Offset: 0x00CA02A8
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UnlockTeleport, new Action<int>(this.EventUnlockTeleport));
			base.OnBeforeHide();
		}

		// Token: 0x060327F2 RID: 206834 RVA: 0x00CA20CC File Offset: 0x00CA02CC
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(5);
			if (verticalLayout2 != null)
			{
				verticalLayout2.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x060327F3 RID: 206835 RVA: 0x00CA2148 File Offset: 0x00CA0348
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TeleportMarkItem teleportMarkItem = param[0] as TeleportMarkItem;
				if (teleportMarkItem != null)
				{
					this.SelectedMarkItem = teleportMarkItem;
					this.LayoutContext.MarkItem = teleportMarkItem;
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonEnableClickByTeleportState(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					UUIText text = base.GetText(4);
					if (text != null)
					{
						text.ShowTextNew(this.SelectedMarkItem.GetLocaleDesc());
					}
					base.UpdateMultiMap();
					base.UpdateTopRightIconByTeleportState();
					bool flag = base.UpdateQuickGoto();
					WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
					if (layoutContext == null)
					{
						return;
					}
					layoutContext.SetConfirmBtnActive(!flag);
				}
			}
		}

		// Token: 0x060327F4 RID: 206836 RVA: 0x00CA21FC File Offset: 0x00CA03FC
		private void EventUnlockTeleport(int teleportId)
		{
			TeleportMarkItem selectedMarkItem = this.SelectedMarkItem;
			int? num = (selectedMarkItem != null) ? new int?(selectedMarkItem.MarkConfigId) : null;
			if (!(teleportId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			base.Close();
		}

		// Token: 0x0401D73D RID: 120637
		[Nullable(2)]
		private TeleportMarkItem SelectedMarkItem;

		// Token: 0x0200AC56 RID: 44118
		public static class EComponents
		{
			// Token: 0x04035961 RID: 219489
			public const int TeleportPanel = 0;
		}
	}
}
