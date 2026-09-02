using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CC1 RID: 23745
	public class TeamTeleportFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE57 RID: 245335 RVA: 0x00F2E27F File Offset: 0x00F2C47F
		[NullableContext(1)]
		public TeamTeleportFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE58 RID: 245336 RVA: 0x00F2E288 File Offset: 0x00F2C488
		protected override void OnStart()
		{
			this.TickDuration = (double)((this.OpenParam as IPromptParamHub).Duration.GetValueOrDefault() * 1000f);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.MainText, "TeamTeleport_Tips", new <>z__ReadOnlySingleElementList<object>(Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(this.TickDuration)));
		}

		// Token: 0x0603BE59 RID: 245337 RVA: 0x00F2E2E4 File Offset: 0x00F2C4E4
		protected override void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}

		// Token: 0x0603BE5A RID: 245338 RVA: 0x00F2E2E6 File Offset: 0x00F2C4E6
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}

		// Token: 0x0603BE5B RID: 245339 RVA: 0x00F2E2E8 File Offset: 0x00F2C4E8
		protected override void OnTick(float delta)
		{
			if (this.TickTime >= this.TickDuration)
			{
				base.CloseMe(null);
				return;
			}
			this.TickTime += (double)delta;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.MainText, "TeamTeleport_Tips", new <>z__ReadOnlySingleElementList<object>(Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(this.TickDuration - this.TickTime)));
		}
	}
}
