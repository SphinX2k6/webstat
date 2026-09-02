using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.PlayerInput
{
	// Token: 0x02004549 RID: 17737
	[NullableContext(1)]
	[Nullable(0)]
	public static class axisMappings
	{
		// Token: 0x0602EAEA RID: 191210 RVA: 0x00B0FB74 File Offset: 0x00B0DD74
		public static bool HasField(string fieldName)
		{
			return typeof(axisMappings).GetField(fieldName) != null;
		}

		// Token: 0x0401A853 RID: 108627
		public const string 手柄右摇杆垂直方向 = "手柄右摇杆垂直方向";

		// Token: 0x0401A854 RID: 108628
		public const string 手柄左摇杆垂直方向 = "手柄左摇杆垂直方向";
	}
}
