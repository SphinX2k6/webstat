using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063CC RID: 25548
	public class RoverlikeActionSubViewFactory
	{
		// Token: 0x06040252 RID: 262738 RVA: 0x010701F2 File Offset: 0x0106E3F2
		public static ERoverActionSubViewType ServerTypeToSubViewType(RoverRogueGainOperateType serverType)
		{
			switch (serverType)
			{
			case RoverRogueGainOperateType.RoverRogueBlessSelect:
				return ERoverActionSubViewType.SelectBlessing;
			case RoverRogueGainOperateType.RoverRogueRoleEnhanceSelect:
				return ERoverActionSubViewType.SelectReinforcement;
			case RoverRogueGainOperateType.RoverRogueBlessEnhanceSelect:
				return ERoverActionSubViewType.BlessingReinforcement;
			default:
				return ERoverActionSubViewType.None;
			}
		}

		// Token: 0x06040253 RID: 262739 RVA: 0x01070210 File Offset: 0x0106E410
		[NullableContext(2)]
		public static RoverlikeActionSubViewBase CreateSubView(ERoverActionSubViewType type)
		{
			switch (type)
			{
			case ERoverActionSubViewType.BlessingSuitPreview:
				return new RoverlikeSubViewBlessingSuitPreview();
			case ERoverActionSubViewType.BlessingSuitSelect:
				return new RoverlikeSubViewBlessingSuitSelect();
			case ERoverActionSubViewType.SelectBlessing:
				return new RoverlikeSubViewSelectBlessing();
			case ERoverActionSubViewType.SelectReinforcement:
				return new RoverlikeSubViewSelectReinforcement();
			case ERoverActionSubViewType.SelectEvent:
				return new RoverlikeSubViewEvent();
			case ERoverActionSubViewType.BlessingReinforcement:
				return new RoverlikeSubViewBlessingReinforcement();
			default:
				return null;
			}
		}
	}
}
