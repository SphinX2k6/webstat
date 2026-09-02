using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007072 RID: 28786
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class Capability : IGameCapability
	{
		// Token: 0x06045C2C RID: 285740 RVA: 0x01240790 File Offset: 0x0123E990
		[NullableContext(2)]
		protected Capability(ICapabilityGameObject ownerGameObject = null)
		{
		}

		// Token: 0x06045C2D RID: 285741 RVA: 0x012407AC File Offset: 0x0123E9AC
		protected virtual ICapabilityConfig GetDefaultConfig()
		{
			return new CapabilityConfig
			{
				Tags = new List<int>(),
				TickGroup = null,
				TickGroupOrder = 100,
				InterruptsTags = new List<int>()
			};
		}

		// Token: 0x06045C2E RID: 285742 RVA: 0x012407EB File Offset: 0x0123E9EB
		public ICapabilityConfig GetConfig()
		{
			if (this.CachedConfig == null)
			{
				this.CachedConfig = this.GetDefaultConfig();
			}
			return this.CachedConfig;
		}

		// Token: 0x06045C2F RID: 285743
		public abstract void Setup();

		// Token: 0x06045C30 RID: 285744
		public abstract void PreTick(float deltaMilliseconds);

		// Token: 0x06045C31 RID: 285745
		public abstract bool ShouldActivate();

		// Token: 0x06045C32 RID: 285746
		public abstract bool ShouldDeactivate();

		// Token: 0x06045C33 RID: 285747
		public abstract void OnActivated();

		// Token: 0x06045C34 RID: 285748 RVA: 0x01240807 File Offset: 0x0123EA07
		public virtual void Activate()
		{
		}

		// Token: 0x06045C35 RID: 285749 RVA: 0x01240809 File Offset: 0x0123EA09
		public virtual void Deactivate()
		{
		}

		// Token: 0x06045C36 RID: 285750
		public abstract void OnDeactivated();

		// Token: 0x06045C37 RID: 285751
		public abstract void TickActive(float deltaMilliseconds);

		// Token: 0x06045C38 RID: 285752 RVA: 0x0124080B File Offset: 0x0123EA0B
		public bool IsActive()
		{
			return this.State == CapabilityCommonDefine.ECapabilityState.Active;
		}

		// Token: 0x06045C39 RID: 285753 RVA: 0x01240816 File Offset: 0x0123EA16
		public bool IsBlocked()
		{
			return this.BlockedBy.Count > 0;
		}

		// Token: 0x06045C3A RID: 285754 RVA: 0x01240826 File Offset: 0x0123EA26
		public CapabilityCommonDefine.ECapabilityState GetState()
		{
			return this.State;
		}

		// Token: 0x06045C3B RID: 285755 RVA: 0x0124082E File Offset: 0x0123EA2E
		public string GetCapabilityId()
		{
			ICapabilityGameObject ownerGameObject = this.OwnerGameObject;
			return ((ownerGameObject != null) ? ownerGameObject.GetId() : null) + ":" + base.GetType().Name;
		}

		// Token: 0x06045C3C RID: 285756 RVA: 0x01240857 File Offset: 0x0123EA57
		public void InternalMarkSetupDone()
		{
			if (this.State == CapabilityCommonDefine.ECapabilityState.Inactive)
			{
				this.State = CapabilityCommonDefine.ECapabilityState.Deactivated;
			}
		}

		// Token: 0x06045C3D RID: 285757 RVA: 0x01240868 File Offset: 0x0123EA68
		public void InternalSetActive()
		{
			if (this.State != CapabilityCommonDefine.ECapabilityState.Active)
			{
				this.State = CapabilityCommonDefine.ECapabilityState.Active;
			}
		}

		// Token: 0x06045C3E RID: 285758 RVA: 0x0124087A File Offset: 0x0123EA7A
		public void InternalSetDeactivated()
		{
			if (this.State == CapabilityCommonDefine.ECapabilityState.Active)
			{
				this.State = CapabilityCommonDefine.ECapabilityState.Deactivated;
			}
		}

		// Token: 0x06045C3F RID: 285759 RVA: 0x0124088C File Offset: 0x0123EA8C
		public void InternalAddBlock(ICapabilityBlockEntry entry)
		{
			this.BlockedBy.Add(entry);
		}

		// Token: 0x06045C40 RID: 285760 RVA: 0x0124089C File Offset: 0x0123EA9C
		public void InternalRemoveBlock(int tag, object instigator)
		{
			for (int i = this.BlockedBy.Count - 1; i >= 0; i--)
			{
				ICapabilityBlockEntry capabilityBlockEntry = this.BlockedBy[i];
				if (capabilityBlockEntry.Tag == tag && capabilityBlockEntry.Instigator == instigator)
				{
					this.BlockedBy.RemoveAt(i);
					return;
				}
			}
		}

		// Token: 0x0402707F RID: 159871
		private CapabilityCommonDefine.ECapabilityState State;

		// Token: 0x04027080 RID: 159872
		private readonly List<ICapabilityBlockEntry> BlockedBy = new List<ICapabilityBlockEntry>();

		// Token: 0x04027081 RID: 159873
		[Nullable(2)]
		private ICapabilityConfig CachedConfig;

		// Token: 0x04027082 RID: 159874
		[Nullable(2)]
		public ICapabilityGameObject OwnerGameObject = ownerGameObject;
	}
}
