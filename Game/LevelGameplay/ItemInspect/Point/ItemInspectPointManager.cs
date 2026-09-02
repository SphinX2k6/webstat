using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Point
{
	// Token: 0x02006E52 RID: 28242
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ItemInspectPointManager
	{
		// Token: 0x060448D1 RID: 280785
		public abstract void Init(ISequenceUnlockPoints config);

		// Token: 0x060448D2 RID: 280786 RVA: 0x011D2A44 File Offset: 0x011D0C44
		protected ItemInspectPoint CreatePoint(IInteractPoint config)
		{
			ItemInspectPoint itemInspectPoint = new ItemInspectPoint();
			itemInspectPoint.EffectConfigs = config.InteractEffects;
			int tag = config.Tag;
			itemInspectPoint.TagId = tag;
			itemInspectPoint.CancelTrace = config.CancelRaycast.GetValueOrDefault();
			itemInspectPoint.ProtectTime = config.ProtectTime.GetValueOrDefault();
			itemInspectPoint.InteractionConfig = config.InteractionConfig;
			this.TagIdToPointMap[tag] = itemInspectPoint;
			bool isValidPoint = config.IsValidPoint;
			itemInspectPoint.IsValid = isValidPoint;
			if (isValidPoint)
			{
				this.MaxValidCount++;
			}
			return itemInspectPoint;
		}

		// Token: 0x060448D3 RID: 280787 RVA: 0x011D2AD3 File Offset: 0x011D0CD3
		protected virtual bool IsCurrentStageComplete()
		{
			return false;
		}

		// Token: 0x060448D4 RID: 280788 RVA: 0x011D2AD6 File Offset: 0x011D0CD6
		public int GetMaxValidCount()
		{
			return this.MaxValidCount;
		}

		// Token: 0x060448D5 RID: 280789 RVA: 0x011D2ADE File Offset: 0x011D0CDE
		public int GetCheckedValidCount()
		{
			return this.CheckedValidCount;
		}

		// Token: 0x060448D6 RID: 280790 RVA: 0x011D2AE8 File Offset: 0x011D0CE8
		[NullableContext(2)]
		public ItemInspectPoint GetPoint(int tagId)
		{
			ItemInspectPoint result;
			if (this.TagIdToPointMap.TryGetValue(tagId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060448D7 RID: 280791 RVA: 0x011D2B08 File Offset: 0x011D0D08
		public bool CheckPoint(int tagId)
		{
			ItemInspectPoint itemInspectPoint;
			if (!this.TagIdToPointMap.TryGetValue(tagId, out itemInspectPoint))
			{
				return false;
			}
			if (itemInspectPoint.IsChecked)
			{
				return false;
			}
			itemInspectPoint.IsChecked = true;
			this.CheckedValidCount++;
			return this.IsCurrentStageComplete();
		}

		// Token: 0x060448D8 RID: 280792 RVA: 0x011D2B4C File Offset: 0x011D0D4C
		public virtual EInteractPointInteractionType? GetCurrentStageInteractionType()
		{
			return null;
		}

		// Token: 0x060448D9 RID: 280793 RVA: 0x011D2B62 File Offset: 0x011D0D62
		[NullableContext(2)]
		public virtual ItemInspectPoint GetCurrentStageDragPoint()
		{
			return null;
		}

		// Token: 0x060448DA RID: 280794 RVA: 0x011D2B65 File Offset: 0x011D0D65
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public virtual List<IInteractEffect> GetCurrentStageEnterEffects()
		{
			return null;
		}

		// Token: 0x060448DB RID: 280795 RVA: 0x011D2B68 File Offset: 0x011D0D68
		public virtual bool ShouldResetAfterCurrentStageEnd()
		{
			return false;
		}

		// Token: 0x060448DC RID: 280796 RVA: 0x011D2B6B File Offset: 0x011D0D6B
		public virtual bool HasNextStage()
		{
			return false;
		}

		// Token: 0x060448DD RID: 280797 RVA: 0x011D2B6E File Offset: 0x011D0D6E
		public virtual bool AdvanceToNextStage()
		{
			return false;
		}

		// Token: 0x060448DE RID: 280798 RVA: 0x011D2B71 File Offset: 0x011D0D71
		public virtual void ActivateCurrentStage()
		{
		}

		// Token: 0x040262A3 RID: 156323
		private readonly Dictionary<int, ItemInspectPoint> TagIdToPointMap = new Dictionary<int, ItemInspectPoint>();

		// Token: 0x040262A4 RID: 156324
		private int MaxValidCount;

		// Token: 0x040262A5 RID: 156325
		private int CheckedValidCount;
	}
}
