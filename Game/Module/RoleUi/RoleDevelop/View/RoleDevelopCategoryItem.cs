using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050AF RID: 20655
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopCategoryItem : GridProxyAbstract<RoleDevelopCategoryData>
	{
		// Token: 0x17008C08 RID: 35848
		// (get) Token: 0x0603538C RID: 217996 RVA: 0x00D577A0 File Offset: 0x00D559A0
		public ERoleDevelopCategoryType CategoryType
		{
			get
			{
				return this.Data.CategoryType;
			}
		}

		// Token: 0x0603538D RID: 217997 RVA: 0x00D577B0 File Offset: 0x00D559B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603538E RID: 217998 RVA: 0x00D57898 File Offset: 0x00D55A98
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
		}

		// Token: 0x0603538F RID: 217999 RVA: 0x00D578B7 File Offset: 0x00D55AB7
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06035390 RID: 218000 RVA: 0x00D578C9 File Offset: 0x00D55AC9
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06035391 RID: 218001 RVA: 0x00D578DB File Offset: 0x00D55ADB
		public override void Refresh(RoleDevelopCategoryData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.CategoryName, Array.Empty<object>());
		}

		// Token: 0x06035392 RID: 218002 RVA: 0x00D57900 File Offset: 0x00D55B00
		public void RefreshHint(bool isShowUpgrade, bool isShowFinish)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(isShowUpgrade);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(isShowFinish);
		}

		// Token: 0x06035393 RID: 218003 RVA: 0x00D57927 File Offset: 0x00D55B27
		public override object GetKey(RoleDevelopCategoryData data, int gridIndex)
		{
			return data.CategoryType;
		}

		// Token: 0x06035394 RID: 218004 RVA: 0x00D57934 File Offset: 0x00D55B34
		public void SetToggleCallback(Action<RoleDevelopCategoryData> callback)
		{
			this.ToggleCallback = callback;
		}

		// Token: 0x06035395 RID: 218005 RVA: 0x00D5793D File Offset: 0x00D55B3D
		public void SetCanExecuteCallback(Func<RoleDevelopCategoryData, bool> callback)
		{
			this.CanExecuteCallback = callback;
		}

		// Token: 0x06035396 RID: 218006 RVA: 0x00D57946 File Offset: 0x00D55B46
		private bool OnCanExecuteChange()
		{
			Func<RoleDevelopCategoryData, bool> canExecuteCallback = this.CanExecuteCallback;
			return canExecuteCallback == null || canExecuteCallback(this.Data);
		}

		// Token: 0x06035397 RID: 218007 RVA: 0x00D5795F File Offset: 0x00D55B5F
		private void OnClickToggle(EToggleState state)
		{
			Action<RoleDevelopCategoryData> toggleCallback = this.ToggleCallback;
			if (toggleCallback == null)
			{
				return;
			}
			toggleCallback(this.Data);
		}

		// Token: 0x0401EA1D RID: 125469
		private RoleDevelopCategoryData Data;

		// Token: 0x0401EA1E RID: 125470
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<RoleDevelopCategoryData> ToggleCallback;

		// Token: 0x0401EA1F RID: 125471
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<RoleDevelopCategoryData, bool> CanExecuteCallback;

		// Token: 0x0200B038 RID: 45112
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036AB0 RID: 223920
			public const int Toggle = 0;

			// Token: 0x04036AB1 RID: 223921
			public const int NameTxt = 1;

			// Token: 0x04036AB2 RID: 223922
			public const int UpItem = 2;

			// Token: 0x04036AB3 RID: 223923
			public const int FinishItem = 3;
		}
	}
}
