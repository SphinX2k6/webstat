using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.NewWorld.SceneItem.Controller
{
	// Token: 0x02004877 RID: 18551
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SceneItemBuffController : ControllerBase<SceneItemBuffController>
	{
		// Token: 0x06030451 RID: 197713 RVA: 0x00BBF4DC File Offset: 0x00BBD6DC
		public void BuffOperate(int entityId, BuffOperateType type, Action<BuffOperateType, bool> resultCb = null)
		{
			long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId);
			EntityBuffProducerOperateRequest entityBuffProducerOperateRequest = EntityBuffProducerOperateRequest.Create();
			entityBuffProducerOperateRequest.OpEntityId = creatureDataId;
			entityBuffProducerOperateRequest.OpType = type;
			Singleton<Net>.Instance.Call<EntityBuffProducerOperateResponse>(ERequestMessageId.EntityBuffProducerOperateRequest, entityBuffProducerOperateRequest, delegate(EntityBuffProducerOperateResponse response, Net.CallbackStatus _)
			{
				bool arg = false;
				if (response.ErrorCode == ErrorCode.Success)
				{
					arg = true;
				}
				long opEntityId = response.OpEntityId;
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(opEntityId);
				if (entity == null || !entity.IsInit)
				{
					return;
				}
				if (resultCb != null)
				{
					resultCb(response.OpType, arg);
				}
			}, 0);
		}
	}
}
