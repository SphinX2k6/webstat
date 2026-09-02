using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.SkillButtonUi;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF0 RID: 27632
	public class LevelEventSetSkillButtonEffect : LevelEventBase
	{
		// Token: 0x060440FB RID: 278779 RVA: 0x011AB032 File Offset: 0x011A9232
		public LevelEventSetSkillButtonEffect(int id) : base(id)
		{
		}

		// Token: 0x060440FC RID: 278780 RVA: 0x011AB03C File Offset: 0x011A923C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			SetSkillBtnEffect setSkillBtnEffect = inParams as SetSkillBtnEffect;
			ISkillBtnEffectBase skillBtnEffectData = setSkillBtnEffect.SkillBtnEffectData;
			ESkillButtonExtraEffect eskillButtonExtraEffect = ESkillButtonExtraEffect.None;
			if (skillBtnEffectData.Type == ESkillBtnEffectType.MusicBattleBtnEffect)
			{
				eskillButtonExtraEffect = ESkillButtonExtraEffect.Rhythm;
			}
			if (eskillButtonExtraEffect != ESkillButtonExtraEffect.None)
			{
				if (setSkillBtnEffect.SkillBtnType == Aki.TDConfigMgr.Action.ESkillButtonType.协奏)
				{
					ControllerBase<BattleUiControl>.Instance.PlayConcertoExtraEffect(eskillButtonExtraEffect, setSkillBtnEffect.Time);
					return;
				}
				ControllerBase<SkillButtonUiController>.Instance.PlayExtraEffect((CSharpScript.Game.Module.SkillButtonUi.ESkillButtonType)setSkillBtnEffect.SkillBtnType, eskillButtonExtraEffect, setSkillBtnEffect.Time);
			}
		}
	}
}
