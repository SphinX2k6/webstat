using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200583C RID: 22588
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabMachineMarkItem : ConfigMarkItem
	{
		// Token: 0x060396D0 RID: 235216 RVA: 0x00E94473 File Offset: 0x00E92673
		public DollGrabMachineMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x060396D1 RID: 235217 RVA: 0x00E94489 File Offset: 0x00E92689
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.UpdateGamePlayState();
		}

		// Token: 0x060396D2 RID: 235218 RVA: 0x00E94497 File Offset: 0x00E92697
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.DollGrabMachineMarkItemView;
		}

		// Token: 0x060396D3 RID: 235219 RVA: 0x00E9449B File Offset: 0x00E9269B
		protected override MarkItemView CreateView()
		{
			return new DollGrabMachineMarkItemView(this);
		}

		// Token: 0x060396D4 RID: 235220 RVA: 0x00E944A4 File Offset: 0x00E926A4
		public int GetEntityId()
		{
			if (this.MarkConfig == null)
			{
				return 0;
			}
			return this.MarkConfig.GetValueOrDefault().EntityConfigId;
		}

		// Token: 0x060396D5 RID: 235221 RVA: 0x00E944D0 File Offset: 0x00E926D0
		protected void UpdateGamePlayState()
		{
			int entityId = this.GetEntityId();
			if (ModelBase<MapModel>.Instance.IsMarkHideByServer(this.MapId, entityId))
			{
				base.MarkItemEntity.GamePlay.GamePlayState = EMarkGamePlayState.Hide;
				return;
			}
			base.MarkItemEntity.GamePlay.GamePlayState = (ModelBase<DollGrabModel>.Instance.IsDollGrabMachineDeliveryComplete(this.MapId, entityId) ? EMarkGamePlayState.Finish : EMarkGamePlayState.Processing);
		}
	}
}
