using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E99 RID: 20121
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RankGridItem : GridProxyAbstract<TowerDefenseRankRoleData>
	{
		// Token: 0x06033FE9 RID: 212969 RVA: 0x00D01A44 File Offset: 0x00CFFC44
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033FEA RID: 212970 RVA: 0x00D01B10 File Offset: 0x00CFFD10
		protected override UniTask OnBeforeStartAsync()
		{
			RankGridItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RankGridItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033FEB RID: 212971 RVA: 0x00D01B54 File Offset: 0x00CFFD54
		private void RefreshPosTexture()
		{
			UUITexture texture = base.GetTexture(2);
			if (this.Data != null)
			{
				texture.SetUIActive(this.Data.IsOnline);
				if (this.Data.IsOnline)
				{
					string posTexture = Singleton<TowerDefenseRankItemUtil>.Instance.GetPosTexture(this.Data.Pos);
					string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(posTexture);
					base.SetTextureByPath(resourcePath, texture, null, null);
					return;
				}
			}
			else
			{
				texture.SetUIActive(false);
			}
		}

		// Token: 0x06033FEC RID: 212972 RVA: 0x00D01BCC File Offset: 0x00CFFDCC
		private void RefreshItemGrid()
		{
			RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(this.Data.RoleSkinId);
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleSkinConfig.Value.RoleId);
			if (this.CacheGridData == null)
			{
				this.CacheGridData = new CharacterSmallItemGrid
				{
					Data = null
				};
			}
			this.CacheGridData.ItemConfigId = new int?(roleSkinConfig.Value.RoleId);
			this.CacheGridData.SkinId = new int?(this.Data.RoleSkinId);
			this.CacheGridData.BottomTextId = "Text_LevelShow_Text";
			this.CacheGridData.BottomTextParameter = new object[]
			{
				this.Data.RoleLevel
			};
			this.CacheGridData.ElementId = new int?(roleConfig.Value.ElementId);
			this.ItemGrid.Apply<CharacterSmallItemGrid>(this.CacheGridData);
		}

		// Token: 0x06033FED RID: 212973 RVA: 0x00D01CC4 File Offset: 0x00CFFEC4
		private void RefreshPhantomIcon()
		{
			TowerDefencePhantom? towerDefensePhantomById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefensePhantomById(this.Data.PhantomId);
			base.SetTextureByPath(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(towerDefensePhantomById.Value.PhantomItemId).Value.IconMiddle, base.GetTexture(1), null, null);
		}

		// Token: 0x06033FEE RID: 212974 RVA: 0x00D01D28 File Offset: 0x00CFFF28
		public override void Refresh(TowerDefenseRankRoleData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			bool flag = !data.IsEmpty;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (flag)
			{
				this.RefreshPosTexture();
				this.RefreshItemGrid();
				this.RefreshPhantomIcon();
			}
		}

		// Token: 0x0401E0D3 RID: 123091
		private TowerDefenseRankRoleData Data;

		// Token: 0x0401E0D4 RID: 123092
		private SmallItemGrid ItemGrid;

		// Token: 0x0401E0D5 RID: 123093
		private CharacterSmallItemGrid CacheGridData;

		// Token: 0x0200AE3F RID: 44607
		[NullableContext(0)]
		private class ERankGridItem
		{
			// Token: 0x040361A2 RID: 221602
			public const int GridItem = 0;

			// Token: 0x040361A3 RID: 221603
			public const int PhantomTexture = 1;

			// Token: 0x040361A4 RID: 221604
			public const int PosTexture = 2;

			// Token: 0x040361A5 RID: 221605
			public const int ContentItem = 3;

			// Token: 0x040361A6 RID: 221606
			public const int EmptyItem = 4;
		}
	}
}
