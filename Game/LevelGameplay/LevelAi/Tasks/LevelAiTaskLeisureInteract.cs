using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E21 RID: 28193
	public class LevelAiTaskLeisureInteract : LevelAiTask
	{
		// Token: 0x06044714 RID: 280340 RVA: 0x011C7750 File Offset: 0x011C5950
		[NullableContext(1)]
		public unsafe override void MakePlanExpansions(PlanningContext context, LevelAiWorldState worldState)
		{
			string reason = "Leisure Interact Task Make Plan Expansions";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LevelIndex", context.CurrentLevelIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StepIndex", context.CurrentStepIndex);
			base.PrintDescription(reason, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!this.IsInit)
			{
				this.Init();
			}
			this.CreatePlanSteps(context, worldState.MakeCopy());
		}

		// Token: 0x06044715 RID: 280341 RVA: 0x011C77D8 File Offset: 0x011C59D8
		public void Init()
		{
			if (this.IsInit)
			{
				return;
			}
			NpcLeisureInteract npcLeisureInteract = this.Params as NpcLeisureInteract;
			if (npcLeisureInteract == null)
			{
				return;
			}
			LevelAiTask levelAiTask = null;
			ENpcLeisureInteract type = npcLeisureInteract.Option.Type;
			if (type <= ENpcLeisureInteract.SwingGetUp)
			{
				levelAiTask = new LevelAiTaskSitDown();
				levelAiTask.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description + " SitDownTask", npcLeisureInteract);
			}
			else
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelAi;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[LevelAiTaskLeisureInteract] 未配置正确的行为类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", base.CreatureDataComponent.GetPbDataId());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (levelAiTask != null)
			{
				if (this.NextNodes.Count > 0)
				{
					foreach (LevelAiStandaloneNode item in this.NextNodes)
					{
						levelAiTask.NextNodes.Add(item);
					}
					this.NextNodes.Clear();
				}
				this.NextNodes.Add(levelAiTask);
			}
			this.IsInit = true;
		}

		// Token: 0x0402616B RID: 156011
		public bool CanRecordPlanProgress;

		// Token: 0x0402616C RID: 156012
		public int Cost;

		// Token: 0x0402616D RID: 156013
		private bool IsInit;
	}
}
