using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006488 RID: 25736
	public class ActivityRoadBookDefine : IStaticVariableResetter
	{
		// Token: 0x06040908 RID: 264456 RVA: 0x0108CF0D File Offset: 0x0108B10D
		static ActivityRoadBookDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ActivityRoadBookDefine.CreateStaticDefaultValue), new Action(ActivityRoadBookDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06040909 RID: 264457 RVA: 0x0108CF2C File Offset: 0x0108B12C
		public static void CreateStaticDefaultValue()
		{
			ActivityRoadBookDefine.RoadBookPhantomColorText = new Dictionary<int, string>
			{
				{
					0,
					"#5F5F62"
				},
				{
					1,
					"#384BFF"
				},
				{
					2,
					"#8A00FF"
				},
				{
					3,
					"#A7974D"
				},
				{
					4,
					"#BE1327"
				}
			};
		}

		// Token: 0x0604090A RID: 264458 RVA: 0x0108CF7F File Offset: 0x0108B17F
		public static void ResetStaticDefaultValue()
		{
			ActivityRoadBookDefine.RoadBookPhantomColorText = null;
		}

		// Token: 0x04024214 RID: 147988
		[Nullable(1)]
		public static Dictionary<int, string> RoadBookPhantomColorText;
	}
}
