using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200606A RID: 24682
	[NullableContext(1)]
	[Nullable(0)]
	public class ShowQuestUpdateTipsProcess : TPendingProcess
	{
		// Token: 0x0603E3F3 RID: 254963 RVA: 0x00FE404F File Offset: 0x00FE224F
		public ShowQuestUpdateTipsProcess(QuestUpdateTipsShowData info)
		{
		}

		// Token: 0x17009AC6 RID: 39622
		// (get) Token: 0x0603E3F4 RID: 254964 RVA: 0x00FE406A File Offset: 0x00FE226A
		public override EMissionProcessType ProcessType
		{
			get
			{
				return EMissionProcessType.ShowQuestUpdateTips;
			}
		}

		// Token: 0x17009AC7 RID: 39623
		// (get) Token: 0x0603E3F5 RID: 254965 RVA: 0x00FE406D File Offset: 0x00FE226D
		public override bool IsSkipAnim { get; } = info.IsSkipAnim;

		// Token: 0x04022E47 RID: 142919
		public readonly QuestUpdateTipsShowData Info = info;
	}
}
