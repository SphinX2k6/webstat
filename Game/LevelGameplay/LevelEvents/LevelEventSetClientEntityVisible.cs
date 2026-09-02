using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BE6 RID: 27622
	public class LevelEventSetClientEntityVisible : LevelEventBase
	{
		// Token: 0x060440D9 RID: 278745 RVA: 0x011A9A50 File Offset: 0x011A7C50
		public LevelEventSetClientEntityVisible(int id) : base(id)
		{
		}

		// Token: 0x060440DA RID: 278746 RVA: 0x011A9A5C File Offset: 0x011A7C5C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SetEntityClientVisible setEntityClientVisible = inParams as SetEntityClientVisible;
			if (setEntityClientVisible == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (setEntityClientVisible.EntityIds == null || setEntityClientVisible.EntityIds.Count == 0)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "目标Entity未配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (int num in setEntityClientVisible.EntityIds)
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
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					ControllerBase<CreatureController>.Instance.SetEntityEnable(worldEntity, setEntityClientVisible.Visible, "LevelEventSetClientEntityVisible", true);
				}
			}
		}
	}
}
