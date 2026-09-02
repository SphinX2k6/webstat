using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005607 RID: 22023
	public class PhantomCardSkillData
	{
		// Token: 0x06038279 RID: 230009 RVA: 0x00E38CC3 File Offset: 0x00E36EC3
		[NullableContext(1)]
		public void RefreshData(PhantomBattleCardSkillUnlockInfo skillInfo)
		{
			this.CardId = skillInfo.CardId;
			this.Unlock = skillInfo.Unlock;
			this.TargetNum = skillInfo.TargetNum;
			this.CurNum = skillInfo.CurNum;
		}

		// Token: 0x04020156 RID: 131414
		public int CardId;

		// Token: 0x04020157 RID: 131415
		public bool Unlock;

		// Token: 0x04020158 RID: 131416
		public int TargetNum;

		// Token: 0x04020159 RID: 131417
		public int CurNum;
	}
}
