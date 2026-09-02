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
	// Token: 0x02004EA7 RID: 20135
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseRankFormationItemV2 : GridProxyAbstract<TowerDefenseRankRoleData>
	{
		// Token: 0x0603405E RID: 213086 RVA: 0x00D038F4 File Offset: 0x00D01AF4
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

		// Token: 0x0603405F RID: 213087 RVA: 0x00D039C0 File Offset: 0x00D01BC0
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseRankFormationItemV2.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseRankFormationItemV2.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034060 RID: 213088 RVA: 0x00D03A04 File Offset: 0x00D01C04
		private void RefreshOnlineKey()
		{
			UUITexture texture = base.GetTexture(2);
			if (this.Data != null && this.Data.IsOnline)
			{
				texture.SetUIActive(true);
				string posTexture = Singleton<TowerDefenseRankItemUtil>.Instance.GetPosTexture(this.Data.Pos);
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(posTexture);
				base.SetTextureByPath(resourcePath, texture, null, null);
				return;
			}
			texture.SetUIActive(false);
		}

		// Token: 0x06034061 RID: 213089 RVA: 0x00D03A74 File Offset: 0x00D01C74
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

		// Token: 0x06034062 RID: 213090 RVA: 0x00D03B6C File Offset: 0x00D01D6C
		private void RefreshPhantomIcon()
		{
			TowerDefencePhantom? towerDefensePhantomById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefensePhantomById(this.Data.PhantomId);
			base.SetTextureByPath(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(towerDefensePhantomById.Value.PhantomItemId).Value.IconMiddle, base.GetTexture(1), null, null);
		}

		// Token: 0x06034063 RID: 213091 RVA: 0x00D03BD0 File Offset: 0x00D01DD0
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
				this.RefreshOnlineKey();
				this.RefreshItemGrid();
				this.RefreshPhantomIcon();
			}
		}

		// Token: 0x0401E10C RID: 123148
		private TowerDefenseRankRoleData Data;

		// Token: 0x0401E10D RID: 123149
		private SmallItemGrid ItemGrid;

		// Token: 0x0401E10E RID: 123150
		[Nullable(2)]
		private CharacterSmallItemGrid CacheGridData;

		// Token: 0x0200AE59 RID: 44633
		[NullableContext(0)]
		private class EFormationItemComponent
		{
			// Token: 0x0403620F RID: 221711
			public const int RoleItem = 0;

			// Token: 0x04036210 RID: 221712
			public const int PhantomIconTex = 1;

			// Token: 0x04036211 RID: 221713
			public const int OnlineKeyTex = 2;

			// Token: 0x04036212 RID: 221714
			public const int FormationItem = 3;

			// Token: 0x04036213 RID: 221715
			public const int EmptyItem = 4;
		}
	}
}
