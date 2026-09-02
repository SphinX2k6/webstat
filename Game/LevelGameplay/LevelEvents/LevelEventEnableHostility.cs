using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B8C RID: 27532
	public class LevelEventEnableHostility : LevelEventBase
	{
		// Token: 0x06043F47 RID: 278343 RVA: 0x0119AAD0 File Offset: 0x01198CD0
		public LevelEventEnableHostility(int id) : base(id)
		{
		}

		// Token: 0x06043F48 RID: 278344 RVA: 0x0119AADC File Offset: 0x01198CDC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EnableHostility enableHostility = inParams as EnableHostility;
			if (enableHostility == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZS, "参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			this.IsEnable = enableHostility.IsEnable;
			this.EntityIds = enableHostility.EntityIds;
			foreach (int num in this.EntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
				if (entityByPbDataId == null || !entityByPbDataId.Valid)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.ZS;
					string message = "实体不存在 可能已被销毁";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", num);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (!this.IsEnable)
				{
					CharacterAiComponent component = entityByPbDataId.Entity.GetComponent<CharacterAiComponent>();
					if (component != null)
					{
						component.SetAiTickLock(true);
					}
					CharacterAiComponent component2 = entityByPbDataId.Entity.GetComponent<CharacterAiComponent>();
					if (component2 != null)
					{
						component2.SetAiHateConfig("10");
					}
				}
				else
				{
					CharacterAiComponent component3 = entityByPbDataId.Entity.GetComponent<CharacterAiComponent>();
					if (component3 != null)
					{
						component3.SetAiHateConfig("");
					}
					CharacterAiComponent component4 = entityByPbDataId.Entity.GetComponent<CharacterAiComponent>();
					if (component4 != null)
					{
						component4.SetAiTickLock(false);
					}
				}
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x04026004 RID: 155652
		[Nullable(2)]
		private List<int> EntityIds;

		// Token: 0x04026005 RID: 155653
		private bool IsEnable;
	}
}
