using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine.Extension;

// Token: 0x02000071 RID: 113
[NullableContext(2)]
[Nullable(0)]
public class Queue<T> : IEnumerable<T>, IEnumerable, IClearable
{
	// Token: 0x060002A4 RID: 676 RVA: 0x0000E146 File Offset: 0x0000C346
	public Queue(int capacity = 4)
	{
		this.DefaultCapacity = capacity;
		this.DataArray = new T[capacity];
	}

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x060002A5 RID: 677 RVA: 0x0000E161 File Offset: 0x0000C361
	public int Size
	{
		get
		{
			return this.SizeInternal;
		}
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x0000E16C File Offset: 0x0000C36C
	[NullableContext(1)]
	public void Push(T element)
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
		this.Version++;
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x0000E1F8 File Offset: 0x0000C3F8
	public T Pop()
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
		this.Version++;
		int num = this.DataArray.Length;
		if (num > 4 && num > this.DefaultCapacity)
		{
			int num2 = num / 2;
			if (this.SizeInternal == num2)
			{
				int num3 = (int)((float)num * 0.75f);
				if (num3 > this.DefaultCapacity)
				{
					this.SetCapacity(num3);
				}
			}
		}
		return result;
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x0000E2D0 File Offset: 0x0000C4D0
	public bool TryPop(out T Result)
	{
		if (this.SizeInternal == 0)
		{
			Result = default(T);
			return false;
		}
		Result = this.DataArray[this.Head];
		this.DataArray[this.Head] = default(T);
		this.Head = (this.Head + 1) % this.DataArray.Length;
		this.SizeInternal--;
		this.Version++;
		int num = this.DataArray.Length;
		if (num > 4 && num > this.DefaultCapacity)
		{
			int num2 = num / 2;
			if (this.SizeInternal == num2)
			{
				int num3 = (int)((float)num * 0.75f);
				if (num3 > this.DefaultCapacity)
				{
					this.SetCapacity(num3);
				}
			}
		}
		return true;
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x060002A9 RID: 681 RVA: 0x0000E390 File Offset: 0x0000C590
	public T Front
	{
		get
		{
			if (this.SizeInternal == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Container, ELogAuthor.LFJW, "队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return default(T);
			}
			return this.DataArray[this.Head];
		}
	}

	// Token: 0x060002AA RID: 682 RVA: 0x0000E3DB File Offset: 0x0000C5DB
	public bool TryGetFront(out T Result)
	{
		if (this.SizeInternal == 0)
		{
			Result = default(T);
			return false;
		}
		Result = this.DataArray[this.Head];
		return true;
	}

	// Token: 0x060002AB RID: 683 RVA: 0x0000E408 File Offset: 0x0000C608
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

	// Token: 0x060002AC RID: 684 RVA: 0x0000E4D8 File Offset: 0x0000C6D8
	private void SetCapacity(int capacity)
	{
		if (this.SizeInternal == 0)
		{
			this.DataArray = new T[capacity];
			this.Head = 0;
			this.Tail = 0;
			return;
		}
		int num = this.DataArray.Length;
		if (capacity < num)
		{
			if (this.Head == 0)
			{
				T[] array = new T[capacity];
				Array.Copy(this.DataArray, 0, array, 0, capacity);
				this.DataArray = array;
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
				T[] array2 = new T[capacity];
				Array.Copy(this.DataArray, 0, array2, 0, capacity);
				this.DataArray = array2;
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
				T[] array3 = new T[capacity];
				Array.Copy(this.DataArray, 0, array3, 0, capacity);
				this.DataArray = array3;
				this.Head = num7;
				return;
			}
		}
		else
		{
			T[] array4 = new T[capacity];
			Array.Copy(this.DataArray, 0, array4, 0, this.DataArray.Length);
			this.DataArray = array4;
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

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x060002AD RID: 685 RVA: 0x0000E76F File Offset: 0x0000C96F
	public bool Empty
	{
		get
		{
			return this.SizeInternal == 0;
		}
	}

	// Token: 0x060002AE RID: 686 RVA: 0x0000E77A File Offset: 0x0000C97A
	public void Clear()
	{
		Array.Clear(this.DataArray, 0, this.DataArray.Length);
		this.Head = 0;
		this.Tail = 0;
		this.SizeInternal = 0;
		this.Version++;
	}

	// Token: 0x060002AF RID: 687 RVA: 0x0000E7B3 File Offset: 0x0000C9B3
	[NullableContext(1)]
	public IEnumerator<T> GetEnumerator()
	{
		return new Queue<T>.Enumerator(this);
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x0000E7C0 File Offset: 0x0000C9C0
	[NullableContext(1)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x040001F1 RID: 497
	private const int MINIMUM_GROW = 4;

	// Token: 0x040001F2 RID: 498
	private const float THREE_QUARTER = 0.75f;

	// Token: 0x040001F3 RID: 499
	private int Version;

	// Token: 0x040001F4 RID: 500
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private T[] DataArray;

	// Token: 0x040001F5 RID: 501
	private readonly int DefaultCapacity;

	// Token: 0x040001F6 RID: 502
	private int Head;

	// Token: 0x040001F7 RID: 503
	private int Tail;

	// Token: 0x040001F8 RID: 504
	private int SizeInternal;

	// Token: 0x02007188 RID: 29064
	[NullableContext(1)]
	[Nullable(0)]
	private struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		// Token: 0x0604678A RID: 288650 RVA: 0x012ACCC7 File Offset: 0x012AAEC7
		public Enumerator(Queue<T> queue)
		{
			this.<queue>P = queue;
			this.Index = 0;
			this.Current = default(T);
			this.Version = this.<queue>P.Version;
		}

		// Token: 0x0604678B RID: 288651 RVA: 0x012ACCF4 File Offset: 0x012AAEF4
		public bool MoveNext()
		{
			if (this.Version != this.<queue>P.Version)
			{
				throw new InvalidOperationException("The queue was modified during foreach");
			}
			if (this.Index < this.<queue>P.SizeInternal)
			{
				Queue<T> queue = this.<queue>P;
				int index = this.Index;
				this.Index = index + 1;
				this.Current = queue.Get(index);
				return true;
			}
			return false;
		}

		// Token: 0x0604678C RID: 288652 RVA: 0x012ACD57 File Offset: 0x012AAF57
		public void Reset()
		{
			this.Index = 0;
		}

		// Token: 0x1700A768 RID: 42856
		// (get) Token: 0x0604678D RID: 288653 RVA: 0x012ACD60 File Offset: 0x012AAF60
		T IEnumerator<!0>.Current
		{
			get
			{
				return this.Current;
			}
		}

		// Token: 0x1700A769 RID: 42857
		// (get) Token: 0x0604678E RID: 288654 RVA: 0x012ACD68 File Offset: 0x012AAF68
		[Nullable(2)]
		object IEnumerator.Current
		{
			[NullableContext(2)]
			get
			{
				return this.Current;
			}
		}

		// Token: 0x0604678F RID: 288655 RVA: 0x012ACD75 File Offset: 0x012AAF75
		public void Dispose()
		{
		}

		// Token: 0x040278CA RID: 161994
		[CompilerGenerated]
		private Queue<T> <queue>P;

		// Token: 0x040278CB RID: 161995
		private readonly int Version;

		// Token: 0x040278CC RID: 161996
		private int Index;

		// Token: 0x040278CD RID: 161997
		private T Current;
	}
}
