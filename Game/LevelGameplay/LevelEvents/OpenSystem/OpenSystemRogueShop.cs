using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C86 RID: 27782
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueShop : OpenSystemBase
	{
		// Token: 0x060442E3 RID: 279267 RVA: 0x011B2EEE File Offset: 0x011B10EE
		public OpenSystemRogueShop(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442E4 RID: 279268 RVA: 0x011B2EF8 File Offset: 0x011B10F8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueShop.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueShop.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442E5 RID: 279269 RVA: 0x011B2F34 File Offset: 0x011B1134
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			if (ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
			{
				WeeklyRogueModel instance = ModelBase<WeeklyRogueModel>.Instance;
				RogueWeeklyOption rogueWeeklyOption = (instance != null) ? instance.GetOptionByBindId(-1) : null;
				return ControllerBase<WeeklyRogueController>.Instance.GetViewNameByType(rogueWeeklyOption.Type);
			}
			CSharpScript.Game.Module.Roguelike.RoguelikeChooseData roguelikeChooseDataById = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(-1);
			return ControllerBase<RoguelikeController>.Instance.GetViewNameByGainType(roguelikeChooseDataById.RoguelikeGainDataType.Value);
		}
	}
}
