using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

// Token: 0x02000C24 RID: 3108
[NullableContext(1)]
[Nullable(0)]
public static class StringUtils
{
	// Token: 0x060035AD RID: 13741 RVA: 0x00032488 File Offset: 0x00030688
	public static string Format(string inString, [Nullable(new byte[]
	{
		1,
		2
	})] params string[] args)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		foreach (object obj in StringUtils.FormatRegexNew.Matches(inString))
		{
			Match match = (Match)obj;
			int num2 = int.Parse(match.Groups[1].Value);
			stringBuilder.Append(inString.Substring(num, match.Index - num));
			StringBuilder stringBuilder2 = stringBuilder;
			string value;
			if (num2 >= args.Length)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("{");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				defaultInterpolatedStringHandler.AppendLiteral("}");
				value = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else if ((value = args[num2]) == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("{");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				defaultInterpolatedStringHandler.AppendLiteral("}");
				value = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			stringBuilder2.Append(value);
			num = match.Index + match.Length;
		}
		stringBuilder.Append(inString.Substring(num));
		return stringBuilder.ToString();
	}

	// Token: 0x060035AE RID: 13742 RVA: 0x000325BC File Offset: 0x000307BC
	public static string FormatStaticBuilder(string inString, params object[] args)
	{
		string[] array = StringUtils.FormatRegex.Split(inString);
		StringBuilder staticBuilder = StringUtils.StaticBuilder;
		staticBuilder.Clear();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			staticBuilder.Append(array[i]);
			if (i != array.Length - 1)
			{
				StringBuilder stringBuilder = staticBuilder;
				string value;
				if (i >= args.Length)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
					defaultInterpolatedStringHandler.AppendLiteral("{");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i);
					defaultInterpolatedStringHandler.AppendLiteral("}");
					value = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					object obj = args[i];
					value = ((obj != null) ? obj.ToString() : null);
				}
				stringBuilder.Append(value);
			}
			i++;
		}
		return staticBuilder.ToString();
	}

	// Token: 0x060035AF RID: 13743 RVA: 0x00032658 File Offset: 0x00030858
	public static string Uint8ArrayToString(byte[] array)
	{
		List<string> list = new List<string>();
		int num = array.Length;
		int i = 0;
		while (i < num)
		{
			byte b = array[i++];
			switch (b >> 4)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			{
				List<string> list2 = list;
				char c = (char)b;
				list2.Add(c.ToString());
				break;
			}
			case 12:
			case 13:
			{
				byte b2 = array[i++];
				list.Add(((char)((int)(b & 31) << 6 | (int)(b2 & 63))).ToString());
				break;
			}
			case 14:
			{
				byte b2 = array[i++];
				byte b3 = array[i++];
				list.Add(((char)((int)(b & 15) << 12 | (int)(b2 & 63) << 6 | (int)(b3 & 63))).ToString());
				break;
			}
			}
		}
		return string.Join("", list);
	}

	// Token: 0x060035B0 RID: 13744 RVA: 0x00032758 File Offset: 0x00030958
	public static int GetStringRealCount(string src)
	{
		int num = 0;
		int length = src.Length;
		for (int i = 0; i < length; i++)
		{
			int num2 = (int)src[i];
			if (num2 >= 0 && num2 <= 128)
			{
				num++;
			}
			else
			{
				num += 2;
			}
		}
		return num;
	}

	// Token: 0x060035B1 RID: 13745 RVA: 0x0003279B File Offset: 0x0003099B
	[NullableContext(2)]
	public static bool IsEmpty([NotNullWhen(false)] string content)
	{
		return string.IsNullOrEmpty(content);
	}

	// Token: 0x060035B2 RID: 13746 RVA: 0x000327A3 File Offset: 0x000309A3
	public static string ParseTabAndLine(string content)
	{
		return content.Replace("\\n", "\n").Replace("\\r", "").Replace("\\t", "\t");
	}

	// Token: 0x060035B3 RID: 13747 RVA: 0x000327D4 File Offset: 0x000309D4
	public static bool IsIpAddress(string serverIp)
	{
		string pattern = "((\\d|[1-9]\\d|1\\d\\d|2[0-4]\\d|25[0-5])\\.){3}(\\d|[1-9]\\d|1\\d\\d|2[0-4]\\d|25[0-5])";
		return Regex.IsMatch(serverIp, pattern);
	}

	// Token: 0x060035B4 RID: 13748 RVA: 0x000327EE File Offset: 0x000309EE
	[NullableContext(2)]
	public static bool IsBlank(string content)
	{
		return string.IsNullOrWhiteSpace(content);
	}

	// Token: 0x060035B5 RID: 13749 RVA: 0x000327F6 File Offset: 0x000309F6
	public static bool IsNothing(string content)
	{
		return StringUtils.IsEmpty(content) || content == "None";
	}

	// Token: 0x060035B6 RID: 13750 RVA: 0x00032810 File Offset: 0x00030A10
	public static List<List<string>> ParseCsvContent(string content)
	{
		string text = "";
		List<string> list = new List<string>
		{
			""
		};
		List<List<string>> list2 = new List<List<string>>();
		list2.Add(list);
		int num = 0;
		int num2 = 0;
		bool flag = true;
		foreach (char c in content.StartsWith("﻿") ? content.Replace("﻿", "") : content)
		{
			if (c == '"')
			{
				if (flag && c.ToString() == text)
				{
					List<string> list3 = list;
					int num3 = num;
					List<string> list4 = list3;
					int index = num3;
					ReadOnlySpan<char> str = list3[num3];
					char c2 = c;
					list4[index] = str + new ReadOnlySpan<char>(ref c2);
				}
				flag = !flag;
			}
			else if (c == ',' && flag)
			{
				list.Add("");
				num++;
				c = '\0';
			}
			else if (c == '\n' && flag)
			{
				if (text == "\r")
				{
					list[num] = list[num].Substring(0, list[num].Length - 1);
				}
				List<string> list5 = new List<string>();
				char c2;
				c = (c2 = '\0');
				list5.Add(c2.ToString());
				list = list5;
				list2.Add(list);
				num2++;
				num = 0;
			}
			else
			{
				List<string> list3 = list;
				int num3 = num;
				List<string> list6 = list3;
				int index2 = num3;
				ReadOnlySpan<char> str2 = list3[num3];
				char c2 = c;
				list6[index2] = str2 + new ReadOnlySpan<char>(ref c2);
			}
			text = c.ToString();
		}
		List<string> list7 = list2[list2.Count - 1];
		if (list7.Count == 1 && list7[0] == "")
		{
			list2.RemoveAt(list2.Count - 1);
		}
		return list2;
	}

	// Token: 0x060035B7 RID: 13751 RVA: 0x000329DC File Offset: 0x00030BDC
	public static bool CheckIsOnlyLettersAndNumbers(string content)
	{
		return Regex.IsMatch(content, "^[A-Za-z0-9]*$");
	}

	// Token: 0x060035B8 RID: 13752 RVA: 0x000329E9 File Offset: 0x00030BE9
	public static bool CheckIsOnlyBlank(string content)
	{
		return Regex.IsMatch(content, "^\\s*$");
	}

	// Token: 0x060035B9 RID: 13753 RVA: 0x000329F8 File Offset: 0x00030BF8
	public static Dictionary<string, string> ParseCSVStringToMap(string content)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] array = content.Split(',', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':', StringSplitOptions.None);
			if (array2.Length == 2)
			{
				string text = array2[0];
				string value = array2[1];
				if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(value))
				{
					dictionary[text] = value;
				}
			}
		}
		return dictionary;
	}

	// Token: 0x04000688 RID: 1672
	public const string ZERO_STRING = "0";

	// Token: 0x04000689 RID: 1673
	public const string ONE_STRING = "1";

	// Token: 0x0400068A RID: 1674
	public const string EMPTY_STRING = "";

	// Token: 0x0400068B RID: 1675
	public const string LINE_BREAK_STRING = "\n";

	// Token: 0x0400068C RID: 1676
	public const string TAB_STRING = "\t";

	// Token: 0x0400068D RID: 1677
	public const string SLASH_STRING = "/";

	// Token: 0x0400068E RID: 1678
	public const string SPEED_STRING = "/s";

	// Token: 0x0400068F RID: 1679
	public const string NONE_STRING = "None";

	// Token: 0x04000690 RID: 1680
	public const string EQUAL = "=";

	// Token: 0x04000691 RID: 1681
	public const string NOT_EQUAL = "!=";

	// Token: 0x04000692 RID: 1682
	public const string LESS_THAN = "<";

	// Token: 0x04000693 RID: 1683
	public const string LESS_EQUAL_THAN = "<=";

	// Token: 0x04000694 RID: 1684
	public const string GRATHER_THAN = ">";

	// Token: 0x04000695 RID: 1685
	public const string GRATHER_EQUAL_THAN = ">=";

	// Token: 0x04000696 RID: 1686
	private const string REG_PATTERN = "{[0-9]+}";

	// Token: 0x04000697 RID: 1687
	private const string REG_FLAGS = "g";

	// Token: 0x04000698 RID: 1688
	private const string UTF8_BOM_HEAD = "﻿";

	// Token: 0x04000699 RID: 1689
	[StaticVariableRuleIgnore]
	private static readonly Regex FormatRegex = new Regex("{[0-9]+}", RegexOptions.None);

	// Token: 0x0400069A RID: 1690
	[StaticVariableRuleIgnore]
	private static readonly StringBuilder StaticBuilder = new StringBuilder();

	// Token: 0x0400069B RID: 1691
	[StaticVariableRuleIgnore]
	private static readonly Regex FormatRegexNew = new Regex("\\{(\\d+)\\}", RegexOptions.None);
}
