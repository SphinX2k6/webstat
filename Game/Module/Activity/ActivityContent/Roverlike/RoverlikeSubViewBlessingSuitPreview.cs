using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D3 RID: 25555
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSubViewBlessingSuitPreview : RoverlikeActionSubViewBase
	{
		// Token: 0x17009DB4 RID: 40372
		// (get) Token: 0x060402A0 RID: 262816 RVA: 0x01071A5E File Offset: 0x0106FC5E
		public override ERoverActionSubViewType SubViewType
		{
			get
			{
				return ERoverActionSubViewType.BlessingSuitPreview;
			}
		}

		// Token: 0x17009DB5 RID: 40373
		// (get) Token: 0x060402A1 RID: 262817 RVA: 0x01071A61 File Offset: 0x0106FC61
		public override string ResourceId
		{
			get
			{
				return "UiItem_RoverlikeBlessingSetPreview";
			}
		}

		// Token: 0x060402A2 RID: 262818 RVA: 0x01071A68 File Offset: 0x0106FC68
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

		// Token: 0x060402A3 RID: 262819 RVA: 0x01071AD1 File Offset: 0x0106FCD1
		protected override void OnStart()
		{
			this.BlessingSuitLayout = new GenericLayout<RoverlikeBlessingSuitItem, IRoverlikeBlessingSuitData>(base.GetHorizontalLayout(0), new Func<RoverlikeBlessingSuitItem>(this.CreateBlessingSuitItem), null, false, true);
		}

		// Token: 0x060402A4 RID: 262820 RVA: 0x01071AF4 File Offset: 0x0106FCF4
		private RoverlikeBlessingSuitItem CreateBlessingSuitItem()
		{
			RoverlikeBlessingSuitItem roverlikeBlessingSuitItem = new RoverlikeBlessingSuitItem();
			roverlikeBlessingSuitItem.BindOnSuitClick(new Action<IRoverlikeBlessingSuitData>(this.OnSuitItemClick));
			return roverlikeBlessingSuitItem;
		}

		// Token: 0x060402A5 RID: 262821 RVA: 0x01071B10 File Offset: 0x0106FD10
		private void OnSuitItemClick(IRoverlikeBlessingSuitData data)
		{
			List<IRoverlikeBlessingSuitData> list = this.OpenParam as List<IRoverlikeBlessingSuitData>;
			if (list == null || list.Count == 0)
			{
				return;
			}
			int num = list.IndexOf(data);
			RoverlikeBlessingSuitSelectParam openParam = new RoverlikeBlessingSuitSelectParam
			{
				SuitDataList = list,
				SelectedIndex = ((num >= 0) ? num : 0)
			};
			ControllerBase<RoverlikeController>.Instance.OpenActionSubView(ERoverActionSubViewType.BlessingSuitSelect, openParam);
			ControllerBase<RoverlikeController>.Instance.FinishActionSubView(this.IncId);
		}

		// Token: 0x060402A6 RID: 262822 RVA: 0x01071B75 File Offset: 0x0106FD75
		private void RefreshBlessingSuitLayout(List<IRoverlikeBlessingSuitData> dataList)
		{
			this.BlessingSuitLayout.RefreshByData(dataList, new Action(this.OnBlessingSuitLayoutRefreshed), true);
		}

		// Token: 0x060402A7 RID: 262823 RVA: 0x01071B90 File Offset: 0x0106FD90
		private void OnBlessingSuitLayoutRefreshed()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoverlikeBlessingSuitPreview");
		}

		// Token: 0x060402A8 RID: 262824 RVA: 0x01071BA8 File Offset: 0x0106FDA8
		public override void OnRefreshSubView()
		{
			List<IRoverlikeBlessingSuitData> list = this.OpenParam as List<IRoverlikeBlessingSuitData>;
			if (list != null && list.Count > 0)
			{
				this.RefreshBlessingSuitLayout(list);
			}
		}

		// Token: 0x04023FF9 RID: 147449
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeBlessingSuitItem, IRoverlikeBlessingSuitData> BlessingSuitLayout;

		// Token: 0x0200C436 RID: 50230
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C66C RID: 247404
			public const int BlessingSuitLayout = 0;

			// Token: 0x0403C66D RID: 247405
			public const int BlessingSuitItem = 1;
		}
	}
}
