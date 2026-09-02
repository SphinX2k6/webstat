using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.NewWorld.Character.Custom.Components
{
	// Token: 0x020048EA RID: 18666
	[NullableContext(2)]
	[Nullable(0)]
	public class TriggerComponent : EntityComponent
	{
		// Token: 0x170082F8 RID: 33528
		// (get) Token: 0x06030BD6 RID: 199638 RVA: 0x00C0AE74 File Offset: 0x00C09074
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> Actions
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				TriggerComponent config = this.Config;
				if (config != null && config.ClientPrePerformance.GetValueOrDefault())
				{
					TriggerComponent config2 = this.Config;
					if (((config2 != null) ? config2.Actions : null) != null)
					{
						List<ActionInfo> list = new List<ActionInfo>();
						foreach (ActionInfo actionInfo in this.Config.Actions)
						{
							if (actionInfo.Name != EAction.PlayEffect)
							{
								list.Add(actionInfo);
							}
						}
						return list;
					}
					return null;
				}
				else
				{
					TriggerComponent config3 = this.Config;
					if (config3 == null)
					{
						return null;
					}
					return config3.Actions;
				}
			}
		}

		// Token: 0x170082F9 RID: 33529
		// (get) Token: 0x06030BD7 RID: 199639 RVA: 0x00C0AF24 File Offset: 0x00C09124
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> ExitActions
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				TriggerComponent config = this.Config;
				if (config != null && config.ClientPrePerformance.GetValueOrDefault())
				{
					TriggerComponent config2 = this.Config;
					bool flag;
					if (config2 == null)
					{
						flag = (null != null);
					}
					else
					{
						ITriggerExitConfig exitConfig = config2.ExitConfig;
						flag = (((exitConfig != null) ? exitConfig.Actions : null) != null);
					}
					if (flag)
					{
						List<ActionInfo> list = new List<ActionInfo>();
						foreach (ActionInfo actionInfo in this.Config.ExitConfig.Actions)
						{
							if (actionInfo.Name != EAction.PlayEffect)
							{
								list.Add(actionInfo);
							}
						}
						return list;
					}
					return null;
				}
				else
				{
					TriggerComponent config3 = this.Config;
					if (config3 == null)
					{
						return null;
					}
					ITriggerExitConfig exitConfig2 = config3.ExitConfig;
					if (exitConfig2 == null)
					{
						return null;
					}
					return exitConfig2.Actions;
				}
			}
		}

		// Token: 0x06030BD8 RID: 199640 RVA: 0x00C0AFF0 File Offset: 0x00C091F0
		protected override bool OnInitData(IEntityArgs args = null)
		{
			object obj;
			if (args == null)
			{
				obj = null;
			}
			else
			{
				CreateEntityData p = args.GetP1<CreateEntityData>();
				obj = ((p != null) ? p.GetParam<TriggerComponent>() : null);
			}
			TriggerComponent config = obj as TriggerComponent;
			PawnSensoryInfoComponent component = base.Entity.GetComponent<PawnSensoryInfoComponent>();
			if (component != null && component.LogicRange == 0f)
			{
				component.SetLogicRange(300f);
			}
			this.Config = config;
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.EntityConfigId = this.CreatureDataComp.GetPbDataId();
			return true;
		}

		// Token: 0x06030BD9 RID: 199641 RVA: 0x00C0B06C File Offset: 0x00C0926C
		protected override bool OnStart()
		{
			this.RangeComp = base.Entity.GetComponent<RangeComponent>();
			if (this.RangeComp == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[TriggerComponent] RangeComp缺失";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", this.EntityConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			TriggerComponent config = this.Config;
			if (config != null && config.OnlineDisableTip.GetValueOrDefault() && !Singleton<RangeComponentMessageManager>.Instance.HasMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trigger, new TMessageRegisterCallback(this.OnServerMessageEmit)))
			{
				Singleton<RangeComponentMessageManager>.Instance.RegisterMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trigger, new TMessageRegisterCallback(this.OnServerMessageEmit));
			}
			return true;
		}

		// Token: 0x06030BDA RID: 199642 RVA: 0x00C0B120 File Offset: 0x00C09320
		protected override bool OnEnd()
		{
			this.Config = null;
			if (Singleton<RangeComponentMessageManager>.Instance.HasMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trigger, new TMessageRegisterCallback(this.OnServerMessageEmit)))
			{
				Singleton<RangeComponentMessageManager>.Instance.UnRegisterMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trigger, new TMessageRegisterCallback(this.OnServerMessageEmit));
			}
			return true;
		}

		// Token: 0x06030BDB RID: 199643 RVA: 0x00C0B174 File Offset: 0x00C09374
		[NullableContext(1)]
		public TriggerContext CreateTriggerContext(int targetId)
		{
			return TriggerContext.Create(base.Entity.Id, targetId, null, null, null);
		}

		// Token: 0x06030BDC RID: 199644 RVA: 0x00C0B1AD File Offset: 0x00C093AD
		[NullableContext(1)]
		private void OnServerMessageEmit(AccessRangeType accessRangeType, AccessRangeResultType accessRangeResultType, Entity otherEntity, ErrorCode errorCode)
		{
			if (errorCode == ErrorCode.ErrOnlineInteractNotOpen || errorCode == ErrorCode.ErrOnlineInteractNoPermission || errorCode == ErrorCode.ErrInteractMultiGameMode)
			{
				ControllerBase<LevelGamePlayController>.Instance.ShowFakeErrorCodeTips(600064);
			}
		}

		// Token: 0x06030BDD RID: 199645 RVA: 0x00C0B1DC File Offset: 0x00C093DC
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			TriggerComponent triggerComponent = (TriggerComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (triggerComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RangeComp"))
			{
				if (triggerComponent.RangeComp == null)
				{
					this.RangeComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RangeComponent>(this.RangeComp), "RangeComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (triggerComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TriggerComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EntityConfigId"))
			{
				this.EntityConfigId = triggerComponent.EntityConfigId;
			}
			return true;
		}

		// Token: 0x0401C030 RID: 114736
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401C031 RID: 114737
		private RangeComponent RangeComp;

		// Token: 0x0401C032 RID: 114738
		private TriggerComponent Config;

		// Token: 0x0401C033 RID: 114739
		private int EntityConfigId;
	}
}
