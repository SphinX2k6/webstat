using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DDB RID: 24027
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class DangoItem : GridProxyAbstract<DangoAbyssDefine.DangoListRoleData>
	{
		// Token: 0x0603C7C2 RID: 247746 RVA: 0x00F5C760 File Offset: 0x00F5A960
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C7C3 RID: 247747 RVA: 0x00F5C88A File Offset: 0x00F5AA8A
		private void OnToggleClick(EToggleState toggleState)
		{
			this.CurrentData.OnClickCallBack(this.CurrentData);
		}

		// Token: 0x0603C7C4 RID: 247748 RVA: 0x00F5C8A4 File Offset: 0x00F5AAA4
		[NullableContext(1)]
		public override void Refresh(DangoAbyssDefine.DangoListRoleData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			bool flag = this.ViewModel.GetDangoId() == this.CurrentData.Id;
			bool ifLock = data.Data.GetIfLock();
			EToggleState state = flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
			base.GetItem(5).SetUIActive(ifLock);
			base.GetItem(4).SetUIActive(!ifLock);
			base.GetItem(2).SetUIActive(ifLock);
			UUITexture texture = base.GetTexture(1);
			base.SetTextureByPath(data.Data.GetTexture(), texture, null, null);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = ifLock;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			this.BindRedDot();
		}

		// Token: 0x0603C7C5 RID: 247749 RVA: 0x00F5C960 File Offset: 0x00F5AB60
		private void BindRedDot()
		{
			this.UnBindRedDot();
			if (!this.HasBindRedDot && this.CurrentData != null)
			{
				UUIItem item = base.GetItem(3);
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotDangoRole, item, null, this.CurrentData.Id);
			}
		}

		// Token: 0x0603C7C6 RID: 247750 RVA: 0x00F5C9A8 File Offset: 0x00F5ABA8
		private void UnBindRedDot()
		{
			this.HasBindRedDot = false;
			if (this.HasBindRedDot && this.CurrentData != null)
			{
				UUIItem item = base.GetItem(3);
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotDangoRole, item, this.CurrentData.Id);
			}
		}

		// Token: 0x0603C7C7 RID: 247751 RVA: 0x00F5C9EF File Offset: 0x00F5ABEF
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0402201C RID: 139292
		private DangoAbyssDefine.DangoListRoleData CurrentData;

		// Token: 0x0402201D RID: 139293
		public PluginEquipViewModel ViewModel;

		// Token: 0x0402201E RID: 139294
		private bool HasBindRedDot;

		// Token: 0x0200BE34 RID: 48692
		[NullableContext(0)]
		private class EDangoItemComponent
		{
			// Token: 0x0403A8E5 RID: 239845
			public const int Toggle = 0;

			// Token: 0x0403A8E6 RID: 239846
			public const int Texture = 1;

			// Token: 0x0403A8E7 RID: 239847
			public const int LockItem = 2;

			// Token: 0x0403A8E8 RID: 239848
			public const int ItemRedDot = 3;

			// Token: 0x0403A8E9 RID: 239849
			public const int PanelUnlock = 4;

			// Token: 0x0403A8EA RID: 239850
			public const int PanelLock = 5;
		}
	}
}
