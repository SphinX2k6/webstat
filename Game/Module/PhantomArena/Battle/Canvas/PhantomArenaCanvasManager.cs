using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Canvas
{
	// Token: 0x0200562B RID: 22059
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCanvasManager
	{
		// Token: 0x06038375 RID: 230261 RVA: 0x00E3C013 File Offset: 0x00E3A213
		public void AddAreaCanvas(IAreaCanvas areaCanvas)
		{
			this.AreaCanvasList.Add(areaCanvas);
		}

		// Token: 0x06038376 RID: 230262 RVA: 0x00E3C021 File Offset: 0x00E3A221
		public void ClearAreaCanvas()
		{
			this.AreaCanvasList = new List<IAreaCanvas>();
		}

		// Token: 0x06038377 RID: 230263 RVA: 0x00E3C030 File Offset: 0x00E3A230
		public void SortOrderAreaCanvas(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo, ISkillInteractMainUiInteract uiInteract)
		{
			foreach (IAreaCanvas areaCanvas in this.AreaCanvasList)
			{
				if (areaCanvas.CheckCanvasSortOrder(tagList, skillTriggerInfo))
				{
					areaCanvas.HandleSortOrder();
					areaCanvas.ReceiveUiInteract(uiInteract);
				}
			}
		}

		// Token: 0x06038378 RID: 230264 RVA: 0x00E3C094 File Offset: 0x00E3A294
		public void ResetAreaCanvas()
		{
			foreach (IAreaCanvas areaCanvas in this.AreaCanvasList)
			{
				areaCanvas.CancelSortOrder();
				areaCanvas.ReceiveUiInteract(null);
			}
		}

		// Token: 0x0402019F RID: 131487
		protected List<IAreaCanvas> AreaCanvasList = new List<IAreaCanvas>();
	}
}
