using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DDC RID: 19932
	public interface ITrapDefenseResultUnlockInfo
	{
		// Token: 0x17008862 RID: 34914
		// (get) Token: 0x0603392A RID: 211242
		// (set) Token: 0x0603392B RID: 211243
		ETrapDefenseResultUnlockType Type { get; set; }

		// Token: 0x17008863 RID: 34915
		// (get) Token: 0x0603392C RID: 211244
		// (set) Token: 0x0603392D RID: 211245
		int Id { get; set; }

		// Token: 0x17008864 RID: 34916
		// (get) Token: 0x0603392E RID: 211246
		// (set) Token: 0x0603392F RID: 211247
		bool? NeedUnlockBar { get; set; }

		// Token: 0x17008865 RID: 34917
		// (get) Token: 0x06033930 RID: 211248
		// (set) Token: 0x06033931 RID: 211249
		bool? IsFinish { get; set; }

		// Token: 0x17008866 RID: 34918
		// (get) Token: 0x06033932 RID: 211250
		// (set) Token: 0x06033933 RID: 211251
		bool? IsNewUnlock { get; set; }

		// Token: 0x17008867 RID: 34919
		// (get) Token: 0x06033934 RID: 211252
		// (set) Token: 0x06033935 RID: 211253
		bool? ForShare { get; set; }
	}
}
