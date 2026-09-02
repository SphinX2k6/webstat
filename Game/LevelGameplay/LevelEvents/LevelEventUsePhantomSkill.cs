using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C26 RID: 27686
	public class LevelEventUsePhantomSkill : LevelEventBase
	{
		// Token: 0x060441B8 RID: 278968 RVA: 0x011AF780 File Offset: 0x011AD980
		public LevelEventUsePhantomSkill(int id) : base(id)
		{
		}

		// Token: 0x060441B9 RID: 278969 RVA: 0x011AF78C File Offset: 0x011AD98C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			UsePhantomSkill usePhantomSkill = inParams as UsePhantomSkill;
			if (usePhantomSkill == null)
			{
				return;
			}
			if (!ModelBase<SceneTeamModel>.Instance.IsPhantomTeam)
			{
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (usePhantomSkill.BlackboardPos != null)
			{
				ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(getCurrentEntity.Entity.Id, usePhantomSkill.BlackboardPos.Key, (double)usePhantomSkill.BlackboardPos.Value.X.GetValueOrDefault(), (double)usePhantomSkill.BlackboardPos.Value.Y.GetValueOrDefault(), (double)usePhantomSkill.BlackboardPos.Value.Z.GetValueOrDefault());
			}
			if (usePhantomSkill.BlackboardRot != null)
			{
				if (Global.BaseCharacter == null)
				{
					return;
				}
				ControllerBase<BlackboardController>.Instance.SetRotatorValueByEntity(getCurrentEntity.Entity.Id, usePhantomSkill.BlackboardRot.Key, usePhantomSkill.BlackboardRot.Value.Y.GetValueOrDefault(), usePhantomSkill.BlackboardRot.Value.X.GetValueOrDefault(), usePhantomSkill.BlackboardRot.Value.Z.GetValueOrDefault());
			}
			getCurrentEntity.Entity.GetComponent<BaseTagComponent>().AddTag(new int?(GameplayTagUtils.GetTagIdByName(usePhantomSkill.SkillType.ToEnumString())));
		}
	}
}
