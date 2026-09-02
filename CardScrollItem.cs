using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002B65 RID: 11109
internal class CardScrollItem : SurvivorsRogueCardScrollItemBase<int>
{
	// Token: 0x0601623F RID: 90687 RVA: 0x00625084 File Offset: 0x00623284
	public override UniTask RefreshAsync(int weaponId, bool isSelected, int gridIndex)
	{
		CardScrollItem.<RefreshAsync>d__0 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.weaponId = weaponId;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<CardScrollItem.<RefreshAsync>d__0>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016240 RID: 90688 RVA: 0x006250CF File Offset: 0x006232CF
	protected override bool OnCanExecuteChange()
	{
		return false;
	}
}
