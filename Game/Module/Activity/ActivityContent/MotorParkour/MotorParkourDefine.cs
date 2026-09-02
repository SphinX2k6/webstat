using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066B3 RID: 26291
	public class MotorParkourDefine
	{
		// Token: 0x04024A60 RID: 150112
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static Vector worldToMotorParkourUiUnit = Vector.Create(1.0, -1.0, 1.0);

		// Token: 0x04024A61 RID: 150113
		public const int SPLINE_DISTANCE_INTERVAL = 1000;

		// Token: 0x04024A62 RID: 150114
		public const int MOTORPARKOUR_WORLD_TO_UI_ROTATION_REVISE_ANGLE = 90;
	}
}
