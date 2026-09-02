using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aki.Config;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200534F RID: 21327
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PlotAudioModel : ModelBase<PlotAudioModel>
	{
		// Token: 0x0603665F RID: 222815 RVA: 0x00DB7024 File Offset: 0x00DB5224
		public string GetExternalSourcesMediaName(PlotAudio config)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			string value = "";
			string value2 = this.UpdateVarExtension(config.VarParams, config.FileName);
			string packageAudio = Singleton<LanguageSystem>.Instance.PackageAudio;
			if (!(packageAudio == "zh"))
			{
				if (!(packageAudio == "en"))
				{
					if (!(packageAudio == "ja"))
					{
						if (packageAudio == "ko")
						{
							flag = config.CheckGenderKo;
						}
					}
					else
					{
						flag = config.CheckGenderJa;
					}
				}
				else
				{
					flag = config.CheckGenderEn;
				}
			}
			else
			{
				flag = config.CheckGenderZh;
			}
			string value3 = Singleton<LanguageSystem>.Instance.PackageAudio;
			if (config.GlobalLanguage)
			{
				value3 = "gl";
			}
			if (flag)
			{
				value = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "_F" : "_M");
			}
			stringBuilder.Append(value3).Append("_").Append(value2).Append(value).Append(".wem");
			return stringBuilder.ToString();
		}

		// Token: 0x06036660 RID: 222816 RVA: 0x00DB7128 File Offset: 0x00DB5328
		public string GetAudioMouthAnimName(PlotAudio config)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			string value = "";
			string value2 = this.UpdateVarExtension(config.VarParams, config.FileName);
			string packageAudio = Singleton<LanguageSystem>.Instance.PackageAudio;
			if (!(packageAudio == "zh"))
			{
				if (!(packageAudio == "en"))
				{
					if (!(packageAudio == "ja"))
					{
						if (packageAudio == "ko")
						{
							flag = config.CheckGenderKo;
						}
					}
					else
					{
						flag = config.CheckGenderJa;
					}
				}
				else
				{
					flag = config.CheckGenderEn;
				}
			}
			else
			{
				flag = config.CheckGenderZh;
			}
			string value3 = Singleton<LanguageSystem>.Instance.PackageAudio;
			if (config.GlobalLanguage)
			{
				value3 = "gl";
			}
			if (flag)
			{
				value = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "_F" : "_M");
			}
			stringBuilder.Append(value3).Append("_").Append(value2).Append(value);
			string value4 = stringBuilder.ToString();
			stringBuilder.Clear();
			stringBuilder.Append("/Game/Aki/Sequence/SequenceAnim/VoiceMouth/").Append(Singleton<LanguageSystem>.Instance.PackageAudio).Append("/").Append(value4).Append(".").Append(value4);
			return stringBuilder.ToString();
		}

		// Token: 0x06036661 RID: 222817 RVA: 0x00DB7270 File Offset: 0x00DB5470
		public string GetExternalSourcesMediaNameForEditor(PlotAudio config, bool isFemale)
		{
			bool flag = false;
			string value = "";
			string value2 = this.UpdateVarExtension(config.VarParams, config.FileName);
			string packageAudio = Singleton<LanguageSystem>.Instance.PackageAudio;
			if (!(packageAudio == "zh"))
			{
				if (!(packageAudio == "en"))
				{
					if (!(packageAudio == "ja"))
					{
						if (packageAudio == "ko")
						{
							flag = config.CheckGenderKo;
						}
					}
					else
					{
						flag = config.CheckGenderJa;
					}
				}
				else
				{
					flag = config.CheckGenderEn;
				}
			}
			else
			{
				flag = config.CheckGenderZh;
			}
			if (flag)
			{
				value = (isFemale ? "_F" : "_M");
			}
			return new StringBuilder(Singleton<LanguageSystem>.Instance.PackageAudio).Append("_").Append(value2).Append(value).Append(".wem").ToString();
		}

		// Token: 0x06036662 RID: 222818 RVA: 0x00DB7348 File Offset: 0x00DB5548
		private Dictionary<string, string> ParseParamString(string paramString)
		{
			string[] array = paramString.Split(' ', StringSplitOptions.None);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split('=', StringSplitOptions.None);
				if (array3.Length == 2)
				{
					dictionary[array3[0]] = array3[1];
				}
			}
			return dictionary;
		}

		// Token: 0x06036663 RID: 222819 RVA: 0x00DB7394 File Offset: 0x00DB5594
		private string UpdateVarExtension(string info, string name)
		{
			string text = "";
			if (StringUtils.IsBlank(info))
			{
				return name;
			}
			Dictionary<string, string> dictionary = this.ParseParamString(info);
			string a;
			string key;
			if (dictionary.TryGetValue("VarType", out a) && a == "Global" && dictionary.TryGetValue("Key", out key))
			{
				text = (ModelBase<WorldModel>.Instance.GetWorldStateString(key) ?? "");
			}
			if (StringUtils.IsBlank(text))
			{
				return name;
			}
			return new Regex("\\{VarParams\\}").Replace(name, text);
		}

		// Token: 0x0401F484 RID: 128132
		private const string GLOBAL = "gl";
	}
}
