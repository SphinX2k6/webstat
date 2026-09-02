using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007079 RID: 28793
	[NullableContext(1)]
	[Nullable(0)]
	public class EntityCapabilityHostComponent : EntityComponent, ICapabilityGameObject
	{
		// Token: 0x06045C84 RID: 285828 RVA: 0x01242098 File Offset: 0x01240298
		public EntityCapabilityHostComponent()
		{
			this.Host = new CapabilityHostImpl(new CapabilityHostInitParam
			{
				Id = new Func<string>(delegate
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Entity#");
					Entity entity = base.Entity;
					defaultInterpolatedStringHandler.AppendFormatted<int?>((entity != null) ? new int?(entity.Id) : null);
					return defaultInterpolatedStringHandler.ToStringAndClear();
				}),
				IsValid = (() => base.Active),
				GetBoundActor = delegate
				{
					Entity entity = base.Entity;
					if (entity == null)
					{
						return null;
					}
					BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
					if (component == null)
					{
						return null;
					}
					return component.Owner;
				}
			});
		}

		// Token: 0x06045C85 RID: 285829 RVA: 0x012420F1 File Offset: 0x012402F1
		protected override bool OnStart()
		{
			this.Host.Register();
			return true;
		}

		// Token: 0x06045C86 RID: 285830 RVA: 0x012420FF File Offset: 0x012402FF
		protected override bool OnEnd()
		{
			this.Host.Unregister();
			return true;
		}

		// Token: 0x06045C87 RID: 285831 RVA: 0x0124210D File Offset: 0x0124030D
		protected override void OnTick(float deltaMilliseconds)
		{
			this.Host.TickOutside(deltaMilliseconds);
		}

		// Token: 0x06045C88 RID: 285832 RVA: 0x0124211B File Offset: 0x0124031B
		public string GetId()
		{
			return this.Host.GetId();
		}

		// Token: 0x06045C89 RID: 285833 RVA: 0x01242128 File Offset: 0x01240328
		public bool IsValid()
		{
			return this.Host.IsValid();
		}

		// Token: 0x06045C8A RID: 285834 RVA: 0x01242135 File Offset: 0x01240335
		[NullableContext(2)]
		public AActor GetBoundActor()
		{
			return this.Host.GetBoundActor();
		}

		// Token: 0x06045C8B RID: 285835 RVA: 0x01242142 File Offset: 0x01240342
		public T AddCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			return this.Host.AddCapabilityData<T>(ctor);
		}

		// Token: 0x06045C8C RID: 285836 RVA: 0x01242150 File Offset: 0x01240350
		[return: Nullable(2)]
		public T GetCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			return this.Host.GetCapabilityData<T>(ctor);
		}

		// Token: 0x06045C8D RID: 285837 RVA: 0x0124215E File Offset: 0x0124035E
		public T GetOrAddCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			return this.Host.GetOrAddCapabilityData<T>(ctor);
		}

		// Token: 0x06045C8E RID: 285838 RVA: 0x0124216C File Offset: 0x0124036C
		public bool HasCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			return this.Host.HasCapabilityData<T>(ctor);
		}

		// Token: 0x06045C8F RID: 285839 RVA: 0x0124217A File Offset: 0x0124037A
		public T AddCapability<[Nullable(0)] T>(Type ctor) where T : Capability
		{
			return this.Host.AddCapability<T>(ctor);
		}

		// Token: 0x06045C90 RID: 285840 RVA: 0x01242188 File Offset: 0x01240388
		public bool RemoveCapability<[Nullable(0)] T>(Type ctor) where T : Capability
		{
			return this.Host.RemoveCapability<T>(ctor);
		}

		// Token: 0x06045C91 RID: 285841 RVA: 0x01242196 File Offset: 0x01240396
		public IReadOnlyDictionary<Type, Capability> GetCapabilities()
		{
			return this.Host.GetCapabilities();
		}

		// Token: 0x06045C92 RID: 285842 RVA: 0x012421A3 File Offset: 0x012403A3
		[return: Nullable(2)]
		public T GetCapability<[Nullable(0)] T>(Type ctor) where T : Capability
		{
			return this.Host.GetCapability<T>(ctor);
		}

		// Token: 0x06045C93 RID: 285843 RVA: 0x012421B1 File Offset: 0x012403B1
		public void BlockCapabilities(int tag, object instigator)
		{
			this.Host.BlockCapabilities(tag, instigator);
		}

		// Token: 0x06045C94 RID: 285844 RVA: 0x012421C0 File Offset: 0x012403C0
		public void UnblockCapabilities(int tag, object instigator)
		{
			this.Host.UnblockCapabilities(tag, instigator);
		}

		// Token: 0x06045C95 RID: 285845 RVA: 0x012421CF File Offset: 0x012403CF
		public bool IsCapabilityState(Capability cap, CapabilityCommonDefine.ECapabilityState state)
		{
			return this.Host.IsCapabilityState(cap, state);
		}

		// Token: 0x06045C96 RID: 285846 RVA: 0x012421E0 File Offset: 0x012403E0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			EntityCapabilityHostComponent entityCapabilityHostComponent = (EntityCapabilityHostComponent)componentTemplate;
			return !base.CanResetComponentProperty("Host") || entityCapabilityHostComponent.Host == null || base.CheckClearObject(EntityComponentSystem.ClearObject<CapabilityHostImpl>(this.Host), "Host");
		}

		// Token: 0x0402709F RID: 159903
		private readonly CapabilityHostImpl Host;
	}
}
