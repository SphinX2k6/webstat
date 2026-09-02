using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;

// Token: 0x020010FF RID: 4351
public class GuessJokerGameExitStage : GuessJokerStageBase
{
	// Token: 0x06007144 RID: 28996 RVA: 0x001D9AAF File Offset: 0x001D7CAF
	[NullableContext(1)]
	public GuessJokerGameExitStage(GuessJokerStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x06007145 RID: 28997 RVA: 0x001D9AB8 File Offset: 0x001D7CB8
	protected override void OnEnter()
	{
		ModelBase<GuessJokerGamePlayModel>.Instance.CloseGamePlayViewAsync().Forget(delegate(Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJoker关闭游戏界面失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}, true);
		int roleId = ModelBase<GuessJokerGamePlayModel>.Instance.GetRoleId();
		GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(roleId);
		int? num = (jokerAiConfigByRoleId != null) ? new int?(jokerAiConfigByRoleId.GetValueOrDefault().NpcId) : null;
		if (num != null)
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.ShowOnlyGuessJokerNpc(num.Value);
		}
	}
}
