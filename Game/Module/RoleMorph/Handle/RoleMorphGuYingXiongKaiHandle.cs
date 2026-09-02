using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.Module.RoleMorph.Handle
{
	// Token: 0x020050E5 RID: 20709
	public class RoleMorphGuYingXiongKaiHandle : RoleMorphHandleBase
	{
		// Token: 0x06035629 RID: 218665 RVA: 0x00D6437C File Offset: 0x00D6257C
		public override void BeginMorph()
		{
			ModelBase<TrackModel>.Instance.SetForceCloseTracked(true);
			List<int> list = new List<int>
			{
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.古英雄铠.模式标识.蓄力模式"],
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.古英雄铠.模式标识.隐藏瞄准UI"]
			};
			ModelBase<BattleUiModel>.Instance.SetTagIdJoystickStaticVisible(list.ToArray());
			ModelBase<BattleUiModel>.Instance.SetTagIdMoveCursorVisible(list.ToArray());
		}

		// Token: 0x0603562A RID: 218666 RVA: 0x00D643E4 File Offset: 0x00D625E4
		public override void EndMorph()
		{
			ModelBase<TrackModel>.Instance.SetForceCloseTracked(false);
		}
	}
}
