using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051F1 RID: 20977
	public class RogueBattleMapRoleAttributeNameItem : UiPanelBase
	{
		// Token: 0x06035D80 RID: 220544 RVA: 0x00D8C664 File Offset: 0x00D8A864
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06035D81 RID: 220545 RVA: 0x00D8C700 File Offset: 0x00D8A900
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<RougeBattleAttributeStarItem, bool>(base.GetHorizontalLayout(4), new Func<RougeBattleAttributeStarItem>(this.CreateElement), null, false, true);
		}

		// Token: 0x06035D82 RID: 220546 RVA: 0x00D8C723 File Offset: 0x00D8A923
		[NullableContext(1)]
		private RougeBattleAttributeStarItem CreateElement()
		{
			return new RougeBattleAttributeStarItem();
		}

		// Token: 0x06035D83 RID: 220547 RVA: 0x00D8C72A File Offset: 0x00D8A92A
		protected override void OnBeforeDestroy()
		{
			this.StarLayout = null;
		}

		// Token: 0x06035D84 RID: 220548 RVA: 0x00D8C734 File Offset: 0x00D8A934
		public void Refresh(int roleId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			if (roleDataById == null)
			{
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
				if (roleConfig == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RogueBattle;
					ELogAuthor author = ELogAuthor.WHJ;
					string message = "没有角色数据";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				base.GetText(0).SetText(ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name), true);
				ElementInfo? elementInfo = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(roleConfig.Value.ElementId);
				string elementInfoLocalName = ConfigBase<ElementInfoConfig>.Instance.GetElementInfoLocalName(elementInfo.Value.Name);
				base.GetText(3).SetText(elementInfoLocalName, true);
				base.SetElementIcon(elementInfo.Value.Icon, base.GetTexture(2), roleConfig.Value.ElementId, null);
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetUIActive(false);
				}
				UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(4);
				if (horizontalLayout == null)
				{
					return;
				}
				horizontalLayout.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				base.GetText(0).SetText(roleDataById.GetName(null), true);
				ElementInfo? elementInfo2 = roleDataById.GetElementInfo();
				string elementInfoLocalName2 = ConfigBase<ElementInfoConfig>.Instance.GetElementInfoLocalName(elementInfo2.Value.Name);
				base.GetText(3).SetText(elementInfoLocalName2, true);
				base.SetElementIcon(elementInfo2.Value.Icon, base.GetTexture(2), roleDataById.GetRoleConfig().ElementId, null);
				bool flag = ModelBase<RogueBattleModel>.Instance.IsRoleGot(roleId);
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.SetUIActive(flag);
				}
				UUIHorizontalLayout horizontalLayout2 = base.GetHorizontalLayout(4);
				if (horizontalLayout2 != null)
				{
					horizontalLayout2.RootUIComp.Get().SetUIActive(flag);
				}
				if (!flag)
				{
					return;
				}
				int incIdByRoleId = ModelBase<RogueBattleModel>.Instance.GetIncIdByRoleId(roleId);
				RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(incIdByRoleId);
				int rogueRoleLevel = ModelBase<MapRogueModel>.Instance.GetRogueRoleLevel();
				UUIText text3 = base.GetText(1);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(rogueRoleLevel);
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				int rogueRoleMaxStar = ModelBase<MapRogueModel>.Instance.GetRogueRoleMaxStar();
				int level = roleInfoById.Level;
				List<bool> list = new List<bool>(rogueRoleMaxStar);
				for (int i = 0; i < rogueRoleMaxStar; i++)
				{
					list.Add(i < level);
				}
				GenericLayout<RougeBattleAttributeStarItem, bool> starLayout = this.StarLayout;
				if (starLayout == null)
				{
					return;
				}
				starLayout.RefreshByData(list, null, false);
				return;
			}
		}

		// Token: 0x0401EE8D RID: 126605
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RougeBattleAttributeStarItem, bool> StarLayout;
	}
}
