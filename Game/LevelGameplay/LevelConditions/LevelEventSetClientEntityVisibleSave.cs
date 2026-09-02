using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E05 RID: 28165
	public class LevelEventSetClientEntityVisibleSave : LevelEventBase
	{
		// Token: 0x06044665 RID: 280165 RVA: 0x011C4D7B File Offset: 0x011C2F7B
		public LevelEventSetClientEntityVisibleSave(int id) : base(id)
		{
		}

		// Token: 0x06044666 RID: 280166 RVA: 0x011C4D84 File Offset: 0x011C2F84
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SetEntityClientVisibleSave setEntityClientVisibleSave = inParams as SetEntityClientVisibleSave;
			if (setEntityClientVisibleSave == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (context.Type.GetValueOrDefault() == EGeneralContextType.Entity)
			{
				EntityContext entityContext = context as EntityContext;
				if (entityContext != null && entityContext.ClientExecuteActions)
				{
					if (setEntityClientVisibleSave.EntityIds == null || setEntityClientVisibleSave.EntityIds.Count == 0)
					{
						Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "目标Entity未配置", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					foreach (int num in setEntityClientVisibleSave.EntityIds)
					{
						EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
						WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
						if (worldEntity == null || !worldEntity.Valid)
						{
							global::Log instance = Singleton<global::Log>.Instance;
							ELogModule module = ELogModule.LevelEvent;
							ELogAuthor author = ELogAuthor.CH;
							string message = "目标Entity不存在";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", num);
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else
						{
							ControllerBase<CreatureController>.Instance.SetEntityEnable(worldEntity, setEntityClientVisibleSave.Visible, "LevelEventSetClientEntityVisible", false);
						}
					}
					return;
				}
			}
			Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.FZX, "不是场景引用的帧事件", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
