using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.VillageInfr;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005861 RID: 22625
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrTreeMarkItem : ConfigMarkItem
	{
		// Token: 0x060398C8 RID: 235720 RVA: 0x00E9A224 File Offset: 0x00E98424
		public VillageInfrTreeMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x060398C9 RID: 235721 RVA: 0x00E9A23A File Offset: 0x00E9843A
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.UpdateGamePlayState();
		}

		// Token: 0x170092F0 RID: 37616
		// (get) Token: 0x060398CA RID: 235722 RVA: 0x00E9A248 File Offset: 0x00E98448
		// (set) Token: 0x060398CB RID: 235723 RVA: 0x00E9A284 File Offset: 0x00E98484
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

		// Token: 0x060398CC RID: 235724 RVA: 0x00E9A286 File Offset: 0x00E98486
		[PreserveBaseOverrides]
		protected new virtual VillageInfrTreeMarkItemView CreateView()
		{
			return new VillageInfrTreeMarkItemView(this);
		}

		// Token: 0x060398CD RID: 235725 RVA: 0x00E9A290 File Offset: 0x00E98490
		protected override bool GamePlayIsFinish()
		{
			InfrV2TreeBuild? treeConfigByMarkId = ConfigBase<VillageInfrConfig>.Instance.GetTreeConfigByMarkId(this.MarkId);
			IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(treeConfigByMarkId.Value.Id);
			return treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusComplete;
		}

		// Token: 0x060398CE RID: 235726 RVA: 0x00E9A2D5 File Offset: 0x00E984D5
		public void UpdateGamePlayState()
		{
			base.MarkItemEntity.GamePlay.GamePlayState = (this.GamePlayIsFinish() ? EMarkGamePlayState.Finish : EMarkGamePlayState.Processing);
		}

		// Token: 0x04020AB2 RID: 133810
		[Nullable(2)]
		public VillageInfrTreeMarkItemView InnerView;
	}
}
