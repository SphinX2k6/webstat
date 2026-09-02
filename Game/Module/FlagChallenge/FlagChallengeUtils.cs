using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D42 RID: 23874
	public class FlagChallengeUtils
	{
		// Token: 0x0603C329 RID: 246569 RVA: 0x00F447F4 File Offset: 0x00F429F4
		[NullableContext(1)]
		public unsafe static string GetDynamicRes(EFlagChallengeUiStyleType style, string baseKey, int index)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted(baseKey);
			defaultInterpolatedStringHandler.AppendFormatted<int>(index);
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			Dictionary<string, string> dictionary;
			if (!Singleton<FlagChallengeDefine>.Instance.flagChallengeStyleRes.TryGetValue(style, out dictionary))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "未定义的资源";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("style", style);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", text);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return "";
			}
			string text2;
			if (!dictionary.TryGetValue(text, out text2) || string.IsNullOrEmpty(text2))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.FlagChallenge;
				ELogAuthor author2 = ELogAuthor.LJS;
				string message2 = "未定义的资源";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("style", style);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("key", text);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return "";
			}
			return text2;
		}

		// Token: 0x0603C32A RID: 246570 RVA: 0x00F4490C File Offset: 0x00F42B0C
		public static bool IsInFlagChallengeDungeon()
		{
			return ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon;
		}

		// Token: 0x0603C32B RID: 246571 RVA: 0x00F44918 File Offset: 0x00F42B18
		public static int GetStrongholdActivityId(int strongholdId)
		{
			FlagStronghold? strongholdConfig = ConfigBase<FlagChallengeConfig>.Instance.GetStrongholdConfig(strongholdId);
			return ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(strongholdConfig.Value.ChallengeLevelId).Value.ActivityId;
		}

		// Token: 0x0603C32C RID: 246572 RVA: 0x00F4495C File Offset: 0x00F42B5C
		public static int GetAreaActivityId(int areaId)
		{
			FlagChallengeArea? areaConfig = ConfigBase<FlagChallengeConfig>.Instance.GetAreaConfig(areaId);
			return ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(areaConfig.Value.LevelId).Value.ActivityId;
		}

		// Token: 0x0603C32D RID: 246573 RVA: 0x00F449A0 File Offset: 0x00F42BA0
		public static int GetLevelActivityId(int levelId)
		{
			return ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(levelId).Value.ActivityId;
		}

		// Token: 0x0603C32E RID: 246574 RVA: 0x00F449C8 File Offset: 0x00F42BC8
		public static int GetBuffActivityId(int buffId)
		{
			return ConfigBase<FlagChallengeConfig>.Instance.GetRoleBuffConfig(buffId).Value.ActivityId;
		}
	}
}
