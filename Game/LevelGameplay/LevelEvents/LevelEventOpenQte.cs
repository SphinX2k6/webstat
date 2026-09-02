using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Common.Component;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BBA RID: 27578
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventOpenQte : LevelEventBase
	{
		// Token: 0x06044018 RID: 278552 RVA: 0x011A0BF6 File Offset: 0x0119EDF6
		public LevelEventOpenQte(int id) : base(id)
		{
		}

		// Token: 0x06044019 RID: 278553 RVA: 0x011A0C00 File Offset: 0x0119EE00
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			OpenQteAction openQteAction = inParams as OpenQteAction;
			if (openQteAction == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			EOpenQteType type = openQteAction.Config.Type;
			bool value;
			if (type != EOpenQteType.PanelQte)
			{
				value = (type == EOpenQteType.LevelQte && this.ExecuteLevelQte(openQteAction, context));
			}
			else
			{
				value = this.ExecutePanelQte(openQteAction, context);
			}
			base.FinishExecute(value, false, true);
		}

		// Token: 0x0604401A RID: 278554 RVA: 0x011A0C5C File Offset: 0x0119EE5C
		private bool ExecutePanelQte(OpenQteAction param, GeneralContext context)
		{
			IOpenPanelQteQte openPanelQteQte = param.Config as IOpenPanelQteQte;
			if (openPanelQteQte == null || openPanelQteQte.Type != EOpenQteType.PanelQte)
			{
				return false;
			}
			ControllerBase<PanelQteController>.Instance.StartLevelEventQte(openPanelQteQte.Id);
			return true;
		}

		// Token: 0x0604401B RID: 278555 RVA: 0x011A0C94 File Offset: 0x0119EE94
		private bool ExecuteLevelQte(OpenQteAction param, GeneralContext context)
		{
			IOpenLevelQte openLevelQte = param.Config as IOpenLevelQte;
			if (openLevelQte == null || openLevelQte.Type != EOpenQteType.LevelQte)
			{
				return false;
			}
			Entity targetEntityByContext = this.GetTargetEntityByContext(openLevelQte.LevelQteEntity, context);
			if (targetEntityByContext == null || !targetEntityByContext.Valid)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventOpenQte] 找不到对应的QTE实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			LevelQteComponent component = targetEntityByContext.GetComponent<LevelQteComponent>();
			if (component == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventOpenQte] 实体缺少LevelQte组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return component.StartQte(false);
		}

		// Token: 0x0604401C RID: 278556 RVA: 0x011A0D28 File Offset: 0x0119EF28
		[return: Nullable(2)]
		private Entity GetTargetEntityByContext(ITargetEntityType targetEntityConfig, GeneralContext context)
		{
			Entity result = null;
			switch (targetEntityConfig.Type)
			{
			case ETargetEntityType.Target:
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				Entity entity;
				if (instance == null)
				{
					entity = null;
				}
				else
				{
					EntityHandle entityByPbDataId = instance.GetEntityByPbDataId(((ITargetEntity)targetEntityConfig).EntityId);
					entity = ((entityByPbDataId != null) ? entityByPbDataId.Entity : null);
				}
				result = entity;
				break;
			}
			case ETargetEntityType.Self:
			{
				TriggerContext triggerContext = context as TriggerContext;
				if (triggerContext != null && triggerContext.TriggerEntityId != null)
				{
					CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
					Entity entity2;
					if (instance2 == null)
					{
						entity2 = null;
					}
					else
					{
						EntityHandle entityById = instance2.GetEntityById(triggerContext.TriggerEntityId.Value);
						entity2 = ((entityById != null) ? entityById.Entity : null);
					}
					result = entity2;
				}
				else
				{
					EntityContext entityContext = context as EntityContext;
					if (entityContext != null && entityContext.EntityId != null)
					{
						CreatureModel instance3 = ModelBase<CreatureModel>.Instance;
						Entity entity3;
						if (instance3 == null)
						{
							entity3 = null;
						}
						else
						{
							EntityHandle entityById2 = instance3.GetEntityById(entityContext.EntityId.Value);
							entity3 = ((entityById2 != null) ? entityById2.Entity : null);
						}
						result = entity3;
					}
				}
				break;
			}
			case ETargetEntityType.Triggered:
			{
				TriggerContext triggerContext2 = context as TriggerContext;
				if (triggerContext2 == null || triggerContext2.OtherEntityId == null)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventOpenQte] context数据异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					CreatureModel instance4 = ModelBase<CreatureModel>.Instance;
					Entity entity4;
					if (instance4 == null)
					{
						entity4 = null;
					}
					else
					{
						EntityHandle entityById3 = instance4.GetEntityById(triggerContext2.OtherEntityId.Value);
						entity4 = ((entityById3 != null) ? entityById3.Entity : null);
					}
					result = entity4;
				}
				break;
			}
			case ETargetEntityType.Player:
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				result = ((baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null);
				break;
			}
			}
			return result;
		}
	}
}
