using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Common.Component;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BE8 RID: 27624
	public class LevelEventSetExploreState : LevelEventBase
	{
		// Token: 0x060440DD RID: 278749 RVA: 0x011A9D8B File Offset: 0x011A7F8B
		public LevelEventSetExploreState(int Id) : base(Id)
		{
		}

		// Token: 0x060440DE RID: 278750 RVA: 0x011A9D94 File Offset: 0x011A7F94
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			ITeleControlConfig config = (inParams as SetExploreState).Config;
			if (config != null)
			{
				ETeleControlType teleControlType = config.TeleControlType;
				if (teleControlType == ETeleControlType.BigWorld)
				{
					ModelBase<ManipulaterModel>.Instance.SetManipulateMode(ManipulaterModel.EManipulaterMode.BigWorld);
					return;
				}
				if (teleControlType == ETeleControlType.Boss)
				{
					ModelBase<ManipulaterModel>.Instance.SetManipulateMode(ManipulaterModel.EManipulaterMode.Boss);
				}
			}
		}
	}
}
