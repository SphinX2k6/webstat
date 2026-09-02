using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052DE RID: 21214
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackSceneItemHighlightManager : QuickHackHighlightManager
	{
		// Token: 0x060362E2 RID: 221922 RVA: 0x00DA58C8 File Offset: 0x00DA3AC8
		public override void RefreshTargetsHighlight(IEnumerable<EntityHandle> lockTargets, IEnumerable<EntityHandle> onScreenTargets)
		{
			foreach (EntityHandle entityHandle in lockTargets)
			{
				this.ShowGuideLine(entityHandle);
			}
			foreach (EntityHandle entityHandle2 in onScreenTargets)
			{
				this.ShowGuideLine(entityHandle2);
			}
		}

		// Token: 0x060362E3 RID: 221923 RVA: 0x00DA5948 File Offset: 0x00DA3B48
		public override void RemoveAllHighlight()
		{
			foreach (EntityHandle entityHandle in this.ShowGuideLineEntitySet)
			{
				if (entityHandle != null)
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity != null)
					{
						SceneItemQuickHackComponent component = entity.GetComponent<SceneItemQuickHackComponent>();
						if (component != null)
						{
							component.StopGuideLine();
						}
					}
				}
			}
			this.ShowGuideLineEntitySet.Clear();
			this.CheckedEntityIdSet.Clear();
		}

		// Token: 0x060362E4 RID: 221924 RVA: 0x00DA59CC File Offset: 0x00DA3BCC
		private void ShowGuideLine(EntityHandle entityHandle)
		{
			int id = entityHandle.Id;
			if (this.CheckedEntityIdSet.Contains(id))
			{
				return;
			}
			this.CheckedEntityIdSet.Add(id);
			SceneItemQuickHackComponent sceneItemQuickHackComponent;
			if (entityHandle == null)
			{
				sceneItemQuickHackComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				sceneItemQuickHackComponent = ((entity != null) ? entity.GetComponent<SceneItemQuickHackComponent>() : null);
			}
			SceneItemQuickHackComponent sceneItemQuickHackComponent2 = sceneItemQuickHackComponent;
			if (sceneItemQuickHackComponent2 == null)
			{
				return;
			}
			if (sceneItemQuickHackComponent2.ShowGuideLine())
			{
				this.ShowGuideLineEntitySet.Add(entityHandle);
			}
		}

		// Token: 0x0401F219 RID: 127513
		private readonly HashSet<int> CheckedEntityIdSet = new HashSet<int>();

		// Token: 0x0401F21A RID: 127514
		private readonly HashSet<EntityHandle> ShowGuideLineEntitySet = new HashSet<EntityHandle>();
	}
}
