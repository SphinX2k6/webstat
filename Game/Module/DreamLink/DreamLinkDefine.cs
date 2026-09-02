using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D94 RID: 23956
	public class DreamLinkDefine : IStaticVariableResetter
	{
		// Token: 0x0603C565 RID: 247141 RVA: 0x00F50456 File Offset: 0x00F4E656
		static DreamLinkDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(DreamLinkDefine.CreateStaticDefaultValue), new Action(DreamLinkDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603C566 RID: 247142 RVA: 0x00F50475 File Offset: 0x00F4E675
		public static void CreateStaticDefaultValue()
		{
			Dictionary<SignState, EActivityTaskState> dictionary = new Dictionary<SignState, EActivityTaskState>();
			dictionary[SignState.Lock] = EActivityTaskState.Active;
			dictionary[SignState.Unlock] = EActivityTaskState.FinishedAndUnclaimed;
			dictionary[SignState.IsReceive] = EActivityTaskState.FinishedAndClaimed;
			DreamLinkDefine.signStateResolver = dictionary;
		}

		// Token: 0x0603C567 RID: 247143 RVA: 0x00F50499 File Offset: 0x00F4E699
		public static void ResetStaticDefaultValue()
		{
			DreamLinkDefine.signStateResolver = null;
		}

		// Token: 0x04021EB8 RID: 138936
		public const int CHANGE_STATE_FINISH_COUNT = 3;

		// Token: 0x04021EB9 RID: 138937
		public const int BOSS_INST_ROLE_COUNT = 3;

		// Token: 0x04021EBA RID: 138938
		public const int WORLD_RUN_ENDING_ID = 3020;

		// Token: 0x04021EBB RID: 138939
		[Nullable(2)]
		public static Dictionary<SignState, EActivityTaskState> signStateResolver;
	}
}
