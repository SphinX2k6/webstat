using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001E2F RID: 7727
[NullableContext(1)]
[Nullable(0)]
public class GuidePrefabDefine : IStaticVariableResetter
{
	// Token: 0x0600E49A RID: 58522 RVA: 0x003DABAC File Offset: 0x003D8DAC
	static GuidePrefabDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GuidePrefabDefine.CreateStaticDefaultValue), new Action(GuidePrefabDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600E49B RID: 58523 RVA: 0x003DABCC File Offset: 0x003D8DCC
	public static void CreateStaticDefaultValue()
	{
		Dictionary<string, GuidePrefabDefine.IPrefabSettingValue> dictionary = new Dictionary<string, GuidePrefabDefine.IPrefabSettingValue>();
		string key = "FightConcertoStateGuide";
		GuidePrefabDefine.PrefabSettingValue prefabSettingValue = new GuidePrefabDefine.PrefabSettingValue();
		prefabSettingValue.GetPrefabPathFunc = delegate(string[] args)
		{
			List<string> res = new List<string>();
			ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true).ToList<EntityHandle>().ForEach(delegate(EntityHandle roleEntity)
			{
				res.Add("/Game/Aki/UI/UIResources/UiFight/Prefabs/FightConcertoState.FightConcertoState");
			});
			return res.ToArray();
		};
		prefabSettingValue.Callback = delegate(AActor[] actors, string[] args)
		{
			List<EntityHandle> list = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true).ToList<EntityHandle>();
			int index;
			int index2;
			for (index = 0; index < list.Count; index = index2 + 1)
			{
				EntityHandle roleEntity = list[index];
				if (index < actors.Length)
				{
					ConcertoResponseItem item = new ConcertoResponseItem();
					item.CreateByActorAsync(actors[index], null, false).ContinueWith(delegate()
					{
						item.Refresh(ModelBase<BattleUiModel>.Instance.GetRoleData(roleEntity.Id));
						(actors[index].GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(true);
					});
				}
				index2 = index;
			}
		};
		dictionary.Add(key, prefabSettingValue);
		GuidePrefabDefine.predefPrefabSetting = dictionary;
	}

	// Token: 0x0600E49C RID: 58524 RVA: 0x003DAC3D File Offset: 0x003D8E3D
	public static void ResetStaticDefaultValue()
	{
		GuidePrefabDefine.predefPrefabSetting = null;
	}

	// Token: 0x0600E49D RID: 58525 RVA: 0x003DAC48 File Offset: 0x003D8E48
	public static void setPrefabText(UUIText text, string content)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<GuidePrefabDefine.IPrefabConf> prefabas = new List<GuidePrefabDefine.IPrefabConf>();
		List<string> list = new List<string>();
		List<int> prefabSlice = new List<int>();
		int num = 0;
		int i = 0;
		while (i < content.Length)
		{
			int num2 = content.IndexOf('[', i);
			if (num2 == -1)
			{
				stringBuilder.Append(content.Substring(i, content.Length - i));
				break;
			}
			stringBuilder.Append(content.Substring(i, num2 - i));
			int num3 = content.IndexOf(']', num2);
			if (num3 <= num2)
			{
				stringBuilder.Append(content.Substring(num2 + 1, content.Length - num2 - 1));
				break;
			}
			string[] array = content.Substring(num2 + 1, num3 - num2 - 1).Split(',', StringSplitOptions.None);
			if (array.Length == 0)
			{
				return;
			}
			prefabas.Add(new GuidePrefabDefine.PrefabConf
			{
				PrefabKey = array[0],
				Args = array
			});
			GuidePrefabDefine.IPrefabSettingValue prefabSettingValue;
			if (!GuidePrefabDefine.predefPrefabSetting.TryGetValue(array[0], out prefabSettingValue))
			{
				return;
			}
			string[] array2 = prefabSettingValue.GetPrefabPathFunc(array);
			prefabSlice.Add(array2.Length);
			list.AddRange(array2);
			i = num3 + 1;
			for (int j = 0; j < array2.Length; j++)
			{
				stringBuilder.Append("<snidx=");
				stringBuilder.Append(num);
				stringBuilder.Append("/>");
				num++;
			}
		}
		Singleton<LguiUtil>.Instance.LoadAndSetText(text, stringBuilder.ToString(), list.ToArray(), delegate(AActor[] objects)
		{
			int num4 = 0;
			for (int k = 0; k < prefabas.Count; k++)
			{
				GuidePrefabDefine.IPrefabConf prefabConf = prefabas[k];
				GuidePrefabDefine.IPrefabSettingValue prefabSettingValue2;
				if (GuidePrefabDefine.predefPrefabSetting.TryGetValue(prefabConf.PrefabKey, out prefabSettingValue2) && prefabSettingValue2 != null && prefabSettingValue2.Callback != null)
				{
					prefabSettingValue2.Callback(objects.Skip(num4).Take(prefabSlice[k]).ToArray<AActor>(), prefabConf.Args);
				}
				num4 += prefabSlice[k];
			}
		}, "js_undefined");
	}

	// Token: 0x04006DF0 RID: 28144
	public const string NEW_TAG = "New:";

	// Token: 0x04006DF1 RID: 28145
	public static Dictionary<string, GuidePrefabDefine.IPrefabSettingValue> predefPrefabSetting;

	// Token: 0x02008194 RID: 33172
	public interface IPrefabSettingValue
	{
		// Token: 0x1700A837 RID: 43063
		// (get) Token: 0x060484EA RID: 296170
		// (set) Token: 0x060484EB RID: 296171
		Func<string[], string[]> GetPrefabPathFunc { get; set; }

		// Token: 0x1700A838 RID: 43064
		// (get) Token: 0x060484EC RID: 296172
		// (set) Token: 0x060484ED RID: 296173
		Action<AActor[], string[]> Callback { get; set; }
	}

	// Token: 0x02008195 RID: 33173
	[Nullable(0)]
	public class PrefabSettingValue : GuidePrefabDefine.IPrefabSettingValue
	{
		// Token: 0x1700A839 RID: 43065
		// (get) Token: 0x060484EE RID: 296174 RVA: 0x0135F58A File Offset: 0x0135D78A
		// (set) Token: 0x060484EF RID: 296175 RVA: 0x0135F592 File Offset: 0x0135D792
		public Func<string[], string[]> GetPrefabPathFunc { get; set; }

		// Token: 0x1700A83A RID: 43066
		// (get) Token: 0x060484F0 RID: 296176 RVA: 0x0135F59B File Offset: 0x0135D79B
		// (set) Token: 0x060484F1 RID: 296177 RVA: 0x0135F5A3 File Offset: 0x0135D7A3
		public Action<AActor[], string[]> Callback { get; set; }
	}

	// Token: 0x02008196 RID: 33174
	public interface IPrefabConf
	{
		// Token: 0x1700A83B RID: 43067
		// (get) Token: 0x060484F3 RID: 296179
		// (set) Token: 0x060484F4 RID: 296180
		string PrefabKey { get; set; }

		// Token: 0x1700A83C RID: 43068
		// (get) Token: 0x060484F5 RID: 296181
		// (set) Token: 0x060484F6 RID: 296182
		string[] Args { get; set; }
	}

	// Token: 0x02008197 RID: 33175
	[Nullable(0)]
	public class PrefabConf : GuidePrefabDefine.IPrefabConf
	{
		// Token: 0x1700A83D RID: 43069
		// (get) Token: 0x060484F7 RID: 296183 RVA: 0x0135F5B4 File Offset: 0x0135D7B4
		// (set) Token: 0x060484F8 RID: 296184 RVA: 0x0135F5BC File Offset: 0x0135D7BC
		public string PrefabKey { get; set; }

		// Token: 0x1700A83E RID: 43070
		// (get) Token: 0x060484F9 RID: 296185 RVA: 0x0135F5C5 File Offset: 0x0135D7C5
		// (set) Token: 0x060484FA RID: 296186 RVA: 0x0135F5CD File Offset: 0x0135D7CD
		public string[] Args { get; set; }
	}
}
