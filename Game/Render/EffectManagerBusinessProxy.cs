using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004777 RID: 18295
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EffectManagerBusinessProxy : Singleton<EffectManagerBusinessProxy>
	{
		// Token: 0x0602F758 RID: 194392 RVA: 0x00B47D2D File Offset: 0x00B45F2D
		private void EffectReadyCallBack(int handle, string reason)
		{
			if (!Singleton<EffectSystem>.Instance.GetHideOnBurstSkill(handle))
			{
				return;
			}
			this.EffectsDestroyOnBurstSkill.Add(handle);
		}

		// Token: 0x0602F759 RID: 194393 RVA: 0x00B47D4A File Offset: 0x00B45F4A
		private void EffectFinishCallBack(int handle, string reason, bool immediately)
		{
			this.EffectsDestroyOnBurstSkill.Remove(handle);
		}

		// Token: 0x0602F75A RID: 194394 RVA: 0x00B47D59 File Offset: 0x00B45F59
		private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			this.CurrentCharacter = ((baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null);
			TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
			this.CurrentCharacterEntityId = ((baseCharacter2 != null) ? baseCharacter2.GetEntityIdNoBlueprint() : 0);
		}

		// Token: 0x0602F75B RID: 194395 RVA: 0x00B47D8C File Offset: 0x00B45F8C
		private void OnCharUseSkill(int charId, int skillId, bool isAutonomousProxy)
		{
			if (this.CurrentCharacter == null || charId != this.CurrentCharacterEntityId)
			{
				return;
			}
			CharacterSkillComponent component = this.CurrentCharacter.GetComponent<CharacterSkillComponent>();
			SSkillInfo sskillInfo = (component != null) ? component.GetSkillInfo(skillId) : null;
			if (sskillInfo != null && sskillInfo.SkillGenre == ESkillGenre.大招3)
			{
				foreach (int num in this.EffectsDestroyOnBurstSkill)
				{
					if (Singleton<EffectSystem>.Instance.IsValid(num))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.RenderEffect;
						ELogAuthor author = ELogAuthor.LSY;
						string message = "Effect Recycled By Burst";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", Singleton<EffectSystem>.Instance.GetPath(num));
						instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						Singleton<EffectSystem>.Instance.StopEffectById(num, "[EffectManagerBusinessProxy.OnCharUseSkill]", true, null);
					}
				}
			}
		}

		// Token: 0x0602F75C RID: 194396 RVA: 0x00B47E80 File Offset: 0x00B46080
		protected override bool OnInit()
		{
			this.DestroyOnBurstStat = Stat.Create("EffectManagerBusinessProxy_DestroyOnBurst", "", "");
			this.EffectsDestroyOnBurstSkill = new HashSet<int>();
			Singleton<EventSystem>.Instance.Add<int, string>(EEventName.BeforePlayEffect, new Action<int, string>(this.EffectReadyCallBack));
			Singleton<EventSystem>.Instance.Add<int, string, bool>(EEventName.FinishEffect, new Action<int, string, bool>(this.EffectFinishCallBack));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
			return true;
		}

		// Token: 0x0401B1CB RID: 111051
		[Nullable(2)]
		private Stat DestroyOnBurstStat;

		// Token: 0x0401B1CC RID: 111052
		[Nullable(2)]
		private HashSet<int> EffectsDestroyOnBurstSkill;

		// Token: 0x0401B1CD RID: 111053
		[Nullable(2)]
		private Entity CurrentCharacter;

		// Token: 0x0401B1CE RID: 111054
		private int CurrentCharacterEntityId;
	}
}
