using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200515F RID: 20831
	public class RoguelikeRoleAffixDetailToggle : GridProxyAbstract<int>
	{
		// Token: 0x060359CD RID: 219597 RVA: 0x00D775E0 File Offset: 0x00D757E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickExtendToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060359CE RID: 219598 RVA: 0x00D77686 File Offset: 0x00D75886
		private void OnClickExtendToggle(EToggleState toggleState)
		{
			Action<int> onSelectCallback = this.OnSelectCallback;
			if (onSelectCallback == null)
			{
				return;
			}
			onSelectCallback(base.GridIndex);
		}

		// Token: 0x060359CF RID: 219599 RVA: 0x00D776A0 File Offset: 0x00D758A0
		public override void Refresh(int id, bool isSelected, int gridIndex)
		{
			this.Id = id;
			RogueCharacterBuff? rogueCharacterBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterBuffConfig(id);
			if (rogueCharacterBuffConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(rogueCharacterBuffConfig.Value.AffixIcon, base.GetSprite(0), false, null, null);
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060359D0 RID: 219600 RVA: 0x00D7770D File Offset: 0x00D7590D
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060359D1 RID: 219601 RVA: 0x00D77720 File Offset: 0x00D75920
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401ECAD RID: 126125
		public int Id;

		// Token: 0x0401ECAE RID: 126126
		[Nullable(2)]
		public Action<int> OnSelectCallback;

		// Token: 0x0200B10E RID: 45326
		private class EComponent
		{
			// Token: 0x04036EB6 RID: 224950
			public const int SpriteIcon = 0;

			// Token: 0x04036EB7 RID: 224951
			public const int ExtendToggle = 1;
		}
	}
}
