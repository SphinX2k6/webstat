using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02002780 RID: 10112
public class RogueBattleTeamEditData : UiPopViewData
{
	// Token: 0x06013F19 RID: 81689 RVA: 0x0058F21C File Offset: 0x0058D41C
	public RogueBattleTeamEditData(int formationIndex, [Nullable(new byte[]
	{
		2,
		1
	})] Func<List<int>, UniTask> onTeamEditConfirm)
	{
		this.FormationIndex = formationIndex;
		this.OnTeamEditConfirm = onTeamEditConfirm;
	}

	// Token: 0x04009B5A RID: 39770
	public int FormationIndex;

	// Token: 0x04009B5B RID: 39771
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<List<int>, UniTask> OnTeamEditConfirm;
}
