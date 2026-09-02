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

// Token: 0x02001AF9 RID: 6905
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class RankRoleGridItem : GridProxyAbstract<DangoAbyssRankRoleData>
{
	// Token: 0x0600C6E4 RID: 50916 RVA: 0x00349728 File Offset: 0x00347928
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C6E5 RID: 50917 RVA: 0x003497D4 File Offset: 0x003479D4
	protected override UniTask OnBeforeStartAsync()
	{
		RankRoleGridItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RankRoleGridItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6E6 RID: 50918 RVA: 0x00349818 File Offset: 0x00347A18
	private void RefreshPosTexture()
	{
		UUITexture texture = base.GetTexture(2);
		if (this.Data.IsEmpty)
		{
			texture.SetUIActive(false);
			return;
		}
		if (this.Data != null)
		{
			texture.SetUIActive(this.Data.IsOnline);
			if (this.Data.IsOnline)
			{
				string posTexture = DangoAbyssRankItemHelper.GetPosTexture(this.Data.Pos);
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

	// Token: 0x0600C6E7 RID: 50919 RVA: 0x003498A4 File Offset: 0x00347AA4
	private void RefreshItemGrid()
	{
		if (this.Data.IsEmpty)
		{
			this.ItemGrid.SetActive(false);
			return;
		}
		this.ItemGrid.SetActive(true);
		RoleSkin value = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(this.Data.RoleSkinId).Value;
		RoleInfo value2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(value.RoleId).Value;
		if (this.CacheGridData == null)
		{
			this.CacheGridData = new CharacterSmallItemGrid
			{
				Data = null
			};
		}
		this.CacheGridData.ItemConfigId = new int?(value.RoleId);
		this.CacheGridData.SkinId = new int?(this.Data.RoleSkinId);
		this.CacheGridData.BottomTextId = "Text_LevelShow_Text";
		this.CacheGridData.BottomTextParameter = new object[]
		{
			this.Data.RoleLevel
		};
		this.CacheGridData.ElementId = new int?(value2.ElementId);
		this.ItemGrid.Apply<CharacterSmallItemGrid>(this.CacheGridData);
	}

	// Token: 0x0600C6E8 RID: 50920 RVA: 0x003499BC File Offset: 0x00347BBC
	private void RefreshDangoIcon()
	{
		if (this.Data.IsEmpty)
		{
			base.GetTexture(1).SetUIActive(false);
			return;
		}
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(this.Data.DangoId);
		string text = ((dangoAbyssRoleData != null) ? dangoAbyssRoleData.GetFormationIcon() : null) ?? "";
		if (!string.IsNullOrEmpty(text))
		{
			base.GetTexture(1).SetUIActive(true);
			base.SetTextureByPath(text, base.GetTexture(1), null, null);
			return;
		}
		base.GetTexture(1).SetUIActive(false);
	}

	// Token: 0x0600C6E9 RID: 50921 RVA: 0x00349A50 File Offset: 0x00347C50
	private void RefreshQualityItem()
	{
		if (this.Data.IsEmpty)
		{
			this.DangoCircleQualityItem.SetActive(false);
			return;
		}
		Dictionary<int, int> equipPluginMap = this.Data.GetEquipPluginMap();
		DangoCircleQualityData dangoCircleQualityData = new DangoCircleQualityData();
		dangoCircleQualityData.PluginIdMap = equipPluginMap;
		this.DangoCircleQualityItem.RefreshData(dangoCircleQualityData);
		this.DangoCircleQualityItem.SetActive(true);
	}

	// Token: 0x0600C6EA RID: 50922 RVA: 0x00349AAB File Offset: 0x00347CAB
	public override void Refresh(DangoAbyssRankRoleData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshPosTexture();
		this.RefreshItemGrid();
		this.RefreshDangoIcon();
		this.RefreshQualityItem();
	}

	// Token: 0x04005F42 RID: 24386
	private DangoAbyssRankRoleData Data;

	// Token: 0x04005F43 RID: 24387
	private SmallItemGrid ItemGrid;

	// Token: 0x04005F44 RID: 24388
	[Nullable(2)]
	private CharacterSmallItemGrid CacheGridData;

	// Token: 0x04005F45 RID: 24389
	[Nullable(2)]
	private AbyssDangoCircleQualityItem DangoCircleQualityItem;

	// Token: 0x02007DCE RID: 32206
	[NullableContext(0)]
	private class ERankRoleComponent
	{
		// Token: 0x0402ADA4 RID: 175524
		public const int GridItem = 0;

		// Token: 0x0402ADA5 RID: 175525
		public const int DangoTexture = 1;

		// Token: 0x0402ADA6 RID: 175526
		public const int PosTexture = 2;

		// Token: 0x0402ADA7 RID: 175527
		public const int QualityItem = 3;
	}
}
