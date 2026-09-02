using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006195 RID: 24981
	[NullableContext(1)]
	[Nullable(0)]
	public class SoundAreaDetectionRecord
	{
		// Token: 0x0603F1A4 RID: 258468 RVA: 0x0102EACC File Offset: 0x0102CCCC
		[NullableContext(2)]
		public SoundAreaDetectionRecord(ESoundAreaDataType type, DungeonDetectionRecord dungeonDetectionRecord = null, SilentAreaDetectionRecord silentAreaDetectionRecord = null)
		{
			this.Type = new ESoundAreaDataType?(type);
			this.DungeonDetectionRecord = dungeonDetectionRecord;
			this.SilentAreaDetectionRecord = silentAreaDetectionRecord;
		}

		// Token: 0x17009B11 RID: 39697
		// (get) Token: 0x0603F1A5 RID: 258469 RVA: 0x0102EAF0 File Offset: 0x0102CCF0
		[Nullable(0)]
		public OneOf<DungeonDetection, SilentAreaDetection>? Conf
		{
			[NullableContext(0)]
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							SilentAreaDetection? silentAreaDetection = (silentAreaDetectionRecord != null) ? new SilentAreaDetection?(silentAreaDetectionRecord.Conf) : null;
							if (silentAreaDetection == null)
							{
								return null;
							}
							return new OneOf<DungeonDetection, SilentAreaDetection>?(silentAreaDetection.GetValueOrDefault());
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						DungeonDetection? dungeonDetection = (dungeonDetectionRecord != null) ? new DungeonDetection?(dungeonDetectionRecord.Conf) : null;
						if (dungeonDetection == null)
						{
							return null;
						}
						return new OneOf<DungeonDetection, SilentAreaDetection>?(dungeonDetection.GetValueOrDefault());
					}
				}
				return null;
			}
		}

		// Token: 0x17009B12 RID: 39698
		// (get) Token: 0x0603F1A6 RID: 258470 RVA: 0x0102EBBC File Offset: 0x0102CDBC
		public string Name
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.Name : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.Name : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B13 RID: 39699
		// (get) Token: 0x0603F1A7 RID: 258471 RVA: 0x0102EC38 File Offset: 0x0102CE38
		public string BigIcon
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.BigIcon : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.BigIcon : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B14 RID: 39700
		// (get) Token: 0x0603F1A8 RID: 258472 RVA: 0x0102ECB4 File Offset: 0x0102CEB4
		public string LockBigIcon
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.LockBigIcon : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.LockBigIcon : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B15 RID: 39701
		// (get) Token: 0x0603F1A9 RID: 258473 RVA: 0x0102ED30 File Offset: 0x0102CF30
		public string AttributesDescriptionUnlock
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.AttributesDescriptionUnlock : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.AttributesDescriptionUnlock : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B16 RID: 39702
		// (get) Token: 0x0603F1AA RID: 258474 RVA: 0x0102EDAC File Offset: 0x0102CFAC
		public string InstanceSubTypeDescription
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.InstanceSubTypeDescription : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.InstanceSubTypeDescription : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B17 RID: 39703
		// (get) Token: 0x0603F1AB RID: 258475 RVA: 0x0102EE28 File Offset: 0x0102D028
		public string LeftBgSprite
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.LeftBgSprite : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.LeftBgSprite : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B18 RID: 39704
		// (get) Token: 0x0603F1AC RID: 258476 RVA: 0x0102EEA4 File Offset: 0x0102D0A4
		public string RightBgSprite
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.RightBgSprite : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.RightBgSprite : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B19 RID: 39705
		// (get) Token: 0x0603F1AD RID: 258477 RVA: 0x0102EF20 File Offset: 0x0102D120
		public string LeftBgTexture
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.LeftBgTexture : null) ?? "";
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.LeftBgTexture : null) ?? "";
					}
				}
				return "";
			}
		}

		// Token: 0x17009B1A RID: 39706
		// (get) Token: 0x0603F1AE RID: 258478 RVA: 0x0102EF9C File Offset: 0x0102D19C
		public int DetectionTitlePanel
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return 0;
							}
							return silentAreaDetectionRecord.Conf.DetectionTitlePanel;
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return 0;
						}
						return dungeonDetectionRecord.Conf.DetectionTitlePanel;
					}
				}
				return 0;
			}
		}

		// Token: 0x17009B1B RID: 39707
		// (get) Token: 0x0603F1AF RID: 258479 RVA: 0x0102F000 File Offset: 0x0102D200
		public int[] PhantomId
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.PhantomId() : null) ?? Array.Empty<int>();
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.PhantomId() : null) ?? Array.Empty<int>();
					}
				}
				return Array.Empty<int>();
			}
		}

		// Token: 0x17009B1C RID: 39708
		// (get) Token: 0x0603F1B0 RID: 258480 RVA: 0x0102F07C File Offset: 0x0102D27C
		public int LockCon
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return 0;
							}
							return silentAreaDetectionRecord.Conf.LockCon;
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return 0;
						}
						return dungeonDetectionRecord.Conf.LockCon;
					}
				}
				return 0;
			}
		}

		// Token: 0x17009B1D RID: 39709
		// (get) Token: 0x0603F1B1 RID: 258481 RVA: 0x0102F0E0 File Offset: 0x0102D2E0
		public int PeriodicityChallengeType
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return 0;
							}
							return silentAreaDetectionRecord.Conf.PeriodicityChallengeType;
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return 0;
						}
						return dungeonDetectionRecord.Conf.PeriodicityChallengeType;
					}
				}
				return 0;
			}
		}

		// Token: 0x17009B1E RID: 39710
		// (get) Token: 0x0603F1B2 RID: 258482 RVA: 0x0102F144 File Offset: 0x0102D344
		public int Secondary
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return 0;
							}
							return silentAreaDetectionRecord.Conf.Secondary;
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return 0;
						}
						return dungeonDetectionRecord.Conf.Secondary;
					}
				}
				return 0;
			}
		}

		// Token: 0x17009B1F RID: 39711
		// (get) Token: 0x0603F1B3 RID: 258483 RVA: 0x0102F1A8 File Offset: 0x0102D3A8
		public bool? IsLock
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return null;
							}
							return new bool?(silentAreaDetectionRecord.IsLock);
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return null;
						}
						return new bool?(dungeonDetectionRecord.IsLock);
					}
				}
				return new bool?(false);
			}
		}

		// Token: 0x17009B20 RID: 39712
		// (get) Token: 0x0603F1B4 RID: 258484 RVA: 0x0102F21C File Offset: 0x0102D41C
		public int Id
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return 0;
							}
							return silentAreaDetectionRecord.Conf.Id;
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return 0;
						}
						return dungeonDetectionRecord.Conf.Id;
					}
				}
				return 0;
			}
		}

		// Token: 0x17009B21 RID: 39713
		// (get) Token: 0x0603F1B5 RID: 258485 RVA: 0x0102F280 File Offset: 0x0102D480
		public int PreOpenId
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return 0;
							}
							return silentAreaDetectionRecord.Conf.PreOpenId;
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return 0;
						}
						return dungeonDetectionRecord.Conf.PreOpenId;
					}
				}
				return 0;
			}
		}

		// Token: 0x17009B22 RID: 39714
		// (get) Token: 0x0603F1B6 RID: 258486 RVA: 0x0102F2E4 File Offset: 0x0102D4E4
		public int SortId
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != ESoundAreaDataType.Dungeon)
					{
						if (valueOrDefault == ESoundAreaDataType.SilentArea)
						{
							SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
							if (silentAreaDetectionRecord == null)
							{
								return 0;
							}
							return silentAreaDetectionRecord.Conf.SortId;
						}
					}
					else
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						if (dungeonDetectionRecord == null)
						{
							return 0;
						}
						return dungeonDetectionRecord.Conf.SortId;
					}
				}
				return 0;
			}
		}

		// Token: 0x17009B23 RID: 39715
		// (get) Token: 0x0603F1B7 RID: 258487 RVA: 0x0102F348 File Offset: 0x0102D548
		public Dictionary<int, int> ShowRewardMap
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.ShowRewardMap() : null) ?? new Dictionary<int, int>();
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.ShowRewardMap() : null) ?? new Dictionary<int, int>();
					}
				}
				return new Dictionary<int, int>();
			}
		}

		// Token: 0x17009B24 RID: 39716
		// (get) Token: 0x0603F1B8 RID: 258488 RVA: 0x0102F3C4 File Offset: 0x0102D5C4
		public Dictionary<int, int> ShowRewardMapCalabash
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.ShowRewardMapCalabash() : null) ?? new Dictionary<int, int>();
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.ShowRewardMapCalabash() : null) ?? new Dictionary<int, int>();
					}
				}
				return new Dictionary<int, int>();
			}
		}

		// Token: 0x17009B25 RID: 39717
		// (get) Token: 0x0603F1B9 RID: 258489 RVA: 0x0102F440 File Offset: 0x0102D640
		public int[] PhantomFetterGroup
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.PhantomFetterGroup() : null) ?? Array.Empty<int>();
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.PhantomFetterGroup() : null) ?? Array.Empty<int>();
					}
				}
				return Array.Empty<int>();
			}
		}

		// Token: 0x17009B26 RID: 39718
		// (get) Token: 0x0603F1BA RID: 258490 RVA: 0x0102F4BC File Offset: 0x0102D6BC
		public int[] WeaponFetterGroup
		{
			get
			{
				ESoundAreaDataType? type = this.Type;
				if (type != null)
				{
					ESoundAreaDataType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault == ESoundAreaDataType.Dungeon)
					{
						DungeonDetectionRecord dungeonDetectionRecord = this.DungeonDetectionRecord;
						return ((dungeonDetectionRecord != null) ? dungeonDetectionRecord.Conf.WeaponFetterGroup() : null) ?? Array.Empty<int>();
					}
					if (valueOrDefault == ESoundAreaDataType.SilentArea)
					{
						SilentAreaDetectionRecord silentAreaDetectionRecord = this.SilentAreaDetectionRecord;
						return ((silentAreaDetectionRecord != null) ? silentAreaDetectionRecord.Conf.WeaponFetterGroup() : null) ?? Array.Empty<int>();
					}
				}
				return Array.Empty<int>();
			}
		}

		// Token: 0x0603F1BB RID: 258491 RVA: 0x0102F537 File Offset: 0x0102D737
		public int GetTargetTowerDifficulty()
		{
			return AdventureDefine.periodicityChallengeTypeToTarget[(EPeriodicityChallengeType)this.PeriodicityChallengeType];
		}

		// Token: 0x0603F1BC RID: 258492 RVA: 0x0102F54C File Offset: 0x0102D74C
		public bool GetTargetTowerIsUnlock()
		{
			int targetTowerDifficulty = this.GetTargetTowerDifficulty();
			return targetTowerDifficulty > 0 && (targetTowerDifficulty - 1 <= 0 || ModelBase<TowerModel>.Instance.GetDifficultyIsClear(targetTowerDifficulty - 1));
		}

		// Token: 0x04023685 RID: 145029
		public ESoundAreaDataType? Type;

		// Token: 0x04023686 RID: 145030
		[Nullable(2)]
		public DungeonDetectionRecord DungeonDetectionRecord;

		// Token: 0x04023687 RID: 145031
		[Nullable(2)]
		public SilentAreaDetectionRecord SilentAreaDetectionRecord;
	}
}
