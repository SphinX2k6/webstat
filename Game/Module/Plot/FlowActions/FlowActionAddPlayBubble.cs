using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005409 RID: 21513
	public class FlowActionAddPlayBubble : FlowActionBase
	{
		// Token: 0x06036EF3 RID: 225011 RVA: 0x00DF1A74 File Offset: 0x00DEFC74
		protected override void OnExecute()
		{
			AddPlayBubble addPlayBubble = this.ActionInfo.Params as AddPlayBubble;
			if (addPlayBubble == null)
			{
				return;
			}
			if (addPlayBubble.EntityIds.Count == 0)
			{
				return;
			}
			CharacterDynamicFlowData data = this.CreateCharacterFlowData(addPlayBubble);
			ControllerBase<DynamicFlowController>.Instance.AddDynamicFlow(data);
			base.FinishExecute(true, true);
		}

		// Token: 0x06036EF4 RID: 225012 RVA: 0x00DF1AC0 File Offset: 0x00DEFCC0
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}

		// Token: 0x06036EF5 RID: 225013 RVA: 0x00DF1AC8 File Offset: 0x00DEFCC8
		[NullableContext(1)]
		private CharacterDynamicFlowData CreateCharacterFlowData(AddPlayBubble flowData)
		{
			return new CharacterDynamicFlowData
			{
				MasterInfo = new DynamicFlowActorInfo
				{
					PbDataId = flowData.EntityIds[0]
				},
				BubbleData = flowData,
				Type = new EDynamicFlowType?(EDynamicFlowType.FlowAction)
			};
		}
	}
}
