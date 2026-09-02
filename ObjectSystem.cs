using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000BCE RID: 3022
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ObjectSystem : Singleton<ObjectSystem>
{
	// Token: 0x060031AA RID: 12714 RVA: 0x0001E4C2 File Offset: 0x0001C6C2
	public bool Initialize()
	{
		this.Objects.Clear();
		this.Versions.Clear();
		this.Indexes.Clear();
		return true;
	}

	// Token: 0x060031AB RID: 12715 RVA: 0x0001E4E8 File Offset: 0x0001C6E8
	[NullableContext(2)]
	public bool IsValid(ObjectBase obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.Index < 0 || obj.Index > 32767 || obj.Id < 0)
		{
			return false;
		}
		ObjectBase objectBase = this.Objects[obj.Index];
		if (objectBase == null)
		{
			return false;
		}
		int? num = (objectBase != null) ? new int?(objectBase.Id) : null;
		int id = obj.Id;
		return num.GetValueOrDefault() == id & num != null;
	}

	// Token: 0x060031AC RID: 12716 RVA: 0x0001E568 File Offset: 0x0001C768
	[NullableContext(0)]
	[return: Nullable(2)]
	public unsafe T Create<T>() where T : ObjectBase
	{
		Stat value = null;
		if (Stat.Enable && !this.StatWeakMap.TryGetValue(typeof(T), out value))
		{
			value = null;
			this.StatWeakMap[typeof(T)] = value;
		}
		T t = default(T);
		int num;
		int num2;
		if (this.Objects.Count <= 32767)
		{
			num = this.Objects.Count;
			t = (T)((object)Activator.CreateInstance(typeof(T), new object[]
			{
				0,
				num
			}));
			this.Objects.Add(t);
			this.Versions.Add(1);
			num2 = 1;
		}
		else
		{
			if (this.Indexes.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "无法分配Object的Id，超出设计最大数量";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MaxIndex", 32767);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Effects.length", this.Objects.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return default(T);
			}
			num = this.Indexes[this.Indexes.Count - 1];
			this.Indexes.RemoveAt(this.Indexes.Count - 1);
			t = (T)((object)Activator.CreateInstance(typeof(T), new object[]
			{
				0,
				num
			}));
			this.Objects[num] = t;
			List<int> versions = this.Versions;
			int index = num;
			int num3 = versions[index] + 1;
			versions[index] = num3;
			num2 = num3;
			if (num2 > 65535)
			{
				num2 = 1;
				this.Versions[num] = num2;
			}
		}
		int id = num << 16 | num2;
		t.Id = id;
		return t;
	}

	// Token: 0x060031AD RID: 12717 RVA: 0x0001E774 File Offset: 0x0001C974
	public unsafe bool CreateExternal<[Nullable(0)] T>(T obj) where T : ObjectBase
	{
		int num;
		int num2;
		if (this.Objects.Count < 32767)
		{
			num = this.Objects.Count;
			this.Objects.Add(obj);
			this.Versions.Add(1);
			num2 = 1;
		}
		else
		{
			if (this.Indexes.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "无法分配Object的Id，超出设计最大数量";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MaxIndex", 32767);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Effects.length", this.Objects.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			num = this.Indexes[this.Indexes.Count - 1];
			this.Indexes.RemoveAt(this.Indexes.Count - 1);
			this.Objects[num] = obj;
			List<int> versions = this.Versions;
			int index = num;
			int num3 = versions[index] + 1;
			versions[index] = num3;
			num2 = num3;
			if (num2 > 65535)
			{
				num2 = 1;
				this.Versions[num] = num2;
			}
		}
		int id = num << 16 | num2;
		obj.Id = id;
		obj.Index = num;
		return true;
	}

	// Token: 0x060031AE RID: 12718 RVA: 0x0001E8E0 File Offset: 0x0001CAE0
	public bool Destroy(ObjectBase obj)
	{
		if (!this.IsValid(obj))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Object;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "对象重复销毁";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("class", obj.GetType().Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.Objects[obj.Index] = null;
		this.Indexes.Add(obj.Index);
		return true;
	}

	// Token: 0x04000494 RID: 1172
	private readonly Dictionary<Type, Stat> StatWeakMap = new Dictionary<Type, Stat>();

	// Token: 0x04000495 RID: 1173
	private const int Digit = 32;

	// Token: 0x04000496 RID: 1174
	private const int IndexDigit = 16;

	// Token: 0x04000497 RID: 1175
	public const int VersionDigit = 16;

	// Token: 0x04000498 RID: 1176
	private const int MaxIndex = 32767;

	// Token: 0x04000499 RID: 1177
	private const int MaxVersion = 65535;

	// Token: 0x0400049A RID: 1178
	public readonly List<ObjectBase> Objects = new List<ObjectBase>();

	// Token: 0x0400049B RID: 1179
	private readonly List<int> Versions = new List<int>();

	// Token: 0x0400049C RID: 1180
	private readonly List<int> Indexes = new List<int>();
}
