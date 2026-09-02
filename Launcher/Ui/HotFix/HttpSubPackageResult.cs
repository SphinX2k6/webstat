using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004516 RID: 17686
	[NullableContext(2)]
	[Nullable(0)]
	public class HttpSubPackageResult
	{
		// Token: 0x0401A783 RID: 108419
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public int code;

		// Token: 0x0401A784 RID: 108420
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public int userId;

		// Token: 0x0401A785 RID: 108421
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public List<int> needConfirmQuestIdSet;

		// Token: 0x0401A786 RID: 108422
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public List<int> finishQuestIdSet;

		// Token: 0x0401A787 RID: 108423
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public List<int> currentBlockIdSet;

		// Token: 0x0401A788 RID: 108424
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public List<uint> mp4FinishQuestFlag;

		// Token: 0x0401A789 RID: 108425
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public int sex;

		// Token: 0x0401A78A RID: 108426
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ResourcePackagePositionData> positions;
	}
}
