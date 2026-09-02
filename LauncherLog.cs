using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Launcher.Util;
using UnrealEngine.Utils;

// Token: 0x020034E7 RID: 13543
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LauncherLog : Singleton<LauncherLog>
{
	// Token: 0x0601CA00 RID: 117248 RVA: 0x00896493 File Offset: 0x00894693
	public void SetJsDebugId(string id)
	{
		if (!string.IsNullOrEmpty(id))
		{
			this.JsDebugId = "(" + id + ")";
		}
	}

	// Token: 0x0601CA01 RID: 117249 RVA: 0x008964B3 File Offset: 0x008946B3
	public void SetLevel(LauncherLog.ELogLevel level)
	{
		this.Level = level;
	}

	// Token: 0x0601CA02 RID: 117250 RVA: 0x008964BC File Offset: 0x008946BC
	public bool CheckError()
	{
		return this.Level >= LauncherLog.ELogLevel.Error;
	}

	// Token: 0x0601CA03 RID: 117251 RVA: 0x008964CA File Offset: 0x008946CA
	public bool CheckWarn()
	{
		return this.Level >= LauncherLog.ELogLevel.Warn;
	}

	// Token: 0x0601CA04 RID: 117252 RVA: 0x008964D8 File Offset: 0x008946D8
	public bool CheckInfo()
	{
		return this.Level >= LauncherLog.ELogLevel.Info;
	}

	// Token: 0x0601CA05 RID: 117253 RVA: 0x008964E6 File Offset: 0x008946E6
	public bool CheckDebug()
	{
		return this.Level >= LauncherLog.ELogLevel.Debug;
	}

	// Token: 0x0601CA06 RID: 117254 RVA: 0x008964F4 File Offset: 0x008946F4
	public void Error(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.Print(LauncherLog.ELogLevel.Error, message, pairs, this.LevelTrace[LauncherLog.ELogLevel.Error], null);
	}

	// Token: 0x0601CA07 RID: 117255 RVA: 0x0089650C File Offset: 0x0089470C
	public void ErrorWithStack(string message, Exception error, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.Print(LauncherLog.ELogLevel.Error, message, pairs, this.LevelTrace[LauncherLog.ELogLevel.Error], error);
	}

	// Token: 0x0601CA08 RID: 117256 RVA: 0x00896524 File Offset: 0x00894724
	public void Warn(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.Print(LauncherLog.ELogLevel.Warn, message, pairs, this.LevelTrace[LauncherLog.ELogLevel.Warn], null);
	}

	// Token: 0x0601CA09 RID: 117257 RVA: 0x0089653C File Offset: 0x0089473C
	public void Info(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.Print(LauncherLog.ELogLevel.Info, message, pairs, this.LevelTrace[LauncherLog.ELogLevel.Info], null);
	}

	// Token: 0x0601CA0A RID: 117258 RVA: 0x00896554 File Offset: 0x00894754
	public void Debug(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.Print(LauncherLog.ELogLevel.Debug, message, pairs, this.LevelTrace[LauncherLog.ELogLevel.Debug], null);
	}

	// Token: 0x0601CA0B RID: 117259 RVA: 0x0089656C File Offset: 0x0089476C
	private unsafe void Print(LauncherLog.ELogLevel level, string message, [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs, bool trace, [Nullable(2)] Exception error = null)
	{
		this.Increment++;
		if (level > this.Level)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 4);
		defaultInterpolatedStringHandler.AppendLiteral("[");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.Increment);
		defaultInterpolatedStringHandler.AppendLiteral("][");
		defaultInterpolatedStringHandler.AppendFormatted(this.LevelName[level]);
		defaultInterpolatedStringHandler.AppendLiteral("][Launcher][");
		defaultInterpolatedStringHandler.AppendFormatted(this.GetTime());
		defaultInterpolatedStringHandler.AppendLiteral("] ");
		defaultInterpolatedStringHandler.AppendFormatted(message);
		StringBuilder stringBuilder = new StringBuilder(defaultInterpolatedStringHandler.ToStringAndClear());
		if (pairs.Length > 0)
		{
			stringBuilder.Append(' ');
			ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				ValueTuple<string, object> valueTuple = *readOnlySpan[i];
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder2);
				appendInterpolatedStringHandler.AppendLiteral("[");
				appendInterpolatedStringHandler.AppendFormatted(valueTuple.Item1);
				appendInterpolatedStringHandler.AppendLiteral(": ");
				appendInterpolatedStringHandler.AppendFormatted(this.ToString(valueTuple.Item2));
				appendInterpolatedStringHandler.AppendLiteral("]");
				stringBuilder3.Append(ref appendInterpolatedStringHandler);
			}
		}
		string value = null;
		if (trace)
		{
			value = this.GetStack(error, (error != null) ? 0 : 3);
		}
		if (!string.IsNullOrEmpty(value))
		{
			stringBuilder.Append('\n');
			stringBuilder.Append(value);
		}
		this.LogMessage(level, stringBuilder.ToString());
	}

	// Token: 0x0601CA0C RID: 117260 RVA: 0x008966E8 File Offset: 0x008948E8
	private string GetTime()
	{
		DateTime now = DateTime.Now;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
		defaultInterpolatedStringHandler.AppendFormatted<int>(now.Hour);
		defaultInterpolatedStringHandler.AppendLiteral(".");
		defaultInterpolatedStringHandler.AppendFormatted<int>(now.Minute);
		defaultInterpolatedStringHandler.AppendLiteral(".");
		defaultInterpolatedStringHandler.AppendFormatted<int>(now.Second);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted<int>(now.Millisecond);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601CA0D RID: 117261 RVA: 0x00896768 File Offset: 0x00894968
	[NullableContext(2)]
	private string ToString(object value)
	{
		if (value == null)
		{
			return "null";
		}
		string text = value as string;
		if (text != null)
		{
			return text;
		}
		if (this.Serialization && value.GetType().IsClass)
		{
			return this.Encode(value) ?? "";
		}
		return value.ToString();
	}

	// Token: 0x0601CA0E RID: 117262 RVA: 0x008967B8 File Offset: 0x008949B8
	[return: Nullable(2)]
	private string Encode(object target)
	{
		try
		{
			return LauncherJson.Stringify<object>(target, null);
		}
		catch (Exception ex)
		{
			string message = "Log 序列化异常";
			Exception error = ex;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
			this.ErrorWithStack(message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return null;
	}

	// Token: 0x0601CA0F RID: 117263 RVA: 0x0089680C File Offset: 0x00894A0C
	private string GetStack([Nullable(2)] Exception error, int firstStackIndex)
	{
		return string.Empty;
	}

	// Token: 0x0601CA10 RID: 117264 RVA: 0x00896813 File Offset: 0x00894A13
	private void LogMessage(LauncherLog.ELogLevel level, string message)
	{
		switch (level)
		{
		case LauncherLog.ELogLevel.Error:
			UnrealLogger.Error(message);
			return;
		case LauncherLog.ELogLevel.Warn:
			UnrealLogger.Warn(message);
			return;
		case LauncherLog.ELogLevel.Info:
			UnrealLogger.Info(message);
			return;
		case LauncherLog.ELogLevel.Debug:
			UnrealLogger.Info(message);
			return;
		default:
			return;
		}
	}

	// Token: 0x0400E684 RID: 59012
	private readonly Dictionary<LauncherLog.ELogLevel, bool> LevelTrace = new Dictionary<LauncherLog.ELogLevel, bool>
	{
		{
			LauncherLog.ELogLevel.Error,
			true
		},
		{
			LauncherLog.ELogLevel.Warn,
			false
		},
		{
			LauncherLog.ELogLevel.Info,
			false
		},
		{
			LauncherLog.ELogLevel.Debug,
			false
		}
	};

	// Token: 0x0400E685 RID: 59013
	private readonly Dictionary<LauncherLog.ELogLevel, string> LevelName = new Dictionary<LauncherLog.ELogLevel, string>
	{
		{
			LauncherLog.ELogLevel.Error,
			"E"
		},
		{
			LauncherLog.ELogLevel.Warn,
			"W"
		},
		{
			LauncherLog.ELogLevel.Info,
			"I"
		},
		{
			LauncherLog.ELogLevel.Debug,
			"D"
		}
	};

	// Token: 0x0400E686 RID: 59014
	private LauncherLog.ELogLevel Level = LauncherLog.ELogLevel.Debug;

	// Token: 0x0400E687 RID: 59015
	private readonly bool Serialization;

	// Token: 0x0400E688 RID: 59016
	private int Increment;

	// Token: 0x0400E689 RID: 59017
	private string JsDebugId = string.Empty;

	// Token: 0x0200969D RID: 38557
	[NullableContext(0)]
	public enum ELogLevel
	{
		// Token: 0x04031B12 RID: 203538
		Error,
		// Token: 0x04031B13 RID: 203539
		Warn,
		// Token: 0x04031B14 RID: 203540
		Info,
		// Token: 0x04031B15 RID: 203541
		Debug
	}
}
