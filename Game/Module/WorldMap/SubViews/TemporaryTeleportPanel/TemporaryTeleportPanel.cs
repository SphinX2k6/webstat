using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.TemporaryTeleportPanel
{
	// Token: 0x02004B85 RID: 19333
	public class TemporaryTeleportPanel : WorldMapSecondaryUiLayoutB
	{
		// Token: 0x060327E5 RID: 206821 RVA: 0x00CA1D5D File Offset: 0x00C9FF5D
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_TemporaryTeleportPanel_Prefab";
		}

		// Token: 0x060327E6 RID: 206822 RVA: 0x00CA1D64 File Offset: 0x00C9FF64
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetRaycastTarget(false);
			}
			base.OnStart();
		}

		// Token: 0x060327E7 RID: 206823 RVA: 0x00CA1D80 File Offset: 0x00C9FF80
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TemporaryTeleportMarkItem temporaryTeleportMarkItem = param[0] as TemporaryTeleportMarkItem;
				if (temporaryTeleportMarkItem != null)
				{
					this.LayoutContext.MarkItem = temporaryTeleportMarkItem;
					this.SelectedMarkItem = temporaryTeleportMarkItem;
					UUIText text = base.GetText(1);
					if (text != null)
					{
						text.SetText(StringUtils.Format("{0}{1}/{2}", new string[]
						{
							this.SelectedMarkItem.GetTitleText() ?? "",
							ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.TemporaryTeleport).ToString(),
							ConfigCommonParamById.GetIntConfig("TemporaryTeleportCountLimit").ToString()
						}), true);
					}
					ButtonItem rightConfirmBtn = this.RightConfirmBtn;
					if (rightConfirmBtn != null)
					{
						rightConfirmBtn.SetUiActive(false);
					}
					ButtonItem leftConfirmBtn = this.LeftConfirmBtn;
					if (leftConfirmBtn != null)
					{
						leftConfirmBtn.SetUiActive(false);
					}
					ButtonItem middleCenterBtn = this.MiddleCenterBtn;
					if (middleCenterBtn != null)
					{
						middleCenterBtn.SetUiActive(true);
					}
					base.SetDelBtnActive(true);
					this.SetSpriteByPath(this.SelectedMarkItem.IconPath, base.GetSprite(0), false, null, null);
					UUIText text2 = base.GetText(2);
					if (text2 != null)
					{
						text2.SetText(this.SelectedMarkItem.GetDescText() ?? "", true);
					}
					UUIText text3 = base.GetText(3);
					if (text3 != null)
					{
						text3.SetUIActive(false);
					}
					UUIItem item = base.GetItem(5);
					if (item != null)
					{
						item.SetUIActive(false);
					}
					this.UpdateButtonState();
					this.UpdateMultiMap();
				}
			}
		}

		// Token: 0x060327E8 RID: 206824 RVA: 0x00CA1EDB File Offset: 0x00CA00DB
		protected override void OnMiddleCenterBtnClick(int index)
		{
			if (this.SelectedMarkItem != null)
			{
				MapController instance = ControllerBase<MapController>.Instance;
				if (instance != null)
				{
					instance.RequestTeleportToTargetByTemporaryTeleport(this.SelectedMarkItem.TeleportId, null);
				}
				base.Close();
			}
		}

		// Token: 0x060327E9 RID: 206825 RVA: 0x00CA1F07 File Offset: 0x00CA0107
		protected override void OnDelBtnClick()
		{
			this.OpenSureRemoveTemporaryTeleport();
		}

		// Token: 0x060327EA RID: 206826 RVA: 0x00CA1F10 File Offset: 0x00CA0110
		private void OpenSureRemoveTemporaryTeleport()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DestroyTemporaryTeleport);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.RemoveTemporaryTeleport);
			ConfirmBoxController instance = ControllerBase<ConfirmBoxController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060327EB RID: 206827 RVA: 0x00CA1F51 File Offset: 0x00CA0151
		private void RemoveTemporaryTeleport()
		{
			if (this.SelectedMarkItem != null)
			{
				MapExploreToolController instance = ControllerBase<MapExploreToolController>.Instance;
				if (instance != null)
				{
					instance.RemoveTemporaryTeleportRequest((long)this.SelectedMarkItem.TeleportId, this.SelectedMarkItem.MarkId);
				}
				base.Close();
			}
		}

		// Token: 0x060327EC RID: 206828 RVA: 0x00CA1F88 File Offset: 0x00CA0188
		private void UpdateButtonState()
		{
			ButtonItem middleCenterBtn = this.MiddleCenterBtn;
			if (middleCenterBtn != null)
			{
				middleCenterBtn.SetLocalText("TeleportFastMove", Array.Empty<object>());
			}
			OnlineModel instance = ModelBase<OnlineModel>.Instance;
			if (instance != null && instance.GetIsTeamModel())
			{
				base.SetDelBtnActive(ModelBase<OnlineModel>.Instance.GetIsMyTeam());
			}
			else
			{
				base.SetDelBtnActive(true);
			}
			ButtonItem middleCenterBtn2 = this.MiddleCenterBtn;
			if (middleCenterBtn2 == null)
			{
				return;
			}
			TemporaryTeleportMarkItem selectedMarkItem = this.SelectedMarkItem;
			middleCenterBtn2.SetEnableClick(selectedMarkItem == null || !selectedMarkItem.IsServerDisable);
		}

		// Token: 0x060327ED RID: 206829 RVA: 0x00CA2004 File Offset: 0x00CA0204
		private void UpdateMultiMap()
		{
			if (this.SelectedMarkItem == null)
			{
				return;
			}
			bool flag = this.SelectedMarkItem.ShowSecondaryUiMultiMapIcon();
			UUISprite sprite = base.GetSprite(11);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			string resourceId = flag ? "SP_MarkMultiMapSelect" : "SP_MarkTime";
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string path = (instance != null) ? instance.GetResourcePath(resourceId) : null;
			this.SetSpriteByPath(path, base.GetSprite(11), false, null, null);
		}

		// Token: 0x0401D73C RID: 120636
		[Nullable(2)]
		private TemporaryTeleportMarkItem SelectedMarkItem;

		// Token: 0x0200AC55 RID: 44117
		public static class EComponents
		{
			// Token: 0x04035960 RID: 219488
			public const int TemporaryTeleportPanel = 0;
		}
	}
}
