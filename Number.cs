using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

// Token: 0x02000051 RID: 81
[JsonConverter(typeof(NumberConverter))]
[Obsolete("请尽量用明确的数值类型")]
[StructLayout(LayoutKind.Explicit)]
public struct Number
{
	// Token: 0x0600015C RID: 348 RVA: 0x0000979E File Offset: 0x0000799E
	private Number(long value, byte tag)
	{
		this._floatValue = 0f;
		this._doubleValue = 0.0;
		this._longValue = value;
		this._typeTag = tag;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x000097C8 File Offset: 0x000079C8
	public static Number FromInt(int value)
	{
		return new Number((long)value, 0);
	}

	// Token: 0x0600015E RID: 350 RVA: 0x000097D4 File Offset: 0x000079D4
	public static Number FromDouble(double value)
	{
		return new Number(0L, 1)
		{
			_doubleValue = value
		};
	}

	// Token: 0x0600015F RID: 351 RVA: 0x000097F4 File Offset: 0x000079F4
	public static Number FromFloat(float value)
	{
		return new Number(0L, 2)
		{
			_floatValue = value
		};
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00009814 File Offset: 0x00007A14
	public bool IsInt()
	{
		return this._typeTag == 0;
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0000981F File Offset: 0x00007A1F
	public bool IsDouble()
	{
		return this._typeTag == 1;
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0000982A File Offset: 0x00007A2A
	public bool IsFloat()
	{
		return this._typeTag == 2;
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00009835 File Offset: 0x00007A35
	public bool IsNaN()
	{
		return (this.IsDouble() && double.IsNaN(this._doubleValue)) || (this.IsFloat() && float.IsNaN(this._floatValue));
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00009863 File Offset: 0x00007A63
	public bool IsInfinity()
	{
		if (this.IsDouble())
		{
			return double.IsInfinity(this._doubleValue);
		}
		return this.IsFloat() && float.IsInfinity(this._floatValue);
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0000988E File Offset: 0x00007A8E
	public int GetInt()
	{
		if (!this.IsInt())
		{
			throw new InvalidOperationException("Number is not an integer");
		}
		return (int)this._longValue;
	}

	// Token: 0x06000166 RID: 358 RVA: 0x000098AA File Offset: 0x00007AAA
	public long GetLong()
	{
		if (!this.IsInt())
		{
			throw new InvalidOperationException("Number is not an integer");
		}
		return this._longValue;
	}

	// Token: 0x06000167 RID: 359 RVA: 0x000098C8 File Offset: 0x00007AC8
	public double GetDouble()
	{
		byte typeTag = this._typeTag;
		double result;
		if (typeTag != 1)
		{
			if (typeTag != 2)
			{
				result = (double)this._longValue;
			}
			else
			{
				result = (double)this._floatValue;
			}
		}
		else
		{
			result = this._doubleValue;
		}
		return result;
	}

	// Token: 0x06000168 RID: 360 RVA: 0x00009904 File Offset: 0x00007B04
	public float GetFloat()
	{
		byte typeTag = this._typeTag;
		float result;
		if (typeTag != 1)
		{
			if (typeTag == 2)
			{
				result = this._floatValue;
			}
			else
			{
				result = (float)this._longValue;
			}
		}
		else
		{
			result = (float)this._doubleValue;
		}
		return result;
	}

	// Token: 0x06000169 RID: 361 RVA: 0x0000993C File Offset: 0x00007B3C
	public static implicit operator Number(int value)
	{
		return Number.FromInt(value);
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00009944 File Offset: 0x00007B44
	public static implicit operator Number(double value)
	{
		return Number.FromDouble(value);
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0000994C File Offset: 0x00007B4C
	public static implicit operator Number(float value)
	{
		return Number.FromFloat(value);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00009954 File Offset: 0x00007B54
	public static implicit operator int(Number number)
	{
		return number.GetInt();
	}

	// Token: 0x0600016D RID: 365 RVA: 0x0000995D File Offset: 0x00007B5D
	public static implicit operator double(Number number)
	{
		return number.GetDouble();
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00009966 File Offset: 0x00007B66
	public static implicit operator float(Number number)
	{
		return number.GetFloat();
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00009970 File Offset: 0x00007B70
	public static Number operator +(Number a, Number b)
	{
		if (a.IsDouble() || b.IsDouble())
		{
			return Number.FromDouble(a.GetDouble() + b.GetDouble());
		}
		if (!a.IsFloat() && !b.IsFloat())
		{
			return Number.FromInt(a.GetInt() + b.GetInt());
		}
		return Number.FromFloat(a.GetFloat() + b.GetFloat());
	}

	// Token: 0x06000170 RID: 368 RVA: 0x000099E0 File Offset: 0x00007BE0
	public static Number operator -(Number a, Number b)
	{
		if (a.IsDouble() || b.IsDouble())
		{
			return Number.FromDouble(a.GetDouble() - b.GetDouble());
		}
		if (!a.IsFloat() && !b.IsFloat())
		{
			return Number.FromInt(a.GetInt() - b.GetInt());
		}
		return Number.FromFloat(a.GetFloat() - b.GetFloat());
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00009A50 File Offset: 0x00007C50
	public static Number operator *(Number a, Number b)
	{
		if (a.IsDouble() || b.IsDouble())
		{
			return Number.FromDouble(a.GetDouble() * b.GetDouble());
		}
		if (!a.IsFloat() && !b.IsFloat())
		{
			return Number.FromInt(a.GetInt() * b.GetInt());
		}
		return Number.FromFloat(a.GetFloat() * b.GetFloat());
	}

	// Token: 0x06000172 RID: 370 RVA: 0x00009AC0 File Offset: 0x00007CC0
	public static Number operator /(Number a, Number b)
	{
		if ((b.IsInt() && b.GetInt() == 0) || (b.IsDouble() && Math.Abs(b.GetDouble()) < 5E-324) || (b.IsFloat() && Math.Abs(b.GetFloat()) < 1E-45f))
		{
			throw new DivideByZeroException("Cannot divide by zero");
		}
		if (a.IsDouble() || b.IsDouble())
		{
			return Number.FromDouble(a.GetDouble() / b.GetDouble());
		}
		if (a.IsFloat() || b.IsFloat())
		{
			return Number.FromFloat(a.GetFloat() / b.GetFloat());
		}
		return Number.FromDouble(a.GetDouble() / b.GetDouble());
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00009B88 File Offset: 0x00007D88
	public static Number operator %(Number a, Number b)
	{
		if ((b.IsInt() && b.GetInt() == 0) || (b.IsDouble() && Math.Abs(b.GetDouble()) < 5E-324) || (b.IsFloat() && Math.Abs(b.GetFloat()) < 1E-45f))
		{
			throw new DivideByZeroException("Cannot modulo by zero");
		}
		if (a.IsDouble() || b.IsDouble())
		{
			return Number.FromDouble(a.GetDouble() % b.GetDouble());
		}
		if (a.IsFloat() || b.IsFloat())
		{
			return Number.FromFloat(a.GetFloat() % b.GetFloat());
		}
		return Number.FromInt(a.GetInt() % b.GetInt());
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00009C50 File Offset: 0x00007E50
	public static Number operator ++(Number a)
	{
		if (a.IsDouble())
		{
			return Number.FromDouble(a.GetDouble() + 1.0);
		}
		if (a.IsFloat())
		{
			return Number.FromFloat(a.GetFloat() + 1f);
		}
		return Number.FromInt(a.GetInt() + 1);
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00009CA8 File Offset: 0x00007EA8
	public static Number operator --(Number a)
	{
		if (a.IsDouble())
		{
			return Number.FromDouble(a.GetDouble() - 1.0);
		}
		if (a.IsFloat())
		{
			return Number.FromFloat(a.GetFloat() - 1f);
		}
		return Number.FromInt(a.GetInt() - 1);
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00009D00 File Offset: 0x00007F00
	public static bool operator ==(Number a, Number b)
	{
		if (a.IsInt() && b.IsInt())
		{
			return a.GetInt() == b.GetInt();
		}
		return Math.Abs(a.GetDouble() - b.GetDouble()) < double.Epsilon;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00009D4F File Offset: 0x00007F4F
	public static bool operator !=(Number a, Number b)
	{
		return !(a == b);
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00009D5B File Offset: 0x00007F5B
	public static bool operator >(Number a, Number b)
	{
		return a.GetDouble() > b.GetDouble();
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00009D6D File Offset: 0x00007F6D
	public static bool operator <=(Number a, Number b)
	{
		return a.GetDouble() <= b.GetDouble();
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00009D82 File Offset: 0x00007F82
	public static bool operator >=(Number a, Number b)
	{
		return a.GetDouble() >= b.GetDouble();
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00009D97 File Offset: 0x00007F97
	public static bool operator <(Number a, Number b)
	{
		return a.GetDouble() < b.GetDouble();
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00009DAC File Offset: 0x00007FAC
	[NullableContext(1)]
	public override string ToString()
	{
		byte typeTag = this._typeTag;
		string result;
		if (typeTag != 0)
		{
			if (typeTag != 2)
			{
				result = this.GetDouble().ToString();
			}
			else
			{
				result = this.GetFloat().ToString();
			}
		}
		else
		{
			result = this.GetInt().ToString();
		}
		return result;
	}

	// Token: 0x0400016E RID: 366
	[FieldOffset(0)]
	private long _longValue;

	// Token: 0x0400016F RID: 367
	[FieldOffset(0)]
	private double _doubleValue;

	// Token: 0x04000170 RID: 368
	[FieldOffset(0)]
	private float _floatValue;

	// Token: 0x04000171 RID: 369
	[FieldOffset(8)]
	private byte _typeTag;

	// Token: 0x04000172 RID: 370
	private const byte IntTag = 0;

	// Token: 0x04000173 RID: 371
	private const byte DoubleTag = 1;

	// Token: 0x04000174 RID: 372
	private const byte FloatTag = 2;

	// Token: 0x04000175 RID: 373
	private const long TagMask = 255L;
}
