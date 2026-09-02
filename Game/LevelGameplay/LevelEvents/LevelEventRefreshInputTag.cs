using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD1 RID: 27601
	public class LevelEventRefreshInputTag : LevelEventBase
	{
		// Token: 0x06044083 RID: 278659 RVA: 0x011A5674 File Offset: 0x011A3874
		public LevelEventRefreshInputTag(int id) : base(id)
		{
		}

		// Token: 0x06044084 RID: 278660 RVA: 0x011A5680 File Offset: 0x011A3880
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ControllerBase<InputController>.Instance.SetMoveControlEnabled(true, true, true, true);
			Singleton<LevelEventLockInputState>.Instance.Unlock();
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity;
			if (baseCharacter == null)
			{
				entity = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			Entity entity2 = entity;
			int num = GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"];
			if (entity2 != null && entity2.Valid)
			{
				BaseTagComponent component = entity2.GetComponent<BaseTagComponent>();
				if (component != null && component.HasTag(num))
				{
					component.RemoveTag(new int?(num));
				}
			}
		}

		// Token: 0x06044085 RID: 278661 RVA: 0x011A5708 File Offset: 0x011A3908
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.UnLimitPlayerOperation
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, null);
		}
	}
}
