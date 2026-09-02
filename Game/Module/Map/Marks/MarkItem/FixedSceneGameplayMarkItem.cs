using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005845 RID: 22597
	[NullableContext(1)]
	[Nullable(0)]
	public class FixedSceneGameplayMarkItem : ConfigMarkItem
	{
		// Token: 0x06039729 RID: 235305 RVA: 0x00E9548A File Offset: 0x00E9368A
		public FixedSceneGameplayMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x0603972A RID: 235306 RVA: 0x00E954A0 File Offset: 0x00E936A0
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.FixedSceneGamePlayMarkItemView;
		}

		// Token: 0x0603972B RID: 235307 RVA: 0x00E954A4 File Offset: 0x00E936A4
		[PreserveBaseOverrides]
		protected new virtual FixedSceneGamePlayMarkItemView CreateView()
		{
			return new FixedSceneGamePlayMarkItemView(this);
		}

		// Token: 0x0603972C RID: 235308 RVA: 0x00E954AC File Offset: 0x00E936AC
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.UpdateMultiMapFloorSelectedState();
		}

		// Token: 0x0603972D RID: 235309 RVA: 0x00E954BC File Offset: 0x00E936BC
		protected override void InitIcon()
		{
			LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo((this.MarkConfig != null) ? this.MarkConfig.GetValueOrDefault().RelativeId : 0);
			if (levelPlayInfo == null || levelPlayInfo.IsClose)
			{
				this.IconPath = (((this.MarkConfig != null) ? this.MarkConfig.GetValueOrDefault().LockMarkPic : null) ?? "");
				return;
			}
			this.IconPath = (((this.MarkConfig != null) ? this.MarkConfig.GetValueOrDefault().UnlockMarkPic : null) ?? "");
		}

		// Token: 0x0603972E RID: 235310 RVA: 0x00E9555C File Offset: 0x00E9375C
		public override bool IsMultiMap()
		{
			return this.MarkConfig == null || this.MarkConfig.GetValueOrDefault().MultiMapFloorId != 0;
		}

		// Token: 0x0603972F RID: 235311 RVA: 0x00E9558C File Offset: 0x00E9378C
		public override int GetMultiMapId()
		{
			if (this.MarkConfig == null)
			{
				return 0;
			}
			return this.MarkConfig.GetValueOrDefault().MultiMapFloorId;
		}

		// Token: 0x06039730 RID: 235312 RVA: 0x00E955B7 File Offset: 0x00E937B7
		protected override void OnUpdate(global::Vector playerLocation)
		{
			base.OnUpdate(playerLocation);
			if (base.MapType == EMapType.MiniMap)
			{
				this.UpdateMultiMapFloorSelectedState();
			}
		}

		// Token: 0x06039731 RID: 235313 RVA: 0x00E955CF File Offset: 0x00E937CF
		private void UpdateMultiMapFloorSelectedState()
		{
			bool isSelectThisFloor = base.IsSelectThisFloor;
			base.IsSelectThisFloor = this.GetIsSelectThisFloor();
			if (isSelectThisFloor != base.IsSelectThisFloor)
			{
				base.UpdateViewIcon();
			}
		}

		// Token: 0x06039732 RID: 235314 RVA: 0x00E955F1 File Offset: 0x00E937F1
		public override ESecondaryPanel GetSecondaryUiType()
		{
			if (this.MarkType == EMarkType.CorniceMeeting)
			{
				return ESecondaryPanel.CorniceMeetingPanel;
			}
			if (base.IsLordGym() || base.IsNewLordGym())
			{
				return ESecondaryPanel.LordGymPanel;
			}
			return ESecondaryPanel.SceneGameplayPanel;
		}
	}
}
