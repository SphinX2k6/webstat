using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Effect
{
	// Token: 0x02006E59 RID: 28249
	public class ItemInspectEffectPlayPerform : ItemInspectEffectBase
	{
		// Token: 0x060448FF RID: 280831 RVA: 0x011D3290 File Offset: 0x011D1490
		[NullableContext(1)]
		protected override void Execute(IInteractEffect @params)
		{
			int curItemId = ModelBase<ItemInspectModel>.Instance.CurItemId;
			foreach (int tagId in ((IExecuteTag)@params).Tags)
			{
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
				if (gameplayTagById != null)
				{
					SceneInteractionManager.Get().PlayExtraEffectByTag(curItemId, gameplayTagById.Value, false);
				}
			}
			base.FinishExecute(true);
		}
	}
}
