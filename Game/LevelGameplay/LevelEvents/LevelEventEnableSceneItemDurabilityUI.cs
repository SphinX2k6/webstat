using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B8E RID: 27534
	public class LevelEventEnableSceneItemDurabilityUI : LevelEventBase
	{
		// Token: 0x06043F4C RID: 278348 RVA: 0x0119AD77 File Offset: 0x01198F77
		public LevelEventEnableSceneItemDurabilityUI(int id) : base(id)
		{
		}

		// Token: 0x06043F4D RID: 278349 RVA: 0x0119AD80 File Offset: 0x01198F80
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			IHealthBarDisplayClientFunction healthBarDisplayClientFunction = inParams as IHealthBarDisplayClientFunction;
			this.PbDataId = healthBarDisplayClientFunction.EntityId;
			this.IsVisible = healthBarDisplayClientFunction.IsVisible;
			if (this.IsVisible)
			{
				base.CreateWaitEntityTask(this.PbDataId);
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.PbDataId);
			if (entityByPbDataId != null && entityByPbDataId.Valid)
			{
				Singleton<EventSystem>.Instance.Emit<int, bool, int?, int?, string>(EEventName.OnEnableSceneItemDurabilityUI, entityByPbDataId.Id, false, null, null, null);
			}
			else
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CK;
				string message = "[可破坏物耐久度UI]隐藏时实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F4E RID: 278350 RVA: 0x0119AE44 File Offset: 0x01199044
		protected override void ExecuteWhenEntitiesReady()
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.PbDataId);
			if (entityByPbDataId == null || !entityByPbDataId.Valid)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CK;
				string message = "[可破坏物耐久度UI]显示时实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, false, true);
				return;
			}
			WorldEntity entity = entityByPbDataId.Entity;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			SceneItemDamageComponent component2 = entity.GetComponent<SceneItemDamageComponent>();
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnEnableSceneItemDurabilityUI;
			int id = entityByPbDataId.Id;
			bool p = true;
			int? p2 = new int?(component.GetDurabilityValue());
			float? num = (component2 != null) ? new float?(component2.GetMaxDurablePoint()) : null;
			instance2.Emit<int, bool, int?, int?, string>(name, id, p, p2, new int?(((num != null) ? new int?((int)num.GetValueOrDefault()) : null).GetValueOrDefault(100)), component.GetEntityTidName() ?? "");
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F4F RID: 278351 RVA: 0x0119AF49 File Offset: 0x01199149
		protected override void OnReset()
		{
			this.PbDataId = 0;
			this.IsVisible = false;
		}

		// Token: 0x04026007 RID: 155655
		private int PbDataId;

		// Token: 0x04026008 RID: 155656
		private bool IsVisible;
	}
}
