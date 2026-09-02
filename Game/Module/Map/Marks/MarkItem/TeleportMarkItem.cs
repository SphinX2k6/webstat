using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200585B RID: 22619
	[NullableContext(1)]
	[Nullable(0)]
	public class TeleportMarkItem : ConfigMarkItem
	{
		// Token: 0x170092DB RID: 37595
		// (get) Token: 0x06039882 RID: 235650 RVA: 0x00E9985C File Offset: 0x00E97A5C
		public override bool IsFogUnlock
		{
			get
			{
				if (this.MarkConfig.Value.ObjectType == 6)
				{
					return !this.IsLocked || base.IsFogUnlock;
				}
				return base.IsFogUnlock;
			}
		}

		// Token: 0x06039883 RID: 235651 RVA: 0x00E99896 File Offset: 0x00E97A96
		public TeleportMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x06039884 RID: 235652 RVA: 0x00E998AC File Offset: 0x00E97AAC
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.TeleportMarkItemView;
		}

		// Token: 0x06039885 RID: 235653 RVA: 0x00E998B0 File Offset: 0x00E97AB0
		[PreserveBaseOverrides]
		protected new virtual TeleportMarkItemView CreateView()
		{
			return new TeleportMarkItemView(this);
		}

		// Token: 0x170092DC RID: 37596
		// (get) Token: 0x06039886 RID: 235654 RVA: 0x00E998B8 File Offset: 0x00E97AB8
		// (set) Token: 0x06039887 RID: 235655 RVA: 0x00E998F4 File Offset: 0x00E97AF4
		public override string IconPath
		{
			get
			{
				if (!this.IsLocked)
				{
					return this.MarkConfig.Value.UnlockMarkPic;
				}
				return this.MarkConfig.Value.LockMarkPic;
			}
			set
			{
			}
		}

		// Token: 0x170092DD RID: 37597
		// (get) Token: 0x06039888 RID: 235656 RVA: 0x00E998F8 File Offset: 0x00E97AF8
		public bool IsActivity
		{
			get
			{
				return this.MarkConfig.Value.ObjectType == 13;
			}
		}

		// Token: 0x170092DE RID: 37598
		// (get) Token: 0x06039889 RID: 235657 RVA: 0x00E99920 File Offset: 0x00E97B20
		public bool IsDungeonEntrance
		{
			get
			{
				return this.MarkConfig.Value.RelativeType == 2 || ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckMarkIdLinkDungeonEntrance(base.MarkConfigId);
			}
		}

		// Token: 0x170092DF RID: 37599
		// (get) Token: 0x0603988A RID: 235658 RVA: 0x00E99955 File Offset: 0x00E97B55
		public bool IsTowerEntrance
		{
			get
			{
				return ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckMarkIdIsTowerEntrance(base.MarkConfigId);
			}
		}

		// Token: 0x170092E0 RID: 37600
		// (get) Token: 0x0603988B RID: 235659 RVA: 0x00E99967 File Offset: 0x00E97B67
		public bool IsRoguelike
		{
			get
			{
				return ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckMarkIdIsRoguelike(base.MarkConfigId);
			}
		}

		// Token: 0x170092E1 RID: 37601
		// (get) Token: 0x0603988C RID: 235660 RVA: 0x00E9997C File Offset: 0x00E97B7C
		public bool IsWeeklyRogue
		{
			get
			{
				InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(base.MarkConfigId);
				return dungeonConfig != null && dungeonConfig.Value.InstSubType == 29;
			}
		}

		// Token: 0x170092E2 RID: 37602
		// (get) Token: 0x0603988D RID: 235661 RVA: 0x00E999B8 File Offset: 0x00E97BB8
		public bool IsRogueRes
		{
			get
			{
				return ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckMarkIdIsRogueRes(base.MarkConfigId);
			}
		}

		// Token: 0x170092E3 RID: 37603
		// (get) Token: 0x0603988E RID: 235662 RVA: 0x00E999CA File Offset: 0x00E97BCA
		public bool IsShipTowerEntrance
		{
			get
			{
				return ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckMarkIdIsShipTowerEntrance(base.MarkConfigId);
			}
		}

		// Token: 0x170092E4 RID: 37604
		// (get) Token: 0x0603988F RID: 235663 RVA: 0x00E999DC File Offset: 0x00E97BDC
		public bool IsWheelTowerEntrance
		{
			get
			{
				return ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckMarkIdIsWheelTower(base.MarkConfigId);
			}
		}

		// Token: 0x06039890 RID: 235664 RVA: 0x00E999F0 File Offset: 0x00E97BF0
		public override bool IsMultiMap()
		{
			return this.MarkConfig.Value.MultiMapFloorId != 0;
		}

		// Token: 0x06039891 RID: 235665 RVA: 0x00E99A14 File Offset: 0x00E97C14
		public override int GetMultiMapId()
		{
			return this.MarkConfig.Value.MultiMapFloorId;
		}

		// Token: 0x06039892 RID: 235666 RVA: 0x00E99A34 File Offset: 0x00E97C34
		public override ESecondaryPanel GetSecondaryUiType()
		{
			if (this.IsActivity)
			{
				return base.GetSecondaryUiType();
			}
			if (!this.IsDungeonEntrance)
			{
				return ESecondaryPanel.TeleportPanel;
			}
			if (this.IsTowerEntrance)
			{
				return ESecondaryPanel.TowerEntrancePanel;
			}
			if (this.IsRoguelike)
			{
				return ESecondaryPanel.RoguelikePanel;
			}
			if (this.IsWeeklyRogue)
			{
				return ESecondaryPanel.WeeklyRoguePanel;
			}
			if (this.IsRogueRes)
			{
				return ESecondaryPanel.RogueResPanel;
			}
			if (this.IsShipTowerEntrance)
			{
				return ESecondaryPanel.ShipTowerEntrancePanel;
			}
			if (this.IsWheelTowerEntrance)
			{
				return ESecondaryPanel.WheelTowerEntrancePanel;
			}
			return ESecondaryPanel.InstanceDungeonEntrancePanel;
		}

		// Token: 0x04020AA9 RID: 133801
		[Nullable(2)]
		public TeleportMarkItemView InnerView;

		// Token: 0x04020AAA RID: 133802
		public bool IsDirty;
	}
}
