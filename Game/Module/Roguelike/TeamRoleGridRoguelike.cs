using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200515B RID: 20827
	public class TeamRoleGridRoguelike : TeamRoleGridBase
	{
		// Token: 0x060359B0 RID: 219568 RVA: 0x00D770E8 File Offset: 0x00D752E8
		[NullableContext(1)]
		protected override CharacterMediumItemGrid GetRoleParameters(CharacterMediumItemGrid baseParameter, RoleDataBase data)
		{
			int roleShowLevel = ModelBase<RoguelikeModel>.Instance.GetEntranceViewModel().RoleShowLevel;
			int level = data.GetLevelData().GetLevel();
			if (roleShowLevel > level)
			{
				baseParameter.BottomTextId = null;
				baseParameter.BottomTextParameter = null;
				baseParameter.AddLevel = new int?(roleShowLevel);
			}
			return baseParameter;
		}
	}
}
