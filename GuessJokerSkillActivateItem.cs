using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001134 RID: 4404
public class GuessJokerSkillActivateItem : UiPanelBase
{
	// Token: 0x06007355 RID: 29525 RVA: 0x001E2CD8 File Offset: 0x001E0ED8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
	}

	// Token: 0x06007356 RID: 29526 RVA: 0x001E2D5E File Offset: 0x001E0F5E
	protected override void OnStart()
	{
	}

	// Token: 0x06007357 RID: 29527 RVA: 0x001E2D60 File Offset: 0x001E0F60
	public void Refresh(int skillId)
	{
		JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(skillId);
		if (jokerSkill == null)
		{
			return;
		}
		JokerSkill value = jokerSkill.Value;
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.ShowTextNew(value.SkillName);
		}
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.ShowTextNew(value.ShortSkillDesc);
		}
		base.SetTextureByPath(value.SkillIconPath, base.GetTexture(2), null, null);
		if (value.SkillPlayTextureLength == 1)
		{
			base.SetTextureByPath(value.SkillPlayTexture(0), base.GetTexture(1), null, null);
			return;
		}
		string path = (ModelBase<WorldLevelModel>.Instance.Sex == 1) ? value.SkillPlayTexture(0) : value.SkillPlayTexture(1);
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
	}

	// Token: 0x020074C4 RID: 29892
	private static class EComponentDefine
	{
		// Token: 0x04028517 RID: 165143
		public const int MaskButton = 0;

		// Token: 0x04028518 RID: 165144
		public const int RoleTexture = 1;

		// Token: 0x04028519 RID: 165145
		public const int SkillIconTexture = 2;

		// Token: 0x0402851A RID: 165146
		public const int DescText = 3;

		// Token: 0x0402851B RID: 165147
		public const int ValueText = 4;
	}
}
