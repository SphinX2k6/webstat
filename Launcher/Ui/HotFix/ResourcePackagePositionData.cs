using System;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004515 RID: 17685
	public class ResourcePackagePositionData
	{
		// Token: 0x0401A77F RID: 108415
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public int instanceId;

		// Token: 0x0401A780 RID: 108416
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public double x;

		// Token: 0x0401A781 RID: 108417
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public double y;

		// Token: 0x0401A782 RID: 108418
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public double z;
	}
}
