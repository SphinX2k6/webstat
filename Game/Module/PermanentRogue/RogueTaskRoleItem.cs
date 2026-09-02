using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056A8 RID: 22184
	public class RogueTaskRoleItem : UiPanelBase
	{
		// Token: 0x06038789 RID: 231305 RVA: 0x00E4ED6D File Offset: 0x00E4CF6D
		public RogueTaskRoleItem(int roleId, bool bIsLock)
		{
			this.RoleId = roleId;
			this.IsLock = bIsLock;
		}

		// Token: 0x0603878A RID: 231306 RVA: 0x00E4ED8A File Offset: 0x00E4CF8A
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603878B RID: 231307 RVA: 0x00E4EDC4 File Offset: 0x00E4CFC4
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(this.IsLock);
			}
			base.SetTextureByPath(ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value.FormationRoleCard, base.GetTexture(0), null, null);
		}

		// Token: 0x0603878C RID: 231308 RVA: 0x00E4EE31 File Offset: 0x00E4D031
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer = null;
		}

		// Token: 0x0603878D RID: 231309 RVA: 0x00E4EE3C File Offset: 0x00E4D03C
		public void SetCharUnlock()
		{
			if (!this.IsLock)
			{
				return;
			}
			this.IsLock = false;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Unlock", false, null, false);
		}

		// Token: 0x040203EF RID: 132079
		protected int RoleId;

		// Token: 0x040203F0 RID: 132080
		protected bool IsLock = true;

		// Token: 0x040203F1 RID: 132081
		[Nullable(2)]
		public LevelSequencePlayer LevelSequencePlayer;
	}
}
