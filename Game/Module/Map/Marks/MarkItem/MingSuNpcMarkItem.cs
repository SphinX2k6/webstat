using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.MingSu;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200584F RID: 22607
	[NullableContext(1)]
	[Nullable(0)]
	public class MingSuNpcMarkItem : ConfigMarkItem
	{
		// Token: 0x060397F4 RID: 235508 RVA: 0x00E971A9 File Offset: 0x00E953A9
		public MingSuNpcMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x060397F5 RID: 235509 RVA: 0x00E971BF File Offset: 0x00E953BF
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.MingSuNpcMarkItemView;
		}

		// Token: 0x060397F6 RID: 235510 RVA: 0x00E971C3 File Offset: 0x00E953C3
		[PreserveBaseOverrides]
		protected new virtual MingSuNpcMarkItemView CreateView()
		{
			return new MingSuNpcMarkItemView(this);
		}

		// Token: 0x170092C4 RID: 37572
		// (get) Token: 0x060397F7 RID: 235511 RVA: 0x00E971CB File Offset: 0x00E953CB
		public bool IsTowerEntrance
		{
			get
			{
				return ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckMarkIdIsTowerEntrance(base.MarkConfigId);
			}
		}

		// Token: 0x060397F8 RID: 235512 RVA: 0x00E971E0 File Offset: 0x00E953E0
		protected override bool GamePlayIsFinish()
		{
			MapMark value = this.MarkConfig.Value;
			if (value.RelativeType == 1 && this.MarkConfig.Value.RelativeSubType == 5)
			{
				int relativeId = value.RelativeId;
				return ModelBase<MingSuModel>.Instance.GetDarkCoastDeliveryDataByLevelPlayId(relativeId).GetDarkCoastDeliveryGuardState() == MingSuDefine.EDarkCoastDeliveryLevelDataState.Received;
			}
			return false;
		}

		// Token: 0x060397F9 RID: 235513 RVA: 0x00E97236 File Offset: 0x00E95436
		protected override void InitIcon()
		{
			this.UpdateIconPath();
		}

		// Token: 0x060397FA RID: 235514 RVA: 0x00E97240 File Offset: 0x00E95440
		public override void UpdateIconPath()
		{
			if (this.MarkConfig.Value.RelativeSubType != 11)
			{
				this.IconPath = this.MarkConfig.Value.LockMarkPic;
				return;
			}
			if (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male)
			{
				this.IconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMapNpc009");
				return;
			}
			this.IconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconMapNpc010");
		}
	}
}
