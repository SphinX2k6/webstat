using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Extension;

// Token: 0x0200005B RID: 91
[NullableContext(2)]
[Nullable(0)]
public class Deque<T> : IClearable
{
	// Token: 0x060001E8 RID: 488 RVA: 0x0000B590 File Offset: 0x00009790
	public Deque(int capacity = 4)
	{
		this.DefaultCapacity = capacity;
		this.DataArray = new T[capacity];
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0000B5AC File Offset: 0x000097AC
	[NullableContext(1)]
	public void Clone(Deque<T> origin)
	{
		this.Clear();
		this.DataArray = new T[origin.DataArray.Length];
		for (int i = 0; i < origin.Size; i++)
		{
			T t = origin.DataArray[(origin.Head + i) % origin.DataArray.Length];
			this.DataArray[i] = t;
		}
		this.SizeInternal = origin.Size;
		this.Tail = origin.Size;
	}

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x060001EA RID: 490 RVA: 0x0000B625 File Offset: 0x00009825
	public int Size
	{
		get
		{
			return this.SizeInternal;
		}
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0000B630 File Offset: 0x00009830
	[NullableContext(1)]
	public void AddFront(T element)
	{
		if (this.SizeInternal == this.DataArray.Length)
		{
			int num = this.DataArray.Length * 2;
			if (num < this.DataArray.Length + 4)
			{
				num = this.DataArray.Length + 4;
			}
			this.SetCapacity(num);
		}
		int num2 = (this.Head - 1 + this.DataArray.Length) % this.DataArray.Length;
		this.DataArray[num2] = element;
		this.Head = num2;
		this.SizeInternal++;
	}

	// Token: 0x060001EC RID: 492 RVA: 0x0000B6B4 File Offset: 0x000098B4
	[NullableContext(1)]
	public void AddRear(T element)
	{
		if (this.SizeInternal == this.DataArray.Length)
		{
			int num = this.DataArray.Length * 2;
			if (num < this.DataArray.Length + 4)
			{
				num = this.DataArray.Length + 4;
			}
			this.SetCapacity(num);
		}
		this.DataArray[this.Tail] = element;
		this.Tail = (this.Tail + 1) % this.DataArray.Length;
		this.SizeInternal++;
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x060001ED RID: 493 RVA: 0x0000B734 File Offset: 0x00009934
	public T Front
	{
		get
		{
			if (this.SizeInternal == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.WCL, "队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return default(T);
			}
			return this.DataArray[this.Head];
		}
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x060001EE RID: 494 RVA: 0x0000B780 File Offset: 0x00009980
	public T Rear
	{
		get
		{
			if (this.SizeInternal == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.WCL, "队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return default(T);
			}
			int num = (this.Tail - 1 + this.DataArray.Length) % this.DataArray.Length;
			return this.DataArray[num];
		}
	}

	// Token: 0x060001EF RID: 495 RVA: 0x0000B7E4 File Offset: 0x000099E4
	public T RemoveFront()
	{
		if (this.SizeInternal == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.LFJW, "队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return default(T);
		}
		T result = this.DataArray[this.Head];
		this.DataArray[this.Head] = default(T);
		this.Head = (this.Head + 1) % this.DataArray.Length;
		this.SizeInternal--;
		int num = this.DataArray.Length;
		if (num > 4 && num > this.DefaultCapacity)
		{
			int num2 = (int)Math.Floor((double)num / 2.0);
			if (this.SizeInternal == num2)
			{
				int num3 = (int)Math.Floor((double)((float)num * 0.75f));
				if (num3 > this.DefaultCapacity)
				{
					this.SetCapacity(num3);
				}
			}
		}
		return result;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x0000B8C4 File Offset: 0x00009AC4
	public T RemoveRear()
	{
		if (this.SizeInternal == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.WCL, "队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return default(T);
		}
		int num = (this.Tail - 1 + this.DataArray.Length) % this.DataArray.Length;
		T result = this.DataArray[num];
		this.DataArray[num] = default(T);
		this.Tail = num;
		this.SizeInternal--;
		int num2 = this.DataArray.Length;
		if (num2 > 4 && num2 > this.DefaultCapacity)
		{
			int num3 = (int)Math.Floor((double)num2 / 2.0);
			if (this.SizeInternal == num3)
			{
				int num4 = (int)Math.Floor((double)((float)num2 * 0.75f));
				if (num4 > this.DefaultCapacity)
				{
					this.SetCapacity(num4);
				}
			}
		}
		return result;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x0000B9A8 File Offset: 0x00009BA8
	public unsafe T Get(int index)
	{
		if (this.SizeInternal == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.WCL, "队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return default(T);
		}
		if (index < 0 || index >= this.SizeInternal)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Container;
			ELogAuthor author = ELogAuthor.WCL;
			string message = "下标越界";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("index", index);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("size", this.SizeInternal);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return default(T);
		}
		return this.DataArray[(this.Head + index) % this.DataArray.Length];
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x0000BA78 File Offset: 0x00009C78
	private void SetCapacity(int capacity)
	{
		if (this.SizeInternal == 0)
		{
			Array.Resize<T>(ref this.DataArray, capacity);
			this.Head = 0;
			this.Tail = 0;
			return;
		}
		int num = this.DataArray.Length;
		if (capacity < num)
		{
			if (this.Head == 0)
			{
				Array.Resize<T>(ref this.DataArray, capacity);
				this.Tail %= capacity;
				return;
			}
			int num2 = num - capacity;
			int num3 = num - num2;
			if (this.Head < this.Tail)
			{
				int num4 = 0;
				for (int i = num3; i < this.Tail; i++)
				{
					this.DataArray[num4++] = this.DataArray[i];
					this.DataArray[i] = default(T);
				}
				if (num3 <= this.Head)
				{
					this.Head = (this.Head + num2) % capacity;
				}
				int num5 = this.Tail - num3;
				if (num5 > 0)
				{
					this.Tail = num5 % capacity;
				}
				else
				{
					this.Tail %= capacity;
				}
				Array.Resize<T>(ref this.DataArray, capacity);
				return;
			}
			if (this.Head >= this.Tail)
			{
				int num6 = num - this.Head;
				int num7 = capacity - num6;
				for (int j = 0; j < num6; j++)
				{
					this.DataArray[num7 + j] = this.DataArray[this.Head + j];
					this.DataArray[this.Head + j] = default(T);
				}
				Array.Resize<T>(ref this.DataArray, capacity);
				this.Head = num7;
				return;
			}
		}
		else
		{
			Array.Resize<T>(ref this.DataArray, capacity);
			if (this.Tail == 0)
			{
				this.Tail = this.SizeInternal;
				return;
			}
			if (this.Head >= this.Tail)
			{
				int num8 = num - this.Head;
				int num9 = this.DataArray.Length - num8;
				for (int k = 0; k < num8; k++)
				{
					this.DataArray[num9 + k] = this.DataArray[this.Head + k];
					this.DataArray[this.Head + k] = default(T);
				}
				this.Head = num9;
			}
		}
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x060001F3 RID: 499 RVA: 0x0000BCB8 File Offset: 0x00009EB8
	public bool Empty
	{
		get
		{
			return this.SizeInternal == 0;
		}
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0000BCC3 File Offset: 0x00009EC3
	public void Clear()
	{
		Array.Resize<T>(ref this.DataArray, 0);
		this.Head = 0;
		this.Tail = 0;
		this.SizeInternal = 0;
	}

	// Token: 0x040001AB RID: 427
	private const int MINIMUM_GROW = 4;

	// Token: 0x040001AC RID: 428
	private const float THREE_QUARTER = 0.75f;

	// Token: 0x040001AD RID: 429
	[Nullable(1)]
	private T[] DataArray;

	// Token: 0x040001AE RID: 430
	private readonly int DefaultCapacity;

	// Token: 0x040001AF RID: 431
	private int Head;

	// Token: 0x040001B0 RID: 432
	private int Tail;

	// Token: 0x040001B1 RID: 433
	private int SizeInternal;
}
