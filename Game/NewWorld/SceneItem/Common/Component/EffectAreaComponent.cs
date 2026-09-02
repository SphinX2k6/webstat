using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x0200487B RID: 18555
	public class EffectAreaComponent : EntityComponent
	{
		// Token: 0x0603046B RID: 197739 RVA: 0x00BC04C4 File Offset: 0x00BBE6C4
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			return true;
		}

		// Token: 0x0603046C RID: 197740 RVA: 0x00BC04C7 File Offset: 0x00BBE6C7
		protected override bool OnStart()
		{
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnPlayerOverlapCallback));
			return true;
		}

		// Token: 0x0603046D RID: 197741 RVA: 0x00BC04EC File Offset: 0x00BBE6EC
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnPlayerOverlapCallback));
			if (this.IsPlayerInRange)
			{
				this.OnPlayerOverlapCallback(false);
			}
			return true;
		}

		// Token: 0x0603046E RID: 197742 RVA: 0x00BC0520 File Offset: 0x00BBE720
		private void OnPlayerOverlapCallback(bool isEnter)
		{
			this.IsPlayerInRange = isEnter;
		}

		// Token: 0x0603046F RID: 197743 RVA: 0x00BC052C File Offset: 0x00BBE72C
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			EffectAreaComponent effectAreaComponent = (EffectAreaComponent)componentTemplate;
			if (base.CanResetComponentProperty("IsPlayerInRange"))
			{
				this.IsPlayerInRange = effectAreaComponent.IsPlayerInRange;
			}
			return true;
		}

		// Token: 0x0401BB92 RID: 113554
		private bool IsPlayerInRange;
	}
}
