using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E94 RID: 28308
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class FishingQteModel : ModelBase<FishingQteModel>
	{
		// Token: 0x1700A3C9 RID: 41929
		// (get) Token: 0x06044A45 RID: 281157 RVA: 0x011D72BB File Offset: 0x011D54BB
		[Nullable(2)]
		public IFishingQteConfig GameConfig
		{
			[NullableContext(2)]
			get
			{
				if (Singleton<PublicUtil>.Instance.UseDbConfig())
				{
					return this.GameDbConfigProxy;
				}
				return this.GameJsonConfig;
			}
		}

		// Token: 0x06044A46 RID: 281158 RVA: 0x011D72D8 File Offset: 0x011D54D8
		[NullableContext(0)]
		public UniTask<bool> GameplayStart(int pbEntityId, long creatureDataId)
		{
			FishingQteModel.<GameplayStart>d__15 <GameplayStart>d__;
			<GameplayStart>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<GameplayStart>d__.<>4__this = this;
			<GameplayStart>d__.pbEntityId = pbEntityId;
			<GameplayStart>d__.creatureDataId = creatureDataId;
			<GameplayStart>d__.<>1__state = -1;
			<GameplayStart>d__.<>t__builder.Start<FishingQteModel.<GameplayStart>d__15>(ref <GameplayStart>d__);
			return <GameplayStart>d__.<>t__builder.Task;
		}

		// Token: 0x06044A47 RID: 281159 RVA: 0x011D732C File Offset: 0x011D552C
		public bool GameplayStartByTempFishPoint(long creatureDataId)
		{
			TempFishingPointData tempFishingPointDataByCreatureDataId = ModelBase<FishingModel>.Instance.GetTempFishingPointDataByCreatureDataId(creatureDataId);
			if (tempFishingPointDataByCreatureDataId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[FishingQte] 无法查到对应临时捕捞点信息";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (tempFishingPointDataByCreatureDataId.CurrentCount == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelPlay;
				ELogAuthor author2 = ELogAuthor.YYZ;
				string message2 = "[FishingQte] 交互点可捕捞次数不足";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("临时捕捞点实体Id", tempFishingPointDataByCreatureDataId.CreatureDataId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			this.CurrentFishingPointCreatureDataId = creatureDataId;
			this.CurrentFishingPointConfigId = 0;
			this.CurrentGameplayId = tempFishingPointDataByCreatureDataId.GamePlayId;
			this.CurrentInteractType = EFishingPointType.Temp;
			this.CurrentFishingIconType = EFishingIconType.Fish;
			return this.InitialGameInfo(tempFishingPointDataByCreatureDataId.CurrentCount);
		}

		// Token: 0x06044A48 RID: 281160 RVA: 0x011D73E8 File Offset: 0x011D55E8
		private unsafe bool InitialGameInfo(int maxRound)
		{
			this.InitTechEffect();
			this.InitialConfig();
			if (this.GameInfo == null)
			{
				this.GameInfo = new FishingQteGameInfo();
			}
			this.GameInfo.Clear();
			EArrowDirection arrowDirection = this.GameConfig.IsAnticlockwise ? EArrowDirection.Anticlockwise : EArrowDirection.Clockwise;
			this.GameInfo.CreateRingInfo(arrowDirection);
			this.GameInfo.MaxRound = maxRound;
			IntArray[] invalidArea = this.GameConfig.InvalidArea;
			this.GameInfo.GetRingInfo().IsWholeRing = (invalidArea.Length == 0);
			this.AccumulatePerfectCombo = 0;
			this.TempGetDataMap.Clear();
			this.TempGetDataTagMap.Clear();
			this.TempGetDataList.Clear();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[FishingQte] 捕鱼玩法开始";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LevelGameplayId", this.CurrentGameplayId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FishingPointId", this.CurrentFishingPointConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("cIncId", this.CurrentFishingPointCreatureDataId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return true;
		}

		// Token: 0x06044A49 RID: 281161 RVA: 0x011D751C File Offset: 0x011D571C
		private void InitTechEffect()
		{
			this.FishingQteAutoFactor = 1f;
			this.FishingQteOnFactor = 1f;
			Dictionary<int, HashSet<int>> effectType2TechIdsMap = ModelBase<FishingModel>.Instance.EffectType2TechIdsMap;
			HashSet<int> hashSet;
			if (effectType2TechIdsMap.TryGetValue(11, out hashSet))
			{
				foreach (int techId in hashSet)
				{
					if (ModelBase<FishingModel>.Instance.GetFishingTechUnlock(techId))
					{
						int techEffectId = ConfigBase<FishingConfig>.Instance.GetFishingTechById(techId).Effect(0);
						FishingTechEffect fishingTechEffectById = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId);
						this.FishingQteAutoFactor += (float)fishingTechEffectById.Params(0) * 0.01f;
					}
				}
			}
			HashSet<int> hashSet2;
			if (effectType2TechIdsMap.TryGetValue(10, out hashSet2))
			{
				foreach (int techId2 in hashSet2)
				{
					if (ModelBase<FishingModel>.Instance.GetFishingTechUnlock(techId2))
					{
						int techEffectId2 = ConfigBase<FishingConfig>.Instance.GetFishingTechById(techId2).Effect(0);
						FishingTechEffect fishingTechEffectById2 = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId2);
						this.FishingQteOnFactor += (float)fishingTechEffectById2.Params(0) * 0.01f;
					}
				}
			}
		}

		// Token: 0x06044A4A RID: 281162 RVA: 0x011D7674 File Offset: 0x011D5874
		private void InitialConfig()
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				this.GameDbConfig = ConfigBase<FishingConfig>.Instance.GetFishingQteConfig(this.CurrentGameplayId);
				if (this.GameDbConfig != null)
				{
					this.GameDbConfigProxy = new FishingQteConfigDbProxy(this.GameDbConfig.Value);
					return;
				}
				this.GameDbConfigProxy = null;
				return;
			}
			else
			{
				string text = "../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/FishingRouletteConfig.json";
				if (text == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.YYZ, "[FishingQte] 捕鱼转盘玩法找不到Json数据配置", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				string configPath = Singleton<PublicUtil>.Instance.GetConfigPath(text);
				string text2 = "";
				UKuroStaticLibrary.LoadFileToString(ref text2, configPath);
				List<IFishingQteConfig> list = Json.Decode<List<IFishingQteConfig>>(text2, null);
				if (list != null)
				{
					IFishingQteConfig fishingQteConfig = list.Find((IFishingQteConfig value) => value.Id == this.CurrentGameplayId);
					this.GameJsonConfig = fishingQteConfig;
					this.GameJsonConfig.CursorSpeed = this.StringToListValue(fishingQteConfig.CursorSpeed.Cast<object>().ToString());
					this.GameJsonConfig.RouletteRotateSpeed = this.StringToListValue(fishingQteConfig.RouletteRotateSpeed.Cast<object>().ToString());
					this.GameJsonConfig.PerfectAppearRate = this.StringToListValue(fishingQteConfig.PerfectAppearRate.Cast<object>().ToString());
				}
				return;
			}
		}

		// Token: 0x06044A4B RID: 281163 RVA: 0x011D77A4 File Offset: 0x011D59A4
		private Dictionary<int, int> StringToListValue(string stringValue)
		{
			string[] array = stringValue.Replace("[", "").Replace("]", "").Split(',', StringSplitOptions.None);
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(':', StringSplitOptions.None);
				dictionary[int.Parse(array3[0])] = int.Parse(array3[1]);
			}
			return dictionary;
		}

		// Token: 0x06044A4C RID: 281164 RVA: 0x011D7810 File Offset: 0x011D5A10
		public void EnterNextRound()
		{
			this.GameInfo.CurrentRound = Math.Min(this.GameInfo.CurrentRound + 1, this.GameInfo.MaxRound);
			if (this.GameInfo.CurrentRound != this.GameInfo.MaxRound)
			{
				this.GameInfo.CurrentScore -= (float)this.GameConfig.MaxScore;
				return;
			}
			this.GameInfo.SetGameStage(EFishingQteStage.End);
		}

		// Token: 0x1700A3CA RID: 41930
		// (get) Token: 0x06044A4D RID: 281165 RVA: 0x011D7888 File Offset: 0x011D5A88
		public float ScoreUp
		{
			get
			{
				return (float)this.GameConfig.ScoreUp * this.FishingQteAutoFactor;
			}
		}

		// Token: 0x1700A3CB RID: 41931
		// (get) Token: 0x06044A4E RID: 281166 RVA: 0x011D789D File Offset: 0x011D5A9D
		public float HitAreaScore
		{
			get
			{
				return (float)this.GameConfig.HitAreaScore * this.FishingQteOnFactor;
			}
		}

		// Token: 0x1700A3CC RID: 41932
		// (get) Token: 0x06044A4F RID: 281167 RVA: 0x011D78B2 File Offset: 0x011D5AB2
		public float PerfectScore
		{
			get
			{
				return (float)this.GameConfig.PerfectScore * this.FishingQteOnFactor;
			}
		}

		// Token: 0x1700A3CD RID: 41933
		// (get) Token: 0x06044A51 RID: 281169 RVA: 0x011D78D6 File Offset: 0x011D5AD6
		// (set) Token: 0x06044A50 RID: 281168 RVA: 0x011D78C7 File Offset: 0x011D5AC7
		private int AccumulatePerfectCombo
		{
			get
			{
				return this.AccumulatePerfectComboInternal;
			}
			set
			{
				this.AccumulatePerfectComboInternal = value;
				this.RefreshAccumulatePerfectCombo();
			}
		}

		// Token: 0x06044A52 RID: 281170 RVA: 0x011D78E0 File Offset: 0x011D5AE0
		public void OnQteOn()
		{
			this.GameInfo.CurrentScore += this.HitAreaScore;
			int accumulatePerfectCombo = this.AccumulatePerfectCombo;
			this.AccumulatePerfectCombo = accumulatePerfectCombo + 1;
		}

		// Token: 0x06044A53 RID: 281171 RVA: 0x011D7918 File Offset: 0x011D5B18
		public void OnPerfectOn()
		{
			this.GameInfo.CurrentScore += this.PerfectScore;
			int accumulatePerfectCombo = this.AccumulatePerfectCombo;
			this.AccumulatePerfectCombo = accumulatePerfectCombo + 1;
		}

		// Token: 0x06044A54 RID: 281172 RVA: 0x011D794D File Offset: 0x011D5B4D
		public void OnMissOn()
		{
			this.GameInfo.CurrentScore = Math.Max(0f, this.GameInfo.CurrentScore - (float)this.GameConfig.MistakeScore);
			this.AccumulatePerfectCombo = 0;
		}

		// Token: 0x06044A55 RID: 281173 RVA: 0x011D7984 File Offset: 0x011D5B84
		private void RefreshAccumulatePerfectCombo()
		{
			int accumulatePerfectCombo = this.AccumulatePerfectCombo;
			this.GameInfo.CursorSpeed = (float)this.RefreshInfoByKey(accumulatePerfectCombo, this.GameConfig.CursorSpeed);
			this.GameInfo.RingSpeed = (float)this.RefreshInfoByKey(accumulatePerfectCombo, this.GameConfig.RouletteRotateSpeed);
			this.GameInfo.PerfectAppearRate = (float)this.RefreshInfoByKey(accumulatePerfectCombo, this.GameConfig.PerfectAppearRate);
		}

		// Token: 0x06044A56 RID: 281174 RVA: 0x011D79F4 File Offset: 0x011D5BF4
		private int RefreshInfoByKey(int currentKey, Dictionary<int, int> keyValueMap)
		{
			List<KeyValuePair<int, int>> list = keyValueMap.ToList<KeyValuePair<int, int>>();
			for (int i = 0; i < list.Count; i++)
			{
				int key = list[i].Key;
				int value = list[i].Value;
				if (i >= list.Count - 1)
				{
					return value;
				}
				int key2 = list[i + 1].Key;
				if (key <= currentKey && currentKey < key2)
				{
					return value;
				}
			}
			return 0;
		}

		// Token: 0x06044A57 RID: 281175 RVA: 0x011D7A68 File Offset: 0x011D5C68
		public void SetTempGetDataListFromServer(List<FishingItemInfo> dataList, EFishingQteGetItemTagType tagType)
		{
			foreach (FishingItemInfo fishingItemInfo in dataList)
			{
				DockyardItemBlockOriginalData dockyardItemBlockOriginalData = new DockyardItemBlockOriginalData(fishingItemInfo);
				this.TempGetDataMap[fishingItemInfo.IncrId] = dockyardItemBlockOriginalData;
				this.TempGetDataTagMap[fishingItemInfo.IncrId] = tagType;
				this.TempGetDataList.Add(dockyardItemBlockOriginalData);
			}
		}

		// Token: 0x06044A58 RID: 281176 RVA: 0x011D7AE8 File Offset: 0x011D5CE8
		public List<DockyardItemBlockOriginalData> GetTempGetDataList()
		{
			List<DockyardItemBlockOriginalData> result = this.TempGetDataMap.Values.ToList<DockyardItemBlockOriginalData>();
			this.TempGetDataMap.Clear();
			this.TempGetDataTagMap.Clear();
			this.TempGetDataList.Clear();
			return result;
		}

		// Token: 0x06044A59 RID: 281177 RVA: 0x011D7B1B File Offset: 0x011D5D1B
		[NullableContext(2)]
		public DockyardItemBlockOriginalData ShiftTempGetData()
		{
			if (this.TempGetDataList.Count == 0)
			{
				return null;
			}
			DockyardItemBlockOriginalData result = this.TempGetDataList[0];
			this.TempGetDataList.RemoveAt(0);
			return result;
		}

		// Token: 0x06044A5A RID: 281178 RVA: 0x011D7B44 File Offset: 0x011D5D44
		public bool IsTempGetDataEmpty()
		{
			return this.TempGetDataList.Count == 0;
		}

		// Token: 0x06044A5B RID: 281179 RVA: 0x011D7B54 File Offset: 0x011D5D54
		public EFishingQteGetItemTagType GetTempGetDataTag(int incId)
		{
			EFishingQteGetItemTagType result;
			if (this.TempGetDataTagMap.TryGetValue(incId, out result))
			{
				return result;
			}
			return EFishingQteGetItemTagType.None;
		}

		// Token: 0x0402636A RID: 156522
		private const float PERCENT_CONVERT = 0.01f;

		// Token: 0x0402636B RID: 156523
		private int CurrentGameplayId;

		// Token: 0x0402636C RID: 156524
		public int CurrentFishingPointConfigId;

		// Token: 0x0402636D RID: 156525
		public long CurrentFishingPointCreatureDataId;

		// Token: 0x0402636E RID: 156526
		public EFishingPointType CurrentInteractType;

		// Token: 0x0402636F RID: 156527
		public FishingQteGameInfo GameInfo;

		// Token: 0x04026370 RID: 156528
		private FishingQteConfig? GameDbConfig;

		// Token: 0x04026371 RID: 156529
		[Nullable(2)]
		private FishingQteConfigDbProxy GameDbConfigProxy;

		// Token: 0x04026372 RID: 156530
		[Nullable(2)]
		private IFishingQteConfig GameJsonConfig;

		// Token: 0x04026373 RID: 156531
		public EFishingIconType CurrentFishingIconType;

		// Token: 0x04026374 RID: 156532
		private float FishingQteOnFactor = 1f;

		// Token: 0x04026375 RID: 156533
		private float FishingQteAutoFactor = 1f;

		// Token: 0x04026376 RID: 156534
		private int AccumulatePerfectComboInternal;

		// Token: 0x04026377 RID: 156535
		private Dictionary<int, DockyardItemBlockOriginalData> TempGetDataMap = new Dictionary<int, DockyardItemBlockOriginalData>();

		// Token: 0x04026378 RID: 156536
		private Dictionary<int, EFishingQteGetItemTagType> TempGetDataTagMap = new Dictionary<int, EFishingQteGetItemTagType>();

		// Token: 0x04026379 RID: 156537
		private List<DockyardItemBlockOriginalData> TempGetDataList = new List<DockyardItemBlockOriginalData>();
	}
}
