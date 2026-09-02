using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063B3 RID: 25523
	[NullableContext(1)]
	public interface IRoverlikeFloatTextData
	{
		// Token: 0x17009D86 RID: 40326
		// (get) Token: 0x060401AC RID: 262572
		// (set) Token: 0x060401AD RID: 262573
		ERoverlikeFloatTextType Type { get; set; }

		// Token: 0x17009D87 RID: 40327
		// (get) Token: 0x060401AE RID: 262574
		// (set) Token: 0x060401AF RID: 262575
		string TextKey { get; set; }

		// Token: 0x17009D88 RID: 40328
		// (get) Token: 0x060401B0 RID: 262576
		// (set) Token: 0x060401B1 RID: 262577
		string[] TextParam { get; set; }
	}
}
