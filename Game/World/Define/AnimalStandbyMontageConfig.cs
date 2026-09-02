using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.World.Define
{
	// Token: 0x020046DA RID: 18138
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class AnimalStandbyMontageConfig : ConfigBase<AnimalStandbyMontageConfig>
	{
		// Token: 0x0602F2AF RID: 193199 RVA: 0x00B2CCE7 File Offset: 0x00B2AEE7
		protected override bool OnInit()
		{
			this.ConfigDataMap = new Dictionary<string, List<AnimalStandbyMontage>>();
			return true;
		}

		// Token: 0x0602F2B0 RID: 193200 RVA: 0x00B2CCF5 File Offset: 0x00B2AEF5
		protected override bool OnClear()
		{
			this.ConfigDataMap = null;
			return true;
		}

		// Token: 0x0602F2B1 RID: 193201 RVA: 0x00B2CD00 File Offset: 0x00B2AF00
		private bool GetAnimalStandbyMontageConfig(string bpPath, List<AnimalStandbyMontage> @out)
		{
			IReadOnlyList<AnimalStandbyMontage> configList = ConfigAnimalStandbyMontageByBp.GetConfigList(bpPath, false);
			if (configList == null)
			{
				return false;
			}
			@out.Clear();
			foreach (AnimalStandbyMontage item in configList)
			{
				@out.Add(item);
			}
			return true;
		}

		// Token: 0x0602F2B2 RID: 193202 RVA: 0x00B2CD5C File Offset: 0x00B2AF5C
		[return: Nullable(2)]
		public List<AnimalStandbyMontage> GetAnimalStandbyMontageData(string bpPath)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				if (!this.ConfigDataMap.ContainsKey(bpPath))
				{
					List<AnimalStandbyMontage> list = new List<AnimalStandbyMontage>();
					if (!this.GetAnimalStandbyMontageConfig(bpPath, list))
					{
						return null;
					}
					this.ConfigDataMap.Add(bpPath, list);
				}
				List<AnimalStandbyMontage> valueOrDefault = this.ConfigDataMap.GetValueOrDefault(bpPath);
				if (valueOrDefault == null)
				{
					return null;
				}
				return valueOrDefault;
			}
			else
			{
				this.ParseConfigFromJsonFile();
				List<AnimalStandbyMontage> valueOrDefault2 = this.ConfigDataMap.GetValueOrDefault(bpPath);
				if (valueOrDefault2 == null)
				{
					return null;
				}
				return valueOrDefault2;
			}
		}

		// Token: 0x0602F2B3 RID: 193203 RVA: 0x00B2CDD0 File Offset: 0x00B2AFD0
		private void ParseConfigFromJsonFile()
		{
			string configPath = Singleton<PublicUtil>.Instance.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/AnimalStandbyTag.json");
			if (!Singleton<PublicUtil>.Instance.IsUseTempData())
			{
				configPath = Singleton<PublicUtil>.Instance.GetConfigPath("Content/Aki/UniverseEditorConfig/Json/AnimalStandbyTag.json");
			}
			if (!UBlueprintPathsLibrary.FileExists(configPath))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "不存在AnimalStandbyTag.json文件。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", configPath);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			string text = "";
			UKuroStaticLibrary.LoadFileToString(ref text, configPath);
			AnimalStandbyMontage[] array = Json.Parse<AnimalStandbyMontage[]>(text, null);
			if (array == null)
			{
				return;
			}
			foreach (AnimalStandbyMontage item in array)
			{
				if (!string.IsNullOrEmpty(item.Bp))
				{
					if (!this.ConfigDataMap.ContainsKey(item.Bp))
					{
						this.ConfigDataMap.Add(item.Bp, new List<AnimalStandbyMontage>());
					}
					this.ConfigDataMap.GetValueOrDefault(item.Bp).Add(item);
				}
			}
		}

		// Token: 0x0401ADE2 RID: 110050
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, List<AnimalStandbyMontage>> ConfigDataMap;
	}
}
