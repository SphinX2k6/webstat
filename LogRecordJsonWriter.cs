using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Core.Common;

// Token: 0x02000050 RID: 80
[NullableContext(1)]
[Nullable(0)]
public static class LogRecordJsonWriter
{
	// Token: 0x06000158 RID: 344 RVA: 0x00009368 File Offset: 0x00007568
	public static string EscapeJsString(string value)
	{
		StringBuilder stringBuilder = null;
		int i = 0;
		while (i < value.Length)
		{
			char c = value[i];
			char c2 = c;
			string text;
			switch (c2)
			{
			case '\b':
				text = "\\b";
				break;
			case '\t':
				text = "\\t";
				break;
			case '\n':
				text = "\\n";
				break;
			case '\v':
				goto IL_82;
			case '\f':
				text = "\\f";
				break;
			case '\r':
				text = "\\r";
				break;
			default:
				if (c2 != '"')
				{
					if (c2 != '\\')
					{
						goto IL_82;
					}
					text = "\\\\";
				}
				else
				{
					text = "\\\"";
				}
				break;
			}
			IL_A7:
			string text2 = text;
			if (text2 == null)
			{
				if (stringBuilder != null)
				{
					stringBuilder.Append(c);
				}
			}
			else
			{
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(value.Length + 16);
					stringBuilder.Append(value, 0, i);
				}
				stringBuilder.Append(text2);
			}
			i++;
			continue;
			IL_82:
			if (c < ' ')
			{
				string str = "\\u";
				int num = (int)c;
				text = str + num.ToString("x4");
				goto IL_A7;
			}
			text = null;
			goto IL_A7;
		}
		return ((stringBuilder != null) ? stringBuilder.ToString() : null) ?? value;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00009474 File Offset: 0x00007674
	[return: Nullable(2)]
	public static string Write(ILogRecord content)
	{
		LogRecord logRecord = content as LogRecord;
		if (logRecord != null)
		{
			return LogRecordJsonWriter.WriteLogRecord(logRecord);
		}
		LogReportRecord logReportRecord = content as LogReportRecord;
		if (logReportRecord == null)
		{
			return Json.Stringify<ILogRecord>(content, null);
		}
		return LogRecordJsonWriter.WriteLogReportRecord(logReportRecord);
	}

	// Token: 0x0600015A RID: 346 RVA: 0x000094AC File Offset: 0x000076AC
	private static string WriteLogRecord(LogRecord r)
	{
		StringBuilder stringBuilder = new StringBuilder(512);
		stringBuilder.Append("{\"Sp\":").Append(r.Sp);
		if (r.Ed != null)
		{
			stringBuilder.Append(",\"Ed\":").Append(r.Ed.Value);
		}
		stringBuilder.Append(",\"Context\":").Append(r.Context ?? "{}");
		if (r.P4V != null)
		{
			stringBuilder.Append(",\"P4V\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.P4V)).Append('"');
		}
		if (r.Br != null)
		{
			stringBuilder.Append(",\"Br\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Br)).Append('"');
		}
		stringBuilder.Append(",\"PlayerId\":").Append(r.PlayerId);
		stringBuilder.Append(",\"Id\":").Append(r.Id);
		stringBuilder.Append(",\"Level\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Level)).Append('"');
		stringBuilder.Append(",\"Module\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Module)).Append('"');
		if (r.Category != null)
		{
			stringBuilder.Append(",\"Category\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Category)).Append('"');
		}
		stringBuilder.Append(",\"Author\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Author)).Append('"');
		stringBuilder.Append(",\"Msg\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Msg)).Append('"');
		if (r.Stack != null)
		{
			stringBuilder.Append(",\"Stack\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Stack)).Append('"');
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000969C File Offset: 0x0000789C
	private static string WriteLogReportRecord(LogReportRecord r)
	{
		StringBuilder stringBuilder = new StringBuilder(512);
		stringBuilder.Append("{\"Sp\":").Append(r.Sp);
		if (r.Ed != null)
		{
			stringBuilder.Append(",\"Ed\":").Append(r.Ed.Value);
		}
		stringBuilder.Append(",\"PlayerId\":").Append(r.PlayerId);
		stringBuilder.Append(",\"Num\":").Append(r.Num);
		stringBuilder.Append(",\"Detail\":").Append(r.Detail);
		if (r.P4V != null)
		{
			stringBuilder.Append(",\"P4V\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.P4V)).Append('"');
		}
		if (r.Br != null)
		{
			stringBuilder.Append(",\"Br\":\"").Append(LogRecordJsonWriter.EscapeJsString(r.Br)).Append('"');
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}
}
