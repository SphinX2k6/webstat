using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052DF RID: 21215
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackTagHighlightManager : QuickHackHighlightManager
	{
		// Token: 0x060362E6 RID: 221926 RVA: 0x00DA5A4C File Offset: 0x00DA3C4C
		public override void Init(QuickHackDevice config)
		{
			base.Init(config);
			string selectTargetTag = config.SelectTargetTag;
			string onScreenTargetTag = config.OnScreenTargetTag;
			if (!StringUtils.IsBlank(selectTargetTag))
			{
				this.LockTargetTagId = GameplayTagUtils.GetTagIdByName(selectTargetTag);
			}
			if (!StringUtils.IsBlank(onScreenTargetTag))
			{
				this.OnScreenTargetTagId = GameplayTagUtils.GetTagIdByName(onScreenTargetTag);
			}
		}

		// Token: 0x060362E7 RID: 221927 RVA: 0x00DA5A98 File Offset: 0x00DA3C98
		public override void RefreshTargetsHighlight(IEnumerable<EntityHandle> lockTargets, IEnumerable<EntityHandle> onScreenTargets)
		{
			IQuickHackHighlightPreProcessResult quickHackHighlightPreProcessResult = base.PreProcessSelectAndOnScreenTargets(lockTargets, onScreenTargets);
			HashSet<EntityHandle> newOnScreenTargetSet = quickHackHighlightPreProcessResult.NewOnScreenTargetSet;
			HashSet<EntityHandle> newLockTargetSet = quickHackHighlightPreProcessResult.NewLockTargetSet;
			if (this.OnScreenTargetTagId != 0)
			{
				this.RefreshTargetsTag(this.OnScreenTargetTagId, newOnScreenTargetSet, this.OnScreenTargetSet);
			}
			if (this.LockTargetTagId != 0)
			{
				this.RefreshTargetsTag(this.LockTargetTagId, newLockTargetSet, this.LockTargetSet);
			}
		}

		// Token: 0x060362E8 RID: 221928 RVA: 0x00DA5AF0 File Offset: 0x00DA3CF0
		public override void RemoveAllHighlight()
		{
			if (this.OnScreenTargetTagId != 0)
			{
				this.ClearTargetsTag(this.OnScreenTargetTagId, this.OnScreenTargetSet);
			}
			if (this.LockTargetTagId != 0)
			{
				this.ClearTargetsTag(this.LockTargetTagId, this.LockTargetSet);
			}
		}

		// Token: 0x060362E9 RID: 221929 RVA: 0x00DA5B28 File Offset: 0x00DA3D28
		private void RefreshTargetsTag(int tagId, HashSet<EntityHandle> newTargetSet, HashSet<EntityHandle> currentTargetSet)
		{
			List<EntityHandle> list = new List<EntityHandle>();
			foreach (EntityHandle entityHandle in currentTargetSet)
			{
				if (!newTargetSet.Remove(entityHandle))
				{
					list.Add(entityHandle);
					if (entityHandle != null && entityHandle.Valid)
					{
						BaseTagComponent component = entityHandle.Entity.GetComponent<BaseTagComponent>();
						if (component != null)
						{
							component.RemoveTag(new int?(tagId));
						}
					}
				}
			}
			foreach (EntityHandle item in list)
			{
				currentTargetSet.Remove(item);
			}
			foreach (EntityHandle entityHandle2 in newTargetSet)
			{
				if (entityHandle2 != null && entityHandle2.Valid)
				{
					BaseTagComponent component2 = entityHandle2.Entity.GetComponent<BaseTagComponent>();
					if (component2 != null)
					{
						component2.AddTag(new int?(tagId));
						currentTargetSet.Add(entityHandle2);
					}
				}
			}
		}

		// Token: 0x060362EA RID: 221930 RVA: 0x00DA5C68 File Offset: 0x00DA3E68
		private void ClearTargetsTag(int tagId, HashSet<EntityHandle> targetSet)
		{
			foreach (EntityHandle entityHandle in targetSet)
			{
				if (entityHandle != null && entityHandle.Valid)
				{
					BaseTagComponent component = entityHandle.Entity.GetComponent<BaseTagComponent>();
					if (component != null)
					{
						component.RemoveTag(new int?(tagId));
					}
				}
			}
			targetSet.Clear();
		}

		// Token: 0x0401F21B RID: 127515
		private int LockTargetTagId;

		// Token: 0x0401F21C RID: 127516
		private int OnScreenTargetTagId;

		// Token: 0x0401F21D RID: 127517
		private readonly HashSet<EntityHandle> LockTargetSet = new HashSet<EntityHandle>();

		// Token: 0x0401F21E RID: 127518
		private readonly HashSet<EntityHandle> OnScreenTargetSet = new HashSet<EntityHandle>();
	}
}
