using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DCC RID: 28108
	public class LevelConditionOnSkillButtonDataRefresh : LevelConditionBase
	{
		// Token: 0x060445E1 RID: 280033 RVA: 0x011C2EE0 File Offset: 0x011C10E0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			string limitParams = inConditionInfo.GetLimitParams(LevelConditionOnSkillButtonDataRefresh.EArgsType.ActionType.ToEnumString());
			if (limitParams == null)
			{
				return false;
			}
			if (eventArgs.Length == 0)
			{
				return false;
			}
			int num = (int)eventArgs[0];
			if (this.LastViewId != num)
			{
				this.LastViewId = num;
				this.LastIndex = -1;
				this.LastSkillId = -1;
			}
			int num2 = int.Parse(limitParams);
			int skillButtonIndexByButton = instance.GetSkillButtonIndexByButton(num2);
			SkillButtonData skillButtonDataByButton = instance.GetSkillButtonDataByButton((ESkillButtonType)num2);
			int? num3 = (skillButtonDataByButton != null) ? new int?(skillButtonDataByButton.GetSkillId()) : null;
			if (this.LastIndex == -1 && this.LastSkillId == -1)
			{
				this.LastIndex = skillButtonIndexByButton;
				this.LastSkillId = num3.GetValueOrDefault(-1);
				return true;
			}
			if (this.LastIndex == skillButtonIndexByButton)
			{
				int lastSkillId = this.LastSkillId;
				int? num4 = num3;
				return lastSkillId == num4.GetValueOrDefault() & num4 != null;
			}
			return false;
		}

		// Token: 0x040260F6 RID: 155894
		private int LastIndex = -1;

		// Token: 0x040260F7 RID: 155895
		private int LastSkillId = -1;

		// Token: 0x040260F8 RID: 155896
		private int LastViewId = -1;

		// Token: 0x0200CB1D RID: 51997
		[EnumExtensions]
		public enum EArgsType
		{
			// Token: 0x0403E584 RID: 255364
			[EnumStringMember("skillId")]
			ActionType
		}
	}
}
