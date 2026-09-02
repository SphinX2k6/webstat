using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB0 RID: 19888
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapMapComponentContainer
	{
		// Token: 0x06033845 RID: 211013 RVA: 0x00CE2FF8 File Offset: 0x00CE11F8
		[return: Nullable(2)]
		public TrapMapComponentBase AddComponent(ETrapDefenseMapComponent componentType, TrapMapEntity parent)
		{
			TrapMapComponentBase trapMapComponentBase = TrapDefenseDefine.towerMapComponentConstructors[componentType](parent);
			this.AddInternal(componentType, trapMapComponentBase);
			return trapMapComponentBase;
		}

		// Token: 0x06033846 RID: 211014 RVA: 0x00CE3024 File Offset: 0x00CE1224
		private bool AddInternal(ETrapDefenseMapComponent componentType, TrapMapComponentBase component)
		{
			int componentId = component.ComponentId;
			if (this.ComponentIdMap.ContainsKey(componentId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefense;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[塔防地图]TrapMapComponentContainer.AddInternal->添加组件失败，重复组件Id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("componentId", componentId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.ComponentIdMap[componentId] = component;
			if (!this.ComponentTypeMap.ContainsKey(componentType))
			{
				List<TrapMapComponentBase> value = new List<TrapMapComponentBase>();
				this.ComponentTypeMap[componentType] = value;
			}
			this.ComponentTypeMap[componentType].Add(component);
			component.Add();
			component.Enable = true;
			return true;
		}

		// Token: 0x06033847 RID: 211015 RVA: 0x00CE30C8 File Offset: 0x00CE12C8
		[NullableContext(0)]
		[return: Nullable(2)]
		public T GetComponent<T>(ETrapDefenseMapComponent componentType) where T : TrapMapComponentBase
		{
			List<T> allGeneric = this.GetAllGeneric<T>(componentType);
			if (allGeneric != null && allGeneric.Count > 0)
			{
				return allGeneric[0];
			}
			return default(T);
		}

		// Token: 0x06033848 RID: 211016 RVA: 0x00CE30FC File Offset: 0x00CE12FC
		[NullableContext(2)]
		public TrapMapComponentBase GetComponentById(int componentId)
		{
			if (!this.ComponentIdMap.ContainsKey(componentId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefense;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[塔防地图]TrapMapComponentContainer.GetById->获取组件失败，不存在该组件Id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("componentId", componentId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return this.ComponentIdMap[componentId];
		}

		// Token: 0x06033849 RID: 211017 RVA: 0x00CE3154 File Offset: 0x00CE1354
		[return: Nullable(2)]
		public T GetComponentByFilter<[Nullable(0)] T>(ETrapDefenseMapComponent componentType, Func<T, bool> filterFunc) where T : TrapMapComponentBase
		{
			List<T> allGeneric = this.GetAllGeneric<T>(componentType);
			if (allGeneric != null)
			{
				for (int i = 0; i < allGeneric.Count; i++)
				{
					if (filterFunc(allGeneric[i]))
					{
						return allGeneric[i];
					}
				}
			}
			return default(T);
		}

		// Token: 0x0603384A RID: 211018 RVA: 0x00CE31A0 File Offset: 0x00CE13A0
		[NullableContext(0)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<T> GetAllGeneric<T>(ETrapDefenseMapComponent componentType) where T : TrapMapComponentBase
		{
			List<TrapMapComponentBase> all = this.GetAll(componentType);
			if (all != null)
			{
				List<T> list = new List<T>();
				for (int i = 0; i < all.Count; i++)
				{
					T t = all[i] as T;
					if (t != null)
					{
						list.Add(t);
					}
				}
				return list;
			}
			return null;
		}

		// Token: 0x0603384B RID: 211019 RVA: 0x00CE31F4 File Offset: 0x00CE13F4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<TrapMapComponentBase> GetAll(ETrapDefenseMapComponent componentType)
		{
			if (!this.ComponentTypeMap.ContainsKey(componentType))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefense;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[塔防地图]MapComponentContainer.Get->获取组件失败，不存在该类型组件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("componentType", componentType);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			List<TrapMapComponentBase> list = this.ComponentTypeMap[componentType];
			if (list.Count <= 0 && !this.ComponentTypeMap.ContainsKey(componentType))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.TowerDefense;
				ELogAuthor author2 = ELogAuthor.LYX;
				string message2 = "[塔防地图]MapComponentContainer.Get->获取组件失败，不存在该类型组件";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("componentType", componentType);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			return list;
		}

		// Token: 0x0603384C RID: 211020 RVA: 0x00CE3298 File Offset: 0x00CE1498
		public void RemoveComponent(ETrapDefenseMapComponent componentType)
		{
			List<TrapMapComponentBase> all = this.GetAll(componentType);
			if (all != null)
			{
				for (int i = all.Count - 1; i >= 0; i--)
				{
					TrapMapComponentBase trapMapComponentBase = all[i];
					int componentId = trapMapComponentBase.ComponentId;
					this.ComponentIdMap.Remove(componentId);
					all.RemoveAt(i);
					trapMapComponentBase.Enable = false;
					trapMapComponentBase.Remove();
				}
			}
		}

		// Token: 0x0603384D RID: 211021 RVA: 0x00CE32F4 File Offset: 0x00CE14F4
		public void RemoveAll()
		{
			foreach (KeyValuePair<int, TrapMapComponentBase> keyValuePair in this.ComponentIdMap)
			{
				keyValuePair.Value.Enable = false;
				keyValuePair.Value.Remove();
			}
			this.ComponentIdMap.Clear();
			this.ComponentTypeMap.Clear();
		}

		// Token: 0x0603384E RID: 211022 RVA: 0x00CE3370 File Offset: 0x00CE1570
		public void Init()
		{
			foreach (KeyValuePair<int, TrapMapComponentBase> keyValuePair in this.ComponentIdMap)
			{
				keyValuePair.Value.Init();
			}
		}

		// Token: 0x0603384F RID: 211023 RVA: 0x00CE33C8 File Offset: 0x00CE15C8
		public void Tick(float delta)
		{
			foreach (KeyValuePair<int, TrapMapComponentBase> keyValuePair in this.ComponentIdMap)
			{
				keyValuePair.Value.Tick(delta);
			}
		}

		// Token: 0x0401DD57 RID: 122199
		private readonly Dictionary<int, TrapMapComponentBase> ComponentIdMap = new Dictionary<int, TrapMapComponentBase>();

		// Token: 0x0401DD58 RID: 122200
		private readonly Dictionary<ETrapDefenseMapComponent, List<TrapMapComponentBase>> ComponentTypeMap = new Dictionary<ETrapDefenseMapComponent, List<TrapMapComponentBase>>();
	}
}
