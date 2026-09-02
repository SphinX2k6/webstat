using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054D7 RID: 21719
	[NullableContext(2)]
	[Nullable(0)]
	internal class PhantomArenaMapEntranceDifficultItem : GridProxyAbstract<int>
	{
		// Token: 0x0603752E RID: 226606 RVA: 0x00E09494 File Offset: 0x00E07694
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
			};
		}

		// Token: 0x0603752F RID: 226607 RVA: 0x00E09514 File Offset: 0x00E07714
		private void OnClickItem(EToggleState toggleState)
		{
			if (base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_UnChecked)
			{
				return;
			}
			Action<int> selectCallBack = this.SelectCallBack;
			if (selectCallBack != null)
			{
				selectCallBack(this.Difficult);
			}
			IScrollViewDelegate<IGridProxy<int>, int> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}

		// Token: 0x06037530 RID: 226608 RVA: 0x00E09564 File Offset: 0x00E07764
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(delegate()
			{
				IScrollViewDelegate<IGridProxy<int>, int> scrollViewDelegate = base.ScrollViewDelegate;
				int? num = (scrollViewDelegate != null) ? new int?(scrollViewDelegate.GetSelectedGridIndex()) : null;
				int gridIndex = base.GridIndex;
				return !(num.GetValueOrDefault() == gridIndex & num != null);
			});
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06037531 RID: 226609 RVA: 0x00E09594 File Offset: 0x00E07794
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.Difficult = data;
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(PhantomArenaDefine.difficultNumTextures[data]);
			base.TrySetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			Func<int> getCurrentMapId = this.GetCurrentMapId;
			int? num = (getCurrentMapId != null) ? new int?(getCurrentMapId()) : null;
			bool uiactive = num != null && ModelBase<PhantomArenaModel>.Instance.GetPermanentIsDifficultCompleted(num.Value, this.Difficult);
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06037532 RID: 226610 RVA: 0x00E0962D File Offset: 0x00E0782D
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06037533 RID: 226611 RVA: 0x00E09640 File Offset: 0x00E07840
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06037534 RID: 226612 RVA: 0x00E09653 File Offset: 0x00E07853
		public override object GetKey(int data, int displayIndex)
		{
			return this.Difficult;
		}

		// Token: 0x0401FC86 RID: 130182
		private int Difficult;

		// Token: 0x0401FC87 RID: 130183
		public Action<int> SelectCallBack;

		// Token: 0x0401FC88 RID: 130184
		public Func<int> GetCurrentMapId;

		// Token: 0x0200B447 RID: 46151
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037CAF RID: 228527
			public const int Toggle = 0;

			// Token: 0x04037CB0 RID: 228528
			public const int TexRome = 1;

			// Token: 0x04037CB1 RID: 228529
			public const int Done = 2;
		}
	}
}
