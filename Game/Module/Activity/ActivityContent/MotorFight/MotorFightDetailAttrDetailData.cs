using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066D2 RID: 26322
	public class MotorFightDetailAttrDetailData : IMotorFightDetailAttrDetailData
	{
		// Token: 0x1700A091 RID: 41105
		// (get) Token: 0x06041BB2 RID: 269234 RVA: 0x010DAFFF File Offset: 0x010D91FF
		// (set) Token: 0x06041BB3 RID: 269235 RVA: 0x010DB007 File Offset: 0x010D9207
		public MotorFightAttrShow Config { get; set; }

		// Token: 0x1700A092 RID: 41106
		// (get) Token: 0x06041BB4 RID: 269236 RVA: 0x010DB010 File Offset: 0x010D9210
		// (set) Token: 0x06041BB5 RID: 269237 RVA: 0x010DB018 File Offset: 0x010D9218
		public EMotorFightAttrShowType Type { get; set; }
	}
}
