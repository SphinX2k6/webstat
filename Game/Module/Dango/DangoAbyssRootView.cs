using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DDA RID: 24026
	[NullableContext(1)]
	[Nullable(0)]
	public class DangoAbyssRootView : UiViewBase
	{
		// Token: 0x0603C7AC RID: 247724 RVA: 0x00F5C2BC File Offset: 0x00F5A4BC
		public DangoAbyssRootView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C7AD RID: 247725 RVA: 0x00F5C2D0 File Offset: 0x00F5A4D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C7AE RID: 247726 RVA: 0x00F5C3B8 File Offset: 0x00F5A5B8
		public override bool GetLoopAudioEventSwitch()
		{
			return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
		}

		// Token: 0x0603C7AF RID: 247727 RVA: 0x00F5C3C7 File Offset: 0x00F5A5C7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnAbyssRoleInfoUpdate));
		}

		// Token: 0x0603C7B0 RID: 247728 RVA: 0x00F5C3E5 File Offset: 0x00F5A5E5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnAbyssRoleInfoUpdate));
		}

		// Token: 0x0603C7B1 RID: 247729 RVA: 0x00F5C403 File Offset: 0x00F5A603
		protected override void OnHandleLoadScene()
		{
			ControllerBase<DangoAbyssController>.Instance.InitAbyssDangoObserver(0);
		}

		// Token: 0x0603C7B2 RID: 247730 RVA: 0x00F5C410 File Offset: 0x00F5A610
		protected override void OnHandleReleaseScene()
		{
			ControllerBase<DangoAbyssController>.Instance.DestroyAbyssDangoObserver(0);
		}

		// Token: 0x0603C7B3 RID: 247731 RVA: 0x00F5C41D File Offset: 0x00F5A61D
		private void OnAbyssRoleInfoUpdate()
		{
			this.InfoPanel.OnDangoInfoUpdate();
		}

		// Token: 0x0603C7B4 RID: 247732 RVA: 0x00F5C42A File Offset: 0x00F5A62A
		private DangoItem InitItem()
		{
			return new DangoItem
			{
				ViewModel = this.ViewModel
			};
		}

		// Token: 0x0603C7B5 RID: 247733 RVA: 0x00F5C440 File Offset: 0x00F5A640
		protected override UniTask OnBeforeStartAsync()
		{
			DangoAbyssRootView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssRootView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C7B6 RID: 247734 RVA: 0x00F5C484 File Offset: 0x00F5A684
		protected override void OnStart()
		{
			this.DLSSPastValue = UKismetSystemLibrary.GetConsoleVariableIntValue("r.NGX.DLSS.Enable");
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Enable 0", null);
			DangoRootViewData dangoRootViewData = this.OpenParam as DangoRootViewData;
			this.ActivityId = dangoRootViewData.ActivityId;
			int num = dangoRootViewData.DangoId;
			if (num == 0)
			{
				AbyssDangoRoleData[] allDangoList = this.GetActivityData().GetAllDangoList();
				if (allDangoList.Length != 0)
				{
					num = allDangoList[0].GetId();
				}
			}
			this.ViewModel.SetDangoId(num, false);
			this.Layout = new GenericLayout<DangoItem, DangoAbyssDefine.DangoListRoleData>(base.GetVerticalLayout(1), new Func<DangoItem>(this.InitItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x0603C7B7 RID: 247735 RVA: 0x00F5C52A File Offset: 0x00F5A72A
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C7B8 RID: 247736 RVA: 0x00F5C533 File Offset: 0x00F5A733
		private DangoAbyssActivityData GetActivityData()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as DangoAbyssActivityData;
		}

		// Token: 0x0603C7B9 RID: 247737 RVA: 0x00F5C54C File Offset: 0x00F5A74C
		protected override void OnBeforeShow()
		{
			this.ViewModel.Bind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
			if (this.GetActivityData().GetAllDangoList().Length == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YZY, "没有团子数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int dangoId = this.ViewModel.GetDangoId();
			AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId);
			this.OnSelectDango(dangoAbyssRoleData);
			this.RefreshLayout();
		}

		// Token: 0x0603C7BA RID: 247738 RVA: 0x00F5C5C3 File Offset: 0x00F5A7C3
		private void OnDataUpdate(EPluginEquipViewData key)
		{
			switch (key)
			{
			case EPluginEquipViewData.DangoId:
				this.OnDangoIdUpdate();
				return;
			case EPluginEquipViewData.SlotIndex:
				this.OnSlotIndexUpdate();
				break;
			case EPluginEquipViewData.PluginItem:
				break;
			default:
				return;
			}
		}

		// Token: 0x0603C7BB RID: 247739 RVA: 0x00F5C5E5 File Offset: 0x00F5A7E5
		protected override void OnAfterDestroy()
		{
			this.ViewModel.UnBind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
		}

		// Token: 0x0603C7BC RID: 247740 RVA: 0x00F5C600 File Offset: 0x00F5A800
		private void RefreshLayout()
		{
			List<DangoAbyssDefine.DangoListRoleData> list = new List<DangoAbyssDefine.DangoListRoleData>();
			foreach (AbyssDangoRoleData abyssDangoRoleData in this.GetActivityData().GetAllDangoList())
			{
				list.Add(new DangoAbyssDefine.DangoListRoleData
				{
					Data = abyssDangoRoleData,
					Id = abyssDangoRoleData.GetId(),
					OnClickCallBack = new Action<DangoAbyssDefine.DangoListRoleData>(this.OnItemClick)
				});
			}
			this.Layout.RefreshByData(list, null, false);
		}

		// Token: 0x0603C7BD RID: 247741 RVA: 0x00F5C676 File Offset: 0x00F5A876
		private void OnItemClick(DangoAbyssDefine.DangoListRoleData data)
		{
			this.OnSelectDango(data.Data);
		}

		// Token: 0x0603C7BE RID: 247742 RVA: 0x00F5C684 File Offset: 0x00F5A884
		[NullableContext(2)]
		private void OnSelectDango(AbyssDangoRoleData dangoData)
		{
			if (dangoData == null)
			{
				return;
			}
			int id = dangoData.GetId();
			this.ViewModel.SetDangoId(id, false);
			ControllerBase<DangoAbyssController>.Instance.RefreshAbyssDangoModel(0, id, "MonsterCase", null);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnAbyssPluginDangoSelect, id);
		}

		// Token: 0x0603C7BF RID: 247743 RVA: 0x00F5C6CC File Offset: 0x00F5A8CC
		private void OnDangoIdUpdate()
		{
			int dangoId = this.ViewModel.GetDangoId();
			ModelBase<DangoAbyssModel>.Instance.SetDangoHasCheck(dangoId);
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshAbyssDevelopRedDot);
			this.Layout.RefreshWithoutDataSync();
		}

		// Token: 0x0603C7C0 RID: 247744 RVA: 0x00F5C70B File Offset: 0x00F5A90B
		private void OnSlotIndexUpdate()
		{
			this.ViewModel.GetSlotIndex();
		}

		// Token: 0x0603C7C1 RID: 247745 RVA: 0x00F5C71C File Offset: 0x00F5A91C
		protected override void OnBeforeDestroy()
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.NGX.DLSS.Enable ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.DLSSPastValue);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}

		// Token: 0x04022016 RID: 139286
		private int ActivityId;

		// Token: 0x04022017 RID: 139287
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DangoItem, DangoAbyssDefine.DangoListRoleData> Layout;

		// Token: 0x04022018 RID: 139288
		[Nullable(2)]
		private DangoAbyssRoleInfoItem InfoPanel;

		// Token: 0x04022019 RID: 139289
		private readonly PluginEquipViewModel ViewModel = new PluginEquipViewModel();

		// Token: 0x0402201A RID: 139290
		private int DLSSPastValue;

		// Token: 0x0402201B RID: 139291
		private const int MODELINDEX = 0;

		// Token: 0x0200BE32 RID: 48690
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403A8DD RID: 239837
			public const int BtnClose = 0;

			// Token: 0x0403A8DE RID: 239838
			public const int DangoScrollView = 1;

			// Token: 0x0403A8DF RID: 239839
			public const int DangoItem = 2;

			// Token: 0x0403A8E0 RID: 239840
			public const int AttributePanel = 3;
		}
	}
}
