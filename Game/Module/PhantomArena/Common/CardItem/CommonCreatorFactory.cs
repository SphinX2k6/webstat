using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x02005532 RID: 21810
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonCreatorFactory<[Nullable(2)] TBase>
	{
		// Token: 0x060379F4 RID: 227828 RVA: 0x00E1CBC0 File Offset: 0x00E1ADC0
		[NullableContext(0)]
		public void Register<TChild>() where TChild : TBase, new()
		{
			Type typeFromHandle = typeof(TBase);
			Type typeFromHandle2 = typeof(TChild);
			this.FactoryMap[typeFromHandle2] = (() => Activator.CreateInstance<TChild>());
			this.TypeMapping[typeFromHandle2] = typeFromHandle;
		}

		// Token: 0x060379F5 RID: 227829 RVA: 0x00E1CC1C File Offset: 0x00E1AE1C
		public TChild GetComponent<[Nullable(0)] TChild>() where TChild : TBase, new()
		{
			Type typeFromHandle = typeof(TChild);
			Type type;
			if (this.TypeMapping.TryGetValue(typeFromHandle, out type))
			{
				return (TChild)((object)this.FactoryMap[typeFromHandle]());
			}
			throw new InvalidOperationException("No factory registered for type " + typeFromHandle.FullName);
		}

		// Token: 0x060379F6 RID: 227830 RVA: 0x00E1CC70 File Offset: 0x00E1AE70
		public void RegisterWithKey<[Nullable(0)] TValue>(Enum key) where TValue : TBase, new()
		{
			Type typeFromHandle = typeof(TBase);
			Type typeFromHandle2 = typeof(TValue);
			this.FactoryMap[typeFromHandle2] = (() => Activator.CreateInstance<TValue>());
			this.TypeMapping[typeFromHandle2] = typeFromHandle;
			this.KeyMapping[key.ToString()] = typeFromHandle2;
		}

		// Token: 0x060379F7 RID: 227831 RVA: 0x00E1CCE0 File Offset: 0x00E1AEE0
		public TValue GetComponentWithKey<[Nullable(0)] TValue>(Enum key) where TValue : TBase, new()
		{
			Type type;
			Func<object> func;
			if (this.KeyMapping.TryGetValue(key.ToString(), out type) && this.FactoryMap.TryGetValue(type, out func))
			{
				return (TValue)((object)this.FactoryMap[type]());
			}
			throw new InvalidOperationException("No factory registered for type " + type.FullName);
		}

		// Token: 0x0401FE35 RID: 130613
		private Dictionary<Type, Func<object>> FactoryMap = new Dictionary<Type, Func<object>>();

		// Token: 0x0401FE36 RID: 130614
		private Dictionary<Type, Type> TypeMapping = new Dictionary<Type, Type>();

		// Token: 0x0401FE37 RID: 130615
		private Dictionary<string, Type> KeyMapping = new Dictionary<string, Type>();
	}
}
