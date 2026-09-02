using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.RoleSelect
{
	// Token: 0x020054B6 RID: 21686
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaRoleSelectionItem : LoopScrollSmallItemGrid<IPhantomArenaRoleSelectionItemData>
	{
		// Token: 0x060373CA RID: 226250 RVA: 0x00E0306C File Offset: 0x00E0126C
		protected override void OnRefresh(IPhantomArenaRoleSelectionItemData data, bool isSelected, int gridIndex)
		{
			int roleConfigId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(data.CardRoleId).RoleConfigId;
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId);
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(roleConfigId),
				SkinId = new int?(roleConfig.Value.SkinId),
				ElementId = new int?(roleConfig.Value.ElementId),
				IsLockVisible = new bool?(!ModelBase<PhantomArenaModel>.Instance.IsRoleUnlock(data.CardRoleId)),
				IsRedDotVisible = new bool?(data.CanReceived)
			};
			base.Apply<CharacterSmallItemGrid>(parameters);
			this.SetSelected(isSelected, false);
		}

		// Token: 0x060373CB RID: 226251 RVA: 0x00E0312B File Offset: 0x00E0132B
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, true);
		}

		// Token: 0x060373CC RID: 226252 RVA: 0x00E03135 File Offset: 0x00E01335
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, true);
		}

		// Token: 0x060373CD RID: 226253 RVA: 0x00E0313F File Offset: 0x00E0133F
		[return: Nullable(2)]
		public override object GetKey(IPhantomArenaRoleSelectionItemData data, int gridIndex)
		{
			return data.CardRoleId;
		}
	}
}
