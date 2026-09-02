using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D3 RID: 26067
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballRoleClassItem : GridProxyAbstract<IPinballRoleClassItemData>
	{
		// Token: 0x060411F8 RID: 266744 RVA: 0x010B53C8 File Offset: 0x010B35C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060411F9 RID: 266745 RVA: 0x010B5434 File Offset: 0x010B3634
		protected override UniTask OnBeforeStartAsync()
		{
			PinballRoleClassItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballRoleClassItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060411FA RID: 266746 RVA: 0x010B5478 File Offset: 0x010B3678
		[NullableContext(1)]
		public override void Refresh(IPinballRoleClassItemData data, bool isSelected, int gridIndex)
		{
			PinballRoleClassIconItemData data2 = new PinballRoleClassIconItemData
			{
				IconPath = data.IconPath,
				BgColor = data.BgColor
			};
			this.ClassIconItem.Refresh(data2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		}

		// Token: 0x040247A1 RID: 149409
		[Nullable(2)]
		private PinballRoleClassIconItem ClassIconItem;

		// Token: 0x0200C5D3 RID: 50643
		private enum EComponent
		{
			// Token: 0x0403CE46 RID: 249414
			ClassIconItem,
			// Token: 0x0403CE47 RID: 249415
			NameText
		}
	}
}
