using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Common.Component;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005441 RID: 21569
	public class FlowActionUnlockEntity : FlowActionBase
	{
		// Token: 0x06036FD3 RID: 225235 RVA: 0x00DF589C File Offset: 0x00DF3A9C
		protected unsafe override void OnExecute()
		{
			foreach (int num in (this.ActionInfo.Params as UnlockEntity).EntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
				LevelTagComponent levelTagComponent;
				if (entityByPbDataId == null)
				{
					levelTagComponent = null;
				}
				else
				{
					WorldEntity entity = entityByPbDataId.Entity;
					levelTagComponent = ((entity != null) ? entity.GetComponent<LevelTagComponent>() : null);
				}
				LevelTagComponent levelTagComponent2 = levelTagComponent;
				if (levelTagComponent2 == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.CH;
					string message = "找不对对应的实体";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("actionId", this.ActionInfo.ActionId);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					levelTagComponent2.RemoveServerTagByIdLocal(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.锁定"], "FlowActionUnlockEntity");
				}
			}
		}
	}
}
