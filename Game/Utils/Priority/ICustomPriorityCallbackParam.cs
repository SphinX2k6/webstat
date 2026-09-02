using System;

namespace CSharpScript.Game.Utils.Priority
{
	// Token: 0x02004703 RID: 18179
	public interface ICustomPriorityCallbackParam
	{
		// Token: 0x17008160 RID: 33120
		// (get) Token: 0x0602F424 RID: 193572
		// (set) Token: 0x0602F425 RID: 193573
		bool? IsReentrant { get; set; }

		// Token: 0x17008161 RID: 33121
		// (get) Token: 0x0602F426 RID: 193574
		// (set) Token: 0x0602F427 RID: 193575
		bool IsForce { get; set; }
	}
}
