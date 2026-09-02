using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.HandBook
{
	// Token: 0x02005ABC RID: 23228
	public class KurotatoHandBookWeaponViewTabItem : GridProxyAbstract<EKurotatoCardType>
	{
		// Token: 0x0603ABB9 RID: 240569 RVA: 0x00EE3C9C File Offset: 0x00EE1E9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ABBA RID: 240570 RVA: 0x00EE3D64 File Offset: 0x00EE1F64
		public override void Refresh(EKurotatoCardType tabType, bool isSelected, int gridIndex)
		{
			this.TabType = tabType;
			string textStringId = KurotatoDefine.KurotatoHandBookTabName[tabType];
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
			this.UnBindRedDot();
			this.BindRedDot();
		}

		// Token: 0x0603ABBB RID: 240571 RVA: 0x00EE3DA7 File Offset: 0x00EE1FA7
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0603ABBC RID: 240572 RVA: 0x00EE3DB0 File Offset: 0x00EE1FB0
		private void BindRedDot()
		{
			ERedDotName name = (this.TabType == EKurotatoCardType.Weapon) ? ERedDotName.RedDotKurotatoWeapon : ERedDotName.RedDotKurotatoProp;
			ControllerBase<RedDotController>.Instance.BindRedDot(name, base.GetItem(2), null, 0);
		}

		// Token: 0x0603ABBD RID: 240573 RVA: 0x00EE3DE8 File Offset: 0x00EE1FE8
		private void UnBindRedDot()
		{
			ERedDotName name = (this.TabType == EKurotatoCardType.Weapon) ? ERedDotName.RedDotKurotatoWeapon : ERedDotName.RedDotKurotatoProp;
			ControllerBase<RedDotController>.Instance.UnBindRedDot(name);
		}

		// Token: 0x0603ABBE RID: 240574 RVA: 0x00EE3E18 File Offset: 0x00EE2018
		public void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x0603ABBF RID: 240575 RVA: 0x00EE3E3E File Offset: 0x00EE203E
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true);
		}

		// Token: 0x0603ABC0 RID: 240576 RVA: 0x00EE3E47 File Offset: 0x00EE2047
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false);
		}

		// Token: 0x0603ABC1 RID: 240577 RVA: 0x00EE3E50 File Offset: 0x00EE2050
		private void OnClickToggle(EToggleState state)
		{
			Action<EKurotatoCardType> onToggleCallBack = this.OnToggleCallBack;
			if (onToggleCallBack == null)
			{
				return;
			}
			onToggleCallBack(this.TabType);
		}

		// Token: 0x0402135A RID: 136026
		private EKurotatoCardType TabType;

		// Token: 0x0402135B RID: 136027
		[Nullable(2)]
		public Action<EKurotatoCardType> OnToggleCallBack;

		// Token: 0x0200BAD0 RID: 47824
		private enum EComponents
		{
			// Token: 0x04039AA7 RID: 236199
			ToggleRoot,
			// Token: 0x04039AA8 RID: 236200
			TextTabName,
			// Token: 0x04039AA9 RID: 236201
			ItemRedDot
		}
	}
}
