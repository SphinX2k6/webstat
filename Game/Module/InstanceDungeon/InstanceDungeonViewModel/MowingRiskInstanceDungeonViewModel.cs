using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel
{
	// Token: 0x02005BDB RID: 23515
	public class MowingRiskInstanceDungeonViewModel : InstanceDungeonViewModelBase
	{
		// Token: 0x0603B89C RID: 243868 RVA: 0x00F17988 File Offset: 0x00F15B88
		protected override bool OnCheckInstanceUnlock(int instanceId)
		{
			return ControllerBase<ActivityMowingRiskController>.Instance.CheckInstanceUnlockByInstanceId(instanceId);
		}

		// Token: 0x0603B89D RID: 243869 RVA: 0x00F17998 File Offset: 0x00F15B98
		[NullableContext(2)]
		protected override TableTextArgNew OnGetUnlockConditionTextId(int instanceId)
		{
			string instanceLockTextIdByInstanceId = ControllerBase<ActivityMowingRiskController>.Instance.GetInstanceLockTextIdByInstanceId(instanceId);
			string[] args = ControllerBase<ActivityMowingRiskController>.Instance.GetInstanceLockTextArgsByInstanceId(instanceId) ?? Array.Empty<string>();
			return new TableTextArgNew(instanceLockTextIdByInstanceId, args);
		}
	}
}
