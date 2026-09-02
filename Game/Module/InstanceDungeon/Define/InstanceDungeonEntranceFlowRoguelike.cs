using System;
using System.Linq;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C2A RID: 23594
	public class InstanceDungeonEntranceFlowRoguelike : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA30 RID: 244272 RVA: 0x00F1C354 File Offset: 0x00F1A554
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				ControllerBase<RoguelikeController>.Instance.OpenRoguelikeInstanceView();
			});
			base.AddStep(delegate
			{
				ControllerBase<RoguelikeController>.Instance.OpenRoguelikeSelectRoleView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId);
			});
			base.AddStep(delegate
			{
				ControllerBase<RoguelikeController>.Instance.RoguelikeStartRequest(false, ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, (from id in ModelBase<RoguelikeModel>.Instance.GetEntranceViewModel().FormationIdList
				where id != 0
				select id).ToList<int>(), ModelBase<RoguelikeModel>.Instance.GetEntranceViewModel().CurrentEntriesGroupData.Id);
			});
		}
	}
}
