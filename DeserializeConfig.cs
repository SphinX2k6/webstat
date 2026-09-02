using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Common.Proxy;
using Aki.Config;

// Token: 0x02000059 RID: 89
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DeserializeConfig : Singleton<global::DeserializeConfig>, IDeserializeConfigProxy
{
	// Token: 0x060001D5 RID: 469 RVA: 0x0000AD90 File Offset: 0x00008F90
	[NullableContext(0)]
	public DeserializeConfigResult<int> ParseInt([Nullable(1)] byte[] buffer, int startIndex = 0, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		DeserializeConfigResult<int> result = new DeserializeConfigResult<int>
		{
			Success = true,
			Value = 0,
			Position = startIndex
		};
		if (buffer.Length >= startIndex + 4)
		{
			result.Value = BitConverter.ToInt32(buffer, startIndex);
			result.Position = startIndex + 4;
		}
		else
		{
			Singleton<global::Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.LZP, "配置表序列化 int32 类型出错，请检查配置表定义与配置表数据是否一致！", pairs);
			result.Success = false;
		}
		return result;
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0000AE00 File Offset: 0x00009000
	[NullableContext(0)]
	public DeserializeConfigResult<long> ParseBigInt([Nullable(1)] byte[] buffer, int startIndex = 0, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		DeserializeConfigResult<long> result = new DeserializeConfigResult<long>
		{
			Success = true,
			Value = 0L,
			Position = startIndex
		};
		if (buffer.Length >= startIndex + 8)
		{
			result.Value = (long)BitConverter.ToDouble(buffer, startIndex);
			result.Position = startIndex + 8;
		}
		else
		{
			Singleton<global::Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.LZP, "配置表序列化 int64 类型出错，请检查配置表定义与配置表数据是否一致！", pairs);
			result.Success = false;
		}
		return result;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x0000AE70 File Offset: 0x00009070
	[NullableContext(0)]
	public DeserializeConfigResult<float> ParseFloat([Nullable(1)] byte[] buffer, int startIndex = 0, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		DeserializeConfigResult<float> result = new DeserializeConfigResult<float>
		{
			Success = true,
			Value = 0f,
			Position = startIndex
		};
		if (buffer.Length >= startIndex + 4)
		{
			int num = BitConverter.ToInt32(buffer, startIndex);
			result.Position = startIndex + 4;
			result.Value = (float)((double)num * 0.0001);
		}
		else
		{
			Singleton<global::Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.LZP, "配置表序列化 float 类型出错，请检查配置表定义与配置表数据是否一致！", pairs);
			result.Success = false;
		}
		return result;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000AEF0 File Offset: 0x000090F0
	[NullableContext(0)]
	public DeserializeConfigResult<double> ParseFloat64([Nullable(1)] byte[] buffer, int startIndex = 0, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		DeserializeConfigResult<double> result = new DeserializeConfigResult<double>
		{
			Success = true,
			Value = 0.0,
			Position = startIndex
		};
		if (buffer.Length >= startIndex + 8)
		{
			result.Value = BitConverter.ToDouble(buffer, startIndex);
			result.Position = startIndex + 8;
		}
		else
		{
			Singleton<global::Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.CYK, "配置表序列化 float64 类型出错，请检查配置表定义与配置表数据是否一致！", pairs);
			result.Success = false;
		}
		return result;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0000AF68 File Offset: 0x00009168
	[NullableContext(0)]
	public DeserializeConfigResult<bool> ParseBoolean([Nullable(1)] byte[] buffer, int startIndex = 0, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		DeserializeConfigResult<bool> result = new DeserializeConfigResult<bool>
		{
			Success = true,
			Value = false,
			Position = startIndex
		};
		if (buffer.Length >= startIndex + 1)
		{
			result.Value = (buffer[startIndex] == 1);
			result.Position = startIndex + 1;
		}
		else
		{
			Singleton<global::Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.LZP, "配置表序列化 bool 类型出错，请检查配置表定义与配置表数据是否一致！", pairs);
			result.Success = false;
		}
		return result;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0000AFD4 File Offset: 0x000091D4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public DeserializeConfigResult<string> ParseStringRange(byte[] buffer, int begin, int size, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		DeserializeConfigResult<string> result = new DeserializeConfigResult<string>
		{
			Success = false,
			Value = "",
			Position = begin
		};
		if (buffer.Length < begin + size)
		{
			Singleton<global::Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.LZP, "配置表序列化 string 类型出错，请检查配置表定义与配置表数据是否一致！", pairs);
			return result;
		}
		if (size == 0)
		{
			result.Success = true;
			return result;
		}
		List<string> list = null;
		int i = begin;
		while (i < begin + size)
		{
			int num = (int)buffer[i];
			if (num >> 7 == 0)
			{
				this.TempCodes.Add((int)buffer[i]);
				i++;
			}
			else if ((num & 252) == 252)
			{
				int num2 = (int)(buffer[i] & 3) << 30;
				num2 |= (int)(buffer[i + 1] & 63) << 24;
				num2 |= (int)(buffer[i + 2] & 63) << 18;
				num2 |= (int)(buffer[i + 3] & 63) << 12;
				num2 |= (int)(buffer[i + 4] & 63) << 6;
				num2 |= (int)(buffer[i + 5] & 63);
				this.TempCodes.Add(num2);
				i += 6;
			}
			else if ((num & 248) == 248)
			{
				int num2 = (int)(buffer[i] & 7) << 24;
				num2 |= (int)(buffer[i + 1] & 63) << 18;
				num2 |= (int)(buffer[i + 2] & 63) << 12;
				num2 |= (int)(buffer[i + 3] & 63) << 6;
				num2 |= (int)(buffer[i + 4] & 63);
				this.TempCodes.Add(num2);
				i += 5;
			}
			else if ((num & 240) == 240)
			{
				int num2 = (int)(buffer[i] & 15) << 18;
				num2 |= (int)(buffer[i + 1] & 63) << 12;
				num2 |= (int)(buffer[i + 2] & 63) << 6;
				num2 |= (int)(buffer[i + 3] & 63);
				this.TempCodes.Add(num2);
				i += 4;
			}
			else if ((num & 224) == 224)
			{
				int num2 = (int)(buffer[i] & 31) << 12;
				num2 |= (int)(buffer[i + 1] & 63) << 6;
				num2 |= (int)(buffer[i + 2] & 63);
				this.TempCodes.Add(num2);
				i += 3;
			}
			else if ((num & 192) == 192)
			{
				int num2 = (int)(buffer[i] & 63) << 6;
				num2 |= (int)(buffer[i + 1] & 63);
				this.TempCodes.Add(num2);
				i += 2;
			}
			else
			{
				this.TempCodes.Add((int)buffer[i]);
				i++;
			}
			if (this.TempCodes.Count == 65535)
			{
				string item = string.Join<char>("", this.TempCodes.ConvertAll<char>((int c) => (char)c));
				this.TempCodes.Clear();
				if (list != null)
				{
					list.Add(item);
				}
				else
				{
					list = new List<string>
					{
						item
					};
				}
			}
		}
		string text = (list != null) ? string.Join("", list) : null;
		if (this.TempCodes.Count > 0)
		{
			string text2 = string.Join<char>("", this.TempCodes.ConvertAll<char>((int c) => (char)c));
			this.TempCodes.Clear();
			text = ((text != null) ? (text + text2) : text2);
		}
		result.Value = (text ?? "");
		result.Position = begin + size;
		result.Success = true;
		return result;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0000B344 File Offset: 0x00009544
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public DeserializeConfigResult<string> ParseString(byte[] buffer, int startIndex = 0, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		DeserializeConfigResult<string> result = new DeserializeConfigResult<string>
		{
			Success = false,
			Value = "",
			Position = startIndex
		};
		DeserializeConfigResult<int> deserializeConfigResult = this.ParseInt(buffer, startIndex, pairs);
		if (deserializeConfigResult.Success)
		{
			int value = deserializeConfigResult.Value;
			int position = deserializeConfigResult.Position;
			result.Position = position;
			if (value < 0)
			{
				Singleton<global::Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.LZP, "配置表序列化 string 类型出错，请检查配置表定义与配置表数据是否一致！", pairs);
				return result;
			}
			if (value == 0)
			{
				result.Success = true;
				return result;
			}
			result = this.ParseStringRange(buffer, position, value, pairs);
		}
		return result;
	}

	// Token: 0x0400019F RID: 415
	private const double RATE_10000 = 0.0001;

	// Token: 0x040001A0 RID: 416
	private const int MAX_CODES = 65535;

	// Token: 0x040001A1 RID: 417
	private readonly List<int> TempCodes = new List<int>();

	// Token: 0x040001A2 RID: 418
	[StaticVariableRuleIgnore]
	private readonly global::Stat ParseIntStat = global::Stat.Create("DeserializeConfig.Instance.ParseInt", "", "");

	// Token: 0x040001A3 RID: 419
	[StaticVariableRuleIgnore]
	private readonly global::Stat ParseBigIntStat = global::Stat.Create("DeserializeConfig.ParseBigInt", "", "");

	// Token: 0x040001A4 RID: 420
	[StaticVariableRuleIgnore]
	private readonly global::Stat ParseFloatStat = global::Stat.Create("DeserializeConfig.Instance.ParseFloat", "", "");

	// Token: 0x040001A5 RID: 421
	[StaticVariableRuleIgnore]
	private readonly global::Stat ParseFloat64Stat = global::Stat.Create("DeserializeConfig.ParseFloat64", "", "");

	// Token: 0x040001A6 RID: 422
	[StaticVariableRuleIgnore]
	private readonly global::Stat ParseBooleanStat = global::Stat.Create("DeserializeConfig.ParseBoolean", "", "");

	// Token: 0x040001A7 RID: 423
	[StaticVariableRuleIgnore]
	private readonly global::Stat ParseStringRangeStat = global::Stat.Create("DeserializeConfig.Instance.ParseStringRange", "", "");

	// Token: 0x040001A8 RID: 424
	[StaticVariableRuleIgnore]
	private readonly global::Stat ParseStringStat = global::Stat.Create("DeserializeConfig.ParseString", "", "");
}
