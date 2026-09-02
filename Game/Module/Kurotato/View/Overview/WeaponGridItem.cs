using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.View.Components;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA5 RID: 23205
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class WeaponGridItem : SyncGridProxyAbstract<IKurotatoMediumItemGridData>
	{
		// Token: 0x0603AB36 RID: 240438 RVA: 0x00EE0E84 File Offset: 0x00EDF084
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB37 RID: 240439 RVA: 0x00EE0EED File Offset: 0x00EDF0ED
		protected override void OnStart()
		{
			this.GridItem.CreateThenShowByActor(base.GetItem(0).GetOwner());
		}

		// Token: 0x0603AB38 RID: 240440 RVA: 0x00EE0F08 File Offset: 0x00EDF108
		public void SetSelected(bool selected, bool force = false)
		{
			this.GridItem.Refresh(this.Data, null);
			this.GridItem.SetSelected(selected, force);
		}

		// Token: 0x0603AB39 RID: 240441 RVA: 0x00EE0F3C File Offset: 0x00EDF13C
		public override void Refresh(IKurotatoMediumItemGridData data)
		{
			this.Data = data;
			bool flag = data.Type == EKurotatoCardType.None;
			base.GetItem(0).SetUIActive(!flag);
			base.GetItem(1).SetUIActive(flag);
			if (flag)
			{
				this.SetSelected(false, true);
				return;
			}
			this.GridItem.Refresh(data, null);
			Func<IKurotatoMediumItemGridData, bool> isSelectedCb = this.IsSelectedCb;
			this.SetSelected(isSelectedCb != null && isSelectedCb(data), true);
			this.GridItem.BindCallback(delegate(EToggleState state)
			{
				Action<bool> onClickCb = this.OnClickCb;
				if (onClickCb == null)
				{
					return;
				}
				onClickCb(state == EToggleState.ETT_Checked);
			});
		}

		// Token: 0x04021307 RID: 135943
		public IKurotatoMediumItemGridData Data;

		// Token: 0x04021308 RID: 135944
		private readonly KurotatoWeaponMediumItemGrid GridItem = new KurotatoWeaponMediumItemGrid();

		// Token: 0x04021309 RID: 135945
		[Nullable(2)]
		public Action<bool> OnClickCb;

		// Token: 0x0402130A RID: 135946
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<IKurotatoMediumItemGridData, bool> IsSelectedCb;

		// Token: 0x0200BAA8 RID: 47784
		[NullableContext(0)]
		private enum EGridComp
		{
			// Token: 0x04039A13 RID: 236051
			GridItem,
			// Token: 0x04039A14 RID: 236052
			PanelEmpty
		}
	}
}
