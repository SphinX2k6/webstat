using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006763 RID: 26467
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class LineCrossConfig : ConfigBase<LineCrossConfig>
	{
		// Token: 0x06041FA4 RID: 270244 RVA: 0x010EDC97 File Offset: 0x010EBE97
		public LineCrossEntrance? GetLineCrossEntranceById(int id)
		{
			return ConfigLineCrossEntranceById.GetConfig(id, true);
		}

		// Token: 0x06041FA5 RID: 270245 RVA: 0x010EDCA0 File Offset: 0x010EBEA0
		public LineCrossGroup? GetLineCrossGroupByGroupId(int groupId)
		{
			return ConfigLineCrossGroupByGroupId.GetConfig(groupId, true);
		}

		// Token: 0x06041FA6 RID: 270246 RVA: 0x010EDCA9 File Offset: 0x010EBEA9
		public LineCrossChallenge? GetLineCrossChallengeById(int id)
		{
			return ConfigLineCrossChallengeById.GetConfig(id, true);
		}

		// Token: 0x06041FA7 RID: 270247 RVA: 0x010EDCB2 File Offset: 0x010EBEB2
		public LineCrossActivity? GetLineCrossActivityById(int id)
		{
			return ConfigLineCrossActivityByActivityId.GetConfig(id, true);
		}
	}
}
