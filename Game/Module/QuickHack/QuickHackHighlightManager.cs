using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052DD RID: 21213
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class QuickHackHighlightManager
	{
		// Token: 0x060362DC RID: 221916 RVA: 0x00DA5800 File Offset: 0x00DA3A00
		public virtual void Init(QuickHackDevice config)
		{
			this.UseTargetHighlightCondition = config.UseTargetHighlightCondition;
		}

		// Token: 0x060362DD RID: 221917 RVA: 0x00DA580F File Offset: 0x00DA3A0F
		public void Clear()
		{
			this.RemoveAllHighlight();
		}

		// Token: 0x060362DE RID: 221918
		public abstract void RefreshTargetsHighlight(IEnumerable<EntityHandle> lockTargets, IEnumerable<EntityHandle> onScreenTargets);

		// Token: 0x060362DF RID: 221919
		public abstract void RemoveAllHighlight();

		// Token: 0x060362E0 RID: 221920 RVA: 0x00DA5818 File Offset: 0x00DA3A18
		protected IQuickHackHighlightPreProcessResult PreProcessSelectAndOnScreenTargets(IEnumerable<EntityHandle> lockTargets, IEnumerable<EntityHandle> onScreenTargets)
		{
			HashSet<EntityHandle> hashSet = new HashSet<EntityHandle>(onScreenTargets);
			HashSet<EntityHandle> hashSet2 = new HashSet<EntityHandle>(lockTargets);
			QuickHackSkillInstance currentSelectSkill = ModelBase<QuickHackModel>.Instance.CurrentSelectSkill;
			foreach (EntityHandle entityHandle in hashSet2)
			{
				if (this.UseTargetHighlightCondition && currentSelectSkill != null && !currentSelectSkill.CheckTargetExtraConditions(entityHandle))
				{
					hashSet2.Remove(entityHandle);
					hashSet.Add(entityHandle);
				}
				else
				{
					hashSet.Remove(entityHandle);
				}
			}
			return new QuickHackHighlightPreProcessResult
			{
				NewOnScreenTargetSet = hashSet,
				NewLockTargetSet = hashSet2
			};
		}

		// Token: 0x0401F218 RID: 127512
		private bool UseTargetHighlightCondition;
	}
}
