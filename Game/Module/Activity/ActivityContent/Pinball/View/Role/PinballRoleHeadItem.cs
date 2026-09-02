using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D6 RID: 26070
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballRoleHeadItem : GridProxyAbstract<IPinballRoleHeadItemData>
	{
		// Token: 0x06041211 RID: 266769 RVA: 0x010B5530 File Offset: 0x010B3730
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041212 RID: 266770 RVA: 0x010B565A File Offset: 0x010B385A
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChangeInternal));
		}

		// Token: 0x06041213 RID: 266771 RVA: 0x010B567C File Offset: 0x010B387C
		public override void Refresh(IPinballRoleHeadItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshSelectState(true);
			this.RefreshHeadTexture();
			this.RefreshLockState();
			this.RefreshTrailState();
			if (this.Data.NeedRedDot)
			{
				this.UnBindRedDot();
				this.BindRedDot();
				return;
			}
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06041214 RID: 266772 RVA: 0x010B56D8 File Offset: 0x010B38D8
		public void RefreshSelectState(bool bJumpToLastFrame)
		{
			IPinballRoleHeadItemData data = this.Data;
			EToggleState state = (data != null && data.IsSelected) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, false, false, bJumpToLastFrame);
		}

		// Token: 0x06041215 RID: 266773 RVA: 0x010B5710 File Offset: 0x010B3910
		public void RefreshHeadTexture()
		{
			if (this.Data == null)
			{
				return;
			}
			string middleIcon = this.Data.RoleConfig.MiddleIcon;
			base.SetTextureByPath(middleIcon, base.GetTexture(1), null, null);
			base.SetTextureByPath(middleIcon, base.GetTexture(2), null, null);
		}

		// Token: 0x06041216 RID: 266774 RVA: 0x010B576C File Offset: 0x010B396C
		public void RefreshLockState()
		{
			if (this.Data == null)
			{
				return;
			}
			bool isLocked = this.Data.IsLocked;
			base.GetItem(3).SetUIActive(isLocked);
			UUITexture texture = base.GetTexture(1);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = isLocked;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUITexture texture2 = base.GetTexture(2);
			UUIItem uuiitem2 = texture2;
			bool bUseChangeColor2 = isLocked;
			fcolor = new FColor?(texture2.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		}

		// Token: 0x06041217 RID: 266775 RVA: 0x010B57D5 File Offset: 0x010B39D5
		public void RefreshTrailState()
		{
			if (this.Data == null)
			{
				return;
			}
			base.GetItem(5).SetUIActive(this.Data.IsTrail);
		}

		// Token: 0x06041218 RID: 266776 RVA: 0x010B57F8 File Offset: 0x010B39F8
		public void BindRedDot()
		{
			if (this.Data == null)
			{
				return;
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPinballRole, base.GetItem(4), null, this.Data.RoleConfig.Id);
		}

		// Token: 0x06041219 RID: 266777 RVA: 0x010B5838 File Offset: 0x010B3A38
		public void UnBindRedDot()
		{
			if (this.Data == null)
			{
				return;
			}
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPinballRole, base.GetItem(4), 0);
		}

		// Token: 0x0604121A RID: 266778 RVA: 0x010B585A File Offset: 0x010B3A5A
		private bool CanExecuteChangeInternal()
		{
			return this.Data != null && (base.GetExtendToggle(0).GetToggleState() != EToggleState.ETT_Checked || !this.Data.IsSelected);
		}

		// Token: 0x0604121B RID: 266779 RVA: 0x010B5885 File Offset: 0x010B3A85
		private void OnToggleStateChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<IPinballRoleHeadItemData> onSelectCallBack = this.OnSelectCallBack;
				if (onSelectCallBack == null)
				{
					return;
				}
				onSelectCallBack(this.Data);
			}
		}

		// Token: 0x0604121C RID: 266780 RVA: 0x010B58A1 File Offset: 0x010B3AA1
		protected override void OnDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0604121D RID: 266781 RVA: 0x010B58AC File Offset: 0x010B3AAC
		public override object GetKey(IPinballRoleHeadItemData data, int displayIndex)
		{
			return data.RoleConfig.Id;
		}

		// Token: 0x040247A7 RID: 149415
		[Nullable(2)]
		private IPinballRoleHeadItemData Data;

		// Token: 0x040247A8 RID: 149416
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IPinballRoleHeadItemData> OnSelectCallBack;

		// Token: 0x0200C5D5 RID: 50645
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CE4D RID: 249421
			ItemToggle,
			// Token: 0x0403CE4E RID: 249422
			UnSelectedHeadTexture,
			// Token: 0x0403CE4F RID: 249423
			SelectedHeadTexture,
			// Token: 0x0403CE50 RID: 249424
			LockItem,
			// Token: 0x0403CE51 RID: 249425
			RedDotItem,
			// Token: 0x0403CE52 RID: 249426
			TrailItem
		}
	}
}
