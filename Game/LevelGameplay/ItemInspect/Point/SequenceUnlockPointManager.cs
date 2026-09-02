using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Point
{
	// Token: 0x02006E54 RID: 28244
	[NullableContext(1)]
	[Nullable(0)]
	public class SequenceUnlockPointManager : ItemInspectPointManager
	{
		// Token: 0x060448E1 RID: 280801 RVA: 0x011D2BB4 File Offset: 0x011D0DB4
		public override void Init(ISequenceUnlockPoints config)
		{
			foreach (ISequenceInteractStage sequenceInteractStage in config.Stages)
			{
				List<ItemInspectPoint> list = new List<ItemInspectPoint>();
				foreach (IInteractPoint config2 in sequenceInteractStage.InteractPoints)
				{
					list.Add(base.CreatePoint(config2));
				}
				this.PointGroups.Add(list);
				this.StageConfigs.Add(sequenceInteractStage);
			}
		}

		// Token: 0x060448E2 RID: 280802 RVA: 0x011D2C68 File Offset: 0x011D0E68
		protected override bool IsCurrentStageComplete()
		{
			if (this.CurrentStageIndex >= this.PointGroups.Count)
			{
				return false;
			}
			using (List<ItemInspectPoint>.Enumerator enumerator = this.PointGroups[this.CurrentStageIndex].GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsChecked)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060448E3 RID: 280803 RVA: 0x011D2CE4 File Offset: 0x011D0EE4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override List<IInteractEffect> GetCurrentStageEnterEffects()
		{
			ISequenceInteractStage sequenceInteractStage = this.StageConfigs.ElementAtOrDefault(this.CurrentStageIndex);
			if (sequenceInteractStage == null)
			{
				return null;
			}
			return sequenceInteractStage.EnterStageEffects;
		}

		// Token: 0x060448E4 RID: 280804 RVA: 0x011D2D04 File Offset: 0x011D0F04
		public override bool ShouldResetAfterCurrentStageEnd()
		{
			ISequenceInteractStage sequenceInteractStage = this.StageConfigs.ElementAtOrDefault(this.CurrentStageIndex);
			return sequenceInteractStage != null && sequenceInteractStage.IsResetAfterStageEnd.GetValueOrDefault();
		}

		// Token: 0x060448E5 RID: 280805 RVA: 0x011D2D35 File Offset: 0x011D0F35
		public override bool HasNextStage()
		{
			return this.CurrentStageIndex + 1 < this.PointGroups.Count;
		}

		// Token: 0x060448E6 RID: 280806 RVA: 0x011D2D4C File Offset: 0x011D0F4C
		public override bool AdvanceToNextStage()
		{
			if (!this.HasNextStage())
			{
				return false;
			}
			this.CurrentStageIndex++;
			return true;
		}

		// Token: 0x060448E7 RID: 280807 RVA: 0x011D2D68 File Offset: 0x011D0F68
		public override void ActivateCurrentStage()
		{
			List<ItemInspectPoint> list = this.PointGroups.ElementAtOrDefault(this.CurrentStageIndex);
			if (list == null)
			{
				return;
			}
			foreach (ItemInspectPoint itemInspectPoint in list)
			{
				itemInspectPoint.IsActive = true;
			}
		}

		// Token: 0x060448E8 RID: 280808 RVA: 0x011D2DCC File Offset: 0x011D0FCC
		public override EInteractPointInteractionType? GetCurrentStageInteractionType()
		{
			List<ItemInspectPoint> list = this.PointGroups.ElementAtOrDefault(this.CurrentStageIndex);
			if (list == null)
			{
				return null;
			}
			ItemInspectPoint itemInspectPoint = list.ElementAtOrDefault(0);
			if (itemInspectPoint == null)
			{
				return null;
			}
			IInteractPointInteraction interactionConfig = itemInspectPoint.InteractionConfig;
			if (interactionConfig == null)
			{
				return null;
			}
			return new EInteractPointInteractionType?(interactionConfig.Type);
		}

		// Token: 0x060448E9 RID: 280809 RVA: 0x011D2E2C File Offset: 0x011D102C
		[NullableContext(2)]
		public override ItemInspectPoint GetCurrentStageDragPoint()
		{
			List<ItemInspectPoint> list = this.PointGroups.ElementAtOrDefault(this.CurrentStageIndex);
			if (list == null)
			{
				return null;
			}
			ItemInspectPoint itemInspectPoint = null;
			foreach (ItemInspectPoint itemInspectPoint2 in list)
			{
				IInteractPointInteraction interactionConfig = itemInspectPoint2.InteractionConfig;
				if (interactionConfig != null && interactionConfig.Type <= EInteractPointInteractionType.Drag)
				{
					if (itemInspectPoint != null)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.LevelPlay;
						ELogAuthor author = ELogAuthor.FZX;
						string message = "物品检视，同一阶段配置了多个拖拽交互点，取第一个";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("阶段", this.CurrentStageIndex);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						break;
					}
					itemInspectPoint = itemInspectPoint2;
				}
			}
			return itemInspectPoint;
		}

		// Token: 0x040262A6 RID: 156326
		private int CurrentStageIndex;

		// Token: 0x040262A7 RID: 156327
		private readonly List<List<ItemInspectPoint>> PointGroups = new List<List<ItemInspectPoint>>();

		// Token: 0x040262A8 RID: 156328
		private readonly List<ISequenceInteractStage> StageConfigs = new List<ISequenceInteractStage>();
	}
}
