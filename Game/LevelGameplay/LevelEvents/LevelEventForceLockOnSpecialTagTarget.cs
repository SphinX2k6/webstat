using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA4 RID: 27556
	public class LevelEventForceLockOnSpecialTagTarget : LevelEventBase
	{
		// Token: 0x06043FBF RID: 278463 RVA: 0x0119DEBF File Offset: 0x0119C0BF
		public LevelEventForceLockOnSpecialTagTarget(int id) : base(id)
		{
		}

		// Token: 0x06043FC0 RID: 278464 RVA: 0x0119DEC8 File Offset: 0x0119C0C8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SetForceLock setForceLock = inParams as SetForceLock;
			if (setForceLock == null)
			{
				return;
			}
			int entityId = setForceLock.EntityId;
			CharacterLockOnComponent component = Global.BaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterLockOnComponent>();
			if (component == null || !component.Valid)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Level, ELogAuthor.ZQ, "LevelEventForceLockOnSpecialTagTarget 获取不到玩家lockon组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(setForceLock.EntityId);
			component.ForceLookAt(new LockOnInfo(null, "")
			{
				EntityHandle = entityByPbDataId
			}, setForceLock.IsLocked);
		}
	}
}
