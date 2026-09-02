using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000E63 RID: 3683
public class NumberUtil
{
	// Token: 0x0600589F RID: 22687 RVA: 0x00107554 File Offset: 0x00105754
	[NullableContext(1)]
	public static string GetNumberLocalText(int num)
	{
		string id = "";
		if (num == 1)
		{
			id = "One";
		}
		else if (num == 2)
		{
			id = "Two";
		}
		else if (num == 3)
		{
			id = "Three";
		}
		else if (num == 4)
		{
			id = "Four";
		}
		else if (num == 5)
		{
			id = "Five";
		}
		else if (num == 6)
		{
			id = "Six";
		}
		else if (num == 7)
		{
			id = "Seven";
		}
		else if (num == 8)
		{
			id = "Eight";
		}
		else if (num == 9)
		{
			id = "Nine";
		}
		else if (num == 10)
		{
			id = "Ten";
		}
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById(id), null) ?? "";
	}
}
