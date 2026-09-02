using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047DA RID: 18394
	[NullableContext(2)]
	[Nullable(0)]
	public class DynamicPortalCreatorComponent : EntityComponent
	{
		// Token: 0x0602FB5F RID: 195423 RVA: 0x00B6AA5C File Offset: 0x00B68C5C
		protected override bool OnInitData(IEntityArgs args = null)
		{
			object param = args.GetP1<CreateEntityData>().GetParam<DynamicPortalCreatorComponent>();
			this.Config = (DynamicPortalCreatorComponent)param;
			if (this.Config.Model.Type == EDynamicPortalCreateType.Bullet)
			{
				this.BulletTypeConfig = this.Config.Model;
				this.BulletIds.Add((long)this.BulletTypeConfig.TypeA.BulletId);
				this.BulletIds.Add((long)this.BulletTypeConfig.TypeB.BulletId);
			}
			return true;
		}

		// Token: 0x0602FB60 RID: 195424 RVA: 0x00B6AADD File Offset: 0x00B68CDD
		protected override bool OnStart()
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			if (this.Config.Model.Type == EDynamicPortalCreateType.Bullet)
			{
				this.HitComp = base.Entity.GetComponent<SceneItemHitComponent>();
			}
			return true;
		}

		// Token: 0x0602FB61 RID: 195425 RVA: 0x00B6AB14 File Offset: 0x00B68D14
		protected override void OnActivate()
		{
			if (this.Config.Model.Type == EDynamicPortalCreateType.Bullet)
			{
				this.AddHitEvent();
			}
		}

		// Token: 0x0602FB62 RID: 195426 RVA: 0x00B6AB2E File Offset: 0x00B68D2E
		protected override bool OnEnd()
		{
			if (this.Config.Model.Type == EDynamicPortalCreateType.Bullet)
			{
				this.RemoveHitEvent();
			}
			return true;
		}

		// Token: 0x0602FB63 RID: 195427 RVA: 0x00B6AB49 File Offset: 0x00B68D49
		public IPortalRenderConfig GetPortalRenderConfig()
		{
			DynamicPortalCreatorComponent config = this.Config;
			if (config == null)
			{
				return null;
			}
			return config.Model.RenderConfig;
		}

		// Token: 0x0602FB64 RID: 195428 RVA: 0x00B6AB61 File Offset: 0x00B68D61
		private void AddHitEvent()
		{
			if (this.HitComp == null)
			{
				return;
			}
			this.HitComp.AddComponentHitCondition(this, new SceneItemHitComponent.TSceneItemHitConditionCheck(this.HitBulletIdCheck));
			Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation>(this, EEventName.OnSceneItemHitByHitData, new Action<global::HitInformation>(this.OnSceneItemHit));
		}

		// Token: 0x0602FB65 RID: 195429 RVA: 0x00B6ABA4 File Offset: 0x00B68DA4
		private void RemoveHitEvent()
		{
			if (this.HitComp == null)
			{
				return;
			}
			this.HitComp.RemoveComponentHitCondition(this, new SceneItemHitComponent.TSceneItemHitConditionCheck(this.HitBulletIdCheck));
			if (Singleton<EventSystem>.Instance.HasWithTarget<global::HitInformation>(this, EEventName.OnSceneItemHitByHitData, new Action<global::HitInformation>(this.OnSceneItemHit)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation>(this, EEventName.OnSceneItemHitByHitData, new Action<global::HitInformation>(this.OnSceneItemHit));
			}
		}

		// Token: 0x0602FB66 RID: 195430 RVA: 0x00B6AC10 File Offset: 0x00B68E10
		[NullableContext(1)]
		private bool HitBulletIdCheck(global::HitInformation hitData)
		{
			long bulletId = hitData.BulletId;
			return this.BulletIds.Contains(bulletId);
		}

		// Token: 0x0602FB67 RID: 195431 RVA: 0x00B6AC30 File Offset: 0x00B68E30
		[NullableContext(1)]
		private void OnSceneItemHit(global::HitInformation hitData)
		{
			AwakeDynamicPortalRequest awakeDynamicPortalRequest = AwakeDynamicPortalRequest.Create();
			awakeDynamicPortalRequest.EntityId = this.CreatureDataComp.GetCreatureDataId();
			awakeDynamicPortalRequest.BulletId = ((hitData.BulletId >= -2147483648L && hitData.BulletId <= 2147483647L) ? ((int)hitData.BulletId) : hitData.BulletEntityId);
			awakeDynamicPortalRequest.IsAwake = true;
			Singleton<Net>.Instance.Call<AwakeDynamicPortalResponse>(ERequestMessageId.AwakeDynamicPortalRequest, awakeDynamicPortalRequest, delegate(AwakeDynamicPortalResponse response, Net.CallbackStatus _)
			{
				ErrorCode? errorCode = (response != null) ? new ErrorCode?(response.ErrorCode) : null;
				if (errorCode != null)
				{
					ErrorCode valueOrDefault = errorCode.GetValueOrDefault();
					if (valueOrDefault == ErrorCode.Success || valueOrDefault == ErrorCode.ErrPortalCreatorActive)
					{
						return;
					}
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26043, null, true, true);
			}, 0);
		}

		// Token: 0x0602FB68 RID: 195432 RVA: 0x00B6ACBC File Offset: 0x00B68EBC
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			DynamicPortalCreatorComponent dynamicPortalCreatorComponent = (DynamicPortalCreatorComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (dynamicPortalCreatorComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (dynamicPortalCreatorComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DynamicPortalCreatorComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("HitComp"))
			{
				if (dynamicPortalCreatorComponent.HitComp == null)
				{
					this.HitComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemHitComponent>(this.HitComp), "HitComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BulletIds") && dynamicPortalCreatorComponent.BulletIds != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<long>>(this.BulletIds), "BulletIds"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("BulletTypeConfig"))
			{
				if (dynamicPortalCreatorComponent.BulletTypeConfig == null)
				{
					this.BulletTypeConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IDynamicPortalByBullet>(this.BulletTypeConfig), "BulletTypeConfig"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B555 RID: 111957
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401B556 RID: 111958
		private DynamicPortalCreatorComponent Config;

		// Token: 0x0401B557 RID: 111959
		private SceneItemHitComponent HitComp;

		// Token: 0x0401B558 RID: 111960
		[Nullable(1)]
		private readonly List<long> BulletIds = new List<long>();

		// Token: 0x0401B559 RID: 111961
		private IDynamicPortalByBullet BulletTypeConfig;
	}
}
