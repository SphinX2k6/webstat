using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E9 RID: 25577
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeOutsideRoleItem : GridProxyAbstract<RoverlikeOutsideRoleData>
	{
		// Token: 0x06040397 RID: 263063 RVA: 0x01075674 File Offset: 0x01073874
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040398 RID: 263064 RVA: 0x0107575C File Offset: 0x0107395C
		public override void Refresh(RoverlikeOutsideRoleData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			base.GridIndex = gridIndex;
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				if (!string.IsNullOrEmpty(data.IconPath))
				{
					base.SetTextureByPath(data.IconPath, texture, null, null);
				}
				UUIItem uuiitem = texture;
				bool bUseChangeColor = !data.Unlocked;
				FColor? fcolor = new FColor?(texture.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(!data.Unlocked);
			}
			Func<RoverlikeOutsideRoleData, int, bool> getHasRedDot = this.GetHasRedDot;
			bool uiactive = (getHasRedDot != null) ? getHasRedDot(data, gridIndex) : data.HasRedDot;
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive);
			}
			Func<RoverlikeOutsideRoleData, int, bool> isGridSelected = this.IsGridSelected;
			bool flag = (isGridSelected != null) ? isGridSelected(data, gridIndex) : isSelected;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06040399 RID: 263065 RVA: 0x0107583D File Offset: 0x01073A3D
		public override void Clear()
		{
			this.CurrentData = null;
		}

		// Token: 0x0604039A RID: 263066 RVA: 0x01075846 File Offset: 0x01073A46
		public override object GetKey(RoverlikeOutsideRoleData data, int displayIndex)
		{
			return data.RoleId;
		}

		// Token: 0x0604039B RID: 263067 RVA: 0x01075854 File Offset: 0x01073A54
		private void OnToggleStateChanged(EToggleState state)
		{
			if (this.CurrentData == null)
			{
				return;
			}
			if (state != EToggleState.ETT_Checked)
			{
				Func<RoverlikeOutsideRoleData, int, bool> isGridSelected = this.IsGridSelected;
				if (isGridSelected != null && isGridSelected(this.CurrentData, base.GridIndex))
				{
					UUIExtendToggle extendToggle = base.GetExtendToggle(0);
					if (extendToggle == null)
					{
						return;
					}
					extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				}
				return;
			}
			Action<RoverlikeOutsideRoleData, int> onClickCb = this.OnClickCb;
			if (onClickCb == null)
			{
				return;
			}
			onClickCb(this.CurrentData, base.GridIndex);
		}

		// Token: 0x04024034 RID: 147508
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoverlikeOutsideRoleData, int> OnClickCb;

		// Token: 0x04024035 RID: 147509
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeOutsideRoleData, int, bool> IsGridSelected;

		// Token: 0x04024036 RID: 147510
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeOutsideRoleData, int, bool> GetHasRedDot;

		// Token: 0x04024037 RID: 147511
		[Nullable(2)]
		private RoverlikeOutsideRoleData CurrentData;

		// Token: 0x0200C44F RID: 50255
		[NullableContext(0)]
		private enum EOutsideRoleComponents
		{
			// Token: 0x0403C6DE RID: 247518
			TogRole,
			// Token: 0x0403C6DF RID: 247519
			TexIcon,
			// Token: 0x0403C6E0 RID: 247520
			PnlLock,
			// Token: 0x0403C6E1 RID: 247521
			PnlRedDot
		}
	}
}
