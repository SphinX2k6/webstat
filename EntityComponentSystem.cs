using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000096 RID: 150
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EntityComponentSystem : Singleton<EntityComponentSystem>
{
	// Token: 0x060003E3 RID: 995 RVA: 0x00017626 File Offset: 0x00015826
	public bool Initialize()
	{
		return true;
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0001762C File Offset: 0x0001582C
	[return: Nullable(2)]
	public EntityComponent Create(Type type, Entity entity, [Nullable(2)] IEntityArgs args = null)
	{
		if (entity.UsePool && !this.ComponentTemplates.ContainsKey(type))
		{
			EntityComponent value = Activator.CreateInstance(type) as EntityComponent;
			this.ComponentTemplates.Add(type, value);
		}
		EntityComponent entityComponent = Activator.CreateInstance(type) as EntityComponent;
		if (!entityComponent.Create(entity, args))
		{
			return null;
		}
		return entityComponent;
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x00017684 File Offset: 0x00015884
	[return: Nullable(2)]
	public T Create<[Nullable(0)] T>(Entity entity, [Nullable(2)] IEntityArgs args = null) where T : EntityComponent, new()
	{
		if (entity.UsePool && !this.ComponentTemplates.ContainsKey(typeof(T)))
		{
			T t = Activator.CreateInstance<T>();
			this.ComponentTemplates.Add(typeof(T), t);
		}
		T t2 = Activator.CreateInstance<T>();
		if (!t2.Create(entity, args))
		{
			return default(T);
		}
		return t2;
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x000176F4 File Offset: 0x000158F4
	public bool Destroy<[Nullable(0)] T>(Entity entity, T component) where T : EntityComponent
	{
		bool flag = component.Clear();
		if (!flag)
		{
			return false;
		}
		if (!entity.UsePool)
		{
			return flag;
		}
		return this.ClearComponent<T>(component);
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x00017728 File Offset: 0x00015928
	private bool ClearComponent<[Nullable(0)] T>(T component) where T : EntityComponent
	{
		Type type = component.GetType();
		EntityComponent entityComponent;
		this.ComponentTemplates.TryGetValue(type, out entityComponent);
		if (entityComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "清理不存在的组件类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Component", type.Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return component.ClearComponent(entityComponent);
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x00017790 File Offset: 0x00015990
	public static bool ClearObject<[Nullable(2)] T>(T obj)
	{
		bool flag = obj == null || obj is Stat || obj is Delegate;
		if (flag)
		{
			return true;
		}
		IList list = obj as IList;
		if (list != null)
		{
			list.Clear();
			return true;
		}
		IClearable clearable = obj as IClearable;
		if (clearable != null)
		{
			clearable.Clear();
			return true;
		}
		IDictionary dictionary = obj as IDictionary;
		if (dictionary == null)
		{
			IClear clear = obj as IClear;
			return clear != null && clear.ClearObject();
		}
		dictionary.Clear();
		return true;
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0001782B File Offset: 0x00015A2B
	[NullableContext(2)]
	public static bool ClearObject<TValue>([Nullable(new byte[]
	{
		2,
		1
	})] HashSet<TValue> obj)
	{
		if (obj != null)
		{
			obj.Clear();
		}
		return true;
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x00017837 File Offset: 0x00015A37
	[NullableContext(2)]
	public static bool ClearObject<TValue>([Nullable(new byte[]
	{
		2,
		1
	})] TArray<TValue> obj)
	{
		if (obj != null)
		{
			obj.Empty(true);
		}
		return true;
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00017844 File Offset: 0x00015A44
	[NullableContext(2)]
	public static bool ClearObject<TValue>([Nullable(new byte[]
	{
		2,
		1
	})] TSet<TValue> obj)
	{
		if (obj != null)
		{
			obj.Empty(0);
		}
		return true;
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x00017851 File Offset: 0x00015A51
	[NullableContext(2)]
	public static bool ClearObject<TKey, TValue>([Nullable(new byte[]
	{
		2,
		1,
		1
	})] TMap<TKey, TValue> obj)
	{
		if (obj != null)
		{
			obj.Empty(0);
		}
		return true;
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0001785E File Offset: 0x00015A5E
	public static bool ClearObject<TKey, TValue>([Nullable(new byte[]
	{
		2,
		1,
		1
	})] ConditionalWeakTable<TKey, TValue> obj) where TKey : class where TValue : class
	{
		return true;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x00017861 File Offset: 0x00015A61
	public static bool ClearObject<T>([Nullable(new byte[]
	{
		2,
		1
	})] WeakSet<T> obj) where T : class
	{
		return true;
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00017864 File Offset: 0x00015A64
	public static bool ClearObject<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
	{
		2,
		1,
		1
	})] WeakMap<TKey, TValue> obj) where TKey : class
	{
		return true;
	}

	// Token: 0x040003A5 RID: 933
	public readonly Dictionary<Type, EntityComponent> ComponentTemplates = new Dictionary<Type, EntityComponent>();

	// Token: 0x040003A6 RID: 934
	public readonly Stat PerformanceStateClearComponent = Stat.Create("PerformanceStateClearComponent", "", "");
}
