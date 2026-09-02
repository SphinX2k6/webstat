using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007077 RID: 28791
	[NullableContext(1)]
	[Nullable(0)]
	public class CapabilityHostImpl : ICapabilityGameObject, IClear
	{
		// Token: 0x06045C6A RID: 285802 RVA: 0x01241B59 File Offset: 0x0123FD59
		public CapabilityHostImpl(ICapabilityHostInitParam Init)
		{
			this.Init = Init;
		}

		// Token: 0x06045C6B RID: 285803 RVA: 0x01241B80 File Offset: 0x0123FD80
		public string GetId()
		{
			Func<string> func = this.Init.Id as Func<string>;
			if (func == null)
			{
				return (string)this.Init.Id;
			}
			return func();
		}

		// Token: 0x06045C6C RID: 285804 RVA: 0x01241BB8 File Offset: 0x0123FDB8
		public bool IsValid()
		{
			Func<bool> isValid = this.Init.IsValid;
			return isValid == null || isValid();
		}

		// Token: 0x06045C6D RID: 285805 RVA: 0x01241BD0 File Offset: 0x0123FDD0
		[NullableContext(2)]
		public AActor GetBoundActor()
		{
			Func<AActor> getBoundActor = this.Init.GetBoundActor;
			if (getBoundActor == null)
			{
				return null;
			}
			return getBoundActor();
		}

		// Token: 0x06045C6E RID: 285806 RVA: 0x01241BE8 File Offset: 0x0123FDE8
		public T AddCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			if (this.DataComponents.ContainsKey(ctor))
			{
				return this.DataComponents[ctor] as T;
			}
			T t = (T)((object)Activator.CreateInstance(ctor, new object[]
			{
				this
			}));
			this.DataComponents[ctor] = t;
			t.OnAdded();
			return t;
		}

		// Token: 0x06045C6F RID: 285807 RVA: 0x01241C50 File Offset: 0x0123FE50
		[return: Nullable(2)]
		public T GetCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			CapabilityData valueOrDefault = this.DataComponents.GetValueOrDefault(ctor);
			if (valueOrDefault != null)
			{
				return valueOrDefault as T;
			}
			return default(T);
		}

		// Token: 0x06045C70 RID: 285808 RVA: 0x01241C82 File Offset: 0x0123FE82
		public T GetOrAddCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			T result;
			if ((result = this.GetCapabilityData<T>(ctor)) == null)
			{
				result = this.AddCapabilityData<T>(ctor);
			}
			return result;
		}

		// Token: 0x06045C71 RID: 285809 RVA: 0x01241C9B File Offset: 0x0123FE9B
		public bool HasCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData
		{
			return this.DataComponents.ContainsKey(ctor);
		}

		// Token: 0x06045C72 RID: 285810 RVA: 0x01241CAC File Offset: 0x0123FEAC
		public T AddCapability<[Nullable(0)] T>(Type ctor) where T : Capability
		{
			Capability valueOrDefault = this.Capabilities.GetValueOrDefault(ctor);
			if (valueOrDefault != null)
			{
				return valueOrDefault as T;
			}
			T t = (T)((object)Activator.CreateInstance(ctor, new object[]
			{
				this
			}));
			this.Capabilities[ctor] = t;
			t.Setup();
			t.InternalMarkSetupDone();
			ControllerBase<CapabilityController>.Instance.OnCapabilityAdded(t);
			return t;
		}

		// Token: 0x06045C73 RID: 285811 RVA: 0x01241D24 File Offset: 0x0123FF24
		public bool RemoveCapability<[Nullable(0)] T>(Type ctor) where T : Capability
		{
			Capability valueOrDefault = this.Capabilities.GetValueOrDefault(ctor);
			if (valueOrDefault == null)
			{
				return false;
			}
			this.Capabilities.Remove(ctor);
			ControllerBase<CapabilityController>.Instance.OnCapabilityRemoved(valueOrDefault);
			if (valueOrDefault.IsActive())
			{
				valueOrDefault.OnDeactivated();
				valueOrDefault.InternalSetDeactivated();
			}
			return true;
		}

		// Token: 0x06045C74 RID: 285812 RVA: 0x01241D70 File Offset: 0x0123FF70
		public IReadOnlyDictionary<Type, Capability> GetCapabilities()
		{
			return this.Capabilities;
		}

		// Token: 0x06045C75 RID: 285813 RVA: 0x01241D78 File Offset: 0x0123FF78
		[return: Nullable(2)]
		public T GetCapability<[Nullable(0)] T>(Type ctor) where T : Capability
		{
			return this.Capabilities.GetValueOrDefault(ctor) as T;
		}

		// Token: 0x06045C76 RID: 285814 RVA: 0x01241D90 File Offset: 0x0123FF90
		public void BlockCapabilities(int tag, object instigator)
		{
			foreach (Capability capability in this.Capabilities.Values)
			{
				if (capability.GetConfig().Tags.Contains(tag))
				{
					capability.InternalAddBlock(new ICapabilityBlockEntry
					{
						Tag = tag,
						Instigator = instigator
					});
					ControllerBase<CapabilityController>.Instance.OnCapabilityBlocked(capability, tag);
					if (capability.IsActive())
					{
						capability.OnDeactivated();
						capability.InternalSetDeactivated();
					}
				}
			}
		}

		// Token: 0x06045C77 RID: 285815 RVA: 0x01241E30 File Offset: 0x01240030
		public void UnblockCapabilities(int tag, object instigator)
		{
			foreach (Capability capability in this.Capabilities.Values)
			{
				if (capability.GetConfig().Tags.Contains(tag))
				{
					capability.InternalRemoveBlock(tag, instigator);
					if (!capability.IsBlocked())
					{
						ControllerBase<CapabilityController>.Instance.OnCapabilityUnblocked(capability, tag);
					}
				}
			}
		}

		// Token: 0x06045C78 RID: 285816 RVA: 0x01241EB0 File Offset: 0x012400B0
		public bool IsCapabilityState(Capability cap, CapabilityCommonDefine.ECapabilityState state)
		{
			return cap.GetState() == state;
		}

		// Token: 0x06045C79 RID: 285817 RVA: 0x01241EBB File Offset: 0x012400BB
		public void Register()
		{
			ControllerBase<CapabilityController>.Instance.RegisterGameObject(this);
		}

		// Token: 0x06045C7A RID: 285818 RVA: 0x01241EC8 File Offset: 0x012400C8
		public void Unregister()
		{
			foreach (Capability capability in this.Capabilities.Values)
			{
				ControllerBase<CapabilityController>.Instance.OnCapabilityRemoved(capability);
				if (capability.IsActive())
				{
					capability.OnDeactivated();
					capability.InternalSetDeactivated();
				}
			}
			this.Capabilities.Clear();
			foreach (CapabilityData capabilityData in this.DataComponents.Values)
			{
				capabilityData.OnRemoved();
			}
			this.DataComponents.Clear();
			ControllerBase<CapabilityController>.Instance.UnregisterGameObject(this);
		}

		// Token: 0x06045C7B RID: 285819 RVA: 0x01241FA0 File Offset: 0x012401A0
		public void TickOutside(float deltaMilliseconds)
		{
			ControllerBase<CapabilityController>.Instance.TickHostDefaultGroup(this, deltaMilliseconds);
		}

		// Token: 0x06045C7C RID: 285820 RVA: 0x01241FAE File Offset: 0x012401AE
		public bool ClearObject()
		{
			this.Unregister();
			return true;
		}

		// Token: 0x04027094 RID: 159892
		private readonly Dictionary<Type, CapabilityData> DataComponents = new Dictionary<Type, CapabilityData>();

		// Token: 0x04027095 RID: 159893
		private readonly Dictionary<Type, Capability> Capabilities = new Dictionary<Type, Capability>();

		// Token: 0x04027096 RID: 159894
		private readonly ICapabilityHostInitParam Init;
	}
}
