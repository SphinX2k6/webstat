using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B42 RID: 23362
	public class RewardItemData
	{
		// Token: 0x0603B178 RID: 242040 RVA: 0x00EF3A94 File Offset: 0x00EF1C94
		public RewardItemData(int configId, int count, int? uniqueId = null, EDropItemType dropItemType = EDropItemType.Normal)
		{
			this.ConfigId = configId;
			this.Count = count;
			this.UniqueId = uniqueId.GetValueOrDefault();
			this.DropItemType = dropItemType;
			InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
			this.Config = instance.GetItemConfigData(configId);
			if (this.Config == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RewardItem;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "生成奖励物品数据时，没有在d.道具中找到";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configId", configId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.TypeConfig = ((this.Config.ItemType != null) ? instance.GetItemTypeConfig((int)this.Config.ItemType.Value) : null);
			this.TypeSortIndex = ((this.TypeConfig != null) ? this.TypeConfig.GetValueOrDefault().SortIndex : 0);
			this.QualityId = this.Config.QualityId;
		}

		// Token: 0x0603B179 RID: 242041 RVA: 0x00EF3B81 File Offset: 0x00EF1D81
		[NullableContext(1)]
		public ItemConfig GetConfig()
		{
			return this.Config;
		}

		// Token: 0x0603B17A RID: 242042 RVA: 0x00EF3B89 File Offset: 0x00EF1D89
		public int GetTypeSortIndex()
		{
			return this.TypeSortIndex;
		}

		// Token: 0x0603B17B RID: 242043 RVA: 0x00EF3B91 File Offset: 0x00EF1D91
		public int GetQualityId()
		{
			return this.QualityId;
		}

		// Token: 0x0603B17C RID: 242044 RVA: 0x00EF3B99 File Offset: 0x00EF1D99
		public EDropItemType GetDropItemType()
		{
			return this.DropItemType;
		}

		// Token: 0x0603B17D RID: 242045 RVA: 0x00EF3BA1 File Offset: 0x00EF1DA1
		public ERoleDevelopStateTagType? GetRoleDevelopStateTagType()
		{
			return this.RoleDevelopStateTagTypeValue;
		}

		// Token: 0x0603B17E RID: 242046 RVA: 0x00EF3BA9 File Offset: 0x00EF1DA9
		public void SetRoleDevelopStateTagType(ERoleDevelopStateTagType? value)
		{
			this.RoleDevelopStateTagTypeValue = value;
		}

		// Token: 0x0603B17F RID: 242047 RVA: 0x00EF3BB2 File Offset: 0x00EF1DB2
		public void SetShowTimeFlag(bool value)
		{
			this.ShowTimeFlagValue = value;
		}

		// Token: 0x0603B180 RID: 242048 RVA: 0x00EF3BBB File Offset: 0x00EF1DBB
		public bool GetShowTimeFlag()
		{
			return this.ShowTimeFlagValue;
		}

		// Token: 0x0402153E RID: 136510
		public readonly int ConfigId;

		// Token: 0x0402153F RID: 136511
		public readonly int UniqueId;

		// Token: 0x04021540 RID: 136512
		public int Count;

		// Token: 0x04021541 RID: 136513
		[Nullable(2)]
		private readonly ItemConfig Config;

		// Token: 0x04021542 RID: 136514
		private readonly TypeInfo? TypeConfig;

		// Token: 0x04021543 RID: 136515
		private readonly int TypeSortIndex;

		// Token: 0x04021544 RID: 136516
		private readonly int QualityId;

		// Token: 0x04021545 RID: 136517
		private readonly EDropItemType DropItemType;

		// Token: 0x04021546 RID: 136518
		private ERoleDevelopStateTagType? RoleDevelopStateTagTypeValue;

		// Token: 0x04021547 RID: 136519
		private bool ShowTimeFlagValue;
	}
}
