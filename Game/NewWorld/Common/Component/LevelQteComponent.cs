using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C3 RID: 18627
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelQteComponent : EntityComponent
	{
		// Token: 0x06030920 RID: 198944 RVA: 0x00BF0D60 File Offset: 0x00BEEF60
		protected override bool OnInitData(IEntityArgs args = null)
		{
			LevelQteComponent levelQteComponent = args.GetP1<CreateEntityData>().GetParam<LevelQteComponent>() as LevelQteComponent;
			this.QteConfig = levelQteComponent.QteConfig;
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			return true;
		}

		// Token: 0x06030921 RID: 198945 RVA: 0x00BF0D9C File Offset: 0x00BEEF9C
		protected override bool OnEnd()
		{
			CommonQteContextBase activeQteContext = this.ActiveQteContext;
			if (activeQteContext != null && activeQteContext.IsActive())
			{
				ControllerBase<CommonQteController>.Instance.StopQte(this.ActiveQteContext.HandleId);
			}
			return true;
		}

		// Token: 0x06030922 RID: 198946 RVA: 0x00BF0DC8 File Offset: 0x00BEEFC8
		public bool StartQte(bool restartIfSameQteExist = false)
		{
			CommonQteContextBase activeQteContext = this.ActiveQteContext;
			if (activeQteContext != null && activeQteContext.IsActive() && restartIfSameQteExist)
			{
				ControllerBase<CommonQteController>.Instance.StopQte(this.ActiveQteContext.HandleId);
			}
			IQteType qteConfig = this.QteConfig;
			if ((((qteConfig != null) ? new Aki.TDConfigMgr.Component.EQteType?(qteConfig.Type) : null) ?? ((Aki.TDConfigMgr.Component.EQteType)1)) == Aki.TDConfigMgr.Component.EQteType.SingleBtn)
			{
				this.ActiveQteContext = ControllerBase<CommonQteController>.Instance.StartQte(this.QteConfig.QteId, new TCommonQteCallback(this.OnQteSuccess), new TCommonQteCallback(this.OnQteFailed), EQteSource.Level, null);
				if (this.ActiveQteContext != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06030923 RID: 198947 RVA: 0x00BF0E72 File Offset: 0x00BEF072
		public void StopQte()
		{
			CommonQteContextBase activeQteContext = this.ActiveQteContext;
			if (activeQteContext != null && activeQteContext.IsActive())
			{
				ControllerBase<CommonQteController>.Instance.StopQte(this.ActiveQteContext.HandleId);
			}
		}

		// Token: 0x06030924 RID: 198948 RVA: 0x00BF0E9D File Offset: 0x00BEF09D
		public bool IsQteActive()
		{
			CommonQteContextBase activeQteContext = this.ActiveQteContext;
			return activeQteContext != null && activeQteContext.IsActive();
		}

		// Token: 0x06030925 RID: 198949 RVA: 0x00BF0EB0 File Offset: 0x00BEF0B0
		private void OnQteSuccess(CommonQteContextBase context)
		{
			this.ActiveQteContext = null;
			IQteType qteConfig = this.QteConfig;
			if ((((qteConfig != null) ? new Aki.TDConfigMgr.Component.EQteType?(qteConfig.Type) : null) ?? ((Aki.TDConfigMgr.Component.EQteType)1)) == Aki.TDConfigMgr.Component.EQteType.SingleBtn)
			{
				ISingleBtnQte singleBtnQte = (ISingleBtnQte)this.QteConfig;
				List<ActionInfo> actions = singleBtnQte.SuccessCallback.Actions;
				string sendSelfEvent = singleBtnQte.SuccessCallback.SendSelfEvent;
				if (actions != null)
				{
					ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(actions, this.CreateEntityContext(), null);
				}
				if (sendSelfEvent != null)
				{
					LevelGeneralNetworks.RequestEntitySendEvent(this.CreatureDataComp.GetCreatureDataId(), sendSelfEvent);
				}
				return;
			}
		}

		// Token: 0x06030926 RID: 198950 RVA: 0x00BF0F48 File Offset: 0x00BEF148
		private void OnQteFailed(CommonQteContextBase context)
		{
			this.ActiveQteContext = null;
			IQteType qteConfig = this.QteConfig;
			if ((((qteConfig != null) ? new Aki.TDConfigMgr.Component.EQteType?(qteConfig.Type) : null) ?? ((Aki.TDConfigMgr.Component.EQteType)1)) == Aki.TDConfigMgr.Component.EQteType.SingleBtn)
			{
				ISingleBtnQte singleBtnQte = (ISingleBtnQte)this.QteConfig;
				List<ActionInfo> actions = singleBtnQte.FailureCallback.Actions;
				string sendSelfEvent = singleBtnQte.FailureCallback.SendSelfEvent;
				if (actions != null)
				{
					ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(actions, this.CreateEntityContext(), null);
				}
				if (sendSelfEvent != null)
				{
					LevelGeneralNetworks.RequestEntitySendEvent(this.CreatureDataComp.GetCreatureDataId(), sendSelfEvent);
				}
				return;
			}
		}

		// Token: 0x06030927 RID: 198951 RVA: 0x00BF0FE0 File Offset: 0x00BEF1E0
		[NullableContext(1)]
		private EntityContext CreateEntityContext()
		{
			EntityContext entityContext = EntityContext.Create(base.Entity.Id, null);
			entityContext.ClientExecuteActions = true;
			return entityContext;
		}

		// Token: 0x06030928 RID: 198952 RVA: 0x00BF1010 File Offset: 0x00BEF210
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			LevelQteComponent levelQteComponent = (LevelQteComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (levelQteComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("QteConfig"))
			{
				if (levelQteComponent.QteConfig == null)
				{
					this.QteConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IQteType>(this.QteConfig), "QteConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActiveQteContext"))
			{
				if (levelQteComponent.ActiveQteContext == null)
				{
					this.ActiveQteContext = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CommonQteContextBase>(this.ActiveQteContext), "ActiveQteContext"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401BE99 RID: 114329
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BE9A RID: 114330
		private IQteType QteConfig;

		// Token: 0x0401BE9B RID: 114331
		private CommonQteContextBase ActiveQteContext;
	}
}
