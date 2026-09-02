using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029B2 RID: 10674
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerDescTeamItem : GridProxyAbstract<ShipTowerTeamData>
{
	// Token: 0x06015481 RID: 87169 RVA: 0x005E5C58 File Offset: 0x005E3E58
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(14, typeof(UUIMultiTemplateLayout)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickMechanismDetail)),
			new ValueTuple<int, Delegate>(12, new Action<EToggleState>(this.OnClickTeamRoot))
		};
	}

	// Token: 0x06015482 RID: 87170 RVA: 0x005E5E44 File Offset: 0x005E4044
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerDescTeamItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerDescTeamItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015483 RID: 87171 RVA: 0x005E5E87 File Offset: 0x005E4087
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x06015484 RID: 87172 RVA: 0x005E5E89 File Offset: 0x005E4089
	protected override void OnStart()
	{
	}

	// Token: 0x06015485 RID: 87173 RVA: 0x005E5E8B File Offset: 0x005E408B
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x06015486 RID: 87174 RVA: 0x005E5E8D File Offset: 0x005E408D
	public override void Refresh(ShipTowerTeamData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x06015487 RID: 87175 RVA: 0x005E5E98 File Offset: 0x005E4098
	public void Refresh(ShipTowerTeamData data)
	{
		this.ItemData = data;
		InstanceDungeon? instanceDungeonCfg = data.GetInstanceDungeonCfg(null);
		SlashTowerStageInfo? shipTowerStageCfg = data.GetShipTowerStageCfg();
		int recommendLevelByInstId = ModelBase<ShipTowerModel>.Instance.GetRecommendLevelByInstId(data.InstId);
		base.GetText(0).ShowTextNew(data.TeamInstName);
		base.GetText(16).ShowTextNew(data.TeamName);
		base.GetText(1).SetText(data.CurrentScore.ToString(), true);
		List<int> list;
		if (shipTowerStageCfg == null)
		{
			list = new List<int>();
		}
		else
		{
			list = new List<int>();
			for (int i = 0; i < shipTowerStageCfg.Value.BuffIdLength; i++)
			{
				list.Add(shipTowerStageCfg.Value.BuffId(i));
			}
		}
		this.UpdateWords(list);
		base.GetText(3).ShowTextNew("GhostShipMonster_Text1");
		base.GetText(13).ShowTextNew(((instanceDungeonCfg != null) ? instanceDungeonCfg.GetValueOrDefault().DungeonDesc : null) ?? "");
		base.SetTextureByPath(((instanceDungeonCfg != null) ? instanceDungeonCfg.GetValueOrDefault().DifficultyIcon : null) ?? "", base.GetTexture(8), null, null);
		UUIText text = base.GetText(9);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "GhostShipTeamRecommendLv_Text", new <>z__ReadOnlySingleElementList<object>(recommendLevelByInstId));
		int stageId = data.StageId;
		ShipTowerStageData stageDataById = ModelBase<ShipTowerModel>.Instance.GetStageDataById(stageId);
		base.GetItem(17).SetUIActive(stageDataById.IsQuickPass);
		this.UpdateRoleList();
		this.UpdateBuff();
	}

	// Token: 0x06015488 RID: 87176 RVA: 0x005E6043 File Offset: 0x005E4243
	private void OnClickMechanismDetail()
	{
		Action<ShipTowerTeamData> mechanismClickCallBack = this.MechanismClickCallBack;
		if (mechanismClickCallBack == null)
		{
			return;
		}
		mechanismClickCallBack(this.ItemData);
	}

	// Token: 0x06015489 RID: 87177 RVA: 0x005E605B File Offset: 0x005E425B
	private void OnClickTeamRoot(EToggleState toggleState)
	{
		Action<ShipTowerTeamData> roleClickCallBack = this.RoleClickCallBack;
		if (roleClickCallBack == null)
		{
			return;
		}
		roleClickCallBack(this.ItemData);
	}

	// Token: 0x0601548A RID: 87178 RVA: 0x005E6074 File Offset: 0x005E4274
	public void SetTeamToggleIsSelect(bool isSelect)
	{
		EToggleState state = isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(12);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x0601548B RID: 87179 RVA: 0x005E60A0 File Offset: 0x005E42A0
	private void UpdateWords(List<int> buffIdList)
	{
		string text = "GhostShipMonster_Text2";
		string text2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
		if (buffIdList.Count == 0)
		{
			string text3 = "GhostShipMonsterNull_Text";
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text3, text3);
			text2 = text2 + "  " + multiTextByKey;
		}
		base.GetText(2).SetText(text2, true);
		this.WordLayout.RefreshByData(this.ItemData.GetWordInfoList(), null, false);
	}

	// Token: 0x0601548C RID: 87180 RVA: 0x005E610E File Offset: 0x005E430E
	public void UpdateRoleList()
	{
		this.RoleLayout.RefreshByData(this.ItemData.GetUseRoleList(), null, false);
	}

	// Token: 0x0601548D RID: 87181 RVA: 0x005E6128 File Offset: 0x005E4328
	public void UpdateBuff()
	{
		ShipTowerBuffData buffDataEdit = this.ItemData.BuffDataEdit;
		int num = (buffDataEdit != null) ? buffDataEdit.ItemId : 0;
		if (num > 0)
		{
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = this.ItemData,
				ItemConfigId = new int?(num)
			};
			this.BuffItem.Apply<PropSmallItemGrid>(parameters);
			return;
		}
		this.BuffItem.Apply<EmptySmallItemGrid>(new EmptySmallItemGrid());
	}

	// Token: 0x0601548E RID: 87182 RVA: 0x005E618C File Offset: 0x005E438C
	[NullableContext(2)]
	private void OnClickBuff(MediumItemGridExtendCallback _)
	{
		this.BuffItem.SetSelected(false, true);
		Action<ShipTowerTeamData> buffClickCallBack = this.BuffClickCallBack;
		if (buffClickCallBack == null)
		{
			return;
		}
		buffClickCallBack(this.ItemData);
	}

	// Token: 0x0601548F RID: 87183 RVA: 0x005E61B1 File Offset: 0x005E43B1
	private ShipTowerRoleItem CreateRoleItem()
	{
		return new ShipTowerRoleItem();
	}

	// Token: 0x06015490 RID: 87184 RVA: 0x005E61B8 File Offset: 0x005E43B8
	private ShipTowerWordItem CreateWordItem()
	{
		return new ShipTowerWordItem();
	}

	// Token: 0x06015491 RID: 87185 RVA: 0x005E61C0 File Offset: 0x005E43C0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		string a = configParams[0];
		UUIItem uuiitem = null;
		if (!(a == "Desc"))
		{
			if (!(a == "Item"))
			{
				if (!(a == "TeamAndItem"))
				{
					if (a == "TeamAndItemOuter")
					{
						UUIExtendToggle extendToggle = base.GetExtendToggle(12);
						uuiitem = ((extendToggle != null) ? extendToggle.GetRootComponent() : null);
					}
				}
				else
				{
					uuiitem = base.GetGuideUiItem("1");
				}
			}
			else
			{
				uuiitem = this.BuffItem.GetRootItem();
			}
		}
		else
		{
			UUIText text = base.GetText(13);
			uuiitem = ((text != null) ? text.GetParentAsUIItem() : null);
		}
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0400A416 RID: 42006
	[Nullable(2)]
	private ShipTowerTeamData ItemData;

	// Token: 0x0400A417 RID: 42007
	private GenericLayout<ShipTowerRoleItem, ShipTowerRoleData> RoleLayout;

	// Token: 0x0400A418 RID: 42008
	private GenericLayout<ShipTowerWordItem, ShipTowerWordItemData> WordLayout;

	// Token: 0x0400A419 RID: 42009
	private SmallItemGrid BuffItem;

	// Token: 0x0400A41A RID: 42010
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerTeamData> RoleClickCallBack;

	// Token: 0x0400A41B RID: 42011
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerTeamData> BuffClickCallBack;

	// Token: 0x0400A41C RID: 42012
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerTeamData> MechanismClickCallBack;

	// Token: 0x02008D07 RID: 36103
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F6FE RID: 194302
		public const int TxtTitle = 0;

		// Token: 0x0402F6FF RID: 194303
		public const int TxtScore = 1;

		// Token: 0x0402F700 RID: 194304
		public const int TxtWord = 2;

		// Token: 0x0402F701 RID: 194305
		public const int TxtMechanismTitle = 3;

		// Token: 0x0402F702 RID: 194306
		public const int BtnMechanismDetail = 4;

		// Token: 0x0402F703 RID: 194307
		public const int VLayoutMechanismList = 5;

		// Token: 0x0402F704 RID: 194308
		public const int SpriteTeamBg = 6;

		// Token: 0x0402F705 RID: 194309
		public const int SpriteTeamSelect = 7;

		// Token: 0x0402F706 RID: 194310
		public const int TextureTeamIndex = 8;

		// Token: 0x0402F707 RID: 194311
		public const int TxtTeamRecommendLv = 9;

		// Token: 0x0402F708 RID: 194312
		public const int HLayoutRoleList = 10;

		// Token: 0x0402F709 RID: 194313
		public const int ItemBuff = 11;

		// Token: 0x0402F70A RID: 194314
		public const int ToggleTeamRoot = 12;

		// Token: 0x0402F70B RID: 194315
		public const int TxtMechanismDesc = 13;

		// Token: 0x0402F70C RID: 194316
		public const int MLayout = 14;

		// Token: 0x0402F70D RID: 194317
		public const int ItemWord = 15;

		// Token: 0x0402F70E RID: 194318
		public const int TxtTeamName = 16;

		// Token: 0x0402F70F RID: 194319
		public const int QuickPassItem = 17;
	}
}
