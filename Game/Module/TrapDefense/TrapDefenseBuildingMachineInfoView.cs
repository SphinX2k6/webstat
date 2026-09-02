using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E64 RID: 20068
	public class TrapDefenseBuildingMachineInfoView : UiViewBase
	{
		// Token: 0x06033DE8 RID: 212456 RVA: 0x00CF9FF0 File Offset: 0x00CF81F0
		[NullableContext(1)]
		public TrapDefenseBuildingMachineInfoView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033DE9 RID: 212457 RVA: 0x00CF9FFC File Offset: 0x00CF81FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedMask));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033DEA RID: 212458 RVA: 0x00CFA0A4 File Offset: 0x00CF82A4
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingMachineInfoView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingMachineInfoView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033DEB RID: 212459 RVA: 0x00CFA0E7 File Offset: 0x00CF82E7
		protected override void OnBeforeDestroy()
		{
			this.InfoItem = null;
		}

		// Token: 0x06033DEC RID: 212460 RVA: 0x00CFA0F0 File Offset: 0x00CF82F0
		private void OnClickedMask()
		{
			base.CloseMe(null);
		}

		// Token: 0x0401E002 RID: 122882
		[Nullable(2)]
		protected TrapDefenseBuildingDevelopDetailInfoItem InfoItem;

		// Token: 0x0200AE19 RID: 44569
		internal class EMainDefine
		{
			// Token: 0x04036115 RID: 221461
			public const int BtnMask = 0;

			// Token: 0x04036116 RID: 221462
			public const int BuildingItem = 1;
		}
	}
}
