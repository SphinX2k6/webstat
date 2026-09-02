using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200268B RID: 9867
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewNodeItemBase : UiPanelBase
{
	// Token: 0x0601376F RID: 79727 RVA: 0x0056CB66 File Offset: 0x0056AD66
	public virtual void Refresh(IQuestReviewNodeParam param)
	{
	}

	// Token: 0x06013770 RID: 79728 RVA: 0x0056CB68 File Offset: 0x0056AD68
	public void SetSeqPlayer(LevelSequencePlayer seqPlayer)
	{
		this.SeqPlayer = seqPlayer;
	}

	// Token: 0x06013771 RID: 79729 RVA: 0x0056CB74 File Offset: 0x0056AD74
	public void PlaySeqByName(string seqName)
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.PlayLevelSequenceByName(seqName, false, null, false);
	}

	// Token: 0x040097B1 RID: 38833
	protected LevelSequencePlayer SeqPlayer;
}
