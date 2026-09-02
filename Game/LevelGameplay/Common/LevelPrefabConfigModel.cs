using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Common
{
	// Token: 0x02006F2D RID: 28461
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class LevelPrefabConfigModel : ModelBase<LevelPrefabConfigModel>
	{
		// Token: 0x06044E9D RID: 282269 RVA: 0x011F0CDC File Offset: 0x011EEEDC
		protected override bool OnInit()
		{
			string text = "";
			string configPath = this.GetConfigPath();
			UKuroStaticLibrary.LoadFileToString(ref text, configPath);
			if (StringUtils.IsNothing(text))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.CH;
				string message = "LoadFileToString returned empty content";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", configPath);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			LevelPrefabConfig levelPrefabConfig = Json.Parse<LevelPrefabConfig>(text, null);
			if (levelPrefabConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Config;
				ELogAuthor author2 = ELogAuthor.CH;
				string message2 = "Failed to parse LevelPrefabConfig.json";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", configPath);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return true;
			}
			this.Config = levelPrefabConfig;
			return true;
		}

		// Token: 0x06044E9E RID: 282270 RVA: 0x011F0D6C File Offset: 0x011EEF6C
		private string GetConfigPath()
		{
			if (this.ConfigPath == null)
			{
				string str = UKismetSystemLibrary.ConvertToAbsolutePath(UBlueprintPathsLibrary.ProjectContentDir());
				this.ConfigPath = UKismetSystemLibrary.ConvertToAbsolutePath(str + "Aki/Config/Json/NewKuroLevelPrefabConfig.json");
			}
			return this.ConfigPath;
		}

		// Token: 0x06044E9F RID: 282271 RVA: 0x011F0DA8 File Offset: 0x011EEFA8
		public bool IsCloseUroPrefab(string prefabName)
		{
			return this.Config != null && Array.Exists<string>(this.Config.CloseUroPrefab, (string x) => x == prefabName);
		}

		// Token: 0x040266CC RID: 157388
		[Nullable(2)]
		private LevelPrefabConfig Config;

		// Token: 0x040266CD RID: 157389
		[Nullable(2)]
		private string ConfigPath;
	}
}
