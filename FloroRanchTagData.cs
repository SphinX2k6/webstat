using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;

// Token: 0x02001BD0 RID: 7120
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchTagData
{
	// Token: 0x0600CF41 RID: 53057 RVA: 0x00371A56 File Offset: 0x0036FC56
	public void SetTagId(int tagId)
	{
		if (tagId == this.TagIdInternal)
		{
			return;
		}
		this.TagIdInternal = tagId;
		this.TagConfig = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchTagConfig(this.TagIdInternal);
		this.DynamicParams = null;
	}

	// Token: 0x0600CF42 RID: 53058 RVA: 0x00371A86 File Offset: 0x0036FC86
	public void SetDynamicParams(int n, int m, int p)
	{
		this.DynamicParams = new TagDynamicParams
		{
			N = n,
			M = m,
			P = p
		};
	}

	// Token: 0x170010DC RID: 4316
	// (get) Token: 0x0600CF43 RID: 53059 RVA: 0x00371AA8 File Offset: 0x0036FCA8
	public int TagId
	{
		get
		{
			return this.TagIdInternal;
		}
	}

	// Token: 0x170010DD RID: 4317
	// (get) Token: 0x0600CF44 RID: 53060 RVA: 0x00371AB0 File Offset: 0x0036FCB0
	public string Desc
	{
		get
		{
			if (this.TagConfig == null)
			{
				return "";
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.TagConfig.Value.Name, null);
			if (string.IsNullOrEmpty(localTextNew))
			{
				return "";
			}
			string input = StringUtils.Format(localTextNew, this.TagConfig.Value.NameParam());
			FloroRanchTag config = this.TagConfig.Value;
			ITagDynamicParams parameters = this.DynamicParams;
			return Regex.Replace(input, "\\{[NnMmPp]\\}", delegate(Match match)
			{
				char c = char.ToUpper(match.Value[1]);
				if (c == 'N')
				{
					if (parameters == null)
					{
						return config.N;
					}
					return parameters.N.ToString();
				}
				else if (c == 'M')
				{
					if (parameters == null)
					{
						return config.M;
					}
					return parameters.M.ToString();
				}
				else
				{
					if (parameters == null)
					{
						return config.P;
					}
					return parameters.P.ToString();
				}
			});
		}
	}

	// Token: 0x040062B3 RID: 25267
	private int TagIdInternal;

	// Token: 0x040062B4 RID: 25268
	private FloroRanchTag? TagConfig;

	// Token: 0x040062B5 RID: 25269
	[Nullable(2)]
	private ITagDynamicParams DynamicParams;
}
