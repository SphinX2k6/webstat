using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066CF RID: 26319
	public class MotorFightDefine
	{
		// Token: 0x04024AD4 RID: 150228
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EMotorFightAttrShowType, string> motorFightAttrShowTypeToName = new Dictionary<EMotorFightAttrShowType, string>
		{
			{
				EMotorFightAttrShowType.MainGun,
				"MotorFightGame_UIAttriDesc_01"
			},
			{
				EMotorFightAttrShowType.Wingman,
				"MotorFightGame_UIAttriDesc_02"
			},
			{
				EMotorFightAttrShowType.Common,
				"MotorFightGame_UIAttriDesc_03"
			}
		};
	}
}
