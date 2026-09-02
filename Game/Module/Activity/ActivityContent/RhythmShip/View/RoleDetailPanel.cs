using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064F6 RID: 25846
	internal class RoleDetailPanel : UiPanelBase
	{
		// Token: 0x06040B64 RID: 265060 RVA: 0x01098150 File Offset: 0x01096350
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x06040B65 RID: 265061 RVA: 0x01098204 File Offset: 0x01096404
		public void RefreshPanel()
		{
			if (ModelBase<RhythmShipModel>.Instance.RhythmShipLevelRole <= 0)
			{
				base.GetItem(5).SetUIActive(true);
				base.GetItem(0).SetUIActive(false);
				return;
			}
			base.GetItem(5).SetUIActive(false);
			base.GetItem(0).SetUIActive(true);
			RhythmRole? rhythmRoleById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleById(ModelBase<RhythmShipModel>.Instance.RhythmShipLevelRole);
			if (rhythmRoleById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rhythmRoleById.Value.RoleNameText, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rhythmRoleById.Value.RoleDesText, Array.Empty<object>());
			base.SetTextureByPath(rhythmRoleById.Value.RoleHeadTexture, base.GetTexture(1), null, null);
			if (!string.IsNullOrEmpty(rhythmRoleById.Value.SkillIcon))
			{
				base.GetItem(6).SetUIActive(true);
				base.SetTextureByPath(rhythmRoleById.Value.SkillIcon, base.GetTexture(2), null, null);
				return;
			}
			base.GetItem(6).SetUIActive(false);
		}
	}
}
