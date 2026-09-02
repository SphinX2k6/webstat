using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F5D RID: 28509
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class BigStuffedDollModel : ModelBase<BigStuffedDollModel>
	{
		// Token: 0x1700A49C RID: 42140
		// (get) Token: 0x06044FFE RID: 282622 RVA: 0x011F5650 File Offset: 0x011F3850
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public OneOf<BrokenRockConfig, BrokenRockConfig> Config
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				if (!Singleton<PublicUtil>.Instance.UseDbConfig())
				{
					if (this.GameJsonConfig == null)
					{
						return default(OneOf<BrokenRockConfig, BrokenRockConfig>);
					}
					return this.GameJsonConfig;
				}
				else
				{
					if (this.GameDbConfig == null)
					{
						return default(OneOf<BrokenRockConfig, BrokenRockConfig>);
					}
					return this.GameDbConfig.Value;
				}
			}
		}

		// Token: 0x06044FFF RID: 282623 RVA: 0x011F56B0 File Offset: 0x011F38B0
		public void GameplayStart(int id, int treeConfigId)
		{
			this.CurrentGameplayId = id;
			this.BehaviorTreeConfigId = treeConfigId;
			this.SetGameStage(EGameStage.None);
			this.GameInfo.Clear();
			this.CurrentScore = 0f;
			this.CurrentArrowDirection = EArrowDirection.Clockwise;
			this.InitialConfig();
			if (!this.Config.HasValue)
			{
				return;
			}
			string[] array;
			if (this.Config.IsT1)
			{
				array = this.Config.AsT1.EntityUid.Split('_', StringSplitOptions.None);
			}
			else
			{
				array = this.Config.AsT2.EntityUid.Split('_', StringSplitOptions.None);
			}
			int.TryParse(array[2], out this.BrokenRockEntityPbDataId);
		}

		// Token: 0x06045000 RID: 282624 RVA: 0x011F5764 File Offset: 0x011F3964
		public void InitialConfig()
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				this.GameDbConfig = ConfigBrokenRockConfigById.GetConfig(this.CurrentGameplayId, true);
				return;
			}
			string text = "../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/BrokenRockConfig.json";
			if (string.IsNullOrEmpty(text))
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.YSQ, "大个布偶坚固岩石玩法找不到Json数据配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			string configPath = Singleton<PublicUtil>.Instance.GetConfigPath(text);
			string text2 = "";
			UKuroStaticLibrary.LoadFileToString(ref text2, configPath);
			BrokenRockJsonConfig brokenRockJsonConfig = Json.Decode<BrokenRockJsonConfig>(text2, null);
			if (brokenRockJsonConfig != null)
			{
				this.GameJsonConfig = null;
				foreach (BrokenRockConfig brokenRockConfig in brokenRockJsonConfig.Config)
				{
					if (brokenRockConfig.Id == this.CurrentGameplayId)
					{
						this.GameJsonConfig = brokenRockConfig;
						break;
					}
				}
				if (this.GameJsonConfig != null)
				{
					this.GameJsonRingConfig = new Dictionary<int, BrokenRockRingConfig>();
					foreach (int num in this.GameJsonConfig.Rings)
					{
						BrokenRockRingConfig brokenRockRingConfig = null;
						foreach (BrokenRockRingConfig brokenRockRingConfig2 in brokenRockJsonConfig.Rings)
						{
							if (brokenRockRingConfig2.Id == num)
							{
								brokenRockRingConfig = brokenRockRingConfig2;
								break;
							}
						}
						if (brokenRockRingConfig != null)
						{
							this.GameJsonRingConfig[num] = brokenRockRingConfig;
						}
					}
				}
			}
		}

		// Token: 0x06045001 RID: 282625 RVA: 0x011F58AC File Offset: 0x011F3AAC
		private Dictionary<int, int> StringToMapValue(string stringValue)
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

		// Token: 0x06045002 RID: 282626 RVA: 0x011F5918 File Offset: 0x011F3B18
		public int GetCurrentGameplayId()
		{
			return this.CurrentGameplayId;
		}

		// Token: 0x06045003 RID: 282627 RVA: 0x011F5920 File Offset: 0x011F3B20
		public void SetGameStage(EGameStage stage)
		{
			this.LastGameStage = this.GameStage;
			this.GameStage = stage;
			Singleton<EventSystem>.Instance.Emit<EGameStage>(EEventName.OnBigStuffedDollGameStageUpdate, this.GameStage);
		}

		// Token: 0x06045004 RID: 282628 RVA: 0x011F594B File Offset: 0x011F3B4B
		public EGameStage GetGameStage()
		{
			return this.GameStage;
		}

		// Token: 0x06045005 RID: 282629 RVA: 0x011F5954 File Offset: 0x011F3B54
		public void EnterNextGameStage()
		{
			this.LastGameStage = this.GameStage;
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnBigStuffedDollGameStageUpdate;
			EGameStage egameStage = this.GameStage + 1;
			this.GameStage = egameStage;
			instance.Emit<EGameStage>(name, egameStage);
		}

		// Token: 0x06045006 RID: 282630 RVA: 0x011F5990 File Offset: 0x011F3B90
		public void ArrowEnterNextValidArea()
		{
			int validAreaNum = this.GameInfo.GetValidAreaNum();
			if (validAreaNum == 0)
			{
				return;
			}
			int currentArrowStayTotalIndex = this.GameInfo.CurrentArrowStayTotalIndex;
			EArrowDirection currentArrowDirection = this.CurrentArrowDirection;
			if (currentArrowDirection != EArrowDirection.Clockwise)
			{
				if (currentArrowDirection == EArrowDirection.Anticlockwise)
				{
					this.GameInfo.CurrentArrowStayTotalIndex--;
				}
			}
			else
			{
				this.GameInfo.CurrentArrowStayTotalIndex++;
			}
			if (this.GameInfo.CurrentArrowStayTotalIndex > validAreaNum - 1)
			{
				this.GameInfo.CurrentArrowStayTotalIndex = 0;
			}
			else if (this.GameInfo.CurrentArrowStayTotalIndex < 0)
			{
				this.GameInfo.CurrentArrowStayTotalIndex = validAreaNum - 1;
			}
			if (currentArrowStayTotalIndex == this.GameInfo.CurrentArrowStayTotalIndex)
			{
				return;
			}
			int currentArrowStayRingId = this.GameInfo.CurrentArrowStayRingId;
			this.GameInfo.UpdateCurrentArrowStayInfo();
			Singleton<EventSystem>.Instance.Emit<int, int, int>(EEventName.OnBigStuffedDollArrowStayAreaUpdate, currentArrowStayRingId, this.GameInfo.CurrentArrowStayRingId, this.GameInfo.CurrentArrowStayRelativeValidAreaIndex);
		}

		// Token: 0x06045007 RID: 282631 RVA: 0x011F5A78 File Offset: 0x011F3C78
		public int GetGlobalTime()
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				if (this.GameDbConfig == null)
				{
					return 0;
				}
				return this.GameDbConfig.GetValueOrDefault().GlobalTime;
			}
			else
			{
				BrokenRockConfig gameJsonConfig = this.GameJsonConfig;
				if (gameJsonConfig == null)
				{
					return 0;
				}
				return gameJsonConfig.GlobalTime;
			}
		}

		// Token: 0x06045008 RID: 282632 RVA: 0x011F5AC4 File Offset: 0x011F3CC4
		public int GetScoreDown()
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				if (this.GameDbConfig == null)
				{
					return 0;
				}
				return this.GameDbConfig.GetValueOrDefault().ScoreDown;
			}
			else
			{
				BrokenRockConfig gameJsonConfig = this.GameJsonConfig;
				if (gameJsonConfig == null)
				{
					return 0;
				}
				return gameJsonConfig.ScoreDown;
			}
		}

		// Token: 0x06045009 RID: 282633 RVA: 0x011F5B10 File Offset: 0x011F3D10
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public OneOf<BrokenRockRing, BrokenRockRingConfig> GetRingConfig(int ringId)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				BrokenRockRing? config = ConfigBrokenRockRingById.GetConfig(ringId, true);
				if (config == null)
				{
					return default(OneOf<BrokenRockRing, BrokenRockRingConfig>);
				}
				return config.Value;
			}
			else
			{
				BrokenRockRingConfig value;
				if (this.GameJsonRingConfig != null && this.GameJsonRingConfig.TryGetValue(ringId, out value))
				{
					return value;
				}
				return default(OneOf<BrokenRockRing, BrokenRockRingConfig>);
			}
		}

		// Token: 0x0604500A RID: 282634 RVA: 0x011F5B7C File Offset: 0x011F3D7C
		public int GetArrowSpeed([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<BrokenRockRing, BrokenRockRingConfig>? ringConfig)
		{
			int result = 0;
			if (ringConfig == null)
			{
				return result;
			}
			float currentScore = this.CurrentScore;
			if (ringConfig.Value.IsT1)
			{
				BrokenRockRing asT = ringConfig.Value.AsT1;
				for (int i = 0; i < asT.SpeedLength; i++)
				{
					DicIntInt? dicIntInt = asT.Speed(i);
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					if (currentScore < (float)key)
					{
						break;
					}
					result = value;
				}
			}
			else
			{
				foreach (KeyValuePair<int, int> keyValuePair in ringConfig.Value.AsT2.Speed)
				{
					int key2 = keyValuePair.Key;
					int value2 = keyValuePair.Value;
					if (currentScore < (float)key2)
					{
						break;
					}
					result = value2;
				}
			}
			return result;
		}

		// Token: 0x0604500B RID: 282635 RVA: 0x011F5C7C File Offset: 0x011F3E7C
		public void ArrowDirectionReverse()
		{
			EArrowDirection currentArrowDirection = this.CurrentArrowDirection;
			if (currentArrowDirection != EArrowDirection.Clockwise)
			{
				if (currentArrowDirection == EArrowDirection.Anticlockwise)
				{
					this.CurrentArrowDirection = EArrowDirection.Clockwise;
				}
			}
			else
			{
				this.CurrentArrowDirection = EArrowDirection.Anticlockwise;
			}
			this.GameInfo.OnArrowDirectionReverse();
		}

		// Token: 0x040267B3 RID: 157619
		private int CurrentGameplayId;

		// Token: 0x040267B4 RID: 157620
		public int BehaviorTreeConfigId;

		// Token: 0x040267B5 RID: 157621
		public int BrokenRockEntityPbDataId;

		// Token: 0x040267B6 RID: 157622
		public long BrokenRockEntityCreatureDataId;

		// Token: 0x040267B7 RID: 157623
		private BrokenRockConfig? GameDbConfig;

		// Token: 0x040267B8 RID: 157624
		[Nullable(2)]
		private BrokenRockConfig GameJsonConfig;

		// Token: 0x040267B9 RID: 157625
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, BrokenRockRingConfig> GameJsonRingConfig;

		// Token: 0x040267BA RID: 157626
		public readonly BigStuffedGameInfo GameInfo = new BigStuffedGameInfo();

		// Token: 0x040267BB RID: 157627
		private EGameStage GameStage;

		// Token: 0x040267BC RID: 157628
		public bool GameResult;

		// Token: 0x040267BD RID: 157629
		public float CurrentScore;

		// Token: 0x040267BE RID: 157630
		public EArrowDirection CurrentArrowDirection;

		// Token: 0x040267BF RID: 157631
		public EGameStage LastGameStage;
	}
}
