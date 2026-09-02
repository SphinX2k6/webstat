using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200585C RID: 22620
	[NullableContext(1)]
	[Nullable(0)]
	public class TemporaryTeleportMarkItem : ServerMarkItem
	{
		// Token: 0x170092E5 RID: 37605
		// (get) Token: 0x06039893 RID: 235667 RVA: 0x00E99A9C File Offset: 0x00E97C9C
		public int TeleportId
		{
			get
			{
				DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
				return ((serverMarkInfo != null) ? serverMarkInfo.TeleportId : null).GetValueOrDefault();
			}
		}

		// Token: 0x170092E6 RID: 37606
		// (get) Token: 0x06039894 RID: 235668 RVA: 0x00E99ACB File Offset: 0x00E97CCB
		public override EMarkType MarkType
		{
			get
			{
				return EMarkType.TemporaryTeleport;
			}
		}

		// Token: 0x170092E7 RID: 37607
		// (get) Token: 0x06039895 RID: 235669 RVA: 0x00E99ACF File Offset: 0x00E97CCF
		public bool IsNewCustomMarkItem
		{
			get
			{
				return this.IsNew;
			}
		}

		// Token: 0x06039896 RID: 235670 RVA: 0x00E99AD7 File Offset: 0x00E97CD7
		protected override void OnUpdate(global::Vector playerLocation)
		{
			base.OnUpdate(playerLocation);
			if (base.MapType == EMapType.MiniMap)
			{
				this.UpdateMultiMapFloorSelectedState();
			}
		}

		// Token: 0x06039897 RID: 235671 RVA: 0x00E99AF0 File Offset: 0x00E97CF0
		private void UpdateViewIcon()
		{
			if (base.View != null && !base.IsDestroy)
			{
				TemporaryTeleportMarkItemView temporaryTeleportMarkItemView = base.View as TemporaryTeleportMarkItemView;
				if (temporaryTeleportMarkItemView != null)
				{
					temporaryTeleportMarkItemView.UpdateIcon();
				}
			}
		}

		// Token: 0x06039898 RID: 235672 RVA: 0x00E99B22 File Offset: 0x00E97D22
		public void UpdateMultiMapFloorSelectedState()
		{
			bool isSelectThisFloor = base.IsSelectThisFloor;
			base.IsSelectThisFloor = this.GetIsSelectThisFloor();
			if (isSelectThisFloor != base.IsSelectThisFloor)
			{
				this.UpdateViewIcon();
			}
		}

		// Token: 0x06039899 RID: 235673 RVA: 0x00E99B44 File Offset: 0x00E97D44
		public override bool ShowSecondaryUiMultiMapIcon()
		{
			return this.IsMultiMap();
		}

		// Token: 0x0603989A RID: 235674 RVA: 0x00E99B4C File Offset: 0x00E97D4C
		public override int GetMultiMapId()
		{
			int? trackAreaId = this.TrackAreaId;
			int num = 0;
			if (trackAreaId.GetValueOrDefault() == num & trackAreaId != null)
			{
				return 0;
			}
			return base.GetMultiMapIdSub();
		}

		// Token: 0x170092E8 RID: 37608
		// (get) Token: 0x0603989B RID: 235675 RVA: 0x00E99B80 File Offset: 0x00E97D80
		public override int? TrackAreaId
		{
			get
			{
				DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
				return new int?(((serverMarkInfo != null) ? serverMarkInfo.AreaId : null).GetValueOrDefault());
			}
		}

		// Token: 0x0603989C RID: 235676 RVA: 0x00E99BB4 File Offset: 0x00E97DB4
		public TemporaryTeleportMarkItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x0603989D RID: 235677 RVA: 0x00E99BC4 File Offset: 0x00E97DC4
		protected override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			base.SetTrackData(serverMarkInfo.TrackTarget);
			this.SetConfigId(base.ConfigId);
			this.UpdateVisibleRelativeState();
			this.UpdateMultiMapFloorSelectedState();
		}

		// Token: 0x0603989E RID: 235678 RVA: 0x00E99C02 File Offset: 0x00E97E02
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.TemporaryTeleportMarkItemView;
		}

		// Token: 0x0603989F RID: 235679 RVA: 0x00E99C06 File Offset: 0x00E97E06
		[PreserveBaseOverrides]
		protected new virtual TemporaryTeleportMarkItemView CreateView()
		{
			return new TemporaryTeleportMarkItemView(this);
		}

		// Token: 0x060398A0 RID: 235680 RVA: 0x00E99C0E File Offset: 0x00E97E0E
		public void SetConfigId(int configId)
		{
			this.ServerMarkInfo.MarkConfigId = configId;
			this.OnSetConfigId(configId);
		}

		// Token: 0x060398A1 RID: 235681 RVA: 0x00E99C24 File Offset: 0x00E97E24
		public void OnSetConfigId(int configId)
		{
			TemporaryTeleportMark? temporaryTeleportMarkConfigById = ConfigBase<MapConfig>.Instance.GetTemporaryTeleportMarkConfigById(configId);
			this.OnAfterSetConfigId(new MarkItemData
			{
				MarkPic = temporaryTeleportMarkConfigById.Value.MarkPic,
				Scale = new float?(temporaryTeleportMarkConfigById.Value.Scale),
				ShowPriority = new int?(temporaryTeleportMarkConfigById.Value.ShowPriority),
				ShowRange = temporaryTeleportMarkConfigById.Value.ShowRange()
			});
		}

		// Token: 0x060398A2 RID: 235682 RVA: 0x00E99CA6 File Offset: 0x00E97EA6
		public void SetIsNew(bool isNew)
		{
			this.IsNew = isNew;
		}

		// Token: 0x060398A3 RID: 235683 RVA: 0x00E99CB0 File Offset: 0x00E97EB0
		[NullableContext(2)]
		public override string GetTitleText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetTemporaryTeleportMarkConfigById(base.ConfigId).Value.MarkTitle, null);
		}

		// Token: 0x060398A4 RID: 235684 RVA: 0x00E99CE4 File Offset: 0x00E97EE4
		[NullableContext(2)]
		public string GetDescText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetTemporaryTeleportMarkConfigById(base.ConfigId).Value.MarkDesc, null);
		}

		// Token: 0x04020AAB RID: 133803
		private bool IsNew;
	}
}
