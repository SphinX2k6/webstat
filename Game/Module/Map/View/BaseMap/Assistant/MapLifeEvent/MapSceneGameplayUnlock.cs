using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapLifeEvent
{
	// Token: 0x02005804 RID: 22532
	public class MapSceneGameplayUnlock : MapLifeEventListener
	{
		// Token: 0x0603952A RID: 234794 RVA: 0x00E8D91C File Offset: 0x00E8BB1C
		[NullableContext(1)]
		public MapSceneGameplayUnlock(BaseMap map) : base(map)
		{
		}

		// Token: 0x0603952B RID: 234795 RVA: 0x00E8D928 File Offset: 0x00E8BB28
		public override void OnWorldMapBeforeShow()
		{
			this.Data = (ModelBase<MapModel>.Instance.MapLifeEventListenerTriggerMap[EMapLifeEventListenerType.SceneGameplayUnlock].Data as IMapSceneGameplayUnlockData);
			List<MarkItem> list = new List<MarkItem>();
			Dictionary<int, MarkItem> markItemsByType = this.TargetExpressionMap.GetMarkItemsByType(EMarkType.FixedSceneGameplay, true);
			Dictionary<int, MarkItem> markItemsByType2 = this.TargetExpressionMap.GetMarkItemsByType(EMarkType.SceneGameplay, true);
			if (markItemsByType != null)
			{
				list.AddRange(markItemsByType.Values);
			}
			if (markItemsByType2 != null)
			{
				list.AddRange(markItemsByType2.Values);
			}
			foreach (MarkItem markItem in list)
			{
				ConfigMarkItem configMarkItem = markItem as ConfigMarkItem;
				if (configMarkItem != null && configMarkItem.MarkConfig != null)
				{
					configMarkItem.IsCanShowView = false;
					configMarkItem.ViewUpdateAsync(Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation(), false, false).Forget();
				}
			}
		}

		// Token: 0x0603952C RID: 234796 RVA: 0x00E8DA0C File Offset: 0x00E8BC0C
		public override void OnWorldMapAfterShow()
		{
			this.TargetExpressionMap.HandleSceneGamePlayMarkItemOpen(EMarkType.FixedSceneGameplay, this.Data.RelativeType, this.Data.RelativeSubType);
			this.TargetExpressionMap.HandleSceneGamePlayMarkItemOpen(EMarkType.SceneGameplay, this.Data.RelativeType, this.Data.RelativeSubType);
			ModelBase<MapModel>.Instance.MapLifeEventListenerTriggerMap[EMapLifeEventListenerType.SceneGameplayUnlock].State = false;
		}

		// Token: 0x04020961 RID: 133473
		[Nullable(2)]
		private IMapSceneGameplayUnlockData Data;
	}
}
