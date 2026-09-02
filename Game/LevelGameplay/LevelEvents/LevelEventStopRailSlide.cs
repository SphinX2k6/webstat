using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.NewWorld.Character.Common.Controller;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C0F RID: 27663
	public class LevelEventStopRailSlide : LevelEventBase
	{
		// Token: 0x06044177 RID: 278903 RVA: 0x011ADE9E File Offset: 0x011AC09E
		public LevelEventStopRailSlide(int id) : base(id)
		{
		}

		// Token: 0x06044178 RID: 278904 RVA: 0x011ADEA8 File Offset: 0x011AC0A8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventStopRailSlide 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ISlideRailEndType endTarget = (inParams as SlideRailEnd).EndTarget;
			ESlideRailEndType type = endTarget.Type;
			if (type != ESlideRailEndType.Player)
			{
				if (type != ESlideRailEndType.AiFollower)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventStopRailSlide 未知的EndTarget类型", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				int aiEntityId = ((IAiFollowerSlideRailEnd)endTarget).AiEntityId;
				ControllerBase<CharacterRailSlideController>.Instance.RemoveActiveFollower(aiEntityId);
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(aiEntityId);
				WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
				if (worldEntity == null || !worldEntity.Valid)
				{
					return;
				}
				CharacterRailSlideComponent component = worldEntity.GetComponent<CharacterRailSlideComponent>();
				if (component == null)
				{
					return;
				}
				component.SetExitSplineRailSlide("LevelEventStopRailSlide", true);
				return;
			}
			else
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
				if (entity == null)
				{
					return;
				}
				CharacterRailSlideComponent component2 = entity.GetComponent<CharacterRailSlideComponent>();
				if (component2 == null)
				{
					return;
				}
				component2.SetExitSplineRailSlide("LevelEventStopRailSlide", true);
				return;
			}
		}
	}
}
