using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D1 RID: 25041
	[NullableContext(1)]
	[Nullable(0)]
	public class GuQinActivityMainViewSubToggleItem : UiPanelBase
	{
		// Token: 0x0603F2FB RID: 258811 RVA: 0x010387A4 File Offset: 0x010369A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F2FC RID: 258812 RVA: 0x010388EF File Offset: 0x01036AEF
		protected override void OnStart()
		{
			base.GetExtendToggle(0).bLockStateOnSelect = true;
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteCallback));
			this.SetToggleState(EToggleState.ETT_UnChecked, true);
		}

		// Token: 0x0603F2FD RID: 258813 RVA: 0x01038923 File Offset: 0x01036B23
		private bool CanExecuteCallback()
		{
			if (this.Data.GetStatus() == EGuQinActivityTaskStatus.Lock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(this.Data.GetLockTip());
				return false;
			}
			return true;
		}

		// Token: 0x0603F2FE RID: 258814 RVA: 0x0103894A File Offset: 0x01036B4A
		private void OnToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_UnChecked)
			{
				return;
			}
			this.SelectCallback(this, this.Data);
		}

		// Token: 0x0603F2FF RID: 258815 RVA: 0x01038962 File Offset: 0x01036B62
		public void SetToggleState(EToggleState state, bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleStateForce(state, fireEvent, false, false);
		}

		// Token: 0x0603F300 RID: 258816 RVA: 0x01038974 File Offset: 0x01036B74
		public void Refresh(GuQinActivityTaskData data)
		{
			this.Data = data;
			GuQinActivityTask config = data.GetConfig();
			string text = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? config.FemaleTabBgPath : config.TabBgPath;
			if (!StringUtils.IsBlank(text))
			{
				base.TrySetTextureByPath(text, base.GetTexture(1), null, null);
			}
			if (!StringUtils.IsBlank(config.TabNumTexturePath))
			{
				base.TrySetTextureByPath(config.TabNumTexturePath, base.GetTexture(2), null, null);
			}
			if (!StringUtils.IsBlank(config.TabNumTxt))
			{
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), config.TabNumTxt, Array.Empty<object>());
			}
			EGuQinActivityTaskStatus status = data.GetStatus();
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(status == EGuQinActivityTaskStatus.Lock);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(status == EGuQinActivityTaskStatus.Completed);
			}
			UUIItem item3 = base.GetItem(5);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(data.GetIsRedDot());
		}

		// Token: 0x0603F301 RID: 258817 RVA: 0x01038A70 File Offset: 0x01036C70
		public void RefreshRedDot()
		{
			if (this.Data == null)
			{
				return;
			}
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.Data.GetIsRedDot());
		}

		// Token: 0x040237D4 RID: 145364
		public GuQinActivityTaskData Data;

		// Token: 0x040237D5 RID: 145365
		public Action<GuQinActivityMainViewSubToggleItem, GuQinActivityTaskData> SelectCallback;

		// Token: 0x0200C310 RID: 49936
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C203 RID: 246275
			public const int Toggle = 0;

			// Token: 0x0403C204 RID: 246276
			public const int TexIcon = 1;

			// Token: 0x0403C205 RID: 246277
			public const int TexNum = 2;

			// Token: 0x0403C206 RID: 246278
			public const int TextDay = 3;

			// Token: 0x0403C207 RID: 246279
			public const int PnlLock = 4;

			// Token: 0x0403C208 RID: 246280
			public const int RedDot = 5;

			// Token: 0x0403C209 RID: 246281
			public const int PnlDone = 6;
		}
	}
}
