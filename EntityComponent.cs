using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

// Token: 0x02000095 RID: 149
[NullableContext(1)]
[Nullable(0)]
public abstract class EntityComponent : IComponentDependency, IEntityComponentCleaner
{
	// Token: 0x060003A1 RID: 929 RVA: 0x000162BC File Offset: 0x000144BC
	public static int GetByType(string typeName)
	{
		EComponent result;
		if (!Enum.TryParse<EComponent>(typeName, out result))
		{
			return -1;
		}
		return (int)result;
	}

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x060003A2 RID: 930 RVA: 0x000162D6 File Offset: 0x000144D6
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Type[] Dependencies { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; }

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x060003A3 RID: 931 RVA: 0x000162DD File Offset: 0x000144DD
	public bool Valid
	{
		get
		{
			return this.EntityInternal != null && !this.EntityInternal.IsClear;
		}
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x000162F8 File Offset: 0x000144F8
	public EntityComponent()
	{
		Type type = base.GetType();
		this.NeedEnableInternal = EntityComponent.IsOverrideMethod(type, "OnEnable", BindingFlags.Instance | BindingFlags.NonPublic);
		this.NeedDisableInternal = EntityComponent.IsOverrideMethod(type, "OnDisable", BindingFlags.Instance | BindingFlags.NonPublic);
		this.NeedTickInternal = EntityComponent.IsOverrideMethod(type, "OnTick", BindingFlags.Instance | BindingFlags.NonPublic);
		this.NeedForceTickInternal = EntityComponent.IsOverrideMethod(type, "OnForceTick", BindingFlags.Instance | BindingFlags.NonPublic);
		this.NeedAfterTickInternal = EntityComponent.IsOverrideMethod(type, "OnAfterTick", BindingFlags.Instance | BindingFlags.NonPublic);
		this.NeedForceAfterTickInternal = EntityComponent.IsOverrideMethod(type, "OnForceAfterTick", BindingFlags.Instance | BindingFlags.NonPublic);
		this.NeedChangeTimeDilationInternal = EntityComponent.IsOverrideMethod(type, "OnChangeTimeDilation", BindingFlags.Instance | BindingFlags.NonPublic);
		if (Stat.Enable)
		{
			string name = base.GetType().Name;
			Stat[] array;
			if (EntityComponentConstant.StatMap.ContainsKey(name))
			{
				array = EntityComponentConstant.StatMap[name];
			}
			else
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
				EntityComponentConstant.StatMap[name] = array;
			}
			this.CreateStat = array[0];
			this.InitStat = array[1];
			this.ClearStat = array[2];
			this.StartStat = array[3];
			this.EndStat = array[4];
			this.ActivateStat = array[5];
			this.StatTick = array[6];
			this.StatForceTick = array[7];
			this.StatAfterTick = array[8];
			this.StatForceAfterTick = array[9];
		}
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00016480 File Offset: 0x00014680
	private static bool IsOverrideMethod(Type type, string methodName, BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic)
	{
		MethodInfo method = type.GetMethod(methodName, flags);
		return method != null && method.DeclaringType != typeof(EntityComponent);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x000164B6 File Offset: 0x000146B6
	private void ClearInternal()
	{
		this.DisableHandlesMap.Clear();
		this.DisableCount = 0;
		this.EntityInternal = null;
	}

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x060003A7 RID: 935 RVA: 0x000164D1 File Offset: 0x000146D1
	public Entity Entity
	{
		get
		{
			return this.EntityInternal;
		}
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x060003A8 RID: 936 RVA: 0x000164D9 File Offset: 0x000146D9
	public bool Active
	{
		get
		{
			Entity entityInternal = this.EntityInternal;
			return entityInternal != null && entityInternal.Active && this.ActiveInternal;
		}
	}

	// Token: 0x17000084 RID: 132
	// (get) Token: 0x060003A9 RID: 937 RVA: 0x000164F7 File Offset: 0x000146F7
	public bool NeedTick
	{
		get
		{
			return this.NeedTickInternal;
		}
	}

	// Token: 0x17000085 RID: 133
	// (get) Token: 0x060003AA RID: 938 RVA: 0x000164FF File Offset: 0x000146FF
	public bool NeedForceTick
	{
		get
		{
			return this.NeedForceTickInternal;
		}
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x060003AB RID: 939 RVA: 0x00016507 File Offset: 0x00014707
	public bool NeedAfterTick
	{
		get
		{
			return this.NeedAfterTickInternal;
		}
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x060003AC RID: 940 RVA: 0x0001650F File Offset: 0x0001470F
	public bool NeedForceAfterTick
	{
		get
		{
			return this.NeedForceAfterTickInternal;
		}
	}

	// Token: 0x17000088 RID: 136
	// (get) Token: 0x060003AD RID: 941 RVA: 0x00016517 File Offset: 0x00014717
	public float TimeDilation
	{
		get
		{
			return this.Entity.TimeDilation;
		}
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00016524 File Offset: 0x00014724
	private unsafe bool Do(Func<bool> handle, string name)
	{
		try
		{
			if (!handle())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "组件生命周期执行失败";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", this.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("entity", this.Entity.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("component", base.GetType().Name);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return false;
			}
		}
		catch (Exception ex) when (1)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "组件生命周期执行异常";
			Exception error = ex;
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("name", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Id", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("entity", this.Entity.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("component", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("error", ex.Message);
			instance2.ErrorWithStack(module2, author2, message2, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
			return false;
		}
		return true;
	}

	// Token: 0x060003AF RID: 943 RVA: 0x000166E8 File Offset: 0x000148E8
	private bool DoWithStat(Func<bool> handle, Stat stat, string name)
	{
		return this.Do(handle, name);
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x000166F4 File Offset: 0x000148F4
	public bool Create(Entity entity, [Nullable(2)] IEntityArgs args = null)
	{
		this.EntityInternal = entity;
		return this.DoWithStat(() => this.OnCreate(args), this.CreateStat, "Create");
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x0001673C File Offset: 0x0001493C
	public bool Respawn(Entity entity, [Nullable(2)] IEntityArgs args = null)
	{
		this.EntityInternal = entity;
		return this.DoWithStat(() => this.OnCreate(args), this.CreateStat, "Create");
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00016781 File Offset: 0x00014981
	public bool RespawnNew(Entity entity)
	{
		this.EntityInternal = entity;
		return true;
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x0001678B File Offset: 0x0001498B
	[NullableContext(2)]
	public bool InitData(IEntityArgs args = null)
	{
		return this.OnInitData(args);
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x00016794 File Offset: 0x00014994
	public bool Init()
	{
		return this.OnInit();
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0001679C File Offset: 0x0001499C
	public bool Deinit()
	{
		return this.DoWithStat(new Func<bool>(this.OnDeinit), this.InitStat, "OnDeinit");
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x000167BC File Offset: 0x000149BC
	public bool Clear()
	{
		bool result = this.DoWithStat(new Func<bool>(this.OnClear), this.ClearStat, "OnClear");
		this.ClearInternal();
		return result;
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x000167E2 File Offset: 0x000149E2
	public bool Start()
	{
		return this.DoWithStat(new Func<bool>(this.OnStart), this.StartStat, "OnStart");
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00016802 File Offset: 0x00014A02
	public void Activate()
	{
		this.DoWithStat(delegate
		{
			this.OnActivate();
			return true;
		}, this.ActivateStat, "OnActivate");
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x00016822 File Offset: 0x00014A22
	public void PostActivate()
	{
		this.DoWithStat(delegate
		{
			this.OnPostActivate();
			return true;
		}, this.ActivateStat, "OnPostActivate");
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00016842 File Offset: 0x00014A42
	public virtual bool End()
	{
		return this.DoWithStat(new Func<bool>(this.OnEnd), this.EndStat, "OnEnd");
	}

	// Token: 0x060003BB RID: 955 RVA: 0x00016864 File Offset: 0x00014A64
	public void RefreshEnable(EEntityDisableKey reason)
	{
		bool activeInternal = this.ActiveInternal;
		this.ActiveInternal = (this.DisableHandlesMap.Count == 0 && this.DisableKeysMap.Count == 0);
		if (this.EntityInternal != null)
		{
			this.ActiveInternal = (this.ActiveInternal && this.EntityInternal.Active);
		}
		if (this.ActiveInternal == activeInternal)
		{
			return;
		}
		if (this.ActiveInternal)
		{
			if (this.NeedEnableInternal)
			{
				this.Do(delegate
				{
					this.OnEnable();
					return true;
				}, "OnEnable");
				return;
			}
		}
		else if (this.NeedDisableInternal)
		{
			string reasonStr = reason.ToString();
			this.Do(delegate
			{
				this.OnDisable(reasonStr);
				return true;
			}, "OnDisable");
		}
	}

	// Token: 0x060003BC RID: 956 RVA: 0x00016934 File Offset: 0x00014B34
	public void RefreshEnable(string reason)
	{
		bool activeInternal = this.ActiveInternal;
		this.ActiveInternal = (this.DisableHandlesMap.Count == 0 && this.DisableKeysMap.Count == 0);
		if (this.EntityInternal != null)
		{
			this.ActiveInternal = (this.ActiveInternal && this.EntityInternal.Active);
		}
		if (this.ActiveInternal == activeInternal)
		{
			return;
		}
		if (this.ActiveInternal)
		{
			if (this.NeedEnableInternal)
			{
				this.Do(delegate
				{
					this.OnEnable();
					return true;
				}, "OnEnable");
				return;
			}
		}
		else if (this.NeedDisableInternal)
		{
			this.Do(delegate
			{
				this.OnDisable(reason);
				return true;
			}, "OnDisable");
		}
	}

	// Token: 0x060003BD RID: 957 RVA: 0x000169F8 File Offset: 0x00014BF8
	public unsafe bool Enable(int? handle, string reason)
	{
		if (handle != null)
		{
			int? num = handle;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null) && this.DisableHandlesMap.Remove(handle.Value))
			{
				this.RefreshEnable(reason);
				return true;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Entity;
		ELogAuthor author = ELogAuthor.LCC;
		string message = "组件激活失败句柄不存在";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityName", base.GetType().Name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", handle);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		return false;
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00016AE8 File Offset: 0x00014CE8
	public unsafe int Disable(string reason)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "Disable的Reason不能使用undefined";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Component", base.GetType().Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		else if (reason.Length < 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "Disable的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Component", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		int num = this.DisableCount + 1;
		this.DisableCount = num;
		int num2 = num;
		this.DisableHandlesMap[num2] = reason;
		this.RefreshEnable(reason);
		return num2;
	}

	// Token: 0x060003BF RID: 959 RVA: 0x00016BDC File Offset: 0x00014DDC
	public void EnableByKey(EEntityDisableKey key, bool removeAll = true)
	{
		int num;
		if (!this.DisableKeysMap.TryGetValue(key, out num) || num <= 0)
		{
			this.DisableKeysMap.Remove(key);
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
		this.RefreshEnable(key);
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00016C38 File Offset: 0x00014E38
	public void DisableByKey(EEntityDisableKey reasonKey, bool noDuplicate = true)
	{
		int num = Math.Max(0, this.DisableKeysMap.GetValueOrDefault(reasonKey, 0));
		if (noDuplicate && num > 0)
		{
			return;
		}
		this.DisableKeysMap[reasonKey] = num + 1;
		this.RefreshEnable(reasonKey);
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00016C78 File Offset: 0x00014E78
	public unsafe void Tick(float delta)
	{
		if (!this.Active)
		{
			return;
		}
		try
		{
			this.OnTick(delta);
		}
		catch (Exception ex) when (1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "组件 Tick 异常";
			Exception error = ex;
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", this.Entity.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00016D74 File Offset: 0x00014F74
	public unsafe void ForceTick(float delta)
	{
		if (!this.Active)
		{
			return;
		}
		try
		{
			this.OnForceTick(delta);
		}
		catch (Exception ex) when (1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "组件 ForceTick 异常";
			Exception error = ex;
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", this.Entity.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x00016E70 File Offset: 0x00015070
	public unsafe void AfterTick(float delta)
	{
		if (!this.Active)
		{
			return;
		}
		try
		{
			this.OnAfterTick(delta);
		}
		catch (Exception ex) when (1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "组件 AfterTick 异常";
			Exception error = ex;
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", this.Entity.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x00016F6C File Offset: 0x0001516C
	public unsafe void ForceAfterTick(float delta)
	{
		if (!this.Active)
		{
			return;
		}
		try
		{
			this.OnForceAfterTick(delta);
		}
		catch (Exception ex) when (1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "组件 ForceAfterTick 异常";
			Exception error = ex;
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", this.Entity.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x00017068 File Offset: 0x00015268
	public void SetTimeDilation(float timeDilation)
	{
		if (!this.NeedChangeTimeDilationInternal)
		{
			return;
		}
		this.Do(delegate
		{
			this.OnChangeTimeDilation(timeDilation);
			return true;
		}, "OnChangeTimeDilation");
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x000170AA File Offset: 0x000152AA
	[NullableContext(2)]
	protected virtual bool OnCreate(IEntityArgs args = null)
	{
		return true;
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x000170AD File Offset: 0x000152AD
	[NullableContext(2)]
	protected virtual bool OnInitData(IEntityArgs args = null)
	{
		return true;
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x000170B0 File Offset: 0x000152B0
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x000170B3 File Offset: 0x000152B3
	protected virtual bool OnDeinit()
	{
		return true;
	}

	// Token: 0x060003CA RID: 970 RVA: 0x000170B6 File Offset: 0x000152B6
	protected virtual bool OnClear()
	{
		return true;
	}

	// Token: 0x060003CB RID: 971 RVA: 0x000170B9 File Offset: 0x000152B9
	protected virtual bool OnStart()
	{
		return true;
	}

	// Token: 0x060003CC RID: 972 RVA: 0x000170BC File Offset: 0x000152BC
	protected virtual void OnActivate()
	{
	}

	// Token: 0x060003CD RID: 973 RVA: 0x000170BE File Offset: 0x000152BE
	protected virtual void OnPostActivate()
	{
	}

	// Token: 0x060003CE RID: 974 RVA: 0x000170C0 File Offset: 0x000152C0
	protected virtual bool OnEnd()
	{
		return true;
	}

	// Token: 0x060003CF RID: 975 RVA: 0x000170C3 File Offset: 0x000152C3
	protected virtual void OnEnable()
	{
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x000170C5 File Offset: 0x000152C5
	protected virtual void OnDisable(string reason)
	{
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x000170C7 File Offset: 0x000152C7
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x000170C9 File Offset: 0x000152C9
	protected virtual void OnForceTick(float delta)
	{
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x000170CB File Offset: 0x000152CB
	protected virtual void OnAfterTick(float delta)
	{
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x000170CD File Offset: 0x000152CD
	protected virtual void OnForceAfterTick(float delta)
	{
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x000170CF File Offset: 0x000152CF
	protected virtual void OnChangeTimeDilation(float timeDilation)
	{
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x000170D1 File Offset: 0x000152D1
	public virtual void OnEntityWasRecentlyRenderedOnScreenChange(bool wasRecentlyRenderedOnScreen)
	{
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x000170D3 File Offset: 0x000152D3
	public virtual void OnEntityBudgetTickEnableChange(bool enable)
	{
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x000170D8 File Offset: 0x000152D8
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 3);
		defaultInterpolatedStringHandler.AppendLiteral("[object ");
		defaultInterpolatedStringHandler.AppendFormatted(base.GetType().Name);
		defaultInterpolatedStringHandler.AppendLiteral("(Id=");
		Entity entity = this.Entity;
		defaultInterpolatedStringHandler.AppendFormatted<int?>((entity != null) ? new int?(entity.Id) : null);
		defaultInterpolatedStringHandler.AppendLiteral(")");
		defaultInterpolatedStringHandler.AppendFormatted(this.Valid ? "" : "(D)");
		defaultInterpolatedStringHandler.AppendLiteral("]");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0001717C File Offset: 0x0001537C
	public string DumpDisableInfo()
	{
		List<string> list = new List<string>();
		string value = "";
		foreach (KeyValuePair<int, string> keyValuePair in this.DisableHandlesMap)
		{
			List<string> list2 = list;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 4);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("{Component:");
			defaultInterpolatedStringHandler.AppendFormatted(base.GetType().Name);
			defaultInterpolatedStringHandler.AppendLiteral(",Handle:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Key);
			defaultInterpolatedStringHandler.AppendLiteral(",Reason:");
			defaultInterpolatedStringHandler.AppendFormatted(keyValuePair.Value);
			defaultInterpolatedStringHandler.AppendLiteral("}");
			list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			value = " ";
		}
		return string.Join("", list);
	}

	// Token: 0x060003DA RID: 986 RVA: 0x00017268 File Offset: 0x00015468
	public void AddUnResetProperty(params string[] properties)
	{
		if (this.UnResetPropertySet == null)
		{
			this.UnResetPropertySet = new HashSet<string>();
		}
		foreach (string item in properties)
		{
			this.UnResetPropertySet.Add(item);
		}
	}

	// Token: 0x060003DB RID: 987 RVA: 0x000172A9 File Offset: 0x000154A9
	protected bool CanResetComponentProperty(string property)
	{
		return this.UnResetPropertySet == null || this.UnResetPropertySet.Count == 0 || !this.UnResetPropertySet.Contains(property);
	}

	// Token: 0x060003DC RID: 988 RVA: 0x000172D4 File Offset: 0x000154D4
	protected unsafe bool CheckClearObject(bool success, string objectName)
	{
		if (success)
		{
			return true;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Entity;
		ELogAuthor author = ELogAuthor.CJH;
		string message = "组件存在未定义清理方式的Object";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Component", base.GetType().Name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Object", objectName);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return false;
	}

	// Token: 0x060003DD RID: 989 RVA: 0x00017344 File Offset: 0x00015544
	[NullableContext(2)]
	public static bool operator !(EntityComponent component)
	{
		return component == null || !component.Valid;
	}

	// Token: 0x060003DE RID: 990 RVA: 0x00017354 File Offset: 0x00015554
	public virtual bool ClearComponent(EntityComponent componentTemplate)
	{
		if (this.CanResetComponentProperty("EntityInternal"))
		{
			if (componentTemplate.EntityInternal == null)
			{
				this.EntityInternal = null;
			}
			else if (!this.CheckClearObject(EntityComponentSystem.ClearObject<Entity>(this.EntityInternal), "EntityInternal"))
			{
				return false;
			}
		}
		if (this.CanResetComponentProperty("DisableCount"))
		{
			this.DisableCount = componentTemplate.DisableCount;
		}
		if (this.CanResetComponentProperty("DisableHandlesMap") && componentTemplate.DisableHandlesMap != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, string>>(this.DisableHandlesMap), "DisableHandlesMap"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("DisableKeysMap") && componentTemplate.DisableKeysMap != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EEntityDisableKey, int>>(this.DisableKeysMap), "DisableKeysMap"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("CreateStat") && componentTemplate.CreateStat != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.CreateStat), "CreateStat"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("InitStat") && componentTemplate.InitStat != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.InitStat), "InitStat"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("ClearStat") && componentTemplate.ClearStat != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.ClearStat), "ClearStat"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("StartStat") && componentTemplate.StartStat != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StartStat), "StartStat"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("EndStat") && componentTemplate.EndStat != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.EndStat), "EndStat"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("ActivateStat") && componentTemplate.ActivateStat != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.ActivateStat), "ActivateStat"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("StatTick") && componentTemplate.StatTick != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatTick), "StatTick"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("StatForceTick") && componentTemplate.StatForceTick != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatForceTick), "StatForceTick"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("StatAfterTick") && componentTemplate.StatAfterTick != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatAfterTick), "StatAfterTick"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("StatForceAfterTick") && componentTemplate.StatForceAfterTick != null && !this.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatForceAfterTick), "StatForceAfterTick"))
		{
			return false;
		}
		if (this.CanResetComponentProperty("ActiveInternal"))
		{
			this.ActiveInternal = componentTemplate.ActiveInternal;
		}
		return true;
	}

	// Token: 0x0400038D RID: 909
	public const int DISABLE_REASON_LENGTH_LIMIT = 4;

	// Token: 0x0400038E RID: 910
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<string> UnResetPropertySet;

	// Token: 0x0400038F RID: 911
	[Nullable(2)]
	private Entity EntityInternal;

	// Token: 0x04000390 RID: 912
	private int DisableCount;

	// Token: 0x04000391 RID: 913
	private readonly Dictionary<int, string> DisableHandlesMap = new Dictionary<int, string>();

	// Token: 0x04000392 RID: 914
	private readonly Dictionary<EEntityDisableKey, int> DisableKeysMap = new Dictionary<EEntityDisableKey, int>();

	// Token: 0x04000393 RID: 915
	[Nullable(2)]
	private readonly Stat CreateStat;

	// Token: 0x04000394 RID: 916
	[Nullable(2)]
	private readonly Stat InitStat;

	// Token: 0x04000395 RID: 917
	[Nullable(2)]
	private readonly Stat ClearStat;

	// Token: 0x04000396 RID: 918
	[Nullable(2)]
	private readonly Stat StartStat;

	// Token: 0x04000397 RID: 919
	[Nullable(2)]
	private readonly Stat EndStat;

	// Token: 0x04000398 RID: 920
	[Nullable(2)]
	private readonly Stat ActivateStat;

	// Token: 0x04000399 RID: 921
	[Nullable(2)]
	private readonly Stat StatTick;

	// Token: 0x0400039A RID: 922
	[Nullable(2)]
	private readonly Stat StatForceTick;

	// Token: 0x0400039B RID: 923
	[Nullable(2)]
	private readonly Stat StatAfterTick;

	// Token: 0x0400039C RID: 924
	[Nullable(2)]
	private readonly Stat StatForceAfterTick;

	// Token: 0x0400039D RID: 925
	private bool ActiveInternal = true;

	// Token: 0x0400039E RID: 926
	private readonly bool NeedEnableInternal;

	// Token: 0x0400039F RID: 927
	private readonly bool NeedDisableInternal;

	// Token: 0x040003A0 RID: 928
	private readonly bool NeedTickInternal;

	// Token: 0x040003A1 RID: 929
	private readonly bool NeedForceTickInternal;

	// Token: 0x040003A2 RID: 930
	private readonly bool NeedAfterTickInternal;

	// Token: 0x040003A3 RID: 931
	private readonly bool NeedForceAfterTickInternal;

	// Token: 0x040003A4 RID: 932
	private readonly bool NeedChangeTimeDilationInternal;
}
