using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048EE RID: 18670
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CharacterEmotionBubbleController : ControllerBase<CharacterEmotionBubbleController>
	{
		// Token: 0x06030BE2 RID: 199650 RVA: 0x00C0B314 File Offset: 0x00C09514
		protected override bool OnInit()
		{
			this.InitEmotionConfig();
			this.InitAnimalConfig();
			return true;
		}

		// Token: 0x06030BE3 RID: 199651 RVA: 0x00C0B324 File Offset: 0x00C09524
		[NullableContext(2)]
		public IEmotionConfigInfo GetMonsterEmotionConfigById(int id)
		{
			if (!this.MonsterEmotionMap.ContainsKey(id))
			{
				this.InitMonsterConfig(id);
			}
			IEmotionConfigInfo result;
			this.MonsterEmotionMap.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x06030BE4 RID: 199652 RVA: 0x00C0B358 File Offset: 0x00C09558
		[NullableContext(2)]
		public IEmotionEffectInfo GetMonsterEmotionInfo(int id)
		{
			IEmotionConfigInfo monsterEmotionConfigById = this.GetMonsterEmotionConfigById(id);
			if (monsterEmotionConfigById == null)
			{
				return null;
			}
			string text;
			this.EmotionEffectMap.TryGetValue(monsterEmotionConfigById.EmotionName, out text);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			return new IEmotionEffectInfo
			{
				Effect = text,
				Socket = monsterEmotionConfigById.Socket,
				Offset = monsterEmotionConfigById.Offset
			};
		}

		// Token: 0x06030BE5 RID: 199653 RVA: 0x00C0B3B4 File Offset: 0x00C095B4
		[return: Nullable(2)]
		public IEmotionEffectInfo GetAnimalEmotionInfo(string blueprintPath, string emotion, string montage)
		{
			string text;
			this.EmotionEffectMap.TryGetValue(emotion, out text);
			IEmotionBubbleConfig emotionBubbleConfig = null;
			Dictionary<string, Dictionary<string, IEmotionBubbleConfig>> dictionary;
			Dictionary<string, IEmotionBubbleConfig> dictionary2;
			if (this.EmotionMontageMap.TryGetValue(blueprintPath, out dictionary) && dictionary.TryGetValue(emotion, out dictionary2))
			{
				dictionary2.TryGetValue(montage, out emotionBubbleConfig);
			}
			if (text != null && emotionBubbleConfig != null)
			{
				return new IEmotionEffectInfo
				{
					Effect = text,
					Socket = emotionBubbleConfig.Socket,
					Offset = emotionBubbleConfig.Offset
				};
			}
			return null;
		}

		// Token: 0x06030BE6 RID: 199654 RVA: 0x00C0B424 File Offset: 0x00C09624
		private void InitEmotionConfig()
		{
			IReadOnlyList<EmotionBubbleConfig> configList = ConfigEmotionBubbleConfigAll.GetConfigList(true);
			if (configList == null || configList.Count == 0)
			{
				return;
			}
			foreach (EmotionBubbleConfig emotionBubbleConfig in configList)
			{
				this.EmotionEffectMap[emotionBubbleConfig.EmotionName] = emotionBubbleConfig.EmotionPath;
			}
		}

		// Token: 0x06030BE7 RID: 199655 RVA: 0x00C0B494 File Offset: 0x00C09694
		private unsafe void InitMonsterConfig(int id)
		{
			EmotionBubbleMonsterConfig? config = ConfigEmotionBubbleMonsterConfigById.GetConfig(id, true);
			if (config == null)
			{
				return;
			}
			List<int> list = new List<int>();
			if (config.Value.StateTagList() != null)
			{
				string[] array = config.Value.StateTagList();
				int i = 0;
				while (i < array.Length)
				{
					string text = array[i];
					FGameplayTag? gameplayTagByName = GameplayTagUtils.GetGameplayTagByName(text);
					int? num = (gameplayTagByName != null) ? new int?(gameplayTagByName.GetValueOrDefault().TagId()) : null;
					if (num == null)
					{
						goto IL_A4;
					}
					int? num2 = num;
					int num3 = 0;
					if (num2.GetValueOrDefault() == num3 & num2 != null)
					{
						goto IL_A4;
					}
					list.Add(num.Value);
					IL_10C:
					i++;
					continue;
					IL_A4:
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "[Emotion] InitMonsterConfig 没找到对应Tag";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Tag", text);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					goto IL_10C;
				}
			}
			if (list.Count == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Character;
				ELogAuthor author2 = ELogAuthor.CWZ;
				string message2 = "[Emotion] InitMonsterConfig 配置无任何有效 Tag，跳过";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.MonsterEmotionMap[id] = new IEmotionConfigInfo
			{
				EmotionName = config.Value.EmotionName,
				TagList = list,
				Socket = config.Value.AttachPoint,
				Offset = global::Vector.Create((double)config.Value.Offset(0), (double)config.Value.Offset(1), (double)config.Value.Offset(2))
			};
		}

		// Token: 0x06030BE8 RID: 199656 RVA: 0x00C0B678 File Offset: 0x00C09878
		private void InitAnimalConfig()
		{
			IReadOnlyList<EmotionBubbleAnimalConfig> configList = ConfigEmotionBubbleAnimalConfigAll.GetConfigList(true);
			if (configList == null || configList.Count == 0)
			{
				return;
			}
			foreach (EmotionBubbleAnimalConfig emotionBubbleAnimalConfig in configList)
			{
				string monsterBp = emotionBubbleAnimalConfig.MonsterBp;
				if (!this.EmotionMontageMap.ContainsKey(monsterBp))
				{
					this.EmotionMontageMap[monsterBp] = new Dictionary<string, Dictionary<string, IEmotionBubbleConfig>>();
				}
				Dictionary<string, Dictionary<string, IEmotionBubbleConfig>> dictionary = this.EmotionMontageMap[monsterBp];
				string montagePath = emotionBubbleAnimalConfig.MontagePath;
				if (montagePath.Length < 1)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "[Emotion] InitAnimalConfig MontagePath为空";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BlueprintPath", monsterBp);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					if (!dictionary.ContainsKey(emotionBubbleAnimalConfig.EmotionName))
					{
						dictionary[emotionBubbleAnimalConfig.EmotionName] = new Dictionary<string, IEmotionBubbleConfig>();
					}
					dictionary[emotionBubbleAnimalConfig.EmotionName][montagePath] = new IEmotionBubbleConfig
					{
						Socket = emotionBubbleAnimalConfig.AttachPoint,
						Offset = global::Vector.Create((double)emotionBubbleAnimalConfig.Offset(0), (double)emotionBubbleAnimalConfig.Offset(1), (double)emotionBubbleAnimalConfig.Offset(2))
					};
				}
			}
		}

		// Token: 0x0401C039 RID: 114745
		private readonly Dictionary<int, IEmotionConfigInfo> MonsterEmotionMap = new Dictionary<int, IEmotionConfigInfo>();

		// Token: 0x0401C03A RID: 114746
		private readonly Dictionary<string, Dictionary<string, Dictionary<string, IEmotionBubbleConfig>>> EmotionMontageMap = new Dictionary<string, Dictionary<string, Dictionary<string, IEmotionBubbleConfig>>>();

		// Token: 0x0401C03B RID: 114747
		private readonly Dictionary<string, string> EmotionEffectMap = new Dictionary<string, string>();
	}
}
