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

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A0D RID: 23053
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginServerItem : UiPanelBase, IDynamicScrollItem<ILoginServersData>
	{
		// Token: 0x0603A606 RID: 239110 RVA: 0x00ECD3A0 File Offset: 0x00ECB5A0
		public AUIBaseActor GetUsingItem(ILoginServersData data)
		{
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x0603A607 RID: 239111 RVA: 0x00ECD3B4 File Offset: 0x00ECB5B4
		public UniTask Init(UUIItem actor)
		{
			LoginServerItem.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<LoginServerItem.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603A608 RID: 239112 RVA: 0x00ECD3FF File Offset: 0x00ECB5FF
		public void ClearItem()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectServerItem, new Action(this.OnSelectServerItem));
			base.Destroy(null);
		}

		// Token: 0x0603A609 RID: 239113 RVA: 0x00ECD424 File Offset: 0x00ECB624
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

		// Token: 0x0603A60A RID: 239114 RVA: 0x00ECD56F File Offset: 0x00ECB76F
		private void OnExtendToggleComfirmBtn(EToggleState state)
		{
			if (this.Data != null)
			{
				ModelBase<LoginServerModel>.Instance.CurrentUiSelectSeverData = this.Data;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectServerItem);
			}
		}

		// Token: 0x0603A60B RID: 239115 RVA: 0x00ECD596 File Offset: 0x00ECB796
		private void OnSelectServerItem()
		{
			this.RefreshToggleState();
		}

		// Token: 0x0603A60C RID: 239116 RVA: 0x00ECD5A0 File Offset: 0x00ECB7A0
		private void RefreshToggleState()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				bool flag = ModelBase<LoginServerModel>.Instance.CurrentUiSelectSeverData == this.Data;
				extendToggle.SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x0603A60D RID: 239117 RVA: 0x00ECD5DC File Offset: 0x00ECB7DC
		public void Update(ILoginServersData data, int index)
		{
			this.Data = data;
			this.Region = data.Region;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(data.name, true);
			}
			bool uiactive = ModelBase<LoginServerModel>.Instance.OnBeginSuggestServerData == this.Data;
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			this.UpdatePlayerInfo();
			this.RefreshToggleState();
		}

		// Token: 0x0603A60E RID: 239118 RVA: 0x00ECD648 File Offset: 0x00ECB848
		public void UpdatePlayerInfo()
		{
			SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
			string sdkUid = ((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "";
			int loginLevel = ModelBase<LoginServerModel>.Instance.GetLoginLevel(sdkUid, this.Region);
			bool flag = loginLevel > 0;
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				UUIText text = base.GetText(5);
				if (text != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalText(text, "OverSeaServerLv", new <>z__ReadOnlySingleElementList<object>(loginLevel));
				}
			}
		}

		// Token: 0x0603A60F RID: 239119 RVA: 0x00ECD6CA File Offset: 0x00ECB8CA
		protected override void OnBeforeDestroy()
		{
			this.Data = null;
		}

		// Token: 0x040210F6 RID: 135414
		[Nullable(2)]
		private ILoginServersData Data;

		// Token: 0x040210F7 RID: 135415
		private string Region = "";
	}
}
