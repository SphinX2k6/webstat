using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x02004699 RID: 18073
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct TFormulaValue
	{
		// Token: 0x170080BE RID: 32958
		// (get) Token: 0x0602F0A5 RID: 192677 RVA: 0x00B25968 File Offset: 0x00B23B68
		public EFormulaValueType Type { get; }

		// Token: 0x0602F0A6 RID: 192678 RVA: 0x00B25970 File Offset: 0x00B23B70
		[NullableContext(2)]
		private TFormulaValue(EFormulaValueType type, double doubleValue = 0.0, bool boolValue = false, string stringValue = null, Entity entityValue = null, double[] doubleArrayValue = null, ContextParam contextValue = null, [Nullable(new byte[]
		{
			2,
			1
		})] string[] stringArrayValue = null, TagContainer tagContainerValue = null, Vector vectorValue = null, Rotator rotatorValue = null)
		{
			this.Type = type;
			this._doubleValue = doubleValue;
			this._boolValue = boolValue;
			this._stringValue = stringValue;
			this._entityValue = entityValue;
			this._doubleArrayValue = doubleArrayValue;
			this._contextValue = contextValue;
			this._stringArrayValue = stringArrayValue;
			this._tagContainerValue = tagContainerValue;
			this._vectorValue = vectorValue;
			this._rotatorValue = rotatorValue;
		}

		// Token: 0x170080BF RID: 32959
		// (get) Token: 0x0602F0A7 RID: 192679 RVA: 0x00B259D2 File Offset: 0x00B23BD2
		public bool IsNull
		{
			get
			{
				return this.Type == EFormulaValueType.None;
			}
		}

		// Token: 0x0602F0A8 RID: 192680 RVA: 0x00B259E0 File Offset: 0x00B23BE0
		public static TFormulaValue FromInt(int value)
		{
			return new TFormulaValue(EFormulaValueType.Double, (double)value, false, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0602F0A9 RID: 192681 RVA: 0x00B25A00 File Offset: 0x00B23C00
		public static TFormulaValue FromLong(long value)
		{
			return new TFormulaValue(EFormulaValueType.Double, (double)value, false, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0602F0AA RID: 192682 RVA: 0x00B25A20 File Offset: 0x00B23C20
		public static TFormulaValue FromFloat(float value)
		{
			return new TFormulaValue(EFormulaValueType.Double, (double)value, false, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0602F0AB RID: 192683 RVA: 0x00B25A40 File Offset: 0x00B23C40
		public static TFormulaValue FromDouble(double value)
		{
			return new TFormulaValue(EFormulaValueType.Double, value, false, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0602F0AC RID: 192684 RVA: 0x00B25A60 File Offset: 0x00B23C60
		public static TFormulaValue FromBool(bool value)
		{
			return new TFormulaValue(EFormulaValueType.Bool, 0.0, value, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0602F0AD RID: 192685 RVA: 0x00B25A88 File Offset: 0x00B23C88
		public static TFormulaValue FromString(string value)
		{
			return new TFormulaValue(EFormulaValueType.String, 0.0, false, value, null, null, null, null, null, null, null);
		}

		// Token: 0x0602F0AE RID: 192686 RVA: 0x00B25AB0 File Offset: 0x00B23CB0
		public static TFormulaValue FromEntity(Entity value)
		{
			return new TFormulaValue(EFormulaValueType.Entity, 0.0, false, null, value, null, null, null, null, null, null);
		}

		// Token: 0x0602F0AF RID: 192687 RVA: 0x00B25AD8 File Offset: 0x00B23CD8
		public static TFormulaValue FromIntArray(int[] value)
		{
			return new TFormulaValue(EFormulaValueType.DoubleArray, 0.0, false, null, null, Array.ConvertAll<int, double>(value, (int v) => (double)v), null, null, null, null, null);
		}

		// Token: 0x0602F0B0 RID: 192688 RVA: 0x00B25B24 File Offset: 0x00B23D24
		public static TFormulaValue FromLongArray(long[] value)
		{
			return new TFormulaValue(EFormulaValueType.DoubleArray, 0.0, false, null, null, Array.ConvertAll<long, double>(value, (long v) => (double)v), null, null, null, null, null);
		}

		// Token: 0x0602F0B1 RID: 192689 RVA: 0x00B25B70 File Offset: 0x00B23D70
		public static TFormulaValue FromDoubleArray(double[] value)
		{
			return new TFormulaValue(EFormulaValueType.DoubleArray, 0.0, false, null, null, value, null, null, null, null, null);
		}

		// Token: 0x0602F0B2 RID: 192690 RVA: 0x00B25B98 File Offset: 0x00B23D98
		[NullableContext(2)]
		public static TFormulaValue FromContext(ContextParam value)
		{
			if (value != null)
			{
				return new TFormulaValue(EFormulaValueType.Context, 0.0, false, null, null, null, value, null, null, null, null);
			}
			return default(TFormulaValue);
		}

		// Token: 0x0602F0B3 RID: 192691 RVA: 0x00B25BCC File Offset: 0x00B23DCC
		public static TFormulaValue FromStringArray(string[] value)
		{
			return new TFormulaValue(EFormulaValueType.StringArray, 0.0, false, null, null, null, null, value, null, null, null);
		}

		// Token: 0x0602F0B4 RID: 192692 RVA: 0x00B25BF4 File Offset: 0x00B23DF4
		public static TFormulaValue FromTagContainer(TagContainer value)
		{
			return new TFormulaValue(EFormulaValueType.TagContainer, 0.0, false, null, null, null, null, null, value, null, null);
		}

		// Token: 0x0602F0B5 RID: 192693 RVA: 0x00B25C1C File Offset: 0x00B23E1C
		public static TFormulaValue FromVector(Vector value)
		{
			return new TFormulaValue(EFormulaValueType.Vector, 0.0, false, null, null, null, null, null, null, value, null);
		}

		// Token: 0x0602F0B6 RID: 192694 RVA: 0x00B25C44 File Offset: 0x00B23E44
		public static TFormulaValue FromRotator(Rotator value)
		{
			return new TFormulaValue(EFormulaValueType.Rotator, 0.0, false, null, null, null, null, null, null, null, value);
		}

		// Token: 0x0602F0B7 RID: 192695 RVA: 0x00B25C6C File Offset: 0x00B23E6C
		public static TFormulaValue FromArrayLiteral(TFormulaValue[] values)
		{
			double[] array = new double[values.Length];
			bool flag = true;
			for (int i = 0; i < values.Length; i++)
			{
				double num;
				if (!values[i].TryGetDouble(out num))
				{
					flag = false;
					break;
				}
				array[i] = num;
			}
			if (flag)
			{
				return TFormulaValue.FromDoubleArray(array);
			}
			string[] array2 = new string[values.Length];
			for (int j = 0; j < values.Length; j++)
			{
				string text;
				if (!values[j].TryGetString(out text) || text == null)
				{
					throw new Exception("Array literal only supports number[] or string[]");
				}
				array2[j] = text;
			}
			return TFormulaValue.FromStringArray(array2);
		}

		// Token: 0x0602F0B8 RID: 192696 RVA: 0x00B25CFC File Offset: 0x00B23EFC
		public bool TryGetInt(out int value)
		{
			if (this.Type == EFormulaValueType.Double && this._doubleValue >= -2147483648.0 && this._doubleValue <= 2147483647.0)
			{
				value = (int)this._doubleValue;
				return true;
			}
			value = 0;
			return false;
		}

		// Token: 0x0602F0B9 RID: 192697 RVA: 0x00B25D38 File Offset: 0x00B23F38
		public bool TryGetLong(out long value)
		{
			if (this.Type == EFormulaValueType.Double && this._doubleValue >= -9.223372036854776E+18 && this._doubleValue <= 9.223372036854776E+18)
			{
				value = (long)this._doubleValue;
				return true;
			}
			value = 0L;
			return false;
		}

		// Token: 0x0602F0BA RID: 192698 RVA: 0x00B25D75 File Offset: 0x00B23F75
		public bool TryGetFloat(out float value)
		{
			if (this.Type == EFormulaValueType.Double && this._doubleValue >= -3.4028234663852886E+38 && this._doubleValue <= 3.4028234663852886E+38)
			{
				value = (float)this._doubleValue;
				return true;
			}
			value = 0f;
			return false;
		}

		// Token: 0x0602F0BB RID: 192699 RVA: 0x00B25DB5 File Offset: 0x00B23FB5
		public bool TryGetDouble(out double value)
		{
			value = this._doubleValue;
			return this.Type == EFormulaValueType.Double;
		}

		// Token: 0x0602F0BC RID: 192700 RVA: 0x00B25DC8 File Offset: 0x00B23FC8
		public bool TryGetBool(out bool value)
		{
			value = this._boolValue;
			return this.Type == EFormulaValueType.Bool;
		}

		// Token: 0x0602F0BD RID: 192701 RVA: 0x00B25DDB File Offset: 0x00B23FDB
		[NullableContext(2)]
		public bool TryGetString(out string value)
		{
			value = this._stringValue;
			return this.Type == EFormulaValueType.String;
		}

		// Token: 0x0602F0BE RID: 192702 RVA: 0x00B25DEE File Offset: 0x00B23FEE
		[NullableContext(2)]
		public bool TryGetEntity(out Entity value)
		{
			value = this._entityValue;
			return this.Type == EFormulaValueType.Entity;
		}

		// Token: 0x0602F0BF RID: 192703 RVA: 0x00B25E04 File Offset: 0x00B24004
		[NullableContext(2)]
		public bool TryGetIntArray(out int[] value)
		{
			if (this.Type == EFormulaValueType.DoubleArray && this._doubleArrayValue != null)
			{
				value = Array.ConvertAll<double, int>(this._doubleArrayValue, (double element) => (int)element);
				return true;
			}
			value = null;
			return false;
		}

		// Token: 0x0602F0C0 RID: 192704 RVA: 0x00B25E54 File Offset: 0x00B24054
		[NullableContext(2)]
		public bool TryGetLongArray(out long[] value)
		{
			if (this.Type == EFormulaValueType.DoubleArray && this._doubleArrayValue != null)
			{
				value = Array.ConvertAll<double, long>(this._doubleArrayValue, (double element) => (long)element);
				return true;
			}
			value = null;
			return false;
		}

		// Token: 0x0602F0C1 RID: 192705 RVA: 0x00B25EA4 File Offset: 0x00B240A4
		[NullableContext(2)]
		public bool TryGetDoubleArray(out double[] value)
		{
			value = this._doubleArrayValue;
			return this.Type == EFormulaValueType.DoubleArray;
		}

		// Token: 0x0602F0C2 RID: 192706 RVA: 0x00B25EB7 File Offset: 0x00B240B7
		[NullableContext(2)]
		public bool TryGetContext(out ContextParam value)
		{
			value = this._contextValue;
			return this.Type == EFormulaValueType.Context;
		}

		// Token: 0x0602F0C3 RID: 192707 RVA: 0x00B25ECA File Offset: 0x00B240CA
		public bool TryGetStringArray([Nullable(new byte[]
		{
			2,
			1
		})] out string[] value)
		{
			value = this._stringArrayValue;
			return this.Type == EFormulaValueType.StringArray;
		}

		// Token: 0x0602F0C4 RID: 192708 RVA: 0x00B25EDD File Offset: 0x00B240DD
		[NullableContext(2)]
		public bool TryGetTagContainer(out TagContainer value)
		{
			value = this._tagContainerValue;
			return this.Type == EFormulaValueType.TagContainer;
		}

		// Token: 0x0602F0C5 RID: 192709 RVA: 0x00B25EF0 File Offset: 0x00B240F0
		[NullableContext(2)]
		public bool TryGetVector(out Vector value)
		{
			value = this._vectorValue;
			return this.Type == EFormulaValueType.Vector;
		}

		// Token: 0x0602F0C6 RID: 192710 RVA: 0x00B25F04 File Offset: 0x00B24104
		[NullableContext(2)]
		public bool TryGetRotator(out Rotator value)
		{
			value = this._rotatorValue;
			return this.Type == EFormulaValueType.Rotator;
		}

		// Token: 0x0602F0C7 RID: 192711 RVA: 0x00B25F18 File Offset: 0x00B24118
		public bool TryGetArrayElement(int index, out TFormulaValue value)
		{
			if (index < 0)
			{
				value = default(TFormulaValue);
				return false;
			}
			if (this.Type == EFormulaValueType.DoubleArray && this._doubleArrayValue != null && index < this._doubleArrayValue.Length)
			{
				value = TFormulaValue.FromDouble(this._doubleArrayValue[index]);
				return true;
			}
			if (this.Type == EFormulaValueType.StringArray && this._stringArrayValue != null && index < this._stringArrayValue.Length)
			{
				value = TFormulaValue.FromString(this._stringArrayValue[index]);
				return true;
			}
			value = default(TFormulaValue);
			return false;
		}

		// Token: 0x0602F0C8 RID: 192712 RVA: 0x00B25F9C File Offset: 0x00B2419C
		public bool TryGetIndex(out int index)
		{
			if (this.Type == EFormulaValueType.Double && this._doubleValue >= -2147483648.0 && this._doubleValue <= 2147483647.0)
			{
				index = (int)this._doubleValue;
				return true;
			}
			index = -1;
			return false;
		}

		// Token: 0x0602F0C9 RID: 192713 RVA: 0x00B25FD8 File Offset: 0x00B241D8
		private static bool IsNumeric(TFormulaValue value)
		{
			return value.Type == EFormulaValueType.Double;
		}

		// Token: 0x0602F0CA RID: 192714 RVA: 0x00B25FE4 File Offset: 0x00B241E4
		public static TFormulaValue operator +(TFormulaValue operand)
		{
			if (!TFormulaValue.IsNumeric(operand))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Invalid unary + operand: ");
				defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(operand);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return operand;
		}

		// Token: 0x0602F0CB RID: 192715 RVA: 0x00B26028 File Offset: 0x00B24228
		public static TFormulaValue operator -(TFormulaValue operand)
		{
			if (operand.Type == EFormulaValueType.Double)
			{
				return TFormulaValue.FromDouble(-operand._doubleValue);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid unary - operand: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(operand);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0CC RID: 192716 RVA: 0x00B26078 File Offset: 0x00B24278
		public static TFormulaValue operator !(TFormulaValue operand)
		{
			bool flag;
			if (!operand.TryGetBool(out flag))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Invalid unary ! operand: ");
				defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(operand);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return TFormulaValue.FromBool(!flag);
		}

		// Token: 0x0602F0CD RID: 192717 RVA: 0x00B260C4 File Offset: 0x00B242C4
		public static TFormulaValue operator +(TFormulaValue left, TFormulaValue right)
		{
			if (left.Type == EFormulaValueType.String || right.Type == EFormulaValueType.String)
			{
				return TFormulaValue.FromString(left.ToString() + right.ToString());
			}
			if (TFormulaValue.IsNumeric(left) && TFormulaValue.IsNumeric(right))
			{
				return TFormulaValue.FromDouble((double)left + (double)right);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
			defaultInterpolatedStringHandler.AppendLiteral(" + ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0CE RID: 192718 RVA: 0x00B26170 File Offset: 0x00B24370
		public static TFormulaValue operator -(TFormulaValue left, TFormulaValue right)
		{
			if (TFormulaValue.IsNumeric(left) && TFormulaValue.IsNumeric(right))
			{
				return TFormulaValue.FromDouble((double)left - (double)right);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
			defaultInterpolatedStringHandler.AppendLiteral(" - ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0CF RID: 192719 RVA: 0x00B261E0 File Offset: 0x00B243E0
		public static TFormulaValue operator *(TFormulaValue left, TFormulaValue right)
		{
			if (TFormulaValue.IsNumeric(left) && TFormulaValue.IsNumeric(right))
			{
				return TFormulaValue.FromDouble((double)left * (double)right);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
			defaultInterpolatedStringHandler.AppendLiteral(" * ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0D0 RID: 192720 RVA: 0x00B26250 File Offset: 0x00B24450
		public static TFormulaValue operator /(TFormulaValue left, TFormulaValue right)
		{
			if (TFormulaValue.IsNumeric(left) && TFormulaValue.IsNumeric(right))
			{
				return TFormulaValue.FromDouble((double)left / (double)right);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
			defaultInterpolatedStringHandler.AppendLiteral(" / ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0D1 RID: 192721 RVA: 0x00B262C0 File Offset: 0x00B244C0
		public static TFormulaValue operator %(TFormulaValue left, TFormulaValue right)
		{
			if (TFormulaValue.IsNumeric(left) && TFormulaValue.IsNumeric(right))
			{
				return TFormulaValue.FromDouble((double)left % (double)right);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
			defaultInterpolatedStringHandler.AppendLiteral(" % ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0D2 RID: 192722 RVA: 0x00B26330 File Offset: 0x00B24530
		public static TFormulaValue operator &(TFormulaValue left, TFormulaValue right)
		{
			bool flag;
			bool flag2;
			if (left.TryGetBool(out flag) && right.TryGetBool(out flag2))
			{
				return TFormulaValue.FromBool(flag && flag2);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
			defaultInterpolatedStringHandler.AppendLiteral(" && ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0D3 RID: 192723 RVA: 0x00B2639C File Offset: 0x00B2459C
		public static TFormulaValue operator |(TFormulaValue left, TFormulaValue right)
		{
			bool flag;
			bool flag2;
			if (left.TryGetBool(out flag) && right.TryGetBool(out flag2))
			{
				return TFormulaValue.FromBool(flag || flag2);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
			defaultInterpolatedStringHandler.AppendLiteral(" || ");
			defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0602F0D4 RID: 192724 RVA: 0x00B26406 File Offset: 0x00B24606
		public static bool operator >(TFormulaValue left, TFormulaValue right)
		{
			return TFormulaValue.Compare(left, right) > 0;
		}

		// Token: 0x0602F0D5 RID: 192725 RVA: 0x00B26412 File Offset: 0x00B24612
		public static bool operator >=(TFormulaValue left, TFormulaValue right)
		{
			return TFormulaValue.Compare(left, right) >= 0;
		}

		// Token: 0x0602F0D6 RID: 192726 RVA: 0x00B26421 File Offset: 0x00B24621
		public static bool operator <(TFormulaValue left, TFormulaValue right)
		{
			return TFormulaValue.Compare(left, right) < 0;
		}

		// Token: 0x0602F0D7 RID: 192727 RVA: 0x00B2642D File Offset: 0x00B2462D
		public static bool operator <=(TFormulaValue left, TFormulaValue right)
		{
			return TFormulaValue.Compare(left, right) <= 0;
		}

		// Token: 0x0602F0D8 RID: 192728 RVA: 0x00B2643C File Offset: 0x00B2463C
		public static bool operator ==(TFormulaValue left, TFormulaValue right)
		{
			return TFormulaValue.AreEqual(left, right);
		}

		// Token: 0x0602F0D9 RID: 192729 RVA: 0x00B26445 File Offset: 0x00B24645
		public static bool operator !=(TFormulaValue left, TFormulaValue right)
		{
			return !TFormulaValue.AreEqual(left, right);
		}

		// Token: 0x0602F0DA RID: 192730 RVA: 0x00B26454 File Offset: 0x00B24654
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is TFormulaValue)
			{
				TFormulaValue right = (TFormulaValue)obj;
				return this == right;
			}
			return false;
		}

		// Token: 0x0602F0DB RID: 192731 RVA: 0x00B26480 File Offset: 0x00B24680
		public override int GetHashCode()
		{
			switch (this.Type)
			{
			case EFormulaValueType.Double:
				return HashCode.Combine<EFormulaValueType, double>(this.Type, this._doubleValue);
			case EFormulaValueType.Bool:
				return HashCode.Combine<EFormulaValueType, bool>(this.Type, this._boolValue);
			case EFormulaValueType.String:
				return HashCode.Combine<EFormulaValueType, string>(this.Type, this._stringValue);
			case EFormulaValueType.Entity:
				return HashCode.Combine<EFormulaValueType, Entity>(this.Type, this._entityValue);
			case EFormulaValueType.DoubleArray:
			{
				EFormulaValueType type = this.Type;
				double[] doubleArrayValue = this._doubleArrayValue;
				int num = HashCode.Combine<EFormulaValueType, int>(type, (doubleArrayValue != null) ? doubleArrayValue.Length : 0);
				if (this._doubleArrayValue != null)
				{
					for (int i = 0; i < this._doubleArrayValue.Length; i++)
					{
						num = HashCode.Combine<int, double>(num, this._doubleArrayValue[i]);
					}
				}
				return num;
			}
			case EFormulaValueType.Context:
				return HashCode.Combine<EFormulaValueType, ContextParam>(this.Type, this._contextValue);
			case EFormulaValueType.StringArray:
			{
				EFormulaValueType type2 = this.Type;
				string[] stringArrayValue = this._stringArrayValue;
				int num2 = HashCode.Combine<EFormulaValueType, int>(type2, (stringArrayValue != null) ? stringArrayValue.Length : 0);
				if (this._stringArrayValue != null)
				{
					for (int j = 0; j < this._stringArrayValue.Length; j++)
					{
						num2 = HashCode.Combine<int, string>(num2, this._stringArrayValue[j]);
					}
				}
				return num2;
			}
			case EFormulaValueType.TagContainer:
				return HashCode.Combine<EFormulaValueType, TagContainer>(this.Type, this._tagContainerValue);
			case EFormulaValueType.Vector:
				return HashCode.Combine<EFormulaValueType, Vector>(this.Type, this._vectorValue);
			case EFormulaValueType.Rotator:
				return HashCode.Combine<EFormulaValueType, Rotator>(this.Type, this._rotatorValue);
			default:
				return this.Type.GetHashCode();
			}
		}

		// Token: 0x0602F0DC RID: 192732 RVA: 0x00B26604 File Offset: 0x00B24804
		private static int Compare(TFormulaValue left, TFormulaValue right)
		{
			if (!TFormulaValue.IsNumeric(left) || !TFormulaValue.IsNumeric(right))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Invalid compare operation: ");
				defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(left);
				defaultInterpolatedStringHandler.AppendLiteral(" and ");
				defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(right);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			double num = (double)left - (double)right;
			if (Math.Abs(num) <= 5E-324)
			{
				return 0;
			}
			if (num <= 0.0)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x0602F0DD RID: 192733 RVA: 0x00B26694 File Offset: 0x00B24894
		private static bool AreEqual(TFormulaValue left, TFormulaValue right)
		{
			if (left.Type != right.Type)
			{
				return TFormulaValue.IsNumeric(left) && TFormulaValue.IsNumeric(right) && Math.Abs((double)left - (double)right) <= double.Epsilon;
			}
			switch (left.Type)
			{
			case EFormulaValueType.None:
				return true;
			case EFormulaValueType.Double:
				return Math.Abs(left._doubleValue - right._doubleValue) <= double.Epsilon;
			case EFormulaValueType.Bool:
				return left._boolValue == right._boolValue;
			case EFormulaValueType.String:
				return left._stringValue == right._stringValue;
			case EFormulaValueType.Entity:
				return left._entityValue == right._entityValue;
			case EFormulaValueType.DoubleArray:
				if (left._doubleArrayValue == null || right._doubleArrayValue == null || left._doubleArrayValue.Length != right._doubleArrayValue.Length)
				{
					return false;
				}
				for (int i = 0; i < left._doubleArrayValue.Length; i++)
				{
					if (Math.Abs(left._doubleArrayValue[i] - right._doubleArrayValue[i]) > 5E-324)
					{
						return false;
					}
				}
				return true;
			case EFormulaValueType.Context:
				return left._contextValue == right._contextValue;
			case EFormulaValueType.StringArray:
				if (left._stringArrayValue == null || right._stringArrayValue == null || left._stringArrayValue.Length != right._stringArrayValue.Length)
				{
					return false;
				}
				for (int j = 0; j < left._stringArrayValue.Length; j++)
				{
					if (!string.Equals(left._stringArrayValue[j], right._stringArrayValue[j], StringComparison.Ordinal))
					{
						return false;
					}
				}
				return true;
			case EFormulaValueType.TagContainer:
				return left._tagContainerValue == right._tagContainerValue;
			case EFormulaValueType.Vector:
				return object.Equals(left._vectorValue, right._vectorValue);
			case EFormulaValueType.Rotator:
				return object.Equals(left._rotatorValue, right._rotatorValue);
			default:
				return false;
			}
		}

		// Token: 0x0602F0DE RID: 192734 RVA: 0x00B26870 File Offset: 0x00B24A70
		public override string ToString()
		{
			switch (this.Type)
			{
			case EFormulaValueType.Double:
				return this._doubleValue.ToString();
			case EFormulaValueType.Bool:
				return this._boolValue.ToString();
			case EFormulaValueType.String:
				return this._stringValue ?? string.Empty;
			case EFormulaValueType.Entity:
			{
				Entity entityValue = this._entityValue;
				return ((entityValue != null) ? entityValue.ToString() : null) ?? string.Empty;
			}
			case EFormulaValueType.DoubleArray:
				if (this._doubleArrayValue != null)
				{
					return "[" + string.Join<double>(",", this._doubleArrayValue) + "]";
				}
				return "[]";
			case EFormulaValueType.Context:
			{
				ContextParam contextValue = this._contextValue;
				return ((contextValue != null) ? contextValue.ToString() : null) ?? string.Empty;
			}
			case EFormulaValueType.StringArray:
				if (this._stringArrayValue != null)
				{
					return "[" + string.Join(",", this._stringArrayValue) + "]";
				}
				return "[]";
			case EFormulaValueType.TagContainer:
			{
				TagContainer tagContainerValue = this._tagContainerValue;
				return ((tagContainerValue != null) ? tagContainerValue.ToString() : null) ?? string.Empty;
			}
			case EFormulaValueType.Vector:
			{
				Vector vectorValue = this._vectorValue;
				return ((vectorValue != null) ? vectorValue.ToString() : null) ?? string.Empty;
			}
			case EFormulaValueType.Rotator:
			{
				Rotator rotatorValue = this._rotatorValue;
				return ((rotatorValue != null) ? rotatorValue.ToString() : null) ?? string.Empty;
			}
			default:
				return string.Empty;
			}
		}

		// Token: 0x0602F0DF RID: 192735 RVA: 0x00B269CE File Offset: 0x00B24BCE
		public static implicit operator TFormulaValue(int value)
		{
			return TFormulaValue.FromInt(value);
		}

		// Token: 0x0602F0E0 RID: 192736 RVA: 0x00B269D6 File Offset: 0x00B24BD6
		public static implicit operator TFormulaValue(long value)
		{
			return TFormulaValue.FromLong(value);
		}

		// Token: 0x0602F0E1 RID: 192737 RVA: 0x00B269DE File Offset: 0x00B24BDE
		public static implicit operator TFormulaValue(float value)
		{
			return TFormulaValue.FromFloat(value);
		}

		// Token: 0x0602F0E2 RID: 192738 RVA: 0x00B269E6 File Offset: 0x00B24BE6
		public static implicit operator TFormulaValue(double value)
		{
			return TFormulaValue.FromDouble(value);
		}

		// Token: 0x0602F0E3 RID: 192739 RVA: 0x00B269EE File Offset: 0x00B24BEE
		public static implicit operator TFormulaValue(bool value)
		{
			return TFormulaValue.FromBool(value);
		}

		// Token: 0x0602F0E4 RID: 192740 RVA: 0x00B269F6 File Offset: 0x00B24BF6
		public static implicit operator TFormulaValue(string value)
		{
			return TFormulaValue.FromString(value);
		}

		// Token: 0x0602F0E5 RID: 192741 RVA: 0x00B269FE File Offset: 0x00B24BFE
		public static implicit operator TFormulaValue(Entity value)
		{
			return TFormulaValue.FromEntity(value);
		}

		// Token: 0x0602F0E6 RID: 192742 RVA: 0x00B26A06 File Offset: 0x00B24C06
		public static implicit operator TFormulaValue(int[] value)
		{
			return TFormulaValue.FromIntArray(value);
		}

		// Token: 0x0602F0E7 RID: 192743 RVA: 0x00B26A0E File Offset: 0x00B24C0E
		public static implicit operator TFormulaValue(long[] value)
		{
			return TFormulaValue.FromLongArray(value);
		}

		// Token: 0x0602F0E8 RID: 192744 RVA: 0x00B26A16 File Offset: 0x00B24C16
		public static implicit operator TFormulaValue(double[] value)
		{
			return TFormulaValue.FromDoubleArray(value);
		}

		// Token: 0x0602F0E9 RID: 192745 RVA: 0x00B26A1E File Offset: 0x00B24C1E
		public static implicit operator TFormulaValue(string[] value)
		{
			return TFormulaValue.FromStringArray(value);
		}

		// Token: 0x0602F0EA RID: 192746 RVA: 0x00B26A26 File Offset: 0x00B24C26
		public static implicit operator TFormulaValue(ContextParam value)
		{
			return TFormulaValue.FromContext(value);
		}

		// Token: 0x0602F0EB RID: 192747 RVA: 0x00B26A2E File Offset: 0x00B24C2E
		public static implicit operator TFormulaValue(TagContainer value)
		{
			return TFormulaValue.FromTagContainer(value);
		}

		// Token: 0x0602F0EC RID: 192748 RVA: 0x00B26A36 File Offset: 0x00B24C36
		public static implicit operator TFormulaValue(Vector value)
		{
			return TFormulaValue.FromVector(value);
		}

		// Token: 0x0602F0ED RID: 192749 RVA: 0x00B26A3E File Offset: 0x00B24C3E
		public static implicit operator TFormulaValue(Rotator value)
		{
			return TFormulaValue.FromRotator(value);
		}

		// Token: 0x0602F0EE RID: 192750 RVA: 0x00B26A48 File Offset: 0x00B24C48
		public static implicit operator long[](TFormulaValue value)
		{
			long[] array;
			if (!value.TryGetLongArray(out array) || array == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to long[].");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return array;
		}

		// Token: 0x0602F0EF RID: 192751 RVA: 0x00B26AA4 File Offset: 0x00B24CA4
		public static explicit operator int(TFormulaValue value)
		{
			int result;
			if (!value.TryGetInt(out result))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to int.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return result;
		}

		// Token: 0x0602F0F0 RID: 192752 RVA: 0x00B26AFC File Offset: 0x00B24CFC
		public static explicit operator long(TFormulaValue value)
		{
			long result;
			if (!value.TryGetLong(out result))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to long.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return result;
		}

		// Token: 0x0602F0F1 RID: 192753 RVA: 0x00B26B54 File Offset: 0x00B24D54
		public static explicit operator float(TFormulaValue value)
		{
			float result;
			if (!value.TryGetFloat(out result))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to float.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return result;
		}

		// Token: 0x0602F0F2 RID: 192754 RVA: 0x00B26BAC File Offset: 0x00B24DAC
		public static explicit operator double(TFormulaValue value)
		{
			double result;
			if (!value.TryGetDouble(out result))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to double.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return result;
		}

		// Token: 0x0602F0F3 RID: 192755 RVA: 0x00B26C04 File Offset: 0x00B24E04
		public static explicit operator bool(TFormulaValue value)
		{
			bool result;
			if (!value.TryGetBool(out result))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to bool.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return result;
		}

		// Token: 0x0602F0F4 RID: 192756 RVA: 0x00B26C5C File Offset: 0x00B24E5C
		public static explicit operator string(TFormulaValue value)
		{
			string text;
			if (!value.TryGetString(out text) || text == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to string.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return text;
		}

		// Token: 0x0602F0F5 RID: 192757 RVA: 0x00B26CB8 File Offset: 0x00B24EB8
		public static explicit operator Entity(TFormulaValue value)
		{
			Entity entity;
			if (!value.TryGetEntity(out entity) || entity == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to Entity.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return entity;
		}

		// Token: 0x0602F0F6 RID: 192758 RVA: 0x00B26D14 File Offset: 0x00B24F14
		public static explicit operator int[](TFormulaValue value)
		{
			int[] array;
			if (!value.TryGetIntArray(out array) || array == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to int[].");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return array;
		}

		// Token: 0x0602F0F7 RID: 192759 RVA: 0x00B26D70 File Offset: 0x00B24F70
		public static explicit operator double[](TFormulaValue value)
		{
			double[] array;
			if (!value.TryGetDoubleArray(out array) || array == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to double[].");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return array;
		}

		// Token: 0x0602F0F8 RID: 192760 RVA: 0x00B26DCC File Offset: 0x00B24FCC
		public static explicit operator string[](TFormulaValue value)
		{
			string[] array;
			if (!value.TryGetStringArray(out array) || array == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to string[].");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return array;
		}

		// Token: 0x0602F0F9 RID: 192761 RVA: 0x00B26E28 File Offset: 0x00B25028
		public static explicit operator TagContainer(TFormulaValue value)
		{
			TagContainer tagContainer;
			if (!value.TryGetTagContainer(out tagContainer) || tagContainer == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to TagContainer.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return tagContainer;
		}

		// Token: 0x0602F0FA RID: 192762 RVA: 0x00B26E84 File Offset: 0x00B25084
		public static explicit operator Vector(TFormulaValue value)
		{
			Vector vector;
			if (!value.TryGetVector(out vector) || vector == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to Vector.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return vector;
		}

		// Token: 0x0602F0FB RID: 192763 RVA: 0x00B26EE0 File Offset: 0x00B250E0
		public static explicit operator Rotator(TFormulaValue value)
		{
			Rotator rotator;
			if (!value.TryGetRotator(out rotator) || rotator == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot cast TFormulaValue(type=");
				defaultInterpolatedStringHandler.AppendFormatted<EFormulaValueType>(value.Type);
				defaultInterpolatedStringHandler.AppendLiteral(") to Rotator.");
				throw new InvalidCastException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return rotator;
		}

		// Token: 0x0401ACE9 RID: 109801
		private readonly double _doubleValue;

		// Token: 0x0401ACEA RID: 109802
		private readonly bool _boolValue;

		// Token: 0x0401ACEB RID: 109803
		[Nullable(2)]
		private readonly string _stringValue;

		// Token: 0x0401ACEC RID: 109804
		[Nullable(2)]
		private readonly Entity _entityValue;

		// Token: 0x0401ACED RID: 109805
		[Nullable(2)]
		private readonly double[] _doubleArrayValue;

		// Token: 0x0401ACEE RID: 109806
		[Nullable(2)]
		private readonly ContextParam _contextValue;

		// Token: 0x0401ACEF RID: 109807
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly string[] _stringArrayValue;

		// Token: 0x0401ACF0 RID: 109808
		[Nullable(2)]
		private readonly TagContainer _tagContainerValue;

		// Token: 0x0401ACF1 RID: 109809
		[Nullable(2)]
		private readonly Vector _vectorValue;

		// Token: 0x0401ACF2 RID: 109810
		[Nullable(2)]
		private readonly Rotator _rotatorValue;
	}
}
