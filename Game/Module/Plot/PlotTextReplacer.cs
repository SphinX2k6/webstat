using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005379 RID: 21369
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotTextReplacer
	{
		// Token: 0x0603680B RID: 223243 RVA: 0x00DC5EB8 File Offset: 0x00DC40B8
		public void Init()
		{
			if (this.IsInit)
			{
				return;
			}
			this.IsMale = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male);
			this.PlayerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			this.ThirdPerson = (this.IsMale ? ConfigBase<TextConfig>.Instance.GetTextById("He") : ConfigBase<TextConfig>.Instance.GetTextById("She"));
			this.IsInit = true;
		}

		// Token: 0x0603680C RID: 223244 RVA: 0x00DC5F26 File Offset: 0x00DC4126
		public void Clear()
		{
			this.IsInit = false;
		}

		// Token: 0x0603680D RID: 223245 RVA: 0x00DC5F2F File Offset: 0x00DC412F
		[NullableContext(2)]
		public string Replace(string text, bool needClear = false)
		{
			if (text == null)
			{
				return null;
			}
			if (needClear)
			{
				this.Clear();
			}
			this.Init();
			return this.Pattern.Replace(text, new MatchEvaluator(this.Replacer));
		}

		// Token: 0x0603680E RID: 223246 RVA: 0x00DC5F60 File Offset: 0x00DC4160
		private string Replacer(Match match)
		{
			string value = match.Value;
			GroupCollection groups = match.Groups;
			if (groups.Count >= 3 && !string.IsNullOrEmpty(groups[1].Value) && !string.IsNullOrEmpty(groups[2].Value))
			{
				if (!this.IsMale)
				{
					return groups[2].Value;
				}
				return groups[1].Value;
			}
			else
			{
				if (value == "{TA}")
				{
					return this.ThirdPerson;
				}
				if (value == "{PlayerName}")
				{
					return this.PlayerName;
				}
				return value;
			}
		}

		// Token: 0x0401F61C RID: 128540
		private const string TA = "{TA}";

		// Token: 0x0401F61D RID: 128541
		private const string PLAYER_NAME = "{PlayerName}";

		// Token: 0x0401F61E RID: 128542
		private bool IsInit;

		// Token: 0x0401F61F RID: 128543
		private bool IsMale;

		// Token: 0x0401F620 RID: 128544
		private string PlayerName = "";

		// Token: 0x0401F621 RID: 128545
		private string ThirdPerson = "";

		// Token: 0x0401F622 RID: 128546
		private readonly Regex Pattern = new Regex("\\{(?:Male=(.*?);Female=(.*?)|TA|PlayerName)\\}");
	}
}
