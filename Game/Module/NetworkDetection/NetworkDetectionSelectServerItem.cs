using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C7 RID: 22215
	[NullableContext(1)]
	[Nullable(0)]
	public class NetworkDetectionSelectServerItem : UiPanelBase, IDynamicScrollItem<ILoginServersData>
	{
		// Token: 0x060388A2 RID: 231586 RVA: 0x00E52ABB File Offset: 0x00E50CBB
		public AUIBaseActor GetUsingItem(ILoginServersData data)
		{
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x060388A3 RID: 231587 RVA: 0x00E52AD0 File Offset: 0x00E50CD0
		public UniTask Init(UUIItem actor)
		{
			NetworkDetectionSelectServerItem.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<NetworkDetectionSelectServerItem.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x060388A4 RID: 231588 RVA: 0x00E52B1B File Offset: 0x00E50D1B
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x060388A5 RID: 231589 RVA: 0x00E52B24 File Offset: 0x00E50D24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleComfirmBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060388A6 RID: 231590 RVA: 0x00E52C6F File Offset: 0x00E50E6F
		protected override void OnStart()
		{
			base.GetItem(7).SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x060388A7 RID: 231591 RVA: 0x00E52C8B File Offset: 0x00E50E8B
		private void OnExtendToggleComfirmBtn(EToggleState state)
		{
			if (this.Data != null)
			{
				ModelBase<NetworkDetectionModel>.Instance.CurrentUiSelectSeverData = this.Data;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnNetworkDetectionSelectServerItem);
			}
		}

		// Token: 0x060388A8 RID: 231592 RVA: 0x00E52CB2 File Offset: 0x00E50EB2
		private void OnSelectServerItem()
		{
			this.RefreshToggleState();
		}

		// Token: 0x060388A9 RID: 231593 RVA: 0x00E52CBA File Offset: 0x00E50EBA
		private void RefreshToggleState()
		{
			base.GetExtendToggle(0).SetToggleState((ModelBase<NetworkDetectionModel>.Instance.CurrentUiSelectSeverData == this.Data) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060388AA RID: 231594 RVA: 0x00E52CE2 File Offset: 0x00E50EE2
		public void Update(ILoginServersData data, int index)
		{
			this.Data = data;
			base.GetText(1).SetText(data.name, true);
			this.RefreshToggleState();
		}

		// Token: 0x060388AB RID: 231595 RVA: 0x00E52D04 File Offset: 0x00E50F04
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNetworkDetectionSelectServerItem, new Action(this.OnSelectServerItem));
			this.Data = null;
		}

		// Token: 0x0402044A RID: 132170
		[Nullable(2)]
		private ILoginServersData Data;

		// Token: 0x0200B733 RID: 46899
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04038AAA RID: 232106
			ComfirmBtn,
			// Token: 0x04038AAB RID: 232107
			ServerName,
			// Token: 0x04038AAC RID: 232108
			ServerInfo,
			// Token: 0x04038AAD RID: 232109
			Gou,
			// Token: 0x04038AAE RID: 232110
			RoleNode,
			// Token: 0x04038AAF RID: 232111
			RoleLevel,
			// Token: 0x04038AB0 RID: 232112
			SuggestLabel = 7
		}
	}
}
