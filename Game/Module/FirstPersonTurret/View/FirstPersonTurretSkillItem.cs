using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.SkillButtonUi;

namespace CSharpScript.Game.Module.FirstPersonTurret.View
{
	// Token: 0x02005D81 RID: 23937
	[NullableContext(2)]
	[Nullable(0)]
	public class FirstPersonTurretSkillItem : BattleSkillItem
	{
		// Token: 0x0603C465 RID: 246885 RVA: 0x00F4B1F4 File Offset: 0x00F493F4
		public override void Initialize(object param = null)
		{
			FirstPersonTurretSkillItemParam firstPersonTurretSkillItemParam = param as FirstPersonTurretSkillItemParam;
			if (firstPersonTurretSkillItemParam != null)
			{
				this.TurretButtonType = new ESkillButtonType?(firstPersonTurretSkillItemParam.ButtonType);
				base.Initialize(firstPersonTurretSkillItemParam.InputIndex);
				return;
			}
			this.TurretButtonType = null;
			base.Initialize(param);
		}

		// Token: 0x0603C466 RID: 246886 RVA: 0x00F4B241 File Offset: 0x00F49441
		public override void Refresh(ISkillButtonData skillButtonData)
		{
			base.Refresh(skillButtonData);
			this.DisableActionInput();
		}

		// Token: 0x0603C467 RID: 246887 RVA: 0x00F4B250 File Offset: 0x00F49450
		public override void RefreshKey()
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.SetActive(false);
		}

		// Token: 0x0603C468 RID: 246888 RVA: 0x00F4B263 File Offset: 0x00F49463
		public override void Reset()
		{
			this.RestoreActionInput();
			base.Reset();
		}

		// Token: 0x0603C469 RID: 246889 RVA: 0x00F4B271 File Offset: 0x00F49471
		public ESkillButtonType? GetTurretButtonType()
		{
			return this.TurretButtonType;
		}

		// Token: 0x0603C46A RID: 246890 RVA: 0x00F4B27C File Offset: 0x00F4947C
		public void RestoreActionInput()
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController != null)
			{
				foreach (string actionName in this.DisabledActionNameSet)
				{
					characterController.SetActionEnable(actionName, true);
				}
			}
			this.DisabledActionNameSet.Clear();
		}

		// Token: 0x0603C46B RID: 246891 RVA: 0x00F4B2E4 File Offset: 0x00F494E4
		private void DisableActionInput()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			string text = (skillButtonData != null) ? skillButtonData.GetActionName() : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			TsCharacterController characterController = Global.CharacterController;
			if (characterController != null)
			{
				characterController.SetActionEnable(text, false);
			}
			this.DisabledActionNameSet.Add(text);
		}

		// Token: 0x04021E4E RID: 138830
		private ESkillButtonType? TurretButtonType;

		// Token: 0x04021E4F RID: 138831
		[Nullable(1)]
		private readonly HashSet<string> DisabledActionNameSet = new HashSet<string>();
	}
}
