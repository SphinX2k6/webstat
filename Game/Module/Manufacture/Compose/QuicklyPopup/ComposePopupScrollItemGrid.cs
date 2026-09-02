using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup
{
	// Token: 0x020059CF RID: 22991
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ComposePopupScrollItemGrid : GridProxyAbstract<ISelectedData>
	{
		// Token: 0x0603A41D RID: 238621 RVA: 0x00EC4624 File Offset: 0x00EC2824
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

		// Token: 0x0603A41E RID: 238622 RVA: 0x00EC4690 File Offset: 0x00EC2890
		protected override UniTask OnBeforeStartAsync()
		{
			ComposePopupScrollItemGrid.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComposePopupScrollItemGrid.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A41F RID: 238623 RVA: 0x00EC46D3 File Offset: 0x00EC28D3
		protected override void OnStart()
		{
			ComposePopupMediumItemGrid composeItemGrid = this.ComposeItemGrid;
			if (composeItemGrid == null)
			{
				return;
			}
			composeItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		}

		// Token: 0x0603A420 RID: 238624 RVA: 0x00EC4704 File Offset: 0x00EC2904
		public override void Refresh(ISelectedData data, bool isSelected, int gridIndex)
		{
			if (data.ItemId == -1)
			{
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(0);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item3 = base.GetItem(1);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				UUIItem item4 = base.GetItem(0);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				ComposePopupMediumItemGrid composeItemGrid = this.ComposeItemGrid;
				if (composeItemGrid != null)
				{
					composeItemGrid.Refresh(data, isSelected, gridIndex);
				}
				ComposePopupMediumItemGrid composeItemGrid2 = this.ComposeItemGrid;
				if (composeItemGrid2 == null)
				{
					return;
				}
				composeItemGrid2.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
				{
					Action<ISelectedData> onToggleCallback = this.OnToggleCallback;
					if (onToggleCallback == null)
					{
						return;
					}
					onToggleCallback(data);
				});
				return;
			}
		}

		// Token: 0x0402103F RID: 135231
		[Nullable(2)]
		private ComposePopupMediumItemGrid ComposeItemGrid;

		// Token: 0x04021040 RID: 135232
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ISelectedData> OnToggleCallback;
	}
}
