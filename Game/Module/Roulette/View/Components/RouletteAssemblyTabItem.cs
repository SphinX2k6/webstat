using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View.Components
{
	// Token: 0x0200501E RID: 20510
	[NullableContext(1)]
	[Nullable(0)]
	public class RouletteAssemblyTabItem : UiPanelBase
	{
		// Token: 0x06034DC7 RID: 216519 RVA: 0x00D46210 File Offset: 0x00D44410
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034DC8 RID: 216520 RVA: 0x00D46279 File Offset: 0x00D44479
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<RouletteAssemblyTab, int>(base.GetHorizontalLayout(0), new Func<RouletteAssemblyTab>(this.CreateTabItem), null, false, true);
		}

		// Token: 0x06034DC9 RID: 216521 RVA: 0x00D4629C File Offset: 0x00D4449C
		private RouletteAssemblyTab CreateTabItem()
		{
			return new RouletteAssemblyTab
			{
				ToggleCallBack = new Action<int, bool>(this.OnClickToggle)
			};
		}

		// Token: 0x06034DCA RID: 216522 RVA: 0x00D462B8 File Offset: 0x00D444B8
		private void OnClickToggle(int typeId, bool bSelected)
		{
			if (!bSelected)
			{
				return;
			}
			if (this.SelectedTypeId == typeId)
			{
				return;
			}
			if (this.SelectedTypeId != -1)
			{
				this.Layout.GetLayoutItemByKey(this.SelectedTypeId).SetToggleState(false, false);
			}
			this.SelectedTypeId = typeId;
			Action<int> toggleCallBack = this.ToggleCallBack;
			if (toggleCallBack == null)
			{
				return;
			}
			toggleCallBack(typeId);
		}

		// Token: 0x06034DCB RID: 216523 RVA: 0x00D46314 File Offset: 0x00D44514
		public UniTask Refresh(int[] typeIdList)
		{
			RouletteAssemblyTabItem.<Refresh>d__7 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.typeIdList = typeIdList;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<RouletteAssemblyTabItem.<Refresh>d__7>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x06034DCC RID: 216524 RVA: 0x00D4635F File Offset: 0x00D4455F
		public void SelectTab(int selectTypeId)
		{
			this.Layout.GetLayoutItemByKey(selectTypeId).SetToggleState(true, true);
		}

		// Token: 0x0401E780 RID: 124800
		public int SelectedTypeId = -1;

		// Token: 0x0401E781 RID: 124801
		[Nullable(2)]
		public Action<int> ToggleCallBack;

		// Token: 0x0401E782 RID: 124802
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RouletteAssemblyTab, int> Layout;
	}
}
