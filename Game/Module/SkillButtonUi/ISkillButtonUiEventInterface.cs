using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F7A RID: 20346
	[NullableContext(1)]
	public interface ISkillButtonUiEventInterface
	{
		// Token: 0x06034799 RID: 214937 RVA: 0x00D21B75 File Offset: 0x00D1FD75
		void EquipExplorePhantomSkill()
		{
		}

		// Token: 0x0603479A RID: 214938 RVA: 0x00D21B77 File Offset: 0x00D1FD77
		void SkillCountChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
		}

		// Token: 0x0603479B RID: 214939 RVA: 0x00D21B79 File Offset: 0x00D1FD79
		void SkillRemainCdChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
		}
	}
}
