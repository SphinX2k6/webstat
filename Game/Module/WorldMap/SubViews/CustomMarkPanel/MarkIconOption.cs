using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CustomMarkPanel
{
	// Token: 0x02004BC6 RID: 19398
	public class MarkIconOption : UiPanelBase
	{
		// Token: 0x170086F5 RID: 34549
		// (get) Token: 0x06032A15 RID: 207381 RVA: 0x00CAEE45 File Offset: 0x00CAD045
		// (set) Token: 0x06032A16 RID: 207382 RVA: 0x00CAEE4D File Offset: 0x00CAD04D
		public CustomMark? Config { get; set; }

		// Token: 0x06032A17 RID: 207383 RVA: 0x00CAEE58 File Offset: 0x00CAD058
		[NullableContext(1)]
		public void Initialize(UUIItem item, UUIItem parent, CustomMark config)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			this.ParentMarkUi = parent;
			AActor owner = item.GetOwner();
			item.SetUIActive(true);
			base.CreateThenShowByActor(owner, null);
			this.Config = new CustomMark?(config);
			this.SetSpriteByPath(this.Config.Value.MarkPic, base.GetSprite(0), false, null, null);
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetRaycastTarget(true);
		}

		// Token: 0x06032A18 RID: 207384 RVA: 0x00CAEED8 File Offset: 0x00CAD0D8
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
		}

		// Token: 0x06032A19 RID: 207385 RVA: 0x00CAEF41 File Offset: 0x00CAD141
		protected override void OnStart()
		{
			base.GetExtendToggle(1).SetToggleGroup(this.ParentMarkUi.GetOwner());
			base.GetExtendToggle(1).bLockStateOnSelect = true;
		}

		// Token: 0x06032A1A RID: 207386 RVA: 0x00CAEF67 File Offset: 0x00CAD167
		[NullableContext(1)]
		public void SetOnclick(Action<EToggleState> fn)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			extendToggle.OnStateChange.Clear();
			extendToggle.OnStateChange.Add(fn);
		}

		// Token: 0x06032A1B RID: 207387 RVA: 0x00CAEF86 File Offset: 0x00CAD186
		public void SetToggleChecked()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x06032A1C RID: 207388 RVA: 0x00CAEF9E File Offset: 0x00CAD19E
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Clear();
		}

		// Token: 0x0401D7FE RID: 120830
		[Nullable(2)]
		private UUIItem ParentMarkUi;

		// Token: 0x0200ACAC RID: 44204
		public static class EMarkOptionsComponents
		{
			// Token: 0x04035A52 RID: 219730
			public const int Icon = 0;

			// Token: 0x04035A53 RID: 219731
			public const int Toggle = 1;
		}
	}
}
