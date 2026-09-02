using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x0200008C RID: 140
[NullableContext(2)]
[Nullable(0)]
public abstract class Entity : ObjectBase, IGameBudgetManagedObject, IStaticVariableResetter
{
	// Token: 0x0600032D RID: 813 RVA: 0x000131B4 File Offset: 0x000113B4
	static Entity()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(Entity.CreateStaticDefaultValue), new Action(Entity.ResetStaticDefaultValue));
	}

	// Token: 0x0600032E RID: 814 RVA: 0x000131D3 File Offset: 0x000113D3
	public static void CreateStaticDefaultValue()
	{
		Entity._statMap = new Dictionary<string, Stat[]>();
	}

	// Token: 0x0600032F RID: 815 RVA: 0x000131DF File Offset: 0x000113DF
	public static void ResetStaticDefaultValue()
	{
		Entity._staticGameBudgetConfigInternal = null;
		Entity._statMap = null;
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x06000330 RID: 816 RVA: 0x000131ED File Offset: 0x000113ED
	public virtual bool UsePool { get; }

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x06000331 RID: 817 RVA: 0x000131F5 File Offset: 0x000113F5
	// (set) Token: 0x06000332 RID: 818 RVA: 0x000131FD File Offset: 0x000113FD
	public bool IsEncloseSpace
	{
		get
		{
			return this.IsEncloseSpaceInternal;
		}
		set
		{
			this.IsEncloseSpaceInternal = value;
		}
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x06000333 RID: 819 RVA: 0x00013206 File Offset: 0x00011406
	[Nullable(1)]
	protected static TsGameBudgetGroupConfig StaticGameBudgetConfigInternal
	{
		[NullableContext(1)]
		get
		{
			return Entity._staticGameBudgetConfigInternal;
		}
	}

	// Token: 0x06000334 RID: 820 RVA: 0x00013210 File Offset: 0x00011410
	[NullableContext(1)]
	protected virtual TsGameBudgetGroupConfig StaticGameBudgetConfig()
	{
		if (Entity._staticGameBudgetConfigInternal == null)
		{
			Entity._staticGameBudgetConfigInternal = new TsGameBudgetGroupConfig(FNameUtil.GetDynamicFName("NormalEntity").Value, ESignificanceGroup.Low);
		}
		return Entity.StaticGameBudgetConfigInternal;
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x06000335 RID: 821 RVA: 0x00013246 File Offset: 0x00011446
	public uint GameBudgetManagedToken
	{
		get
		{
			return this.GameBudgetManagedTokenInternal;
		}
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000336 RID: 822 RVA: 0x0001324E File Offset: 0x0001144E
	public EExecutedFlag Flag
	{
		get
		{
			return this.FlagInternal;
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x06000337 RID: 823 RVA: 0x00013256 File Offset: 0x00011456
	public TsGameBudgetGroupConfig GameBudgetConfig
	{
		get
		{
			return this.GameBudgetConfigInternal;
		}
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x06000338 RID: 824 RVA: 0x0001325E File Offset: 0x0001145E
	public float DistanceWithCamera
	{
		get
		{
			return this.DistanceWithCameraInternal;
		}
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x06000339 RID: 825 RVA: 0x00013266 File Offset: 0x00011466
	[Nullable(new byte[]
	{
		1,
		1,
		1,
		2
	})]
	private static Dictionary<string, Stat[]> StatMap
	{
		[return: Nullable(new byte[]
		{
			1,
			1,
			1,
			2
		})]
		get
		{
			return Entity._statMap;
		}
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00013270 File Offset: 0x00011470
	public Entity(int id, int index) : base(id, index)
	{
	}

	// Token: 0x0600033B RID: 827 RVA: 0x000132D4 File Offset: 0x000114D4
	[return: Nullable(new byte[]
	{
		1,
		2
	})]
	private Stat[] GetStats()
	{
		string name = base.GetType().Name;
		Stat[] array;
		if (!Entity.StatMap.TryGetValue(name, out array))
		{
			array = new Stat[10];
			Stat stat = null;
			array[0] = stat;
			array[1] = stat;
			array[2] = stat;
			array[3] = stat;
			array[4] = stat;
			array[5] = stat;
			array[6] = stat;
			array[7] = stat;
			array[8] = stat;
			array[9] = stat;
			Entity.StatMap[name] = array;
		}
		return array;
	}

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x0600033C RID: 828 RVA: 0x0001333C File Offset: 0x0001153C
	public bool Active
	{
		get
		{
			return this.DisableHandlesMap.Count == 0 && this.DisableKeysMap.Count == 0;
		}
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x0600033D RID: 829 RVA: 0x0001335B File Offset: 0x0001155B
	public float TimeDilation
	{
		get
		{
			return this.TimeDilationInternal;
		}
	}

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x0600033E RID: 830 RVA: 0x00013363 File Offset: 0x00011563
	public bool IsCreate
	{
		get
		{
			return (this.FlagInternal & EExecutedFlag.Create) > EExecutedFlag.None;
		}
	}

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x0600033F RID: 831 RVA: 0x00013370 File Offset: 0x00011570
	public bool IsStart
	{
		get
		{
			return (this.FlagInternal & EExecutedFlag.Start) > EExecutedFlag.None;
		}
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000340 RID: 832 RVA: 0x0001337D File Offset: 0x0001157D
	public bool IsInit
	{
		get
		{
			return (this.FlagInternal & EExecutedFlag.Activate) > EExecutedFlag.None;
		}
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000341 RID: 833 RVA: 0x0001338B File Offset: 0x0001158B
	public bool IsEnd
	{
		get
		{
			return (this.FlagInternal & EExecutedFlag.End) > EExecutedFlag.None;
		}
	}

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000342 RID: 834 RVA: 0x00013399 File Offset: 0x00011599
	public bool IsClear
	{
		get
		{
			return (this.FlagInternal & EExecutedFlag.Clear) > EExecutedFlag.None;
		}
	}

	// Token: 0x06000343 RID: 835 RVA: 0x000133AA File Offset: 0x000115AA
	public void ResetFlag()
	{
		this.FlagInternal = EExecutedFlag.None;
	}

	// Token: 0x06000344 RID: 836 RVA: 0x000133B4 File Offset: 0x000115B4
	[NullableContext(0)]
	[return: Nullable(2)]
	public T GetComponent<T>() where T : EntityComponent
	{
		int index = ComponentIndexGetter<T>.Index;
		if (index >= this.ComponentsRegistry.Count || index < 0)
		{
			return default(T);
		}
		return this.ComponentsRegistry[index] as T;
	}

	// Token: 0x06000345 RID: 837 RVA: 0x000133FC File Offset: 0x000115FC
	[NullableContext(1)]
	[return: Nullable(2)]
	public EntityComponent GetComponent(Type componentType)
	{
		int byType = ComponentIndexGetter<EntityComponent>.GetByType(componentType.Name, false);
		if (byType >= this.ComponentsRegistry.Count || byType < 0)
		{
			return null;
		}
		return this.ComponentsRegistry[byType];
	}

	// Token: 0x06000346 RID: 838 RVA: 0x00013438 File Offset: 0x00011638
	[NullableContext(0)]
	[return: Nullable(2)]
	public unsafe T CheckGetComponent<T>() where T : EntityComponent
	{
		T component = this.GetComponent<T>();
		if (component == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "获取组件失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", typeof(T).Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return component;
	}

	// Token: 0x06000347 RID: 839 RVA: 0x000134E4 File Offset: 0x000116E4
	[NullableContext(1)]
	[return: Nullable(2)]
	protected unsafe T AddComponent<[Nullable(0)] T>(int? priority = null, [Nullable(2)] IEntityArgs args = null) where T : EntityComponent, IComponentDependency, new()
	{
		if ((this.FlagInternal & EExecutedFlag.Create) != EExecutedFlag.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "实体已创建完成不能再添加组件";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", typeof(T).Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return default(T);
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Entity;
		ELogAuthor author2 = ELogAuthor.LCC;
		string message2 = "添加组件";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", this.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("component", typeof(T).Name);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		if (ComponentIndexGetter<T>.Index < 0)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "组件没有在EComponent定义";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("component", typeof(T).Name);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return default(T);
		}
		Type[] dependencies = IComponentDependency.Dependencies;
		if (dependencies != null)
		{
			foreach (Type type in dependencies)
			{
				int byType = ComponentIndexGetter<T>.GetByType(type.Name, false);
				if (byType < 0)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Entity;
					ELogAuthor author4 = ELogAuthor.LFJW;
					string message4 = "依赖组件没有在EComponent定义";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("component", type.Name);
					instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					return default(T);
				}
				if (this.ComponentsRegistry[byType] == null)
				{
					Log instance5 = Singleton<Log>.Instance;
					ELogModule module5 = ELogModule.Entity;
					ELogAuthor author5 = ELogAuthor.LCC;
					string message5 = "添加组件检查依赖失败";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("Id", this.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("component", typeof(T).Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("dependence", type.Name);
					instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 4));
					return default(T);
				}
			}
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(this.Id);
		T t = Singleton<EntityComponentSystem>.Instance.Create<T>(entity, args);
		if (t == null)
		{
			return default(T);
		}
		Type typeFromHandle = typeof(EntityComponent);
		Type type2 = typeof(T);
		while (type2 != null && !(type2 == typeFromHandle) && type2.IsSubclassOf(typeFromHandle))
		{
			int byType2 = ComponentIndexGetter<T>.GetByType(type2.Name, false);
			if (byType2 < 0)
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.Entity;
				ELogAuthor author6 = ELogAuthor.LFJW;
				string message6 = "组件没有在EComponent定义";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("component", type2.Name);
				instance6.Error(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 2));
				return default(T);
			}
			EntityComponent entityComponent = (byType2 < this.ComponentsRegistry.Count) ? this.ComponentsRegistry[byType2] : null;
			if (entityComponent != null)
			{
				Log instance7 = Singleton<Log>.Instance;
				ELogModule module7 = ELogModule.Entity;
				ELogAuthor author7 = ELogAuthor.LCC;
				string message7 = "添加组件失败：组件已存在，请勿重复添加！";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray7 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 1) = new ValueTuple<string, object>("Id", this.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 2) = new ValueTuple<string, object>("AddComponent", type2.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 3) = new ValueTuple<string, object>("ExistComponent", entityComponent.GetType().Name);
				instance7.Error(module7, author7, message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray7, 4));
				return default(T);
			}
			while (this.ComponentsRegistry.Count <= byType2)
			{
				this.ComponentsRegistry.Add(null);
			}
			this.ComponentsRegistry[byType2] = t;
			type2 = type2.BaseType;
		}
		this.Components.Add(t);
		this.TickComponentManager.Add(t, priority);
		return t;
	}

	// Token: 0x06000348 RID: 840 RVA: 0x00013A48 File Offset: 0x00011C48
	protected unsafe EntityComponent AddComponent([Nullable(1)] Type componentType, int? priority = null, IEntityArgs args = null)
	{
		if ((this.FlagInternal & EExecutedFlag.Create) != EExecutedFlag.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "实体已创建完成不能再添加组件";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", componentType.Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return null;
		}
		if (ComponentIndexGetter<EntityComponent>.GetByType(componentType.Name, false) < 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "组件没有在EComponent定义";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("component", componentType.Name);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		PropertyInfo property = componentType.GetProperty("Dependencies", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		if (property != null)
		{
			Type[] array = (Type[])property.GetValue(null);
			if (array != null)
			{
				foreach (Type type in array)
				{
					int byType = ComponentIndexGetter<EntityComponent>.GetByType(type.Name, false);
					if (byType < 0)
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Entity;
						ELogAuthor author3 = ELogAuthor.LFJW;
						string message3 = "依赖组件没有在EComponent定义";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("component", type.Name);
						instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
						return null;
					}
					if (this.ComponentsRegistry[byType] == null)
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.Entity;
						ELogAuthor author4 = ELogAuthor.LCC;
						string message4 = "添加组件检查依赖失败";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Id", this.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("component", componentType.Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("dependence", type.Name);
						instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 4));
						return null;
					}
				}
			}
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(this.Id);
		EntityComponent entityComponent = Singleton<EntityComponentSystem>.Instance.Create(componentType, entity, args);
		if (entityComponent == null)
		{
			return null;
		}
		Type typeFromHandle = typeof(EntityComponent);
		Type type2 = componentType;
		while (type2 != null && !(type2 == typeFromHandle) && type2.IsSubclassOf(typeFromHandle))
		{
			int byType2 = ComponentIndexGetter<EntityComponent>.GetByType(type2.Name, false);
			if (byType2 < 0)
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.Entity;
				ELogAuthor author5 = ELogAuthor.LFJW;
				string message5 = "组件没有在EComponent定义";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("component", type2.Name);
				instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
				return null;
			}
			EntityComponent entityComponent2 = (byType2 < this.ComponentsRegistry.Count) ? this.ComponentsRegistry[byType2] : null;
			if (entityComponent2 != null)
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.Entity;
				ELogAuthor author6 = ELogAuthor.LCC;
				string message6 = "添加组件失败：组件已存在，请勿重复添加！";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("Id", this.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 2) = new ValueTuple<string, object>("AddComponent", type2.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 3) = new ValueTuple<string, object>("ExistComponent", entityComponent2.GetType().Name);
				instance6.Error(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 4));
				return null;
			}
			while (this.ComponentsRegistry.Count <= byType2)
			{
				this.ComponentsRegistry.Add(null);
			}
			this.ComponentsRegistry[byType2] = entityComponent;
			type2 = type2.BaseType;
		}
		this.Components.Add(entityComponent);
		this.TickComponentManager.Add(entityComponent, priority);
		return entityComponent;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x00013ECC File Offset: 0x000120CC
	public void SetTimeDilation(float timeDilation)
	{
		this.TimeDilationInternal = timeDilation;
		foreach (EntityComponent entityComponent in this.Components)
		{
			entityComponent.SetTimeDilation(timeDilation);
		}
	}

	// Token: 0x0600034A RID: 842 RVA: 0x00013F24 File Offset: 0x00012124
	public void ChangeTickInterval(int interval)
	{
		this.TickInterval = interval;
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00013F2D File Offset: 0x0001212D
	public int GetTickInterval()
	{
		return this.TickInterval;
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00013F35 File Offset: 0x00012135
	public float GetDeltaSeconds()
	{
		return this.DeltaSeconds;
	}

	// Token: 0x0600034D RID: 845 RVA: 0x00013F40 File Offset: 0x00012140
	public unsafe void RegisterToGameBudgetController(AActor actor)
	{
		if (!GameBudgetInterfaceController.IsOpen)
		{
			return;
		}
		if (this.GameBudgetConfigInternal == null)
		{
			this.GameBudgetConfigInternal = this.StaticGameBudgetConfig();
			bool afterTick = false;
			foreach (EntityComponent entityComponent in this.Components)
			{
				if (new Action<bool>(entityComponent.OnEntityWasRecentlyRenderedOnScreenChange) != null)
				{
					if (this.OnWasRecentlyRenderComponents == null)
					{
						this.OnWasRecentlyRenderComponents = new List<EntityComponent>();
					}
					this.OnWasRecentlyRenderComponents.Add(entityComponent);
				}
				if (new Action<bool>(entityComponent.OnEntityBudgetTickEnableChange) != null)
				{
					if (this.OnBudgetTickEnableChangeComponents == null)
					{
						this.OnBudgetTickEnableChangeComponents = new List<EntityComponent>();
					}
					this.OnBudgetTickEnableChangeComponents.Add(entityComponent);
				}
				if (entityComponent.NeedAfterTick)
				{
					afterTick = true;
				}
			}
			if (!this.GameBudgetGCHandle.IsAllocated)
			{
				this.GameBudgetGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
			}
			this.GameBudgetManagedTokenInternal = Singleton<GameBudgetInterfaceController>.Instance.RegisterTick(this.GameBudgetConfigInternal.GroupName, this.GameBudgetConfigInternal.SignificanceGroup, this, actor, afterTick, this.OnBudgetTickEnableChangeComponents != null, this.OnWasRecentlyRenderComponents != null, true);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Entity;
		ELogAuthor author = ELogAuthor.WY;
		string message = "Entity注册到时间预算管理器中失败，Token已经存在";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entity", base.GetType().Name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GameBudgetManagedToken", this.GameBudgetManagedTokenInternal);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600034E RID: 846 RVA: 0x000140D4 File Offset: 0x000122D4
	public void UnregisterFromGameBudgetController()
	{
		if (!GameBudgetInterfaceController.IsOpen)
		{
			return;
		}
		if (this.GameBudgetManagedTokenInternal != 0U)
		{
			this.GameBudgetManagedTokenInternal = 0U;
			this.GameBudgetConfigInternal = null;
			Singleton<GameBudgetInterfaceController>.Instance.UnregisterTick(this);
		}
		if (this.GameBudgetGCHandle.IsAllocated)
		{
			this.GameBudgetGCHandle.Free();
		}
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00014124 File Offset: 0x00012324
	public unsafe bool Create(IEntityArgs args = null)
	{
		if (Stat.Enable)
		{
			Stat[] stats = this.GetStats();
			this.CreateStat = stats[0];
			this.InitDataStat = stats[1];
			this.InitStat = stats[2];
			this.ClearStat = stats[3];
			this.StartStat = stats[4];
			this.EndStat = stats[5];
			this.ActivateStat = stats[6];
			this.PostActivateStat = stats[7];
			this.TickStat = stats[8];
			this.AfterTickStat = stats[9];
		}
		try
		{
			if (!this.OnCreate(args))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "Entity创建失败，请检查前面组件的报错";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entity", base.GetType().Name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
		}
		catch (Exception ex) when (1)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "Entity创建执行异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance2.ErrorWithStack(module2, author2, message2, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		this.FlagInternal = EExecutedFlag.Create;
		this.TickComponentManager.Sort();
		return true;
	}

	// Token: 0x06000350 RID: 848 RVA: 0x000142A4 File Offset: 0x000124A4
	public unsafe virtual bool Respawn(IEntityArgs args = null)
	{
		try
		{
			this.OnRespawn(args);
		}
		catch (Exception ex) when (1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "Entity执行Respawn异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		using (List<EntityComponent>.Enumerator enumerator = this.Components.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.Respawn(this, args))
				{
					return false;
				}
			}
		}
		this.FlagInternal = EExecutedFlag.Create;
		return true;
	}

	// Token: 0x06000351 RID: 849 RVA: 0x000143BC File Offset: 0x000125BC
	protected virtual bool OnRespawn(IEntityArgs args = null)
	{
		return true;
	}

	// Token: 0x06000352 RID: 850 RVA: 0x000143C0 File Offset: 0x000125C0
	public unsafe bool InitData(IEntityArgs args = null)
	{
		if ((this.FlagInternal & EExecutedFlag.InitData) != EExecutedFlag.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "Entity重复执行InitData";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		try
		{
			using (List<EntityComponent>.Enumerator enumerator = this.Components.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.InitData(args))
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Entity;
						ELogAuthor author2 = ELogAuthor.LCC;
						string message2 = "Entity初始化失败，请检查前面组件的报错";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entity", base.GetType().Name);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return false;
					}
				}
			}
			if (!this.OnInitData(args))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Entity;
				ELogAuthor author3 = ELogAuthor.LCC;
				string message3 = "Entity初始化失败，请检查前面的报错";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entity", base.GetType().Name);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
		}
		catch (Exception ex) when (1)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.LCC;
			string message4 = "Entity执行InitData异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance4.ErrorWithStack(module4, author4, message4, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return false;
		}
		this.FlagInternal |= EExecutedFlag.InitData;
		return true;
	}

	// Token: 0x06000353 RID: 851 RVA: 0x000145C4 File Offset: 0x000127C4
	protected virtual bool OnInitData(IEntityArgs args = null)
	{
		return true;
	}

	// Token: 0x06000354 RID: 852 RVA: 0x000145C8 File Offset: 0x000127C8
	public unsafe bool Init()
	{
		if ((this.FlagInternal & EExecutedFlag.Init) != EExecutedFlag.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "Entity重复执行Init";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		UKuroJsModelFunctionLibrary.AddEntity(this.Id);
		try
		{
			if (!this.OnInit())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "Entity初始化失败，请检查前面组件的报错";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entity", base.GetType().Name);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
		}
		catch (Exception ex) when (1)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LCC;
			string message3 = "Entity初始化执行异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance3.ErrorWithStack(module3, author3, message3, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return false;
		}
		using (List<EntityComponent>.Enumerator enumerator = this.Components.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.Init())
				{
					return false;
				}
			}
		}
		this.FlagInternal |= EExecutedFlag.Init;
		return true;
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0001479C File Offset: 0x0001299C
	public unsafe bool Clear()
	{
		bool flag = false;
		for (int i = this.Components.Count - 1; i >= 0; i--)
		{
			if (!Singleton<EntityComponentSystem>.Instance.Destroy<EntityComponent>(this, this.Components[i]))
			{
				flag = true;
			}
		}
		if (flag)
		{
			return false;
		}
		try
		{
			if (!this.OnClear())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "清理失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entity", base.GetType().Name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
		}
		catch (Exception ex) when (1)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "Entity清理执行异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance2.ErrorWithStack(module2, author2, message2, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		this.ClearInternal();
		this.FlagInternal |= EExecutedFlag.Clear;
		return true;
	}

	// Token: 0x06000356 RID: 854 RVA: 0x000148F4 File Offset: 0x00012AF4
	private void ClearInternal()
	{
		this.DisableCount = 0;
		this.TickInterval = 0;
		this.TimeDilationInternal = 1f;
		this.IsEncloseSpaceInternal = false;
		this.TickComponentManager.Clear();
		this.DisableHandlesMap.Clear();
		this.DisableKeysMap.Clear();
		this.PendingEnable = null;
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0001494C File Offset: 0x00012B4C
	public unsafe bool Start()
	{
		if ((this.FlagInternal & EExecutedFlag.Start) != EExecutedFlag.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "Entity重复执行Start";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		try
		{
			if (!this.OnStart())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "Entity开始失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entity", base.GetType().Name);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
		}
		catch (Exception ex) when (1)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LCC;
			string message3 = "Entity开始执行异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance3.ErrorWithStack(module3, author3, message3, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return false;
		}
		using (List<EntityComponent>.Enumerator enumerator = this.Components.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.Start())
				{
					return false;
				}
			}
		}
		this.FlagInternal |= EExecutedFlag.Start;
		return true;
	}

	// Token: 0x06000358 RID: 856 RVA: 0x00014B18 File Offset: 0x00012D18
	public void Activate()
	{
		foreach (EntityComponent entityComponent in this.Components)
		{
			entityComponent.Activate();
		}
		this.FlagInternal |= EExecutedFlag.Activate;
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00014B78 File Offset: 0x00012D78
	public unsafe void PostActivate()
	{
		if ((this.FlagInternal & EExecutedFlag.Activate) == EExecutedFlag.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "Entity未执行Activate就执行PostActivate";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		CreatureDataComponent component = this.GetComponent<CreatureDataComponent>();
		long? num = (component != null) ? new long?(component.GetCreatureDataId()) : null;
		if (component != null)
		{
			component.GetPbDataId();
		}
		bool flag = num != null;
		foreach (EntityComponent entityComponent in this.Components)
		{
			entityComponent.PostActivate();
		}
		this.FlagInternal |= EExecutedFlag.PostActivate;
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00014C80 File Offset: 0x00012E80
	public unsafe bool End()
	{
		if ((this.FlagInternal & EExecutedFlag.Start) == EExecutedFlag.None)
		{
			return true;
		}
		bool flag = false;
		for (int i = this.Components.Count - 1; i >= 0; i--)
		{
			if (!this.Components[i].End())
			{
				flag = true;
			}
		}
		if (flag)
		{
			return false;
		}
		try
		{
			if (!this.OnEnd())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "Entity结束失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entity", base.GetType().Name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
		}
		catch (Exception ex) when (1)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "Entity结束执行异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance2.ErrorWithStack(module2, author2, message2, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		this.FlagInternal |= EExecutedFlag.End;
		UKuroJsModelFunctionLibrary.RemoveEntity(this.Id);
		return true;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00014DE0 File Offset: 0x00012FE0
	[NullableContext(1)]
	public unsafe bool Enable(int handle, string reason)
	{
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "Entity.Enable";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", handle);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		if (!this.DisableHandlesMap.ContainsKey(handle))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "Entity实体激活失败句柄不存在";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Handle", handle);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("Reason", reason);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			return false;
		}
		this.DisableHandlesMap.Remove(handle);
		this.RefreshComponentsEnable(reason);
		return true;
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00014F5C File Offset: 0x0001315C
	[NullableContext(1)]
	public unsafe int Disable(string reason)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "Disable的Reason不能使用undefined";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", base.GetType().Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		else if (reason.Length < 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "Disable的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Entity", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		int num = this.DisableCount + 1;
		this.DisableCount = num;
		int num2 = num;
		this.DisableHandlesMap[num2] = reason;
		this.RefreshComponentsEnable(reason);
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "Entity.Disable";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Handle", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("Reason", reason);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		}
		return num2;
	}

	// Token: 0x0600035D RID: 861 RVA: 0x00015124 File Offset: 0x00013324
	public unsafe void EnableByKey(EEntityDisableKey key, bool removeAll = true)
	{
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "Entity.EnableByKey";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("RemoveAll", removeAll);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		if (key != EEntityDisableKey.SetEntityEnable)
		{
			this.EnableByKey(EEntityDisableKey.SetEntityEnable, true);
		}
		int num;
		if (!this.DisableKeysMap.TryGetValue(key, out num) || num <= 0)
		{
			if (num != 0)
			{
				this.DisableKeysMap.Remove(key);
			}
			return;
		}
		if (!removeAll && num > 1)
		{
			this.DisableKeysMap[key] = num - 1;
		}
		else
		{
			this.DisableKeysMap.Remove(key);
		}
		this.RefreshComponentsEnable(key);
	}

	// Token: 0x0600035E RID: 862 RVA: 0x00015243 File Offset: 0x00013443
	public bool HasDisableKey(EEntityDisableKey key)
	{
		return this.DisableKeysMap.ContainsKey(key);
	}

	// Token: 0x0600035F RID: 863 RVA: 0x00015254 File Offset: 0x00013454
	public unsafe void DisableByKey(EEntityDisableKey key, bool noDuplicate = true)
	{
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "Entity.DisableByKey";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("NoDuplicate", noDuplicate);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		int num;
		this.DisableKeysMap.TryGetValue(key, out num);
		num = Math.Max(0, num);
		if (noDuplicate && num > 0)
		{
			return;
		}
		this.DisableKeysMap[key] = num + 1;
		this.RefreshComponentsEnable(key);
	}

	// Token: 0x06000360 RID: 864 RVA: 0x0001534C File Offset: 0x0001354C
	[NullableContext(1)]
	private void RefreshComponentsEnable(object reason)
	{
		if (!this.IsStart)
		{
			this.PendingEnable = reason;
			return;
		}
		for (int i = this.Components.Count - 1; i >= 0; i--)
		{
			this.Components[i].RefreshEnable(reason.ToString());
		}
	}

	// Token: 0x06000361 RID: 865 RVA: 0x00015398 File Offset: 0x00013598
	public void ExecutePendingEnableProcess()
	{
		if (!this.IsStart || this.PendingEnable == null)
		{
			return;
		}
		for (int i = this.Components.Count - 1; i >= 0; i--)
		{
			this.Components[i].RefreshEnable(this.PendingEnable.ToString());
		}
		this.PendingEnable = null;
	}

	// Token: 0x06000362 RID: 866 RVA: 0x000153F1 File Offset: 0x000135F1
	public void ForceTick(float delta)
	{
		if (!this.Active)
		{
			return;
		}
		this.TickComponentManager.ForceTick(delta * this.TimeDilationInternal);
	}

	// Token: 0x06000363 RID: 867 RVA: 0x00015410 File Offset: 0x00013610
	public void ScheduledTick(float deltaSeconds, int deltaFrames, float distance)
	{
		this.DeltaSeconds = deltaSeconds;
		this.TickInterval = deltaFrames;
		this.LastTickFrame = Singleton<Time>.Instance.Frame;
		if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.DistanceWithCameraInternal, (double)distance, null))
		{
			this.DistanceWithCameraInternal = distance;
			if (!Singleton<EntitySystemHelper>.Instance.IsSortDirty)
			{
				Singleton<EntitySystemHelper>.Instance.IsSortDirty = true;
			}
		}
		if (base.Valid && this.IsInit)
		{
			this.Tick(deltaSeconds * 1000f);
		}
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00015494 File Offset: 0x00013694
	public virtual void Tick(float delta)
	{
		if (!this.Active)
		{
			this.TickComponentManager.ClearDelta();
			return;
		}
		this.TickComponentManager.Tick(this.TickInterval, delta * this.TimeDilationInternal);
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000154C3 File Offset: 0x000136C3
	public void ForceAfterTick(float delta)
	{
		if (!this.Active)
		{
			return;
		}
		this.TickComponentManager.ForceAfterTick(delta * this.TimeDilationInternal);
	}

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x06000366 RID: 870 RVA: 0x000154E1 File Offset: 0x000136E1
	public bool HasScheduledAfterTick
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000367 RID: 871 RVA: 0x000154E4 File Offset: 0x000136E4
	public void ScheduledAfterTick(float deltaSeconds, int deltaFrames, float distance)
	{
		if (base.Valid && this.IsInit)
		{
			this.AfterTick(deltaSeconds * 1000f);
		}
	}

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000368 RID: 872 RVA: 0x00015503 File Offset: 0x00013703
	public bool HasOnEnabledChange
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000369 RID: 873 RVA: 0x00015508 File Offset: 0x00013708
	public void OnEnabledChange(bool enable, float distance)
	{
		if (this.OnBudgetTickEnableChangeComponents != null)
		{
			foreach (EntityComponent entityComponent in this.OnBudgetTickEnableChangeComponents)
			{
				entityComponent.OnEntityBudgetTickEnableChange(enable);
			}
		}
	}

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x0600036A RID: 874 RVA: 0x00015564 File Offset: 0x00013764
	public bool HasOnWasRecentlyRenderedOnScreenChange
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0600036B RID: 875 RVA: 0x00015568 File Offset: 0x00013768
	public void OnWasRecentlyRenderedOnScreenChange(bool wasRecentlyRenderedOnScreen)
	{
		if (this.OnWasRecentlyRenderComponents != null)
		{
			foreach (EntityComponent entityComponent in this.OnWasRecentlyRenderComponents)
			{
				entityComponent.OnEntityWasRecentlyRenderedOnScreenChange(wasRecentlyRenderedOnScreen);
			}
		}
	}

	// Token: 0x0600036C RID: 876 RVA: 0x000155C4 File Offset: 0x000137C4
	public GCHandle GetGCHandle()
	{
		return this.GameBudgetGCHandle;
	}

	// Token: 0x0600036D RID: 877 RVA: 0x000155CC File Offset: 0x000137CC
	public void AfterTick(float delta)
	{
		if (!this.Active)
		{
			this.TickComponentManager.ClearDelta();
			return;
		}
		this.TickComponentManager.AfterTick(this.TickInterval, delta * this.TimeDilationInternal);
	}

	// Token: 0x0600036E RID: 878 RVA: 0x000155FB File Offset: 0x000137FB
	protected virtual bool OnCreate(IEntityArgs args = null)
	{
		return true;
	}

	// Token: 0x0600036F RID: 879 RVA: 0x000155FE File Offset: 0x000137FE
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x06000370 RID: 880 RVA: 0x00015601 File Offset: 0x00013801
	protected virtual bool OnDeinit()
	{
		return true;
	}

	// Token: 0x06000371 RID: 881 RVA: 0x00015604 File Offset: 0x00013804
	protected virtual bool OnClear()
	{
		return true;
	}

	// Token: 0x06000372 RID: 882 RVA: 0x00015607 File Offset: 0x00013807
	protected virtual bool OnStart()
	{
		return true;
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0001560A File Offset: 0x0001380A
	protected virtual bool OnEnd()
	{
		return true;
	}

	// Token: 0x06000374 RID: 884 RVA: 0x00015610 File Offset: 0x00013810
	[NullableContext(1)]
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 3);
		defaultInterpolatedStringHandler.AppendLiteral("[object ");
		defaultInterpolatedStringHandler.AppendFormatted(base.GetType().Name);
		defaultInterpolatedStringHandler.AppendLiteral("(Id=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.Id);
		defaultInterpolatedStringHandler.AppendLiteral(")");
		defaultInterpolatedStringHandler.AppendFormatted(base.Valid ? "" : "(D)");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0001568C File Offset: 0x0001388C
	[NullableContext(1)]
	public string DumpDisableInfo()
	{
		List<string> list = new List<string>();
		string value = "";
		foreach (KeyValuePair<int, string> keyValuePair in this.DisableHandlesMap)
		{
			List<string> list2 = list;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("{Handle:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Key);
			defaultInterpolatedStringHandler.AppendLiteral(",Reason:");
			defaultInterpolatedStringHandler.AppendFormatted(keyValuePair.Value);
			defaultInterpolatedStringHandler.AppendLiteral("}");
			list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			value = " ";
		}
		return string.Join("", list);
	}

	// Token: 0x06000376 RID: 886 RVA: 0x00015754 File Offset: 0x00013954
	[NullableContext(1)]
	public string DumpComponentsDisableInfo()
	{
		List<string> list = new List<string>();
		string str = "";
		foreach (EntityComponent entityComponent in this.Components)
		{
			string text = entityComponent.DumpDisableInfo();
			if (!string.IsNullOrEmpty(text))
			{
				list.Add(str + text);
				str = " ";
			}
		}
		return string.Join("", list);
	}

	// Token: 0x06000377 RID: 887 RVA: 0x000157D8 File Offset: 0x000139D8
	public static bool operator !(Entity entity)
	{
		return entity == null || !entity.Valid;
	}

	// Token: 0x04000353 RID: 851
	public const int DISABLE_REASON_LENGTH_LIMIT = 4;

	// Token: 0x04000354 RID: 852
	public const int MILLIONSECOND_PER_SECOND = 1000;

	// Token: 0x04000356 RID: 854
	private Stat CreateStat;

	// Token: 0x04000357 RID: 855
	private Stat InitDataStat;

	// Token: 0x04000358 RID: 856
	private Stat InitStat;

	// Token: 0x04000359 RID: 857
	protected Stat InitStatTdType;

	// Token: 0x0400035A RID: 858
	private Stat ClearStat;

	// Token: 0x0400035B RID: 859
	protected Stat ClearStatTdType;

	// Token: 0x0400035C RID: 860
	private Stat StartStat;

	// Token: 0x0400035D RID: 861
	protected Stat StartStatTdType;

	// Token: 0x0400035E RID: 862
	private Stat EndStat;

	// Token: 0x0400035F RID: 863
	protected Stat EndStatTdType;

	// Token: 0x04000360 RID: 864
	private Stat ActivateStat;

	// Token: 0x04000361 RID: 865
	private Stat PostActivateStat;

	// Token: 0x04000362 RID: 866
	protected Stat ActivateStatTdType;

	// Token: 0x04000363 RID: 867
	private Stat TickStat;

	// Token: 0x04000364 RID: 868
	protected Stat TickStatTdType;

	// Token: 0x04000365 RID: 869
	private Stat AfterTickStat;

	// Token: 0x04000366 RID: 870
	protected Stat AfterTickStatTdType;

	// Token: 0x04000367 RID: 871
	private EExecutedFlag FlagInternal;

	// Token: 0x04000368 RID: 872
	[Nullable(1)]
	public List<EntityComponent> Components = new List<EntityComponent>();

	// Token: 0x04000369 RID: 873
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<EntityComponent> OnWasRecentlyRenderComponents;

	// Token: 0x0400036A RID: 874
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<EntityComponent> OnBudgetTickEnableChangeComponents;

	// Token: 0x0400036B RID: 875
	[Nullable(1)]
	public TickComponentManager TickComponentManager = new TickComponentManager();

	// Token: 0x0400036C RID: 876
	private int DisableCount;

	// Token: 0x0400036D RID: 877
	private float DeltaSeconds;

	// Token: 0x0400036E RID: 878
	private int TickInterval;

	// Token: 0x0400036F RID: 879
	public int LastTickFrame;

	// Token: 0x04000370 RID: 880
	private bool IsEncloseSpaceInternal;

	// Token: 0x04000371 RID: 881
	private float TimeDilationInternal = 1f;

	// Token: 0x04000372 RID: 882
	private static TsGameBudgetGroupConfig _staticGameBudgetConfigInternal;

	// Token: 0x04000373 RID: 883
	private uint GameBudgetManagedTokenInternal;

	// Token: 0x04000374 RID: 884
	private TsGameBudgetGroupConfig GameBudgetConfigInternal;

	// Token: 0x04000375 RID: 885
	private float DistanceWithCameraInternal = -1f;

	// Token: 0x04000376 RID: 886
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly List<EntityComponent> ComponentsRegistry = new List<EntityComponent>();

	// Token: 0x04000377 RID: 887
	[Nullable(1)]
	private readonly Dictionary<int, string> DisableHandlesMap = new Dictionary<int, string>();

	// Token: 0x04000378 RID: 888
	[Nullable(1)]
	private readonly Dictionary<EEntityDisableKey, int> DisableKeysMap = new Dictionary<EEntityDisableKey, int>();

	// Token: 0x04000379 RID: 889
	[Nullable(1)]
	private object PendingEnable;

	// Token: 0x0400037A RID: 890
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		2
	})]
	private static Dictionary<string, Stat[]> _statMap;

	// Token: 0x0400037B RID: 891
	private GCHandle GameBudgetGCHandle;
}
