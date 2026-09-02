using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.RoleSelect
{
	// Token: 0x020054B9 RID: 21689
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaRoleSkillItem : GridProxyAbstract<PhantomArenaRoleSkillItemData>
	{
		// Token: 0x060373E5 RID: 226277 RVA: 0x00E03BA3 File Offset: 0x00E01DA3
		public PhantomArenaRoleSkillItem()
		{
			base.GridIndex = -1;
		}

		// Token: 0x060373E6 RID: 226278 RVA: 0x00E03BB4 File Offset: 0x00E01DB4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleSelectInternal))
			};
		}

		// Token: 0x060373E7 RID: 226279 RVA: 0x00E03C1C File Offset: 0x00E01E1C
		[NullableContext(1)]
		public override void Refresh(PhantomArenaRoleSkillItemData data, bool isSelected, int gridIndex)
		{
			base.GridIndex = gridIndex;
			this.Data = data;
			base.SetTextureByPath(data.IconPath, base.GetTexture(1), null, null);
			this.SetSelected(isSelected);
		}

		// Token: 0x060373E8 RID: 226280 RVA: 0x00E03C5B File Offset: 0x00E01E5B
		private void OnToggleSelectInternal(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> onToggleSelect = this.OnToggleSelect;
				if (onToggleSelect == null)
				{
					return;
				}
				onToggleSelect(base.GridIndex);
			}
		}

		// Token: 0x060373E9 RID: 226281 RVA: 0x00E03C77 File Offset: 0x00E01E77
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060373EA RID: 226282 RVA: 0x00E03C8F File Offset: 0x00E01E8F
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060373EB RID: 226283 RVA: 0x00E03CA7 File Offset: 0x00E01EA7
		public void SetSelected(bool isSelected)
		{
			if (this.IsSelected == isSelected)
			{
				return;
			}
			this.IsSelected = isSelected;
			if (this.IsSelected)
			{
				this.OnSelected(false);
				return;
			}
			this.OnDeselected(false);
		}

		// Token: 0x0401FC26 RID: 130086
		protected bool IsSelected;

		// Token: 0x0401FC27 RID: 130087
		protected PhantomArenaRoleSkillItemData Data;

		// Token: 0x0401FC28 RID: 130088
		public Action<int> OnToggleSelect;

		// Token: 0x0200B426 RID: 46118
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037BE8 RID: 228328
			public const int ItemToggle = 0;

			// Token: 0x04037BE9 RID: 228329
			public const int SkillTexture = 1;
		}
	}
}
