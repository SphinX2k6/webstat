using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200584B RID: 22603
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrRoadMarkItem : ConfigMarkItem
	{
		// Token: 0x0603975F RID: 235359 RVA: 0x00E95BB0 File Offset: 0x00E93DB0
		public InfrRoadMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x06039760 RID: 235360 RVA: 0x00E95BC6 File Offset: 0x00E93DC6
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.UpdateGamePlayState();
		}

		// Token: 0x06039761 RID: 235361 RVA: 0x00E95BD4 File Offset: 0x00E93DD4
		[PreserveBaseOverrides]
		protected new virtual InfrRoadMarkItemView CreateView()
		{
			return new InfrRoadMarkItemView(this);
		}

		// Token: 0x06039762 RID: 235362 RVA: 0x00E95BDC File Offset: 0x00E93DDC
		protected override bool GamePlayIsFinish()
		{
			InfrRoadBuild? roadConfigByMarkId = ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigByMarkId(this.MarkId);
			InfrastructureDefine.IInfrRoadData roadDataByRoadId = ModelBase<InfrastructureModel>.Instance.GetRoadDataByRoadId(roadConfigByMarkId.Value.Id);
			return roadDataByRoadId != null && roadDataByRoadId.Status == InfrStatusPb.InfrStatusComplete;
		}

		// Token: 0x06039763 RID: 235363 RVA: 0x00E95C21 File Offset: 0x00E93E21
		public void UpdateGamePlayState()
		{
			base.MarkItemEntity.GamePlay.GamePlayState = (this.GamePlayIsFinish() ? EMarkGamePlayState.Finish : EMarkGamePlayState.Processing);
		}

		// Token: 0x04020A55 RID: 133717
		[Nullable(2)]
		public InfrRoadMarkItemView InnerView;
	}
}
