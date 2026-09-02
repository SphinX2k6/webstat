using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.Reward
{
	// Token: 0x02005282 RID: 21122
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class RewardConfig : ConfigBase<RewardConfig>
	{
		// Token: 0x0603604C RID: 221260 RVA: 0x00D9863B File Offset: 0x00D9683B
		public DropPackage? GetDropPackage(int id)
		{
			return ConfigDropPackageById.GetConfig(id, true);
		}

		// Token: 0x0603604D RID: 221261 RVA: 0x00D98644 File Offset: 0x00D96844
		[NullableContext(2)]
		public Dictionary<int, int> GetDropPackagePreview(int id)
		{
			DropPackage? config = ConfigDropPackageById.GetConfig(id, true);
			if (config == null)
			{
				return null;
			}
			return config.Value.DropPreview();
		}

		// Token: 0x0603604E RID: 221262 RVA: 0x00D98674 File Offset: 0x00D96874
		public List<TItem> GetDropPackagePreviewItemList(int id)
		{
			List<TItem> list = new List<TItem>();
			DropPackage? config = ConfigDropPackageById.GetConfig(id, true);
			if (config == null)
			{
				return list;
			}
			foreach (DicIntInt dicIntInt in config.Value.DropPreviewIter())
			{
				int key = dicIntInt.Key;
				int value = dicIntInt.Value;
				list.Add(new TItem(new InventoryDefine.GetItemData(key, 0), value));
			}
			return list;
		}

		// Token: 0x0603604F RID: 221263 RVA: 0x00D98708 File Offset: 0x00D96908
		public List<TItem> GetDropPackagePreviewItemListByIdList(IReadOnlyList<int> idList)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (int id in idList)
			{
				foreach (TItem titem in this.GetDropPackagePreviewItemList(id))
				{
					int itemId = titem.ItemData.ItemId;
					int count = titem.Count;
					if (!dictionary.TryAdd(itemId, count))
					{
						Dictionary<int, int> dictionary2 = dictionary;
						int key = itemId;
						dictionary2[key] += count;
					}
				}
			}
			CSharpScript.Game.Module.Item.ItemConfig itemConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance;
			List<TItem> list = (from kvp in dictionary
			select new TItem
			{
				ItemData = new InventoryDefine.GetItemData(kvp.Key, 0),
				Count = kvp.Value
			}).ToList<TItem>();
			list.Sort(delegate(TItem a, TItem b)
			{
				ItemInfo? config = itemConfig.GetConfig(a.ItemData.ItemId);
				ItemInfo? config2 = itemConfig.GetConfig(b.ItemData.ItemId);
				if (config != null && config2 != null && config.Value.QualityId != config2.Value.QualityId)
				{
					return config2.Value.QualityId - config.Value.QualityId;
				}
				return a.ItemData.ItemId - b.ItemData.ItemId;
			});
			return list;
		}

		// Token: 0x06036050 RID: 221264 RVA: 0x00D98814 File Offset: 0x00D96A14
		public DropShowPlan? GetDropShowPlan(int id)
		{
			return ConfigDropShowPlanById.GetConfig(id, true);
		}

		// Token: 0x06036051 RID: 221265 RVA: 0x00D98820 File Offset: 0x00D96A20
		public int GetSpeed()
		{
			if (this.AdsorptionSpeed == null)
			{
				this.AdsorptionSpeed = new int?(ConfigCommonParamById.GetIntConfig("adsorption_speed").Value);
			}
			return this.AdsorptionSpeed.Value;
		}

		// Token: 0x06036052 RID: 221266 RVA: 0x00D98864 File Offset: 0x00D96A64
		public int GetMaxAdsorption()
		{
			if (this.AdsorptionMaxTime == null)
			{
				this.AdsorptionMaxTime = new int?(ConfigCommonParamById.GetIntConfig("adsorption_time").Value);
			}
			return this.AdsorptionMaxTime.Value;
		}

		// Token: 0x06036053 RID: 221267 RVA: 0x00D988A8 File Offset: 0x00D96AA8
		public int GetHeightProtect()
		{
			if (this.DropHeightProtect == null)
			{
				this.DropHeightProtect = new int?(ConfigCommonParamById.GetIntConfig("drop_height_protect").Value);
			}
			return this.DropHeightProtect.Value;
		}

		// Token: 0x06036054 RID: 221268 RVA: 0x00D988EC File Offset: 0x00D96AEC
		public float GetRestitution()
		{
			if (this.DropBounceCoefficient == null)
			{
				this.DropBounceCoefficient = new float?(ConfigCommonParamById.GetFloatConfig("drop_bounce_coefficient").Value);
			}
			return this.DropBounceCoefficient.Value;
		}

		// Token: 0x06036055 RID: 221269 RVA: 0x00D98930 File Offset: 0x00D96B30
		public float GetFriction()
		{
			if (this.DropFriction == null)
			{
				this.DropFriction = new float?(ConfigCommonParamById.GetFloatConfig("drop_friction").Value);
			}
			return this.DropFriction.Value;
		}

		// Token: 0x06036056 RID: 221270 RVA: 0x00D98974 File Offset: 0x00D96B74
		public int GetDropItemPickUpRange()
		{
			if (this.DropPickUpRange == null)
			{
				this.DropPickUpRange = new int?(ConfigCommonParamById.GetIntConfig("drop_item_pickup_range").Value);
			}
			return this.DropPickUpRange.Value;
		}

		// Token: 0x06036057 RID: 221271 RVA: 0x00D989B8 File Offset: 0x00D96BB8
		public int GetPickUpInBagRange()
		{
			if (this.DropPickUpInBagRange == null)
			{
				this.DropPickUpInBagRange = new int?(ConfigCommonParamById.GetIntConfig("drop_pickup_in_bag_range").Value);
			}
			return this.DropPickUpInBagRange.Value;
		}

		// Token: 0x06036058 RID: 221272 RVA: 0x00D989FC File Offset: 0x00D96BFC
		public int GetDropItemAcceleration()
		{
			if (this.AdsorptionAcceleration == null)
			{
				this.AdsorptionAcceleration = new int?(ConfigCommonParamById.GetIntConfig("adsorption_acceleration").Value);
			}
			return this.AdsorptionAcceleration.Value;
		}

		// Token: 0x06036059 RID: 221273 RVA: 0x00D98A40 File Offset: 0x00D96C40
		public int GetFallToGroundSpeed()
		{
			if (this.FallToGroundSpeed == null)
			{
				this.FallToGroundSpeed = new int?(ConfigCommonParamById.GetIntConfig("drop_fall_ground_speed").Value);
			}
			return this.FallToGroundSpeed.Value;
		}

		// Token: 0x0603605A RID: 221274 RVA: 0x00D98A84 File Offset: 0x00D96C84
		public int GetDropChestOffsetZ()
		{
			if (this.DropChestOffsetZ == null)
			{
				this.DropChestOffsetZ = new int?(ConfigCommonParamById.GetIntConfig("drop_chest_zaxis_offset").Value);
			}
			return this.DropChestOffsetZ.Value;
		}

		// Token: 0x0603605B RID: 221275 RVA: 0x00D98AC8 File Offset: 0x00D96CC8
		public int GetDropBornRadius()
		{
			if (this.DropBornRadius == null)
			{
				this.DropBornRadius = new int?(ConfigCommonParamById.GetIntConfig("drop_born_radius").Value);
			}
			return this.DropBornRadius.Value;
		}

		// Token: 0x0603605C RID: 221276 RVA: 0x00D98B0C File Offset: 0x00D96D0C
		public int GetDropRotationProtectTime()
		{
			if (this.DropRotationProtectTime == null)
			{
				this.DropRotationProtectTime = new int?(ConfigCommonParamById.GetIntConfig("drop_lock_rotation_time").Value);
			}
			return this.DropRotationProtectTime.Value;
		}

		// Token: 0x0603605D RID: 221277 RVA: 0x00D98B50 File Offset: 0x00D96D50
		public List<TItem> GetMergedDropPackagePreviewItemList(int[] dropPackageIdList)
		{
			List<TItem> list = new List<TItem>();
			if (dropPackageIdList == null)
			{
				return list;
			}
			foreach (int id in dropPackageIdList)
			{
				DropPackage? dropPackage;
				IEnumerable<DicIntInt> enumerable = (this.GetDropPackage(id) != null) ? dropPackage.GetValueOrDefault().DropPreviewIter() : null;
				if (enumerable != null)
				{
					foreach (DicIntInt dicIntInt in enumerable)
					{
						TItem item = new TItem(new InventoryDefine.GetItemData(dicIntInt.Key, 0), dicIntInt.Value);
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x0603605E RID: 221278 RVA: 0x00D98C0C File Offset: 0x00D96E0C
		public int GetLowModeCount()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("into_bag_list_low_count");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "慢速模式最大数量无法找到, 请检测c.参数字段\"into_bag_list_low_count\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 1;
			}
			return intConfig.Value;
		}

		// Token: 0x0603605F RID: 221279 RVA: 0x00D98C64 File Offset: 0x00D96E64
		public int GetFastModeCount()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("into_bag_list_fast_count");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "快速模式最大数量无法找到, 请检测c.参数字段\"into_bag_list_fast_count\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 1;
			}
			return intConfig.Value;
		}

		// Token: 0x06036060 RID: 221280 RVA: 0x00D98CBC File Offset: 0x00D96EBC
		public int GetLowModeNextAddItemTime()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("into_bag_next_item_low_time");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "慢速模式下一个物品进包时间无法找到, 请检测c.参数字段\"into_bag_next_item_low_time\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 1;
			}
			return intConfig.Value;
		}

		// Token: 0x06036061 RID: 221281 RVA: 0x00D98D14 File Offset: 0x00D96F14
		public int GetFastModeNextAddItemTime()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("into_bag_next_item_fast_time");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "快速模式下一个物品进包时间无法找到, 请检测c.参数字段\"into_bag_next_item_fast_time\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 1;
			}
			return intConfig.Value;
		}

		// Token: 0x06036062 RID: 221282 RVA: 0x00D98D6C File Offset: 0x00D96F6C
		public int GetIntoBagMaxCount()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("item_list_max_size");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "外入包列表最大数量无法找到, 请检测c.参数字段\"item_list_max_size\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 1;
			}
			return intConfig.Value;
		}

		// Token: 0x06036063 RID: 221283 RVA: 0x00D98DC4 File Offset: 0x00D96FC4
		public int GetShowTime()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("into_bag_show_time");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "入包每个物品的显示时间无法找到, 请检测c.参数字段\"into_bag_show_time\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 3000;
			}
			return intConfig.Value;
		}

		// Token: 0x06036064 RID: 221284 RVA: 0x00D98E20 File Offset: 0x00D97020
		public int GetNextItemTime()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("into_bag_next_item_time");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "下一个物品添加进来的时间无法找到, 请检测c.参数字段\"into_bag_next_item_time\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 300;
			}
			return intConfig.Value;
		}

		// Token: 0x06036065 RID: 221285 RVA: 0x00D98E7C File Offset: 0x00D9707C
		public int GetSliderTime()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("into_bag_slide_time");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "上滑时间无法找到, 请检测c.参数字段\"into_bag_slide_time\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (intConfig == null || intConfig.Value < 0)
			{
				return 200;
			}
			return intConfig.Value;
		}

		// Token: 0x06036066 RID: 221286 RVA: 0x00D98ED8 File Offset: 0x00D970D8
		protected override bool OnClear()
		{
			this.AdsorptionSpeed = null;
			this.AdsorptionMaxTime = null;
			this.DropHeightProtect = null;
			this.DropBounceCoefficient = null;
			this.DropFriction = null;
			this.DropPickUpRange = null;
			this.DropPickUpInBagRange = null;
			this.AdsorptionAcceleration = null;
			this.FallToGroundSpeed = null;
			this.DropChestOffsetZ = null;
			this.DropBornRadius = null;
			this.DropRotationProtectTime = null;
			return true;
		}

		// Token: 0x0401F0C5 RID: 127173
		private int? AdsorptionSpeed;

		// Token: 0x0401F0C6 RID: 127174
		private int? AdsorptionMaxTime;

		// Token: 0x0401F0C7 RID: 127175
		private int? DropHeightProtect;

		// Token: 0x0401F0C8 RID: 127176
		private float? DropBounceCoefficient;

		// Token: 0x0401F0C9 RID: 127177
		private float? DropFriction;

		// Token: 0x0401F0CA RID: 127178
		private int? DropPickUpRange;

		// Token: 0x0401F0CB RID: 127179
		private int? DropPickUpInBagRange;

		// Token: 0x0401F0CC RID: 127180
		private int? AdsorptionAcceleration;

		// Token: 0x0401F0CD RID: 127181
		private int? FallToGroundSpeed;

		// Token: 0x0401F0CE RID: 127182
		private int? DropChestOffsetZ;

		// Token: 0x0401F0CF RID: 127183
		private int? DropBornRadius;

		// Token: 0x0401F0D0 RID: 127184
		private int? DropRotationProtectTime;
	}
}
