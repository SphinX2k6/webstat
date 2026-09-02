using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005517 RID: 21783
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CollectCardDetailTabItem : GridProxyAbstract<CollectCardDetailViewTabData>
	{
		// Token: 0x06037913 RID: 227603 RVA: 0x00E18B48 File Offset: 0x00E16D48
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemToggleStateChange))
			};
		}

		// Token: 0x06037914 RID: 227604 RVA: 0x00E18BAF File Offset: 0x00E16DAF
		private void OnItemToggleStateChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<ECollectCardDetailViewTab> callbackOnClick = this.CallbackOnClick;
				if (callbackOnClick == null)
				{
					return;
				}
				callbackOnClick(this.Data.Index);
			}
		}

		// Token: 0x06037915 RID: 227605 RVA: 0x00E18BD0 File Offset: 0x00E16DD0
		public override void Refresh(CollectCardDetailViewTabData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.NameId, Array.Empty<object>());
		}

		// Token: 0x06037916 RID: 227606 RVA: 0x00E18BF5 File Offset: 0x00E16DF5
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06037917 RID: 227607 RVA: 0x00E18C08 File Offset: 0x00E16E08
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06037918 RID: 227608 RVA: 0x00E18C1B File Offset: 0x00E16E1B
		public override object GetKey(CollectCardDetailViewTabData data, int displayIndex)
		{
			return data.Index;
		}

		// Token: 0x0401FDD4 RID: 130516
		private CollectCardDetailViewTabData Data;

		// Token: 0x0401FDD5 RID: 130517
		public Action<ECollectCardDetailViewTab> CallbackOnClick;

		// Token: 0x0200B4A6 RID: 46246
		[NullableContext(0)]
		private static class ETabComponents
		{
			// Token: 0x04037EBD RID: 229053
			public const int ItemToggle = 0;

			// Token: 0x04037EBE RID: 229054
			public const int NameText = 1;
		}
	}
}
