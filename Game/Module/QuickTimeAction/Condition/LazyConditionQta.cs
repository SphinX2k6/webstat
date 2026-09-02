using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using AkiClient.Game.Aki.Data.QuickTimeAction;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052CF RID: 21199
	[NullableContext(1)]
	[Nullable(0)]
	public class LazyConditionQta : LazyConditionBase
	{
		// Token: 0x060362B7 RID: 221879 RVA: 0x00DA4CBB File Offset: 0x00DA2EBB
		public LazyConditionQta(TLazyConditionResultCallback callback) : base(callback)
		{
		}

		// Token: 0x060362B8 RID: 221880 RVA: 0x00DA4CC4 File Offset: 0x00DA2EC4
		public void SetQtaCondition(SQtaCondition ueCondition, SQta qtaConfig, int payloadId, bool immediatelyCheck = true)
		{
			CfgLazyConditionGroup cfgLazyConditionGroup = new CfgLazyConditionGroup();
			cfgLazyConditionGroup.ConditionFormula = ueCondition.Formula;
			cfgLazyConditionGroup.PayloadId = payloadId;
			for (int i = 0; i < ueCondition.Contents.Num(); i++)
			{
				SQtaCondition_Content sqtaCondition_Content = ueCondition.Contents.Get(i);
				if (sqtaCondition_Content != null)
				{
					if (sqtaCondition_Content.ConditionType == EQtaConditionType.检查输入)
					{
						for (int j = 0; j < qtaConfig.BaseConfig.InputConfig.Num(); j++)
						{
							SCommonQteButton scommonQteButton = qtaConfig.BaseConfig.InputConfig.Get(j);
							CfgLazyConditionForInput cfgLazyConditionForInput = new CfgLazyConditionForInput();
							cfgLazyConditionForInput.InitForQta(QtaActionNames.Get((int)scommonQteButton.Action), sqtaCondition_Content);
							cfgLazyConditionGroup.ConditionGroup.Add(cfgLazyConditionForInput);
						}
					}
					else if (sqtaCondition_Content.ConditionType == EQtaConditionType.检查Tag)
					{
						CfgLazyConditionForTag cfgLazyConditionForTag = new CfgLazyConditionForTag();
						cfgLazyConditionForTag.InitForQta(sqtaCondition_Content);
						cfgLazyConditionGroup.ConditionGroup.Add(cfgLazyConditionForTag);
					}
					else if (sqtaCondition_Content.ConditionType == EQtaConditionType.事件变化)
					{
						CfgLazyConditionForEntityEvent cfgLazyConditionForEntityEvent = new CfgLazyConditionForEntityEvent();
						cfgLazyConditionForEntityEvent.InitForQta(sqtaCondition_Content);
						cfgLazyConditionGroup.ConditionGroup.Add(cfgLazyConditionForEntityEvent);
					}
				}
			}
			base.SetCondition(cfgLazyConditionGroup, immediatelyCheck);
		}
	}
}
