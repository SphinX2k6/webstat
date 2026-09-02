using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C43 RID: 27715
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemConfirmBox : OpenSystemBase
	{
		// Token: 0x0604421B RID: 279067 RVA: 0x011B1333 File Offset: 0x011AF533
		public OpenSystemConfirmBox(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604421C RID: 279068 RVA: 0x011B133C File Offset: 0x011AF53C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemConfirmBox.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>4__this = this;
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemConfirmBox.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604421D RID: 279069 RVA: 0x011B1390 File Offset: 0x011AF590
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			return ControllerBase<ConfirmBoxController>.Instance.GetUiViewName(inParams.BoardId);
		}

		// Token: 0x0604421E RID: 279070 RVA: 0x011B13BC File Offset: 0x011AF5BC
		private int? GetQuestIdByContext(GeneralContext context)
		{
			int? result = null;
			EGeneralContextType? type = context.Type;
			if (type != null)
			{
				EGeneralContextType valueOrDefault = type.GetValueOrDefault();
				if (valueOrDefault != EGeneralContextType.Quest)
				{
					if (valueOrDefault == EGeneralContextType.GeneralLogicTree)
					{
						result = new int?((context as GeneralLogicTreeContext).TreeConfigId);
					}
				}
				else
				{
					result = new int?((context as QuestContext).QuestId);
				}
			}
			return result;
		}
	}
}
